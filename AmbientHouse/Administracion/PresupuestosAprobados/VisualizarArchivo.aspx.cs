using DomainAmbientHouse.Servicios;
using System;
using System.Web;

namespace AmbientHouse.Administracion.PresupuestosAprobados
{
    public partial class VisualizarArchivo : System.Web.UI.Page
    {
        private int EventoId
        {
            get
            {
                return Int32.Parse(Session["EventoId"].ToString());
            }
            set
            {
                Session["EventoId"] = value;
            }
        }

        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(Session["PresupuestoId"].ToString());
            }
            set
            {
                Session["PresupuestoId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos ArchivoDescargar
        {
            get { return (DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos)HttpContext.Current.Session["ArchivoOrganizacion"]; }
            set { HttpContext.Current.Session["ArchivoOrganizacion"] = value; }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = int.Parse(Request["Id"]);
            }

            if (Request["EventoId"] != null)
            {
                EventoId = int.Parse(Request["EventoId"]);
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = int.Parse(Request["PresupuestoId"]);
            }

            ArchivoDescargar = new DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos();

            ArchivoDescargar = administracion.BuscarOrganizacionArchivo(id);
        }

        protected void ButtonVolverInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/PresupuestosAprobados/ProveedoresExternos.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
        }
    }
}