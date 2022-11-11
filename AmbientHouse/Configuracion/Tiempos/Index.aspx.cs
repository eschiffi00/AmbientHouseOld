using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Tiempos
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios administrativa = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Buscar();

            }
        }

        private void Buscar()
        {
            GridViewTiempo.DataSource = administrativa.ObtenerTiempos();
            GridViewTiempo.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Tiempos/Editar.aspx");
        }

        protected void GridViewTiempo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTiempo.PageIndex = e.NewPageIndex;
            Buscar();
        }
    }
}