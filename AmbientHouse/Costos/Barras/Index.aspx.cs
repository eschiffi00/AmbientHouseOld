using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Barras
{
    public partial class Index : System.Web.UI.Page
    {

        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarCostoBarras();
            }

        }

        private void BuscarCostoBarras()
        {
            GridViewCostoBarra.DataSource = servicios.ObtenerCostoBarras();
            GridViewCostoBarra.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Barras/Editar.aspx");
        }

        protected void GridViewCostoBarra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoBarra.PageIndex = e.NewPageIndex;
            BuscarCostoBarras();

        }
    }
}