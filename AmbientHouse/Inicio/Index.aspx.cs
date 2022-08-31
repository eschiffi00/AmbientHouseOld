using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio
{
    public partial class Index : System.Web.UI.Page
    {
        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonExperienciasCatering_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Experiencias/Index.aspx");
        }

        protected void ButtonExperienciasBarras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/ExperienciasBarras/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());

            if (PerfilId == PerfilOrganizador)
            {
                Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
            }
            else if (PerfilId == PerfilOperacion)
            {
                Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
            }
            else
                Response.Redirect("~/Inicio/Principal.aspx");
        }

    }
}