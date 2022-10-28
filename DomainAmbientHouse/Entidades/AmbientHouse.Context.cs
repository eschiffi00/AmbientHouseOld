﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AmbientHouseEntities : DbContext
    {
        public AmbientHouseEntities()
            : base("name=AmbientHouseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Adicionales> Adicionales { get; set; }
        public DbSet<AdicionalesItems> AdicionalesItems { get; set; }
        public DbSet<AmbientacionCI> AmbientacionCI { get; set; }
        public DbSet<AmbientacionSalon> AmbientacionSalon { get; set; }
        public DbSet<Bancos> Bancos { get; set; }
        public DbSet<Bloqueo> Bloqueo { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<CategoriasArchivos> CategoriasArchivos { get; set; }
        public DbSet<CategoriasItem> CategoriasItem { get; set; }
        public DbSet<CentroCostos> CentroCostos { get; set; }
        public DbSet<Cheques> Cheques { get; set; }
        public DbSet<ChequesPagosProveedores> ChequesPagosProveedores { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<ClientesBis> ClientesBis { get; set; }
        public DbSet<ClientesEventosMovimientos> ClientesEventosMovimientos { get; set; }
        public DbSet<ClientesPrueba> ClientesPrueba { get; set; }
        public DbSet<CodigoPorRubro> CodigoPorRubro { get; set; }
        public DbSet<Comisiones> Comisiones { get; set; }
        public DbSet<ComprobantePagoProveedor> ComprobantePagoProveedor { get; set; }
        public DbSet<ComprobantesPagados> ComprobantesPagados { get; set; }
        public DbSet<ComprobantesProveedores> ComprobantesProveedores { get; set; }
        public DbSet<ComprobantesProveedores_Detalles> ComprobantesProveedores_Detalles { get; set; }
        public DbSet<CondicionIva> CondicionIva { get; set; }
        public DbSet<ConfiguracionCateringTecnica> ConfiguracionCateringTecnica { get; set; }
        public DbSet<ConversionMonedas> ConversionMonedas { get; set; }
        public DbSet<CostoAdicionales> CostoAdicionales { get; set; }
        public DbSet<CostoAmbientacion> CostoAmbientacion { get; set; }
        public DbSet<CostoBarra> CostoBarra { get; set; }
        public DbSet<CostoCanon> CostoCanon { get; set; }
        public DbSet<CostoCatering> CostoCatering { get; set; }
        public DbSet<CostoLogistica> CostoLogistica { get; set; }
        public DbSet<CostoSalones> CostoSalones { get; set; }
        public DbSet<CostosPaquetesCIAmbientacion> CostosPaquetesCIAmbientacion { get; set; }
        public DbSet<CostoTecnica> CostoTecnica { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Cuentas_Log> Cuentas_Log { get; set; }
        public DbSet<Degustacion> Degustacion { get; set; }
        public DbSet<DegustacionDetalle> DegustacionDetalle { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<DuracionEvento> DuracionEvento { get; set; }
        public DbSet<EjecucionTareasProgramadas> EjecucionTareasProgramadas { get; set; }
        public DbSet<EmpleadoDepartamentos> EmpleadoDepartamentos { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<EmpleadosPresupuestosAprobados> EmpleadosPresupuestosAprobados { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<FacturaClienteDetalle> FacturaClienteDetalle { get; set; }
        public DbSet<FacturasCliente> FacturasCliente { get; set; }
        public DbSet<Familias> Familias { get; set; }
        public DbSet<FechasBloqueadas> FechasBloqueadas { get; set; }
        public DbSet<Feriados> Feriados { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<FormasdePago> FormasdePago { get; set; }
        public DbSet<GruposItems> GruposItems { get; set; }
        public DbSet<Herramientas> Herramientas { get; set; }
        public DbSet<Impuestos> Impuestos { get; set; }
        public DbSet<Indexacion> Indexacion { get; set; }
        public DbSet<Intermediarios> Intermediarios { get; set; }
        public DbSet<INVENTARIO_Depositos> INVENTARIO_Depositos { get; set; }
        public DbSet<INVENTARIO_Movimiento_Producto> INVENTARIO_Movimiento_Producto { get; set; }
        public DbSet<INVENTARIO_Pedido> INVENTARIO_Pedido { get; set; }
        public DbSet<INVENTARIO_Producto> INVENTARIO_Producto { get; set; }
        public DbSet<INVENTARIO_ProductoDeposito> INVENTARIO_ProductoDeposito { get; set; }
        public DbSet<INVENTARIO_Recetas> INVENTARIO_Recetas { get; set; }
        public DbSet<INVENTARIO_Requerimiento> INVENTARIO_Requerimiento { get; set; }
        public DbSet<INVENTARIO_Requerimiento_Detalle> INVENTARIO_Requerimiento_Detalle { get; set; }
        public DbSet<INVENTARIO_Unidades> INVENTARIO_Unidades { get; set; }
        public DbSet<INVENTARIO_UnidadesConversion> INVENTARIO_UnidadesConversion { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Jornadas> Jornadas { get; set; }
        public DbSet<LiquidacionHorasPersonal> LiquidacionHorasPersonal { get; set; }
        public DbSet<LiquidacionHorasPersonal_Detalle> LiquidacionHorasPersonal_Detalle { get; set; }
        public DbSet<Locaciones> Locaciones { get; set; }
        public DbSet<LocacionesValorAnio> LocacionesValorAnio { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<MomentosDias> MomentosDias { get; set; }
        public DbSet<Monedas> Monedas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        public DbSet<NotaCreditos> NotaCreditos { get; set; }
        public DbSet<ObjetivosEmpleados> ObjetivosEmpleados { get; set; }
        public DbSet<ObjetivosGrupos> ObjetivosGrupos { get; set; }
        public DbSet<OrganizacionItems> OrganizacionItems { get; set; }
        public DbSet<OrganizacionPresupuestoDetalle> OrganizacionPresupuestoDetalle { get; set; }
        public DbSet<OrganizacionPresupuestoProveedoresExternos> OrganizacionPresupuestoProveedoresExternos { get; set; }
        public DbSet<OrganizacionPresupuestosArchivos> OrganizacionPresupuestosArchivos { get; set; }
        public DbSet<OrganizacionPresupuestoTimming> OrganizacionPresupuestoTimming { get; set; }
        public DbSet<PagosClientes> PagosClientes { get; set; }
        public DbSet<PagosProveedores> PagosProveedores { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<PlanesDePago> PlanesDePago { get; set; }
        public DbSet<PresupuestoDetalle> PresupuestoDetalle { get; set; }
        public DbSet<Presupuestos> Presupuestos { get; set; }
        public DbSet<ProcesoCierre> ProcesoCierre { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosCatering> ProductosCatering { get; set; }
        public DbSet<ProductosCateringItems> ProductosCateringItems { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<ProveedoresFormasdePago> ProveedoresFormasdePago { get; set; }
        public DbSet<ProveedoresRetenciones> ProveedoresRetenciones { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Ratios> Ratios { get; set; }
        public DbSet<ReciboEventoPresupuesto> ReciboEventoPresupuesto { get; set; }
        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<Retenciones> Retenciones { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Rubros> Rubros { get; set; }
        public DbSet<Rubros_Proveedores> Rubros_Proveedores { get; set; }
        public DbSet<Sectores> Sectores { get; set; }
        public DbSet<SectoresEmpresa> SectoresEmpresa { get; set; }
        public DbSet<Segmentos> Segmentos { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TABLA_Retenciones> TABLA_Retenciones { get; set; }
        public DbSet<TecnicaSalon> TecnicaSalon { get; set; }
        public DbSet<Tiempos> Tiempos { get; set; }
        public DbSet<TipoBarraCategoriaItem> TipoBarraCategoriaItem { get; set; }
        public DbSet<TipoCatering> TipoCatering { get; set; }
        public DbSet<TipoCateringAdicional> TipoCateringAdicional { get; set; }
        public DbSet<TipoCateringFamilia> TipoCateringFamilia { get; set; }
        public DbSet<TipoCateringTiempoProductoItem> TipoCateringTiempoProductoItem { get; set; }
        public DbSet<TipoComprobante_Impuestos> TipoComprobante_Impuestos { get; set; }
        public DbSet<TipoComprobantes> TipoComprobantes { get; set; }
        public DbSet<TipoEmpleados> TipoEmpleados { get; set; }
        public DbSet<TipoEventos> TipoEventos { get; set; }
        public DbSet<TipoLogistica> TipoLogistica { get; set; }
        public DbSet<TipoMovimientos> TipoMovimientos { get; set; }
        public DbSet<TipoPagoEmpleados> TipoPagoEmpleados { get; set; }
        public DbSet<TiposBarras> TiposBarras { get; set; }
        public DbSet<TipoServicioAdicional> TipoServicioAdicional { get; set; }
        public DbSet<TipoServicios> TipoServicios { get; set; }
        public DbSet<Transferencias> Transferencias { get; set; }
        public DbSet<UnidadesNegocios> UnidadesNegocios { get; set; }
        public DbSet<UnidadesNegocios_Proveedores> UnidadesNegocios_Proveedores { get; set; }
        public DbSet<UnidadesNegocios_TipoMovimientos> UnidadesNegocios_TipoMovimientos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioPipeDrive_Ambient> UsuarioPipeDrive_Ambient { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosGrupos> UsuariosGrupos { get; set; }
        public DbSet<UsuariosLocaciones> UsuariosLocaciones { get; set; }
        public DbSet<ItemDetalle> ItemDetalle { get; set; }
        public DbSet<NombreFantasia> NombreFantasia { get; set; }
        public DbSet<AvisosClientesPorFecha> AvisosClientesPorFecha { get; set; }
        public DbSet<CobranzasVentas> CobranzasVentas { get; set; }
        public DbSet<ControlEventosConfirmados> ControlEventosConfirmados { get; set; }
        public DbSet<EMPLEADODEPARTAMENTO> EMPLEADODEPARTAMENTO { get; set; }
        public DbSet<EventosConfirmadosProveedores> EventosConfirmadosProveedores { get; set; }
        public DbSet<EventosConfirmadosReservadosTODOS> EventosConfirmadosReservadosTODOS { get; set; }
        public DbSet<EVENTOSTODOS> EVENTOSTODOS { get; set; }
        public DbSet<GastosporPresupuestos> GastosporPresupuestos { get; set; }
        public DbSet<ObtenerAdiciones> ObtenerAdiciones { get; set; }
        public DbSet<ObtenerArchivosPorCategorias> ObtenerArchivosPorCategorias { get; set; }
        public DbSet<ObtenerCantidadInvitadosBarras> ObtenerCantidadInvitadosBarras { get; set; }
        public DbSet<ObtenerCantidadInvitadosCatering> ObtenerCantidadInvitadosCatering { get; set; }
        public DbSet<ObtenerCantidadPersonasAdicionalesCatering> ObtenerCantidadPersonasAdicionalesCatering { get; set; }
        public DbSet<ObtenerClientes> ObtenerClientes { get; set; }
        public DbSet<ObtenerContactosClientes> ObtenerContactosClientes { get; set; }
        public DbSet<ObtenerDatosParaPresupuesto> ObtenerDatosParaPresupuesto { get; set; }
        public DbSet<ObtenerEventos> ObtenerEventos { get; set; }
        public DbSet<ObtenerEventosNew> ObtenerEventosNew { get; set; }
        public DbSet<ObtenerEventosSeguimiento> ObtenerEventosSeguimiento { get; set; }
        public DbSet<ObtenerFamilias> ObtenerFamilias { get; set; }
        public DbSet<ObtenerGruposconFamilias> ObtenerGruposconFamilias { get; set; }
        public DbSet<ObtenerPrecioCostoBarra> ObtenerPrecioCostoBarra { get; set; }
        public DbSet<ObtenerPrecioCostoCatering> ObtenerPrecioCostoCatering { get; set; }
        public DbSet<ObtenerPrecioCostoTecnica> ObtenerPrecioCostoTecnica { get; set; }
        public DbSet<ObtenerPresupuestoAmbientacion> ObtenerPresupuestoAmbientacion { get; set; }
        public DbSet<ObtenerPresupuestoArtistica> ObtenerPresupuestoArtistica { get; set; }
        public DbSet<ObtenerPresupuestoAudiovisual> ObtenerPresupuestoAudiovisual { get; set; }
        public DbSet<ObtenerPresupuestoBarra> ObtenerPresupuestoBarra { get; set; }
        public DbSet<ObtenerPresupuestoCatering> ObtenerPresupuestoCatering { get; set; }
        public DbSet<ObtenerPresupuestoSalon> ObtenerPresupuestoSalon { get; set; }
        public DbSet<ObtenerPresupuestoTecnica> ObtenerPresupuestoTecnica { get; set; }
        public DbSet<ObtenerUsuarios> ObtenerUsuarios { get; set; }
        public DbSet<PresupuestosAVencer> PresupuestosAVencer { get; set; }
        public DbSet<ProveedoresExternos> ProveedoresExternos { get; set; }
        public DbSet<ProveedoresPagos> ProveedoresPagos { get; set; }
        public DbSet<ReporteAdiocionales> ReporteAdiocionales { get; set; }
        public DbSet<ReporteComprobantes> ReporteComprobantes { get; set; }
        public DbSet<ReporteEventosCobranzas> ReporteEventosCobranzas { get; set; }
        public DbSet<ReporteEventosPorUnidadesdeNegocios> ReporteEventosPorUnidadesdeNegocios { get; set; }
        public DbSet<ResponsablesEventos> ResponsablesEventos { get; set; }
        public DbSet<SeguimientosEventosClientesEstados> SeguimientosEventosClientesEstados { get; set; }
    
        [EdmFunction("AmbientHouseEntities", "CuentaCorrienteProveedores")]
        public virtual IQueryable<CuentaCorrienteProveedores_Result> CuentaCorrienteProveedores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CuentaCorrienteProveedores_Result>("[AmbientHouseEntities].[CuentaCorrienteProveedores]()");
        }
    
        [EdmFunction("AmbientHouseEntities", "CuentaCorrienteProveedoresGral")]
        public virtual IQueryable<CuentaCorrienteProveedoresGral_Result> CuentaCorrienteProveedoresGral()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CuentaCorrienteProveedoresGral_Result>("[AmbientHouseEntities].[CuentaCorrienteProveedoresGral]()");
        }
    
        [EdmFunction("AmbientHouseEntities", "informeCorrienteProveedor")]
        public virtual IQueryable<informeCorrienteProveedor_Result> informeCorrienteProveedor(Nullable<int> unidad)
        {
            var unidadParameter = unidad.HasValue ?
                new ObjectParameter("Unidad", unidad) :
                new ObjectParameter("Unidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<informeCorrienteProveedor_Result>("[AmbientHouseEntities].[informeCorrienteProveedor](@Unidad)", unidadParameter);
        }
    
        public virtual int ActualizarPresupuestosRealizados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPresupuestosRealizados");
        }
    
        public virtual int ActualizarPresupuestosVencidos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPresupuestosVencidos");
        }
    
        public virtual ObjectResult<BuscarItemsporTipoCatering_Result> BuscarItemsporTipoCatering(Nullable<int> tipoCateringId)
        {
            var tipoCateringIdParameter = tipoCateringId.HasValue ?
                new ObjectParameter("TipoCateringId", tipoCateringId) :
                new ObjectParameter("TipoCateringId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarItemsporTipoCatering_Result>("BuscarItemsporTipoCatering", tipoCateringIdParameter);
        }
    
        public virtual ObjectResult<BUSCARPAGOS_Result> BUSCARPAGOS(Nullable<System.DateTime> sTARDATE, Nullable<System.DateTime> eNDDATE)
        {
            var sTARDATEParameter = sTARDATE.HasValue ?
                new ObjectParameter("STARDATE", sTARDATE) :
                new ObjectParameter("STARDATE", typeof(System.DateTime));
    
            var eNDDATEParameter = eNDDATE.HasValue ?
                new ObjectParameter("ENDDATE", eNDDATE) :
                new ObjectParameter("ENDDATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BUSCARPAGOS_Result>("BUSCARPAGOS", sTARDATEParameter, eNDDATEParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> CambiarLogisticaPresupuesto(Nullable<decimal> valorlogistica, Nullable<int> presupuestoId)
        {
            var valorlogisticaParameter = valorlogistica.HasValue ?
                new ObjectParameter("valorlogistica", valorlogistica) :
                new ObjectParameter("valorlogistica", typeof(decimal));
    
            var presupuestoIdParameter = presupuestoId.HasValue ?
                new ObjectParameter("PresupuestoId", presupuestoId) :
                new ObjectParameter("PresupuestoId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("CambiarLogisticaPresupuesto", valorlogisticaParameter, presupuestoIdParameter);
        }
    
        public virtual ObjectResult<CargarCostosSalones_Result> CargarCostosSalones(Nullable<int> locacionId, Nullable<int> sectorId, Nullable<int> anio, Nullable<int> mes, Nullable<int> jornadaId, string dia, Nullable<double> costo, Nullable<double> precio, Nullable<double> royalty)
        {
            var locacionIdParameter = locacionId.HasValue ?
                new ObjectParameter("LocacionId", locacionId) :
                new ObjectParameter("LocacionId", typeof(int));
    
            var sectorIdParameter = sectorId.HasValue ?
                new ObjectParameter("SectorId", sectorId) :
                new ObjectParameter("SectorId", typeof(int));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("Anio", anio) :
                new ObjectParameter("Anio", typeof(int));
    
            var mesParameter = mes.HasValue ?
                new ObjectParameter("Mes", mes) :
                new ObjectParameter("Mes", typeof(int));
    
            var jornadaIdParameter = jornadaId.HasValue ?
                new ObjectParameter("JornadaId", jornadaId) :
                new ObjectParameter("JornadaId", typeof(int));
    
            var diaParameter = dia != null ?
                new ObjectParameter("Dia", dia) :
                new ObjectParameter("Dia", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(double));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(double));
    
            var royaltyParameter = royalty.HasValue ?
                new ObjectParameter("Royalty", royalty) :
                new ObjectParameter("Royalty", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CargarCostosSalones_Result>("CargarCostosSalones", locacionIdParameter, sectorIdParameter, anioParameter, mesParameter, jornadaIdParameter, diaParameter, costoParameter, precioParameter, royaltyParameter);
        }
    
        public virtual ObjectResult<CargarCostosTecnica_Result> CargarCostosTecnica(Nullable<int> locacionId, Nullable<int> sectorId, Nullable<int> tipoServicioId, Nullable<int> segmentoId, Nullable<int> proveedorId, Nullable<int> anio, Nullable<int> mes, string dia, Nullable<double> costo, Nullable<double> precio, Nullable<double> royalty)
        {
            var locacionIdParameter = locacionId.HasValue ?
                new ObjectParameter("LocacionId", locacionId) :
                new ObjectParameter("LocacionId", typeof(int));
    
            var sectorIdParameter = sectorId.HasValue ?
                new ObjectParameter("SectorId", sectorId) :
                new ObjectParameter("SectorId", typeof(int));
    
            var tipoServicioIdParameter = tipoServicioId.HasValue ?
                new ObjectParameter("TipoServicioId", tipoServicioId) :
                new ObjectParameter("TipoServicioId", typeof(int));
    
            var segmentoIdParameter = segmentoId.HasValue ?
                new ObjectParameter("SegmentoId", segmentoId) :
                new ObjectParameter("SegmentoId", typeof(int));
    
            var proveedorIdParameter = proveedorId.HasValue ?
                new ObjectParameter("ProveedorId", proveedorId) :
                new ObjectParameter("ProveedorId", typeof(int));
    
            var anioParameter = anio.HasValue ?
                new ObjectParameter("Anio", anio) :
                new ObjectParameter("Anio", typeof(int));
    
            var mesParameter = mes.HasValue ?
                new ObjectParameter("Mes", mes) :
                new ObjectParameter("Mes", typeof(int));
    
            var diaParameter = dia != null ?
                new ObjectParameter("Dia", dia) :
                new ObjectParameter("Dia", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(double));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(double));
    
            var royaltyParameter = royalty.HasValue ?
                new ObjectParameter("Royalty", royalty) :
                new ObjectParameter("Royalty", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CargarCostosTecnica_Result>("CargarCostosTecnica", locacionIdParameter, sectorIdParameter, tipoServicioIdParameter, segmentoIdParameter, proveedorIdParameter, anioParameter, mesParameter, diaParameter, costoParameter, precioParameter, royaltyParameter);
        }
    
        public virtual ObjectResult<DetalleInformeResultados_Result> DetalleInformeResultados(string tipoMovimiento, Nullable<int> tipoMovimientoId, Nullable<System.DateTime> fechaDesde, Nullable<System.DateTime> fechaHasta)
        {
            var tipoMovimientoParameter = tipoMovimiento != null ?
                new ObjectParameter("TipoMovimiento", tipoMovimiento) :
                new ObjectParameter("TipoMovimiento", typeof(string));
    
            var tipoMovimientoIdParameter = tipoMovimientoId.HasValue ?
                new ObjectParameter("TipoMovimientoId", tipoMovimientoId) :
                new ObjectParameter("TipoMovimientoId", typeof(int));
    
            var fechaDesdeParameter = fechaDesde.HasValue ?
                new ObjectParameter("FechaDesde", fechaDesde) :
                new ObjectParameter("FechaDesde", typeof(System.DateTime));
    
            var fechaHastaParameter = fechaHasta.HasValue ?
                new ObjectParameter("FechaHasta", fechaHasta) :
                new ObjectParameter("FechaHasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetalleInformeResultados_Result>("DetalleInformeResultados", tipoMovimientoParameter, tipoMovimientoIdParameter, fechaDesdeParameter, fechaHastaParameter);
        }
    
        public virtual int EliminarEventosGuardados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarEventosGuardados");
        }
    
        public virtual ObjectResult<EventosReservadosPorFechasPorSegmentos_Result> EventosReservadosPorFechasPorSegmentos(Nullable<int> segmento, Nullable<System.DateTime> starDate, Nullable<System.DateTime> endDate)
        {
            var segmentoParameter = segmento.HasValue ?
                new ObjectParameter("Segmento", segmento) :
                new ObjectParameter("Segmento", typeof(int));
    
            var starDateParameter = starDate.HasValue ?
                new ObjectParameter("StarDate", starDate) :
                new ObjectParameter("StarDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EventosReservadosPorFechasPorSegmentos_Result>("EventosReservadosPorFechasPorSegmentos", segmentoParameter, starDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<InformeResultados_Result> InformeResultados(Nullable<System.DateTime> fechaDesde, Nullable<System.DateTime> fechaHasta)
        {
            var fechaDesdeParameter = fechaDesde.HasValue ?
                new ObjectParameter("FechaDesde", fechaDesde) :
                new ObjectParameter("FechaDesde", typeof(System.DateTime));
    
            var fechaHastaParameter = fechaHasta.HasValue ?
                new ObjectParameter("FechaHasta", fechaHasta) :
                new ObjectParameter("FechaHasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InformeResultados_Result>("InformeResultados", fechaDesdeParameter, fechaHastaParameter);
        }
    
        public virtual ObjectResult<IVAVenta_Result> IVAVenta(Nullable<int> empresa, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var empresaParameter = empresa.HasValue ?
                new ObjectParameter("Empresa", empresa) :
                new ObjectParameter("Empresa", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IVAVenta_Result>("IVAVenta", empresaParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<ListadoProveedoresAsociados_Result> ListadoProveedoresAsociados(Nullable<int> proveedorId, Nullable<System.DateTime> fechaDesde, Nullable<System.DateTime> fechaHasta)
        {
            var proveedorIdParameter = proveedorId.HasValue ?
                new ObjectParameter("ProveedorId", proveedorId) :
                new ObjectParameter("ProveedorId", typeof(int));
    
            var fechaDesdeParameter = fechaDesde.HasValue ?
                new ObjectParameter("FechaDesde", fechaDesde) :
                new ObjectParameter("FechaDesde", typeof(System.DateTime));
    
            var fechaHastaParameter = fechaHasta.HasValue ?
                new ObjectParameter("FechaHasta", fechaHasta) :
                new ObjectParameter("FechaHasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListadoProveedoresAsociados_Result>("ListadoProveedoresAsociados", proveedorIdParameter, fechaDesdeParameter, fechaHastaParameter);
        }
    
        public virtual int PreciosCatering(Nullable<int> tipoCateringId, Nullable<double> costo, Nullable<double> precio)
        {
            var tipoCateringIdParameter = tipoCateringId.HasValue ?
                new ObjectParameter("tipoCateringId", tipoCateringId) :
                new ObjectParameter("tipoCateringId", typeof(int));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(double));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PreciosCatering", tipoCateringIdParameter, costoParameter, precioParameter);
        }
    
        public virtual ObjectResult<ReporteIva_Result> ReporteIva(Nullable<int> empresa, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var empresaParameter = empresa.HasValue ?
                new ObjectParameter("Empresa", empresa) :
                new ObjectParameter("Empresa", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReporteIva_Result>("ReporteIva", empresaParameter, startDateParameter, endDateParameter);
        }
    }
}
