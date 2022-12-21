using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AmbientHouse.Presupuestos
{
    public partial class GestionPorEvento : System.Web.UI.Page
    {

        EventosServicios servicios = new EventosServicios();
        PresupuestosServicios serviciosPresupuestos = new PresupuestosServicios();
        ClientesServicios serviciosClientes = new ClientesServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();

        Comun cmd = new Comun();

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

        private List<PresupuestoDetalle> ListPresupuestoDetalleAprobados
        {
            get
            {
                return Session["ListPresupuestoDetalleAprobados"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalleAprobados"] = value;
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

        private DomainAmbientHouse.Entidades.ClientesPipedrive ClienteSeleccionado
        {
            get
            {
                return Session["ClienteSeleccionado"] as DomainAmbientHouse.Entidades.ClientesPipedrive;
            }
            set
            {
                Session["ClienteSeleccionado"] = value;
            }
        }

        private double PorcentajeOrganizador
        {
            get
            {
                return double.Parse(Session["PorcentajeOrganizadorApro"].ToString());
            }
            set
            {
                Session["PorcentajeOrganizadorApro"] = value;
            }
        }

        private double ImporteOrganizador
        {
            get
            {
                return double.Parse(Session["ImporteOrganizadorApro"].ToString());
            }
            set
            {
                Session["ImporteOrganizadorApro"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListPresupuestoDetalleAprobados = new List<PresupuestoDetalle>();
                ListPresupuestoDetalle = new List<PresupuestoDetalle>();
                ListPresupuestos = new List<ObtenerEventosPresupuestos>();

                InicializarPagina();

                PanelEventoGanado.Visible = false;
                PanelEventoPerdido.Visible = false;
                PanelGrillaEventos.Visible = true;
                PanelCheques.Visible = false;
                PanelTransferencia.Visible = false;

                LabelError.Visible = false;
                LabelMensajeError.Visible = false;

                CargarListas();

                PersonaFisicaoJuridica();

                PanelCliente.Visible = false;

            }
        }

        private void CargarListas()
        {
            DropDownListCondicionIva.Items.Clear();
            DropDownListCondicionIva.Items.Add("Resp. Inscripto");
            DropDownListCondicionIva.Items.Add("Monotributo");
            DropDownListCondicionIva.Items.Add("Exento");
            DropDownListCondicionIva.Items.Add("Consumidor Final");

            DropDownListFormadePago.DataSource = administrativas.ObtenerFormasdePago();
            DropDownListFormadePago.DataTextField = "Descripcion";
            DropDownListFormadePago.DataValueField = "Id";
            DropDownListFormadePago.DataBind();

            DropDownListBancos.DataSource = administrativas.ObtenerBancos();
            DropDownListBancos.DataTextField = "Identificador";
            DropDownListBancos.DataValueField = "Id";
            DropDownListBancos.DataBind();

            DropDownListBancoTransferencia.DataSource = administrativas.ObtenerCuentas().Where(o => o.TipoCuenta.Equals("BANCARIA")).ToList();
            DropDownListBancoTransferencia.DataTextField = "Nombre";
            DropDownListBancoTransferencia.DataValueField = "Id";
            DropDownListBancoTransferencia.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                EventoId = id;

                LabelNroEvento.Text = EventoId.ToString();

                EventoSeleccionado = servicios.BuscarEvento(EventoId);

                ClienteSeleccionado = ListClientesPipe.Where(o => o.Id == EventoSeleccionado.ClienteId).FirstOrDefault();

                GridViewPresupuestos.DataSource = servicios.BuscarPrespuestosPorEventos(EventoId);
                GridViewPresupuestos.DataBind();

            }

        }

        protected void ButtonVer_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewPresupuestos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPresupuestos.Rows[index];

                int EventoId = int.Parse(row.Cells[1].Text);

                int PresupuestoId = int.Parse(row.Cells[3].Text);

                //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
            else if (e.CommandName == "ContinuarPresupuesto")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPresupuestos.Rows[index];

                int EventoId = int.Parse(row.Cells[1].Text);
                int PresupuestoId = int.Parse(row.Cells[3].Text);


                Response.Redirect("~/Presupuestos/NuevoPresupuesto.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
            else if (e.CommandName == "Imprimir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPresupuestos.Rows[index];


                int PresupuestoId = int.Parse(row.Cells[3].Text);

                //LabelPresupuesto.Text = PresupuestoId.ToString();

                Presupuestos = new PresupuestoPDF();

                Presupuestos = serviciosPresupuestos.ObtenerPresupuestosPorPresupuesto(PresupuestoId, ListClientesPipe);

                //Image1.ImageUrl = "~/Presupuestos/PresupuestoCliente.ashx";

                if (Presupuestos != null) Response.Redirect("~/Presupuestos/Imprimir.aspx"); ;

                //UpdatePanelPresupuestos.Update();
            }
            else if (e.CommandName == "Descuentos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPresupuestos.Rows[index];

                int EventoId = int.Parse(row.Cells[1].Text);

                int PresupuestoId = int.Parse(row.Cells[3].Text);

                //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                Response.Redirect("~/Presupuestos/Descuentos.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }
            else if (e.CommandName == "Represupuestar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPresupuestos.Rows[index];

                int EventoId = int.Parse(row.Cells[1].Text);

                int PresupuestoId = int.Parse(row.Cells[3].Text);

                //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                Response.Redirect("~/Presupuestos/RePresupuestar.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
            }

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presupuestos/Nuevo.aspx?EventoId=" + EventoId);
        }

        protected void ButtonEventoGanado_Click(object sender, EventArgs e)
        {
            int CantidadChekeados = 0;
            LabelError.Visible = false;

            foreach (GridViewRow row in GridViewPresupuestos.Rows)
            {

                CheckBox check = row.FindControl("CheckBoxSeleccionarEvento") as CheckBox;

                if (check.Checked)
                {
                    CantidadChekeados = CantidadChekeados + 1;

                }
            }

            if (CantidadChekeados >= 1)
            {
                double importeOrganizador = 0;
                double porcentajeOrganizador = 0;

                foreach (GridViewRow row in GridViewPresupuestos.Rows)
                {
                    CheckBox check = row.FindControl("CheckBoxSeleccionarEvento") as CheckBox;

                    if (check.Checked)
                    {
                        PresupuestoId = int.Parse(row.Cells[3].Text);

                        PanelEventoGanado.Visible = true;

                        CargarEvento();

                        CargarPresupuesto(ref importeOrganizador, ref porcentajeOrganizador);

                        CargarDetallePresupuesto();


                    }
                }

                if (ListPresupuestoDetalle.Count > 0)
                {
                    GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
                    GridViewVentas.DataBind();

                }

                CalcularTotalPresupuesto();


                PanelCliente.Visible = false;
                TextBoxBuscadorCuitCuil.Visible = true;
                ButtonBuscar.Visible = true;
                PanelEventoPerdido.Visible = false;
                PanelGrillaEventos.Visible = false;



            }
            else { LabelError.Text = "NO PUEDE GANARSE UN EVENTO SIN UN SOLO PRESUPUESTO"; LabelError.Visible = true; }
        }

        private void CargarEvento()
        {
            EventoSeleccionado = new DomainAmbientHouse.Entidades.Eventos();

            EventoSeleccionado = servicios.BuscarEvento(EventoId);

            LabelNroEvent.Text = EventoSeleccionado.Id.ToString().PadLeft(8, '0');
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

                GridViewPresupuestosaAprobar.DataSource = ListPresupuestos.ToList();
                GridViewPresupuestosaAprobar.DataBind();

            }
        }

        private void CargarDetallePresupuesto()
        {

            ListPresupuestoDetalle = serviciosPresupuestos.BuscarDetallePresupuesto(PresupuestoId);


            //foreach (var item in Items)
            //{
            //    PresupuestoDetalle presu = new PresupuestoDetalle();

            //    presu.Id = item.Id;
            //    presu.PresupuestoId = item.PresupuestoId;
            //    presu.Cannon = item.Cannon;
            //    presu.CantidadAdicional = item.CantidadAdicional;
            //    presu.CantInvitadosLogistica = item.CantInvitadosLogistica;
            //    presu.CodigoItem = item.CodigoItem;
            //    presu.ProductoId = item.ProductoId;
            //    presu.Comision = item.Comision;
            //    presu.Costo = item.Costo;
            //    presu.Descuentos = item.Descuentos;

            //    presu.Logistica = item.Logistica;
            //    presu.PorcentajeComision = item.PorcentajeComision;
            //    presu.PrecioItem = item.PrecioItem;
            //    presu.PrecioLista = item.PrecioLista;
            //    presu.PrecioMas5 = item.PrecioMas5;
            //    presu.PrecioMenos10 = item.PrecioMenos10;
            //    presu.PrecioMenos5 = item.PrecioMenos5;
            //    presu.PrecioSeleccionado = item.PrecioSeleccionado;
            //    presu.ProductoDescripcion = item.ProductoDescripcion;

            //    presu.LocacionId = item.LocacionId;
            //    presu.ProveedorId = item.ProveedorId;

            //    presu.ServicioId = item.ServicioId;
            //    presu.TipoLogisticaId = item.TipoLogisticaId;
            //    presu.UnidadNegocioId = item.UnidadNegocioId;
            //    presu.ValorSeleccionado = item.ValorSeleccionado;
            //    presu.UsoCocina = item.UsoCocina;
            //    presu.version = item.version;
            //    presu.EstadoId = item.EstadoId;

            //    ListPresupuestoDetalle.Add(presu);
            //}



        }

        private void CalcularTotalPresupuesto()
        {
            //var query = (from L in ListPresupuestoDetalle
            //             select L.ValorSeleccionado + (L.Cannon == null ? 0 : L.Cannon) + (L.Logistica == null ? 0 : L.Logistica)).Sum();

            //double TotalOrganizador = 0;

            double TotalPresupuesto = 0;

            TotalPresupuesto = cmd.CalcularTotalPresupuestoPendiente(PresupuestoId, ListPresupuestoDetalle, PorcentajeOrganizador, ImporteOrganizador);



            //if (ImporteOrganizador > 0)
            //{ }
            //else if (PorcentajeOrganizador > 0)
            //{ }

            //TextBoxTotalOrganizador.Text = TotalPresupuesto.ToString();

            TextBoxTotalPresupuesto.Text = (System.Math.Round(TotalPresupuesto, 2)).ToString("C");

            TextBoxTotalPAX.Text = System.Math.Round((TotalPresupuesto / CantidadTotalInvitados), 2).ToString("C");
        }

        private void CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {


            CantidadTotalInvitados = Int32.Parse(cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes).ToString());

        }

        protected void ButtonEventoPerdido_Click(object sender, EventArgs e)
        {
            PanelEventoGanado.Visible = false;
            PanelEventoPerdido.Visible = true;
            PanelGrillaEventos.Visible = false;

            TextBoxNroEventoPerdido.Text = EventoId.ToString();

            if (EventoSeleccionado.RazonSocial != null)
                TextBoxClientePerdido.Text = EventoSeleccionado.ApellidoNombreCliente + " - " + EventoSeleccionado.RazonSocial;
            else
                TextBoxClientePerdido.Text = EventoSeleccionado.ApellidoNombreCliente;
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            PanelEventoGanado.Visible = false;
            PanelGrillaEventos.Visible = true;
            PanelEventoPerdido.Visible = false;

            //UpdatePanelGestionEventos.Update();

        }

        protected void GridViewPresupuestos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImprimirPresupuesto = (ImageButton)e.Row.FindControl("ButtonImprirmir");
                ImageButton verPresupuesto = (ImageButton)e.Row.FindControl("ButtonVer");
                ImageButton verDescuentos = (ImageButton)e.Row.FindControl("ImageDescuentos");
                ImageButton represupuestar = (ImageButton)e.Row.FindControl("ImageRepresupuestar");

                CheckBox seleccionado = (CheckBox)e.Row.FindControl("CheckBoxSeleccionarEvento");

                e.Row.Cells[13].Visible = false;

                verDescuentos.Visible = false;
                represupuestar.Visible = false;

                DateTime fechaEvento = DateTime.Parse(e.Row.Cells[9].Text);

                if (PerfilId == PerfilGerencial)
                    verDescuentos.Visible = true;

                if (e.Row.Cells[11].Text == "Guardado")
                {
                    ImprimirPresupuesto.Visible = false;

                    seleccionado.Visible = false;

                    e.Row.Cells[13].Visible = true;

                }

                if (e.Row.Cells[11].Text == "Vencido")
                {
                    ImprimirPresupuesto.Visible = false;

                    if (fechaEvento > System.DateTime.Today)
                        represupuestar.Visible = true;

                    seleccionado.Visible = false;

                    e.Row.Cells[13].Visible = false;


                }

                if (e.Row.Cells[11].Text == "Presupuesto a Revisar")
                {
                    ImprimirPresupuesto.Visible = false;
                    seleccionado.Visible = false;
                    e.Row.Cells[13].Visible = false;
                }

            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {

            //PersonaFisicaoJuridica();

            PanelCliente.Visible = false;
            string CuitCuil;

            LabelErrorCuit.Visible = false;

            //if (cmd.ValidarCuilCuit(TextBoxBuscadorCuitCuil.Text))
            //{

            TextBoxApellidoyNombre.Text = "";
            TextBoxRazonSocial.Text = "";
            TextBoxDomicilio.Text = "";

            TextBoxCorreoContratacion.Text = "";
            TextBoxCorreoAdministracion.Text = "";
            TextBoxCorreoTesoreria.Text = "";

            TextBoxTelContratacion.Text = "";
            TextBoxTelAdministracion.Text = "";
            TextBoxTelTesoreria.Text = "";

            CuitCuil = TextBoxBuscadorCuitCuil.Text;

            ClienteBisSeleccionado = serviciosClientes.BuscarClientePorCuitCuil(CuitCuil);

            if (ClienteBisSeleccionado != null)
            {
                PanelCliente.Visible = true;

                ClienteId = ClienteBisSeleccionado.Id;

                if (ClienteBisSeleccionado.PersonaFisicaJuridica == "FISICA")
                {
                    RadioButtonPF.Checked = true;

                    LabelApellidoyNombre.Visible = true;
                    TextBoxApellidoyNombre.Visible = true;

                    TextBoxApellidoyNombre.Text = ClienteBisSeleccionado.ApellidoNombre;

                    LabelRazonSocial.Visible = false;
                    TextBoxRazonSocial.Visible = false;


                }
                else
                {
                    RadioButtonPJ.Checked = true;

                    LabelRazonSocial.Visible = true;
                    TextBoxRazonSocial.Visible = true;

                    TextBoxRazonSocial.Text = ClienteBisSeleccionado.RazonSocial;

                    LabelApellidoyNombre.Visible = false;
                    TextBoxApellidoyNombre.Visible = false;


                }



                TextBoxCuilCuit.Text = CuitCuil;
                TextBoxDomicilio.Text = ClienteBisSeleccionado.Direccion;
                DropDownListCondicionIva.SelectedValue = ClienteBisSeleccionado.CondicionIva;
                DropDownListTipoCliente.SelectedValue = ClienteBisSeleccionado.TipoCliente;


                TextBoxCorreoContratacion.Text = ClienteBisSeleccionado.MailContactoContratacion;
                TextBoxCorreoAdministracion.Text = ClienteBisSeleccionado.MailContactoAdministracion;
                TextBoxCorreoTesoreria.Text = ClienteBisSeleccionado.MailContactoTesoreia;
                TextBoxCorreoOrganizacion.Text = ClienteBisSeleccionado.MailContactoOrganizacion;

                TextBoxTelContratacion.Text = ClienteBisSeleccionado.TelContactoContratacion;
                TextBoxTelAdministracion.Text = ClienteBisSeleccionado.TelContactoAdministracion;
                TextBoxTelTesoreria.Text = ClienteBisSeleccionado.TelContactoTesoreria;
                TextBoxTelOrganizacion.Text = ClienteBisSeleccionado.TelContactoOrganizacion;


            }
            else
            {
                RadioButtonPF.Checked = true;
                TextBoxApellidoyNombre.Visible = true;
                ClienteId = 0;
                TextBoxCuilCuit.Text = TextBoxBuscadorCuitCuil.Text;
                PanelCliente.Visible = true;
            }

            //}
            //else
            //{
            //    LabelErrorCuit.Visible = true;
            //    LabelErrorCuit.Text = "El Cuit/Cuil no es Valido.";
            //}

            UpdatePanelClientes.Update();
        }

        private void PersonaFisicaoJuridica()
        {

            TextBoxApellidoyNombre.Visible = false;
            LabelApellidoyNombre.Visible = false;

            TextBoxRazonSocial.Visible = false;
            LabelRazonSocial.Visible = false;

            if (RadioButtonPF.Checked)
            {
                TextBoxApellidoyNombre.Visible = RadioButtonPF.Checked;
                LabelApellidoyNombre.Visible = RadioButtonPF.Checked;

            }
            else
            {
                TextBoxRazonSocial.Visible = RadioButtonPJ.Checked;
                LabelRazonSocial.Visible = RadioButtonPJ.Checked;

            }

            UpdatePanelClientes.Update();

        }

        protected void ButtonAceptarGanado_Click(object sender, EventArgs e)
        {

            if (Validar())
            {

                GanarEvento();

            }

        }

        private bool Validar()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            LabelMensajeError.Visible = false;

            if (TextBoxCuilCuit.Text == "")
            {
                LabelMensajeError.Text = "Debe Cargar el Cuil/Cuit para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;
            }

            if (TextBoxDomicilio.Text == "")
            {
                LabelMensajeError.Text = "Debe Cargar el Domicilio del Cliente para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;
            }

            if (RadioButtonPF.Checked)
            {
                if (TextBoxApellidoyNombre.Text == "")
                {
                    LabelMensajeError.Text = "Debe Cargar el Apellido y Nombre del Cliente para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }
            }
            else
            {
                if (TextBoxRazonSocial.Text == "")
                {
                    LabelMensajeError.Text = "Debe Cargar la Razon Social del Cliente para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

            }


            if (!cmd.IsNumeric(TextBoxMontoSenia.Text))
            {
                LabelMensajeError.Text = "Debe Cargar el Monto de la senia para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;
            }

            if (FileUploadComprobanteMailAprobacion.HasFile == false)
            {
                LabelMensajeError.Text = "Debe Cargar la imagen del Mail de Confirmacion del Presupuesto para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;

            }

            if (!cmd.ValidarExtensionTexto(System.IO.Path.GetExtension(FileUploadComprobanteMailAprobacion.FileName)))
            {
                LabelMensajeError.Text = "El tipo de Archivo a subir como comprobante de Aprobacion no es un archivo de Texto.";
                LabelMensajeError.Visible = true;

                return false;

            }

            if (!cmd.IsDate(TextBoxFechaSenia.Text))
            {
                LabelMensajeError.Text = "Debe Cargar la fecha de la senia o la misma no es valida para poder continuar.";
                LabelMensajeError.Visible = true;

                return false;

            }

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaCheque)
            {
                if (!cmd.IsDate(TextBoxFechaEmision.Text))
                {
                    LabelMensajeError.Text = "Debe Cargar la fecha de Emision del Cheque o la misma no es valida para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaVencimiento.Text))
                {
                    LabelMensajeError.Text = "Debe Cargar la fecha de Vencimiento del Cheque o la misma no es valida para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

                if (TextBoxNroCheque.Text == "")
                {
                    LabelMensajeError.Text = "Debe Cargar el Nro de Cheque para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }


            }
            else if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaTransferencia)
            {

                if (TextBoxNroComprobanteTrans.Text == "")
                {
                    LabelMensajeError.Text = "Debe Cargar el Nro de Transferencia para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }

                if (!cmd.IsDate(TextBoxFechaComprobanteTrans.Text))
                {
                    LabelMensajeError.Text = "Debe Cargar la fecha de Transferencia o la misma no es valida para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;
                }


                if (FileUploadComprobanteTransferencia.HasFile == false)
                {
                    LabelMensajeError.Text = "Debe Cargar el Comprobante de Transferencia para poder continuar.";
                    LabelMensajeError.Visible = true;

                    return false;

                }

                if (!cmd.ValidarExtensionTexto(System.IO.Path.GetExtension(FileUploadComprobanteTransferencia.FileName)))
                {
                    LabelMensajeError.Text = "El tipo de Archivo a subir como comprobante de Transferencia no es un archivo de Texto";
                    LabelMensajeError.Visible = true;

                    return false;

                }
            }

            return true;
        }

        private void GanarEvento()
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            DomainAmbientHouse.Entidades.ClientesBis cliente = new DomainAmbientHouse.Entidades.ClientesBis();

            DomainAmbientHouse.Entidades.PagosClientes pagoCliente = new PagosClientes();

            int EventoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());

            int PresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            if (RadioButtonPF.Checked == true) { cliente.PersonaFisicaJuridica = "FISICA"; }
            else { cliente.PersonaFisicaJuridica = "JURIDICA"; }

            cliente.Id = ClienteId;

            cliente.ApellidoNombre = TextBoxApellidoyNombre.Text;
            cliente.CUILCUIT = TextBoxCuilCuit.Text;
            cliente.RazonSocial = TextBoxRazonSocial.Text;
            cliente.Direccion = TextBoxDomicilio.Text;
            cliente.CondicionIva = DropDownListCondicionIva.SelectedItem.Text;
            cliente.TipoCliente = DropDownListTipoCliente.SelectedItem.Value;

            cliente.MailContactoContratacion = TextBoxCorreoContratacion.Text;
            cliente.MailContactoAdministracion = TextBoxCorreoAdministracion.Text;
            cliente.MailContactoTesoreia = TextBoxCorreoTesoreria.Text;
            cliente.MailContactoOrganizacion = TextBoxCorreoOrganizacion.Text;

            cliente.TelContactoContratacion = TextBoxTelContratacion.Text;
            cliente.TelContactoAdministracion = TextBoxTelAdministracion.Text;
            cliente.TelContactoTesoreria = TextBoxTelTesoreria.Text;
            cliente.TelContactoOrganizacion = TextBoxTelOrganizacion.Text;

            DomainAmbientHouse.Entidades.Eventos evento = servicios.BuscarEvento(EventoId);

            if (TextBoxFechaSenia.Text != "")
            {
                evento.FechaSena = DateTime.ParseExact(TextBoxFechaSenia.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                evento.FechaSena = System.DateTime.Today;
            }

            evento.MontoSena = cmd.ValidarImportes(TextBoxMontoSenia.Text);
            evento.EmpleadoId = EmpleadoId;
            evento.ComprobanteAprovacion = FileUploadComprobanteMailAprobacion.FileBytes;
            evento.ComprobanteAprovacionExtension = System.IO.Path.GetExtension(FileUploadComprobanteMailAprobacion.FileName);
            evento.FormadePagoId = Int32.Parse(DropDownListFormadePago.SelectedItem.Value);
            evento.EstadoId = EventoAprobado;
            evento.Comentario = TextBoxComentario.Text;

            DomainAmbientHouse.Entidades.Cheques cheque = new DomainAmbientHouse.Entidades.Cheques();

            DomainAmbientHouse.Entidades.Transferencias transferencia = new Transferencias();

            if (evento.FormadePagoId == FormaCheque)
            {
                int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString()); ;

                cheque.NroCheque = TextBoxNroCheque.Text;
                cheque.Importe = cmd.ValidarImportes(TextBoxMontoSenia.Text);
                cheque.FechaEmision = DateTime.ParseExact(TextBoxFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.FechaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cheque.BancoId = Int32.Parse(DropDownListBancos.SelectedItem.Value);
                cheque.BancoDescripcion = DropDownListBancos.SelectedItem.Text;
                cheque.TipoCheque = "DE TERCEROS";
                cheque.Observaciones = TextBoxObservaciones.Text;
                cheque.EstadoId = Pendiente;

            }
            else if (evento.FormadePagoId == FormaTransferencia)
            {
                if (TextBoxNroComprobanteTrans.Text != "")
                    evento.NroComprobanteTransSenia = TextBoxNroComprobanteTrans.Text;

                //if (cmd.IsDate(TextBoxFechaComprobanteTrans.Text))
                //    evento.FechaComprobanteTransSenia = DateTime.Parse(TextBoxFechaComprobanteTrans.Text);

                //evento.ComprobanteTransferencia = FileUploadComprobanteTransferencia.FileBytes;
                //evento.ComprobanteTransferenciaExtension = System.IO.Path.GetExtension(FileUploadComprobanteTransferencia.FileName);

                transferencia.BancoId = int.Parse(DropDownListBancoTransferencia.SelectedItem.Value);
                transferencia.NroTransferencia = TextBoxNroComprobanteTrans.Text;
                transferencia.FechaTransferencia = DateTime.ParseExact(TextBoxFechaComprobanteTrans.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                transferencia.Importe = cmd.ValidarImportes(TextBoxMontoSenia.Text);
                transferencia.Comprobante = FileUploadComprobanteTransferencia.FileBytes;
                transferencia.ComprobanteExtension = System.IO.Path.GetExtension(FileUploadComprobanteTransferencia.FileName);
                transferencia.NombreArchivo = System.IO.Path.GetFileName(FileUploadComprobanteTransferencia.FileName);


            }




            DomainAmbientHouse.Entidades.Presupuestos presupuesto = servicios.BuscarPresupuesto(PresupuestoId);

            presupuesto.EstadoId = PresupuestoAprobado;


            foreach (GridViewRow row in GridViewPresupuestosaAprobar.Rows)
            {

                int presupuestoId = Int32.Parse(row.Cells[13].Text);

                List<PresupuestoDetalle> list = serviciosPresupuestos.BuscarDetallePresupuesto(presupuestoId);

                foreach (var item in list)
                {
                    PresupuestoDetalle detalle = new PresupuestoDetalle();

                    detalle.PresupuestoId = item.PresupuestoId;
                    detalle.Cannon = item.Cannon;
                    detalle.CantidadAdicional = item.CantidadAdicional;
                    detalle.CantInvitadosLogistica = item.CantInvitadosLogistica;
                    detalle.CodigoItem = item.CodigoItem;
                    detalle.ProductoId = item.ProductoId;
                    detalle.Comision = item.Comision;
                    detalle.Costo = item.Costo;
                    detalle.Descuentos = item.Descuentos;
                    detalle.Incremento = item.Incremento;
                    detalle.Logistica = item.Logistica;
                    detalle.PorcentajeComision = item.PorcentajeComision;
                    detalle.PrecioItem = item.PrecioItem;
                    detalle.PrecioLista = item.PrecioLista;
                    detalle.PrecioMas5 = item.PrecioMas5;
                    detalle.PrecioMenos10 = item.PrecioMenos10;
                    detalle.PrecioMenos5 = item.PrecioMenos5;
                    detalle.PrecioSeleccionado = item.PrecioSeleccionado;
                    detalle.ProductoDescripcion = item.ProductoDescripcion;
                    detalle.LocacionId = item.LocacionId;
                    detalle.ProveedorId = item.ProveedorId;
                    detalle.ServicioId = item.ServicioId;
                    detalle.TipoLogisticaId = item.TipoLogisticaId;
                    detalle.UnidadNegocioId = item.UnidadNegocioId;
                    detalle.ValorSeleccionado = item.ValorSeleccionado;
                    detalle.UsoCocina = item.UsoCocina;
                    detalle.version = item.version;
                    detalle.ValorIntermediario = item.ValorIntermediario;
                    detalle.Comentario = item.Comentario;
                    detalle.AnuloCanon = item.AnuloCanon;
                    detalle.CostoSillas = item.CostoSillas;
                    detalle.CostoMesas = item.CostoMesas;
                    detalle.PrecioSillas = item.PrecioSillas;
                    detalle.PrecioMesas = item.PrecioMesas;
                    detalle.Royalty = item.Royalty;

                    ListPresupuestoDetalleAprobados.Add(detalle);

                }

            }


            Mail mailAprobacion = new Mail();

            servicios.AprobarPresupuesto(evento, ListPresupuestos, cliente, ListPresupuestoDetalleAprobados, cheque, transferencia);



            foreach (var item in ListPresupuestos)
            {
                //mailAprobacion.envioMailAprobadoComercial(item.PresupuestoId, evento.Id);
            }


            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void DropDownListFormadePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FormaCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int FormaTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            PanelCheques.Visible = false;
            PanelTransferencia.Visible = false;

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaCheque)
            {
                PanelCheques.Visible = true;

            }

            if (Int32.Parse(DropDownListFormadePago.SelectedItem.Value) == FormaTransferencia)
            {
                PanelTransferencia.Visible = true;
            }

            UpdatePanelFormasdePago.Update();
        }

        protected void ButtonVolverPerdido_Click(object sender, EventArgs e)
        {
            PanelEventoGanado.Visible = false;
            PanelEventoPerdido.Visible = false;
            PanelGrillaEventos.Visible = true;
        }

        protected void ButtonVolverGanado_Click(object sender, EventArgs e)
        {
            PanelEventoGanado.Visible = false;
            PanelEventoPerdido.Visible = false;
            PanelGrillaEventos.Visible = true;
        }

        protected void ButtonAceptarPerido_Click(object sender, EventArgs e)
        {
            PerderEvento();

        }

        private void PerderEvento()
        {
            int EventoPerdido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());

            servicios.EventoPerdido(EventoId, EventoPerdido, TextBoxComentario.Text);

            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void RadioButtonPJ_CheckedChanged(object sender, EventArgs e)
        {
            PersonaFisicaoJuridica();
        }

        protected void RadioButtonPF_CheckedChanged(object sender, EventArgs e)
        {
            PersonaFisicaoJuridica();
        }



    }
}