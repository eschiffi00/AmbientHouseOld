using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.Localidades
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.Localidades LocalidadesSeleccionado
        {
            get
            {
                return Session["LocalidadesSeleccionado"] as DomainAmbientHouse.Entidades.Localidades;
            }
            set
            {
                Session["LocalidadesSeleccionado"] = value;
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
                NuevoLocalidades();
            else
                EditarLocalidades(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarLocalidades(long id)
        {
            DomainAmbientHouse.Entidades.Localidades localidades = new DomainAmbientHouse.Entidades.Localidades();

            localidades = servicio.BuscarLocalidades(id);

            LocalidadesSeleccionado = localidades;


            TextBoxDescripcion.Text = localidades.Descripcion;



        }

        private void NuevoLocalidades()
        {
            LocalidadesSeleccionado = new DomainAmbientHouse.Entidades.Localidades();


        }

        private void GrabarLocalidades()
        {
            DomainAmbientHouse.Entidades.Localidades localidades = LocalidadesSeleccionado;

            localidades.Descripcion = TextBoxDescripcion.Text;




            servicio.NuevoLocalidades(localidades);

            Response.Redirect("~/Configuracion/Localidades/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarLocalidades();
           
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Localidades/Index.aspx");
        }
    }
}