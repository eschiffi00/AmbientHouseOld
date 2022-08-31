using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Organizador.Planificacion
{
    public partial class Ver : System.Web.UI.Page
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

                InicializarPagina();

            }
        }

        private void InicializarPagina()
        {

            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            string mail = "";
            string telefono = "";

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
                }
            }

            CargarEvento(mail, telefono);

            CargarPresupuesto();

            if (id == 0)
                NuevaOrganizacionDetalle();
            else
                EditarOrganizacionDetalle(id);

            SetFocus(TextBoxBocados);

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

            GridViewProveedoresExternos.DataSource = administrativas.ObtenerProveedoresExternosPorPresupuesto(PresupuestoId);
            GridViewProveedoresExternos.DataBind();

            BuscarArchivos();


        }

        private void BuscarArchivos()
        {
            GridViewArchivo.DataSource = administrativas.ObtenerArchivosPorPresupuesto(PresupuestoId);
            GridViewArchivo.DataBind();
        }
        private void EditarOrganizacionDetalle(int id)
        {
            DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle organizacionDetalle = new DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle();

            organizacionDetalle = eventos.BuscarOrganizacionDetalle(id);

            if (organizacionDetalle != null)
            {
                OrganizacionDetalle = organizacionDetalle;

                TextBoxMotivo.Text = OrganizacionDetalle.MotivoFestejo;

                TextBoxMail.Text = OrganizacionDetalle.Mail;
                TextBoxTelefono.Text = OrganizacionDetalle.Tel;

                TextBoxLocacionOtra.Text = OrganizacionDetalle.LocacionOtra;
                TextBoxDireccionLocacion.Text = OrganizacionDetalle.Direccion;

                if (OrganizacionDetalle.BocadosEstado)
                    TextBoxBocados.Text = OrganizacionDetalle.Bocados;


                if (OrganizacionDetalle.IslasEstado)
                    TextBoxIslas.Text = OrganizacionDetalle.Islas;


                if (OrganizacionDetalle.PrincipalAdultosEstado)
                    TextBoxPrincipalAdultos.Text = OrganizacionDetalle.PrincipalAdultos;

                if (OrganizacionDetalle.PrincipalAdolescentesEstado)
                    TextBoxPrincipalAdolescentes.Text = OrganizacionDetalle.PrincipalAdolescentes;

                if (OrganizacionDetalle.PostreAdultosAdolescentesEstado)
                    TextBoxPostreAdultosAdolescentes.Text = OrganizacionDetalle.PostreAdultosAdolescentes;

                if (OrganizacionDetalle.PrincipalChicosEstado)
                    TextBoxPrincipalMenores.Text = OrganizacionDetalle.PrincipalChicos;

                if (OrganizacionDetalle.PostreChicosEstado)
                    TextBoxPostreMenores.Text = OrganizacionDetalle.PostreChicos;

                if (OrganizacionDetalle.MesaDulceEstado)
                    TextBoxMesaDulce.Text = OrganizacionDetalle.MesaDulce;

                if (OrganizacionDetalle.FinFiestaEstado)
                    TextBoxFindeFiesta.Text = OrganizacionDetalle.FinFiesta;

                if (OrganizacionDetalle.ServiciodeVinoChampagneEstado)
                    TextBoxVinoChampagne.Text = OrganizacionDetalle.ServiciodeVinoChampagne;

                if (OrganizacionDetalle.ManteleriaEstado)
                    TextBoxManteleria.Text = OrganizacionDetalle.Manteleria;

                if (OrganizacionDetalle.ServilletasEstado)
                    TextBoxServilletas.Text = OrganizacionDetalle.Servilletas;

                if (OrganizacionDetalle.SillasEstado)
                    TextBoxSillas.Text = OrganizacionDetalle.Sillas;

                if (OrganizacionDetalle.InvitadosDespues00Estado)
                    TextBoxInvitadosDespuesde00.Text = OrganizacionDetalle.InvitadosDespues00;

                if (OrganizacionDetalle.CumpleaniosEnEventoEstado)
                    TextBoxCumpleenelEvento.Text = OrganizacionDetalle.CumpleaniosEnEvento;

                if (OrganizacionDetalle.TortaAlegoricaEstado)
                    TextBoxTortaAlegorica.Text = OrganizacionDetalle.TortaAlegorica;

                if (OrganizacionDetalle.LleganAlSalonEstado)
                    TextBoxLlegaSalon.Text = OrganizacionDetalle.LleganAlSalon;

                if (OrganizacionDetalle.PlatosEspecialesEstado)
                    TextBox1PlatosEspecciales.Text = OrganizacionDetalle.PlatosEspeciales;

                if (OrganizacionDetalle.ListaCocherasEstado)
                    TextBoxListaCocheras.Text = OrganizacionDetalle.ListaCocheras;

                if (OrganizacionDetalle.AcreditacionesEstado)
                    TextBoxAcreditaciones.Text = OrganizacionDetalle.Acreditaciones;

                if (OrganizacionDetalle.ListaInvitadosEstado)
                    TextBoxListadeInvitados.Text = OrganizacionDetalle.ListaInvitados;

                if (OrganizacionDetalle.LayoutEstado)
                    TextBoxLayout.Text = OrganizacionDetalle.Layout;

                if (OrganizacionDetalle.AlfombraRojaEstado)
                    TextBoxAlfombraRoja.Text = OrganizacionDetalle.AlfombraRoja;

                if (OrganizacionDetalle.Anexo7Estado)
                    TextBoxAnexo7.Text = OrganizacionDetalle.Anexo7;


                TextBoxObservacionesBarras.Text = OrganizacionDetalle.ObservacionBarras;
                TextBoxObservacionesAmbientacion.Text = OrganizacionDetalle.ObservacionAmbientacion;
                TextBoxObservacionesCatering.Text = OrganizacionDetalle.ObservacionCatering;
                TextBoxObservacionesAdicionales.Text = OrganizacionDetalle.ObservacionesAdicionales;
                TextBoxObservacionesParticularidades.Text = OrganizacionDetalle.ObservacionParticulares;
                TextBoxObservacionesTecnica.Text = OrganizacionDetalle.ObservacionTecnica;


                DropDownListEscenario.SelectedValue = OrganizacionDetalle.Escenario;
                DropDownListRamo.SelectedValue = OrganizacionDetalle.Ramo;

            }
            GridViewProveedoresExternos.DataSource = administrativas.ObtenerProveedoresExternosPorPresupuesto(PresupuestoId);
            GridViewProveedoresExternos.DataBind();


            GridViewTimming.DataSource = administrativas.ObtenerTimmingPorPresupuesto(PresupuestoId);
            GridViewTimming.DataBind();

            GridViewArchivo.DataSource = administrativas.ObtenerArchivosPorPresupuesto(PresupuestoId);
            GridViewArchivo.DataBind();




        }

        private void NuevaOrganizacionDetalle()
        {
            OrganizacionDetalle = new DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle();

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

        }

        private void CargarPresupuesto()
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


                string Locacion = eventos.BuscarLocacion(PresupuestoSeleccionado.LocacionId).Descripcion;
                //string Locacion = eventos.TraerLocaciones().Where(o => o.Id == PresupuestoSeleccionado.LocacionId).Select(o => o.Descripcion).SingleOrDefault();

                if (PresupuestoSeleccionado.SectorId != null)
                {
                    string sector = administrativas.BuscarSector((int)PresupuestoSeleccionado.SectorId).Descripcion;

                    LabelLocacion.Text = Locacion.ToUpper() + " (" + sector.ToUpper() + ")";

                    return;

                }

                LabelLocacion.Text = Locacion.ToUpper();

            }
        }

        protected void GridViewArchivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivo.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivos = administrativas.BuscarOrganizacionArchivo(Id);

                Response.Redirect("~/Operacion/Planificacion/VisualizarArchivo.aspx?Id=" + Id);
            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/Index.aspx?FechaEvento=" + Fecha);
        }

    }
}