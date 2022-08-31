using DomainAmbientHouse.Servicios;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AmbientHouse.Presupuestos
{
    /// <summary>
    /// Summary description for CateringExperiencias
    /// </summary>
    public class CateringExperiencias : IHttpHandler, IRequiresSessionState
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

        private int EventoId
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Session["EventoId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["EventoId"] = value;
            }
        }

        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Session["PresupuestoId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["PresupuestoId"] = value;
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

            try
            {


                Salida = new List<string>();

                if (TipoCateringId > 0)
                {
                    List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);

                    foreach (var item in ListTiempos)
                    {

                        Salida.Add("<div style=\'font-size: 12px;font-family: Dosis; margin-left: 10px;\'>&nbsp;&nbsp;&nbsp;" + item.Descripcion.ToUpper() + "</div>");

                        List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                        foreach (var itemProducto in ListProductos)
                        {

                            Salida.Add("<div style=\"font-size: 12px; font-family: Dosis; margin-left: 30px;\">&nbsp;&nbsp;&nbsp;" + itemProducto.Descripcion.ToUpper() + "</div>");

                            List<DomainAmbientHouse.Entidades.Items> ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);

                            foreach (var itemProductosItems in ListProductoItems)
                            {
                                Salida.Add("<div style=\"font-size: 10px; font-family: Dosis; margin-left: 50px;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itemProductosItems.Detalle + "</div>");
                            }

                        }

                        List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                        foreach (var itemCategorias in ListCategorias)
                        {
                            Salida.Add("<div style=\"font-size: 12px; font-family: Dosis; margin-left: 30px;\">&nbsp;&nbsp;&nbsp;" + itemCategorias.Descripcion.ToUpper() + "</div>");

                            List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                            foreach (var itemCatItems in ListCategoriaItems)
                            {
                                Salida.Add("<div style=\"font-size: 10px;font-family: Dosis; margin-left: 50px;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itemCatItems.Detalle + "</div>");
                            }

                        }


                        List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                        foreach (var itemItems in ListItems)
                        {
                            Salida.Add("<div style=\"font-size: 10px; font-family: Dosis; margin-left: 50px;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itemItems.Detalle + "</div>");
                        }
                    }

                }

                string pdfTemplate;

                if (Salida.Count() <= 19)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 19 renglones 1 hoja.pdf";
                else if (Salida.Count() <= 38)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 38 renglones 2 hojas.pdf";
                else if (Salida.Count() <= 56)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 56 renglones 3 hojas.pdf";
                else if (Salida.Count() <= 75)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 75 renglones 4 hojas.pdf";
                else if (Salida.Count() <= 94)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 94 renglones 5 hojas.pdf";
                else if (Salida.Count() <= 113)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 113 renglones 6 hojas.pdf";
                else if (Salida.Count() <= 132)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 132 renglones 7 hojas.pdf";
                else if (Salida.Count() <= 151)
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 151 renglones 8 hojas.pdf";
                else
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering Hasta 169 renglones 9 hojas.pdf";


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

                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);


                foreach (var sal in Salida)
                {
                    contador = contador + 1;

                    string htmlText = sal;
                    IList<AcroFields.FieldPosition> pos = pdfFormFields.GetFieldPositions("Campo" + contador.ToString());
                    //Field1 is the name of the field in the PDF Template you are trying to fill/overlay
                    AddHTMLToContent(htmlText, pdfStamper.GetOverContent(pos[0].page), pos);
                    //stamp is the PdfStamper in this example

                    //pdfFormFields.SetField("Campo" + contador.ToString(), Convert.ToString(sal));
                }

                DomainAmbientHouse.Entidades.TipoCatering tipo = servicios.BuscarTipoCatering(TipoCateringId);
                DomainAmbientHouse.Entidades.Presupuestos presu = presupuestos.BuscarPresupuesto(PresupuestoId);

                string anioMes = DateTime.Parse(presu.FechaEvento.ToString()).Year.ToString() + "/" + DateTime.Parse(presu.FechaEvento.ToString()).Month.ToString();


                pdfFormFields.SetField("Experiencia", Convert.ToString(tipo.Descripcion));
                pdfFormFields.SetField("Evento", Convert.ToString("# Evento " + EventoId.ToString().PadLeft(8, '0')));
                pdfFormFields.SetField("Presupuesto", Convert.ToString("# Presupuesto " + PresupuestoId.ToString().PadLeft(8, '0')));
                pdfFormFields.SetField("MesAnio", anioMes);

                pdfStamper.FormFlattening = true;
                pdfStamper.Close();

                context.Response.ClearHeaders();
                context.Response.ClearContent();
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("content-disposition", "inline; filename=" + newFile);

                context.Response.BinaryWrite(_MemoryStream.ToArray());
                context.Response.End();

            }
            catch (Exception ex)
            {

                throw ex;
            }
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