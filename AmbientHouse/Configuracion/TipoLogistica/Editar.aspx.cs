using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Configuracion.TipoLogistica
{
    public partial class Editar : System.Web.UI.Page
    {

        private DomainAmbientHouse.Entidades.TipoLogistica TipoLogisticaSeleccionado
        {
            get
            {
                return Session["TipoLogisticaSeleccionado"] as DomainAmbientHouse.Entidades.TipoLogistica;
            }
            set
            {
                Session["TipoLogisticaSeleccionado"] = value;
            }
        }

        private AdministrativasServicios servicio = new AdministrativasServicios();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            long id = 0;

            if (Request["Id"] != null)
            {
                id = Int64.Parse(Request["Id"]);
            }


            if (id == 0)
                NuevoTipoLogistica();
            else
                EditarTipoLogistica(id);

            SetFocus(TextBoxConcepto);
        }

        private void EditarTipoLogistica(long id)
        {
            DomainAmbientHouse.Entidades.TipoLogistica tipoLogistica = new DomainAmbientHouse.Entidades.TipoLogistica();

            tipoLogistica = servicio.BuscarTipoLogistica(id);

            TipoLogisticaSeleccionado = tipoLogistica;



            TextBoxConcepto.Text = tipoLogistica.Concepto;



        }

        private void NuevoTipoLogistica()
        {
            TipoLogisticaSeleccionado = new DomainAmbientHouse.Entidades.TipoLogistica();


        }

        private void GrabarTipoLogistica()
        {
            DomainAmbientHouse.Entidades.TipoLogistica tipoLogistica = TipoLogisticaSeleccionado;

            tipoLogistica.Concepto = TextBoxConcepto.Text;





            servicio.NuevoTipoLogistica(tipoLogistica);

            Response.Redirect("~/Configuracion/TipoLogistica/Index.aspx");
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoLogistica/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarTipoLogistica();
        }
    }
}