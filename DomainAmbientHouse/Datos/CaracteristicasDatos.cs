using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class CaracteristicasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CaracteristicasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Caracteristicas> ObtenerCaracteristicas()
        {

            return SqlContext.Caracteristicas.ToList();

        }

    }
}
