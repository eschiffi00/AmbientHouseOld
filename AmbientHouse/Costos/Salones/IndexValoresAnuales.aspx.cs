using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Salones
{
    public partial class IndexValoresAnuales : System.Web.UI.Page
    {
        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarValoresAnuales();
            }
        }

        private void BuscarValoresAnuales()
        {
            GridViewSalonesAnio.DataSource = servicios.ObtenerCostosSalonesPorAnios();
            GridViewSalonesAnio.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Salones/EditarValoresAnuales.aspx");
        }

        protected void GridViewSalonesAnio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSalonesAnio.PageIndex = e.NewPageIndex;
            BuscarValoresAnuales();
        }
    }
}