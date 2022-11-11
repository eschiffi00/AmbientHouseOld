using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class TipoCateringNegocios
    {

        TipoCateringDatos Datos;

        public TipoCateringNegocios()
        {
            Datos = new TipoCateringDatos();
        }

        public virtual List<TipoCatering> ObtenerTipoCatering()
        {

            return Datos.ObtenerTipoCatering();

        }

        public virtual List<TipoCatering> BuscarTipoCateringPorSegmentoCaracteristicaMomendoDuracionEvento(int caracteristicaId, int segmentoId, int MomentoDiaId, int DuracionId)
        {

            return Datos.BuscarTipoCateringPorSegmentoCaracteristicaMomendoDuracionEvento(caracteristicaId, segmentoId, MomentoDiaId, DuracionId);

        }

        public TipoCatering BuscarTipoCatering(long id)
        {
            return Datos.BuscarTipoCatering(id);
        }

        public void NuevoTipoCatering(TipoCatering TipoCatering)
        {
            Datos.NuevoTipoCatering(TipoCatering);
        }

        public void EditarTipoCatering(TipoCatering tipoCatering)
        {
            Datos.EditarTipoCatering(tipoCatering);
        }

        public List<TipoCatering> ObtenerAdicionalesTipoCatering()
        {
            return Datos.ObtenerAdicionalesTipoCatering();
        }

        public List<ConfiguracionCateringTecnica> ObtenerConfiguracionCateringTecnica(int segmentoId, int caracteristicaId, int momentoDiaId, int duracionId)
        {
            return Datos.ObtenerConfiguracionCateringTecnica(segmentoId, caracteristicaId, momentoDiaId, duracionId);
        }

        public void ImportarConfiguracionCateringTecnica(List<ConfiguracionCateringTecnica> configuracionCateringTecnica)
        {

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    //Datos.EliminarConfiguracionCateringTecnica();


                    foreach (var item in configuracionCateringTecnica)
                    {

                        ConfiguracionCateringTecnica configuracion = new ConfiguracionCateringTecnica();

                        configuracion.SegmentoId = item.SegmentoId;
                        configuracion.CaracteristicaId = item.CaracteristicaId;
                        configuracion.DuracionId = item.DuracionId;
                        configuracion.MomentoDiaId = item.MomentoDiaId;
                        configuracion.TipoCateringId = item.TipoCateringId;
                        configuracion.TipoServicioId = item.TipoServicioId;
                        configuracion.EstadoId = item.EstadoId;


                        Datos.NuevaConfiguracionCateringTecnica(configuracion);


                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        internal void GrabarConfiguracionCateringTecnica(List<ConfiguracionCateringTecnica> list)
        {
            using (TransactionScope scope = new TransactionScope())
            {

            }

        }

        public List<TipoCatering> ObtenerTipoCateringSoloActivos()
        {
            return Datos.ObtenerTipoCateringSoloActivos();
        }

        public ConfiguracionCateringTecnica BuscarConfiguracionCateringTecnica(int segmentoId, int caracteristicaId, int momentoDiaId, int duracionId, int tipoCateringId, int tipoServicioId)
        {
            return Datos.BuscarConfiguracionCateringTecnica(segmentoId, caracteristicaId, momentoDiaId, duracionId, tipoCateringId, tipoServicioId);
        }

        public void ActivarDesactivarConfiguracion(int Id, int estado)
        {
            Datos.ActivarDesactivarConfiguracion(Id, estado);
        }

        public List<TipoCatering> BuscarTipoCateringPorAdicional(int adicionalId)
        {
            return Datos.BuscarTipoCateringPorAdicional(adicionalId);
        }

        public List<TipoCatering> BuscarTipoCateringParaAgregarPorAdicional(int adicionalId)
        {
            return Datos.BuscarTipoCateringParaAgregarPorAdicional(adicionalId);
        }

        public void ActualizarTipoCatering(TipoCatering item)
        {
            Datos.ActualizarTipoCatering(item);
        }
    }
}
