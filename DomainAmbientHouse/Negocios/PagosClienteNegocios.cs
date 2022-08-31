using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;
using System.Configuration;

namespace DomainAmbientHouse.Negocios
{
    public class PagosClienteNegocios
    {

        PagosClienteDatos Datos;
        ChequesDatos DatosCheques;
        TransferenciasDatos DatosTransferencia;

        public PagosClienteNegocios()
        {
            Datos = new PagosClienteDatos();
        }

        public virtual List<PagosClientes> ObtenerPagosClientePorPresupuesto(int presupuestoId)
        {

            return Datos.ObtenerPagosClientePorPresupuesto(presupuestoId);

        }

        public PagosClientes BuscarPagoCliente(int id)
        {
            return Datos.BuscarPagoCliente(id);
        }

        public bool GrabarPago(PagosClientes pagoCliente, Cheques cheque)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosCheques = new ChequesDatos();

                    if (DatosCheques.GrabarChequesClientes(cheque))
                        Datos.GrabarPagos(pagoCliente);
                    else
                        return false;

                    scope.Complete();

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }


        }

        public bool GrabarPago(PagosClientes pagoCliente, Transferencias transferencia)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    DatosTransferencia = new TransferenciasDatos();

                    if (DatosTransferencia.GrabarTransferencias(transferencia))
                        Datos.GrabarPagos(pagoCliente);
                    else
                        return false;


                    scope.Complete();

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }


        }

        public bool GrabarPago(PagosClientes pagoCliente)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    Datos.GrabarPagos(pagoCliente);

                    scope.Complete();

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool EliminarPago(int id)
        {
            return Datos.ElimnarPagosCliente(id);
        }

        internal List<PagosClientes> ObtenerPagosClientePorPresupuestoNeto(int PresupuestoId)
        {
            return Datos.ObtenerPagosClientePorPresupuestoNeto(PresupuestoId);
        }

        internal List<PagosClientes> ObtenerIndexacion(int presupuestoId, double indice, string tipoIndexacion)
        {
            return Datos.TotalPagado(presupuestoId, indice,  tipoIndexacion);
        }

        internal List<PagosClientes> ObtenerIndexacion(string fechaEvento,double totalPresupuesto, double indexacion, string tipoIndexacion, 
                                                    List<SimuladorIndexacion> SimuladorIndexacionSeleccionado)
        {
            return Datos.ObtenerIndexacion(fechaEvento, totalPresupuesto, indexacion, tipoIndexacion, SimuladorIndexacionSeleccionado);
        }

        public List<CobranzasVentas> ListarCobranzasVentas()
        {
            return Datos.ListarCobranzasVentas();
        }

        internal bool EditarPagosClientes(PagosClientes pago)
        {
            return Datos.EditarPagosClientes(pago);
        }
    }
}
