using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class CentroCostosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CentroCostosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<CentroCostos> ObtenerCentroCostos()
        {

            return SqlContext.CentroCostos.ToList();

        }

    }
}
