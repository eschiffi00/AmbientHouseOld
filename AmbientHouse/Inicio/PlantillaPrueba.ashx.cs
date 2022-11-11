using DomainAmbientHouse.Servicios;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio
{
    /// <summary>
    /// Summary description for PlantillaPrueba
    /// </summary>
    public class PlantillaPrueba : IHttpHandler, IRequiresSessionState
    {
        private int TipoCateringId
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Session["TipoCateringId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["TipoCateringId"] = value;
            }
        }

        private List<string> Salida
        {
            get
            {
                return HttpContext.Current.Session["Salida"] as List<string>;
            }
            set
            {
                HttpContext.Current.Session["Salida"] = value;
            }
        }

        AdministrativasServicios servicios = new AdministrativasServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();

        public void ProcessRequest(HttpContext context)
        {
            Salida = new List<string>();

            string style = " margin-left: auto; " +
                                  " margin-right: auto;" +
                                  " margin-top: 10px;";

            string html = "<div style=\'" + style + "\'>";

            if (TipoCateringId > 0)
            {
                List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);

                foreach (var item in ListTiempos)
                {
                    TextBox textoItem = new TextBox();
                    //textoItem.Attributes.Add("style","font-size: 12px;font-family: Dosis-Medium;");
                    textoItem.Text = item.Descripcion.ToUpper();
                    textoItem.Font.Name = "Dosis";


                    html = html + "<h5 style=\'margin-left: 20px; margin-right: 20px; margin-top: 10px; font-family: Dosis; color: black;text-transform: uppercase;\'>";
                    html = html + textoItem.Text + "</h5> </br>";


                    //Salida.Add("<div style=\'font-size: 12px;font-family: Dosis;margin-left: 10px;\'>&nbsp;&nbsp;&nbsp;" + textoItem.Text + "</div>");

                    List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                    foreach (var itemProducto in ListProductos)
                    {
                        TextBox textoProducto = new TextBox();
                        //    //textoProducto.Attributes.Add("style", "font-size: 12px;font-family: Dosis-Medium;");
                        textoProducto.Text = itemProducto.Descripcion.ToUpper();
                        //    textoProducto.Font.Name = "Dosis";
                        //    Salida.Add("<div style=\'font-size: 12px;font-family: Dosis;margin-left: 30px;\'>&nbsp;&nbsp;&nbsp;" + textoProducto.Text + "</div>");

                        html = html + "<h5 style=\'margin-left: 20px; margin-right: 20px; margin-top: 10px; font-family: Dosis; color: black;text-transform: uppercase;\'>" + textoProducto.Text + "</h5> </br>";
                        html = html + "<ul style=\' margin-left: 20px;  margin-right: 20px;  margin-top: 10px; font-size: 12px;font-family: Dosis; line-height: 25px;text-align: justify;\'>";


                        List<DomainAmbientHouse.Entidades.Items> ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);
                        foreach (var itemProductosItems in ListProductoItems)
                        {
                            TextBox textoProductoItem = new TextBox();
                            //textoProductoItem.Attributes.Add("style", "font-family: Dosis-ExtraLight;");
                            textoProductoItem.Text = itemProductosItems.Detalle;

                            html = html + "<li>" + textoProductoItem.Text + "</li>";
                            //        Salida.Add("<div style=\'font-size: 10px; font-family: Dosis; 8px;margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoProductoItem.Text + "</div>");
                        }
                        html = html + "</ul> </br>";

                    }

                    //List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                    //foreach (var itemCategorias in ListCategorias)
                    //{
                    //    TextBox textoCategorias = new TextBox();
                    //    //textoCategorias.Attributes.Add("style", "font-size: 12px;font-family: Dosis-Medium;");
                    //    textoCategorias.Text = itemCategorias.Descripcion.ToUpper();
                    //    textoCategorias.Font.Name = "Dosis";

                    //    Salida.Add("<div style=\'font-size: 12px;font-family: Dosis;margin-left: 30px;\'>&nbsp;&nbsp;&nbsp;" + textoCategorias.Text + "</div>");

                    //    List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                    //    foreach (var itemCatItems in ListCategoriaItems)
                    //    {
                    //        TextBox textoCatItem = new TextBox();
                    //        textoCatItem.Attributes.Add("style", "font-family: Dosis;");
                    //        textoCatItem.Text = itemCatItems.Detalle;

                    //        Salida.Add("<div style=\'font-size: 10px;font-family: Dosis;margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoCatItem.Text + "</div>");
                    //    }

                    //}


                    //List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                    //foreach (var itemItems in ListItems)
                    //{
                    //    TextBox textoItems = new TextBox();
                    //    textoItems.Attributes.Add("style", "font-family: Dosis;");
                    //    textoItems.Text = itemItems.Detalle;

                    //    Salida.Add("<div style=\'font-size: 10px;font-family: Dosis; margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoItems.Text + "</div>");
                    //}
                }


            }

            html = html + "</div>";

            string pdfTemplate;


            pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\UNAHOJA.pdf";

            //if (Salida.Count() <= 50)
            //    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 4 hojas.pdf";
            //else if (Salida.Count() <= 75)
            //    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 5 hojas.pdf";
            //else if (Salida.Count() <= 100)
            //    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 6 hojas.pdf";
            //else if (Salida.Count() <= 125)
            //    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 7 hojas.pdf";
            //else if (Salida.Count() <= 150)
            //    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 8 hojas.pdf";
            //else
            //    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 9 hojas.pdf";


            string newFile = "TipoCatering.pdf";
            MemoryStream _MemoryStream = new MemoryStream();
            PdfReader reader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(reader, _MemoryStream);
            Dictionary<string, string> infoOriginal = reader.Info;
            Dictionary<string, string> info = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> s in infoOriginal)
            {
                info[s.Key] = string.Empty;  //con esto elimino la metadata del pdf
            }

            info["Application"] = string.Empty;
            info["Producer"] = string.Empty;
            info["ModDate "] = string.Empty;
            pdfStamper.MoreInfo = info;
            AcroFields pdfFormFields = pdfStamper.AcroFields;

            int contador = 0;

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font bold = FontFactory.GetFont(FontFactory.COURIER, 12f, iTextSharp.text.Font.BOLD);

            //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            //iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);


            //foreach (var sal in Salida)
            //{
            //    contador = contador + 1;

            string htmlText = html;
            //string htmlText = sal;


            IList<AcroFields.FieldPosition> pos = pdfFormFields.GetFieldPositions("Campo1");
            //IList<AcroFields.FieldPosition> pos = pdfFormFields.GetFieldPositions("Campo" + contador.ToString());
            //Field1 is the name of the field in the PDF Template you are trying to fill/overlay
            AddHTMLToContent(htmlText, pdfStamper.GetOverContent(pos[0].page), pos);
            //stamp is the PdfStamper in this example

            //pdfFormFields.SetField("Campo" + contador.ToString(), Convert.ToString(sal));
            //}


            DomainAmbientHouse.Entidades.TipoCatering tipo = servicios.BuscarTipoCatering(TipoCateringId);


            pdfFormFields.SetField("Experiencia", Convert.ToString(tipo.Descripcion));

            pdfStamper.FormFlattening = true;
            pdfStamper.Close();

            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("content-disposition", "inline; filename=" + newFile);

            context.Response.BinaryWrite(_MemoryStream.ToArray());
            context.Response.End();

            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        public void AddHTMLToContent(String htmlText, PdfContentByte contentBtye, IList<AcroFields.FieldPosition> pos)
        {
            Paragraph par = new Paragraph();
            ColumnText c1 = new ColumnText(contentBtye);
            try
            {
                List<IElement> elements = HTMLWorker.ParseToList(new StringReader(htmlText), null);
                foreach (IElement element in elements)
                {
                    par.Add(element);
                }

                c1.AddElement(par);
                c1.SetSimpleColumn(pos[0].position.Left, pos[0].position.Bottom, pos[0].position.Right, pos[0].position.Top);
                c1.Go(); //very important!!!
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}