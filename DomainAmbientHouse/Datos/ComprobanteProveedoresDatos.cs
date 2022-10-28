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
    public class ComprobanteProveedoresDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public ComprobanteProveedoresDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ComprobantesProveedores> ObtenerComprobanteProveedores(SearcherComprobantes searcher)
        {
            var query = from u in SqlContext.ComprobantesProveedores
                        join p in SqlContext.Proveedores on u.ProveedorId equals p.Id into Ps
                        from p in Ps.DefaultIfEmpty()
                        join tc in SqlContext.TipoComprobantes on u.TipoComprobanteId equals tc.Id
                        join fp in SqlContext.FormasdePago on u.FormadePagoId equals fp.Id
                        join e in SqlContext.Estados on u.EstadoId equals e.Id
                        join Em in SqlContext.Empresas on u.EmpresaId equals Em.Id into Ems
                        from Em in Ems.DefaultIfEmpty()
                        where u.Delete == false
                        select new
                        {
                            Id = u.Id,
                            ProveedorId = (u.ProveedorId == null ? null : u.ProveedorId),
                            RazonSocial = p.RazonSocial,
                            Cuit = p.Cuit,
                            TipoComprobanteId = u.TipoComprobanteId,
                            TipoComprobanteDescripcion = tc.Descripcion,
                            MontoNeto = u.MontoNeto,
                            MontoFactura = u.MontoFactura,
                            Fecha = u.Fecha,
                            NroComprobante = u.NroComprobante,
                            FormaPagoId = u.FormadePagoId,
                            FormaPagoDescripcion = fp.Descripcion,
                            EstadoId = u.EstadoId,
                            EstadoDescripcion = e.Descripcion,
                            EmpresaId = (u.EmpresaId == null ? 0 : u.EmpresaId),
                            EmpresaRS = Em.RazonSocial

                        };

            if (searcher.ProveedorId != "null")
            {
                int proveedorId = int.Parse(searcher.ProveedorId);
                query = query.Where(o => o.ProveedorId == proveedorId);
            }

            if (!string.IsNullOrEmpty(searcher.NroComprobante))
            {
                long nroComprobante = long.Parse(searcher.NroComprobante);
                query = query.Where(o => o.NroComprobante.Equals(nroComprobante));
            }

            if (!string.IsNullOrEmpty(searcher.NroCuit))
            {
                query = query.Where(o => o.Cuit.Contains(searcher.NroCuit));
            }

            if (searcher.FormadePago != "null")
            {
                int formaPagoId = int.Parse(searcher.FormadePago);
                query = query.Where(o => o.FormaPagoId == formaPagoId);
            }

            if (searcher.Estado != "null")
            {
                int estadoId = int.Parse(searcher.Estado);
                query = query.Where(o => o.EstadoId == estadoId);
            }

            if (searcher.Empresa != "null")
            {
                int empresaId = int.Parse(searcher.Empresa);
                query = query.Where(o => o.EmpresaId == empresaId);
            }

            if (!string.IsNullOrEmpty(searcher.FechaComprobanteDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaComprobanteDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.Fecha >= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaComprobanteHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaComprobanteHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.Fecha <= fecha);
            }



            List<ComprobantesProveedores> Salida = new List<ComprobantesProveedores>();
            foreach (var item in query)
            {

                ComprobantesProveedores cat = new ComprobantesProveedores();

                cat.Id = item.Id;
                cat.ProveedorId = item.ProveedorId;
                cat.RazonSocial = item.RazonSocial;
                cat.Cuit = item.Cuit;
                cat.TipoComprobanteId = item.TipoComprobanteId;
                cat.TipoComprobanteDescripcion = item.TipoComprobanteDescripcion;
                cat.MontoNeto = item.MontoNeto;
                cat.MontoFactura = item.MontoFactura;
                cat.NroComprobante = item.NroComprobante;
                cat.Fecha = item.Fecha;
                cat.FormadePagoId = item.FormaPagoId;
                cat.FormaPagoDescripcion = item.FormaPagoDescripcion;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.EmpresaId = item.EmpresaId;
                cat.EmpresaRS = item.EmpresaRS;
                Salida.Add(cat);
            }

            return Salida.OrderByDescending(o => o.Fecha).OrderByDescending(o => o.EstadoId).ToList();


        }

        public virtual List<ComprobantesProveedores> ObtenerComprobanteProveedores()
        {
            var query = from u in SqlContext.ComprobantesProveedores
                        join p in SqlContext.Proveedores on u.ProveedorId equals p.Id into Ps
                        from p in Ps.DefaultIfEmpty()
                        //join pp in SqlContext.ComprobantePagoProveedor on u.Id equals pp.ComprobanteProveedorId into pps
                        //from pp in pps.DefaultIfEmpty()
                        join tc in SqlContext.TipoComprobantes on u.TipoComprobanteId equals tc.Id
                        join fp in SqlContext.FormasdePago on u.FormadePagoId equals fp.Id
                        join e in SqlContext.Estados on u.EstadoId equals e.Id
                        join Em in SqlContext.Empresas on u.EmpresaId equals Em.Id into Ems
                        from Em in Ems.DefaultIfEmpty()
                        where u.Delete == false
                        select new
                        {
                            Id = u.Id,
                            ProveedorId = (u.ProveedorId == null ? null : u.ProveedorId),
                            RazonSocial = p.RazonSocial,
                            Cuit = p.Cuit,
                            TipoComprobanteId = u.TipoComprobanteId,
                            TipoComprobanteDescripcion = tc.Descripcion,
                            MontoNeto = u.MontoNeto,
                            MontoFactura = u.MontoFactura,
                            Fecha = u.Fecha,
                            NroComprobante = u.NroComprobante,
                            FormaPagoId = u.FormadePagoId,
                            FormaPagoDescripcion = fp.Descripcion,
                            EstadoId = u.EstadoId,
                            EstadoDescripcion = e.Descripcion,
                            //NroOrdenPago = (pp.PagoProveedorId == null ? 0 : pp.PagoProveedorId),
                            EmpresaId = (u.EmpresaId == null ? 0 : u.EmpresaId),
                            EmpresaRS = Em.RazonSocial

                        };


            List<ComprobantesProveedores> Salida = new List<ComprobantesProveedores>();
            foreach (var item in query)
            {

                ComprobantesProveedores cat = new ComprobantesProveedores();

                cat.Id = item.Id;
                cat.ProveedorId = item.ProveedorId;
                cat.RazonSocial = item.RazonSocial;
                cat.Cuit = item.Cuit;
                cat.TipoComprobanteId = item.TipoComprobanteId;
                cat.TipoComprobanteDescripcion = item.TipoComprobanteDescripcion;
                cat.MontoNeto = item.MontoNeto;
                cat.MontoFactura = item.MontoFactura;
                cat.NroComprobante = item.NroComprobante;
                cat.Fecha = item.Fecha;
                cat.FormadePagoId = item.FormaPagoId;
                cat.FormaPagoDescripcion = item.FormaPagoDescripcion;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                //cat.NroOrdenPago = item.NroOrdenPago;
                cat.EmpresaId = item.EmpresaId;
                cat.EmpresaRS = item.EmpresaRS;
                Salida.Add(cat);
            }

            return Salida.OrderByDescending(o => o.Fecha).OrderByDescending(o => o.EstadoId).ToList();


        }

        internal List<EventosConfirmadosProveedores> BuscarPagosProveedores()
        {
            return SqlContext.EventosConfirmadosProveedores.ToList();
        }

        public virtual ComprobantesProveedores BuscarComprobantes(int id)
        {
            var query = from u in SqlContext.ComprobantesProveedores
                        join p in SqlContext.Proveedores on u.ProveedorId equals p.Id into Ps
                        from p in Ps.DefaultIfEmpty()
                        join tc in SqlContext.TipoComprobantes on u.TipoComprobanteId equals tc.Id
                        join fp in SqlContext.FormasdePago on u.FormadePagoId equals fp.Id
                        join e in SqlContext.Estados on u.EstadoId equals e.Id
                        join Em in SqlContext.Empresas on u.EmpresaId equals Em.Id into Ems
                        from Em in Ems.DefaultIfEmpty()
                        where u.Id == id
                        select new
                        {
                            Id = u.Id,
                            ProveedorId = (u.ProveedorId == null ? null : u.ProveedorId),
                            RazonSocial = p.RazonSocial,
                            TipoComprobanteId = u.TipoComprobanteId,
                            TipoComprobanteDescripcion = tc.Descripcion,
                            PuntoVenta = u.PuntoVenta,
                            MontoNeto = u.MontoNeto,
                            MontoFactura = u.MontoFactura,
                            Fecha = u.Fecha,
                            NroComprobante = u.NroComprobante,
                            FormaPagoId = u.FormadePagoId,
                            FormaPagoDescripcion = fp.Descripcion,
                            EstadoId = u.EstadoId,
                            EstadoDescripcion = e.Descripcion,
                            EmpresaId = (u.EmpresaId == null ? null : u.EmpresaId),
                            EmpresaRS = Em.RazonSocial,
                            CuentaId = u.CuentaId,
                            IIBBARBA = u.IIBBARBA,
                            IIBBCABA = u.IIBBCABA,
                            PercepcionIVA = u.PercepcionIVA

                        };

            List<ComprobantesProveedores> Salida = new List<ComprobantesProveedores>();
            foreach (var item in query)
            {

                ComprobantesProveedores cat = new ComprobantesProveedores();

                cat.Id = item.Id;
                cat.ProveedorId = item.ProveedorId;
                cat.RazonSocial = item.RazonSocial;
                cat.TipoComprobanteId = item.TipoComprobanteId;
                cat.TipoComprobanteDescripcion = item.TipoComprobanteDescripcion;
                cat.PuntoVenta = item.PuntoVenta;
                cat.MontoNeto = item.MontoNeto;
                cat.MontoFactura = item.MontoFactura;
                cat.NroComprobante = item.NroComprobante;
                cat.Fecha = item.Fecha;
                cat.FormadePagoId = item.FormaPagoId;
                cat.FormaPagoDescripcion = item.FormaPagoDescripcion;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.EmpresaId = item.EmpresaId;
                cat.EmpresaRS = item.EmpresaRS;
                cat.CuentaId = item.CuentaId;
                cat.IIBBARBA = item.IIBBARBA;
                cat.IIBBCABA = item.IIBBCABA;
                cat.PercepcionIVA = item.PercepcionIVA;

                Salida.Add(cat);
            }

            return Salida.SingleOrDefault();

        }

        public virtual void NuevoComprobanteProveedores(ComprobantesProveedores comprobante)
        {
            if (comprobante.Id > 0)
            {
                ComprobantesProveedores editComprobante = SqlContext.ComprobantesProveedores.Where(o => o.Id == comprobante.Id).SingleOrDefault();

                editComprobante.ProveedorId = comprobante.ProveedorId;
                editComprobante.RazonSocial = comprobante.RazonSocial;
                editComprobante.TipoComprobanteId = comprobante.TipoComprobanteId;
                editComprobante.TipoComprobanteDescripcion = comprobante.TipoComprobanteDescripcion;
                editComprobante.MontoFactura = comprobante.MontoFactura;
                editComprobante.MontoNeto = comprobante.MontoNeto;
                editComprobante.NroComprobante = comprobante.NroComprobante;
                editComprobante.PuntoVenta = comprobante.PuntoVenta;
                editComprobante.Fecha = comprobante.Fecha;
                editComprobante.Iva105 = comprobante.Iva105;
                editComprobante.Iva21 = comprobante.Iva21;
                editComprobante.Iva27 = comprobante.Iva27;
                editComprobante.IIBBCABA = comprobante.IIBBCABA;
                editComprobante.IIBBARBA = comprobante.IIBBARBA;
                editComprobante.PercepcionIVA = comprobante.PercepcionIVA;
                editComprobante.FormadePagoId = comprobante.FormadePagoId;
                editComprobante.EstadoId = comprobante.EstadoId;
                editComprobante.EmpresaId = comprobante.EmpresaId;
                editComprobante.UpdateFecha = System.DateTime.Now;

                SqlContext.SaveChanges();

            }
            else
            {
                comprobante.CreateFecha = System.DateTime.Now;

                SqlContext.ComprobantesProveedores.Add(comprobante);
                SqlContext.SaveChanges();

            }
        }

        public void GrabarMoviemientoCuentas(ComprobantesProveedores comprobante)
        {
            if (comprobante.CuentaId > 0)
            {

                try
                {
                    int Id = 0;
                    if (SqlContext.Cuentas_Log.Where(o => o.CuentaId == comprobante.CuentaId).ToList().Count > 0)
                    {
                        Id = SqlContext.Cuentas_Log.Where(o => o.CuentaId == comprobante.CuentaId).Max(o => o.Id);

                        Cuentas_Log log = SqlContext.Cuentas_Log.Where(o => o.CuentaId == comprobante.CuentaId && o.Id == Id).FirstOrDefault();

                        log.CuentaId = log.CuentaId;

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = log.SaldoActual;
                        log.SaldoActual = log.SaldoActual - double.Parse(comprobante.MontoFactura.ToString());
                        log.TipoMovimiento = "DEBITO";
                        log.UsuarioId = comprobante.EmpleadoId;


                        SqlContext.Cuentas_Log.Add(log);
                        SqlContext.SaveChanges();
                    }
                    else
                    {
                        Cuentas_Log log = new Cuentas_Log();

                        log.CuentaId = Int32.Parse(comprobante.CuentaId.ToString());

                        log.FechaMovimiento = System.DateTime.Now;
                        log.SaldoAnterior = 0;
                        log.SaldoActual = 0 - double.Parse(comprobante.MontoFactura.ToString());
                        log.TipoMovimiento = "DEBITO";
                        log.UsuarioId = comprobante.EmpleadoId;

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

        public virtual void NuevoComprobanteProveedoresDetalle(ComprobantesProveedores_Detalles det)
        {
            SqlContext.ComprobantesProveedores_Detalles.Add(det);
            SqlContext.SaveChanges();
        }

        public virtual void EliminarComprobanteProveedoresDetalle(int comprobanteId)
        {
            List<ComprobantesProveedores_Detalles> detalle = SqlContext.ComprobantesProveedores_Detalles.Where(o => o.ComprobanteProveedorId == comprobanteId).ToList();

            try
            {
                foreach (var item in detalle)
                {
                    SqlContext.ComprobantesProveedores_Detalles.Remove(item);
                    SqlContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual List<ComprobantesProveedores_Detalles> BuscarDetalleComprobanteProveedorPorComprobante(int comprobanteId)
        {
            var query = from CD in SqlContext.ComprobantesProveedores_Detalles
                        join Tm in SqlContext.TipoMovimientos on CD.TipoMoviemientoId equals Tm.Id
                        join Cc in SqlContext.CentroCostos on CD.CentroCostoId equals Cc.Id
                        where CD.ComprobanteProveedorId == comprobanteId
                        select new
                        {
                            Id = CD.Id,
                            CentroCostoId = CD.CentroCostoId,
                            CentroCostoDescripcion = Cc.Descripcion,
                            TipoMovimientoId = CD.TipoMoviemientoId,
                            TipoMovimientoDescripcion = Tm.Descripcion,
                            Importe = CD.Importe,
                            Cantidad = CD.Cantidad,
                            Descripcion = CD.Descripcion,
                            ComprobanteProveedorId = CD.ComprobanteProveedorId,
                            TipoImpuestoId = CD.TipoImpuestoId,
                            ValorImpuesto = CD.ValorImpuesto,
                            ValorImpuestoInterno = CD.ValorImpuestoInterno
                        };

            List<ComprobantesProveedores_Detalles> Salida = new List<ComprobantesProveedores_Detalles>();
            foreach (var item in query)
            {

                ComprobantesProveedores_Detalles cat = new ComprobantesProveedores_Detalles();

                cat.Id = item.Id;
                cat.CentroCostoId = item.CentroCostoId;
                cat.CentroCostoDescripcion = item.CentroCostoDescripcion;
                cat.TipoMoviemientoId = item.TipoMovimientoId;
                cat.TipoMovimientoCodigo = item.TipoMovimientoDescripcion;
                cat.Importe = item.Importe;
                cat.Cantidad = item.Cantidad;
                cat.Descripcion = item.Descripcion;
                cat.ComprobanteProveedorId = item.ComprobanteProveedorId;
                cat.TipoImpuestoId = item.TipoImpuestoId;
                cat.ValorImpuesto = item.ValorImpuesto;
                cat.ValorImpuestoInterno = item.ValorImpuestoInterno;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public void GrabarComprobantePagoProveedor(ComprobantePagoProveedor comprobante)
        {
            SqlContext.ComprobantePagoProveedor.Add(comprobante);
            SqlContext.SaveChanges();
        }

        public List<ComprobantesProveedores> BuscarComprobantesPorProveedor(int proveedorId)
        {
            var query = from u in SqlContext.ComprobantesProveedores
                        join p in SqlContext.Proveedores on u.ProveedorId equals p.Id into Ps
                        from p in Ps.DefaultIfEmpty()
                        join tc in SqlContext.TipoComprobantes on u.TipoComprobanteId equals tc.Id
                        join fp in SqlContext.FormasdePago on u.FormadePagoId equals fp.Id
                        join e in SqlContext.Estados on u.EstadoId equals e.Id
                        where u.Delete == false
                        select new
                        {
                            Id = u.Id,
                            ProveedorId = (u.ProveedorId == null ? null : u.ProveedorId),
                            RazonSocial = p.RazonSocial,
                            TipoComprobanteId = u.TipoComprobanteId,
                            TipoComprobanteDescripcion = tc.Descripcion,
                            MontoNeto = u.MontoNeto,
                            MontoFactura = u.MontoFactura,
                            Fecha = u.Fecha,
                            NroComprobante = u.NroComprobante,
                            FormaPagoId = u.FormadePagoId,
                            FormaPagoDescripcion = fp.Descripcion,
                            EstadoId = u.EstadoId,
                            EstadoDescripcion = e.Descripcion

                        };

            List<ComprobantesProveedores> Salida = new List<ComprobantesProveedores>();
            foreach (var item in query)
            {

                ComprobantesProveedores cat = new ComprobantesProveedores();

                cat.Id = item.Id;
                cat.ProveedorId = item.ProveedorId;
                cat.RazonSocial = item.RazonSocial;
                cat.TipoComprobanteId = item.TipoComprobanteId;
                cat.TipoComprobanteDescripcion = item.TipoComprobanteDescripcion;
                cat.MontoNeto = item.MontoNeto;
                cat.MontoFactura = item.MontoFactura;
                cat.NroComprobante = item.NroComprobante;
                cat.Fecha = item.Fecha;
                cat.FormadePagoId = item.FormaPagoId;
                cat.FormaPagoDescripcion = item.FormaPagoDescripcion;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;

                Salida.Add(cat);
            }

            if (proveedorId > 0)
            {
                Salida.Where(o => o.ProveedorId == proveedorId);
            }



            return Salida.OrderByDescending(o => o.EstadoId).ToList();
        }

        public List<ReporteComprobantes> ObtenerReporteComprobantes(SearcherReporteComprobantes searcher)
        {
            var query = from r in SqlContext.ReporteComprobantes
                        select r;

            if (!string.IsNullOrEmpty(searcher.FechaDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.Fecha >= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.Fecha <= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.RazonSocial))
            {
                query = query.Where(o => o.RazonSocial.Contains(searcher.RazonSocial));
            }
            if (!string.IsNullOrEmpty(searcher.PresupuestoId))
            {
                int presupuestoId = Int32.Parse(searcher.PresupuestoId);
                query = query.Where(o => o.PresupuestoId == presupuestoId);
            }

            if (searcher.TipoMovimientoId != "Todas")
            {
                int tipoMovimientoId = Int32.Parse(searcher.TipoMovimientoId);
                query = query.Where(o => o.TipoMoviemientoId == tipoMovimientoId);
            }

            return query.OrderBy(o => o.Fecha).ToList();

        }

        internal List<ComprobantesProveedores> BuscarComprobantesPorProveedorNroComprobante(int proveedorId, long nroComprobante)
        {
            return SqlContext.ComprobantesProveedores.Where(o => o.ProveedorId == proveedorId && o.NroComprobante == nroComprobante && o.Delete == false).ToList();

        }

        internal List<ReporteIva_Result> BuscarIva(string fechaInicio, string fechaFin, int empresa)
        {

            DateTime starDate = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return SqlContext.ReporteIva(empresa, starDate, endDate).OrderBy(o => o.Fecha).ToList();
        }

        internal bool GrabarComprobante(ComprobantesProveedores comprobantes)
        {
            if (comprobantes.Id > 0)
            {
                ComprobantesProveedores edit = SqlContext.ComprobantesProveedores.Where(o => o.Id == comprobantes.Id).SingleOrDefault();

                edit.NroComprobante = comprobantes.NroComprobante;
                edit.TipoComprobanteId = comprobantes.TipoComprobanteId;
                edit.EmpresaId = comprobantes.EmpresaId;

                edit.UpdateFecha = System.DateTime.Now;

                try
                {
                    SqlContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                comprobantes.CreateFecha = System.DateTime.Now;

                try
                {
                    SqlContext.ComprobantesProveedores.Add(comprobantes);
                    SqlContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }

        }

        public bool ElimnarComprobanteProveedor(int id)
        {
            try
            {


                if (id > 0)
                {
                    ComprobantesProveedores edit = SqlContext.ComprobantesProveedores.Where(o => o.Id == id).SingleOrDefault();

                    if (edit != null)
                    {

                        edit.Delete = true;
                        edit.DeleteFecha = System.DateTime.Now;

                        SqlContext.SaveChanges();

                        return true;
                    }
                    else
                        return false;

                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InformeResultados_Result> BuscarInformeResultados(string fechaInicio, string fechaFin)
        {
            DateTime starDate = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return SqlContext.InformeResultados(starDate, endDate).OrderBy(o => o.Codigo).ToList();
        }

        public List<DetalleInformeResultados_Result> BuscarDetalleInformeResultados(string tipoMovimiento, int tipoMovimientoId, string fechaInicio, string fechaFin)
        {
            DateTime starDate = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return SqlContext.DetalleInformeResultados(tipoMovimiento, tipoMovimientoId, starDate, endDate).ToList();
        }

        public ComprobantesProveedores_Detalles BuscarComprobanteDetalle(int Id)
        {
            return SqlContext.ComprobantesProveedores_Detalles.Single(o => o.Id == Id);
        }

        public bool EditarComprobanteDetalle(ComprobantesProveedores_Detalles comprobante)
        {
            if (comprobante.Id > 0)
            {
                try
                {
                    ComprobantesProveedores_Detalles edit = SqlContext.ComprobantesProveedores_Detalles.Single(o => o.Id == comprobante.Id);

                    edit.TipoMoviemientoId = comprobante.TipoMoviemientoId;

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

        internal void NuevoComprobantePagoProveedor(ComprobantePagoProveedor comprobantePagoProveedor)
        {

            ComprobantePagoProveedor edit = SqlContext.ComprobantePagoProveedor.SingleOrDefault(o => o.ComprobanteProveedorId == comprobantePagoProveedor.ComprobanteProveedorId
                                                                                    && o.PagoProveedorId == comprobantePagoProveedor.PagoProveedorId);
            if (edit != null)
            {
                comprobantePagoProveedor.PagoProveedorId = edit.PagoProveedorId;
                comprobantePagoProveedor.ComprobanteProveedorId = edit.ComprobanteProveedorId;

                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.ComprobantePagoProveedor.Add(comprobantePagoProveedor);
                SqlContext.SaveChanges();
            }
        }

        public List<GastosporPresupuestos> BuscarGastosPresupuestos(SearcherComprobantes searcher)
        {

            var query = from g in SqlContext.GastosporPresupuestos
                        select g;

            if (!string.IsNullOrWhiteSpace(searcher.PresupuestoId))
            {
                int presupuestoId = Int32.Parse(searcher.PresupuestoId);
                query = query.Where(o => o.PresupuestoId == presupuestoId);
            }

            return query.ToList();

        }



        internal ComprobantePagoProveedor BuscarComprobantePagoProveedor(int pagoId)
        {
            return SqlContext.ComprobantePagoProveedor.SingleOrDefault(o => o.PagoProveedorId == pagoId);
        }

        internal void EliminarComprobantePago(int comprobanteId, int pagoId)
        {
            try
            {

                ComprobantePagoProveedor pago = SqlContext.ComprobantePagoProveedor.Single(o => o.ComprobanteProveedorId == comprobanteId
                                                                                            && o.PagoProveedorId == pagoId);

                SqlContext.ComprobantePagoProveedor.Remove(pago);
                SqlContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        internal List<IVAVenta_Result> BuscarIvaVenta(string fechaInicio, string fechaFin, int empresa)
        {

            DateTime starDate = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return SqlContext.IVAVenta(empresa, starDate, endDate).OrderBy(o => o.Fecha).ToList();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class DetalleInformeResultados_Result
    {
        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaPagoStr
        {
            get
            {
                return String.Format(formatoFecha, Fecha);
            }
            set
            {
                Fecha = DateTime.ParseExact(FechaPagoStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string ImporteStr
        {
            get
            {
                if (Importe != null)
                    return System.Math.Round((double)Importe, 2).ToString("C");
                else
                    return "";
            }

        }

    }

    public partial class InformeResultados_Result
    {
        public string TotalStr
        {
            get
            {
                if (Total != null)
                    return System.Math.Round((double)Total, 2).ToString("C");
                else
                    return "";
            }

        }
    }


    public partial class SearcherReporteComprobantes
    {

        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }

        public string TipoMovimientoId { get; set; }

        public string RazonSocial { get; set; }

        public string PresupuestoId { get; set; }
    }

    public partial class SearcherComprobantes
    {
        public string NroComprobante { get; set; }
        public string NroCuit { get; set; }
        public string ProveedorId { get; set; }
        public string Estado { get; set; }
        public string FormadePago { get; set; }
        public string Empresa { get; set; }
        public string FechaComprobanteDesde { get; set; }
        public string FechaComprobanteHasta { get; set; }
        public string PresupuestoId { get; set; }

    }

    public partial class ComprobantesProveedores
    {
        public string Cuit { get; set; }
    }

    public partial class GastosporPresupuestos
    {
        public string Cliente
        {
            get
            {
                if (RazonSocial == "" || RazonSocial == null)
                    return ApellidoNombre;
                else
                    return RazonSocial;
            }
        }
    }

}