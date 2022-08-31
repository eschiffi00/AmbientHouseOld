using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Globalization;

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
