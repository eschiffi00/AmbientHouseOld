using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.SessionState;

namespace AmbientHouse.Operacion.Planificacion
{
    /// <summary>
    /// Summary description for DescargarArchivos
    /// </summary>
    public class DescargarArchivos : IHttpHandler, IRequiresSessionState
    {

        private DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos Archivo
        {
            get { return (DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos)HttpContext.Current.Session["ArchivoOrganizacion"]; }
            set { HttpContext.Current.Session["ArchivoOrganizacion"] = value; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Byte[] data = (Byte[])Archivo.Archivo;

            byte[] file = Archivo.Archivo;
            string Extension = Archivo.Extension.Replace(".", "");

            context.Response.AddHeader("Content-type", GetContentType(Extension));
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Archivo.NombreArchivo + Archivo.Extension);
            context.Response.BinaryWrite(data);
            context.Response.Flush();
            context.Response.End();
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