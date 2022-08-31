using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

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
