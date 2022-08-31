using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.PresupuestosAprobados
{
    public partial class SeguirAprobados : System.Web.UI.Page
    {
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

        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
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

        private int ClienteId
        {
            get
            {
                return Int32.Parse(Session["ClienteId"].ToString());
            }
            set
            {
                Session["ClienteId"] = value;
            }
        }

        private int ClienteBisId
        {
            get
            {
                return Int32.Parse(Session["ClienteBisId"].ToString());
            }
            set
            {
                Session["ClienteBisId"] = value;
            }
        }

        private double TotalPresupuesto
        {
            get
            {
                return Double.Parse(Session["TotalPresupuesto"].ToString());
            }
            set
            {
                Session["TotalPresupuesto"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Eventos EventoSeleccionado
        {
            get
            {
                return Session["EventoSeleccionado"] as DomainAmbientHouse.Entidades.Eventos;
            }
            set
            {
                Session["EventoSeleccionado"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Presupuestos PresupuestoSeleccionado
        {
            get
            {
                return Session["PresupuestoSeleccionado"] as DomainAmbientHouse.Entidades.Presupuestos;
            }
            set
            {
                Session["PresupuestoSeleccionado"] = value;
            }
        }

        private int CantidadTotalInvitados
        {
            get
            {
                return Int32.Parse(Session["CantidadTotalInvitados"].ToString());
            }
            set
            {
                Session["CantidadTotalInvitados"] = value;
            }
        }

        private List<ClientesPipedrive> ListClientesPipe
        {
            get
            {
                return Session["ListClientesPipe"] as List<ClientesPipedrive>;
            }
            set
            {
                Session["ListClientesPipe"] = value;
            }
        }

        private List<PagosClientes> ListPagoClientes
        {
            get
            {
                return Session["ListPagoClientes"] as List<PagosClientes>;
            }
            set
            {
                Session["ListPagoClientes"] = value;
            }
        }

        AdministrativasServicios administrativas = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MaskedEditExtenderFecha.Mask = "99/99/9999";

                CargarLista();

                InicializarPagina();
                LabelMensaje.Visible = false;
                PanelPagoClientes.Visible = false;
                PanelCheques.Visible = false;
                PanelTransferencia.Visible = false;


            }

        }

        private void CargarLista()
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
            int propinas = Int32.Parse(ConfigurationManager.AppSettings["Propina"].ToString());
            int cuentaDepositoEnGarantia = Int32.Parse(ConfigurationManager.AppSettings["CuentaDEPOSITOENGARANTIA"].ToString());

            DropDownListFormadePago.DataSource = administrativas.ObtenerFormasdePago();
            DropDownListFormadePago.DataTextField = "Descripcion";
            DropDownListFormadePago.DataValueField = "Id";
            DropDownListFormadePago.DataBind();

            DropDownListBancos.DataSource = administrativas.ObtenerBancos();
            DropDownListBancos.DataTextField = "Identificador";
            DropDownListBancos.DataValueField = "Id";
            DropDownListBancos.DataBind();



            DropDownListEmpresa.DataSource = administrativas.ObtenerEmpresasBlanco();
            DropDownListEmpresa.DataTextField = "RazonSocial";
            DropDownListEmpresa.DataValueField = "Id";
            DropDownListEmpresa.DataBind();


            DropDownListTipoMovimiento.DataSource = administrativas.ObtenerTipoMovimientos().Where(o => o.Id == cuentaClientes ||
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
                                                                                                    o.Id == propinas ||
                                                                                                    o.Id == cuentaDepositoEnGarantia);
            DropDownListTipoMovimiento.DataTextField = "Identificador";
            DropDownListTipoMovimiento.DataValueField = "Id";
            DropDownListTipoMovimiento.DataBind();

            DropDownListEstadoPagos.DataSource = administrativas.BuscarEstadosPorEntidad("PagosClientes");
            DropDownListEstadoPagos.DataTextField = "Descripcion";
            DropDownListEstadoPagos.DataValueField = "Id";
            DropDownListEstadoPagos.DataBind();

        }

        private void InicializarPagina()
        {
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());


            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            LabelError.Visible = false;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;

                //TextBoxNroEvento.Text = EventoId.ToString().PadLeft(8, '0');
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
                //TextBoxNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');
            }

            CargarEvento();

            CargarPresupuesto();
            CargarDetalle();

            BuscarPagoPorPresupuestos();

            List<FacturasCliente> listFC = administrativas.BuscarFacturasClientePorNroPresupuesto(PresupuestoId);

            GridViewFacturas.DataSource = listFC;
            GridViewFacturas.DataBind();

        }

        private void BuscarPagoPorPresupuestos()
        {

            List<PagosClientes> ListPagoClientesValor = presupuestos.ObtenerPagosClientePorPresupuestoNeto(PresupuestoId).ToList();

            double indice = cmd.ValidarImportes(TextBoxIndexacion.Text);


            List<PagosClientes> list = administrativas.ObtenerIndexacion(PresupuestoId, indice, DropDownListTipoIndexacion.SelectedValue);

            if (list.Count() > 0)
            {
                PagosClientes ultimaFecha = (from s in list select s).OrderByDescending(o => o.FechaPago).OrderByDescending(o => o.Id).First();

                if (ultimaFecha != null)
                {
                    TextBoxSaldoAlDiadeHoy.Text = "";
                    TextBoxSaldoAldiaDelEvento.Text = "";
                    TextBoxSaldoAlUltimoPago.Text = "";

                    if (ultimaFecha.SaldoIndexadoAlDia != null)
                        TextBoxSaldoAlDiadeHoy.Text = System.Math.Round((double)ultimaFecha.SaldoIndexadoAlDia, 2).ToString("C");
                    if (ultimaFecha.SaldoIndexadoAlDiaEvento != null)
                        TextBoxSaldoAldiaDelEvento.Text = System.Math.Round((double)ultimaFecha.SaldoIndexadoAlDiaEvento, 2).ToString("C");
                    if (ultimaFecha.SaldoIndexadoAlaFecha != null)
                        TextBoxSaldoAlUltimoPago.Text = System.Math.Round((double)ultimaFecha.SaldoIndexadoAlaFecha, 2).ToString("C");
                    //TextBoxFechaReserva.Text = ultimaFecha.FechaReserva;
                    //TextBoxCantidadDiasIndexacion.Text = ultimaFecha.CantDias.ToString();
                }
            }
            double totalPagado = ListPagoClientesValor.Sum(o => o.ImporteNeto);

            TextBoxTotalPagado.Text = System.Math.Round(totalPagado, 2).ToString("C");


            ListPagoClientes = presupuestos.ObtenerPagosClientePorPresupuesto(PresupuestoId);

            GridViewPagos.DataSource = ListPagoClientes.ToList();
            GridViewPagos.DataBind();

        }

        private void CalcularSaldos()
        {

            double subtotal = presupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

            double saldoPago;

            saldoPago = (subtotal - double.Parse(TextBoxImporte.Text));

            //if (cmd.IsNumeric(TextBoxIndexacion.Text))
            //    saldoPago = saldoPago * (double.Parse(TextBoxIndexacion.Text) / 100);


            double subtotal1Total;
            double saldoTotal;

            subtotal1Total = presupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

            saldoTotal = subtotal1Total - double.Parse(TextBoxImporte.Text);

            //TextBoxSaldoPresupuesto.Text = (saldoTotal + saldoPago).ToString();

            //TextBoxSubtoPagado.Text = totalPagos.ToString();

            //TextBoxSaldoPresupuesto.Text = (Valor - totalPagos).ToString();

        }

        private double CalcularIva(string porcentaje)
        {

            double subtotal = presupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

            if (cmd.IsNumeric(subtotal) && cmd.IsNumeric(porcentaje))
            {
                return subtotal + (subtotal * (double.Parse(porcentaje) / 100));
            }

            return subtotal;

        }

        private void CargarDetalle()
        {

            List<PresupuestoDetalle> ListPresuDetalle = presupuestos.BuscarDetallePresupuestoAprobados(PresupuestoId);

            GridViewVentas.DataSource = ListPresuDetalle.ToList();
            GridViewVentas.DataBind();
        }

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {


            CantidadTotalInvitados = Int32.Parse(cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes).ToString());

        }

        private void CargarEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = eventos.BuscarEvento(EventoId);

            TextBoxNroEvento.Text = EventoSeleccionado.NroEvento;

            TextBoxCientesApellido.Text = EventoSeleccionado.ApellidoNombreCliente;

            ClienteId = EventoSeleccionado.ClienteId;

            if (EventoSeleccionado.ClienteBisId > 0)
                ClienteBisId = (int)EventoSeleccionado.ClienteBisId;

            LabelEjecutivo.Text = administrativas.BuscarEmpleado((int)EventoSeleccionado.EmpleadoId).ApellidoNombre;

            if (EventoSeleccionado.Indexacion != null && EventoSeleccionado.Indexacion != 0)
                TextBoxIndexacion.Text = EventoSeleccionado.Indexacion.ToString();
            else
                TextBoxIndexacion.Text = "4";


            DropDownListTipoIndexacion.SelectedValue = EventoSeleccionado.TipoIndexacion;


        }

        private void CargarPresupuesto()
        {
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);

                TextBoxNroPresupuesto.Text = PresupuestoSeleccionado.NroPresupuesto;

                TextBoxCantMayores.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) TextBoxCantAdolescentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) TextBoxCantMenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) TextBoxCantEntre3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();


                TextBoxFechaDesdeEvento.Text = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);


                //double Valor = presupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

                double Valor = presupuestos.CalcularValorTotalPresupuestoAprobado(PresupuestoId);

                double Royalty = presupuestos.CalcularValorTotalRoyaltyAprobado(PresupuestoId);


                LabelCaracteristica.Text = eventos.TraerCaracteristicas().Where(o => o.Id == PresupuestoSeleccionado.CaracteristicaId).Select(o => o.Descripcion).SingleOrDefault();
                LabelSegmentos.Text = eventos.TraerSegmentos().Where(o => o.Id == PresupuestoSeleccionado.SegmentoId).Select(o => o.Descripcion).SingleOrDefault();
                LabelTipoEvento.Text = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();
                LabelJornada.Text = eventos.TraerJornadas().Where(o => o.Id == PresupuestoSeleccionado.JornadaId).Select(o => o.Descripcion).SingleOrDefault();
                LabelMomentodelDia.Text = administrativas.ObtenerMomentosDias().Where(o => o.Id == PresupuestoSeleccionado.MomentoDiaID).Select(o => o.Descripcion).SingleOrDefault();
                LabelDuraciondelEvento.Text = administrativas.ObtenerDuracionEvento().Where(o => o.Id == PresupuestoSeleccionado.DuracionId).Select(o => o.Descripcion).SingleOrDefault();

                TextBoxHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;
                TextBoxHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;


                LabelLocaciones.Text = eventos.TraerLocaciones().Where(o => o.Id == PresupuestoSeleccionado.LocacionId).Select(o => o.Descripcion).SingleOrDefault();

                if (PresupuestoSeleccionado.SectorId != null)
                {
                    LabelSector.Text = administrativas.BuscarSector((int)PresupuestoSeleccionado.SectorId).Descripcion;
                }

                CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);

                TextBoxSubtotalPresupuesto.Text = System.Math.Round(Valor, 2).ToString("C");

                TextBoxTotalPorcOrganizador.Text = PresupuestoSeleccionado.ValorOrganizador.ToString();

                TextBoxRoyalty.Text = System.Math.Round(Royalty, 2).ToString("C");

                TotalPresupuesto = Valor;


            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void ButtonModificarFechaEvento_Click(object sender, EventArgs e)
        {
            LabelMensaje.Visible = false;
            DateTime fechaAnterior = DateTime.Parse(PresupuestoSeleccionado.FechaEvento.ToString());

            DateTime fechaNueva = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            PresupuestoSeleccionado.FechaEvento = fechaNueva;

            string HoraInicioAnterior = PresupuestoSeleccionado.HorarioEvento;
            string HoraFinAnterior = PresupuestoSeleccionado.HoraFinalizado;

            string HoraInicioNueva = TextBoxHoraInicio.Text;
            string HoraFinNueva = TextBoxHoraFin.Text;


            PresupuestoSeleccionado.HorarioEvento = TextBoxHoraInicio.Text;
            PresupuestoSeleccionado.HoraFinalizado = TextBoxHoraFin.Text;

            if (presupuestos.ActualizarFechaEvento(PresupuestoSeleccionado))
            {
                Mail mail = new Mail();

                mail.CambioFecha(PresupuestoSeleccionado.Id, PresupuestoSeleccionado.EventoId, fechaAnterior, HoraInicioAnterior, HoraFinAnterior);

                LabelMensaje.Text = "La modificacion fue echa con Exito!!!";
                LabelMensaje.ForeColor = System.Drawing.Color.Green;
                LabelMensaje.Visible = true;
            }
            else
            {
                LabelMensaje.Text = "La modificacion no fue realizada.";
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
                LabelMensaje.Visible = true;
            }


        }

        protected void GridViewVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                int Id = int.Parse(row.Cells[0].Text);

                if (presupuestos.ElimarDetallePresupuesto(Id))
                {
                    CargarPresupuesto();
                    CargarDetalle();
                    UpdatePanelCotizador.Update();
                }

            }
            else if (e.CommandName == "Cobrado")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                int Id = int.Parse(row.Cells[0].Text);

                if (presupuestos.ActualizarCobroItem(Id))
                {
                    CargarDetalle();
                    UpdatePanelCotizador.Update();
                }

            }
        }

        private bool GrabarPago()
        {

            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            int pagoEfectuado = Int32.Parse(ConfigurationManager.AppSettings["PagoClienteEfectuado"].ToString());
            int pagoPendiente = Int32.Parse(ConfigurationManager.AppSettings["PagoClientePendiente"].ToString());

            PagosClientes pagos = new PagosClientes();

            pagos.PresupuestoId = PresupuestoId;

            if (cmd.IsNumeric(TextBoxImporte.Text))
                pagos.Importe = cmd.ValidarImportes(TextBoxImporte.Text);

            pagos.FechaPago = DateTime.Parse(TextBoxFechaPago.Text);

            pagos.EmpleadoId = EmpleadoId;
            pagos.TipoMovimientoId = Int32.Parse(DropDownListTipoMovimiento.SelectedItem.Value);
            pagos.FormadePagoId = Int32.Parse(DropDownListFormadePago.SelectedItem.Value);
            pagos.CuentaId = Int32.Parse(DropDownListCuentas.SelectedItem.Value);
            pagos.EmpresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);
            pagos.Concepto = TextBoxConcepto.Text;
            pagos.NroRecibo = TextBoxNroRecibo.Text;
            pagos.TipoPago = DropDownListTipoPago.SelectedItem.Value;
            pagos.EstadoId = Int32.Parse(DropDownListEstadoPagos.SelectedItem.Value);

            //if (cmd.IsNumeric(TextBoxIndexacion.Text))
            //    pagos.Indexacion = double.Parse(TextBoxIndexacion.Text);

            DomainAmbientHouse.Entidades.Cheques cheque;
            DomainAmbientHouse.Entidades.Transferencias transferencia;

            if (pagos.FormadePagoId == FormaCheque)
            {

                cheque = new DomainAmbientHouse.Entidades.Cheques();

                int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString()); ;

                cheque.ClienteId = ClienteBisId;
                cheque.NroCheque = TextBoxNroCheque.Text;
                cheque.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                cheque.FechaEmision = DateTime.ParseExact(TextBoxFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.FechaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                cheque.BancoDescripcion = DropDownListBancos.SelectedItem.Text;
                cheque.TipoCheque = "DE TERCEROS";
                cheque.Observaciones = TextBoxObservaciones.Text;
                cheque.EstadoId = Pendiente;

                return presupuestos.GrabarPagoCliente(pagos, cheque);

            }
            else if (pagos.FormadePagoId == FormaTransferencia)
            {
                transferencia = new DomainAmbientHouse.Entidades.Transferencias();

                transferencia.ClienteId = ClienteBisId;
                transferencia.NroTransferencia = TextBoxNroComprobanteTrans.Text;
                transferencia.FechaTransferencia = DateTime.ParseExact(TextBoxFechaComprobanteTrans.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                transferencia.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
                transferencia.Comprobante = FileUploadComprobanteTransferencia.FileBytes;
                transferencia.ComprobanteExtension = System.IO.Path.GetExtension(FileUploadComprobanteTransferencia.FileName);
                transferencia.NombreArchivo = System.IO.Path.GetFileName(FileUploadComprobanteTransferencia.FileName);
                transferencia.BancoId = Int32.Parse(DropDownListCuentas.SelectedItem.Value);

                return presupuestos.GrabarPagoCliente(pagos, transferencia);

            }
            else
            {
                return presupuestos.GrabarPagoCliente(pagos);
            }


        }

        protected void ButtonGrabarPago_Click(object sender, EventArgs e)
        {

            if (ValidarPago())
            {
                GrabarPago();

                BuscarPagoPorPresupuestos();

                CalcularSaldos();

                foreach (var item in PanelPagoClientes.Controls)
                {
                    //IDENTIFICO EN EL LISTADO DE CONTROLES CUALES SON TEXTBOX
                    if (item is TextBox)
                    {

                        //IDENTIFICO CUALES ESTAN ACTIVOS
                        if (((TextBox)item).ReadOnly == false)
                            ((TextBox)item).Text = "";

                    }

                }

                PanelPagoClientes.Visible = false;

            }
            UpdatePanelCotizador.Update();
            UpdatePanelPagos.Update();

        }

        private bool ValidarPago()
        {
            LabelError.Visible = false;

            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaCheque)
            {
                if (TextBoxNroCheque.Text.Length == 0)
                {
                    LabelError.Visible = true;
                    LabelError.Text = "El nro. de cheque es requerida.";
                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaEmision.Text))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "La fecha de emisión es requerida.";
                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaVencimiento.Text))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "La fecha de vencimiento es requerida.";
                    return false;
                }

                DomainAmbientHouse.Entidades.ChequesSearcher searcher = new DomainAmbientHouse.Entidades.ChequesSearcher();

                searcher.NroCheque = TextBoxNroCheque.Text;

                if (administrativas.ListarCheques(searcher).Count() > 0)
                {
                    LabelError.Visible = true;
                    LabelError.Text = "El Nro de Cheque ya existe en el sistema.";
                    return false;

                }
            }
            else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaTransferencia)
            {
                if (TextBoxNroComprobanteTrans.Text.Length == 0)
                {
                    LabelError.Visible = true;
                    LabelError.Text = "El nro. de comprobante de transferencia es requerido.";
                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaComprobanteTrans.Text))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "La fecha de transferencia es requerido.";
                    return false;
                }

            }
            else
            {

                if (!cmd.IsDate(TextBoxFechaPago.Text))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "La fecha de pago es requerida.";
                    return false;
                }

                if (!cmd.IsNumeric(TextBoxImporte.Text))
                {
                    LabelError.Visible = true;
                    LabelError.Text = "El importe no puede ser nulo o no es un valor númerico.";
                    return false;
                }

                if (TextBoxConcepto.Text.Length == 0)
                {
                    LabelError.Visible = true;
                    LabelError.Text = "El concepto del pago es requerido.";
                    return false;
                }

            }

            return true;
        }

        protected void ButtonAgregarPago_Click(object sender, EventArgs e)
        {

            int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());


            //TextBoxTipoMovimiento.Text = administrativas.BuscarTipoMovimiento(cuentaClientes).Descripcion;
            PanelPagoClientes.Visible = true;
            UpdatePanelPagos.Update();
        }

        protected void GridViewPagos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPagos.Rows[index];

                int Id = int.Parse(row.Cells[0].Text);

                if (presupuestos.ElimarPagoCliente(Id))
                {
                    BuscarPagoPorPresupuestos();

                    UpdatePanelPagos.Update();
                }

            }
            else if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPagos.Rows[index];
                int Id = int.Parse(row.Cells[0].Text);

                PagosClientes pago = presupuestos.BuscarPagoCliente(Id);

                TextBox txtImporte = (TextBox)row.FindControl("TextBoxImporte");
                TextBox txtNroRecibo = (TextBox)row.FindControl("TextBoxNroRecibo");
                //DropDownList dropdownlistTipoPago = (DropDownList)row.FindControl("DropDownListTipoPago");


                if (cmd.IsNumeric(txtImporte.Text))
                    pago.Importe = cmd.ValidarImportes(txtImporte.Text);

                pago.NroRecibo = txtNroRecibo.Text;

                //pago.TipoPago = dropdownlistTipoPago.SelectedItem.Value;

                if (pago != null)
                {
                    try
                    {
                        presupuestos.GrabarPagoCliente(pago);

                        BuscarPagoPorPresupuestos();

                        UpdatePanelPagos.Update();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }


        }

        protected void DropDownListFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            PanelCheques.Visible = false;
            PanelTransferencia.Visible = false;

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaCheque)
            {
                PanelCheques.Visible = true;

            }

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaTransferencia)
            {
                PanelTransferencia.Visible = true;
            }

            UpdatePanelPagos.Update();

        }

        protected void GridViewVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int cobrado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleCobrado"].ToString()); ;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button pagado = (Button)e.Row.FindControl("ButtonPagado");

                Label FechaPagado = (Label)e.Row.FindControl("Fecha");

                int Id = int.Parse(e.Row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(Id);


                if (detalle.EstadoId == cobrado)
                {
                    pagado.Visible = false;

                    FechaPagado.Text = String.Format("{0:dd/MM/yyyy}", detalle.FechaCobroItem);
                }

            }
        }

        protected void GridViewPagos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtImporte = (TextBox)e.Row.FindControl("TextBoxImporte");
                TextBox txtNroRecibo = (TextBox)e.Row.FindControl("TextBoxNroRecibo");
                //DropDownList dropdownlistTipoPago = (DropDownList)e.Row.FindControl("DropDownListTipoPago");

                int Id = int.Parse(e.Row.Cells[0].Text);

                PagosClientes detalle = presupuestos.BuscarPagoCliente(Id);

                txtNroRecibo.Text = detalle.NroRecibo;
                txtImporte.Text = detalle.Importe.ToString();

                //dropdownlistTipoPago.SelectedValue = detalle.TipoPago;

            }
        }

        protected void DropDownListTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListTipoPago.SelectedItem.Value == "Reserva")
            {
                TextBoxConcepto.Text = "RESERVA PRESUPUESTO";
            }

            UpdatePanelPagos.Update();
        }

        private double CalcularIndexacion(double capital, double indexacion, int presupuestoId)
        {
            DomainAmbientHouse.Entidades.Presupuestos presupuesto = presupuestos.BuscarPresupuesto(presupuestoId);

            DateTime fechaEvento = DateTime.Parse(presupuesto.FechaEvento.ToString());


            List<PagosClientes> ListPagoClientesValor = presupuestos.ObtenerPagosClientePorPresupuestoNeto(PresupuestoId).ToList();


            var queryValorReserva = from r in ListPagoClientesValor
                                    where r.TipoPago != null && r.TipoPago.Contains("Reserva")
                                    select r;

            double valorReserva = 0;

            if (queryValorReserva != null)
            {
                valorReserva = queryValorReserva.FirstOrDefault().ImporteNeto;
            }

            //double valorReserva = (ListPagoClientesValor.Where(o => o.TipoPago.Contains("Reserva")).Count() == 0)
            //    ? 0
            //    : ListPagoClientesValor.Where(o => o.TipoPago.Contains("Reserva")).FirstOrDefault().ImporteNeto;

            double valorSena = (ListPagoClientesValor.Where(o => o.TipoPago.Contains("Seña")).Count() == 0)
                ? 0
                : ListPagoClientesValor.Where(o => o.TipoPago.Contains("Seña")).FirstOrDefault().ImporteNeto;


            double pagado = valorReserva + valorSena;

            DateTime fechaReserva = new DateTime();
            if (ListPagoClientesValor.Where(o => o.TipoPago.Equals("Reserva")).FirstOrDefault().FechaPago != null)
            {
                fechaReserva = ListPagoClientesValor.Where(o => o.TipoPago.Equals("Reserva")).FirstOrDefault().FechaPago;

                // Difference in days, hours, and minutes.
                TimeSpan ts = fechaEvento - fechaReserva;

                // Difference in days.
                int differenceInDays = ts.Days;

                float valornoElevado = (1 + (float)indexacion / 100);
                float potencia = (differenceInDays / 30);
                float saldo = ((float)capital - (float)pagado);
                double elevado = Math.Pow((float)valornoElevado, (float)potencia);
                double valorElevado = (saldo * elevado);

                return valorElevado;

            }

            return 0;
        }

        protected void ButtonIndexacion_Click(object sender, EventArgs e)
        {
            BuscarPagoPorPresupuestos();


            UpdatePanelPagos.Update();
        }

        protected void ButtonConfirmarIndexacion_Click(object sender, EventArgs e)
        {
            EventoSeleccionado.Indexacion = cmd.ValidarImportes(TextBoxIndexacion.Text);
            EventoSeleccionado.TipoIndexacion = DropDownListTipoIndexacion.SelectedItem.Value;
            eventos.GuardarEvento(EventoSeleccionado);
        }

        protected void DropDownListEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListEmpresa.SelectedItem != null)
            {
                int empresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);

                List<DomainAmbientHouse.Entidades.Cuentas> listadoCuentasPorEmpresa = administrativas.ListarCuentasProEmpresas(empresaId);

                DropDownListCuentas.DataSource = listadoCuentasPorEmpresa.OrderBy(o => o.Nombre).ToList();
                DropDownListCuentas.DataTextField = "Nombre";
                DropDownListCuentas.DataValueField = "Id";
                DropDownListCuentas.DataBind();

                UpdatePanelPagos.Update();
            }
        }

    }
}