using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class RecibosNegocios
    {

        RecibosDatos Datos;

        public RecibosNegocios()
        {
            Datos = new RecibosDatos();
        }

        public Recibos BuscarRecibo(int id)
        {
            return Datos.BuscarRecibo(id);
        }

        internal List<Recibos> ObtenerRecibos()
        {
            return Datos.ObtenerRecibos();
        }

        public List<Recibos> BuscarRecibos(RecibosSearcher searcher)
        {
            return Datos.BuscarRecibos(searcher);
        }

        //public bool GrabarRecibo(Recibos recibo,
        //    DomainAmbientHouse.Entidades reciboDetalle,
        //    DomainAmbientHouse.Entidades.Cheques cheque,
        //    DomainAmbientHouse.Entidades.Transferencias transferencia)
        //{
        //    int formaPagoCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
        //    int formaPagoTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());
        //    int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());

        //    ChequesDatos DatosCheques = new ChequesDatos();
        //    TransferenciasDatos DatosTransferencias = new TransferenciasDatos();
        //    PagosClienteDatos DatosPagoClientes = new PagosClienteDatos();


        //    PagosClientes pagos = new PagosClientes();

        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        try
        //        {

        //            if (recibo.FormadePagoId == formaPagoCheque)
        //            {
        //                //cheque.ClienteId = cliente.Id;

        //                DatosCheques.GrabarChequesClientes(cheque);
        //            }
        //            else if ((recibo.FormadePagoId == formaPagoTransferencia))
        //            {
        //                //transferencia.ClienteId = cliente.Id;

        //                DatosTransferencias.GrabarTransferencias(transferencia);
        //            }


        //            pagos.PresupuestoId = int.Parse(reciboDetalle.PresupuestoId.ToString());

        //            //pagos.Importe = double.Parse(recibo.Importe.ToString());

        //            pagos.FechaPago = DateTime.Parse(recibo.FechaRecibo.ToString());

        //            pagos.EmpleadoId = recibo.EmpleadoId;
        //            pagos.TipoMovimientoId = cuentaClientes;
        //            pagos.FormadePagoId = int.Parse(recibo.FormadePagoId.ToString());
        //            pagos.CuentaId = recibo.CuentaId;

        //            DatosPagoClientes.GrabarPagos(pagos);

        //            Datos.GrabarRecibos(recibo);

        //            scope.Complete();

        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            DomainAmbientHouse.Servicios.Log.save(this, ex);
        //            return false;
        //        }
        //    }

        //}


    }
}
