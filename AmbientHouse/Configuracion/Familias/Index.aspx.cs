using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Familias
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicio = new AdministrativasServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarFamilias();
            }
        }

        private void BuscarFamilias()
        {
            GridViewFamilias.DataSource = servicio.ObtenerFamilias();
            GridViewFamilias.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Familias/Editar.aspx");
        }



        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void GridViewFamilias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFamilias.PageIndex = e.NewPageIndex;
            BuscarFamilias();
        }


    }
}