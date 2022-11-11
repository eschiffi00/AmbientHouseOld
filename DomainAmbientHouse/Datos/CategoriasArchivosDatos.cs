using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class CategoriasArchivosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CategoriasArchivosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public List<CategoriasArchivos> ObtenerCategoriasArchivos()
        {
            return SqlContext.CategoriasArchivos.ToList();
        }



        public void NuevaCategoriaArchivo(CategoriasArchivos Categorias)
        {
            SqlContext.CategoriasArchivos.Add(Categorias);
            SqlContext.SaveChanges();
        }
    }
}
