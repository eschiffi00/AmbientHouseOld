using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
