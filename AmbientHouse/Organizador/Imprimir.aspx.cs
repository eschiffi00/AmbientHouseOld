using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Organizador
{
    public partial class Imprimir : System.Web.UI.Page
    {
        private string Fecha
        {
            get
            {
                return Session["Fecha"].ToString();
            }
            set
            {
                Session["Fecha"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Fecha = Request["FechaEvento"].ToString();
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/Index.aspx?FechaEvento=" + Fecha);
        }
    }
}