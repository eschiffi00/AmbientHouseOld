using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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


        public  Sectores BuscarSector(int sectorId)
        {
            return Datos.BuscarSector(sectorId);
        }
    }
}
