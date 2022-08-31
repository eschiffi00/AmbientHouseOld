using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Drawing;

namespace AmbientHouse.Organizador
{
    public partial class CalendarioOrganizador : System.Web.UI.Page
    {
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

        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administracion = new AdministrativasServicios();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalendarEventos.Caption = "Eventos Confirmados/Reservados";
                CalendarEventos.FirstDayOfWeek = FirstDayOfWeek.Sunday;
                CalendarEventos.NextPrevFormat = NextPrevFormat.FullMonth;
                CalendarEventos.TitleFormat = TitleFormat.MonthYear;
                CalendarEventos.ShowGridLines = true;
                CalendarEventos.DayStyle.HorizontalAlign = HorizontalAlign.Left;
                CalendarEventos.DayStyle.VerticalAlign = VerticalAlign.Top;
                CalendarEventos.DayStyle.Height = new Unit(150);
                CalendarEventos.DayStyle.Width = new Unit(200);
                CalendarEventos.OtherMonthDayStyle.BackColor = System.Drawing.Color.Cornsilk;


                LabelVisto.BackColor = System.Drawing.Color.BlueViolet;
                LabelVisto.ForeColor = System.Drawing.Color.White;
                LabelVisto.Text = "EVENTO VISTO";

                LabelNoVisto.BackColor = System.Drawing.Color.Green;
                LabelNoVisto.ForeColor = System.Drawing.Color.White;
                LabelNoVisto.Text = "EVENTO NO VISTO";


            }
        }

        protected void CalendarEventos_DayRender(object sender, DayRenderEventArgs e)
        {
            Calendario(e);

        }

        private void Calendario(DayRenderEventArgs e)
        { 
            int eventoConfirmado = 2;
            int eventoReservado = 4;

            int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());

            List<EventosConfirmadosReservadosTODOS> listEventos = new List<EventosConfirmadosReservadosTODOS>();




            if (PerfilId != PerfilCoordinadorOrganizacion)
                listEventos = eventos.EventosTodos();
            else
                listEventos = eventos.EventosTodos().Where(o => o.Coordinador1 == EmpleadoId || o.Coordinador2 == EmpleadoId).ToList();



            if (DropDownListTipoEvento.SelectedValue == "Eventos")
            {
                listEventos = listEventos.Where(o => o.TipoEventoId != 18).ToList();
            }
            else
            {
                listEventos = listEventos.Where(o => o.TipoEventoId == 18).ToList();
            }

            foreach (var item in listEventos)
            {

                if (e.Day.Date == item.FechaEvento)
                {

                    if (item.EstadoId == eventoConfirmado)
                    {
                        Literal lit = new Literal();
                        lit.Text = "<br/>";
                        e.Cell.Controls.Add(lit);

                        Button lbl = new Button();
                        if (item.ApellidoNombre.Trim().Length > 0 || item.ApellidoNombre.Trim() != "")
                            lbl.Text = item.ApellidoNombre + " - Cant. Invitados: " + item.CantidadInicialInvitados + " Locacion: " + item.LOCACION;
                        else
                            lbl.Text = item.RazonSocial + " - Cant. Invitados: " + item.CantidadInicialInvitados + " Locacion: " + item.LOCACION;

                        lbl.Font.Size = new FontUnit(FontSize.Small);

                        OrganizacionPresupuestoDetalle detalle = eventos.BuscarOrganizacionDetallePorPresupuesto(item.PresupuestoId);

                        if (detalle != null)
                            lbl.ForeColor = System.Drawing.Color.BlueViolet;
                        else
                            lbl.ForeColor = System.Drawing.Color.Green;

                        lbl.Attributes.Add("onclick", "<script language='javascript'>window.open('Default.aspx', 'Serial Numbers', 'width=200 , height=300, toolbar=no');</script>");
                        //lbl.Click += new EventHandler(btn_Click);

                        e.Cell.Controls.Add(lbl);
                    }
                    else
                    {
                        Literal lit = new Literal();
                        lit.Text = "<br/>";
                        e.Cell.Controls.Add(lit);

                        Button lbl = new Button();
                        if (item.ApellidoNombre.Trim().Length > 0 || item.ApellidoNombre.Trim() != "")
                            lbl.Text = item.ApellidoNombre + " - Cant. Invitados: " + item.CantidadInicialInvitados + " Locacion: " + item.LOCACION;
                        else
                            lbl.Text = item.RazonSocial + " - Cant. Invitados: " + item.CantidadInicialInvitados + " Locacion: " + item.LOCACION;

                        lbl.Font.Size = new FontUnit(FontSize.Small);

                        OrganizacionPresupuestoDetalle detalle = eventos.BuscarOrganizacionDetallePorPresupuesto(item.PresupuestoId);

                        if (detalle != null)
                            lbl.ForeColor = System.Drawing.Color.BlueViolet;
                        else
                            lbl.ForeColor = System.Drawing.Color.Green;

                        lbl.Attributes.Add("onclick", "<script language='javascript'>window.open('Default.aspx', 'Serial Numbers', 'width=200 , height=300, toolbar=no');</script>");
                        //lbl.Attributes.Add("OnClick", "btn_Click");
                        //lbl.Click += new EventHandler(btn_Click);

                        e.Cell.Controls.Add(lbl);
                    }

                }

            }

            int mes = e.Day.Date.Month;
            int anio = e.Day.Date.Year;





            List<Feriados> feriados = administracion.ObtenerFeriados(anio, mes);

            foreach (var item in feriados)
            {

                if (e.Day.Date == item.Fecha)
                {
                    e.Day.IsSelectable = true;
                    Literal lit = new Literal();
                    lit.Text = "<br/>";
                    e.Cell.Controls.Add(lit);

                    Button lbl = new Button();
                    lbl.Text = item.Descripcion.ToUpper();
                    lbl.Font.Size = new FontUnit(FontSize.Small);
                    lbl.ForeColor = System.Drawing.Color.Fuchsia;
                    e.Cell.Controls.Add(lbl);
                }

                if (item.SePasaA != null)
                {
                    if (e.Day.Date == item.SePasaA)
                    {
                        e.Day.IsSelectable = true;
                        Literal lit = new Literal();
                        lit.Text = "<br/>";
                        e.Cell.Controls.Add(lit);

                        Button lbl = new Button();
                        lbl.Text = item.Descripcion.ToUpper();
                        lbl.Font.Size = new FontUnit(FontSize.Small);
                        lbl.ForeColor = System.Drawing.Color.Fuchsia;
                        e.Cell.Controls.Add(lbl);
                    }
                }
            }

            int.Parse(ConfigurationManager.AppSettings["DegustacionAbierta"].ToString());

            List<DomainAmbientHouse.Entidades.Degustacion> list = this.administracion.ObtenerDegustacion();

            foreach (DomainAmbientHouse.Entidades.Degustacion degustacion in list)
            {
                if (e.Day.Date == degustacion.FechaDegustacion)
                {
                    e.Day.IsSelectable = true;
                    Literal child = new Literal
                    {
                        Text = "<br/>"
                    };
                    e.Cell.Controls.Add(child);
                    Button button5 = new Button
                    {
                        Text = "DEGUSTACION: " + degustacion.FechaDegustacion.ToShortDateString(),
                        Font = { Size = new FontUnit(FontSize.Small) },
                        ForeColor = Color.Black
                    };
                    e.Cell.Controls.Add(button5);
                }
            }
        }

        protected void CalendarEventos_SelectionChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/Index.aspx?FechaEvento=" + CalendarEventos.SelectedDate.ToShortDateString());
        }

        protected void ButtonHerramientas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Index.aspx");
        }

        protected void ButtonVerListadoEventos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/ReporteEventos.aspx");
        }

        protected void ButtonDegustacion_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Organizador/Degustacion/Index.aspx");
        }

        protected void ButtonEventosRealizados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/EventosRealizados/Index.aspx");
        }

        protected void DropDownListTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}