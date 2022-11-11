using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class PresupuestosNegocios
    {

        PresupuestosDatos Datos;
        EventosDatos DatosEventos;
        PresupuestoDetalleDatos DatosPresupuestoDetalle;
        ClientesDatos DatosClientes;
        ChequesDatos DatosCheques;
        TransferenciasDatos DatosTransferencias;
        PagosClienteDatos DatosPagoClientes;
        IndexacionDatos DatosIndexacion;

        public PresupuestosNegocios()
        {
            Datos = new PresupuestosDatos();
            DatosEventos = new EventosDatos();
            DatosPresupuestoDetalle = new PresupuestoDetalleDatos();
            DatosClientes = new ClientesDatos();
            DatosCheques = new ChequesDatos();
            DatosTransferencias = new TransferenciasDatos();
            DatosPagoClientes = new PagosClienteDatos();
            DatosIndexacion = new IndexacionDatos();
        }

        public virtual ObtenerDatosParaPresupuesto ObtenerPresupuestos(int eventoId)
        {

            return Datos.ObtenerPresupuestos(eventoId);

        }

        public ObtenerPresupuestoSalon ObtenerPresupuestosSalon(int presupuestoId)
        {
            return Datos.ObtenerPresupuestosSalon(presupuestoId);
        }

        public ObtenerPresupuestoTecnica ObtenerPresupuestoTecnica(int presupuestoId)
        {
            return Datos.ObtenerPresupuestosTecnica(presupuestoId);
        }

        public ObtenerPresupuestoCatering ObtenerPresupuestoCatering(int presupuestoId)
        {
            return Datos.ObtenerPresupuestoCatering(presupuestoId);
        }

        public ObtenerPresupuestoBarra ObtenerPresupuestoBarra(int presupuestoId)
        {
            return Datos.ObtenerPresupuestoBarra(presupuestoId);
        }

        public ObtenerPresupuestoAmbientacion ObtenerPresupuestoAmbientacion(int presupuestoId)
        {
            return Datos.ObtenerPresupuestoAmbientacion(presupuestoId);
        }

        public PresupuestoPDF ObtenerPresupuestosPorPresupuesto(int id, List<ClientesPipedrive> lisClientes)
        {
            return Datos.ObtenerPresupuestosPorPresupuesto(id, lisClientes);
        }

        public List<ListarAdicionalesPorPresupuesto> ObtenerAdicionales(int presupuestoId, int EstadoId)
        {
            return Datos.ObtenerAdicionales(presupuestoId, EstadoId);
        }

        public Presupuestos BuscarPresupuesto(int PresupuestoId)
        {
            return Datos.BuscarPresupuesto(PresupuestoId);
        }

        public void GuardarPresupuesto(Presupuestos PresupuestoSeleccionado)
        {
            Datos.GuardarPresupuesto(PresupuestoSeleccionado);
        }

        public double CalcularValorTotalPresupuestoPorPresupuestoId(int PresupuestoId)
        {
            return Datos.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);
        }

        public List<ObtenerEventos> BuscarPrespuestosPorEventos(int EventoId)
        {
            return Datos.BuscarPrespuestosPorEventos(EventoId);
        }

        public List<PresupuestoDetalle> BuscarDetallePresupuesto(int PresupuestoId)
        {
            return DatosPresupuestoDetalle.BuscarDetallePresupuesto(PresupuestoId);
        }

        public List<PresupuestoDetalle> ObtenerPresupuestoDetalle(int presupuestoId, int unidadNegocioId, int estadoDetalleId)
        {
            return Datos.ObtenerPresupuestoDetalle(presupuestoId, unidadNegocioId, estadoDetalleId);
        }

        public virtual void AprobarPresupuesto(Eventos evento, Presupuestos presupuesto, ClientesBis cliente, List<PresupuestoDetalle> listPresupuestoDetalle, Cheques cheque)
        {
            int aprobarDetalle = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());
            int formaPagoCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosPresupuestoDetalle.EliminarPresupuestoDetalle(presupuesto.Id);

                    DatosClientes.GrabarClienteBis(cliente);

                    evento.ClienteBisId = cliente.Id;

                    if (evento.FormadePagoId == formaPagoCheque)
                    {
                        cheque.ClienteId = cliente.Id;
                        DatosCheques.GrabarChequesClientes(cheque);

                        evento.ChequeSenaId = cheque.Id;
                    }


                    DatosEventos.EditarEvento(evento);


                    Datos.EditarPresupuesto(presupuesto);



                    foreach (var item in listPresupuestoDetalle)
                    {

                        PresupuestoDetalle presu = new PresupuestoDetalle();


                        presu.PresupuestoId = presupuesto.Id;
                        presu.Cannon = item.Cannon;
                        presu.CantidadAdicional = item.CantidadAdicional;
                        presu.CantInvitadosLogistica = item.CantInvitadosLogistica;
                        presu.CodigoItem = item.CodigoItem;
                        presu.ProductoId = item.ProductoId;
                        presu.Comision = item.Comision;
                        presu.Costo = item.Costo;
                        presu.Descuentos = item.Descuentos;

                        presu.Logistica = item.Logistica;
                        presu.PorcentajeComision = item.PorcentajeComision;
                        presu.PrecioItem = item.PrecioItem;
                        presu.PrecioLista = item.PrecioLista;
                        presu.PrecioMas5 = item.PrecioMas5;
                        presu.PrecioMenos10 = item.PrecioMenos10;
                        presu.PrecioMenos5 = item.PrecioMenos5;
                        presu.PrecioSeleccionado = item.PrecioSeleccionado;
                        presu.ProductoDescripcion = item.ProductoDescripcion;

                        presu.LocacionId = item.LocacionId;
                        presu.ProveedorId = item.ProveedorId;

                        presu.ServicioId = item.ServicioId;
                        presu.TipoLogisticaId = item.TipoLogisticaId;
                        presu.UnidadNegocioId = item.UnidadNegocioId;
                        presu.ValorSeleccionado = item.ValorSeleccionado;
                        presu.UsoCocina = item.UsoCocina;
                        presu.version = item.version;


                        presu.ValorIntermediario = item.ValorIntermediario;


                        item.EstadoId = aprobarDetalle;
                        item.FechaAprobacion = System.DateTime.Now;

                        DatosPresupuestoDetalle.GuardarPresupuestoDetalle(item);

                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }
            }
        }



        public virtual void AprobarPresupuesto(Eventos evento, List<ObtenerEventosPresupuestos> ListPresupuestos,
                                                ClientesBis cliente, List<PresupuestoDetalle> ListPresupuestoDetalleAprobados,
                                                Cheques cheque, Transferencias transferencia)
        {
            int aprobarDetalle = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());
            int formaPagoCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int formaPagoTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());


            PagosClientes pagos = new PagosClientes();


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (var item in ListPresupuestos)
                    {
                        DatosPresupuestoDetalle.EliminarPresupuestoDetalle(item.PresupuestoId);
                    }


                    DatosClientes.GrabarClienteBis(cliente);

                    evento.ClienteBisId = cliente.Id;

                    if (evento.FormadePagoId == formaPagoCheque)
                    {
                        cheque.ClienteId = cliente.Id;
                        DatosCheques.GrabarChequesClientes(cheque);

                        evento.ChequeSenaId = cheque.Id;
                    }
                    else if (evento.FormadePagoId == formaPagoTransferencia)
                    {

                        transferencia.ClienteId = cliente.Id;
                        DatosTransferencias.GrabarTransferencias(transferencia);


                        evento.ComprobanteTransferencia = transferencia.Comprobante;
                        evento.ComprobanteTransferenciaExtension = transferencia.ComprobanteExtension;
                        evento.FechaComprobanteTransSenia = transferencia.FechaTransferencia;

                    }

                    DatosEventos.EditarEvento(evento);

                    foreach (var itemPresu in ListPresupuestos)
                    {
                        Datos.AprobarPresupuesto(itemPresu.PresupuestoId);


                        List<PresupuestoDetalle> list = ListPresupuestoDetalleAprobados.Where(o => o.PresupuestoId == itemPresu.PresupuestoId).ToList();


                        foreach (var itemDetalle in list)
                        {

                            PresupuestoDetalle presu = new PresupuestoDetalle();

                            presu.PresupuestoId = itemDetalle.PresupuestoId;
                            presu.Cannon = itemDetalle.Cannon;
                            presu.CantidadAdicional = itemDetalle.CantidadAdicional;
                            presu.CantInvitadosLogistica = itemDetalle.CantInvitadosLogistica;
                            presu.CodigoItem = itemDetalle.CodigoItem;
                            presu.ProductoId = itemDetalle.ProductoId;
                            presu.Comision = itemDetalle.Comision;
                            presu.Costo = itemDetalle.Costo;
                            presu.Descuentos = itemDetalle.Descuentos;
                            presu.Logistica = itemDetalle.Logistica;
                            presu.PorcentajeComision = itemDetalle.PorcentajeComision;
                            presu.PrecioItem = itemDetalle.PrecioItem;
                            presu.PrecioLista = itemDetalle.PrecioLista;
                            presu.PrecioMas5 = itemDetalle.PrecioMas5;
                            presu.PrecioMenos10 = itemDetalle.PrecioMenos10;
                            presu.PrecioMenos5 = itemDetalle.PrecioMenos5;
                            presu.PrecioSeleccionado = itemDetalle.PrecioSeleccionado;
                            presu.ProductoDescripcion = itemDetalle.ProductoDescripcion;
                            presu.LocacionId = itemDetalle.LocacionId;
                            presu.ProveedorId = itemDetalle.ProveedorId;
                            presu.ServicioId = itemDetalle.ServicioId;
                            presu.TipoLogisticaId = itemDetalle.TipoLogisticaId;
                            presu.UnidadNegocioId = itemDetalle.UnidadNegocioId;
                            presu.ValorSeleccionado = itemDetalle.ValorSeleccionado;
                            presu.UsoCocina = itemDetalle.UsoCocina;
                            presu.version = itemDetalle.version;
                            presu.ValorIntermediario = itemDetalle.ValorIntermediario;
                            presu.Comentario = itemDetalle.Comentario;
                            itemDetalle.EstadoId = aprobarDetalle;
                            itemDetalle.FechaAprobacion = System.DateTime.Now;
                            presu.AnuloCanon = itemDetalle.AnuloCanon;
                            presu.Royalty = itemDetalle.Royalty;


                            DatosPresupuestoDetalle.GuardarPresupuestoDetalle(itemDetalle);
                        }

                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }
            }
        }

        internal List<Presupuestos> BuscarPresupuestoPorCliente(int clientebisId)
        {
            return Datos.BuscarPresupuestoPorCliente(clientebisId);
        }

        public void ReservarPresupuesto(Eventos evento, Presupuestos presupuesto, ClientesBis cliente,
                                        List<PresupuestoDetalle> ListPresupuestoDetalle,
                                        Cheques cheque, Transferencias transferencia)
        {
            int aprobarDetalle = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());
            int formaPagoCheque = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoCheque"].ToString());
            int formaPagoTransferencia = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());
            int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());
            int pagoClienteEfectuado = Int32.Parse(ConfigurationManager.AppSettings["PagoClienteEfectuado"].ToString());


            PagosClientes pagos = new PagosClientes();

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosPresupuestoDetalle.EliminarPresupuestoDetalle(presupuesto.Id);

                    DatosClientes.GrabarClienteBis(cliente);

                    evento.ClienteBisId = cliente.Id;

                    double valorIndexacion = DatosIndexacion.BuscarIndexacionVigente().ValorIndexacion;

                    evento.Indexacion = valorIndexacion;

                    if (evento.FormadePagoId == formaPagoCheque)
                    {
                        cheque.ClienteId = cliente.Id;

                        DatosCheques.GrabarChequesClientes(cheque);
                    }
                    else if ((evento.FormadePagoId == formaPagoTransferencia))
                    {
                        transferencia.ClienteId = cliente.Id;

                        DatosTransferencias.GrabarTransferencias(transferencia);
                    }


                    pagos.PresupuestoId = presupuesto.Id;
                    pagos.Importe = double.Parse(evento.MontoSena.ToString());

                    pagos.FechaPago = DateTime.Parse(evento.FechaSena.ToString());

                    pagos.EmpleadoId = evento.EmpleadoId;
                    pagos.TipoMovimientoId = cuentaClientes;
                    pagos.FormadePagoId = int.Parse(evento.FormadePagoId.ToString());
                    pagos.CuentaId = evento.CuentaId;
                    pagos.EmpresaId = evento.EmpresaId;
                    pagos.Concepto = evento.Concepto;
                    pagos.NroRecibo = evento.NroRecibo;
                    pagos.TipoPago = evento.TipoPago;
                    pagos.EstadoId = pagoClienteEfectuado;

                    DatosPagoClientes.GrabarPagos(pagos);

                    DatosEventos.EditarEvento(evento);

                    Datos.EditarPresupuesto(presupuesto);


                    foreach (var item in ListPresupuestoDetalle)
                    {
                        PresupuestoDetalle presu = new PresupuestoDetalle();

                        presu.PresupuestoId = presupuesto.Id;
                        presu.Cannon = item.Cannon;
                        presu.CantidadAdicional = item.CantidadAdicional;
                        presu.CantInvitadosLogistica = item.CantInvitadosLogistica;
                        presu.CodigoItem = item.CodigoItem;
                        presu.ProductoId = item.ProductoId;
                        presu.Comision = item.Comision;
                        presu.Costo = item.Costo;
                        presu.Descuentos = item.Descuentos;
                        presu.Incremento = item.Incremento;
                        presu.EstadoProveedor = item.EstadoProveedor;

                        presu.ComentarioProveedor = item.ComentarioProveedor;

                        presu.Logistica = item.Logistica;
                        presu.PorcentajeComision = item.PorcentajeComision;
                        presu.PrecioItem = item.PrecioItem;
                        presu.PrecioLista = item.PrecioLista;
                        presu.PrecioMas5 = item.PrecioMas5;
                        presu.PrecioMenos10 = item.PrecioMenos10;
                        presu.PrecioMenos5 = item.PrecioMenos5;
                        presu.PrecioSeleccionado = item.PrecioSeleccionado;
                        presu.ProductoDescripcion = item.ProductoDescripcion;

                        presu.LocacionId = item.LocacionId;
                        presu.ProveedorId = item.ProveedorId;

                        presu.ServicioId = item.ServicioId;
                        presu.TipoLogisticaId = item.TipoLogisticaId;
                        presu.UnidadNegocioId = item.UnidadNegocioId;
                        presu.ValorSeleccionado = item.ValorSeleccionado;

                        presu.UsoCocina = item.UsoCocina;
                        presu.version = item.version;
                        presu.Comentario = item.Comentario;

                        presu.ValorIntermediario = item.ValorIntermediario;

                        presu.Royalty = item.Royalty;

                        item.EstadoId = item.EstadoId;
                        item.FechaAprobacion = item.FechaAprobacion;
                        item.FechaCreate = item.FechaCreate;

                        DatosPresupuestoDetalle.GuardarPresupuestoDetalle(item);

                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }
            }
        }

        internal List<PresupuestoDetalle> BuscarDetallePresupuestoAprobados(int PresupuestoId)
        {
            return DatosPresupuestoDetalle.BuscarDetallePresupuestoAprobados(PresupuestoId);
        }

        public void AplicarAjuste(int presupuestoDetalleId, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            Datos.AplicarAjuste(presupuestoDetalleId, TotalDescuento, TotalIncremento, Comentario);
        }

        public void AplicarAjuste(int presupuestoDetalleId, double TotalDescuento, double TotalIncremento, string Comentario, double TotalCosto)
        {
            Datos.AplicarAjuste(presupuestoDetalleId, TotalDescuento, TotalIncremento, Comentario, TotalCosto);
        }

        internal double CalcularValorTotalPresupuestoPorPresupuestoIdPendiente(int PresupuestoId)
        {
            return Datos.CalcularValorTotalPresupuestoPorPresupuestoIdPendiente(PresupuestoId);
        }

        public void EditarCantidadInvitados(Presupuestos PresupuestoSeleccionado)
        {
            Datos.EditarCantidadInvitados(PresupuestoSeleccionado);
        }

        public bool ActualizarFechaEvento(Presupuestos PresupuestoSeleccionado)
        {
            return Datos.ActualizarFechaEvento(PresupuestoSeleccionado);
        }

        public List<FechasBloqueadas> ObtenerFechasBloqueadas(DateTime fechaSeleccionada)
        {
            return Datos.ObtenerFechasBloqueadas(fechaSeleccionada);
        }

        public bool EliminarDetallePresupuesto(int Id)
        {
            return Datos.EliminarDetallePresupuesto(Id);
        }

        public CalculoIndexacion CalcularIndexacion(double indice, int presupuestoId)
        {
            return Datos.CalcularIndexacion(indice, presupuestoId);
        }

        public CalculoIndexacion CalcularIndexacionPagoaCuenta(double indice, int presupuestoId)
        {
            return Datos.CalcularIndexacionPagoaCuenta(indice, presupuestoId);
        }

        public double CalcularValorTotalPresupuestoAprobado(int PresupuestoId)
        {
            return Datos.CalcularValorTotalPresupuestoAprobado(PresupuestoId);
        }

        internal bool EliminarInvitadosPendientes(int presupuestoId)
        {
            return Datos.EliminarInvitadosPendientes(presupuestoId);
        }

        internal double CalcularValorTotalRoyaltyAprobado(int presupuestoId)
        {
            return Datos.CalcularValorTotalRoyaltyAprobado(presupuestoId);
        }
    }
}
