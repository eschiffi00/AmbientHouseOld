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
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio
{
    /// <summary>
    /// Summary description for BarrasExperiencias
    /// </summary>
    public class BarrasExperiencias : IHttpHandler, IRequiresSessionState
    {

        private int TipoBarraId
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Session["TipoBarraId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["TipoBarraId"] = value;
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

        public void ProcessRequest(HttpContext context)
        {
            Salida = new List<string>();

            if (TipoBarraId > 0)
            {
                List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoBarra(TipoBarraId);

                foreach (var itemCategorias in ListCategorias)
                {
                    TextBox textoCategorias = new TextBox();
                    //textoCategorias.Attributes.Add("style", "font-size: 12px;font-family: Dosis-Medium;");
                    textoCategorias.Text = itemCategorias.Descripcion.ToUpper();
                    textoCategorias.Font.Name = "Dosis";

                    Salida.Add("<div style=\'font-size: 12px;font-family: Dosis;margin-left: 30px;\'>&nbsp;&nbsp;&nbsp;" + textoCategorias.Text + "</div>");

                    List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoBarraCategorias(TipoBarraId, itemCategorias.Id);

                    foreach (var itemCatItems in ListCategoriaItems)
                    {

                        TextBox textoCatItem = new TextBox();
                        textoCatItem.Attributes.Add("style", "font-family: Dosis;");
                        textoCatItem.Text = itemCatItems.Detalle;

                        Salida.Add("<div style=\'font-size: 10px;font-family: Dosis;margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoCatItem.Text + "</div>");

                    }
                }

                List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoBarra(TipoBarraId);

                foreach (var itemItems in ListItems)
                {
                    TextBox textoItems = new TextBox();
                    textoItems.Attributes.Add("style", "font-family: Dosis;");
                    textoItems.Text = itemItems.Detalle;

                    Salida.Add("<div style=\'font-size: 10px;font-family: Dosis; margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoItems.Text + "</div>");

                }

            }

            string pdfTemplate;

            if (Salida.Count() <= 19)
                pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Barras Hasta 19 renglones 1 hoja.pdf";
            else if (Salida.Count() <= 38)
                pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Barras Hasta 38 renglones 2 hojas.pdf";
            else if (Salida.Count() <= 56)
                pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Barras Hasta 56 renglones 3 hojas.pdf";
            else
                pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Barras Hasta 75 renglones 4 hojas.pdf";

            string newFile = "Barras.pdf";
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


            DomainAmbientHouse.Entidades.TiposBarras tb = servicios.BuscarTipoBarras(TipoBarraId);


            pdfFormFields.SetField("Experiencia", Convert.ToString(tb.Descripcion));

            pdfStamper.FormFlattening = true;
            pdfStamper.Close();

            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("content-disposition", "inline; filename=" + newFile);

            context.Response.BinaryWrite(_MemoryStream.ToArray());
            context.Response.End();
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