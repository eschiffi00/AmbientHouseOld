<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ejemplo.aspx.cs" Inherits="AmbientHouse.Inicio.ejemplo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
  
    <style type="text/css">
        ul {
            margin-left: 20px;
            margin-right: 20px;
            margin-top: 10px;
            columns: 1;
            font-family: Dosis;
            font-size: 15px;
            line-height: 25px;
            text-align: justify;
        }

        p {
            margin-left: 20px;
            margin-right: 20px;
            margin-top: 10px;
            line-height: 25px;
        }

        body {
            /*background: rgb(176,174,238);
            background: linear-gradient(90deg, rgba(176,174,238,1) 0%, rgba(29,30,31,1) 100%);*/
        }

        .Pagina {
            margin-left: auto;
            margin-right: auto;
            margin-top: 10px;
            /*background-color:#e4e4e4;*/
            /*background-image:url("../Content/Imagenes/paltas-hoja02-246x311px.png");
            background-repeat: no-repeat;
            background-position:right top;*/
            width: 50%;
            border-color: gray;
            border-width: 2px;
            border-style: outset;
            border-radius: 5px;
            /*box-shadow:10px 10px;*/
            min-height: 400px;
            line-height: 25px;
        }

        div img {
            position: absolute;
            top: 50px;
            left: 50px;
        }

        .Caratula {
            margin-left: auto;
            margin-right: auto;
            margin-top: 10px;
            /*background-color:#e4e4e4;*/
            background-image: url("../Content/Imagenes/logo-231x93px.png");
            background-repeat: no-repeat;
            background-position: center;
            /*background-image:url("../Content/Imagenes/cucharas-portada-251x57px.png");
            background-repeat: no-repeat;
            background-position:bottom;*/
            width: 50%;
            border-color: gray;
            border-width: 2px;
            border-style: outset;
            border-radius: 5px;
            /*box-shadow:10px 10px;*/
            min-height: 300px;
        }

        .footerCaratula {
            margin-left: auto;
            margin-right: auto;
            margin-top: 10px;
            background-image: url("../Content/Imagenes/cucharas-portada-251x57px.png");
            background-repeat: no-repeat;
            background-position: center;
            color: red;
        }

        .header {
            margin-left: 20px;
            margin-right: 20px;
            margin-top: 10px;
            font-family: Dosis;
            color: black;
            text-transform: uppercase;
        }

        .title {
            margin-left: 20px;
            margin-right: 20px;
            margin-top: 10px;
            font-family: Dosis;
            color: black;
            /*color: #777777;*/
            text-transform: uppercase;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                DomainAmbientHouse.Servicios.AdministrativasServicios administrativas = new DomainAmbientHouse.Servicios.AdministrativasServicios();

                int TipoCateringId = 1;

                DomainAmbientHouse.Entidades.TipoCatering TipoCatering = administrativas.BuscarTipoCatering(TipoCateringId);

                Response.Write("<div class=\"Caratula\">");
                Response.Write("<div class=\"header\">");
                Response.Write(TipoCatering.Descripcion);
                Response.Write("</div>");
                Response.Write("<h5 class=\"title\">");
                Response.Write("");
                Response.Write("</h5>");
                Response.Write("<div class=\"footerCaratula\">");
                Response.Write("</div>");
                Response.Write("</div>");



                List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = administrativas.ObtenerTiemposPorTipoCatering(TipoCateringId);

                foreach (var item in ListTiempos)
                {


                    string imagen = "";
                    if (item.Descripcion.Contains("Recepción"))
                    { imagen = "entradas.png"; }
                    else if (item.Descripcion.Contains("Plato Principal"))
                    { imagen = "plato-principal.png"; }
                    else if (item.Descripcion.Contains("Postre"))
                    { imagen = "postres.png"; }
                    else if (item.Descripcion.Contains("Mesa dulce"))
                    { imagen = "mesa-dulce.png"; }
                    else if (item.Descripcion.Contains("Break 1"))
                    { imagen = "frutas-secas.png"; }
                    else if (item.Descripcion.Contains("Break 2"))
                    { imagen = "coffe.png"; }
                    else if (item.Descripcion.Contains("Brindis"))
                    { imagen = "brindis.png"; }
                    else if (item.Descripcion.Contains("Fin de fiesta"))
                    { imagen = ""; }
                    else
                    { imagen = "todoelevento.png"; }

                    string style = " margin-left: auto; " +
                                    " margin-right: auto;" +
                                    " margin-top: 10px;" +
                                    " /*background-color:#e4e4e4;*/ " +
                                    " background-image:url(\"../Content/Imagenes/Experiencias/" + imagen + "\");" +
                                    " background-repeat: no-repeat;" +
                                    " background-position:right top;" +
                                    " width: 50%;" +
                                    " border-color: gray;" +
                                    " border-width: 2px;" +
                                    " border-style: outset;" +
                                    " border-radius: 5px;" +
                                    " /*box-shadow:10px 10px;*/" +
                                    " min-height:600px;" +
                                    " line-height :25px;";

                    Response.Write("<div style=\'" + style + "\'>");

                    Response.Write("<div class=\"header\">");
                    //Response.Write("<div id=\"carouselExampleSlidesOnly\" class=\"carousel slide\" data-ride=\"carousel\">");
                    //Response.Write("<div class=\"carousel-inner\">");
                    //Response.Write("<div class=\"carousel-item active\">");
                    //Response.Write("<img src=\"../Content/Imagenes/bocados.jpg\">");
                    //Response.Write("</div>");
                    //Response.Write("</div>");
                    //Response.Write("</div>");
                    Response.Write(item.Descripcion);
                    Response.Write("</div>");

                    List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = administrativas.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                    foreach (var itemProducto in ListProductos)
                    {

                        Response.Write("<h5 class=\"title\">");
                        Response.Write(itemProducto.Descripcion);
                        Response.Write("</h5>");

                        List<DomainAmbientHouse.Entidades.Items> ListProductoItems = administrativas.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);

                        //Response.Write("<p class=\"card-text\">");
                        Response.Write("<ul>");
                        foreach (var itemProductosItems in ListProductoItems)
                        {
                            Response.Write(itemProductosItems.Detalle + "</br>");
                        }
                        Response.Write("</ul>");
                        //Response.Write("</p>");

                    }

                    List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = administrativas.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                    foreach (var itemCategorias in ListCategorias)
                    {
                        Response.Write("<h5 class=\"title\">");
                        Response.Write(itemCategorias.Descripcion);
                        Response.Write("</h5>");

                        List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = administrativas.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                        //Response.Write("<p class=\"card-text\">");
                        Response.Write("<ul>");
                        foreach (var itemCatItems in ListCategoriaItems)
                        {
                            Response.Write(itemCatItems.Detalle + "</br>");
                        }
                        Response.Write("</ul>");
                        //Response.Write("</p>");

                    }

                    List<DomainAmbientHouse.Entidades.Items> ListItems = administrativas.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                    //Response.Write("<p class=\"card-text\">");
                    Response.Write("<ul>");
                    foreach (var itemItems in ListItems)
                    {
                        Response.Write(itemItems.Detalle + "</br>");
                    }
                    Response.Write("</ul>");
                    //Response.Write("</p>");

                    //string imagenFooter = "redes-136x21px.png";

                    //string styleFooter = " margin-left: auto; " +
                    //             " margin-right: auto;" +
                    //             " margin-top: 10px;" +
                    //             " /*background-color:#e4e4e4;*/ " +
                    //             " background-image:url(\"../Content/Imagenes/" + imagenFooter + "\");" +
                    //             " background-repeat: no-repeat;" +
                    //             " background-position:right bottom;" +
                    //             " width: 50%;" +
                    //             " border-color: gray;" +
                    //             " border-width: 2px;" +
                    //             " border-style: outset;" +
                    //             " border-radius: 5px;" +
                    //             " /*box-shadow:10px 10px;*/" +
                    //             " line-height :25px;";

                    string styleFooter = "";

                    Response.Write("<div style=\'" + styleFooter + "\'>");
                    Response.Write("");
                    Response.Write("</div>");

                    Response.Write("</div>");
                    //Final CARD
                }


                Response.Write("<div class=\"Pagina\">");
                Response.Write("<h5 class=\"title\">");
                Response.Write("Por favor considerar:");
                Response.Write("</h5>");
                Response.Write("<p>");
                Response.Write("Si la experiencia del servicio contratado incluyera islas, se contemplará 1 isla cada 50 personas, sumándose la próxima isla cuando superen 25 invitados más.</br>" +
                                "La variedad de las islas respetarán el orden de aparición del menú contratado. En caso de desear intercambiar una isla por otra, dicha modificación tendrá costo adicional.</br>" +
                                "Los platos principales y postres son uno a elección.</br>" +
                                "La descripción del servicio es orientativa.</br>" +
                                "Los productos podrán ser modificados y/o reemplazos por ítems similares, " +
                                "dependiendo la disponibilidad de insumos o materia prima del mercado. ");
                Response.Write("</p>");
                Response.Write("</div>");
            
            %>
        </div>
    </form>

    <script src="../Boostrap4/js/bootstrap.min.js"></script>
    <script src="../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../Boostrap4/js/popper.min.js"></script>
</body>
</html>
