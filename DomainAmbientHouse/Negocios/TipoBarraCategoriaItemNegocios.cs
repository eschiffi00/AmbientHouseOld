using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class TipoBarraCategoriaItemNegocios
    {

        TipoBarraCategoriaItemDatos Datos;

        public TipoBarraCategoriaItemNegocios()
        {
            Datos = new TipoBarraCategoriaItemDatos();
        }

        public virtual List<TipoBarraCategoriaItem> ObtenerTipoBarraCategoriaItem(int tipoBarraId)
        {

            return Datos.ObtenerTipoBarraCategoriaItem(tipoBarraId);

        }


        public TipoBarraCategoriaItem BuscarTipoBarraCategoriaItem(long id)
        {
            return Datos.BuscarTipoBarraCategoriaItem(id);
        }

        public void NuevoTipoBarraCategoriaItem(TipoBarraCategoriaItem tipo)
        {
            Datos.NuevoTipoBarraCategoriaItem(tipo);
        }

        //public List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCatering(int tipoCatering)
        //{
        //    return Datos.BuscarConfiguracionPorTipoCatering(tipoCatering);
        //}


        public void ActualizarTipoBarraCategoriaItem(TipoBarraCategoriaItem item)
        {
            Datos.ActualizarTipoBarraCategoriaItem(item);
        }

        //public  List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCateringArmadoArbol(int TipoCateringId)
        //{
        //    return Datos.BuscarConfiguracionPorTipoCateringArmadoArbol(TipoCateringId);
        //}
    }
}
