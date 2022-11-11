using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Operacion
{
    public partial class CalendarioOperacion : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administracion = new AdministrativasServicios();
        //Integracion.Servicios.ReporteServicios integracion = new Integracion.Servicios.ReporteServicios();

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


                ButtonStock.Visible = false;

                ButtonConfigurarCategoriaItems.Visible = false;
                ButtonConfigurarItems.Visible = false;
                ButtonTipoBarrasCategorias.Visible = false;

                if (EmpleadoId == 33)
                {
                    ButtonConfigurarCategoriaItems.Visible = true;
                    ButtonConfigurarItems.Visible = true;
                    ButtonTipoBarrasCategorias.Visible = true;
                }


                if (EmpleadoId == 205 || EmpleadoId == 258 || EmpleadoId == 236 || EmpleadoId == 260)
                    ButtonStock.Visible = true;
            }
        }

        protected void CalendarEventos_DayRender(object sender, DayRenderEventArgs e)
        {
            int eventoConfirmado = 2;
            int eventoReservado = 4;


            List<EventosConfirmadosReservadosTODOS> listEventos = eventos.EventosTodos();

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
            Response.Redirect("~/Operacion/Index.aspx?FechaEvento=" + CalendarEventos.SelectedDate.ToShortDateString());
        }

        protected void ButtonHerramientas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Index.aspx");
        }

        protected void ButtonVerListadoEventos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operacion/ReporteEventos.aspx");
        }

        protected void ButtonDegustacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operacion/Degustacion/Index.aspx");
        }

        protected void ButtonStock_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Existencias/Index.aspx");
        }

        protected void DropDownListTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonConfigurarItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Items/Index.aspx");
        }

        protected void ButtonConfigurarCategoriaItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/CategoriaItems/Index.aspx");
        }

        protected void ButtonTipoBarrasCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoBarrasCategoriasItem/Index.aspx");
        }
    }
}