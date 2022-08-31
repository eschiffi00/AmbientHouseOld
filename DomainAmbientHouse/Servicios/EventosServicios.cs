using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DomainAmbientHouse.Servicios
{
    public class EventosServicios
    {
        EventosNegocios Negocio;
        PresupuestosNegocios NegociosPresupuestos;
        ClientesNegocios NegociosClientes;
        LocacionesNegocios NegociosLocaciones;
        SegmentosNegocios NegociosSegmentos;
        TipoEventosNegocios NegociosTipoEventos;
        CaracteristicasNegocios NegociosCaracteristicas;
        JornadasNegocios NegociosJornadas;
        SectoresNegocios NegociosSectores;
        TipoServiciosNegocios NegociosTipoServicios;
        TipoCateringNegocios NegociosTipoCatering;
        TipoBarrasNegocios NegociosTipoBarras;
        CategoriasNegocios NegociosCategorias;
        CostoNegocios NegociosCosto;
        ProveedoresNegocios NegociosProveedores;
        ParametrosNegocios NegociosParametros;
        EstadosNegocios NegociosEstados;
        EmpleadosNegocios NegociosEmpleados;
        AdicionalesNegocios NegociosAdicionales;
        MomentosDiasNegocios NegociosMomentosdelDia;
        CostosPaquetesCIAmbientacionNegocios NegociosCostosCIAmbientacion;

        public EventosServicios()
        {
            Negocio = new EventosNegocios();
            NegociosClientes = new ClientesNegocios();
            NegociosPresupuestos = new PresupuestosNegocios();
            NegociosLocaciones = new LocacionesNegocios();
            NegociosSegmentos = new SegmentosNegocios();
            NegociosTipoEventos = new TipoEventosNegocios();
            NegociosCaracteristicas = new CaracteristicasNegocios();
            NegociosJornadas = new JornadasNegocios();
            NegociosSectores = new SectoresNegocios();
            NegociosTipoServicios = new TipoServiciosNegocios();
            NegociosTipoCatering = new TipoCateringNegocios();
            NegociosTipoBarras = new TipoBarrasNegocios();
            NegociosCategorias = new CategoriasNegocios();
            NegociosCosto = new CostoNegocios();
            NegociosProveedores = new ProveedoresNegocios();
            NegociosParametros = new ParametrosNegocios();
            NegociosEstados = new EstadosNegocios();
            NegociosEmpleados = new EmpleadosNegocios();
            NegociosAdicionales = new AdicionalesNegocios();
            NegociosMomentosdelDia = new MomentosDiasNegocios();
            NegociosCostosCIAmbientacion = new CostosPaquetesCIAmbientacionNegocios();

        }


        public MomentosDias BuscarMomentosdelDia(int Id)
        {
            return NegociosMomentosdelDia.BuscarMomentosDias(Id);
        }

        public List<Presupuestos> BuscarEventosPorFechaYLocacion(DateTime fecha, int locacionId)
        {
            return Negocio.BuscarEventosPorFecha(fecha, locacionId);
        }

        public virtual List<ObtenerEventos> BuscarEventosPorFechaVista(DateTime fecha)
        {

            return Negocio.BuscarEventosPorFechaVista(fecha);

        }

        //public virtual List<Migrados> BuscarEventosMigradosPorFechaVista(DateTime fecha)
        //{
        //    return Negocio.BuscarEventosMigradosPorFechaVista(fecha);

        //}
        public List<Sectores> BuscarSectoresPorLocacion(int LocacionId)
        {
            return NegociosSectores.ObtenerSectoresPorLocacion(LocacionId);
        }

        public CostoCatering BuscarCostoCatering(int tipoCateringId, int cantidadInvitados, int proveedorId)
        {
            return NegociosCosto.BuscarCostoCatering(tipoCateringId, cantidadInvitados, proveedorId);
        }


        public CostoAdicionales BuscarCostoAdicionalCatering(int AdicionalId, int cantidadInvitados)
        {
            return NegociosCosto.BuscarCostoAdicionalCatering(AdicionalId, cantidadInvitados);
        }

        public CostoTecnica BuscarCostoTecnica(int tipoServicioId, int segmentoId, int anio, int mes, string dia, int proveedorId)
        {
            return NegociosCosto.BuscarCostoTecnica(tipoServicioId, segmentoId, anio, mes, dia, proveedorId);
        }

        public CostoSalones BuscarCostoSalones(int locacionId, int sectorId, int jornadaId, int anio, int mes, string dia)
        {
            return NegociosCosto.BuscarCostoSalon(locacionId, sectorId, jornadaId, anio, mes, dia);
        }

        public CostoBarra BuscarCostoBarra(int tipoBarra, int cantidadInvitados, int proveedorId)
        {
            return NegociosCosto.BuscarCostoBarra(tipoBarra, cantidadInvitados, proveedorId);
        }


        public CostoLogistica BuscarCostoLogistica(int tipoLogisticaId, int localidadId, int cantInvitados)
        {
            return NegociosCosto.BuscarCostoLogistica(tipoLogisticaId, localidadId, cantInvitados);
        }

        public CostoLogistica BuscarCostoLogistica(int tipoLogisticaId, int localidadId, int cantInvitados, int tipoEventoId)
        {
            return NegociosCosto.BuscarCostoLogistica(tipoLogisticaId, localidadId, cantInvitados, tipoEventoId);
        }
        public Parametros BuscarParametros(string valor)
        {
            return NegociosParametros.BuscarParametros(valor);
        }

        public Locaciones BuscarLocacion(int locacionId)
        {
            return NegociosLocaciones.BuscarLocaciones(locacionId);
        }

        #region Tablas Administrativas

        public List<TipoEventos> TraerTipoEvento()
        {
            return NegociosTipoEventos.ObtenerTipoEventos();
        }

        public List<Locaciones> TraerLocaciones()
        {
            return NegociosLocaciones.ObtenerLocacionesParaCotizar();
        }

        public List<Locaciones> TraerLocacionesSinPrecios()
        {
            return NegociosLocaciones.ObtenerLocacionesSinPrecios();
        }

        public List<Caracteristicas> TraerCaracteristicas()
        {
            return NegociosCaracteristicas.ObtenerCaracteristicas();
        }

        public List<Segmentos> TraerSegmentos()
        {
            return NegociosSegmentos.ObtenerSegmentos();
        }

        public List<Jornadas> TraerJornadas()
        {
            return NegociosJornadas.ObtenerJornadas();
        }

        public List<TipoServicios> TraerTipoServicios()
        {
            return NegociosTipoServicios.ObtenerTipoServicios();
        }

        public List<TipoCatering> TraerTipoCatering()
        {
            return NegociosTipoCatering.ObtenerTipoCatering();
        }

        public List<TipoCatering> TraerTipoCateringSoloActivos()
        {
            return NegociosTipoCatering.ObtenerTipoCateringSoloActivos();
        }

        public List<TipoCatering> TraerTipoCatering(int caracteristicaId, int segmentoId, int MomentoDiaId, int DuracionId)
        {
            return NegociosTipoCatering.BuscarTipoCateringPorSegmentoCaracteristicaMomendoDuracionEvento(caracteristicaId, segmentoId, MomentoDiaId, DuracionId);
        }

        public List<TiposBarras> TraerTipoBarras()
        {
            return NegociosTipoBarras.ObtenerTipoBarras();
        }

        public List<Categorias> TraerCategorias()
        {
            return NegociosCategorias.ObtenerCategorias();
        }

        public List<Proveedores> TraerProveedoresPorRubro(int unidadNegocioId)
        {
            return NegociosProveedores.BuscarProveedoresporUnidadesNegocios(unidadNegocioId);
        }
        #endregion

        public void GuardarEvento(Eventos evento, Presupuestos presupuesto)
        {
            Negocio.NuevoEvento(evento, presupuesto);
        }


        public List<Estados> BuscarEstadosEventos()
        {

            return NegociosEstados.BuscarEstadosPorEntidad("Eventos");
        }

        public virtual List<Estados> BuscarEstadosPorEntidadParaSeguimientos()
        {

            return NegociosEstados.BuscarEstadosPorEntidadParaSeguimientos("Presupuestos");

        }

        public List<Empleados> BuscarEjecutivos(int departamentoId)
        {
            return NegociosEmpleados.BuscarEmpleadosPorDepartamento(departamentoId);
        }

        public List<ObtenerEventos> BuscarEventosPorFechaClienteVista(DateTime fechaEvento, string cliente, string nroPresupuesto)
        {
            return Negocio.BuscarEventosPorFechaClienteVista(fechaEvento, cliente, nroPresupuesto);
        }

        public List<ObtenerCantidadInvitadosCatering> TraerCantidadPersonasCatering()
        {
            return Negocio.TraerCantidadPersonasCatering();
        }

        public List<ObtenerCantidadInvitadosBarras> TraerCantidadPersonasBarras()
        {
            return Negocio.TraerCantidadPersonasBarras();
        }

        public List<ObtenerEventos> BuscarEventosPorEjecutivo(int empleadoId)
        {
            return Negocio.BuscarEventosPorEjecutivo(empleadoId);
        }


        public void GrabarSeguimiento(int presupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoModificado, int empleadoId)
        {
            Negocio.GrabarSeguimiento(presupuestoId, movimientosClientes, estadoModificado, empleadoId);
        }

        public List<SeguimientosEventosClientesEstados> BuscarEventosPorEjecutivoSeguimiento(int empleadoId)
        {
            return Negocio.BuscarEventosPorEjecutivoSeguimiento(empleadoId);
        }

     

        public int BuscarUltimoPresupuestoPorEvento(int eventoId)
        {
            return Negocio.BuscarUltimoPresupuestoPorEvento(eventoId);
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservados()
        {
            return Negocio.BuscarEventosConfirmadosReservados();
        }

      

        public int BuscarClientePorEvento(int EventoId)
        {
            return Negocio.BuscarClientePorEvento(EventoId);
        }

     

        public List<ObtenerEventosPresupuestos> BuscarEventosActivosPorEjecutivoSeguimiento(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, List<ClientesPipedrive> listClientes)
        {
            return Negocio.BuscarEventosActivosPorEjecutivoSeguimiento(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, listClientes);

        }

        public List<ObtenerEventosPresupuestos> BuscarEventosConfirmadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente,string apellidonombre, string razonsocial, string fechaEvento)
        {
            return Negocio.BuscarEventosConfirmadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidonombre,razonsocial, fechaEvento);

        }

        public List<ObtenerEventosPresupuestos> BuscarEventosRealizadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string fecha)
        {
            return Negocio.BuscarEventosRealizadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente,fecha);

        }


        public List<ObtenerEventosPresupuestos> BuscarEventosReservadosPorEjecutivos(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string fechaEvento)
        {
            return Negocio.BuscarEventosReservadosPorEjecutivos(EmpleadoId, nroEvento, nroPresupuesto, nroCliente,fechaEvento);

        }


        public List<SeguimientosEventosClientesEstados> BuscarPrespuestosPorEvnetos(long EventoId)
        {
            return Negocio.BuscarPrespuestosPorEvnetos(EventoId);
        }

        public ObtenerEventos BuscarEventoPorNroEvento(int id)
        {
            return Negocio.BuscarEventoPorNroEvento(id);
        }

        public ObtenerEventos BuscarEventoPorNroPresupuesto(int id)
        {
            return Negocio.BuscarEventoPorNroPresupuesto(id);
        }

        public List<ObtenerEventos> BuscarEventosActivosPorEjecutivoSeguimiento(int EmpleadoId, int nroCliente, int nroEvento, string apellidoCliente, int nroPresupuesto)
        {

            return Negocio.BuscarEventosActivosPorEjecutivoSeguimiento(EmpleadoId, nroCliente, nroEvento, apellidoCliente, nroPresupuesto);
        }

        public List<ObtenerEventos> ObtenerEventosConfirmados()
        {
            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());

            return Negocio.ObtenerEventos(estadoConfirmado);

        }

        public List<EventosConfirmadosReservadosTODOS> EventosTodos()
        {
            return Negocio.EventosTodos();
        }

        public List<ObtenerEventos> ObtenerEventosReservados()
        {
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());

            return Negocio.ObtenerEventos(estadoReservado);

        }


        public void CambioEstadoEvento(int eventoId, int estadoId)
        {
            Negocio.CambioEstadoEvento(eventoId, estadoId);
        }


        public void GrabarSeguimiento(int PresupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoId)
        {
            Negocio.GrabarSeguimiento(PresupuestoId, movimientosClientes, estadoId);
        }

        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int empleadoId)
        {
            return Negocio.ObtenerReporteEventosPorUnidadesNegocios(empleadoId);
        }

        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {
            return Negocio.ObtenerReporteEventosPorUnidadesNegocios(nroEvento, nroPresupuesto, fechaDesde, fechaHasta);
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservadosPorFechaVista(DateTime dateTime)
        {
            return Negocio.BuscarEventosConfirmadosReservadosPorFechaVista(dateTime);
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservadosSolamente(int nroCliente, int nroPresupuesto, int nroEvento, string apellidoCliente)
        {
            return Negocio.BuscarEventosConfirmadosReservadosSolamente(nroCliente, nroPresupuesto, nroEvento, apellidoCliente);
        }

        public List<CostoCatering> ObtenerCostosCatering()
        {
            return NegociosCosto.ObtenerCostosCatering();
        }

        public List<ObtenerCantidadInvitadosCatering> TraerCantidadPersonasCateringAdicionales()
        {
            return Negocio.TraerCantidadPersonasCateringAdicionales();
        }

        public List<ObtenerEventosSeguimiento> BuscarEventosActivosPorEjecutivoProximosAVencer(int EmpleadoId)
        {
            return Negocio.BuscarEventosActivosPorEjecutivoProximosAVencer(EmpleadoId);
        }

        public void EventoPerdido(int EventoId, int estadoEventoPerdido, string comentario)
        {
            Negocio.EventoPerdido(EventoId, estadoEventoPerdido, comentario);
        }

        public List<PresupuestosAVencer> BuscarPresupuestosAvencerPorEjecutivo(int EmpleadoId)
        {
            return Negocio.BuscarPresupuestosAvencerPorEjecutivo(EmpleadoId);
        }

        public List<ObtenerEventos> BuscarEventosASeguirPorEjecutivo(int EmpleadoId)
        {
            return Negocio.BuscarEventosASeguirPorEjecutivo(EmpleadoId);
        }

        public List<ObtenerEventos> BuscarEventosPerdidosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente)
        {
            return Negocio.BuscarEventosPerdidosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente);
        }

        public TecnicaSalon BuscarTecnicaPorLocacion(int LocacionId, int SectorId)
        {
            return Negocio.BuscarTecnicaPorLocacion(LocacionId, SectorId);
        }

        public List<LocacionesValorAnio> ObtenerCostosSalonesPorAnios()
        {
            return NegociosLocaciones.ObtenerCostosSalonesPorAnios();
        }

        public LocacionesValorAnio BuscarLocacionesValorAnio(int id)
        {
            return NegociosLocaciones.BuscarLocacionesValorAnio(id);
        }

        public void NuevoLocacionesValorAnio(LocacionesValorAnio locacionesValorAnio)
        {
            NegociosLocaciones.NuevoLocacionesValorAnio(locacionesValorAnio);
        }

        public bool ObtenerLocacionesValorAnio(int anio, int locacionId)
        {
            return NegociosLocaciones.ObtenerLocacionesValorAnio(anio, locacionId);
        }

        public CostoAmbientacion BuscarCostoAmbientacion(int categoriaId, int cantInvitadosCosto, int proveedorId)
        {
            return NegociosCosto.BuscarCostoAmbientacion(categoriaId, cantInvitadosCosto, proveedorId);
        }

        public List<CostoBarra> ObtenerCostoBarras()
        {
            return NegociosCosto.ObtenerCostoBarras();
        }

        public List<CostoTecnica> ObtenerCostosTecnica()
        {
            return NegociosCosto.ObtenerCostoTecnica();
        }

        public List<CostoAmbientacion> ObtenerCostosAmbientacion()
        {
            return NegociosCosto.ObtenerCostosAmbientacion();
        }

        public List<CostoAdicionales> ObtenerCostosAdicionales()
        {
            return NegociosCosto.ObtenerCostosAdicionales();
        }

        public List<Proveedores> ObtenerProveedoresCotizador()
        {
            return NegociosProveedores.ObtenerProveedoresCotizador();
        }

        public List<CostoLogistica> ObtenerCostosLogisticas(int tipoLogisticaId, int localidadId, string cantidadInvitadoId, int tipoEventoId)
        {
            return NegociosCosto.ObtenerCostosLogisticas(tipoLogisticaId, localidadId, cantidadInvitadoId, tipoEventoId);
        }

        public Eventos BuscarEvento(int EventoId)
        {
            return Negocio.BuscarEvento(EventoId);
        }

        public Presupuestos BuscarPresupuesto(int PresupuestoId)
        {
            return NegociosPresupuestos.BuscarPresupuesto(PresupuestoId);
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosGuardadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, List<ClientesPipedrive> listClientes)
        {
            return Negocio.BuscarEventosGuardadosPorEjecutivo(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, listClientes);
        }

        public void GuardarEvento(Eventos EventoSeleccionado)
        {
            Negocio.GuardarEvento(EventoSeleccionado);
        }

        public void GuardarPresupuesto(Presupuestos PresupuestoSeleccionado)
        {
            NegociosPresupuestos.GuardarPresupuesto(PresupuestoSeleccionado);
        }

        public CostosPaquetesCIAmbientacion BuscarPreciosCostosPaquetesCIAmbientacion(int paqueteId, int caracteristicaId, 
                                                                                        int segmentoId, int proveedorId,
                                                                                        int cantidadPaquetes,int semestre, int anio)
        {
            return NegociosCostosCIAmbientacion.BuscarPreciosPaquetesCIAmbientacion(paqueteId,caracteristicaId,segmentoId,proveedorId,cantidadPaquetes,semestre,anio);
        }

        public List<CostoCanon> ObtenerCostosCanon()
        {
            return NegociosCosto.ObtenerCostosCanon();
        }

        public CostoCanon BuscarCostoCanon(int segmentoId, int caracteriticaId, int TipoCateringId)
        {
            return NegociosCosto.BuscarCostoCanon(segmentoId, caracteriticaId, TipoCateringId);
        }

        public List<ObtenerEventos> BuscarPrespuestosPorEventos(int EventoId)
        {
            return NegociosPresupuestos.BuscarPrespuestosPorEventos(EventoId);
        }

        public List<TipoServicios> TraerTipoServicios(int CaracteristicasId, int SegmentosId, int MomentoDiaId, int DuracionId)
        {
            return NegociosTipoServicios.TraerTipoServicios(CaracteristicasId, SegmentosId, MomentoDiaId, DuracionId);
        }

        public void GuardarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle)
        {
            Negocio.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle);
        }

        public List<Proveedores> TraerProveedores(List<int> list)
        {
            return NegociosProveedores.TraerProveedores(list);
        }

        public Adicionales BuscarAdicional(int adicionalId)
        {
            return NegociosAdicionales.BuscarAdicional(adicionalId);
        }

        public void AprobarPresupuesto(Eventos evento, Presupuestos presupuesto, ClientesBis cliente, List<PresupuestoDetalle> listPresupuestoDetalle, Cheques cheque)
        {
            NegociosPresupuestos.AprobarPresupuesto(evento, presupuesto, cliente, listPresupuestoDetalle, cheque);
        }

        public List<CostoSalones> ObtenerCostoSalones()
        {
            return NegociosCosto.ObtenerCostoSalones();
        }

        public List<TiposBarras> BuscarTipoBarrasPorSegmento(int segmentoId, int duracionId)
        {
            return NegociosTipoBarras.BuscarTipoBarrasPorSegmento(segmentoId, duracionId);
        }

        public ObtenerEventosPresupuestos BuscarPresupuestoParaAprobar(int PresupuestoId)
        {
            return Negocio.BuscarPresupuestoParaAprobar(PresupuestoId);
        }

        public void ReservarPresupuesto(Eventos evento, Presupuestos presupuesto, ClientesBis cliente, List<PresupuestoDetalle> ListPresupuestoDetalle, Cheques cheque, Transferencias transferencia)
        {
            NegociosPresupuestos.ReservarPresupuesto(evento, presupuesto, cliente, ListPresupuestoDetalle, cheque, transferencia);
        }

        public List<Locaciones> ObtenerLocacionesParaCotizar()
        {
            return NegociosLocaciones.ObtenerLocacionesParaCotizar();
        }

        public List<Locaciones> ObtenerLocaciones(int usuario)
        {
            return NegociosLocaciones.ObtenerLocaciones(usuario);
        }


        public AmbientacionSalon BuscarAmbientacionPorLocacion(int LocacionId, int SectorId)
        {
            return Negocio.BuscarAmbientacionPorLocacion(LocacionId, SectorId);
        }

        public List<Locaciones> ObtenerLocacionesOUT()
        {
            return NegociosLocaciones.ObtenerLocacionesOUT();
        }

        public CostoLogistica BuscarCostoLogistica(int id)
        {
            return NegociosCosto.BuscarCostoLogistica(id);
        }

        public void ActualizarCostoLogistica(CostoLogistica costos)
        {
            NegociosCosto.ActualizarCostoLogistica(costos);
        }

        public void GrabarProveedoresAmbientacion(int sectorId, List<AmbientacionSalon> ListAmbientacionSalon)
        {
            NegociosProveedores.GrabarProveedoresAmbientacion(sectorId, ListAmbientacionSalon);
        }

        public List<AmbientacionSalon> ObtenerProveedorAmbientacionPorLocacionSector(int LocacionId, int sectorId)
        {
            return NegociosProveedores.ObtenerProveedorAmbientacionPorLocacionSector(LocacionId, sectorId);
        }

        public List<TecnicaSalon> ObtenerProveedorTecnicaPorLocacionSector(int LocacionId, int sectorId)
        {
            return NegociosProveedores.ObtenerProveedorTecnicaPorLocacionSector(LocacionId, sectorId);
        }

        public List<ObtenerEventosPresupuestosProveedores> BuscarEventosConfirmadosProveedoresExternos(int nropresupuesto, string fechaDesde, string fechaHasta, int unidadNegocioId)
        {
            return Negocio.BuscarEventosConfirmadosProveedoresExternos( nropresupuesto,  fechaDesde,  fechaHasta,  unidadNegocioId);

        }

        public void RePresupuestarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalleModificado)
        {
            Negocio.RePresupuestarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado,
                ListPresupuestoDetalleModificado);
        }

        public List<ObtenerEventosPresupuestos> BuscarEventos(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, string fechaEvento)
        {
            return Negocio.BuscarEventos(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, fechaEvento);
        }

        public void GuardarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle, List<PresupuestoDetalle> ListPresupuestoDetalleCambios, List<PresupuestoDetalle> ListPresupuestoDetalleQuitados)
        {
            Negocio.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle, ListPresupuestoDetalleCambios, ListPresupuestoDetalleQuitados);
        }

        public void GuardarPresupuesto(Eventos EventoSeleccionado, Presupuestos PresupuestoSeleccionado, List<PresupuestoDetalle> ListPresupuestoDetalle, int estadoAprobadoItem, DateTime fechaAprobacion)
        {
            Negocio.GuardarPresupuesto(EventoSeleccionado, PresupuestoSeleccionado, ListPresupuestoDetalle, estadoAprobadoItem,fechaAprobacion);
        }

        public void AprobarPresupuesto(Eventos evento, List<ObtenerEventosPresupuestos> ListPresupuestos, ClientesBis cliente, List<PresupuestoDetalle> ListPresupuestoDetalleAprobados, Cheques cheque, Transferencias transferencia)
        {
            NegociosPresupuestos.AprobarPresupuesto(evento, ListPresupuestos, cliente, ListPresupuestoDetalleAprobados, cheque, transferencia);
        }

        public Sectores BuscarSector(int sectorId)
        {
            return NegociosSectores.BuscarSector(sectorId);
        }

        public OrganizacionPresupuestoDetalle BuscarOrganizacionDetalle(int id)
        {
            return Negocio.BuscarOrganizacionDetalle(id);
        }

        public OrganizacionPresupuestoDetalle BuscarOrganizacionDetallePorPresupuesto(int PresupuestoId)
        {
            return Negocio.BuscarOrganizacionDetallePorPresupuesto(PresupuestoId);
        }

        public void GrabarOrganizacionPresupuestoDetalle(OrganizacionPresupuestoDetalle detalle)
        {
            Negocio.GrabarOrganizacionPresupuestoDetalle(detalle);
        }

        public List<Locaciones> ObtenerLocacionesParaCotizarPorLocacion(int localidadId, string tieneVerde, string estacionamiento, string aireLibre)
        {
            LocacionesNegocios negocios = new LocacionesNegocios();

            return negocios.ObtenerLocacionesParaCotizarPorLocacion(localidadId,tieneVerde,  estacionamiento,  aireLibre);
        }

        public DuracionEvento BuscarDuracionEvento(int Id)
        {
            DuracionEventoNegocios negocio = new DuracionEventoNegocios();

            return negocio.BuscarDuracion(Id);
        }

        public void BuscarEventosTable(int eventoId, int presupuestoId, HtmlTable _retorno)
        {


            Eventos evento = Negocio.BuscarEvento(eventoId);

            if (evento == null)
                return ;

            Presupuestos presupuesto = NegociosPresupuestos.BuscarPresupuesto(presupuestoId);

            if (presupuesto == null)
                return;

            _retorno.Rows.Add(AddFilaEvento("Cliente", "Contacto CRM",
                                evento.ClienteBisId.ToString(),
                                evento.ClienteId.ToString()));

            _retorno.Rows.Add(AddFilaEvento("Nro Evento", "Nro Presupuesto",
                                evento.NroEvento,
                                presupuesto.NroPresupuesto));

            _retorno.Rows.Add(AddFilaEvento("Tipo Evento", "Momento del Dia",
                                this.TraerTipoEvento().Where(o => o.Id == presupuesto.TipoEventoId).FirstOrDefault().Descripcion,
                                this.BuscarMomentosdelDia((int)presupuesto.MomentoDiaID).Descripcion));

            _retorno.Rows.Add(AddFilaEvento("Caracteristicas", "Jornadas",
                                this.TraerCaracteristicas().Where(o => o.Id == presupuesto.CaracteristicaId).FirstOrDefault().Descripcion,
                                this.TraerJornadas().Where(o => o.Id == presupuesto.JornadaId).FirstOrDefault().Descripcion));

            _retorno.Rows.Add(AddFilaEvento("Segmentos", "Duracion del Evento",
                                this.TraerSegmentos().Where(o => o.Id == presupuesto.SegmentoId).FirstOrDefault().Descripcion,
                                this.BuscarDuracionEvento((int) presupuesto.DuracionId).Descripcion));

            _retorno.Rows.Add(AddFilaEvento("Locacion", "Sector",
                                this.TraerLocaciones().Where(o => o.Id == presupuesto.LocacionId).FirstOrDefault().Descripcion, 
                                this.BuscarSector((int)presupuesto.SectorId).Descripcion));

            _retorno.Rows.Add(AddFilaEvento("Fecha Evento", "Ejecutivo",
                                String.Format("{0:dd/MM/yyyy}", presupuesto.FechaEvento), 
                                NegociosEmpleados.BuscarEmpleado(evento.EmpleadoId).ApellidoNombre));

            _retorno.Rows.Add(AddFilaEvento("Cant. Mayores", "Cant. Adolescentes",
                                presupuesto.CantidadInicialInvitados.ToString(),
                                (presupuesto.CantidadInvitadosAdolecentes == null? "0": presupuesto.CantidadInvitadosAdolecentes.ToString())));

            _retorno.Rows.Add(AddFilaEvento("Cant. entre 3 y 8", "Cant. Menores de 3",
                                (presupuesto.CantidadInvitadosMenores3y8 == null ? "0" : presupuesto.CantidadInvitadosMenores3y8.ToString()),
                                (presupuesto.CantidadInvitadosMenores3 == null ? "0" : presupuesto.CantidadInvitadosMenores3.ToString())));

            _retorno.Rows.Add(AddFilaEvento("Hora Inicio", "Hora Fin",
                                presupuesto.HorarioEvento,
                                presupuesto.HoraFinalizado));



        }

        private HtmlTableRow AddFilaEvento(string descripcion1, string descripcion2, string contenido1, string contenido2)
        {
            HtmlTableRow fila = new HtmlTableRow();

            

            HtmlTableCell celda10 = new HtmlTableCell();

            Label lbl = new Label();


            lbl.CssClass = "form-control";

            lbl.Attributes.Add("class", "alert alert-secondary");

            lbl.Text = descripcion1 + ": <b>" + contenido1 + "</b>";

            celda10.Controls.Add(lbl);

            HtmlTableCell celda11 = new HtmlTableCell();
            celda11.InnerText = "";

            HtmlTableCell celda12 = new HtmlTableCell();

            Label lbl1 = new Label();


            lbl1.CssClass = "form-control";

            lbl1.Text = descripcion2 +  ": <b>" + contenido2 + "</b>";

            celda12.Controls.Add(lbl1);

            fila.Cells.Add(celda10);
            fila.Cells.Add(celda11);
            fila.Cells.Add(celda12);

            return fila;
        
        }

        public List<ObtenerEventosPresupuestosProveedores> BuscarProveedoresEstadosEventosConfirmados(int nropresupuesto, string fechaeventodesde, string fechaeventohasta, int unidadnegocioId, string estadoProveedor, int proveedorId)
        {
            return Negocio.BuscarProveedoresEstadosEventosConfirmados(nropresupuesto, fechaeventodesde, fechaeventohasta, unidadnegocioId, estadoProveedor, proveedorId);
        }


        public List<ListadoProveedoresAsociados_Result> ListadoProveedoresAsociados(SearcherReporteProveedoresAsociados searcher)
        {
            return Negocio.ListadoProveedoresAsociados(searcher);
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosARevisar()
        {
            return Negocio.ListarEventosARevisar();
        }
    }
}
