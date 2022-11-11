using System;

namespace AmbientHouse.Administracion.Presupuestos
{
    public partial class Imprimir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }
    }
}