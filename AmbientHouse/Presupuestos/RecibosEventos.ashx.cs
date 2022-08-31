using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
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
    /// Summary description for RecibosEventos
    /// </summary>
    public class RecibosEventos : IHttpHandler, IRequiresSessionState
    {
        private RecibosPDF recibos
        {
            get { return (RecibosPDF)HttpContext.Current.Session["RecibosPDF"]; }
            set { HttpContext.Current.Session["RecibosPDF"] = value; }
        }

        private PresupuestosServicios servicio = new PresupuestosServicios();
        private Comun cmd = new Comun();
        private AdministrativasServicios serviciosAdministrativas = new AdministrativasServicios();

        public void ProcessRequest(HttpContext context)
        {



            try
            {




                string pdfTemplate;


                pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Recibo Lahusen.pdf";


                string newFile = "Recibo.pdf";
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

                if (recibos.ApellidoNombre != null)
                    pdfFormFields.SetField("RazonSocialApellidoNombre", Convert.ToString(recibos.ApellidoNombre));
                else
                    pdfFormFields.SetField("RazonSocialApellidoNombre", Convert.ToString(recibos.RazonSocial));

                pdfFormFields.SetField("Domicilio", Convert.ToString(recibos.Domicilio));
                pdfFormFields.SetField("Importe", Convert.ToString(Math.Ceiling(recibos.Importe)));
                pdfFormFields.SetField("Total", Convert.ToString(Math.Ceiling(recibos.Importe)));
                pdfFormFields.SetField("Fecha", String.Format("{0:dd/MM/yyyy}", recibos.FechaSenia));
                pdfFormFields.SetField("CUIT", Convert.ToString(recibos.CuilCuit));
                pdfFormFields.SetField("IVA", Convert.ToString(recibos.CondicionIva));

                pdfFormFields.SetField("NroRecibo", Convert.ToString("1".PadLeft(6,'0'))); 

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}