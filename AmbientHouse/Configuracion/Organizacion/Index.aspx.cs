using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
namespace AmbientHouse.Configuracion.Organizacion
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BuscarItemsOrganizacion();
        }

        private void BuscarItemsOrganizacion()
        {
            GridViewOrganizacion.DataSource = administracion.ObtenerItemsOrganizacion();
            GridViewOrganizacion.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Organizacion/Editar.aspx");
        }

        protected void GridViewOrganizacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewOrganizacion.PageIndex = e.NewPageIndex;
            BuscarItemsOrganizacion();
        }
    }
}