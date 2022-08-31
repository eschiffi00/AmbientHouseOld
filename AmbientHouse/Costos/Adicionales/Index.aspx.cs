using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

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