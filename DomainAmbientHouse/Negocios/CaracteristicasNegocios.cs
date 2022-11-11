using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class CaracteristicasNegocios
    {

        CaracteristicasDatos Datos;

        public CaracteristicasNegocios()
        {
            Datos = new CaracteristicasDatos();
        }

        public virtual List<Caracteristicas> ObtenerCaracteristicas()
        {

            return Datos.ObtenerCaracteristicas();

        }

    }
}
