using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using System.Configuration;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Transferencias : System.Web.UI.Page
    {
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
                LabelErrores.Visible = false;
                LabelValorCambio.Visible = false;
                TextBoxTipoCambio.Visible = false;

                TextBoxTipoCambio.Text = "1";

                InicializarPagina();
                CargarListas();
            }
        }

        private void CargarListas()
        {
            int cuentaPrestamos = Int32.Parse(ConfigurationManager.AppSettings["CuentaPrestamos"].ToString());

            DropDownListTipoMovimiento.DataSource = administracion.ObtenerTipoMovimientos().Where(o => o.Id == cuentaPrestamos);
            DropDownListTipoMovimiento.DataTextField = "Identificador";
            DropDownListTipoMovimiento.DataValueField = "Id";
            DropDownListTipoMovimiento.DataBind();

            DropDownListCuentaDestino.DataSource = administracion.ObtenerCuentas().Where(o => o.Id != CuentaId && o.TipoCuenta != "CHEQUE");
            DropDownListCuentaDestino.DataTextField = "Nombre";
            DropDownListCuentaDestino.DataValueField = "Id";
            DropDownListCuentaDestino.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;
         
            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CuentaId = id;

                DomainAmbientHouse.Entidades.Cuentas cuenta = administracion.BuscarCuenta(id);

                TextBoxCuentaOrigen.Text = cuenta.Nombre;

            }

            SetFocus(TextBoxImporte);
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
                if (GrabarMovimiento())
                    Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        private bool GrabarMovimiento()
        {
            DomainAmbientHouse.Entidades.TransferenciasCuentas movimientos = new DomainAmbientHouse.Entidades.TransferenciasCuentas();

            movimientos.CuentaOrigenId = CuentaId;
            movimientos.CuentaDestinoId = Int32.Parse(DropDownListCuentaDestino.SelectedItem.Value);
            movimientos.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            movimientos.Concepto = TextBoxConcepto.Text.ToUpper();
            movimientos.UsuarioId = EmpleadoId;
            movimientos.TipoMovimientoId = Int32.Parse(DropDownListTipoMovimiento.SelectedItem.Value);
            if (cmd.IsNumeric(TextBoxTipoCambio.Text))
                movimientos.TipoCambio = cmd.ValidarImportes(TextBoxTipoCambio.Text);
            else
                movimientos.TipoCambio = 1;

            return administracion.GrabarTransferenciaCuenta(movimientos);

        }

        public bool Validar()
        {
            LabelErrores.Visible = false;

            if (!cmd.IsNumeric(TextBoxImporte.Text))
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "El importe no es numerico o no fue ingresado";
                return false;
            }

            if (TextBoxConcepto.Text.Length == 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "El concepto es requerido";
                return false;
            }


            return true;
        }

        protected void DropDownListCuentaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCuentaDestino.SelectedItem != null)
            {
                if (EstablecerTipodeCambio())
                {
                    LabelValorCambio.Visible = true;
                    TextBoxTipoCambio.Visible = true;
                }

                UpdatePanelTransferencias.Update();
            
            }
        }

        private bool EstablecerTipodeCambio()
        {
            int cuentaOrigen = CuentaId;
            int cuentaDestino = Int32.Parse(DropDownListCuentaDestino.SelectedItem.Value);

            DomainAmbientHouse.Entidades.Cuentas origen = administracion.BuscarCuenta(cuentaOrigen);

            DomainAmbientHouse.Entidades.Cuentas destino = administracion.BuscarCuenta(cuentaDestino);


            if (origen.MonedaId != destino.MonedaId)
                return true;
            else
                return false;
        }
    }
}