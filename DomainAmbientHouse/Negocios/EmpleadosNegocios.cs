using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class EmpleadosNegocios
    {

        EmpleadosDatos Datos;

        public EmpleadosNegocios()
        {
            Datos = new EmpleadosDatos();
        }

        public virtual List<Empleados> BuscarEmpleadosPorDepartamento(int departamentoId)
        {

            return Datos.BuscarEmpleadosPorDepartamento(departamentoId);

        }


        public List<Empleados> ObtenerEmpleados()
        {
            return Datos.ObtenerEmpleados();

        }

        public Empleados BuscarEmpleado(int id)
        {
            return Datos.BuscarEmpleado(id);
        }

        public void NuevoEmpleado(Empleados empleado)
        {
            Datos.NuevoEmpleado(empleado);
        }

        public void GrabarEquipo(EmpleadosPresupuestosAprobados empleados)
        {
            Datos.GrabarEquipo(empleados);
        }

        public EmpleadosPresupuestosAprobados BuscarEquiposPorPresupuesto(int PresupuestoId)
        {
            return Datos.BuscarEquiposPorPresupuesto(PresupuestoId);
        }

        internal List<Empleados> ObtenerEmpleadosPorTipoEmpleado(int tipoEmpleado)
        {
            return Datos.ObtenerEmpleadosPorTipoEmpleado(tipoEmpleado);
        }

        //internal List<PersonalEventos> BuscarPersonalEvento(int EventoId)
        //{
        //   return Datos.BuscarPersonalEvento( EventoId);
        //}

        internal List<Empleados> ListarEmpleados(EmpleadosSearcher searcher)
        {
            return Datos.ListarEmpleados(searcher);
        }
    }
}
