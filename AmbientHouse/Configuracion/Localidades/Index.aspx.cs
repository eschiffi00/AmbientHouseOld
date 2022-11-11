using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Localidades
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BuscarLocalidades();
            }
        }

        private void BuscarLocalidades()
        {
            GridViewLocalidades.DataSource = servicios.ObtenerLocalidades();
            GridViewLocalidades.DataBind();
        }



        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Localidades/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewLocalidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLocalidades.PageIndex = e.NewPageIndex;
            BuscarLocalidades();

        }
    }
}