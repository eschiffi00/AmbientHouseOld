using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class EstadosNegocios
    {

        EstadosDatos Datos;

        public EstadosNegocios()
        {
            Datos = new EstadosDatos();
        }

        public virtual List<Estados> BuscarEstadosPorEntidad(string entidad)
        {

            return Datos.BuscarEstadosPorEntidad(entidad);

        }

        public virtual List<Estados> BuscarEstadosPorEntidadParaSeguimientos(string entidad)
        {

            return Datos.BuscarEstadosPorEntidadParaSeguimientos(entidad);

        }


        public Estados BuscarEstado(int Id)
        {
            return Datos.BuscarEstado(Id);
        }
    }
}
