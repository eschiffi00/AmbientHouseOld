using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class JornadasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public JornadasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Jornadas> ObtenerJornadas()
        {

            return SqlContext.Jornadas.ToList();

        }

    }
}
