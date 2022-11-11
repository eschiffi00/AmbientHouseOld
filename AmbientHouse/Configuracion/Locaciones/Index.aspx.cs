using DomainAmbientHouse.Servicios;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Locaciones
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios adminServicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ObtenerLocaciones(TextBoxDescripcionBuscador.Text);
            }

        }

        private void ObtenerLocaciones(string descripcion)
        {
            GridViewLocaciones.DataSource = adminServicios.ObtenerLocaciones().Where(o => o.Descripcion.ToLower().Contains(descripcion.ToLower())).ToList();
            GridViewLocaciones.DataBind();
        }

        protected void ButtonAgregarLocacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewLocaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLocaciones.PageIndex = e.NewPageIndex;
            ObtenerLocaciones(TextBoxDescripcionBuscador.Text);
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            ObtenerLocaciones(TextBoxDescripcionBuscador.Text);
        }





    }
}