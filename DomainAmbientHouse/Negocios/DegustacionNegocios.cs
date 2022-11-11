using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class DegustacionNegocios
    {

        DegustacionDatos Datos;

        public DegustacionNegocios()
        {
            Datos = new DegustacionDatos();
        }

        public virtual Degustacion BuscarDegustacion(int Id)
        {

            return Datos.BuscarDegustacion(Id);

        }

        public virtual void GrabarDegustacion(Degustacion degustacion)
        {

            Datos.GrabarDegustacion(degustacion);

        }

        public virtual List<Degustacion> ObtenerDegustaciones()
        {

            return Datos.ObtenerDegustaciones();

        }



    }
}
