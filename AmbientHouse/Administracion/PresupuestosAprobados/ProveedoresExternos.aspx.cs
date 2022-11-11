using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.PresupuestosAprobados
{
    public partial class ProveedoresExternos : System.Web.UI.Page
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


            }

            CargarEvento(mail, telefono);

            CargarPresupuesto();

            BuscarProveedoresExternos();

            BuscarArchivos();

        }

        private void BuscarProveedoresExternos()
        {
            GridViewProveedoresExternos.DataSource = administrativas.ObtenerProveedoresExternosPorPresupuesto(PresupuestoId);
            GridViewProveedoresExternos.DataBind();
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

                TextBoxHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;
                TextBoxHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;

                LabelTipoEvento.Text = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();


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


        }

        private void BuscarArchivos()
        {


            GridViewArchivo.DataSource = administrativas.ObtenerArchivosPorPresupuestoPorUsuario(PresupuestoId, EmpleadoId).ToList();
            GridViewArchivo.DataBind();
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

            }
            else if (e.CommandName == "Descargar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivo.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestosArchivos archivos = administrativas.BuscarOrganizacionArchivo(Id);



                Response.Redirect("~/Administracion/PresupuestosAprobados/VisualizarArchivo.aspx?Id=" + Id + "&EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
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

        private void GrabarArchivo(OrganizacionPresupuestosArchivos archivo)
        {


            administrativas.GrabarArchivo(archivo);


            BuscarArchivos();
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {

            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = Int32.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());

            if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
                Response.Redirect("~/Administracion/Default.aspx");
            else
                Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
        }



        protected void GridViewProveedoresExternos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ok = (ImageButton)e.Row.FindControl("ImageButtonSegurosOK");

                TextBox observaciones = (TextBox)e.Row.FindControl("TextBoxObservaciones");

                int Id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos proveedor = administrativas.BuscarOrganizacionPresupuestoProveedoresExternos(Id);

                observaciones.Text = proveedor.Observaciones;

                if (proveedor.SegurosOk)
                    ok.ImageUrl = "~/Content/Imagenes/aprobado.png";
                else
                    ok.ImageUrl = "~/Content/Imagenes/noaprobado.png";


            }
        }

        protected void GridViewProveedoresExternos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seguros")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProveedoresExternos.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos proveedor = administrativas.BuscarOrganizacionPresupuestoProveedoresExternos(Id);

                if (proveedor.SegurosOk)

                    proveedor.SegurosOk = false;
                else
                    proveedor.SegurosOk = true;

                administrativas.GrabarProveedoresExternos(proveedor);

                BuscarProveedoresExternos();

                UpdatePanelProveedores.Update();

            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProveedoresExternos.Rows[index];


                TextBox Observaciones = row.FindControl("TextBoxObservaciones") as TextBox;

                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos proveedor = administrativas.BuscarOrganizacionPresupuestoProveedoresExternos(Id);

                proveedor.Observaciones = Observaciones.Text;

                administrativas.GrabarProveedoresExternos(proveedor);

                BuscarProveedoresExternos();
                UpdatePanelProveedores.Update();
            }
        }
    }
}