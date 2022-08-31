using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Configuration;

namespace DomainAmbientHouse.Negocios
{
    public class EventosNegocios
    {

        EventosDatos Datos;
        CostosDatos DatosCostos;
        PresupuestosDatos DatosPresupuestos;
        AdicionalesDatos DatosAdicionales;
        ParametrosDatos DatosParametros;
        PresupuestoDetalleDatos DatosPresupuestoDetalle;

        public EventosNegocios()
        {
            Datos = new EventosDatos();
            DatosCostos = new CostosDatos();
            DatosPresupuestos = new PresupuestosDatos();
            DatosAdicionales = new AdicionalesDatos();
            DatosParametros = new ParametrosDatos();
            DatosPresupuestoDetalle = new PresupuestoDetalleDatos();
        }
        
        public virtual List<Presupuestos> BuscarEventosPorFecha(DateTime fecha, int locacionId)
        {

            return Datos.BuscarEventosPorFecha(fecha, locacionId);

        }

        public void NuevoEvento(Eventos evento, Presupuestos presupuesto)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.NuevoEvento(evento);

                    presupuesto.EventoId = evento.Id;

                    Datos.NuevoPresupuesto(presupuesto);

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<ObtenerEventos> BuscarEventosPorFechaVista(DateTime fecha)
        {
            return Datos.BuscarEventosPorFechaVista(fecha);
        }

        public List<ObtenerEventos> BuscarEventosPorFechaClienteVista(DateTime fechaEvento, string cliente, string nroPresupuesto)
        {
            return Datos.BuscarEventosPorFechaClienteVista(fechaEvento, cliente, nroPresupuesto);
        }

        public List<ObtenerEventos> BuscarEventosPorCliente(int clienteId)
        {
            return Datos.BuscarEventosPorCliente(clienteId);
        }

        public List<ObtenerCantidadInvitadosCatering> TraerCantidadPersonasCatering()
        {
            return Datos.TraerCantidadPersonasCatering();
        }

        public List<ObtenerCantidadInvitadosBarras> TraerCantidadPersonasBarras()
        {
            return Datos.TraerCantidadPersonasBarras();
        }

        public List<ObtenerEventos> BuscarEventosPorEjecutivo(int empleadoId)
        {
            return Datos.BuscarEventosPorEjecutivo(empleadoId);
        }

        //public void EditarEvento(Eventos evento, Presupuestos presupuesto)
        //{
        //    Datos.EditarEvento(evento, presupuesto);
        //}

        public void GrabarSeguimiento(int presupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoModificado, int empleadoId)
        {
            Datos.GrabarSeguimiento(presupuestoId, movimientosClientes, estadoModificado, empleadoId);
        }

        public List<SeguimientosEventosClientesEstados> BuscarEventosPorEjecutivoSeguimiento(int empleadoId)
        {
            return Datos.BuscarEventosPorEjecutivoSeguimiento(empleadoId);
        }

        //public void GrabarSeguimientoyAlerta(int presupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoModificado, Alertas alertas, int empleadoId)
        //{
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        try
        //        {

        //            Datos.GrabarSeguimientoyAlerta(presupuestoId, movimientosClientes, estadoModificado, alertas, empleadoId);
        //            scope.Complete();

        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}

        public int BuscarUltimoPresupuestoPorEvento(int eventoId)
        {
            return Datos.BuscarUltimoPresupuestoPorEvento(eventoId);
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservados()
        {
            return Datos.BuscarEventosConfirmadosReservados();
        }

        public int BuscarClientePorEvento(int EventoId)
        {
            return Datos.BuscarClientePorEvento(EventoId);
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosActivosPorEjecutivoSeguimiento(int EmpleadoId,int nroEvento,int nroPresupuesto, int nroCliente,string apellidoynombre,string razonsocial, List<ClientesPipedrive> listClientes)
        {
            return Datos.BuscarEventosActivosPorEjecutivoSeguimiento(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, listClientes);
        }

        public List<SeguimientosEventosClientesEstados> BuscarPrespuestosPorEvnetos(long EventoId)
        {
            return Datos.BuscarPrespuestosPorEvnetos(EventoId);
        }

        public ObtenerEventos BuscarEventoPorNroEvento(int id)
        {
            return Datos.BuscarEventoPorNroEvento(id);
        }

        public ObtenerEventos BuscarEventoPorNroPresupuesto(int id)
        {
            return Datos.BuscarEventoPorNroPresupuesto(id);
        }

        public List<ObtenerEventos> BuscarEventosActivosPorEjecutivoSeguimiento(int EmpleadoId, int nroCliente, int nroEvento, string apellidoCliente, int nroPresupuesto)
        {
            return Datos.BuscarEventosActivosPorEjecutivoSeguimiento(EmpleadoId, nroCliente, nroEvento, apellidoCliente, nroPresupuesto);
        }

        public List<ObtenerEventos> ObtenerEventos(int estado)
        {
            return Datos.ObtenerEventos(estado);
        }

        public void CambioEstadoEvento(int eventoId, int estadoId)
        {
            Datos.CambioEstadoEvento(eventoId, estadoId);
        }

        //public void GrabarSeguimientoyAlerta(int PresupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoId, Alertas alertas)
        //{
        //    Datos.GrabarSeguimientoyAlerta(PresupuestoId, movimientosClientes, estadoId, alertas);
        //}

        public void GrabarSeguimiento(int PresupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoId)
        {
            Datos.GrabarSeguimiento(PresupuestoId, movimientosClientes, estadoId);
        }

        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int empleadoId)
        {
            return Datos.ObtenerReporteEventosPorUnidadesNegocios(empleadoId);
        }

        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int nroEvento,int nroPresupuesto,  string fechaDesde, string fechaHasta)
        {
            return Datos.ObtenerReporteEventosPorUnidadesNegocios( nroEvento,  nroPresupuesto,  fechaDesde,  fechaHasta);
        
        }

        public List<Entidades.ObtenerEventos> BuscarEventosConfirmadosReservadosPorFechaVista(DateTime dateTime)
        {
            return Datos.BuscarEventosConfirmadosReservadosPorFechaVista(dateTime);
        }

        public List<Entidades.ObtenerEventos> BuscarEventosConfirmadosReservadosSolamente(int nroCliente, int nroPresupuesto, int nroEvento, string apellidoCliente)
        {
            return Datos.BuscarEventosConfirmadosReservadosSolamente(nroCliente, nroPresupuesto, nroEvento, apellidoCliente);
        }

        public List<ObtenerCantidadInvitadosCatering> TraerCantidadPersonasCateringAdicionales()
        {
            return Datos.TraerCantidadPersonasCateringAdicionales();
        }

        public List<ObtenerEventosSeguimiento> BuscarEventosActivosPorEjecutivoProximosAVencer(int EmpleadoId)
        {
            return Datos.BuscarEventosActivosPorEjecutivoProximosAVencer(EmpleadoId);
        }

        public void EventoPerdido(int EventoId, int estadoEventoPerdido, string comentario)
        {
            Datos.EventoPerdido(EventoId, estadoEventoPerdido, comentario);
        }

        public List<PresupuestosAVencer> BuscarPresupuestosAvencerPorEjecutivo(int EmpleadoId)
        {
            return Datos.BuscarPresupuestosAvencerPorEjecutivo(EmpleadoId);
        }

        public List<Entidades.ObtenerEventos> BuscarEventosASeguirPorEjecutivo(int EmpleadoId)
        {
            return Datos.BuscarEventosASeguirPorEjecutivo(EmpleadoId);
        }

        private static void GenerarNuevoPresupuesto(int estadoPresupuestoEnviadoalCliente, Presupuestos OldPresu, Presupuestos NewPresu)
        {
            NewPresu.EventoId = OldPresu.EventoId;
            NewPresu.CantidadInicialInvitados = OldPresu.CantidadInicialInvitados;
            NewPresu.CantidadInvitadosAdolecentes = OldPresu.CantidadInvitadosAdolecentes;
            NewPresu.CantidadInvitadosMenores3 = OldPresu.CantidadInvitadosMenores3;
            NewPresu.CantidadInvitadosMenores3y8 = OldPresu.CantidadInvitadosMenores3y8;
            NewPresu.CaracteristicaId = OldPresu.CaracteristicaId;
            NewPresu.SegmentoId = OldPresu.SegmentoId;
            NewPresu.TipoEventoId = OldPresu.TipoEventoId;
            NewPresu.PresupuestoIdAnterior = OldPresu.Id;
            NewPresu.TipoEventoOtro = OldPresu.TipoEventoOtro;
            NewPresu.SectorId = OldPresu.SectorId;
            NewPresu.LocacionId = OldPresu.LocacionId;
            NewPresu.LocacionOtra = OldPresu.LocacionOtra;
            NewPresu.JornadaId = OldPresu.JornadaId;

            NewPresu.HoraFinalizado = OldPresu.HoraFinalizado;
            NewPresu.HorarioArmado = OldPresu.HorarioArmado;
            NewPresu.HorarioEvento = OldPresu.HorarioEvento;
            NewPresu.FechaEvento = OldPresu.FechaEvento;
            NewPresu.FechaPresupuesto = System.DateTime.Now;
            NewPresu.EstadoId = estadoPresupuestoEnviadoalCliente;
        }

        public List<Entidades.ObtenerEventosPresupuestos> BuscarEventosConfirmadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente,string apellidonombre, string razonsocial, string fechaEvento)
        {
            return Datos.BuscarEventosConfirmadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente,apellidonombre, razonsocial,fechaEvento);
        }

        public List<Entidades.ObtenerEventosPresupuestos> BuscarEventosReservadosPorEjecutivos(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string fechaEvento)
        {
            return Datos.BuscarEventosReservadosPorEjecutivos(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, fechaEvento);
        }

        public List<Entidades.ObtenerEventos> BuscarEventosPerdidosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente)
        {
            return Datos.BuscarEventosPerdidosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente);
        }

        public TecnicaSalon BuscarTecnicaPorLocacion(int LocacionId , int SectorId)
        {
            return Datos.BuscarTecnicaPorLocacion(LocacionId, SectorId);
        }

        public Eventos BuscarEvento(int EventoId)
        {
            return Datos.BuscarEvento(EventoId);
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosGuardadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente,string apellidoynombre,string razonsocial, List<ClientesPipedrive> listClientes)
        {
            return Datos.BuscarEventosGuardadosPorEjecutivoSeguimiento(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, listClientes);
        }

        public List<ObtenerEventosPresupuestos> BuscarEventos(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, string fechaEvento)
        {
            return Datos.BuscarEventos(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, fechaEvento);
        }

        public void GuardarEvento(Eventos EventoSeleccionado)
        {
            Datos.GuardarEvento(EventoSeleccionado);
        }

        public void GuardarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle)
        {
            int UnidadNegocioSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosPresupuestoDetalle.EliminarPresupuestoDetalle(PresupuestoSeleccionado.Id);

                    Datos.GuardarEvento(EventoSeleccionado);

                    PresupuestoSeleccionado.EventoId = EventoSeleccionado.Id;

                    DatosPresupuestos.GuardarPresupuesto(PresupuestoSeleccionado);

                    foreach (var item in ListPresupuestoDetalle)
                    {

                        PresupuestoDetalle presu = new PresupuestoDetalle();

                        presu.PresupuestoId = PresupuestoSeleccionado.Id;
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
                        presu.EstadoId = item.EstadoId;
                        presu.FechaAprobacion = item.FechaAprobacion;
                        presu.ValorIntermediario = item.ValorIntermediario;
                        presu.AnuloCanon = item.AnuloCanon;
                        presu.CostoMesas = item.CostoMesas;
                        presu.CostoSillas = item.CostoSillas;
                        presu.PrecioMesas = item.PrecioMesas;
                        presu.PrecioSillas = item.PrecioSillas;
                        presu.Royalty = item.Royalty;

                        DatosPresupuestoDetalle.GuardarPresupuestoDetalle(presu);

                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {

                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }
            
            }
        }

        public void RePresupuestarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle)
        {
            int UnidadNegocioSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    

                    Datos.GuardarEvento(EventoSeleccionado);

                    PresupuestoSeleccionado.EventoId = EventoSeleccionado.Id;

                    DatosPresupuestos.GuardarPresupuesto(PresupuestoSeleccionado);

                    foreach (var item in ListPresupuestoDetalle)
                    {

                        PresupuestoDetalle presu = new PresupuestoDetalle();


                        presu.PresupuestoId = PresupuestoSeleccionado.Id;
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
                        presu.EstadoId = item.EstadoId;
                        presu.FechaAprobacion = item.FechaAprobacion;
                        presu.ValorIntermediario = item.ValorIntermediario;
                        presu.Incremento = item.Incremento;
                        presu.Descuentos = item.Descuentos;

                        DatosPresupuestoDetalle.GuardarPresupuestoDetalle(presu);

                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {

                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }

            }
        }

        public ObtenerEventosPresupuestos BuscarPresupuestoParaAprobar(int PresupuestoId)
        {
            return Datos.BuscarPresupuestoParaAprobar(PresupuestoId);
        }

        public AmbientacionSalon BuscarAmbientacionPorLocacion(int LocacionId, int SectorId)
        {
            return Datos.BuscarAmbientacionPorLocacion(LocacionId, SectorId);
        }

        public List<EventosConfirmadosReservadosTODOS> EventosTodos()
        {
            return Datos.EventosTodos();
        }

        public List<ObtenerEventosPresupuestosProveedores> BuscarEventosConfirmadosProveedoresExternos(int nropresupuesto, string fechaDesde, string fechaHasta, int unidadNegocioId)
        {
            return Datos.BuscarEventosConfirmadosProveedoresExternos( nropresupuesto,  fechaDesde,  fechaHasta,  unidadNegocioId);
        }

        public void GuardarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle, List<PresupuestoDetalle> ListPresupuestoDetalleCambios, List<PresupuestoDetalle> ListPresupuestoDetalleQuitados)
        {
            int UnidadNegocioSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            int EstadoItemPendiente = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosPresupuestoDetalle.EliminarPresupuestoDetalle(ListPresupuestoDetalleQuitados);

                    Datos.GuardarEvento(EventoSeleccionado);

                    PresupuestoSeleccionado.EventoId = EventoSeleccionado.Id;

                    DatosPresupuestos.GuardarPresupuesto(PresupuestoSeleccionado);

                    foreach (var item in ListPresupuestoDetalleCambios)
                    {

                        PresupuestoDetalle presu = new PresupuestoDetalle();

                        presu.PresupuestoId = PresupuestoSeleccionado.Id;
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
                        presu.EstadoId = EstadoItemPendiente;
                        presu.ValorIntermediario = item.ValorIntermediario;
                        presu.AnuloCanon = item.AnuloCanon;

                        DatosPresupuestoDetalle.GuardarPresupuestoDetalle(presu);

                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {

                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }

            }
        }

        public void GuardarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle, int estadoAprobadoItem, DateTime fechaAprobacion)
        {
            int UnidadNegocioSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosPresupuestoDetalle.EliminarPresupuestoDetalle(PresupuestoSeleccionado.Id);

                    Datos.GuardarEvento(EventoSeleccionado);

                    PresupuestoSeleccionado.EventoId = EventoSeleccionado.Id;

                    DatosPresupuestos.GuardarPresupuesto(PresupuestoSeleccionado);

                    foreach (var item in ListPresupuestoDetalle)
                    {

                        PresupuestoDetalle presu = new PresupuestoDetalle();

                        presu.PresupuestoId = PresupuestoSeleccionado.Id;
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
                        presu.EstadoId = estadoAprobadoItem;
                        presu.FechaAprobacion = fechaAprobacion;
                        presu.ValorIntermediario = item.ValorIntermediario;

                        DatosPresupuestoDetalle.GuardarPresupuestoDetalle(presu);

                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {

                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                }

            }
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosRealizadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string fecha)
        {
            return Datos.BuscarEventosRealizadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente,fecha);
        }

        public OrganizacionPresupuestoDetalle BuscarOrganizacionDetalle(int id)
        {
            return Datos.BuscarOrganizacionDetalle(id);
        }

        public OrganizacionPresupuestoDetalle BuscarOrganizacionDetallePorPresupuesto(int PresupuestoId)
        {
            return Datos.BuscarOrganizacionDetallePorPresupuesto(PresupuestoId);
        }

        public void GrabarOrganizacionPresupuestoDetalle(OrganizacionPresupuestoDetalle detalle)
        {
            Datos.GrabarOrganizacionPresupuestoDetalle(detalle);
        }

        internal List<ObtenerEventosPresupuestosProveedores> BuscarProveedoresEstadosEventosConfirmados(int nropresupuesto, string fechaeventodesde, string fechaeventohasta, int unidadnegocioId, string estadoProveedor, int proveedorId)
        {
            return Datos.BuscarProveedoresEstadosEventosConfirmados(nropresupuesto, fechaeventodesde, fechaeventohasta, unidadnegocioId, estadoProveedor, proveedorId);
        }

        internal List<ResponsablesEventos> ListarResponsablesEventos(ResponsablesSearcher searcher)
        {
            return Datos.ListarResponsablesEventos(searcher);
        }

        internal List<ListadoProveedoresAsociados_Result> ListadoProveedoresAsociados(SearcherReporteProveedoresAsociados searcher)
        {
            return Datos.ListarProveedoresAsociados(searcher);
        }

        internal List<ObtenerEventosPresupuestos> ListarEventosARevisar()
        {
            return Datos.ListarEventosARevisar();
        }
    }
}
