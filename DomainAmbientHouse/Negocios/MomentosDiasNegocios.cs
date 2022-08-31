using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class MomentosDiasNegocios
    {

      MomentosDiaDatos Datos;

      public MomentosDiasNegocios()
        {
            Datos = new MomentosDiaDatos();
        }

      public virtual List<MomentosDias> ObtenerMomentosDia()
        {

            return Datos.ObtenerMomentosDia();

        }


      public MomentosDias BuscarMomentosDias(int id)
      {
          return Datos.BuscarMomentosDias(id);
      }

      public void NuevoMomentoDia(MomentosDias item)
      { 
        Datos.NuevoMomentoDia( item);
      }
    }
}
