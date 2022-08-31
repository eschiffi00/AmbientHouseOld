﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entidades
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
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<CategoriasArchivos> CategoriasArchivos { get; set; }
        public DbSet<CategoriasItem> CategoriasItem { get; set; }
        public DbSet<CentroCostos> CentroCostos { get; set; }
        public DbSet<Cheques> Cheques { get; set; }
        public DbSet<ChequesPagosProveedores> ChequesPagosProveedores { get; set; }
        public DbSet<ClientesBis> ClientesBis { get; set; }
        public DbSet<ClientesEventosMovimientos> ClientesEventosMovimientos { get; set; }
        public DbSet<ClientesPrueba> ClientesPrueba { get; set; }
        public DbSet<CodigoPorRubro> CodigoPorRubro { get; set; }
        public DbSet<Comisiones> Comisiones { get; set; }
        public DbSet<ComprobantePagoProveedor> ComprobantePagoProveedor { get; set; }
        public DbSet<ComprobantesProveedores> ComprobantesProveedores { get; set; }
        public DbSet<ComprobantesProveedores_Detalles> ComprobantesProveedores_Detalles { get; set; }
        public DbSet<ConfiguracionCateringTecnica> ConfiguracionCateringTecnica { get; set; }
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
        public DbSet<FacturasClientes> FacturasClientes { get; set; }
        public DbSet<Familias> Familias { get; set; }
        public DbSet<FechasBloqueadas> FechasBloqueadas { get; set; }
        public DbSet<Feriados> Feriados { get; set; }
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
        public DbSet<Items> Items { get; set; }
        public DbSet<Jornadas> Jornadas { get; set; }
        public DbSet<Locaciones> Locaciones { get; set; }
        public DbSet<LocacionesValorAnio> LocacionesValorAnio { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<MomentosDias> MomentosDias { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        public DbSet<NotaCredito_Detalle> NotaCredito_Detalle { get; set; }
        public DbSet<NotaCreditos> NotaCreditos { get; set; }
        public DbSet<ObjetivosEmpleados> ObjetivosEmpleados { get; set; }
        public DbSet<ObjetivosGrupos> ObjetivosGrupos { get; set; }
        public DbSet<OrganizacionCatering> OrganizacionCatering { get; set; }
        public DbSet<OrganizacionItems> OrganizacionItems { get; set; }
        public DbSet<OrganizacionPresupuestoDetalle> OrganizacionPresupuestoDetalle { get; set; }
        public DbSet<OrganizacionPresupuestoProveedoresExternos> OrganizacionPresupuestoProveedoresExternos { get; set; }
        public DbSet<OrganizacionPresupuestosArchivos> OrganizacionPresupuestosArchivos { get; set; }
        public DbSet<OrganizacionPresupuestoTimming> OrganizacionPresupuestoTimming { get; set; }
        public DbSet<PagosClientes> PagosClientes { get; set; }
        public DbSet<PagosProveedores> PagosProveedores { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<PlanesDePago> PlanesDePago { get; set; }
        public DbSet<PresupuestoDetalle> PresupuestoDetalle { get; set; }
        public DbSet<Presupuestos> Presupuestos { get; set; }
        public DbSet<ProcesoCierre> ProcesoCierre { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosCatering> ProductosCatering { get; set; }
        public DbSet<ProductosCateringItems> ProductosCateringItems { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<ReciboEventoPresupuesto> ReciboEventoPresupuesto { get; set; }
        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<Retenciones> Retenciones { get; set; }
        public DbSet<Rubros> Rubros { get; set; }
        public DbSet<Rubros_Proveedores> Rubros_Proveedores { get; set; }
        public DbSet<Sectores> Sectores { get; set; }
        public DbSet<SectoresEmpresa> SectoresEmpresa { get; set; }
        public DbSet<Segmentos> Segmentos { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
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
        public DbSet<TiposBarras> TiposBarras { get; set; }
        public DbSet<TipoServicioAdicional> TipoServicioAdicional { get; set; }
        public DbSet<TipoServicios> TipoServicios { get; set; }
        public DbSet<Transferencias> Transferencias { get; set; }
        public DbSet<UnidadesNegocios> UnidadesNegocios { get; set; }
        public DbSet<UnidadesNegocios_Proveedores> UnidadesNegocios_Proveedores { get; set; }
        public DbSet<UnidadesNegocios_TipoMovimientos> UnidadesNegocios_TipoMovimientos { get; set; }
        public DbSet<UsuarioPipeDrive_Ambient> UsuarioPipeDrive_Ambient { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosGrupos> UsuariosGrupos { get; set; }
        public DbSet<UsuariosLocaciones> UsuariosLocaciones { get; set; }
        public DbSet<AvisosClientesPorFecha> AvisosClientesPorFecha { get; set; }
        public DbSet<EMPLEADODEPARTAMENTO> EMPLEADODEPARTAMENTO { get; set; }
        public DbSet<EventosConfirmadosReservadosTODOS> EventosConfirmadosReservadosTODOS { get; set; }
        public DbSet<EVENTOSTODOS> EVENTOSTODOS { get; set; }
        public DbSet<ObtenerAdiciones> ObtenerAdiciones { get; set; }
        public DbSet<ObtenerArchivosPorCategorias> ObtenerArchivosPorCategorias { get; set; }
        public DbSet<ObtenerCantidadInvitadosBarras> ObtenerCantidadInvitadosBarras { get; set; }
        public DbSet<ObtenerCantidadInvitadosCatering> ObtenerCantidadInvitadosCatering { get; set; }
        public DbSet<ObtenerCantidadPersonasAdicionalesCatering> ObtenerCantidadPersonasAdicionalesCatering { get; set; }
        public DbSet<ObtenerClientes> ObtenerClientes { get; set; }
        public DbSet<ObtenerContactosClientes> ObtenerContactosClientes { get; set; }
        public DbSet<ObtenerDatosParaPresupuesto> ObtenerDatosParaPresupuesto { get; set; }
        public DbSet<ObtenerEventos> ObtenerEventos { get; set; }
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
        public DbSet<ReporteAdiocionales> ReporteAdiocionales { get; set; }
        public DbSet<ReporteComprobantes> ReporteComprobantes { get; set; }
        public DbSet<ReporteEventosPorUnidadesdeNegocios> ReporteEventosPorUnidadesdeNegocios { get; set; }
        public DbSet<SeguimientosEventosClientesEstados> SeguimientosEventosClientesEstados { get; set; }
    
        public virtual int ActualizarPresupuestosRealizados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPresupuestosRealizados");
        }
    
        public virtual int ActualizarPresupuestosVencidos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPresupuestosVencidos");
        }
    
        public virtual int EliminarEventosGuardados()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarEventosGuardados");
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
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
