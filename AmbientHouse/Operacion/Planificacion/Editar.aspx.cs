using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Operacion.Planificacion
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

        AdministrativasServicios administrativas = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ButtonGuardarLogistica.Visible = false;

                LabelHoraArmadoLogistica.Visible = false;
                LabelHoraArmadoSalon.Visible = false;

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

        private void EditarOrganizacionDetalle(int id)
        {
            DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle organizacionDetalle = new DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle();

            organizacionDetalle = eventos.BuscarOrganizacionDetalle(id);


            int EmpleadoEsCarina = 31;
            int EmpleadoEsNelson = 260;


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

                if (OrganizacionDetalle.EntradaEstado)
                    TextBoxEntrada.Text = OrganizacionDetalle.Entrada;


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

                if (OrganizacionDetalle.MesaPrincipalEstado)
                    TextBoxMesaPrincipal.Text = OrganizacionDetalle.MesaPrincipal;


                TextBoxObservacionesBarras.Text = OrganizacionDetalle.ObservacionBarras;
                TextBoxObservacionesAmbientacion.Text = OrganizacionDetalle.ObservacionAmbientacion;
                TextBoxObservacionesCatering.Text = OrganizacionDetalle.ObservacionCatering;
                TextBoxObservacionesAdicionales.Text = OrganizacionDetalle.ObservacionesAdicionales;
                TextBoxObservacionesParticularidades.Text = OrganizacionDetalle.ObservacionParticulares;
                TextBoxObservacionesTecnica.Text = OrganizacionDetalle.ObservacionTecnica;

                TextBoxContactoDireccionProveedoresIngresoLugar.Text = OrganizacionDetalle.IngresoProveedoresLugar;
                TextBoxContactoResponsableLugar.Text = OrganizacionDetalle.ContactoResponsableLugar;
                TextBoxContactoTelefonoLugar.Text = OrganizacionDetalle.TelefonoResponsableLugar;


                if (EmpleadoId == EmpleadoEsCarina)
                {
                    TextBoxDiaArmadoSalon.ReadOnly = false;
                    TextBoxHoraArmadoSalon.ReadOnly = false;
                    TextBoxDiaDesarmadoSalon.ReadOnly = false;

                    ButtonGuardarLogistica.Visible = true;
                }

                if (EmpleadoId == EmpleadoEsNelson)
                {
                    TextBoxDiaArmadoLogistica.ReadOnly = false;
                    TextBoxHoraArmadoLogistica.ReadOnly = false;

                    ButtonGuardarLogistica.Visible = true;
                }

                TextBoxDiaArmadoLogistica.Text = OrganizacionDetalle.FechaArmadoLogistica;
                TextBoxDiaArmadoSalon.Text = OrganizacionDetalle.FechaArmadoSalon;
                TextBoxHoraDesarmadoSalon.Text = OrganizacionDetalle.FechaDesarmadoSalon;

                TextBoxHoraArmadoLogistica.Text = OrganizacionDetalle.HoraArmadoLogistica;
                TextBoxHoraArmadoSalon.Text = OrganizacionDetalle.HoraArmadoSalon;
                TextBoxHoraDesarmadoSalon.Text = OrganizacionDetalle.HoraDesarmadoSalon;

                TextBoxCantPersonasAfectadasArmado.Text = OrganizacionDetalle.CantPersonasAfectadasArmado;

                DropDownListEscenario.SelectedValue = OrganizacionDetalle.Escenario;
                DropDownListRamo.SelectedValue = OrganizacionDetalle.Ramo;


                this.ImageButtonSePidioHielo.ImageUrl = !this.OrganizacionDetalle.SePidioHielo ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
                this.ImageButtonSePidioLogitica.ImageUrl = !this.OrganizacionDetalle.SePidioLogistica ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
                this.ImageButtonManteleria.ImageUrl = !this.OrganizacionDetalle.SePidioManteleria ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
                this.ImageButtonSePidioMoviliario.ImageUrl = !this.OrganizacionDetalle.SePidioMoviliario ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
                this.TextBoxObservacionesHielo.Text = this.OrganizacionDetalle.ObservacionesHielo;
                this.TextBoxObservacionesLogistica.Text = this.OrganizacionDetalle.ObservacionesLogistica;
                this.TextBoxObservacionesManteleria.Text = this.OrganizacionDetalle.ObservacionesManteleria;
                this.TextBoxObservacionesMoviliario.Text = this.OrganizacionDetalle.ObservacionesMoviliario;



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

            int EmpleadoEsCarina = 31;
            int EmpleadoEsNelson = 260;


            if (EmpleadoId == EmpleadoEsCarina)
            {
                TextBoxDiaArmadoSalon.ReadOnly = false;
                TextBoxHoraArmadoSalon.ReadOnly = false;


                ButtonGuardarLogistica.Visible = true;
            }

            if (EmpleadoId == EmpleadoEsNelson)
            {
                TextBoxDiaArmadoLogistica.ReadOnly = false;
                TextBoxHoraArmadoLogistica.ReadOnly = false;
                TextBoxDiaDesarmadoSalon.ReadOnly = false;

                ButtonGuardarLogistica.Visible = true;
            }

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

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operacion/Index.aspx?FechaEvento=" + Fecha);
        }

        protected void GridViewArchivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivo.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivos = administrativas.BuscarOrganizacionArchivo(Id);

                Response.Redirect("~/Operacion/Planificacion/VisualizarArchivo.aspx?Id=" + Id + "&EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
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

        protected void ButtonAgregarArchivo_Click(object sender, EventArgs e)
        {
            GrabarArchivo();

        }

        private void GrabarArchivo()
        {
            OrganizacionPresupuestosArchivos archivo = new OrganizacionPresupuestosArchivos();

            archivo.PresupuestoId = PresupuestoId;
            archivo.Desripcion = DropDownListNombreArchivo.SelectedItem.Value;
            archivo.NombreArchivo = System.IO.Path.GetFileName(FileUploadArchivo.FileName);

            archivo.Archivo = FileUploadArchivo.FileBytes;
            archivo.Extension = System.IO.Path.GetExtension(FileUploadArchivo.FileName);

            archivo.EmpleadoId = EmpleadoId;
            archivo.CreateFecha = System.DateTime.Now;

            administrativas.GrabarArchivo(archivo);


            BuscarArchivos();
        }

        private void GrabarArchivo(OrganizacionPresupuestosArchivos archivo)
        {


            administrativas.GrabarArchivo(archivo);


            BuscarArchivos();
        }

        private void BuscarArchivos()
        {
            GridViewArchivo.DataSource = administrativas.ObtenerArchivosPorPresupuesto(PresupuestoId);
            GridViewArchivo.DataBind();
        }

        protected void GridViewArchivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button editar = (Button)e.Row.FindControl("ButtonEditar");



                int Id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivo = administrativas.BuscarOrganizacionArchivo(Id);

                if (EmpleadoId == archivo.EmpleadoId)
                    editar.Visible = true;
                else
                    editar.Visible = false;


            }
        }

        protected void ButtonGuardarLogistica_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {

            if (ValidarHoraArmado())
            {
                DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle detalle = OrganizacionDetalle;

                detalle.PresupuestoId = Int32.Parse(Request["PresupuestoId"]);

                if (this.eventos.BuscarOrganizacionDetallePorPresupuesto(detalle.PresupuestoId) == null)
                {
                    detalle.BocadosEstado = false;
                    detalle.IslasEstado = false;
                    detalle.AcreditacionesEstado = false;
                    detalle.FinFiestaEstado = false;
                    detalle.InvitadosDespues00Estado = false;
                    detalle.ListaCocherasEstado = false;
                    detalle.ListaInvitadosEstado = false;
                    detalle.LleganAlSalonEstado = false;
                    detalle.ManteleriaEstado = false;
                    detalle.MesaDulceEstado = false;
                    detalle.MesaPrincipalEstado = false;
                    detalle.PlatosEspecialesEstado = false;
                    detalle.PostreAdultosAdolescentesEstado = false;
                    detalle.PostreChicosEstado = false;
                    detalle.PrincipalAdolescentesEstado = false;
                    detalle.PrincipalAdultosEstado = false;
                    detalle.PrincipalChicosEstado = false;
                    detalle.ServiciodeVinoChampagneEstado = false;
                    detalle.ServilletasEstado = false;
                    detalle.SillasEstado = false;
                    detalle.TortaAlegoricaEstado = false;
                    detalle.AlfombraRojaEstado = false;
                    detalle.Anexo7Estado = false;
                    detalle.LayoutEstado = false;
                    detalle.Ramo = "NO";
                    detalle.Escenario = "NO";
                }


                detalle.FechaArmadoLogistica = TextBoxDiaArmadoLogistica.Text;
                detalle.FechaArmadoSalon = TextBoxDiaArmadoSalon.Text;
                detalle.FechaDesarmadoSalon = TextBoxDiaDesarmadoSalon.Text;

                detalle.HoraArmadoLogistica = TextBoxHoraArmadoLogistica.Text;
                detalle.HoraArmadoSalon = TextBoxHoraArmadoSalon.Text;
                detalle.HoraDesarmadoSalon = TextBoxHoraDesarmadoSalon.Text;
                detalle.CantPersonasAfectadasArmado = TextBoxCantPersonasAfectadasArmado.Text;

                detalle.SePidioHielo = this.ImageButtonSePidioHielo.ImageUrl == "~/Content/Imagenes/aprobado.png";
                detalle.SePidioLogistica = this.ImageButtonSePidioLogitica.ImageUrl == "~/Content/Imagenes/aprobado.png";
                detalle.SePidioManteleria = this.ImageButtonManteleria.ImageUrl == "~/Content/Imagenes/aprobado.png";
                detalle.SePidioMoviliario = this.ImageButtonSePidioMoviliario.ImageUrl == "~/Content/Imagenes/aprobado.png";
                detalle.ObservacionesHielo = this.TextBoxObservacionesHielo.Text;
                detalle.ObservacionesLogistica = this.TextBoxObservacionesLogistica.Text;
                detalle.ObservacionesManteleria = this.TextBoxObservacionesManteleria.Text;
                detalle.ObservacionesMoviliario = this.TextBoxObservacionesMoviliario.Text;


                eventos.GrabarOrganizacionPresupuestoDetalle(detalle);
            }

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

            if (TextBoxHoraDesarmadoSalon.Text.Length > 0)
            {
                if (!cmd.ValidarHora(TextBoxHoraDesarmadoSalon.Text))
                {
                    LabelHoraArmadoSalon.Visible = true;
                    return false;
                }
            }

            return true;

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

        protected void GridViewCatering_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CargarEstadoProveedor(e);
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

        protected void ImageButtonSePidioHielo_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarEstadoLogistica(this.ImageButtonSePidioHielo);

        }

        protected void ImageButtonSePidioMoviliario_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarEstadoLogistica(this.ImageButtonSePidioMoviliario);
        }

        protected void ImageButtonSePidioLogitica_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarEstadoLogistica(this.ImageButtonSePidioLogitica);
        }

        protected void ImageButtonManteleria_Click(object sender, ImageClickEventArgs e)
        {
            this.CargarEstadoLogistica(this.ImageButtonManteleria);
        }

        private void CargarEstadoLogistica(ImageButton img)
        {
            img.ImageUrl = (img.ImageUrl != "~/Content/Imagenes/aprobado.png")
                            ? "~/Content/Imagenes/aprobado.png"
                            : "~/Content/Imagenes/noaprobado.png";
            this.UpdatePanelLogistica.Update();

        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/Planificacion/ImprimirEvento.aspx?PresupuestoId=" + PresupuestoId + "&EventoId=" + EventoId);
        }

    }
}