using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class FacturasClientesNegocios
    {

        FacturasClientesDatos Datos;
        FacturasClientesDetalleDatos DatosDetalle;

        public FacturasClientesNegocios()
        {
            Datos = new FacturasClientesDatos();
            DatosDetalle = new FacturasClientesDetalleDatos();
        }

        public virtual List<FacturasCliente> ListarFacturasClientes(FacturasClienteSearcher searcher)
        {

            return Datos.ListarFacturasClientes(searcher);

        }

        public bool GrabarFactura(FacturasCliente factura)
        {

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Datos.GrabarFacturasCliente(factura);

                    foreach (var item in factura.FacturaClienteDetalle)
                    {
                        item.FacturaClienteId = factura.Id;
                        DatosDetalle.GrabarFacturasClienteDetalle(item);
                    }

                    scope.Complete();

                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public FacturasCliente BuscarFacturasCliente(int id)
        {
            return Datos.BuscarFacturaCliente(id);
        }

        public bool ExisteFacturaPorEmpresayNro(int empresaId, int nroFactura, int tipoComprobanteId)
        {
            return Datos.ExisteFacturaPorEmpresayNro(empresaId, nroFactura, tipoComprobanteId);
        }

        internal List<FacturasCliente> BuscarFacturasClientePorNroPresupuesto(int presupuestoId)
        {
            return Datos.BuscarFacturasClientePorNroPresupuesto(presupuestoId);
        }
    }
}
