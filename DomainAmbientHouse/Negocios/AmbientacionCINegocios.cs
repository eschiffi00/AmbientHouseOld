using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class AmbientacionCINegocios
    {

        AmbientacionCIDatos Datos;

        public AmbientacionCINegocios()
        {
            Datos = new AmbientacionCIDatos();
        }

        public virtual List<AmbientacionCI> ObtenerAmbientacionesCI()
        {

            return Datos.ObtenerAmbientacionesCI();

        }

        public virtual void Grabar(AmbientacionCI ambientacion)
        { Datos.Grabar(ambientacion); }

        public virtual AmbientacionCI Buscar(int Id)
        {
            return Datos.Buscar(Id);
        }

    }
}
