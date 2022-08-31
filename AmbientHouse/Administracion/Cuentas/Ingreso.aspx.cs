using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Globalization;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Ingreso : System.Web.UI.Page
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

                LabelVerificado.Visible = false;
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CuentaId = id;

                TextBoxCuenta.Text = administracion.BuscarCuenta(id).Nombre;
            }


            NuevoMovimientos();


            SetFocus(TextBoxFechaPago);
        }

        private void NuevoMovimientos()
        {
            MovimientosSeleccionado = new DomainAmbientHouse.Entidades.MovimientosCuentas();
        }

        private void CargarListas()
        {
            int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());
            int cuentaImpuestosMusicales = Int32.Parse(ConfigurationManager.AppSettings["CuentaImpuestoMusicales"].ToString());
            int valletParking = Int32.Parse(ConfigurationManager.AppSettings["CuentaVallet"].ToString());
            int canon = Int32.Parse(ConfigurationManager.AppSettings["CuentaCanon"].ToString());
            int cuentaRetencionesIIBBARBA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBBARBA"].ToString());
            int cuentaGastosRepresentacion = Int32.Parse(ConfigurationManager.AppSettings["CuentaGASTOSREPRESENTACION"].ToString());
            int cuentaDiferenciaCambio = Int32.Parse(ConfigurationManager.AppSettings["CuentaDIFERENCIACAMBIO"].ToString());
            int cuentaOtrosIngresos = Int32.Parse(ConfigurationManager.AppSettings["CuentaOTROSINGRESOS"].ToString());
            int cuentaDepositoEnGarantia = Int32.Parse(ConfigurationManager.AppSettings["CuentaDEPOSITOENGARANTIA"].ToString());

            DropDownListTipoMoviemiento.DataSource = administracion.ObtenerTipoMovimientos().Where(o => o.Id == cuentaClientes ||
                                                                                                    o.Id == cuentaRetencionesGanancias ||
                                                                                                    o.Id == cuentaRetencionesIVA ||
                                                                                                    o.Id == cuentaRetencionesIIBB ||
                                                                                                    o.Id == cuentaRetencionesSUSS ||
                                                                                                    o.Id == cuentaImpuestosMusicales ||
                                                                                                    o.Id == valletParking ||
                                                                                                    o.Id == canon ||
                                                                                                    o.Id == cuentaRetencionesIIBBARBA ||
                                                                                                    o.Id == cuentaGastosRepresentacion ||
                                                                                                    o.Id == cuentaDiferenciaCambio ||
                                                                                                    o.Id == cuentaOtrosIngresos ||
                                                                                                    o.Id == cuentaDepositoEnGarantia);
            DropDownListTipoMoviemiento.DataTextField = "Identificador";
            DropDownListTipoMoviemiento.DataValueField = "Id";
            DropDownListTipoMoviemiento.DataBind();
        }

        protected void DropDownListTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListTipoPago.SelectedItem.Value == "Reserva")
            {
                TextBoxConcepto.Text = "RESERVA PRESUPUESTO";
            }

            UpdatePanelIngresos.Update();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.MovimientosCuentas movimiento = MovimientosSeleccionado;

            movimiento.CuentaId = CuentaId;
            movimiento.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            movimiento.FechaMovimiento = DateTime.ParseExact(TextBoxFechaPago.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            movimiento.Descripcion = TextBoxConcepto.Text;
            movimiento.TipoMovimientoId = Int32.Parse(DropDownListTipoMoviemiento.SelectedItem.Value);
            movimiento.PresupuestoId = Int32.Parse(TextBoxNroPresupuesto.Text);
            movimiento.NroComprobante = TextBoxNroRecibo.Text;
            movimiento.EmpleadoId = EmpleadoId;

            administracion.GrabarIngresoMovimientoCaja(movimiento);
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
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
        
    }
}