using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
