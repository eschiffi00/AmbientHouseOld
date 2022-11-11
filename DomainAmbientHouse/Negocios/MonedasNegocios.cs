using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
