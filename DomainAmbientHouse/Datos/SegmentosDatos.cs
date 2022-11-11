using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class SegmentosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public SegmentosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Segmentos> ObtenerSegmentos()
        {

            return SqlContext.Segmentos.ToList();

        }


        public Segmentos BuscarSegmentos(int Id)
        {
            return SqlContext.Segmentos.Where(o => o.Id == Id).SingleOrDefault();
        }
    }
}
