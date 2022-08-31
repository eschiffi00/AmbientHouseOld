using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ObjetivosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ObjetivosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ObjetivosEmpleados> BuscarObjetivosPorEmpleadoMensuales(int empleadoId)
        {

            return SqlContext.ObjetivosEmpleados.Where(o=> o.EmpleadoId == empleadoId).ToList();

        }

        public virtual int BuscarObjetivosCumplidosPorEmpleadoMensuales(int empleadoId, int mes, int anio)
        {

            return SqlContext.Eventos.Where(o => o.EmpleadoId == empleadoId).Count();

        }

    }
}
