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

namespace AmbientHouse.Presupuestos
{
    public partial class RePresupuestar : System.Web.UI.Page
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

        private PresupuestoPDF Presupuestos
        {
            get { return (PresupuestoPDF)HttpContext.Current.Session["PresupuestoCliente"]; }
            set { HttpContext.Current.Session["PresupuestoCliente"] = value; }
        }

        AdministrativasServicios administrativas = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
                RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
                RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
                RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
                RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

                RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
                RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

                ListPresupuestoDetalleModificado = new List<PresupuestoDetalle>();

                InicializarPagina();

                PanelVisorPDF.Visible = false;
                PanelCotixador.Visible = true;
            }
        }

        private void InicializarPagina()
        {

            GridViewVentas.Visible = false;
            TextBoxTotalRenta.Visible = false;
            LabelRentaTotal.Visible = false;

            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());


            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;

                TextBoxNroEvento.Text = EventoId.ToString().PadLeft(8, '0');


            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
                TextBoxNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');
            }

            CargarEvento();

            CargarPresupuesto();

            List<PresupuestoDetalle> ListPresuDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);


            foreach (var item in ListPresuDetalle)
            {

                PresupuestoDetalle det = AgregarItem(item, PresupuestoSeleccionado);

                ListPresupuestoDetalleModificado.Add(det);
            }



            GridViewVentas.DataSource = ListPresupuestoDetalleModificado.ToList();
            GridViewVentas.DataBind();

            GridViewVentas.Visible = true;


            double Valor = cmd.CalcularTotalPresupuesto(ListPresuDetalle, 0, 0);


            double valorOrganizador = 0;

            if (PresupuestoSeleccionado.PorcentajeOrganizador > 0)
            {

                //double resta = Valor - double.Parse(PresupuestoSeleccionado.ValorOrganizador.ToString());
                double porcentaje = (double.Parse(PresupuestoSeleccionado.PorcentajeOrganizador.ToString()) / 100);

                TextBoxTotalOrganizador.Text =  System.Math.Round(Valor * porcentaje).ToString("C");

                valorOrganizador = System.Math.Round(Valor * porcentaje);
            }
            else if (PresupuestoSeleccionado.ImporteOrganizador > 0)
            {
                TextBoxTotalOrganizador.Text = System.Math.Round(double.Parse(PresupuestoSeleccionado.ImporteOrganizador.ToString()), 2).ToString("C");

                valorOrganizador = System.Math.Round(double.Parse(PresupuestoSeleccionado.ImporteOrganizador.ToString()), 2);
            }
            else
            {
                TextBoxTotalOrganizador.Text = "0";
            }

            TextBoxTotalPresupuesto.Text = System.Math.Round(Valor + valorOrganizador, 2).ToString("C");

            TextBoxTotalPAX.Text = System.Math.Round(((Valor + valorOrganizador) / CantidadTotalInvitados), 2).ToString("C");
        }

        private PresupuestoDetalle AgregarItem(PresupuestoDetalle detalle, DomainAmbientHouse.Entidades.Presupuestos presupuesto)
        {
            int productoNinguno = Int32.Parse(ConfigurationManager.AppSettings["ProductoSalonSinCosto"].ToString());

            int PresupuestoDetallePendiente =
                Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());
            int cantidadAductos = 0;
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


            CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text,
                TextBoxCantAdolescentes.Text);

            if (cmd.IsNumeric(TextBoxCantMayores.Text))
                cantidadAductos = Int32.Parse(TextBoxCantMayores.Text);

            if (cmd.IsNumeric(TextBoxCantAdolescentes.Text))
                cantidadAdolescentes = Int32.Parse(TextBoxCantAdolescentes.Text);


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

                    if (detalle.Logistica > 0) //No actualiza la logistica
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


                default: //ORGANIZACION

                    ServicioId = Int32.Parse(detalle.ServicioId.ToString());
                    ProveedorId = Int32.Parse(detalle.ProveedorId.ToString());
                    Codigo = cmd.ArmarCodigoOrganizacion(ServicioId,
                        ProveedorId,
                        CantidadTotalInvitados);

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

                detalle.EstadoId = PresupuestoDetallePendiente;
                detalle.CantidadAdicional = cantidadAdicional;


                return detalle = presupuestos.AddItem(detalle, producto, (int)presupuesto.LocacionId, cantidadAductos,
                    cantidadAdolescentes,
                    CantidadTotalInvitados,ListPresupuestoDetalleModificado);


            }

            return new PresupuestoDetalle();


        }

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {


            CantidadTotalInvitados = Int32.Parse(cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes).ToString());

        }

        private void CargarEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = eventos.BuscarEvento(EventoId);

            TextBoxCientesApellido.Text = EventoSeleccionado.ApellidoNombreCliente;


            ClienteId = EventoSeleccionado.ClienteId;

            TextBoxComentarioEvento.Text = EventoSeleccionado.Comentario;

        }

        private void CargarPresupuesto()
        {
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);

                TextBoxCantMayores.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) TextBoxCantAdolescentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) TextBoxCantMenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) TextBoxCantEntre3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();


                TextBoxFechaDesdeEvento.Text = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);


                double Valor = presupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

                LabelCaracteristica.Text = eventos.TraerCaracteristicas().Where(o => o.Id == PresupuestoSeleccionado.CaracteristicaId).Select(o => o.Descripcion).SingleOrDefault();
                LabelSegmentos.Text = eventos.TraerSegmentos().Where(o => o.Id == PresupuestoSeleccionado.SegmentoId).Select(o => o.Descripcion).SingleOrDefault();
                LabelTipoEvento.Text = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();
                LabelJornada.Text = eventos.TraerJornadas().Where(o => o.Id == PresupuestoSeleccionado.JornadaId).Select(o => o.Descripcion).SingleOrDefault();
                LabelMomentodelDia.Text = administrativas.ObtenerMomentosDias().Where(o => o.Id == PresupuestoSeleccionado.MomentoDiaID).Select(o => o.Descripcion).SingleOrDefault();
                LabelDuraciondelEvento.Text = administrativas.ObtenerDuracionEvento().Where(o => o.Id == PresupuestoSeleccionado.DuracionId).Select(o => o.Descripcion).SingleOrDefault();

                LabelHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;
                LabelHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;

                TextBoxComentarioPresupuesto.Text = PresupuestoSeleccionado.Comentario;

                LabelLocaciones.Text = eventos.TraerLocaciones().Where(o => o.Id == PresupuestoSeleccionado.LocacionId).Select(o => o.Descripcion).SingleOrDefault();

                if (PresupuestoSeleccionado.SectorId != null)
                {
                    LabelSector.Text = administrativas.BuscarSector((int)PresupuestoSeleccionado.SectorId).Descripcion;
                }

                CalcularCantidadInvitados(TextBoxCantMayores.Text, TextBoxCantEntre3y8.Text, TextBoxCantMenores3.Text, TextBoxCantAdolescentes.Text);

                TextBoxTotalPresupuesto.Text = System.Math.Round(Valor, 2).ToString("C");

                TextBoxTotalPAX.Text = System.Math.Round((Valor / CantidadTotalInvitados), 2).ToString("C");

                TextBoxTotalOrganizador.Text = PresupuestoSeleccionado.ValorOrganizador.ToString();

            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presupuestos/GestionPorEvento.aspx?Id=" + EventoId);
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            
            int PresupuestoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());


            PresupuestoSeleccionado.Id = 0;
            PresupuestoSeleccionado.EstadoId = PresupuestoEnviado;
            PresupuestoSeleccionado.FechaPresupuesto = System.DateTime.Now;

            eventos.RePresupuestarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalleModificado);

            PanelVisorPDF.Visible = true;
            PanelCotixador.Visible = false;

            PresupuestoId = PresupuestoSeleccionado.Id;

            EventoId = EventoSeleccionado.Id;

            Presupuestos = new PresupuestoPDF();

            Presupuestos = presupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presupuestos/GestionPorEvento.aspx?Id=" + EventoId);
        }


    }
}