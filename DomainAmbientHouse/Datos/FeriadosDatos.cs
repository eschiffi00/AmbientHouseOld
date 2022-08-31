using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

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
          
            return SqlContext.Feriados.Where(o=> o.Anio == anio).ToList();

        }

    }
}
