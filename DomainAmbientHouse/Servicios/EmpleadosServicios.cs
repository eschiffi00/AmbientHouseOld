using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System.Collections.Generic;

namespace DomainAmbientHouse.Servicios
{
    public class EmpleadosServicios
    {

        EmpleadosNegocios Negocios;


        public EmpleadosServicios()
        {
            Negocios = new EmpleadosNegocios();

        }


        public List<Empleados> ObtenerEmpleados()
        {

            return Negocios.ObtenerEmpleados();
        }




        public Empleados BuscarEmpleado(int id)
        {
            return Negocios.BuscarEmpleado(id);
        }

        public void NuevoEmpleado(Empleados empleado)
        {
            Negocios.NuevoEmpleado(empleado);
        }

        public List<Empleados> ListarEmpleados(EmpleadosSearcher searcher)
        {
            return Negocios.ListarEmpleados(searcher);
        }
    }
}
