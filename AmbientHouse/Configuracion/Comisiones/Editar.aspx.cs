using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Configuracion.Comisiones
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.Comisiones ComisionesSeleccionado
        {
            get
            {
                return Session["ComisionesSeleccionado"] as DomainAmbientHouse.Entidades.Comisiones;
            }
            set
            {
                Session["ComisionesSeleccionado"] = value;
            }
        }

        private int ComisionesId
        {
            get
            {
                return Int32.Parse(Session["ComisionesId"].ToString());
            }
            set
            {
                Session["ComisionesId"] = value;
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

                ComisionesId = id;
            }


            if (id == 0)
                NuevoComisiones();
            else
                EditarComisiones(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarComisiones(int id)
        {

            DomainAmbientHouse.Entidades.Comisiones comisiones = new DomainAmbientHouse.Entidades.Comisiones();

            comisiones = servicios.BuscarComisiones(id);

            ComisionesSeleccionado = comisiones;

            TextBoxDescripcion.ReadOnly = true;
            TextBoxDescripcion.Text = comisiones.Descripcion;
            TextBoxPorcentaje.Text = comisiones.Porcentaje.ToString();
            TextBoxPorcentajeAdicional.Text = comisiones.PorcentajeAdicional.ToString();

        }

        private void NuevoComisiones()
        {
            ComisionesSeleccionado = new DomainAmbientHouse.Entidades.Comisiones();
            TextBoxDescripcion.ReadOnly = false;
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.Comisiones comisiones = ComisionesSeleccionado;

            comisiones.Descripcion = TextBoxDescripcion.Text;

            if (cmd.IsNumeric(TextBoxPorcentaje.Text))
            {
                comisiones.Porcentaje = double.Parse(TextBoxPorcentaje.Text);
            }

            if (cmd.IsNumeric(TextBoxPorcentajeAdicional.Text))
            {
                comisiones.PorcentajeAdicional = double.Parse(TextBoxPorcentajeAdicional.Text);
            }
            else comisiones.PorcentajeAdicional = 0;

            servicios.NuevaComisiones(comisiones);
            Response.Redirect("~/Configuracion/Comisiones/Index.aspx");
        }


        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Comisiones/Index.aspx");
        }
    }
}