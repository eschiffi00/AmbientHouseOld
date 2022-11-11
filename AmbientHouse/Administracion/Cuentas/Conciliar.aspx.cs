using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Conciliar : System.Web.UI.Page
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

                InicializarPagina();
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

            }

            SetFocus(TextBoxImporte);
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
            movimientos.SaldoAnterior = cmd.ValidarImportes(TextBoxImporte.Text);
            movimientos.SaldoActual = cmd.ValidarImportes(TextBoxImporte.Text);
            movimientos.Descripcion = TextBoxConcepto.Text.ToUpper();
            movimientos.UsuarioId = EmpleadoId;
            movimientos.FechaMovimiento = System.DateTime.Now;
            movimientos.TipoMovimiento = "CONCILIACION";

            return administracion.GrabarMovimiento(movimientos);

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

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }
    }
}