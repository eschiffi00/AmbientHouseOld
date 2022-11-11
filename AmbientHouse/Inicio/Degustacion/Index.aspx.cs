using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio.Degustacion
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Buscar();
            }

        }

        private void Buscar()
        {
            int degustacionAbierta = int.Parse(ConfigurationManager.AppSettings["DegustacionAbierta"].ToString());

            this.GridViewDegustacion.DataSource = this.administracion.ObtenerDegustacion().Where(o => o.EstadoId == degustacionAbierta).ToList();
            this.GridViewDegustacion.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Inicio/Principal.aspx");

        }

        protected void GridViewDegustacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDegustacion.PageIndex = e.NewPageIndex;
            this.Buscar();

        }


    }
}