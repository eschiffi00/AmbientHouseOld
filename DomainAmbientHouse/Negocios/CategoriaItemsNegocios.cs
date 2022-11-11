using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class CategoriaItemsNegocios
    {

        CategoriaItemsDatos Datos;

        public CategoriaItemsNegocios()
        {
            Datos = new CategoriaItemsDatos();
        }

        public virtual List<CategoriasItem> ObtenerCategoriasItem()
        {
            return Datos.ObtenerCategoriasItem();

        }

        public virtual CategoriasItem BuscarCategoriaPadre(int id)
        {
            return Datos.BuscarPadreCategoria(id);
        }


        public List<CategoriasItem> ObtenerCategoriasPorGrupos(int grupoId)
        {
            return Datos.ObtenerCategoriasPorGrupos(grupoId);
        }

        public List<CategoriasItem> ObtenerCategoriasItemHijosPadres()
        {
            return Datos.ObtenerCategoriasItemHijosPadres();
        }

        public CategoriasItem BuscarCategoriaItem(int id)
        {
            return Datos.BuscarCategoriaItem(id);
        }

        public void NuevaCategoriaItem(CategoriasItem categoria)
        {
            Datos.NuevaCategoriaItem(categoria);
        }

        public List<CategoriasItem> ObtenerCategoriasPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            return Datos.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        public List<CategoriasItem> ObtenerCategoriasPorTipoBarra(int TipoBarraId)
        {
            return Datos.ObtenerCategoriasPorTipoBarra(TipoBarraId);
        }
    }
}
