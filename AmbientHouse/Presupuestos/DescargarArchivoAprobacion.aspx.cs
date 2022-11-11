using DomainAmbientHouse.Servicios;
using System;
using System.Web;

namespace AmbientHouse.Presupuestos
{
    public partial class DescargarArchivoAprobacion : System.Web.UI.Page
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

        private DomainAmbientHouse.Entidades.Eventos EventosSeleccionado
        {
            get { return (DomainAmbientHouse.Entidades.Eventos)HttpContext.Current.Session["EventoSeleccionado"]; }
            set { HttpContext.Current.Session["EventoSeleccionado"] = value; }
        }


        EventosServicios eventos = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }

        }

        private void InicializarPagina()
        {

            if (Request["EventoId"] != null)
            {
                EventoId = int.Parse(Request["EventoId"]);
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = int.Parse(Request["PresupuestoId"]);
            }

            EventosSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventosSeleccionado = eventos.BuscarEvento(EventoId);
        }

        protected void ButtonVolverInicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Presupuestos/ReservarPresupuesto.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
        }
    }
}