using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class TipoComprobantesNegocios
    {

        TipoComprobantesDatos Datos;

        public TipoComprobantesNegocios()
        {
            Datos = new TipoComprobantesDatos();
        }

        public virtual List<TipoComprobantes> ObtenerTipoComprobantes()
        {

            return Datos.ObtenerTipoComprobantes();

        }

        public TipoComprobantes BuscarTipoComprobantes(int id)
        {
            return Datos.BuscarTipoComprobantes(id);
        }

        public void NuevoTipoComprobantes(TipoComprobantes tc, List<Impuestos> ListImpuestos)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Datos.NuevoTipoComprobantes(tc);

                    int tipoComprobanteId = tc.Id;


                    Datos.EliminarImpuestoTipoComprobante(tipoComprobanteId);

                    foreach (var item in ListImpuestos)
                    {
                        Datos.NuevoTipoComprobanteImpuesto(item, tc.Id);
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                    throw ex;
                }



            }
        }


        internal List<TipoComprobantes> BuscarTipoComprobantesPorTipoProveedor(int? condicionIvaId)
        {
            return Datos.BuscarTipoComprobantesPorTipoProveedor(condicionIvaId);
        }
    }
}
