using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Operacion.Degustacion
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            GridViewDegustacion.DataSource = administracion.ObtenerDegustacion();
            GridViewDegustacion.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
        }

        protected void GridViewDegustacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDegustacion.PageIndex = e.NewPageIndex;
            this.Buscar();
        }
    }
}