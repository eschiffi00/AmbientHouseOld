using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class IndexacionNegocios
    {

        IndexacionDatos Datos;

        public IndexacionNegocios()
        {
            Datos = new IndexacionDatos();
        }

        public virtual Indexacion BuscarIndexacionVigente()
        {

            return Datos.BuscarIndexacionVigente();

        }

    }
}
