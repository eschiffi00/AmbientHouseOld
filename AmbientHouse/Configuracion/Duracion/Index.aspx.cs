using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Duracion
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicio = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarDuraciones();
            }
        }

        private void BuscarDuraciones()
        {
            GridViewDuracion.DataSource = servicio.ObtenerDuracionEvento();
            GridViewDuracion.DataBind();
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Configuracion/Duracion/Editar.aspx");
        }

        protected void GridViewDuracion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDuracion.PageIndex = e.NewPageIndex;
            BuscarDuraciones();
        }
    }
}