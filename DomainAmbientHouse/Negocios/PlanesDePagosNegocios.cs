using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class PlanesDePagosNegocios
    {

      PlanesDePagosDatos Datos;

      public PlanesDePagosNegocios()
        {
            Datos = new PlanesDePagosDatos();
        }

      public virtual List<PlanesDePago> ObtenerPlanesDePagos()
        {

            return Datos.ObtenerPlanesDePagos();

        }


      public PlanesDePago BuscarPlanesDePago(int id)
      {
          return Datos.BuscarPlanesDePago(id);
      }

      public void NuevaPlanesDePago(PlanesDePago planesDePago)
      {
          Datos.NuevaPlanesDePago(planesDePago);
      }

   
    }
}
