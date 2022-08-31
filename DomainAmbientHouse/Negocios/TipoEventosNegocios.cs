using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
