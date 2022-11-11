using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Adicionales
{
    public partial class Index : System.Web.UI.Page
    {
        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarCostoAdicionales();
            }

        }

        private void BuscarCostoAdicionales()
        {
            GridViewCostoAdicionales.DataSource = servicios.ObtenerCostosAdicionales();
            GridViewCostoAdicionales.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Adicionales/Editar.aspx");
        }

        protected void GridViewCostoAdicionales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoAdicionales.PageIndex = e.NewPageIndex;
            BuscarCostoAdicionales();
        }
    }
}