using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Seguridad;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;



namespace AmbientHouse.Seguridad
{
    public partial class Login : System.Web.UI.Page
    {
        SeguridadServicios seguridad = new SeguridadServicios();

        AdministrativasServicios administracion = new AdministrativasServicios();


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

        private int UsuarioPipeDriveId
        {
            get
            {
                return Int32.Parse(Session["UsuarioPipeDriveId"].ToString());
            }
            set
            {
                Session["UsuarioPipeDriveId"] = value;
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

        private int AreaId
        {
            get
            {
                return Int32.Parse(Session["AreaId"].ToString());
            }
            set
            {
                Session["AreaId"] = value;
            }
        }

        private string UsuarioLogeado
        {
            get
            {
                return Session["UsuarioLogeado"].ToString();
            }
            set
            {
                Session["UsuarioLogeado"] = value;
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

        private List<Locaciones> ListLocacionesUsuarios
        {
            get
            {
                return Session["ListLocacionesUsuarios"] as List<Locaciones>;
            }
            set
            {
                Session["ListLocacionesUsuarios"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            { }

        }

        protected void LoginAmbient_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            int activo = int.Parse(ConfigurationManager.AppSettings["UsuarioActivo"].ToString());

            int PerfilCoordinadorVentas = int.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilAdministracion = int.Parse(ConfigurationManager.AppSettings["Administracion"].ToString());
            int PerfilGerencia = int.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());
            int PerfilGestor = int.Parse(ConfigurationManager.AppSettings["Gestor"].ToString());

            int PerfilStock = int.Parse(ConfigurationManager.AppSettings["Stock"].ToString());
            int PerfilStockCarga = int.Parse(ConfigurationManager.AppSettings["StockCarga"].ToString());

            int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());


            if (ValidarUsuario(LoginAmbient.UserName, LoginAmbient.Password, activo))
            {
                List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle> listaEventos = administracion.ListarEventosFechaEnvioMailPresentacion();

                //foreach (var item in listaEventos)
                //{

                //    Mail mail = new Mail();

                //    mail.envioMailAlertaMailPresentacion( item.Id, item.PresupuestoId);
                //}

                seguridad.EjecutoTareasProgramdasHoy();

                DomainAmbientHouse.Entidades.Usuarios usu = seguridad.GetEmpleadoUsuario(LoginAmbient.UserName, LoginAmbient.Password, activo);

                if (usu.HabilitarCambioPassword)
                {
                    EmpleadoId = usu.EmpleadoId;
                    Response.Redirect("~/Seguridad/CambioPassword.aspx");
                }
                else
                {

                    EmpleadoId = usu.EmpleadoId;

                    if (usu.PerfilId != null)
                    {
                        PerfilId = (int)usu.PerfilId;
                    }

                    UsuarioPipeDrive_Ambient usuPipe = seguridad.GetEmpleadoUsuarioPipe((int)usu.EmpleadoId);
                    ListClientesPipe = new List<ClientesPipedrive>();

                    if (usuPipe != null)
                    {
                        UsuarioPipeDriveId = (int)usuPipe.UserPipeDriveId;

                        DomainAmbientHouse.Servicios.Pipedrive pipeDrive = new DomainAmbientHouse.Servicios.Pipedrive();

                        ListClientesPipe = pipeDrive.ObtenerListaClientesPipedrive(null, usuPipe.UserPipeDriveId.ToString());

                        ////List<ClientesPrueba> list = pipeDrive.ObtenerClientes((int)usuPipe.UserAmbientId);



                        ////foreach (var item in list)
                        ////{
                        ////    ClientesPipedrive cli = new ClientesPipedrive();

                        ////    cli.ApellidoNombre = item.Persona;
                        ////    cli.Id = (int)item.ClienteId;
                        ////    cli.Owner =  item.propietario.ToString();

                        ////    cli.Identificador = item.Persona ;
                        ////    ListClientesPipe.Add(cli);

                        ////}

                    }


                    ListLocacionesUsuarios = seguridad.GetLocacionesUsuarios(usu.EmpleadoId);

                    AreaId = seguridad.GetAreaEmpleado(EmpleadoId);

                    UsuarioLogeado = "SI";

                    if (PerfilId == PerfilCoordinadorVentas || PerfilId == PerfilEjecutivo || PerfilId == PerfilGestor)
                    {
                        Response.Redirect("~/Inicio/Principal.aspx");
                    }
                    else if (PerfilId == PerfilAdministracion)
                    {
                        Response.Redirect("~/Home/Index.aspx");
                    }
                    else if (PerfilId == PerfilGerencia)
                    {
                        Response.Redirect("~/Home/Index.aspx");

                    }
                    else if (PerfilId == PerfilOrganizador || PerfilId == PerfilCoordinadorOrganizacion)
                    {
                        Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
                    }
                    else if (PerfilId == PerfilStock)
                    {
                        Response.Redirect("~/Stock/Existencias/Index.aspx");
                    }
                    else if (PerfilId == PerfilStockCarga)
                    {
                        Response.Redirect("~/Stock/Existencias/Index.aspx");
                    }
                    else if (PerfilId == PerfilOperacion)
                    {
                        Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
                    }

                }

            }
            else
            {
                Response.Redirect("~/Seguridad/Login.aspx");
            }
        }

        private bool ValidarUsuario(string usuario, string password, int activo)
        {
            return seguridad.ValidarUsuarios(usuario, password, activo);

        }


        //public void GoogleAutentificacion()
        //{
        //    GoogleConnect.ClientId = Valor.GoogleClientId();
        //    GoogleConnect.ClientSecret = Valor.GoogleClientSecret();
        //    GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
        //    if (!String.IsNullOrEmpty(Request.QueryString["code"]))
        //    {
        //        String code = Request.QueryString["code"];
        //        String json = GoogleConnect.Fetch("me", code);
        //        Controller.DataGoogle.GoogleProfile perfil = new JavaScriptSerializer().Deserialize<Controller.DataGoogle.GoogleProfile>(json);
        //        Session["PerfilID"] = perfil.Id;
        //        Session["PerfilNombre"] = perfil.DisplayName;
        //        Session["PerfilEmail"] = perfil.Emails.Find(email => email.Type == "account").Value;
        //        Session["PerfilSexo"] = perfil.Gender;
        //        Session["PerfilTipo"] = perfil.ObjectType;
        //        Session["PerfilImagen"] = perfil.Image.Url.ToString();
        //    }
        //    if (Session["PerfilEmail"] != null)
        //    {
        //        if (Sub.ValidarMail(Session["PerfilEmail"].ToString().ToLower()))
        //        {
        //            Response.Redirect("~/View/StaGemaList/MenuPrincipal.aspx");
        //        }
        //        else
        //        {
        //            String ScriptAct = "<script language='javascript'>" + "NoAutenticadoStaGema();" + "</script>";
        //            ClientScript.RegisterStartupScript(this.GetType(), "NoAutenticadoStaGema();", ScriptAct);
        //        }
        //    }
        //}
    }
}