using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class IntermediariosNegocios
    {

        IntermediariosDatos Datos;

        public IntermediariosNegocios()
        {
            Datos = new IntermediariosDatos();
        }

        public virtual List<Intermediarios> BuscarValoresIntermediariosPorLocacion(int locacionId)
        {

            return Datos.BuscarValoresIntermediariosPorLocacion(locacionId);

        }

    }
}
