using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
            return Datos.BuscarDuracion( id);
        }

        public void NuevaDuracionEvento(DuracionEvento item)
        {
            Datos.NuevaDuracionEvento(item);
        }
    }
}
