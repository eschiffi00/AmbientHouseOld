using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Costos.Ambientacion
{
    public partial class Index : System.Web.UI.Page
    {


        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarCostoAmbientacion();
            }

        }

        private void BuscarCostoAmbientacion()
        {
            GridViewCostoAmbientacion.DataSource = servicios.ObtenerCostosAmbientacion();
            GridViewCostoAmbientacion.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Ambientacion/Editar.aspx");
        }

        protected void GridViewCostoAmbientacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoAmbientacion.PageIndex = e.NewPageIndex;
            BuscarCostoAmbientacion();

        }
    }
}