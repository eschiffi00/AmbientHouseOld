using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class SeguridadDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public SeguridadDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public bool ValidarUsuarios(string username, string password, int activo)
        {
            return (SqlContext.Usuarios.Where(o => o.UserName.Equals(username) && o.Password.Equals(password) && o.EstadoId == activo).Count() > 0);
        }

        public Usuarios GetEmpleadoUsuario(string username, string password, int activo)
        {
            var query = from U in SqlContext.Usuarios
                        join P in SqlContext.Perfiles on U.PerfilId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        where U.UserName.Contains(username) && U.Password.Contains(password) && U.EstadoId == activo
                        select new
                        {
                            EmpleadoId = U.EmpleadoId,
                            UserName = U.UserName,
                            Password = U.Password,
                            PerfilId = (U.PerfilId == null ? null : U.PerfilId),
                            PerfilDescripcion = (P.Descripcion == null ? null : P.Descripcion),
                            CodigoSeguridad = U.CodigoSeguridad,
                            RutaCodigoSeguridad = U.RutaCodigoSeguridad,
                            EstadoId = U.EstadoId,
                            HabilitarCambioPassword = U.HabilitarCambioPassword
                        };

            Usuarios cat = new Usuarios();

            if (query != null)
            {
                cat.EmpleadoId = query.FirstOrDefault().EmpleadoId;
                cat.UserName = query.FirstOrDefault().UserName;
                cat.Password = query.FirstOrDefault().Password;
                cat.PerfilId = query.FirstOrDefault().PerfilId;
                cat.PerfilDescripcion = query.FirstOrDefault().PerfilDescripcion;
                cat.CodigoSeguridad = query.FirstOrDefault().CodigoSeguridad;
                cat.RutaCodigoSeguridad = query.FirstOrDefault().RutaCodigoSeguridad;
                cat.EstadoId = query.FirstOrDefault().EstadoId;
                cat.HabilitarCambioPassword = query.FirstOrDefault().HabilitarCambioPassword;
            }

            return cat;
        }

        public bool EsUsuarioGerencia(int empleadoId)
        {

            int areaGerencia = Int32.Parse(ConfigurationManager.AppSettings["DeptoGerencia"].ToString());

            return (SqlContext.EMPLEADODEPARTAMENTO.Where(o => o.EmpleadoId == empleadoId && o.DepartamentoId == areaGerencia).Count() > 0);
        }

        public int GetAreaEmpleado(int EmpleadoId)
        {
            return SqlContext.EMPLEADODEPARTAMENTO.Where(o => o.EmpleadoId == EmpleadoId).First().DepartamentoId;
        }

        public List<ObtenerUsuarios> ObtenerUsuarios()
        {
            return SqlContext.ObtenerUsuarios.ToList();
        }

        public Usuarios BuscarUsuario(long id)
        {
            return SqlContext.Usuarios.Where(o => o.EmpleadoId == id).First();
        }

        public List<Empleados> ObtenerEmpleadosSinUsuario()
        {

            int usuarioActivo = Int32.Parse(ConfigurationManager.AppSettings["UsuarioActivo"].ToString());


            List<Empleados> queryUsuarios = (from U in SqlContext.Usuarios
                                             join E in SqlContext.Empleados on U.EmpleadoId equals E.Id
                                             //where U.EstadoId == usuarioActivo
                                             select E).ToList();

            return SqlContext.Empleados.ToList().Except(queryUsuarios).ToList();


        }

        public void NuevoUsuario(Usuarios usuario, int departamentoId)
        {

            int ExisteUsuario = SqlContext.Usuarios.Where(o => o.EmpleadoId == usuario.EmpleadoId).Count();

            if (ExisteUsuario > 0)
            {

                Usuarios usuEdit = SqlContext.Usuarios.Where(o => o.EmpleadoId == usuario.EmpleadoId).First();

                usuEdit.UserName = usuario.UserName;
                usuEdit.Password = usuario.Password;
                usuEdit.EstadoId = usuario.EstadoId;
                usuEdit.EmpleadoId = usuario.EmpleadoId;

                EmpleadoDepartamentos EmDeptoEdit = SqlContext.EmpleadoDepartamentos.Where(o => o.EmpleadoId == usuario.EmpleadoId).First();

                EmDeptoEdit.DepartamentoId = departamentoId;

                SqlContext.SaveChanges();
            }
            else
            {
                EmpleadoDepartamentos EmDepto = new EmpleadoDepartamentos();

                EmDepto.EmpleadoId = usuario.EmpleadoId;
                EmDepto.DepartamentoId = departamentoId;

                SqlContext.EmpleadoDepartamentos.Add(EmDepto);
                SqlContext.SaveChanges();

                SqlContext.Usuarios.Add(usuario);
                SqlContext.SaveChanges();
            }

        }

        public Usuarios BuscarUsuarioPorEmpleado(int EmpleadoId)
        {
            return SqlContext.Usuarios.Where(o => o.EmpleadoId == EmpleadoId).FirstOrDefault();
        }

        public void EditarUsuario(Usuarios usuario)
        {
            Usuarios usuEdit = SqlContext.Usuarios.Where(o => o.EmpleadoId == usuario.EmpleadoId).FirstOrDefault();

            usuEdit.Password = usuario.Password;
            usuEdit.EstadoId = usuario.EstadoId;
            usuEdit.HabilitarCambioPassword = usuario.HabilitarCambioPassword;

            SqlContext.SaveChanges();

        }

        public UsuarioPipeDrive_Ambient GetEmpleadoUsuarioPipe(int EmpleadoId)
        {
            return SqlContext.UsuarioPipeDrive_Ambient.Where(o => o.UserAmbientId == EmpleadoId).SingleOrDefault();
        }

        public void EjecutoTareasProgramdasHoy()
        {
            if (SqlContext.EjecucionTareasProgramadas.Where(o => o.FechaEjecucion == System.DateTime.Today).Count() == 0)
            {

                SqlContext.ActualizarPresupuestosVencidos();

                SqlContext.ActualizarPresupuestosRealizados();

                SqlContext.EliminarEventosGuardados();

                EjecucionTareasProgramadas programada = new EjecucionTareasProgramadas();

                programada.FechaEjecucion = System.DateTime.Today;

                SqlContext.EjecucionTareasProgramadas.Add(programada);

                SqlContext.SaveChanges();

            }
        }
    }
}
