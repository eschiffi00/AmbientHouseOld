using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Globalization;
using System.Configuration;

namespace AmbientHouse.Organizador
{
    public partial class Index : System.Web.UI.Page
    {

        public EventosServicios servicios = new EventosServicios();
        public PresupuestosServicios presupuestos = new PresupuestosServicios();
        public AdministrativasServicios administrativa = new AdministrativasServicios();

        public Comun cmd = new Comun();

        private PresupuestoPDF Presupuestos
        {
            get { return (PresupuestoPDF)HttpContext.Current.Session["PresupuestoCliente"]; }
            set { HttpContext.Current.Session["PresupuestoCliente"] = value; }
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

        private string Fecha
        {
            get
            {
                return Session["Fecha"].ToString();
            }
            set
            {
                Session["Fecha"] = value;
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

        private int TipoCatering
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarFechas();
            }
        }

        private void BuscarFechas()
        {

            Fecha = Request["FechaEvento"].ToString();


            DateTime fechaSeleccionada = DateTime.ParseExact(Fecha, "d/M/yyyy", CultureInfo.InvariantCulture);

            int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());

            List<EventosConfirmadosReservadosTODOS> listEventos = servicios.EventosTodos().Where(o => o.FechaEvento == fechaSeleccionada).ToList();

            if (PerfilId != PerfilCoordinadorOrganizacion)
                listEventos = servicios.EventosTodos().Where(o => o.FechaEvento == fechaSeleccionada).ToList();
            else
                listEventos = servicios.EventosTodos().Where(o => o.FechaEvento == fechaSeleccionada && (o.Coordinador1 == EmpleadoId || o.Coordinador2 == EmpleadoId)).ToList();

            GridViewEventosGanados.DataSource = listEventos.ToList();
            GridViewEventosGanados.DataBind();

            UpdatePanelGrillas.Update();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
        }

        protected void GridViewEventosGanados_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());

            int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());

            if (e.CommandName == "Imprimir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                PresupuestoId = int.Parse(row.Cells[1].Text);

                Presupuestos = new PresupuestoPDF();

                Presupuestos = presupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

                if (Presupuestos != null) Response.Redirect("~/Organizador/Imprimir.aspx?FechaEvento=" + Fecha);

            }
            else if (e.CommandName == "Experiencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                PresupuestoId = int.Parse(row.Cells[1].Text);

                EventoId = int.Parse(row.Cells[0].Text);

                List<PresupuestoDetalle> presu = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == RubroCatering).ToList();

                if (presu.Count > 0)
                {
                    TipoCatering = Int32.Parse(administrativa.BuscarProducto(presu.FirstOrDefault().ProductoId).TipoCateringId.ToString());

                    Response.Redirect("~/Organizador/ReporteExperienciaOrganizador.aspx?FechaEvento=" + Fecha);
                }

            }
            else if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                PresupuestoId = int.Parse(row.Cells[1].Text);

                EventoId = int.Parse(row.Cells[0].Text);

                if (PerfilId == PerfilCoordinadorOrganizacion)
                    Response.Redirect("~/Organizador/Planificacion/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                else
                    Response.Redirect("~/Organizador/Planificacion/Editar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "CargarProveedoresExternos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[1].Text);

                Response.Redirect("~/Administracion/PresupuestosAprobados/ProveedoresExternos.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                PresupuestoId = int.Parse(row.Cells[1].Text);
                DropDownList coordinador1 = (DropDownList)row.FindControl("DropDownListCoordinador");
                DropDownList coordinador2 = (DropDownList)row.FindControl("DropDownListCoordinador1");
                DropDownList organizador = (DropDownList)row.FindControl("DropDownListOrganizador");

                TextBox horaCoordinador1 = (TextBox)row.FindControl("TextBoxHoraCoordinador1");
                TextBox horaCoordinador2 = (TextBox)row.FindControl("TextBoxHoraCoordinador2");

                EmpleadosPresupuestosAprobados empleados = administrativa.BuscarEquiposPorPresupuesto(PresupuestoId);



                if (empleados == null)
                    empleados = new EmpleadosPresupuestosAprobados();

                empleados.PresupuestoId = PresupuestoId;
                if (coordinador1.SelectedItem.Value != "null")
                    empleados.CoordinadorId = Int32.Parse(coordinador1.SelectedItem.Value);
                else
                    empleados.CoordinadorId = null;

                if (coordinador2.SelectedItem.Value != "null")
                    empleados.CoordinadorBisId = Int32.Parse(coordinador2.SelectedItem.Value);
                else
                    empleados.CoordinadorBisId = null;

                if (organizador.SelectedItem.Value != "null")
                    empleados.OrganizadorId = Int32.Parse(organizador.SelectedItem.Value);
                else
                    empleados.OrganizadorId = null;

                empleados.HoraIngresoCoordinador1 = horaCoordinador1.Text;
                empleados.HoraIngresoCoordinador2 = horaCoordinador2.Text;

                administrativa.GrabarEquipo(empleados);


            }
        }

        protected void GridViewEventosGanados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());


                int coordinador = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoCoordinador"].ToString());

                DropDownList coordinador1 = (DropDownList)e.Row.FindControl("DropDownListCoordinador");
                DropDownList coordinador2 = (DropDownList)e.Row.FindControl("DropDownListCoordinador1");
                DropDownList organizador = (DropDownList)e.Row.FindControl("DropDownListOrganizador");

                TextBox horaCoordinador1 = (TextBox)e.Row.FindControl("TextBoxHoraCoordinador1");
                TextBox horaCoordinador2 = (TextBox)e.Row.FindControl("TextBoxHoraCoordinador2");

                Label respCocina = (Label)e.Row.FindControl("LabelRespCocina");
                Label respBarra = (Label)e.Row.FindControl("LabelRespBarra");
                Label respLogistica = (Label)e.Row.FindControl("LabelRespLogistica");
                Label respSalon = (Label)e.Row.FindControl("LabelRespSalon");
                Label respOperaciones = (Label)e.Row.FindControl("LabelRespOperaciones");
                Label respLogArmado = (Label)e.Row.FindControl("LabelRespLogisticaArmado");
                Label respLogDesarmado = (Label)e.Row.FindControl("LabelRespLogisticaDesarmado");

                int PresupuestoId = Int32.Parse(e.Row.Cells[1].Text);

                DomainAmbientHouse.Entidades.EmpleadosPresupuestosAprobados empleados = administrativa.BuscarEquiposPorPresupuesto(PresupuestoId);

                if (empleados != null)
                {
                    if (cmd.IsNumeric(empleados.JefeCocinaId))
                        respCocina.Text = administrativa.BuscarEmpleado((int)empleados.JefeCocinaId).ApellidoNombre;
                    else
                        respCocina.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.JefeBarraId))
                        respBarra.Text = administrativa.BuscarEmpleado((int)empleados.JefeBarraId).ApellidoNombre;
                    else
                        respBarra.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.JefeLogisticaId))
                        respLogistica.Text = administrativa.BuscarEmpleado((int)empleados.JefeLogisticaId).ApellidoNombre;
                    else
                        respLogistica.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.JefeSalonId))
                        respSalon.Text = administrativa.BuscarEmpleado((int)empleados.JefeSalonId).ApellidoNombre;
                    else
                        respSalon.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.JefeOperacionId))
                        respOperaciones.Text = administrativa.BuscarEmpleado((int)empleados.JefeOperacionId).ApellidoNombre;
                    else
                        respOperaciones.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.ResponsableLogisticaArmadoId))
                        respLogArmado.Text = administrativa.BuscarEmpleado((int)empleados.ResponsableLogisticaArmadoId).ApellidoNombre;
                    else
                        respLogArmado.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.ResponsableLogisticaDesarmadoId))
                        respLogDesarmado.Text = administrativa.BuscarEmpleado((int)empleados.ResponsableLogisticaDesarmadoId).ApellidoNombre;
                    else
                        respLogDesarmado.Text = "Sin Asignar";
                }

                coordinador1.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(coordinador);
                coordinador1.DataTextField = "ApellidoNombre";
                coordinador1.DataValueField = "Id";
                coordinador1.DataBind();

                coordinador2.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(coordinador);
                coordinador2.DataTextField = "ApellidoNombre";
                coordinador2.DataValueField = "Id";
                coordinador2.DataBind();

                organizador.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(coordinador);
                organizador.DataTextField = "ApellidoNombre";
                organizador.DataValueField = "Id";
                organizador.DataBind();

                if (PerfilId == PerfilCoordinadorOrganizacion)
                {
                    coordinador1.Enabled = false;
                    coordinador2.Enabled = false;
                    organizador.Enabled = false;
                }


                if (empleados != null)
                {
                    if (empleados.CoordinadorId != null)
                        coordinador1.SelectedValue = empleados.CoordinadorId.ToString();

                    if (empleados.CoordinadorBisId != null)
                        coordinador2.SelectedValue = empleados.CoordinadorBisId.ToString();

                    if (empleados.OrganizadorId != null)
                        organizador.SelectedValue = empleados.OrganizadorId.ToString();

                    horaCoordinador1.Text = empleados.HoraIngresoCoordinador1;
                    horaCoordinador2.Text = empleados.HoraIngresoCoordinador2;

                }

            }
        }


    }
}
