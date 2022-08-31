using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class CentroCostosNegocios
    {

        CentroCostosDatos Datos;

      public CentroCostosNegocios()
        {
            Datos = new CentroCostosDatos();
        }

      public virtual List<CentroCostos> ObtenerCentroCostos()
        {

            return Datos.ObtenerCentroCostos();

        }

    }
}
