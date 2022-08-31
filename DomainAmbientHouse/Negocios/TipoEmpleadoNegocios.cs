using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;

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
