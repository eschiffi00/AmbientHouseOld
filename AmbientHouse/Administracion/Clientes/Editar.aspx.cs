using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Administracion.Clientes
{
    public partial class Editar : System.Web.UI.Page
    {
        ClientesServicios servicios = new ClientesServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.ClientesBis ClientesBisSeleccionado
        {
            get
            {
                return Session["ClientesBisSeleccionado"] as DomainAmbientHouse.Entidades.ClientesBis;
            }
            set
            {
                Session["ClientesBisSeleccionado"] = value;
            }
        }

        private int ClienteId
        {
            get
            {
                return Int32.Parse(Session["ClienteBisId"].ToString());
            }
            set
            {
                Session["ClienteBisId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PersonaFisicaJuridica();

                CargarListas();

                InicializarPagina();

            }
        }

        private void CargarListas()
        {
            DropDownListCondicionIva.Items.Clear();
            DropDownListCondicionIva.Items.Add("Resp. Inscripto");
            DropDownListCondicionIva.Items.Add("Monotributo");
            DropDownListCondicionIva.Items.Add("Exento");
            DropDownListCondicionIva.Items.Add("Consumidor Final");
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ClienteId = id;
            }


            if (id == 0)
                NuevoCliente();
            else
                EditarCliente(id);

            SetFocus(TextBoxApellidoyNombre);
        }

        private void EditarCliente(int id)
        {
            TextBoxRazonSocial.Visible = false;
            TextBoxApellidoyNombre.Visible = false;
            LabelRazonSocial.Visible = false;
            LabelApellidoyNombre.Visible = false;

            DomainAmbientHouse.Entidades.ClientesBis clientes = new DomainAmbientHouse.Entidades.ClientesBis();

            clientes = servicios.BuscarCliente(id);

            ClientesBisSeleccionado = clientes;

            if (clientes.PersonaFisicaJuridica.Contains("JURIDICA"))
            {
                RadioButtonPersonaJuridica.Checked = true;
                TextBoxRazonSocial.Visible = true;
                LabelRazonSocial.Visible = true;
            }
            else if (clientes.PersonaFisicaJuridica.Contains("FISICA"))
            {
                RadioButtonPersonaFisica.Checked = true;
                TextBoxApellidoyNombre.Visible = true;
                LabelApellidoyNombre.Visible = true;
            }

            TextBoxApellidoyNombre.Text = clientes.ApellidoNombre;
            TextBoxRazonSocial.Text = clientes.RazonSocial;
            TextBoxDomicilio.Text = clientes.Direccion;
            TextBoxCuilCuit.Text = clientes.CUILCUIT;

            DropDownListCondicionIva.SelectedValue = clientes.CondicionIva;

            TextBoxCorreoAdministracion.Text = clientes.MailContactoAdministracion;
            TextBoxCorreoContratacion.Text = clientes.MailContactoContratacion;
            TextBoxCorreoTesoreria.Text = clientes.MailContactoTesoreia;
            TextBoxCorreoOrganizacion.Text = clientes.MailContactoOrganizacion;

            TextBoxTelAdministracion.Text = clientes.TelContactoAdministracion;
            TextBoxTelContratacion.Text = clientes.TelContactoContratacion;
            TextBoxTelTesoreria.Text = clientes.TelContactoTesoreria;
            TextBoxTelOrganizacion.Text = clientes.TelContactoOrganizacion;

            DropDownListTipoCliente.SelectedValue = clientes.TipoCliente;

            //TextBoxPorcentaje.Text = comisiones.Porcentaje.ToString();
            //TextBoxPorcentajeAdicional.Text = comisiones.PorcentajeAdicional.ToString();
        }

        private void NuevoCliente()
        {
            ClientesBisSeleccionado = new DomainAmbientHouse.Entidades.ClientesBis();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Clientes/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {

            DomainAmbientHouse.Entidades.ClientesBis cliente = ClientesBisSeleccionado;

            cliente.RazonSocial = TextBoxRazonSocial.Text;
            cliente.ApellidoNombre = TextBoxApellidoyNombre.Text;
            cliente.CondicionIva = DropDownListCondicionIva.SelectedValue;
            cliente.CUILCUIT = TextBoxCuilCuit.Text;
            cliente.Direccion = TextBoxDomicilio.Text;
            cliente.TipoCliente = DropDownListTipoCliente.SelectedValue;
            cliente.MailContactoAdministracion = TextBoxCorreoAdministracion.Text;
            cliente.MailContactoContratacion = TextBoxCorreoContratacion.Text;
            cliente.MailContactoTesoreia = TextBoxCorreoTesoreria.Text;
            cliente.MailContactoOrganizacion = TextBoxCorreoOrganizacion.Text;
            cliente.TelContactoAdministracion = TextBoxTelAdministracion.Text;
            cliente.TelContactoContratacion = TextBoxTelContratacion.Text;
            cliente.TelContactoTesoreria = TextBoxTelTesoreria.Text;
            cliente.TelContactoOrganizacion = TextBoxTelOrganizacion.Text;

            if (RadioButtonPersonaFisica.Checked)
                cliente.PersonaFisicaJuridica = "FISICA";
            else
                cliente.PersonaFisicaJuridica = "JURIDICA";

            servicios.GrabarCliente(cliente);

            Response.Redirect("~/Administracion/Clientes/Index.aspx");
        }

        protected void RadioButtonPersonaFisica_CheckedChanged(object sender, EventArgs e)
        {
            PersonaFisicaJuridica();

        }

        private void PersonaFisicaJuridica()
        {
            TextBoxRazonSocial.Visible = RadioButtonPersonaJuridica.Checked;
            TextBoxApellidoyNombre.Visible = RadioButtonPersonaFisica.Checked;
            LabelApellidoyNombre.Visible = RadioButtonPersonaFisica.Checked;
            LabelRazonSocial.Visible = RadioButtonPersonaJuridica.Checked;
        }

        protected void RadioButtonPersonaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            PersonaFisicaJuridica();
        }

    }
}