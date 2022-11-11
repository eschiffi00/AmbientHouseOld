using DomainAmbientHouse.Servicios;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AmbientHouse.Presupuestos
{
    /// <summary>
    /// Summary description for ImagenAprobacion
    /// </summary>
    public class ImagenAprobacion : IHttpHandler, IRequiresSessionState
    {
        private int EventoId
        {

            get { return (Int32)HttpContext.Current.Session["EventoId"]; }
            set { HttpContext.Current.Session["EventoId"] = value; }

        }

        public void ProcessRequest(HttpContext context)
        {
            bool isMale = true;
            DomainAmbientHouse.Entidades.Eventos fotos = null;
            byte[] buffer;
            try
            {

                EventosServicios servicio = new EventosServicios();
                fotos = servicio.BuscarEvento(EventoId);

                //isMale = ((fotos.sexo.ToString().ToUpper().Trim().Equals("M") ? true : false));

                if (fotos != null && fotos.ComprobanteAprovacion != null)
                {

                    byte[] datosImagen = (byte[])fotos.ComprobanteAprovacion;
                    MemoryStream ms = new MemoryStream(datosImagen);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                    string name = "FotoAmpliada" + DateTime.Now.Ticks + (DateTime.Now.Millisecond + EventoId);
                    string ext = fotos.ComprobanteAprovacionExtension;

                    buffer = fotos.ComprobanteAprovacion.ToArray();

                    ResponseImage(context, name, ext, buffer);
                    return;


                    //int fileExtensionMaxSize = int.Parse(ConfigurationManager.AppSettings.Get("fileExtensionMaxSize"));
                    //string ValidExtenssionUploadFile = ConfigurationManager.AppSettings.Get("ValidExtenssionUploadFile");

                    //string name = "FotoAmpliada" + DateTime.Now.Ticks + (DateTime.Now.Millisecond + EventoId);
                    //int extLength = ((fotos.ComprobanteAprovacionExtension != null && fileExtensionMaxSize >= fotos.ComprobanteAprovacionExtension.ToString().Trim().Length) ? fotos.ComprobanteAprovacionExtension.ToString().Trim().Length : fileExtensionMaxSize);
                    //string ext = ((fotos.ComprobanteAprovacionExtension != null) ? fotos.ComprobanteAprovacionExtension.ToString().Trim().ToLower().Replace(" ", "").Replace("%", "").Replace("/", "").Replace("\\", "").Replace(":", "").Replace(".", "").Substring(0, extLength) : ".png"); ;

                    //// Controla que la extension del archivo valida 
                    //if (ValidExtenssionUploadFile.IndexOf("." + ext) >= 0)
                    //{
                    //    buffer = fotos.ComprobanteAprovacion.ToArray();

                    //    ResponseImage(context, name, ext, buffer);
                    //    return;
                    //}
                }
            }
            catch { /* NADA */ }

            // Si no hay foto o hubo errores... retorna la silueta correspondiente...
            string filename = context.Request.PhysicalApplicationPath + "Content\\imagenes\\Sin Archivo.jpg";
            FileStream fs = File.OpenRead(filename);
            buffer = new byte[(int)fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);

            string[] names = filename.Split('\\');
            ResponseImage(context, names[names.Length - 1], "png", buffer);
        }

        /// <summary>
        /// Retorna la imagen en el output del handler
        /// </summary>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <param name="ext"></param>
        /// <param name="buffer"></param>
        private void ResponseImage(HttpContext context, string name, string ext, Byte[] buffer)
        {
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.AppendHeader("content-disposition", "inline; filename=" + name.Replace(" ", ""));// ANTES attachment NO FUNCIONA CON IE8
            context.Response.ContentType = "image/" + ext.Trim().ToLower();

            context.Response.BinaryWrite(buffer);

            // Cierra la transmision del archivo
            context.Response.End();

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