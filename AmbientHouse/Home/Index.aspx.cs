using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace AmbientHouse.Home
{
    public partial class Index : System.Web.UI.Page
    {
        private int AreaId
        {
            get
            {
                return Int32.Parse(Session["AreaId"].ToString());
            }
            set
            {
                Session["AreaId"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            insertarTexto();
        }

        private void insertarTexto()
        {
            string oldFile = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Pueba.pdf";
            string newFile = @"C:\Users\Pc\Desktop\newFile.pdf";

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
            cb.SetFontAndSize(bf, 12);

            // write the text in the pdf content
            cb.BeginText();
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, "Some random blablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla...", 150, 640, 0);
            cb.EndText();
            cb.BeginText();
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, "Other random blablablablablablaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa...", 150, 660, 0);

            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 2);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }
    }
}