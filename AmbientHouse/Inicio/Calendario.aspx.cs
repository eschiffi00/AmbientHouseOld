using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Inicio
{
    public partial class Calendario : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administracion = new AdministrativasServicios();
      


        protected void Page_Load(object sender, EventArgs e)
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


            //Button1.Attributes.Add("Onclick", "javascript:VentanaDialogoModal(‘Calendario.aspx‘,Text1.value,‘400‘,‘400‘,‘Text1‘);");
        }

        protected void CalendarEventos_DayRender(object sender, DayRenderEventArgs e)
        {


            int eventoConfirmado = 2;
            int eventoReservado = 4;

            //List<DomainAmbientHouse.Entidades.ObtenerEventos> eventoConfirmados = eventos.ObtenerEventosConfirmados();

            //List<Integracion.Entidades.ObtenerEventos> eventosConfirmadosSA = integracion.ObtenerEventosPorEstado(eventoConfirmado);

            //List<Integracion.Entidades.ObtenerEventos> eventosConfirmadosSA = eventosAnteriores.Where(o => o.EstadoId == ).ToList();

            List<EventosConfirmadosReservadosTODOS> listEventos = eventos.EventosTodos();



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
                        lbl.Attributes.Add("onclick",  "<script language='javascript'>window.open('Default.aspx', 'Serial Numbers', 'width=200 , height=300, toolbar=no');</script>" );
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
                        ForeColor = System.Drawing.Color.Black
                    };
                    e.Cell.Controls.Add(button5);
                }
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/PresupuestosAprobados/Imprimir.aspx");
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }



    }
}