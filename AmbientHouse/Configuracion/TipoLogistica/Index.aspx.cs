using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.TipoLogistica
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BuscarTipoLogistica();
            }
        }

        private void BuscarTipoLogistica()
        {
            GridViewTipoLogistica.DataSource = servicios.ObtenerTipoLogistica();
            GridViewTipoLogistica.DataBind();
        }


        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoLogistica/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewTipoLogistica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTipoLogistica.PageIndex = e.NewPageIndex;
            BuscarTipoLogistica();
        }
    }
}