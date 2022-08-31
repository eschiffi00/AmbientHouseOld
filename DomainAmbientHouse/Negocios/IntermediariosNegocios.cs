using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
