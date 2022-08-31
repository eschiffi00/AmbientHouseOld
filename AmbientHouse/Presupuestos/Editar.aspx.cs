using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Presupuestos
{
    public partial class Editar1 : System.Web.UI.Page
    {
        EventosServicios servicios = new EventosServicios();
        PresupuestosServicios serviciosPresupuestos = new PresupuestosServicios();
        ClientesServicios serviciosClientes = new ClientesServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();

        Comun cmd = new Comun();

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

        private List<PresupuestoDetalle> ListPresupuestoDetalle
        {
            get
            {
                return Session["ListPresupuestoDetalle"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalle"] = value;
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

        private List<ObtenerEventosPresupuestos> ListPresupuestos
        {
            get
            {
                return Session["ListPresupuestos"] as List<ObtenerEventosPresupuestos>;
            }
            set
            {
                Session["ListPresupuestos"] = value;
            }
        }

        private double PorcentajeOrganizador
        {
            get
            {
                return double.Parse(Session["PorcentajeOrganizadorRes"].ToString());
            }
            set
            {
                Session["PorcentajeOrganizadorRes"] = value;
            }
        }

        private double ImporteOrganizador
        {
            get
            {
                return double.Parse(Session["ImporteOrganizadorRes"].ToString());
            }
            set
            {
                Session["ImporteOrganizadorRes"] = value;
            }
        }

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
            double importeOrganizador = 0;
            double porcentajeOrganizador = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;

                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);


                CargarEvento();

                CargarPresupuesto(ref importeOrganizador, ref porcentajeOrganizador);

                CargarDetallePresupuesto();

                CalcularTotalPresupuesto();

            }
        }

        private void CalcularTotalPresupuesto()
        {
        

            double Valor = cmd.CalcularTotalPresupuesto(ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);


            TextBoxTotalPresupuesto.Text = (System.Math.Round(Valor, 2)).ToString("C");

            TextBoxTotalPAX.Text = (System.Math.Round(Valor / CantidadTotalInvitados, 2)).ToString("C");


        }

        private void CargarPresupuesto(ref double importeOrganizador, ref double porcentajeOrganizador)
        {


            ObtenerEventosPresupuestos ListPresupuesto = servicios.BuscarPresupuestoParaAprobar(PresupuestoId);

            if (ListPresupuesto.ImporteOrganizador != null)
                importeOrganizador = importeOrganizador + double.Parse(ListPresupuesto.ImporteOrganizador.ToString());


            if (ListPresupuesto.PorcentajeOrganizador != null)
                porcentajeOrganizador = porcentajeOrganizador + double.Parse(ListPresupuesto.PorcentajeOrganizador.ToString());


            ListPresupuestos.Add(ListPresupuesto);

            ImporteOrganizador = importeOrganizador;
            PorcentajeOrganizador = porcentajeOrganizador;




            if (ListPresupuestos.Count > 0)
            {

                var cantidadinvitados = (from c in ListPresupuestos
                                         select c.CantidadInicialInvitados +
                                            (c.CantidadInvitadosAdolecentes == null ? 0 : c.CantidadInvitadosAdolecentes) +
                                            (c.CantidadInvitadosMenores3 == null ? 0 : c.CantidadInvitadosMenores3) +
                                            (c.CantidadInvitadosMenores3y8 == null ? 0 : c.CantidadInvitadosMenores3y8)).Sum();


                CantidadTotalInvitados = Int32.Parse(cantidadinvitados.ToString());

                GridViewPresupuestos.DataSource = ListPresupuestos.ToList();
                GridViewPresupuestos.DataBind();

            }
        }

        private void CargarDetallePresupuesto()
        {

            ListPresupuestoDetalle = serviciosPresupuestos.BuscarDetallePresupuesto(PresupuestoId);


           

            if (ListPresupuestoDetalle.Count > 0)
            {
                GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                GridViewVentas.DataBind();

            }
        }

        private void CargarEvento()
        {

         
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = servicios.BuscarEvento(EventoId);

            LabelNroEvent.Text = EventoSeleccionado.Id.ToString().PadLeft(8,'0');

            ClienteId = EventoSeleccionado.ClienteId;



         

        }

    }
}