using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Rectificatoria : System.Web.UI.Page
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

        private double SaldoActual
        {
            get
            {
                return double.Parse(Session["SaldoActual"].ToString());
            }
            set
            {
                Session["SaldoActual"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelErrores.Visible = false;
                PanelPresupuestos.Visible = false;

                InicializarPagina();
                CargarListas();
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CuentaId = id;

                DomainAmbientHouse.Entidades.Cuentas cuenta = administracion.BuscarCuenta(id);

                TextBoxCuenta.Text = cuenta.Nombre;

                DomainAmbientHouse.Entidades.Cuentas_Log log = administracion.BuscarUltimoMovimientoCuenta(CuentaId);

                if (cmd.IsNumeric(log.SaldoActual))
                {
                    TextBoxSaldo.Text = log.SaldoActual.ToString("C");
                    SaldoActual = log.SaldoActual;
                }
                else
                    SaldoActual = 0;
            }

            SetFocus(TextBoxImporte);
        }

        private void CargarListas()
        {
           
            DropDownListTipoMovimiento.DataSource = administracion.ObtenerTipoMovimientos();
            DropDownListTipoMovimiento.DataTextField = "Identificador";
            DropDownListTipoMovimiento.DataValueField = "Id";
            DropDownListTipoMovimiento.DataBind();


            DropDownListCentrodeCosto.DataSource = administracion.ObtenerCentroCosto();
            DropDownListCentrodeCosto.DataTextField = "Descripcion";
            DropDownListCentrodeCosto.DataValueField = "Id";
            DropDownListCentrodeCosto.DataBind();


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
            DomainAmbientHouse.Entidades.Cuentas_Log movimientos = new DomainAmbientHouse.Entidades.Cuentas_Log();

            movimientos.CuentaId = CuentaId;
            movimientos.SaldoAnterior = cmd.ValidarImportes(SaldoActual.ToString());
            if (DropDownListMovimiento.SelectedValue == "DEBITO")
                movimientos.SaldoActual = SaldoActual - cmd.ValidarImportes(TextBoxImporte.Text);
            else
                movimientos.SaldoActual = SaldoActual + cmd.ValidarImportes(TextBoxImporte.Text);

            movimientos.Descripcion = TextBoxConcepto.Text.ToUpper();
            movimientos.UsuarioId = EmpleadoId;
            movimientos.TipoMovimientoId = Int32.Parse(DropDownListTipoMovimiento.SelectedItem.Value);
            movimientos.TipoMovimiento = DropDownListMovimiento.SelectedItem.Value;
            movimientos.FechaMovimiento = System.DateTime.Now;

            int? presupuestoId;

            if (cmd.IsNumeric(TextBoxNroPresupuesto.Text))
                presupuestoId = Int32.Parse(TextBoxNroPresupuesto.Text);
            else
                presupuestoId = null;

            int? centroCostoId;

            if (cmd.IsNumeric(DropDownListCentrodeCosto.SelectedItem.Value))
                centroCostoId = Int32.Parse(DropDownListCentrodeCosto.SelectedItem.Value);
            else
                centroCostoId = null;
            

            return administracion.RectificarMovimiento(movimientos,presupuestoId,centroCostoId);

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

        protected void DropDownListMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListMovimiento.SelectedItem != null)
            {
                if (DropDownListMovimiento.SelectedValue == "CREDITO")
                {
                    PanelPresupuestos.Visible = true;

                    
                }
                else
                    PanelPresupuestos.Visible = false;

                UpdatePanelRectificatoria.Update();
            }
        }
    }
}