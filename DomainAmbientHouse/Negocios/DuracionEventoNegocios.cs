using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class DuracionEventoNegocios
    {

        DuracionEventoDatos Datos;

        public DuracionEventoNegocios()
        {
            Datos = new DuracionEventoDatos();
        }

        public virtual List<DuracionEvento> ObtenerDuracionEvento()
        {

            return Datos.ObtenerDuracionEvento();

        }


        public DuracionEvento BuscarDuracion(int id)
        {
            return Datos.BuscarDuracion(id);
        }

        public void NuevaDuracionEvento(DuracionEvento item)
        {
            Datos.NuevaDuracionEvento(item);
        }
    }
}
