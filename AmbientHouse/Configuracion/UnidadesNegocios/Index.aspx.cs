using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.UnidadesNegocios
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }

        }

        private void CargarGrilla()
        {
            GridViewRubros.DataSource = servicios.ObtenerUN();
            GridViewRubros.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/UnidadesNegocios/Editar.aspx");
        }

        protected void GridViewRubros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRubros.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }
    }
}