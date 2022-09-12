using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbEntidades.Entities;
using DbEntidades.Operators;
using NPOI.SS.Formula.Functions;
using AmbientHouse.Reportes;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace AmbientHouse.Administracion.PagoProveedores
{
    public partial class Editar : System.Web.UI.Page
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

        private List<DomainAmbientHouse.Entidades.Cheques> ListChequesSeleccionados
        {
            get
            {
                return Session["ListChequesSeleccionados"] as List<DomainAmbientHouse.Entidades.Cheques>;
            }
            set
            {
                Session["ListChequesSeleccionados"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MaskedEditExtenderFecha.Mask = "99/99/9999";

                ListChequesSeleccionados = new List<DomainAmbientHouse.Entidades.Cheques>();

                InicializarPagina();

                CargarListas();

                FormasdePago();

           
                PanelCheques.Visible = false;
                PanelTransferencia.Visible = false;
                PanelRetenciones.Visible = false;
                LabelChequeRepetido.Visible = false;

                FormasdePagoSeleccionada();

            }
        }

        private void CargarListas()
        {

           

            string CuentaDeudores =ConfigurationManager.AppSettings["CuentaDeudas"].ToString();

            DropDownListCuenta.DataSource = servicios.ListarCuentasEfectivosMasEfectivo(EmpresaId);
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

            if(ListComprobantesSeleccionados.Count > 0)
            {
                List<ComprobantesPagosDetalle> ListaPagos = new List<ComprobantesPagosDetalle>();
                

                    foreach(var comprobante in ListComprobantesSeleccionados)
                    {
                        List<ComprobantesProveedores_Detalles> ComprobanteDetalle = new List<ComprobantesProveedores_Detalles>();
                        ComprobanteDetalle.AddRange(ComprobantesProveedores_DetallesOperator.GetAllByParameter("ComprobanteProveedorId", comprobante.Id));
                        if (ComprobanteDetalle.Count >= 1)
                        {
                        var ind = 0;
                            foreach (var detalle in ComprobanteDetalle)
                            {
                                var importes = ComprobantesPagadosOperator.GetAllByParameter("ComprobanteProveedorDetalleId", detalle.Id);
                            var importe = importes.Count > 0 ? importes[ind].MontoPagado : 0;
                            if ((detalle.Importe+detalle.ValorImpuesto) > importe)
                                {

                                ComprobantesPagosDetalle ComprobantePago = new ComprobantesPagosDetalle();
                                ComprobantePago.ComprobanteProveedorDetalleId = detalle.Id;
                                ComprobantePago.NroPresupuesto = detalle.PresupuestoId is null ? 0 : detalle.PresupuestoId.Value;
                                ComprobantePago.Descripcion = detalle.Descripcion;
                                ComprobantePago.TipoMovimiento = TipoMovimientosOperator.GetOneByParameter("Id", detalle.TipoMoviemientoId).Id;
                                ComprobantePago.TMDescripcion = TipoMovimientosOperator.GetOneByParameter("Id", detalle.TipoMoviemientoId).Descripcion;
                                
                                ComprobantePago.Costo = (detalle.Importe - importe) < 0 ? 0 : (detalle.Importe - importe);
                                ComprobantePago.Costo = Math.Round(ComprobantePago.Costo, 2);
                                if(ComprobantePago.Costo == 0)
                                {
                                    importe = importe - detalle.Importe;
                                    ComprobantePago.ValorImpuesto = (detalle.ValorImpuesto - importe);
                                }
                                else {ComprobantePago.ValorImpuesto = detalle.ValorImpuesto;}
                                var iibbarba = comprobante.IIBBARBA is null ? 0 : comprobante.IIBBARBA.Value;
                                var iva105 = comprobante.Iva105 is null ? 0 : comprobante.Iva105.Value;
                                var iibbcaba = comprobante.IIBBCABA is null ? 0 : comprobante.IIBBCABA.Value;
                                if (ind == 0)
                                {
                                    ComprobantePago.ValorImpuesto = Math.Round((ComprobantePago.ValorImpuesto + iibbarba + iva105 + iibbcaba),2);
                                }
                                ComprobantePago.CostoTotal = Math.Round((ComprobantePago.Costo + ComprobantePago.ValorImpuesto),2);
                                ListaPagos.Add(ComprobantePago);
                                ind++;
                                }   
                            }
                        }
                    }
                GridViewPresupuestos.DataSource = ListaPagos;
                GridViewPresupuestos.DataBind();
            }

            if (ListComprobantesSeleccionados.Count > 1)
            {
                GridViewComprobantes.DataSource = ListComprobantesSeleccionados.ToList();
                GridViewComprobantes.DataBind();

                double totalImporteNotaCreditos = ObtenerImporteNotaCreditos(ListComprobantesSeleccionados);
                 


                EmpresaId = (int) ListComprobantesSeleccionados.FirstOrDefault().EmpresaId;

                TextBoxImporte.Text = (ListComprobantesSeleccionados.Sum(o => o.MontoFactura) - totalImporteNotaCreditos).ToString();

                TextBoxImporte.ReadOnly = true;

                TextBoxImportePagado.Text = TextBoxImporte.Text;
                TextBoxImportePagado.ReadOnly = true;

                DropDownListProveedores.DataSource = servicios.ObtenerProveedoresPorProveedores(ListComprobantesSeleccionados.Select(o => o.ProveedorId).ToList());
                DropDownListProveedores.DataTextField = "RazonSocial";
                DropDownListProveedores.DataValueField = "Id";
                DropDownListProveedores.DataBind();

            }
            else if (ListComprobantesSeleccionados.Count == 1)
            {
                GridViewComprobantes.DataSource = ListComprobantesSeleccionados.ToList();
                GridViewComprobantes.DataBind();

                double totalImporteNotaCreditos = ObtenerImporteNotaCreditos(ListComprobantesSeleccionados);

                EmpresaId = (int)ListComprobantesSeleccionados.FirstOrDefault().EmpresaId;

                double valorPagado = 0;
                foreach (var item in ListComprobantesSeleccionados)
                {
                    List<DomainAmbientHouse.Entidades.PagosProveedores> listarPagoProveedores = servicios.BuscarPagoProveedoresPorComprabante(item.Id);

                    if (listarPagoProveedores.Count() > 0)
                        valorPagado = valorPagado + listarPagoProveedores.Sum(o => o.Importe);
                }

                double saldoComprobantes = ListComprobantesSeleccionados.Sum(o => o.MontoFactura).Value - valorPagado - totalImporteNotaCreditos;

                TextBoxImporte.Text = saldoComprobantes.ToString();

                TextBoxImportePagado.Text = (valorPagado + totalImporteNotaCreditos).ToString();
                TextBoxImportePagado.ReadOnly = true;

                DropDownListProveedores.DataSource = servicios.ObtenerProveedoresPorProveedores(ListComprobantesSeleccionados.Select(o => o.ProveedorId).ToList());
                DropDownListProveedores.DataTextField = "RazonSocial";
                DropDownListProveedores.DataValueField = "Id";
                DropDownListProveedores.DataBind();

            }
            else
            {
                EditarPagoProveedor(id);
            }

            SetFocus(TextBoxImporte);
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

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            var error = 0;
            double totalaPagar = 0;
            foreach (GridViewRow fila in GridViewPresupuestos.Rows)
            {
                TableCellCollection fila2;
                fila2 = fila.Cells;
                double costo = float.Parse(fila2[5].Text);
                double valorImpuesto = float.Parse(fila2[6].Text);
                double montoPagado = 0;
                if (((TextBox)fila.FindControl("MontoaPagar")).Text != ""){
                    var montoTemp = ((TextBox)fila.FindControl("MontoaPagar")).Text;
                    montoTemp = montoTemp.Contains(".") ? montoTemp.Replace(".", ",") : montoTemp;
                    montoPagado = float.Parse(montoTemp);
                    //var algo = Int32.Parse(((TextBox)fila.FindControl("NroComprobante")).Text);
                }
                if(costo + valorImpuesto < 0)
                    {totalaPagar = totalaPagar + montoPagado + costo + valorImpuesto;}
                else 
                    { totalaPagar = totalaPagar + montoPagado;}
                var costoFinal = Math.Truncate(costo + valorImpuesto);
                var montoFinal = Math.Truncate(montoPagado);
                if (costoFinal < montoFinal && costoFinal >= 0) 
                    { error = 1; }    
            }
            var totalInt = Math.Truncate(totalaPagar);
            var ImporteInt = Math.Truncate(float.Parse(TextBoxImporte.Text));
            //if (totalaPagar != float.Parse(TextBoxImporte.Text))
            if (totalInt != ImporteInt)
            {
                error = 2;
            }


            if(error == 0)
            {
                /////INICIA GRABACION DE ComprobantesPagados/////
                ComprobantesPagados comprobante = new ComprobantesPagados();
                var ind = 0;

                foreach (GridViewRow fila in GridViewPresupuestos.Rows)
                {
                    TableCellCollection fila2;
                    fila2 = fila.Cells;
                    //comprobante.NroComprobante = Int32.Parse(((TextBox)fila.FindControl("NroComprobante")).Text);
                    comprobante.ComprobanteProveedorDetalleId = Int32.Parse(fila2[0].Text);
                    var ids = ComprobantesPagadosOperator.GetAllByParameter("ComprobanteProveedorDetalleId", comprobante.ComprobanteProveedorDetalleId.Value);
                    var id = ids.Count > 0 ? ids[ind].Id : -1;
                    comprobante.Id = id;
                    comprobante.NroPresupuesto  = fila2[1].Text != "" ? Int32.Parse(fila2[3].Text) : 0;
                    comprobante.TipoMovimiento  = TipoMovimientosOperator.GetOneByStrParameter("Descripcion", fila2[4].Text).Id;
                    comprobante.TMDescripcion   = fila2[4].Text;
                    //comprobante.MontoPagado     = float.Parse(fila2[7].Text);
                    //comprobante.NroPresupuesto = Int32.Parse(((TextBox)fila.FindControl("NroPresupuesto")).Text);
                    //comprobante.TipoMovimiento = Int32.Parse(((TextBox)fila.FindControl("TipoMovimiento")).Text);
                    //comprobante.TMDescripcion = ((TextBox)fila.FindControl("TMDescripcion")).Text;
                    comprobante.MontoPagado = float.Parse(((TextBox)fila.FindControl("MontoaPagar")).Text);
                    ComprobantesPagadosOperator.Save(comprobante);
                    ind++;
                }

                Grabar(sender, e);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "dlgOutOfRange",
                    "ShowError('" + error+"');", true);
            }
            
        }

        private void Grabar(object sender, EventArgs e)
        {
            int FormaRetenciones = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoRetenciones"].ToString());
            int FormaPagoTransferencias = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            DomainAmbientHouse.Entidades.PagosProveedores pagos = new DomainAmbientHouse.Entidades.PagosProveedores();

            pagos.NroOrdenPago = TextBoxNroOrdenPago.Text;
            pagos.Saldo = cmd.ValidarImportes(TextBoxImportePagado.Text);
            pagos.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            pagos.CuentaId = Int32.Parse(DropDownListCuenta.SelectedItem.Value);
            pagos.FormadePagoId = Int32.Parse(DropDownListFormadePago.SelectedItem.Value);
            pagos.Fecha = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            pagos.EmpleadoId = EmpleadoId;

            if (pagos.FormadePagoId == FormaRetenciones)
            {
                pagos.NroCertificado = TextBoxNroCertificado.Text;
                pagos.TipoMoviemientoId = Int32.Parse(DropDownListTipoMoviminetos.SelectedItem.Value);
            }
            else if (pagos.FormadePagoId == FormaPagoTransferencias)
            {
                pagos.FechaTransferencia = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                pagos.NroTransferencia = TextBoxNroComprobanteTrans.Text;
                pagos.ProveedorId = ProveedorId;
               
            }
            servicios.GrabarPagoProveedores(pagos, ListComprobantesSeleccionados, ListChequesSeleccionados);

            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
        }

        protected void DropDownListFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormasdePagoSeleccionada();

        }

        private void FormasdePagoSeleccionada()
        {
            int FormaPagoEfectivo = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoEfectivo"].ToString());

            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());
            int FormaChequedeTerceros = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoChequeTercero"].ToString());
            int FormaRetenciones = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoRetenciones"].ToString());

            PanelCheques.Visible = false;
            PanelTransferencia.Visible = false;
            PanelRetenciones.Visible = false;

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
                //else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaPagoEfectivo)
                //{
                //    DropDownListCuenta.Items.Clear();
                //    DropDownListCuenta.DataSource = servicios.ListarCuentasEfectivos();
                //    DropDownListCuenta.DataTextField = "Nombre";
                //    DropDownListCuenta.DataValueField = "Id";
                //    DropDownListCuenta.DataBind();
                //}
            }





            UpdatePanelPagoProveedores.Update();
        }

        protected void ButtonAgregarCheques_Click(object sender, EventArgs e)
        {
            AgregarCheques();


        }

        private void AgregarCheques()
        {

            LabelChequeRepetido.Visible = false;

            int FormaChequedeTerceros = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoChequeTercero"].ToString());

            int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString()); ;

            DomainAmbientHouse.Entidades.Cheques cheque = new DomainAmbientHouse.Entidades.Cheques();

            DomainAmbientHouse.Entidades.ChequesSearcher searcher = new DomainAmbientHouse.Entidades.ChequesSearcher();

            searcher.NroCheque = TextBoxNroCheque.Text;

            if (servicios.ListarCheques(searcher).Count() == 0)
            {

                cheque.NroCheque = TextBoxNroCheque.Text;
                cheque.Importe = cmd.ValidarImportes(TextBoxImporteCheque.Text);
                cheque.FechaEmision = DateTime.ParseExact(TextBoxFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.FechaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                cheque.BancoDescripcion = DropDownListBancos.SelectedItem.Text;

                if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaChequedeTerceros)
                    cheque.TipoCheque = "DE TERCEROS";
                else
                    cheque.TipoCheque = "PROPIO";

                cheque.Observaciones = TextBoxObservaciones.Text;
                cheque.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
                cheque.EstadoId = Pendiente;

                ListChequesSeleccionados.Add(cheque);

                GridViewCheques.DataSource = ListChequesSeleccionados.ToList();
                GridViewCheques.DataBind();


                TextBoxNroCheque.Text = "";
                TextBoxImporteCheque.Text = "";
                TextBoxFechaVencimiento.Text = "";
                TextBoxFechaEmision.Text = "";
                TextBoxObservaciones.Text = "";
            }
            else
            {
                LabelChequeRepetido.Visible = true;
            }
        }

        protected void ButtonQuitarCheques_Click(object sender, EventArgs e)
        {

        }
        //protected virtual void OnErrorReached(EventArgs e)
        //{
        //    DialogContentHandler handler = "DialogContentHandler.ashx";
        //    handler?.Invoke(this, e);
        //}
    }
}