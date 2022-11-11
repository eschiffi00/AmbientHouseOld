using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Cheques
{
    public partial class Editar1 : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();
        ClientesServicios clientes = new ClientesServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.Cheques ChequesSeleccionado
        {
            get
            {
                return Session["ChequesSeleccionado"] as DomainAmbientHouse.Entidades.Cheques;
            }
            set
            {
                Session["ChequesSeleccionado"] = value;
            }
        }

        private int ChequeId
        {
            get
            {
                return Int32.Parse(Session["ChequeId"].ToString());
            }
            set
            {
                Session["ChequeId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MaskedEditExtenderFechaEmision.Mask = "99/99/9999";
                MaskedEditExtenderFechaVencimiento.Mask = "99/99/9999";

                CargarListas();
                InicializarPagina();
            }

        }

        private void CargarListas()
        {
            DropDownListProveedor.DataSource = administracion.ListarProveedores();
            DropDownListProveedor.DataTextField = "RazonSocial";
            DropDownListProveedor.DataValueField = "Id";
            DropDownListProveedor.DataBind();

            ClientesSearcher searcher = new ClientesSearcher();

            DropDownListCliente.DataSource = clientes.BuscarClientesPorApellidoRazonSocial(searcher);
            DropDownListCliente.DataTextField = "RazonSocial";
            DropDownListCliente.DataValueField = "Id";
            DropDownListCliente.DataBind();


            List<DomainAmbientHouse.Entidades.Cuentas> listadoCuentasPorEmpresa = administracion.ObtenerCuentas().Where(o => o.TipoCuenta == "BANCARIA").ToList();

            DropDownListCuentas.DataSource = listadoCuentasPorEmpresa.OrderBy(o => o.Nombre).ToList();
            DropDownListCuentas.DataTextField = "Nombre";
            DropDownListCuentas.DataValueField = "Id";
            DropDownListCuentas.DataBind();

            DropDownListBancos.DataSource = administracion.ObtenerBancos();
            DropDownListBancos.DataTextField = "Identificador";
            DropDownListBancos.DataValueField = "Id";
            DropDownListBancos.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ChequeId = id;
            }

            if (id == 0)
            {
                NuevoCheque();
            }
            else
            {
                EditarCheque(id);
            }
            SetFocus(TextBoxNroCheque);

        }

        private void NuevoCheque()
        {
            ChequesSeleccionado = new DomainAmbientHouse.Entidades.Cheques();
        }

        private void EditarCheque(int id)
        {

            DomainAmbientHouse.Entidades.Cheques cheque = new DomainAmbientHouse.Entidades.Cheques();

            cheque = administracion.BuscarCheque(id);

            ChequesSeleccionado = cheque;

            TextBoxNroCheque.Text = cheque.NroCheque.ToString();

            if (cheque.ProveedorId != null)
                DropDownListProveedor.SelectedValue = cheque.ProveedorId.ToString();
            else
                DropDownListCliente.SelectedValue = cheque.ClienteId.ToString();

            if (cheque.CuentaId != null)
                DropDownListCuentas.SelectedValue = cheque.CuentaId.ToString();

            TextBoxFechaEmision.Text = String.Format("{0:dd/MM/yyyy}", cheque.FechaEmision);
            TextBoxFechaVencimiento.Text = String.Format("{0:dd/MM/yyyy}", cheque.FechaVencimiento);
            TextBoxObservaciones.Text = cheque.Observaciones;
            DropDownListBancos.SelectedValue = cheque.BancoId.ToString();

            TextBoxImporte.Text = cheque.Importe.ToString();

        }
        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cheques/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
                Grabar();
        }

        private void Grabar()
        {

            int chequePendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString());

            LabelErrores.Visible = false;

            DomainAmbientHouse.Entidades.Cheques cheque = ChequesSeleccionado;

            DateTime fechaEmision = DateTime.ParseExact(TextBoxFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fechaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            cheque.NroCheque = TextBoxNroCheque.Text;
            cheque.Observaciones = TextBoxObservaciones.Text;

            if (DropDownListProveedor.SelectedItem.Value != "null")
            {
                cheque.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);
            }

            if (DropDownListCliente.SelectedItem.Value != "null")
            {
                cheque.ClienteId = Int32.Parse(DropDownListCliente.SelectedItem.Value);
            }

            if (DropDownListCuentas.SelectedItem.Value != "null")
            {
                cheque.CuentaId = Int32.Parse(DropDownListCuentas.SelectedItem.Value);
            }
            cheque.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);

            cheque.FechaVencimiento = fechaVencimiento;
            cheque.FechaEmision = fechaEmision;
            cheque.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            cheque.EstadoId = chequePendiente;

            administracion.GuardarCheque(cheque);
            Response.Redirect("~/Administracion/Cheques/Index.aspx");

        }

        private bool Validar()
        {
            if (!cmd.IsDate(TextBoxFechaEmision.Text))
            {
                LabelErrores.Text = "La fecha de Emision no es una fecha valida.";
                LabelErrores.Visible = true;
                return false;
            }

            if (!cmd.IsDate(TextBoxFechaVencimiento.Text))
            {
                LabelErrores.Text = "La fecha de Vencimiento no es una fecha valida.";
                LabelErrores.Visible = true;
                return false;
            }

            return true;
        }
    }
}