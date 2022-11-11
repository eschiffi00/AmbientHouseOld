using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.Cuentas CuentasSeleccionado
        {
            get
            {
                return Session["CuentasSeleccionado"] as DomainAmbientHouse.Entidades.Cuentas;
            }
            set
            {
                Session["CuentasSeleccionado"] = value;
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

        AdministrativasServicios administrativas = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
                InicializarPagina();
            }
        }

        private void CargarListas()
        {
            DropDownListMonedas.DataSource = administrativas.ObtenerMonedas();
            DropDownListMonedas.DataTextField = "Descripcion";
            DropDownListMonedas.DataValueField = "Id";
            DropDownListMonedas.DataBind();

            DropDownListEmpresa.DataSource = administrativas.ObtenerEmpresas();
            DropDownListEmpresa.DataTextField = "RazonSocial";
            DropDownListEmpresa.DataValueField = "Id";
            DropDownListEmpresa.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CuentaId = id;
            }


            if (id == 0)
                NuevaCuenta();
            else
                EditarCuenta(id);

            SetFocus(TextBoxNombre);
        }

        private void EditarCuenta(int id)
        {

            DomainAmbientHouse.Entidades.Cuentas cuenta = new DomainAmbientHouse.Entidades.Cuentas();

            cuenta = administrativas.BuscarCuenta(id);

            CuentasSeleccionado = cuenta;

            TextBoxNombre.Text = cuenta.Nombre;
            TextBoxDescripcion.Text = cuenta.Descripcion;
            DropDownListTipoCuenta.SelectedValue = cuenta.TipoCuenta;
            DropDownListMonedas.SelectedValue = cuenta.MonedaId.ToString();
            DropDownListEmpresa.SelectedValue = cuenta.EmpresaId.ToString();

        }

        private void NuevaCuenta()
        {
            CuentasSeleccionado = new DomainAmbientHouse.Entidades.Cuentas();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.Cuentas cuenta = CuentasSeleccionado;

            cuenta.Descripcion = TextBoxDescripcion.Text;
            cuenta.Nombre = TextBoxNombre.Text;
            cuenta.TipoCuenta = DropDownListTipoCuenta.SelectedItem.Value;
            cuenta.MonedaId = Int32.Parse(DropDownListMonedas.SelectedItem.Value);
            cuenta.EmpresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);

            administrativas.GrabarCuenta(cuenta);
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }
    }
}