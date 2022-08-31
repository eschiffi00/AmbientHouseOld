using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;
using System.Configuration;
using System.Globalization;

namespace DomainAmbientHouse.Negocios
{
    public class PagoProveedoresNegocios
    {

        PagoProveedoresDatos Datos;

        ComprobanteProveedoresDatos DatosComprobantesProveedor;

        ChequesDatos DatosCheques;

        ComprobanteProveedoresDatos DatosComprobantes;

        RetencionesDatos DatosRetenciones;

        TransferenciasDatos DatosTransferencias;

        public PagoProveedoresNegocios()
        {
            Datos = new PagoProveedoresDatos();
        }

        public virtual List<PagosProveedores> ObtenerPagoProveedores()
        {

            return Datos.ObtenerPagoProveedores();

        }

        public PagosProveedores BuscarPagoProveedor(int id)
        {
            return Datos.BuscarPagoProveedor(id);
        }

        public void NuevaPagosProveedores(PagosProveedores pago, string descripcion)
        {
            Datos.NuevoPagoProveedores(pago, descripcion);
        }

        public void GrabarPagoProveedores(PagosProveedores PagosProveedoresSeleccionado, List<ComprobantesProveedores>
                                            ListComprobantesSeleccionados, List<Cheques> ListChequesSeleccionados)
        {

            int Pagado = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagado"].ToString());
            int Parcial = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagoParcial"].ToString());

            int FormaPagoRetenciones = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoRetenciones"].ToString());
            int FormaPagoTransferencias = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Datos.NuevoPagoProveedores(PagosProveedoresSeleccionado, "");

                    DatosComprobantesProveedor = new ComprobanteProveedoresDatos();

                    if (ListComprobantesSeleccionados.Count() == 1)
                    {

                        int Id = ListComprobantesSeleccionados.FirstOrDefault().Id;

                        ComprobanteProveedoresDatos DatosComprobantes = new ComprobanteProveedoresDatos();

                        ComprobantesProveedores editCompro = DatosComprobantes.BuscarComprobantes(Id);

                        double total = PagosProveedoresSeleccionado.Importe + PagosProveedoresSeleccionado.Saldo;

                        if (editCompro.MontoFactura == total)
                            editCompro.EstadoId = Pagado;
                        else
                            editCompro.EstadoId = Parcial;

                        DatosComprobantes.NuevoComprobanteProveedores(editCompro);

                        ComprobantePagoProveedor comprobante = new ComprobantePagoProveedor();

                        comprobante.ComprobanteProveedorId = Id;
                        comprobante.PagoProveedorId = PagosProveedoresSeleccionado.Id;

                        DatosComprobantesProveedor.GrabarComprobantePagoProveedor(comprobante);
                    }
                    else
                    {
                        foreach (var item in ListComprobantesSeleccionados)
                        {
                            ComprobanteProveedoresDatos DatosComprobantes = new ComprobanteProveedoresDatos();

                            ComprobantesProveedores editCompro = DatosComprobantes.BuscarComprobantes(item.Id);

                            editCompro.EstadoId = Pagado;

                            DatosComprobantes.NuevoComprobanteProveedores(editCompro);

                            ComprobantePagoProveedor comprobante = new ComprobantePagoProveedor();

                            comprobante.ComprobanteProveedorId = item.Id;
                            comprobante.PagoProveedorId = PagosProveedoresSeleccionado.Id;

                            DatosComprobantesProveedor.GrabarComprobantePagoProveedor(comprobante);


                        }
                    }



                    if (PagosProveedoresSeleccionado.FormadePagoId == FormaPagoRetenciones)
                    {
                        DatosRetenciones = new RetencionesDatos();

                        Retenciones retencion = new Retenciones();

                        retencion.NroCertificado = PagosProveedoresSeleccionado.NroCertificado;
                        retencion.Importe = PagosProveedoresSeleccionado.Importe;
                        retencion.Fecha = PagosProveedoresSeleccionado.Fecha;
                        retencion.TipoMovimimientoId = PagosProveedoresSeleccionado.TipoMoviemientoId;
                        retencion.PagoProveedorId = PagosProveedoresSeleccionado.Id;

                        DatosRetenciones.GrabarRetenciones(retencion);
                    }
                    else if (PagosProveedoresSeleccionado.FormadePagoId == FormaPagoTransferencias)
                    {

                        DatosTransferencias = new TransferenciasDatos();

                        Transferencias transferencia = new Transferencias();

                        transferencia.ProveedorId = PagosProveedoresSeleccionado.ProveedorId;
                        transferencia.BancoId = PagosProveedoresSeleccionado.CuentaId;
                        transferencia.NroTransferencia = PagosProveedoresSeleccionado.NroTransferencia;
                        transferencia.Importe = PagosProveedoresSeleccionado.Importe;
                        transferencia.NombreArchivo = "";
                        transferencia.ComprobanteExtension = "";


                        if (PagosProveedoresSeleccionado.FechaTransferencia != null)
                            transferencia.FechaTransferencia = DateTime.Parse(PagosProveedoresSeleccionado.FechaTransferencia.ToString());
                        else
                            transferencia.FechaTransferencia = System.DateTime.Now;

                        DatosTransferencias.GrabarTransferencias(transferencia);

                    }

                    DatosCheques = new ChequesDatos();
                    foreach (var item in ListChequesSeleccionados)
                    {

                        Cheques cheque = new Cheques();

                        cheque.NroCheque = item.NroCheque;
                        cheque.Importe = item.Importe;
                        cheque.FechaVencimiento = item.FechaVencimiento;
                        cheque.FechaEmision = item.FechaEmision;
                        cheque.Observaciones = item.Observaciones;
                        cheque.TipoCheque = item.TipoCheque;
                        cheque.BancoId = item.BancoId;
                        cheque.EstadoId = item.EstadoId;
                        cheque.ProveedorId = item.ProveedorId;


                        DatosCheques.NuevosCheques(cheque);

                        ChequesPagosProveedores chequesPagos = new ChequesPagosProveedores();

                        chequesPagos.ChequeId = cheque.Id;
                        chequesPagos.PagoProveedorId = PagosProveedoresSeleccionado.Id;

                        DatosCheques.GrabarChequePagoProveedor(chequesPagos);

                    }


                    scope.Complete();
                }
                catch (Exception ex)
                {

                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }
            }
        }

        public List<PagosProveedores> BuscarPagoProveedoresPorComprabante(int comprobanteId)
        {
            return Datos.BuscarPagoProveedoresPorComprabante(comprobanteId);
        }

        public PagosProveedores BuscarPagoProveedorPorCheque(int chequeId)
        {
            return Datos.BuscarPagoProveedorPorCheque(chequeId);
        }

        internal void ActualizarPagoProveedor(PagosProveedores pago)
        {
            Datos.ActualizarPagoProveedor(pago);
        }

        internal List<PagosProveedores> ObtenerPagosPorComprobante(int comprobanteId)
        {
            return Datos.ObtenerPagosPorComprobante(comprobanteId);
        }

        internal void GrabarPagoProveedores(List<OrdenPagoProveedores> ListOrdenPagoProveedoresSeleccionados)
        {
            int Pagado = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagado"].ToString());
            int Parcial = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagoParcial"].ToString());

            int FormaPagoRetenciones = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoRetenciones"].ToString());
            int FormaPagoTransferencias = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());
            int FormaPagoCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());

            int chequePendiente = Int32.Parse(ConfigurationManager.AppSettings["ChequesPendiente"].ToString()); ;

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    foreach (var item in ListOrdenPagoProveedoresSeleccionados)
                    {
                        PagosProveedores pagoProveedor = new PagosProveedores();

                        pagoProveedor.CuentaId = item.CuentaId;
                        pagoProveedor.EmpleadoId = item.EmpleadoId;
                        pagoProveedor.Fecha = DateTime.ParseExact(item.FechaPago, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        pagoProveedor.FormadePagoId = item.FormadePagoId;
                        pagoProveedor.Importe = item.Importe;
                        pagoProveedor.ProveedorId = item.ProveedorId;
                        pagoProveedor.Saldo = item.Saldo;

                        Datos.NuevoPagoProveedores(pagoProveedor, "");

                        ActualizarComprobantes(Pagado, Parcial, item, pagoProveedor);

                        if (item.FormadePagoId == FormaPagoRetenciones)
                        {
                            DatosRetenciones = new RetencionesDatos();

                            Retenciones retencion = new Retenciones();

                            retencion.NroCertificado = item.NroComprobante;
                            retencion.Importe = item.Importe;
                            retencion.Fecha = DateTime.ParseExact(item.FechaPago, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            retencion.TipoMovimimientoId = item.TipoRetencion;
                            retencion.PagoProveedorId = pagoProveedor.Id;

                            DatosRetenciones.GrabarRetenciones(retencion);
                        }
                        else if (item.FormadePagoId == FormaPagoTransferencias)
                        {

                            DatosTransferencias = new TransferenciasDatos();

                            Transferencias transferencia = new Transferencias();

                            transferencia.ProveedorId = item.ProveedorId;
                            transferencia.BancoId = item.CuentaId;
                            transferencia.NroTransferencia = item.NroComprobante;
                            transferencia.Importe = item.Importe;
                            transferencia.NombreArchivo = "";
                            transferencia.ComprobanteExtension = "";


                            if (pagoProveedor.FechaTransferencia != null)
                                transferencia.FechaTransferencia = DateTime.Parse(pagoProveedor.FechaTransferencia.ToString());
                            else
                                transferencia.FechaTransferencia = System.DateTime.Now;

                            DatosTransferencias.GrabarTransferencias(transferencia);

                        }
                        else if (item.FormadePagoId == FormaPagoCheque)
                        {
                            DatosCheques = new ChequesDatos();

                            Cheques cheque = new Cheques();

                            cheque.NroCheque = item.NroComprobante;
                            cheque.Importe = item.Importe;
                            cheque.FechaVencimiento = DateTime.ParseExact(item.FechaVencimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            cheque.FechaEmision = DateTime.ParseExact(item.FechaEmision, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            cheque.Observaciones = item.Observaciones;
                            cheque.TipoCheque = item.TipoCheque;
                            cheque.BancoId = item.BancoId;
                            cheque.EstadoId = chequePendiente;
                            cheque.ProveedorId = item.ProveedorId;


                            DatosCheques.NuevosCheques(cheque);

                            ChequesPagosProveedores chequesPagos = new ChequesPagosProveedores();

                            chequesPagos.ChequeId = cheque.Id;
                            chequesPagos.PagoProveedorId = pagoProveedor.Id;

                            DatosCheques.GrabarChequePagoProveedor(chequesPagos);
                        }

                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void ActualizarComprobantes(int Pagado, int Parcial, OrdenPagoProveedores item, PagosProveedores pagoProveedor)
        {

            DatosComprobantesProveedor = new ComprobanteProveedoresDatos();

            if (item.ListaComprobantes.Count() == 1)
            {
                int Id = item.ListaComprobantes.FirstOrDefault().Id;

                ComprobanteProveedoresDatos DatosComprobantes = new ComprobanteProveedoresDatos();

                ComprobantesProveedores editCompro = DatosComprobantes.BuscarComprobantes(Id);

                double total = pagoProveedor.Importe + pagoProveedor.Saldo;

                if (editCompro.MontoFactura == total)
                    editCompro.EstadoId = Pagado;
                else
                    editCompro.EstadoId = Parcial;

                DatosComprobantes.NuevoComprobanteProveedores(editCompro);

                ComprobantePagoProveedor comprobante = new ComprobantePagoProveedor();

                comprobante.ComprobanteProveedorId = Id;
                comprobante.PagoProveedorId = pagoProveedor.Id;

                DatosComprobantesProveedor.GrabarComprobantePagoProveedor(comprobante);
            }
            else
            {
                double importe = 0;

                foreach (var item1 in item.ListaComprobantes)
                {
                    ComprobanteProveedoresDatos DatosComprobantes = new ComprobanteProveedoresDatos();

                    ComprobantesProveedores editCompro = DatosComprobantes.BuscarComprobantes(item1.Id);

                    editCompro.EstadoId = Pagado;

                    DatosComprobantes.NuevoComprobanteProveedores(editCompro);

                    ComprobantePagoProveedor comprobante = new ComprobantePagoProveedor();

                    comprobante.ComprobanteProveedorId = item1.Id;
                    comprobante.PagoProveedorId = pagoProveedor.Id;

                    DatosComprobantesProveedor.GrabarComprobantePagoProveedor(comprobante);

                }
            }
        }
    }
}
