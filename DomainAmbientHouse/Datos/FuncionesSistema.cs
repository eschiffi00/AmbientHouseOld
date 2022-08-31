using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainAmbientHouse.Datos
{
    public class FuncionesSistemasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public FuncionesSistemasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual void ActualizarPresupuestosVencidos()
        {

           int resultado =  SqlContext.ActualizarPresupuestosVencidos();

        }
    }
}
