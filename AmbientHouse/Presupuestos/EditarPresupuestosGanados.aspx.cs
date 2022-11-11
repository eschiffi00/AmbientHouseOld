using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AmbientHouse.Presupuestos
{
    public partial class EditarPresupuestosGanados : System.Web.UI.Page
    {

        #region Variables

        private int RubroSalon
        {
            get
            {
                return Int32.Parse(Session["RubroSalonAdicionales"].ToString());
            }
            set
            {
                Session["RubroSalonAdicionales"] = value;
            }
        }

        private int RubroCatering
        {
            get
            {
                return Int32.Parse(Session["RubroCateringAdicionales"].ToString());
            }
            set
            {
                Session["RubroCateringAdicionales"] = value;
            }
        }

        private int RubroBarra
        {
            get
            {
                return Int32.Parse(Session["RubroBarraAdicionales"].ToString());
            }
            set
            {
                Session["RubroBarraAdicionales"] = value;
            }
        }

        private int RubroTecnica
        {
            get
            {
                return Int32.Parse(Session["RubroTecnicaAdicionales"].ToString());
            }
            set
            {
                Session["RubroTecnicaAdicionales"] = value;
            }
        }

        private int RubroAmbientacion
        {
            get
            {
                return Int32.Parse(Session["RubroAmbientacionAdicionales"].ToString());
            }
            set
            {
                Session["RubroAmbientacionAdicionales"] = value;
            }
        }

        private int RubroOrganizacion
        {
            get
            {
                return Int32.Parse(Session["RubroOrganizacionAdicionales"].ToString());
            }
            set
            {
                Session["RubroOrganizacionAdicionales"] = value;
            }
        }

        private int RubroAdicional
        {
            get
            {
                return Int32.Parse(Session["RubroAdicionalAdicionales"].ToString());
            }
            set
            {
                Session["RubroAdicionalAdicionales"] = value;
            }
        }

        private int RubroAjustes
        {
            get
            {
                return Int32.Parse(Session["RubroAjustesAdicionales"].ToString());
            }
            set
            {
                Session["RubroAjustesAdicionales"] = value;
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

        private int SectorId
        {
            get
            {
                return Int32.Parse(Session["SectorIdAdicionales"].ToString());
            }
            set
            {
                Session["SectorIdAdicionales"] = value;
            }
        }

        private int LocacionId
        {
            get
            {
                return Int32.Parse(Session["LocacionIdVer"].ToString());
            }
            set
            {
                Session["LocacionIdVer"] = value;
            }
        }

        private int SegmentosId
        {
            get
            {
                return Int32.Parse(Session["SegmentosIdAdicionales"].ToString());
            }
            set
            {
                Session["SegmentosIdAdicionales"] = value;
            }
        }

        private int CaracteristicasId
        {
            get
            {
                return Int32.Parse(Session["CaracteristicasIdAdicionales"].ToString());
            }
            set
            {
                Session["CaracteristicasIdAdicionales"] = value;
            }
        }

        private int JornadaId
        {
            get
            {
                return Int32.Parse(Session["JornadaIdAdicionales"].ToString());
            }
            set
            {
                Session["JornadaIdAdicionales"] = value;
            }
        }

        private int TipoEventoId
        {
            get
            {
                return Int32.Parse(Session["TipoEventoIdAdicionales"].ToString());
            }
            set
            {
                Session["TipoEventoIdAdicionales"] = value;
            }
        }

        private int DuracionId
        {
            get
            {
                return Int32.Parse(Session["DuracionIdAdicionales"].ToString());
            }
            set
            {
                Session["DuracionIdAdicionales"] = value;
            }
        }

        private int MomentoDiaId
        {
            get
            {
                return Int32.Parse(Session["MomentoDiaIdAdicionales"].ToString());
            }
            set
            {
                Session["MomentoDiaIdAdicionales"] = value;
            }
        }

        private int UnidadNegocioParaAdicional
        {
            get
            {
                return Int32.Parse(Session["UnidadNegocioParaAdicionalAA"].ToString());
            }
            set
            {
                Session["UnidadNegocioParaAdicionalAA"] = value;
            }
        }

        private string PrecioParaAdicional
        {
            get
            {
                return Session["PrecioParaAdicionalAA"].ToString();
            }
            set
            {
                Session["PrecioParaAdicionalAA"] = value;
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

        private double ValorPax
        {
            get
            {
                return double.Parse(Session["ValorPax"].ToString());
            }
            set
            {
                Session["ValorPax"] = value;
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

        private int CantidadTotalInvitados
        {
            get
            {
                return Int32.Parse(Session["CantidadTotalInvitadosAdicionales"].ToString());
            }
            set
            {
                Session["CantidadTotalInvitadosAdicionales"] = value;
            }
        }

        private int CantidadInvitadosLogistica
        {
            get
            {
                return Int32.Parse(Session["CantidadInvitadosLogisticaAdicionales"].ToString());
            }
            set
            {
                Session["CantidadInvitadosLogisticaAdicionales"] = value;
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

        private List<PresupuestoDetalle> ListPresupuestoDetalleCambios
        {
            get
            {
                return Session["ListPresupuestoDetalleCambios"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalleCambios"] = value;
            }
        }

        private List<PresupuestoDetalle> ListPresupuestoDetalleQuitados
        {
            get
            {
                return Session["ListPresupuestoDetalleQuitados"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalleQuitados"] = value;
            }
        }

        private List<PresupuestoDetalle> ListPresupuestoDetalleModificado
        {
            get
            {
                return Session["ListPresupuestoDetalleModificado"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalleModificado"] = value;
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

        private List<TipoCatering> ListTipoCatering
        {
            get
            {
                return Session["ListTipoCateringAdicionales"] as List<TipoCatering>;
            }
            set
            {
                Session["ListTipoCateringAdicionales"] = value;
            }
        }

        private List<TipoServicios> ListTipoServicios
        {
            get
            {
                return Session["ListTipoServiciosAdicionales"] as List<TipoServicios>;
            }
            set
            {
                Session["ListTipoServiciosAdicionales"] = value;
            }
        }

        private List<Categorias> ListCategorias
        {
            get
            {
                return Session["ListCategoriasAdicionales"] as List<Categorias>;
            }
            set
            {
                Session["ListCategoriasAdicionales"] = value;
            }
        }

        private double PorcentajeOrganizador
        {
            get
            {
                return double.Parse(Session["PorcentajeOrganizador"].ToString());
            }
            set
            {
                Session["PorcentajeOrganizador"] = value;
            }
        }

        private double ImporteOrganizador
        {
            get
            {
                return double.Parse(Session["ImporteOrganizador"].ToString());
            }
            set
            {
                Session["ImporteOrganizador"] = value;
            }
        }

        private PresupuestoPDF Presupuestos
        {
            get { return (PresupuestoPDF)HttpContext.Current.Session["PresupuestoCliente"]; }
            set { HttpContext.Current.Session["PresupuestoCliente"] = value; }
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

        AdministrativasServicios administrativas = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        ClientesServicios clientes = new ClientesServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListPresupuestos = new List<ObtenerEventosPresupuestos>();

                ListPresupuestoDetalle = new List<PresupuestoDetalle>();
                ListPresupuestoDetalleCambios = new List<PresupuestoDetalle>();
                ListPresupuestoDetalleQuitados = new List<PresupuestoDetalle>();
                ListPresupuestoDetalleModificado = new List<PresupuestoDetalle>();


                RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
                RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
                RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
                RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
                RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

                RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
                RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());
                RubroAjustes = Int32.Parse(ConfigurationManager.AppSettings["RubroAjustes"].ToString());

                CargarListas();

                InicializarPagina();

                PanelAdicionales.Visible = false;
                PanelVisorPDF.Visible = false;
                PanelPendientePDF.Visible = false;

                LabelCantidadItemsOrganizacion.Visible = false;
                LabelLogistica.Visible = false;

                TextBoxCantidadItemsOrganizacion.Visible = false;
                TextBoxCostoLogistica.Visible = false;

                LabelTipoLogistica.Visible = false;
                LabelLocalidadLogistica.Visible = false;

                DropDownListConceptoLogistica.Visible = false;
                DropDownListLocalidadesLogisitca.Visible = false;

                PanelAmbientacionCorporativoInformal.Visible = false;
            }
        }

        private void CargarListas()
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["AmbientacionCIActivo"].ToString());

            ListLocaciones = eventos.ObtenerLocacionesParaCotizar();


            List<UnidadesNegocios> ListUN = new List<UnidadesNegocios>();

            foreach (var item in ListPresupuestoDetalle)
            {
                UnidadesNegocios un = administrativas.BuscarUnidadNegocio(item.UnidadNegocioId);


                ListUN.Add(un);
            }

            DropDownListUnidadNegocio.DataSource = administrativas.ObtenerUNCotizador(ListUN);
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();

            DropDownListConceptoLogistica.DataSource = administrativas.ObtenerTipoLogistica();
            DropDownListConceptoLogistica.DataTextField = "Concepto";
            DropDownListConceptoLogistica.DataValueField = "Id";
            DropDownListConceptoLogistica.DataBind();

            DropDownListLocalidadesLogisitca.DataSource = administrativas.ObtenerLocalidades();
            DropDownListLocalidadesLogisitca.DataTextField = "Descripcion";
            DropDownListLocalidadesLogisitca.DataValueField = "Id";
            DropDownListLocalidadesLogisitca.DataBind();


            DropDownListCIItemsAmbientacion.DataSource = administrativas.ObtenerAmbientacionesCI().Where(o => o.EstadoId == activo).ToList();
            DropDownListCIItemsAmbientacion.DataTextField = "Descripcion";
            DropDownListCIItemsAmbientacion.DataValueField = "Id";
            DropDownListCIItemsAmbientacion.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            double importeOrganizador = 0;
            double porcentajeOrganizador = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
            }


            CargarEvento();

            CargarPresupuesto(ref importeOrganizador, ref porcentajeOrganizador);

            ListPresupuestoDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);

            if (ListPresupuestoDetalle.Count > 0)
            {
                GridViewVentas.DataSource = ListPresupuestoDetalle.OrderBy(o => o.FechaAprobacion).ToList();
                GridViewVentas.DataBind();
            }
        }

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {

            CantidadTotalParaCotizar = cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes);
            CantidadTotalInvitados = Convert.ToInt32(CantidadTotalParaCotizar);
        }

        private void CargarListasAmbientacion()
        {
            List<Categorias> categoriasAmbientacion = administrativas.BuscarCategoriasPorLocacionCaracteristicaSegmento(LocacionId, CaracteristicasId, SegmentosId, SectorId);

            ListCategorias = categoriasAmbientacion.ToList();

            if (DropDownListUnidadNegocio.SelectedItem != null && DropDownListProveedor.SelectedItem != null) CargarServicios();

            UpdatePanelCotizador.Update();


        }

        private void CargarEvento()
        {

            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = eventos.BuscarEvento(EventoId);

            LabelNroEvent.Text = EventoSeleccionado.Id.ToString().PadLeft(8, '0');

            ClienteId = (int)EventoSeleccionado.ClienteBisId;

            LabelCLiente.Text = clientes.BuscarCliente(ClienteId).ApellidoNombre.ToUpper();

            TextBoxComentarioEvento.Text = EventoSeleccionado.Comentario;

        }

        private void CargarPresupuesto(ref double importeOrganizador, ref double porcentajeOrganizador)
        {
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);


                LabelNroPresup.Text = PresupuestoSeleccionado.Id.ToString().PadLeft(8, '0');

                TextBoxCantMayores.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) TextBoxCantAdolescentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) TextBoxCantMenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) TextBoxCantEntre3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();

                if (PresupuestoSeleccionado.CantidadAdultosFinal != null) TextBoxCantMayoresFinal.Text = PresupuestoSeleccionado.CantidadAdultosFinal.ToString();
                if (PresupuestoSeleccionado.CantidadAdolescentesFinal != null) TextBoxCantAdolescentesFinal.Text = PresupuestoSeleccionado.CantidadAdolescentesFinal.ToString();
                if (PresupuestoSeleccionado.CantidadMenoresEntre3y8Final != null) TextBoxCantEntre3y8Final.Text = PresupuestoSeleccionado.CantidadMenoresEntre3y8Final.ToString();
                if (PresupuestoSeleccionado.CantidadMenores3Final != null) TextBoxCantMenores3Final.Text = PresupuestoSeleccionado.CantidadMenores3Final.ToString();


                int CantidadesFinales = Int32.Parse((
                    (PresupuestoSeleccionado.CantidadAdultosFinal == null ? 0 : PresupuestoSeleccionado.CantidadAdultosFinal) +
                    (PresupuestoSeleccionado.CantidadAdolescentesFinal == null ? 0 : PresupuestoSeleccionado.CantidadAdolescentesFinal) +
                    (PresupuestoSeleccionado.CantidadMenoresEntre3y8Final == null ? 0 : PresupuestoSeleccionado.CantidadMenoresEntre3y8Final) +
                    (PresupuestoSeleccionado.CantidadMenores3Final == null ? 0 : PresupuestoSeleccionado.CantidadMenores3Final)
                    ).ToString());

                if (CantidadesFinales > 0)
                    ButtonAgregarInvitados.Visible = false;
                else
                    ButtonAgregarInvitados.Visible = true;


                TextBoxFechaDesdeEvento.Text = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);


                double Valor = presupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

                LabelCaracteristica.Text = eventos.TraerCaracteristicas().Where(o => o.Id == PresupuestoSeleccionado.CaracteristicaId).Select(o => o.Descripcion).SingleOrDefault();
                LabelSegmentos.Text = eventos.TraerSegmentos().Where(o => o.Id == PresupuestoSeleccionado.SegmentoId).Select(o => o.Descripcion).SingleOrDefault();
                LabelTipoEvento.Text = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();
                LabelJornada.Text = eventos.TraerJornadas().Where(o => o.Id == PresupuestoSeleccionado.JornadaId).Select(o => o.Descripcion).SingleOrDefault();
                LabelMomentodelDia.Text = administrativas.ObtenerMomentosDias().Where(o => o.Id == PresupuestoSeleccionado.MomentoDiaID).Select(o => o.Descripcion).SingleOrDefault();
                LabelDuraciondelEvento.Text = administrativas.ObtenerDuracionEvento().Where(o => o.Id == PresupuestoSeleccionado.DuracionId).Select(o => o.Descripcion).SingleOrDefault();


                CaracteristicasId = PresupuestoSeleccionado.CaracteristicaId;
                SegmentosId = PresupuestoSeleccionado.SegmentoId;
                TipoEventoId = PresupuestoSeleccionado.TipoEventoId;
                JornadaId = (int)PresupuestoSeleccionado.JornadaId;
                LocacionId = PresupuestoSeleccionado.LocacionId;
                MomentoDiaId = (int)PresupuestoSeleccionado.MomentoDiaID;
                DuracionId = (int)PresupuestoSeleccionado.DuracionId;

                if (PresupuestoSeleccionado.SectorId != null)
                    SectorId = (int)PresupuestoSeleccionado.SectorId;
                else
                    SectorId = new Int32();

                LabelHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;
                LabelHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;

                Locaciones loc = ListLocaciones.Where(o => o.Id == LocacionId).SingleOrDefault();

                TextBoxComentarioPresupuesto.Text = PresupuestoSeleccionado.Comentario;

                LabelLocaciones.Text = eventos.TraerLocaciones().Where(o => o.Id == PresupuestoSeleccionado.LocacionId).Select(o => o.Descripcion).SingleOrDefault();

                if (PresupuestoSeleccionado.SectorId != null)
                {
                    LabelSector.Text = administrativas.BuscarSector((int)PresupuestoSeleccionado.SectorId).Descripcion;
                }

                if (PresupuestoSeleccionado.ImporteOrganizador != null)
                    ImporteOrganizador = double.Parse(PresupuestoSeleccionado.ImporteOrganizador.ToString());
                else
                    ImporteOrganizador = 0;

                if (PresupuestoSeleccionado.PorcentajeOrganizador != null)
                    PorcentajeOrganizador = double.Parse(PresupuestoSeleccionado.PorcentajeOrganizador.ToString());
                else
                    PorcentajeOrganizador = 0;

                CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);

                TextBoxTotalPresupuesto.Text = System.Math.Round(Valor, 2).ToString("C");

                TextBoxTotalPAX.Text = System.Math.Round((Valor / CantidadTotalInvitados), 2).ToString("C");

                ValorPax = System.Math.Round((Valor / CantidadTotalInvitados), 2);

                TextBoxTotalPorcOrganizador.Text = PresupuestoSeleccionado.ValorOrganizador.ToString();

                CargarListasTipoCateringTipoTecnica();

                CargarListasAmbientacion();

            }

            //ObtenerEventosPresupuestos ListPresupuesto = eventos.BuscarPresupuestoParaAprobar(PresupuestoId);

            //if (ListPresupuesto.ImporteOrganizador != null)
            //    importeOrganizador = importeOrganizador + double.Parse(ListPresupuesto.ImporteOrganizador.ToString());


            //if (ListPresupuesto.PorcentajeOrganizador != null)
            //    porcentajeOrganizador = porcentajeOrganizador + double.Parse(ListPresupuesto.PorcentajeOrganizador.ToString());


            //ListPresupuestos.Add(ListPresupuesto);

            //ImporteOrganizador = importeOrganizador;
            //PorcentajeOrganizador = porcentajeOrganizador;




            //if (ListPresupuestos.Count > 0)
            //{

            //    var cantidadinvitados = (from c in ListPresupuestos
            //                             select c.CantidadInicialInvitados +
            //                                (c.CantidadInvitadosAdolecentes == null ? 0 : c.CantidadInvitadosAdolecentes) +
            //                                (c.CantidadInvitadosMenores3 == null ? 0 : c.CantidadInvitadosMenores3) +
            //                                (c.CantidadInvitadosMenores3y8 == null ? 0 : c.CantidadInvitadosMenores3y8)).Sum();


            //    CantidadTotalInvitados = Int32.Parse(cantidadinvitados.ToString());

            //    GridViewPresupuestos.DataSource = ListPresupuestos.ToList();
            //    GridViewPresupuestos.DataBind();

            //}
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void GridViewVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int UnidadNegocioId;
            int ProveedorId;

            int RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            int RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());


            if (e.CommandName == "CargarAdicionales")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];



                UnidadNegocioId = int.Parse(row.Cells[14].Text);

                UnidadNegocioParaAdicional = UnidadNegocioId;

                PrecioParaAdicional = row.Cells[3].Text;


                List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = new List<ObtenerAdicionales>();

                if (UnidadNegocioId == RubroSalon)
                {
                    Adicionales = administrativas.ObtenerAdicionalesPorLocacionesUnidadNegocio(LocacionId);
                }
                else if (UnidadNegocioId == RubroCatering)
                {

                    int ProductoId = int.Parse(row.Cells[1].Text);

                    int TipoCateringId = (int)administrativas.BuscarProducto(ProductoId).TipoCateringId;

                    ProveedorId = int.Parse(row.Cells[13].Text);


                    Adicionales = administrativas.ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(ProveedorId, UnidadNegocioId, TipoCateringId);
                }
                else
                {
                    ProveedorId = int.Parse(row.Cells[13].Text);

                    Adicionales = administrativas.ObtenerAdicionalesPorProveedoryUnidadNegocio(ProveedorId, UnidadNegocioId);

                }


                if (Adicionales.Count > 0)
                {
                    DropDownListAdicionales.Items.Clear();
                    DropDownListAdicionales.DataSource = Adicionales.ToList();
                    DropDownListAdicionales.DataTextField = "Descripcion";
                    DropDownListAdicionales.DataValueField = "Id";
                    DropDownListAdicionales.DataBind();


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
            else if (e.CommandName == "QuitarItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = new DomainAmbientHouse.Entidades.PresupuestoDetalle();


                detalle.Id = Int32.Parse(row.Cells[15].Text);


                var itemRemove = ListPresupuestoDetalle.Where(o => o.Id == detalle.Id).Single();

                ListPresupuestoDetalleQuitados.Add(itemRemove);

                ListPresupuestoDetalle.Remove(itemRemove);

                if (itemRemove.UnidadNegocioId == 10)
                {
                    if (presupuestos.EliminarInvitadosPendientes((int)itemRemove.PresupuestoId))
                    {
                        TextBoxCantAdolescentesFinal.Text = "";
                        TextBoxCantEntre3y8Final.Text = "";
                        TextBoxCantMayoresFinal.Text = "";
                        TextBoxCantMenores3Final.Text = "";

                        PresupuestoSeleccionado.CantidadAdolescentesFinal = null;
                        PresupuestoSeleccionado.CantidadAdultosFinal = null;
                        PresupuestoSeleccionado.CantidadMenores3Final = null;
                        PresupuestoSeleccionado.CantidadMenoresEntre3y8Final = null;

                        ButtonAgregarInvitados.Visible = true;

                    }
                }

                GuardarEvento();

                GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                GridViewVentas.DataBind();

                TextBoxTotalPresupuesto.Text = ListPresupuestoDetalle.Sum(o => o.ValorSeleccionado).ToString();

                TextBoxTotalPAX.Text = (double.Parse(TextBoxTotalPresupuesto.Text) / CantidadTotalInvitados).ToString();

                double TotalPresupuesto = 0;

                TotalPresupuesto = cmd.CalcularTotalPresupuesto(ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);

                TextBoxTotalPresupuesto.Text = System.Math.Round(TotalPresupuesto, 2).ToString("C");


                TextBoxCantidadAdicional.Text = "";
                UpdatePanelCotizador.Update();

            }
            else if (e.CommandName == "AprobarItem")
            {
                Mail mailAprobacion = new Mail();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                int detalleId = Int32.Parse(row.Cells[15].Text);

                DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = presupuestos.AprobarItemPresupuesto(detalleId);

                mailAprobacion.envioMailCambiosEventoGanado(PresupuestoId, EventoId, row.Cells[2].Text);

                ListPresupuestoDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);

                GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                GridViewVentas.DataBind();

                TextBoxTotalPresupuesto.Text = ListPresupuestoDetalle.Sum(o => o.ValorSeleccionado).ToString();

                TextBoxTotalPAX.Text = (double.Parse(TextBoxTotalPresupuesto.Text) / CantidadTotalInvitados).ToString();

                double TotalPresupuesto = 0;

                TotalPresupuesto = cmd.CalcularTotalPresupuesto(ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);

                TextBoxTotalPresupuesto.Text = System.Math.Round(TotalPresupuesto, 2).ToString("C");

                InicializarPagina();
                UpdatePanelCotizador.Update();

            }


        }

        protected void DropDownListAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListAdicionales.SelectedItem != null)
            {
                Adicionales adicional = eventos.BuscarAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));

                if (adicional.RequiereCantidad == "S")
                {
                    LabelCantidadAdicional.Visible = true;
                    TextBoxCantidadAdicional.Visible = true;
                }
            }
        }

        //protected void ButtonAgregarAdicional_Click(object sender, EventArgs e)
        //{
        //    int PresupuestoDetallePendiente = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());
        //    int RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

        //    string CodigoAdicional = cmd.ArmarCodigoAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value), CantidadTotalInvitados);


        //    Comisiones com = administrativas.BuscarComisionPorUnidadNegocioPrecioSeleccionado(UnidadNegocioParaAdicional, PrecioParaAdicional);

        //    double porcentaje = (com.PorcentajeAdicional == null ? 0 : double.Parse(com.PorcentajeAdicional.ToString()));


        //    Productos producto = administrativas.BuscarProductosPorCodigo(CodigoAdicional);

        //    if (producto != null)
        //    {
        //        PresupuestoDetalle presu = new PresupuestoDetalle();

        //        double Total = 0; // producto.Precio * double.Parse(DropDownListPrecios.SelectedItem.Value.ToString()) * CantidadTotalInvitados;
        //        double Costo = 0;


        //        var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ServicioId == producto.Id).SingleOrDefault();

        //        if (ItemRepetido == null)
        //        {


        //            Adicionales adi = eventos.BuscarAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value.ToString()));


        //            presu.UnidadNegocioId = RubroAdicional;
        //            presu.ServicioId = Int32.Parse(DropDownListAdicionales.SelectedItem.Value.ToString());
        //            presu.ProveedorId = producto.ProveedorId;
        //            presu.PrecioItem = producto.Precio;

        //            if (adi.RequiereCantidad == "S")
        //            {
        //                if (TextBoxCantidadAdicional.Text != "" && cmd.IsNumeric(TextBoxCantidadAdicional.Text))
        //                {
        //                    Total = (producto.Precio * Int32.Parse(TextBoxCantidadAdicional.Text));
        //                    Costo = (producto.Costo * Int32.Parse(TextBoxCantidadAdicional.Text));
        //                }
        //                else
        //                {
        //                    Total = (producto.Precio * 1);
        //                    Costo = (producto.Costo * 1);
        //                }
        //            }
        //            else
        //            {
        //                Total = (producto.Precio * CantidadTotalInvitados);
        //                Costo = (producto.Costo * CantidadTotalInvitados);
        //            }

        //            CalcularValorIntermediario(presu, Total, RubroAdicional);


        //            presu.ValorSeleccionado = System.Math.Round(Total + (presu.ValorIntermediario == null ? 0 : double.Parse(presu.ValorIntermediario.ToString())), 2);


        //            presu.ProductoId = producto.Id;

        //            presu.ProductoDescripcion = producto.Descripcion;
        //            presu.CantidadAdicional = (TextBoxCantidadAdicional.Text == "" ? 1 : Int32.Parse(TextBoxCantidadAdicional.Text));
        //            presu.PrecioSeleccionado = "";
        //            presu.CodigoItem = producto.Codigo;
        //            presu.Costo = Costo + (presu.ValorIntermediario == null ? 0 : double.Parse(presu.ValorIntermediario.ToString()));
        //            presu.Comision = System.Math.Round(Total * (porcentaje / 100), 2);
        //            presu.PorcentajeComision = porcentaje;

        //            presu.PrecioMas5 = Total * double.Parse("1.05");
        //            presu.PrecioLista = Total;
        //            presu.PrecioMenos5 = Total * double.Parse("0.95");
        //            presu.PrecioMenos10 = Total * double.Parse("0.90");

        //            presu.EstadoId = PresupuestoDetallePendiente;
        //            presu.FechaAprobacion = System.DateTime.Now;

        //            ListPresupuestoDetalle.Add(presu);
        //        }
        //    }
        //    else
        //    {
        //        LabelMensajeAdicionales.Visible = true;
        //        LabelMensajeAdicionales.Text = "No Existe el Item creado para poder Cotizar.";
        //    }



        //    GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
        //    GridViewVentas.DataBind();

        //    double TotalPresupuesto = 0;

        //    TotalPresupuesto = cmd.CalcularTotalPresupuesto(ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);

        //    TextBoxTotalPresupuesto.Text = System.Math.Round(TotalPresupuesto, 2).ToString("C");

        //    TextBoxTotalPAX.Text = System.Math.Round((TotalPresupuesto / CantidadTotalInvitados), 2).ToString("C");
        //}

        protected void GridViewVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button presupuestarAdicionales = (Button)e.Row.FindControl("ButtonPresupuestarAdicionales");

                Button quitarAdicionales = (Button)e.Row.FindControl("ButtonQuitarItem");

                DropDownList precios = (DropDownList)e.Row.FindControl("DropDownListPreciosItem");

                Button aprobarItem = (Button)e.Row.FindControl("ButtonAprobarItem");


                quitarAdicionales.Visible = false;
                aprobarItem.Visible = false;

                if (e.Row.Cells[16].Text == "Pendiente")
                {

                    presupuestarAdicionales.Visible = false;
                    quitarAdicionales.Visible = true;
                    aprobarItem.Visible = true;

                }
                //else if ((e.Row.Cells[13].Text == "10") && (e.Row.Cells[15].Text == "Pendiente"))
                //{
                //    presupuestarAdicionales.Visible = false;
                //    quitarAdicionales.Visible = true;
                //    aprobarItem.Visible = true;
                //}
                else if ((e.Row.Cells[14].Text == "10") && (e.Row.Cells[15].Text == "Aprobado"))
                {
                    presupuestarAdicionales.Visible = false;

                }
                else if ((e.Row.Cells[14].Text == "10"))
                {
                    presupuestarAdicionales.Visible = false;

                }
                else if ((e.Row.Cells[14].Text == "9"))
                {
                    presupuestarAdicionales.Visible = false;

                }


            }
        }

        protected void ButtonGuardarCambios_Click(object sender, EventArgs e)
        {
            //Mail mailAprobacion = new Mail();

            //int estadoAprobadoItem = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            //eventos.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle, estadoAprobadoItem, System.DateTime.Today);

            //string Mensaje = "El Presupuesto: <b>" + PresupuestoSeleccionado.Id.ToString() +
            //                 "</b> sufrio modificaciones." +
            //                 " Nro. Evento: <b>" + EventoSeleccionado.Id.ToString() + "</b></br>" +
            //                 " Cliente: <b>" + LabelCLiente.Text + "</b></br>" +
            //                 " Ejecutivo: <b>" + ValidarEjecutivo(EventoSeleccionado.EmpleadoId) + "</b></br>" +
            //                 " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento) + "</b></br>" +
            //                 " Locacion: <b>" + ValidarLocacion(PresupuestoSeleccionado.LocacionId) + "</b></br>" +
            //                 " Tipo Evento: <b>" + ValidarTipoCatering(PresupuestoSeleccionado.TipoEventoId) + "</b></br>" +
            //                 " Cantidad Invitados: <b>" + CantidadTotalInvitados.ToString() + "</b></br>" +
            //                 " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

            //mailAprobacion.envioMailCambiosEventoGanado(Mensaje);

            Presupuestos = new PresupuestoPDF();

            Presupuestos = presupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

            PanelPendientePDF.Visible = false;
            PanelVisorPDF.Visible = true;
            PanelCotixador.Visible = false;
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void DropDownListUnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            PanelAmbientacionCorporativoInformal.Visible = false;

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

                    List<Proveedores> Prov = eventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedor.Items.Clear();
                    DropDownListProveedor.AppendDataBoundItems = true;
                    DropDownListProveedor.DataSource = Prov.ToList();
                    DropDownListProveedor.DataTextField = "RazonSocial";
                    DropDownListProveedor.DataValueField = "Id";
                    DropDownListProveedor.DataBind();


                    if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroCatering)
                    {

                        CalcularCantidadinvitadosLogistica();

                        CargarServicios();

                        HabilitarLogisticaCannon(true);

                        TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                                       Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value), CantidadInvitadosLogistica).ToString();


                    }

                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroBarra)
                    {

                        CalcularCantidadinvitadosLogistica();

                        CargarServicios();

                        HabilitarLogisticaCannon(true);

                        TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                                                               Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value), CantidadInvitadosLogistica).ToString();

                    }

                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroTecnica)
                    {
                        //ObtenerTecnicaSalon();

                        CargarServicios();

                        HabilitarLogisticaCannon(false);
                    }
                    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroAmbientacion)
                    {
                        //ObtenerAmbientacionSalon();
                        if (CaracteristicasId == caracteristicaId && SegmentosId == segmentoId)
                        {
                            PanelAmbientacionCorporativoInformal.Visible = true;
                            DropDownListServicio.Visible = false;
                        }
                        else
                        {
                            PanelAmbientacionCorporativoInformal.Visible = false;
                            DropDownListServicio.Visible = true;
                        }


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
                DropDownListServicio.DataSource = eventos.BuscarTipoBarrasPorSegmento(SegmentosId, DuracionId);
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();

            }
            else if (unidadNegocio == RubroAdicional)
            {
                int Proveedor = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

                List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = administrativas.ObtenerAdicionalesPorProveedor(Proveedor);


                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = Adicionales.ToList();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();

            }
            else if (unidadNegocio == RubroAmbientacion)
            {
                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = ListCategorias.ToList();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();
            }
            else if (unidadNegocio == RubroOrganizacion)
            {
                DropDownListServicio.Items.Clear();
                DropDownListServicio.DataSource = administrativas.ObtenerItemsOrganizacion();
                DropDownListServicio.DataTextField = "Descripcion";
                DropDownListServicio.DataValueField = "Id";
                DropDownListServicio.DataBind();
            }

            UpdatePanelCotizador.Update();
        }

        private int CalcularCantidadinvitadosLogistica()
        {
            CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);

            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, CantidadTotalInvitados);


            CantidadInvitadosLogistica = cantInvitadosCosto;
            return cantInvitadosCosto;
        }

        private void CargarListasTipoCateringTipoTecnica()
        {
            List<TipoCatering> tc = eventos.TraerTipoCatering(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);


            ListTipoCatering = tc.ToList();



            List<TipoServicios> Tt = eventos.TraerTipoServicios(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);


            ListTipoServicios = Tt.ToList();

            if (DropDownListUnidadNegocio.SelectedItem != null && DropDownListProveedor.SelectedItem != null) CargarServicios();

            UpdatePanelCotizador.Update();

        }

        private void HabilitarLogisticaCannon(bool habilitar)
        {
            LabelTipoLogistica.Visible = habilitar;
            DropDownListConceptoLogistica.Visible = habilitar;

            LabelLocalidadLogistica.Visible = habilitar;
            DropDownListLocalidadesLogisitca.Visible = habilitar;

            TextBoxCostoLogistica.Visible = habilitar;
            TextBoxCostoLogistica.Text = "0";

            LabelLogistica.Visible = habilitar;
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

        protected void DropDownListServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarServicios();
        }

        protected void DropDownListConceptoLogistica_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                           Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
        }

        protected void DropDownListLocalidadesLogisitca_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCostoLogistica.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value),
                                              Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value), CantidadInvitadosLogistica).ToString();
        }

        //protected void ButtonAgregarItem_Click(object sender, EventArgs e)
        //{



        //    int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

        //    int LocacionLahusen = Int32.Parse(ConfigurationManager.AppSettings["Lahusen"].ToString());

        //    int ProveedorCateringAmbient = Int32.Parse(ConfigurationManager.AppSettings["ProveedorCateringAmbient"].ToString());

        //    LabelErrores.Visible = false;

        //    CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);

        //    DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


        //    if (Validar())
        //    {

        //        int unidadNegocioSeleccionada = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString());

        //        if (unidadNegocioSeleccionada == RubroCatering)
        //        {
        //            string Codigo = cmd.ArmarCodigoCatering(Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), CantidadTotalInvitados);

        //            Productos producto = administrativas.BuscarProductosPorCodigo(Codigo, fechaSeleccionada);

        //            if (producto != null)
        //            {
        //                PresupuestoDetalle presu = new PresupuestoDetalle();

        //                double TotalCatering = 0;// producto.Precio * double.Parse(DropDownListPrecios.SelectedItem.Value.ToString()) * CantidadTotalInvitados;
        //                double porcentajeCatering = 0;

        //                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id).SingleOrDefault();



        //                if (ItemRepetido == null)
        //                {
        //                    presu.UnidadNegocioId = unidadNegocioSeleccionada;
        //                    presu.ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value.ToString());


        //                    TotalCatering = CalcularPrecioVenta(DropDownListPrecios, producto, TotalCatering) * CantidadTotalParaCotizar;

        //                    List<Comisiones> comisiones = administrativas.ObtenerComisiones();

        //                    porcentajeCatering = GenerarComision(DropDownListPrecios.SelectedItem.Text, TotalCatering, porcentajeCatering, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");

        //                    PorcentajeVendidoCatering = PorcentajeAdicional(DropDownListPrecios.SelectedItem.Text, PorcentajeVendidoCatering, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");

        //                    presu.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value.ToString());
        //                    presu.PrecioItem = TotalCatering;
        //                    presu.ProductoId = producto.Id;

        //                    CalcularValorIntermediario(presu, TotalCatering, RubroCatering);

        //                    presu.ProductoDescripcion = producto.Descripcion;
        //                    presu.TipoLogisticaId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());
        //                    presu.LocalidadId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());
        //                    presu.CantInvitadosLogistica = CantidadInvitadosLogistica; //Int32.Parse(DropDownListCantInvitadosLogisitca.SelectedItem.Value.ToString());
        //                    presu.Logistica = Int32.Parse(TextBoxCostoLogistica.Text);


        //                    //presu.Cannon = Int32.Parse(TextBoxCostoCannonCatering.Text) * CantidadTotalInvitados;
        //                    if (LocacionId == LocacionLahusen && Int32.Parse(DropDownListProveedor.SelectedItem.Value.ToString()) == ProveedorCateringAmbient)
        //                        presu.Cannon = ObtenerCostoCanon(SegmentosId, CaracteristicasId, Int32.Parse(DropDownListServicio.SelectedItem.Value.ToString())) * CantidadTotalInvitados;
        //                    else
        //                        presu.Cannon = ObtenerCostoCanon(TotalCatering);

        //                    presu.ValorSeleccionado = System.Math.Round(TotalCatering, 2);


        //                    presu.PrecioSeleccionado = DropDownListPrecios.SelectedItem.Text;
        //                    presu.CodigoItem = producto.Codigo;
        //                    presu.Costo = producto.Costo * CantidadTotalInvitados;
        //                    presu.Comision = System.Math.Round(porcentajeCatering, 2);
        //                    presu.PorcentajeComision = PorcentajeVendidoCatering;

        //                    presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5") * CantidadTotalInvitados;
        //                    presu.PrecioLista = CalcularPrecios(producto, "PL") * CantidadTotalInvitados;
        //                    presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5") * CantidadTotalInvitados;
        //                    presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10") * CantidadTotalInvitados;

        //                    presu.EstadoId = PresupuestoDetalleAprobado;

        //                    ListPresupuestoDetalle.Add(presu);
        //                }

        //            }

        //            else
        //            {
        //                LabelErrores.Visible = true;
        //                LabelErrores.Text = "No Existe el Item creado para poder Cotizar.";
        //            }
        //        }
        //        else if (unidadNegocioSeleccionada == RubroTecnica)
        //        {
        //            string CodigoTecnica = cmd.ArmarCodigoTecnica(TextBoxFechaDesdeEvento.Text, Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), SegmentosId, SectorId);

        //            Productos producto = administrativas.BuscarProductosPorCodigo(CodigoTecnica, fechaSeleccionada);

        //            if (producto != null)
        //            {
        //                PresupuestoDetalle presu = new PresupuestoDetalle();

        //                double Total = 0; //producto.Precio * double.Parse(DropDownListPrecios.SelectedItem.Value.ToString());
        //                double porcentajeTecnica = 0;


        //                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id).SingleOrDefault();

        //                if (ItemRepetido == null)
        //                {
        //                    presu.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString());
        //                    presu.ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value.ToString());

        //                    Total = CalcularPrecioVenta(DropDownListPrecios, producto, Total);

        //                    List<Comisiones> comisiones = administrativas.ObtenerComisiones();

        //                    porcentajeTecnica = GenerarComision(DropDownListPrecios.SelectedItem.Text, Total, porcentajeTecnica, comisiones, "ComisionTecnicaPL+5", "ComisionTecnicaPL", "ComisionTecnicaPL-5", "ComisionTecnicaPL-10");

        //                    PorcentajeVendidoTecnica = PorcentajeAdicional(DropDownListPrecios.SelectedItem.Text, PorcentajeVendidoTecnica, comisiones, "ComisionTecnicaPL+5", "ComisionTecnicaPL", "ComisionTecnicaPL-5", "ComisionTecnicaPL-10");

        //                    presu.PrecioItem = Total;

        //                    presu.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value.ToString());
        //                    presu.PrecioItem = Total;
        //                    presu.ProductoId = producto.Id;

        //                    CalcularValorIntermediario(presu, Total, RubroTecnica);


        //                    presu.ValorSeleccionado = System.Math.Round(Total + (presu.ValorIntermediario == null ? 0 : double.Parse(presu.ValorIntermediario.ToString())), 2);

        //                    presu.ProductoDescripcion = producto.Descripcion;

        //                    presu.PrecioSeleccionado = DropDownListPrecios.SelectedItem.Text;
        //                    presu.CodigoItem = producto.Codigo;
        //                    presu.Costo = producto.Costo;

        //                    if (Comisiona == "S")
        //                    {
        //                        presu.Comision = System.Math.Round(porcentajeTecnica, 2);
        //                        presu.PorcentajeComision = PorcentajeVendidoTecnica;
        //                    }
        //                    else
        //                    {
        //                        presu.Comision = 0;
        //                        presu.PorcentajeComision = 0;
        //                    }


        //                    presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5");
        //                    presu.PrecioLista = CalcularPrecios(producto, "PL");
        //                    presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5");
        //                    presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10");

        //                    presu.EstadoId = PresupuestoDetalleAprobado;

        //                    ListPresupuestoDetalle.Add(presu);
        //                }
        //            }
        //            else
        //            {
        //                LabelErrores.Visible = true;
        //                LabelErrores.Text = "No Existe el Item creado para poder Cotizar.";
        //            }
        //        }
        //        else if (unidadNegocioSeleccionada == RubroBarra)
        //        {
        //            string CodigoSalon = cmd.ArmarCodigoBarra(Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), CantidadTotalInvitados);

        //            Productos producto = administrativas.BuscarProductosPorCodigo(CodigoSalon, fechaSeleccionada);

        //            TiposBarras tb = administrativas.BuscarTipoBarras(Int32.Parse(DropDownListServicio.SelectedItem.Value));


        //            if (producto != null)
        //            {
        //                PresupuestoDetalle presu = new PresupuestoDetalle();

        //                double TotalBarra = 0;// producto.Precio * double.Parse(DropDownListPrecios.SelectedItem.Value.ToString()) * CantidadTotalInvitados;
        //                double porcentajeBarra = 0;


        //                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id).SingleOrDefault();


        //                int CantItem = ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroBarra).Count();

        //                if (CantItem <= 2)
        //                {

        //                    if (ItemRepetido == null)
        //                    {

        //                        presu.UnidadNegocioId = unidadNegocioSeleccionada;
        //                        presu.ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value.ToString());
        //                        presu.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value.ToString());




        //                        if (tb.RangoEtareo == "ADULTOS")
        //                        {
        //                            string CodigoBarraBIS = cmd.ArmarCodigoBarra(Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), Int32.Parse(TextBoxCantMayores.Text));

        //                            Productos productoBIS = administrativas.BuscarProductosPorCodigo(CodigoBarraBIS, fechaSeleccionada);

        //                            TotalBarra = CalcularPrecioVenta(DropDownListPrecios, productoBIS, TotalBarra) * Int32.Parse(TextBoxCantMayores.Text);
        //                            presu.CantidadAdicional = Int32.Parse(TextBoxCantMayores.Text);

        //                            presu.ProductoDescripcion = productoBIS.Descripcion;

        //                            presu.Costo = productoBIS.Costo * Int32.Parse(TextBoxCantMayores.Text);

        //                            presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5") * Int32.Parse(TextBoxCantMayores.Text);
        //                            presu.PrecioLista = CalcularPrecios(producto, "PL") * Int32.Parse(TextBoxCantMayores.Text);
        //                            presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5") * Int32.Parse(TextBoxCantMayores.Text);
        //                            presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10") * Int32.Parse(TextBoxCantMayores.Text);


        //                            producto = productoBIS;
        //                        }
        //                        else
        //                        {
        //                            if (CantItem < 1)
        //                            {
        //                                string CodigoBarraBIS = cmd.ArmarCodigoBarra(Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), CantidadTotalInvitados);

        //                                Productos productoBIS = administrativas.BuscarProductosPorCodigo(CodigoBarraBIS, fechaSeleccionada);

        //                                TotalBarra = CalcularPrecioVenta(DropDownListPrecios, productoBIS, TotalBarra) * CantidadTotalInvitados;
        //                                presu.CantidadAdicional = CantidadTotalInvitados;

        //                                presu.ProductoDescripcion = productoBIS.Descripcion;

        //                                presu.Costo = productoBIS.Costo * CantidadTotalInvitados;

        //                                presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5") * CantidadTotalInvitados;
        //                                presu.PrecioLista = CalcularPrecios(producto, "PL") * CantidadTotalInvitados;
        //                                presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5") * CantidadTotalInvitados;
        //                                presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10") * CantidadTotalInvitados;


        //                                producto = productoBIS;
        //                            }
        //                            else
        //                            {
        //                                string CodigoBarraBIS = cmd.ArmarCodigoBarra(Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text)));

        //                                Productos productoBIS = administrativas.BuscarProductosPorCodigo(CodigoBarraBIS, fechaSeleccionada);


        //                                TotalBarra = CalcularPrecioVenta(DropDownListPrecios, productoBIS, TotalBarra) * (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));
        //                                presu.CantidadAdicional = (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));

        //                                presu.ProductoDescripcion = productoBIS.Descripcion;

        //                                presu.Costo = productoBIS.Costo * (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));

        //                                presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5") * (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));
        //                                presu.PrecioLista = CalcularPrecios(producto, "PL") * (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));
        //                                presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5") * (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));
        //                                presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10") * (TextBoxCantAdolescentes.Text == "" ? 0 : Int32.Parse(TextBoxCantAdolescentes.Text));


        //                                producto = productoBIS;

        //                            }
        //                        }

        //                        presu.PrecioItem = TotalBarra;

        //                        List<Comisiones> comisiones = administrativas.ObtenerComisiones();

        //                        porcentajeBarra = GenerarComision(DropDownListPrecios.SelectedItem.Text, TotalBarra, porcentajeBarra, comisiones, "ComisionBarraPL+5", "ComisionBarraPL", "ComisionBarraPL-5", "ComisionBarraPL-10");

        //                        PorcentajeVendidoBarra = PorcentajeAdicional(DropDownListPrecios.SelectedItem.Text, PorcentajeVendidoBarra, comisiones, "ComisionBarraPL+5", "ComisionBarraPL", "ComisionBarraPL-5", "ComisionBarraPL-10");

        //                        CalcularValorIntermediario(presu, TotalBarra, RubroBarra);

        //                        presu.ProductoId = producto.Id;
        //                        presu.TipoLogisticaId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());
        //                        presu.LocalidadId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());
        //                        presu.CantInvitadosLogistica = CantidadInvitadosLogistica; //Int32.Parse(DropDownListCantInvitadosLogisitca.SelectedItem.Value.ToString());
        //                        presu.Logistica = Int32.Parse(TextBoxCostoLogistica.Text);

        //                        presu.Cannon = ObtenerCostoCanonBarra(TotalBarra);

        //                        //presu.Cannon = Int32.Parse(TextBoxCostoCannonBarra.Text) * CantidadTotalInvitados;

        //                        presu.ValorSeleccionado = System.Math.Round(TotalBarra, 2);

        //                        presu.PrecioSeleccionado = DropDownListPrecios.SelectedItem.Text;
        //                        presu.CodigoItem = producto.Codigo;

        //                        presu.Comision = System.Math.Round(porcentajeBarra, 2);
        //                        presu.PorcentajeComision = PorcentajeVendidoBarra;


        //                        presu.EstadoId = PresupuestoDetalleAprobado;

        //                        ListPresupuestoDetalle.Add(presu);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                LabelErrores.Visible = true;
        //                LabelErrores.Text = "No Existe el Item creado para poder Cotizar.";
        //            }

        //        }
        //        else if (unidadNegocioSeleccionada == RubroAmbientacion)
        //        {
        //            string CodigoSalon = cmd.ArmarCodigoAmbientacion(Int32.Parse(DropDownListServicio.SelectedItem.Value), Int32.Parse(DropDownListProveedor.SelectedItem.Value), CantidadTotalInvitados, SectorId);

        //            Productos producto = administrativas.BuscarProductosPorCodigo(CodigoSalon, fechaSeleccionada);

        //            if (producto != null)
        //            {
        //                PresupuestoDetalle presu = new PresupuestoDetalle();

        //                double Total = 0; // producto.Precio * double.Parse(DropDownListPrecios.SelectedItem.Value.ToString());
        //                double porcentajeAmbientacion = 0;

        //                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id).SingleOrDefault();

        //                if (ItemRepetido == null)
        //                {
        //                    presu.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString());
        //                    presu.ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value.ToString());
        //                    presu.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value.ToString());

        //                    presu.ProductoDescripcion = producto.Descripcion;


        //                    Total = CalcularPrecioVenta(DropDownListPrecios, producto, Total);

        //                    presu.PrecioItem = Total;

        //                    List<Comisiones> comisiones = administrativas.ObtenerComisiones();

        //                    porcentajeAmbientacion = GenerarComision(DropDownListPrecios.SelectedItem.Text, Total, porcentajeAmbientacion, comisiones, "ComisionAmbientacionPL+5", "ComisionAmbientacionPL", "ComisionAmbientacionPL-5", "ComisionAmbientacionPL-10");

        //                    PorcentajeVendidoAmbientacion = PorcentajeAdicional(DropDownListPrecios.SelectedItem.Text, PorcentajeVendidoAmbientacion, comisiones, "ComisionAmbientacionPL+5", "ComisionAmbientacionPL", "ComisionAmbientacionPL-5", "ComisionAmbientacionPL-10");


        //                    CalcularValorIntermediario(presu, Total, RubroAmbientacion);


        //                    presu.ValorSeleccionado = System.Math.Round(Total + (presu.ValorIntermediario == null ? 0 : double.Parse(presu.ValorIntermediario.ToString())), 2);


        //                    presu.ProductoId = producto.Id;
        //                    presu.PrecioSeleccionado = DropDownListPrecios.SelectedItem.Text;
        //                    presu.CodigoItem = producto.Codigo;
        //                    presu.Costo = producto.Costo;

        //                    if (Comisiona == "S")
        //                    {
        //                        presu.Comision = System.Math.Round(porcentajeAmbientacion, 2);
        //                        presu.PorcentajeComision = PorcentajeVendidoAmbientacion;
        //                    }
        //                    else
        //                    {
        //                        presu.Comision = 0;
        //                        presu.PorcentajeComision = 0;
        //                    }
        //                    presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5");
        //                    presu.PrecioLista = CalcularPrecios(producto, "PL");
        //                    presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5");
        //                    presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10");


        //                    presu.EstadoId = PresupuestoDetalleAprobado;

        //                    ListPresupuestoDetalle.Add(presu);

        //                }
        //            }
        //            else
        //            {
        //                LabelErrores.Visible = true;
        //                LabelErrores.Text = "No Existe el Item creado para poder Cotizar.";
        //            }

        //        }
        //        else if (unidadNegocioSeleccionada == RubroOrganizacion)
        //        {
        //            string CodigoSalon = cmd.ArmarCodigoOrganizacion(
        //                Int32.Parse(DropDownListServicio.SelectedItem.Value),
        //                Int32.Parse(DropDownListProveedor.SelectedItem.Value), CantidadTotalInvitados);

        //            Productos producto =
        //                administrativas.BuscarProductosPorCodigo(CodigoSalon, fechaSeleccionada);

        //            if (producto != null)
        //            {
        //                PresupuestoDetalle presu = new PresupuestoDetalle();

        //                double
        //                    Total = 0; // producto.Precio * double.Parse(DropDownListPrecios.SelectedItem.Value.ToString());
        //                double porcentajeAmbientacion = 0;

        //                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id)
        //                    .SingleOrDefault();

        //                if (ItemRepetido == null)
        //                {
        //                    presu.UnidadNegocioId =
        //                        Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString());
        //                    presu.ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value.ToString());
        //                    presu.ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value.ToString());

        //                    presu.ProductoDescripcion = producto.Descripcion;


        //                    Total = CalcularPrecioVenta(DropDownListPrecios, producto, Total);

        //                    if (TextBoxCantidadItemsOrganizacion.Text != "" &&
        //                        cmd.IsNumeric(TextBoxCantidadItemsOrganizacion.Text))
        //                        presu.PrecioItem = Total * Int32.Parse(TextBoxCantidadItemsOrganizacion.Text);
        //                    else
        //                        presu.PrecioItem = Total;

        //                    List<Comisiones> comisiones = administrativas.ObtenerComisiones();

        //                    porcentajeAmbientacion = GenerarComision(DropDownListPrecios.SelectedItem.Text, Total,
        //                        porcentajeAmbientacion, comisiones, "ComisionOrganizacionPL+5",
        //                        "ComisionOrganizacionPL", "ComisionOrganizacionPL-5", "ComisionOrganizacionPL-10");

        //                    PorcentajeVendidoAmbientacion = PorcentajeAdicional(DropDownListPrecios.SelectedItem.Text,
        //                        PorcentajeVendidoAmbientacion, comisiones, "ComisionOrganizacionPL+5",
        //                        "ComisionOrganizacionPL", "ComisionOrganizacionPL-5", "ComisionOrganizacionPL-10");


        //                    CalcularValorIntermediario(presu, Total, RubroAmbientacion);


        //                    presu.ValorSeleccionado =
        //                        System.Math.Round(
        //                            Total + (presu.ValorIntermediario == null
        //                                ? 0
        //                                : double.Parse(presu.ValorIntermediario.ToString())), 2);


        //                    presu.ProductoId = producto.Id;
        //                    presu.PrecioSeleccionado = DropDownListPrecios.SelectedItem.Text;
        //                    presu.CodigoItem = producto.Codigo;
        //                    presu.Costo = producto.Costo;

        //                    if (Comisiona == "S")
        //                    {
        //                        presu.Comision = System.Math.Round(porcentajeAmbientacion, 2);
        //                        presu.PorcentajeComision = PorcentajeVendidoAmbientacion;
        //                    }
        //                    else
        //                    {
        //                        presu.Comision = 0;
        //                        presu.PorcentajeComision = 0;
        //                    }

        //                    presu.PrecioMas5 = CalcularPrecios(producto, "PL + 5");
        //                    presu.PrecioLista = CalcularPrecios(producto, "PL");
        //                    presu.PrecioMenos5 = CalcularPrecios(producto, "PL - 5");
        //                    presu.PrecioMenos10 = CalcularPrecios(producto, "PL - 10");


        //                    presu.EstadoId = PresupuestoDetalleAprobado;

        //                    ListPresupuestoDetalle.Add(presu);

        //                }
        //            }
        //            else
        //            {
        //                LabelErrores.Visible = true;
        //                LabelErrores.Text = "No Existe el Item creado para poder Cotizar.";

        //            }
        //        }

        //        GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
        //        GridViewVentas.DataBind();


        //        double TotalPresupuesto = 0;

        //        TotalPresupuesto = cmd.CalcularTotalPresupuesto(ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);

        //        TextBoxTotalPresupuesto.Text = System.Math.Round(TotalPresupuesto, 2).ToString("C");

        //        TextBoxTotalPAX.Text = System.Math.Round((TotalPresupuesto / CantidadTotalInvitados), 2).ToString("C");

        //        TextBoxCantidadAdicional.Text = "";
        //        UpdatePanelCotizador.Update();

        //    }
        //}

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

        #region Logistica

        private string ObtenerCostoLogistica(int tipoLogisticaId, int localidades, int cantInvitados)
        {

            int tipoEventoAuditorio = Int32.Parse(ConfigurationManager.AppSettings["Auditorio"].ToString());
            int tipoEventoCongreso = Int32.Parse(ConfigurationManager.AppSettings["Congreso"].ToString());
            int tipoEventoFeriaExposiciones = Int32.Parse(ConfigurationManager.AppSettings["FeriaExposiciones"].ToString());


            CalcularCantidadinvitadosLogistica();
            CostoLogistica costoLogistica = new CostoLogistica();

            if (TipoEventoId == tipoEventoAuditorio)
            {
                costoLogistica = eventos.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidades,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoCongreso)
            {
                costoLogistica = eventos.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidades,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else if (TipoEventoId == tipoEventoFeriaExposiciones)
            {
                costoLogistica = eventos.BuscarCostoLogistica(tipoLogisticaId,
                                                                   localidades,
                                                                   CantidadInvitadosLogistica, TipoEventoId);
            }
            else
            {
                costoLogistica = eventos.BuscarCostoLogistica(tipoLogisticaId,
                                                                localidades,
                                                                CantidadInvitadosLogistica);
            }

            string TieneLogistica = ListLocaciones.Where(o => o.Id == LocacionId).Select(o => o.TieneLogistica).SingleOrDefault();



            if (TieneLogistica == "S")
            {
                LabelTipoLogistica.Visible = true;
                LabelLocalidadLogistica.Visible = true;
                DropDownListLocalidadesLogisitca.Visible = true;
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
                LabelLocalidadLogistica.Visible = false;
                DropDownListLocalidadesLogisitca.Visible = false;
                DropDownListConceptoLogistica.Visible = false;
                LabelLogistica.Visible = false;
                TextBoxCostoLogistica.Visible = false;

                return "0";
            }


        }

        #endregion

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
                searcher.LocalidadId = Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value.ToString());
                searcher.LogisticaCosto = Int32.Parse(TextBoxCostoLogistica.Text);

                AgregarItem(searcher);



            }
            //AgregarItem(DropDownListPrecios.SelectedItem.Text, Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value));
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


            //AgregarItem("", RubroAdicional);
        }

        private void AgregarItem(PresupuestoDetalleADD searcher)
        {
            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            LabelErrores.Visible = false;

            int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());
            int cantidadAductos = 0;
            int cantidadAdolescentes = 0;
            int cantidadAdicional = 0;
            int ServicioId = 0;
            int ProveedorId = 0;


            int CantidadInvitadosLog = 0;


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
                              SectorId, searcher.FechaEvento);

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

                    TiposBarras barra = administrativas.BuscarTipoBarras(ServicioId);

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
                        administrativas.BuscarAdicional(
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
                producto = administrativas.BuscarProductosPorCodigo(Codigo, fechaSeleccionada);
            else
                producto = administrativas.BuscarProducto(searcher.productoNinguno);




            if (producto != null)
            {

                var ItemRepetido = ListPresupuestoDetalle.Where(o => o.ProductoId == producto.Id && o.UnidadNegocioId != RubroAdicional && o.UnidadNegocioId != RubroAmbientacion).SingleOrDefault();

                if (ItemRepetido == null)
                {
                    PresupuestoDetalle detalle = new PresupuestoDetalle();

                    detalle.UnidadNegocioId = producto.UnidadNegocioId;
                    detalle.ServicioId = ServicioId;

                    if (ProveedorId == 0)
                        detalle.LocacionId = LocacionId;
                    else
                        detalle.ProveedorId = ProveedorId;



                    detalle.ProductoDescripcion = producto.Descripcion;
                    detalle.ProductoId = producto.Id;
                    detalle.PrecioSeleccionado = searcher.precioSeleccionado;
                    detalle.CodigoItem = producto.Codigo;
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

                    detalle.EstadoId = PresupuestoDetalleAprobado;
                    detalle.SegmentoId = SegmentosId;
                    detalle.CarasteristicaId = CaracteristicasId;

                    detalle.CantidadAdicional = cantidadAdicional;

                    detalle.FechaAprobacion = System.DateTime.Today;
                    detalle.AnuloCanon = false;

                    detalle = presupuestos.AddItem(detalle, producto, LocacionId, cantidadAductos,
                       cantidadAdolescentes,
                       CantidadTotalInvitados,
                       ListPresupuestoDetalle);

                    ListPresupuestoDetalleCambios.Add(detalle);

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

            CalcularTotalPresupuesto();

            TextBoxCantidadAdicional.Text = "";
            UpdatePanelCotizador.Update();

        }

        //private void AgregarItem(string precioSeleccionado, int unidadNegocio)
        //{

        //    int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());
        //    int cantidadAductos = 0;
        //    int cantidadAdolescentes = 0;
        //    int cantidadAdicional = 0;
        //    int ServicioId = 0;
        //    int ProveedorId = 0;

        //    int TipoLogisticaId = 0;
        //    int LocalidadId = 0;
        //    int CantidadInvitadosLog = 0;
        //    int LogisticaCosto = 0;

        //    double CannonCatering = 0;
        //    double CannonBarra = 0;
        //    double CannonAmbientacion = 0;

        //    CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text,
        //        TextBoxCantAdolescentes.Text);

        //    if (cmd.IsNumeric(TextBoxCantMayores.Text))
        //        cantidadAductos = Int32.Parse(TextBoxCantMayores.Text);

        //    if (cmd.IsNumeric(TextBoxCantAdolescentes.Text))
        //        cantidadAdolescentes = Int32.Parse(TextBoxCantAdolescentes.Text);


        //    DateTime fechaSeleccionada =
        //        DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //    string Codigo;

        //    Productos producto = new Productos();


        //    switch (unidadNegocio)
        //    {
        //        case 1: //AMBIENTACION
        //            ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value);
        //            ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

        //            if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
        //                .SingleOrDefault().CannonAmbientacion > 0)
        //                CannonAmbientacion = double.Parse(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroAmbientacion)
        //                    .SingleOrDefault().CannonAmbientacion.ToString());

        //            Codigo = cmd.ArmarCodigoAmbientacion(ServicioId,
        //                ProveedorId,
        //                CantidadTotalInvitados,
        //                SectorId);


        //            break;

        //        case 2: //TECNICA
        //            ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value);
        //            ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

        //            Codigo = cmd.ArmarCodigoTecnica(TextBoxFechaDesdeEvento.Text,
        //                ServicioId,
        //                ProveedorId,
        //                SegmentosId,
        //                SectorId);

        //            break;

        //        case 3: //CATERING
        //            ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value);
        //            ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

        //            if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
        //                    .SingleOrDefault().CannonCatering > 0)
        //                CannonCatering = double.Parse(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
        //                    .SingleOrDefault().CannonCatering.ToString());

        //            TipoLogisticaId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());
        //            LocalidadId = Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value.ToString());
        //            CantidadInvitadosLog = CantidadInvitadosLogistica;
        //            LogisticaCosto = Int32.Parse(TextBoxCostoLogistica.Text);

        //            Codigo = cmd.ArmarCodigoCatering(ServicioId,
        //                ProveedorId,
        //                CantidadTotalInvitados);

        //            break;



        //        case 6: //BARRA
        //            ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value);
        //            ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);

        //            if (ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
        //                    .SingleOrDefault().CannonBarra > 0)
        //                CannonBarra = double.Parse(ListPresupuestoDetalle.Where(o => o.UnidadNegocioId == RubroSalon)
        //                    .SingleOrDefault().CannonBarra.ToString());



        //            TipoLogisticaId = Int32.Parse(DropDownListConceptoLogistica.SelectedItem.Value.ToString());
        //            LocalidadId = Int32.Parse(DropDownListLocalidadesLogisitca.SelectedItem.Value.ToString());
        //            CantidadInvitadosLog = CantidadInvitadosLogistica;
        //            LogisticaCosto = Int32.Parse(TextBoxCostoLogistica.Text);

        //            Codigo = cmd.ArmarCodigoBarra(ServicioId,
        //                ProveedorId,
        //                CantidadTotalInvitados);
        //            break;

        //        case 7: //SALON
        //            ServicioId = LocacionId;

        //            Codigo = cmd.ArmarCodigoSalon(TextBoxFechaDesdeEvento.Text,
        //                LocacionId,
        //                SectorId,
        //                JornadaId,
        //                CantidadTotalInvitados);

        //            break;

        //        case 9: //Adicional
        //             ServicioId = Int32.Parse(DropDownListAdicionales.SelectedItem.Value);

        //            Adicionales adi =
        //                administrativas.BuscarAdicional(
        //                    Int32.Parse(DropDownListAdicionales.SelectedItem.Value.ToString()));

        //            if (adi.RequiereCantidadRango == "S")
        //            {
        //                if (TextBoxCantidadAdicional.Text != "" && cmd.IsNumeric(TextBoxCantidadAdicional.Text))
        //                {
        //                    Codigo = cmd.ArmarCodigoAdicional(
        //                        Int32.Parse(DropDownListAdicionales.SelectedItem.Value),
        //                        Int32.Parse(TextBoxCantidadAdicional.Text));

        //                    cantidadAdicional = int.Parse(TextBoxCantidadAdicional.Text);


        //                }
        //                else
        //                {
        //                    Codigo = cmd.ArmarCodigoAdicional(
        //                        Int32.Parse(DropDownListAdicionales.SelectedItem.Value), 1);
        //                }
        //            }
        //            else if (adi.RequiereCantidad == "S")
        //            {

        //                Codigo = cmd.ArmarCodigoAdicional(
        //                         Int32.Parse(DropDownListAdicionales.SelectedItem.Value), 1);

        //                if (TextBoxCantidadAdicional.Text != "" && cmd.IsNumeric(TextBoxCantidadAdicional.Text))
        //                {

        //                    cantidadAdicional = int.Parse(TextBoxCantidadAdicional.Text);

        //                }
        //                else
        //                {
        //                    cantidadAdicional = 1;
        //                }
        //            }
        //            else
        //                Codigo = cmd.ArmarCodigoAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value),
        //                    CantidadTotalInvitados);


        //            break;

        //        default: //ORGANIZACION

        //            ServicioId = Int32.Parse(DropDownListServicio.SelectedItem.Value);
        //            ProveedorId = Int32.Parse(DropDownListProveedor.SelectedItem.Value);
        //            Codigo = cmd.ArmarCodigoOrganizacion(ServicioId,
        //                ProveedorId,
        //                CantidadTotalInvitados);

        //            break;

        //    }


        //        producto = administrativas.BuscarProductosPorCodigo(Codigo, fechaSeleccionada);


        //    if (producto != null)
        //    {

        //        PresupuestoDetalle detalle = new PresupuestoDetalle();

        //        detalle.UnidadNegocioId = producto.UnidadNegocioId;
        //        detalle.ServicioId = ServicioId;

        //        if (ProveedorId == 0)
        //            detalle.LocacionId = LocacionId;
        //        else
        //            detalle.ProveedorId = ProveedorId;



        //        detalle.ProductoDescripcion = producto.Descripcion;
        //        detalle.ProductoId = producto.Id;

        //        detalle.PrecioSeleccionado = precioSeleccionado;
        //        detalle.CodigoItem = producto.Codigo;


        //        if (TipoLogisticaId > 0)
        //            detalle.TipoLogisticaId = TipoLogisticaId;
        //        if (LocalidadId > 0)
        //            detalle.LocalidadId = LocalidadId;
        //        if (CantidadInvitadosLog > 0)
        //            detalle.CantInvitadosLogistica = CantidadInvitadosLog;
        //        if (LogisticaCosto > 0)
        //            detalle.Logistica = LogisticaCosto;

        //        detalle.EstadoId = PresupuestoDetalleAprobado;
        //        detalle.SegmentoId = SegmentosId;
        //        detalle.CarasteristicaId = CaracteristicasId;
        //        detalle.FechaAprobacion = System.DateTime.Today;

        //        detalle.CantidadAdicional = cantidadAdicional;

        //        detalle = presupuestos.AddItem(detalle, producto, LocacionId, cantidadAductos,
        //            cantidadAdolescentes,
        //            CantidadTotalInvitados);

        //        ListPresupuestoDetalleCambios.Add(detalle);

        //        ListPresupuestoDetalle.Add(detalle);

        //    }
        //    else
        //    {
        //        LabelErrores.Visible = true;
        //        LabelErrores.Text = "No Existe el Item creado para poder Cotizar.";
        //    }



        //    GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
        //    GridViewVentas.DataBind();


        //    //if (GridViewVentas.Rows.Count > 0)
        //    //{
        //    //    HabilitarDeshabilitarDropdownList(false);
        //    //    PanelArmarCotizacion.Visible = true;
        //    //    ButtonAgregarItem.Visible = true;
        //    //}

        //    CalcularTotalPresupuesto();

        //    //CalcularSubTotalComision();

        //    //CalcularRenta();

        //    TextBoxCantidadAdicional.Text = "";
        //    UpdatePanelCotizador.Update();

        //}

        private void CalcularTotalPresupuesto()
        {

            double Valor = cmd.CalcularTotalPresupuestoAprobado(PresupuestoId, ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);


            TextBoxTotalPresupuesto.Text = (System.Math.Round(Valor, 2)).ToString("C");

            TextBoxTotalPAX.Text = (System.Math.Round(Valor / CantidadTotalInvitados, 2)).ToString("C");
        }

        protected void ButtonVerCambios_Click(object sender, EventArgs e)
        {

            GuardarEvento();

            Presupuestos = new PresupuestoPDF();

            Presupuestos = presupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

            PanelPendientePDF.Visible = true;
            PanelVisorPDF.Visible = false;
            PanelCotixador.Visible = false;
        }

        private void GuardarEvento()
        {
            eventos.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle, ListPresupuestoDetalleCambios, ListPresupuestoDetalleQuitados);
        }

        protected void ButtonSalirPendiente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void ButtonAgregarInvitados_Click(object sender, EventArgs e)
        {

            int ProductoInvitadosAgregados = Int32.Parse(ConfigurationManager.AppSettings["ProductoInvitados"].ToString());
            int PresupuestoDetallePendiente =
             Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());



            if (cmd.IsNumeric(TextBoxCantAdolescentesAdicionales.Text) && TextBoxCantAdolescentesAdicionales.Text.Length > 0)
            {
                PresupuestoSeleccionado.CantidadAdolescentesFinal = Int32.Parse(TextBoxCantAdolescentesAdicionales.Text);
                TextBoxCantAdolescentesFinal.Text = ((PresupuestoSeleccionado.CantidadInvitadosAdolecentes == null ? 0 : PresupuestoSeleccionado.CantidadInvitadosAdolecentes)
                                                                                                            + Int32.Parse(TextBoxCantAdolescentesAdicionales.Text)).ToString();
            }

            if (cmd.IsNumeric(TextBoxCantMayoresAdicionales.Text) && TextBoxCantMayoresAdicionales.Text.Length > 0)
            {
                PresupuestoSeleccionado.CantidadAdultosFinal = Int32.Parse(TextBoxCantMayoresAdicionales.Text);
                TextBoxCantMayoresFinal.Text = ((PresupuestoSeleccionado.CantidadInicialInvitados == null ? 0 : PresupuestoSeleccionado.CantidadInicialInvitados)
                                                                                                            + Int32.Parse(TextBoxCantMayoresAdicionales.Text)).ToString();
            }

            if (cmd.IsNumeric(TextBoxCantEntre3y8Adicionales.Text) && TextBoxCantEntre3y8Adicionales.Text.Length > 0)
            {
                PresupuestoSeleccionado.CantidadMenoresEntre3y8Final = Int32.Parse(TextBoxCantEntre3y8Adicionales.Text);
                TextBoxCantEntre3y8Final.Text = ((PresupuestoSeleccionado.CantidadInvitadosMenores3y8 == null ? 0 : PresupuestoSeleccionado.CantidadInvitadosMenores3y8)
                                                                                                            + Int32.Parse(TextBoxCantEntre3y8Adicionales.Text)).ToString();
            }

            if (cmd.IsNumeric(TextBoxCantMenores3Adicionales.Text) && TextBoxCantMenores3Adicionales.Text.Length > 0)
            {
                PresupuestoSeleccionado.CantidadMenores3Final = Int32.Parse(TextBoxCantMenores3Adicionales.Text);
                TextBoxCantMenores3Final.Text = ((PresupuestoSeleccionado.CantidadInvitadosMenores3 == null ? 0 : PresupuestoSeleccionado.CantidadInvitadosMenores3)
                                                                                                            + Int32.Parse(TextBoxCantMenores3Adicionales.Text)).ToString();
            }



            ListPresupuestoDetalleModificado.Clear();

            foreach (var item in ListPresupuestoDetalle)
            {

                PresupuestoDetalle det = CalcularDifInvitados(item, PresupuestoSeleccionado, TextBoxCantMayoresFinal.Text, TextBoxCantAdolescentesFinal.Text, TextBoxCantMenores3Final.Text, TextBoxCantEntre3y8Final.Text);

                ListPresupuestoDetalleModificado.Add(det);

            }

            double totalModificado = cmd.CalcularTotalPresupuesto(ListPresupuestoDetalleModificado, 0, 0);

            double totalCosto = cmd.CalcularCostoTotalPresupuestoPorPresupuestoId(ListPresupuestoDetalleModificado, 0, 0);

            double totalPaxModificado = cmd.CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text) +
                                    cmd.CalcularCantidadInvitados(TextBoxCantMayoresFinal.Text, TextBoxCantEntre3y8Final.Text, TextBoxCantMenores3Final.Text, TextBoxCantAdolescentesFinal.Text);

            double totalPorPersona = totalModificado / totalPaxModificado;

            double totalCostoPorPersona = totalCosto / totalPaxModificado;

            double totalPaxAgregados = cmd.CalcularCantidadInvitados(TextBoxCantMayoresAdicionales.Text, TextBoxCantEntre3y8Adicionales.Text,
                                                                        TextBoxCantMenores3Adicionales.Text, TextBoxCantAdolescentesAdicionales.Text);


            //double valorTotalInvitados = totalPorPersona * totalPaxAgregados;

            double valorTotalInvitados = ValorPax * totalPaxAgregados;

            double valorTotalInvitadosCosto = totalCostoPorPersona * totalPaxAgregados;


            TextBoxTotalInvitadosAgregados.Text = valorTotalInvitados.ToString("C");


            PresupuestoDetalle detalle = new PresupuestoDetalle();

            detalle.ProductoId = ProductoInvitadosAgregados;
            detalle.ValorSeleccionado = valorTotalInvitados;
            detalle.Costo = valorTotalInvitadosCosto;
            detalle.ProductoDescripcion = "Invitados Agregados: " + totalPaxAgregados.ToString() + " PAX";
            detalle.EstadoId = PresupuestoDetallePendiente;
            detalle.UnidadNegocioId = RubroAjustes;
            detalle.PrecioSeleccionado = "";
            detalle.PrecioItem = valorTotalInvitados;
            detalle.PrecioLista = 0;
            detalle.PrecioMas5 = 0;
            detalle.PrecioMenos10 = 0;
            detalle.PrecioMenos5 = 0;
            detalle.PorcentajeComision = 0;
            detalle.CodigoItem = "IA";
            detalle.CantidadAdicional = int.Parse(totalPaxAgregados.ToString());

            ListPresupuestoDetalle.Add(detalle);
            ListPresupuestoDetalleCambios.Add(detalle);

            GridViewVentas.DataSource = ListPresupuestoDetalle.OrderBy(o => o.FechaAprobacion).ToList();
            GridViewVentas.DataBind();

            CalcularTotalPresupuesto();

            TextBoxCantAdolescentesAdicionales.Text = "";
            TextBoxCantMayoresAdicionales.Text = "";
            TextBoxCantEntre3y8Adicionales.Text = "";
            TextBoxCantMenores3Adicionales.Text = "";

            UpdatePanelCotizador.Update();


        }

        private PresupuestoDetalle CalcularDifInvitados(PresupuestoDetalle detalle, DomainAmbientHouse.Entidades.Presupuestos presupuesto,
                                                        string pcantidadAdultos, string pcantidadAdolescentes, string pcantidadMenores3, string pcantidadMenoresEntre3y8)
        {
            int productoNinguno = Int32.Parse(ConfigurationManager.AppSettings["ProductoSalonSinCosto"].ToString());


            int cantidadAdultos = 0;
            int cantidadAdolescentes = 0;
            int cantidadAdicional = 0;
            int ServicioId = 0;
            int ProveedorId = 0;

            int TipoLogisticaId = 0;
            int LocalidadId = 0;
            int CantidadInvitadosLog = 0;
            int LogisticaCosto = 0;

            double CannonCatering = 0;
            double CannonBarra = 0;
            double CannonAmbientacion = 0;


            CalcularCantidadInvitados(pcantidadAdultos, pcantidadMenoresEntre3y8, pcantidadMenores3, pcantidadAdolescentes);

            if (cmd.IsNumeric(pcantidadAdultos))
                cantidadAdultos = Int32.Parse(pcantidadAdultos);

            if (cmd.IsNumeric(pcantidadAdolescentes))
                cantidadAdolescentes = Int32.Parse(pcantidadAdolescentes);


            DateTime fechaSeleccionada =
                DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string Codigo;

            Productos producto = new Productos();


            switch (detalle.UnidadNegocioId)
            {
                case 1: //AMBIENTACION
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());
                    ProveedorId = Int32.Parse(detalle.ProveedorId.ToString());

                    if (detalle.Cannon > 0)
                        CannonAmbientacion = double.Parse(detalle.Cannon.ToString());


                    Codigo = cmd.ArmarCodigoAmbientacion(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados,
                        Int32.Parse(presupuesto.SectorId.ToString()), TextBoxFechaDesdeEvento.Text);


                    break;

                case 2: //TECNICA
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());
                    ProveedorId = Int32.Parse(detalle.ProveedorId.ToString());

                    Codigo = cmd.ArmarCodigoTecnica(TextBoxFechaDesdeEvento.Text,
                        ServicioId,
                        ProveedorId,
                        Int32.Parse(presupuesto.SegmentoId.ToString()),
                        Int32.Parse(presupuesto.SectorId.ToString()));

                    break;

                case 3: //CATERING
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());
                    ProveedorId = Int32.Parse(detalle.ProveedorId.ToString());

                    if (detalle.Cannon > 0)
                        CannonCatering = double.Parse(detalle.Cannon.ToString());

                    if (detalle.Logistica > 0)
                        LogisticaCosto = Int32.Parse(detalle.Logistica.ToString());

                    Codigo = cmd.ArmarCodigoCatering(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados);

                    break;



                case 6: //BARRA
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());
                    ProveedorId = Int32.Parse(detalle.ProveedorId.ToString());

                    if (detalle.Cannon > 0)
                        CannonBarra = double.Parse(detalle.Cannon.ToString());

                    if (detalle.Logistica > 0)
                        LogisticaCosto = Int32.Parse(detalle.Logistica.ToString());


                    Codigo = cmd.ArmarCodigoBarra(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados);
                    break;

                case 7: //SALON
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());


                    Codigo = cmd.ArmarCodigoSalon(TextBoxFechaDesdeEvento.Text,
                        Int32.Parse(presupuesto.LocacionId.ToString()),
                        Int32.Parse(presupuesto.SectorId.ToString()),
                        Int32.Parse(presupuesto.JornadaId.ToString()),
                        CantidadTotalInvitados);

                    break;

                case 8: //Organizacion
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());
                    ProveedorId = Int32.Parse(detalle.ProveedorId.ToString());
                    Codigo = cmd.ArmarCodigoOrganizacion(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados);

                    break;

                case 9: //Adicional
                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());


                    Adicionales adi =
                        administrativas.BuscarAdicional(
                            Int32.Parse(detalle.ServicioId.ToString()));

                    if (adi.RequiereCantidadRango == "S")
                    {
                        if (detalle.CantidadAdicional > 0 && cmd.IsNumeric(detalle.CantidadAdicional))
                        {
                            Codigo = cmd.ArmarCodigoAdicional(
                                Int32.Parse(detalle.ServicioId.ToString()),
                                Int32.Parse(detalle.CantidadAdicional.ToString()));

                            cantidadAdicional = Int32.Parse(detalle.CantidadAdicional.ToString());
                        }
                        else
                            Codigo = cmd.ArmarCodigoAdicional(
                                Int32.Parse(detalle.ServicioId.ToString()), 1);
                    }
                    else if (adi.RequiereCantidad == "S")
                    {
                        Codigo = cmd.ArmarCodigoAdicional(
                                  Int32.Parse(detalle.ServicioId.ToString()), 1);

                        cantidadAdicional = Int32.Parse(detalle.CantidadAdicional.ToString());

                    }
                    else
                        Codigo = cmd.ArmarCodigoAdicional(Int32.Parse(detalle.ServicioId.ToString()),
                            CantidadTotalInvitados);

                    break;


                default: //Ajustes

                    Codigo = "";

                    break;

            }

            if (productoNinguno != detalle.ProductoId)
                producto = administrativas.BuscarProductosPorCodigo(Codigo, fechaSeleccionada);
            else
                producto = administrativas.BuscarProducto(productoNinguno);

            if (producto != null)
            {

                detalle.UnidadNegocioId = producto.UnidadNegocioId;
                detalle.ServicioId = ServicioId;

                if (ProveedorId == 0)
                    detalle.LocacionId = Int32.Parse(presupuesto.LocacionId.ToString());
                else
                    detalle.ProveedorId = ProveedorId;


                detalle.ProductoDescripcion = detalle.ProductoDescripcion;
                detalle.ProductoId = detalle.ProductoId;

                detalle.PrecioSeleccionado = detalle.PrecioSeleccionado;
                detalle.CodigoItem = detalle.CodigoItem;

                detalle.CannonAmbientacion = CannonAmbientacion;
                detalle.CannonBarra = CannonBarra;
                detalle.CannonCatering = CannonCatering;

                if (TipoLogisticaId > 0)
                    detalle.TipoLogisticaId = TipoLogisticaId;
                if (LocalidadId > 0)
                    detalle.LocalidadId = LocalidadId;
                if (CantidadInvitadosLog > 0)
                    detalle.CantInvitadosLogistica = CantidadInvitadosLog;
                if (LogisticaCosto > 0)
                    detalle.Logistica = LogisticaCosto;


                detalle.CantidadAdicional = cantidadAdicional;


                return detalle = presupuestos.AddItem(detalle, producto, (int)presupuesto.LocacionId, cantidadAdultos,
                    cantidadAdolescentes,
                    CantidadTotalInvitados,
                    ListPresupuestoDetalle);


            }

            return new PresupuestoDetalle();


        }

        private Productos CargarAmbientacionCI(string fechaEvento, int paqueteAmbientacionId, int caracteristicaId, int segmentoId, int proveedorId, int cantidadPaquetes, string precioSeleccionado)
        {

            int semestre = Int32.Parse(cmd.ObtenerSemestre(fechaEvento));

            int anio = DateTime.Parse(fechaEvento).Year;

            int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());
            int pendienteDetalle = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());


            DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion costoAmbientacion = eventos.BuscarPreciosCostosPaquetesCIAmbientacion(paqueteAmbientacionId,
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


            Productos producto = administrativas.BuscarProductosPorCodigo(Codigo);

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

            administrativas.NuevoProducto(producto);
            return producto;
        }

    }
}