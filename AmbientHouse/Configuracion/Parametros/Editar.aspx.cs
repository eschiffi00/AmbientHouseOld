using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.Parametros
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Parametros ParametrosSeleccionado
        {
            get
            {
                return Session["ParametrosSeleccionado"] as DomainAmbientHouse.Entidades.Parametros;
            }
            set
            {
                Session["ParametrosSeleccionado"] = value;
            }
        }

        private int ParametrosId
        {
            get
            {
                return Int32.Parse(Session["ParametrosId"].ToString());
            }
            set
            {
                Session["ParametrosId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { InicializarPagina(); }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ParametrosId = id;
            }


            if (id == 0)
                NuevoParametros();
            else
                EditarParametros(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarParametros(int id)
        {

            DomainAmbientHouse.Entidades.Parametros parametros = new DomainAmbientHouse.Entidades.Parametros();

            parametros = servicios.BuscarParametro(id);

            ParametrosSeleccionado = parametros;

            TextBoxDescripcion.ReadOnly = true;
            TextBoxDescripcion.Text = parametros.Descripcion;
            TextBoxValor.Text = parametros.Valor.ToString();

        }

        private void NuevoParametros()
        {
            ParametrosSeleccionado = new DomainAmbientHouse.Entidades.Parametros();
            TextBoxDescripcion.ReadOnly = false;
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.Parametros parametros = ParametrosSeleccionado;

            parametros.Descripcion = TextBoxDescripcion.Text;
            parametros.Valor = TextBoxValor.Text;

            servicios.NuevoParametro(parametros);
            Response.Redirect("~/Configuracion/Parametros/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Parametros/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }
    }
}