using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
