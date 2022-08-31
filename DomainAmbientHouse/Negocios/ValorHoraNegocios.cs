using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ValorHoraNegocios
    {

      ValorHorasDatos Datos;

      public ValorHoraNegocios()
        {
            Datos = new ValorHorasDatos();
        }

      //public virtual List<ValorHoras> ObtenerValorHoras()
      //  {

      //      return Datos.ObtenerValorHoras();

      //  }

      //public ValorHoras BuscarValorHoras(int id)
      //{
      //    return Datos.BuscarValorHoras(id);
      //}

      //public void NuevoValorHora(ValorHoras vh)
      //{
      //    Datos.NuevoValorHora(vh);
      //}

      //public ValorHoras BuscarValorHoraPorSectorTipoEmpleadoTipoPago(int sectorId, int tipoEmpleadoId, int tipoPagoId)
      //{
      //    return Datos.BuscarValorHoraPorSectorTipoEmpleadoTipoPago(sectorId,tipoEmpleadoId,tipoPagoId);
      //}


     
    }
}
