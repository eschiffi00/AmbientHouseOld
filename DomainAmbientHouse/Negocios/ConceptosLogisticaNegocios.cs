using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class ConceptosLogisticaNegocios
    {

        ConceptosLogisticaDatos Datos;

        public ConceptosLogisticaNegocios()
        {
            Datos = new ConceptosLogisticaDatos();
        }

        public virtual List<TipoLogistica> ObtenerTipoLogistica()
        {

            return Datos.ObtenerTipoLogistica();

        }


        public void NuevoTipoLogitica(TipoLogistica tipoLogistica)
        {
            Datos.NuevoTipoLogistica(tipoLogistica);
        }

        public TipoLogistica BuscarTipoLogistica(long id)
        {
            return Datos.BuscarTipoLogistica(id);
        }
    }
}
