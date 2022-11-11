using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

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
