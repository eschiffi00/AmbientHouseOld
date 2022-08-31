using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Globalization;
using System.Configuration;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Egreso : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.MovimientosCuentas MovimientosSeleccionado
        {
            get
            {
                return Session["MovimientosSeleccionado"] as DomainAmbientHouse.Entidades.MovimientosCuentas;
            }
            set
            {
                Session["MovimientosSeleccionado"] = value;
            }
        }

        private int CuentaId
        {
            get
            {
                return Int32.Parse(Session["CuentaId"].ToString());
            }
            set
            {
                Session["CuentaId"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MaskedEditExtenderFecha.Mask = "99/99/9999";

                CargarListas();
                InicializarPagina();
                LabelErrorNroComprobante.Visible = false;
                LabelVerificado.Visible = false;

            }
        }

        private void InicializarPagina()
        {
            int id = 0;
            PanelImpuestos.Visible = false;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CuentaId = id;

                DomainAmbientHouse.Entidades.Cuentas cuenta = administracion.BuscarCuenta(id);
                
                TextBoxCuenta.Text = cuenta.Nombre;

                if (cuenta.TipoCuenta == "BANCARIA")
                    PanelImpuestos.Visible = true;

            }

           

            TextBoxNroComprobante.Text = Int64.Parse(System.DateTime.Now.ToString("yyyyMMddmmss")).ToString(); 
            NuevoMovimientos();

            SetFocus(TextBoxFecha);
        }

        private void NuevoMovimientos()
        {
            MovimientosSeleccionado = new DomainAmbientHouse.Entidades.MovimientosCuentas();
        }

        private void CargarListas()
        {
            int iva21 = Int32.Parse(ConfigurationManager.AppSettings["IVA21Porciento"].ToString());
            int iva27 = Int32.Parse(ConfigurationManager.AppSettings["IVA27Porciento"].ToString());
            int iva105 = Int32.Parse(ConfigurationManager.AppSettings["IVA105Porciento"].ToString());


            ComboBoxProveedor.DataSource = administracion.ObtenerProveedores();
            ComboBoxProveedor.DataTextField = "RazonSocial";
            ComboBoxProveedor.DataValueField = "Id";
            ComboBoxProveedor.DataBind();

            ComboTipoMovimiento.DataSource = administracion.ObtenerTipoMovimientosEgresos();
            ComboTipoMovimiento.DataTextField = "Identificador";
            ComboTipoMovimiento.DataValueField = "Id";
            ComboTipoMovimiento.DataBind();

            DropDownListCentroCosto.DataSource = administracion.ObtenerCentroCosto();
            DropDownListCentroCosto.DataTextField = "Descripcion";
            DropDownListCentroCosto.DataValueField = "Id";
            DropDownListCentroCosto.DataBind();

            DropDownListTipoImpuesto.DataSource = administracion.ObtenerImpuestos().Where(o=> o.Id == iva21 ||
                                                                                            o.Id == iva27 ||
                                                                                            o.Id == iva105);
            DropDownListTipoImpuesto.DataTextField = "Descripcion";
            DropDownListTipoImpuesto.DataValueField = "Id";
            DropDownListTipoImpuesto.DataBind();

            DropDownListEmpresa.DataSource = administracion.ObtenerEmpresasBlancoProveedores();
            DropDownListEmpresa.DataTextField = "RazonSocial";
            DropDownListEmpresa.DataValueField = "Id";
            DropDownListEmpresa.DataBind();


            DropDownListDegustacion.DataSource = administracion.ObtenerDegustacion();
            DropDownListDegustacion.DataTextField = "Identificador";
            DropDownListDegustacion.DataValueField = "Id";
            DropDownListDegustacion.DataBind();



        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
                GrabarySalir();
        }

        private void GrabarySalir()
        {
            Grabar();
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.MovimientosCuentas movimiento = MovimientosSeleccionado;

            movimiento.CuentaId = CuentaId;
            movimiento.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            movimiento.FechaMovimiento = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            movimiento.Descripcion = TextBoxConcepto.Text;
            movimiento.ProveedorId = Int32.Parse(ComboBoxProveedor.SelectedItem.Value);
            movimiento.CentroCostoId = Int32.Parse(DropDownListCentroCosto.SelectedItem.Value);
            movimiento.TipoMovimientoId = Int32.Parse(ComboTipoMovimiento.SelectedItem.Value);
            movimiento.NroComprobante = TextBoxNroComprobante.Text;
            movimiento.EmpleadoId = EmpleadoId;
            movimiento.EmpresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);

            if (cmd.IsNumeric(TextBoxNroPresupuesto.Text))
                movimiento.PresupuestoGastoId = Int32.Parse(TextBoxNroPresupuesto.Text);

            if (DropDownListDegustacion.SelectedItem.Value != "null")
                movimiento.DegustacionId = Int32.Parse(DropDownListDegustacion.SelectedItem.Value);

            if (DropDownListTipoImpuesto.SelectedItem.Value != "0")
            {
                movimiento.TipoImpuestoId = Int32.Parse(DropDownListTipoImpuesto.SelectedItem.Value);
                movimiento.ValorImpuesto = cmd.ValidarImportes(TextBoxValorImpuesto.Text);
            }

            if (cmd.IsNumeric(TextBoxIIBBARBA.Text))
                movimiento.IIBBARBA = cmd.ValidarImportes(TextBoxIIBBARBA.Text);

            if (cmd.IsNumeric(TextBoxIIBBCABA.Text))
                movimiento.IIBBCABA = cmd.ValidarImportes(TextBoxIIBBCABA.Text);

            if (cmd.IsNumeric(TextBoxPercepcionIVA.Text))
                movimiento.PercepcionIVA = cmd.ValidarImportes(TextBoxPercepcionIVA.Text);

            administracion.GrabarEgresoMovimientoCaja(movimiento);
        }

        private void GrabaryContinuar()
        {
            Grabar();

            TextBoxImporte.Text = "";
            TextBoxFecha.Text = "";
            TextBoxConcepto.Text = "";
            TextBoxNroComprobante.Text = Int64.Parse(System.DateTime.Now.ToString("yyyyMMddmmss")).ToString();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        private bool Validar()
        {

            int proveedorId = Int32.Parse(ComboBoxProveedor.SelectedItem.Value);

            long nroComprobante = Int64.Parse(TextBoxNroComprobante.Text);

            List<ComprobantesProveedores> cp = administracion.BuscarComprobantesPorProveedorNroComprobante(proveedorId, nroComprobante).ToList();

            if (cp.Count() > 0)
            {
                LabelErrorNroComprobante.Text = "El Nro Comprobante ya existe para ese proveedor.";
                LabelErrorNroComprobante.Visible = true;
                return false;
            }


            return true;

        }

        protected void ButtonAceptaryContinuar_Click(object sender, EventArgs e)
        {
            if (Validar())
                GrabaryContinuar();
        }

        protected void ButtonVerificar_Click(object sender, EventArgs e)
        {
            if (cmd.IsNumeric(TextBoxNroPresupuesto.Text))
            {
                LabelVerificado.Visible = true;

                if (VerificarNroPresupuesto())
                    LabelVerificado.Text = "Existe";
                else
                    LabelVerificado.Text = "No Existe";

            }
        }

        private bool VerificarNroPresupuesto()
        {
            int presupuestoId = Int32.Parse(TextBoxNroPresupuesto.Text);

            PresupuestosServicios presupuestos = new PresupuestosServicios();

            return presupuestos.BuscarPresupuesto(presupuestoId) != null;
        }

        protected void DropDownListTipoImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListTipoImpuesto.SelectedItem.Value != "0")
            {
                if (!cmd.IsNumeric(TextBoxImporte.Text))
                    return;

                double importe = cmd.ValidarImportes(TextBoxImporte.Text);

                switch (DropDownListTipoImpuesto.SelectedItem.Text)
                {

                    case "IVA 21":
                        TextBoxValorImpuesto.Text = (importe * cmd.ValidarImportes("0,21")).ToString();
                        break;
                    case "IVA 27":
                        TextBoxValorImpuesto.Text = (importe * cmd.ValidarImportes("0,27")).ToString();
                        break;
                    case "IVA 10.5":
                        TextBoxValorImpuesto.Text = (importe * cmd.ValidarImportes("0,105")).ToString();
                        break;
                    default:
                        break;
                }

                UpdatePanelEgreso.Update();
            }
        }

      

    }
}