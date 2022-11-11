using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class JornadasNegocios
    {

        JornadasDatos Datos;

        public JornadasNegocios()
        {
            Datos = new JornadasDatos();
        }

        public virtual List<Jornadas> ObtenerJornadas()
        {

            return Datos.ObtenerJornadas();

        }

    }
}
