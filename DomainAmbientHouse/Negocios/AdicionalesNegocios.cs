using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class AdicionalesNegocios
    {

        AdicionalesDatos Datos;

        public AdicionalesNegocios()
        {
            Datos = new AdicionalesDatos();
        }

        public virtual List<ObtenerAdicionales> ObtenerAdicionales()
        {

            return Datos.ObtenerAdicionales();

        }

        public Adicionales BuscarAdicional(int id)
        {
            return Datos.BuscarAdicional(id);
        }

        public void NuevoAdicional(Adicionales adicional, List<TipoCatering> ListTipoCatering, List<TipoServicios> ListTipoServicios)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Datos.NuevoAdicional(adicional);

                    if (ListTipoCatering.Count > 0)
                    {
                        TipoCateringDatos datos = new TipoCateringDatos();

                        datos.EliminarTipoCateringAdicional(adicional.Id);

                        foreach (var item in ListTipoCatering)
                        {


                            TipoCateringAdicional tcA = new TipoCateringAdicional();

                            tcA.AdicionalId = adicional.Id;
                            tcA.TipoCateringId = item.Id;

                            datos.NuevoTipoCateringAdicional(tcA);


                        }

                    }

                    if (ListTipoServicios.Count > 0)
                    {
                        TipoServiciosDatos datos = new TipoServiciosDatos();

                        datos.EliminarTipoServicioAdicional(adicional.Id);

                        foreach (var item in ListTipoServicios)
                        {


                            TipoServicioAdicional tsA = new TipoServicioAdicional();

                            tsA.AdicionalId = adicional.Id;
                            tsA.TipoServicioId = item.Id;

                            datos.NuevoTipoServicioAdicional(tsA);


                        }

                    }



                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }



        public List<ObtenerAdicionales> ObtenerAdicionalesPorProveedor(int proveedorId)
        {
            return Datos.ObtenerAdicionalesPorProveedor(proveedorId);
        }

        public List<Adicionales> ObtenerAdicionalesPorLocaciones(int LocacionId)
        {
            return Datos.ObtenerAdicionalesPorLocaciones(LocacionId);
        }

        public List<ObtenerAdicionales> ObtenerAdicionalesPorLocacionesUnidadNegocio(int LocacionId)
        {
            return Datos.ObtenerAdicionalesPorLocacionesUnidadNegocio(LocacionId);
        }


        public List<ReporteAdicionales> ObtenerAdicionalesEventos(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {
            return Datos.ObtenerAdicionalesEventos(nroEvento, nroPresupuesto, fechaDesde, fechaHasta);
        }

        public List<Entidades.ObtenerAdicionales> ObtenerAdicionalesPorProveedoryUnidadNegocio(int ProveedorId, int UnidadNegocioId)
        {
            return Datos.ObtenerAdicionalesPorProveedoryUnidadNegocio(ProveedorId, UnidadNegocioId);
        }



        public List<Entidades.ObtenerAdicionales> ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(int ProveedorId, int UnidadNegocioId, int TipoCateringId)
        {
            return Datos.ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(ProveedorId, UnidadNegocioId, TipoCateringId);
        }

        public void ActualizarAdicional(Adicionales item)
        {
            Datos.ActualizarAdicional(item);
        }

        internal void GrabarItemsAdicionales(int adicionalId, int itemsId)
        {
            Datos.NuevoAdicionalItem(adicionalId, itemsId);
        }

        internal bool EliminarItemsAdicionales(int Id, int adicionalId)
        {
            return Datos.EliminarItemsAdicionales(Id, adicionalId);
        }

        internal List<Entidades.ObtenerAdicionales> BuscarAdicionalesPorDescripcionProveedorSalon(string descripcion, int proveedorId, int locacionId, int unidadNegocioId)
        {
            return Datos.BuscarAdicionalesPorDescripcionProveedorSalon(descripcion, proveedorId, locacionId, unidadNegocioId);
        }
    }
}
