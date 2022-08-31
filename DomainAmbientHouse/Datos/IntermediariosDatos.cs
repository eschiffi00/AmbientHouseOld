using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainAmbientHouse.Datos
{
    public class IntermediariosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public IntermediariosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }



        public List<Intermediarios> BuscarValoresIntermediariosPorLocacion(int locacionId)
        {
            return SqlContext.Intermediarios.Where(o => o.LocacionId == locacionId).ToList();
        }
    }
}
