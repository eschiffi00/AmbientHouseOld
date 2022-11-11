using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class UbicacionNegocios
    {

        UbicacionDatos Datos;

        public UbicacionNegocios()
        {
            Datos = new UbicacionDatos();
        }

        public virtual List<Provincias> ObtenerProvincias()
        {

            return Datos.ObtenerProvincias();

        }

        public virtual List<Ciudades> BuscarCiudadesPorProvincia(int provinciaId)
        {
            return Datos.BuscarCiudadesPorProvincia(provinciaId);
        }


        internal Ciudades BuscarCiudad(int Id)
        {
            return Datos.BuscarCiudad(Id);
        }

        public virtual Provincias BuscarProvinciaPorCiudad(int ciudadId)
        {
            return Datos.BuscarProvinciaPorCiudad(ciudadId);
        }
    }
}
