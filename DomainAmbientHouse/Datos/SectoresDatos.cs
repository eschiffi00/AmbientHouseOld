using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class SectoresDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public SectoresDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }
        
        public virtual List<Sectores> ObtenerSectoresPorLocacion(int locacionId)
        {

            return SqlContext.Sectores.Where(o=>o.LocacionId == locacionId).ToList();

        }


        public void NuevoSectores(Sectores sector)
        {
            if (sector.Id > 0)
            {
                Sectores editSector = SqlContext.Sectores.Where(o => o.Id == sector.Id).FirstOrDefault();

                editSector.Descripcion = sector.Descripcion;
                editSector.LocacionId = sector.LocacionId;
            
            }
            else
            {
                SqlContext.Sectores.Add(sector);
                SqlContext.SaveChanges();
            }
        }

        public Sectores BuscarSector(int sectorId)
        {
            return SqlContext.Sectores.Where(o => o.Id == sectorId).SingleOrDefault();
        }
    }
}
