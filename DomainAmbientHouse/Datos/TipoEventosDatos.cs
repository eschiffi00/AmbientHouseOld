using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class TipoEventosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoEventosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoEventos> ObtenerTipoEventos()
        {

            return SqlContext.TipoEventos.ToList();

        }


        public TipoEventos BuscarTipoEvento(int tipoEventoId)
        {
            return SqlContext.TipoEventos.Where(o => o.Id == tipoEventoId).SingleOrDefault();
        }
    }
}
