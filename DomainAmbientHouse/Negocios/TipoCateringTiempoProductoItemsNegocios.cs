using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class TipoCateringTiempoProductoItemsNegocios
    {

        TipoCateringTiempoProductoItemDatos Datos;

        public TipoCateringTiempoProductoItemsNegocios()
        {
            Datos = new TipoCateringTiempoProductoItemDatos();
        }

        public virtual List<TipoCateringTiempoProductoItem> ObtenerTipoCateringTiempoProductoItemDatos(int tipoCateringId)
        {

            return Datos.ObtenerTipoCateringTiempoProductoItemDatos(tipoCateringId);

        }


        public TipoCateringTiempoProductoItem BuscarTipoCateringTiempoProductoItem(long id)
        {
            return Datos.BuscarTipoCateringTiempoProductoItem(id);
        }

        public void NuevoTipoCateringTiempoProductoItem(TipoCateringTiempoProductoItem tipo)
        {
            Datos.NuevoTipoCateringTiempoProductoItem(tipo);
        }

        public List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCatering(int tipoCatering)
        {
            return Datos.BuscarConfiguracionPorTipoCatering(tipoCatering);
        }


        public void ActualizarTipoCateringTiempoProductoItem(TipoCateringTiempoProductoItem item)
        {
            Datos.ActualizarTipoCateringTiempoProductoItem(item);
        }

        public List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCateringArmadoArbol(int TipoCateringId)
        {
            return Datos.BuscarConfiguracionPorTipoCateringArmadoArbol(TipoCateringId);
        }
    }
}
