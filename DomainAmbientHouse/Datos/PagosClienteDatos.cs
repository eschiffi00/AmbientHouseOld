using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Globalization;

namespace DomainAmbientHouse.Datos
{
    public class PagosClienteDatos
    {

        public AmbientHouseEntities SqlContext { get; set; }

        public PagosClienteDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<PagosClientes> ObtenerPagosClientePorPresupuesto(int presupuestoId)
        {

            var query = from p in SqlContext.PagosClientes
                        where p.PresupuestoId == presupuestoId && p.Delete == false
                        select p;

            return PagoClienteToModel(query).OrderBy(o => o.FechaCreate).ToList();

        }

        public virtual List<PagosClientes> ObtenerPagosClientePorPresupuestoNeto(int presupuestoId)
        {
            int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());

            var query = from p in SqlContext.PagosClientes
                        where p.PresupuestoId == presupuestoId && p.Delete == false && (p.TipoMovimientoId == cuentaClientes
                                                                                        || p.TipoMovimientoId == cuentaRetencionesGanancias
                                                                                        || p.TipoMovimientoId == cuentaRetencionesIVA
                                                                                        || p.TipoMovimientoId == cuentaRetencionesIIBB
                                                                                        || p.TipoMovimientoId == cuentaRetencionesSUSS)
                        select p;

            return PagoClienteToModel(query).OrderBy(o => o.FechaCreate).ToList();

        }

        private List<PagosClientes> PagoClienteToModel(IQueryable<PagosClientes> query)
        {
            int movimientoIM = Int32.Parse(ConfigurationManager.AppSettings["CuentaImpuestoMusicales"].ToString());

            List<PagosClientes> list = new List<PagosClientes>();

            foreach (var item in query)
            {
                PagosClientes salida = new PagosClientes();

                salida.Id = item.Id;
                salida.FechaPago = item.FechaPago;
                salida.Importe = item.Importe;
                salida.TipoMovimientoId = item.TipoMovimientoId;
                salida.TipoMovimientoDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMovimientoId).SingleOrDefault().Descripcion;
                salida.FormadePagoId = item.FormadePagoId;
                salida.FormaPagoDescripcion = SqlContext.FormasdePago.Where(o => o.Id == item.FormadePagoId).SingleOrDefault().Descripcion;
                salida.EmpleadoId = item.EmpleadoId;
                salida.EmpleadoDescripcion = SqlContext.Empleados.Where(o => o.Id == item.EmpleadoId).SingleOrDefault().ApellidoNombre;
                salida.Indexacion = item.Indexacion;
                salida.IvaPorcentaje = item.IvaPorcentaje;
                salida.Concepto = item.Concepto;
                salida.EmpresaId = item.EmpresaId;
                salida.EmpresaRazonSocial = SqlContext.Empresas.Where(o => o.Id == item.EmpresaId).SingleOrDefault().RazonSocial;
                salida.EmpresaCondicionIva = SqlContext.Empresas.Where(o => o.Id == item.EmpresaId).SingleOrDefault().CondicionIva;
                salida.NroRecibo = item.NroRecibo;
                salida.TipoPago = item.TipoPago;
                salida.EstadoId = item.EstadoId;


                switch (salida.EmpresaCondicionIva)
                {
                    case "RESPINSCRIPTO":
                        if (salida.TipoMovimientoId == movimientoIM)
                            salida.ImporteNeto = (item.Importe);
                        else
                            salida.ImporteNeto = (item.Importe / double.Parse("1,21"));
                        break;
                    case "MONOTRIBUTO":
                        salida.ImporteNeto = item.Importe;
                        break;
                    case "OTRO":
                        salida.ImporteNeto = item.Importe;
                        break;
                    default:
                        break;
                }

                list.Add(salida);
            }

            return list;
        }

        public bool GrabarPagos(PagosClientes pagoCliente)
        {
            try
            {

                if (pagoCliente.Id > 0)
                {
                    PagosClientes edit = SqlContext.PagosClientes.Where(o => o.Id == pagoCliente.Id).SingleOrDefault();

                    double importeAnterior = edit.Importe;
                    double importeNuevo = pagoCliente.Importe;

                    edit.Importe = pagoCliente.Importe;
                    edit.FechaPago = pagoCliente.FechaPago;
                    edit.EmpleadoId = pagoCliente.EmpleadoId;
                    edit.FechaUpdate = System.DateTime.Now;
                    edit.TipoMovimientoId = pagoCliente.TipoMovimientoId;
                    edit.FormadePagoId = pagoCliente.FormadePagoId;
                    edit.Indexacion = pagoCliente.Indexacion;
                    edit.IvaPorcentaje = pagoCliente.IvaPorcentaje;
                    edit.CuentaId = pagoCliente.CuentaId;
                    edit.Concepto = pagoCliente.Concepto;
                    edit.EmpresaId = pagoCliente.EmpresaId;
                    edit.NroRecibo = pagoCliente.NroRecibo;
                    edit.TipoPago = pagoCliente.TipoPago;
                    edit.EstadoId = pagoCliente.EstadoId;

                    SqlContext.SaveChanges();

                    double importeMovimiento = importeNuevo - importeAnterior;

                    if (importeMovimiento > 0 || importeMovimiento < 0)
                        GrabarMoviemientoCuentas(edit, importeMovimiento);

                    return true;
                }
                else
                {
                    pagoCliente.FechaCreate = System.DateTime.Now;

                    SqlContext.PagosClientes.Add(pagoCliente);
                    SqlContext.SaveChanges();

                    GrabarMoviemientoCuentas(pagoCliente);

                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        private void GrabarMoviemientoCuentas(PagosClientes pago, double importeMovimiento)
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
                        log.SaldoActual = log.SaldoActual + double.Parse(importeMovimiento.ToString());
                        log.TipoMovimiento = "CREDITO";
                        log.UsuarioId = pago.EmpleadoId;
                        log.PagoClienteId = pago.Id;
                        log.PagoProveedorId = null;
                        log.Descripcion = pago.Concepto;

                        SqlContext.Cuentas_Log.Add(log);
                        SqlContext.SaveChanges();
                    }
                    else
                    {
                        Cuentas_Log log = new Cuentas_Log();

                        log.CuentaId = Int32.Parse(pago.CuentaId.ToString());

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = 0;
                        log.SaldoActual = 0 + double.Parse(importeMovimiento.ToString());
                        log.TipoMovimiento = "CREDITO";
                        log.UsuarioId = pago.EmpleadoId;
                        log.PagoClienteId = pago.Id;
                        log.PagoProveedorId = null;
                        log.Descripcion = pago.Concepto;

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

        private double? CalcularSaldoIndexable(int presupuestoId)
        {
            PresupuestosDatos datosPresupuestos = new PresupuestosDatos();

            double total = datosPresupuestos.CalcularValorTotalPresupuestoPorPresupuestoId(presupuestoId);

            PagosClienteDatos datosPagosClientes = new PagosClienteDatos();

            double totalPagado = 0; // this.TotalPagado(presupuestoId);


            return total - totalPagado;

        }

        public void GrabarMoviemientoCuentas(PagosClientes pago)
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
                        log.TipoMovimiento = "CREDITO";
                        log.UsuarioId = pago.EmpleadoId;
                        log.PagoClienteId = pago.Id;
                        log.PagoProveedorId = null;
                        log.Descripcion = pago.Concepto;

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
                        log.TipoMovimiento = "CREDITO";
                        log.UsuarioId = pago.EmpleadoId;
                        log.PagoClienteId = pago.Id;
                        log.PagoProveedorId = null;
                        log.Descripcion = pago.Concepto;

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

        public PagosClientes BuscarPagoCliente(int id)
        {
            return SqlContext.PagosClientes.Where(o => o.Id == id).SingleOrDefault();

        }

        public bool ElimnarPagosCliente(int id)
        {
            if (id > 0)
            {
                PagosClientes edit = BuscarPagoCliente(id);

                if (edit != null)
                {

                    edit.Delete = true;
                    edit.FechaDelete = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    CuentasDatos datosCuenta = new CuentasDatos();

                    datosCuenta.EliminarMovimiento(id);

                    return true;

                }
                else
                    return false;

            }
            else
                return false;
        }

        public List<PagosClientes> TotalPagado(int presupuestoId, double indice, string tipoIndexacion)
        {
            int tipoMovimientoCLIENTE = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString()); ;
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());

            double iva21 = Double.Parse(ConfigurationManager.AppSettings["IVA21"].ToString());

            string empresaOtra = "OTRO";
            string empresaMonotributo = "MONOTRIBUTO";

            PresupuestosDatos presu = new PresupuestosDatos();

            double totalPresupuesto = presu.CalcularValorTotalPresupuestoPorPresupuestoId(presupuestoId);

            DateTime fechaEvento = DateTime.Parse(SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).FirstOrDefault().FechaEvento.ToString());

            List<PagosClientes> ListPagosRealizados = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                                        && o.Delete == false).OrderBy(o => o.FechaPago).ToList();

            double totalPagosPorPresupuesto = 0;
            double saldoPresupuesto = 0;

            DateTime? fechaReserva = null;

            List<PagosClientes> Salida = new List<PagosClientes>();

            double? saldoPresupuestoReserva = 0;

            foreach (var item in ListPagosRealizados)
            {
                if (item.TipoMovimientoId == tipoMovimientoCLIENTE
                    || item.TipoMovimientoId == cuentaRetencionesGanancias
                    || item.TipoMovimientoId == cuentaRetencionesIVA
                    || item.TipoMovimientoId == cuentaRetencionesIIBB


                    || item.TipoMovimientoId == cuentaRetencionesSUSS)
                {

                    Empresas empresa = SqlContext.Empresas.Where(o => o.Id == item.EmpresaId).SingleOrDefault();

                    //EMPRESA ES OTRO Y TIPO MOVIMIENTO ES PAGO DE CLIENTE EVENTO NO LLEVA IVA
                    if (empresa.CondicionIva == empresaOtra && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else if (empresa.CondicionIva == empresaMonotributo && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + (item.Importe / iva21);


                    if (item.TipoPago == "Reserva" || fechaReserva != null)
                    {
                        fechaReserva = item.FechaPago;
                        saldoPresupuesto = totalPresupuesto - totalPagosPorPresupuesto;
                        saldoPresupuestoReserva = saldoPresupuesto;

                        PagosClientes pago = new PagosClientes();


                        pago.Id = item.Id;
                        pago.PresupuestoId = item.PresupuestoId;
                        pago.FechaPago = item.FechaPago;
                        pago.Concepto = item.Concepto;

                        pago.Importe = item.Importe;
                        pago.NroRecibo = item.NroRecibo;

                        DateTime fReserva = (from s in SqlContext.PagosClientes
                                             where s.PresupuestoId == presupuestoId && s.Delete == false && s.TipoPago == "Reserva"
                                             select s).FirstOrDefault().FechaPago;

                        //pago.FechaReserva = pago.FechaReservaString(fReserva);
                        //pago.CantDias = pago.DiasIndexacion(fechaEvento, fReserva);

                        if (tipoIndexacion == "pp")
                        {

                            if (Salida.Count > 0)
                            {
                                pago.SaldoIndexadoAlaFecha = CalcularIndexacion(fechaEvento, fReserva, (double)saldoPresupuestoReserva, indice); // -totalPagosPorPresupuesto;
                                pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEvento, fReserva, (double)saldoPresupuestoReserva, indice); // -totalPagosPorPresupuesto;
                                pago.SaldoIndexadoAlDia = CalcularIndexacion(fechaEvento, fReserva, (double)saldoPresupuestoReserva, indice); // -totalPagosPorPresupuesto;
                            }
                            else
                            {
                                saldoPresupuestoReserva = (double)saldoPresupuesto;
                                pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEvento, fReserva, (double)saldoPresupuesto, indice);
                            }
                        }
                        else
                        {
                            if (Salida.Count > 0)
                            {
                                PagosClientes ultimaFecha = (from s in Salida select s).OrderByDescending(o => o.FechaPago).OrderByDescending(o => o.Id).First();

                                pago.SaldoIndexadoAlaFecha = CalcularIndexacion(item.FechaPago, ultimaFecha.FechaPago, (double)ultimaFecha.SaldoIndexadoAlaFecha, indice) - item.Importe;
                                pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEvento, item.FechaPago, (double)pago.SaldoIndexadoAlaFecha, indice);
                                pago.SaldoIndexadoAlDia = CalcularIndexacion(System.DateTime.Today, ultimaFecha.FechaPago, (double)pago.SaldoIndexadoAlaFecha, indice);

                            }
                            else
                            {
                                pago.SaldoIndexadoAlaFecha = saldoPresupuesto;
                                pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEvento, item.FechaPago, (double)pago.SaldoIndexadoAlaFecha, indice);
                            }
                        }


                        Salida.Add(pago);

                    }
                    else
                    {
                        saldoPresupuesto = totalPresupuesto - totalPagosPorPresupuesto;

                        PagosClientes pago = new PagosClientes();

                        pago.Id = item.Id;
                        pago.PresupuestoId = item.PresupuestoId;
                        pago.FechaPago = item.FechaPago;
                        pago.Concepto = item.Concepto;

                        pago.Importe = item.Importe;
                        pago.NroRecibo = item.NroRecibo;

                        pago.SaldoIndexadoAlaFecha = saldoPresupuesto;

                        Salida.Add(pago);

                    }

                }
            }

            return Salida.ToList();
        }

        public List<PagosClientes> TotalPagadoBis(int presupuestoId, double indice, string tipoIndexacion)
        {

            PresupuestosDatos presu = new PresupuestosDatos();

            double totalPresupuesto = presu.CalcularValorTotalPresupuestoPorPresupuestoId(presupuestoId);

            DateTime fechaEvento = DateTime.Parse(SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).FirstOrDefault().FechaEvento.ToString());


            double totalPagadoPresupuesto = this.TotalPagadoPorPresupuesto(presupuestoId);

            double totalPagadoALaReserva = this.TotalPagadoAlaReservaPorPresupuesto(presupuestoId);


            return new List<PagosClientes>();

        }

        public double TotalPagadoPorPresupuesto(int presupuestoId)
        {
            int tipoMovimientoCLIENTE = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString()); ;
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());

            double iva21 = Double.Parse(ConfigurationManager.AppSettings["IVA21"].ToString());

            string empresaOtra = "OTRO";
            string empresaMonotributo = "MONOTRIBUTO";

            List<PagosClientes> ListPagosRealizados = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                                      && o.Delete == false).OrderBy(o => o.FechaPago).ToList();

            double totalPagosPorPresupuesto = 0;

            foreach (var item in ListPagosRealizados)
            {



                if (item.TipoMovimientoId == tipoMovimientoCLIENTE
                       || item.TipoMovimientoId == cuentaRetencionesGanancias
                       || item.TipoMovimientoId == cuentaRetencionesIVA
                       || item.TipoMovimientoId == cuentaRetencionesIIBB
                       || item.TipoMovimientoId == cuentaRetencionesSUSS)
                {

                    Empresas empresa = SqlContext.Empresas.Where(o => o.Id == item.EmpresaId).SingleOrDefault();

                    //EMPRESA ES OTRO Y TIPO MOVIMIENTO ES PAGO DE CLIENTE EVENTO NO LLEVA IVA
                    if (empresa.CondicionIva == empresaOtra && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else if (empresa.CondicionIva == empresaMonotributo && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + (item.Importe / iva21);
                }

            }

            return totalPagosPorPresupuesto;
        }

        public double TotalPagadoAlaReservaPorPresupuesto(int presupuestoId)
        {
            int tipoMovimientoCLIENTE = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString()); ;
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());

            double iva21 = Double.Parse(ConfigurationManager.AppSettings["IVA21"].ToString());

            string empresaOtra = "OTRO";
            string empresaMonotributo = "MONOTRIBUTO";


            
            //OBTENGO TODOS LOS PAGOS QUE SON RESERVA
            List<PagosClientes> ListPagosRealizadosALaReserva = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                                        && o.TipoPago == "Reserva"
                                                                                        && o.Delete == false).OrderBy(o => o.FechaPago).ToList();
            //OBTENGO LA FECHA LA ULTIMA FECHA DE RESERVA
            PagosClientes result = ListPagosRealizadosALaReserva.OrderByDescending(t => t.FechaPago).First();

            //OBTENENGO TODOS LOS PAGOS HASTA LA ULTIMA FECHA DE RESERVA
            List<PagosClientes> ListPagosRealizados = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                                       && o.FechaPago <= result.FechaPago
                                                                                       && o.Delete == false).OrderBy(o => o.FechaPago).ToList();



            double totalPagosPorPresupuesto = 0;

            foreach (var item in ListPagosRealizados)
            {




                if (item.TipoMovimientoId == tipoMovimientoCLIENTE
                       || item.TipoMovimientoId == cuentaRetencionesGanancias
                       || item.TipoMovimientoId == cuentaRetencionesIVA
                       || item.TipoMovimientoId == cuentaRetencionesIIBB
                       || item.TipoMovimientoId == cuentaRetencionesSUSS)
                {

                    Empresas empresa = SqlContext.Empresas.Where(o => o.Id == item.EmpresaId).SingleOrDefault();

                    //EMPRESA ES OTRO Y TIPO MOVIMIENTO ES PAGO DE CLIENTE EVENTO NO LLEVA IVA
                    if (empresa.CondicionIva == empresaOtra && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else if (empresa.CondicionIva == empresaMonotributo && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + (item.Importe / iva21);
                }

            }

            return totalPagosPorPresupuesto;
        }

        private double? CalcularIndexacion(DateTime fechaPago, DateTime ultimaFecha, double saldoPresupuesto, double indice)
        {
            TimeSpan ts = fechaPago - ultimaFecha;
            int diferenciaEnDias = ts.Days;


            double valornoElevado = (1 + (float)indice / 100);
            double potencia = ((float)diferenciaEnDias / 30);
            double elevado = Math.Pow((float)valornoElevado, (float)potencia);
            double valotIndexado = (saldoPresupuesto * elevado);

            return valotIndexado;
        }

        public List<PagosClientes> ObtenerIndexacion(string fechaEvento, double totalPresupuesto, double indice, string tipoIndexacion, List<SimuladorIndexacion> SimuladorIndexacionSeleccionado)
        {

            string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

            double totalPagosPorPresupuesto = 0;
            double saldoPresupuesto = 0;
            double saldoPresupuestoReserva = 0;



            int Count = 0;
            DateTime fechaReserva = System.DateTime.Today;
            DateTime fechaEventoInterna = DateTime.Parse(fechaEvento);

            List<PagosClientes> Salida = new List<PagosClientes>();


            foreach (var item in SimuladorIndexacionSeleccionado)
            {

                totalPagosPorPresupuesto = totalPagosPorPresupuesto + double.Parse(item.Importe);


                if (Count == 0)
                {
                    saldoPresupuestoReserva = totalPresupuesto - totalPagosPorPresupuesto;
                    fechaReserva = DateTime.Parse(item.FechaPago);
                }


                saldoPresupuesto = totalPresupuesto - totalPagosPorPresupuesto;

                PagosClientes pago = new PagosClientes();

                pago.Importe = double.Parse(item.Importe);
                pago.FechaPago = DateTime.Parse(item.FechaPago);


                if (tipoIndexacion == "pp")
                {

                    if (Salida.Count > 0)
                    {
                        pago.SaldoIndexadoAlaFecha = CalcularIndexacion(fechaEventoInterna, fechaReserva, (double)saldoPresupuestoReserva, indice) - totalPagosPorPresupuesto;
                        pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEventoInterna, fechaReserva, (double)saldoPresupuestoReserva, indice) - totalPagosPorPresupuesto;
                        pago.SaldoIndexadoAlDia = CalcularIndexacion(fechaEventoInterna, fechaReserva, (double)saldoPresupuestoReserva, indice) - totalPagosPorPresupuesto;
                    }
                    else
                    {
                        //saldoPresupuestoReserva = (double)saldoPresupuesto;
                        pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEventoInterna, fechaReserva, (double)saldoPresupuesto, indice);
                    }
                }
                else
                {
                    if (Salida.Count > 0)
                    {
                        PagosClientes ultimaFecha = (from s in Salida select s).OrderByDescending(o => o.FechaPago).OrderByDescending(o => o.Id).First();

                        //pago.SaldoIndexadoAlaFecha = CalcularIndexacion(item.FechaPago, ultimaFecha.FechaPago, (double)ultimaFecha.SaldoIndexadoAlaFecha, indice) - item.Importe;
                        //pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEvento, item.FechaPago, (double)pago.SaldoIndexadoAlaFecha, indice);
                        //pago.SaldoIndexadoAlDia = CalcularIndexacion(System.DateTime.Today, ultimaFecha.FechaPago, (double)pago.SaldoIndexadoAlaFecha, indice);
                    }
                    //else
                    //{
                    //    pago.SaldoIndexadoAlaFecha = saldoPresupuesto;
                    //    pago.SaldoIndexadoAlDiaEvento = CalcularIndexacion(fechaEvento, item.FechaPago, (double)pago.SaldoIndexadoAlaFecha, indice);
                    //}
                }


                Salida.Add(pago);
                Count = Count + 1;

            }

            return Salida.ToList();
        }

        public List<CobranzasVentas> ListarCobranzasVentas()
        {

            List<CobranzasVentas> list = SqlContext.CobranzasVentas.OrderBy(o => o.PresupuestoId).ToList();


            foreach (var item in list)
            {
                List<PagosClientes> suma = this.TotalPagado(item.PresupuestoId, (item.Indexacion == null) ?
                                                                                    1 :
                                                                                    double.Parse(item.Indexacion.ToString())
                                                                               , item.TipoIndexacion);


                if (suma.FirstOrDefault().SaldoIndexadoAlDiaEvento != null)
                    item.TotalIndexado = double.Parse(suma.FirstOrDefault().SaldoIndexadoAlDiaEvento.ToString());
                else if (suma.FirstOrDefault().SaldoIndexadoAlaFecha != null)
                    item.TotalIndexado = double.Parse(suma.FirstOrDefault().SaldoIndexadoAlaFecha.ToString());

            }


            return list;
        }

        internal bool EditarPagosClientes(PagosClientes pago)
        {
            if (pago.Id > 0)
            {
                try
                {
                    PagosClientes edit = SqlContext.PagosClientes.Single(o => o.Id == pago.Id);

                    edit.TipoMovimientoId = pago.TipoMovimientoId;

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

    }

}

namespace DomainAmbientHouse.Entidades
{
    public partial class PagosClientes
    {
        public string FormaPagoDescripcion { get; set; }

        public string TipoMovimientoDescripcion { get; set; }

        public string EmpleadoDescripcion { get; set; }

        public string EmpresaRazonSocial { get; set; }

        public double ImporteNeto { get; set; }

        public string EmpresaCondicionIva { get; set; }

        public double? SaldoIndexadoAlaFecha { get; set; }

        public double? SaldoIndexadoAlDiaEvento { get; set; }

        public double? SaldoIndexadoAlDia { get; set; }

        public double? SaldoAlaReserva { get; set; }

    }

    public partial class SimuladorIndexacion
    {
        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaEvento { get; set; }

        public string FechaPago { get; set; }
        public string Importe { get; set; }

        public double Total { get; set; }
    }

    public partial class CobranzasVentas
    {
        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaEventoStr
        {
            get
            {
                return String.Format(formatoFecha, FechaEvento);
            }
            set
            {
                FechaEvento = DateTime.ParseExact(FechaEventoStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string FechaPagoStr
        {
            get
            {
                return String.Format(formatoFecha, FechaPago);
            }
            set
            {
                FechaPago = DateTime.ParseExact(FechaPagoStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }

        public string TotalStr
        {
            get
            {
                return System.Math.Round((double)TOTALPRESUPUESTOSININDEXACION, 2).ToString("C");
            }

        }

        public double TotalIndexado { get; set; }
    }
}
