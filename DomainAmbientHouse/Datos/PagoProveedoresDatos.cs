using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class PagoProveedoresDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }
         
        public PagoProveedoresDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<PagosProveedores> ObtenerPagoProveedores()
        {

            return SqlContext.PagosProveedores.ToList();

        }

        public PagosProveedores BuscarPagoProveedor(int id)
        {
            return SqlContext.PagosProveedores.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoPagoProveedores(PagosProveedores pagos, string descripcion)
        {
            if (pagos.Id > 0)
            {

                PagosProveedores catEdit = SqlContext.PagosProveedores.Where(o => o.Id == pagos.Id).First();

                catEdit.Fecha = pagos.Fecha;
                catEdit.Importe = pagos.Importe;
                catEdit.CuentaId = pagos.CuentaId;
                catEdit.FormadePagoId = pagos.FormadePagoId;
                catEdit.NroComprobanteTransferencia = pagos.NroComprobanteTransferencia;
                catEdit.FechaTransferencia = pagos.FechaTransferencia;



                SqlContext.SaveChanges();
            }
            else
            {
                pagos.NroOrdenPago = (this.SqlContext.PagosProveedores.Count<PagosProveedores>() + 1).ToString();

                SqlContext.PagosProveedores.Add(pagos);
                SqlContext.SaveChanges();


                try
                {
                    int Id = 0;
                    if (SqlContext.Cuentas_Log.Where(o => o.CuentaId == pagos.CuentaId).ToList().Count > 0)
                    {
                        Id = SqlContext.Cuentas_Log.Where(o => o.CuentaId == pagos.CuentaId).Max(o => o.Id);

                        Cuentas_Log log = SqlContext.Cuentas_Log.Where(o => o.CuentaId == pagos.CuentaId && o.Id == Id).FirstOrDefault();

                        log.CuentaId = log.CuentaId;

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = log.SaldoActual;
                        log.SaldoActual = log.SaldoActual - double.Parse(pagos.Importe.ToString());
                        log.TipoMovimiento = "DEBITO";
                        log.UsuarioId = pagos.EmpleadoId;
                        log.PagoProveedorId = pagos.Id;
                        log.PagoClienteId = null;
                        log.Descripcion = descripcion;

                        SqlContext.Cuentas_Log.Add(log);
                        SqlContext.SaveChanges();
                    }
                    else
                    {

                        Cuentas_Log log = new Cuentas_Log();

                        log.CuentaId = Int32.Parse(pagos.CuentaId.ToString());

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = 0;
                        log.SaldoActual = 0 - double.Parse(pagos.Importe.ToString());
                        log.TipoMovimiento = "DEBITO";
                        log.UsuarioId = pagos.EmpleadoId;
                        log.PagoProveedorId = pagos.Id;
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

        public List<PagosProveedores> BuscarPagoProveedoresPorComprabante(int comprobanteId)
        {
            var query = from c in SqlContext.ComprobantePagoProveedor
                        join pp in SqlContext.PagosProveedores on c.PagoProveedorId equals pp.Id
                        where c.ComprobanteProveedorId == comprobanteId
                        select pp;


            return query.OrderBy(o => o.Fecha).ToList();
        }

        public PagosProveedores BuscarPagoProveedorPorCheque(int chequeId)
        {
            var query = from C in SqlContext.Cheques
                        join Cp in SqlContext.ChequesPagosProveedores on C.Id equals Cp.ChequeId
                        join Pp in SqlContext.PagosProveedores on Cp.PagoProveedorId equals Pp.Id
                        join Cu in SqlContext.Cuentas on Pp.CuentaId equals Cu.Id
                        where C.Id == chequeId
                        select Pp;


            return query.FirstOrDefault();
        }

        internal void ActualizarPagoProveedor(PagosProveedores pago)
        {
            if (pago.Id > 0)
            {
                PagosProveedores edit = SqlContext.PagosProveedores.Single(o => o.Id == pago.Id);

                edit.CuentaId = pago.CuentaId;

                SqlContext.SaveChanges();

            }
        }

        internal List<PagosProveedores> ObtenerPagosPorComprobante(int comprobanteId)
        {
            var query = from P in SqlContext.PagosProveedores
                        join CP in SqlContext.ComprobantePagoProveedor on P.Id equals CP.PagoProveedorId
                        join Cu in SqlContext.Cuentas on P.CuentaId equals Cu.Id
                        join Fp in SqlContext.FormasdePago on P.FormadePagoId equals Fp.Id
                        join Chp in SqlContext.ChequesPagosProveedores on P.Id equals Chp.PagoProveedorId into Chps
                        from Chp in Chps.DefaultIfEmpty()
                        join Che in SqlContext.Cheques on Chp.ChequeId equals Che.Id into Ches
                        from Che in Ches.DefaultIfEmpty()
                        
                        where CP.ComprobanteProveedorId == comprobanteId
                        select new
                        {
                            Id = P.Id,
                            Fecha = P.Fecha,
                            Importe = P.Importe,
                            NroOrdenPago = P.NroOrdenPago,
                            CuentaId = P.CuentaId,
                            FormaPagoId = P.FormadePagoId,
                            CuentaNombre = Cu.Nombre,
                            FormaPagoDescripcion = Fp.Descripcion,
                            NroCheque = Che.NroCheque,
                            NroTransferencia = P.NroComprobanteTransferencia
                        };

            List<PagosProveedores> Salida = new List<PagosProveedores>();
            foreach (var item in query)
            {

                PagosProveedores cat = new PagosProveedores();

                cat.Id = item.Id;
                cat.Fecha = item.Fecha;
                cat.Importe = item.Importe;
                cat.NroOrdenPago = item.NroOrdenPago;
                cat.CuentaId = item.CuentaId;
                cat.FormadePagoId = item.FormaPagoId;
                cat.CuentaNombre = item.CuentaNombre;
                cat.FormaPagoDescripcion = item.FormaPagoDescripcion;
                cat.NroCheque = item.NroCheque;
                cat.NroComprobanteTransferencia = item.NroTransferencia;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Fecha).ToList();
        }

        internal void EliminarPagoProveedor(int id)
        {
            try
            {
                PagosProveedores pago = SqlContext.PagosProveedores.Single(o => o.Id == id);

                SqlContext.PagosProveedores.Remove(pago);
                SqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
         
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class PagosProveedores
    {
        public string CuentaNombre { get; set; }
        public string FormaPagoDescripcion { get; set; }
        public string NroCheque { get; set; }
        
    }

    public partial class OrdenPagoProveedores
    {
        public string NroComprobante { get; set; }
        public double Importe { get; set; }
        public double Saldo { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public int ProveedorId { get; set; }
        public int BancoId { get; set; }
        public string Observaciones { get; set; }
        public int FormadePagoId { get; set; }
        public string FormadePagoDescripcion { get; set; }
        public int TipoRetencion { get; set; }
        public string TipoCheque { get; set; }
        public string FechaPago { get; set; }
        public int CuentaId { get; set; }
        public int EmpleadoId { get; set; }

        public List<ComprobantesProveedores> ListaComprobantes { get; set; }

        public int Id { get; set; }
    }
}
