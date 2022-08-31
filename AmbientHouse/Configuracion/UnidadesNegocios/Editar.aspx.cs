using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.UnidadesNegocios
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.UnidadesNegocios RubroSeleccionado
        {
            get
            {
                return Session["RubroSeleccionado"] as DomainAmbientHouse.Entidades.UnidadesNegocios;
            }
            set
            {
                Session["RubroSeleccionado"] = value;
            }
        }

        private int RubroId
        {
            get
            {
                return Int32.Parse(Session["RubroId"].ToString());
            }
            set
            {
                Session["RubroId"] = value;
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

                RubroId = id;
            }


            if (id == 0)
                NuevoRubro();
            else
                EditarRubro(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarRubro(int id)
        {

            DomainAmbientHouse.Entidades.UnidadesNegocios rubro = new DomainAmbientHouse.Entidades.UnidadesNegocios();

            rubro = servicios.BuscarUnidadNegocio(id);

            RubroSeleccionado = rubro;


            TextBoxDescripcion.Text = rubro.Descripcion;

        }

        private void NuevoRubro()
        {
            RubroSeleccionado = new DomainAmbientHouse.Entidades.UnidadesNegocios();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.UnidadesNegocios rubro = RubroSeleccionado;

            rubro.Descripcion = TextBoxDescripcion.Text;

            servicios.NuevoUnidadNegocio(rubro);
            Response.Redirect("~/Configuracion/UnidadesNegocios/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/UnidadesNegocios/Index.aspx");
        }
    }
}