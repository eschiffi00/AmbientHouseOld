using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class SectoresEmpresasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public SectoresEmpresasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }
        
        public virtual List<SectoresEmpresa> ObtenerSectoresEmpresaPorDepartamento(int departamentoId)
        {

            return SqlContext.SectoresEmpresa.Where(o => o.DepartamentoId == departamentoId).ToList();

        }


        public void NuevoSectores(SectoresEmpresa sector)
        {
            if (sector.Id > 0)
            {
                SectoresEmpresa editSector = SqlContext.SectoresEmpresa.Where(o => o.Id == sector.Id).FirstOrDefault();

                editSector.Descripcion = sector.Descripcion;
                editSector.DepartamentoId  = sector.DepartamentoId;
            
            }
            else
            {
                SqlContext.SectoresEmpresa.Add(sector);
                SqlContext.SaveChanges();
            }
        }

        public SectoresEmpresa BuscarSectorEmpresa(int Id)
        {
            return SqlContext.SectoresEmpresa.Where(o => o.Id == Id).SingleOrDefault();
        }

        internal List<SectoresEmpresa> ObtenerSectoresEmpresa()
        {
            return SqlContext.SectoresEmpresa.ToList();
        }
    }
}
