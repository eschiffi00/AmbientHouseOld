using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class CondicionIvaDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CondicionIvaDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<CondicionIva> ListarCondicionIva()
        {
            return SqlContext.CondicionIva.ToList();
        }

        public virtual CondicionIva BuscarCondicionIva(int Id)
        {
            return SqlContext.CondicionIva.Where(o => o.Id == Id).FirstOrDefault();
        }


    }
}
