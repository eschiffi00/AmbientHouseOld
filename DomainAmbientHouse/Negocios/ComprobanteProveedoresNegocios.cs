using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class ComprobanteProveedoresNegocios
    {

        ComprobanteProveedoresDatos Datos;
        MovimientosDatos DatosMovimientos;
        PagoProveedoresDatos DatosPagos;

        public ComprobanteProveedoresNegocios()
        {
            Datos = new ComprobanteProveedoresDatos();
            DatosMovimientos = new MovimientosDatos();
            DatosPagos = new PagoProveedoresDatos();
        }

        public virtual List<ComprobantesProveedores> ObtenerComprobanteProveedores(SearcherComprobantes searcher)
        {

            return Datos.ObtenerComprobanteProveedores(searcher);

        }

        public virtual List<ComprobantesProveedores> ObtenerComprobanteProveedores()
        {

            return Datos.ObtenerComprobanteProveedores();

        }

        public virtual ComprobantesProveedores BuscarComprobantes(int id)
        {
            return Datos.BuscarComprobantes(id);
        }

        public virtual bool NuevoComprobanteProveedores(ComprobantesProveedores comprobante, List<ComprobantesProveedores_Detalles> detalle)
        {

            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Datos.EliminarComprobanteProveedoresDetalle((int)comprobante.Id);

                    Datos.NuevoComprobanteProveedores(comprobante);

                    if (comprobante.TipoComprobanteId == ComprobanteInterno)
                    {
                        PagosProveedores pagos = new PagosProveedores
                        {
                            EmpleadoId = comprobante.EmpleadoId,
                            FormadePagoId = comprobante.FormadePagoId,
                            Importe = double.Parse(comprobante.MontoFactura.ToString()),
                            CuentaId = int.Parse(comprobante.CuentaId.ToString()),
                            Fecha = DateTime.Now
                        };
                        this.DatosPagos.NuevoPagoProveedores(pagos, "Pago Nro Comprobante: (" + comprobante.NroComprobante + ")");
                    }


                    foreach (var item in detalle)
                    {
                        ComprobantesProveedores_Detalles det = new ComprobantesProveedores_Detalles();

                        det.CentroCostoId = item.CentroCostoId;
                        det.TipoMoviemientoId = item.TipoMoviemientoId;
                        det.Importe = item.Importe;
                        det.Descripcion = item.Descripcion;
                        det.Cantidad = item.Cantidad;
                        det.ComprobanteProveedorId = comprobante.Id;
                        det.PresupuestoId = item.PresupuestoId;
                        det.UnidadNegocioId = item.UnidadNegocioId;
                        det.DegustacionId = item.DegustacionId;

                        if (comprobante.TipoComprobanteId != ComprobanteInterno)
                        {
                            det.TipoImpuestoId = item.TipoImpuestoId;
                            det.ValorImpuesto = item.ValorImpuesto;
                            det.ValorImpuestoInterno = item.ValorImpuestoInterno;
                        }

                        Datos.NuevoComprobanteProveedoresDetalle(det);
                    }


                    scope.Complete();
                    return true;

                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);

                    return false;
                }
            }
        }

        public virtual List<ComprobantesProveedores_Detalles> BuscarDetalleComprobanteProveedorPorComprobante(int comprobanteId)
        {
            return Datos.BuscarDetalleComprobanteProveedorPorComprobante(comprobanteId);
        }

        public List<ComprobantesProveedores> BuscarComprobantesPorProveedor(int proveedorId)
        {
            return Datos.BuscarComprobantesPorProveedor(proveedorId);
        }

        public List<ReporteComprobantes> ObtenerReporteComprobantes(SearcherReporteComprobantes searcher)
        {
            return Datos.ObtenerReporteComprobantes(searcher);
        }

        internal List<ComprobantesProveedores> BuscarComprobantesPorProveedorNroComprobante(int proveedorId, long nroComprobante)
        {
            return Datos.BuscarComprobantesPorProveedorNroComprobante(proveedorId, nroComprobante);
        }

        internal List<ReporteIva_Result> BuscarIva(string fechaInicio, string fechaFin, int empresa)
        {
            return Datos.BuscarIva(fechaInicio, fechaFin, empresa);
        }

        internal bool GrabarComprobante(ComprobantesProveedores comprobantes)
        {
            return Datos.GrabarComprobante(comprobantes);
        }

        internal bool ElimarComprobanteProveedor(int ComprobanteId)
        {
            return Datos.ElimnarComprobanteProveedor(ComprobanteId);
        }

        internal List<InformeResultados_Result> BuscarInformeResultados(string fechaInicio, string fechaFin)
        {
            return Datos.BuscarInformeResultados(fechaInicio, fechaFin);
        }

        internal List<DetalleInformeResultados_Result> BuscarDetalleInformeResultados(string tipoMovimiento, int tipoMovimientoId, string fechaInicio, string fechaFin)
        {
            return Datos.BuscarDetalleInformeResultados(tipoMovimiento, tipoMovimientoId, fechaInicio, fechaFin);
        }

        internal ComprobantesProveedores_Detalles BuscarComprobanteDetalle(int Id)
        {
            return Datos.BuscarComprobanteDetalle(Id);
        }

        internal bool EditarComprobanteDetalle(ComprobantesProveedores_Detalles comprobante)
        {
            return Datos.EditarComprobanteDetalle(comprobante);
        }

        internal List<GastosporPresupuestos> ListarGastosporPresupuestos(SearcherComprobantes searcher)
        {
            return Datos.BuscarGastosPresupuestos(searcher);
        }

        internal List<EventosConfirmadosProveedores> BuscarPagosProveedores()
        {
            return Datos.BuscarPagosProveedores();
        }
        public List<IVAVenta_Result> BuscarIvaVenta(string fechaInicio, string fechaFin, int empresa)
        {
            return Datos.BuscarIvaVenta(fechaInicio, fechaFin, empresa);
        }
    }
}
