using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Organizador.EventosRealizados
{
    public partial class Index : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        Comun cmd = new Comun();

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
            { }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarEventosRealizados();
        }

        private void BuscarEventosRealizados()
        {
            int nroEvento = 0;
            if (TextBoxNroEventoBuscador.Text != "" && cmd.IsNumeric(TextBoxNroEventoBuscador.Text))
                nroEvento = Int32.Parse(TextBoxNroEventoBuscador.Text);

            int nroPresupuesto = 0;
            if (TextBoxNroPresupuestoBuscador.Text != "" && cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text))
                nroPresupuesto = Int32.Parse(TextBoxNroPresupuestoBuscador.Text);

            int nroCliente = 0;

            string fechaEvento = TextBoxFechaEvento.Text;


            List<ObtenerEventosPresupuestos> ListEventos = eventos.BuscarEventosRealizadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, fechaEvento);

            GridViewRealizados.DataSource = ListEventos.ToList();
            GridViewRealizados.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
        }

        protected void GridViewRealizados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRealizados.PageIndex = e.NewPageIndex;
            BuscarEventosRealizados();
        }

        protected void GridViewRealizados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewRealizados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Organizador/Planificacion/Editar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
        }

    }
}