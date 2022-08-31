using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Costos.Canon
{
    public partial class Index : System.Web.UI.Page
    {
        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarCostoCanon();
            }

        }

        private void BuscarCostoCanon()
        {
            GridViewCostoCannon.DataSource = servicios.ObtenerCostosCanon();
            GridViewCostoCannon.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Canon/Editar.aspx");
        }

        protected void GridViewCostoCannon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoCannon.PageIndex = e.NewPageIndex;
            BuscarCostoCanon();
        }
    }
}