using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.MomentosDia
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.MomentosDias MomentosDiasSeleccionado
        {
            get
            {
                return Session["MomentosDiasSeleccionado"] as DomainAmbientHouse.Entidades.MomentosDias;
            }
            set
            {
                Session["MomentosDiasSeleccionado"] = value;
            }
        }

        private int MomentosDiasId
        {
            get
            {
                return Int32.Parse(Session["MomentosDiasId"].ToString());
            }
            set
            {
                Session["MomentosDiasId"] = value;
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

                MomentosDiasId = id;
            }


            if (id == 0)
                NuevoMomento();
            else
                EditarMomento(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarMomento(int id)
        {

            DomainAmbientHouse.Entidades.MomentosDias momento = new DomainAmbientHouse.Entidades.MomentosDias();

            momento = servicios.BuscarMomentosDias(id);

            MomentosDiasSeleccionado = momento;


            TextBoxDescripcion.Text = momento.Descripcion;

        }

        private void NuevoMomento()
        {
            MomentosDiasSeleccionado = new DomainAmbientHouse.Entidades.MomentosDias();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.MomentosDias momento = MomentosDiasSeleccionado;

            momento.Descripcion = TextBoxDescripcion.Text;


            servicios.NuevoMomentoDia(momento);
            Response.Redirect("~/Configuracion/MomentosDia/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/MomentosDia/Index.aspx");
        }
    }
}