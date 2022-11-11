using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Configuracion.TipoTecnica
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();

        private DomainAmbientHouse.Entidades.TipoServicios TipoServicioSeleccionado
        {
            get
            {
                return Session["TipoServicioSeleccionado"] as DomainAmbientHouse.Entidades.TipoServicios;
            }
            set
            {
                Session["TipoServicioSeleccionado"] = value;
            }
        }

        private int TipoServicioId
        {
            get
            {
                return Int32.Parse(Session["TipoServicioId"].ToString());
            }
            set
            {
                Session["TipoServicioId"] = value;
            }
        }

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
                id = Int32.Parse(Request["Id"]);

                TipoServicioId = id;
            }


            if (id == 0)
                NuevoTipoServicio();
            else
                EditarTipoServicio(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarTipoServicio(int id)
        {

            DomainAmbientHouse.Entidades.TipoServicios tiposervicio = new DomainAmbientHouse.Entidades.TipoServicios();

            tiposervicio = servicios.BuscarTipoServicios(id);

            TipoServicioSeleccionado = tiposervicio;


            TextBoxDescripcion.Text = tiposervicio.Descripcion;

        }

        private void NuevoTipoServicio()
        {
            TipoServicioSeleccionado = new DomainAmbientHouse.Entidades.TipoServicios();
        }

        private void GrabarItem()
        {


            DomainAmbientHouse.Entidades.TipoServicios tiposervicio = TipoServicioSeleccionado;

            tiposervicio.Descripcion = TextBoxDescripcion.Text;
            tiposervicio.RubroId = 2;

            servicios.NuevoTipoServicio(tiposervicio);
            Response.Redirect("~/Configuracion/TipoTecnica/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoTecnica/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarItem();
        }
    }
}