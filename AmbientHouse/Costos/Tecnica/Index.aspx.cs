using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Costos.Tecnica
{
    public partial class Index : System.Web.UI.Page
    {

        EventosServicios servicios = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarCostoTecnica();
            }

        }

        private void BuscarCostoTecnica()
        {
            GridViewCostoTecnica.DataSource = servicios.ObtenerCostosTecnica();
            GridViewCostoTecnica.DataBind();
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Tecnica/Editar.aspx");
        }

        protected void GridViewCostoTecnica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoTecnica.PageIndex = e.NewPageIndex;
            BuscarCostoTecnica();
        }
    }
}