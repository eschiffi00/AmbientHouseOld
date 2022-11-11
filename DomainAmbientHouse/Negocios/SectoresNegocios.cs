using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class SectoresNegocios
    {

        SectoresDatos Datos;

        public SectoresNegocios()
        {
            Datos = new SectoresDatos();
        }

        public virtual List<Sectores> ObtenerSectoresPorLocacion(int locacionId)
        {
            return Datos.ObtenerSectoresPorLocacion(locacionId);
        }


        public Sectores BuscarSector(int sectorId)
        {
            return Datos.BuscarSector(sectorId);
        }
    }
}
