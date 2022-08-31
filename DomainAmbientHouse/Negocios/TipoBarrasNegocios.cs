using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class TipoBarrasNegocios
    {

        TipoBarrasDatos Datos;

      public TipoBarrasNegocios()
        {
            Datos = new TipoBarrasDatos();
        }

      public virtual List<TiposBarras> ObtenerTipoBarras()
        {

            return Datos.ObtenerTipoBarras();

        }


      public TiposBarras BuscarTipoBarras(int id)
      {
          return Datos.BuscarTipoBarras(id);
      }

      public void NuevoTipoBarra(TiposBarras tipoBarra)
      {
          Datos.NuevoTipoBarra( tipoBarra);
      }

      public List<TiposBarras> BuscarTipoBarrasPorSegmento(int segmentoId, int duracionId)
      {
          return Datos.BuscarTipoBarrasPorSegmento(segmentoId, duracionId);
      }
    }
}
