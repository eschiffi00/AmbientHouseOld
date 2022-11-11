using DomainAmbientHouse.Seguridad;
using DomainAmbientHouse.Servicios;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace AmbientHouse.RRHH.Empleados
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.Usuarios UsuarioSeleccionado
        {
            get
            {
                return Session["UsuarioSeleccionado"] as DomainAmbientHouse.Entidades.Usuarios;
            }
            set
            {
                Session["UsuarioSeleccionado"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Empleados EmpleadoSeleccionada
        {
            get
            {
                return Session["EmpleadoSeleccionada"] as DomainAmbientHouse.Entidades.Empleados;
            }
            set
            {
                Session["EmpleadoSeleccionada"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoEditarId"].ToString());
            }
            set
            {
                Session["EmpleadoEditarId"] = value;
            }
        }

        SeguridadServicios servicios = new SeguridadServicios();
        AdministrativasServicios serviciosAdmin = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelUsuarios.Visible = CheckBoxEsUsuario.Checked;

                MaskedEditExtenderFechaNacimiento.Mask = "99/99/9999";
                MaskedEditExtenderIngreso.Mask = "99/99/9999";

                PanelDatosLaborales.Visible = false;
                PanelDatosPersonales.Visible = true;

                CargarListas();

                InicializarPagina();

            }
        }

        private void CargarListas()
        {
            DropDownListEstado.DataSource = serviciosAdmin.BuscarEstadosPorEntidad("Usuarios");
            DropDownListEstado.DataTextField = "Descripcion";
            DropDownListEstado.DataValueField = "Id";
            DropDownListEstado.DataBind();

            DropDownListPerfiles.DataSource = servicios.ObtenerPerfiles();
            DropDownListPerfiles.DataTextField = "Descripcion";
            DropDownListPerfiles.DataValueField = "Id";
            DropDownListPerfiles.DataBind();

            DropDownListGrupo.DataSource = servicios.ObtenerGrupos();
            DropDownListGrupo.DataTextField = "Nombre";
            DropDownListGrupo.DataValueField = "Id";
            DropDownListGrupo.DataBind();

            DropDownListDepartamento.DataSource = serviciosAdmin.ObtenerDepartamentos();
            DropDownListDepartamento.DataTextField = "Nombre";
            DropDownListDepartamento.DataValueField = "Id";
            DropDownListDepartamento.DataBind();

            DropDownListSituacion.DataSource = serviciosAdmin.BuscarEstadosPorEntidad("Empleados");
            DropDownListSituacion.DataTextField = "Descripcion";
            DropDownListSituacion.DataValueField = "Id";
            DropDownListSituacion.DataBind();

            DropDownListProvincia.DataSource = serviciosAdmin.ObtenerProvincias();
            DropDownListProvincia.DataTextField = "Descripcion";
            DropDownListProvincia.DataValueField = "Id";
            DropDownListProvincia.DataBind();

            int provinciaId = Int32.Parse(DropDownListProvincia.SelectedItem.Value);

            CargarCiudades(DropDownListLocalidad, provinciaId);

            DropDownListProvinciaLegal.DataSource = serviciosAdmin.ObtenerProvincias();
            DropDownListProvinciaLegal.DataTextField = "Descripcion";
            DropDownListProvinciaLegal.DataValueField = "Id";
            DropDownListProvinciaLegal.DataBind();

            int provinciaLegalId = Int32.Parse(DropDownListProvinciaLegal.SelectedItem.Value);

            CargarCiudades(DropDownListLocalidadLegal, provinciaLegalId);

            //DropDownListTipoEmpleado.DataSource = serviciosAdmin.ObtenerTipoEmpleados();
            //DropDownListTipoEmpleado.DataTextField = "Descripcion";
            //DropDownListTipoEmpleado.DataValueField = "Id";
            //DropDownListTipoEmpleado.DataBind();

            //DropDownListLocalidad.DataSource = serviciosAdmin.ObtenerLocalidades();
            //DropDownListLocalidad.DataTextField = "Descripcion";
            //DropDownListLocalidad.DataValueField = "Id";
            //DropDownListLocalidad.DataBind();

            ListItem oDNI = new ListItem();
            oDNI.Text = "DNI";
            oDNI.Value = "DNI";

            ListItem oCI = new ListItem();
            oCI.Text = "CI";
            oCI.Value = "CI";

            ListItem oPasaporte = new ListItem();
            oPasaporte.Text = "PASAPORTE";
            oPasaporte.Value = "PASAPORTE";

            DropDownListTipoDocumento.Items.Clear();
            DropDownListTipoDocumento.Items.Add(oDNI);
            DropDownListTipoDocumento.Items.Add(oCI);
            DropDownListTipoDocumento.Items.Add(oPasaporte);

        }

        private void InicializarPagina()
        {
            int Id = 0;

            if (Request["Id"] != null)
            {
                Id = Int32.Parse(Request["Id"].ToString());

                EmpleadoId = Id;
            }


            if (Id == 0)
                NuevoEmpleado();
            else
                EditarEmpleado(Id);

            SetFocus(TextBoxApellidoNombre);
        }

        private void EditarEmpleado(int Id)
        {
            DomainAmbientHouse.Entidades.Empleados empleado = new DomainAmbientHouse.Entidades.Empleados();

            empleado = serviciosAdmin.BuscarEmpleado(Id);

            EmpleadoSeleccionada = empleado;


            TextBoxApellidoNombre.Text = empleado.ApellidoNombre;
            TextBoxNombre.Text = empleado.Nombre;
            TextBoxCUIL.Text = empleado.Cuil;

            TextBoxNroLegajo.Text = empleado.NroLegajo.ToString();
            DropDownListSituacion.SelectedValue = empleado.EstadoId.ToString();
            TextBoxFechaIngreso.Text = String.Format("{0:dd/MM/yyyy}", empleado.FechaIngreso);
            TextBoxFechaNacimiento.Text = String.Format("{0:dd/MM/yyyy}", empleado.FechaNacimiento);
            TextBoxHoraDesde.Text = empleado.HorarioDesde;
            TextBoxHoraHasta.Text = empleado.HorarioHasta;

            TextBoxMail.Text = empleado.Mail;
            TextBoxMailLaboral.Text = empleado.MailLaboral;
            TextBoxNroDocumento.Text = empleado.NroDocumento.ToString();

            TextBoxTelefonoFijo.Text = empleado.TelefonoFijo;
            TextBoxTelefonoMovil.Text = empleado.TelefonoMovil;
            TextBoxTelLaboral.Text = empleado.TelefonoFijoLaboral;


            TextBoxDomicilio.Text = empleado.Direccion;
            TextBoxDomicilioLegal.Text = empleado.DireccionLegal;
            if (empleado.LocalidadId != null)
            {
                int ciudadId = empleado.LocalidadId;

                DropDownListLocalidad.SelectedValue = ciudadId.ToString();
                DropDownListProvincia.SelectedValue = serviciosAdmin.BuscarProvinciaPorCiudad(ciudadId).Id.ToString();
            }


            if (empleado.CiudadLegalId != null)
            {
                int ciudadId = (int)empleado.CiudadLegalId;

                DropDownListLocalidadLegal.SelectedValue = ciudadId.ToString();
                DropDownListProvinciaLegal.SelectedValue = serviciosAdmin.BuscarProvinciaPorCiudad(ciudadId).Id.ToString();



            }

            TextBoxCP.Text = empleado.CP;
            TextBoxCPLegal.Text = empleado.CPLegal;

            DropDownListTipoDocumento.SelectedValue = empleado.TipoDocumento;

            if (empleado.UsaPc)
            {
                DropDownListUsaPC.SelectedValue = "SI";
                TextBoxNroPc.Text = empleado.NroPc;
            }

            int sectorid = empleado.SectorEmpresaId;
            int departamentoId = empleado.DepartamentoId;

            ObtenerSectoresporDepartamentos(departamentoId);

            ObtenerTipoEmpleadosporSectores(sectorid);

            DropDownListDepartamento.SelectedValue = empleado.DepartamentoId.ToString();
            DropDownListTipoEmpleado.SelectedValue = empleado.TipoEmpleadoId.ToString();
            DropDownListSector.SelectedValue = empleado.SectorEmpresaId.ToString();


            if (empleado.Premio > 0)
                TextBoxPremio.Text = empleado.Premio.ToString();
            if (empleado.SAC > 0)
                TextBoxSAC.Text = empleado.SAC.ToString();
            if (empleado.Sueldo > 0)
                TextBoxSueldo.Text = empleado.Sueldo.ToString();

            TextBoxObservaciones.Text = empleado.Observaciones;


        }

        private void NuevoEmpleado()
        {
            EmpleadoSeleccionada = new DomainAmbientHouse.Entidades.Empleados();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.Empleados empleado = EmpleadoSeleccionada;

            empleado.ApellidoNombre = TextBoxApellidoNombre.Text;
            empleado.Cuil = TextBoxCUIL.Text;
            empleado.Direccion = TextBoxDomicilio.Text;
            empleado.EstadoId = Int32.Parse(DropDownListSituacion.SelectedItem.Value);
            if (cmd.IsDate(TextBoxFechaIngreso.Text))
                empleado.FechaIngreso = DateTime.ParseExact(TextBoxFechaIngreso.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            empleado.FechaNacimiento = DateTime.ParseExact(TextBoxFechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            empleado.HorarioDesde = TextBoxHoraDesde.Text;
            empleado.HorarioHasta = TextBoxHoraHasta.Text;
            empleado.LocalidadId = Int32.Parse(DropDownListLocalidad.SelectedItem.Value);
            empleado.CiudadLegalId = Int32.Parse(DropDownListLocalidadLegal.SelectedItem.Value);

            empleado.Mail = TextBoxMail.Text;
            empleado.MailLaboral = TextBoxMailLaboral.Text;
            empleado.NroDocumento = Int32.Parse(TextBoxNroDocumento.Text);
            if (cmd.IsNumeric(TextBoxPremio.Text))
                empleado.Premio = Double.Parse(TextBoxPremio.Text);
            if (cmd.IsNumeric(TextBoxSAC.Text))
                empleado.SAC = Double.Parse(TextBoxSAC.Text);
            if (cmd.IsNumeric(TextBoxSueldo.Text))
                empleado.Sueldo = Double.Parse(TextBoxSueldo.Text);
            empleado.TelefonoFijo = TextBoxTelefonoFijo.Text;
            empleado.TelefonoMovil = TextBoxTelefonoMovil.Text;
            empleado.TelefonoFijoLaboral = TextBoxTelLaboral.Text;
            empleado.CelularFijoLaboral = TextBoxCelularLaboral.Text;
            empleado.TipoDocumento = DropDownListTipoDocumento.SelectedItem.Value;
            empleado.TipoEmpleadoId = Int32.Parse(DropDownListTipoEmpleado.SelectedItem.Value);
            empleado.SectorEmpresaId = Int32.Parse(DropDownListSector.SelectedItem.Value);
            empleado.DepartamentoId = Int32.Parse(DropDownListDepartamento.SelectedItem.Value);
            empleado.Observaciones = TextBoxObservaciones.Text;

            servicios.NuevoEmpleado(empleado);
            Response.Redirect("~/RRHH/Empleados/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RRHH/Empleados/Index.aspx");
        }

        protected void CheckBoxEsUsuario_CheckedChanged(object sender, EventArgs e)
        {
            PanelUsuarios.Visible = CheckBoxEsUsuario.Checked;
        }

        protected void DropDownListDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarSectores();

            CargarTipoEmpleados();

            UpdatePanelEmpleados.Update();

        }

        private void CargarSectores()
        {
            int departamentoId = Int32.Parse(DropDownListDepartamento.SelectedItem.Value);
            ObtenerSectoresporDepartamentos(departamentoId);
        }

        private void ObtenerSectoresporDepartamentos(int departamentoId)
        {
            if (DropDownListDepartamento.SelectedItem != null)
            {

                DropDownListSector.DataSource = serviciosAdmin.ObtenerSectoresEmpresaPorDepartamento(departamentoId);
                DropDownListSector.DataTextField = "Descripcion";
                DropDownListSector.DataValueField = "Id";
                DropDownListSector.DataBind();

            }
        }

        protected void DropDownListSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTipoEmpleados();
        }

        private void CargarTipoEmpleados()
        {
            int sectorId = Int32.Parse(DropDownListSector.SelectedItem.Value);

            ObtenerTipoEmpleadosporSectores(sectorId);
        }
        private void ObtenerTipoEmpleadosporSectores(int sectorId)
        {
            if (DropDownListSector.SelectedItem != null)
            {

                DropDownListTipoEmpleado.DataSource = serviciosAdmin.ObtenerTipoEmpleadosPorSector(sectorId);
                DropDownListTipoEmpleado.DataTextField = "Descripcion";
                DropDownListTipoEmpleado.DataValueField = "Id";
                DropDownListTipoEmpleado.DataBind();

            }
        }

        protected void ButtonDatosPersonales_Click(object sender, EventArgs e)
        {

            PanelDatosLaborales.Visible = false;
            PanelDatosPersonales.Visible = true;
        }

        protected void ButtonDatosLaborales_Click(object sender, EventArgs e)
        {

            PanelDatosLaborales.Visible = true;
            PanelDatosPersonales.Visible = false;
        }

        protected void DropDownListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProvincia.SelectedItem != null)
            {
                int provinciaId = Int32.Parse(DropDownListProvincia.SelectedItem.Value);
                CargarCiudades(DropDownListLocalidad, provinciaId);

                if (DropDownListLocalidad.SelectedItem.Value != null)
                {
                    int ciudadId = Int32.Parse(DropDownListLocalidad.SelectedItem.Value);

                    CargarDatosCiudad(ciudadId, TextBoxCP);

                }

            }
        }

        private void CargarCiudades(DropDownList dropdown, int provinciaId)
        {


            dropdown.Items.Clear();
            dropdown.DataSource = serviciosAdmin.BuscarCiudadesPorProvincia(provinciaId);
            dropdown.DataTextField = "Descripcion";
            dropdown.DataValueField = "Id";
            dropdown.DataBind();
        }

        protected void DropDownListProvinciaLegal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProvinciaLegal.SelectedItem != null)
            {
                int provinciaId = Int32.Parse(DropDownListProvinciaLegal.SelectedItem.Value);
                CargarCiudades(DropDownListLocalidadLegal, provinciaId);

                if (DropDownListLocalidadLegal.SelectedItem.Value != null)
                {
                    int ciudadId = Int32.Parse(DropDownListLocalidadLegal.SelectedItem.Value);

                    CargarDatosCiudad(ciudadId, TextBoxCPLegal);

                }
            }
        }

        protected void DropDownListLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListLocalidad.SelectedItem.Value != null)
            {
                int ciudadId = Int32.Parse(DropDownListLocalidad.SelectedItem.Value);

                CargarDatosCiudad(ciudadId, TextBoxCP);

            }
        }

        private void CargarDatosCiudad(int ciudadId, TextBox cp)
        {
            DomainAmbientHouse.Entidades.Ciudades ciudad = serviciosAdmin.BuscarCiudad(ciudadId);

            if (ciudad != null)
            {

                cp.Text = ciudad.CP.ToString();
            }
        }

        protected void DropDownListLocalidadLegal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListLocalidadLegal.SelectedItem.Value != null)
            {
                int ciudadId = Int32.Parse(DropDownListLocalidadLegal.SelectedItem.Value);

                CargarDatosCiudad(ciudadId, TextBoxCPLegal);

            }
        }

    }
}