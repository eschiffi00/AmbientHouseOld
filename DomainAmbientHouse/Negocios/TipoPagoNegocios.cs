using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;

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
