using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System.Collections.Generic;

namespace DomainAmbientHouse.Seguridad
{
    public class SeguridadServicios
    {
        SeguridadNegocios negocios;
        PerfilesNegocios perfil;
        UsuariosGruposNegocios grupos;

        public SeguridadServicios()
        {
            negocios = new SeguridadNegocios();
            perfil = new PerfilesNegocios();
            grupos = new UsuariosGruposNegocios();
        }
        public bool ValidarUsuarios(string username, string password, int activo)
        {
            return negocios.ValidarUsuarios(username, password, activo);
        }

        public Usuarios GetEmpleadoUsuario(string username, string password, int activo)
        {
            return negocios.GetEmpleadoUsuario(username, password, activo);
        }

        public bool EsUsuarioGerencia(int empleadoId)
        {
            return negocios.EsUsuarioGerencia(empleadoId);
        }

        public int GetAreaEmpleado(int EmpleadoId)
        {
            return negocios.GetAreaEmpleado(EmpleadoId);
        }

        public List<ObtenerUsuarios> ObtenerUsuarios()
        {
            return negocios.ObtenerUsuarios();
        }

        public Usuarios BuscarUsuario(long id)
        {
            return negocios.BuscarUsuario(id);
        }

        public List<Empleados> ObtenerEmpleadosSinUsuario()
        {
            return negocios.ObtenerEmpleadosSinUsuario();
        }

        public void NuevoUsuario(Usuarios usuario, int departamentoId)
        {
            negocios.NuevoUsuario(usuario, departamentoId);
        }

        public Usuarios BuscarUsuarioPorEmpleado(int EmpleadoId)
        {
            return negocios.BuscarUsuarioPorEmpleado(EmpleadoId);
        }

        public void EditarUsuario(Usuarios usuario)
        {
            negocios.EditarUsuario(usuario);
        }

        public List<Perfiles> ObtenerPerfiles()
        {
            return perfil.ObtenerPerfiles();
        }

        public UsuarioPipeDrive_Ambient GetEmpleadoUsuarioPipe(int EmpleadoId)
        {
            return negocios.GetEmpleadoUsuarioPipe(EmpleadoId);
        }

        public List<UsuariosGrupos> ObtenerGrupos()
        {
            return grupos.ObtenerGrupos();

        }

        public List<Locaciones> GetLocacionesUsuarios(int usuario)
        {
            LocacionesNegocios locaciones = new LocacionesNegocios();

            return locaciones.ObtenerLocaciones(usuario);
        }

        public void NuevoEmpleado(Empleados empleado)
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            negocios.NuevoEmpleado(empleado);
        }

        public void EjecutoTareasProgramdasHoy()
        {
            negocios.EjecutoTareasProgramdasHoy();
        }
    }
}
