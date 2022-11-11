using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class UbicacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public UbicacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Provincias> ObtenerProvincias()
        {

            return SqlContext.Provincias.ToList();

        }

        private List<Ciudades> CiudadesToModel(IQueryable<Ciudades> query)
        {
            List<Ciudades> list = new List<Ciudades>();

            foreach (var item in query)
            {
                Ciudades salida = new Ciudades();

                salida.Id = item.Id;
                salida.Descripcion = item.Descripcion;
                salida.CP = item.CP;
                salida.ProvinciaId = item.ProvinciaId;
                salida.ProvinciaDescripcion = SqlContext.Provincias.Single(o => o.Id == item.ProvinciaId).Descripcion;



                list.Add(salida);
            }

            return list;
        }

        public virtual List<Ciudades> BuscarCiudadesPorProvincia(int provinciaId)
        {

            var query = from c in SqlContext.Ciudades
                        where c.ProvinciaId == provinciaId
                        select c;

            return query.OrderBy(o => o.Descripcion).ToList();

        }


        internal Ciudades BuscarCiudad(int Id)
        {
            return SqlContext.Ciudades.Single(o => o.Id == Id);
        }

        public virtual Provincias BuscarProvinciaPorCiudad(int ciudadId)
        {
            var query = from C in SqlContext.Ciudades
                        join P in SqlContext.Provincias on C.ProvinciaId equals P.Id
                        where C.Id == ciudadId
                        select P;

            return query.SingleOrDefault();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class Ciudades
    {

        public string ProvinciaDescripcion { get; set; }

    }
}