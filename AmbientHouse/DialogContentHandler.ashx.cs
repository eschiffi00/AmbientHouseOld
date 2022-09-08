using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbientHouse
{
    /// <summary>
    /// Descripción breve de Handler1
    /// </summary>
    public class DialogContentHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string s = "El Monto a Pagar es mayor al Costo";
            context.Response.Write(s);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}