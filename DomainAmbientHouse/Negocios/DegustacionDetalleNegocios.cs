using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class DegustacionDetalleNegocios
    {

        DegustacionDetalleDatos Datos;

        public DegustacionDetalleNegocios()
        {
            Datos = new DegustacionDetalleDatos();
        }

        public virtual DegustacionDetalle BuscarDegustacionDetalle(int Id)
        {

            return Datos.BuscarDegustacionDetalle(Id);

        }

        public virtual List<DegustacionDetalle> BuscarDegustacionDetallePorDegustacion(int DegustacionId)
        {

            return Datos.BuscarDegustacionDetallePorDegustacion(DegustacionId);

        }

        public virtual List<DegustacionDetalle> BuscarDegustacionDetallePorEmpleado(int DegustacionId, int EmpleadoId)
        {

            return Datos.BuscarDegustacionDetallePorEmpleado(DegustacionId, EmpleadoId);

        }

        public virtual void GrabarDegustacionDetalle(DegustacionDetalle degustacion)
        {

            Datos.GrabarDegustacionDetalle(degustacion);

        }

    }
}
