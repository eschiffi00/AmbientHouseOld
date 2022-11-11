using System;

namespace AmbientHouse
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Seguridad/Login.aspx");
        }
    }
}