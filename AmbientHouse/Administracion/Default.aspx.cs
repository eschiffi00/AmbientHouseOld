using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Seguridad;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Configuration;


namespace AmbientHouse.Administracion
{
    public partial class Default : System.Web.UI.Page
    {
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

        private List<ObtenerEventosPresupuestos> ListEventos
        {
            get
            {
                return Session["ListEventos"] as List<ObtenerEventosPresupuestos>;
            }
            set
            {
                Session["ListEventos"] = value;
            }
        }

        private int NroEventoBus
        {
            get
            {
                return Int32.Parse(Session["NroEventoBus"].ToString());
            }
            set
            {
                Session["NroEventoBus"] = value;
            }
        }

        private int NroPresupuestoBus
        {
            get
            {
                return Int32.Parse(Session["NroPresupuestoBus"].ToString());
            }
            set
            {
                Session["NroPresupuestoBus"] = value;
            }
        }

        private string FechaEventoBus
        {
            get
            {
                return Session["FechaEventoBus"].ToString();
            }
            set
            {
                Session["FechaEventoBus"] = value;
            }
        }

        EventosServicios eventos = new EventosServicios();
        SeguridadServicios seguridad = new SeguridadServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewEventosGanados.Visible = false;

                GridViewRealizados.Visible = false;

                GridViewEventosRevisar.Visible = false;


                ListEventos = new List<ObtenerEventosPresupuestos>();

            }
        }

        private void Buscar()
        {
            int nroEvento = 0;
            if (TextBoxNroEventoBuscador.Text != "" && cmd.IsNumeric(TextBoxNroEventoBuscador.Text))
            {
                nroEvento = Int32.Parse(TextBoxNroEventoBuscador.Text);
                NroEventoBus = Int32.Parse(TextBoxNroEventoBuscador.Text);
            }

            int nroPresupuesto = 0;
            if (TextBoxNroPresupuestoBuscador.Text != "" && cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text))
            {
                nroPresupuesto = Int32.Parse(TextBoxNroPresupuestoBuscador.Text);
                NroPresupuestoBus = Int32.Parse(TextBoxNroPresupuestoBuscador.Text);
            }

            string fechaEvento = TextBoxFechaEvento.Text;
            FechaEventoBus = fechaEvento;

            int nroCliente = 0;

            ListEventos = eventos.BuscarEventosConfirmadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente,TextBoxApellidoNombre.Text, TextBoxRazonSocial.Text, fechaEvento);
            GridViewEventosGanados.DataSource = ListEventos.ToList();
            GridViewEventosGanados.DataBind();

            GridViewEventosGanados.Visible = true;

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


            ListEventos = eventos.BuscarEventosRealizadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, fechaEvento);
            GridViewRealizados.DataSource = ListEventos.ToList();
            GridViewRealizados.DataBind();

            GridViewRealizados.Visible = true;

        }

        protected void ButtonAdministracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Index.aspx");
        }

        protected void ButtonReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Index.aspx");
        }

        protected void ButtonMisArchivos_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonEventoGanado_Click(object sender, EventArgs e)
        {

            Buscar();

            GridViewRealizados.Visible = false;
            GridViewEventosRevisar.Visible = false;
        }

        protected void GridViewEventosGanados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int cerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString()); ;

            int PresupuestoARevisar = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoARevisar"].ToString());

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button reservar = (Button)e.Row.FindControl("ButtonReservar");
                Button confirmar = (Button)e.Row.FindControl("ButtonConfirmar");

                Button adicionales = (Button)e.Row.FindControl("ButtonVenderAdicionales");
                Button seguros = (Button)e.Row.FindControl("ButtonCargarSeguros");
                Button comanda = (Button)e.Row.FindControl("ButtonCargarComanda");
                Button proveedores = (Button)e.Row.FindControl("ButtonProvveedores");




                TextBox textoCliente = (TextBox)e.Row.FindControl("TextBoxCliente");
                TextBox textoEjecutivo = (TextBox)e.Row.FindControl("TextBoxEjecutivo");
                TextBox textoLocacion = (TextBox)e.Row.FindControl("TextBoxLocacion");
                TextBox textoFechaEvento = (TextBox)e.Row.FindControl("TextBoxFechaEvento");

                TextBox textoCuit = (TextBox)e.Row.FindControl("TextBoxCuit");
                TextBox textoCorreo = (TextBox)e.Row.FindControl("TextBoxCorreo");
                TextBox textoCelular = (TextBox)e.Row.FindControl("TextBoxCelular");

                int eventoId = Int32.Parse(e.Row.Cells[0].Text);
                int presupuestoId = Int32.Parse(e.Row.Cells[2].Text);

                DomainAmbientHouse.Entidades.ObtenerEventosPresupuestos evento = ListEventos.Where(o => o.EventoId == eventoId &&
                                                                                                    o.PresupuestoId == presupuestoId).SingleOrDefault();


                if (evento.ApellidoNombre.Length > 0)
                    textoCliente.Text = evento.ApellidoNombre.ToUpper();
                else
                    textoCliente.Text = evento.RazonSocial.ToUpper(); ;

                textoEjecutivo.Text = evento.Ejecutivo;
                textoLocacion.Text = evento.LOCACION;
                textoFechaEvento.Text = String.Format("{0:dd/MM/yyyy}", evento.FechaEvento);

                textoCuit.Text = evento.Cuit;
                textoCorreo.Text = evento.Correo;
                textoCelular.Text = evento.Celular;

                textoCliente.ReadOnly = true;
                textoEjecutivo.ReadOnly = true;
                textoLocacion.ReadOnly = true;
                textoFechaEvento.ReadOnly = true;
                textoCuit.ReadOnly = true;
                textoCorreo.ReadOnly = true;
                textoCelular.ReadOnly = true;

                reservar.Visible = false;
                confirmar.Visible = false;


                if (evento.EstadoEventoId == cerrado)
                {

                    reservar.Visible = true;
                    confirmar.Visible = false;

                }
                else
                {
                    reservar.Visible = false;
                    confirmar.Visible = true;
                }




            }

        }

        protected void ButtonEventoGanadoOLD_Click(object sender, EventArgs e)
        {

            GridViewEventosGanados.Visible = false;
            GridViewRealizados.Visible = false;
        }

        protected void GridViewEventosGanados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosGanados.PageIndex = e.NewPageIndex;
            Buscar();

        }

        protected void GridViewEventosGanadosOLD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[10].Text == "Cerrado")
                {
                    e.Row.Cells[12].Visible = true;
                    e.Row.Cells[13].Visible = false;
                    e.Row.Cells[14].Visible = false;
                }
                else if (e.Row.Cells[10].Text == "Reservado")
                {
                    e.Row.Cells[12].Visible = false;
                    e.Row.Cells[13].Visible = true;
                    e.Row.Cells[14].Visible = false;

                }
                else
                {
                    e.Row.Cells[12].Visible = false;
                    e.Row.Cells[13].Visible = false;
                    e.Row.Cells[14].Visible = true;
                }
            }
        }

        protected void GridViewEventosGanados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                Response.Redirect("~/Administracion/PresupuestosAprobados/SeguirAprobados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
            else if (e.CommandName == "Reservar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];


                int PresupuestoId = int.Parse(row.Cells[2].Text);
                int EventoId = int.Parse(row.Cells[0].Text);

                if (EventoId > 0 && PresupuestoId > 0)
                    Response.Redirect("~/Presupuestos/ReservarPresupuesto.aspx?EventoId=" + EventoId.ToString() + "&PresupuestoId=" + PresupuestoId.ToString());

            }
            else if (e.CommandName == "Confirmar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];


                int PresupuestoId = int.Parse(row.Cells[2].Text);
                int EventoId = int.Parse(row.Cells[0].Text);

                if (EventoId > 0 && PresupuestoId > 0)
                    Response.Redirect("~/Presupuestos/ReservarPresupuesto.aspx?EventoId=" + EventoId.ToString() + "&PresupuestoId=" + PresupuestoId.ToString());


            }
            else if (e.CommandName == "Imprimir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];


                int PresupuestoId = int.Parse(row.Cells[2].Text);

                //LabelPresupuesto.Text = PresupuestoId.ToString();

                Presupuestos = new PresupuestoPDF();

                Presupuestos = presupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

                //Image1.ImageUrl = "~/Presupuestos/PresupuestoCliente.ashx";

                if (Presupuestos != null) Response.Redirect("~/Administracion/PresupuestosAprobados/Imprimir.aspx"); ;

                //UpdatePanelPresupuestos.Update();
            }
            else if (e.CommandName == "Descuentos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                Response.Redirect("~/Administracion/PresupuestosAprobados/Descuentos.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
            else if (e.CommandName == "VenderAdicionales")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "CargarProveedoresExternos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Administracion/PresupuestosAprobados/ProveedoresExternos.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "Comanda")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Administracion/PresupuestosAprobados/CargarComanda.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "Cobranza")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Administracion/Cobranzas/Editar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "Proveedores")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosGanados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Administracion/ProveedoresExternos/Editar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxNroEventoBuscador.Text = "";
            TextBoxNroPresupuestoBuscador.Text = "";
            TextBoxFechaEvento.Text = "";
            TextBoxRazonSocial.Text = "";
            TextBoxApellidoNombre.Text = "";

            Buscar();
        }

        protected void ButtonEventosRealizados_Click(object sender, EventArgs e)
        {
            BuscarEventosRealizados();

            GridViewEventosGanados.Visible = false;
            GridViewEventosRevisar.Visible = false;
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

                Response.Redirect("~/Administracion/PresupuestosAprobados/SeguirAprobados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
            else if (e.CommandName == "VenderAdicionales")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewRealizados.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

            }
            else if (e.CommandName == "Imprimir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewRealizados.Rows[index];


                int PresupuestoId = int.Parse(row.Cells[2].Text);

                //LabelPresupuesto.Text = PresupuestoId.ToString();

                Presupuestos = new PresupuestoPDF();

                Presupuestos = presupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

                //Image1.ImageUrl = "~/Presupuestos/PresupuestoCliente.ashx";

                if (Presupuestos != null) Response.Redirect("~/Administracion/PresupuestosAprobados/Imprimir.aspx"); ;

            }

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonEventosARevisar_Click(object sender, EventArgs e)
        {

            BuscarEventosARevisar();
         
        }

        private void BuscarEventosARevisar()
        {
            ListEventos = eventos.BuscarEventosARevisar();
            GridViewEventosRevisar.DataSource = ListEventos.ToList();
            GridViewEventosRevisar.DataBind();

            GridViewEventosRevisar.Visible = true;
            GridViewRealizados.Visible = false;
            GridViewEventosGanados.Visible = false;

        }

        protected void GridViewEventosRevisar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewEventosRevisar.Rows[index];

                int EventoId = int.Parse(row.Cells[0].Text);

                int PresupuestoId = int.Parse(row.Cells[2].Text);

                Response.Redirect("~/Administracion/PresupuestosAprobados/PresupuestosARevisar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
        }

        protected void GridViewEventosRevisar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosRevisar.PageIndex = e.NewPageIndex;
            BuscarEventosARevisar();
        }
    }
}