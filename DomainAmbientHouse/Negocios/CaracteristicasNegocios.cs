using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
