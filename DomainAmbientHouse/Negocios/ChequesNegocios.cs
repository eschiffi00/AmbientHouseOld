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
    public class ChequesNegocios
    {

        ChequesDatos Datos;

        public ChequesNegocios()
        {
            Datos = new ChequesDatos();
        }

        public virtual List<Cheques> ObtenerCheqhes()
        {

            return Datos.ObtenerCheqhes();

        }

        public void AcreditarCheques(List<Cheques> ListChequesSeleccionados, int empleadoId)
        {

            int estadoChequeAcreditado = Int32.Parse(ConfigurationManager.AppSettings["ChequesPagado"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                   

                    foreach (var item in ListChequesSeleccionados)
                    {
                        Cheques cheque = new Cheques();

                        cheque.Id = item.Id;
                        cheque.NroCheque = item.NroCheque;
                        cheque.Importe = item.Importe;
                        cheque.FechaVencimiento = item.FechaVencimiento;
                        cheque.FechaEmision = item.FechaEmision;
                        cheque.Observaciones = item.Observaciones;
                        cheque.TipoCheque = item.TipoCheque;
                        cheque.BancoId = item.BancoId;
                        cheque.EstadoId = estadoChequeAcreditado;
                        cheque.ProveedorId = item.ProveedorId;
                        cheque.ClienteId = item.ClienteId;

                        Datos.NuevosCheques(cheque);

                        CuentasDatos datosCuentas = new CuentasDatos();

                        if (item.CuentaId > 0)
                        {
                            Cuentas_Log ultimoMovimiento = datosCuentas.BuscarUltimoMovimientoPorCuenta((int)item.CuentaId);

                            Cuentas_Log movimientos = new Cuentas_Log();

                            movimientos.CuentaId = (int)item.CuentaId;
                            movimientos.Descripcion = "Cheque Debitado";
                            movimientos.FechaMovimiento = System.DateTime.Now;
                            movimientos.SaldoAnterior = ultimoMovimiento.SaldoActual;
                            movimientos.SaldoActual = ultimoMovimiento.SaldoActual - item.Importe;
                            movimientos.TipoMovimiento = "DEBITO";
                            movimientos.UsuarioId = empleadoId;

                            datosCuentas.GrabarMovimiento(movimientos);

                        }

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

        public Cheques BuscarCheque(int id)
        {
            return Datos.BuscarCheque(id);
        }

        internal List<Cheques> ListarCheques(ChequesSearcher searcher)
        {
            return Datos.ListarCheques(searcher);
        }

        internal void GuardarCheques(Cheques cheque)
        {
             Datos.NuevosCheques(cheque);
        }
    }
}
