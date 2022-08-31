using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Security.Permissions;

namespace AmbientHouse.Presupuestos
{
    /// <summary>
    /// Summary description for ComprobanteMail
    /// </summary>
    public class ComprobanteMail: IHttpHandler, IRequiresSessionState
    {

        private DomainAmbientHouse.Entidades.Eventos EventosPDF
        {
            get { return (DomainAmbientHouse.Entidades.Eventos)HttpContext.Current.Session["Evento"]; }
            set { HttpContext.Current.Session["Evento"] = value; }
        }

    

        public void ProcessRequest(HttpContext context)
        {

            try
            {


                Byte[] data = (Byte[])EventosPDF.ComprobanteAprovacion;

                byte[] file = EventosPDF.ComprobanteAprovacion;
                string Extension = EventosPDF.ComprobanteAprovacionExtension.Replace(".", "");

                context.Response.AddHeader("Content-type", GetContentType(Extension));
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + EventosPDF.Id.ToString() + EventosPDF.ComprobanteAprovacionExtension);
                context.Response.BinaryWrite(data);
                context.Response.Flush();
                context.Response.End();


            }
            catch (Exception ex)
            {

                DomainAmbientHouse.Servicios.Log.save(this, ex);
            }
  
        }

        private string GetContentType(string FileExtension)
        {
            // Convertimos la extensión en minúsculas
            string ext = FileExtension.ToLower(
                System.Threading.Thread.CurrentThread.CurrentCulture);
            // Verificamos que contenga el punto de
            // otra manera habría que agregarlo para 
            // poder obtener los resultados esperados
            if (!ext.StartsWith("."))
                ext = String.Concat(".", ext);
            // Se declara un permisos pata obtener
            // acceso de solo lectura al registro
            // NOTA: Se está utilizando: using System.Security.Permissions;
            RegistryPermission Reg = new RegistryPermission(
            RegistryPermissionAccess.Read, "HKEY_CLASSES_ROOT\\");
            // Creamos un llave de registro para
            // HKEY_CLASSES_ROOT
            Microsoft.Win32.RegistryKey regKey =
                Microsoft.Win32.Registry.ClassesRoot;
            // Intentamos crear una llave de registro
            // a partir de la extensión
            Microsoft.Win32.RegistryKey regKeyExt =
                regKey.OpenSubKey(ext);
            // Si la extensión existe como sub llave de registro
            // entonces devolveremos su valor de lo contrario
            // se devuelve el valor predeterminado
            if (regKeyExt == null)
                return "application/octet-stream";
            else
                return regKeyExt.GetValue("Content Type",
            "application/octet-stream").ToString();
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