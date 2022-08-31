using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class EmpleadosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public EmpleadosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Empleados> BuscarEmpleadosPorDepartamento(int departamentoId)
        {

            var query = from E in SqlContext.Empleados
                        join Ed in SqlContext.EMPLEADODEPARTAMENTO on E.Id equals Ed.EmpleadoId
                        where Ed.DepartamentoId == departamentoId
                        select E;

            return query.ToList();
             

        }

        public List<Empleados> ObtenerEmpleados()
        {
            return SqlContext.Empleados.ToList();
        }

        public Empleados BuscarEmpleado(int id)
        {
            return SqlContext.Empleados.Where(o => o.Id == id).First();
        }

        public void NuevoEmpleado(Empleados empleado)
        {
            if (empleado.Id > 0)
            {
                Empleados edit = SqlContext.Empleados.Where(o => o.Id == empleado.Id).First();

                edit.ApellidoNombre = empleado.ApellidoNombre;
                edit.NroLegajo = empleado.NroLegajo;
                edit.Nombre = empleado.Nombre;
                edit.Cuil = empleado.ApellidoNombre;
                edit.TipoDocumento = empleado.TipoDocumento;
                edit.NroDocumento = empleado.NroDocumento;
                edit.Direccion = empleado.Direccion;
                edit.LocalidadId = empleado.LocalidadId;
                edit.CP = empleado.CP;

                edit.DireccionLegal = empleado.DireccionLegal;
                edit.CiudadLegalId = empleado.CiudadLegalId;
                edit.CPLegal = empleado.CPLegal;

                edit.FechaNacimiento = empleado.FechaNacimiento;
                edit.TelefonoFijo = empleado.TelefonoFijo;
                edit.TelefonoMovil = empleado.TelefonoMovil;

                edit.Mail = empleado.Mail;

                edit.EstadoId = empleado.EstadoId;

                edit.FechaIngreso = empleado.FechaIngreso;
                edit.SectorEmpresaId = empleado.SectorEmpresaId;
                edit.TipoEmpleadoId = empleado.TipoEmpleadoId;
                edit.DepartamentoId = empleado.DepartamentoId;

                edit.HorarioDesde = empleado.HorarioDesde;
                edit.HorarioHasta = empleado.HorarioHasta;
                edit.MailLaboral = empleado.MailLaboral;
                edit.UsaPc = empleado.UsaPc;
                edit.NroPc = empleado.NroPc;
              
                edit.Observaciones = empleado.Observaciones;
                edit.Premio = empleado.Premio;
                edit.SAC = empleado.SAC;
                
                edit.Sueldo = empleado.Sueldo;
             
               
                edit.TipoEmpleadoId = empleado.TipoEmpleadoId;


              
                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.Empleados.Add(empleado);
                SqlContext.SaveChanges();
            }
        }

        public void GrabarEquipo(EmpleadosPresupuestosAprobados empleados)
        {
            
                if (SqlContext.EmpleadosPresupuestosAprobados.Where(o => o.PresupuestoId == empleados.PresupuestoId).Count() > 0)
                {
                    EmpleadosPresupuestosAprobados edit = SqlContext.EmpleadosPresupuestosAprobados.Where(o => o.PresupuestoId == empleados.PresupuestoId).SingleOrDefault();

                    edit.JefeCocinaId = empleados.JefeCocinaId;
                    edit.JefeBarraId = empleados.JefeBarraId;
                    edit.JefeLogisticaId = empleados.JefeLogisticaId;
                    edit.JefeOperacionId = empleados.JefeOperacionId;
                    edit.JefeSalonId = empleados.JefeSalonId;
                    edit.CoordinadorId = empleados.CoordinadorId;
                    edit.CoordinadorBisId = empleados.CoordinadorBisId;
                    edit.OrganizadorId = empleados.OrganizadorId;
                    edit.ResponsableLogisticaArmadoId = empleados.ResponsableLogisticaArmadoId;
                    edit.ResponsableLogisticaDesarmadoId = empleados.ResponsableLogisticaDesarmadoId;
                    edit.HoraIngresoCoordinador1 = empleados.HoraIngresoCoordinador1;
                    edit.HoraIngresoCoordinador2 = empleados.HoraIngresoCoordinador2;

                    SqlContext.SaveChanges();
                }
                else
                {
                    SqlContext.EmpleadosPresupuestosAprobados.Add(empleados);
                    SqlContext.SaveChanges();
                }

           
        }

        public EmpleadosPresupuestosAprobados BuscarEquiposPorPresupuesto(int PresupuestoId)
        {
            return SqlContext.EmpleadosPresupuestosAprobados.Where(o => o.PresupuestoId == PresupuestoId).SingleOrDefault();
        }

        public  List<Empleados> ObtenerEmpleadosPorTipoEmpleado(int tipoEmpleado)
        {
            int Baja = Int32.Parse(ConfigurationManager.AppSettings["Baja"].ToString());

            return SqlContext.Empleados.Where(o => o.EstadoId != Baja && o.TipoEmpleadoId == tipoEmpleado).ToList();
        }

        public List<Empleados> ListarEmpleados(EmpleadosSearcher searcher)
        {

            var query = from e in SqlContext.Empleados
                        select e;

            if (!string.IsNullOrEmpty(searcher.ApellidoNombre))
                query = query.Where(o => o.ApellidoNombre.Contains(searcher.ApellidoNombre));

            return query.ToList();

        }

    }
}


namespace DomainAmbientHouse.Entidades
{
    public partial class EmpleadosSearcher
    {
        public string ApellidoNombre { get; set; }
    }

    public partial class ResponsablesEventos
    {
        public string Cliente
        {
            get
            {
                if (RazonSocial == "")
                    return ApellidoNombre;
                else
                    return RazonSocial;
            }
        }
    }
    public partial class ResponsablesSearcher
    {
        public string NroPresupuesto { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string Organizador { get; set; }
        public string Coordinador1 { get; set; }
        public string Coordinador2 { get; set; }
    }
}