using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
        return Datos.BuscarTipoLogistica( id);
      }
    }
}
