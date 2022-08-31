using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
            return Datos.BuscarEstado( Id);
        }
    }
}
