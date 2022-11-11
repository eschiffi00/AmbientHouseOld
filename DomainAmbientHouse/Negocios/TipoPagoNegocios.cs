using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class TipoPagoNegocios
    {

        TipoPagoDatos Datos;

        public TipoPagoNegocios()
        {
            Datos = new TipoPagoDatos();
        }

        public virtual List<TipoPagoEmpleados> ObtenerTipoPago()
        {

            return Datos.ObtenerTipoPagos();

        }




    }
}
