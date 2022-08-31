using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Seguridad.Usuarios
{
    public partial class MensajeSeguridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { InicializarPagina(); }
        }

        private void InicializarPagina()
        {
            string mensaje = null;

            if (Request["Mensaje"] != null)
            {
                mensaje = Request["Mensaje"];

                LabelMensaje.Text = mensaje.ToUpper();
            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Seguridad/Usuarios/Index.aspx");
        }

    }
}