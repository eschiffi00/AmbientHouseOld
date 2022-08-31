using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Configuration;

namespace AmbientHouse.Configuracion.AmbientacionCI
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.AmbientacionCI AmbientacionCISeleccionado
        {
            get
            {
                return Session["AmbientacionCISeleccionado"] as DomainAmbientHouse.Entidades.AmbientacionCI;
            }
            set
            {
                Session["AmbientacionCISeleccionado"] = value;
            }
        }

        private int AmbientacionCIId
        {
            get
            {
                return Int32.Parse(Session["AmbientacionCIId"].ToString());
            }
            set
            {
                Session["AmbientacionCIId"] = value;
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

                AmbientacionCIId = id;
            }


            if (id == 0)
                NuevaAmbientacionCI();
            else
                EditarAmbientacionCI(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarAmbientacionCI(int id)
        {
            DomainAmbientHouse.Entidades.AmbientacionCI ambientacion = new DomainAmbientHouse.Entidades.AmbientacionCI();

            ambientacion = administracion.BuscarAmbientacionCI(id);

            AmbientacionCISeleccionado = ambientacion;


            TextBoxDescripcion.Text = ambientacion.Descripcion;

           

        }

        private void NuevaAmbientacionCI()
        {
            AmbientacionCISeleccionado = new DomainAmbientHouse.Entidades.AmbientacionCI();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {

            int activo = Int32.Parse(ConfigurationManager.AppSettings["AmbientacionCIActivo"].ToString());



            DomainAmbientHouse.Entidades.AmbientacionCI ambientacion = AmbientacionCISeleccionado;

            ambientacion.Descripcion = TextBoxDescripcion.Text;
            ambientacion.Flete = false;
            ambientacion.EstadoId = activo;

            administracion.GrabarAmbientacionCI(ambientacion);


            Response.Redirect("~/Configuracion/AmbientacionCI/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AmbientacionCI/Index.aspx");
        }
    }
}