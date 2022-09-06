using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.AppShared.MasterPage
{
    public partial class Ambient : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            //if (Session["WebApplication"] == null)
            //{
            //    string url = GetRouteUrl("Login", null); ;
            //    Response.Redirect(url, false);
            //    return;
            //}
            Session["WebApplication"] = "AmbientHouse";
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings[Session["WebApplication"].ToString()].ConnectionString;
            Session["WebApplicationConStr"] = conn;
            LibDB2.DB db = new LibDB2.DB(conn);
//#if DEBUG
//            if (Session["UsuarioId"] == null) Session["UsuarioId"] = "1";
//            LibDB2.DB.deshabilita_encripcion = false;
//            Session["WebApplication"] = "SomosAmbient";
//            string conn = System.Configuration.ConfigurationManager.ConnectionStrings[Session["WebApplication"].ToString()].ConnectionString;
//            LibDB2.DB db = new LibDB2.DB(conn);
//#endif
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}