using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Costos.Catering
{
    public partial class Index : System.Web.UI.Page
    {
        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarCostoCatering();
            }

        }

        private void BuscarCostoCatering()
        {
            GridViewCostoCatering.DataSource = servicios.ObtenerCostosCatering();
            GridViewCostoCatering.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void GridViewCostoCatering_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoCatering.PageIndex = e.NewPageIndex;
            BuscarCostoCatering();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Catering/Editar.aspx");
        }
    }
}