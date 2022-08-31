using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Globalization;

namespace AmbientHouse.Administracion.Recibos
{
    public partial class Editar1 : System.Web.UI.Page
    {

        private int ReciboId
        {
            get
            {
                return Int32.Parse(Session["ReciboId"].ToString());
            }
            set
            {
                Session["ReciboId"] = value;
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

        private int EventoId
        {
            get
            {
                return Int32.Parse(Session["EventoId"].ToString());
            }
            set
            {
                Session["EventoId"] = value;
            }
        }

        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(Session["PresupuestoId"].ToString());
            }
            set
            {
                Session["PresupuestoId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Recibos RecibosSeleccionado
        {
            get
            {
                return Session["RecibosSeleccionado"] as DomainAmbientHouse.Entidades.Recibos;
            }
            set
            {
                Session["RecibosSeleccionado"] = value;
            }
        }

        //private DomainAmbientHouse.Entidades.ReciboDetalle ReciboDetalleSeleccionado
        //{
        //    get
        //    {
        //        return Session["ReciboDetalleSeleccionado"] as DomainAmbientHouse.Entidades.ReciboDetalle;
        //    }
        //    set
        //    {
        //        Session["ReciboDetalleSeleccionado"] = value;
        //    }
        //}

        AdministrativasServicios administracion = new AdministrativasServicios();
        PresupuestosServicios presupuesto = new PresupuestosServicios();
        ProveedoresServicios proveedores = new ProveedoresServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                InicializarPagina();

                PanelCheques.Visible = false;
                PanelTransferencia.Visible = false;

            }
        }

        private void CargarListas()
        {
            DropDownListFormaPago.DataSource = administracion.ObtenerFormasdePago();
            DropDownListFormaPago.DataTextField = "Descripcion";
            DropDownListFormaPago.DataValueField = "Id";
            DropDownListFormaPago.DataBind();

            DropDownListBancos.DataSource = administracion.ObtenerBancos();
            DropDownListBancos.DataTextField = "Identificador";
            DropDownListBancos.DataValueField = "Id";
            DropDownListBancos.DataBind();

            DropDownListBancoTransferencia.DataSource = administracion.ObtenerCuentas().Where(o => o.TipoCuenta.Equals("BANCARIA")).ToList();
            DropDownListBancoTransferencia.DataTextField = "Nombre";
            DropDownListBancoTransferencia.DataValueField = "Id";
            DropDownListBancoTransferencia.DataBind();

            DropDownListTipoMovimiento.DataSource = administracion.ObtenerTipoMovimientosParaRecibosIngresos();
            DropDownListTipoMovimiento.DataTextField = "Identificador";
            DropDownListTipoMovimiento.DataValueField = "Id";
            DropDownListTipoMovimiento.DataBind();

            DropDownListCuentas.DataSource = administracion.ObtenerCuentas();
            DropDownListCuentas.DataTextField = "Nombre";
            DropDownListCuentas.DataValueField = "Id";
            DropDownListCuentas.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ReciboId = id;
            }


            if (id == 0)
                NuevoRecibo();
            else
                EditarRecibo(id);

            SetFocus(TextBoxNroRecibo);
        }

        private void EditarRecibo(int id)
        {

            DomainAmbientHouse.Entidades.Recibos recibo = new DomainAmbientHouse.Entidades.Recibos();

            recibo = administracion.BuscarRecibo(id);

            RecibosSeleccionado = recibo;


            TextBoxConcepto.Text = recibo.Concepto;
            TextBoxFechaRecibo.Text = recibo.FechaRecibo.ToString();
           
            TextBoxNroRecibo.Text = recibo.NroRecibo;



        }

        private void NuevoRecibo()
        {
            RecibosSeleccionado = new DomainAmbientHouse.Entidades.Recibos();
        }

        private void Grabar()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

           
            DomainAmbientHouse.Entidades.Recibos recibo = RecibosSeleccionado;

            DomainAmbientHouse.Entidades.Cheques cheque = new DomainAmbientHouse.Entidades.Cheques();

            DomainAmbientHouse.Entidades.Transferencias transferencia = new DomainAmbientHouse.Entidades.Transferencias();

          

            recibo.NroRecibo = TextBoxNroRecibo.Text;
            recibo.Concepto = TextBoxConcepto.Text;
            recibo.FechaRecibo = DateTime.Parse(TextBoxFechaRecibo.Text);
            recibo.FormadePagoId = Int32.Parse(DropDownListFormaPago.SelectedItem.Value);
            recibo.EmpleadoId = EmpleadoId;
            recibo.CuentaId = Int32.Parse(DropDownListCuentas.SelectedItem.Value);

            
            if (recibo.FormadePagoId == FormaCheque)
            {
                int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString()); ;

                cheque.NroCheque = TextBoxNroCheque.Text;
                cheque.Importe = double.Parse(TextBoxImporte.Text);
                cheque.FechaEmision = DateTime.ParseExact(TextBoxFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.FechaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                cheque.BancoDescripcion = DropDownListBancos.SelectedItem.Text;
                cheque.TipoCheque = "DE TERCEROS";
                cheque.Observaciones = TextBoxObservaciones.Text;
                cheque.EstadoId = Pendiente;

            }
            else if (recibo.FormadePagoId == FormaTransferencia)
            {
              

                transferencia.BancoId = int.Parse(DropDownListBancoTransferencia.SelectedItem.Value);
                transferencia.NroTransferencia = TextBoxNroComprobanteTrans.Text;
                transferencia.FechaTransferencia = DateTime.ParseExact(TextBoxFechaComprobanteTrans.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                transferencia.Importe = double.Parse(TextBoxImporte.Text);
                transferencia.Comprobante = FileUploadComprobanteTransferencia.FileBytes;
                transferencia.ComprobanteExtension = System.IO.Path.GetExtension(FileUploadComprobanteTransferencia.FileName);
                transferencia.NombreArchivo = System.IO.Path.GetFileName(FileUploadComprobanteTransferencia.FileName);


            }

            //administracion.GrabarRecibo(recibo, ReciboDetalleSeleccionado,cheque, transferencia);

            Response.Redirect("~/Administracion/Recibos/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Recibos/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();

        }
         
        protected void DropDownListFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            PanelCheques.Visible = false;
            PanelTransferencia.Visible = false;

            if (Int32.Parse(DropDownListFormaPago.SelectedItem.Value) == FormaCheque)
            {
                PanelCheques.Visible = true;

            }

            if (Int32.Parse(DropDownListFormaPago.SelectedItem.Value) == FormaTransferencia)
            {
                PanelTransferencia.Visible = true;
            }

            UpdatePanelFormasdePago.Update();
        }

        protected void ButtonBuscarProveedor_Click(object sender, EventArgs e)
        {
            //if (TextBoxCuitProveedor.Text.Length == 11 && cmd.IsNumeric(TextBoxCuitProveedor.Text))
            //{

            //    DomainAmbientHouse.Entidades.Proveedores proveedor = proveedores.BuscarProveedoresPorCuit(TextBoxCuitProveedor.Text);

            //    if (proveedor != null)
            //    {
            //        TextBoxNroPresupuesto.Text = "";
            //        Resultado.Text = proveedor.RazonSocial.ToUpper();

            //        RecibosEventosSeleccionado = new ReciboEventoPresupuesto();

            //        RecibosEventosSeleccionado.ProveedorId = proveedor.Id;

            //        Resultado.ForeColor = System.Drawing.Color.Green;
            //        Resultado.Font.Bold = true;
            //    }
            //    else
            //    {
            //        Resultado.Text = "No se encontraron datos con el valor Ingresado.";
            //        Resultado.ForeColor = System.Drawing.Color.Red;
            //        Resultado.Font.Bold = true;
            //    }
            //}
            //else
            //{
            //    Resultado.Text = "El valor ingresado no es un Cuit Valido.";
            //    Resultado.ForeColor = System.Drawing.Color.Red;
            //    Resultado.Font.Bold = true;
            //}
        }

        protected void ButtonBuscarPresupuesto_Click(object sender, EventArgs e)
        {

            //if (TextBoxNroPresupuesto.Text.Length > 1 && cmd.IsNumeric(TextBoxNroPresupuesto.Text))
            //{
            //    int nroPresupuesto = int.Parse(TextBoxNroPresupuesto.Text);
            //    DomainAmbientHouse.Entidades.Presupuestos presu = presupuesto.BuscarPresupuesto(nroPresupuesto);

            //    if (presu != null)
            //    {
            //        TextBoxCuitProveedor.Text = "";
            //        Resultado.Text = presu.NroPresupuesto;

            //        RecibosDetalleSeleccionado = new ReciboEventoPresupuesto();

            //        RecibosEventosSeleccionado.EventoId = presu.EventoId;
            //        RecibosEventosSeleccionado.PresupuestoId = presu.Id;

            //        Resultado.ForeColor = System.Drawing.Color.Green;
            //        Resultado.Font.Bold = true;
            //    }
            //    else
            //    { 
            //        Resultado.Text = "No se encontraron datos con el valor Ingresado.";
            //        Resultado.ForeColor = System.Drawing.Color.Red;
            //        Resultado.Font.Bold = true;
            //    }
            //}
            //else
            //{
            //    Resultado.Text = "El valor ingresado no es un Nro de Presupuesto Valido.";
            //    Resultado.ForeColor = System.Drawing.Color.Red;
            //    Resultado.Font.Bold = true;
            //}
        }

    }
}