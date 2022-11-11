using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
