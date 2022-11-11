using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Seguridad;
using DomainAmbientHouse.Servicios;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AmbientHouse.Presupuestos
{
    public partial class Editar : System.Web.UI.Page
    {
        #region Variables Session

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

        private int DuracionId
        {
            get
            {
                return Int32.Parse(Session["DuracionId"].ToString());
            }
            set
            {
                Session["DuracionId"] = value;
            }
        }

        private int MomentoDiaId
        {
            get
            {
                return Int32.Parse(Session["MomentoDiaId"].ToString());
            }
            set
            {
                Session["MomentoDiaId"] = value;
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

        private int LocacionId
        {
            get
            {
                return Int32.Parse(Session["LocacionId"].ToString());
            }
            set
            {
                Session["LocacionId"] = value;
            }
        }

        private int SectorId
        {
            get
            {
                return Int32.Parse(Session["SectorId"].ToString());
            }
            set
            {
                Session["SectorId"] = value;
            }
        }

        private int TipoCateringId
        {
            get
            {
                return Int32.Parse(Session["TipoCateringId"].ToString());
            }
            set
            {
                Session["TipoCateringId"] = value;
            }
        }

        private int SegmentosId
        {
            get
            {
                return Int32.Parse(Session["SegmentosId"].ToString());
            }
            set
            {
                Session["SegmentosId"] = value;
            }
        }

        private int CaracteristicasId
        {
            get
            {
                return Int32.Parse(Session["CaracteristicasId"].ToString());
            }
            set
            {
                Session["CaracteristicasId"] = value;
            }
        }

        private int JornadaId
        {
            get
            {
                return Int32.Parse(Session["JornadaId"].ToString());
            }
            set
            {
                Session["JornadaId"] = value;
            }
        }

        private int TipoEventoId
        {
            get
            {
                return Int32.Parse(Session["TipoEventoId"].ToString());
            }
            set
            {
                Session["TipoEventoId"] = value;
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

        private double CantidadTotalParaCotizar
        {
            get
            {
                return double.Parse(Session["CantidadTotalParaCotizar"].ToString());
            }
            set
            {
                Session["CantidadTotalParaCotizar"] = value;
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

        private int CantidadInvitadosLogistica
        {
            get
            {
                return Int32.Parse(Session["CantidadInvitadosLogistica"].ToString());
            }
            set
            {
                Session["CantidadInvitadosLogistica"] = value;
            }
        }

        private int ProveedorTecnicaId
        {
            get
            {
                return Int32.Parse(Session["ProveedorTecnicaId"].ToString());
            }
            set
            {
                Session["ProveedorTecnicaId"] = value;
            }
        }

        private int ProveedorAmbientacionId
        {
            get
            {
                return Int32.Parse(Session["ProveedorAmbientacionId"].ToString());
            }
            set
            {
                Session["ProveedorAmbientacionId"] = value;
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

        private int UnidadNegocioId
        {
            get
            {
                return Int32.Parse(Session["UnidadNegocioId"].ToString());
            }
            set
            {
                Session["UnidadNegocioId"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.PresupuestoAdicionales> ListAdicionales
        {
            get
            {
                return Session["ListAdicionales"] as List<DomainAmbientHouse.Entidades.PresupuestoAdicionales>;
            }
            set
            {
                Session["ListAdicionales"] = value;
            }
        }

        private int EstadoEvento
        {
            get
            {
                return Int32.Parse(Session["EstadoEvento"].ToString());
            }
            set
            {
                Session["EstadoEvento"] = value;
            }
        }

        private int RubroSalon
        {
            get
            {
                return Int32.Parse(Session["RubroSalon"].ToString());
            }
            set
            {
                Session["RubroSalon"] = value;
            }
        }

        private int RubroCatering
        {
            get
            {
                return Int32.Parse(Session["RubroCatering"].ToString());
            }
            set
            {
                Session["RubroCatering"] = value;
            }
        }

        private int RubroBarra
        {
            get
            {
                return Int32.Parse(Session["RubroBarra"].ToString());
            }
            set
            {
                Session["RubroBarra"] = value;
            }
        }

        private int RubroTecnica
        {
            get
            {
                return Int32.Parse(Session["RubroTecnica"].ToString());
            }
            set
            {
                Session["RubroTecnica"] = value;
            }
        }

        private int RubroAmbientacion
        {
            get
            {
                return Int32.Parse(Session["RubroAmbientacion"].ToString());
            }
            set
            {
                Session["RubroAmbientacion"] = value;
            }
        }

        private int RubroOrganizacion
        {
            get
            {
                return Int32.Parse(Session["RubroOrganizacion"].ToString());
            }
            set
            {
                Session["RubroOrganizacion"] = value;
            }
        }

        private int RubroAdicional
        {
            get
            {
                return Int32.Parse(Session["RubroAdicional"].ToString());
            }
            set
            {
                Session["RubroAdicional"] = value;
            }
        }

        private double PorcentajeVendidoSalon
        {
            get
            {
                return double.Parse(Session["PorcentajeVendidoSalon"].ToString());
            }
            set
            {
                Session["PorcentajeVendidoSalon"] = value;
            }
        }

        private double PorcentajeVendidoCatering
        {
            get
            {
                return double.Parse(Session["PorcentajeVendidoCatering"].ToString());
            }
            set
            {
                Session["PorcentajeVendidoCatering"] = value;
            }
        }

        private double PorcentajeVendidoTecnica
        {
            get
            {
                return double.Parse(Session["PorcentajeVendidoTecnica"].ToString());
            }
            set
            {
                Session["PorcentajeVendidoTecnica"] = value;
            }
        }

        private double PorcentajeVendidoBarra
        {
            get
            {
                return double.Parse(Session["PorcentajeVendidoBarra"].ToString());
            }
            set
            {
                Session["PorcentajeVendidoBarra"] = value;
            }
        }

        private double PorcentajeVendidoAmbientacion
        {
            get
            {
                return double.Parse(Session["PorcentajeVendidoAmbientacion"].ToString());
            }
            set
            {
                Session["PorcentajeVendidoAmbientacion"] = value;
            }
        }

        private double PorcentajeVendidoAdicional
        {
            get
            {
                return double.Parse(Session["PorcentajeVendidoAdicional"].ToString());
            }
            set
            {
                Session["PorcentajeVendidoAdicional"] = value;
            }
        }

        private int UsuarioPipeDriveId
        {
            get
            {
                return Int32.Parse(Session["UsuarioPipeDriveId"].ToString());
            }
            set
            {
                Session["UsuarioPipeDriveId"] = value;
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

        private int UnidadNegocioParaAdicional
        {
            get
            {
                return Int32.Parse(Session["UnidadNegocioParaAdicional"].ToString());
            }
            set
            {
                Session["UnidadNegocioParaAdicional"] = value;
            }
        }

        private string PrecioParaAdicional
        {
            get
            {
                return Session["PrecioParaAdicional"].ToString();
            }
            set
            {
                Session["PrecioParaAdicional"] = value;
            }
        }

        private string TipoCannon
        {
            get
            {
                return (Session["TipoCannon"].ToString());
            }
            set
            {
                Session["TipoCannon"] = value;
            }
        }

        private string TipoCannonBarra
        {
            get
            {
                return (Session["TipoCannonBarra"].ToString());
            }
            set
            {
                Session["TipoCannonBarra"] = value;
            }
        }

        private string TipoCannonAmbientacion
        {
            get
            {
                return (Session["TipoCannonAmbientacion"].ToString());
            }
            set
            {
                Session["TipoCannonAmbientacion"] = value;
            }
        }

        private double ValorCannon
        {
            get
            {
                return double.Parse(Session["ValorCannon"].ToString());
            }
            set
            {
                Session["ValorCannon"] = value;
            }
        }

        private double ValorCannonBarra
        {
            get
            {
                return double.Parse(Session["ValorCannonBarra"].ToString());
            }
            set
            {
                Session["ValorCannonBarra"] = value;
            }
        }

        private double ValorCannonAmbientacion
        {
            get
            {
                return double.Parse(Session["ValorCannonAmbientacion"].ToString());
            }
            set
            {
                Session["ValorCannonAmbientacion"] = value;
            }
        }

        private string Accion
        {
            get
            {
                return (Session["Accion"].ToString());
            }
            set
            {
                Session["Accion"] = value;
            }
        }

        #endregion

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

        private List<AmbientacionCI> ListAmbientacionCI
        {
            get
            {
                return Session["ListAmbientacionCI"] as List<AmbientacionCI>;
            }
            set
            {
                Session["ListAmbientacionCI"] = value;
            }
        }

        private List<Locaciones> ListLocaciones
        {
            get
            {
                return Session["ListLocaciones"] as List<Locaciones>;
            }
            set
            {
                Session["ListLocaciones"] = value;
            }
        }

        private List<Locaciones> ListLocacionesOUT
        {
            get
            {
                return Session["ListLocacionesOUT"] as List<Locaciones>;
            }
            set
            {
                Session["ListLocacionesOUT"] = value;
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

        private List<TipoCatering> ListTipoCatering
        {
            get
            {
                return Session["ListTipoCatering"] as List<TipoCatering>;
            }
            set
            {
                Session["ListTipoCatering"] = value;
            }
        }

        private List<TipoServicios> ListTipoServicios
        {
            get
            {
                return Session["ListTipoServicios"] as List<TipoServicios>;
            }
            set
            {
                Session["ListTipoServicios"] = value;
            }
        }

        private List<Categorias> ListCategorias
        {
            get
            {
                return Session["ListCategorias"] as List<Categorias>;
            }
            set
            {
                Session["ListCategorias"] = value;
            }
        }

        private List<Adicionales> ListAdicionalesFiltrados
        {
            get
            {
                return Session["ListAdicionalesFiltrados"] as List<Adicionales>;
            }
            set
            {
                Session["ListAdicionalesFiltrados"] = value;
            }
        }

        private PresupuestoPDF Presupuestos
        {
            get { return (PresupuestoPDF)HttpContext.Current.Session["PresupuestoCliente"]; }
            set { HttpContext.Current.Session["PresupuestoCliente"] = value; }
        }

        private Negocio NegociosPipeDrive
        {
            get { return (Negocio)HttpContext.Current.Session["NuevoNegocio"]; }
            set { HttpContext.Current.Session["NuevoNegocio"] = value; }
        }

        private double TotalPresupuesto
        {
            get
            {
                return double.Parse(Session["TotalPresupuesto"].ToString());
            }
            set
            {
                Session["TotalPresupuesto"] = value;
            }
        }

        private double TotalOrganizador
        {
            get
            {
                return double.Parse(Session["TotalOrganizador"].ToString());
            }
            set
            {
                Session["TotalOrganizador"] = value;
            }
        }

        private double TotalOrganizadorRoyalty
        {
            get
            {
                return double.Parse(Session["TotalOrganizadorRoyalty"].ToString());
            }
            set
            {
                Session["TotalOrganizadorRoyalty"] = value;
            }
        }

        private List<Locaciones> ListLocacionesUsuarios
        {
            get
            {
                return Session["ListLocacionesUsuarios"] as List<Locaciones>;
            }
            set
            {
                Session["ListLocacionesUsuarios"] = value;
            }
        }

        public EventosServicios servicios = new EventosServicios();
        public ClientesServicios serviciosClientes = new ClientesServicios();
        public AdministrativasServicios serviciosAdministrativas = new AdministrativasServicios();
        public ProveedoresServicios proveedorServicios = new ProveedoresServicios();
        private PresupuestosServicios serviciosPresupuestos = new PresupuestosServicios();
        public SeguridadServicios seguridad = new SeguridadServicios();

        public Comun cmd = new Comun();
        public Pipedrive pipe = new Pipedrive();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListTipoCatering = new List<TipoCatering>();
                ListTipoServicios = new List<TipoServicios>();
                ListCategorias = new List<Categorias>();
                ListAdicionalesFiltrados = new List<Adicionales>();

                ListPresupuestoDetalle = new List<PresupuestoDetalle>();

                CargarListas();

                CargarVariablesSession();

                ClienteId = 0;
                EstadoEvento = 0;

                Accion = "A";
                CargarListasTipoCateringTipoTecnica();
                CargarListasAmbientacion();

                Controles();

                InicializarPagina();

                PanelAmbientacionCorporativoInformal.Visible = false;
                ListAmbientacionCI = new List<AmbientacionCI>();

            }

        }

        private void InicializarPagina()
        {
            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
            }


            if (EventoId > 0 && PresupuestoId == 0)
            {

                EstadoEvento = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            }

            if (EventoId == 0)
                NuevoEvento();
            else
                EditarEvento();
        }

        private void NuevoEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();
        }

        private void EditarEvento()
        {

            CargarEvento();



            CargarPresupuesto();

            CargarListasAmbientacion();

            ListPresupuestoDetalle = serviciosPresupuestos.BuscarDetallePresupuesto(PresupuestoId);


            if (ListPresupuestoDetalle.Count > 0)
            {
                Locaciones loc = ListLocaciones.Where(o => o.Id == LocacionId).SingleOrDefault();

                GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                GridViewVentas.DataBind();


                HabilitarDeshabilitarDropdownList(false);

                CalcularTotalPresupuesto();

                CalcularSubTotalComision();

                CalcularRenta();

                PanelArmarCotizacion.Visible = true;
                ButtonAgregarItem.Visible = true;

            }

        }

        private void EditarEventoAdicional()
        {

            CargarEvento();

            CargarPresupuesto();

            ListPresupuestoDetalle = serviciosPresupuestos.BuscarDetallePresupuesto(PresupuestoId);


            if (ListPresupuestoDetalle.Count > 0)
            {
                GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                GridViewVentas.DataBind();


                HabilitarDeshabilitarDropdownList(false);

                CalcularTotalPresupuesto();

                CalcularSubTotalComision();

                CalcularRenta();

                PanelArmarCotizacion.Visible = true;
                ButtonAgregarItem.Visible = true;

            }

        }

        private void CalcularSubTotalComision()
        {
            var query = (from L in ListPresupuestoDetalle
                         select L.Comision).Sum();

            //TextBoxSubTotalComision.Text = query.ToString("C");
        }

        private void CalcularTotalPresupuesto()
        {

            double coeficienteRoyalty = double.Parse(ConfigurationManager.AppSettings["coeficienteRoyalty"].ToString());

            coeficienteRoyalty = (coeficienteRoyalty / 100);

            var query = (from L in ListPresupuestoDetalle
                         select L.ValorSeleccionado + (L.Cannon == null ? 0 : L.Cannon)
                                                    + (L.Logistica == null ? 0 : L.Logistica)
                                                    + (L.UsoCocina == null ? 0 : L.UsoCocina)
                                                    + (L.ValorIntermediario == null ? 0 : L.ValorIntermediario)
                                                    + (L.PrecioMesas == null ? 0 : L.PrecioMesas)
                                                    + (L.PrecioSillas == null ? 0 : L.PrecioSillas)).Sum();

            double TotalOrganizador = 0;

            double TotalOrganizadorRoyalty = 0;

            if (cmd.IsNumeric(TextBoxPorcentajeOrganizador.Text))
            {
                TotalOrganizador = double.Parse(query.ToString()) * (double.Parse(TextBoxPorcentajeOrganizador.Text) / 100);

                TotalOrganizadorRoyalty = (double.Parse(query.ToString()) * (double.Parse(TextBoxPorcentajeOrganizador.Text) / 100)) * coeficienteRoyalty;
            }

            if (cmd.IsNumeric(TextBoxImporteOrganizador.Text))
            {
                TotalOrganizador = double.Parse(TextBoxImporteOrganizador.Text);

                TotalOrganizadorRoyalty = double.Parse(TextBoxImporteOrganizador.Text) * coeficienteRoyalty;
            }


            //cmd.CalcularTotalPresupuestoPendiente(ListPresupuestoDetalle,

            double TotalPresupuesto1 = double.Parse(query.ToString()) + TotalOrganizador + TotalOrganizadorRoyalty;

            TotalPresupuesto = TotalPresupuesto1;

            TextBoxTotalPresupuesto.Text = (System.Math.Round(TotalPresupuesto1, 2)).ToString("C");

            //TextBoxTotalPresupuesto.Text = (System.Math.Round(double.Parse(query.ToString()) , 2)).ToString();

            TextBoxTotalPAX.Text = (TotalPresupuesto1 / CantidadTotalInvitados).ToString("C");
        }

        private void CalcularTotalRoyalty()
        {

            double coeficienteRoyalty = double.Parse(ConfigurationManager.AppSettings["coeficienteRoyalty"].ToString());

            coeficienteRoyalty = (coeficienteRoyalty / 100);

            var query = (from L in ListPresupuestoDetalle
                         select L.Royalty).Sum();


            TextBoxRoyalty.Text = (double.Parse(query.ToString()) + TotalOrganizadorRoyalty).ToString("C");

        }
        private void Controles()
        {
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());

            TextBoxOtroLocacion.Visible = false;
            TextBoxOtroTipoEvento.Visible = false;

            LabelTipoLogistica.Visible = false;
            DropDownListConceptoLogistica.Visible = false;

            //LabelLocalidadLogistica.Visible = false;
            //DropDownListLocalidadesLogisitca.Visible = false;

            TextBoxCostoLogistica.Visible = false;

            LabelCantidadItemsOrganizacion.Visible = false;
            TextBoxCantidadItemsOrganizacion.Visible = false;

            TextBoxCostoCannonBarra.Visible = false;

            LabelCannon.Visible = false;
            LabelLogistica.Visible = false;


            LabelCantidadAdicional.Visible = false;
            TextBoxCantidadAdicional.Visible = false;

            PanelVisorPDF.Visible = false;
            PanelCotixador.Visible = true;
            PanelMensaje.Visible = false;
            PanelNuevoNegocio.Visible = false;
            PanelNuevoEventoConfirmado.Visible = false;


            PanelListarClientes.Visible = false;
            PanelArmarCotizacion.Visible = false;

            PanelLocacionOut.Visible = false;

            ButtonAgregarItem.Visible = false;

            PanelAdicionales.Visible = false;
            LabelMensajeAdicionales.Visible = false;

            TextBoxCliente.Visible = false;

            LabelErrores.Visible = false;
            LabelMensajeCliente.Visible = false;

            CalendarExtenderFechaEvento.StartDate = System.DateTime.Today;

            LabelRentaPorcentaje.Visible = false;
            LabelRentaValor.Visible = false;
            LabelRoyalty.Visible = false;
            TextBoxRentaPorcentaje.Visible = false;
            TextBoxRentaValor.Visible = false;
            TextBoxRoyalty.Visible = false;

            LabelHoraInicio.Visible = false;
            LabelHoraFin.Visible = false;

            if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
            {
                LabelRentaPorcentaje.Visible = true;
                LabelRentaValor.Visible = true;
                LabelRoyalty.Visible = true;
                TextBoxRentaPorcentaje.Visible = true;
                TextBoxRentaValor.Visible = true;
                TextBoxRoyalty.Visible = true;


            }


        }

        private void CargarVariablesSession()
        {
            CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
            SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
            TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());
            JornadaId = Int32.Parse(DropDownListJornadas.SelectedItem.Value.ToString());
            LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
            MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());
            //DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());
            DuracionId = 0;
            SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());


            RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

            PorcentajeVendidoSalon = 0;
            PorcentajeVendidoCatering = 0;
            PorcentajeVendidoTecnica = 0;
            PorcentajeVendidoBarra = 0;
            PorcentajeVendidoAmbientacion = 0;
            PorcentajeVendidoAdicional = 0;

            TipoCannon = "";
            TipoCannonBarra = "";
            TipoCannonAmbientacion = "";

            TotalOrganizador = 0;
            TotalOrganizadorRoyalty = 0;
            TipoCateringId = 0;

        }

        private void CargarListas()
        {
            int LogisticaDefault = Int32.Parse(ConfigurationManager.AppSettings["LogisticaPorDefecto"].ToString()); ;


            DropDownListTipoEvento.DataSource = servicios.TraerTipoEvento();
            DropDownListTipoEvento.DataTextField = "Descripcion";
            DropDownListTipoEvento.DataValueField = "Id";
            DropDownListTipoEvento.DataBind();

            DropDownListMomentodelDia.DataSource = serviciosAdministrativas.ObtenerMomentosDias();
            DropDownListMomentodelDia.DataTextField = "Descripcion";
            DropDownListMomentodelDia.DataValueField = "Id";
            DropDownListMomentodelDia.DataBind();

            if (ListLocacionesUsuarios.Count == 0)
            {
                ListLocaciones = servicios.ObtenerLocacionesParaCotizar();

                Locaciones loc = new Locaciones();

                loc.Id = 0;
                loc.Descripcion = "OUT";

                ListLocaciones.Add(loc);

                DropDownListLocaciones.DataSource = ListLocaciones.ToList();
                DropDownListLocaciones.DataTextField = "Descripcion";
                DropDownListLocaciones.DataValueField = "Id";
                DropDownListLocaciones.DataBind();

            }
            else
            {

                ListLocaciones = ListLocacionesUsuarios.ToList();

                DropDownListLocaciones.DataSource = ListLocacionesUsuarios.ToList();
                DropDownListLocaciones.DataTextField = "Descripcion";
                DropDownListLocaciones.DataValueField = "Id";
                DropDownListLocaciones.DataBind();

            }


            DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value));
            DropDownListSectores.DataTextField = "Descripcion";
            DropDownListSectores.DataValueField = "Id";
            DropDownListSectores.DataBind();


            DropDownListCaracteristicas.DataSource = servicios.TraerCaracteristicas();
            DropDownListCaracteristicas.DataTextField = "Descripcion";
            DropDownListCaracteristicas.DataValueField = "Id";
            DropDownListCaracteristicas.DataBind();


            DropDownListSegmentos.DataSource = servicios.TraerSegmentos();
            DropDownListSegmentos.DataTextField = "Descripcion";
            DropDownListSegmentos.DataValueField = "Id";
            DropDownListSegmentos.DataBind();


            DropDownListJornadas.DataSource = servicios.TraerJornadas();
            DropDownListJornadas.DataTextField = "Descripcion";
            DropDownListJornadas.DataValueField = "Id";
            DropDownListJornadas.DataBind();


            DropDownListUnidadNegocio.DataSource = serviciosAdministrativas.ObtenerUNCotizador();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();

            DropDownListConceptoLogistica.DataSource = serviciosAdministrativas.ObtenerTipoLogistica();
            DropDownListConceptoLogistica.DataTextField = "Concepto";
            DropDownListConceptoLogistica.DataValueField = "Id";
            DropDownListConceptoLogistica.DataBind();

            DropDownListConceptoLogistica.SelectedValue = LogisticaDefault.ToString();

            DropDownListLocalidadOut.DataSource = serviciosAdministrativas.ObtenerLocalidades();
            DropDownListLocalidadOut.DataTextField = "Descripcion";
            DropDownListLocalidadOut.DataValueField = "Id";
            DropDownListLocalidadOut.DataBind();


        }

        private void CargarPresupuesto()
        {

            int LocacionOtro = Int32.Parse(ConfigurationManager.AppSettings["LocacionOtro"].ToString());

            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = servicios.BuscarPresupuesto(PresupuestoId);

                TextBoxCantMayores.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) TextBoxCantAdolescentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) TextBoxCantMenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) TextBoxCantEntre3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();


                TextBoxFechaDesdeEvento.Text = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);

                CalcularCantidadInvitados(PresupuestoSeleccionado.CantidadInicialInvitados.ToString(), PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString()
                                        , PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString(), PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString());


                double Valor = serviciosPresupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);


                LocacionId = PresupuestoSeleccionado.LocacionId;

                DropDownListLocaciones.SelectedValue = PresupuestoSeleccionado.LocacionId.ToString();

                Locaciones loc = ListLocaciones.Where(o => o.Id == LocacionId).SingleOrDefault();

                if (loc != null)
                {
                    //TipoCannon = loc.TipoCannon;
                    //ValorCannon = (loc.Cannon == null ? 0 : double.Parse(loc.Cannon.ToString()));


                    //ButtonAgregarSalon.Visible = true;
                    //LabelPrecioVentaSalon.Visible = true;
                    //DropDownListPrecioSalon.Visible = true;
                }
                else
                {
                    DropDownListLocaciones.SelectedValue = "0";

                    ListLocacionesOUT = servicios.ObtenerLocacionesOUT();

                    DropDownListLocacionesOut.DataSource = ListLocacionesOUT.ToList();
                    DropDownListLocacionesOut.DataTextField = "Descripcion";
                    DropDownListLocacionesOut.DataValueField = "Id";
                    DropDownListLocacionesOut.DataBind();


                    Locaciones locOUT = ListLocacionesOUT.Where(o => o.Id == LocacionId).SingleOrDefault();

                    TipoCannon = locOUT.TipoCannonCatering;

                    if (TipoCannon == "Persona")
                        RadioButtonCannonPorPersona.Checked = true;
                    else
                        RadioButtonCannonPorcentaje.Checked = true;

                    ValorCannon = (locOUT.Cannon == null ? 0 : double.Parse(locOUT.Cannon.ToString()));

                    TextBoxCannonOut.Text = ValorCannon.ToString();
                    double UsoConica = (locOUT.UsoCocina == null ? 0 : double.Parse(locOUT.UsoCocina.ToString())); ;

                    TextBoxUsoCocinaOUT.Text = UsoConica.ToString();

                    PanelLocacionOut.Visible = true;


                    DropDownListLocacionesOut.SelectedValue = locOUT.Id.ToString();

                    if (locOUT.Id == LocacionOtro)
                    {
                        TextBoxOtroLocacion.Visible = true;
                        TextBoxOtroLocacion.Text = PresupuestoSeleccionado.LocacionOtra;

                        TextBoxDireccionLocacionOut.Text = PresupuestoSeleccionado.DireccionOtra;

                    }

                    ButtonAgregarSalon.Visible = false;
                    LabelPrecioVentaSalon.Visible = false;
                    DropDownListPrecioSalon.Visible = false;

                }
                CaracteristicasId = PresupuestoSeleccionado.CaracteristicaId;
                SegmentosId = PresupuestoSeleccionado.SegmentoId;
                TipoEventoId = PresupuestoSeleccionado.TipoEventoId;
                JornadaId = (int)PresupuestoSeleccionado.JornadaId;
                SectorId = (PresupuestoSeleccionado.SectorId == null ? 0 : int.Parse(PresupuestoSeleccionado.SectorId.ToString()));

                if (PresupuestoSeleccionado.PorcentajeOrganizador != null) TextBoxPorcentajeOrganizador.Text = PresupuestoSeleccionado.PorcentajeOrganizador.ToString();

                if (PresupuestoSeleccionado.ValorOrganizador != null) TextBoxTotalPorcOrganizador.Text = PresupuestoSeleccionado.ValorOrganizador.ToString();

                if (PresupuestoSeleccionado.DuracionId != null)
                {
                    DuracionId = int.Parse(PresupuestoSeleccionado.DuracionId.ToString());
                    //DropDownListDuracionEvento.SelectedValue = PresupuestoSeleccionado.DuracionId.ToString();
                }
                else DuracionId = 0;

                if (PresupuestoSeleccionado.MomentoDiaID != null)
                {
                    MomentoDiaId = int.Parse(PresupuestoSeleccionado.MomentoDiaID.ToString());
                    DropDownListMomentodelDia.SelectedValue = PresupuestoSeleccionado.MomentoDiaID.ToString();
                }
                else MomentoDiaId = 0;

                DropDownListCaracteristicas.SelectedValue = PresupuestoSeleccionado.CaracteristicaId.ToString();
                DropDownListSegmentos.SelectedValue = PresupuestoSeleccionado.SegmentoId.ToString();
                DropDownListTipoEvento.SelectedValue = PresupuestoSeleccionado.TipoEventoId.ToString();
                DropDownListJornadas.SelectedValue = PresupuestoSeleccionado.JornadaId.ToString();

                TextBoxImporteOrganizador.Text = PresupuestoSeleccionado.ImporteOrganizador.ToString();
                TextBoxTotalPorcOrganizador.Text = PresupuestoSeleccionado.ValorOrganizador.ToString();
                TextBoxPorcentajeOrganizador.Text = PresupuestoSeleccionado.PorcentajeOrganizador.ToString();

                TextBoxComentarioEvento.Text = PresupuestoSeleccionado.Comentario;

                TextBoxHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;
                TextBoxHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;

            }
        }

        private void CargarEvento()
        {

            PanelBuscarCliente.Visible = false;
            PanelListarClientes.Visible = true;

            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = servicios.BuscarEvento(EventoId);


            ClienteId = EventoSeleccionado.ClienteId;

            TextBoxCliente.Visible = true;

            //ClientesPipedrive cliente = ListClientesPipe.Where(o => o.Id == ClienteId).FirstOrDefault(); //serviciosClientes.BuscarCliente(ClienteId);

            TextBoxCliente.Text = EventoSeleccionado.ApellidoNombreCliente;



            DropDownListClientesPipe.Visible = false;
            //DropDownListClientes.Visible = false;

        }

        private int ObtenerCantidadInvitadosCosto(List<ObtenerCantidadInvitadosCatering> Cantidades, int CantidadInvitados)
        {

            foreach (var item in Cantidades)
            {
                if (CantidadInvitados <= item.CantidadPersonas)
                {
                    return item.CantidadPersonas;
                }
            }
            return Cantidades.Max(o => o.CantidadPersonas);

        }

        #region Agregar Items

        protected void ButtonAgregarItem_Click(object sender, EventArgs e)
        {
            int informal = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int corporativo = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            if (Validar())
            {


                PresupuestoDetalleADD searcher = new PresupuestoDetalleADD();

                searcher.precioSeleccionado = DropDownListPrecios.SelectedItem.Text;
                searcher.unidadNegocio = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);
                searcher.productoNinguno = 0;
                searcher.proveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

                if (((CaracteristicasId != informal) || (SegmentosId != corporativo)) || (searcher.unidadNegocio != RubroAmbientacion))
                {
                    searcher.servicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value);
                }
                else
                {
                    searcher.servicioId = Int32.Parse(DropDownListCIItemsAmbientacion.SelectedItem.Value);

                }
                searcher.cantidadAdultos = TextBoxCantMayores.Text;
                searcher.cantidadEntre3y8 = TextBoxCantEntre3y8.Text;
                searcher.cantidadMenores3 = TextBoxCantMenores3.Text;
                searcher.cantidadAdolescentes = TextBoxCantAdolescentes.Text;

                searcher.FechaEvento = TextBoxFechaDesdeEvento.Text;

                searcher.TipoLogisticaId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());

                if (ListLocaciones.Count() > 0)
                    searcher.LocalidadId = ListLocaciones.Where(o => o.Id == LocacionId).Select(s => s.LocalidadId).SingleOrDefault();
                else if (ListLocacionesOUT.Count() > 0)
                    searcher.LocalidadId = ListLocacionesOUT.Where(o => o.Id == LocacionId).Select(s => s.LocalidadId).SingleOrDefault();
                else
                    searcher.LocalidadId = Int32.Parse(DropDownListLocalidadOut.SelectedItem.Value);


                searcher.LogisticaCosto = Int32.Parse(TextBoxCostoLogistica.Text);
                Accion = "A";
                AgregarItem(searcher);

            }
        }

        protected void ButtonAgregarSalon_Click(object sender, EventArgs e)
        {

            CalcularDuracionEvento(TextBoxHoraInicio.Text, TextBoxHoraFin.Text);

            PresupuestoDetalleADD searcher = new PresupuestoDetalleADD();

            searcher.precioSeleccionado = DropDownListPrecioSalon.SelectedItem.Text;
            searcher.unidadNegocio = RubroSalon;
            searcher.productoNinguno = 0;

            searcher.cantidadAdultos = TextBoxCantMayores.Text;
            searcher.cantidadEntre3y8 = TextBoxCantEntre3y8.Text;
            searcher.cantidadMenores3 = TextBoxCantMenores3.Text;
            searcher.cantidadAdolescentes = TextBoxCantAdolescentes.Text;

            searcher.FechaEvento = TextBoxFechaDesdeEvento.Text;


            AgregarItem(searcher);

        }

        protected void ButtonAgregarAdicional_Click(object sender, EventArgs e)
        {

            PresupuestoDetalleADD searcher = new PresupuestoDetalleADD();


            searcher.precioSeleccionado = null;
            searcher.unidadNegocio = RubroAdicional;
            searcher.productoNinguno = 0;
            searcher.servicioId = Int32.Parse(DropDownListAdicionales.SelectedItem.Value);

            searcher.cantidadAdultos = TextBoxCantMayores.Text;
            searcher.cantidadEntre3y8 = TextBoxCantEntre3y8.Text;
            searcher.cantidadMenores3 = TextBoxCantMenores3.Text;
            searcher.cantidadAdolescentes = TextBoxCantAdolescentes.Text;

            searcher.FechaEvento = TextBoxFechaDesdeEvento.Text;

            searcher.cantidadAdicional = TextBoxCantidadAdicional.Text;

            AgregarItem(searcher);

        }

        protected void ButtonAgregarUbicacion_Click(object sender, EventArgs e)
        {
            int productoNinguno = Int32.Parse(ConfigurationManager.AppSettings["ProductoSalonSinCosto"].ToString());

            CalcularDuracionEvento(TextBoxHoraInicio.Text, TextBoxHoraFin.Text);

            PresupuestoDetalleADD searcher = new PresupuestoDetalleADD();

            searcher.precioSeleccionado = "Sin Precio";
            searcher.unidadNegocio = RubroSalon;
            searcher.productoNinguno = productoNinguno;

            searcher.cantidadAdultos = TextBoxCantMayores.Text;
            searcher.cantidadEntre3y8 = TextBoxCantEntre3y8.Text;
            searcher.cantidadMenores3 = TextBoxCantMenores3.Text;
            searcher.cantidadAdolescentes = TextBoxCantAdolescentes.Text;

            searcher.FechaEvento = TextBoxFechaDesdeEvento.Text;


            AgregarItem(searcher);

        }

        private void AgregarItem(PresupuestoDetalleADD searcher)
        {

            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            LabelErrores.Visible = false;

            int PresupuestoDetallePendiente =
                Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());

            int cantidadAductos = 0;
            int cantidadAdolescentes = 0;
            int cantidadAdicional = 0;
            int ServicioId = 0;
            int ProveedorId = 0;
            int CantidadInvitadosLog = 0;
            int cantidadInvitadosAdicional = 0;
            double CannonCatering = 0;
            double CannonBarra = 0;
            double CannonAmbientacion = 0;


            CalcularCantidadInvitados(searcher.cantidadAdultos, searcher.cantidadEntre3y8, searcher.cantidadMenores3,
               searcher.cantidadAdolescentes);

            if (cmd.IsNumeric(searcher.cantidadAdultos))
                cantidadAductos = Int32.Parse(searcher.cantidadAdultos);

            if (cmd.IsNumeric(searcher.cantidadAdolescentes))
                cantidadAdolescentes = Int32.Parse(searcher.cantidadAdolescentes);


            DateTime fechaSeleccionada =
                DateTime.ParseExact(searcher.FechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string Codigo;

            Productos producto = new Productos();


            switch (searcher.unidadNegocio)
            {
                case 1: //AMBIENTACION
                    ServicioId = searcher.servicioId;
                    ProveedorId = searcher.proveedorId;


                    if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
                          .SingleOrDefault().CannonAmbientacion > 0)
                        CannonAmbientacion = double.Parse(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
                            .SingleOrDefault().CannonAmbientacion.ToString());

                    if (CaracteristicasId != caracteristicaId || SegmentosId != segmentoId)
                    {
                        Codigo = cmd.ArmarCodigoAmbientacion(ServicioId,
                                 ProveedorId,
                                 CantidadTotalInvitados,
                                 SectorId, searcher.FechaEvento);
                    }
                    else if (Accion == "M")
                    {

                        CargarAmbientacionCI(String.Format("{0:dd/MM/yyyy}", TextBoxFechaDesdeEvento.Text),
                              searcher.servicioId,
                              CaracteristicasId,
                              SegmentosId,
                             searcher.proveedorId,
                              Int32.Parse(searcher.cantidadAdicional),
                              searcher.precioSeleccionado);

                        Codigo = cmd.ArmarCodigoAmbientacionCorporativoInformal(searcher.servicioId,
                              ProveedorId,
                              Int32.Parse(searcher.cantidadAdicional),
                              SectorId, searcher.FechaEvento);

                        ServicioId = searcher.servicioId;
                        ProveedorId = searcher.proveedorId;
                    }
                    else
                    {
                        CargarAmbientacionCI(String.Format("{0:dd/MM/yyyy}", TextBoxFechaDesdeEvento.Text),
                                  Int32.Parse(DropDownListCIItemsAmbientacion.SelectedItem.Value),
                                  CaracteristicasId,
                                  SegmentosId,
                                  Int32.Parse(DropDownListProveedor.SelectedItem.Value),
                                  Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue),
                                  DropDownListPrecios.SelectedItem.Text);

                        Codigo = cmd.ArmarCodigoAmbientacionCorporativoInformal(Int32.Parse(DropDownListCIItemsAmbientacion.SelectedItem.Value),
                                    ProveedorId,
                                    Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue),
                                    SectorId,
                                    searcher.FechaEvento);

                        ServicioId = Int32.Parse(DropDownListCIItemsAmbientacion.SelectedItem.Value);
                        cantidadAdicional = Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue);
                        ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);


                    }


                    break;

                case 2: //TECNICA
                    ServicioId = searcher.servicioId;
                    ProveedorId = searcher.proveedorId;

                    Codigo = cmd.ArmarCodigoTecnica(searcher.FechaEvento,
                         ServicioId,
                         ProveedorId,
                         SegmentosId,
                         SectorId);

                    break;

                case 3: //CATERING
                    ServicioId = searcher.servicioId;
                    ProveedorId = searcher.proveedorId;

                    if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
                            .SingleOrDefault().CannonCatering > 0)
                        CannonCatering = double.Parse(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
                            .SingleOrDefault().CannonCatering.ToString());

                    //TipoLogisticaId = searcher.TipoLogisticaId;
                    //LocalidadId = searcher.LocalidadId;
                    CantidadInvitadosLog = CantidadInvitadosLogistica;
                    //LogisticaCosto = searcher.LogisticaCosto;

                    Codigo = cmd.ArmarCodigoCatering(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados);

                    break;



                case 6: //BARRA
                    ServicioId = searcher.servicioId;
                    ProveedorId = searcher.proveedorId;

                    if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
                            .SingleOrDefault().CannonBarra > 0)
                        CannonBarra = double.Parse(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
                            .SingleOrDefault().CannonBarra.ToString());

                    TiposBarras barra = serviciosAdministrativas.BuscarTipoBarras(ServicioId);

                    //TipoLogisticaId = searcher.TipoLogisticaId;
                    // LocalidadId = searcher.LocalidadId;
                    CantidadInvitadosLog = CantidadInvitadosLogistica;
                    //LogisticaCosto = searcher.LogisticaCosto;

                    int cantidadInvitadosBarra;
                    if (barra.RangoEtareo == "ADULTOS")
                        cantidadInvitadosBarra = Int32.Parse(searcher.cantidadAdultos);
                    else
                        cantidadInvitadosBarra = Int32.Parse(searcher.cantidadAdolescentes);

                    Codigo = cmd.ArmarCodigoBarra(ServicioId,
                        ProveedorId,
                        cantidadInvitadosBarra);
                    break;

                case 7: //SALON
                    ServicioId = LocacionId;

                    Codigo = cmd.ArmarCodigoSalon(searcher.FechaEvento,
                        LocacionId,
                        SectorId,
                        JornadaId,
                        CantidadTotalInvitados);

                    break;

                case 9: //Adicional
                    ServicioId = searcher.servicioId;


                    Adicionales adi =
                        servicios.BuscarAdicional(
                            ServicioId);

                    if (adi.RequiereCantidadRango == "S")
                    {
                        if (searcher.cantidadAdicional != "" && cmd.IsNumeric(searcher.cantidadAdicional))
                        {
                            Codigo = cmd.ArmarCodigoAdicional(ServicioId,
                                Int32.Parse(searcher.cantidadAdicional));

                            cantidadAdicional = Int32.Parse(searcher.cantidadAdicional);


                        }
                        else
                        {
                            Codigo = cmd.ArmarCodigoAdicional(
                                ServicioId, 1);
                        }
                    }
                    else if (adi.RequiereCantidad == "S")
                    {

                        Codigo = cmd.ArmarCodigoAdicional(
                                 ServicioId, 1);

                        if (searcher.cantidadAdicional != "" && cmd.IsNumeric(searcher.cantidadAdicional))
                        {

                            cantidadAdicional = Int32.Parse(searcher.cantidadAdicional);

                        }
                        else
                        {
                            cantidadAdicional = 1;
                        }
                    }
                    else
                        Codigo = cmd.ArmarCodigoAdicional(ServicioId,
                            CantidadTotalInvitados);


                    break;

                default: //ORGANIZACION

                    ServicioId = searcher.servicioId;
                    ProveedorId = searcher.proveedorId;
                    Codigo = cmd.ArmarCodigoOrganizacion(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados);

                    break;

            }

            if (searcher.productoNinguno == 0)
                producto = serviciosAdministrativas.BuscarProductosPorCodigo(Codigo, fechaSeleccionada);
            else
                producto = serviciosAdministrativas.BuscarProducto(searcher.productoNinguno);


            if (producto != null)
            {

                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id && o.UnidadNegocioId != RubroAmbientacion).SingleOrDefault();

                if (ItemRepetido == null)
                {
                    PresupuestoDetalle detalle = new PresupuestoDetalle();

                    detalle.UnidadNegocioId = producto.UnidadNegocioId;
                    detalle.ServicioId = ServicioId;

                    if (ProveedorId == 0)
                        detalle.LocacionId = LocacionId;
                    else
                        detalle.ProveedorId = ProveedorId;


                    if (searcher.productoNinguno == 0)
                    {
                        detalle.ProductoDescripcion = producto.Descripcion;
                        detalle.ProductoId = producto.Id;
                    }
                    else
                    {
                        detalle.ProductoDescripcion = DropDownListLocacionesOut.SelectedItem.Text + " - " +
                                                      TextBoxDireccionLocacionOut.Text;
                        ;
                        detalle.ProductoId = searcher.productoNinguno;
                    }

                    detalle.PrecioSeleccionado = searcher.precioSeleccionado == null ? "" : searcher.precioSeleccionado;
                    detalle.CodigoItem = producto.Codigo;


                    if (searcher.TipoLogisticaId > 0)
                        detalle.TipoLogisticaId = searcher.TipoLogisticaId;
                    if (searcher.LocalidadId > 0)
                        detalle.LocalidadId = searcher.LocalidadId;
                    if (CantidadInvitadosLog > 0)
                        detalle.CantInvitadosLogistica = CantidadInvitadosLog;
                    if (searcher.LogisticaCosto > 0)
                        detalle.Logistica = searcher.LogisticaCosto;

                    detalle.EstadoId = PresupuestoDetallePendiente;

                    if (cmd.IsNumeric(TextBoxUsoCocinaOUT.Text))
                        detalle.UsoCocina = double.Parse(TextBoxUsoCocinaOUT.Text);

                    if (cmd.IsNumeric(TextBoxCannonOut.Text))
                        detalle.CannonCatering = double.Parse(TextBoxCannonOut.Text);

                    if (cmd.IsNumeric(TextBoxCannonOutBarra.Text))
                        detalle.CannonBarra = double.Parse(TextBoxCannonOutBarra.Text);

                    if (cmd.IsNumeric(TextBoxCannonOutAmbientacion.Text))
                        detalle.CannonAmbientacion = double.Parse(TextBoxCannonOutAmbientacion.Text);


                    detalle.SegmentoId = SegmentosId;
                    detalle.CarasteristicaId = CaracteristicasId;



                    detalle.CantidadAdicional = cantidadAdicional;

                    if (TipoCannonAmbientacion != "")
                        detalle.TipoCanonAmbientacion = TipoCannonAmbientacion;
                    if (TipoCannonBarra != "")
                        detalle.TipoCanonBarra = TipoCannonBarra;
                    if (TipoCannon != "")
                        detalle.TipoCanonCatering = TipoCannon;

                    detalle.AnuloCanon = false;


                    detalle = serviciosPresupuestos.AddItem(detalle, producto, LocacionId, cantidadAductos,
                        cantidadAdolescentes,
                        CantidadTotalInvitados,
                        ListPresupuestoDetalle);

                    ListPresupuestoDetalle.Add(detalle);
                }
                else
                {
                    LabelErrores.Visible = true;
                    LabelErrores.Text = "No Existe el Item creado para poder Cotizar o se encuentra repetido.";
                }

            }
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "No Existe el Item creado para poder Cotizar o se encuentra repetido.";
            }



            GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
            GridViewVentas.DataBind();


            if (GridViewVentas.Rows.Count > 0)
            {
                HabilitarDeshabilitarDropdownList(false);
                PanelArmarCotizacion.Visible = true;
                ButtonAgregarItem.Visible = true;
            }

            CalcularTotalPresupuesto();

            CalcularSubTotalComision();

            CalcularTotalRoyalty();

            CalcularRenta();

            TextBoxCantidadAdicional.Text = "";
            UpdatePanelCotizador.Update();

        }

        private void HabilitarDeshabilitarDropdownList(bool opcion)
        {
            TextBoxHoraInicio.ReadOnly = !opcion;
            TextBoxHoraFin.ReadOnly = !opcion;
            DropDownListCaracteristicas.Enabled = opcion;
            //DropDownListDuracionEvento.Enabled = opcion;
            DropDownListTipoEvento.Enabled = opcion;
            DropDownListMomentodelDia.Enabled = opcion;
            DropDownListJornadas.Enabled = opcion;
            DropDownListSegmentos.Enabled = opcion;
            DropDownListLocaciones.Enabled = opcion;
            DropDownListSectores.Enabled = opcion;
            DropDownListSectoresOut.Enabled = opcion;
            DropDownListLocacionesOut.Enabled = opcion;
            DropDownListLocalidadOut.Enabled = opcion;
            TextBoxOtroLocacion.Enabled = opcion;
            TextBoxDireccionLocacionOut.Enabled = opcion;

            RadioButtonCannonPorcentaje.Enabled = opcion;
            RadioButtonCannonPorPersona.Enabled = opcion;
            RadioButtonCannonAbsoluto.Enabled = opcion;

            RadioButtonCannonPorcentajeBarra.Enabled = opcion;
            RadioButtonCannonPorPersonaBarra.Enabled = opcion;
            RadioButtonCannonAbsolutoBarra.Enabled = opcion;

            RadioButtonCannonPorcentajeAmbientacion.Enabled = opcion;
            RadioButtonCannonPorPersonaAmbientacion.Enabled = opcion;
            RadioButtonCannonAbsolutoAmbientacion.Enabled = opcion;

            TextBoxCannonOut.Enabled = opcion;
            TextBoxCannonOutBarra.Enabled = opcion;
            TextBoxCannonOutAmbientacion.Enabled = opcion;
            TextBoxUsoCocinaOUT.Enabled = opcion;


            TextBoxCantAdolescentes.ReadOnly = !opcion;
            TextBoxCantEntre3y8.ReadOnly = !opcion;
            TextBoxCantMayores.ReadOnly = !opcion;
            TextBoxCantMenores3.ReadOnly = !opcion;

        }

        #endregion

        #region Validaciones

        private bool Validar()
        {
            if (CantidadTotalInvitados <= 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Cantidad de Invitados para poder Cotizar.";
                return false;
            }

            if (TextBoxFechaDesdeEvento.Text == "")
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Fecha del Evento para poder Cotizar.";
                return false;
            }

            if (DropDownListPrecios.SelectedItem.Value == "0")
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Seleccionar un Precio antes de Cotizar.";
                return false;
            }


            LabelErrores.Visible = false;

            return true;

        }

        private bool ValidarSalon()
        {
            if (CantidadTotalInvitados <= 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Cantidad de Invitados para poder Cotizar.";
                return false;
            }

            if (TextBoxFechaDesdeEvento.Text == "")
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Fecha del Evento para poder Cotizar.";
                return false;
            }


            if (DropDownListPrecioSalon.SelectedItem.Value == "0")
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Seleccionar un Precio antes de Cotizar.";
                return false;
            }

            if (!cmd.ValidarHora(TextBoxHoraInicio.Text))
            {
                LabelHoraInicio.Visible = true;
                return false;
            }

            if (!cmd.ValidarHora(TextBoxHoraFin.Text))
            {
                LabelHoraFin.Visible = true;
                return false;
            }

            LabelErrores.Visible = false;

            return true;

        }

        private bool ValidarGuardado()
        {
            if (CantidadTotalInvitados <= 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Cantidad de Invitados para poder Cotizar.";
                return false;
            }

            if (TextBoxFechaDesdeEvento.Text == "")
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Fecha del Evento para poder Cotizar.";
                return false;
            }

            if (GridViewVentas.Rows.Count == 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Generar alguna cotizacion para poder Guardar el Presupuesto.";
                return false;
            }

            if (ClienteId <= 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar un Cliente para poder Cotizar.";
                return false;
            }

            return true;
        }

        private bool ValidarConfirmacion()
        {
            if (CantidadTotalInvitados <= 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Cantidad de Invitados para poder Cotizar.";
                return false;
            }

            if (TextBoxFechaDesdeEvento.Text == "")
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar la Fecha del Evento para poder Cotizar.";
                return false;
            }

            if (GridViewVentas.Rows.Count == 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Generar alguna cotizacion para poder Confirmar el Presupuesto.";
                return false;
            }

            //if (!cmd.IsNumeric(TextBoxPorcentajeOrganizador.Text))
            //{
            //    LabelErrores.Visible = true;
            //    LabelErrores.Text = "Debe Cargar un organizador.";
            //    return false;
            //}

            if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon).Count() == 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar una Cotizacion de Salon.";
                return false;
            }

            if (ClienteId <= 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Cargar un Cliente para poder Cotizar.";
                return false;
            }


            return true;

        }

        #endregion

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {
            CantidadTotalParaCotizar = cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes);
            CantidadTotalInvitados = Convert.ToInt32(CantidadTotalParaCotizar);
        }

        protected void DropDownListTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TipoEventoOtro = Int32.Parse(ConfigurationManager.AppSettings["TipoEventoOtro"].ToString());

            if (DropDownListTipoEvento.SelectedItem.Value != null)
            {

                TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());

                if (DropDownListTipoEvento.SelectedItem.Value == TipoEventoOtro.ToString())
                {
                    UpdatePanelTipoEventoOtro.Visible = true;
                    UpdatePanelTipoEventoOtro.Update();
                }
                else
                {
                    UpdatePanelTipoEventoOtro.Visible = false;
                    UpdatePanelTipoEventoOtro.Update();
                }

            }
        }

        protected void DropDownListLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (DropDownListLocaciones.SelectedItem.Value != null)
            {

                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                //SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value);

                if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                {
                    PanelLocacionOut.Visible = true;

                    ListLocacionesOUT = servicios.ObtenerLocacionesOUT();

                    DropDownListLocacionesOut.DataSource = ListLocacionesOUT.ToList();
                    DropDownListLocacionesOut.DataTextField = "Descripcion";
                    DropDownListLocacionesOut.DataValueField = "Id";
                    DropDownListLocacionesOut.DataBind();


                    DropDownListSectores.DataSource = new List<Sectores>();
                    DropDownListSectores.DataTextField = "Descripcion";
                    DropDownListSectores.DataValueField = "Id";
                    DropDownListSectores.DataBind();



                    TextBoxDireccionLocacionOut.Visible = false;

                    DropDownListPrecioSalon.Visible = false;
                    ButtonAgregarSalon.Visible = false;
                    LabelPrecioVentaSalon.Visible = false;

                }
                else
                {
                    PanelLocacionOut.Visible = false;

                    DropDownListPrecioSalon.Visible = true;
                    ButtonAgregarSalon.Visible = true;
                    LabelPrecioVentaSalon.Visible = true;

                    int seleccionado = Int32.Parse(this.DropDownListLocaciones.SelectedItem.Value.ToString());


                    DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(seleccionado);
                    DropDownListSectores.DataTextField = "Descripcion";
                    DropDownListSectores.DataValueField = "Id";
                    DropDownListSectores.DataBind();

                    SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value);

                    CargarListasAmbientacion();


                    LabelSector.Visible = true;
                    UpdatePanelSector.Visible = true;
                    UpdatePanelSector.Update();

                }


            }
        }

        private void ObtenerTecnicaSalon()
        {
            List<TecnicaSalon> TecSalon = servicios.ObtenerProveedorTecnicaPorLocacionSector(LocacionId, SectorId);

            if (TecSalon.Count() > 0)
            {
                List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                var query = from P in Prov
                            join A in TecSalon on P.Id equals A.ProveedorId
                            select P;



                DropDownListProveedor.Items.Clear();
                DropDownListProveedor.AppendDataBoundItems = true;
                //DropDownListProveedor.DataSource = Prov.Where(o => o.Id == (int)AmbSalon.ProveedorId).ToList();
                DropDownListProveedor.DataSource = query.ToList();
                DropDownListProveedor.DataTextField = "RazonSocial";
                DropDownListProveedor.DataValueField = "Id";
                DropDownListProveedor.DataBind();



                //ProveedorAmbientacionId = AmbSalon.ProveedorId;

            }
            else
            {
                List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                DropDownListProveedor.Items.Clear();
                DropDownListProveedor.AppendDataBoundItems = true;
                DropDownListProveedor.DataSource = Prov.ToList();
                DropDownListProveedor.DataTextField = "RazonSocial";
                DropDownListProveedor.DataValueField = "Id";
                DropDownListProveedor.DataBind();
            }



            //TecnicaSalon TecSalon = servicios.BuscarTecnicaPorLocacion(LocacionId, SectorId);

            //if (TecSalon != null)
            //{
            //    List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

            //    DropDownListProveedor.Items.Clear();
            //    DropDownListProveedor.AppendDataBoundItems = true;
            //    DropDownListProveedor.DataSource = Prov.Where(o => o.Id == (int)TecSalon.ProveedorId).ToList();
            //    DropDownListProveedor.DataTextField = "RazonSocial";
            //    DropDownListProveedor.DataValueField = "Id";
            //    DropDownListProveedor.DataBind();



            //    ProveedorTecnicaId = TecSalon.ProveedorId;

            //}
            //else
            //{
            //    List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

            //    DropDownListProveedor.Items.Clear();
            //    DropDownListProveedor.AppendDataBoundItems = true;
            //    DropDownListProveedor.DataSource = Prov.ToList();
            //    DropDownListProveedor.DataTextField = "RazonSocial";
            //    DropDownListProveedor.DataValueField = "Id";
            //    DropDownListProveedor.DataBind();
            //}

            UpdatePanelCotizador.Update();

        }

        protected void DropDownListUnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {

            LabelCantidadItemsOrganizacion.Visible = false;
            TextBoxCantidadItemsOrganizacion.Visible = false;
            PanelAmbientacionCorporativoInformal.Visible = false;

            int BNN = Int32.Parse(ConfigurationManager.AppSettings["BNN"].ToString());
            int ProveedorBarraBNN = Int32.Parse(ConfigurationManager.AppSettings["BarraBNN"].ToString());
            //int ElDorado = Int32.Parse(ConfigurationManager.AppSettings["ElDorado"].ToString());
            int ProveedorBarraElDorado = Int32.Parse(ConfigurationManager.AppSettings["BarraElDorado"].ToString());

            if (DropDownListUnidadNegocio.SelectedItem.Value != null)
            {

                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroSalon)
                {
                    DropDownListProveedor.Visible = false;
                    DropDownListServicio.Visible = false;

                    HabilitarLogisticaCannon(false);
                }
                else
                {
                    DropDownListProveedor.Visible = true;
                    DropDownListServicio.Visible = true;

                    List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedor.Items.Clear();
                    DropDownListProveedor.AppendDataBoundItems = true;
                    DropDownListProveedor.DataSource = Prov.ToList();
                    DropDownListProveedor.DataTextField = "RazonSocial";
                    DropDownListProveedor.DataValueField = "Id";
                    DropDownListProveedor.DataBind();

                    //if (LocacionId == BNN && 
                    //    Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroBarra)
                    //{

                    //    List<Proveedores> list = serviciosAdministrativas.BuscarProveedorLista(ProveedorBarraBNN);

                    //    DropDownListProveedor.Items.Clear();
                    //    DropDownListProveedor.AppendDataBoundItems = true;
                    //    DropDownListProveedor.DataSource = list.ToList();
                    //    DropDownListProveedor.DataTextField = "RazonSocial";
                    //    DropDownListProveedor.DataValueField = "Id";
                    //    DropDownListProveedor.DataBind();
                    //}
                    //else if (LocacionId == ElDorado && Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroBarra)
                    //{

                    //    List<Proveedores> list = serviciosAdministrativas.BuscarProveedorLista(ProveedorBarraElDorado);

                    //    DropDownListProveedor.Items.Clear();
                    //    DropDownListProveedor.AppendDataBoundItems = true;
                    //    DropDownListProveedor.DataSource = list.ToList();
                    //    DropDownListProveedor.DataTextField = "RazonSocial";
                    //    DropDownListProveedor.DataValueField = "Id";
                    //    DropDownListProveedor.DataBind();
                    //}



                    if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroCatering)
                    {

                        CalcularCantidadinvitadosLogistica();

                        CargarServicios();

                        HabilitarLogisticaCannon(true);

                        TextBoxCostoCannonBarra.Visible = false;
                        LabelCannon.Visible = false;

                        if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                            TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
                        else
                            TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();


                    }

                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroBarra)
                    {

                        CalcularCantidadinvitadosLogistica();

                        CargarServicios();

                        HabilitarLogisticaCannon(true);


                        if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                            TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
                        else
                            TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();




                    }

                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroTecnica)
                    {
                        ObtenerTecnicaSalon();

                        CargarServicios();

                        HabilitarLogisticaCannon(false);
                    }
                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroAmbientacion)
                    {
                        ObtenerAmbientacionSalon();

                        CargarServicios();


                        HabilitarLogisticaCannon(false);


                    }
                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroOrganizacion)
                    {

                        LabelCantidadItemsOrganizacion.Visible = true;
                        TextBoxCantidadItemsOrganizacion.Visible = true;

                        CargarServicios();


                        HabilitarLogisticaCannon(false);
                    }
                }

            }
        }

        private void ObtenerAmbientacionSalon()
        {

            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            List<AmbientacionSalon> AmbSalon = servicios.ObtenerProveedorAmbientacionPorLocacionSector(LocacionId, SectorId);

            if (AmbSalon.Count() > 0)
            {
                List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                var query = from P in Prov
                            join A in AmbSalon on P.Id equals A.ProveedorId
                            select P;



                DropDownListProveedor.Items.Clear();
                DropDownListProveedor.AppendDataBoundItems = true;
                //DropDownListProveedor.DataSource = Prov.Where(o => o.Id == (int)AmbSalon.ProveedorId).ToList();
                DropDownListProveedor.DataSource = query.ToList();
                DropDownListProveedor.DataTextField = "RazonSocial";
                DropDownListProveedor.DataValueField = "Id";
                DropDownListProveedor.DataBind();



                //ProveedorAmbientacionId = AmbSalon.ProveedorId;

            }
            else
            {
                List<Proveedores> Prov = servicios.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                DropDownListProveedor.Items.Clear();
                DropDownListProveedor.AppendDataBoundItems = true;
                DropDownListProveedor.DataSource = Prov.ToList();
                DropDownListProveedor.DataTextField = "RazonSocial";
                DropDownListProveedor.DataValueField = "Id";
                DropDownListProveedor.DataBind();
            }

            if (SegmentosId == segmentoId && CaracteristicasId == caracteristicaId)
            {
                AmbientacionCI(caracteristicaId, segmentoId);
            }
            UpdatePanelCotizador.Update();
        }

        private void AmbientacionCI(int caracteristicaId, int segmentoId)
        {

            PanelAmbientacionCorporativoInformal.Visible = false;
            int activo = Int32.Parse(ConfigurationManager.AppSettings["AmbientacionCIActivo"].ToString());



            int proveedorId = 0;
            if (DropDownListProveedor.SelectedItem != null)
                proveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

            List<CostosPaquetesCIAmbientacion> costos = serviciosAdministrativas.ListarCostosPaquetesCIAmbientacionPorProveedor(proveedorId).ToList();

            if (costos.Count() > 0)
            {
                PanelAmbientacionCorporativoInformal.Visible = true;

                DropDownListCIItemsAmbientacion.DataSource = serviciosAdministrativas.ObtenerAmbientacionesCI().Where(o => o.EstadoId == activo).ToList();
                DropDownListCIItemsAmbientacion.DataTextField = "Descripcion";
                DropDownListCIItemsAmbientacion.DataValueField = "Id";
                DropDownListCIItemsAmbientacion.DataBind();

                DropDownListServicio.Visible = false;

                //return true;
            }
            //return false;

        }

        private void HabilitarLogisticaCannon(bool habilitar)
        {
            LabelTipoLogistica.Visible = habilitar;
            DropDownListConceptoLogistica.Visible = habilitar;

            //LabelLocalidadLogistica.Visible = habilitar;
            //DropDownListLocalidadesLogisitca.Visible = habilitar;

            //labelCantInvitadosLogistica.Visible = habilitar;
            //DropDownListCantInvitadosLogisitca.Visible = habilitar;

            TextBoxCostoLogistica.Visible = habilitar;
            TextBoxCostoLogistica.Text = "0";

            //TextBoxCostoCannonBarra.Visible = habilitar;
            //TextBoxCostoCannonCatering.Visible = habilitar;

            TextBoxCostoCannonBarra.Text = "0";
            //TextBoxCostoCannonCatering.Text = "0";

            //LabelCannon.Visible = habilitar;
            LabelLogistica.Visible = habilitar;
        }

        protected void DropDownListCaracteristicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());

            CargarListasTipoCateringTipoTecnica();

            CargarListasAmbientacion();

            UpdatePanelCotizador.Update();
        }

        private void CargarListasTipoCateringTipoTecnica()
        {
            List<TipoCatering> tc = servicios.TraerTipoCatering(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);


            ListTipoCatering = tc.ToList();



            List<TipoServicios> Tt = servicios.TraerTipoServicios(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);


            ListTipoServicios = Tt.ToList();

            if (DropDownListUnidadNegocio.SelectedItem != null && DropDownListProveedor.SelectedItem != null) CargarServicios();

            UpdatePanelCotizador.Update();

        }

        private void CargarListasAmbientacion()
        {
            List<Categorias> categoriasAmbientacion = serviciosAdministrativas.BuscarCategoriasPorLocacionCaracteristicaSegmento(LocacionId, CaracteristicasId, SegmentosId, SectorId);

            ListCategorias = categoriasAmbientacion.ToList();

            if (DropDownListUnidadNegocio.SelectedItem != null && DropDownListProveedor.SelectedItem != null) CargarServicios();

            UpdatePanelCotizador.Update();


        }

        protected void DropDownListSegmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());

            //DropDownListCategoria.DataSource = serviciosAdministrativas.BuscarCategoriasPorLocacionCaracteristicaSegmento(LocacionId, CaracteristicasId, SegmentosId);
            //DropDownListCategoria.DataTextField = "Descripcion";
            //DropDownListCategoria.DataValueField = "Id";
            //DropDownListCategoria.DataBind();

            //TextBoxCostoCannonCatering.Text = ObtenerCostoCanon(Int32.Parse(DropDownListSegmentos.SelectedItem.Value),
            //                                                              Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value), Int32.Parse(DropDownListServicio.SelectedItem.Value)).ToString(); 

            CargarListasTipoCateringTipoTecnica();

            CargarListasAmbientacion();

            UpdatePanelCotizador.Update();
        }

        protected void DropDownListMomentodelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());

            CargarListasTipoCateringTipoTecnica();
        }

        protected void DropDownListProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarServicios();
        }

        private void CargarServicios()
        {
            int unidadNegocio = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString());

            if (unidadNegocio == RubroCatering)
            {
                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = ListTipoCatering.Distinct().ToList();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();



                if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                    TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
                else
                    TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();

            }
            else if (unidadNegocio == RubroTecnica)
            {
                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = ListTipoServicios.Distinct().ToList();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();
            }
            else if (unidadNegocio == RubroBarra)
            {
                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = servicios.BuscarTipoBarrasPorSegmento(SegmentosId, DuracionId);
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();


                if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                    TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
                else
                    TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();

            }
            else if (unidadNegocio == RubroAdicional)
            {
                int Proveedor = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

                List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = serviciosAdministrativas.ObtenerAdicionalesPorProveedor(Proveedor);


                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = Adicionales.ToList();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();

            }
            else if (unidadNegocio == RubroAmbientacion)
            {
                int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
                int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());


                if (SegmentosId == segmentoId && CaracteristicasId == caracteristicaId)
                {
                    AmbientacionCI(caracteristicaId, segmentoId);
                    //if (!AmbientacionCI(caracteristicaId, segmentoId))
                    //{
                    //    DropDownListServicio.Items.Clear();
                    //    DropDownListServicio.DataSource = ListCategorias.ToList();
                    //    DropDownListServicio.DataTextField = "Descripcion";
                    //    DropDownListServicio.DataValueField = "Id";
                    //    DropDownListServicio.DataBind();
                    //}
                }
                else
                {
                    DropDownListServicio.Items.Clear();
                    DropDownListServicio.DataSource = ListCategorias.ToList();
                    DropDownListServicio.DataTextField = "Descripcion";
                    DropDownListServicio.DataValueField = "Id";
                    DropDownListServicio.DataBind();
                }
            }
            else if (unidadNegocio == RubroOrganizacion)
            {
                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = serviciosAdministrativas.ObtenerItemsOrganizacion();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();
            }

            UpdatePanelCotizador.Update();
        }

        #region Logistica

        protected void DropDownListConceptoLogistica_SelectedIndexChanged(object sender, EventArgs e)
        {
            int LocacionOtro = Int32.Parse(ConfigurationManager.AppSettings["LocacionOtro"].ToString());

            if (DropDownListLocaciones.SelectedItem.Text == "OUT")
            {
                if (DropDownListLocacionesOut.SelectedItem.Value == LocacionOtro.ToString())
                    TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUTOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                                                             Int32.Parse(DropDownListLocalidadOut.SelectedItem.Value),
                                                                             CantidadInvitadosLogistica).ToString();
                else
                    TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                                                            CantidadInvitadosLogistica).ToString();
            }
            else
                TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                                                    CantidadInvitadosLogistica).ToString();
        }

        protected void DropDownListLocalidadesLogisitca_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                TextBoxCostoLogistica.Text = ObtenerCostoLogisticaOUT(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
            else
                TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
        }

        private string ObtenerCostoLogistica(int tipoLogisticaId, int cantInvitados)
        {

            int tipoEventoAuditorio = Int32.Parse(ConfigurationManager.AppSettings["Auditorio"].ToString());
            int tipoEventoCongreso = Int32.Parse(ConfigurationManager.AppSettings["Congreso"].ToString());
            int tipoEventoFeriaExposiciones = Int32.Parse(ConfigurationManager.AppSettings["FeriaExposiciones"].ToString());

            int localidad = ListLocaciones.Where(o => o.Id == LocacionId).Select(o => o.LocalidadId).SingleOrDefault();


            CalcularCantidadinvitadosLogistica();
            CostoLogistica costoLogistica = new CostoLogistica();

            if (TipoEventoId == tipoEventoAuditorio)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoCongreso)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoFeriaExposiciones)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                localidad,
                                                                CantidadInvitadosLogistica);
            }

            string TieneLogistica = ListLocaciones.Where(o => o.Id == LocacionId).Select(o => o.TieneLogistica).SingleOrDefault();



            if (TieneLogistica == "S")
            {
                LabelTipoLogistica.Visible = true;
                //LabelLocalidadLogistica.Visible = true;
                //DropDownListLocalidadesLogisitca.Visible = true;
                DropDownListConceptoLogistica.Visible = true;
                LabelLogistica.Visible = true;
                TextBoxCostoLogistica.Visible = true;

                PresupuestoDetalle preDetalle = ListPresupuestoDetalle.Where(o => o.Logistica > 0).SingleOrDefault();

                if (preDetalle == null)
                {

                    if (costoLogistica != null)
                    {
                        return costoLogistica.Valor.ToString();
                    }
                    else
                    { return "Sin Valor"; }
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                LabelTipoLogistica.Visible = false;
                //LabelLocalidadLogistica.Visible = false;
                //DropDownListLocalidadesLogisitca.Visible = false;
                DropDownListConceptoLogistica.Visible = false;
                LabelLogistica.Visible = false;
                TextBoxCostoLogistica.Visible = false;

                return "0";
            }


        }

        private string ObtenerCostoLogisticaOUT(int tipoLogisticaId, int cantInvitados)
        {

            int tipoEventoAuditorio = Int32.Parse(ConfigurationManager.AppSettings["Auditorio"].ToString());
            int tipoEventoCongreso = Int32.Parse(ConfigurationManager.AppSettings["Congreso"].ToString());
            int tipoEventoFeriaExposiciones = Int32.Parse(ConfigurationManager.AppSettings["FeriaExposiciones"].ToString());

            int localidad = ListLocacionesOUT.Where(o => o.Id == LocacionId).Select(o => o.LocalidadId).SingleOrDefault();

            CalcularCantidadinvitadosLogistica();
            CostoLogistica costoLogistica = new CostoLogistica();

            if (TipoEventoId == tipoEventoAuditorio)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoCongreso)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoFeriaExposiciones)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                localidad,
                                                                CantidadInvitadosLogistica);
            }

            string TieneLogistica = ListLocacionesOUT.Where(o => o.Id == LocacionId).Select(o => o.TieneLogistica).SingleOrDefault();



            if (TieneLogistica == "S")
            {
                LabelTipoLogistica.Visible = true;
                //LabelLocalidadLogistica.Visible = true;
                //DropDownListLocalidadesLogisitca.Visible = true;
                DropDownListConceptoLogistica.Visible = true;
                LabelLogistica.Visible = true;
                TextBoxCostoLogistica.Visible = true;

                PresupuestoDetalle preDetalle = ListPresupuestoDetalle.Where(o => o.Logistica > 0).SingleOrDefault();

                if (preDetalle == null)
                {

                    if (costoLogistica != null)
                    {
                        return costoLogistica.Valor.ToString();
                    }
                    else
                    { return "Sin Valor"; }
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                LabelTipoLogistica.Visible = false;
                //LabelLocalidadLogistica.Visible = false;
                //DropDownListLocalidadesLogisitca.Visible = false;
                DropDownListConceptoLogistica.Visible = false;
                LabelLogistica.Visible = false;
                TextBoxCostoLogistica.Visible = false;

                return "0";
            }


        }

        private string ObtenerCostoLogisticaOUTOUT(int tipoLogisticaId, int localidad, int cantInvitados)
        {

            int tipoEventoAuditorio = Int32.Parse(ConfigurationManager.AppSettings["Auditorio"].ToString());
            int tipoEventoCongreso = Int32.Parse(ConfigurationManager.AppSettings["Congreso"].ToString());
            int tipoEventoFeriaExposiciones = Int32.Parse(ConfigurationManager.AppSettings["FeriaExposiciones"].ToString());

            CalcularCantidadinvitadosLogistica();
            CostoLogistica costoLogistica = new CostoLogistica();

            if (TipoEventoId == tipoEventoAuditorio)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoCongreso)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoFeriaExposiciones)
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidad,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else
            {
                costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                    localidad,
                                                                    CantidadInvitadosLogistica);
            }

            string TieneLogistica = ListLocacionesOUT.Where(o => o.Id == LocacionId).Select(o => o.TieneLogistica).SingleOrDefault();

            if (TieneLogistica == "S")
            {
                LabelTipoLogistica.Visible = true;
                //LabelLocalidadLogistica.Visible = true;
                //DropDownListLocalidadesLogisitca.Visible = true;
                DropDownListConceptoLogistica.Visible = true;
                LabelLogistica.Visible = true;
                TextBoxCostoLogistica.Visible = true;

                PresupuestoDetalle preDetalle = ListPresupuestoDetalle.Where(o => o.Logistica > 0).SingleOrDefault();

                if (preDetalle == null)
                {
                    if (costoLogistica != null)
                    {
                        return costoLogistica.Valor.ToString();
                    }
                    else
                    { return "Sin Valor"; }
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                LabelTipoLogistica.Visible = false;
                //LabelLocalidadLogistica.Visible = false;
                //DropDownListLocalidadesLogisitca.Visible = false;
                DropDownListConceptoLogistica.Visible = false;
                LabelLogistica.Visible = false;
                TextBoxCostoLogistica.Visible = false;

                return "0";
            }

        }

        private int CalcularCantidadinvitadosLogistica()
        {
            CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);

            List<ObtenerCantidadInvitadosCatering> Cantidades = servicios.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, CantidadTotalInvitados);


            CantidadInvitadosLogistica = cantInvitadosCosto;
            return cantInvitadosCosto;
        }

        #endregion

        protected void TextBoxFechaDesdeEvento_TextChanged(object sender, EventArgs e)
        {


            DateTime fechaBloqueada = DateTime.ParseExact("07/12/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fechaBloqueada1 = DateTime.ParseExact("14/12/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            //List<FechasBloqueadas> fechas = serviciosPresupuestos.ObtenerFechasBloqueadas(fechaSeleccionada);

            //List<int> Locaciones = fechas.Select(s => s.LocacionId).ToList();

            //ListLocaciones.Where(o => Locaciones.Contains(!o.Id)).ToList();

            //where list.Contains(PUn.UnidadNegocioId)


            List<DateTime> fechasBloqueadasGalpon = new List<DateTime>();

            fechasBloqueadasGalpon.Add(DateTime.ParseExact("08/03/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            //ABRIL
            fechasBloqueadasGalpon.Add(DateTime.ParseExact("26/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            fechasBloqueadasGalpon.Add(DateTime.ParseExact("27/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            fechasBloqueadasGalpon.Add(DateTime.ParseExact("28/04/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            fechasBloqueadasGalpon.Add(DateTime.ParseExact("12/11/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            fechasBloqueadasGalpon.Add(DateTime.ParseExact("03/05/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            fechasBloqueadasGalpon.Add(DateTime.ParseExact("10/05/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture));


            foreach (DateTime item in fechasBloqueadasGalpon)
            {

                if (item.Equals(fechaSeleccionada))
                {
                    int galponMilagro = 37;

                    DropDownListLocaciones.DataSource = ListLocaciones.Where(l => l.Id != galponMilagro).ToList();
                    DropDownListLocaciones.DataTextField = "Descripcion";
                    DropDownListLocaciones.DataValueField = "Id";
                    DropDownListLocaciones.DataBind();

                    LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value);

                    DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value));
                    DropDownListSectores.DataTextField = "Descripcion";
                    DropDownListSectores.DataValueField = "Id";
                    DropDownListSectores.DataBind();

                    SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());

                    BuscarFechas();
                    return;
                }
            }



            if (fechaBloqueada == fechaSeleccionada)
            {


                int BNN = 50;




                DropDownListLocaciones.DataSource = ListLocaciones.Where(l => l.Id == BNN).ToList();
                DropDownListLocaciones.DataTextField = "Descripcion";
                DropDownListLocaciones.DataValueField = "Id";
                DropDownListLocaciones.DataBind();

                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value);

                DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value));
                DropDownListSectores.DataTextField = "Descripcion";
                DropDownListSectores.DataValueField = "Id";
                DropDownListSectores.DataBind();

                SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());

            }
            else if (fechaBloqueada1 == fechaSeleccionada)
            {

                List<Locaciones> loc = new List<Locaciones>();

                DropDownListLocaciones.DataSource = loc.ToList();
                DropDownListLocaciones.DataTextField = "Descripcion";
                DropDownListLocaciones.DataValueField = "Id";
                DropDownListLocaciones.DataBind();

                //LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value);

                List<Sectores> sec = new List<Sectores>();

                DropDownListSectores.DataSource = sec.ToList();
                DropDownListSectores.DataTextField = "Descripcion";
                DropDownListSectores.DataValueField = "Id";
                DropDownListSectores.DataBind();

                //SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
            }
            else
            {
                DropDownListLocaciones.DataSource = ListLocaciones.ToList();
                DropDownListLocaciones.DataTextField = "Descripcion";
                DropDownListLocaciones.DataValueField = "Id";
                DropDownListLocaciones.DataBind();

                DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value));
                DropDownListSectores.DataTextField = "Descripcion";
                DropDownListSectores.DataValueField = "Id";
                DropDownListSectores.DataBind();
            }

            BuscarFechas();

            DropDownListLocaciones.SelectedValue = LocacionId.ToString();
        }

        private void BuscarFechas()
        {
            if (TextBoxFechaDesdeEvento.Text != "")
            {
                DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                List<DomainAmbientHouse.Entidades.ObtenerEventos> eventos = servicios.BuscarEventosPorFechaVista(DateTime.Parse(fechaSeleccionada.ToShortDateString()));

                GridViewEventosReservadosConfirmados.DataSource = eventos;
                GridViewEventosReservadosConfirmados.DataBind();

                UpdatePanelCotizador.Update();
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {

            if (ValidarGuardado())
            {
                try
                {


                    Grabar();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Grabar()
        {
            GrabarEvento();

            GrabarPresupuesto();

            if (EventoSeleccionado.Id > 0)
            {
                servicios.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle);
            }
            else
            {
                servicios.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle);

                CrearNegocioPipedrive();

                PanelNuevoNegocio.Visible = true;

            }


            PanelCotixador.Visible = false;
            PanelMensaje.Visible = true;
            LabelMensaje.Text = "Se Guardo con exito el presupuesto: Nro. " + PresupuestoSeleccionado.Id;
        }

        private void CrearNegocioPipedrive()
        {
            NegociosPipeDrive = new Negocio();

            int social = Int32.Parse(ConfigurationManager.AppSettings["Social"].ToString()); ;


            if (PresupuestoSeleccionado.SegmentoId == social)
            {
                NegociosPipeDrive.titulo = EventoSeleccionado.ApellidoNombreCliente + " " + DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToShortDateString() + " " + DropDownListTipoEvento.SelectedItem.Text;

            }
            else
            {
                NegociosPipeDrive.titulo = EventoSeleccionado.RazonSocial + " - " + EventoSeleccionado.ApellidoNombreCliente + " " + DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToShortDateString() + "  " + DropDownListTipoEvento.SelectedItem.Text;
            }
            NegociosPipeDrive.valor = TotalPresupuesto.ToString();
            NegociosPipeDrive.moneda = "ARS";
            NegociosPipeDrive.usuario = UsuarioPipeDriveId;
            NegociosPipeDrive.persona = EventoSeleccionado.ClienteId;
            NegociosPipeDrive.nroEvento = EventoSeleccionado.Id;
            NegociosPipeDrive.nroPresupuesto = PresupuestoSeleccionado.Id;
            NegociosPipeDrive.fechaEvento = TextBoxFechaDesdeEvento.Text.ToString();


        }

        private void GrabarEvento()
        {

            int EventoAsignado = Int32.Parse(ConfigurationManager.AppSettings["EstadoAsignado"].ToString());



            if (ListClientesPipe.Where(o => o.Id == ClienteId).Count() > 0)
            {
                ClientesPipedrive cliPipe = ListClientesPipe.Where(o => o.Id == ClienteId).SingleOrDefault();



                EventoSeleccionado.ApellidoNombreCliente = cliPipe.ApellidoNombre;
                EventoSeleccionado.RazonSocial = cliPipe.RazonSocial;
                EventoSeleccionado.Mail = cliPipe.Mail;
                EventoSeleccionado.Tel = cliPipe.Telefono;
            }




            if (DropDownListClientesPipe.SelectedItem != null)
            {
                ClienteId = Int32.Parse(DropDownListClientesPipe.SelectedItem.Value.ToString());
                EventoSeleccionado.ClienteId = ClienteId;
            }


            EventoSeleccionado.EmpleadoId = EmpleadoId;


            if (EstadoEvento == 0)
            {
                EventoSeleccionado.EstadoId = EventoAsignado;
            }
            else
            { EventoSeleccionado.EstadoId = EstadoEvento; }

            EventoSeleccionado.Fecha = DateTime.Now;
            EventoSeleccionado.Comentario = TextBoxComentarioEvento.Text;


            EventoId = EventoSeleccionado.Id;
        }

        private void GrabarPresupuesto()
        {
            int PresupuestoGuardado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoGuardado"].ToString());

            PresupuestoSeleccionado.EstadoId = PresupuestoGuardado;
            PresupuestoSeleccionado.FechaEvento = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            PresupuestoSeleccionado.FechaPresupuesto = System.DateTime.Now;
            PresupuestoSeleccionado.EventoId = EventoId;

            PresupuestoSeleccionado.HorarioEvento = TextBoxHoraInicio.Text;
            PresupuestoSeleccionado.HoraFinalizado = TextBoxHoraFin.Text;


            double SumarDias = 10;

            PresupuestoSeleccionado.FechaCaducidad = System.DateTime.Today.AddDays(SumarDias);



            PresupuestoSeleccionado.CantidadInicialInvitados = int.Parse(TextBoxCantMayores.Text);

            if (TextBoxCantMenores3.Text != "")
            { PresupuestoSeleccionado.CantidadInvitadosMenores3 = int.Parse(TextBoxCantMenores3.Text); }

            if (TextBoxCantEntre3y8.Text != "")
            { PresupuestoSeleccionado.CantidadInvitadosMenores3y8 = int.Parse(TextBoxCantEntre3y8.Text); }

            if (TextBoxCantAdolescentes.Text != "")
            { PresupuestoSeleccionado.CantidadInvitadosAdolecentes = int.Parse(TextBoxCantAdolescentes.Text); }


            if (DropDownListTipoEvento.SelectedItem != null)
            {
                TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.TipoEventoId = TipoEventoId;
            }
            else
            {
                PresupuestoSeleccionado.TipoEventoId = TipoEventoId;
            }

            PresupuestoSeleccionado.TipoEventoOtro = TextBoxOtroTipoEvento.Text;

            if (DropDownListLocaciones.SelectedItem != null)
            {

                if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                {
                    LocacionId = Int32.Parse(DropDownListLocacionesOut.SelectedItem.Value.ToString());
                    PresupuestoSeleccionado.LocacionId = LocacionId;
                }
                else
                {
                    LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                    PresupuestoSeleccionado.LocacionId = LocacionId;
                }

            }
            else
            {
                PresupuestoSeleccionado.LocacionId = LocacionId;
            }

            PresupuestoSeleccionado.LocacionOtra = TextBoxOtroLocacion.Text;
            PresupuestoSeleccionado.DireccionOtra = TextBoxDireccionLocacionOut.Text;

            if (DropDownListJornadas.SelectedItem != null)
            {
                JornadaId = Int32.Parse(DropDownListJornadas.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.JornadaId = JornadaId;
            }
            else
            {
                PresupuestoSeleccionado.JornadaId = JornadaId;
            }

            if (DropDownListSegmentos.SelectedItem != null)
            {
                SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.SegmentoId = SegmentosId;
            }
            else
            {
                PresupuestoSeleccionado.SegmentoId = SegmentosId;
            }

            if (DropDownListCaracteristicas.SelectedItem != null)
            {
                CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.CaracteristicaId = CaracteristicasId;
            }
            else
            {
                PresupuestoSeleccionado.CaracteristicaId = CaracteristicasId;
            }

            if (DropDownListSectores.SelectedItem != null)
            {
                SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.SectorId = SectorId;
            }

            //if (DropDownListDuracionEvento.SelectedItem != null)
            //{
            //    DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());
            PresupuestoSeleccionado.DuracionId = DuracionId;
            //}
            //else
            //{
            //    PresupuestoSeleccionado.DuracionId = DuracionId;
            //}

            if (DropDownListMomentodelDia.SelectedItem != null)
            {
                MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.MomentoDiaID = MomentoDiaId;
            }
            else
            {
                PresupuestoSeleccionado.MomentoDiaID = MomentoDiaId;
            }

            if (cmd.IsNumeric(TextBoxPorcentajeOrganizador.Text))
            {
                PresupuestoSeleccionado.PorcentajeOrganizador = double.Parse(TextBoxPorcentajeOrganizador.Text);

            }
            else
            { PresupuestoSeleccionado.PorcentajeOrganizador = null; }


            if (cmd.IsNumeric(TextBoxImporteOrganizador.Text))
            {
                PresupuestoSeleccionado.ImporteOrganizador = double.Parse(TextBoxImporteOrganizador.Text);
            }
            else
            { PresupuestoSeleccionado.ImporteOrganizador = null; }

            if (cmd.IsNumeric(TotalOrganizador))
            {
                PresupuestoSeleccionado.ValorOrganizador = TotalOrganizador;
            }

            if (cmd.IsNumeric(TotalOrganizadorRoyalty))
            {
                PresupuestoSeleccionado.ValorRoyaltyOrganizador = TotalOrganizadorRoyalty;
            }

            PresupuestoSeleccionado.Comentario = TextBoxComentarioEvento.Text;

        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            int PresupuestoARevisar = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoARevisar"].ToString());

            if (ValidarConfirmacion())
            {


                if (EventoSeleccionado.Id > 0)
                {
                    ConfirmarEvento();

                    ConfirmarPresupuesto();

                    servicios.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle);


                    if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroCatering).Count() > 0)
                        TipoCateringId = Int32.Parse(serviciosAdministrativas.BuscarProducto(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroCatering).FirstOrDefault().ProductoId).TipoCateringId.ToString());

                    PresupuestoId = PresupuestoSeleccionado.Id;

                    EventoId = EventoSeleccionado.Id;

                    Presupuestos = new PresupuestoPDF();

                    Presupuestos = serviciosPresupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);
                }
                else
                {
                    ConfirmarEvento();

                    ConfirmarPresupuesto();

                    servicios.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle);

                    if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroCatering).Count() > 0)
                        TipoCateringId = Int32.Parse(serviciosAdministrativas.BuscarProducto(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroCatering).FirstOrDefault().ProductoId).TipoCateringId.ToString());

                    PresupuestoId = PresupuestoSeleccionado.Id;

                    EventoId = EventoSeleccionado.Id;

                    Presupuestos = new PresupuestoPDF();

                    Presupuestos = serviciosPresupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

                    CrearNegocioPipedrive();

                    PanelNuevoEventoConfirmado.Visible = true;

                }

                if (PresupuestoSeleccionado.EstadoId == PresupuestoARevisar)
                {
                    PanelVisorPDF.Visible = false;
                    PanelCotixador.Visible = false;
                    PanelMensaje.Visible = true;
                    LabelMensaje.Text = "Se Guardo con exito el presupuesto: Nro. " + PresupuestoSeleccionado.Id + " Esta a Revisar por Administracion.";
                }
                else
                {
                    PanelVisorPDF.Visible = true;
                    PanelCotixador.Visible = false;
                }
            }
        }

        private void ConfirmarPresupuesto()
        {
            int PresupuestoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());

            int PresupuestoARevisar = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoARevisar"].ToString());


            int ValorARevisarPresupuesto = Int32.Parse(ConfigurationManager.AppSettings["ValorARevisarPresupuesto"].ToString());


            if (TotalPresupuesto >= ValorARevisarPresupuesto)
                PresupuestoSeleccionado.EstadoId = PresupuestoARevisar;
            else
                PresupuestoSeleccionado.EstadoId = PresupuestoEnviado;


            PresupuestoSeleccionado.FechaEvento = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            PresupuestoSeleccionado.FechaPresupuesto = System.DateTime.Now;
            PresupuestoSeleccionado.EventoId = EventoId;

            PresupuestoSeleccionado.HorarioEvento = TextBoxHoraInicio.Text;
            PresupuestoSeleccionado.HoraFinalizado = TextBoxHoraFin.Text;

            PresupuestoSeleccionado.Comentario = TextBoxComentarioEvento.Text;


            PresupuestoSeleccionado.CantidadInicialInvitados = int.Parse(TextBoxCantMayores.Text);

            if (TextBoxCantMenores3.Text != "")
            { PresupuestoSeleccionado.CantidadInvitadosMenores3 = int.Parse(TextBoxCantMenores3.Text); }

            if (TextBoxCantEntre3y8.Text != "")
            { PresupuestoSeleccionado.CantidadInvitadosMenores3y8 = int.Parse(TextBoxCantEntre3y8.Text); }

            if (TextBoxCantAdolescentes.Text != "")
            { PresupuestoSeleccionado.CantidadInvitadosAdolecentes = int.Parse(TextBoxCantAdolescentes.Text); }


            if (DropDownListTipoEvento.SelectedItem != null)
            {
                TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.TipoEventoId = TipoEventoId;
            }
            else
            {
                PresupuestoSeleccionado.TipoEventoId = TipoEventoId;
            }

            PresupuestoSeleccionado.TipoEventoOtro = TextBoxOtroTipoEvento.Text;

            if (DropDownListLocaciones.SelectedItem != null)
            {

                if (DropDownListLocaciones.SelectedItem.Text == "OUT")
                {
                    LocacionId = Int32.Parse(DropDownListLocacionesOut.SelectedItem.Value.ToString());
                    PresupuestoSeleccionado.LocacionOtra = "OUT";
                    PresupuestoSeleccionado.LocacionId = LocacionId;
                }
                else
                {
                    LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                    PresupuestoSeleccionado.LocacionId = LocacionId;
                }
            }
            else
            {
                PresupuestoSeleccionado.LocacionId = LocacionId;
            }

            PresupuestoSeleccionado.LocacionOtra = TextBoxOtroLocacion.Text;
            PresupuestoSeleccionado.DireccionOtra = TextBoxDireccionLocacionOut.Text;

            if (DropDownListJornadas.SelectedItem != null)
            {
                JornadaId = Int32.Parse(DropDownListJornadas.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.JornadaId = JornadaId;
            }
            else
            {
                PresupuestoSeleccionado.JornadaId = JornadaId;
            }

            if (DropDownListSegmentos.SelectedItem != null)
            {
                SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.SegmentoId = SegmentosId;
            }
            else
            {
                PresupuestoSeleccionado.SegmentoId = SegmentosId;
            }

            if (DropDownListCaracteristicas.SelectedItem != null)
            {
                CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.CaracteristicaId = CaracteristicasId;
            }
            else
            {
                PresupuestoSeleccionado.CaracteristicaId = CaracteristicasId;
            }

            if (DropDownListSectores.SelectedItem != null)
            {

                SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.SectorId = SectorId;
            }
            else if (DropDownListSectoresOut.SelectedItem != null)
            {
                SectorId = Int32.Parse(DropDownListSectoresOut.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.SectorId = SectorId;
            }


            if (DropDownListMomentodelDia.SelectedItem != null)
            {
                MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.MomentoDiaID = MomentoDiaId;
            }
            else
            {
                PresupuestoSeleccionado.MomentoDiaID = MomentoDiaId;
            }

            PresupuestoSeleccionado.DuracionId = DuracionId;


            if (cmd.IsNumeric(TextBoxPorcentajeOrganizador.Text))
            {
                PresupuestoSeleccionado.PorcentajeOrganizador = double.Parse(TextBoxPorcentajeOrganizador.Text);

            }

            if (cmd.IsNumeric(TextBoxPorcentajeOrganizador.Text))
            {
                PresupuestoSeleccionado.PorcentajeOrganizador = double.Parse(TextBoxPorcentajeOrganizador.Text);

            }
            else
            { PresupuestoSeleccionado.PorcentajeOrganizador = null; }


            if (cmd.IsNumeric(TextBoxImporteOrganizador.Text))
            {
                PresupuestoSeleccionado.ImporteOrganizador = double.Parse(TextBoxImporteOrganizador.Text);
            }
            else
            { PresupuestoSeleccionado.ImporteOrganizador = null; }



            if (cmd.IsNumeric(TotalOrganizador))
            {
                PresupuestoSeleccionado.ValorOrganizador = TotalOrganizador;
            }

            if (cmd.IsNumeric(TotalOrganizadorRoyalty))
            {
                PresupuestoSeleccionado.ValorRoyaltyOrganizador = TotalOrganizadorRoyalty;
            }
        }

        private void ConfirmarEvento()
        {

            int EventoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());

            ClientesPipedrive cliPipe = ListClientesPipe.Where(o => o.Id == ClienteId).SingleOrDefault();

            EventoSeleccionado.ApellidoNombreCliente = cliPipe.ApellidoNombre;
            EventoSeleccionado.RazonSocial = cliPipe.RazonSocial;
            EventoSeleccionado.Mail = cliPipe.Mail;
            EventoSeleccionado.Tel = cliPipe.Telefono;

            if (DropDownListClientesPipe.SelectedItem != null)
            {
                ClienteId = Int32.Parse(DropDownListClientesPipe.SelectedItem.Value.ToString());
                EventoSeleccionado.ClienteId = ClienteId;
            }

            EventoSeleccionado.EmpleadoId = EmpleadoId;
            EventoSeleccionado.EstadoId = EventoEnviado;
            EventoSeleccionado.Fecha = DateTime.Now;

            EventoId = EventoSeleccionado.Id;

        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        #region Clientes

        protected void ButtonBuscarCliente_Click(object sender, EventArgs e)
        {

            BuscarClientes();

        }

        private void BuscarClientes()
        {
            string cliente = TextBoxApellidoBuscador.Text.ToUpper();
            LabelMensajeCliente.Visible = false;


            List<ClientesPipedrive> cliPipe = ListClientesPipe.Where(o => o.ApellidoNombre.ToUpper().Contains(cliente)).ToList();

            if (cliPipe.Count > 0)
            {

                DropDownListClientesPipe.DataSource = cliPipe.ToList();
                DropDownListClientesPipe.DataTextField = "Identificador";
                DropDownListClientesPipe.DataValueField = "Id";
                DropDownListClientesPipe.DataBind();

                ClienteId = Int32.Parse(DropDownListClientesPipe.SelectedValue);


                PanelListarClientes.Visible = true;

                UpdatePanelCotizador.Update();
            }
            else
            {

                LabelMensajeCliente.Visible = true;

                LabelMensajeCliente.Text = "No hay Contactos con los parametros seleccionados.";

                UpdatePanelCotizador.Update();
            }

        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxApellidoBuscador.Text = "";

            DropDownListClientesPipe.Items.Clear();

            PanelListarClientes.Visible = false;



            UpdatePanelCotizador.Update();



        }

        #endregion

        protected void ButtonClienteAsignarOtroEjecutivo_Click(object sender, EventArgs e)
        {
            Grabar();
            Response.Redirect("~/Inicio/Default.aspx");
        }

        protected void DropDownListClientesPipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteId = Int32.Parse(DropDownListClientesPipe.SelectedItem.Value);
        }

        private void CalcularTotalOrganizador()
        {
            double coeficienteRoyalty = double.Parse(ConfigurationManager.AppSettings["coeficienteRoyalty"].ToString());

            coeficienteRoyalty = (coeficienteRoyalty / 100);

            if (cmd.IsNumeric(TotalPresupuesto) && cmd.IsNumeric(TextBoxPorcentajeOrganizador.Text))
            {

                TotalOrganizador = TotalPresupuesto * double.Parse(TextBoxPorcentajeOrganizador.Text) / 100;
                TotalOrganizadorRoyalty = (TotalPresupuesto * double.Parse(TextBoxPorcentajeOrganizador.Text) / 100) * coeficienteRoyalty;

            }

            else if (cmd.IsNumeric(TotalPresupuesto) && cmd.IsNumeric(TextBoxImporteOrganizador.Text))
            {
                TotalOrganizador = double.Parse(TextBoxImporteOrganizador.Text);

                TotalOrganizadorRoyalty = (double.Parse(TextBoxImporteOrganizador.Text) * coeficienteRoyalty);
            }

            TextBoxTotalPorcOrganizador.Text = TotalOrganizador.ToString("C");

            CalcularTotalPresupuesto();
        }

        protected void GridViewVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            if (e.CommandName == "CargarAdicionales")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                UnidadNegocioId = int.Parse(row.Cells[9].Text);


                UnidadNegocioParaAdicional = UnidadNegocioId;

                PrecioParaAdicional = row.Cells[3].Text;

                List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = new List<ObtenerAdicionales>();

                if (UnidadNegocioId == RubroSalon)
                {
                    Adicionales = serviciosAdministrativas.ObtenerAdicionalesPorLocacionesUnidadNegocio(LocacionId);
                }
                else if (UnidadNegocioId == RubroCatering)
                {

                    int ProductoId = int.Parse(row.Cells[0].Text);

                    int TipoCateringId = (int)serviciosAdministrativas.BuscarProducto(ProductoId).TipoCateringId;

                    ProveedorId = int.Parse(row.Cells[8].Text);


                    Adicionales = serviciosAdministrativas.ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(ProveedorId, UnidadNegocioId, TipoCateringId);
                }
                else
                {
                    ProveedorId = int.Parse(row.Cells[8].Text);

                    Adicionales = serviciosAdministrativas.ObtenerAdicionalesPorProveedoryUnidadNegocio(ProveedorId, UnidadNegocioId);

                }


                if (Adicionales.Count > 0)
                {
                    DropDownListAdicionales.Items.Clear();
                    DropDownListAdicionales.DataSource = Adicionales.ToList();
                    DropDownListAdicionales.DataTextField = "Descripcion";
                    DropDownListAdicionales.DataValueField = "Id";
                    DropDownListAdicionales.DataBind();


                    Adicionales adi = serviciosAdministrativas.BuscarAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));

                    if (DropDownListAdicionales.SelectedItem.Value != "0")
                    {
                        if (adi.RequiereCantidad == "S")
                        {
                            LabelCantidadAdicional.Visible = true;
                            TextBoxCantidadAdicional.Visible = true;
                        }
                        else if (adi.RequiereCantidadRango == "S")
                        {
                            LabelCantidadAdicional.Visible = true;
                            TextBoxCantidadAdicional.Visible = true;
                        }
                        else
                        {
                            LabelCantidadAdicional.Visible = false;
                            TextBoxCantidadAdicional.Visible = false;
                        }
                    }

                    PanelAdicionales.Visible = true;
                    LabelMensajeAdicionales.Visible = false;
                }
                else
                {
                    LabelMensajeAdicionales.Visible = true;
                    LabelMensajeAdicionales.Text = "No hay Adicionales para este Proveedor/Locacion seleccionada.";

                    PanelAdicionales.Visible = false;

                }

                UpdatePanelCotizador.Update();

            }
            else if (e.CommandName == "CargarPrecios")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = new DomainAmbientHouse.Entidades.PresupuestoDetalle();

                detalle.ProductoId = Int32.Parse(row.Cells[0].Text);


                DropDownList precios = row.FindControl("DropDownListPreciosItem") as DropDownList;


                var itemRemove = ListPresupuestoDetalle.Where(o => o.ProductoId == detalle.ProductoId).SingleOrDefault();

                ListPresupuestoDetalle.Remove(itemRemove);

                PresupuestoDetalle itemAgregado = new PresupuestoDetalle();

                itemAgregado = itemRemove;

                string precioSelecccionado = precios.SelectedItem.Text;

                PresupuestoDetalleADD searcher = new PresupuestoDetalleADD();

                searcher.precioSeleccionado = precioSelecccionado;
                searcher.unidadNegocio = (int)itemAgregado.UnidadNegocioId;
                searcher.productoNinguno = 0;

                searcher.servicioId = (int)itemAgregado.ServicioId;

                if (itemAgregado.ProveedorId != null)
                    searcher.proveedorId = (int)itemAgregado.ProveedorId;

                if (itemAgregado.CantidadAdicional != null)
                    searcher.cantidadAdicional = itemAgregado.CantidadAdicional.ToString();

                searcher.cantidadAdultos = TextBoxCantMayores.Text;
                searcher.cantidadEntre3y8 = TextBoxCantEntre3y8.Text;
                searcher.cantidadMenores3 = TextBoxCantMenores3.Text;
                searcher.cantidadAdolescentes = TextBoxCantAdolescentes.Text;



                searcher.FechaEvento = TextBoxFechaDesdeEvento.Text;

                if (itemAgregado.TipoLogisticaId != null)
                    searcher.TipoLogisticaId = (int)itemAgregado.TipoLogisticaId;
                if (itemAgregado.LocalidadId != null)
                    searcher.LocalidadId = (int)itemAgregado.LocalidadId;
                if (itemAgregado.Logistica != null)
                    searcher.LogisticaCosto = (int)itemAgregado.Logistica;



                Accion = "M";
                AgregarItem(searcher);


            }

            else if (e.CommandName == "QuitarItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = new DomainAmbientHouse.Entidades.PresupuestoDetalle();


                detalle.ProductoId = Int32.Parse(row.Cells[0].Text);



                List<PresupuestoDetalle> itemRemove = ListPresupuestoDetalle.Where(o => o.ProductoId == detalle.ProductoId).ToList();

                foreach (var item in itemRemove)
                {
                    if (item.UnidadNegocioId == RubroSalon)
                    {
                        ListPresupuestoDetalle.Clear();
                        PanelArmarCotizacion.Visible = false;
                        PanelAmbientacionCorporativoInformal.Visible = false;
                        ButtonAgregarItem.Visible = false;
                    }
                    else
                        ListPresupuestoDetalle.Remove(item);
                }



                GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                GridViewVentas.DataBind();

                if (GridViewVentas.Rows.Count == 0)
                {
                    TextBoxPorcentajeOrganizador.Text = "";
                    TextBoxImporteOrganizador.Text = "";

                    HabilitarDeshabilitarDropdownList(true);
                }



                TextBoxTotalPresupuesto.Text = ListPresupuestoDetalle.Sum(o => o.ValorSeleccionado).ToString();

                TextBoxTotalPAX.Text = (double.Parse(TextBoxTotalPresupuesto.Text) / CantidadTotalInvitados).ToString();

                CalcularTotalPresupuesto();

                CalcularSubTotalComision();

                CalcularRenta();

                TextBoxCantidadAdicional.Text = "";
                UpdatePanelCotizador.Update();

            }

        }

        protected void DropDownListAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListAdicionales.SelectedItem != null)
            {
                Adicionales adicional = servicios.BuscarAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));

                if (adicional.RequiereCantidad == "S")
                {
                    LabelCantidadAdicional.Visible = true;
                    TextBoxCantidadAdicional.Visible = true;
                }
                else if (adicional.RequiereCantidadRango == "S")
                {
                    LabelCantidadAdicional.Visible = true;
                    TextBoxCantidadAdicional.Visible = true;
                }
                else
                {
                    LabelCantidadAdicional.Visible = false;
                    TextBoxCantidadAdicional.Visible = false;
                }
            }
        }

        protected void GridViewVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button presupuestarAdicionales = (Button)e.Row.FindControl("ButtonPresupuestarAdicionales");

                DropDownList precios = (DropDownList)e.Row.FindControl("DropDownListPreciosItem");

                Button cambiarPrecios = (Button)e.Row.FindControl("ButtonCambiarPrecio");



                if (e.Row.Cells[9].Text == "9")
                {
                    presupuestarAdicionales.Visible = false;
                }

                if (e.Row.Cells[9].Text == "Sin Precio")
                {
                    cambiarPrecios.Visible = false;
                    presupuestarAdicionales.Visible = false;
                    precios.Visible = false;

                }


            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        private void CalcularRenta()
        {
            Parametros paramRentaPorc = new Parametros();

            paramRentaPorc = serviciosAdministrativas.BuscarParametro("ValorRentaenPorcentajeMinimo");

            Parametros paramRentaImporte = new Parametros();

            paramRentaImporte = serviciosAdministrativas.BuscarParametro("ValorRentaenNominalMinimo");


            double porcentaje = cmd.CalcularRentaPorcentaje(ListPresupuestoDetalle);
            double valor = cmd.CalcularRentaValor(ListPresupuestoDetalle);


            if (valor < double.Parse(paramRentaImporte.Valor.ToString()))
            {
                TextBoxRentaValor.ForeColor = System.Drawing.Color.White;
                TextBoxRentaValor.BackColor = System.Drawing.Color.Red;

            }

            if (porcentaje < double.Parse(paramRentaPorc.Valor.ToString()))
            {
                TextBoxRentaPorcentaje.ForeColor = System.Drawing.Color.White;
                TextBoxRentaPorcentaje.BackColor = System.Drawing.Color.Red;

            }


            TextBoxRentaPorcentaje.Text = porcentaje.ToString();
            TextBoxRentaValor.Text = valor.ToString("C");



        }

        protected void ButtonCalcularOrganizador_Click(object sender, EventArgs e)
        {
            CalcularTotalOrganizador();

            TextBoxPorcentajeOrganizador.ReadOnly = true;
            TextBoxImporteOrganizador.ReadOnly = true;
        }

        protected void ButtonQuitarOrganizador_Click(object sender, EventArgs e)
        {
            TextBoxPorcentajeOrganizador.ReadOnly = false;
            TextBoxImporteOrganizador.ReadOnly = false;

            TextBoxImporteOrganizador.Text = "";
            TextBoxPorcentajeOrganizador.Text = "";
            TextBoxTotalPorcOrganizador.Text = "";
            TotalOrganizador = 0;
            TotalOrganizadorRoyalty = 0;
            CalcularTotalOrganizador();
        }

        protected void DropDownListSectores_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListSectores.SelectedItem != null)
            {
                SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value);

                ObtenerTecnicaSalon();



                CargarListasAmbientacion();
            }


        }

        public void CalcularDuracionEvento(string horaInicio, string horaFin)
        {

            double duracionEvento = 0;
            string cadenaHoraInicio;
            string cadenaMinutosInicio;

            string cadenaHoraFin;
            string cadenaMinutosFin;

            cadenaHoraInicio = horaInicio.Substring(0, 2);
            cadenaMinutosInicio = horaInicio.Substring(3, 2);

            cadenaHoraFin = horaFin.Substring(0, 2);
            cadenaMinutosFin = horaFin.Substring(3, 2);



            if (Int32.Parse(cadenaHoraInicio) == 0)
                horaInicio = "24";

            if (Int32.Parse(cadenaHoraFin) == 0)
                horaInicio = "24";

            int hHoraInicio = Int32.Parse(cadenaHoraInicio + cadenaMinutosInicio);

            int hHoraFin = Int32.Parse(cadenaHoraFin + cadenaMinutosFin);


            if (hHoraFin > hHoraInicio)
                duracionEvento = (hHoraFin - hHoraInicio) / 100;
            else
                duracionEvento = ((2400 - hHoraInicio) + hHoraFin) / 100;

            List<DuracionEvento> Duraciones = serviciosAdministrativas.ObtenerDuracionEvento().OrderBy(o => o.CantidadHoras).ToList();

            foreach (var item in Duraciones)
            {
                if (duracionEvento <= item.CantidadHoras)
                {
                    DuracionId = item.Id;
                    CargarListasTipoCateringTipoTecnica();
                    return;

                }
            }

            int cantidadhoras = (int)Duraciones.Max(o => o.CantidadHoras);


            DuracionId = Duraciones.Where(o => o.CantidadHoras.Equals(cantidadhoras)).FirstOrDefault().Id;
            CargarListasTipoCateringTipoTecnica();


        }

        protected void DropDownListLocacionesOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            int LocacionOtro = Int32.Parse(ConfigurationManager.AppSettings["LocacionOtro"].ToString());

            TextBoxCannonOut.Text = "";
            TextBoxCannonOutBarra.Text = "";
            TextBoxCannonOutAmbientacion.Text = "";

            TextBoxUsoCocinaOUT.Text = "";

            if (Int32.Parse(DropDownListLocacionesOut.SelectedItem.Value) > 0)
            {
                if (DropDownListLocacionesOut.SelectedItem.Value == LocacionOtro.ToString())
                {

                    TextBoxOtroLocacion.Visible = true;
                    TextBoxDireccionLocacionOut.Visible = true;
                    DropDownListLocalidadOut.Visible = true;
                    ObtenerDatosLocacionOut();

                    DropDownListSectoresOut.Visible = false;


                }
                else
                {
                    TextBoxOtroLocacion.Visible = false;
                    TextBoxDireccionLocacionOut.Visible = false;
                    DropDownListLocalidadOut.Visible = false;

                    ObtenerDatosLocacionOut();

                    DropDownListSectoresOut.Visible = true;

                }
            }
        }

        private void ObtenerDatosLocacionOut()
        {
            LocacionId = Int32.Parse(DropDownListLocacionesOut.SelectedItem.Value);

            Locaciones loc = ListLocacionesOUT.Where(o => o.Id == LocacionId).SingleOrDefault();


            DropDownListSectoresOut.DataSource = servicios.BuscarSectoresPorLocacion(LocacionId);
            DropDownListSectoresOut.DataTextField = "Descripcion";
            DropDownListSectoresOut.DataValueField = "Id";
            DropDownListSectoresOut.DataBind();

            if (DropDownListSectoresOut.SelectedItem.Value != null)
                SectorId = Int32.Parse(DropDownListSectoresOut.SelectedItem.Value);
            else
                SectorId = new Int32();

            ObtenerTecnicaSalon();

            CargarListasAmbientacion();

            if (loc.TipoCannonCatering == null)
            {
                if (RadioButtonCannonPorPersona.Checked)
                    TipoCannon = "Persona";
                else if (RadioButtonCannonPorcentaje.Checked)
                    TipoCannon = "Porcentaje";
                else
                    TipoCannon = "Fijo";
            }
            else
            {
                if (loc.TipoCannonCatering == "Persona")
                {
                    RadioButtonCannonPorPersona.Checked = true;
                    TipoCannon = "Persona";
                }
                else if (loc.TipoCannonCatering == "Porcentaje")
                {
                    RadioButtonCannonPorcentaje.Checked = true;
                    TipoCannon = "Porcentaje";
                }
                else
                {
                    RadioButtonCannonAbsoluto.Checked = true;
                    TipoCannon = "Fijo";
                }
            }


            if (loc.TipoCannonBarra == null)
            {
                if (RadioButtonCannonPorPersonaBarra.Checked)
                    TipoCannonBarra = "Persona";
                else if (RadioButtonCannonPorcentajeBarra.Checked)
                    TipoCannonBarra = "Porcentaje";
                else
                    TipoCannonBarra = "Fijo";
            }
            else
            {
                if (loc.TipoCannonBarra == "Persona")
                {
                    RadioButtonCannonPorPersonaBarra.Checked = true;
                    TipoCannonBarra = "Persona";
                }
                else if (loc.TipoCannonBarra == "Porcentaje")
                {
                    RadioButtonCannonPorcentajeBarra.Checked = true;
                    TipoCannonBarra = "Porcentaje";
                }
                else
                {
                    RadioButtonCannonAbsolutoBarra.Checked = true;
                    TipoCannonBarra = "Fijo";
                }
            }

            if (loc.TipoCannonAmbientacion == null)
            {
                if (RadioButtonCannonPorPersonaAmbientacion.Checked)
                    TipoCannonAmbientacion = "Persona";
                else if (RadioButtonCannonPorcentajeAmbientacion.Checked)
                    TipoCannonAmbientacion = "Porcentaje";
                else
                    TipoCannonAmbientacion = "Fijo";
            }
            else
            {
                if (loc.TipoCannonAmbientacion == "Persona")
                {
                    RadioButtonCannonPorPersonaAmbientacion.Checked = true;
                    TipoCannonAmbientacion = "Persona";
                }
                else if (loc.TipoCannonAmbientacion == "Porcentaje")
                {
                    RadioButtonCannonPorcentajeAmbientacion.Checked = true;
                    TipoCannonAmbientacion = "Porcentaje";
                }
                else
                {
                    RadioButtonCannonAbsolutoAmbientacion.Checked = true;
                    TipoCannonAmbientacion = "Fijo";
                }
            }


            if (loc.Cannon != null)
            {
                if (Int32.Parse(loc.Cannon.ToString()) > 0)
                {
                    TextBoxCannonOut.Text = loc.Cannon.ToString();
                    TextBoxCannonOut.ReadOnly = true;
                }
                else
                    TextBoxCannonOut.ReadOnly = false;
            }
            else
            { TextBoxCannonOut.ReadOnly = false; }

            if (loc.CannonBarra != null)
            {
                if (Int32.Parse(loc.CannonBarra.ToString()) > 0)
                {
                    TextBoxCannonOutBarra.Text = loc.CannonBarra.ToString();
                    TextBoxCannonOutBarra.ReadOnly = true;
                }
                else
                    TextBoxCannonOutBarra.ReadOnly = false;
            }
            else
            { TextBoxCannonOutBarra.ReadOnly = false; }

            if (loc.CannonAmbientacion != null)
            {
                if (Int32.Parse(loc.CannonAmbientacion.ToString()) > 0)
                {
                    TextBoxCannonOutAmbientacion.Text = loc.CannonAmbientacion.ToString();
                    TextBoxCannonOutAmbientacion.ReadOnly = true;
                }
                else
                    TextBoxCannonOutAmbientacion.ReadOnly = false;
            }
            else
            { TextBoxCannonOutAmbientacion.ReadOnly = false; }




            if (loc.UsoCocina != null)
            {
                if (Int32.Parse(loc.UsoCocina.ToString()) > 0)
                {
                    TextBoxUsoCocinaOUT.Text = loc.UsoCocina.ToString();
                    TextBoxUsoCocinaOUT.ReadOnly = true;
                }
                else
                    TextBoxUsoCocinaOUT.ReadOnly = false;
            }
            else
            { TextBoxUsoCocinaOUT.ReadOnly = false; }

            UpdatePanelLocacionOut.Update();
        }

        protected void DropDownListSectoresOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListSectoresOut.SelectedItem != null)
            {
                SectorId = Int32.Parse(DropDownListSectoresOut.SelectedItem.Value);

                ObtenerTecnicaSalon();



                CargarListasAmbientacion();
            }


        }

        #region RadioButton

        protected void RadioButtonCannonPorPersona_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannon = "Persona";
        }

        protected void RadioButtonCannonPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannon = "Porcentaje";
        }

        protected void RadioButtonCannonAbsoluto_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannon = "Fijo";
        }

        protected void RadioButtonCannonPorPersonaBarra_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannonBarra = "Persona";
        }

        protected void RadioButtonCannonPorcentajeBarra_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannonBarra = "Porcentaje";
        }

        protected void RadioButtonCannonAbsolutoBarra_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannonBarra = "Fijo";
        }

        protected void RadioButtonCannonPorPersonaAmbientacion_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannonAmbientacion = "Persona";
        }

        protected void RadioButtonCannonPorcentajeAmbientacion_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannonAmbientacion = "Porcentaje";
        }

        protected void RadioButtonCannonAbsolutoAmbientacion_CheckedChanged(object sender, EventArgs e)
        {
            TipoCannonAmbientacion = "Fijo";
        }

        #endregion

        private Productos CargarAmbientacionCI(string fechaEvento, int paqueteAmbientacionId, int caracteristicaId, int segmentoId, int proveedorId, int cantidadPaquetes, string precioSeleccionado)
        {

            int semestre = Int32.Parse(cmd.ObtenerSemestre(fechaEvento));

            int anio = DateTime.Parse(fechaEvento).Year;

            int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());
            int pendienteDetalle = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());


            DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion costoAmbientacion = servicios.BuscarPreciosCostosPaquetesCIAmbientacion(paqueteAmbientacionId,
                                                                                                                                             caracteristicaId,
                                                                                                                                             segmentoId,
                                                                                                                                             proveedorId,
                                                                                                                                             cantidadPaquetes,
                                                                                                                                             semestre, anio);

            if (costoAmbientacion != null)
            {

                return GenerarNuevoProducto(fechaEvento, semestre, anio, activo, costoAmbientacion);


            }
            return new Productos();

        }

        private Productos GenerarNuevoProducto(string fechaEvento, int semestre, int anio, int activo, DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion costoAmbientacion)
        {

            string Codigo = cmd.ArmarCodigoAmbientacionCorporativoInformal(Int32.Parse(DropDownListCIItemsAmbientacion.SelectedItem.Value),
                                                                                Int32.Parse(DropDownListProveedor.SelectedItem.Value),
                                                                                Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue),
                                                                                SectorId, fechaEvento);


            Productos producto = serviciosAdministrativas.BuscarProductosPorCodigo(Codigo);

            if (producto == null)
                producto = new Productos();

            producto.UnidadNegocioId = RubroAmbientacion;
            producto.Codigo = Codigo;

            producto.Descripcion = DropDownListCIItemsAmbientacion.SelectedItem.Text + " Cant. Paquetes: " + DropDownListCICantidadPaquetesAmbientacion.SelectedValue;
            producto.CantidadInvitados = Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue);
            producto.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);
            producto.SegmentoId = SegmentosId;
            producto.CaracteristicaId = CaracteristicasId;
            producto.SectorId = SectorId;
            producto.LocacionId = LocacionId;
            producto.CategoriaId = Int32.Parse(DropDownListCIItemsAmbientacion.SelectedItem.Value);
            producto.Semestre = semestre;
            producto.Anio = anio;
            double Costo = (costoAmbientacion.Costo * Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue)) + costoAmbientacion.CostoFlete;
            producto.Costo = Costo;
            double Precio = (costoAmbientacion.Precio * Int32.Parse(DropDownListCICantidadPaquetesAmbientacion.SelectedValue)) + costoAmbientacion.CostoFlete;
            producto.Precio = Precio;
            producto.Margen = Precio / Costo;
            producto.Estado = activo;


            serviciosAdministrativas.NuevoProducto(producto);
            return producto;
        }

        protected void TextBoxCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenerarPDF()
        {
            Document doc = new Document(PageSize.A4);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\Diego\prueba.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();


            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Mi primer documento PDF"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Llenamos la tabla con información
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();

        }

        private void GenerarPDFconImagen()
        {

            Document doc = new Document(PageSize.A4);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\Diego\prueba.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();
            Paragraph paragraph = new Paragraph("Getting Started ITextSharp.");

            string imageURL = Server.MapPath(".") + "\\GRUPO LAHUSEN.png";

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

            //Resize image depend upon your need

            jpg.ScaleToFit(140f, 120f);

            //Give space before image

            jpg.SpacingBefore = 10f;

            //Give some space after the image

            jpg.SpacingAfter = 1f;

            jpg.Alignment = Element.ALIGN_LEFT;



            doc.Add(paragraph);

            doc.Add(jpg);

            doc.Close();
            writer.Close();

        }


    }
}
