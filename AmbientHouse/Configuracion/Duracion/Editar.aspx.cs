using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Duracion
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.DuracionEvento DuracionEventoSeleccionado
        {
            get
            {
                return Session["DuracionEventoSeleccionado"] as DomainAmbientHouse.Entidades.DuracionEvento;
            }
            set
            {
                Session["DuracionEventoSeleccionado"] = value;
            }
        }

        private int DuracionEventoId
        {
            get
            {
                return Int32.Parse(Session["DuracionEventoId"].ToString());
            }
            set
            {
                Session["DuracionEventoId"] = value;
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

                DuracionEventoId = id;
            }


            if (id == 0)
                NuevaDuracion();
            else
                EditarDuracion(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarDuracion(int id)
        {

            DomainAmbientHouse.Entidades.DuracionEvento duracion = new DomainAmbientHouse.Entidades.DuracionEvento();

            duracion = servicios.BuscarDuracion(id);

            DuracionEventoSeleccionado = duracion;


            TextBoxDescripcion.Text = duracion.Descripcion;

        }

        private void NuevaDuracion()
        {
            DuracionEventoSeleccionado = new DomainAmbientHouse.Entidades.DuracionEvento();
        }

        private void GrabarDuracion()
        {


            DomainAmbientHouse.Entidades.DuracionEvento item = DuracionEventoSeleccionado;

            item.Descripcion = TextBoxDescripcion.Text;


            servicios.NuevaDuracionEvento(item);
            Response.Redirect("~/Configuracion/Duracion/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarDuracion();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Duracion/Index.aspx");
        }
    }
}