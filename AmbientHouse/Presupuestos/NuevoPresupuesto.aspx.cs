
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Seguridad;

namespace AmbientHouse.Presupuestos
{
    public partial class NuevoPresupuesto : System.Web.UI.Page
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

        #endregion

        #region Variables Session Costo

        private double? CostoSalon
        {
            get
            {
                return double.Parse(Session["CostoSalon"].ToString());
            }
            set
            {
                Session["CostoSalon"] = value;
            }
        }

        private double? CostoCatering
        {
            get
            {
                return double.Parse(Session["CostoCatering"].ToString());
            }
            set
            {
                Session["CostoCatering"] = value;
            }
        }

        private double? CostoTecnica
        {
            get
            {
                return double.Parse(Session["CostoTecnica"].ToString());
            }
            set
            {
                Session["CostoTecnica"] = value;
            }
        }

        private double? CostoBarra
        {
            get
            {
                return double.Parse(Session["CostoBarra"].ToString());
            }
            set
            {
                Session["CostoBarra"] = value;
            }
        }

        private double? CostoAmbientacion
        {
            get
            {
                return double.Parse(Session["CostoAmbientacion"].ToString());
            }
            set
            {
                Session["CostoAmbientacion"] = value;
            }
        }

        #endregion

        #region Variables Session Pasos

        private string PasoSalon
        {
            get
            {
                return Session["PasoSalon"].ToString();
            }
            set
            {
                Session["PasoSalon"] = value;
            }
        }

        private string PasoCatering
        {
            get
            {
                return Session["PasoCatering"].ToString();
            }
            set
            {
                Session["PasoCatering"] = value;
            }
        }

        private string PasoTecnica
        {
            get
            {
                return Session["PasoTecnica"].ToString();
            }
            set
            {
                Session["PasoTecnica"] = value;
            }
        }

        private string PasoBarra
        {
            get
            {
                return Session["PasoBarra"].ToString();
            }
            set
            {
                Session["PasoBarra"] = value;
            }
        }

        private string PasoAmbientacion
        {
            get
            {
                return Session["PasoAmbientacion"].ToString();
            }
            set
            {
                Session["PasoAmbientacion"] = value;
            }
        }

        #endregion

        #region Variables Session Objetos

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

        //private DomainAmbientHouse.Entidades.PresupuestoSalon PresupuestoSalonSeleccionado
        //{
        //    get
        //    {
        //        return Session["PresupuestoSalonSeleccionado"] as DomainAmbientHouse.Entidades.PresupuestoSalon;
        //    }
        //    set
        //    {
        //        Session["PresupuestoSalonSeleccionado"] = value;
        //    }
        //}

        //private DomainAmbientHouse.Entidades.PresupuestoCatering PresupuestoCateringSeleccionado
        //{
        //    get
        //    {
        //        return Session["PresupuestoCateringSeleccionado"] as DomainAmbientHouse.Entidades.PresupuestoCatering;
        //    }
        //    set
        //    {
        //        Session["PresupuestoCateringSeleccionado"] = value;
        //    }
        //}

        //private DomainAmbientHouse.Entidades.PresupuestoBarra PresupuestoBarraSeleccionado
        //{
        //    get
        //    {
        //        return Session["PresupuestoBarraSeleccionado"] as DomainAmbientHouse.Entidades.PresupuestoBarra;
        //    }
        //    set
        //    {
        //        Session["PresupuestoBarraSeleccionado"] = value;
        //    }
        //}

        //private DomainAmbientHouse.Entidades.PresupuestoTecnica PresupuestoTecnicaSeleccionado
        //{
        //    get
        //    {
        //        return Session["PresupuestoTecnicaSeleccionado"] as DomainAmbientHouse.Entidades.PresupuestoTecnica;
        //    }
        //    set
        //    {
        //        Session["PresupuestoTecnicaSeleccionado"] = value;
        //    }
        //}

        //private DomainAmbientHouse.Entidades.PresupuestoAmbientacion PresupuestoAmbientacionSeleccionado
        //{
        //    get
        //    {
        //        return Session["PresupuestoAmbientacionSeleccionado"] as DomainAmbientHouse.Entidades.PresupuestoAmbientacion;
        //    }
        //    set
        //    {
        //        Session["PresupuestoAmbientacionSeleccionado"] = value;
        //    }
        //}

        //private DomainAmbientHouse.Entidades.Ajustes AjustesSeleccionado
        //{
        //    get
        //    {
        //        return Session["AjustesSeleccionado"] as DomainAmbientHouse.Entidades.Ajustes;
        //    }
        //    set
        //    {
        //        Session["AjustesSeleccionado"] = value;
        //    }
        //}

        #endregion

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

        private PresupuestoPDF Presupuestos
        {
            get { return (PresupuestoPDF)HttpContext.Current.Session["PresupuestoCliente"]; }
            set { HttpContext.Current.Session["PresupuestoCliente"] = value; }
        }

        public EventosServicios servicios = new EventosServicios();
        public ClientesServicios serviciosClientes = new ClientesServicios();
        public AdministrativasServicios serviciosAdministrativas = new AdministrativasServicios();
        public ProveedoresServicios proveedorServicios = new ProveedoresServicios();
        private PresupuestosServicios serviciosPresupuestos = new PresupuestosServicios();
        public SeguridadServicios seguridad = new SeguridadServicios();

        public Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                if (seguridad.EsUsuarioGerencia(EmpleadoId))
                {
                    LabelDescuentosSalon.Visible = true;
                    TextBoxDescuentosSalon.Visible = true;

                    LabelDescuentoCatering.Visible = true;
                    TextBoxDescuentoCatering.Visible = true;

                    LabelDescuentoTecnica.Visible = true;
                    TextBoxDescuentoTecnica.Visible = true;

                    LabelDescuentoBarra.Visible = true;
                    TextBoxDescuentoBarra.Visible = true;

                    LabelDescuentoAmbientacion.Visible = true;
                    TextBoxDescuentoAmbientacion.Visible = true;

                }
                else
                {
                    LabelDescuentosSalon.Visible = false;
                    TextBoxDescuentosSalon.Visible = false;

                    LabelDescuentoCatering.Visible = false;
                    TextBoxDescuentoCatering.Visible = false;

                    LabelDescuentoTecnica.Visible = false;
                    TextBoxDescuentoTecnica.Visible = false;

                    LabelDescuentoBarra.Visible = false;
                    TextBoxDescuentoBarra.Visible = false;

                    LabelDescuentoAmbientacion.Visible = false;
                    TextBoxDescuentoAmbientacion.Visible = false;

                    PanelAjuste.Visible = false;
                }

                ButtonSiguienteCotizador.Visible = false;
                UpdatePanelErrores.Visible = false;

                DropDownListOtroEjecutivo.Visible = CheckBoxAsignarOtroEjecutivo.Checked;

                ButtonAdicionalesAmbientacion.Visible = false;
                ButtonAdicionalesBarras.Visible = false;
                ButtonAdicionalesCatering.Visible = false;
                ButtonAdicionalesTecnica.Visible = false;
                ButtonAdicionalesSalon.Visible = false;
                ButtonCotizarAdicionales.Visible = false;
                ButtonQuitarAdicional.Visible = false;


                GridViewAdicionalesSalon.Visible = false;
                GridViewCatering.Visible = false;
                GridViewTecnica.Visible = false;
                GridViewBarra.Visible = false;
                GridViewAmbientacion.Visible = false;

                PasoSalon = "N";
                PasoCatering = "N";
                PasoTecnica = "N";
                PasoBarra = "N";
                PasoAmbientacion = "N";


                PorcentajeVendidoSalon = 0;
                PorcentajeVendidoCatering = 0;
                PorcentajeVendidoTecnica = 0;
                PorcentajeVendidoBarra = 0;
                PorcentajeVendidoAmbientacion = 0;

                EstadoEvento = 0;

                PanelCotizador.Visible = false;
                PanelClientes.Visible = true;
                PanelFinanciacion.Visible = false;
                PanelVisorPDF.Visible = false;

                //ButtonAgregarAdicional.Enabled = false;

                

                ListAdicionales = new List<DomainAmbientHouse.Entidades.PresupuestoAdicionales>();

                InicializarPagina();

                CargarListas();

                CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
                SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
                TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());
                JornadaId = Int32.Parse(DropDownListJornadas.SelectedItem.Value.ToString());
                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());
                DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());

                ClienteId = 0;

                CargarListasTipoCateringTipoTecnica();


         

                UpdatePanelTipoEventoOtro.Visible = false;
                UpdatePanelLocacionOtro.Visible = false;

                PanelNuevoCliente.Visible = false;
                PanelListarClientes.Visible = false;

                TextBoxCotizacionSalon.ReadOnly = true;
                TextBoxCotizacionCatering.ReadOnly = true;
                TextBoxCotizacionTecnica.ReadOnly = true;
                TextBoxCotizacionBarras.ReadOnly = true;
                TextBoxCotizacionAmbientacion.ReadOnly = true;
                TextBoxCotizacionAdicionales.ReadOnly = true;


                TextBoxProveedorOtraTecnica.Visible = false;
                LabelProveedorTecnicaOtra.Visible = false;

                ObtenerTecnicaSalon();

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
                UpdatePanelClientes.Visible = false;

                EstadoEvento = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            }

            if (EventoId == 0)
                NuevoEvento();
            else
                EditarEvento();
        }

        private void EditarEvento()
        {

            TextBoxDescuentosSalon.ReadOnly = true;
            TextBoxDescuentoCatering.ReadOnly = true;
            TextBoxDescuentoBarra.ReadOnly = true;
            TextBoxDescuentoTecnica.ReadOnly = true;
            TextBoxDescuentoAmbientacion.ReadOnly = true;


            CargarEvento();

            CargarPresupuesto();

            CargarPresupuestoSalon();

            CargarPresupuestoCatering();

            CargarPresupuestoTecnica();

            CargarPresupuestoBarra();

            CargarPresupuestoAmbientacion();

            CargarAjustes();

            CargarPresupuestoAdicionales();

            CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);

        }

        #region Carga de Eventos/Presupuestos y Cotizaciones

        private void CargarPresupuestoAdicionales()
        {
            ListAdicionales = new List<PresupuestoAdicionales>();

            ListAdicionales = servicios.BuscarAdicionalesPorPresupuesto(PresupuestoId);

            if (ListAdicionales != null || ListAdicionales.Count > 0)
            {
                GridViewAdicionalesSeleccionados.DataSource = ListAdicionales.ToList();
                GridViewAdicionalesSeleccionados.DataBind();

                GridViewAdicionalesSeleccionados.Visible = true;
                ButtonQuitarAdicional.Visible = true;
                ButtonCotizarAdicionales.Visible = true;

            }
            else
            {
                GridViewAdicionalesSeleccionados.Visible = false;
                ButtonQuitarAdicional.Visible = false;
                ButtonCotizarAdicionales.Visible = false;
            }

        }

        private void CargarAjustes()
        {
            AjustesSeleccionado = new Ajustes();

            AjustesSeleccionado = servicios.BuscarAjustesPorPresupuesto(PresupuestoId);

            if (AjustesSeleccionado != null)
            {
                TextBoxAjusteDescripcion.Text = AjustesSeleccionado.Descripcion;
                TextBoxAjustePrecio.Text = AjustesSeleccionado.Precio.ToString();
            }
        }

        private void CargarPresupuestoAmbientacion()
        {
            PresupuestoAmbientacionSeleccionado = new PresupuestoAmbientacion();

            PresupuestoAmbientacionSeleccionado = servicios.BuscarPresupuestoAmbientacionPorPresupuesto(PresupuestoId);

            if (PresupuestoAmbientacionSeleccionado != null)
            {

                TextBoxDescuentoAmbientacion.ReadOnly = false;

                DropDownListCategoria.SelectedValue = PresupuestoAmbientacionSeleccionado.CategoriaId.ToString();
                DropDownListProveedoresAmbientacion.SelectedValue = PresupuestoAmbientacionSeleccionado.ProveedorIr.ToString();



                DropDownListPreciosAmbientacion.Items.Clear();
                DropDownListPreciosAmbientacion.Items.Add(PresupuestoAmbientacionSeleccionado.PrecioMas5 + "|PL + 5");
                DropDownListPreciosAmbientacion.Items.Add(PresupuestoAmbientacionSeleccionado.PrecioLista + "|PL");
                DropDownListPreciosAmbientacion.Items.Add(PresupuestoAmbientacionSeleccionado.PrecioMenos5 + "|PL - 5");
                DropDownListPreciosAmbientacion.Items.Add(PresupuestoAmbientacionSeleccionado.PrecioMenos10 + "|PL - 10");

                TextBoxPrecioSeleccionadoAmbientacion.Text = PresupuestoAmbientacionSeleccionado.PrecioSeleccionado;
                TextBoxCotizacionAmbientacion.Text = PresupuestoAmbientacionSeleccionado.ValorSeleccionado.ToString();
                TextBoxComisionAmbientacion.Text = PresupuestoAmbientacionSeleccionado.Comision.ToString();
                PorcentajeVendidoAmbientacion = PresupuestoAmbientacionSeleccionado.PorcentajeComision == null ? 0 : double.Parse(PresupuestoAmbientacionSeleccionado.PorcentajeComision.ToString());
                TextBoxDescuentoAmbientacion.Text = PresupuestoAmbientacionSeleccionado.Descuentos.ToString();

                ButtonNoCotizarAmbientacion.Visible = true;

                ButtonAdicionalesAmbientacion.Visible = true;

            }
            else
            {
                ButtonNoCotizarAmbientacion.Visible = false;

                ButtonAdicionalesAmbientacion.Visible = false;
            }

        }

        private void CargarPresupuestoBarra()
        {
            PresupuestoBarraSeleccionado = new PresupuestoBarra();

            PresupuestoBarraSeleccionado = servicios.BuscarPresupuestoBarraPorPresupuesto(PresupuestoId);

            if (PresupuestoBarraSeleccionado != null)
            {


                TextBoxDescuentoBarra.ReadOnly = false;
                

                DropDownListProveedorBarra.SelectedValue = PresupuestoBarraSeleccionado.ProveedorId.ToString();
                DropDownListTipoBarra.SelectedValue = PresupuestoBarraSeleccionado.TipoBarraId.ToString();

                if (PresupuestoBarraSeleccionado.TipoLogisticaId != null) DropDownListConceptoLogisticaBarra.SelectedValue = PresupuestoBarraSeleccionado.TipoLogisticaId.ToString();
                if (PresupuestoBarraSeleccionado.LocalidadId != null) DropDownListLocalidadesLogisitcaBarra.SelectedValue = PresupuestoBarraSeleccionado.LocalidadId.ToString();
                if (PresupuestoBarraSeleccionado.CantidadInvitados != null) DropDownListCantInvitadosLogisitcaBarras.SelectedValue = PresupuestoBarraSeleccionado.CantidadInvitados.ToString();

                TextBoxCanonBarras.Text = PresupuestoBarraSeleccionado.CostoCanon.ToString();
                TextBoxLogisticaBarras.Text = PresupuestoBarraSeleccionado.CostoLogistica.ToString();

                DropDownListPreciosBarras.Items.Clear();
                DropDownListPreciosBarras.Items.Add((PresupuestoBarraSeleccionado.PrecioMas5/CantidadTotalInvitados) + "|PL + 5");
                DropDownListPreciosBarras.Items.Add((PresupuestoBarraSeleccionado.PrecioLista/CantidadTotalInvitados) + "|PL");
                DropDownListPreciosBarras.Items.Add((PresupuestoBarraSeleccionado.PrecioMenos5/CantidadTotalInvitados) + "|PL - 5");
                DropDownListPreciosBarras.Items.Add((PresupuestoBarraSeleccionado.PrecioMenos10 / CantidadTotalInvitados) + "|PL - 10");

                TextBoxPrecioSeleccionadoBarra.Text = PresupuestoBarraSeleccionado.PrecioSeleccionado;
                TextBoxCotizacionBarras.Text = PresupuestoBarraSeleccionado.ValorSeleccionado.ToString();
                TextBoxComisionBarras.Text = PresupuestoBarraSeleccionado.Comision.ToString();
                PorcentajeVendidoBarra = PresupuestoBarraSeleccionado.PorcentajeComision == null ? 0 : double.Parse(PresupuestoBarraSeleccionado.PorcentajeComision.ToString());
                TextBoxDescuentoBarra.Text = PresupuestoBarraSeleccionado.Descuentos.ToString();


                ButtonNoCotizarBarra.Visible = true;

                ButtonAdicionalesBarras.Visible = true;

            }
            else
            {
                ButtonNoCotizarBarra.Visible = false;

                ButtonAdicionalesBarras.Visible = false;
            }
        }

        private void CargarPresupuestoTecnica()
        {
            PresupuestoTecnicaSeleccionado = new PresupuestoTecnica();

            PresupuestoTecnicaSeleccionado = servicios.BuscarPresupuestoTecnicaPorPresupuesto(PresupuestoId);

            if (PresupuestoTecnicaSeleccionado != null)
            {

                TextBoxDescuentoTecnica.ReadOnly = false;



                DropDownListTipoServicio.SelectedValue = PresupuestoTecnicaSeleccionado.TipoServicioId.ToString();


                if (PresupuestoTecnicaSeleccionado.TecnicaOtra != "")
                {
                    DropDownListProveedorTecnica.Visible = true;
                    TextBoxProveedorOtraTecnica.Visible = true;

                    DropDownListProveedorTecnica.SelectedValue = PresupuestoTecnicaSeleccionado.ProveedorId.ToString();
                    TextBoxProveedorOtraTecnica.Text = PresupuestoTecnicaSeleccionado.TecnicaOtra;
                }


                TecnicaSalon TecSalon = servicios.BuscarTecnicaPorLocacion(LocacionId);

                if (TecSalon == null)
                {
                    DropDownListProveedorTecnica.Visible = true;

                    DropDownListProveedorTecnica.SelectedValue = PresupuestoTecnicaSeleccionado.ProveedorId.ToString();

                }

                DropDownListPreciosTecnica.Items.Clear();
                DropDownListPreciosTecnica.Items.Add(PresupuestoTecnicaSeleccionado.PrecioMas5 + "|PL + 5");
                DropDownListPreciosTecnica.Items.Add(PresupuestoTecnicaSeleccionado.PrecioLista + "|PL");
                DropDownListPreciosTecnica.Items.Add(PresupuestoTecnicaSeleccionado.PrecioMenos5 + "|PL - 5");
                DropDownListPreciosTecnica.Items.Add(PresupuestoTecnicaSeleccionado.PrecioMenos10 + "|PL - 10");

                TextBoxPrecioSeleccionadoTecnica.Text = PresupuestoTecnicaSeleccionado.PrecioSeleccionado;
                TextBoxCotizacionTecnica.Text = PresupuestoTecnicaSeleccionado.ValorSeleccionado.ToString();
                TextBoxComisionTecnica.Text = PresupuestoTecnicaSeleccionado.Comision.ToString();
                PorcentajeVendidoTecnica = PresupuestoTecnicaSeleccionado.PorcentajeComision == null ? 0 : double.Parse(PresupuestoTecnicaSeleccionado.PorcentajeComision.ToString());
                TextBoxDescuentoTecnica.Text = PresupuestoTecnicaSeleccionado.Descuentos.ToString();


                ButtonNoCotizarTecnica.Visible = true;

                ButtonAdicionalesTecnica.Visible = true;

            }
            else
            {
                ButtonNoCotizarTecnica.Visible = false;

                ButtonAdicionalesTecnica.Visible = false;
            }
        }

        private void CargarPresupuestoCatering()
        {
            PresupuestoCateringSeleccionado = new PresupuestoCatering();

            PresupuestoCateringSeleccionado = servicios.BuscarPresupuestoCateringPorPresupuesto(PresupuestoId);

            if (PresupuestoCateringSeleccionado != null)
            {

                TextBoxDescuentoCatering.ReadOnly = false;
               


                DropDownListProveedorCatering.SelectedValue = PresupuestoCateringSeleccionado.ProveedorId.ToString();
                DropDownListExperiencias.SelectedValue = PresupuestoCateringSeleccionado.ExperienciaId.ToString();

                if (PresupuestoCateringSeleccionado.TipoLogisticaId != null) DropDownListConceptoLogisticaCatering.SelectedValue = PresupuestoCateringSeleccionado.TipoLogisticaId.ToString();
                if (PresupuestoCateringSeleccionado.LocalidadId != null) DropDownListLocalidadesLogisitcaCatering.SelectedValue = PresupuestoCateringSeleccionado.LocalidadId.ToString();
                if (PresupuestoCateringSeleccionado.CantidadInvitados != null) DropDownListCantInvitadosLogisitcaCatering.SelectedValue = PresupuestoCateringSeleccionado.CantidadInvitados.ToString();

                TextBoxCanonCatering.Text = PresupuestoCateringSeleccionado.CostoCanon.ToString();
                TextBoxLogisticaCatering.Text = PresupuestoCateringSeleccionado.CostoLogistica.ToString();

                DropDownListPreciosCatering.Items.Clear();
                DropDownListPreciosCatering.Items.Add((PresupuestoCateringSeleccionado.PrecioMas5/CantidadTotalInvitados) + "|PL + 5");
                DropDownListPreciosCatering.Items.Add((PresupuestoCateringSeleccionado.PrecioLista/CantidadTotalInvitados) + "|PL");
                DropDownListPreciosCatering.Items.Add((PresupuestoCateringSeleccionado.PrecioMenos5/CantidadTotalInvitados) + "|PL - 5");
                DropDownListPreciosCatering.Items.Add((PresupuestoCateringSeleccionado.PrecioMenos10 / CantidadTotalInvitados) + "|PL - 10");

                TextBoxPrecioSeleccionadoCatering.Text = PresupuestoCateringSeleccionado.PrecioSeleccionado;
                TextBoxCotizacionCatering.Text = PresupuestoCateringSeleccionado.ValorSeleccionado.ToString();
                TextBoxComisionCatering.Text = PresupuestoCateringSeleccionado.Comision.ToString();
                PorcentajeVendidoCatering = PresupuestoCateringSeleccionado.PorcentajeComision == null ? 0 : double.Parse(PresupuestoCateringSeleccionado.PorcentajeComision.ToString());
                TextBoxDescuentoCatering.Text = PresupuestoCateringSeleccionado.Descuentos.ToString();

                ButtonNoCotizarCatering.Visible = true;

                ButtonAdicionalesCatering.Visible = true;

            }
            else
            {
                ButtonNoCotizarCatering.Visible = false;

                ButtonAdicionalesCatering.Visible = false;
            }
        }

        private void CargarPresupuestoSalon()
        {
            PresupuestoSalonSeleccionado = new PresupuestoSalon();

            PresupuestoSalonSeleccionado = servicios.BuscarPresupuestoSalonPorPresupuesto(PresupuestoId);

            if (PresupuestoSalonSeleccionado != null)
            {
                TextBoxDescuentosSalon.ReadOnly = false;

                DropDownListLocaciones.SelectedValue = PresupuestoSalonSeleccionado.LocacionId.ToString();
                //LocacionId = PresupuestoSalonSeleccionado.LocacionId;

                DropDownListPreciosSalon.Items.Clear();
                DropDownListPreciosSalon.Items.Add(PresupuestoSalonSeleccionado.PrecioMas5 + "|PL + 5");
                DropDownListPreciosSalon.Items.Add(PresupuestoSalonSeleccionado.PrecioLista + "|PL");
                DropDownListPreciosSalon.Items.Add(PresupuestoSalonSeleccionado.PrecioMenos5 + "|PL - 5");
                DropDownListPreciosSalon.Items.Add(PresupuestoSalonSeleccionado.PrecioMenos10 + "|PL - 10");

                TextBoxPrecioSeleccionadoSalon.Text = PresupuestoSalonSeleccionado.PrecioSeleccionado;
                TextBoxCotizacionSalon.Text = PresupuestoSalonSeleccionado.ValorSeleccionado.ToString();
                TextBoxComisionSalon.Text = PresupuestoSalonSeleccionado.Comision.ToString();
                PorcentajeVendidoSalon = PresupuestoSalonSeleccionado.PorcentajeComision == null ? 0 : double.Parse(PresupuestoSalonSeleccionado.PorcentajeComision.ToString());
                TextBoxDescuentosSalon.Text = PresupuestoSalonSeleccionado.Descuentos.ToString();

                ObtenerTecnicaSalon();

                ButtonNoCotizadorSalones.Visible = true;

                ButtonAdicionalesSalon.Visible = true;

            }
            else
            {
                ButtonNoCotizadorSalones.Visible = false;

                ButtonAdicionalesSalon.Visible = false;
            }
        }

        private void CargarPresupuesto()
        {
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = servicios.BuscarPresupuesto(PresupuestoId);


                LabelCabeceraNroPresupuesto.Text = PresupuestoSeleccionado.Id.ToString();

               

                TextBoxCantMayores.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) TextBoxCantAdolescentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) TextBoxCantMenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) TextBoxCantEntre3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();


                LabelCabeceraFechaEvento.Text = TextBoxFechaDesdeEvento.Text = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);//(DateTime.Parse(PresupuestoSeleccionado.FechaEvento.ToString()).Day + "/" + DateTime.Parse(PresupuestoSeleccionado.FechaEvento.ToString()).Month + "/" + DateTime.Parse(PresupuestoSeleccionado.FechaEvento.ToString()).Year).ToString();
                LabelCabeceraCantInvitados.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosAdolecentes)) LabelCabeceraCantInvitadosAdolecentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosMenores3y8)) LabelCabeceraCantInvitadosentre3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();
                if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosMenores3)) LabelCabeceraCantInvitadosmenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();

                CalcularCantidadInvitados(PresupuestoSeleccionado.CantidadInicialInvitados.ToString(), PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString()
                                        , PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString(), PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString());


                double Valor = serviciosPresupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

                LabelCabeceraValorTotal.Text = Valor.ToString();
                LabelCabeceraPrecioPAX.Text = (Valor / CantidadTotalInvitados).ToString();

                if (PresupuestoSeleccionado.Id > 0) PanelClientes.Visible = false; PanelCotizador.Visible = true;

                TextBoxComentarioPresupuesto.Text = PresupuestoSeleccionado.Comentario;

                LocacionId = PresupuestoSeleccionado.LocacionId;

                CaracteristicasId = PresupuestoSeleccionado.CaracteristicaId;
                SegmentosId = PresupuestoSeleccionado.SegmentoId;
                TipoEventoId = PresupuestoSeleccionado.TipoEventoId;
                JornadaId = PresupuestoSeleccionado.JornadaId;
                SectorId = (PresupuestoSeleccionado.SectorId == null ? 0 : int.Parse(PresupuestoSeleccionado.SectorId.ToString()));


                if (PresupuestoSeleccionado.DuracionId != null)
                {
                    DuracionId = int.Parse(PresupuestoSeleccionado.DuracionId.ToString());
                    DropDownListDuracionEvento.SelectedValue = PresupuestoSeleccionado.DuracionId.ToString();
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

            }
        }

        private void CargarEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = servicios.BuscarEvento(EventoId);

            LabelCabeceraNroEvento.Text = EventoSeleccionado.Id.ToString();
            LabelCabeceraCliente.Text = serviciosClientes.BuscarCliente(EventoSeleccionado.ClienteId).ApellidoNombre.ToUpper();
            TextBoxCabeceraComentarioEvento.Text = EventoSeleccionado.Comentario;
            ClienteId = EventoSeleccionado.ClienteId;


        }

        #endregion

        private void NuevoEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();


            ButtonNoCotizadorSalones.Visible = false;
            ButtonNoCotizarCatering.Visible = false;
            ButtonNoCotizarTecnica.Visible = false;
            ButtonNoCotizarBarra.Visible = false;
            ButtonNoCotizarAmbientacion.Visible = false;

        }

        private void CargarListas()
        {

            CantidadPersonasLogistica();

            DropDownListTipoEvento.DataSource = servicios.TraerTipoEvento();
            DropDownListTipoEvento.DataTextField = "Descripcion";
            DropDownListTipoEvento.DataValueField = "Id";
            DropDownListTipoEvento.DataBind();

            DropDownListMomentodelDia.DataSource = serviciosAdministrativas.ObtenerMomentosDias();
            DropDownListMomentodelDia.DataTextField = "Descripcion";
            DropDownListMomentodelDia.DataValueField = "Id";
            DropDownListMomentodelDia.DataBind();

            DropDownListDuracionEvento.DataSource = serviciosAdministrativas.ObtenerDuracionEvento();
            DropDownListDuracionEvento.DataTextField = "Descripcion";
            DropDownListDuracionEvento.DataValueField = "Id";
            DropDownListDuracionEvento.DataBind();


            DropDownListLocaciones.DataSource = servicios.TraerLocaciones();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();

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

            DropDownListTipoBarra.DataSource = servicios.TraerTipoBarras();
            DropDownListTipoBarra.DataTextField = "Descripcion";
            DropDownListTipoBarra.DataValueField = "Id";
            DropDownListTipoBarra.DataBind();


            DropDownListCategoria.DataSource = servicios.TraerCategorias();
            DropDownListCategoria.DataTextField = "Descripcion";
            DropDownListCategoria.DataValueField = "Id";
            DropDownListCategoria.DataBind();

            DropDownListConceptoLogisticaCatering.DataSource = serviciosAdministrativas.ObtenerTipoLogistica();
            DropDownListConceptoLogisticaCatering.DataTextField = "Concepto";
            DropDownListConceptoLogisticaCatering.DataValueField = "Id";
            DropDownListConceptoLogisticaCatering.DataBind();

            DropDownListLocalidadesLogisitcaCatering.DataSource = serviciosAdministrativas.ObtenerLocalidades();
            DropDownListLocalidadesLogisitcaCatering.DataTextField = "Descripcion";
            DropDownListLocalidadesLogisitcaCatering.DataValueField = "Id";
            DropDownListLocalidadesLogisitcaCatering.DataBind();

            DropDownListConceptoLogisticaBarra.DataSource = serviciosAdministrativas.ObtenerTipoLogistica();
            DropDownListConceptoLogisticaBarra.DataTextField = "Concepto";
            DropDownListConceptoLogisticaBarra.DataValueField = "Id";
            DropDownListConceptoLogisticaBarra.DataBind();

            DropDownListLocalidadesLogisitcaBarra.DataSource = serviciosAdministrativas.ObtenerLocalidades();
            DropDownListLocalidadesLogisitcaBarra.DataTextField = "Descripcion";
            DropDownListLocalidadesLogisitcaBarra.DataValueField = "Id";
            DropDownListLocalidadesLogisitcaBarra.DataBind();

            int deptoVentas = Int32.Parse(ConfigurationManager.AppSettings["DeptoVentas"].ToString());

            List<Empleados> ListaEmpleados = servicios.BuscarEjecutivos(deptoVentas);

            DropDownListOtroEjecutivo.DataSource = ListaEmpleados.Where(o => o.Id != EmpleadoId).ToList();
            DropDownListOtroEjecutivo.DataTextField = "ApellidoNombre";
            DropDownListOtroEjecutivo.DataValueField = "Id";
            DropDownListOtroEjecutivo.DataBind();

            CargarListaProveedores();
        }

        private void CargarListaProveedores()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());

            DropDownListProveedorCatering.DataSource = servicios.TraerProveedoresPorRubro(RubroCatering);
            DropDownListProveedorCatering.DataTextField = "RazonSocial";
            DropDownListProveedorCatering.DataValueField = "Id";
            DropDownListProveedorCatering.DataBind();


            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());

            DropDownListProveedorTecnica.DataSource = servicios.TraerProveedoresPorRubro(RubroTecnica);
            DropDownListProveedorTecnica.DataTextField = "RazonSocial";
            DropDownListProveedorTecnica.DataValueField = "Id";
            DropDownListProveedorTecnica.DataBind();

            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            DropDownListProveedoresAmbientacion.DataSource = servicios.TraerProveedoresPorRubro(RubroAmbientacion);
            DropDownListProveedoresAmbientacion.DataTextField = "RazonSocial";
            DropDownListProveedoresAmbientacion.DataValueField = "Id";
            DropDownListProveedoresAmbientacion.DataBind();

            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());

            DropDownListProveedorBarra.DataSource = servicios.TraerProveedoresPorRubro(RubroBarra);
            DropDownListProveedorBarra.DataTextField = "RazonSocial";
            DropDownListProveedorBarra.DataValueField = "Id";
            DropDownListProveedorBarra.DataBind();

            //int RubroAudioVisual = Int32.Parse(ConfigurationManager.AppSettings["RubroAudioVisual"].ToString());

            //DropDownListProveedorAudiovisual.DataSource = servicios.TraerProveedoresPorRubro(RubroAudioVisual);
            //DropDownListProveedorAudiovisual.DataTextField = "RazonSocial";
            //DropDownListProveedorAudiovisual.DataValueField = "Id";
            //DropDownListProveedorAudiovisual.DataBind();
        }

        #region Obtener Costos y Cantidades

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {
            Parametros parametroCateringEntre3y8 = servicios.BuscarParametros("PorcentajeCateringEntre3y8");

            decimal porcentajeCateringEntre3y8 = decimal.Parse(parametroCateringEntre3y8.Valor);

            Parametros parametroCateringMenores3 = servicios.BuscarParametros("PorcentajeCateringMenores3");

            decimal porcentajeCateringMenores3 = decimal.Parse(parametroCateringMenores3.Valor);

            Parametros parametroCateringAdolescentes = servicios.BuscarParametros("PorcentajeCateringAdolescentes");

            decimal porcentajeCateringAdolescentes = decimal.Parse(parametroCateringAdolescentes.Valor);


            int CantidadAdultos = 0;
            if (cmd.IsNumeric(pCantidadAdultos))
            {
                CantidadAdultos = (int.Parse(pCantidadAdultos));
            }

            int CantidadInvitadosEntre3y8 = 0;
            if (cmd.IsNumeric(pCantidadInvitadosEntre3y8))
            {
                CantidadInvitadosEntre3y8 = int.Parse((int.Parse(pCantidadInvitadosEntre3y8) * porcentajeCateringEntre3y8).ToString());
            }

            int CantidadInvitadosMenores3 = 0;
            if (TextBoxCantMenores3.Text != "")
            {
                CantidadInvitadosMenores3 = int.Parse((int.Parse(pCantidadInvitadosMenores3) * porcentajeCateringMenores3).ToString());
            }

            int CantidadInvitadosAdolecentes = 0;
            if (TextBoxCantAdolescentes.Text != "")
            {
                CantidadInvitadosAdolecentes = int.Parse((int.Parse(pCantidadInvitadosAdolecentes) * porcentajeCateringAdolescentes).ToString());
            }

            CantidadTotalInvitados = CantidadAdultos + CantidadInvitadosEntre3y8 + CantidadInvitadosMenores3 + CantidadInvitadosAdolecentes;

        }

        private void CalcularTotalPresupuesto(string PrecioSalon, string PrecioCatering, string CanonCatering, string LogisticaCatering, string PrecioTecnica,
                                                string PrecioBarra, string CanonBarra, string LogisticaBarra, string PrecioAmbientacion, string PrecioAjuste, 
                                                string PrecioAdicionales,double Descuento)
        {

            double precioSalon = 0;
            if (cmd.IsNumeric(PrecioSalon)) precioSalon = double.Parse(PrecioSalon);

            double precioCatering = 0;
            if (cmd.IsNumeric(PrecioCatering)) precioCatering = double.Parse(PrecioCatering);

            double canonCatering = 0;
            if (cmd.IsNumeric(CanonCatering)) canonCatering = double.Parse(CanonCatering);

            double logisticaCatering = 0;
            if (cmd.IsNumeric(LogisticaCatering)) logisticaCatering = double.Parse(LogisticaCatering);

            double precioTecnica = 0;
            if (cmd.IsNumeric(PrecioTecnica)) precioTecnica = double.Parse(PrecioTecnica);

            double precioBarra = 0;
            if (cmd.IsNumeric(PrecioBarra)) precioBarra = double.Parse(PrecioBarra);

            double canonBarra = 0;
            if (cmd.IsNumeric(CanonBarra)) canonBarra = double.Parse(CanonBarra);

            double logisticaBarra = 0;
            if (cmd.IsNumeric(LogisticaBarra)) logisticaBarra = double.Parse(LogisticaBarra);

            double precioAmbientacion = 0;
            if (cmd.IsNumeric(PrecioAmbientacion)) precioAmbientacion = double.Parse(PrecioAmbientacion);

            double precioAjuste = 0;
            if (cmd.IsNumeric(PrecioAjuste)) precioAjuste = double.Parse(PrecioAjuste);

            double precioAdicionales = 0;
            if (cmd.IsNumeric(PrecioAdicionales)) precioAdicionales = double.Parse(PrecioAdicionales);


            double TotalPresupuesto = 0;


            TotalPresupuesto = precioSalon + precioCatering + (canonCatering * CantidadTotalInvitados) + logisticaCatering + precioTecnica + precioBarra + (canonBarra * CantidadTotalInvitados) + logisticaBarra + precioAmbientacion + precioAjuste + precioAdicionales - Descuento;


            LabelCabeceraValorTotal.Text = Convert.ToString(Math.Ceiling(TotalPresupuesto));

            UpdatePanelCabecera.Update();




        }

        private double CalcularTotalDescuentos(string pDescuentoSalon, string pDescuentoCatering, string pDescuentoTecnica, string pDescuentoBarra, string pDescuentoAmbientacion)
        {

            double DescuentoSalon = 0;
            if (cmd.IsNumeric(pDescuentoSalon)) DescuentoSalon = double.Parse(pDescuentoSalon);

            double DescuentoCatering = 0;
            if (cmd.IsNumeric(pDescuentoCatering)) DescuentoCatering = double.Parse(pDescuentoCatering);

            double DescuentoTecnica = 0;
            if (cmd.IsNumeric(pDescuentoTecnica)) DescuentoTecnica = double.Parse(pDescuentoTecnica);

            double DescuentoBarra = 0;
            if (cmd.IsNumeric(pDescuentoBarra)) DescuentoBarra = double.Parse(pDescuentoBarra);

            double DescuentoAmbientacion = 0;
            if (cmd.IsNumeric(pDescuentoAmbientacion)) DescuentoAmbientacion = double.Parse(pDescuentoAmbientacion);

            double TotalDescuento = 0;


            return TotalDescuento = DescuentoSalon + DescuentoCatering + DescuentoTecnica + DescuentoBarra + DescuentoAmbientacion;



        }

        private int ObtenerCantidadInvitadosCosto(List<ObtenerCantidadPersonasAdicionalesCatering> Cantidades, int CantidadInvitados)
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

        private void CantidadPersonasLogistica()
        {
            DropDownListCantInvitadosLogisitcaCatering.DataSource = serviciosAdministrativas.ObtenerCantidadPersonasLogistica();
            DropDownListCantInvitadosLogisitcaCatering.DataBind();

            DropDownListCantInvitadosLogisitcaBarras.DataSource = serviciosAdministrativas.ObtenerCantidadPersonasLogistica();
            DropDownListCantInvitadosLogisitcaBarras.DataBind();
        }

        private void ObtenerCostoCateringPropio()
        {

            CostoCatering costoCatering = new CostoCatering();


            List<ObtenerCantidadPersonasAdicionalesCatering> Cantidades = servicios.TraerCantidadPersonasCateringAdicionales();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, CantidadTotalInvitados);
            int proveedorId = Int32.Parse(DropDownListProveedorCatering.SelectedItem.Value);


            costoCatering = servicios.BuscarCostoCatering(Int32.Parse(DropDownListExperiencias.SelectedItem.Value),
                                                                    cantInvitadosCosto, proveedorId);




            if (costoCatering != null)
            {


                CostoCatering = costoCatering.Costo;

                string PrecioCateringMas5 = string.Format("{0:n2}", ((decimal.Parse(costoCatering.Precio.ToString()) / decimal.Parse(costoCatering.ValorMenos10PorCiento.ToString()) / decimal.Parse(costoCatering.ValorMenos5PorCiento.ToString()))));

                string PrecioCateringMenos5 = string.Format("{0:n2}", (decimal.Parse(costoCatering.Precio.ToString()) / decimal.Parse(costoCatering.ValorMenos5PorCiento.ToString())));

                string PrecioCateringMenos10 = string.Format("{0:n2}", (decimal.Parse(costoCatering.Precio.ToString())));

                string PrecioCateringPrecioLista = string.Format("{0:n2}", (decimal.Parse(costoCatering.Precio.ToString()) / decimal.Parse(costoCatering.ValorMenos10PorCiento.ToString())));

                DropDownListPreciosCatering.Items.Clear();
                DropDownListPreciosCatering.Items.Add(PrecioCateringMas5 + "|PL + 5");
                DropDownListPreciosCatering.Items.Add(PrecioCateringPrecioLista + "|PL");
                DropDownListPreciosCatering.Items.Add(PrecioCateringMenos5 + "|PL - 5");
                DropDownListPreciosCatering.Items.Add(PrecioCateringMenos10 + "|PL - 10");



            }
            else
            {

                DropDownListPreciosCatering.Items.Clear();
                DropDownListPreciosCatering.Items.Add("Sin Valor");

                TextBoxCotizacionCatering.Text = "";
                TextBoxComisionCatering.Text = "";
                TextBoxPrecioSeleccionadoCatering.Text = "";

                TextBoxCotizacionCatering.ReadOnly = false;

            }
        }

        private void ObtenerCostoTecnicaPropios()
        {
            CostoTecnica costoTec = new CostoTecnica();

            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            costoTec = servicios.BuscarCostoTecnica(Int32.Parse(DropDownListTipoServicio.SelectedItem.Value),
                                                                    Int32.Parse(DropDownListSegmentos.SelectedItem.Value),
                                                                   fechaSeleccionada.Year,
                                                                    fechaSeleccionada.Month,
                                                                    fechaSeleccionada.DayOfWeek.ToString(), ProveedorTecnicaId);
            //Int32.Parse(DropDownListProveedorTecnica.SelectedItem.Value));

            if (costoTec != null)
            {

                CostoTecnica = costoTec.Costo;

                string PrecioTecnicaMas5 = string.Format("{0:n2}", (decimal.Parse(costoTec.Precio.ToString()) / decimal.Parse(costoTec.ValorMenos10PorCiento.ToString()) / decimal.Parse(costoTec.ValorMenos5PorCiento.ToString())));

                string PrecioTecnicaMenos5 = string.Format("{0:n2}", (decimal.Parse(costoTec.Precio.ToString()) / decimal.Parse(costoTec.ValorMenos5PorCiento.ToString())));

                string PrecioTecnicaMenos10 = string.Format("{0:n2}", (decimal.Parse(costoTec.Precio.ToString())));

                string PrecioTecnicaPrecioLista = string.Format("{0:n2}", (decimal.Parse(costoTec.Precio.ToString()) / decimal.Parse(costoTec.ValorMenos10PorCiento.ToString())));

                DropDownListPreciosTecnica.Items.Clear();
                DropDownListPreciosTecnica.Items.Add(PrecioTecnicaMas5 + "|PL + 5");
                DropDownListPreciosTecnica.Items.Add(PrecioTecnicaPrecioLista + "|PL");
                DropDownListPreciosTecnica.Items.Add(PrecioTecnicaMenos5 + "|PL - 5");
                DropDownListPreciosTecnica.Items.Add(PrecioTecnicaMenos10 + "|PL - 10");





            }
            else
            {
                DropDownListPreciosTecnica.Items.Clear();
                DropDownListPreciosTecnica.Items.Add("Sin Valor");

                TextBoxCotizacionTecnica.Text = "";
                TextBoxPrecioSeleccionadoTecnica.Text = "";
                TextBoxComisionTecnica.Text = "";

                TextBoxCotizacionTecnica.ReadOnly = false;
            }
        }

        private void ObtenerCostoBarrasPropio()
        {


            List<ObtenerCantidadPersonasAdicionalesCatering> Cantidades = servicios.TraerCantidadPersonasCateringAdicionales();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, CantidadTotalInvitados);

            CostoBarra costoBarra = new CostoBarra();

            costoBarra = servicios.BuscarCostoBarra(Int32.Parse(DropDownListTipoBarra.SelectedItem.Value),
                                                                   cantInvitadosCosto, int.Parse(DropDownListProveedorBarra.SelectedItem.Value));

            if (costoBarra != null)
            {

                CostoBarra = costoBarra.Costo;


                string PrecioBarrasMas5 = string.Format("{0:n2}", (decimal.Parse(costoBarra.Precios.ToString()) / decimal.Parse(costoBarra.ValorMenos10PorCiento.ToString()) / decimal.Parse(costoBarra.ValorMenos5PorCiento.ToString())));

                string PrecioBarrasMenos5 = string.Format("{0:n2}", (decimal.Parse(costoBarra.Precios.ToString()) / decimal.Parse(costoBarra.ValorMenos5PorCiento.ToString())));

                string PrecioBarrasMenos10 = string.Format("{0:n2}", (decimal.Parse(costoBarra.Precios.ToString())));

                string PrecioBarrasPrecioLista = string.Format("{0:n2}", (decimal.Parse(costoBarra.Precios.ToString()) / decimal.Parse(costoBarra.ValorMenos10PorCiento.ToString())));

                DropDownListPreciosBarras.Items.Clear();
                DropDownListPreciosBarras.Items.Add(PrecioBarrasMas5 + "|PL + 5");
                DropDownListPreciosBarras.Items.Add(PrecioBarrasPrecioLista + "|PL");
                DropDownListPreciosBarras.Items.Add(PrecioBarrasMenos5 + "|PL - 5");
                DropDownListPreciosBarras.Items.Add(PrecioBarrasMenos10 + "|PL - 10");



            }
            else
            {
                DropDownListPreciosBarras.Items.Clear();
                DropDownListPreciosBarras.Items.Add("Sin Valor");

                TextBoxComisionBarras.Text = "";
                TextBoxCotizacionBarras.Text = "";
                TextBoxPrecioSeleccionadoBarra.Text = "";

                TextBoxCotizacionBarras.ReadOnly = false;
            }
        }

        private void ObtenerCostoSalonPropio()
        {
            CostoSalones costoSalon = new CostoSalones();

            LocacionId = int.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());

            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Locaciones locacion = serviciosAdministrativas.BuscarLocaciones(LocacionId);

            if (locacion.TipoLocacion.Trim() == "P")
            {

                LocacionesValorAnio valorAnio = servicios.BuscarLocacionCosto(LocacionId, (int)DateTime.Parse(fechaSeleccionada.ToShortDateString()).Year);

                double valorSalon;

                if (valorAnio != null)
                {
                    valorSalon = valorAnio.Costo;

                    //double valorSalon = servicios.BuscarLocacionCosto(LocacionId, (int)DateTime.Parse(TextBoxFechaDesdeEvento.Text).Year).Costo;


                    SectorId = int.Parse(DropDownListSectores.SelectedItem.Value.ToString());

                    JornadaId = int.Parse(DropDownListJornadas.SelectedItem.Value.ToString());

                    costoSalon = servicios.BuscarCostoSalones(LocacionId, SectorId, JornadaId,
                                                                            DateTime.Parse(fechaSeleccionada.ToShortDateString()).Year,
                                                                            DateTime.Parse(fechaSeleccionada.ToShortDateString()).Month,
                                                                            DateTime.Parse(fechaSeleccionada.ToShortDateString()).DayOfWeek.ToString());
                    if (costoSalon != null)
                    {
                        string PrecioBarrasMenos5 = string.Format("{0:n2}", ((double.Parse(costoSalon.PorcentajedelTotal.ToString()) * valorSalon) / double.Parse(costoSalon.ValorMenos5PorCiento.ToString())));

                        string PrecioBarrasMenos10 = string.Format("{0:n2}", (double.Parse(costoSalon.PorcentajedelTotal.ToString()) * valorSalon));

                        string PrecioBarrasMas5 = string.Format("{0:n2}", ((double.Parse(costoSalon.PorcentajedelTotal.ToString()) * valorSalon) / double.Parse(costoSalon.ValorMenos10PorCiento.ToString()) / double.Parse(costoSalon.ValorMenos5PorCiento.ToString())));

                        string PrecioBarrasPrecioLista = string.Format("{0:n2}", ((double.Parse(costoSalon.PorcentajedelTotal.ToString()) * valorSalon) / double.Parse(costoSalon.ValorMenos10PorCiento.ToString())));

                        DropDownListPreciosSalon.Items.Clear();
                        DropDownListPreciosSalon.Items.Add(PrecioBarrasMas5 + "|PL + 5");
                        DropDownListPreciosSalon.Items.Add(PrecioBarrasPrecioLista + "|PL");
                        DropDownListPreciosSalon.Items.Add(PrecioBarrasMenos5 + "|PL - 5");
                        DropDownListPreciosSalon.Items.Add(PrecioBarrasMenos10 + "|PL - 10");



                    }

                    else
                    {

                        DropDownListPreciosSalon.Items.Clear();
                        DropDownListPreciosSalon.Items.Add("Sin Valor");

                        TextBoxComisionSalon.Text = "";
                        TextBoxCotizacionSalon.Text = "";
                        TextBoxPrecioSeleccionadoSalon.Text = "";

                        TextBoxCotizacionSalon.ReadOnly = false;

                    }

                }
                else
                {
                    DropDownListPreciosSalon.Items.Clear();
                    DropDownListPreciosSalon.Items.Add("Sin Valor");

                    TextBoxComisionSalon.Text = "";
                    TextBoxCotizacionSalon.Text = "";
                    TextBoxPrecioSeleccionadoSalon.Text = "";

                    TextBoxCotizacionSalon.ReadOnly = false;
                }
            }
        }

        private void ObtenerTecnicaSalon()
        {
            TecnicaSalon TecSalon = servicios.BuscarTecnicaPorLocacion(LocacionId);

            if (TecSalon != null)
            {
                DropDownListProveedorTecnica.Visible = false;
                LabelSeleccionProveedor.Visible = false;

                //if (TextBoxProveedorOtraTecnica.Visible) TextBoxProveedorOtraTecnica.Visible = false;

                ProveedorTecnicaId = TecSalon.ProveedorId;

            }
            else
            {
                DropDownListProveedorTecnica.Visible = true;
                LabelSeleccionProveedor.Visible = true;
            }

            UpdatePanelCostoTecnica.Update();

        }

        private void ObtenerCostoAmbientacionPropio()
        {

            CostoAmbientacion costoAmbientacion = new CostoAmbientacion();


            List<ObtenerCantidadPersonasAdicionalesCatering> Cantidades = servicios.TraerCantidadPersonasCateringAdicionales();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, CantidadTotalInvitados);

            costoAmbientacion = servicios.BuscarCostoAmbientacion(Int32.Parse(DropDownListCategoria.SelectedItem.Value),
                                                                    cantInvitadosCosto, Int32.Parse(DropDownListProveedoresAmbientacion.SelectedItem.Value));

            if (costoAmbientacion != null)
            {

                CostoAmbientacion = costoAmbientacion.Costo;


                string PrecioAmbientacionMas5 = string.Format("{0:n2}", ((decimal.Parse(costoAmbientacion.Precio.ToString()) / decimal.Parse(costoAmbientacion.ValorMenos10PorCiento.ToString()) / decimal.Parse(costoAmbientacion.ValorMenos5PorCiento.ToString()))));

                string PrecioAmbientacionMenos5 = string.Format("{0:n2}", (decimal.Parse(costoAmbientacion.Precio.ToString()) / decimal.Parse(costoAmbientacion.ValorMenos5PorCiento.ToString())));

                string PrecioAmbientacionMenos10 = string.Format("{0:n2}", (decimal.Parse(costoAmbientacion.Precio.ToString())));

                string PrecioAmbientacionPrecioLista = string.Format("{0:n2}", (decimal.Parse(costoAmbientacion.Precio.ToString()) / decimal.Parse(costoAmbientacion.ValorMenos10PorCiento.ToString())));

                DropDownListPreciosAmbientacion.Items.Clear();
                DropDownListPreciosAmbientacion.Items.Add(PrecioAmbientacionMas5 + "|PL + 5");
                DropDownListPreciosAmbientacion.Items.Add(PrecioAmbientacionPrecioLista + "|PL");
                DropDownListPreciosAmbientacion.Items.Add(PrecioAmbientacionMenos5 + "|PL - 5");
                DropDownListPreciosAmbientacion.Items.Add(PrecioAmbientacionMenos10 + "|PL - 10");



            }
            else
            {

                DropDownListPreciosAmbientacion.Items.Clear();
                DropDownListPreciosAmbientacion.Items.Add("Sin Valor");


                TextBoxCotizacionAmbientacion.Text = "";
                TextBoxPrecioSeleccionadoAmbientacion.Text = "";
                TextBoxComisionAmbientacion.Text = "";

                TextBoxCotizacionAmbientacion.ReadOnly = false;

            }
        }

        private string ObtenerCostoLogistica(int tipoLogisticaId, int localidades, int cantInvitados)
        {



            CostoLogistica costoLogistica = servicios.BuscarCostoLogistica(tipoLogisticaId,
                                                                            localidades,
                                                                            cantInvitados);


            if (costoLogistica != null)
            {
                return costoLogistica.Valor.ToString();
            }
            else
            { return "Sin Valor"; }
        }

        #endregion

        protected void DropDownListTipoBarra_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerCostoBarrasPropio();
            UpdatePanelCotizarBarras.Update();
        }

        protected void ButtonBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void BuscarClientes()
        {
            string cliente = TextBoxApellidoBuscador.Text;
            string razonsocial = TextBoxRazonSocialBuscador.Text;

            int nrocliente;





            if (TextBoxNroClienteBuscador.Text != "")
            {
                nrocliente = Int32.Parse(TextBoxNroClienteBuscador.Text);
            }
            else
            { nrocliente = 0; }



            var clientes = serviciosClientes.BuscarClientesporApellido(cliente, nrocliente, razonsocial);


            if (clientes.Count > 0)
            {

                DropDownListClientes.DataSource = clientes;
                DropDownListClientes.DataTextField = "ApellidoNombre";
                DropDownListClientes.DataValueField = "Id";
                DropDownListClientes.DataBind();


                PanelNuevoCliente.Visible = false;
                PanelListarClientes.Visible = true;

                UpdatePanelClientes.Update();
            }
            else
            {
                TextBoxApellido.Text = TextBoxApellidoBuscador.Text;
                TextBoxRazonSocial.Text = TextBoxRazonSocialBuscador.Text;

                TextBoxOtro.Visible = false;
                Label1.Visible = false;
                CargarListasClientess();

                PanelNuevoCliente.Visible = true;
                PanelListarClientes.Visible = false;

                UpdatePanelClientes.Update();
            }

        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxApellidoBuscador.Text = "";
            TextBoxRazonSocialBuscador.Text = "";
            TextBoxNroClienteBuscador.Text = "";

            DropDownListClientes.Items.Clear();

            PanelListarClientes.Visible = false;
            PanelNuevoCliente.Visible = false;

            UpdatePanelClientes.Update();
        }

        protected void ButtonClienteSeleccionado_Click(object sender, EventArgs e)
        {

            if (ValidarErrores())
            {
                if (DropDownListClientes.SelectedItem != null)
                {
                    ClienteId = Int32.Parse(DropDownListClientes.SelectedItem.Value.ToString());
                }
                CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);


                PanelCotizador.Visible = true;
                PanelClientes.Visible = false;
                PanelVisorPDF.Visible = false;
                PanelFinanciacion.Visible = false;

                TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());
                JornadaId = Int32.Parse(DropDownListJornadas.SelectedItem.Value.ToString());
                CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
                SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());
                MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());

            }

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
            int LocacionOtro = Int32.Parse(ConfigurationManager.AppSettings["LocacionOtro"].ToString());

            if (DropDownListLocaciones.SelectedItem.Value != null)
            {

                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());



                if (DropDownListLocaciones.SelectedItem.Value == LocacionOtro.ToString())
                {

                    UpdatePanelLocacionOtro.Visible = true;
                    UpdatePanelLocacionOtro.Update();

                    LabelSector.Visible = false;
                    UpdatePanelSector.Visible = false;
                    UpdatePanelSector.Update();
                }
                else
                {

                    ObtenerTecnicaSalon();

                    int seleccionado = Int32.Parse(this.DropDownListLocaciones.SelectedItem.Value.ToString());


                    DropDownListSectores.DataSource = servicios.BuscarSectoresPorLocacion(seleccionado);
                    DropDownListSectores.DataTextField = "Descripcion";
                    DropDownListSectores.DataValueField = "Id";
                    DropDownListSectores.DataBind();

                    DropDownListCategoria.DataSource = serviciosAdministrativas.BuscarCategoriasPorLocacionCaracteristicaSegmento(seleccionado, CaracteristicasId, SegmentosId);
                    DropDownListCategoria.DataTextField = "Descripcion";
                    DropDownListCategoria.DataValueField = "Id";
                    DropDownListCategoria.DataBind();


                    UpdatePanelLocacionOtro.Visible = false;
                    UpdatePanelLocacionOtro.Update();

                    LabelSector.Visible = true;
                    UpdatePanelSector.Visible = true;
                    UpdatePanelSector.Update();

                    UpdatePanelCotizadorAmbientacion.Update();

                }


            }

        }

        #region Button Cotizar

        protected void ButtonCotizarSalon_Click(object sender, EventArgs e)
        {

            ObtenerCostoSalonPropio();
            ObtenerTecnicaSalon();
            UpdatePanelCotizadorSalones.Update();

            PasoSalon = "S";

            ButtonAdicionalesSalon.Visible = true;
            ButtonCotizarAdicionales.Visible = true;
            UpdatePanelAdicionales.Update();
        }

        protected void ButtonCotizadorCatering_Click(object sender, EventArgs e)
        {
            ObtenerCostoCateringPropio();
            UpdatePanelCotizadorCatering.Update();

            PasoCatering = "S";

            ButtonAdicionalesCatering.Visible = true;
            ButtonCotizarAdicionales.Visible = true;
            UpdatePanelAdicionales.Update();

        }

        protected void ButtonCotizadorTecnica_Click(object sender, EventArgs e)
        {

            ObtenerCostoTecnicaPropios();
            UpdatePanelCostoTecnica.Update();

            PasoTecnica = "S";

            ButtonAdicionalesTecnica.Visible = true;
            ButtonCotizarAdicionales.Visible = true;
            UpdatePanelAdicionales.Update();

        }

        protected void ButtonCotizadorBarra_Click(object sender, EventArgs e)
        {
            ObtenerCostoBarrasPropio();
            UpdatePanelCotizarBarras.Update();

            PasoBarra = "S";

            ButtonAdicionalesBarras.Visible = true;
            ButtonCotizarAdicionales.Visible = true;
            UpdatePanelAdicionales.Update();

        }

        protected void ButtonCotizadorAmbientacion_Click(object sender, EventArgs e)
        {
            ObtenerCostoAmbientacionPropio();
            UpdatePanelCotizadorAmbientacion.Update();

            PasoAmbientacion = "S";

            ButtonAdicionalesAmbientacion.Visible = true;
            ButtonCotizarAdicionales.Visible = true;
            UpdatePanelAdicionales.Update();
        }

        #endregion

        protected void DropDownListCantInvitadosLogisitcaBarras_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxLogisticaBarras.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogisticaBarra.SelectedItem.Value),
                                                                           Int32.Parse(DropDownListLocalidadesLogisitcaBarra.SelectedItem.Value), Int32.Parse(DropDownListCantInvitadosLogisitcaBarras.SelectedItem.Value)).ToString();
        }

        protected void DropDownListCantInvitadosLogisitcaCatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxLogisticaCatering.Text = ObtenerCostoLogistica(Int32.Parse(DropDownListConceptoLogisticaCatering.SelectedItem.Value),
                                                                           Int32.Parse(DropDownListLocalidadesLogisitcaCatering.SelectedItem.Value), Int32.Parse(DropDownListCantInvitadosLogisitcaCatering.SelectedItem.Value)).ToString();
        }

        protected void ButtonSiguienteCotizador_Click(object sender, EventArgs e)
        {
            PanelCotizador.Visible = false;
            PanelClientes.Visible = false;
            PanelFinanciacion.Visible = true;
            PanelVisorPDF.Visible = false;


            DropDownListFormadePago.DataSource = serviciosAdministrativas.ObtenerPlanesDePagos();
            DropDownListFormadePago.DataTextField = "Descripcion";
            DropDownListFormadePago.DataValueField = "Id";
            DropDownListFormadePago.DataBind();

        }

        protected void DropDownListCaracteristicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CaracteristicasId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());

            DropDownListCategoria.DataSource = serviciosAdministrativas.BuscarCategoriasPorLocacionCaracteristicaSegmento(LocacionId, CaracteristicasId, SegmentosId);
            DropDownListCategoria.DataTextField = "Descripcion";
            DropDownListCategoria.DataValueField = "Id";
            DropDownListCategoria.DataBind();

            TextBoxCanonCatering.Text = ObtenerCostoCanon(Int32.Parse(DropDownListSegmentos.SelectedItem.Value),
                                                                           Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value), Int32.Parse(DropDownListExperiencias.SelectedItem.Value)).ToString();

            CargarListasTipoCateringTipoTecnica();

            UpdatePanelCotizadorAmbientacion.Update();
            UpdatePanelCotizadorCatering.Update();
        }

        private void CargarListasTipoCateringTipoTecnica()
        {
            List<TipoCatering> tc = servicios.TraerTipoCatering(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);

            //if (tc.Count <= 0)
            //{
            //    tc = servicios.TraerTipoCatering();
            //}

            DropDownListExperiencias.Items.Clear();
            DropDownListExperiencias.DataSource = tc.Distinct().ToList();
            DropDownListExperiencias.DataTextField = "Descripcion";
            DropDownListExperiencias.DataValueField = "Id";
            DropDownListExperiencias.DataBind();

            List<TipoServicios> Tt = servicios.TraerTipoServicios(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);

            //if (Tt.Count <= 0)
            //{
            //    Tt = servicios.TraerTipoServicios();
            //}

            DropDownListTipoServicio.Items.Clear();
            DropDownListTipoServicio.DataSource = Tt.Distinct().ToList();
            DropDownListTipoServicio.DataTextField = "Descripcion";
            DropDownListTipoServicio.DataValueField = "Id";
            DropDownListTipoServicio.DataBind();

            UpdatePanelCotizadorCatering.Update();
            UpdatePanelCostoTecnica.Update();

        }

        protected void DropDownListSegmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SegmentosId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());

            DropDownListCategoria.DataSource = serviciosAdministrativas.BuscarCategoriasPorLocacionCaracteristicaSegmento(LocacionId, CaracteristicasId, SegmentosId);
            DropDownListCategoria.DataTextField = "Descripcion";
            DropDownListCategoria.DataValueField = "Id";
            DropDownListCategoria.DataBind();

            TextBoxCanonCatering.Text = ObtenerCostoCanon(Int32.Parse(DropDownListSegmentos.SelectedItem.Value),
                                                                          Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value), Int32.Parse(DropDownListExperiencias.SelectedItem.Value)).ToString();

            CargarListasTipoCateringTipoTecnica();

            UpdatePanelCotizadorAmbientacion.Update();
            UpdatePanelCotizadorCatering.Update();
        }

        protected void DropDownListSectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value.ToString());
        }

        protected void ButtonClienteGrabar_Click(object sender, EventArgs e)
        {
            GrabarCliente();
            PanelNuevoCliente.Visible = false;
        }

        private void GrabarCliente()
        {
            Clientes cliente = new Clientes();

            cliente.ApellidoNombre = TextBoxApellido.Text;
            cliente.RazonSocial = TextBoxRazonSocial.Text;
            cliente.Mail = TextBoxMail.Text;

            cliente.Celular = TextBoxCelular.Text;
            cliente.ComollegoId = Int32.Parse(DropDownListComoLlego.SelectedItem.Value.ToString());
            cliente.FechaContacto = System.DateTime.Now;
            cliente.TipoCliente = DropDownListTipoCliente.SelectedItem.Value.ToString();

            cliente.ComoLlegoOtro = TextBoxOtro.Text;

            ClienteId = serviciosClientes.NuevoCliente(cliente);


            List<ObtenerClientes> clientes = serviciosClientes.ObtenerClientes();

            DropDownListClientes.DataSource = clientes;
            DropDownListClientes.DataTextField = "ApellidoNombre";
            DropDownListClientes.DataValueField = "Id";
            DropDownListClientes.DataBind();


            DropDownListClientes.SelectedValue = ClienteId.ToString();

            PanelNuevoCliente.Visible = false;
            PanelListarClientes.Visible = true;


            UpdatePanelClientes.Update();

            //UpdatePanelSeleccionClientes.Update();

        }

        private void CargarListasClientess()
        {
            DropDownListComoLlego.DataSource = serviciosClientes.ObtenerComoLlego();
            DropDownListComoLlego.DataTextField = "Descripcion";
            DropDownListComoLlego.DataValueField = "Id";
            DropDownListComoLlego.DataBind();
        }

        protected void DropDownListComoLlego_SelectedIndexChanged(object sender, EventArgs e)
        {
            int clienteOtro = Int32.Parse(ConfigurationManager.AppSettings["OtroCliente"].ToString());

            if (DropDownListComoLlego.SelectedItem.Value != null)
            {

                if (DropDownListComoLlego.SelectedItem.Value == clienteOtro.ToString())
                {
                    TextBoxOtro.Visible = true;
                    Label1.Visible = true;
                    //UpdatePanelOtro.Visible = true;
                    //UpdatePanelOtro.Update();
                    UpdatePanelClientes.Update();
                }
                else
                {
                    TextBoxOtro.Visible = false;
                    Label1.Visible = false;
                    //UpdatePanelOtro.Visible = true;
                    //UpdatePanelOtro.Update();
                    UpdatePanelClientes.Update();
                }

            }
        }

        protected void TextBoxFechaDesdeEvento_TextChanged(object sender, EventArgs e)
        {
            BuscarFechas();
        }

        private void BuscarFechas()
        {
            if (TextBoxFechaDesdeEvento.Text != "")
            {


                DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                List<DomainAmbientHouse.Entidades.ObtenerEventos> eventos = servicios.BuscarEventosPorFechaVista(DateTime.Parse(fechaSeleccionada.ToShortDateString()));

                GridViewEventosReservadosConfirmados.DataSource = eventos;
                GridViewEventosReservadosConfirmados.DataBind();

                UpdatePanelGrillaEventosReservadosConfirmados.Update();
            }
        }


        protected void GridViewEventosReservadosConfirmados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosReservadosConfirmados.PageIndex = e.NewPageIndex;
            BuscarFechas();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarErrores())
            {
                Grabar();
                EditarEvento();
            }
        }

        private void Grabar()
        {
            GrabarEvento();

            GrabarPresupuesto();

            if (PasoSalon == "S" && cmd.IsNumeric(TextBoxCotizacionSalon.Text)) GrabarPresupuestoSalon();

            if (PasoCatering == "S" && cmd.IsNumeric(TextBoxCotizacionCatering.Text)) GrabarPresupuestoCatering();

            if (PasoTecnica == "S" && cmd.IsNumeric(TextBoxCotizacionTecnica.Text)) GrabarPresupuestoTecnica();

            if (PasoBarra == "S" && cmd.IsNumeric(TextBoxCotizacionBarras.Text)) GrabarPresupuestoBarra();

            if (PasoAmbientacion == "S" && cmd.IsNumeric(TextBoxCotizacionAmbientacion.Text)) GrabarPresupuestoAmbientacion();

            GrabarAjustes();

            servicios.GrabarEventoPresupuestos(EventoSeleccionado, PresupuestoSeleccionado, PresupuestoSalonSeleccionado,
                                            PresupuestoCateringSeleccionado, PresupuestoTecnicaSeleccionado, PresupuestoBarraSeleccionado,
                                            PresupuestoAmbientacionSeleccionado, AjustesSeleccionado, ListAdicionales);

            EventoId = EventoSeleccionado.Id;

            PresupuestoId = PresupuestoSeleccionado.Id;
        }

        #region Grabar Eventos/Presupuestos y Cotizaciones

        private void GrabarAjustes()
        {
            if (TextBoxAjusteDescripcion.Text != "" && TextBoxAjustePrecio.Text != "")
            {

                AjustesSeleccionado = new Ajustes();


                AjustesSeleccionado.Descripcion = TextBoxAjusteDescripcion.Text;
                AjustesSeleccionado.Precio = double.Parse(TextBoxAjustePrecio.Text);
                AjustesSeleccionado.PresupuestoId = PresupuestoId;

            }
        }

        private void GrabarPresupuestoAmbientacion()
        {
            if (PresupuestoAmbientacionSeleccionado == null)
            {
                PresupuestoAmbientacionSeleccionado = new PresupuestoAmbientacion();



                PresupuestoAmbientacionSeleccionado.ProveedorIr = Int32.Parse(DropDownListProveedoresAmbientacion.SelectedItem.Value.ToString());


                PresupuestoAmbientacionSeleccionado.CategoriaId = Int32.Parse(DropDownListCategoria.SelectedItem.Value.ToString());

                PresupuestoAmbientacionSeleccionado.Comision = (TextBoxComisionAmbientacion.Text == "" ? 0 : double.Parse(TextBoxComisionAmbientacion.Text));
                PresupuestoAmbientacionSeleccionado.PorcentajeComision = PorcentajeVendidoAmbientacion;
                PresupuestoAmbientacionSeleccionado.ValorSeleccionado = double.Parse(TextBoxCotizacionAmbientacion.Text);
                PresupuestoAmbientacionSeleccionado.PrecioSeleccionado = TextBoxPrecioSeleccionadoAmbientacion.Text;
                PresupuestoAmbientacionSeleccionado.PresupuestoId = PresupuestoId;

                if (cmd.IsNumeric(TextBoxDescuentoAmbientacion.Text)) PresupuestoAmbientacionSeleccionado.Descuentos = double.Parse(TextBoxDescuentoAmbientacion.Text);


                if (DropDownListPreciosAmbientacion.Items.Count > 1)
                {
                    foreach (ListItem item in DropDownListPreciosAmbientacion.Items)
                    {
                        string[] words = item.Value.Split('|');
                        string precio = words[0];
                        string pl = words[1];


                        if (pl == "PL + 5") PresupuestoAmbientacionSeleccionado.PrecioMas5 = double.Parse(precio);
                        else if (pl == "PL") PresupuestoAmbientacionSeleccionado.PrecioLista = double.Parse(precio);
                        else if (pl == "PL - 5") PresupuestoAmbientacionSeleccionado.PrecioMenos5 = double.Parse(precio);
                        else PresupuestoAmbientacionSeleccionado.PrecioMenos10 = double.Parse(precio);

                    }
                }
                else
                {
                    PresupuestoAmbientacionSeleccionado.PrecioMas5 = 0;
                    PresupuestoAmbientacionSeleccionado.PrecioLista = 0;
                    PresupuestoAmbientacionSeleccionado.PrecioMenos5 = 0;
                    PresupuestoAmbientacionSeleccionado.PrecioMenos10 = 0;
                }
            }
        }

        private void GrabarPresupuestoBarra()
        {
            if (PresupuestoBarraSeleccionado == null)
            {
                PresupuestoBarraSeleccionado = new PresupuestoBarra();


                PresupuestoBarraSeleccionado.ProveedorId = Int32.Parse(DropDownListProveedorBarra.SelectedItem.Value.ToString()); ;
                PresupuestoBarraSeleccionado.TipoBarraId = Int32.Parse(DropDownListTipoBarra.SelectedItem.Value.ToString());
                PresupuestoBarraSeleccionado.TipoLogisticaId = Int32.Parse(DropDownListConceptoLogisticaBarra.SelectedItem.Value.ToString());
                PresupuestoBarraSeleccionado.LocalidadId = Int32.Parse(DropDownListLocalidadesLogisitcaBarra.SelectedItem.Value.ToString());

                PresupuestoBarraSeleccionado.CantidadInvitados = Int32.Parse(DropDownListCantInvitadosLogisitcaBarras.SelectedItem.Value.ToString());

                if (cmd.IsNumeric(TextBoxLogisticaBarras.Text)) PresupuestoBarraSeleccionado.CostoLogistica = double.Parse(TextBoxLogisticaBarras.Text);
                if (cmd.IsNumeric(TextBoxCanonBarras.Text)) PresupuestoBarraSeleccionado.CostoCanon = double.Parse(TextBoxCanonBarras.Text);

                PresupuestoBarraSeleccionado.Comision = (TextBoxComisionBarras.Text == "" ? 0 : double.Parse(TextBoxComisionBarras.Text));
                PresupuestoBarraSeleccionado.PorcentajeComision = PorcentajeVendidoBarra;
                PresupuestoBarraSeleccionado.ValorSeleccionado = double.Parse(TextBoxCotizacionBarras.Text);
                PresupuestoBarraSeleccionado.PrecioSeleccionado = TextBoxPrecioSeleccionadoBarra.Text;
                PresupuestoBarraSeleccionado.PresupuestoId = PresupuestoId;
                PresupuestoBarraSeleccionado.SalonInOut = "Salon In";

                if (cmd.IsNumeric(TextBoxDescuentoBarra.Text)) PresupuestoBarraSeleccionado.Descuentos = double.Parse(TextBoxDescuentoBarra.Text);


                if (DropDownListPreciosBarras.Items.Count > 1)
                {
                    foreach (ListItem item in DropDownListPreciosBarras.Items)
                    {
                        string[] words = item.Value.Split('|');
                        string precio = words[0];
                        string pl = words[1];


                        if (pl == "PL + 5") PresupuestoBarraSeleccionado.PrecioMas5 = double.Parse(precio) * CantidadTotalInvitados;
                        else if (pl == "PL") PresupuestoBarraSeleccionado.PrecioLista = double.Parse(precio) * CantidadTotalInvitados;
                        else if (pl == "PL - 5") PresupuestoBarraSeleccionado.PrecioMenos5 = double.Parse(precio) * CantidadTotalInvitados;
                        else PresupuestoBarraSeleccionado.PrecioMenos10 = double.Parse(precio) * CantidadTotalInvitados;

                    }
                }
                else
                {
                    PresupuestoBarraSeleccionado.PrecioMas5 = 0;
                    PresupuestoBarraSeleccionado.PrecioLista = 0;
                    PresupuestoBarraSeleccionado.PrecioMenos5 = 0;
                    PresupuestoBarraSeleccionado.PrecioMenos10 = 0;
                }
            }
        }

        private void GrabarPresupuestoTecnica()
        {
            if (PresupuestoTecnicaSeleccionado == null)
            {
                PresupuestoTecnicaSeleccionado = new PresupuestoTecnica();


                if (DropDownListProveedorTecnica.SelectedItem != null)
                {
                    PresupuestoTecnicaSeleccionado.ProveedorId = Int32.Parse(DropDownListProveedorTecnica.SelectedItem.Value.ToString());
                }
                else PresupuestoTecnicaSeleccionado.ProveedorId = ProveedorTecnicaId;

                PresupuestoTecnicaSeleccionado.TipoServicioId = Int32.Parse(DropDownListExperiencias.SelectedItem.Value.ToString());

                PresupuestoTecnicaSeleccionado.Comision = (TextBoxComisionTecnica.Text == "" ? 0 : double.Parse(TextBoxComisionTecnica.Text));
                PresupuestoTecnicaSeleccionado.PorcentajeComision = PorcentajeVendidoTecnica;
                PresupuestoTecnicaSeleccionado.ValorSeleccionado = double.Parse(TextBoxCotizacionTecnica.Text);
                PresupuestoTecnicaSeleccionado.PrecioSeleccionado = TextBoxPrecioSeleccionadoTecnica.Text;
                PresupuestoTecnicaSeleccionado.PresupuestoId = PresupuestoId;

                if (cmd.IsNumeric(TextBoxDescuentoTecnica.Text)) PresupuestoTecnicaSeleccionado.Descuentos = double.Parse(TextBoxDescuentoTecnica.Text);

                PresupuestoTecnicaSeleccionado.TecnicaOtra = TextBoxProveedorOtraTecnica.Text;

                if (DropDownListPreciosTecnica.Items.Count > 1)
                {
                    foreach (ListItem item in DropDownListPreciosTecnica.Items)
                    {
                        string[] words = item.Value.Split('|');
                        string precio = words[0];
                        string pl = words[1];


                        if (pl == "PL + 5") PresupuestoTecnicaSeleccionado.PrecioMas5 = double.Parse(precio);
                        else if (pl == "PL") PresupuestoTecnicaSeleccionado.PrecioLista = double.Parse(precio);
                        else if (pl == "PL - 5") PresupuestoTecnicaSeleccionado.PrecioMenos5 = double.Parse(precio);
                        else PresupuestoTecnicaSeleccionado.PrecioMenos10 = double.Parse(precio);

                    }
                }
                else
                {
                    PresupuestoTecnicaSeleccionado.PrecioMas5 = 0;
                    PresupuestoTecnicaSeleccionado.PrecioLista = 0;
                    PresupuestoTecnicaSeleccionado.PrecioMenos5 = 0;
                    PresupuestoTecnicaSeleccionado.PrecioMenos10 = 0;
                }
            }
        }

        private void GrabarPresupuestoCatering()
        {
            if (PresupuestoCateringSeleccionado == null)
            {
                PresupuestoCateringSeleccionado = new PresupuestoCatering();


                PresupuestoCateringSeleccionado.ProveedorId = Int32.Parse(DropDownListProveedorCatering.SelectedItem.Value.ToString()); ;
                PresupuestoCateringSeleccionado.ExperienciaId = Int32.Parse(DropDownListExperiencias.SelectedItem.Value.ToString());
                PresupuestoCateringSeleccionado.TipoLogisticaId = Int32.Parse(DropDownListConceptoLogisticaCatering.SelectedItem.Value.ToString());
                PresupuestoCateringSeleccionado.LocalidadId = Int32.Parse(DropDownListLocalidadesLogisitcaCatering.SelectedItem.Value.ToString());

                PresupuestoCateringSeleccionado.CantidadInvitados = Int32.Parse(DropDownListCantInvitadosLogisitcaCatering.SelectedItem.Value.ToString());

                if (cmd.IsNumeric(TextBoxLogisticaCatering.Text)) PresupuestoCateringSeleccionado.CostoLogistica = double.Parse(TextBoxLogisticaCatering.Text);
                if (cmd.IsNumeric(TextBoxCanonCatering.Text)) PresupuestoCateringSeleccionado.CostoCanon = double.Parse(TextBoxCanonCatering.Text);

                PresupuestoCateringSeleccionado.Comision = (TextBoxComisionCatering.Text == "" ? 0 : double.Parse(TextBoxComisionCatering.Text));
                PresupuestoCateringSeleccionado.PorcentajeComision = PorcentajeVendidoCatering;
                PresupuestoCateringSeleccionado.ValorSeleccionado = double.Parse(TextBoxCotizacionCatering.Text);
                PresupuestoCateringSeleccionado.PrecioSeleccionado = TextBoxPrecioSeleccionadoCatering.Text;
                PresupuestoCateringSeleccionado.PresupuestoId = PresupuestoId;

                if (cmd.IsNumeric(TextBoxDescuentoCatering.Text)) PresupuestoCateringSeleccionado.Descuentos = double.Parse(TextBoxDescuentoCatering.Text);

                if (DropDownListPreciosCatering.Items.Count > 1)
                {
                    foreach (ListItem item in DropDownListPreciosCatering.Items)
                    {
                        string[] words = item.Value.Split('|');
                        string precio = words[0];
                        string pl = words[1];


                        if (pl == "PL + 5") PresupuestoCateringSeleccionado.PrecioMas5 = double.Parse(precio) * CantidadTotalInvitados;
                        else if (pl == "PL") PresupuestoCateringSeleccionado.PrecioLista = double.Parse(precio) * CantidadTotalInvitados;
                        else if (pl == "PL - 5") PresupuestoCateringSeleccionado.PrecioMenos5 = double.Parse(precio) * CantidadTotalInvitados;
                        else PresupuestoCateringSeleccionado.PrecioMenos10 = double.Parse(precio) * CantidadTotalInvitados;

                    }
                }
                else
                {
                    PresupuestoCateringSeleccionado.PrecioMas5 = 0;
                    PresupuestoCateringSeleccionado.PrecioLista = 0;
                    PresupuestoCateringSeleccionado.PrecioMenos5 = 0;
                    PresupuestoCateringSeleccionado.PrecioMenos10 = 0;
                }
            }
        }

        private void GrabarPresupuestoSalon()
        {
            if (PresupuestoSalonSeleccionado == null)
            {
                PresupuestoSalonSeleccionado = new PresupuestoSalon();


                PresupuestoSalonSeleccionado.LocacionId = LocacionId;
                PresupuestoSalonSeleccionado.Comision = (TextBoxComisionSalon.Text == "" ? 0 : double.Parse(TextBoxComisionSalon.Text));
                PresupuestoSalonSeleccionado.PorcentajeComision = PorcentajeVendidoSalon;
                PresupuestoSalonSeleccionado.ValorSeleccionado = double.Parse(TextBoxCotizacionSalon.Text);
                PresupuestoSalonSeleccionado.PrecioSeleccionado = TextBoxPrecioSeleccionadoSalon.Text;
                PresupuestoSalonSeleccionado.PresupuestoId = PresupuestoId;

                if (cmd.IsNumeric(TextBoxDescuentosSalon.Text)) PresupuestoSalonSeleccionado.Descuentos = double.Parse(TextBoxDescuentosSalon.Text);

                if (DropDownListPreciosSalon.Items.Count > 1)
                {
                    foreach (ListItem item in DropDownListPreciosSalon.Items)
                    {
                        string[] words = item.Value.Split('|');
                        string precio = words[0];
                        string pl = words[1];


                        if (pl == "PL + 5") PresupuestoSalonSeleccionado.PrecioMas5 = double.Parse(precio);
                        else if (pl == "PL") PresupuestoSalonSeleccionado.PrecioLista = double.Parse(precio);
                        else if (pl == "PL - 5") PresupuestoSalonSeleccionado.PrecioMenos5 = double.Parse(precio);
                        else PresupuestoSalonSeleccionado.PrecioMenos10 = double.Parse(precio);

                    }
                }
                else
                {
                    PresupuestoSalonSeleccionado.PrecioMas5 = 0;
                    PresupuestoSalonSeleccionado.PrecioLista = 0;
                    PresupuestoSalonSeleccionado.PrecioMenos5 = 0;
                    PresupuestoSalonSeleccionado.PrecioMenos10 = 0;
                }
            }
        }

        private void GrabarPresupuesto()
        {

            int PresupuestoGuardado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoGuardado"].ToString());

            PresupuestoSeleccionado.EstadoId = PresupuestoGuardado;
            PresupuestoSeleccionado.FechaEvento = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            PresupuestoSeleccionado.FechaPresupuesto = System.DateTime.Now;
            PresupuestoSeleccionado.EventoId = EventoId;

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
                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.LocacionId = LocacionId;
            }
            else
            {
                PresupuestoSeleccionado.LocacionId = LocacionId;
            }

            PresupuestoSeleccionado.LocacionOtra = TextBoxOtroLocacion.Text;

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

            if (DropDownListDuracionEvento.SelectedItem != null)
            {
                DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.DuracionId = DuracionId;
            }
            else
            {
                PresupuestoSeleccionado.DuracionId = DuracionId;
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
            //servicios.GuardarPresupuesto(PresupuestoSeleccionado);

        }

        private void GrabarEvento()
        {
            
            int EventoAsignado = Int32.Parse(ConfigurationManager.AppSettings["EstadoAsignado"].ToString());

            if (DropDownListClientes.SelectedItem != null)
            {
                ClienteId = Int32.Parse(DropDownListClientes.SelectedItem.Value.ToString());
                EventoSeleccionado.ClienteId = ClienteId;
            }

            if (CheckBoxAsignarOtroEjecutivo.Checked)
            {
                EventoSeleccionado.EmpleadoId = int.Parse(DropDownListOtroEjecutivo.SelectedItem.Value.ToString());
            }
            else
            {
                EventoSeleccionado.EmpleadoId = EmpleadoId;
            }

            if (EstadoEvento == 0)
            {
                EventoSeleccionado.EstadoId = EventoAsignado;
            }
            else
            { EventoSeleccionado.EstadoId = EstadoEvento; }
            
            EventoSeleccionado.Fecha = DateTime.Now;
            EventoSeleccionado.Comentario = TextBoxComentarioEvento.Text;


            //servicios.GuardarEvento(EventoSeleccionado);

            EventoId = EventoSeleccionado.Id;
        }

        #endregion

        #region Calculo de Comisiones

        protected void DropDownListPreciosSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularPrecioSalon();
            UpdatePanelCotizadorSalones.Update();



            ButtonNoCotizadorSalones.Visible = true;
            TextBoxDescuentosSalon.ReadOnly = false;
        }

        private void CalcularPrecioSalon()
        {
            if (DropDownListPreciosSalon.SelectedValue != null)
            {
                string[] words = DropDownListPreciosSalon.SelectedItem.Value.Split('|');
                string precio = words[0];
                string pl = words[1];

                double TotalSalon = (double.Parse(precio));
                TextBoxCotizacionSalon.Text = TotalSalon.ToString();


                double porcentajeSalon = 0;

                List<Comisiones> comisiones = serviciosAdministrativas.ObtenerComisiones();

                porcentajeSalon = GenerarComision(pl, TotalSalon, porcentajeSalon, comisiones, "ComisionSalonPL+5", "ComisionSalonPL", "ComisionSalonPL-5", "ComisionSalonPL-10");

                PorcentajeVendidoSalon = PorcentajeAdicional(pl, PorcentajeVendidoSalon, PorcentajeVendidoCatering, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");


                TextBoxComisionSalon.Text = porcentajeSalon.ToString();

                TextBoxPrecioSeleccionadoSalon.Text = pl.ToString();

                double Descuento = 0;

                Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



                CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                            TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);
            }
        }

        protected void DropDownListPreciosCatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularPrecioCatering();
            UpdatePanelCotizadorCatering.Update();

            ButtonNoCotizarCatering.Visible = true;
            TextBoxDescuentoCatering.ReadOnly = false;
        }

        private void CalcularPrecioCatering()
        {
            if (DropDownListPreciosCatering.SelectedValue != null)
            {

                string[] words = DropDownListPreciosCatering.SelectedItem.Value.Split('|');
                string precio = words[0];
                string pl = words[1];

                double TotalCatering = (double.Parse(precio) * CantidadTotalInvitados);
                TextBoxCotizacionCatering.Text = TotalCatering.ToString();


                double porcentajeCatering = 0;

                List<Comisiones> comisiones = serviciosAdministrativas.ObtenerComisiones();


                porcentajeCatering = GenerarComision(pl, TotalCatering, porcentajeCatering, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");

                PorcentajeVendidoCatering = PorcentajeAdicional(pl, TotalCatering, PorcentajeVendidoCatering, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");

                TextBoxComisionCatering.Text = porcentajeCatering.ToString();

                TextBoxPrecioSeleccionadoCatering.Text = pl.ToString();

                double Descuento = 0;

                Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



                CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                            TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);
            }
        }

        protected void DropDownListPreciosTecnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularPrecioTecnica();

            UpdatePanelCostoTecnica.Update();

            ButtonNoCotizarTecnica.Visible = true;
            TextBoxDescuentoTecnica.ReadOnly = false;
        }

        private void CalcularPrecioTecnica()
        {
            if (DropDownListPreciosTecnica.SelectedValue != null)
            {

                string[] words = DropDownListPreciosTecnica.SelectedItem.Value.Split('|');
                string precio = words[0];
                string pl = words[1];

                double TotalTecnica = (double.Parse(precio));
                TextBoxCotizacionTecnica.Text = TotalTecnica.ToString();


                double porcentajeTecnica = 0;

                List<Comisiones> comisiones = serviciosAdministrativas.ObtenerComisiones();


                porcentajeTecnica = GenerarComision(pl, TotalTecnica, porcentajeTecnica, comisiones, "ComisionTecnicaPL+5", "ComisionTecnicaPL", "ComisionTecnicaPL-5", "ComisionTecnicaPL-10");

                PorcentajeVendidoTecnica = PorcentajeAdicional(pl, PorcentajeVendidoSalon, PorcentajeVendidoTecnica, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");


                TextBoxComisionTecnica.Text = porcentajeTecnica.ToString();

                TextBoxPrecioSeleccionadoTecnica.Text = pl.ToString();

                double Descuento = 0;

                Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



                CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                            TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);
            }
        }

        protected void DropDownListPreciosBarras_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularPrecioBarra();
            UpdatePanelCotizarBarras.Update();

            ButtonNoCotizarBarra.Visible = true;
            TextBoxDescuentoBarra.ReadOnly = false;
        }

        private void CalcularPrecioBarra()
        {
            if (DropDownListPreciosBarras.SelectedValue != null)
            {

                string[] words = DropDownListPreciosBarras.SelectedItem.Value.Split('|');
                string precio = words[0];
                string pl = words[1];

                double TotalBarra = (double.Parse(precio) * CantidadTotalInvitados);
                TextBoxCotizacionBarras.Text = TotalBarra.ToString();


                double porcentajeBarra = 0;

                List<Comisiones> comisiones = serviciosAdministrativas.ObtenerComisiones();


                porcentajeBarra = GenerarComision(pl, TotalBarra, porcentajeBarra, comisiones, "ComisionBarraPL+5", "ComisionBarraPL", "ComisionBarraPL-5", "ComisionBarraPL-10");

                PorcentajeVendidoBarra = PorcentajeAdicional(pl, PorcentajeVendidoBarra, PorcentajeVendidoTecnica, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");


                TextBoxComisionBarras.Text = porcentajeBarra.ToString();

                TextBoxPrecioSeleccionadoBarra.Text = pl.ToString();

                double Descuento = 0;

                Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



                CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                            TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);
            }
        }

        protected void DropDownListPreciosAmbientacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularPrecioAmbientacion();
            UpdatePanelCotizadorAmbientacion.Update();

            ButtonNoCotizarAmbientacion.Visible = true;
            TextBoxDescuentoAmbientacion.ReadOnly = false;

        }

        private void CalcularPrecioAmbientacion()
        {
            if (DropDownListPreciosAmbientacion.SelectedValue != null)
            {

                string[] words = DropDownListPreciosAmbientacion.SelectedItem.Value.Split('|');
                string precio = words[0];
                string pl = words[1];

                double TotalAmbientacion = (double.Parse(precio));
                TextBoxCotizacionAmbientacion.Text = TotalAmbientacion.ToString();


                double porcentajeAmbientacion = 0;

                List<Comisiones> comisiones = serviciosAdministrativas.ObtenerComisiones();


                porcentajeAmbientacion = GenerarComision(pl, TotalAmbientacion, porcentajeAmbientacion, comisiones, "ComisionAmbientacionPL+5", "ComisionAmbientacionPL", "ComisionAmbientacionPL-5", "ComisionAmbientacionPL-10");

                PorcentajeVendidoAmbientacion = PorcentajeAdicional(pl, PorcentajeVendidoAmbientacion, PorcentajeVendidoTecnica, comisiones, "ComisionCateringPL+5", "ComisionCateringPL", "ComisionCateringPL-5", "ComisionCateringPL-10");


                TextBoxComisionAmbientacion.Text = porcentajeAmbientacion.ToString();

                TextBoxPrecioSeleccionadoAmbientacion.Text = pl.ToString();
                double Descuento = 0;

                Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



                CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                            TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);

            }
        }

        private double GenerarComision(string pl, double Total, double porcentaje, List<Comisiones> comisiones, string ComisionPLMas5, string ComisionPL, string comisionPLMenos5, string comisionPLMenos10)
        {
            if (pl == "PL + 5")
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPLMas5)).FirstOrDefault();

                porcentaje = Total * (query.Porcentaje / 100);





            }
            else if (pl == "PL")
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPL)).FirstOrDefault();

                porcentaje = Total * (query.Porcentaje / 100);


            }
            else if (pl == "PL - 5")
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos5)).FirstOrDefault();

                porcentaje = Total * (query.Porcentaje / 100);



            }
            else
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos10)).FirstOrDefault();

                porcentaje = Total * (query.Porcentaje / 100);


            }
            return porcentaje;
        }

        private double PorcentajeAdicional(string pl, double Total, double comisionPorcentaje, List<Comisiones> comisiones, string ComisionPLMas5, string ComisionPL, string comisionPLMenos5, string comisionPLMenos10)
        {
            if (pl == "PL + 5")
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPLMas5)).FirstOrDefault();

                comisionPorcentaje = query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));



            }
            else if (pl == "PL")
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPL)).FirstOrDefault();

                comisionPorcentaje = query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));

            }
            else if (pl == "PL - 5")
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos5)).FirstOrDefault();

                comisionPorcentaje = query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));



            }
            else
            {
                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos10)).FirstOrDefault();

                comisionPorcentaje = query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));


            }
            return comisionPorcentaje;
        }


        #endregion

        protected void DropDownListProveedorTecnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProveedorTecnicaOTRO = Int32.Parse(ConfigurationManager.AppSettings["TECNICAOTRA"].ToString());

            if (DropDownListProveedorTecnica.SelectedItem != null)
            {

                DomainAmbientHouse.Entidades.Proveedores Proveedor = proveedorServicios.GetProveedor(Int32.Parse(DropDownListProveedorTecnica.SelectedItem.Value));
                string ProveedorPropio = Proveedor.Propio.ToString();
                int ProveedorOtro = Proveedor.Id;

                if (ProveedorPropio == "S")
                {
                    TextBoxProveedorOtraTecnica.Visible = false;
                    LabelProveedorTecnicaOtra.Visible = false;


                }
                else
                {
                    TextBoxProveedorOtraTecnica.Visible = true;
                    LabelProveedorTecnicaOtra.Visible = true;


                }

            }

            UpdatePanelCostoTecnica.Update();
        }

        private bool ValidarErrores()
        {
            List<ErroresCotizador> Errores = new List<ErroresCotizador>();

            bool retorno = true;

            if (DropDownListClientes.SelectedItem == null)
            {
                if (ClienteId == 0)
                {
                    ErroresCotizador error = new ErroresCotizador();

                    error.Mensaje = "Debe Cargar un Cliente al presupuesto para Continuar!!!";

                    Errores.Add(error);

                    retorno = false;
                }
            }

            if (TextBoxFechaDesdeEvento.Text == "" && LabelCabeceraFechaEvento.Text == "")
            {
                ErroresCotizador error = new ErroresCotizador();

                error.Mensaje = "Debe Cargar la Fecha del Evento antes de Continuar!!!";

                Errores.Add(error);

                retorno = false;

            }


            if (!cmd.IsNumeric(TextBoxCantMayores.Text) && !cmd.IsNumeric(LabelCabeceraCantInvitados.Text))
            {
                ErroresCotizador error = new ErroresCotizador();

                error.Mensaje = "Debe ingresar la Cantidad de Invitados al Evento!!!";

                Errores.Add(error);

                retorno = false;

            }

            if (retorno)
            {
                UpdatePanelErrores.Visible = false;
                return retorno;
            }
            else
            {

                UpdatePanelErrores.Visible = true;

                GridViewError.DataSource = Errores.ToList();
                GridViewError.DataBind();

                UpdatePanelErrores.Update();

                return retorno;
            }


        }

        private void ValidarErrores(int proveedorCategingId, int proveedorBarraId)
        {
            List<ErroresCotizador> Errores = new List<ErroresCotizador>();


            if (TextBoxFechaDesdeEvento.Text == "" && LabelCabeceraFechaEvento.Text == "")
            {
                ErroresCotizador error = new ErroresCotizador();

                error.Mensaje = "Debe Cargar la Fecha del Evento antes de Continuar!!!";

                Errores.Add(error);

            }


            if (!cmd.IsNumeric(TextBoxCantMayores.Text) && !cmd.IsNumeric(LabelCabeceraCantInvitados.Text))
            {
                ErroresCotizador error = new ErroresCotizador();

                error.Mensaje = "Debe ingresar la Cantidad de Invitados al Evento!!!";

                Errores.Add(error);

            }

            List<Proveedores> proveedores = proveedorServicios.ObtenerProveedores();


            Proveedores proveedorCat = proveedores.Where(o => o.Id == proveedorCategingId).FirstOrDefault();

            if (proveedorCat.Propio == "N")
            {
                if (TextBoxCanonCatering.Text == "")
                {
                    ErroresCotizador error = new ErroresCotizador();

                    error.Mensaje = "Canon Catering es obligatorio cuando el proveedor no es propio!!!";

                    Errores.Add(error);

                }

            }


            Proveedores proveedorBar = proveedores.Where(o => o.Id == proveedorBarraId).FirstOrDefault();

            if (proveedorBar.Propio == "N")
            {
                if (TextBoxCanonBarras.Text == "")
                {
                    ErroresCotizador error = new ErroresCotizador();

                    error.Mensaje = "Canon Barras es obligatorio cuando el proveedor no es propio!!!";

                    Errores.Add(error);

                }

            }

            //LOGISTICA FUERA DE LAHUSEN ES OBLIGATORIA

            GridViewError.DataSource = Errores.ToList();
            GridViewError.DataBind();


        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Default.aspx");
        }

        protected void ButtonAnteriorFinanciacion_Click(object sender, EventArgs e)
        {
            PanelCotizador.Visible = true;
            PanelClientes.Visible = false;
            PanelFinanciacion.Visible = false;
            PanelVisorPDF.Visible = false;
        }

        protected void DropDownListFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {

            int FormadePagoCONTADO = Int32.Parse(ConfigurationManager.AppSettings["PagoCONTADO"].ToString());


            if (DropDownListFormadePago.SelectedItem.Value != null)
            {

                if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value.ToString()) == FormadePagoCONTADO)
                {
                    TextBoxCantidadCuotas.Visible = false;
                    LabelCantidadCuotas.Visible = false;

                    UpdatePanelSeleccionDePago.Update();

                }

            }
        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            PanelCotizador.Visible = false;
            PanelClientes.Visible = false;
            PanelFinanciacion.Visible = false;
            PanelVisorPDF.Visible = true;


            ConfirmarEvento();

            ConfirmarPresupuesto();


            if (PasoSalon == "S" && cmd.IsNumeric(TextBoxCotizacionSalon.Text)) GrabarPresupuestoSalon();

            if (PasoCatering == "S" && cmd.IsNumeric(TextBoxCotizacionCatering.Text)) GrabarPresupuestoCatering();

            if (PasoTecnica == "S" && cmd.IsNumeric(TextBoxCotizacionTecnica.Text)) GrabarPresupuestoTecnica();

            if (PasoBarra == "S" && cmd.IsNumeric(TextBoxCotizacionBarras.Text)) GrabarPresupuestoBarra();

            if (PasoAmbientacion == "S" && cmd.IsNumeric(TextBoxCotizacionAmbientacion.Text)) GrabarPresupuestoAmbientacion();

            GrabarAjustes();

            servicios.GrabarEventoPresupuestos(EventoSeleccionado, PresupuestoSeleccionado, PresupuestoSalonSeleccionado,
                                            PresupuestoCateringSeleccionado, PresupuestoTecnicaSeleccionado, PresupuestoBarraSeleccionado,
                                            PresupuestoAmbientacionSeleccionado, AjustesSeleccionado, ListAdicionales);

            EventoId = EventoSeleccionado.Id;

            PresupuestoId = PresupuestoSeleccionado.Id;


            Presupuestos = new PresupuestoPDF();

            Presupuestos = serviciosPresupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId,ListClientesPipe);

            ButtonGuardar.Visible = false;
            ButtonCancelar.Visible = false;
            PanelCabecera.Visible = false;

        }

        private void ConfirmarPresupuesto()
        {
            int PresupuestoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());

            PresupuestoSeleccionado.EstadoId = PresupuestoEnviado;
            PresupuestoSeleccionado.FechaEvento = DateTime.ParseExact(TextBoxFechaDesdeEvento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            PresupuestoSeleccionado.FechaPresupuesto = System.DateTime.Now;
            PresupuestoSeleccionado.EventoId = EventoId;

            PresupuestoSeleccionado.Comentario = TextBoxComentarioPresupuesto.Text;

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
                LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                PresupuestoSeleccionado.LocacionId = LocacionId;
            }
            else
            {
                PresupuestoSeleccionado.LocacionId = LocacionId;
            }

            PresupuestoSeleccionado.LocacionOtra = TextBoxOtroLocacion.Text;

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
        }

        private void ConfirmarEvento()
        {
            int EventoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());

            if (DropDownListClientes.SelectedItem != null)
            {
                ClienteId = Int32.Parse(DropDownListClientes.SelectedItem.Value.ToString());
                EventoSeleccionado.ClienteId = ClienteId;
            }


            EventoSeleccionado.EmpleadoId = EmpleadoId;
            EventoSeleccionado.EstadoId = EventoEnviado;
            EventoSeleccionado.Fecha = DateTime.Now;


            //servicios.GuardarEvento(EventoSeleccionado);

            EventoId = EventoSeleccionado.Id;
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Default.aspx");
        }

        protected void TextBoxCotizacionSalon_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCotizacionSalon.Text.Length > 4)
            {


            }
        }

        protected void TextBoxCotizacionBarras_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DropDownListAdicionales.SelectedItem != null)
            //{
            //    ButtonAgregarAdicional.Enabled = false;
            //}

            //UpdatePanelAdicionales.Update();
        }

        protected void DropDownListProveedoresAmbientacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonAdicionalesSalon_Click(object sender, EventArgs e)
        {
            int rubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());


            List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = serviciosAdministrativas.ObtenerAdicionales();

            GridViewAdicionalesSalon.Visible = true;
            GridViewCatering.Visible = false;
            GridViewTecnica.Visible = false;
            GridViewBarra.Visible = false;
            GridViewAmbientacion.Visible = false;


            GridViewAdicionalesSalon.DataSource = Adicionales.Where(o => o.RubroId == rubroSalon && o.LocacionId == LocacionId).ToList();
            GridViewAdicionalesSalon.DataBind();

            UpdatePanelAdicionales.Update();
        }

        protected void ButtonAdicionalesCatering_Click(object sender, EventArgs e)
        {
            int rubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());


            List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = serviciosAdministrativas.ObtenerAdicionales();


            GridViewAdicionalesSalon.Visible = false;
            GridViewCatering.Visible = true;
            GridViewTecnica.Visible = false;
            GridViewBarra.Visible = false;
            GridViewAmbientacion.Visible = false;

            int ProveedorCatering = Int32.Parse(DropDownListProveedorCatering.SelectedItem.Value.ToString());


            GridViewCatering.DataSource = Adicionales.Where(o => o.RubroId == rubroCatering && o.ProveedorId == ProveedorCatering).ToList();
            GridViewCatering.DataBind();

            UpdatePanelAdicionales.Update();
        }

        protected void ButtonAdicionalesBarras_Click(object sender, EventArgs e)
        {

            int rubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());


            List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = serviciosAdministrativas.ObtenerAdicionales();

            GridViewAdicionalesSalon.Visible = false;
            GridViewCatering.Visible = false;
            GridViewTecnica.Visible = false;
            GridViewBarra.Visible = true;
            GridViewAmbientacion.Visible = false;

            int ProveedorBarra = Int32.Parse(DropDownListProveedorBarra.SelectedItem.Value.ToString());


            GridViewBarra.DataSource = Adicionales.Where(o => o.RubroId == rubroBarra && o.ProveedorId == ProveedorBarra).ToList();
            GridViewBarra.DataBind();

            UpdatePanelAdicionales.Update();
        }

        protected void ButtonAdicionalesTecnica_Click(object sender, EventArgs e)
        {
            int rubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());



            List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = serviciosAdministrativas.ObtenerAdicionales();


            GridViewAdicionalesSalon.Visible = false;
            GridViewCatering.Visible = false;
            GridViewTecnica.Visible = true;
            GridViewBarra.Visible = false;
            GridViewAmbientacion.Visible = false;


            int ProveedorTecnica = 0;

            if (DropDownListProveedorTecnica.SelectedItem != null)
            {
                ProveedorTecnica = Int32.Parse(DropDownListProveedorTecnica.SelectedItem.Value.ToString());
            }
            else
            {
                ProveedorTecnica = ProveedorTecnicaId;
            }
            GridViewTecnica.DataSource = Adicionales.Where(o => o.RubroId == rubroTecnica && o.ProveedorId == ProveedorTecnica).ToList();
            GridViewTecnica.DataBind();

            UpdatePanelAdicionales.Update();
        }

        protected void ButtonAdicionalesAmbientacion_Click(object sender, EventArgs e)
        {
            int rubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());


            List<DomainAmbientHouse.Entidades.ObtenerAdicionales> Adicionales = serviciosAdministrativas.ObtenerAdicionales();

            GridViewAdicionalesSalon.Visible = false;
            GridViewCatering.Visible = false;
            GridViewTecnica.Visible = false;
            GridViewBarra.Visible = false;
            GridViewAmbientacion.Visible = true;

            int ProveedorAmbientacion = Int32.Parse(DropDownListProveedoresAmbientacion.SelectedItem.Value.ToString());


            GridViewAmbientacion.DataSource = Adicionales.Where(o => o.RubroId == rubroAmbientacion && o.ProveedorId == ProveedorAmbientacion).ToList();
            GridViewAmbientacion.DataBind();

            UpdatePanelAdicionales.Update();
        }

        protected void ButtonCotizarAdicionales_Click(object sender, EventArgs e)
        {
            int CantidadInvitados = CantidadTotalInvitados;
            Double TotalGeneral = 0;
            Double TotalCatering = 0;
            Double TotalSalon = 0;
            Double TotalTecnica = 0;
            Double TotalBarra = 0;
            Double TotalAmbientacion = 0;

            Double TotalComision = 0;
            Double ComisionCatering = 0;
            Double ComisionSalon = 0;
            Double ComisionTecnica = 0;
            Double ComisionBarra = 0;
            Double ComisionAmbientacion = 0;

            Double Precio = 0;

            CargarAdicionalesCatering(CantidadInvitados, ref TotalCatering, ref Precio);


            TotalSalon = CargarAdicionalesSalon(CantidadInvitados, TotalSalon, Precio);
            TotalTecnica = CargarAdicionalesTecnica(CantidadInvitados, TotalTecnica, Precio);
            TotalBarra = CargarAdicionalesBarra(CantidadInvitados, TotalBarra, Precio);
            TotalAmbientacion = CargarAdicionalesAmbientacion(CantidadInvitados, TotalAmbientacion, Precio);

            ComisionCatering =(PorcentajeVendidoCatering / 100) * TotalCatering;
            ComisionSalon =(PorcentajeVendidoSalon / 100) * TotalSalon;
            ComisionTecnica = (PorcentajeVendidoTecnica / 100) * TotalTecnica;
            ComisionBarra = (PorcentajeVendidoBarra / 100) * TotalBarra;
            ComisionAmbientacion = (PorcentajeVendidoAmbientacion / 100) * TotalAmbientacion;

            TotalComision =  System.Math.Round(ComisionCatering + ComisionSalon + ComisionTecnica + ComisionBarra + ComisionAmbientacion,2);

            TotalGeneral = TotalCatering + TotalSalon + TotalTecnica + TotalBarra + TotalAmbientacion;

            GridViewAdicionalesSeleccionados.DataSource = ListAdicionales.ToList();
            GridViewAdicionalesSeleccionados.DataBind();

            TextBoxCotizacionAdicionales.Text = TotalGeneral.ToString();

            TextBoxComisionAdicional.Text = TotalComision.ToString();

            if (GridViewAdicionalesSeleccionados.Rows.Count > 0) ButtonQuitarAdicional.Visible = true;

            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                        TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);
        }

        private double CargarAdicionalesAmbientacion(int CantidadInvitados, Double TotalGeneral, Double Precio)
        {
            foreach (GridViewRow row in GridViewAmbientacion.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxSeleccionAdicional") as CheckBox;

                if (check.Checked)
                {
                    DomainAmbientHouse.Entidades.Adicionales costoAdicional = new DomainAmbientHouse.Entidades.Adicionales();

                    costoAdicional = serviciosAdministrativas.BuscarAdicional(Int32.Parse(row.Cells[0].Text));

                    TreeNode nodoAdicional = new TreeNode();


                    if (row.Cells[4].Text == "S")
                    {
                        TextBox TextCantidad = row.Cells[3].FindControl("TextBoxCantidadAdicional") as TextBox;

                        Double Total;

                        if (TextCantidad.Text == "" || !cmd.IsNumeric(TextCantidad.Text))
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()));

                            TotalGeneral = TotalGeneral + Total;

                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = 1;
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = Precio;
                            adiPresu.Comision = System.Math.Round(Precio * (PorcentajeVendidoAmbientacion / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                        else
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()) * Int32.Parse(TextCantidad.Text));
                            TotalGeneral = TotalGeneral + Total;


                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = Int32.Parse(TextCantidad.Text);
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = (Int32.Parse(TextCantidad.Text) * Precio);
                            adiPresu.Comision = System.Math.Round((Int32.Parse(TextCantidad.Text) * Precio) * (PorcentajeVendidoAmbientacion / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                    }
                    else
                    {
                        Double Total = Double.Parse(costoAdicional.Precio.ToString());

                        TotalGeneral = TotalGeneral + Total;

                        PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                        adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                        adiPresu.Cantidad = CantidadInvitados;
                        adiPresu.Descripcion = row.Cells[1].Text;
                        adiPresu.ValorAdicional = Precio;
                        adiPresu.PrecioPresupuesto = (CantidadInvitados * Precio);
                        adiPresu.Comision = System.Math.Round((CantidadInvitados * Precio) * (PorcentajeVendidoAmbientacion / 100), 2);

                        if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                        {
                            ListAdicionales.Add(adiPresu);
                        }
                    }
                }
            }
            return TotalGeneral;
        }

        private double CargarAdicionalesBarra(int CantidadInvitados, Double TotalGeneral, Double Precio)
        {
            foreach (GridViewRow row in GridViewBarra.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxSeleccionAdicional") as CheckBox;

                if (check.Checked)
                {
                    DomainAmbientHouse.Entidades.Adicionales costoAdicional = new DomainAmbientHouse.Entidades.Adicionales();

                    costoAdicional = serviciosAdministrativas.BuscarAdicional(Int32.Parse(row.Cells[0].Text));

                    TreeNode nodoAdicional = new TreeNode();


                    if (row.Cells[4].Text == "S")
                    {
                        TextBox TextCantidad = row.Cells[3].FindControl("TextBoxCantidadAdicional") as TextBox;

                        Double Total;

                        if (TextCantidad.Text == "" || !cmd.IsNumeric(TextCantidad.Text))
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()));

                            TotalGeneral = TotalGeneral + Total;

                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = 1;
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = Precio;
                            adiPresu.Comision = System.Math.Round(Precio * (PorcentajeVendidoBarra / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                        else
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()) * Int32.Parse(TextCantidad.Text));
                            TotalGeneral = TotalGeneral + Total;


                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = Int32.Parse(TextCantidad.Text);
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = (Int32.Parse(TextCantidad.Text) * Precio);
                            adiPresu.Comision = System.Math.Round((Int32.Parse(TextCantidad.Text) * Precio) * (PorcentajeVendidoBarra / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                    }
                    else
                    {
                        Double Total = Double.Parse(costoAdicional.Precio.ToString());

                        TotalGeneral = TotalGeneral + Total;

                        PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                        adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                        adiPresu.Cantidad = CantidadInvitados;
                        adiPresu.Descripcion = row.Cells[1].Text;
                        adiPresu.ValorAdicional = Precio;
                        adiPresu.PrecioPresupuesto = (CantidadInvitados * Precio);
                        adiPresu.Comision = System.Math.Round((CantidadInvitados * Precio) * (PorcentajeVendidoBarra / 100), 2);

                        if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                        {
                            ListAdicionales.Add(adiPresu);
                        }
                    }
                }
            }
            return TotalGeneral;
        }

        private double CargarAdicionalesTecnica(int CantidadInvitados, Double TotalGeneral, Double Precio)
        {
            foreach (GridViewRow row in GridViewTecnica.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxSeleccionAdicional") as CheckBox;

                if (check.Checked)
                {
                    DomainAmbientHouse.Entidades.Adicionales costoAdicional = new DomainAmbientHouse.Entidades.Adicionales();

                    costoAdicional = serviciosAdministrativas.BuscarAdicional(Int32.Parse(row.Cells[0].Text));

                    TreeNode nodoAdicional = new TreeNode();


                    if (row.Cells[4].Text == "S")
                    {
                        TextBox TextCantidad = row.Cells[3].FindControl("TextBoxCantidadAdicional") as TextBox;

                        Double Total;

                        if (TextCantidad.Text == "" || !cmd.IsNumeric(TextCantidad.Text))
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()));

                            TotalGeneral = TotalGeneral + Total;

                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = 1;
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = Precio;
                            adiPresu.Comision = System.Math.Round(Precio * (PorcentajeVendidoTecnica / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                        else
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()) * Int32.Parse(TextCantidad.Text));
                            TotalGeneral = TotalGeneral + Total;


                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = Int32.Parse(TextCantidad.Text);
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = (Int32.Parse(TextCantidad.Text) * Precio);
                            adiPresu.Comision = System.Math.Round((Int32.Parse(TextCantidad.Text) * Precio) * (PorcentajeVendidoTecnica / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                    }
                    else
                    {
                        Double Total = Double.Parse(costoAdicional.Precio.ToString());

                        TotalGeneral = TotalGeneral + Total;


                        PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                        adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                        adiPresu.Cantidad = CantidadInvitados;
                        adiPresu.Descripcion = row.Cells[1].Text;
                        adiPresu.ValorAdicional = Precio;
                        adiPresu.PrecioPresupuesto = (CantidadInvitados * Precio);
                        adiPresu.Comision = System.Math.Round((CantidadInvitados * Precio) * (PorcentajeVendidoTecnica / 100), 2);

                        if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                        {
                            ListAdicionales.Add(adiPresu);
                        }
                    }
                }
            }
            return TotalGeneral;
        }

        private void CargarAdicionalesCatering(int CantidadInvitados, ref Double TotalGeneral, ref Double Precio)
        {
            List<ObtenerCantidadPersonasAdicionalesCatering> Cantidades = servicios.TraerCantidadPersonasCateringAdicionales();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, CantidadTotalInvitados);

            foreach (GridViewRow row in GridViewCatering.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxSeleccionAdicional") as CheckBox;

                if (check.Checked)
                {
                    DomainAmbientHouse.Entidades.CostoAdicionales costoAdicional = new CostoAdicionales();

                    DomainAmbientHouse.Entidades.Adicionales adicional = new DomainAmbientHouse.Entidades.Adicionales();

                    adicional = serviciosAdministrativas.BuscarAdicional(Int32.Parse(row.Cells[0].Text));

                    if (adicional.Precio != null)
                    {
                        Precio = Double.Parse(adicional.Precio.ToString());
                    }
                    else
                    {
                        costoAdicional = servicios.BuscarCostoAdicionalCatering(Int32.Parse(row.Cells[0].Text), cantInvitadosCosto);
                        Precio = costoAdicional.Precio;
                    }



                    if (row.Cells[4].Text == "S")
                    {
                        TextBox TextCantidad = row.Cells[3].FindControl("TextBoxCantidadAdicional") as TextBox;

                        Double Total;

                        if (TextCantidad.Text == "" || !cmd.IsNumeric(TextCantidad.Text))
                        {
                            //Total = (Double.Parse(costoAdicional.Precio.ToString()));

                            Total = Precio;

                            TotalGeneral = TotalGeneral + Total;

                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = 1;
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = Precio;
                            adiPresu.Comision =System.Math.Round( Precio * (PorcentajeVendidoCatering/100),2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                        else
                        {


                            Total = (Precio * Int32.Parse(TextCantidad.Text));
                            TotalGeneral = TotalGeneral + Total;


                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = Int32.Parse(TextCantidad.Text);
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = (Int32.Parse(TextCantidad.Text) * Precio);
                            adiPresu.Comision = System.Math.Round((Int32.Parse(TextCantidad.Text) * Precio) * (PorcentajeVendidoCatering / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                    }
                    else //EN EL CASO DE ADICIONALES QUE NO REQUIEREN CANTIDAD INDIVIDUAL
                    {
                        //Double Total = (costoAdicional.Precio * CantidadInvitados);

                        Double Total = (Precio * CantidadInvitados);

                        TotalGeneral = TotalGeneral + Total;

                        PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                        adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                        adiPresu.Cantidad = CantidadInvitados;
                        adiPresu.Descripcion = row.Cells[1].Text;
                        adiPresu.ValorAdicional = Precio;
                        adiPresu.PrecioPresupuesto = (CantidadInvitados * Precio);
                        adiPresu.Comision = System.Math.Round((CantidadInvitados * Precio) * (PorcentajeVendidoCatering / 100), 2);

                        if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                        {
                            ListAdicionales.Add(adiPresu);
                        }
                    }
                }
            }
        }

        private double CargarAdicionalesSalon(int CantidadInvitados, Double TotalGeneral, Double Precio)
        {
            foreach (GridViewRow row in GridViewAdicionalesSalon.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxSeleccionAdicional") as CheckBox;

                if (check.Checked)
                {
                    DomainAmbientHouse.Entidades.Adicionales costoAdicional = new DomainAmbientHouse.Entidades.Adicionales();

                    costoAdicional = serviciosAdministrativas.BuscarAdicional(Int32.Parse(row.Cells[0].Text));

                    if (row.Cells[4].Text == "S")
                    {
                        TextBox TextCantidad = row.Cells[3].FindControl("TextBoxCantidadAdicional") as TextBox;

                        Double Total;

                        if (TextCantidad.Text == "" || !cmd.IsNumeric(TextCantidad.Text))
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()));

                            TotalGeneral = TotalGeneral + Total;


                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = 1;
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = Precio;
                            adiPresu.Comision = System.Math.Round(Precio * (PorcentajeVendidoSalon / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }
                        else
                        {
                            Total = (Double.Parse(costoAdicional.Precio.ToString()) * Int32.Parse(TextCantidad.Text));
                            TotalGeneral = TotalGeneral + Total;

                            PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                            adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                            adiPresu.Cantidad = Int32.Parse(TextCantidad.Text);
                            adiPresu.Descripcion = row.Cells[1].Text;
                            adiPresu.ValorAdicional = Precio;
                            adiPresu.PrecioPresupuesto = (Int32.Parse(TextCantidad.Text) * Precio);
                            adiPresu.Comision = System.Math.Round((Int32.Parse(TextCantidad.Text) * Precio) * (PorcentajeVendidoSalon / 100), 2);

                            if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                            {
                                ListAdicionales.Add(adiPresu);
                            }
                        }

                    }
                    else
                    {
                        Double Total = Double.Parse(costoAdicional.Precio.ToString());

                        TotalGeneral = TotalGeneral + Total;


                        PresupuestoAdicionales adiPresu = new PresupuestoAdicionales();

                        adiPresu.AdicionalId = Int32.Parse(row.Cells[0].Text);
                        adiPresu.Cantidad = CantidadInvitados;
                        adiPresu.Descripcion = row.Cells[1].Text;
                        adiPresu.ValorAdicional = Precio;
                        adiPresu.PrecioPresupuesto = (CantidadInvitados * Precio);
                        adiPresu.Comision = System.Math.Round((CantidadInvitados * Precio) * (PorcentajeVendidoSalon / 100), 2);

                        if (ListAdicionales.Where(o => o.AdicionalId == adiPresu.AdicionalId).Count() == 0)
                        {
                            ListAdicionales.Add(adiPresu);
                        }
                    }
                }
            }
            return TotalGeneral;
        }

        protected void ButtonGenerarFinanciacion_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewAdicionalesSalon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[4].Text == "S")
                {
                    e.Row.Cells[3].Controls[1].Visible = true;

                }


            }
        }

        protected void GridViewCatering_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[4].Text == "S")
                {
                    e.Row.Cells[3].Controls[1].Visible = true;

                }


            }
        }

        protected void GridViewTecnica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[4].Text == "S")
                {
                    e.Row.Cells[3].Controls[1].Visible = true;

                }


            }
        }

        protected void GridViewBarra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[4].Text == "S")
                {
                    e.Row.Cells[3].Controls[1].Visible = true;

                }


            }
        }

        protected void GridViewAmbientacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[4].Text == "S")
                {
                    e.Row.Cells[3].Controls[1].Visible = true;

                }


            }
        }


        #region No Cotizar

        protected void ButtonNoCotizadorSalones_Click(object sender, EventArgs e)
        {
            PasoSalon = "N";

            DropDownListPreciosSalon.Items.Clear();
            TextBoxCotizacionSalon.Text = "";
            TextBoxComisionSalon.Text = "";
            TextBoxPrecioSeleccionadoSalon.Text = "";
            TextBoxDescuentosSalon.Text = "";

            if (PresupuestoSalonSeleccionado != null)
            {
                if (PresupuestoSalonSeleccionado.Id > 0)
                {
                    servicios.EliminarPresupuestoSalon(PresupuestoSalonSeleccionado);

                    PresupuestoSalonSeleccionado = null;
                }
            }
            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                        TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);

            UpdatePanelCabecera.Update();

            UpdatePanelAdicionales.Update();
        }

        protected void ButtonNoCotizarCatering_Click(object sender, EventArgs e)
        {
            PasoCatering = "N";

            DropDownListPreciosCatering.Items.Clear();
            TextBoxCotizacionCatering.Text = "";
            TextBoxComisionCatering.Text = "";
            TextBoxPrecioSeleccionadoCatering.Text = "";
            TextBoxDescuentoCatering.Text = "";

            if (PresupuestoCateringSeleccionado != null)
            {
                if (PresupuestoCateringSeleccionado.Id > 0)
                {
                    servicios.EliminarPresupuestoCatering(PresupuestoCateringSeleccionado);

                    PresupuestoCateringSeleccionado = null;
                }
            }
            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                        TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);

            UpdatePanelCabecera.Update();
            UpdatePanelAdicionales.Update();
        }

        protected void ButtonNoCotizarTecnica_Click(object sender, EventArgs e)
        {
            PasoTecnica = "N";

            DropDownListPreciosTecnica.Items.Clear();
            TextBoxCotizacionTecnica.Text = "";
            TextBoxComisionTecnica.Text = "";
            TextBoxPrecioSeleccionadoTecnica.Text = "";
            TextBoxDescuentoTecnica.Text = "";


            if (PresupuestoTecnicaSeleccionado != null)
            {
                if (PresupuestoTecnicaSeleccionado.Id > 0)
                {
                    servicios.EliminarPresupuestoTecnica(PresupuestoTecnicaSeleccionado);

                    PresupuestoTecnicaSeleccionado = null;
                }
            }
            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                        TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);
            UpdatePanelCabecera.Update();
            UpdatePanelAdicionales.Update();
        }

        protected void ButtonNoCotizarBarra_Click(object sender, EventArgs e)
        {
            PasoBarra = "N";

            DropDownListPreciosBarras.Items.Clear();
            TextBoxCotizacionBarras.Text = "";
            TextBoxComisionBarras.Text = "";
            TextBoxPrecioSeleccionadoBarra.Text = "";
            TextBoxDescuentoBarra.Text = "";

            if (PresupuestoBarraSeleccionado != null)
            {
                if (PresupuestoBarraSeleccionado.Id > 0)
                {
                    servicios.EliminarPresupuestoBarra(PresupuestoBarraSeleccionado);

                    PresupuestoBarraSeleccionado = null;
                }
            }

            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                        TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);

            UpdatePanelCabecera.Update();
            UpdatePanelAdicionales.Update();
        }

        protected void ButtonNoCotizarAmbientacion_Click(object sender, EventArgs e)
        {
            PasoAmbientacion = "N";

            DropDownListPreciosAmbientacion.Items.Clear();
            TextBoxCotizacionAmbientacion.Text = "";
            TextBoxComisionAmbientacion.Text = "";
            TextBoxPrecioSeleccionadoAmbientacion.Text = "";
            TextBoxDescuentoAmbientacion.Text = "";

            if (PresupuestoAmbientacionSeleccionado != null)
            {
                if (PresupuestoAmbientacionSeleccionado.Id > 0)
                {
                    servicios.EliminarPresupuestoAmbientacion(PresupuestoAmbientacionSeleccionado);

                    PresupuestoAmbientacionSeleccionado = null;
                }
            }
            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);



            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                        TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);

            UpdatePanelCabecera.Update();
            UpdatePanelAdicionales.Update();
        }

        #endregion

        protected void ButtonQuitarAdicional_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewAdicionalesSeleccionados.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxQuitarSeleccionAdicional") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.PresupuestoAdicionales adicionales = new DomainAmbientHouse.Entidades.PresupuestoAdicionales();

                    adicionales.AdicionalId = Int32.Parse(row.Cells[0].Text);
                    adicionales.Descripcion = row.Cells[1].Text;
                    adicionales.Cantidad = Int32.Parse(row.Cells[2].Text);

                    var itemRemove = ListAdicionales.Where(o => o.AdicionalId == adicionales.AdicionalId).Single();

                    ListAdicionales.Remove(itemRemove);
                }

            }

            var query = from L in ListAdicionales select L.ValorAdicional;
            var queryComisiones = from L in ListAdicionales select L.Comision;

            TextBoxComisionAdicional.Text = queryComisiones.Sum().ToString();
            TextBoxCotizacionAdicionales.Text = query.Sum().ToString();
            GridViewAdicionalesSeleccionados.DataSource = ListAdicionales.ToList();
            GridViewAdicionalesSeleccionados.DataBind();

            UpdatePanelAdicionales.Update();
        }

        protected void CheckBoxAsignarOtroEjecutivo_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListOtroEjecutivo.Visible = CheckBoxAsignarOtroEjecutivo.Checked;

            UpdatePanelComentario.Update();
        }

        protected void ButtonClienteAsignarOtroEjecutivo_Click(object sender, EventArgs e)
        {
            Grabar();
            Response.Redirect("~/Inicio/Default.aspx");
        }

        protected void DropDownListExperiencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCanonCatering.Text = ObtenerCostoCanon(Int32.Parse(DropDownListSegmentos.SelectedItem.Value),
                                                                          Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value), Int32.Parse(DropDownListExperiencias.SelectedItem.Value)).ToString();

        }

        private object ObtenerCostoCanon(int segmentoId, int caracteriticaId, int TipoCateringId)
        {




            CostoCanon costoCanon = servicios.BuscarCostoCanon(segmentoId,
                                                                 caracteriticaId,
                                                                 TipoCateringId);


            if (costoCanon != null)
            {
                return costoCanon.CanonInterno.ToString();
            }
            else
            { return "Sin Valor"; }


        }

        protected void TextBoxDescuentosSalon_TextChanged(object sender, EventArgs e)
        {
            Descuentos();
        }


        protected void TextBoxDescuentoCatering_TextChanged(object sender, EventArgs e)
        {
            Descuentos();
        }

        protected void TextBoxDescuentoTecnica_TextChanged(object sender, EventArgs e)
        {
            Descuentos();
        }

        protected void TextBoxDescuentoBarra_TextChanged(object sender, EventArgs e)
        {
            Descuentos();
        }

        protected void TextBoxDescuentoAmbientacion_TextChanged(object sender, EventArgs e)
        {
            Descuentos();
        }


        private void Descuentos()
        {
            double Descuento = 0;

            Descuento = CalcularTotalDescuentos(TextBoxDescuentosSalon.Text, TextBoxDescuentoCatering.Text, TextBoxDescuentoTecnica.Text, TextBoxDescuentoBarra.Text, TextBoxDescuentoAmbientacion.Text);


            CalcularTotalPresupuesto(TextBoxCotizacionSalon.Text, TextBoxCotizacionCatering.Text, TextBoxCanonCatering.Text, TextBoxLogisticaCatering.Text, TextBoxCotizacionTecnica.Text, TextBoxCotizacionBarras.Text,
                                          TextBoxCanonBarras.Text, TextBoxLogisticaBarras.Text, TextBoxCotizacionAmbientacion.Text, TextBoxAjustePrecio.Text, TextBoxCotizacionAdicionales.Text, Descuento);

            UpdatePanelCabecera.Update();
        }

        protected void DropDownListDuracionEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());

            CargarListasTipoCateringTipoTecnica();
        }

        protected void DropDownListMomentodelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            MomentoDiaId = Int32.Parse(DropDownListMomentodelDia.SelectedItem.Value.ToString());

            CargarListasTipoCateringTipoTecnica();
        }

        protected void DropDownListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}