using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace AmbientHouse
{
    public partial class RepExperiencias : System.Web.UI.Page
    {
        private int TipoCateringId
        {
            get
            {
                return Int32.Parse(Session["TipoCateringId"].ToString());
            }
            set
            {
                Session["TipoCateringId"] = value;
            }
        }

        private int EventoId
        {
            get
            {
                return Int32.Parse(Session["EventoId"].ToString());
            }
            set
            {
                Session["EventoId"] = value;
            }
        }

        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(Session["PresupuestoId"].ToString());
            }
            set
            {
                Session["PresupuestoId"] = value;
            }
        }

        AdministrativasServicios servicios = new AdministrativasServicios();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (TipoCateringId > 0)
                {
                    CargarDatos();

                    List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);

                    //HtmlHelpers html = new HtmlHelpers();

                    //HtmlString str = html.RetornarLi("Prueba", ListTiempos);

                    //System.IO.File.Create("C://Users//Diego//Index.html");

                    foreach (var item in ListTiempos)
                    {
                        HtmlTableRow filaTiempo = new HtmlTableRow();


                        HtmlTableCell celda1Tiempo = new HtmlTableCell();
                        celda1Tiempo.InnerText = item.Descripcion.ToUpper();
                        celda1Tiempo.Attributes.Add("class", "Titulo");
                        //celda1Tiempo.Attributes.Add("style", "font-weight: bold; width: 15%; margin:20px 30px; font-family: sans-serif;");

                        //HtmlTableCell celda2Tiempo = new HtmlTableCell();
                        //celda2Tiempo.InnerText = "";

                        //HtmlTableCell celda3Tiempo = new HtmlTableCell();
                        //celda3Tiempo.InnerText = "";

                        //HtmlTableCell celda4Tiempo = new HtmlTableCell();
                        //celda4Tiempo.InnerText = "";

                        filaTiempo.Cells.Add(celda1Tiempo);
                        //filaTiempo.Cells.Add(celda2Tiempo);
                        //filaTiempo.Cells.Add(celda3Tiempo);
                        //filaTiempo.Cells.Add(celda4Tiempo);
                        // Añadimos las celdas a la tabla
                        Experiencias.Rows.Add(filaTiempo);



                        List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                        //HtmlTableRow filaProductoTitulo = new HtmlTableRow();

                        //HtmlTableCell clProductosIDTitulo = new HtmlTableCell();
                        //clProductosIDTitulo.InnerText = ListProductos.FirstOrDefault().Titulo;

                        //HtmlTableCell clProductosItemsTitulo = new HtmlTableCell();
                        //clProductosItemsTitulo.InnerText = "";

                        //filaProductoTitulo.Cells.Add(clProductosIDTitulo);
                        //filaProductoTitulo.Cells.Add(clProductosItemsTitulo);

                        //Experiencias.Rows.Add(filaProductoTitulo);

                        string Titulo = "";

                        var productoTitulo = "<p>";
                        foreach (var itemProducto in ListProductos)
                        {

                            HtmlTableRow filaProducto = new HtmlTableRow();

                            //HtmlTableCell celda1ProductosCatering = new HtmlTableCell();
                            //celda1ProductosCatering.InnerText = "";

                            //HtmlTableCell celda1ProductosCatering = new HtmlTableCell();



                            //if (Titulo != itemProducto.Titulo)
                            //{
                            //    celda1ProductosCatering.InnerText = itemProducto.Titulo;
                            //    //celda2ProductosCatering.Attributes.Add("style", "font-weight: bold;");
                            //    celda1ProductosCatering.Attributes.Add("class", "SubTitulo");
                            //    Titulo = itemProducto.Titulo;
                            //}
                            //else
                            //    celda1ProductosCatering.InnerText = "";

                            productoTitulo = productoTitulo + itemProducto.Descripcion;

                            HtmlTableCell celda1ProductosCatering = new HtmlTableCell();
                            celda1ProductosCatering.InnerText = itemProducto.Descripcion;
                            //celda1ProductosCatering.InnerHtml = productoTitulo + "</p>";

                            celda1ProductosCatering.Attributes.Add("class", "SubTitulo");



                            //HtmlTableCell celda4ProductosCatering = new HtmlTableCell();
                            //celda4ProductosCatering.InnerText = "";

                            filaProducto.Cells.Add(celda1ProductosCatering);
                            //filaProducto.Cells.Add(celda2ProductosCatering);
                            //filaProducto.Cells.Add(celda3ProductosCatering);
                            //filaProducto.Cells.Add(celda4ProductosCatering);


                            Experiencias.Rows.Add(filaProducto);

                            List<DomainAmbientHouse.Entidades.Items> ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);


                            //var resultProd = "<ul>";
                            foreach (var itemProductosItems in ListProductoItems)
                            {
                                HtmlTableRow filaProductoItems = new HtmlTableRow();

                                //HtmlTableCell celda1ProductosCateringItems = new HtmlTableCell();
                                //celda1ProductosCateringItems.InnerText = "";

                                //HtmlTableCell celda2ProductosCateringItems = new HtmlTableCell();
                                //celda2ProductosCateringItems.InnerText = "";

                                //HtmlTableCell celda3ProductosCateringItems = new HtmlTableCell();
                                //celda3ProductosCateringItems.InnerText = "";

                                HtmlTableCell celda1ProductosCateringItems = new HtmlTableCell();
                                celda1ProductosCateringItems.InnerText = itemProductosItems.Detalle;
                                celda1ProductosCateringItems.Attributes.Add("class", "Items");

                                filaProductoItems.Cells.Add(celda1ProductosCateringItems);
                                //filaProductoItems.Cells.Add(celda2ProductosCateringItems);
                                //filaProductoItems.Cells.Add(celda3ProductosCateringItems);
                                //filaProductoItems.Cells.Add(celda4ProductosCateringItems);

                                Experiencias.Rows.Add(filaProductoItems);

                                //resultProd = resultProd + string.Format("<li>{0}</li>", itemProductosItems.Detalle);
                            }

                            //HtmlTableRow filaProductoItems = new HtmlTableRow();
                            //HtmlTableCell celda1ProductosCateringItems = new HtmlTableCell();


                            //celda1ProductosCateringItems.InnerHtml = resultProd;
                            //celda1ProductosCateringItems.Attributes.Add("class", "Items");

                            //filaProductoItems.Cells.Add(celda1ProductosCateringItems);
                            //Experiencias.Rows.Add(filaProductoItems);

                        }


                        List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                        foreach (var itemCategorias in ListCategorias)
                        {
                            HtmlTableRow filaCategorias = new HtmlTableRow();


                            //HtmlTableCell celda1CategoriasItems = new HtmlTableCell();
                            //celda1CategoriasItems.InnerText = "";

                            HtmlTableCell celda1CategoriasItems = new HtmlTableCell();
                            celda1CategoriasItems.InnerText = itemCategorias.CategoriaItemPadreDescripcion;
                            celda1CategoriasItems.Attributes.Add("class", "SubTitulo");

                            //HtmlTableCell celda3CategoriasItems = new HtmlTableCell();
                            //celda3CategoriasItems.InnerText = "";

                            //HtmlTableCell celda4CategoriasItems = new HtmlTableCell();
                            //celda4CategoriasItems.InnerText = "";

                            filaCategorias.Cells.Add(celda1CategoriasItems);
                            //filaCategorias.Cells.Add(celda2CategoriasItems);
                            //filaCategorias.Cells.Add(celda3CategoriasItems);
                            //filaCategorias.Cells.Add(celda4CategoriasItems);

                            Experiencias.Rows.Add(filaCategorias);


                            List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                            //var resultCat = "<ul>";
                            foreach (var itemCatItems in ListCategoriaItems)
                            {

                                //resultCat = resultCat + string.Format("<li>{0}</li>", itemCatItems.Detalle);

                                HtmlTableRow filaCategoriasItems = new HtmlTableRow();


                                //HtmlTableCell celda1ItemsCategorias = new HtmlTableCell();
                                //celda1ItemsCategorias.InnerText = "";

                                //HtmlTableCell celda2ItemsCategorias = new HtmlTableCell();
                                //celda2ItemsCategorias.InnerText = "";

                                HtmlTableCell celda1ItemsCategorias = new HtmlTableCell();
                                celda1ItemsCategorias.InnerText = itemCatItems.Detalle;
                                celda1ItemsCategorias.Attributes.Add("class", "Items");
                                //HtmlTableCell celda4ItemsCategorias = new HtmlTableCell();
                                //celda4ItemsCategorias.InnerText = "";

                                filaCategoriasItems.Cells.Add(celda1ItemsCategorias);
                                //filaCategoriasItems.Cells.Add(celda2ItemsCategorias);
                                //filaCategoriasItems.Cells.Add(celda3ItemsCategorias);
                                //filaCategoriasItems.Cells.Add(celda4ItemsCategorias);

                                Experiencias.Rows.Add(filaCategoriasItems);
                            }
                            //HtmlTableRow filaCategoriasItems = new HtmlTableRow();
                            //HtmlTableCell celda1ItemsCategorias = new HtmlTableCell();

                            //celda1ItemsCategorias.InnerHtml = resultCat;

                            //filaCategoriasItems.Cells.Add(celda1ItemsCategorias);

                            //Experiencias.Rows.Add(filaCategoriasItems);
                        }



                        List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                        //var result = "<ul>";


                        //result = result + "</ul>";
                        foreach (var itemItems in ListItems)
                        {

                            HtmlTableRow filaItems = new HtmlTableRow();

                            //HtmlTableCell celda1Items = new HtmlTableCell();
                            //celda1Items.InnerText = "";

                            //HtmlTableCell celda2Items = new HtmlTableCell();
                            //celda2Items.InnerText = "";

                            //HtmlTableCell celda3Items = new HtmlTableCell();
                            //celda3Items.InnerText = "";

                            //result = result + string.Format("<li>{0}</li>", itemItems.Detalle);

                            HtmlTableCell celda1Items = new HtmlTableCell();
                            celda1Items.InnerText = itemItems.Detalle;
                            celda1Items.Attributes.Add("class", "Items");

                            filaItems.Cells.Add(celda1Items);
                            //filaItems.Cells.Add(celda2Items);
                            //filaItems.Cells.Add(celda3Items);
                            //filaItems.Cells.Add(celda4Items);

                            Experiencias.Rows.Add(filaItems);

                        }

                        //HtmlTableRow filaItems = new HtmlTableRow();
                        //HtmlTableCell celda1Items = new HtmlTableCell();

                        //celda1Items.InnerHtml = result;

                        //filaItems.Cells.Add(celda1Items);
                        //Experiencias.Rows.Add(filaItems);
                    }
                }
            }
        }

        public void CargarDatos()
        {
            DomainAmbientHouse.Entidades.TipoCatering tc = servicios.BuscarTipoCatering(TipoCateringId);

            //LabelExperiencia.Text = tc.Descripcion.ToUpper();

            LabelNroEvento.Text = EventoId.ToString().PadLeft(8, '0');

            LabelNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');


        }
    }
}