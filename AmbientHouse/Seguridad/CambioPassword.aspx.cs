using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Seguridad;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Seguridad
{
    public partial class CambioPassword : System.Web.UI.Page
    {
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

        SeguridadServicios servicios = new SeguridadServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (CambiarPassword())
            {
                AsignarPerfilesUsuarios();
            }

        }

        private void AsignarPerfilesUsuarios()
        {
            int PerfilCoordinadorVentas = int.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilAdministracion = int.Parse(ConfigurationManager.AppSettings["Administracion"].ToString());
            int PerfilGerencia = int.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());

            int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());

            DomainAmbientHouse.Entidades.Usuarios usu = servicios.BuscarUsuario(EmpleadoId);


            EmpleadoId = usu.EmpleadoId;

            if (usu.PerfilId != null)
            {
                PerfilId = (int)usu.PerfilId;
            }

            UsuarioPipeDrive_Ambient usuPipe = servicios.GetEmpleadoUsuarioPipe((int)usu.EmpleadoId);
            ListClientesPipe = new List<ClientesPipedrive>();

            if (usuPipe != null)
            {
                UsuarioPipeDriveId = (int)usuPipe.UserPipeDriveId;

                DomainAmbientHouse.Servicios.Pipedrive pipeDrive = new DomainAmbientHouse.Servicios.Pipedrive();

                ListClientesPipe = pipeDrive.ObtenerListaClientesPipedrive(null, usuPipe.UserPipeDriveId.ToString());

         
            }


            ListLocacionesUsuarios = servicios.GetLocacionesUsuarios(usu.EmpleadoId);

            AreaId = servicios.GetAreaEmpleado(EmpleadoId);

            UsuarioLogeado = "SI";

            if (PerfilId == PerfilCoordinadorVentas || PerfilId == PerfilEjecutivo)
            {
                Response.Redirect("~/Inicio/Principal.aspx");
            }
            else if (PerfilId == PerfilAdministracion)
            {
                Response.Redirect("~/Administracion/Default.aspx");
            }
            else if (PerfilId == PerfilGerencia)
            {
                Response.Redirect("~/Inicio/Principal.aspx");
            }
            else if (PerfilId == PerfilOrganizador || PerfilId == PerfilCoordinadorOrganizacion)
            {
                Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
            }
            else if (PerfilId == PerfilOperacion)
            {
                Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
            }
        }

        private bool CambiarPassword()
        {
            LabelError.Visible = false;

            DomainAmbientHouse.Entidades.Usuarios  usu = servicios.BuscarUsuario(EmpleadoId);

            if (usu.Password.ToUpper().Trim() ==
                TextBoxLoginAnterior.Text.ToUpper().Trim())
            {

               
                if (TextBoxLoginNuevo.Text.ToUpper().Trim() ==
                    TextBoxConfirmacion.Text.ToUpper().Trim())
                {

                    if (TextBoxLoginNuevo.Text.Length >= 8)
                    {
                        try
                        {
                            usu.Password = TextBoxLoginNuevo.Text;
                            usu.HabilitarCambioPassword = false;

                            servicios.EditarUsuario(usu);

                            return true;
                        }
                        catch (Exception)
                        {

                            return false;
                        }
                    }
                    else
                    {
                        LabelError.Text = "El Nuevo Password no cumple con las normas de seguridad. Minimo 8 caracteres.";
                        LabelError.Visible = true;
                        return false;
                    }
                  
                }
                else
                {
                    LabelError.Text = "El Nuevo Password no fue confirmado correctamente.";
                    LabelError.Visible = true;
                    return false;
                }
            }
            else
            {
                LabelError.Text = "El Password no coindide con el Usuario.";
                LabelError.Visible = true;
                return false;
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado == "SI")
            {
                Response.Redirect("~/Inicio/Principal.aspx");
            }
            else
            {
                Response.Redirect("~/Seguridad/Login.aspx");
            }
        }
    }
}