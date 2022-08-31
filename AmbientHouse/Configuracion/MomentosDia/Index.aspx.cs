using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.MomentosDia
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicio = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarMomenytos();
            }
        }

        private void BuscarMomenytos()
        {
            GridViewMomentos.DataSource = servicio.ObtenerMomentosDias();
            GridViewMomentos.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/MomentosDia/Editar.aspx");
        }

        protected void GridViewMomentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMomentos.PageIndex = e.NewPageIndex;
            BuscarMomenytos();
        }
    }
}