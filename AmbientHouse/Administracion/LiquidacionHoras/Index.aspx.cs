using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.LiquidacionHoras
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscar();
            }
        }

        private void Buscar()
        {

            GridViewLiquidaciones.DataSource = administracion.ObtenerLiquidaciones();
            GridViewLiquidaciones.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/LiquidacionHoras/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Index.aspx");
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewLiquidaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}