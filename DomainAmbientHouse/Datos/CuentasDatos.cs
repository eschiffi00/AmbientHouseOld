using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Globalization;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class CuentasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CuentasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Cuentas> ObtenerCuentas()
        {

            var query = from Tm in SqlContext.Cuentas
                        join M in SqlContext.Monedas on Tm.MonedaId equals M.Id
                        join E in SqlContext.Empresas on Tm.EmpresaId equals E.Id
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            MonedaId = Tm.MonedaId,
                            MonedaDescripcion = M.Descripcion,
                            Nombre = Tm.Nombre,
                            TipoCuenta = Tm.TipoCuenta,
                            EmpresaId = Tm.EmpresaId,
                            EmpresaDescripcion = E.RazonSocial

                        };



            List<Cuentas> Salida = new List<Cuentas>();
            foreach (var item in query)
            {

                Cuentas cat = new Cuentas();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.MonedaId = item.MonedaId;
                cat.MonedaDescripcion = item.MonedaDescripcion;
                cat.Nombre = item.Nombre;
                cat.TipoCuenta = item.TipoCuenta;
                cat.EmpresaId = item.EmpresaId;
                cat.EmpresaDescripcion = item.EmpresaDescripcion;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Nombre).ToList();

        }

        public void GrabarMoviemientoCuentas(PagosProveedores pago)
        {
            if (pago.CuentaId > 0)
            {

                try
                {
                    int Id = 0;
                    if (SqlContext.Cuentas_Log.Where(o => o.CuentaId == pago.CuentaId).ToList().Count > 0)
                    {
                        Id = SqlContext.Cuentas_Log.Where(o => o.CuentaId == pago.CuentaId).Max(o => o.Id);

                        Cuentas_Log log = SqlContext.Cuentas_Log.Where(o => o.CuentaId == pago.CuentaId && o.Id == Id).FirstOrDefault();

                        log.CuentaId = log.CuentaId;

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = log.SaldoActual;
                        log.SaldoActual = log.SaldoActual + double.Parse(pago.Importe.ToString());
                        log.TipoMovimiento = "DEBITO";
                        log.UsuarioId = pago.EmpleadoId;
                        log.PagoProveedorId = pago.Id;
                        log.PagoClienteId = null;

                        SqlContext.Cuentas_Log.Add(log);
                        SqlContext.SaveChanges();
                    }
                    else
                    {

                        Cuentas_Log log = new Cuentas_Log();

                        log.CuentaId = Int32.Parse(pago.CuentaId.ToString());

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = 0;
                        log.SaldoActual = 0 + double.Parse(pago.Importe.ToString());
                        log.TipoMovimiento = "DEBITO";
                        log.UsuarioId = pago.EmpleadoId;
                        log.PagoProveedorId = pago.Id;
                        log.PagoClienteId = null;

                        SqlContext.Cuentas_Log.Add(log);
                        SqlContext.SaveChanges();
                    }




                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Cuentas BuscarCuenta(int id)
        {
            return SqlContext.Cuentas.Single(o => o.Id == id);
        }

        internal void GrabarCuenta(Cuentas cuenta)
        {
            if (cuenta.Id > 0)
            {
                Cuentas edit = SqlContext.Cuentas.Single(o => o.Id == cuenta.Id);

                edit.Nombre = cuenta.Nombre;
                edit.Descripcion = cuenta.Descripcion;
                edit.TipoCuenta = cuenta.TipoCuenta;
                edit.MonedaId = cuenta.MonedaId;
                edit.EmpresaId = cuenta.EmpresaId;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.Cuentas.Add(cuenta);
                SqlContext.SaveChanges();
            }
        }

        internal List<MovimientosCuentas> ListarMovimientos(MovimientosCuentasSearcher searcher)
        {

            var query = from cl in SqlContext.Cuentas_Log
                        where cl.CuentaId == searcher.CuentaId
                        select new MovimientosCuentas
                        {
                            FechaMovimiento = cl.FechaMovimiento,
                            Importe = (cl.SaldoAnterior - cl.SaldoActual) * -1,
                            SaldoAnterior = cl.SaldoAnterior,
                            SaldoActual = cl.SaldoActual,
                            TipoMovimientoCuenta = cl.TipoMovimiento,
                            NroMovimiento = cl.Id,
                            Descripcion = cl.Descripcion

                        };

            if (!string.IsNullOrEmpty(searcher.FechaDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaMovimiento >= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaMovimiento <= fecha);
            }


            return query.OrderBy(o => o.FechaMovimiento).ToList();
        }

        public bool EliminarMovimiento(int id)
        {
            if (id > 0)
            {
                List<Cuentas_Log> edit = SqlContext.Cuentas_Log.Where(o => o.PagoClienteId == id).ToList();

                PagosClientes pago = SqlContext.PagosClientes.Where(o => o.Id == id).Single();

                if (edit.Count() > 0)
                {
                    Cuentas_Log ultimoMov = this.BuscarUltimoMovimientoPorCuenta(pago.CuentaId);

                    Cuentas_Log log = new Cuentas_Log();

                    log.CuentaId = pago.CuentaId;
                    log.Descripcion = "Rectificar pago eliminado.";
                    log.FechaMovimiento = System.DateTime.Now;
                    log.SaldoAnterior = ultimoMov.SaldoActual;
                    log.SaldoActual = ultimoMov.SaldoActual - pago.Importe;
                    log.TipoMovimientoId = pago.TipoMovimientoId;
                    log.TipoMovimiento = "DEBITO";
                    log.UsuarioId = pago.EmpleadoId;

                    SqlContext.Cuentas_Log.Add(log);
                    SqlContext.SaveChanges();

                    //foreach (var item in edit)
                    //{

                    //    SqlContext.Cuentas_Log.Remove(item);

                    //    SqlContext.SaveChanges();
                    //}

                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

        public bool EliminarCuentasLog(int id)
        {
            try
            {


                if (id > 0)
                {
                    try
                    {
                        Cuentas_Log exist = SqlContext.Cuentas_Log.Single(o => o.Id == id);

                        SqlContext.Cuentas_Log.Remove(exist);

                        SqlContext.SaveChanges();

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }

                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal bool EditarMovimiento(Cuentas_Log movimiento)
        {

            try
            {
                if (movimiento.Id > 0)
                {
                    Cuentas_Log edit = SqlContext.Cuentas_Log.Single(o => o.Id == movimiento.Id);

                    edit.Descripcion = movimiento.Descripcion;

                    SqlContext.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }


        }

        internal bool GrabarMovimiento(Cuentas_Log movimiento)
        {
            try
            {
                if (movimiento.Id > 0)
                {
                    Cuentas_Log edit = SqlContext.Cuentas_Log.Single(o => o.Id == movimiento.Id);

                    edit.PagoClienteId = movimiento.PagoClienteId;
                    edit.PagoProveedorId = movimiento.PagoProveedorId;
                    edit.SaldoActual = movimiento.SaldoActual;
                    edit.SaldoAnterior = 0;
                    edit.TipoMovimientoId = movimiento.TipoMovimientoId;
                    edit.UsuarioId = movimiento.UsuarioId;
                    edit.FechaMovimiento = movimiento.FechaMovimiento;
                    edit.CuentaId = movimiento.CuentaId;
                    edit.Descripcion = movimiento.Descripcion;
                    edit.TipoCambio = edit.TipoCambio;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    SqlContext.Cuentas_Log.Add(movimiento);
                    SqlContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        internal bool RectificarMovimiento(Cuentas_Log movimiento, int? presupuestoId, int? centrocostoId)
        {
            try
            {
                if (movimiento.Id > 0)
                {
                    Cuentas_Log edit = SqlContext.Cuentas_Log.Single(o => o.Id == movimiento.Id);

                    edit.PagoClienteId = movimiento.PagoClienteId;
                    edit.PagoProveedorId = movimiento.PagoProveedorId;
                    edit.SaldoActual = movimiento.SaldoActual;
                    edit.SaldoAnterior = movimiento.SaldoAnterior;
                    edit.TipoMovimientoId = movimiento.TipoMovimientoId;
                    edit.UsuarioId = movimiento.UsuarioId;
                    edit.FechaMovimiento = movimiento.FechaMovimiento;
                    //edit.CuentaId = movimiento.CuentaId;
                    edit.Descripcion = movimiento.Descripcion;
                    edit.TipoMovimiento = movimiento.TipoMovimiento;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    if (presupuestoId > 0 && centrocostoId > 0)
                        GenerarDetalleComprobante((int)presupuestoId, movimiento, (int)centrocostoId);

                    SqlContext.Cuentas_Log.Add(movimiento);
                    SqlContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void GenerarDetalleComprobante(int presupuestoId, Cuentas_Log movimiento, int centroCostoId)
        {
            int EmpresaOtra = Int32.Parse(ConfigurationManager.AppSettings["EmpresaOtra"].ToString());
            int EstadoPagado = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagado"].ToString());
            int Efectivo = Int32.Parse(ConfigurationManager.AppSettings["FormadePagoCONTADO"].ToString());
            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());
            int ProveedorOTRO = Int32.Parse(ConfigurationManager.AppSettings["ProveedorOTRO"].ToString());

            ComprobantesProveedores comprobante = new ComprobantesProveedores();

            comprobante.EmpresaId = EmpresaOtra;
            comprobante.CuentaId = movimiento.CuentaId;
            comprobante.EstadoId = EstadoPagado;
            comprobante.Fecha = System.DateTime.Today;
            comprobante.FormadePagoId = Efectivo;
            comprobante.CreateFecha = System.DateTime.Now;

            double Importe = movimiento.SaldoActual - movimiento.SaldoAnterior;

            comprobante.MontoFactura = double.Parse("-1") * Importe;
            comprobante.NroComprobante = Int64.Parse(DateTime.Now.ToString("yyyyMMddmmss"));
            comprobante.ProveedorId = ProveedorOTRO;
            comprobante.TipoComprobanteId = ComprobanteInterno;

            comprobante.IIBBARBA = 0;
            comprobante.IIBBCABA = 0;
            comprobante.PercepcionIVA = 0;

            ComprobanteProveedoresDatos cabecera = new ComprobanteProveedoresDatos();

            cabecera.GrabarComprobante(comprobante);

            ComprobantesProveedores_Detalles comprobanteDetalle = new ComprobantesProveedores_Detalles();

            comprobanteDetalle.Cantidad = 1;
            comprobanteDetalle.CentroCostoId = centroCostoId;
            comprobanteDetalle.TipoMoviemientoId = (int)movimiento.TipoMovimientoId;
            comprobanteDetalle.ComprobanteProveedorId = comprobante.Id;
            comprobanteDetalle.Descripcion = movimiento.Descripcion;
            comprobanteDetalle.PresupuestoId = presupuestoId;
            comprobanteDetalle.Importe = double.Parse("-1") * Importe;

            cabecera.NuevoComprobanteProveedoresDetalle(comprobanteDetalle);


        }

        internal bool EditarComentario(Cuentas_Log movimiento)
        {
            try
            {
                if (movimiento.Id > 0)
                {
                    Cuentas_Log edit = SqlContext.Cuentas_Log.Single(o => o.Id == movimiento.Id);

                    edit.PagoClienteId = movimiento.PagoClienteId;
                    edit.PagoProveedorId = movimiento.PagoProveedorId;
                    edit.SaldoActual = movimiento.SaldoActual;
                    edit.SaldoAnterior = movimiento.SaldoAnterior;
                    edit.TipoMovimientoId = movimiento.TipoMovimientoId;
                    edit.UsuarioId = movimiento.UsuarioId;
                    edit.FechaMovimiento = movimiento.FechaMovimiento;
                    //edit.CuentaId = movimiento.CuentaId;
                    edit.Descripcion = movimiento.Descripcion;

                    SqlContext.SaveChanges();

                    return true;

                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        internal Cuentas_Log BuscarUltimoMovimientoPorCuenta(int cuentaId)
        {
            List<Cuentas_Log> cuentas = SqlContext.Cuentas_Log.Where(o => o.CuentaId == cuentaId).ToList();

            if (cuentas.Count() > 0)
            {
                int Id = cuentas.Max(o => o.Id);

                return SqlContext.Cuentas_Log.Where(o => o.CuentaId == cuentaId && o.Id == Id).FirstOrDefault();
            }
            else
                return new Cuentas_Log();


        }

        internal Cuentas_Log BuscarMovimiento(int id)
        {
            return SqlContext.Cuentas_Log.Single(o => o.Id == id);
        }

        internal List<Cuentas> ListarCuentasProEmpresas(int empresaId)
        {
            return SqlContext.Cuentas.Where(o => o.EmpresaId == empresaId).OrderBy(o => o.Nombre).ToList();
        }

       internal List<Cuentas> ListarCuentasEfectivosMasEfectivo(int empresaId)
         {
            return SqlContext.Cuentas.Where(o => o.EmpresaId == empresaId || o.TipoCuenta == "EFECTIVO").OrderBy(o => o.Nombre).ToList();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class MovimientosCuentas
    {
        public double? Importe { get; set; }

        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }

        public int ProveedorId { get; set; }
        public string Descripcion { get; set; }
        public string NroComprobante { get; set; }
        public int CuentaId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int CentroCostoId { get; set; }
        public int TipoMovimientoId { get; set; }
        public int EmpleadoId { get; set; }
        public int EmpresaId { get; set; }
        public int DegustacionId { get; set; }
        public double SaldoAnterior { get; set; }
        public string SaldoAnteriorStr
        {
            get
            {
                return System.Math.Round((double)SaldoAnterior, 2).ToString("C");
            }

        }
        public double SaldoActual { get; set; }
        public string SaldoActualStr
        {
            get
            {
                return System.Math.Round((double)SaldoActual, 2).ToString("C");
            }

        }
        public string TipoMovimientoCuenta { get; set; }
        public int NroMovimiento { get; set; }

        public int PresupuestoId { get; set; }

        public int? PresupuestoGastoId { get; set; }

        public int? TipoImpuestoId { get; set; }
        public double? ValorImpuesto { get; set; }
        public double? IIBBCABA { get; set; }
        public double? IIBBARBA { get; set; }
        public double? PercepcionIVA { get; set; }
    }

    public partial class TransferenciasCuentas
    {
        public int CuentaOrigenId { get; set; }
        public int CuentaDestinoId { get; set; }
        public double Importe { get; set; }
        public string Concepto { get; set; }
        public int TipoMovimientoId { get; set; }
        public double TipoCambio { get; set; }

        public int UsuarioId { get; set; }
    }

    public partial class MovimientosCuentasSearcher
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int CuentaId { get; set; }
    }

    public partial class Cuentas_Log
    {
        public double Importe { get; set; }

    }
    public partial class Cuentas
    {
        public string MonedaDescripcion { get; set; }


        public string EmpresaDescripcion { get; set; }
    }
}
