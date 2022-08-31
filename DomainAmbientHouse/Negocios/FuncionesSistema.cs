using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class FuncionesSistemaNegocios
    {

        FuncionesSistemasDatos Datos;

        public FuncionesSistemaNegocios()
        {
            Datos = new FuncionesSistemasDatos();
        }

        public virtual void ActualizarPresupuestosVencidos()
        {

            Datos.ActualizarPresupuestosVencidos();

        }

    }
}
