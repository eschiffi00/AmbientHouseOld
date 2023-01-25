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
using DbEntidades.Entities;
using DbEntidades.Operators;

namespace AmbientHouse.Inicio
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
            //try
            //{


            Salida = new List<string>();

            if (TipoCateringId > 0)
            {
                List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);

                foreach (var item in ListTiempos)
                {
                    TextBox textoItem = new TextBox();
                    //textoItem.Attributes.Add("style","font-size: 12px;font-family: Dosis-Medium;");
                    textoItem.Text = item.Descripcion.ToUpper();
                    textoItem.Font.Name = "Calibri";

                    Salida.Add("<div style=\'font-size: 12px;font-family: Calibri;margin-left: 10px;\'>&nbsp;&nbsp;&nbsp;" + textoItem.Text + "</div>");

                    List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                    foreach (var itemProducto in ListProductos)
                    {
                        TextBox textoProducto = new TextBox();
                        //textoProducto.Attributes.Add("style", "font-size: 12px;font-family: Dosis-Medium;");
                        textoProducto.Text = itemProducto.Descripcion.ToUpper();
                        textoProducto.Font.Name = "Dosis";
                        Salida.Add("<div style=\'font-size: 12px;font-family: Calibri;margin-left: 30px;\'>&nbsp;&nbsp;&nbsp;" + textoProducto.Text + "</div>");

                        List<DomainAmbientHouse.Entidades.Items> ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);

                        foreach (var itemProductosItems in ListProductoItems)
                        {
                            TextBox textoProductoItem = new TextBox();
                            //textoProductoItem.Attributes.Add("style", "font-family: Dosis-ExtraLight;");
                            textoProductoItem.Text = itemProductosItems.Detalle;

                            Salida.Add("<div style=\'font-size: 10px; font-family: Calibri; 8px;margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoProductoItem.Text + "</div>");
                        }

                    }

                    List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                    foreach (var itemCategorias in ListCategorias)
                    {
                        TextBox textoCategorias = new TextBox();
                        //textoCategorias.Attributes.Add("style", "font-size: 12px;font-family: Dosis-Medium;");
                        textoCategorias.Text = itemCategorias.Descripcion.ToUpper();
                        textoCategorias.Font.Name = "Dosis";

                        Salida.Add("<div style=\'font-size: 12px;font-family: Calibri;margin-left: 30px;\'>&nbsp;&nbsp;&nbsp;" + textoCategorias.Text + "</div>");

                        List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                        foreach (var itemCatItems in ListCategoriaItems)
                        {
                            TextBox textoCatItem = new TextBox();
                            textoCatItem.Attributes.Add("style", "font-family: Dosis;");
                            textoCatItem.Text = itemCatItems.Detalle;

                            Salida.Add("<div style=\'font-size: 10px;font-family: Calibri;margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoCatItem.Text + "</div>");
                        }

                    }


                    List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                    foreach (var itemItems in ListItems)
                    {
                        TextBox textoItems = new TextBox();
                        textoItems.Attributes.Add("style", "font-family: Dosis;");
                        //var nombreItem = NombreFantasiaOperator.GetOneByIdentity(ItemsOperator.GetOneByIdentity(itemItems.Id).NombreFantasiaId.Value).Descripcion;
                        //textoItems.Text = nombreItem;
                        textoItems.Text = itemItems.Detalle;

                        Salida.Add("<div style=\'font-size: 10px;font-family: Calibri; margin-left: 50px;\'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + textoItems.Text + "</div>");
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

        //private void insertarTexto()
        //{
        //    string cadena = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 8 hojas.pdf";

        //    string cadena1 = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 9 hojas.pdf";
        //    string pathPDF = cadena;
        //    string pathPDF2 = cadena1;

        //    //Objeto para leer el pdf original
        //    PdfReader oReader = new PdfReader(pathPDF);
        //    //Objeto que tiene el tamaño de nuestro documento
        //    iTextSharp.text.Rectangle oSize = oReader.GetPageSizeWithRotation(1);
        //    //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
        //    Document oDocument = new Document(oSize);

        //    // Creamos el objeto en el cual haremos la inserción
        //    FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
        //    PdfWriter oWriter = PdfWriter.GetInstance(oDocument, oFS);
        //    oDocument.Open();

        //    //El contenido del pdf, aqui se hace la escritura del contenido
        //    PdfContentByte oPDF = oWriter.DirectContent;

        //    //Propiedades de nuestra fuente a insertar
        //    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //    oPDF.SetColorFill(BaseColor.RED);
        //    oPDF.SetFontAndSize(bf, 8);

        //    //Se abre el flujo para escribir el texto
        //    oPDF.BeginText();
        //    //asignamos el texto
        //    string text = "HOLA SOY UN TEXTO ROJO EN UN PDF";
        //    // Le damos posición y rotación al texto
        //    // la posición de Y es al revés de como estamos acostumbrados
        //    oPDF.ShowTextAligned(1, text, 30, oSize.Height - 30, 0);
        //    oPDF.EndText();

        //    //crea una nueva pagina y agrega el pdf original
        //    PdfImportedPage page = oWriter.GetImportedPage(oReader, 1);
        //    oPDF.AddTemplate(page, 0, 0);

        //    // Cerramos los objetos utilizados
        //    oDocument.Close();
        //    oFS.Close();
        //    oWriter.Close();
        //    oReader.Close();
        //}

        private void insertarTexto()
        {
            string oldFile = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantillas Catering 8 hojas.pdf";
            string newFile = "newFile.pdf";

            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(bf, 8);

            // write the text in the pdf content
            cb.BeginText();
            string text = "Some random blablablabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 520, 640, 0);
            cb.EndText();
            cb.BeginText();
            text = "Other random blabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 100, 200, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
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