using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Presupuestos
{
    public partial class Ver : System.Web.UI.Page
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
            GridViewVentasConRenta.Visible = false;
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

                //TextBoxNroEvento.Text = EventoId.ToString().PadLeft(8, '0');
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
                //TextBoxNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');
            }

            CargarEvento();

            CargarPresupuesto();

            List<PresupuestoDetalle> ListPresuDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);




            if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
            {

                GridViewVentasConRenta.DataSource = ListPresuDetalle.ToList();
                GridViewVentasConRenta.DataBind();

                GridViewVentasConRenta.Visible = true;

                TextBoxTotalRenta.Visible = true;
                LabelRentaTotal.Visible = true;

                TextBoxTotalRenta.Text = ListPresuDetalle.Sum(o => o.RentaUnNominal).ToString("C");

            }
            else
            {
                GridViewVentas.DataSource = ListPresuDetalle.ToList();
                GridViewVentas.DataBind();

                GridViewVentas.Visible = true;

            }






        }

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {


            CantidadTotalInvitados = Int32.Parse(cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes).ToString());

        }

        private void CargarEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = eventos.BuscarEvento(EventoId);

            TextBoxNroEvento.Text = EventoSeleccionado.NroEvento;

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

                TextBoxNroPresupuesto.Text = PresupuestoSeleccionado.NroPresupuesto;

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

                TextBoxTotalPorcOrganizador.Text = PresupuestoSeleccionado.ValorOrganizador.ToString();

            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presupuestos/GestionPorEvento.aspx?Id=" + EventoId);
        }

        protected void GridViewVentasConRenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            e.Row.Cells[10].BackColor = System.Drawing.Color.GreenYellow;
            e.Row.Cells[10].Font.Bold = true;


        }

    }
}