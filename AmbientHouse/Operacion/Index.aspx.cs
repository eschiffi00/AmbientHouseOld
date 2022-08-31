using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Globalization;
using System.Configuration;

namespace AmbientHouse.Operacion
{
    public partial class Index : System.Web.UI.Page
    {
        public EventosServicios servicios = new EventosServicios();
        public PresupuestosServicios presupuestos = new PresupuestosServicios();
        public AdministrativasServicios administrativa = new AdministrativasServicios();

        public Comun cmd = new Comun();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BuscarFechas();
        }

        private void BuscarFechas()
        {

            Fecha = Request["FechaEvento"].ToString();

            DateTime fechaSeleccionada = DateTime.ParseExact(Fecha, "d/M/yyyy", CultureInfo.InvariantCulture);

            List<EventosConfirmadosReservadosTODOS> listEventos = servicios.EventosTodos().Where(o => o.FechaEvento == fechaSeleccionada).ToList();

            GridViewEventosGanados.DataSource = listEventos.ToList();
            GridViewEventosGanados.DataBind();

            UpdatePanelGrillas.Update();
        }

        protected void GridViewEventosGanados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());

            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[1].Text);

                //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                Response.Redirect("~/Operacion/Planificacion/Editar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
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

                    Response.Redirect("~/Operacion/ReporteExperienciaOperaciones.aspx?FechaEvento=" + Fecha);
                }


            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                PresupuestoId = int.Parse(row.Cells[1].Text);
                DropDownList cocina = (DropDownList)row.FindControl("DropDownListCocina");
                DropDownList salon = (DropDownList)row.FindControl("DropDownListSalon");
                DropDownList barra = (DropDownList)row.FindControl("DropDownListBarra");
                DropDownList operaciones = (DropDownList)row.FindControl("DropDownListOperaciones");
                DropDownList logistica = (DropDownList)row.FindControl("DropDownListLogistica");
                DropDownList logisticaArmado = (DropDownList)row.FindControl("DropDownListResponsableLogisticaArmado");
                DropDownList logisticaDesarmado = (DropDownList)row.FindControl("DropDownListResponsableLogisticaDesarmado");


                EmpleadosPresupuestosAprobados empleados = administrativa.BuscarEquiposPorPresupuesto(PresupuestoId);
                if (empleados == null)
                    empleados = new EmpleadosPresupuestosAprobados();

                empleados.PresupuestoId = PresupuestoId;
                if (cocina.SelectedItem.Value != "null")
                    empleados.JefeCocinaId = Int32.Parse(cocina.SelectedItem.Value);
                else
                    empleados.JefeCocinaId = null;

                if (barra.SelectedItem.Value != "null")
                    empleados.JefeBarraId = Int32.Parse(barra.SelectedItem.Value);
                else
                    empleados.JefeBarraId = null;

                if (salon.SelectedItem.Value != "null")
                    empleados.JefeSalonId = Int32.Parse(salon.SelectedItem.Value);
                else
                    empleados.JefeSalonId = null;

                if (operaciones.SelectedItem.Value != "null")
                    empleados.JefeOperacionId = Int32.Parse(operaciones.SelectedItem.Value);
                else
                    empleados.JefeOperacionId = null;

                if (logistica.SelectedItem.Value != "null")
                    empleados.JefeLogisticaId = Int32.Parse(logistica.SelectedItem.Value);
                else
                    empleados.JefeLogisticaId = null;

                if (logisticaArmado.SelectedItem.Value != "null")
                    empleados.ResponsableLogisticaArmadoId = Int32.Parse(logisticaArmado.SelectedItem.Value);
                else
                    empleados.ResponsableLogisticaArmadoId = null;

                if (logisticaDesarmado.SelectedItem.Value != "null")
                    empleados.ResponsableLogisticaDesarmadoId = Int32.Parse(logisticaDesarmado.SelectedItem.Value);
                else
                    empleados.ResponsableLogisticaDesarmadoId = null;

                administrativa.GrabarEquipo(empleados);



            }
            else if (e.CommandName == "Personal")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[1].Text);

           

                Response.Redirect("~/Operacion/AgregarPersonal.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }


        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
        }

        protected void GridViewEventosGanados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int respCocina = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespCocina"].ToString());
                int respSalon = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespSalon"].ToString());
                int respBarra = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespBarra"].ToString());
                int respOperaciones = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespOperaciones"].ToString());
                int respLogistica = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespLogistica"].ToString());
                int respLogisticaArmado = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespLogistica"].ToString());
                int respLogisticaDesarmado = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoRespLogistica"].ToString());

                Label coordinador1 = (Label)e.Row.FindControl("LabelCoordinador1");
                Label coordinador2 = (Label)e.Row.FindControl("LabelCoordinador2");
                Label organizador = (Label)e.Row.FindControl("LabelOrganizador");

                DropDownList cocina = (DropDownList)e.Row.FindControl("DropDownListCocina");
                DropDownList salon = (DropDownList)e.Row.FindControl("DropDownListSalon");
                DropDownList barra = (DropDownList)e.Row.FindControl("DropDownListBarra");
                DropDownList operaciones = (DropDownList)e.Row.FindControl("DropDownListOperaciones");
                DropDownList logistica = (DropDownList)e.Row.FindControl("DropDownListLogistica");
                DropDownList logisticaArmado = (DropDownList)e.Row.FindControl("DropDownListResponsableLogisticaArmado");
                DropDownList logisticaDesarmado = (DropDownList)e.Row.FindControl("DropDownListResponsableLogisticaDesarmado");

                Label horaCoordinador1 = (Label)e.Row.FindControl("LabelHoraIngresoCoordinador1");
                Label horaCoordinador2 = (Label)e.Row.FindControl("LabelHoraIngresoCoordinador2");


                int PresupuestoId = Int32.Parse(e.Row.Cells[1].Text);

                DomainAmbientHouse.Entidades.EmpleadosPresupuestosAprobados empleados = administrativa.BuscarEquiposPorPresupuesto(PresupuestoId);

                if (empleados != null)
                {
                    if (cmd.IsNumeric(empleados.CoordinadorId))
                        coordinador1.Text = administrativa.BuscarEmpleado((int)empleados.CoordinadorId).ApellidoNombre;
                    else
                        coordinador1.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.CoordinadorBisId))
                        coordinador2.Text = administrativa.BuscarEmpleado((int)empleados.CoordinadorBisId).ApellidoNombre;
                    else
                        coordinador2.Text = "Sin Asignar";

                    if (cmd.IsNumeric(empleados.OrganizadorId))
                        organizador.Text = administrativa.BuscarEmpleado((int)empleados.OrganizadorId).ApellidoNombre;
                    else
                        organizador.Text = "Sin Asignar";

                    horaCoordinador1.Text = empleados.HoraIngresoCoordinador1;
                    horaCoordinador2.Text = empleados.HoraIngresoCoordinador2;
                }

                cocina.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respCocina);
                cocina.DataTextField = "ApellidoNombre";
                cocina.DataValueField = "Id";
                cocina.DataBind();

                salon.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respSalon);
                salon.DataTextField = "ApellidoNombre";
                salon.DataValueField = "Id";
                salon.DataBind();

                barra.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respBarra);
                barra.DataTextField = "ApellidoNombre";
                barra.DataValueField = "Id";
                barra.DataBind();

                operaciones.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respOperaciones);
                operaciones.DataTextField = "ApellidoNombre";
                operaciones.DataValueField = "Id";
                operaciones.DataBind();

                logistica.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respLogistica);
                logistica.DataTextField = "ApellidoNombre";
                logistica.DataValueField = "Id";
                logistica.DataBind();

                logisticaArmado.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respLogistica);
                logisticaArmado.DataTextField = "ApellidoNombre";
                logisticaArmado.DataValueField = "Id";
                logisticaArmado.DataBind();

                logisticaDesarmado.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(respLogistica);
                logisticaDesarmado.DataTextField = "ApellidoNombre";
                logisticaDesarmado.DataValueField = "Id";
                logisticaDesarmado.DataBind();

                if (empleados != null)
                {
                    if (empleados.JefeCocinaId != null)
                        cocina.SelectedValue = empleados.JefeCocinaId.ToString();

                    if (empleados.JefeSalonId != null)
                        salon.SelectedValue = empleados.JefeSalonId.ToString();

                    if (empleados.JefeBarraId != null)
                        barra.SelectedValue = empleados.JefeBarraId.ToString();

                    if (empleados.JefeOperacionId != null)
                        operaciones.SelectedValue = empleados.JefeOperacionId.ToString();

                    if (empleados.JefeLogisticaId != null)
                        logistica.SelectedValue = empleados.JefeLogisticaId.ToString();

                    if (empleados.ResponsableLogisticaArmadoId != null)
                        logisticaArmado.SelectedValue = empleados.ResponsableLogisticaArmadoId.ToString();

                    if (empleados.ResponsableLogisticaDesarmadoId != null)
                        logisticaDesarmado.SelectedValue = empleados.ResponsableLogisticaDesarmadoId.ToString();
                }

            }
        }

    }
}