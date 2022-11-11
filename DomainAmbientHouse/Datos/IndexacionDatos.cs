using DomainAmbientHouse.Entidades;
using System.Linq;

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
