using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

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
