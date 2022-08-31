using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ParametrosNegocios
    {

        ParametrosDatos Datos;

        public ParametrosNegocios()
        {
            Datos = new ParametrosDatos();
        }

        public virtual Parametros BuscarParametros(string valor)
        {

            return Datos.BuscarParametros(valor);

        }


        public List<Parametros> ObtenerParametros()
        {
            return Datos.ObtenerParametros();
        }

        public Parametros BuscarParametros(int id)
        {
            return Datos.BuscarParametros(id);
        }

        public void NuevoParametro(Parametros parametros)
        {
            Datos.NuevoParametros(parametros);
        }
    }
}
