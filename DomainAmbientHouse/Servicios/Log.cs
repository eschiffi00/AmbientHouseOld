using System;
using System.Diagnostics;
using System.IO;
using System.Web;


namespace DomainAmbientHouse.Servicios
{
    public class Log
    {

        public static void save(object obj, Exception ex)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = HttpContext.Current.Request.MapPath("~/logs/" + fecha + ".txt");

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }

        public static void saveAuditoria(object obj, string Mensaje)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = HttpContext.Current.Request.MapPath("~/logs/" + fecha + ".txt");

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + Mensaje);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }



    }
}
