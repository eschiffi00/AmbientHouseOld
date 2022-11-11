using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class CategoriasNegocios
    {

        CategoriasDatos Datos;

        public CategoriasNegocios()
        {
            Datos = new CategoriasDatos();
        }

        public virtual List<Categorias> ObtenerCategorias()
        {

            return Datos.ObtenerCategorias();

        }

        public List<Categorias> ObtenerAmbientaciones()
        {
            return Datos.ObtenerAmbientaciones();
        }

        public Categorias BuscarCategorias(int id)
        {
            return Datos.BuscarCategorias(id);
        }

        public void NuevaCategoria(Categorias categoria)
        {
            Datos.NuevaCategoria(categoria);
        }

        public List<Categorias> BuscarCategoriasPorLocacionCaracteristicaSegmento(int locacionId, int caracteristicaId, int segmentoId, int sectorId)
        {
            return Datos.BuscarCategoriasPorLocacionCaracteristicaSegmento(locacionId, caracteristicaId, segmentoId, sectorId);
        }


        internal List<Categorias> ObtenerAmbientacionesPorLocacion(int locacionId)
        {
            return Datos.ObtenerAmbientacionesPorLocacion(locacionId);
        }
    }
}
