using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class CuentassNegocios
    {

        CuentasDatos Datos;

        public CuentassNegocios()
        {
            Datos = new CuentasDatos();
        }

        public virtual List<Cuentas> ObtenerCuentas()
        {
            return Datos.ObtenerCuentas();
        }

        internal void GrabarEgresoMovimientoCaja(MovimientosCuentas movimiento)
        {
            int EmpresaOtra = Int32.Parse(ConfigurationManager.AppSettings["EmpresaOtra"].ToString());
            int EstadoPagado = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagado"].ToString());
            int Efectivo = Int32.Parse(ConfigurationManager.AppSettings["FormadePagoCONTADO"].ToString());
            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());

            ComprobanteProveedoresDatos datosComprobantes = new ComprobanteProveedoresDatos();
            PagoProveedoresDatos datosPagoProveedores = new PagoProveedoresDatos();

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    ComprobantesProveedores comprobante = new ComprobantesProveedores();

                    //comprobante.EmpresaId = EmpresaOtra;
                    comprobante.CuentaId = movimiento.CuentaId;
                    comprobante.EstadoId = EstadoPagado;
                    comprobante.Fecha = movimiento.FechaMovimiento;
                    comprobante.FormadePagoId = Efectivo;
                    comprobante.MontoFactura = movimiento.Importe;
                    comprobante.NroComprobante = long.Parse(movimiento.NroComprobante.ToString());
                    comprobante.ProveedorId = movimiento.ProveedorId;
                    comprobante.TipoComprobanteId = ComprobanteInterno;
                    comprobante.EmpresaId = movimiento.EmpresaId;
                    comprobante.IIBBARBA = movimiento.IIBBARBA;
                    comprobante.IIBBCABA = movimiento.IIBBCABA;
                    comprobante.PercepcionIVA = movimiento.PercepcionIVA;

                    datosComprobantes.GrabarComprobante(comprobante);

                    ComprobantesProveedores_Detalles comprobanteDetalle = new ComprobantesProveedores_Detalles();

                    comprobanteDetalle.Cantidad = 1;
                    comprobanteDetalle.CentroCostoId = movimiento.CentroCostoId;
                    comprobanteDetalle.TipoMoviemientoId = movimiento.TipoMovimientoId;
                    comprobanteDetalle.ComprobanteProveedorId = comprobante.Id;
                    comprobanteDetalle.Descripcion = movimiento.Descripcion;
                    comprobanteDetalle.PresupuestoId = movimiento.PresupuestoGastoId;
                    comprobanteDetalle.Importe = double.Parse(movimiento.Importe.ToString());
                    comprobanteDetalle.TipoImpuestoId = movimiento.TipoImpuestoId;
                    comprobanteDetalle.ValorImpuesto = movimiento.ValorImpuesto;
                    comprobanteDetalle.DegustacionId = movimiento.DegustacionId;


                    datosComprobantes.NuevoComprobanteProveedoresDetalle(comprobanteDetalle);

                    PagosProveedores pagoProveedor = new PagosProveedores();

                    pagoProveedor.FormadePagoId = Efectivo;
                    pagoProveedor.CuentaId = movimiento.CuentaId;
                    pagoProveedor.Fecha = movimiento.FechaMovimiento;
                    pagoProveedor.Importe = double.Parse(movimiento.Importe.ToString());
                    pagoProveedor.EmpleadoId = movimiento.EmpleadoId;

                    datosPagoProveedores.NuevoPagoProveedores(pagoProveedor, movimiento.Descripcion);


                    ComprobantePagoProveedor comprobantePagoProveedor = new ComprobantePagoProveedor();

                    comprobantePagoProveedor.ComprobanteProveedorId = comprobante.Id;
                    comprobantePagoProveedor.PagoProveedorId = pagoProveedor.Id;

                    datosComprobantes.NuevoComprobantePagoProveedor(comprobantePagoProveedor);

                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        internal Cuentas BuscarCuenta(int id)
        {
            return Datos.BuscarCuenta(id);
        }

        internal void GrabarCuenta(Cuentas cuenta)
        {
            Datos.GrabarCuenta(cuenta);
        }

        internal List<MovimientosCuentas> ListarMovimientos(MovimientosCuentasSearcher searcher)
        {
            return Datos.ListarMovimientos(searcher);
        }

        internal void GrabarIngresosMovimientoCaja(MovimientosCuentas movimiento)
        {
            int EmpresaOtra = Int32.Parse(ConfigurationManager.AppSettings["EmpresaOtra"].ToString());
            int EstadoPagado = Int32.Parse(ConfigurationManager.AppSettings["PagoClienteEfectuado"].ToString());
            int Efectivo = Int32.Parse(ConfigurationManager.AppSettings["FormadePagoCONTADO"].ToString());
            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());

            PagosClienteDatos datosPagosClientes = new PagosClienteDatos();

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    PagosClientes pagos = new PagosClientes();

                    pagos.EmpresaId = EmpresaOtra;
                    pagos.CuentaId = movimiento.CuentaId;
                    pagos.EstadoId = EstadoPagado;
                    pagos.FechaPago = movimiento.FechaMovimiento;
                    pagos.FormadePagoId = Efectivo;
                    pagos.Importe = double.Parse(movimiento.Importe.ToString());
                    pagos.NroRecibo = movimiento.NroComprobante;
                    pagos.Concepto = movimiento.Descripcion;
                    pagos.EmpleadoId = movimiento.EmpleadoId;
                    pagos.PresupuestoId = movimiento.PresupuestoId;
                    pagos.TipoMovimientoId = movimiento.TipoMovimientoId;

                    datosPagosClientes.GrabarPagos(pagos);

                    scope.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        internal bool GrabarTransferenciaCuenta(TransferenciasCuentas movimientos)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Cuentas_Log origen = new Cuentas_Log();

                    Cuentas_Log editOrigen = Datos.BuscarUltimoMovimientoPorCuenta(movimientos.CuentaOrigenId);

                    double tipoCambio = (movimientos.TipoCambio == null ? 1 : movimientos.TipoCambio);

                    origen.CuentaId = movimientos.CuentaOrigenId;
                    origen.TipoMovimiento = "DEBITO";
                    origen.SaldoAnterior = editOrigen.SaldoActual;
                    origen.SaldoActual = editOrigen.SaldoActual - movimientos.Importe;
                    origen.UsuarioId = movimientos.UsuarioId;
                    origen.FechaMovimiento = System.DateTime.Now;
                    origen.Descripcion = movimientos.Concepto;
                    origen.TipoMovimientoId = movimientos.TipoMovimientoId;
                    origen.TipoCambio = movimientos.TipoCambio;

                    Datos.GrabarMovimiento(origen);

                    Cuentas_Log destino = new Cuentas_Log();

                    Cuentas_Log editDestino = Datos.BuscarUltimoMovimientoPorCuenta(movimientos.CuentaDestinoId);

                    destino.CuentaId = movimientos.CuentaDestinoId;
                    destino.TipoMovimiento = "CREDITO";
                    destino.SaldoAnterior = editDestino.SaldoActual;
                    destino.SaldoActual = editDestino.SaldoActual + Conversion(origen.CuentaId, destino.CuentaId, movimientos.Importe, tipoCambio);
                    destino.UsuarioId = movimientos.UsuarioId;
                    destino.FechaMovimiento = System.DateTime.Now;
                    destino.Descripcion = movimientos.Concepto;
                    destino.TipoMovimientoId = movimientos.TipoMovimientoId;
                    destino.TipoCambio = movimientos.TipoCambio;

                    Datos.GrabarMovimiento(destino);

                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal double Conversion(int cuentaOrigen, int cuentaDestino, double importe, double tipoCambio)
        {

            Cuentas origen = this.BuscarCuenta(cuentaOrigen);
            Cuentas destino = this.BuscarCuenta(cuentaDestino);

            MonedasDatos monedas = new MonedasDatos();

            ConversionMonedas conversion = monedas.BuscarConversion(origen.MonedaId, destino.MonedaId);

            if (conversion != null)
            {
                if (conversion.Conversion == "M")
                    return importe * tipoCambio;
                else
                    return importe / tipoCambio;
            }
            else
                return importe;
        }

        internal Cuentas_Log BuscarMovimiento(int id)
        {
            return Datos.BuscarMovimiento(id);
        }

        internal bool GrabarMovimiento(Cuentas_Log cuentasLog)
        {
            return Datos.GrabarMovimiento(cuentasLog);
        }

        internal Cuentas_Log BuscarUltimoMovimientoPorCuenta(int CuentaId)
        {
            return Datos.BuscarUltimoMovimientoPorCuenta(CuentaId);
        }

        internal bool RectificarMovimiento(Cuentas_Log movimientos, int? presupuestoId, int? centroCostoId)
        {
            return Datos.RectificarMovimiento(movimientos, presupuestoId, centroCostoId);
        }

        internal List<Cuentas> ListarCuentasProEmpresas(int empresaId)
        {
            return Datos.ListarCuentasProEmpresas(empresaId);
        }

        internal List<Cuentas> ListarCuentasEfectivosMasEfectivo(int empresaId)
        {
            return Datos.ListarCuentasEfectivosMasEfectivo(empresaId);
        }

        internal bool EditarMovimiento(Cuentas_Log cuentasLog)
        {
            return Datos.EditarMovimiento(cuentasLog);
        }

        public bool EliminarCuentasLog(int id)
        {
            ComprobanteProveedoresDatos datosComprobantes = new ComprobanteProveedoresDatos();
            PagoProveedoresDatos datosPagosProveedores = new PagoProveedoresDatos();

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Cuentas_Log movimiento = Datos.BuscarMovimiento(id);

                    if (movimiento.PagoProveedorId != null)
                    {
                        ComprobantePagoProveedor pago = datosComprobantes.BuscarComprobantePagoProveedor((int)movimiento.PagoProveedorId);

                        if (pago != null)
                        {
                            ComprobantesProveedores comprobante = datosComprobantes.BuscarComprobantes(pago.ComprobanteProveedorId);

                            if (comprobante != null)
                            {
                                datosComprobantes.EliminarComprobanteProveedoresDetalle(comprobante.Id);

                                datosComprobantes.EliminarComprobantePago(comprobante.Id, pago.Id);

                                datosComprobantes.ElimnarComprobanteProveedor(comprobante.Id);

                                datosPagosProveedores.EliminarPagoProveedor(pago.Id);
                            }
                        }

                    }

                    Datos.EliminarCuentasLog(id);
                    scope.Complete();

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }

        }
    }
}
