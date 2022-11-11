using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Impuestos
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarImpuestos();
            }
        }

        private void BuscarImpuestos()
        {
            GridViewImpuestos.DataSource = servicios.ObtenerImpuestos();
            GridViewImpuestos.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Impuestos/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Index.aspx");
        }

        protected void GridViewImpuestos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewImpuestos.PageIndex = e.NewPageIndex;
            BuscarImpuestos();
        }
    }
}