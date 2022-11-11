using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class TipoEventosNegocios
    {

        TipoEventosDatos Datos;

        public TipoEventosNegocios()
        {
            Datos = new TipoEventosDatos();
        }

        public virtual List<TipoEventos> ObtenerTipoEventos()
        {

            return Datos.ObtenerTipoEventos();

        }


        public TipoEventos BuscarTipoEvento(int tipoEventoId)
        {
            return Datos.BuscarTipoEvento(tipoEventoId);
        }
    }
}
