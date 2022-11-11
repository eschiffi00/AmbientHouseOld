using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class SeguridadNegocios
    {

        SeguridadDatos Datos;

        public SeguridadNegocios()
        {
            Datos = new SeguridadDatos();
        }

        public bool ValidarUsuarios(string username, string password, int activo)
        {

            DomainAmbientHouse.Servicios.Log.saveAuditoria(this, "El usuario: " + username + " se logeo en el sistema, el dia: " + System.DateTime.Now);

            return Datos.ValidarUsuarios(username, password, activo);

        }

        public Usuarios GetEmpleadoUsuario(string username, string password, int activo)
        {
            return Datos.GetEmpleadoUsuario(username, password, activo);
        }

        public bool EsUsuarioGerencia(int empleadoId)
        {
            return Datos.EsUsuarioGerencia(empleadoId);
        }

        public int GetAreaEmpleado(int EmpleadoId)
        {
            return Datos.GetAreaEmpleado(EmpleadoId);
        }

        public List<ObtenerUsuarios> ObtenerUsuarios()
        {
            return Datos.ObtenerUsuarios();
        }

        public Usuarios BuscarUsuario(long id)
        {
            return Datos.BuscarUsuario(id);
        }

        public List<Empleados> ObtenerEmpleadosSinUsuario()
        {
            return Datos.ObtenerEmpleadosSinUsuario();
        }

        public void NuevoUsuario(Usuarios usuario, int departamentoId)
        {
            Datos.NuevoUsuario(usuario, departamentoId);
        }

        public Usuarios BuscarUsuarioPorEmpleado(int EmpleadoId)
        {
            return Datos.BuscarUsuarioPorEmpleado(EmpleadoId);
        }

        public void EditarUsuario(Usuarios usuario)
        {
            Datos.EditarUsuario(usuario);
        }

        public UsuarioPipeDrive_Ambient GetEmpleadoUsuarioPipe(int EmpleadoId)
        {
            return Datos.GetEmpleadoUsuarioPipe(EmpleadoId);
        }

        public void EjecutoTareasProgramdasHoy()
        {
            Datos.EjecutoTareasProgramdasHoy();
        }
    }
}
