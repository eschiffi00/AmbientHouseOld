using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Organizador.Planificacion
{
    public partial class Editar : System.Web.UI.Page
    {
        private string Fecha
        {
            get
            {
                return Session["FechaOR"].ToString();
            }
            set
            {
                Session["FechaOR"] = value;
            }
        }

        private int EventoId
        {
            get
            {
                return Int32.Parse(Session["EventoIdOR"].ToString());
            }
            set
            {
                Session["EventoIdOR"] = value;
            }
        }

        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(Session["PresupuestoIdOR"].ToString());
            }
            set
            {
                Session["PresupuestoIdOR"] = value;
            }
        }

        private int ClienteId
        {
            get
            {
                return Int32.Parse(Session["ClienteIdOR"].ToString());
            }
            set
            {
                Session["ClienteIdOR"] = value;
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

        private DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle OrganizacionDetalle
        {
            get
            {
                return Session["OrganizacionDetalleSeleccionado"] as DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle;
            }
            set
            {
                Session["OrganizacionDetalleSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos> ProveedoresExternos
        {
            get
            {
                return Session["ProveedoresExternosSeleccionado"] as List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos>;
            }
            set
            {
                Session["ProveedoresExternosSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoTimming> OrganizacionTimming
        {
            get
            {
                return Session["OrganizacionTimmingSeleccionado"] as List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoTimming>;
            }
            set
            {
                Session["OrganizacionTimmingSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos> OrganizacionArchivos
        {
            get
            {
                return Session["OrganizacionArchivosSeleccionado"] as List<DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos>;
            }
            set
            {
                Session["OrganizacionArchivosSeleccionado"] = value;
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
                ProveedoresExternos = new List<OrganizacionPresupuestoProveedoresExternos>();
                OrganizacionTimming = new List<OrganizacionPresupuestoTimming>();
                OrganizacionArchivos = new List<OrganizacionPresupuestosArchivos>();

                LabelMensajeInvitados.Visible = false;
                LabelMensaje.Visible = false;

                LabelHoraArmadoLogistica.Visible = false;
                LabelHoraArmadoSalon.Visible = false;

                InicializarPagina();

                //MailPresentacion();
            }
        }

        private void InicializarPagina()
        {

            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            string mail = "";
            string telefono = "";
            string direccion = "";
            string locacion = "";


            if (Request["EventoId"] != null)
            {

                EventoId = Int32.Parse(Request["EventoId"]);

                LabelNroEvento.Text = EventoId.ToString().PadLeft(8, '0');
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
                LabelNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle detalle = eventos.BuscarOrganizacionDetallePorPresupuesto(PresupuestoId);

                if (detalle != null)
                {
                    id = detalle.Id;
                    mail = detalle.Mail;
                    telefono = detalle.Tel;
                    direccion = detalle.Direccion;
                    locacion = detalle.LocacionOtra;


                }

                ProveedoresExternos = administrativas.ObtenerProveedoresExternosPorPresupuesto(PresupuestoId);

                OrganizacionTimming = administrativas.ObtenerTimmingPorPresupuesto(PresupuestoId);

                OrganizacionArchivos = administrativas.ObtenerArchivosPorPresupuesto(PresupuestoId);

            }

            CargarEvento(mail, telefono);

            CargarPresupuesto(direccion, locacion);

            if (id == 0)
                NuevaOrganizacionDetalle();
            else
                EditarOrganizacionDetalle(id);

            SetFocus(TextBoxBocados);

            GridViewArchivo.DataSource = OrganizacionArchivos.ToList();
            GridViewArchivo.DataBind();

            GridViewTimming.DataSource = OrganizacionTimming.ToList();
            GridViewTimming.DataBind();

            GridViewProveedoresExternos.DataSource = ProveedoresExternos.ToList();
            GridViewProveedoresExternos.DataBind();

            GridViewCatering.DataSource = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 3 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();
            GridViewCatering.DataBind();

            GridViewBarras.DataSource = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 6 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();
            GridViewBarras.DataBind();

            GridViewAdicionales.DataSource = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 9 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();
            GridViewAdicionales.DataBind();

            GridViewAmbientacion.DataSource = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 1 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();
            GridViewAmbientacion.DataBind();

            GridViewTecnica.DataSource = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 2 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();
            GridViewTecnica.DataBind();

            GridViewOtros.DataSource = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 8 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();
            GridViewOtros.DataBind();

        }

        private void EditarOrganizacionDetalle(int id)
        {
            DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle organizacionDetalle = new DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle();

            organizacionDetalle = eventos.BuscarOrganizacionDetalle(id);

            OrganizacionDetalle = organizacionDetalle;

            TextBoxMotivo.Text = OrganizacionDetalle.MotivoFestejo;

            TextBoxMail.Text = OrganizacionDetalle.Mail;
            TextBoxTelefono.Text = OrganizacionDetalle.Tel;

            TextBoxLocacionOtra.Text = OrganizacionDetalle.LocacionOtra;
            TextBoxDireccionLocacion.Text = OrganizacionDetalle.Direccion;


            DropDownListMailPresentacionSiNo.SelectedValue = OrganizacionDetalle.EnvioMailPresentacion;

            DropDownListSeRealizoReunionCliente.SelectedValue = OrganizacionDetalle.RealizoReunionConCliente;

            if (OrganizacionDetalle.FechaMailPresentacion != null)
                TextBoxFechaMailPresentacion.Text = String.Format("{0:dd/MM/yyyy}", OrganizacionDetalle.FechaMailPresentacion);


            TextBoxBocados.Text = OrganizacionDetalle.Bocados;
            TextBoxIslas.Text = OrganizacionDetalle.Islas;
            TextBoxEntrada.Text = organizacionDetalle.Entrada;
            TextBoxPrincipalAdultos.Text = OrganizacionDetalle.PrincipalAdultos;
            TextBoxPrincipalAdolescentes.Text = OrganizacionDetalle.PrincipalAdolescentes;
            TextBoxPostreAdultosAdolescentes.Text = OrganizacionDetalle.PostreAdultosAdolescentes;
            TextBoxPrincipalMenores.Text = OrganizacionDetalle.PrincipalChicos;
            TextBoxPostreMenores.Text = OrganizacionDetalle.PostreChicos;
            TextBoxMesaDulce.Text = OrganizacionDetalle.MesaDulce;
            TextBoxFindeFiesta.Text = OrganizacionDetalle.FinFiesta;

            TextBoxVinoChampagne.Text = OrganizacionDetalle.ServiciodeVinoChampagne;
            TextBoxObservacionesBarras.Text = OrganizacionDetalle.ObservacionBarras;

            TextBoxMesaPrincipal.Text = OrganizacionDetalle.MesaPrincipal;
            TextBoxManteleria.Text = OrganizacionDetalle.Manteleria;
            TextBoxServilletas.Text = OrganizacionDetalle.Servilletas;
            TextBoxSillas.Text = OrganizacionDetalle.Sillas;
            TextBoxInvitadosDespuesde00.Text = OrganizacionDetalle.InvitadosDespues00;
            TextBoxCumpleenelEvento.Text = OrganizacionDetalle.CumpleaniosEnEvento;
            TextBoxTortaAlegorica.Text = OrganizacionDetalle.TortaAlegorica;
            TextBoxLlegaSalon.Text = OrganizacionDetalle.LleganAlSalon;
            TextBox1PlatosEspecciales.Text = OrganizacionDetalle.PlatosEspeciales;

            TextBoxObservacionesAmbientacion.Text = OrganizacionDetalle.ObservacionAmbientacion;
            TextBoxObservacionesCatering.Text = OrganizacionDetalle.ObservacionCatering;
            TextBoxObservacionesAdicionales.Text = OrganizacionDetalle.ObservacionesAdicionales;
            TextBoxObservacionesParticularidades.Text = OrganizacionDetalle.ObservacionParticulares;
            TextBoxObservacionesTecnica.Text = OrganizacionDetalle.ObservacionTecnica;

            TextBoxListaCocheras.Text = OrganizacionDetalle.ListaCocheras;
            TextBoxAcreditaciones.Text = OrganizacionDetalle.Acreditaciones;
            TextBoxListadeInvitados.Text = OrganizacionDetalle.ListaInvitados;

            TextBoxLayout.Text = OrganizacionDetalle.Layout;
            TextBoxAlfombraRoja.Text = OrganizacionDetalle.AlfombraRoja;
            TextBoxAnexo7.Text = OrganizacionDetalle.Anexo7;
            DropDownListEscenario.SelectedValue = OrganizacionDetalle.Escenario;
            DropDownListRamo.SelectedValue = OrganizacionDetalle.Ramo;

            TextBoxContactoDireccionProveedoresIngresoLugar.Text = OrganizacionDetalle.IngresoProveedoresLugar;
            TextBoxContactoResponsableLugar.Text = OrganizacionDetalle.ContactoResponsableLugar;
            TextBoxContactoTelefonoLugar.Text = OrganizacionDetalle.TelefonoResponsableLugar;

            TextBoxDiaArmadoLogistica.Text = OrganizacionDetalle.FechaArmadoLogistica;
            TextBoxDiaArmadoSalon.Text = OrganizacionDetalle.FechaArmadoSalon;
            TextBoxDiaDesarmadoSalon.Text = OrganizacionDetalle.HoraDesarmadoSalon;

            TextBoxHoraArmadoLogistica.Text = OrganizacionDetalle.HoraArmadoLogistica;
            TextBoxHoraArmadoSalon.Text = OrganizacionDetalle.HoraArmadoSalon;
            TextBoxHoraDesarmadoSalon.Text = OrganizacionDetalle.HoraDesarmadoSalon;

            TextBoxCantPersonasAfectadasArmado.Text = OrganizacionDetalle.CantPersonasAfectadasArmado;

            this.ImageButtonSePidioHielo.ImageUrl = !this.OrganizacionDetalle.SePidioHielo ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
            this.ImageButtonSePidioLogitica.ImageUrl = !this.OrganizacionDetalle.SePidioLogistica ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
            this.ImageButtonSePidioManteleria.ImageUrl = !this.OrganizacionDetalle.SePidioManteleria ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
            this.ImageButtonSePidioMoviliario.ImageUrl = !this.OrganizacionDetalle.SePidioMoviliario ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
            this.TextBoxObservacionesHielo.Text = this.OrganizacionDetalle.ObservacionesHielo;
            this.TextBoxObservacionesLogistica.Text = this.OrganizacionDetalle.ObservacionesLogistica;
            this.TextBoxObservacionesManteleria.Text = this.OrganizacionDetalle.ObservacionesManteleria;
            this.TextBoxObservacionesMoviliario.Text = this.OrganizacionDetalle.ObservacionesMoviliario;


            EstadoCampos();


        }

        private void EstadoCampos()
        {


            TextBoxBocados.ReadOnly = false;
            TextBoxIslas.ReadOnly = false;
            TextBoxEntrada.ReadOnly = false;
            TextBoxPrincipalAdultos.ReadOnly = false;
            TextBoxPrincipalAdolescentes.ReadOnly = false;
            TextBoxPostreAdultosAdolescentes.ReadOnly = false;
            TextBoxPrincipalMenores.ReadOnly = false;
            TextBoxPostreMenores.ReadOnly = false;
            TextBoxMesaDulce.ReadOnly = false;
            TextBoxFindeFiesta.ReadOnly = false;
            TextBoxVinoChampagne.ReadOnly = false;
            TextBoxMesaPrincipal.ReadOnly = false;
            TextBoxManteleria.ReadOnly = false;
            TextBoxServilletas.ReadOnly = false;
            TextBoxSillas.ReadOnly = false;
            TextBoxInvitadosDespuesde00.ReadOnly = false;
            TextBoxCumpleenelEvento.ReadOnly = false;
            TextBoxTortaAlegorica.ReadOnly = false;
            TextBoxLlegaSalon.ReadOnly = false;
            TextBox1PlatosEspecciales.ReadOnly = false;
            TextBoxAcreditaciones.ReadOnly = false;
            TextBoxListadeInvitados.ReadOnly = false;
            TextBoxListaCocheras.ReadOnly = false;
            TextBoxAnexo7.ReadOnly = false;
            TextBoxLayout.ReadOnly = false;
            TextBoxAlfombraRoja.ReadOnly = false;

            System.Drawing.Color color = System.Drawing.Color.BlueViolet;
            bool Bold = true;



            if (OrganizacionDetalle.BocadosEstado)
            {
                TextBoxBocados.Font.Bold = Bold;
                TextBoxBocados.ForeColor = color;
                TextBoxBocados.ReadOnly = true;

                ImageButtonBocados.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonBocados.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.IslasEstado)
            {
                TextBoxIslas.Font.Bold = Bold;
                TextBoxIslas.ForeColor = color;
                TextBoxIslas.ReadOnly = true;

                ImageButtonIslas.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonIslas.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.EntradaEstado)
            {
                TextBoxEntrada.Font.Bold = Bold;
                TextBoxEntrada.ForeColor = color;
                TextBoxEntrada.ReadOnly = true;

                ImageButtonEntrada.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonEntrada.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.PrincipalAdultosEstado)
            {
                TextBoxPrincipalAdultos.Font.Bold = Bold;
                TextBoxPrincipalAdultos.ForeColor = color;
                TextBoxPrincipalAdultos.ReadOnly = true;

                ImageButtonPrincipalAdultos.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonPrincipalAdultos.ImageUrl = "~/Content/Imagenes/noaprobado.png";



            if (OrganizacionDetalle.PrincipalAdolescentesEstado)
            {
                TextBoxPrincipalAdolescentes.Font.Bold = Bold;
                TextBoxPrincipalAdolescentes.ForeColor = color;
                TextBoxPrincipalAdolescentes.ReadOnly = true;
                ImageButtonPrincipalAdolescentes.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonPrincipalAdolescentes.ImageUrl = "~/Content/Imagenes/noaprobado.png";



            if (OrganizacionDetalle.PostreAdultosAdolescentesEstado)
            {
                TextBoxPostreAdultosAdolescentes.Font.Bold = Bold;
                TextBoxPostreAdultosAdolescentes.ForeColor = color;
                TextBoxPostreAdultosAdolescentes.ReadOnly = true;

                ImageButtonPostreAdultosAdolescentes.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonPostreAdultosAdolescentes.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.PrincipalChicosEstado)
            {
                TextBoxPrincipalMenores.Font.Bold = Bold;
                TextBoxPrincipalMenores.ForeColor = color;
                TextBoxPrincipalMenores.ReadOnly = true;
                ImageButtonPrincipalMenores.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonPrincipalMenores.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.PostreChicosEstado)
            {
                TextBoxPostreMenores.Font.Bold = Bold;
                TextBoxPostreMenores.ForeColor = color;
                TextBoxPostreMenores.ReadOnly = true;
                ImageButtonPostreMenores.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonPostreMenores.ImageUrl = "~/Content/Imagenes/noaprobado.png";



            if (OrganizacionDetalle.MesaDulceEstado)
            {
                TextBoxMesaDulce.Font.Bold = Bold;
                TextBoxMesaDulce.ForeColor = color;
                TextBoxMesaDulce.ReadOnly = true;

                ImageButtonMesaDulce.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonMesaDulce.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.FinFiestaEstado)
            {
                TextBoxFindeFiesta.Font.Bold = Bold;
                TextBoxFindeFiesta.ForeColor = color;
                TextBoxFindeFiesta.ReadOnly = true;

                ImageButtonFindeFiesta.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonFindeFiesta.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.ServiciodeVinoChampagneEstado)
            {
                TextBoxVinoChampagne.Font.Bold = Bold;
                TextBoxVinoChampagne.ForeColor = color;
                TextBoxVinoChampagne.ReadOnly = true;

                ImageButtonVinoChampagne.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonVinoChampagne.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.MesaPrincipalEstado)
            {
                TextBoxMesaPrincipal.Font.Bold = Bold;
                TextBoxMesaPrincipal.ForeColor = color;
                TextBoxMesaPrincipal.ReadOnly = true;

                ImageButtonMesaPrincipal.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonMesaPrincipal.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.ManteleriaEstado)
            {
                TextBoxManteleria.Font.Bold = Bold;
                TextBoxManteleria.ForeColor = color;
                TextBoxManteleria.ReadOnly = true;

                ImageButtonManteleria.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonManteleria.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.ServilletasEstado)
            {
                TextBoxServilletas.Font.Bold = Bold;
                TextBoxServilletas.ForeColor = color;
                TextBoxServilletas.ReadOnly = true;

                ImageButtonServilletas.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonServilletas.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.SillasEstado)
            {
                TextBoxSillas.Font.Bold = Bold;
                TextBoxSillas.ForeColor = color;
                TextBoxSillas.ReadOnly = true;

                ImageButtonSillas.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonSillas.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.InvitadosDespues00Estado)
            {
                TextBoxInvitadosDespuesde00.Font.Bold = Bold;
                TextBoxInvitadosDespuesde00.ForeColor = color;
                TextBoxInvitadosDespuesde00.ReadOnly = true;

                ImageButtonInvitadosDespuesde00.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonInvitadosDespuesde00.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.CumpleaniosEnEventoEstado)
            {
                TextBoxCumpleenelEvento.Font.Bold = Bold;
                TextBoxCumpleenelEvento.ForeColor = color;
                TextBoxCumpleenelEvento.ReadOnly = true;

                ImageButtonCumpleenelEvento.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonCumpleenelEvento.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.TortaAlegoricaEstado)
            {
                TextBoxTortaAlegorica.Font.Bold = Bold;
                TextBoxTortaAlegorica.ForeColor = color;
                TextBoxTortaAlegorica.ReadOnly = true;

                ImageButtonTortaAlegorica.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonTortaAlegorica.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.LleganAlSalonEstado)
            {
                TextBoxLlegaSalon.Font.Bold = Bold;
                TextBoxLlegaSalon.ForeColor = color;
                TextBoxLlegaSalon.ReadOnly = true;

                ImageButtonLlegaSalon.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonLlegaSalon.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.PlatosEspecialesEstado)
            {
                TextBox1PlatosEspecciales.Font.Bold = Bold;
                TextBox1PlatosEspecciales.ForeColor = color;
                TextBox1PlatosEspecciales.ReadOnly = true;

                ImageButtonPlatosEspeciales.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonPlatosEspeciales.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.AcreditacionesEstado)
            {
                TextBoxAcreditaciones.Font.Bold = Bold;
                TextBoxAcreditaciones.ForeColor = color;
                TextBoxAcreditaciones.ReadOnly = true;

                ImageButtonAcreditaciones.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonAcreditaciones.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.ListaInvitadosEstado)
            {
                TextBoxListadeInvitados.Font.Bold = Bold;
                TextBoxListadeInvitados.ForeColor = color;
                TextBoxListadeInvitados.ReadOnly = true;

                ImageButtonListaInvitados.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonListaInvitados.ImageUrl = "~/Content/Imagenes/noaprobado.png";

            if (OrganizacionDetalle.ListaCocherasEstado)
            {
                TextBoxListaCocheras.Font.Bold = Bold;
                TextBoxListaCocheras.ForeColor = color;
                TextBoxListaCocheras.ReadOnly = true;

                ImageButtonListaCocheras.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonListaCocheras.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.LayoutEstado)
            {
                TextBoxLayout.Font.Bold = Bold;
                TextBoxLayout.ForeColor = color;
                TextBoxLayout.ReadOnly = true;

                ImageButtonLayout.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonLayout.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.AlfombraRojaEstado)
            {
                TextBoxAlfombraRoja.Font.Bold = Bold;
                TextBoxAlfombraRoja.ForeColor = color;
                TextBoxAlfombraRoja.ReadOnly = true;

                ImageButtonAlfombraRoja.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonAlfombraRoja.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            if (OrganizacionDetalle.Anexo7Estado)
            {
                TextBoxAnexo7.Font.Bold = Bold;
                TextBoxAnexo7.ForeColor = color;
                TextBoxAnexo7.ReadOnly = true;

                ImageButtonAnexo7.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
            else
                ImageButtonAnexo7.ImageUrl = "~/Content/Imagenes/noaprobado.png";


        }

        private void NuevaOrganizacionDetalle()
        {
            OrganizacionDetalle = new DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle();


            OrganizacionDetalle.BocadosEstado = false;
            OrganizacionDetalle.IslasEstado = false;
            OrganizacionDetalle.EntradaEstado = false;
            OrganizacionDetalle.CumpleaniosEnEventoEstado = false;
            OrganizacionDetalle.FinFiestaEstado = false;
            OrganizacionDetalle.InvitadosDespues00Estado = false;
            OrganizacionDetalle.LleganAlSalonEstado = false;
            OrganizacionDetalle.ManteleriaEstado = false;
            OrganizacionDetalle.MesaDulceEstado = false;
            OrganizacionDetalle.MesaPrincipalEstado = false;
            OrganizacionDetalle.PlatosEspecialesEstado = false;
            OrganizacionDetalle.PostreAdultosAdolescentesEstado = false;
            OrganizacionDetalle.PostreChicosEstado = false;
            OrganizacionDetalle.PrincipalAdolescentesEstado = false;
            OrganizacionDetalle.PrincipalAdultosEstado = false;
            OrganizacionDetalle.PrincipalChicosEstado = false;
            OrganizacionDetalle.ServiciodeVinoChampagneEstado = false;
            OrganizacionDetalle.ServilletasEstado = false;
            OrganizacionDetalle.SillasEstado = false;
            OrganizacionDetalle.TortaAlegoricaEstado = false;
            OrganizacionDetalle.AcreditacionesEstado = false;
            OrganizacionDetalle.ListaInvitadosEstado = false;
            OrganizacionDetalle.ListaCocherasEstado = false;
            OrganizacionDetalle.LayoutEstado = false;
            OrganizacionDetalle.AlfombraRojaEstado = false;
            OrganizacionDetalle.Anexo7Estado = false;

            EstadoCampos();


        }

        private void CargarEvento(string mail, string telefono)
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = eventos.BuscarEvento(EventoId);

            LabelCliente.Text = EventoSeleccionado.ApellidoNombreCliente;

            ClienteId = (int)EventoSeleccionado.ClienteBisId;

            ClientesServicios clienteServicios = new ClientesServicios();

            ClientesBis cliente = clienteServicios.BuscarCliente(ClienteId);


            if (cliente.ApellidoNombre != "")
            {
                LabelCliente.Text = cliente.ApellidoNombre.ToUpper();
            }
            else if (cliente.RazonSocial != "")
            {
                LabelCliente.Text = cliente.RazonSocial.ToUpper();
            }
            else
                LabelCliente.Text = "";

            if (mail == "")
                TextBoxMail.Text = cliente.MailContactoContratacion;

            if (telefono == "")
                TextBoxTelefono.Text = cliente.TelContactoContratacion;

            LabelVendedor.Text = administrativas.BuscarEmpleado((int)EventoSeleccionado.EmpleadoId).ApellidoNombre;

        }

        private void CargarPresupuesto(string direccion, string locacion)
        {
            PresupuestoSeleccionado = new DomainAmbientHouse.Entidades.Presupuestos();

            if (PresupuestoId > 0)
            {
                PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);

                TextBoxCantAdultos.Text = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

                if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) TextBoxAdolecentes.Text = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) TextBoxMenores3.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();
                if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) TextBoxMenores3y8.Text = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();


                LabelFechaEvento.Text = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);

                Fecha = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);

                LabelTipoEvento.Text = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();

                LabelCaracteristicas.Text = eventos.TraerCaracteristicas().Where(o => o.Id == PresupuestoSeleccionado.CaracteristicaId).Select(o => o.Descripcion).SingleOrDefault();


                TextBoxHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;
                TextBoxHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;

                TextBoxComentario.Text = PresupuestoSeleccionado.Comentario;

                if (direccion != "")
                    TextBoxDireccionLocacion.Text = direccion;
                else
                    TextBoxDireccionLocacion.Text = PresupuestoSeleccionado.DireccionOtra;

                if (locacion != "")
                    TextBoxLocacionOtra.Text = locacion;
                else
                    TextBoxLocacionOtra.Text = PresupuestoSeleccionado.LocacionOtra;

                EmpleadosPresupuestosAprobados existeEquipo = administrativas.BuscarEquiposPorPresupuesto((int)PresupuestoId);

                int? OrganizadorId = 0;

                if (existeEquipo != null)
                    OrganizadorId = existeEquipo.OrganizadorId;

                if (OrganizadorId > 0)
                    LabelOrganizador.Text = administrativas.BuscarEmpleado((int)OrganizadorId).ApellidoNombre;

                string Locacion = eventos.BuscarLocacion(PresupuestoSeleccionado.LocacionId).Descripcion;

                if (PresupuestoSeleccionado.SectorId != null)
                {
                    string sector = administrativas.BuscarSector((int)PresupuestoSeleccionado.SectorId).Descripcion;

                    LabelLocacion.Text = Locacion.ToUpper() + " (" + sector.ToUpper() + ")";

                    return;

                }

                LabelLocacion.Text = Locacion.ToUpper();

            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Session["EventoIdOR"] = "";
            Session["ClienteIdOR"] = "";
            Session["PresupuestoIdOR"] = "";

            Response.Redirect("~/Organizador/Index.aspx?FechaEvento=" + Fecha);
        }

        protected void ButtonGrabar_Click(object sender, EventArgs e)
        {
            Grabar();

            Response.Redirect("~/Organizador/Index.aspx?FechaEvento=" + Fecha);
        }

        private void Grabar()
        {

            if (ValidarHoraArmado())
            {
                DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle detalle = OrganizacionDetalle;

                detalle.PresupuestoId = Int32.Parse(Request["PresupuestoId"]);

                detalle.Direccion = TextBoxDireccionLocacion.Text;
                detalle.LocacionOtra = TextBoxLocacionOtra.Text;

                detalle.EnvioMailPresentacion = DropDownListMailPresentacionSiNo.SelectedItem.Value;

                if (TextBoxFechaMailPresentacion.Text.Length > 0)
                    detalle.FechaMailPresentacion = DateTime.ParseExact(TextBoxFechaMailPresentacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                detalle.RealizoReunionConCliente = DropDownListSeRealizoReunionCliente.SelectedItem.Value;


                detalle.Bocados = TextBoxBocados.Text;
                detalle.Islas = TextBoxIslas.Text;
                detalle.Entrada = TextBoxEntrada.Text;

                detalle.MotivoFestejo = TextBoxMotivo.Text;
                detalle.Mail = TextBoxMail.Text;
                detalle.Tel = TextBoxTelefono.Text;

                detalle.PrincipalAdultos = TextBoxPrincipalAdultos.Text;
                detalle.PrincipalAdolescentes = TextBoxPrincipalAdolescentes.Text;
                detalle.PostreAdultosAdolescentes = TextBoxPostreAdultosAdolescentes.Text;
                detalle.PrincipalChicos = TextBoxPrincipalMenores.Text;
                detalle.PostreChicos = TextBoxPostreMenores.Text;
                detalle.MesaDulce = TextBoxMesaDulce.Text;
                detalle.FinFiesta = TextBoxFindeFiesta.Text;

                detalle.ServiciodeVinoChampagne = TextBoxVinoChampagne.Text;
                detalle.ObservacionBarras = TextBoxObservacionesBarras.Text;

                detalle.MesaPrincipal = TextBoxMesaPrincipal.Text;
                detalle.Manteleria = TextBoxManteleria.Text;
                detalle.Servilletas = TextBoxServilletas.Text;
                detalle.Sillas = TextBoxSillas.Text;
                detalle.InvitadosDespues00 = TextBoxInvitadosDespuesde00.Text;
                detalle.CumpleaniosEnEvento = TextBoxCumpleenelEvento.Text;
                detalle.TortaAlegorica = TextBoxTortaAlegorica.Text;
                detalle.LleganAlSalon = TextBoxLlegaSalon.Text;
                detalle.PlatosEspeciales = TextBox1PlatosEspecciales.Text;


                detalle.ObservacionAmbientacion = TextBoxObservacionesAmbientacion.Text;
                detalle.ObservacionCatering = TextBoxObservacionesCatering.Text;
                detalle.ObservacionesAdicionales = TextBoxObservacionesAdicionales.Text;
                detalle.ObservacionParticulares = TextBoxObservacionesParticularidades.Text;
                detalle.ObservacionTecnica = TextBoxObservacionesTecnica.Text;

                detalle.BocadosEstado = OrganizacionDetalle.BocadosEstado;
                detalle.IslasEstado = OrganizacionDetalle.IslasEstado;
                detalle.EntradaEstado = OrganizacionDetalle.EntradaEstado;
                detalle.AcreditacionesEstado = OrganizacionDetalle.AcreditacionesEstado;
                detalle.FinFiestaEstado = OrganizacionDetalle.FinFiestaEstado;
                detalle.InvitadosDespues00Estado = OrganizacionDetalle.InvitadosDespues00Estado;
                detalle.ListaCocherasEstado = OrganizacionDetalle.ListaCocherasEstado;
                detalle.ListaInvitadosEstado = OrganizacionDetalle.ListaInvitadosEstado;
                detalle.LleganAlSalonEstado = OrganizacionDetalle.LleganAlSalonEstado;
                detalle.ManteleriaEstado = OrganizacionDetalle.ManteleriaEstado;
                detalle.MesaDulceEstado = OrganizacionDetalle.MesaDulceEstado;
                detalle.MesaPrincipalEstado = OrganizacionDetalle.MesaPrincipalEstado;
                detalle.PlatosEspecialesEstado = OrganizacionDetalle.PlatosEspecialesEstado;
                detalle.PostreAdultosAdolescentesEstado = OrganizacionDetalle.PostreAdultosAdolescentesEstado;
                detalle.PostreChicosEstado = OrganizacionDetalle.PostreChicosEstado;
                detalle.PrincipalAdolescentesEstado = OrganizacionDetalle.PrincipalAdolescentesEstado;
                detalle.PrincipalAdultosEstado = OrganizacionDetalle.PrincipalAdultosEstado;
                detalle.PrincipalChicosEstado = OrganizacionDetalle.PrincipalChicosEstado;
                detalle.ServiciodeVinoChampagneEstado = OrganizacionDetalle.ServiciodeVinoChampagneEstado;
                detalle.ServilletasEstado = OrganizacionDetalle.ServilletasEstado;
                detalle.SillasEstado = OrganizacionDetalle.SillasEstado;
                detalle.TortaAlegoricaEstado = OrganizacionDetalle.TortaAlegoricaEstado;
                detalle.AlfombraRojaEstado = OrganizacionDetalle.AlfombraRojaEstado;
                detalle.Anexo7Estado = OrganizacionDetalle.Anexo7Estado;
                detalle.LayoutEstado = OrganizacionDetalle.LayoutEstado;

                detalle.Acreditaciones = TextBoxAcreditaciones.Text;
                detalle.ListaCocheras = TextBoxListaCocheras.Text;
                detalle.ListaInvitados = TextBoxListadeInvitados.Text;
                detalle.AlfombraRoja = TextBoxAlfombraRoja.Text;
                detalle.Anexo7 = TextBoxAnexo7.Text;
                detalle.Layout = TextBoxLayout.Text;

                detalle.Escenario = DropDownListEscenario.SelectedItem.Value;
                detalle.Ramo = DropDownListRamo.SelectedItem.Value;

                detalle.IngresoProveedoresLugar = TextBoxContactoDireccionProveedoresIngresoLugar.Text;
                detalle.ContactoResponsableLugar = TextBoxContactoResponsableLugar.Text;
                detalle.TelefonoResponsableLugar = TextBoxContactoTelefonoLugar.Text;

                detalle.FechaArmadoLogistica = TextBoxDiaArmadoLogistica.Text;
                detalle.FechaArmadoSalon = TextBoxDiaArmadoSalon.Text;
                detalle.FechaDesarmadoSalon = TextBoxDiaDesarmadoSalon.Text;

                detalle.HoraArmadoLogistica = TextBoxHoraArmadoLogistica.Text;
                detalle.HoraArmadoSalon = TextBoxHoraArmadoSalon.Text;
                detalle.HoraDesarmadoSalon = TextBoxHoraDesarmadoSalon.Text;

                detalle.CantPersonasAfectadasArmado = TextBoxCantPersonasAfectadasArmado.Text;

                eventos.GrabarOrganizacionPresupuestoDetalle(detalle);
            }

        }

        protected void ButtonCambiarHora_Click(object sender, EventArgs e)
        {
            LabelMensaje.Visible = false;


            string HoraInicioAnterior = PresupuestoSeleccionado.HorarioEvento;
            string HoraFinAnterior = PresupuestoSeleccionado.HoraFinalizado;

            string HoraInicioNueva = TextBoxHoraInicio.Text;
            string HoraFinNueva = TextBoxHoraFin.Text;


            PresupuestoSeleccionado.HorarioEvento = TextBoxHoraInicio.Text;
            PresupuestoSeleccionado.HoraFinalizado = TextBoxHoraFin.Text;

            if (presupuestos.ActualizarFechaEvento(PresupuestoSeleccionado))
            {
                Mail mail = new Mail();

                mail.CambioHora(PresupuestoSeleccionado.Id, PresupuestoSeleccionado.EventoId, HoraInicioAnterior, HoraFinAnterior);

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

        protected void ButtonCambiarCantidadInvitados_Click(object sender, EventArgs e)
        {
            ObtenerDiferenciaInvitados();
        }

        private void ObtenerDiferenciaInvitados()
        {

            LabelMensajeInvitados.Visible = false;

            int cantidadAdultosAnterior = 0;

            if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInicialInvitados))
                cantidadAdultosAnterior = (int)PresupuestoSeleccionado.CantidadInicialInvitados;

            int cantidadAdolescentesAnterior = 0;

            if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosAdolecentes))
                cantidadAdolescentesAnterior = (int)PresupuestoSeleccionado.CantidadInvitadosAdolecentes;

            int cantidadEntre3y8Anterior = 0;

            if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosMenores3y8))
                cantidadEntre3y8Anterior = (int)PresupuestoSeleccionado.CantidadInvitadosMenores3y8;

            int cantidadMenores3Anterior = 0;

            if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosMenores3))
                cantidadMenores3Anterior = (int)PresupuestoSeleccionado.CantidadInvitadosMenores3;


            int cantidadAdultosNueva = 0;

            if (cmd.IsNumeric(TextBoxCantAdultos.Text))
                cantidadAdultosNueva = Int32.Parse(TextBoxCantAdultos.Text);

            int cantidadAdolescentesNueva = 0;

            if (cmd.IsNumeric(TextBoxAdolecentes.Text))
                cantidadAdolescentesNueva = Int32.Parse(TextBoxAdolecentes.Text);

            int cantidadEntre3y8Nueva = 0;

            if (cmd.IsNumeric(TextBoxMenores3y8.Text))
                cantidadEntre3y8Nueva = Int32.Parse(TextBoxMenores3y8.Text);

            int cantidadMenores3Nueva = 0;

            if (cmd.IsNumeric(PresupuestoSeleccionado.CantidadInvitadosMenores3))
                cantidadMenores3Nueva = Int32.Parse(TextBoxMenores3.Text);


            int difAdultos = cantidadAdultosNueva - cantidadAdultosAnterior;
            int difAdolescentes = cantidadAdolescentesNueva - cantidadAdolescentesAnterior;
            int difMenos3y8 = cantidadEntre3y8Nueva - cantidadEntre3y8Anterior;
            int difMenores = cantidadMenores3Nueva - cantidadMenores3Anterior;

            if (difAdultos != 0 || difAdolescentes != 0 || difMenos3y8 != 0 || difMenores != 0)
            {
                Mail mailAprobacion = new Mail();

                PresupuestoSeleccionado.CantidadInicialInvitados = (TextBoxCantAdultos.Text != "" ? Int32.Parse(TextBoxCantAdultos.Text) : 0);
                PresupuestoSeleccionado.CantidadInvitadosAdolecentes = (TextBoxAdolecentes.Text != "" ? Int32.Parse(TextBoxAdolecentes.Text) : 0);
                PresupuestoSeleccionado.CantidadInvitadosMenores3y8 = (TextBoxMenores3y8.Text != "" ? Int32.Parse(TextBoxMenores3y8.Text) : 0);
                PresupuestoSeleccionado.CantidadInvitadosMenores3 = (TextBoxMenores3.Text != "" ? Int32.Parse(TextBoxMenores3.Text) : 0);

                try
                {
                    presupuestos.EditarCantidadInvitados(PresupuestoSeleccionado);

                    mailAprobacion.envioMailCambioInvitadosOrganizacion(PresupuestoSeleccionado.Id, PresupuestoSeleccionado.EventoId);

                    LabelMensajeInvitados.Text = "La modificacion fue echa con Exito!!!";
                    LabelMensajeInvitados.ForeColor = System.Drawing.Color.Green;
                    LabelMensajeInvitados.Visible = true;
                }
                catch (Exception)
                {

                    LabelMensajeInvitados.Text = "La modificacion no fue realizada.";
                    LabelMensajeInvitados.ForeColor = System.Drawing.Color.Red;
                    LabelMensajeInvitados.Visible = true;
                }

            }
        }

        #region Button Imagenes

        protected void ImageButtonBocados_Click(object sender, ImageClickEventArgs e)
        {

            OrganizacionDetalle.BocadosEstado = ConfirmadosCampos(TextBoxBocados,
                                                                     OrganizacionDetalle.BocadosEstado,
                                                                     ImageButtonBocados);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonIslas_Click(object sender, ImageClickEventArgs e)
        {

            OrganizacionDetalle.IslasEstado = ConfirmadosCampos(TextBoxIslas,
                                                                OrganizacionDetalle.IslasEstado,
                                                                ImageButtonIslas);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonEntrada_Click(object sender, ImageClickEventArgs e)
        {

            OrganizacionDetalle.EntradaEstado = ConfirmadosCampos(TextBoxEntrada,
                                                                OrganizacionDetalle.EntradaEstado,
                                                                ImageButtonEntrada);

            UpdatePanelOrganizacion.Update();
        }
 
        protected void ImageButtonPrincipalAdultos_Click(object sender, ImageClickEventArgs e)
        {


            OrganizacionDetalle.PrincipalAdultosEstado = ConfirmadosCampos(TextBoxPrincipalAdultos,
                                                                                 OrganizacionDetalle.PrincipalAdultosEstado,
                                                                                 ImageButtonPrincipalAdultos);
            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonPrincipalAdolescentes_Click(object sender, ImageClickEventArgs e)
        {


            OrganizacionDetalle.PrincipalAdolescentesEstado = ConfirmadosCampos(TextBoxPrincipalAdolescentes,
                                                                                 OrganizacionDetalle.PrincipalAdolescentesEstado,
                                                                                 ImageButtonPrincipalAdolescentes);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonPostreAdultosAdolescentes_Click(object sender, ImageClickEventArgs e)
        {

            OrganizacionDetalle.PostreAdultosAdolescentesEstado = ConfirmadosCampos(TextBoxPostreAdultosAdolescentes,
                                                                                    OrganizacionDetalle.PostreAdultosAdolescentesEstado,
                                                                                    ImageButtonPostreAdultosAdolescentes);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonPrincipalMenores_Click(object sender, ImageClickEventArgs e)
        {

            OrganizacionDetalle.PrincipalChicosEstado = ConfirmadosCampos(TextBoxPrincipalMenores,
                                                                            OrganizacionDetalle.PrincipalChicosEstado,
                                                                            ImageButtonPrincipalMenores);

            UpdatePanelOrganizacion.Update();

        }

        protected void ImageButtonPostreMenores_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.PostreChicosEstado = ConfirmadosCampos(TextBoxPostreMenores,
                                                                          OrganizacionDetalle.PostreChicosEstado,
                                                                          ImageButtonPostreMenores);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonMesaDulce_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.MesaDulceEstado = ConfirmadosCampos(TextBoxMesaDulce,
                                                                      OrganizacionDetalle.MesaDulceEstado,
                                                                      ImageButtonMesaDulce);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonFindeFiesta_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.FinFiestaEstado = ConfirmadosCampos(TextBoxFindeFiesta,
                                                                    OrganizacionDetalle.FinFiestaEstado,
                                                                    ImageButtonFindeFiesta);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonVinoChampagne_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.ServiciodeVinoChampagneEstado = ConfirmadosCampos(TextBoxVinoChampagne,
                                                                  OrganizacionDetalle.ServiciodeVinoChampagneEstado,
                                                                  ImageButtonVinoChampagne);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonMesaPrincipal_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.MesaPrincipalEstado = ConfirmadosCampos(TextBoxMesaPrincipal,
                                                                 OrganizacionDetalle.MesaPrincipalEstado,
                                                                 ImageButtonMesaPrincipal);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonManteleria_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.ManteleriaEstado = ConfirmadosCampos(TextBoxManteleria,
                                                                OrganizacionDetalle.ManteleriaEstado,
                                                                ImageButtonManteleria);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonServilletas_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.ServilletasEstado = ConfirmadosCampos(TextBoxServilletas,
                                                               OrganizacionDetalle.ServilletasEstado,
                                                               ImageButtonServilletas);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonSillas_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.SillasEstado = ConfirmadosCampos(TextBoxSillas,
                                                             OrganizacionDetalle.SillasEstado,
                                                             ImageButtonSillas);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonInvitadosDespuesde00_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.InvitadosDespues00Estado = ConfirmadosCampos(TextBoxInvitadosDespuesde00,
                                                            OrganizacionDetalle.InvitadosDespues00Estado,
                                                            ImageButtonInvitadosDespuesde00);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonCumpleenelEvento_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.CumpleaniosEnEventoEstado = ConfirmadosCampos(TextBoxCumpleenelEvento,
                                                           OrganizacionDetalle.CumpleaniosEnEventoEstado,
                                                           ImageButtonCumpleenelEvento);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonTortaAlegorica_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.TortaAlegoricaEstado = ConfirmadosCampos(TextBoxTortaAlegorica,
                                                          OrganizacionDetalle.TortaAlegoricaEstado,
                                                          ImageButtonTortaAlegorica);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonLlegaSalon_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.LleganAlSalonEstado = ConfirmadosCampos(TextBoxLlegaSalon,
                                                       OrganizacionDetalle.LleganAlSalonEstado,
                                                       ImageButtonLlegaSalon);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonPlatosEspeciales_Click(object sender, ImageClickEventArgs e)
        {

            OrganizacionDetalle.PlatosEspecialesEstado = ConfirmadosCampos(TextBox1PlatosEspecciales,
                                                       OrganizacionDetalle.PlatosEspecialesEstado,
                                                       ImageButtonPlatosEspeciales);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonAcreditaciones_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.AcreditacionesEstado = ConfirmadosCampos(TextBoxAcreditaciones,
                                                     OrganizacionDetalle.AcreditacionesEstado,
                                                     ImageButtonAcreditaciones);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonListaInvitados_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.ListaInvitadosEstado = ConfirmadosCampos(TextBoxListadeInvitados,
                                                    OrganizacionDetalle.ListaInvitadosEstado,
                                                    ImageButtonListaInvitados);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonListaCocheras_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.ListaCocherasEstado = ConfirmadosCampos(TextBoxListaCocheras,
                                         OrganizacionDetalle.ListaCocherasEstado,
                                         ImageButtonListaCocheras);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonLayout_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.LayoutEstado = ConfirmadosCampos(TextBoxLayout,
                                        OrganizacionDetalle.LayoutEstado,
                                        ImageButtonLayout);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonAlfombraRoja_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.AlfombraRojaEstado = ConfirmadosCampos(TextBoxAlfombraRoja,
                                      OrganizacionDetalle.AlfombraRojaEstado,
                                      ImageButtonAlfombraRoja);

            UpdatePanelOrganizacion.Update();
        }

        protected void ImageButtonAnexo7_Click(object sender, ImageClickEventArgs e)
        {
            OrganizacionDetalle.Anexo7Estado = ConfirmadosCampos(TextBoxAnexo7,
                                     OrganizacionDetalle.Anexo7Estado,
                                     ImageButtonAnexo7);

            UpdatePanelOrganizacion.Update();
        }

        private bool ConfirmadosCampos(TextBox Control, bool Campo, ImageButton button)
        {

            if (Control.Text.Trim().Length > 0)
            {
                if (Campo)
                {

                    button.ImageUrl = "~/Content/Imagenes/noaprobado.png";

                    Campo = false;
                    Control.ReadOnly = false;

                    return false;

                }
                else
                {
                    button.ImageUrl = "~/Content/Imagenes/aprobado.png";

                    Campo = true;
                    Control.ReadOnly = true;

                    return true;
                }
            }
            return false;


        }


        #endregion

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            OrganizacionPresupuestoProveedoresExternos proveedor = new OrganizacionPresupuestoProveedoresExternos();

            proveedor.ProveedorExterno = TextBoxProveedorExterno.Text;
            proveedor.PresupuestoId = PresupuestoId;
            proveedor.Rubro = DropDownListRubro.SelectedItem.Value; // TextBoxProveedorRubro.Text;
            proveedor.Contacto = TextBoxProveedorContacto.Text;
            proveedor.Correo = TextBoxProveedorCorreo.Text;
            proveedor.Telefono = TextBoxProveedorTelefono.Text;
            proveedor.Observaciones = TextBoxProveedorObservaciones.Text;

            administrativas.GrabarProveedoresExternos(proveedor);


            BuscarProveedoresExternos();

            TextBoxProveedorExterno.Text = "";

            //TextBoxProveedorRubro.Text = "";
            TextBoxProveedorContacto.Text = "";
            TextBoxProveedorCorreo.Text = "";
            TextBoxProveedorTelefono.Text = "";
            TextBoxProveedorObservaciones.Text = "";

            UpdatePanelOrganizacion.Update();

        }

        private void BuscarProveedoresExternos()
        {
            ProveedoresExternos = administrativas.ObtenerProveedoresExternosPorPresupuesto(PresupuestoId);

            GridViewProveedoresExternos.DataSource = ProveedoresExternos.ToList();
            GridViewProveedoresExternos.DataBind();
        }

        protected void GridViewProveedoresExternos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Proveedor = (TextBox)e.Row.FindControl("TextBoxProveedor");
                TextBox Rubro = (TextBox)e.Row.FindControl("TextBoxRubro");
                TextBox Contacto = (TextBox)e.Row.FindControl("TextBoxContacto");
                TextBox Telefono = (TextBox)e.Row.FindControl("TextBoxTelefono");
                TextBox Correo = (TextBox)e.Row.FindControl("TextBoxCorreo");
                TextBox Observaciones = (TextBox)e.Row.FindControl("TextBoxObservaciones");
                Image ok = (Image)e.Row.FindControl("ImageSeguros");


                int Id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos proveedor = administrativas.BuscarOrganizacionPresupuestoProveedoresExternos(Id);

                Proveedor.Text = proveedor.ProveedorExterno;
                Rubro.Text = proveedor.Rubro;
                Contacto.Text = proveedor.Contacto;
                Telefono.Text = proveedor.Telefono;
                Correo.Text = proveedor.Correo;
                Observaciones.Text = proveedor.Observaciones;


                if (proveedor.SegurosOk)
                    ok.ImageUrl = "~/Content/Imagenes/aprobado.png";
                else
                    ok.ImageUrl = "~/Content/Imagenes/noaprobado.png";

                UpdatePanelOrganizacion.Update();
            }

        }

        protected void GridViewProveedoresExternos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProveedoresExternos.Rows[index];

                TextBox Proveedor = row.FindControl("TextBoxProveedor") as TextBox;
                TextBox Rubro = row.FindControl("TextBoxRubro") as TextBox;
                TextBox Contacto = row.FindControl("TextBoxContacto") as TextBox;
                TextBox Telefono = row.FindControl("TextBoxTelefono") as TextBox;
                TextBox Correo = row.FindControl("TextBoxCorreo") as TextBox;
                TextBox Observaciones = row.FindControl("TextBoxObservaciones") as TextBox;

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos proveedor = administrativas.BuscarOrganizacionPresupuestoProveedoresExternos(Id);

                proveedor.ProveedorExterno = Proveedor.Text;
                proveedor.Rubro = Rubro.Text;
                proveedor.Contacto = Contacto.Text;
                proveedor.Telefono = Telefono.Text;
                proveedor.Correo = Correo.Text;
                proveedor.Observaciones = Observaciones.Text;

                administrativas.GrabarProveedoresExternos(proveedor);

                BuscarProveedoresExternos();
                UpdatePanelOrganizacion.Update();

            }
            else if (e.CommandName == "Quitar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProveedoresExternos.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos proveedor = administrativas.BuscarOrganizacionPresupuestoProveedoresExternos(Id);

                administrativas.EliminarProveedoresExternos(proveedor);

                BuscarProveedoresExternos();
                UpdatePanelOrganizacion.Update();


            }
        }

        protected void ButtonAgregarTimming_Click(object sender, EventArgs e)
        {
            OrganizacionPresupuestoTimming timming = new OrganizacionPresupuestoTimming();


            if (TextBoxTimmingDuracion.Text != "")
                timming.Duracion = TextBoxTimmingDuracion.Text;
            else
                timming.Duracion = "0";

            timming.PresupuestoId = PresupuestoId;
            timming.Descripcion = TextBoxTimmingDescripcion.Text;
            timming.HoraInicio = TextBoxTimmingHoraInicio.Text;

            administrativas.GrabarTimming(timming);

            BuscarTimming();

            TextBoxTimmingDuracion.Text = "";
            TextBoxTimmingDescripcion.Text = "";
            TextBoxTimmingHoraInicio.Text = "";

            UpdatePanelOrganizacion.Update();
        }

        private void BuscarTimming()
        {
            OrganizacionTimming = administrativas.ObtenerTimmingPorPresupuesto(PresupuestoId);

            GridViewTimming.DataSource = OrganizacionTimming.ToList();
            GridViewTimming.DataBind();
        }

        protected void GridViewTimming_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Duracion = (TextBox)e.Row.FindControl("TextBoxDuracion");
                TextBox HoraInicio = (TextBox)e.Row.FindControl("TextBoxHoraInicio");
                TextBox Descripcion = (TextBox)e.Row.FindControl("TextBoxDescripcion");



                int Id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoTimming timming = administrativas.BuscarOrganizacionTimming(Id);

                Duracion.Text = timming.Duracion;
                HoraInicio.Text = timming.HoraInicio;
                Descripcion.Text = timming.Descripcion;



                UpdatePanelOrganizacion.Update();
            }
        }

        protected void GridViewTimming_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTimming.Rows[index];

                TextBox Duracion = row.FindControl("TextBoxDuracion") as TextBox;
                TextBox HoraInicio = row.FindControl("TextBoxHoraInicio") as TextBox;
                TextBox Descripcion = row.FindControl("TextBoxDescripcion") as TextBox;

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoTimming timming = administrativas.BuscarOrganizacionTimming(Id);

                timming.Duracion = Duracion.Text;
                timming.HoraInicio = HoraInicio.Text;
                timming.Descripcion = Descripcion.Text;

                administrativas.GrabarTimming(timming);

                BuscarTimming();
                UpdatePanelOrganizacion.Update();

            }
            else if (e.CommandName == "Quitar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTimming.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoTimming timming = administrativas.BuscarOrganizacionTimming(Id);

                administrativas.EliminarTimming(timming);

                BuscarTimming();
                UpdatePanelOrganizacion.Update();


            }
        }

        protected void ButtonAgregarArchivo_Click(object sender, EventArgs e)
        {
            OrganizacionPresupuestosArchivos archivo = new OrganizacionPresupuestosArchivos();

            archivo.PresupuestoId = PresupuestoId;
            archivo.Desripcion = TextBoxArchivoDescripcion.Text;
            archivo.NombreArchivo = System.IO.Path.GetFileName(FileUploadArchivo.FileName);

            archivo.Archivo = FileUploadArchivo.FileBytes;
            archivo.Extension = System.IO.Path.GetExtension(FileUploadArchivo.FileName);

            archivo.EmpleadoId = EmpleadoId;
            archivo.CreateFecha = System.DateTime.Now;

            administrativas.GrabarArchivo(archivo);


            BuscarArchivos();

            TextBoxArchivoDescripcion.Text = "";




            UpdatePanelOrganizacion.Update();
        }

        private void GrabarArchivo(OrganizacionPresupuestosArchivos archivo)
        {


            administrativas.GrabarArchivo(archivo);


            BuscarArchivos();
        }

        protected void GridViewArchivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivo.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivos = administrativas.BuscarOrganizacionArchivo(Id);

                administrativas.EliminarArchivo(archivos);

                BuscarArchivos();
                UpdatePanelOrganizacion.Update();


            }
            else if (e.CommandName == "Descargar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivo.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivos = administrativas.BuscarOrganizacionArchivo(Id);

                Response.Redirect("~/Organizador/Planificacion/VisualizarArchivo.aspx?Id=" + Id + "&EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "EditarArchivo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivo.Rows[index];

                FileUpload subir = row.FindControl("FileUploadArchivoEditar") as FileUpload;


                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivos = administrativas.BuscarOrganizacionArchivo(Id);

                archivos.Archivo = subir.FileBytes;
                archivos.NombreArchivo = System.IO.Path.GetFileName(subir.FileName);
                archivos.Extension = System.IO.Path.GetExtension(subir.FileName);
                archivos.CreateFecha = System.DateTime.Now;

                GrabarArchivo(archivos);

                Mail mail = new Mail();

                mail.envioMailModificacionArchivos(archivos);
            }
        }

        private void BuscarArchivos()
        {
            OrganizacionArchivos = administrativas.ObtenerArchivosPorPresupuesto(PresupuestoId);

            GridViewArchivo.DataSource = OrganizacionArchivos.ToList();
            GridViewArchivo.DataBind();
        }

        protected void ButtonGrabarOrganizacion_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonGrabarAdicionales_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonGrabarAmbientacion_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonGrabarTecnica_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonGrabarParticularidades_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonGrabarBarras_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonGrabarCatering_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private bool ValidarHoraArmado()
        {
            LabelHoraArmadoLogistica.Visible = false;
            LabelHoraArmadoSalon.Visible = false;

            if (TextBoxHoraArmadoLogistica.Text.Length > 0)
            {
                if (!cmd.ValidarHora(TextBoxHoraArmadoLogistica.Text))
                {
                    LabelHoraArmadoLogistica.Visible = true;
                    return false;
                }
            }

            if (TextBoxHoraArmadoSalon.Text.Length > 0)
            {
                if (!cmd.ValidarHora(TextBoxHoraArmadoSalon.Text))
                {
                    LabelHoraArmadoSalon.Visible = true;
                    return false;
                }
            }

            return true;

        }

        protected void ButtonGuardarLogistica_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void GridViewCatering_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);


            //protected void DropDownListMailPresentacionSiNo_SelectedIndexChanged(object sender, EventArgs e)
            //{
            //    MailPresentacion();
            //}

            //private void MailPresentacion()
            //{
            //    string enviomail = DropDownListMailPresentacionSiNo.SelectedValue;

            //    TextBoxFechaMailPresentacion.Visible = false;
            //    LabelFechaEnvioMail.Visible = false;

            //    if (enviomail == "No")
            //    {
            //        TextBoxFechaMailPresentacion.Visible = true;
            //        LabelFechaEnvioMail.Visible = true;

            //    }

            //    UpdatePanelOrganizacion.Update();
            //}

        }

        protected void GridViewBarras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);
        }

        protected void GridViewTecnica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);
        }

        protected void GridViewAmbientacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);
        }

        protected void GridViewAdicionales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);
        }

        protected void GridViewOtros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);
        }

        private void CargarEstadoProveedor(GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Image estadoProveedor = (Image)e.Row.FindControl("ImageEstadoProveedor");


                int Id = int.Parse(e.Row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(Id);

                if (detalle.EstadoProveedor == false || detalle.EstadoProveedor == null)
                    estadoProveedor.ImageUrl = "~/Content/Imagenes/noaprobado.png";
                else
                    estadoProveedor.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/Planificacion/ImprimirEvento.aspx?PresupuestoId=" + PresupuestoId + "&EventoId=" + EventoId);
        }

    }
}