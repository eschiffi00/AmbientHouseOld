using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class CategoriasArchivosNegocios
    {

        CategoriasArchivosDatos Datos;

        public CategoriasArchivosNegocios()
        {
            Datos = new CategoriasArchivosDatos();
        }

        public virtual List<CategoriasArchivos> ObtenerCategoriasArchivos()
        {

            return Datos.ObtenerCategoriasArchivos();

        }


        public void NuevaCategoriaArchivo(CategoriasArchivos Categorias)
        {
            Datos.NuevaCategoriaArchivo(Categorias);
        }
    }
}
