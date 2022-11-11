using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class HerramientasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public HerramientasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ObtenerArchivosPorCategorias> ObtenerHerramientas()
        {

            return SqlContext.ObtenerArchivosPorCategorias.OrderBy(o => o.CarpetaId).ToList();


        }


        public void GrabarHerramientas(Herramientas herramienta)
        {
            SqlContext.Herramientas.Add(herramienta);
            SqlContext.SaveChanges();
        }



        public Herramientas TraerArchivo(int herramientaId)
        {
            return SqlContext.Herramientas.Where(o => o.Id == herramientaId).FirstOrDefault();
        }

        public void EliminarArchivo(Herramientas herramienta)
        {
            Herramientas HerrEliminar = SqlContext.Herramientas.Where(o => o.Id == herramienta.Id).Single();

            SqlContext.Herramientas.Remove(HerrEliminar);

            SqlContext.SaveChanges();
        }
    }
}
