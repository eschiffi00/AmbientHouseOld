using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class ItemsNegocios
    {

        ItemsDatos Datos;

        public ItemsNegocios()
        {
            Datos = new ItemsDatos();
        }

        public virtual List<Items> ObtenerItems(int estadoId)
        {

            return Datos.ObtenerItems(estadoId);

        }

        public virtual List<Items> BuscarItemsFiltros(string detalle, string categoria, int estadoId)
        {

            return Datos.BuscarItemsFiltros(detalle, categoria, estadoId);

        }

        public Items BuscarItems(int id)
        {
            return Datos.BuscarItems(id);
        }

        public void NuevoItems(Items item)
        {
            Datos.NuevoItem(item);
        }

        public List<Items> ObtenerItemsPorGrupo(int grupoId)
        {
            return Datos.ObtenerItemsPorGrupo(grupoId);
        }

        //public List<Items> ObtenerItemsAdicionales(int AdicionalId)
        //{
        //    return Datos.ObtenerItemsAdicionales(AdicionalId);
        //}

        public List<Items> ObtenerItemsPorCategorias(int CategoriaId)
        {
            return Datos.ObtenerItemsPorCategorias(CategoriaId);
        }


        public List<Items> ObtenerItemsPorCategoria(int categoriaId)
        {
            return Datos.ObtenerItemsPorCategoria(categoriaId);
        }

        public void ActualizarItem(Items item)
        {
            Datos.ActualizarItem(item);
        }

        public List<Items> BuscarItemsAsociados(int productoCateringId, string categoria, int estadoActivo)
        {
            return Datos.BuscarItemsFiltrosAgregadosProductos(productoCateringId, categoria, estadoActivo);
        }

        public List<Items> BuscarItemsNoAsociados(int productoCateringId, string categoria, int estadoActivo)
        {
            return Datos.BuscarItemsFiltrosNoAgregadosProductos(productoCateringId, categoria, estadoActivo);
        }


        public List<Items> ObtenerItemsPorTipoCateringTiempoProducto(int TipoCateringId, int TiempoId, int ProductoCateringId)
        {
            return Datos.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, TiempoId, ProductoCateringId);
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempoCategorias(int TipoCateringId, int TiempoId, int CategoriaId)
        {
            return Datos.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, TiempoId, CategoriaId);
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            return Datos.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        public List<Items> ObtenerItemsPorTipoBarraCategorias(int TipoBarraId, int CategoriaItem)
        {
            return Datos.ObtenerItemsPorTipoBarraCategorias(TipoBarraId, CategoriaItem);
        }

        public List<Items> ObtenerItemsPorTipoBarra(int TipoBarraId)
        {
            return Datos.ObtenerItemsPorTipoBarra(TipoBarraId);
        }

        internal List<Items> BuscarItemsporAdicional(int adicionalId)
        {
            return Datos.ListarItemsPorAdicional(adicionalId);
        }

        public List<BuscarItemsporTipoCatering_Result> BuscarItemsPorTipoCatering(int TipoCateringId)
        {
            return Datos.BuscarItemsPorTipoCatering(TipoCateringId);
        }
    }
}
