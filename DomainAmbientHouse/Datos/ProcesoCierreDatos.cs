using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ProcesoCierreDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ProcesoCierreDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ProcesoCierre> ObtenerProcesoCierre()
        {

            return SqlContext.ProcesoCierre.ToList();

        }

    }
}
