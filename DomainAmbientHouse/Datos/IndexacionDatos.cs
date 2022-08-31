using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class IndexacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public IndexacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual Indexacion BuscarIndexacionVigente()
        {

            return SqlContext.Indexacion.Where(o => o.FechaVencimiento == null).FirstOrDefault();

        }

    }
}
