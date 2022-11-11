using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;

namespace AmbientHouse.Administracion.Recibos
{
    public partial class Editar : System.Web.UI.Page
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

        private DomainAmbientHouse.Entidades.RecibosPDF RecibosPDF
        {
            get
            {
                return Session["RecibosPDF"] as DomainAmbientHouse.Entidades.RecibosPDF;
            }
            set
            {
                Session["RecibosPDF"] = value;
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

        private DomainAmbientHouse.Entidades.ClientesBis ClienteBisSeleccionado
        {
            get
            {
                return Session["ClienteBisSeleccionado"] as DomainAmbientHouse.Entidades.ClientesBis;
            }
            set
            {
                Session["ClienteBisSeleccionado"] = value;
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
                PanelReciboPDF.Visible = false;

            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;

                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);


                CargarEvento();

            }

        }

        private void CargarEvento()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());


            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = servicios.BuscarEvento(EventoId);


            LabelMontoSenia.Text = EventoSeleccionado.MontoSena.ToString();
            LabelFechaSenia.Text = String.Format("{0:dd/MM/yyyy}", EventoSeleccionado.FechaSena);




            CargarCliente();


        }

        private void CargarCliente()
        {
            LabelRazonSocial.Visible = false;
            LabelRazonSocialText.Visible = false;
            LabelApellidoyNombre.Visible = false;
            LabelApellidoyNombreText.Visible = false;

            ClienteBisSeleccionado = new ClientesBis();

            ClienteBisSeleccionado = serviciosClientes.BuscarCliente((long)EventoSeleccionado.ClienteBisId);

            if (ClienteBisSeleccionado.PersonaFisicaJuridica == "FISICA")
            {
                LabelApellidoyNombreText.Visible = true;
                LabelApellidoyNombre.Visible = true;

                LabelApellidoyNombreText.Text = ClienteBisSeleccionado.ApellidoNombre;


            }
            else
            {
                LabelRazonSocialText.Visible = true;
                LabelRazonSocial.Visible = true;

                LabelRazonSocialText.Text = ClienteBisSeleccionado.RazonSocial;


            }

            ClienteId = ClienteBisSeleccionado.Id;
            LabelDomicilio.Text = ClienteBisSeleccionado.Direccion;
            LabelCuit.Text = ClienteBisSeleccionado.CUILCUIT;



            LabelCondicionIva.Text = ClienteBisSeleccionado.CondicionIva;



        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {

            RecibosPDF = new RecibosPDF();

            if (ClienteBisSeleccionado.PersonaFisicaJuridica == "FISICA")
            {
                RecibosPDF.ApellidoNombre = LabelApellidoyNombreText.Text;

            }
            else
            {
                RecibosPDF.RazonSocial = LabelRazonSocialText.Text;
            }

            RecibosPDF.Domicilio = LabelDomicilio.Text;
            RecibosPDF.CuilCuit = LabelCuit.Text;
            RecibosPDF.CondicionIva = LabelCondicionIva.Text;
            RecibosPDF.Importe = double.Parse(EventoSeleccionado.MontoSena.ToString());
            RecibosPDF.FechaSenia = EventoSeleccionado.FechaSena;

            PanelReciboPDF.Visible = true;

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Default.aspx");
        }


    }
}