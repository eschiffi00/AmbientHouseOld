using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.PagoProveedores
{
    public partial class Pago : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.PagosProveedores PagosProveedoresSeleccionado
        {
            get
            {
                return Session["PagosProveedoresSeleccionado"] as DomainAmbientHouse.Entidades.PagosProveedores;
            }
            set
            {
                Session["PagosProveedoresSeleccionado"] = value;
            }
        }

        private int PagosProveedorId
        {
            get
            {
                return Int32.Parse(Session["PagosProveedorId"].ToString());
            }
            set
            {
                Session["PagosProveedorId"] = value;
            }
        }

        private int ProveedorId
        {
            get
            {
                return Int32.Parse(Session["ProveedorId"].ToString());
            }
            set
            {
                Session["ProveedorId"] = value;
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

        private int EmpresaId
        {
            get
            {
                return Int32.Parse(Session["EmpresaId"].ToString());
            }
            set
            {
                Session["EmpresaId"] = value;
            }
        }

        private double? Saldo
        {
            get
            {
                return double.Parse(Session["Saldo"].ToString());
            }
            set
            {
                Session["Saldo"] = value;
            }
        }

        private List<int> ProveedoresSeleccionado
        {
            get
            {
                return Session["ProveedoresSeleccionado"] as List<int>;
            }
            set
            {
                Session["ProveedoresSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.ComprobantesProveedores> ListComprobantesSeleccionados
        {
            get
            {
                return Session["ListComprobantesSeleccionados"] as List<DomainAmbientHouse.Entidades.ComprobantesProveedores>;
            }
            set
            {
                Session["ListComprobantesSeleccionados"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.OrdenPagoProveedores> ListOrdenPagoProveedoresSeleccionados
        {
            get
            {
                return Session["ListOrdenPagoProveedoresSeleccionados"] as List<DomainAmbientHouse.Entidades.OrdenPagoProveedores>;
            }
            set
            {
                Session["ListOrdenPagoProveedoresSeleccionados"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelErrores.Visible = false;
                MaskedEditExtenderFecha.Mask = "99/99/9999";

                ListOrdenPagoProveedoresSeleccionados = new List<DomainAmbientHouse.Entidades.OrdenPagoProveedores>();

                InicializarPagina();

                CargarListas();

                FormasdePago();

                PanelCheques.Visible = false;
                PanelTransferencia.Visible = false;
                PanelRetenciones.Visible = false;
                ButtonAgregarPagos.Visible = false;
                LabelChequeRepetido.Visible = false;

                ObtenerFormasdePago();
            }
        }

        private void CargarListas()
        {

            string CuentaDeudores = ConfigurationManager.AppSettings["CuentaDeudas"].ToString();

            DropDownListCuenta.DataSource = servicios.ListarCuentasProEmpresas(EmpresaId);
            DropDownListCuenta.DataTextField = "Nombre";
            DropDownListCuenta.DataValueField = "Id";
            DropDownListCuenta.DataBind();

            DropDownListFormadePago.DataSource = servicios.ObtenerFormasdePago();
            DropDownListFormadePago.DataTextField = "Descripcion";
            DropDownListFormadePago.DataValueField = "Id";
            DropDownListFormadePago.DataBind();


            DropDownListBancos.DataSource = servicios.ObtenerBancos();
            DropDownListBancos.DataTextField = "Identificador";
            DropDownListBancos.DataValueField = "Id";
            DropDownListBancos.DataBind();

            DropDownListTipoMoviminetos.DataSource = servicios.ObtenerTipoMovimientosPorPadre(CuentaDeudores);
            DropDownListTipoMoviminetos.DataTextField = "Descripcion";
            DropDownListTipoMoviminetos.DataValueField = "Id";
            DropDownListTipoMoviminetos.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                PagosProveedorId = id;
            }

            if (Request["ProveedorId"] != null)
            {
                ProveedorId = Int32.Parse(Request["ProveedorId"]);
            }

            if (ListComprobantesSeleccionados.Count > 1)
            {
                GridViewComprobantes.DataSource = ListComprobantesSeleccionados.ToList();
                GridViewComprobantes.DataBind();

                ObtenerPagosPorComprobante(ListComprobantesSeleccionados);

                double totalImporteNotaCreditos = ObtenerImporteNotaCreditos(ListComprobantesSeleccionados);

                LabelTotalFacturas.Text = "$ " + ListComprobantesSeleccionados.Sum(o => o.MontoFactura).ToString();
                LabelTotalNotaCredito.Text = "$ " + totalImporteNotaCreditos;

                if (ListComprobantesSeleccionados.FirstOrDefault().EmpresaId != null)
                    EmpresaId = (int)ListComprobantesSeleccionados.FirstOrDefault().EmpresaId;

                TextBoxImporte.Text = (ListComprobantesSeleccionados.Sum(o => o.MontoFactura) - totalImporteNotaCreditos).ToString();

                Saldo = (ListComprobantesSeleccionados.Sum(o => o.MontoFactura) - totalImporteNotaCreditos);

                TextBoxImporte.ReadOnly = false;

                DropDownListProveedores.DataSource = servicios.ObtenerProveedoresPorProveedores(ListComprobantesSeleccionados.Select(o => o.ProveedorId).ToList());
                DropDownListProveedores.DataTextField = "RazonSocial";
                DropDownListProveedores.DataValueField = "Id";
                DropDownListProveedores.DataBind();

            }
            else if (ListComprobantesSeleccionados.Count == 1)
            {
                GridViewComprobantes.DataSource = ListComprobantesSeleccionados.ToList();
                GridViewComprobantes.DataBind();

                ObtenerPagosPorComprobante(ListComprobantesSeleccionados);

                double totalImporteNotaCreditos = ObtenerImporteNotaCreditos(ListComprobantesSeleccionados);

                LabelTotalFacturas.Text = "$ " + ListComprobantesSeleccionados.Sum(o => o.MontoFactura).ToString();
                LabelTotalNotaCredito.Text = "$ " + totalImporteNotaCreditos;

                if (ListComprobantesSeleccionados.FirstOrDefault().EmpresaId != null)
                    EmpresaId = (int)ListComprobantesSeleccionados.FirstOrDefault().EmpresaId;


                double valorPagado = 0;
                foreach (var item in ListComprobantesSeleccionados)
                {
                    List<DomainAmbientHouse.Entidades.PagosProveedores> listarPagoProveedores = servicios.BuscarPagoProveedoresPorComprabante(item.Id);

                    if (listarPagoProveedores.Count() > 0)
                        valorPagado = valorPagado + listarPagoProveedores.Sum(o => o.Importe);
                }

                double saldoComprobantes = ListComprobantesSeleccionados.Sum(o => o.MontoFactura).Value - valorPagado - totalImporteNotaCreditos;

                Saldo = (valorPagado + totalImporteNotaCreditos);

                TextBoxImporte.Text = saldoComprobantes.ToString();

                DropDownListProveedores.DataSource = servicios.ObtenerProveedoresPorProveedores(ListComprobantesSeleccionados.Select(o => o.ProveedorId).ToList());
                DropDownListProveedores.DataTextField = "RazonSocial";
                DropDownListProveedores.DataValueField = "Id";
                DropDownListProveedores.DataBind();

            }
            else
            {
                EditarPagoProveedor(id);
            }

            SetFocus(TextBoxFecha);
        }

        private void ObtenerPagosPorComprobante(List<DomainAmbientHouse.Entidades.ComprobantesProveedores> ListComprobantesSeleccionados)
        {
            List<DomainAmbientHouse.Entidades.PagosProveedores> result = new List<DomainAmbientHouse.Entidades.PagosProveedores>();

            foreach (var item in ListComprobantesSeleccionados)
            {
                result = servicios.ObtenerPagosPorComprobante(item.Id);
            }

            GridViewPagosRealizados.DataSource = result.ToList();
            GridViewPagosRealizados.DataBind();

            LabelPagos.Text = "$ " + result.Select(s => s.Importe).Sum();
        }

        private double ObtenerImporteNotaCreditos(List<DomainAmbientHouse.Entidades.ComprobantesProveedores> list)
        {
            double result = 0;
            List<DomainAmbientHouse.Entidades.NotaCreditos> listTotal = new List<DomainAmbientHouse.Entidades.NotaCreditos>();

            foreach (var item in list)
            {
                List<DomainAmbientHouse.Entidades.NotaCreditos> notaCreditoRelacionados = servicios.ObtenerNotasCreditosPorComprobante(item.Id);

                foreach (var nc in notaCreditoRelacionados)
                {
                    listTotal.Add(nc);
                }

                result = result + notaCreditoRelacionados.Select(s => s.Importe).Sum();


            }

            GridViewNotasCredito.DataSource = listTotal.ToList();
            GridViewNotasCredito.DataBind();

            return result;
        }

        private void FormasdePago()
        {
            List<DomainAmbientHouse.Entidades.ProveedoresFormasdePago> listarFormadePago = servicios.BuscarFormasdePagoPorProveedor(ProveedorId).ToList();

            DropDownListFormadePago.Items.Clear();

            if (listarFormadePago.Count > 0)
            {
                DropDownListFormadePago.DataSource = listarFormadePago.ToList();
                DropDownListFormadePago.DataTextField = "Descripcion";
                DropDownListFormadePago.DataValueField = "Id";
                DropDownListFormadePago.DataBind();
            }
            else
            {
                DropDownListFormadePago.DataSource = servicios.ObtenerFormasdePago();
                DropDownListFormadePago.DataTextField = "Descripcion";
                DropDownListFormadePago.DataValueField = "Id";
                DropDownListFormadePago.DataBind();

            }
        }

        private void EditarPagoProveedor(int id)
        {

            DomainAmbientHouse.Entidades.PagosProveedores pagoProveedores = new DomainAmbientHouse.Entidades.PagosProveedores();

            ListComprobantesSeleccionados = servicios.ObtenerComprobantes().Where(o => o.Id == id).ToList();

            GridViewComprobantes.DataSource = ListComprobantesSeleccionados.ToList();
            GridViewComprobantes.DataBind();

            double totalImporteNotaCreditos = ObtenerImporteNotaCreditos(ListComprobantesSeleccionados);

            EmpresaId = (int)ListComprobantesSeleccionados.FirstOrDefault().EmpresaId;

            TextBoxImporte.Text = (ListComprobantesSeleccionados.Sum(o => o.MontoFactura) - totalImporteNotaCreditos).ToString();
            TextBoxImporte.ReadOnly = true;

            DropDownListProveedores.DataSource = servicios.ObtenerProveedoresPorProveedores(ListComprobantesSeleccionados.Select(o => o.ProveedorId).ToList());
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
        }

        protected void DropDownListFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerFormasdePago();
        }

        private void ObtenerFormasdePago()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());
            int FormaChequedeTerceros = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoChequeTercero"].ToString());
            int FormaRetenciones = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoRetenciones"].ToString());

            PanelCheques.Visible = false;
            PanelTransferencia.Visible = false;
            PanelRetenciones.Visible = false;
            ButtonAgregarPagos.Visible = false;

            if (DropDownListFormadePago.SelectedItem != null)
            {

                if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaCheque)
                {
                    PanelCheques.Visible = true;
                }
                else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaTransferencia)
                {

                    DomainAmbientHouse.Entidades.Proveedores Proveedor = servicios.BuscarProveedor(ProveedorId);

                    TextBoxCBU.Text = Proveedor.CBU;
                    PanelTransferencia.Visible = true;

                }
                else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaChequedeTerceros)
                {
                    PanelCheques.Visible = true;
                }
                else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaRetenciones)
                {
                    PanelRetenciones.Visible = true;
                }
                else
                {
                    ButtonAgregarPagos.Visible = true;
                }
            }

            UpdatePanelPagoProveedores.Update();
        }

        private void AgregarFormadePago()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());
            int FormaChequedeTerceros = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoChequeTercero"].ToString());
            int FormaRetenciones = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoRetenciones"].ToString());


            DomainAmbientHouse.Entidades.OrdenPagoProveedores OP = new DomainAmbientHouse.Entidades.OrdenPagoProveedores();

            int formaPago = Int32.Parse(DropDownListFormadePago.SelectedItem.Value);

            OP.FechaPago = TextBoxFecha.Text;
            OP.CuentaId = Int32.Parse(DropDownListCuenta.SelectedItem.Value);
            OP.FormadePagoId = Int32.Parse(DropDownListFormadePago.SelectedItem.Value);
            OP.EmpleadoId = EmpleadoId;
            OP.Saldo = double.Parse(Saldo.ToString());
            OP.ListaComprobantes = ListComprobantesSeleccionados;

            if (formaPago == FormaCheque)
            {
                DomainAmbientHouse.Entidades.ChequesSearcher searcher = new DomainAmbientHouse.Entidades.ChequesSearcher();

                searcher.NroCheque = TextBoxNroCheque.Text;

                if (servicios.ListarCheques(searcher).Count() == 0)
                {

                    OP.NroComprobante = TextBoxNroCheque.Text;
                    OP.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                    OP.FechaEmision = TextBoxFechaEmision.Text;
                    OP.FechaVencimiento = TextBoxFechaVencimiento.Text;
                    OP.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
                    OP.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                    OP.Observaciones = TextBoxObservaciones.Text;
                    OP.TipoCheque = "PROPIO";
                    OP.FormadePagoId = formaPago;
                    OP.FormadePagoDescripcion = "CHEQUE PROPIO";

                    PanelCheques.Visible = false;
                }
                else
                {

                    LabelChequeRepetido.Visible = true;
                }

            }
            else if (formaPago == FormaChequedeTerceros)
            {
                OP.NroComprobante = TextBoxNroCheque.Text;
                OP.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                OP.FechaEmision = TextBoxFechaEmision.Text;
                OP.FechaVencimiento = TextBoxFechaVencimiento.Text;
                OP.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
                OP.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                OP.Observaciones = TextBoxObservaciones.Text;
                OP.TipoCheque = "DE TERCEROS";
                OP.FormadePagoId = formaPago;
                OP.FormadePagoDescripcion = "CHEQUE DE TERCEROS";

                PanelCheques.Visible = false;

            }
            else if (formaPago == FormaTransferencia)
            {
                OP.NroComprobante = TextBoxNroComprobanteTrans.Text;
                OP.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                OP.FormadePagoId = formaPago;
                OP.FormadePagoDescripcion = "TRANSFERENCIA BANCARIA";

                PanelTransferencia.Visible = false;

            }
            else if (formaPago == FormaRetenciones)
            {
                OP.NroComprobante = TextBoxNroCertificado.Text;
                OP.TipoRetencion = Int32.Parse(DropDownListTipoMoviminetos.SelectedItem.Value);
                OP.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                OP.FormadePagoId = formaPago;
                OP.FormadePagoDescripcion = "RETENCIONES (" + DropDownListTipoMoviminetos.SelectedItem.Text + ")";

                PanelRetenciones.Visible = false;
            }
            else
            {
                OP.NroComprobante = "SIN NUMERO";
                OP.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                OP.FormadePagoDescripcion = "EFECTIVO";
            }

            OP.Id = ListOrdenPagoProveedoresSeleccionados.Count() + 1;

            ListOrdenPagoProveedoresSeleccionados.Add(OP);

            GridViewPagos.DataSource = ListOrdenPagoProveedoresSeleccionados.ToList();
            GridViewPagos.DataBind();


        }


        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            LabelErrores.Visible = false;
            if (ListOrdenPagoProveedoresSeleccionados.Count() > 0)
            {
                servicios.GrabarPagoProveedores(ListOrdenPagoProveedoresSeleccionados);
                Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
            }
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "No hay pagos agregados para el/los Comprobantes seleccionados.";
            }
        }

        protected void GridViewPagos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "QuitarItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPagos.Rows[index];


                int Id = Int32.Parse(row.Cells[0].Text);

                var itemRemove = ListOrdenPagoProveedoresSeleccionados.Where(o => o.Id == Id).FirstOrDefault();

                ListOrdenPagoProveedoresSeleccionados.Remove(itemRemove);

                GridViewPagos.DataSource = ListOrdenPagoProveedoresSeleccionados.ToList();
                GridViewPagos.DataBind();
            }

            UpdatePanelPagoProveedores.Update();
        }

        protected void ButtonAgregarCheque_Click(object sender, EventArgs e)
        {
            AgregarFormadePago();

            TextBoxImporte.Text = "";
        }

        protected void ButtonAgregarTransferencia_Click(object sender, EventArgs e)
        {
            AgregarFormadePago();

            TextBoxImporte.Text = "";
        }

        protected void ButtonAgregarRetencion_Click(object sender, EventArgs e)
        {
            AgregarFormadePago();

            TextBoxImporte.Text = "";
        }


        protected void ButtonAgregarPagos_Click(object sender, EventArgs e)
        {
            AgregarFormadePago();

            TextBoxImporte.Text = "";
        }

    }
}