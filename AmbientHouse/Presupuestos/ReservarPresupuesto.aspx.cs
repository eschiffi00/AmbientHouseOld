using AmbientHouse.Administracion.PresupuestosAprobados;
//using DbEntidades.Entities;
using DbEntidades.Operators;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;

namespace AmbientHouse.Presupuestos
{
    public partial class ReservarPresupuesto : System.Web.UI.Page
    {


        EventosServicios servicios = new EventosServicios();
        PresupuestosServicios serviciosPresupuestos = new PresupuestosServicios();
        ClientesServicios serviciosClientes = new ClientesServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();

        Comun cmd = new Comun();

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

        private List<PresupuestoDetalle> ListPresupuestoDetalle
        {
            get
            {
                return Session["ListPresupuestoDetalle"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalle"] = value;
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

        private DomainAmbientHouse.Entidades.ClientesBis ClienteBisSeleccionado
        {
            get
            {
                return Session["ClienteBisSeleccionado"] as DomainAmbientHouse.Entidades.ClientesBis;
            }
            set
            {
                Session["ClienteBisSeleccionado"] = value;
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

        private double PorcentajeOrganizador
        {
            get
            {
                return double.Parse(Session["PorcentajeOrganizadorRes"].ToString());
            }
            set
            {
                Session["PorcentajeOrganizadorRes"] = value;
            }
        }

        private double ImporteOrganizador
        {
            get
            {
                return double.Parse(Session["ImporteOrganizadorRes"].ToString());
            }
            set
            {
                Session["ImporteOrganizadorRes"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Eventos EventosPDF
        {
            get { return (DomainAmbientHouse.Entidades.Eventos)HttpContext.Current.Session["Evento"]; }
            set { HttpContext.Current.Session["Evento"] = value; }
        }

        private List<ObtenerEventosPresupuestos> ListPresupuestos
        {
            get
            {
                return Session["ListPresupuestos"] as List<ObtenerEventosPresupuestos>;
            }
            set
            {
                Session["ListPresupuestos"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelCheques.Visible = false;
                PanelTransferencia.Visible = false;

                ListPresupuestos = new List<ObtenerEventosPresupuestos>();
                ListPresupuestoDetalle = new List<PresupuestoDetalle>();

                CargarListas();

                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            double importeOrganizador = 0;
            double porcentajeOrganizador = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;

                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);

                CargarEvento();

                CargarPresupuesto();

                ObtenerEventosPresupuestos ListPresupuesto = servicios.BuscarPresupuestoParaAprobar(PresupuestoId);

                if (ListPresupuesto.ImporteOrganizador != null)
                    importeOrganizador = importeOrganizador + double.Parse(ListPresupuesto.ImporteOrganizador.ToString());


                if (ListPresupuesto.PorcentajeOrganizador != null)
                    porcentajeOrganizador = porcentajeOrganizador + double.Parse(ListPresupuesto.PorcentajeOrganizador.ToString());

                ListPresupuestos.Add(ListPresupuesto);

                List<PresupuestoDetalle> Items = serviciosPresupuestos.BuscarDetallePresupuestoAprobados(PresupuestoId);


                foreach (var item in Items)
                {
                    PresupuestoDetalle presu = new PresupuestoDetalle();

                    presu.Id = item.Id;
                    presu.PresupuestoId = item.PresupuestoId;
                    presu.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                    presu.Cannon = item.Cannon;
                    presu.CantidadAdicional = item.CantidadAdicional;
                    presu.CantInvitadosLogistica = item.CantInvitadosLogistica;
                    presu.CodigoItem = item.CodigoItem;
                    presu.ProductoId = item.ProductoId;
                    presu.Comision = item.Comision;
                    presu.Costo = item.Costo;
                    presu.Logistica = item.Logistica;
                    presu.PorcentajeComision = item.PorcentajeComision;
                    presu.PrecioItem = item.PrecioItem;
                    presu.PrecioLista = item.PrecioLista;
                    presu.PrecioMas5 = item.PrecioMas5;
                    presu.PrecioMenos10 = item.PrecioMenos10;
                    presu.PrecioMenos5 = item.PrecioMenos5;
                    presu.PrecioSeleccionado = item.PrecioSeleccionado;
                    presu.ProductoDescripcion = item.ProductoDescripcion;
                    presu.LocacionId = item.LocacionId;
                    presu.ProveedorId = item.ProveedorId;
                    presu.ProveedorRazonSocial = item.ProveedorRazonSocial;
                    presu.ServicioId = item.ServicioId;
                    presu.TipoLogisticaId = item.TipoLogisticaId;
                    presu.UnidadNegocioId = item.UnidadNegocioId;
                    presu.ValorSeleccionado = item.ValorSeleccionado;
                    presu.UsoCocina = item.UsoCocina;
                    presu.version = item.version;
                    presu.EstadoId = item.EstadoId;
                    presu.Incremento = item.Incremento;
                    presu.Descuentos = item.Descuentos;
                    presu.ValorIntermediario = item.ValorIntermediario;
                    presu.RentaUnNominal = item.RentaUnNominal;
                    presu.RentaUnPorcentaje = item.RentaUnPorcentaje;
                    presu.Comentario = item.Comentario;
                    presu.NuevoValor = item.NuevoValor;
                    presu.AnuloCanon = item.AnuloCanon;
                    presu.EstadoProveedor = item.EstadoProveedor;
                    presu.ComentarioProveedor = item.ComentarioProveedor;
                    presu.FechaCreate = item.FechaCreate;
                    presu.CostoMesas = item.CostoMesas;
                    presu.CostoSillas = item.CostoSillas;
                    presu.PrecioMesas = item.PrecioMesas;
                    presu.PrecioSillas = item.PrecioSillas;

                    ListPresupuestoDetalle.Add(presu);
                }

                ImporteOrganizador = importeOrganizador;
                PorcentajeOrganizador = porcentajeOrganizador;

                if (ListPresupuestos.Count > 0)
                {

                    var cantidadinvitados = (from c in ListPresupuestos
                                             select c.CantidadInicialInvitados +
                                                (c.CantidadInvitadosAdolecentes == null ? 0 : c.CantidadInvitadosAdolecentes) +
                                                (c.CantidadInvitadosMenores3 == null ? 0 : c.CantidadInvitadosMenores3) +
                                                (c.CantidadInvitadosMenores3y8 == null ? 0 : c.CantidadInvitadosMenores3y8)).Sum();


                    CantidadTotalInvitados = Int32.Parse(cantidadinvitados.ToString());

                    double? TotalOrganizador = ListPresupuestos.Sum(o => o.TotalOrganizador);

                    if (cmd.IsNumeric(TotalOrganizador))
                        TextBoxTotalOrganizador.Text = System.Math.Round(double.Parse(TotalOrganizador.ToString()), 2).ToString("C");

                    GridViewPresupuestosaAprobar.DataSource = ListPresupuestos.ToList();
                    GridViewPresupuestosaAprobar.DataBind();

                }


                if (ListPresupuestoDetalle.Count > 0)
                {
                    GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                    GridViewVentas.DataBind();

                    TextBoxTotalRenta.Text = ListPresupuestoDetalle.Sum(o => o.RentaUnNominal).ToString("C");

                }

                PanelCliente.Visible = true;

                CalcularTotalPresupuesto();

            }
        }

        private void CargarEvento()
        {

            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventosPDF = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = servicios.BuscarEvento(EventoId);

            EventosPDF = EventoSeleccionado;

            TextBoxMontoSenia.Text = EventoSeleccionado.MontoSena.ToString();
            TextBoxFechaSenia.Text = String.Format("{0:dd/MM/yyyy}", EventoSeleccionado.FechaSena);

            DropDownListFormadePago.SelectedValue = EventoSeleccionado.FormadePagoId.ToString();

            if (EventoSeleccionado.FormadePagoId == FormaCheque)
            {
                PanelCheques.Visible = true;

                int? chequeId = EventoSeleccionado.ChequeSenaId;

                Cheques cheque = new Cheques();

                if (chequeId != null)
                    cheque = administrativas.BuscarCheque((int)chequeId);

                if (cheque != null)
                {

                    TextBoxNroCheque.Text = cheque.NroCheque;
                    TextBoxFechaEmision.Text = String.Format("{0:dd/MM/yyyy}", cheque.FechaEmision);
                    TextBoxFechaVencimiento.Text = String.Format("{0:dd/MM/yyyy}", cheque.FechaVencimiento);

                    DropDownListBancos.SelectedValue = cheque.BancoId.ToString();

                    TextBoxObservaciones.Text = cheque.Observaciones;
                }

            }
            else if (EventoSeleccionado.FormadePagoId == FormaTransferencia)
            {

                Transferencias transferencia = administrativas.BuscarTransferenciaPorNroComprobante(EventoSeleccionado.NroComprobanteTransSenia.ToString());

                PanelTransferencia.Visible = true;

                //TextBoxNroComprobanteTrans.Text = EventoSeleccionado.NroComprobanteTransSenia.ToString();

                //TextBoxFechaComprobanteTrans.Text = String.Format("{0:dd/MM/yyyy}", EventoSeleccionado.FechaComprobanteTransSenia);

                if (transferencia != null)
                {
                    TextBoxNroComprobanteTrans.Text = transferencia.NroTransferencia.ToString();

                    TextBoxFechaComprobanteTrans.Text = String.Format("{0:dd/MM/yyyy}", transferencia.FechaTransferencia);
                }

            }

            //TextBoxArchivo.Text = EventoSeleccionado.Id.ToString() + EventoSeleccionado.ComprobanteAprovacionExtension;

            TextBoxComentario.Text = EventoSeleccionado.Comentario;

            //Image1.ImageUrl = "/Presupuestos/ImagenAprobacion.ashx";


            CargarCliente();


        }

        private void CargarCliente()
        {

            TextBoxRazonSocial.Visible = false;
            LabelRazonSocial.Visible = false;
            TextBoxApellidoyNombre.Visible = false;
            LabelApellidoyNombre.Visible = false;

            ClienteBisSeleccionado = new ClientesBis();

            ClienteBisSeleccionado = serviciosClientes.BuscarCliente((long)EventoSeleccionado.ClienteBisId);

            if (ClienteBisSeleccionado.PersonaFisicaJuridica == "FISICA")
            {
                TextBoxApellidoyNombre.Visible = true;
                LabelApellidoyNombre.Visible = true;

                TextBoxApellidoyNombre.Text = ClienteBisSeleccionado.ApellidoNombre;


            }
            else
            {
                TextBoxRazonSocial.Visible = true;
                LabelRazonSocial.Visible = true;

                TextBoxRazonSocial.Text = ClienteBisSeleccionado.RazonSocial;
            }

            ClienteId = ClienteBisSeleccionado.Id;
            TextBoxDomicilio.Text = ClienteBisSeleccionado.Direccion;
            TextBoxCuilCuit.Text = ClienteBisSeleccionado.CUILCUIT;
            DropDownListCondicionIva.SelectedValue = ClienteBisSeleccionado.CondicionIva.ToString();
            DropDownListTipoCliente.SelectedValue = ClienteBisSeleccionado.TipoCliente.ToString();

            TextBoxTelAdministracion.Text = ClienteBisSeleccionado.TelContactoAdministracion;
            TextBoxTelContratacion.Text = ClienteBisSeleccionado.TelContactoContratacion;
            TextBoxTelTesoreria.Text = ClienteBisSeleccionado.TelContactoTesoreria;

            TextBoxCorreoAdministracion.Text = ClienteBisSeleccionado.MailContactoAdministracion;
            TextBoxCorreoContratacion.Text = ClienteBisSeleccionado.MailContactoContratacion;
            TextBoxCorreoTesoreria.Text = ClienteBisSeleccionado.MailContactoTesoreia;


        }

        private void CargarPresupuesto()
        {
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            LabelNroEvent.Text = EventoId.ToString();

        }

        private void CalcularTotalPresupuesto()
        {


            double Valor = cmd.CalcularTotalPresupuestoAprobado(PresupuestoId, ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);


            TextBoxTotalPresupuesto.Text = (System.Math.Round(Valor, 2)).ToString("C");

            TextBoxTotalPAX.Text = (System.Math.Round(Valor / CantidadTotalInvitados, 2)).ToString("C");


        }

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {
            CantidadTotalInvitados = Int32.Parse(cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes).ToString());
        }

        private void CargarListas()
        {
            DropDownListCondicionIva.Items.Clear();
            DropDownListCondicionIva.Items.Add("Resp. Inscripto");
            DropDownListCondicionIva.Items.Add("Monotributo");
            DropDownListCondicionIva.Items.Add("Exento");
            DropDownListCondicionIva.Items.Add("Consumidor Final");

            DropDownListFormadePago.DataSource = administrativas.ObtenerFormasdePago();
            DropDownListFormadePago.DataTextField = "Descripcion";
            DropDownListFormadePago.DataValueField = "Id";
            DropDownListFormadePago.DataBind();

            DropDownListBancos.DataSource = administrativas.ObtenerBancos();
            DropDownListBancos.DataTextField = "Identificador";
            DropDownListBancos.DataValueField = "Id";
            DropDownListBancos.DataBind();

            DropDownListCuenta.DataSource = administrativas.ObtenerCuentas();
            DropDownListCuenta.DataTextField = "Nombre";
            DropDownListCuenta.DataValueField = "Id";
            DropDownListCuenta.DataBind();

            DropDownListEmpresas.DataSource = administrativas.ObtenerEmpresasBlanco();
            DropDownListEmpresas.DataTextField = "RazonSocial";
            DropDownListEmpresas.DataValueField = "Id";
            DropDownListEmpresas.DataBind();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GanarEvento();
            }

        }

        private bool Validar()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            LabelMensajeError.Visible = false;

            if (!cmd.IsNumeric(TextBoxMontoSenia.Text))
            {
                LabelMensajeError.Text = "Debe Cargar el Monto de la senia para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;
            }


            //if (FileUploadComprobanteMailAprobacion.HasFile == false)
            //{
            //    LabelMensajeError.Text = "Debe Cargar la imagen del Mail de Confirmacion del Presupuesto para poder continuar.";
            //    LabelMensajeError.Visible = true;

            //    return false;

            //}

            //if (!cmd.ValidarExtensionImagenes(System.IO.Path.GetExtension(FileUploadComprobanteMailAprobacion.FileName)))
            //{
            //    LabelMensajeError.Text = "El tipo de Archivo a subir como comprobante de Aprobacion no es una imagen";
            //    LabelMensajeError.Visible = true;

            //    return false;

            //}

            if (!cmd.IsDate(TextBoxFechaSenia.Text))
            {
                LabelMensajeError.Text = "Debe Cargar la fecha de la senia o la misma no es valida para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;

            }

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaCheque)
            {
                if (!cmd.IsDate(TextBoxFechaEmision.Text))
                {
                    LabelMensajeError.Text = "Debe Cargar la fecha de Emision del Cheque o la misma no es valida para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaVencimiento.Text))
                {
                    LabelMensajeError.Text = "Debe Cargar la fecha de Vencimiento del Cheque o la misma no es valida para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

                if (TextBoxNroCheque.Text == "")
                {
                    LabelMensajeError.Text = "Debe Cargar el Nro de Cheque para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }


            }
            else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaTransferencia)
            {

                if (TextBoxNroComprobanteTrans.Text == "")
                {
                    LabelMensajeError.Text = "Debe Cargar el Nro de Transferencia para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaComprobanteTrans.Text))
                {
                    LabelMensajeError.Text = "Debe Cargar la fecha de Transferencia o la misma no es valida para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }


                //if (FileUploadComprobanteTransferencia.HasFile == false)
                //{
                //    LabelMensajeError.Text = "Debe Cargar el Comprobante de Transferencia para poder continuar.";
                //    LabelMensajeError.Visible = true;

                //    return false;

                //}
            }

            return true;
        }

        private void GanarEvento()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            DomainAmbientHouse.Entidades.ClientesBis cliente = new DomainAmbientHouse.Entidades.ClientesBis();

            int EventoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());

            int PresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            cliente.Id = ClienteId;

            if (TextBoxApellidoyNombre.Visible == true)
                cliente.PersonaFisicaJuridica = "FISICA";
            else
                cliente.PersonaFisicaJuridica = "JURIDICA";

            cliente.ApellidoNombre = TextBoxApellidoyNombre.Text;
            cliente.CUILCUIT = TextBoxCuilCuit.Text;
            cliente.RazonSocial = TextBoxRazonSocial.Text;
            cliente.Direccion = TextBoxDomicilio.Text;
            cliente.CondicionIva = DropDownListCondicionIva.SelectedItem.Text;
            cliente.TipoCliente = DropDownListTipoCliente.SelectedItem.Value;

            cliente.MailContactoContratacion = TextBoxCorreoContratacion.Text;
            cliente.MailContactoAdministracion = TextBoxCorreoAdministracion.Text;
            cliente.MailContactoTesoreia = TextBoxCorreoTesoreria.Text;

            cliente.TelContactoContratacion = TextBoxTelContratacion.Text;
            cliente.TelContactoAdministracion = TextBoxTelAdministracion.Text;
            cliente.TelContactoTesoreria = TextBoxTelTesoreria.Text;

            DomainAmbientHouse.Entidades.Eventos evento = servicios.BuscarEvento(EventoId);

            if (TextBoxFechaSenia.Text != "")
            {
                evento.FechaSena = DateTime.ParseExact(TextBoxFechaSenia.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                evento.FechaSena = System.DateTime.Today;

            }
            evento.MontoSena = cmd.ValidarImportes(TextBoxMontoSenia.Text);

            evento.FormadePagoId = Int32.Parse(DropDownListFormadePago.SelectedItem.Value);
            evento.EstadoId = EventoReservado;
            evento.Comentario = TextBoxComentario.Text;
            evento.CuentaId = Int32.Parse(DropDownListCuenta.SelectedItem.Value);
            evento.EmpresaId = Int32.Parse(DropDownListEmpresas.SelectedItem.Value);

            if (DropDownListTipoPago.SelectedItem.Value == "Seña")
            {
                evento.Concepto = "SEÑA PRESUPUESTO";
                evento.TipoPago = DropDownListTipoPago.SelectedItem.Value;
            }
            else
            {
                evento.Concepto = "RESERVA PRESUPUESTO";
                evento.TipoPago = DropDownListTipoPago.SelectedItem.Value;
            }

            evento.NroRecibo = TextBoxNroRecibo.Text;

            if (cmd.IsNumeric(TextBoxNroComprobanteTrans.Text))
                evento.NroComprobanteTransSenia = TextBoxNroComprobanteTrans.Text;

            if (cmd.IsDate(TextBoxFechaComprobanteTrans.Text))
                evento.FechaComprobanteTransSenia = DateTime.Parse(TextBoxFechaComprobanteTrans.Text);

            DomainAmbientHouse.Entidades.Cheques cheque = new DomainAmbientHouse.Entidades.Cheques();

            DomainAmbientHouse.Entidades.Transferencias transferencia = new DomainAmbientHouse.Entidades.Transferencias();

            if (evento.FormadePagoId == FormaCheque)
            {
                int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString());

                cheque.NroCheque = TextBoxNroCheque.Text;
                cheque.Importe = cmd.ValidarImportes(TextBoxMontoSenia.Text);
                cheque.FechaEmision = DateTime.ParseExact(TextBoxFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.FechaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                cheque.BancoDescripcion = DropDownListBancos.SelectedItem.Text;
                cheque.TipoCheque = "DE TERCEROS";
                cheque.Observaciones = TextBoxObservaciones.Text;
                cheque.EstadoId = Pendiente;

            }
            else if ((evento.FormadePagoId == FormaTransferencia))
            {
                transferencia.NroTransferencia = TextBoxNroComprobanteTrans.Text;
                transferencia.FechaTransferencia = DateTime.ParseExact(TextBoxFechaComprobanteTrans.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                transferencia.Importe = cmd.ValidarImportes(TextBoxMontoSenia.Text);
            }

            DomainAmbientHouse.Entidades.Presupuestos presupuesto = servicios.BuscarPresupuesto(PresupuestoId);

            presupuesto.EstadoId = PresupuestoAprobado;

            Mail mailAprobacion = new Mail();

            servicios.ReservarPresupuesto(evento, presupuesto, cliente, ListPresupuestoDetalle, cheque, transferencia);

            mailAprobacion.envioMailAprobadoAdministracion(presupuesto.Id, evento.Id);
            
            
            CargarComanda();

            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void CargarComanda()
        {
            DbEntidades.Entities.Comandas comanda = new DbEntidades.Entities.Comandas();
            comanda = CargarEventoComanda();
            comanda = CargarPresupuestoComanda(comanda);
            comanda.EstadoId = EstadosOperator.GetApertura("Comandas");
            var comandaNew = ComandasOperator.Save(comanda);
            List<DbEntidades.Entities.ComandaDetalle> comandaDetalle = new List<DbEntidades.Entities.ComandaDetalle>();
            comandaDetalle = CargaDetalleComanda(comandaNew);
            foreach(var detalle in comandaDetalle)
            {
                ComandaDetalleOperator.Save(detalle);
            }

        }
        private DbEntidades.Entities.Comandas CargarEventoComanda()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();
            EventosServicios eventos = new EventosServicios();
            DbEntidades.Entities.Comandas comanda = new DbEntidades.Entities.Comandas();
            EventoSeleccionado = eventos.BuscarEvento(EventoId);

            comanda.Empresa = EventoSeleccionado.ApellidoNombreCliente;

            ClienteId = (int)EventoSeleccionado.ClienteBisId;

            ClientesServicios clienteServicios = new ClientesServicios();

            DomainAmbientHouse.Entidades.ClientesBis cliente = clienteServicios.BuscarCliente(ClienteId);

            if (cliente.RazonSocial != "")
            {
                comanda.Empresa = cliente.RazonSocial.ToUpper();
            }
            return comanda;
        }
        private DbEntidades.Entities.Comandas CargarPresupuestoComanda(DbEntidades.Entities.Comandas comanda)

        {

            EventosServicios eventos = new EventosServicios();
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);

                comanda.Adultos = PresupuestoSeleccionado.CantidadInicialInvitados;

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) comanda.Adolescentes = PresupuestoSeleccionado.CantidadInvitadosAdolecentes;
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null)comanda.Menores3 = PresupuestoSeleccionado.CantidadInvitadosMenores3;
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) comanda.Menores3y8 = PresupuestoSeleccionado.CantidadInvitadosMenores3y8;

                comanda.PresupuestoId = int.Parse(PresupuestoSeleccionado.NroPresupuesto);
                comanda.HorarioLlegada = PresupuestoSeleccionado.HorarioArmado;

                comanda.fechaEvento = PresupuestoSeleccionado.FechaEvento;

                comanda.TipoEvento = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();

                comanda.TipoExperiencia = eventos.TraerCaracteristicas().Where(o => o.Id == PresupuestoSeleccionado.CaracteristicaId).Select(o => o.Descripcion).SingleOrDefault();
                comanda.HorarioInicio = PresupuestoSeleccionado.HorarioEvento;
                comanda.HorarioFin = PresupuestoSeleccionado.HoraFinalizado;

                DomainAmbientHouse.Entidades.EmpleadosPresupuestosAprobados existeEquipo = administrativas.BuscarEquiposPorPresupuesto((int)PresupuestoId);

                int? OrganizadorId = 0;

                if (existeEquipo != null)
                    OrganizadorId = existeEquipo.OrganizadorId;

                if (OrganizadorId > 0)
                    comanda.Organizador = administrativas.BuscarEmpleado((int)OrganizadorId).ApellidoNombre;


                string Locacion = eventos.BuscarLocacion(PresupuestoSeleccionado.LocacionId).Descripcion;
                //string Locacion = eventos.TraerLocaciones().Where(o => o.Id == PresupuestoSeleccionado.LocacionId).Select(o => o.Descripcion).SingleOrDefault();

                if (PresupuestoSeleccionado.SectorId != null)
                {
                    string sector = administrativas.BuscarSector((int)PresupuestoSeleccionado.SectorId).Descripcion;

                    comanda.Locacion = Locacion.ToUpper() + " (" + sector.ToUpper() + ")";

                    return comanda;

                }

                comanda.Locacion = Locacion.ToUpper();

            }
            return comanda;
        }
        private List<DbEntidades.Entities.ComandaDetalle> CargaDetalleComanda(DbEntidades.Entities.Comandas comanda)
        {
            List<DbEntidades.Entities.ComandaDetalle> comandaDetalle = new List<DbEntidades.Entities.ComandaDetalle>();
            PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
            //obtengo todos los presupuestos para la unidad de catering y saber el tipocatering
            var idPreDet = PresupuestoDetalleOperator.GetAllByParameter("PresupuestoId", PresupuestoId.ToString()).Where(x => x.UnidadNegocioId == 3).ToList();
            if (idPreDet.Count > 0)
            {
                var tipoCatering = TipoCateringOperator.GetOneByIdentity(idPreDet[0].ServicioId.Value);
                AdministrativasServicios servicios = new AdministrativasServicios();
                //obtengo todos los elementos asociados a la experiencia
                var ListTipo = TipoCateringTiempoProductoItemOperator.GetAllByParameter("TipoCateringId", tipoCatering.Id.ToString());
                List<DbEntidades.Entities.ComandaDetalleDescripcion> itemsComanda = new List<DbEntidades.Entities.ComandaDetalleDescripcion>();
                //recorro todos los tiempos y obtengo un listado de todos los items que componen la experiencia


                foreach (var tipos in ListTipo.Where(x => x.EstadoId == 38))
                {
                    var comandaTemp = ObtenerItemsTiempo(tipos);
                    if (comandaTemp.Count > 0)
                    {
                        itemsComanda.AddRange(comandaTemp);
                    }
                }
                EventosServicios eventos = new EventosServicios();
                string prod = "";
                string cat = "";
                foreach (var item in itemsComanda)
                {
                    //Input: ItemId,Clave(TCAT + TipoCateringId),Adultos,Menores3,Menores3y8,Adolecentes
                    //Output: Cantidad

                    PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

                    PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);
                    var ratio = RatiosOperator.ObtenerValorRatio(
                        item.ItemId, 0, 0, "TCAT" + tipoCatering.Id,
                        PresupuestoSeleccionado.CantidadAdultosFinal == 0 || PresupuestoSeleccionado.CantidadAdultosFinal == null ? PresupuestoSeleccionado.CantidadInicialInvitados.Value : PresupuestoSeleccionado.CantidadAdultosFinal.Value,
                        PresupuestoSeleccionado.CantidadInvitadosMenores3 == null ? 0 : PresupuestoSeleccionado.CantidadInvitadosMenores3.Value,
                        PresupuestoSeleccionado.CantidadInvitadosMenores3y8 == null ? 0 : PresupuestoSeleccionado.CantidadInvitadosMenores3y8.Value,
                        PresupuestoSeleccionado.CantidadInvitadosAdolecentes == null ? 0 : PresupuestoSeleccionado.CantidadInvitadosAdolecentes.Value);
                    DbEntidades.Entities.ComandaDetalle detalle = new DbEntidades.Entities.ComandaDetalle();
                    detalle.ComandaId = comanda.Id;
                    detalle.Clave = string.IsNullOrEmpty(item.Descripcion) ? " " : item.Descripcion;
                    detalle.ItemId = item.ItemId;
                    //if(item.ItemId < 0 && ratio > 0)
                    //{
                    //    if(item.Descripcion.Substring(0,3) == "PRO")
                    //    {
                    //        prod = item.Descripcion;
                    //        detalle.Cantidad = System.Math.Round(ratio, 2);

                    //    }
                    //    if(item.Descripcion.Substring(0, 3) == "CAT")
                    //    {
                    //        cat = item.Descripcion;
                    //        detalle.Cantidad = System.Math.Round(ratio, 2);
                    //    }
                    //}
                    if (item.ItemId > 0)
                    {
                        detalle.Cantidad = ratio;
                        //if (prod == item.Descripcion)
                        //{
                        //    var cantidaditems = itemsComanda.Count(x => x.Descripcion == prod);
                        //    detalle.Cantidad = System.Math.Round(ratio/cantidaditems, 2);

                        //}
                        //if (cat ==item.Descripcion)
                        //{
                        //    var cantidaditems = itemsComanda.Count(x => x.Descripcion == cat);
                        //    detalle.Cantidad = System.Math.Round(ratio/cantidaditems, 2);
                        //}

                    }
                    
                    detalle.EsAdicional = 0;
                    detalle.EsProducto = 0;
                    detalle.EsItem = 0;
                    detalle.Orden = item.Tiempo;
                    comandaDetalle.Add(detalle);

                }
                return comandaDetalle;
            }
            return comandaDetalle;
        }
        private List<DbEntidades.Entities.ComandaDetalleDescripcion> ObtenerItemsTiempo(DbEntidades.Entities.TipoCateringTiempoProductoItem tipos)
        {
            List<DbEntidades.Entities.ComandaDetalleDescripcion> lista = new List<DbEntidades.Entities.ComandaDetalleDescripcion>();
            DbEntidades.Entities.ComandaDetalleDescripcion itemComanda = new DbEntidades.Entities.ComandaDetalleDescripcion();

            if (tipos.ItemId != null)
            {
                itemComanda.ItemId = tipos.ItemId.Value;
                itemComanda.CategoriaId = 0;
                itemComanda.ProductoId = 0;
                itemComanda.Descripcion = "ITEM" + tipos.ItemId;
                itemComanda.Tiempo = tipos.TiempoId;
                lista.Add(itemComanda);
            }
            if(tipos.CategoriaItemId != null)
            {
                //itemComanda.ItemId = -1;
                //itemComanda.CategoriaId = tipos.CategoriaItemId.Value;
                //itemComanda.ProductoId = 0;
                //itemComanda.Descripcion = "CAT" + tipos.CategoriaItemId;
                //itemComanda.Tiempo = tipos.TiempoId;
                //lista.Add(itemComanda);

                var items = ItemsOperator.GetAllByParameter("CategoriaItemId", tipos.CategoriaItemId.ToString());
                foreach(var item in items)
                {
                    itemComanda = new DbEntidades.Entities.ComandaDetalleDescripcion();
                    itemComanda.ItemId = item.Id;
                    itemComanda.ProductoId = 0;
                    itemComanda.Descripcion = "CAT" + tipos.CategoriaItemId;
                    itemComanda.CategoriaId = tipos.CategoriaItemId.Value;
                    itemComanda.Tiempo = tipos.TiempoId;
                    lista.Add(itemComanda);
                }
            }
            if(tipos.ProductoCateringId != null)
            {
                //itemComanda.ItemId = -1;
                //itemComanda.CategoriaId = 0;
                //itemComanda.ProductoId = tipos.ProductoCateringId.Value;
                //itemComanda.Descripcion = "PRO" + tipos.ProductoCateringId;
                //itemComanda.Tiempo = tipos.TiempoId;
                //lista.Add(itemComanda);
                var itemProducto = ProductosCateringItemsOperator.GetAllByParameter("ProductoCateringId",tipos.ProductoCateringId.ToString());
                foreach(var producto in itemProducto)
                {
                    itemComanda = new DbEntidades.Entities.ComandaDetalleDescripcion();
                    itemComanda.ItemId = producto.ItemId;
                    itemComanda.CategoriaId = 0;
                    itemComanda.Descripcion ="PRO" + tipos.ProductoCateringId;
                    itemComanda.ProductoId = tipos.ProductoCateringId.Value;
                    itemComanda.Tiempo = tipos.TiempoId;
                    lista.Add(itemComanda);
                }
            }
            return lista;
        }
        
        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
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

            UpdatePanelFormasdePago.Update();
        }

        protected void ButtonVerArchivoConfirmacion_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.Eventos evento = servicios.BuscarEvento(EventoId);

            if (evento.ComprobanteAprovacion != null)
            {
                Response.Redirect("~/Presupuestos/DescargarArchivoAprobacion.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }

        }

        protected void ButtonVerArchivoTransferencia_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.Eventos evento = servicios.BuscarEvento(EventoId);

            if (evento.ComprobanteTransferencia != null)
            {
                Response.Redirect("~/Presupuestos/DescargarArchivoTransferencia.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
        }

    }
}