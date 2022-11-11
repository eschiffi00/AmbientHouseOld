using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
