using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class TipoPagoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoPagoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoPagoEmpleados> ObtenerTipoPagos()
        {

            return SqlContext.TipoPagoEmpleados.ToList();

        }




    }
}
