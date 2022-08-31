using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class TipoEmpleadoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public TipoEmpleadoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoEmpleados> ObtenerTipoEmpleados()
        {

            return SqlContext.TipoEmpleados.ToList();

        }

        public virtual List<TipoEmpleados> ObtenerTipoEmpleadosPorSector(int SectorEmpresaId)
        {

            return SqlContext.TipoEmpleados.Where(o=> o.SectorEmpresaId == SectorEmpresaId).ToList();

        }
    }
}
