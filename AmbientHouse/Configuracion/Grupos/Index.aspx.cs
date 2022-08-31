using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Grupos
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicio = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarGrupos();
            }
        }

        private void BuscarGrupos()
        {
            GridViewGrupos.DataSource = servicio.ObtenerGrupos();
            GridViewGrupos.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Grupos/Editar.aspx");
        }

        protected void GridViewGrupos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGrupos.PageIndex = e.NewPageIndex;
            BuscarGrupos();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }
    }
}