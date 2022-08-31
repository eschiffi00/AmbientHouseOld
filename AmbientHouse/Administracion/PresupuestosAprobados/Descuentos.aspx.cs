using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.PresupuestosAprobados
{
    public partial class Descuentos : System.Web.UI.Page
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
        Mail mail = new Mail();


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

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
            }

            CargarEvento();

            CargarPresupuesto();

            List<PresupuestoDetalle> ListPresuDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);

            GridViewVentasConRenta.DataSource = ListPresuDetalle.ToList();
            GridViewVentasConRenta.DataBind();

            GridViewVentasConRenta.Visible = true;

            TextBoxTotalRenta.Visible = true;
            LabelRentaTotal.Visible = true;

            TextBoxTotalRenta.Text = ListPresuDetalle.Sum(o => o.RentaUnNominal).ToString("C");

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

            LabelEjecutivo.Text = administrativas.BuscarEmpleado((int)EventoSeleccionado.EmpleadoId).ApellidoNombre;

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

                if (PresupuestoSeleccionado.ValorOrganizador != null)
                    TextBoxTotalPorcOrganizador.Text = System.Math.Round(double.Parse(PresupuestoSeleccionado.ValorOrganizador.ToString()), 2).ToString("C");

            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void GridViewVentasConRenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descuentos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentasConRenta.Rows[index];

                TextBox descuento = row.FindControl("TextBoxDescuentos") as TextBox;
                TextBox comentario = row.FindControl("TextBoxComentario") as TextBox;


                if (cmd.IsNumeric(descuento.Text.ToString()))
                {

                    double TotalDescuento = cmd.ValidarImportes(descuento.Text.ToString());

                    DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = new DomainAmbientHouse.Entidades.PresupuestoDetalle();


                    detalle.Id = Int32.Parse(row.Cells[0].Text);


                    presupuestos.AplicarAjuste(detalle.Id, TotalDescuento, 0, comentario.Text);

                    mail.EnvioMailAjustes(PresupuestoId, EventoId);
                }


                descuento.Text = "";

            }

            else if (e.CommandName == "Incremento")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentasConRenta.Rows[index];

                TextBox descuento = row.FindControl("TextBoxDescuentos") as TextBox;
                TextBox comentario = row.FindControl("TextBoxComentario") as TextBox;

                if (cmd.IsNumeric(descuento.Text.ToString()))
                {
                    double TotalIncremento = cmd.ValidarImportes(descuento.Text.ToString());

                    DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = new DomainAmbientHouse.Entidades.PresupuestoDetalle();

                    detalle.Id = Int32.Parse(row.Cells[0].Text);

                    presupuestos.AplicarAjuste(detalle.Id, 0, TotalIncremento, comentario.Text);

                    mail.EnvioMailAjustes(PresupuestoId, EventoId);

                }

                descuento.Text = "";
            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentasConRenta.Rows[index];

                TextBox costo = row.FindControl("TextBoxCosto") as TextBox;
                
                if (cmd.IsNumeric(costo.Text.Replace("$ ","").ToString()))
                {
                    double TotalCosto = cmd.ValidarImportes(costo.Text.Replace("$", "").ToString());

                    DomainAmbientHouse.Entidades.PresupuestoDetalle detalle = new DomainAmbientHouse.Entidades.PresupuestoDetalle();

                    detalle.Id = Int32.Parse(row.Cells[0].Text);

                    presupuestos.AplicarAjuste(detalle.Id,0, 0,"", TotalCosto);
                }

            }
            else if (e.CommandName == "AnularCanon")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentasConRenta.Rows[index];

                int Id = Int32.Parse(row.Cells[0].Text);

                PresupuestoDetalle detalle = this.presupuestos.BuscarPresupuestoDetalle(Id);
                detalle.Cannon = 0.0;
                detalle.AnuloCanon = true;
                this.presupuestos.ActualizarDetallePresupuestos(detalle);

            }

            InicializarPagina();
            UpdatePanelCotizador.Update();

        }

        protected void GridViewVentasConRenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].BackColor = System.Drawing.Color.LightGray;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                cmd.PanelDescuentos(e);
            }

        }


    }
}