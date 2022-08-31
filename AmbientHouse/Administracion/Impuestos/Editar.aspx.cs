using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Administracion.Impuestos
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.Impuestos ImpuestosSeleccionado
        {
            get
            {
                return Session["ImpuestosSeleccionado"] as DomainAmbientHouse.Entidades.Impuestos;
            }
            set
            {
                Session["ImpuestosSeleccionado"] = value;
            }
        }

        private int ImpuestoId
        {
            get
            {
                return Int32.Parse(Session["ImpuestoId"].ToString());
            }
            set
            {
                Session["ImpuestoId"] = value;
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

                ImpuestoId = id;
            }


            if (id == 0)
                NuevoImpuesto();
            else
                EditarImpuesto(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarImpuesto(int id)
        {

            DomainAmbientHouse.Entidades.Impuestos impuesto = new DomainAmbientHouse.Entidades.Impuestos();

            impuesto = servicios.BuscarImpuesto(id);

            ImpuestosSeleccionado = impuesto;


            TextBoxDescripcion.Text = impuesto.Descripcion;

            if (impuesto.Porcentaje != null) TextBoxPorcentaje.Text = impuesto.Porcentaje.ToString();

        }

        private void NuevoImpuesto()
        {
            ImpuestosSeleccionado = new DomainAmbientHouse.Entidades.Impuestos();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.Impuestos impuesto = ImpuestosSeleccionado;

            impuesto.Descripcion = TextBoxDescripcion.Text;

            if (cmd.IsNumeric(TextBoxPorcentaje.Text)) impuesto.Porcentaje = double.Parse(TextBoxPorcentaje.Text);

            servicios.NuevoImpuesto(impuesto);
            Response.Redirect("~/Administracion/Impuestos/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Impuestos/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();

        }
    }
}