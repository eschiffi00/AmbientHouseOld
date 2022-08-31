using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Seguridad;
using System.Configuration;

namespace AmbientHouse.Inicio
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

        EventosServicios eventos = new EventosServicios();
        SeguridadServicios seguridad = new SeguridadServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();

        Comun cmd = new Comun();
        Pipedrive pipedrive = new Pipedrive();
        Mail mail = new Mail();

        protected void Page_Load(object sender, EventArgs e)
        {

            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = Int32.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = Int32.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());

            if (!IsPostBack)
            {

                Buscar();

                ButtonNuevoEvento.Visible = false;
                ButtonEventosGuardados.Visible = false;
                ButtonEventosPendientes.Visible = false;
                ButtonEventoGanado.Visible = false;
                ButtonVerPresupuestos.Visible = false;
                ButtonConfiguracion.Visible = false;
                ButtonReportes.Visible = false;
                ButtonAdministracion.Visible = false;
                ButtonRRHH.Visible = false;
                ButtonVerCalendario.Visible = false;

                if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
                {
                    ButtonNuevoEvento.Visible = true;

                    ButtonEventosGuardados.Visible = true;
                    ButtonEventosPendientes.Visible = true;
                    ButtonEventoGanado.Visible = true;

                    ButtonConfiguracion.Visible = true;
                    ButtonReportes.Visible = true;
                    ButtonAdministracion.Visible = true;
                    ButtonRRHH.Visible = true;
                    ButtonVerCalendario.Visible = true;


                    ButtonVerPresupuestos.Visible = true;
                }
                else if (PerfilId == PerfilOrganizador)
                {
                    ButtonVerCalendario.Visible = true;
                }
                else if (PerfilId == PerfilOperacion)
                { 
                    ButtonVerCalendario.Visible = true; 
                }
                else if (PerfilId == PerfilEjecutivo)
                {
                    ButtonNuevoEvento.Visible = true;
                    ButtonEventosGuardados.Visible = true;
                    ButtonEventosPendientes.Visible = true;
                    ButtonEventoGanado.Visible = true;

                    ButtonVerPresupuestos.Visible = true;
                }


            }


        }

        private void CalculodeObjetivos()
        {
            AdministrativasServicios administrativas = new AdministrativasServicios();
            LabelEmpleado.Text = administrativas.BuscarEmpleado(EmpleadoId).ApellidoNombre;

            List<ObjetivosEmpleados> Objetivos = administrativas.BuscarObjetivosPorEmpleado(EmpleadoId);

            if (Objetivos.Count > 0)
            {
                int mes = System.DateTime.Today.Month;
                int anio = System.DateTime.Today.Year;

                int trimestre = cmd.ObtenerTrimetreActual();

                LabelObjetivoMensual.Text = "Facturacion " + (System.Math.Round(Objetivos.Where(o => o.Mes == mes && o.Anio == anio).Sum(o => o.Facturacion), 2)).ToString("C") + " Cant. Eventos " + Objetivos.Where(o => o.Mes == mes && o.Anio == anio).Select(o => o.CantidadAperturas).SingleOrDefault();
                LabelObjetivoQ.Text = "Facturacion " + (System.Math.Round(Objetivos.Where(o => o.Trimestre == trimestre).Sum(o => o.Facturacion), 2)).ToString("C") + " Cant. Eventos " + Objetivos.Where(o => o.Trimestre == trimestre).Sum(o => o.CantidadAperturas);

            }
            else
            {
                LabelObjetivoMensual.Text = "NO POSEE OBJETIVOS DE VENTA SU PERFIL";

            }
        }

        private bool BuscarEventosGuardados()
        {

            NoMostrarGrillas();


            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());


            int nroEvento = 0;
            int nroPresupuesto = 0;
            int nroCliente = 0;
            string apellidoynombre;
            string razonsocial;


            apellidoynombre = TextBoxApellidoBuscador.Text;
            razonsocial = TextBoxRazonSocialBuscador.Text;


            if (cmd.IsNumeric(TextBoxNroEventoBuscador.Text)) nroEvento = int.Parse(TextBoxNroEventoBuscador.Text);
            if (cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text)) nroPresupuesto = int.Parse(TextBoxNroPresupuestoBuscador.Text);

            List<ObtenerEventosPresupuestos> ListaEventos = eventos.BuscarEventosGuardadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, ListClientesPipe);

            if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
            {
                GridViewEventosGuardados.DataSource = ListaEventos.ToList();
                GridViewEventosGuardados.DataBind();

                GridViewEventosGuardados.Visible = true;


            }
            else if (PerfilId == PerfilEjecutivo)
            {
                GridViewEventosGuardadosEjecutivos.DataSource = ListaEventos.ToList();
                GridViewEventosGuardadosEjecutivos.DataBind();

                GridViewEventosGuardadosEjecutivos.Visible = true;


            }

            string Cant = "0";

            Cant = (ListaEventos.ToList().Count).ToString();

            Label1.Text = Label1.Text.Replace("@", Cant);

            UpdatePanelInicio.Update();

            return (GridViewEventosGuardados.Rows.Count > 0);
        }

        private void NoMostrarGrillas()
        {
            GridViewEventosGuardados.Visible = false;
            GridViewEventosGanados.Visible = false;
            GridViewEventosPendientes.Visible = false;
            GridViewEventosPerdidos.Visible = false;

            GridViewEventosGuardadosEjecutivos.Visible = false;
            GridViewEventosGanadosEjecutivos.Visible = false;
            GridViewEventosPendientesEjecutivos.Visible = false;
        }

        private bool BuscarEventosPendientes()
        {

            NoMostrarGrillas();


            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());


            int nroEvento = 0;
            int nroPresupuesto = 0;
            int nroCliente = 0;
            string apellidoynombre;
            string razonsocial;

            //if (cmd.IsNumeric(TextBoxNroClienteBuscador.Text)) nroCliente = int.Parse(TextBoxNroClienteBuscador.Text);
            if (cmd.IsNumeric(TextBoxNroEventoBuscador.Text)) nroEvento = int.Parse(TextBoxNroEventoBuscador.Text);
            if (cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text)) nroPresupuesto = int.Parse(TextBoxNroPresupuestoBuscador.Text);

            apellidoynombre = TextBoxApellidoBuscador.Text;
            razonsocial = TextBoxRazonSocialBuscador.Text;

            List<ObtenerEventosPresupuestos> ListaEventos = eventos.BuscarEventosActivosPorEjecutivoSeguimiento(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, ListClientesPipe);


            if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
            {

                GridViewEventosPendientes.DataSource = ListaEventos.ToList();
                GridViewEventosPendientes.DataBind();

                GridViewEventosPendientes.Visible = true;
            }
            else if (PerfilId == PerfilEjecutivo)         
            {
                GridViewEventosPendientesEjecutivos.DataSource = ListaEventos.ToList();
                GridViewEventosPendientesEjecutivos.DataBind();

                GridViewEventosPendientesEjecutivos.Visible = true;
            }



            string Cant = "0";

            Cant = (ListaEventos.ToList().Count).ToString();

            Label2.Text = Label2.Text.Replace("@", Cant);


            UpdatePanelInicio.Update();

            return (GridViewEventosPendientes.Rows.Count > 0);
        }

        private bool BuscarEventosGanados()
        {

            NoMostrarGrillas();

            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());

            int nroEvento = 0;
            int nroPresupuesto = 0;
            int nroCliente = 0;

            //if (cmd.IsNumeric(TextBoxNroClienteBuscador.Text)) nroCliente = int.Parse(TextBoxNroClienteBuscador.Text);
            if (cmd.IsNumeric(TextBoxNroEventoBuscador.Text)) nroEvento = int.Parse(TextBoxNroEventoBuscador.Text);
            if (cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text)) nroPresupuesto = int.Parse(TextBoxNroPresupuestoBuscador.Text);

            string fecha ="";

            List<ObtenerEventosPresupuestos> ListaEventos = eventos.BuscarEventosReservadosPorEjecutivos(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, fecha);
            if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
            {

                GridViewEventosGanados.DataSource = ListaEventos.ToList();
                GridViewEventosGanados.DataBind();

                GridViewEventosGanados.Visible = true;
            }
            else if (PerfilId == PerfilEjecutivo)
            {

                GridViewEventosGanadosEjecutivos.DataSource = ListaEventos.ToList();
                GridViewEventosGanadosEjecutivos.DataBind();

                GridViewEventosGanadosEjecutivos.Visible = true;
            }




            string Cant = "0";

            Cant = (ListaEventos.ToList().Count).ToString();

            Label3.Text = Label3.Text.Replace("@", Cant);

            UpdatePanelInicio.Update();


            return (GridViewEventosGanados.Rows.Count > 0);
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {


            BuscarEventosGuardados();
            BuscarEventosGanados();
            //BuscarEventosPerdidos();
            BuscarEventosPendientes();

            UpdatePanelBotones.Update();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxApellidoBuscador.Text = "";
            TextBoxNroEventoBuscador.Text = "";
            TextBoxNroPresupuestoBuscador.Text = "";

            Buscar();
        }

        protected void ButtonEventoGanado_Click(object sender, EventArgs e)
        {


            BuscarEventosGanados();
        }

        protected void GridViewEventosPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosPendientes.PageIndex = e.NewPageIndex;
            BuscarEventosPendientes();
        }

        protected void GridViewEventosGanados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosGanados.PageIndex = e.NewPageIndex;
            BuscarEventosGanados();
        }

        protected void ButtonEventosPendientes_Click(object sender, EventArgs e)
        {
            BuscarEventosPendientes();
        }

        protected void ButtonEventoPerdido_Click(object sender, EventArgs e)
        {
            //BuscarEventosPerdidos();
        }

        protected void GridViewEventosPerdidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosPerdidos.PageIndex = e.NewPageIndex;
            //BuscarEventosPerdidos();
        }

        protected void ButtonEventosGuardados_Click(object sender, EventArgs e)
        {

            BuscarEventosGuardados();
        }

        protected void GridViewEventosGuardados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosGuardados.PageIndex = e.NewPageIndex;
            BuscarEventosGuardados();
        }

        protected void ButtonNuevoEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presupuestos/Nuevo.aspx");
        }

        protected void ButtonConfiguracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Index.aspx");
        }

        protected void ButtonMisArchivos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Herramientas/MisArchivos/Index.aspx");
        }

        protected void ButtonHerramientas_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Herramientas/Corporativos/Index.aspx");

            Response.Redirect("~/Inicio/Index.aspx");

        }

        protected void ButtonAdministracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           
            List<UsuariosPipedrive> list = pipedrive.ObtenerListaUsuariosPipedrive();


        }

        protected void ButtonRRHH_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RRHH/Index.aspx");
        }

        protected void GridViewEventosGuardadosEjecutivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosGuardados.PageIndex = e.NewPageIndex;
            BuscarEventosGuardados();
        }

        protected void GridViewEventosGuardados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Parametros paramRentaPorc = new Parametros();

            paramRentaPorc = administrativas.BuscarParametro("ValorRentaenPorcentajeMinimo");

            Parametros paramRentaImporte = new Parametros();

            paramRentaImporte = administrativas.BuscarParametro("ValorRentaenNominalMinimo");


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image Imagen = (Image)e.Row.FindControl("ImageRojo");



                if (double.Parse(e.Row.Cells[11].Text.Replace("$", "")) < double.Parse(paramRentaImporte.Valor.ToString()))
                {
                    Imagen.ImageUrl = "~/Content/Imagenes/rojo.png";



                }
                else Imagen.ImageUrl = "~/Content/Imagenes/verde.png";

                if (double.Parse(e.Row.Cells[10].Text.Replace("$", "")) < double.Parse(paramRentaPorc.Valor.ToString()))
                {

                    Imagen.ImageUrl = "~/Content/Imagenes/rojo.png";


                }
                else Imagen.ImageUrl = "~/Content/Imagenes/verde.png";
            }
        }

        protected void ButtonVerPresupuestos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/PresupuestosEnviadosSistemaAnterior.aspx");
        }

        protected void ButtonVerCalendario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Calendario.aspx");
        }

        protected void GridViewEventosPendientesEjecutivos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text == "Vencido")
                {


                    e.Row.Cells[7].Text = "VENCIDO!!";
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;

                }
            }
        }

        protected void GridViewEventosPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text == "Vencido")
                {


                    e.Row.Cells[8].Text = "VENCIDO!!";
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;

                }
            }
        }

     

    }
}