using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class TipoEmpleadoNegocios
    {

        TipoEmpleadoDatos Datos;

        public TipoEmpleadoNegocios()
        {
            Datos = new TipoEmpleadoDatos();
        }

        public virtual List<TipoEmpleados> ObtenerTipoEmpleados()
        {

            return Datos.ObtenerTipoEmpleados();

        }

        public virtual List<TipoEmpleados> ObtenerTipoEmpleadosPorSector(int sectorId)
        {

            return Datos.ObtenerTipoEmpleadosPorSector(sectorId);

        }


    }
}
