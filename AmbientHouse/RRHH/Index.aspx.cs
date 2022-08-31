using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.RRHH
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAdministrarEmpleados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RRHH/Empleados/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void ButtonAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Seguridad/Usuarios/Index.aspx");
        }
    }
}