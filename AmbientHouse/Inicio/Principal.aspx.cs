using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace AmbientHouse.Inicio
{
    public partial class Principal : System.Web.UI.Page
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

        private int UsuarioId
        {
            get
            {
                return Int32.Parse(Session["UsuarioId"].ToString());
            }
            set
            {
                Session["UsuarioId"] = value;
            }
        }

        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = Int32.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = Int32.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilGestor = int.Parse(ConfigurationManager.AppSettings["Gestor"].ToString());

            LabelErrores.Visible = false;

            if (!IsPostBack)
            {


                ButtonNuevoEvento.Visible = false;
                //ButtonConfiguracion.Visible = false;
                //ButtonReportes.Visible = false;
                //ButtonAdministracion.Visible = false;
                ButtonVerCalendario.Visible = false;
                ButtonStock.Visible = false;
                GridViewEventosEjecutivos.Visible = false;
                GridViewEventosGerencial.Visible = false;
                PanelCarga.Visible = false;

                if (this.HayDegustacionesAbiertas())
                {
                    this.ButtonDegustacion.Visible = true;
                }


                if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
                {
                    ButtonNuevoEvento.Visible = true;
                    //ButtonConfiguracion.Visible = true;
                    //ButtonReportes.Visible = true;
                    //ButtonAdministracion.Visible = true;
                    ButtonVerCalendario.Visible = true;
                    ButtonStock.Visible = true;
                    GridViewEventosGerencial.Visible = true;

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
                    GridViewEventosEjecutivos.Visible = true;
                }
                else if (PerfilId == PerfilGestor)
                {
                    ButtonNuevoEvento.Visible = true;
                    GridViewEventosEjecutivos.Visible = true;
                }

            }
        }

        private bool HayDegustacionesAbiertas()
        {
            AdministrativasServicios servicios = new AdministrativasServicios();
            int degustacionAbierta = int.Parse(ConfigurationManager.AppSettings["DegustacionAbierta"].ToString());
            return ((from o in servicios.ObtenerDegustacion()
                     where o.EstadoId == degustacionAbierta
                     select o).Count<DomainAmbientHouse.Entidades.Degustacion>() > 0);
        }

        #region Botones

        protected void ButtonBuscarEventos_Click(object sender, EventArgs e)
        {


            CargarWorking();

            if (ValidarBusqueda())
                BuscarEventos();
            else
            {
                LimpiarGrillas();
            }



            UpdatePanelGrillas.Update();
        }

        private void CargarWorking()
        { 
            PanelCarga.Visible = true; 
        }

        protected void ButtonNuevoEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presupuestos/Nuevo.aspx");
        }

        protected void ButtonVerCalendario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Calendario.aspx");
        }

        protected void ButtonConfiguracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Index.aspx");
        }

        protected void ButtonHerramientas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Index.aspx");
        }

        protected void ButtonAdministracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void ButtonRRHH_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RRHH/Index.aspx");
        }

        protected void ButtonCambioPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Seguridad/CambioPassword.aspx");
        }

        protected void ButtonPedirCotizacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PedidosCotizacion/Index.aspx");
        }

        protected void ButtonDegustacion_Click(object sender, EventArgs e)
        {

            base.Response.Redirect("~/Inicio/Degustacion/Index.aspx");
        }

        protected void ButtonStock_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Existencias/Index.aspx");
        }

        #endregion

        protected void GridViewEventosGerencial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button continuarEvento = (Button)e.Row.FindControl("ButtonContinuarEvento");
                Button ver = (Button)e.Row.FindControl("ButtonVer");
                Button venderAdicionales = (Button)e.Row.FindControl("ButtonVenderAdicionales");
                Button establecerInvitados = (Button)e.Row.FindControl("ButtonEstablecerInvitados");
                ImageButton verLupa = (ImageButton)e.Row.FindControl("ImageButtonVer");

                continuarEvento.Visible = false;
                ver.Visible = false;
                venderAdicionales.Visible = false;
                establecerInvitados.Visible = false;
                verLupa.Visible = false;

                switch (e.Row.Cells[8].Text)
                {
                    case "Vencido":
                        e.Row.Cells[8].Text = "VENCIDO!!";
                        e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                        ver.Visible = true;

                        break;

                    case "Enviado al Cliente":
                        ver.Visible = true;
                        break;

                    case "Guardado":
                        continuarEvento.Visible = true;
                        break;

                    case "Aprobado":
                        if (e.Row.Cells[7].Text != "Cerrado")
                        {
                            venderAdicionales.Visible = true;
                            establecerInvitados.Visible = true;
                        }
                        break;
                    case "Realizado":

                        verLupa.Visible = true;

                        break;

                    default:
                        break;
                }

                Parametros paramRentaPorc = new Parametros();

                paramRentaPorc = administrativas.BuscarParametro("ValorRentaenPorcentajeMinimo");

                Parametros paramRentaImporte = new Parametros();

                paramRentaImporte = administrativas.BuscarParametro("ValorRentaenNominalMinimo");

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

        protected void GridViewEventosGerencial_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int EventoId = 0;
            int PresupuestoId = 0;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewEventosGerencial.Rows[index];

            switch (e.CommandName)
            {
                case "Continuar":

                    EventoId = Int32.Parse(row.Cells[0].Text);
                    PresupuestoId = Int32.Parse(row.Cells[1].Text);


                    Response.Redirect("~/Presupuestos/Nuevo.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

                case "Ver":

                    EventoId = Int32.Parse(row.Cells[0].Text);

                    //Response.Redirect("~/PresupuestosEventos/Index.aspx?Id=" + EventoId);
                    Response.Redirect("~/Presupuestos/GestionPorEvento.aspx?Id=" + EventoId);
                    break;

                case "VenderAdicionales":
                    EventoId = Int32.Parse(row.Cells[0].Text);
                    PresupuestoId = Int32.Parse(row.Cells[1].Text);


                    Response.Redirect("~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

                case "Invitados":
                    EventoId = Int32.Parse(row.Cells[0].Text);
                    PresupuestoId = Int32.Parse(row.Cells[1].Text);


                    Response.Redirect("~/Presupuestos/EstablecerCantidadInvitados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

                case "VerLupa":
             
                    EventoId = int.Parse(row.Cells[0].Text);

                    PresupuestoId = int.Parse(row.Cells[1].Text);

                    //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                    Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

              
                default:
                    break;
            }


        }

        protected void GridViewEventosEjecutivos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button continuarEvento = (Button)e.Row.FindControl("ButtonContinuarEvento");
                Button ver = (Button)e.Row.FindControl("ButtonVer");
                Button venderAdicionales = (Button)e.Row.FindControl("ButtonVenderAdicionales");
                Button establecerInvitados = (Button)e.Row.FindControl("ButtonEstablecerInvitados");

                continuarEvento.Visible = false;
                ver.Visible = false;
                venderAdicionales.Visible = false;
                establecerInvitados.Visible = false;

                switch (e.Row.Cells[8].Text)
                {
                    case "Vencido":
                        e.Row.Cells[8].Text = "VENCIDO!!";
                        e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                        ver.Visible = true;

                        break;

                    case "Enviado al Cliente":
                        ver.Visible = true;
                        break;

                    case "Guardado":
                        continuarEvento.Visible = true;
                        break;

                    case "Aprobado":
                        if (e.Row.Cells[7].Text != "Cerrado")
                        {
                            venderAdicionales.Visible = true;
                            establecerInvitados.Visible = true;
                        }

                        break;

                    case "Realizado":

                        ver.Visible = true;

                        break;

                    default:
                        break;
                }

            }
        }

        protected void GridViewEventosEjecutivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int EventoId = 0;
            int PresupuestoId = 0;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewEventosEjecutivos.Rows[index];

            switch (e.CommandName)
            {
                case "Continuar":

                    EventoId = Int32.Parse(row.Cells[0].Text);
                    PresupuestoId = Int32.Parse(row.Cells[1].Text);

                    Response.Redirect("~/Presupuestos/Nuevo.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

                case "Ver":
                    EventoId = Int32.Parse(row.Cells[0].Text);

                    Response.Redirect("~/Presupuestos/GestionPorEvento.aspx?Id=" + EventoId);
                    break;

                case "VenderAdicionales":
                    EventoId = Int32.Parse(row.Cells[0].Text);
                    PresupuestoId = Int32.Parse(row.Cells[1].Text);

                    Response.Redirect("~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

                case "Invitados":
                    EventoId = Int32.Parse(row.Cells[0].Text);
                    PresupuestoId = Int32.Parse(row.Cells[1].Text);

                    Response.Redirect("~/Presupuestos/EstablecerCantidadInvitados.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;

                case "VerLupa":

                     EventoId = int.Parse(row.Cells[0].Text);

                    PresupuestoId = int.Parse(row.Cells[1].Text);

                    //Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);

                    Response.Redirect("~/Presupuestos/Ver.aspx?EventoId=" + EventoId + "&PresupuestoId=" + PresupuestoId);
                    break;
                default:
                    break;
            }
        }

        protected void GridViewEventosGerencial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosGerencial.PageIndex = e.NewPageIndex;
            BuscarEventos();
        }

        protected void GridViewEventosEjecutivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosEjecutivos.PageIndex = e.NewPageIndex;
            BuscarEventos();
        }

        private bool ValidarBusqueda()
        {
            if (TextBoxNroEventoBuscador.Text.Length == 0 &&
                TextBoxNroPresupuestoBuscador.Text.Length == 0 &&
                TextBoxApellidoBuscador.Text.Length < 3 &&
                TextBoxRazonSocialBuscador.Text.Length < 3 &&
                TextBoxFecha.Text.Length == 0)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Debe Ingresar al menos un parametro de Busqueda.";
                return false;

            }

            if (TextBoxNroEventoBuscador.Text != "")
            {
                if (!cmd.IsNumeric(TextBoxNroEventoBuscador.Text))
                {
                    LabelErrores.Visible = true;
                    LabelErrores.Text = "El valor no es Numerico.";
                    return false;

                }
            }

            if (TextBoxNroPresupuestoBuscador.Text != "")
            {
                if (!cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text))
                {
                    LabelErrores.Visible = true;
                    LabelErrores.Text = "El valor no es Numerico.";
                    return false;

                }
            }

            return true;

        }

        private void BuscarEventos()
        {

            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilGestor = int.Parse(ConfigurationManager.AppSettings["Gestor"].ToString());

            int nroEvento = 0;
            int nroPresupuesto = 0;
            int nroCliente = 0;
            string apellidoynombre;
            string razonsocial;

            LabelErrores.Visible = false;

            apellidoynombre = TextBoxApellidoBuscador.Text;
            razonsocial = TextBoxRazonSocialBuscador.Text;
            string fechaEvento = TextBoxFecha.Text;


            if (cmd.IsNumeric(TextBoxNroEventoBuscador.Text)) nroEvento = int.Parse(TextBoxNroEventoBuscador.Text);
            if (cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text)) nroPresupuesto = int.Parse(TextBoxNroPresupuestoBuscador.Text);


            List<ObtenerEventosPresupuestos> ListaEventos = eventos.BuscarEventos(EmpleadoId, 
                                                                                    nroEvento, 
                                                                                    nroPresupuesto,
                                                                                    nroCliente,
                                                                                    cmd.QuitarAcentos(apellidoynombre), 
                                                                                    cmd.QuitarAcentos(razonsocial), 
                                                                                    fechaEvento);

            if ((PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial))
            {
                GridViewEventosGerencial.DataSource = ListaEventos.OrderBy(o => o.EstadoEvento).OrderBy(o => o.EstadoPresupuesto).ToList();
                GridViewEventosGerencial.DataBind();

                GridViewEventosGerencial.Visible = true;
            }
            else if (PerfilId == PerfilEjecutivo)
            {
                GridViewEventosEjecutivos.DataSource = ListaEventos.OrderBy(o => o.EstadoEvento).OrderBy(o => o.EstadoPresupuesto).ToList();
                GridViewEventosEjecutivos.DataBind();

                GridViewEventosEjecutivos.Visible = true;

            }
            else if (PerfilId == PerfilGestor)
            {
                GridViewEventosEjecutivos.DataSource = ListaEventos.OrderBy(o => o.EstadoEvento).OrderBy(o => o.EstadoPresupuesto).ToList();
                GridViewEventosEjecutivos.DataBind();

                GridViewEventosEjecutivos.Visible = true;

            }
        }

        private void LimpiarGrillas()
        {
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilGestor = int.Parse(ConfigurationManager.AppSettings["Gestor"].ToString());

            List<ObtenerEventosPresupuestos> ListaEventos = new List<ObtenerEventosPresupuestos>();

            if ((PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial))
            {
                GridViewEventosGerencial.DataSource = ListaEventos.ToList();
                GridViewEventosGerencial.DataBind();

                GridViewEventosGerencial.Visible = false;
            }
            else if (PerfilId == PerfilEjecutivo || PerfilId == PerfilGestor)
            {
                GridViewEventosEjecutivos.DataSource = ListaEventos.ToList();
                GridViewEventosEjecutivos.DataBind();

                GridViewEventosEjecutivos.Visible = false;

            }
          
        }

        protected void TextBoxApellidoBuscador_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxApellidoBuscador.Text.Length > 3)
                BuscarEventos();

            UpdatePanelGrillas.Update();
        }

        protected void TextBoxRazonSocialBuscador_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxRazonSocialBuscador.Text.Length > 3)
                BuscarEventos();

            UpdatePanelGrillas.Update();
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string host = ConfigurationManager.AppSettings["Host"].ToString();
        //    int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
        //    string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
        //    string password = ConfigurationManager.AppSettings["PWD"].ToString();

        //    MailMessage email = new MailMessage();
        //    email.To.Add(new MailAddress("diegostrevezza@hotmail.com"));
        //    email.From = new MailAddress(mailfrom);
        //    email.Subject = "Prueba";
        //    email.Body = "Prueba";
        //    email.IsBodyHtml = true;
        //    email.Priority = MailPriority.High;


        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = host;
        //    smtp.Port = puerto;
        //    smtp.EnableSsl = false;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new NetworkCredential(mailfrom, password);
        //    string output = null;

        //    TextBoxApellidoBuscador.Text = host.ToString() + "-" + puerto.ToString() + "-" + mailfrom.ToString();
        //    try
        //    {
        //        smtp.Send(email);
        //        email.Dispose();
        //        output = "Corre electrónico fue enviado satisfactoriamente.";
        //    }
        //    catch (Exception ex)
        //    {
        //        output = "Error enviando correo electrónico: " + ex.Message;
        //    }
        //}
    }

}