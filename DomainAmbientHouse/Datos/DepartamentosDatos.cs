using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class DepartamentosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public DepartamentosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Departamentos> ObtenerDepartamentos()
        {

            return SqlContext.Departamentos.ToList();

        }


        public Departamentos BuscarDepartamentoPorSector(int sectorid)
        {
            var query = from s in SqlContext.SectoresEmpresa
                        join d in SqlContext.Departamentos on s.DepartamentoId equals d.Id
                        where s.Id == sectorid
                        select d;

            return query.SingleOrDefault();
        }
    }
}
