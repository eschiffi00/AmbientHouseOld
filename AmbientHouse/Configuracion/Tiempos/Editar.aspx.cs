using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Configuracion.Tiempos
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Tiempos TiempoSeleccionado
        {
            get
            {
                return Session["TiempoSeleccionado"] as DomainAmbientHouse.Entidades.Tiempos;
            }
            set
            {
                Session["TiempoSeleccionado"] = value;
            }
        }

        private int TiempoId
        {
            get
            {
                return Int32.Parse(Session["TiempoId"].ToString());
            }
            set
            {
                Session["TiempoId"] = value;
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

                TiempoId = id;
            }


            if (id == 0)
                NuevoTiempo();
            else
                EditarTiempo(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarTiempo(int id)
        {

            DomainAmbientHouse.Entidades.Tiempos tiempo = new DomainAmbientHouse.Entidades.Tiempos();

            tiempo = servicios.BuscarTiempo(id);

            TiempoSeleccionado = tiempo;


            TextBoxDescripcion.Text = tiempo.Descripcion;

            if (tiempo.Orden != null)
                TextBoxOrden.Text = tiempo.Orden.ToString();
        }

        private void NuevoTiempo()
        {
            TiempoSeleccionado = new DomainAmbientHouse.Entidades.Tiempos();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.Tiempos tiempo = TiempoSeleccionado;

            tiempo.Descripcion = TextBoxDescripcion.Text;

            if (TextBoxOrden.Text != "")
                tiempo.Orden = Int32.Parse(TextBoxOrden.Text);

            servicios.NuevoTiempo(tiempo);
            Response.Redirect("~/Configuracion/Tiempos/Index.aspx");
        }


        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Tiempos/Index.aspx");
        }
    }
}