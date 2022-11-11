using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.PlanesDePagos
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarPlanes();

            }
        }

        private void BuscarPlanes()
        {
            GridViewPlanes.DataSource = servicios.ObtenerPlanesDePagos();
            GridViewPlanes.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/PlanesDePagos/Editar.aspx");
        }

        protected void GridViewPlanes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPlanes.PageIndex = e.NewPageIndex;
            BuscarPlanes();
        }
    }
}