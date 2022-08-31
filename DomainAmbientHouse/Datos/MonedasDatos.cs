using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class MonedasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public MonedasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Monedas> ObtenerMonedas()
        {
            return SqlContext.Monedas.ToList();

        }

        public virtual ConversionMonedas BuscarConversion(int origenId, int destinoId)
        {
            return SqlContext.ConversionMonedas.SingleOrDefault(o => o.MonedaOrigenId == origenId 
                                                                    && o.MonedaDestinoId == destinoId);
        }

    }
}
