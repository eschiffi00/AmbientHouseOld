using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class FeriadosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public FeriadosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Feriados> ObtenerFeriados(int anio, int mes)
        {

            return SqlContext.Feriados.Where(o => o.Anio == anio).ToList();

        }

    }
}
