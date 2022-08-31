using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class MonedasNegocios
    {

        MonedasDatos Datos;

        public MonedasNegocios()
        {
            Datos = new MonedasDatos();
        }

        public virtual List<Monedas> ObtenerMonedas()
        {

            return Datos.ObtenerMonedas();

        }

    }
}
