using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Servicios
{
    public class AdministrativasServicios
    {


        HerramientasNegocios NegociosHerramientas;
        DepartamentosNegocios NegociosDepartamentos;
        AdicionalesNegocios NegociosAdicionales;
        RubrosNegocios NegociosRubros;
        UnidadesNegociosNegocios NegociosUN;
        ItemsNegocios NegocioItems;
        GruposNegocios NegocioGrupos;
        FamiliasNegocios NegocioFamilias;
        CategoriasArchivosNegocios NegocioCategoriaArchivos;
        FeriadosNegocios NegocioFeriados;



        FuncionesSistemaNegocios NegocioFuncionesSistema;
        CostoNegocios NegocioCostos;
        ProcesoCierreNegocios NegocioProcesoCierre;



        LocacionesNegocios NegociosLocaciones;
        CostoNegocios NegociosCosto;
        ConceptosLogisticaNegocios NegociosConceptosLogistica;
        LocalidadesNegocios NegociosLocalidades;
        CategoriasNegocios NegociosCategorias;
        TipoServiciosNegocios NegociosTipoServicios;
        TipoBarrasNegocios NegociosTipoBarras;
        ProveedoresNegocios NegociosProveedores;
        PlanesDePagosNegocios NegociosPlanesDePagos;
        ParametrosNegocios NegociosParametros;
        ComisionesNegocios NegociosComisiones;
        ImpuestosNegocios NegociosImpuestos;
        TipoComprobantesNegocios NegocioTC;
        MomentosDiasNegocios MomentosDia;
        DuracionEventoNegocios NegocioDuracionEvento;
        ProductosNegocios NegocioProductos;
        ComprobanteProveedoresNegocios NegocioComprobanteProveedores;
        TipoMovimientosNegocios NegocioTipoMovimiento;
        CentroCostosNegocios NegocioCC;
        FormasdePagoNegocios NegocioFP;
        CuentassNegocios NegocioCuentas;
        BancosNegocios NegocioBancos;
        PagoProveedoresNegocios NegocioPagoProveedores;
        ChequesNegocios NegociosCheques;
        EstadosNegocios NegocioEstados;



        TABLARetencionesNegocios NegociosTablaReteciones;


        public AdministrativasServicios()
        {


            NegociosHerramientas = new HerramientasNegocios();
            NegociosDepartamentos = new DepartamentosNegocios();
            NegociosAdicionales = new AdicionalesNegocios();
            NegociosRubros = new RubrosNegocios();
            NegociosUN = new UnidadesNegociosNegocios();
            NegocioItems = new ItemsNegocios();
            NegocioGrupos = new GruposNegocios();
            NegocioFamilias = new FamiliasNegocios();
            NegocioCategoriaArchivos = new CategoriasArchivosNegocios();
            NegocioFeriados = new FeriadosNegocios();
            NegocioFuncionesSistema = new FuncionesSistemaNegocios();
            NegocioCostos = new CostoNegocios();
            NegocioProcesoCierre = new ProcesoCierreNegocios();
            NegociosLocaciones = new LocacionesNegocios();
            NegociosCosto = new CostoNegocios();
            NegociosConceptosLogistica = new ConceptosLogisticaNegocios();
            NegociosLocalidades = new LocalidadesNegocios();
            NegociosCategorias = new CategoriasNegocios();
            NegociosTipoServicios = new TipoServiciosNegocios();
            NegociosTipoBarras = new TipoBarrasNegocios();
            NegociosProveedores = new ProveedoresNegocios();
            NegociosPlanesDePagos = new PlanesDePagosNegocios();
            NegociosParametros = new ParametrosNegocios();
            NegociosComisiones = new ComisionesNegocios();
            NegociosImpuestos = new ImpuestosNegocios();
            NegocioTC = new TipoComprobantesNegocios();
            MomentosDia = new MomentosDiasNegocios();
            NegocioDuracionEvento = new DuracionEventoNegocios();
            NegocioProductos = new ProductosNegocios();
            NegocioComprobanteProveedores = new ComprobanteProveedoresNegocios();
            NegocioTipoMovimiento = new TipoMovimientosNegocios();
            NegocioCC = new CentroCostosNegocios();
            NegocioFP = new FormasdePagoNegocios();
            NegocioCuentas = new CuentassNegocios();
            NegocioBancos = new BancosNegocios();
            NegocioPagoProveedores = new PagoProveedoresNegocios();
            NegociosCheques = new ChequesNegocios();
            NegocioEstados = new EstadosNegocios();
            NegociosTablaReteciones = new TABLARetencionesNegocios();

        }



        public void NuevosProductosCatering(ProductosCatering item)
        {
            ProductosCateringNegocios negocios = new ProductosCateringNegocios();

            negocios.NuevosProductosCatering(item);
        }

        public List<TABLA_Retenciones> ObtenerTABLA_Retenciones()
        {
            return NegociosTablaReteciones.ObtenerTABLA_Retenciones();
        }

        public List<Locaciones> ObtenerLocaciones()
        {
            return NegociosLocaciones.ObtenerLocaciones();
        }

        public void ActualizarPresupuestosVencidos()
        {
            NegocioFuncionesSistema.ActualizarPresupuestosVencidos();
        }

        public List<TipoCatering> ObtenerTipoCatering()
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.ObtenerTipoCatering();
        }

        public TipoCatering BuscarTipoCatering(long id)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.BuscarTipoCatering(id);
        }

        public void NuevoTipoCatering(TipoCatering TipoCatering)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            negocios.NuevoTipoCatering(TipoCatering);
        }

        public void EditarTipoCatering(TipoCatering tipoCatering)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            negocios.EditarTipoCatering(tipoCatering);
        }

        public List<TipoCatering> ObtenerAdicionalesTipoCatering()
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.ObtenerAdicionalesTipoCatering();
        }

        public List<ObtenerArchivosPorCategorias> ObtenerHerramientas()
        {
            return NegociosHerramientas.ObtenerHerramientas();
        }

        public void GrabarHerramientas(Herramientas herramienta)
        {
            NegociosHerramientas.GrabarHerramientas(herramienta);
        }

        public Herramientas TraerArchivo(int herramientaId)
        {
            return NegociosHerramientas.TraerArchivo(herramientaId);
        }

        public object ObtenerDepartamentos()
        {
            return NegociosDepartamentos.ObtenerDepartamentos();
        }

        public List<ObtenerAdicionales> ObtenerAdicionales()
        {
            return NegociosAdicionales.ObtenerAdicionales();
        }

        public Adicionales BuscarAdicional(int id)
        {
            return NegociosAdicionales.BuscarAdicional(id);
        }

        public void NuevoAdicional(Adicionales adicional, List<TipoCatering> ListTipoCatering, List<TipoServicios> ListTipoServicios)
        {
            NegociosAdicionales.NuevoAdicional(adicional, ListTipoCatering, ListTipoServicios);

        }

        public virtual List<Items> BuscarItemsFiltros(string detalle, string categoria, int estadoId)
        {

            return NegocioItems.BuscarItemsFiltros(detalle, categoria, estadoId);

        }

        public List<Items> ObtenerItems(int estadoId)
        {
            return NegocioItems.ObtenerItems(estadoId);
        }

        public Items BuscarItems(int id)
        {
            return NegocioItems.BuscarItems(id);
        }

        public void NuevoItem(Items item)
        {
            NegocioItems.NuevoItems(item);

        }

        public List<GruposItems> ObtenerGrupos()
        {
            return NegocioGrupos.ObtenerGrupos();
        }

        public GruposItems BuscarGruposItems(int Id)
        {
            return NegocioGrupos.BuscarGruposItems(Id);
        }

        public void NuevoGrupoItem(GruposItems grupoItem)
        {
            NegocioGrupos.NuevoGruposItems(grupoItem);

        }

        public List<ObtenerFamilias> ObtenerFamilias()
        {
            return NegocioFamilias.ObtenerFamilias();
        }

        public Familias BuscarFamilias(int GrupoId, int CategoriaId)
        {
            return NegocioFamilias.BuscarFamilias(GrupoId, CategoriaId);
        }

        public void NuevaFamilia(Familias familia)
        {
            NegocioFamilias.NuevaFamilia(familia);
        }

        public List<ObtenerFamilias> ObtenerFamiliasConItems()
        {
            return NegocioFamilias.ObtenerFamiliasConItems();
        }

        public void NuevaTipoCateringFamilia(TipoCateringFamilia tipoCateringFamilia)
        {
            NegocioFamilias.NuevaTipoCateringFamilia(tipoCateringFamilia);
        }

        public List<GruposItems> ObtenerFamiliasConItemsTipoCatering(int tipoCateringId)
        {
            return NegocioFamilias.ObtenerFamiliasConItemsTipoCatering(tipoCateringId);
        }

        public List<Items> ObtenerItemsPorGrupo(int grupoId)
        {
            return NegocioItems.ObtenerItemsPorGrupo(grupoId);
        }

        public List<ObtenerGruposconFamilias> ObtenerGruposConFamilias()
        {
            return NegocioGrupos.ObtenerGruposConFamilias();
        }

        public List<GruposItems> ObtenerFamiliasConItemsAdicionales(int AdicionalId)
        {
            return NegocioFamilias.ObtenerFamiliasConItemsAdicionales(AdicionalId);
        }

        //public List<Items> ObtenerItemsAdicionales(int AdicionalId)
        //{
        //    return NegocioItems.ObtenerItemsAdicionales(AdicionalId);
        //}

        public void EliminarArchivo(Herramientas herramienta)
        {
            NegociosHerramientas.EliminarArchivo(herramienta);

        }

        public List<CategoriasArchivos> ObtenerCategoriasArchivos()
        {
            return NegocioCategoriaArchivos.ObtenerCategoriasArchivos();
        }

        public void NuevaCategoriaArchivo(CategoriasArchivos Categorias)
        {
            NegocioCategoriaArchivos.NuevaCategoriaArchivo(Categorias);
        }

        public List<Feriados> ObtenerFeriados(int anio, int mes)
        {
            return NegocioFeriados.ObtenerFeriados(anio, mes);
        }

        public virtual List<ObtenerPrecioCostoBarra> ObtenerPrecioCostoBarra()
        {
            return NegocioCostos.ObtenerPrecioCostoBarra();
        }

        public virtual List<ObtenerPrecioCostoCatering> ObtenerPrecioCostoCatering()
        {
            return NegocioCostos.ObtenerPrecioCostoCatering();
        }

        public virtual List<ObtenerPrecioCostoTecnica> ObtenerPrecioCostoTecnica()
        {
            return NegocioCostos.ObtenerPrecioCostoTecnica();
        }

        public virtual List<ProcesoCierre> ObtenerProcesoCierre()
        {
            return NegocioProcesoCierre.ObtenerProcesoCierre();
        }

        public virtual List<TipoLogistica> ObtenerTipoLogistica()
        {
            return NegociosConceptosLogistica.ObtenerTipoLogistica();
        }

        public virtual List<Localidades> ObtenerLocalidades()
        {
            return NegociosLocalidades.ObtenerLocalidades();
        }

        public Locaciones BuscarLocaciones(int Id)
        {
            return NegociosLocaciones.BuscarLocaciones(Id);
        }

        public void NuevaLocacion(Locaciones Locacion, List<Sectores> ListSectores)
        {
            NegociosLocaciones.NuevaLocacion(Locacion, ListSectores);
        }

        //public void NuevoAdicionalSalon(Adicionales adicional, int LocacionId)
        //{
        //    NegociosLocaciones.NuevoAdicionalSalon(adicional, LocacionId);
        //}

        //public List<AdicionalesSalones> ObtenerAdicionalesPorSalon(int LocacionId)
        //{
        //    return NegociosAdicionales.ObtenerAdicionalesPorSalon(LocacionId);
        //}

        public List<Categorias> ObtenerAmbientaciones()
        {
            return NegociosCategorias.ObtenerAmbientaciones();
        }

        public Categorias BuscarCategorias(int id)
        {
            return NegociosCategorias.BuscarCategorias(id);
        }

        public void NuevaCategoria(Categorias categoria)
        {
            NegociosCategorias.NuevaCategoria(categoria);
        }

        public List<TipoServicios> ObtenerTipoTecnica()
        {
            return NegociosTipoServicios.ObtenerTipoServicios();
        }

        public TipoServicios BuscarTipoServicios(int id)
        {
            return NegociosTipoServicios.BuscarTipoServicios(id);
        }

        public void NuevoTipoServicio(TipoServicios tiposervicio)
        {
            NegociosTipoServicios.NuevoTipoServicio(tiposervicio);
        }

        public List<TiposBarras> ObtenerTipoBarras()
        {
            return NegociosTipoBarras.ObtenerTipoBarras();
        }

        public TiposBarras BuscarTipoBarras(int id)
        {
            return NegociosTipoBarras.BuscarTipoBarras(id);
        }

        public void NuevoTipoBarra(TiposBarras tipoBarra)
        {
            NegociosTipoBarras.NuevoTipoBarra(tipoBarra);
        }

        public List<Rubros> ObtenerRubros()
        {
            return NegociosRubros.ObtenerRubros();
        }

        public List<Proveedores> ObtenerProveedores()
        {
            return NegociosProveedores.ObtenerProveedores();
        }

        public Proveedores BuscarProveedor(int id)
        {
            return NegociosProveedores.BuscarProveedor(id);
        }

        public List<Proveedores> BuscarProveedorLista(int id)
        {
            return NegociosProveedores.BuscarProveedorLista(id);
        }


        public void NuevoProveedor(Proveedores proveedor,
                                    List<UnidadesNegocios_Proveedores> ListUnidadesNegociosProveedores,
                                    List<Rubros_Proveedores> ListRubrosProveedores,
                                    List<ProveedoresFormasdePago> ListProveedoresFormasdePago)
        {
            NegociosProveedores.NuevoProveedor(proveedor, ListUnidadesNegociosProveedores, ListRubrosProveedores, ListProveedoresFormasdePago);
        }

        public Rubros BuscarRubro(int id)
        {
            return NegociosRubros.BuscarRubro(id);
        }

        public void NuevoRubro(Rubros rubro)
        {
            NegociosRubros.NuevoRubro(rubro);
        }

        public PlanesDePago BuscarPlanDePago(int id)
        {
            return NegociosPlanesDePagos.BuscarPlanesDePago(id);
        }

        public void NuevaPlanesDePago(PlanesDePago planesDePago)
        {
            NegociosPlanesDePagos.NuevaPlanesDePago(planesDePago);
        }

        public List<PlanesDePago> ObtenerPlanesDePagos()
        {
            return NegociosPlanesDePagos.ObtenerPlanesDePagos();
        }

        public List<Categorias> BuscarCategoriasPorLocacionCaracteristicaSegmento(int locacionId, int caracteristicaId, int segmentoId, int sectorId)
        {
            return NegociosCategorias.BuscarCategoriasPorLocacionCaracteristicaSegmento(locacionId, caracteristicaId, segmentoId, sectorId);
        }

        public List<Proveedores> ObtenerProveedoresPorUnidaddeNegocio(int unidadNegocioId)
        {
            return NegociosProveedores.BuscarProveedoresporUnidadesNegocios(unidadNegocioId);
        }

        public List<ObtenerAdicionales> ObtenerAdicionalesPorProveedor(int proveedorId)
        {
            return NegociosAdicionales.ObtenerAdicionalesPorProveedor(proveedorId);
        }

        public List<Parametros> ObtenerParametros()
        {
            return NegociosParametros.ObtenerParametros();
        }

        public Parametros BuscarParametro(int id)
        {
            return NegociosParametros.BuscarParametros(id);
        }

        public void NuevoParametro(Parametros parametros)
        {
            NegociosParametros.NuevoParametro(parametros);
        }

        public List<Comisiones> ObtenerComisiones()
        {
            return NegociosComisiones.ObtenerComisiones();
        }

        public Comisiones BuscarComisiones(int id)
        {
            return NegociosComisiones.BuscarComisiones(id);
        }

        public void NuevaComisiones(Comisiones comisiones)
        {
            NegociosComisiones.NuevaComisiones(comisiones);
        }

        public Parametros BuscarParametro(string valor)
        {
            return NegociosParametros.BuscarParametros(valor);
        }

        public void ImportarCostosCatering(List<CostoCatering> CostoCateringSalida, int? proveedorId)
        {
            NegocioCostos.ImportarCostosCatering(CostoCateringSalida, proveedorId);
        }

        public void ImportarCostosBarras(List<CostoBarra> CostoBarraSalida, int? proveedorId)
        {
            NegocioCostos.ImportarCostosBarras(CostoBarraSalida, proveedorId);
        }

        public void ImportarCostosTecnica(List<CostoTecnica> CostoTecnicaSalida, int proveedorId, int anio)
        {
            NegocioCostos.ImportarCostosTecnica(CostoTecnicaSalida, proveedorId, anio);
        }

        public void ImportarCostosAmbientacion(List<CostoAmbientacion> CostoAmbientacionSalida, int proveedorId)
        {
            NegocioCostos.ImportarCostosAmbientacion(CostoAmbientacionSalida, proveedorId);
        }

        public void ImportarCostosAdicionales(List<CostoAdicionales> CostoAdicionalesSalida, int? proveedorId, int? locacionId)
        {
            NegocioCostos.ImportarCostosAdicionales(CostoAdicionalesSalida, proveedorId, locacionId);
        }

        public Comisiones BuscarComisiones(string descripcion)
        {
            return NegociosComisiones.BuscarComisiones(descripcion);
        }

        public List<Adicionales> ObtenerAdicionalesPorLocaciones(int LocacionId)
        {
            return NegociosAdicionales.ObtenerAdicionalesPorLocaciones(LocacionId);
        }

        public List<ObtenerAdicionales> ObtenerAdicionalesPorLocacionesUnidadNegocio(int LocacionId)
        {
            return NegociosAdicionales.ObtenerAdicionalesPorLocacionesUnidadNegocio(LocacionId);
        }

        public TipoLogistica BuscarTipoLogistica(long id)
        {
            return NegociosConceptosLogistica.BuscarTipoLogistica(id);
        }

        public void NuevoTipoLogistica(TipoLogistica tipoLogistica)
        {
            NegociosConceptosLogistica.NuevoTipoLogitica(tipoLogistica);
        }

        public Localidades BuscarLocalidades(long id)
        {
            return NegociosLocalidades.BuscarLocalidades(id);
        }

        public void NuevoLocalidades(Localidades localidades)
        {
            NegociosLocalidades.NuevaLocalidades(localidades);
        }

        public void ImportarCostosLogistica(List<CostoLogistica> CostoLogisticaSalida)
        {
            NegocioCostos.ImportarCostosLogistica(CostoLogisticaSalida);
        }

        public void GrabarTecnicaSalon(int sectorId, List<TecnicaSalon> listTecnicaSalon)
        {
            NegociosLocaciones.GrabarTecnicaSalon(sectorId, listTecnicaSalon);
        }

        public List<UnidadesNegocios> ObtenerUN()
        {
            return NegociosUN.ObtenerUN();

        }

        public UnidadesNegocios BuscarUnidadNegocio(int id)
        {
            return NegociosUN.BuscarUnidadesNegocios(id);
        }

        public void NuevoUnidadNegocio(UnidadesNegocios rubro)
        {
            NegociosUN.NuevoUnidadesNegocios(rubro);
        }

        public List<UnidadesNegocios> ObtenerUnidadesdeNegocios()
        {
            return NegociosUN.ObtenerUnidadesNegociosPorDepartamento();
        }

        public List<Impuestos> ObtenerImpuestos()
        {
            return NegociosImpuestos.ObtenerImpuestos();
        }

        public Impuestos BuscarImpuesto(int id)
        {
            return NegociosImpuestos.BuscarImpuestos(id);
        }

        public void NuevoImpuesto(Impuestos impuesto)
        {
            NegociosImpuestos.NuevoImpuestos(impuesto);
        }

        public List<TipoComprobantes> ObtenerTipoComprobantes()
        {
            return NegocioTC.ObtenerTipoComprobantes();
        }

        public TipoComprobantes BuscarTipoComprobante(int id)
        {
            return NegocioTC.BuscarTipoComprobantes(id);
        }

        public void NuevoTipoComprobantes(TipoComprobantes tc, List<Impuestos> ListImpuestos)
        {
            NegocioTC.NuevoTipoComprobantes(tc, ListImpuestos);
        }

        public List<Impuestos> ObtenerImpuestosorTipoComprobante(int tipoComprobanteId)
        {
            return NegociosImpuestos.ObtenerImpuestosorTipoComprobante(tipoComprobanteId);
        }

        public List<int> ObtenerCantidadPersonasLogistica()
        {
            return NegocioCostos.ObtenerCantidadPersonasLogistica();
        }

        public void ImportarCostosCanon(List<CostoCanon> CostoCanonSalida)
        {
            NegocioCostos.ImportarCostosCanon(CostoCanonSalida);
        }

        public List<MomentosDias> ObtenerMomentosDias()
        {
            return MomentosDia.ObtenerMomentosDia();
        }

        public List<DuracionEvento> ObtenerDuracionEvento()
        {
            return NegocioDuracionEvento.ObtenerDuracionEvento();
        }

        public DuracionEvento BuscarDuracion(int id)
        {
            return NegocioDuracionEvento.BuscarDuracion(id);
        }

        public void NuevaDuracionEvento(DuracionEvento duracionEvento)
        {
            NegocioDuracionEvento.NuevaDuracionEvento(duracionEvento);
        }

        public MomentosDias BuscarMomentosDias(int id)
        {
            return MomentosDia.BuscarMomentosDias(id);
        }

        public void NuevoMomentoDia(MomentosDias item)
        {
            MomentosDia.NuevoMomentoDia(item);
        }

        public List<ConfiguracionCateringTecnica> ObtenerConfiguracionCateringTecnica(int segmentoId, int caracteristicaId, int momentoDiaId, int duracionId)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.ObtenerConfiguracionCateringTecnica(segmentoId, caracteristicaId, momentoDiaId, duracionId);
        }

        public void ImportarConfiguracionCateringTecnica(List<ConfiguracionCateringTecnica> ConfiguracionCateringTecnicaSalida)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            negocios.ImportarConfiguracionCateringTecnica(ConfiguracionCateringTecnicaSalida);
        }

        public Productos BuscarProductosPorCodigo(string codigo, DateTime fecha)
        {
            return NegocioProductos.BuscarProductosPorCodigo(codigo, fecha);
        }

        public Productos BuscarProductosPorCodigo(string codigo)
        {
            return NegocioProductos.BuscarProductosPorCodigo(codigo);
        }

        public List<ComprobantesProveedores> ObtenerComprobantes(SearcherComprobantes searcher)
        {
            return NegocioComprobanteProveedores.ObtenerComprobanteProveedores(searcher);
        }

        public List<ComprobantesProveedores> ObtenerComprobantes()
        {
            return NegocioComprobanteProveedores.ObtenerComprobanteProveedores();
        }

        public ComprobantesProveedores BuscarComprobantes(int id)
        {
            return NegocioComprobanteProveedores.BuscarComprobantes(id);
        }

        public bool NuevoComprobantes(ComprobantesProveedores comprobante, List<ComprobantesProveedores_Detalles> detalle)
        {
            return NegocioComprobanteProveedores.NuevoComprobanteProveedores(comprobante, detalle);
        }

        public List<Impuestos> BuscarImpuestosPorTipoComprobante(int tipoComprobanteId)
        {
            return NegociosImpuestos.BuscarImpuestosPorTipoComprobante(tipoComprobanteId);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientos()
        {
            return NegocioTipoMovimiento.ObtenerTipoMovimientos();
        }

        public List<CentroCostos> ObtenerCentroCosto()
        {
            return NegocioCC.ObtenerCentroCostos();
        }

        public List<ComprobantesProveedores_Detalles> BuscarDetalleComprobanteProveedorPorComprobante(int comprobanteId)
        {
            return NegocioComprobanteProveedores.BuscarDetalleComprobanteProveedorPorComprobante(comprobanteId);
        }

        public List<FormasdePago> ObtenerFormasdePago()
        {
            return NegocioFP.ObtenerFormasdePago();
        }

        public List<Productos> ObtenerProductos()
        {
            return NegocioProductos.ObtenerProductos();
        }

        public Productos BuscarProducto(int id)
        {
            return NegocioProductos.BuscarProducto(id);
        }

        public void NuevoProducto(Productos producto)
        {
            NegocioProductos.NuevoProducto(producto);
        }

        public void ImportarCostosLocaciones(List<CostoSalones> CostoSalonesSalida, int locacionId, int anio)
        {
            NegocioCostos.ImportarCostosLocaciones(CostoSalonesSalida, locacionId, anio);
        }

        public List<Productos> BuscarProductosPorFiltros(int unidadNegocioId, int tipoCatering, int tipoBarra, int tipoServicio, int categoriaId,
                                                        int cantidadInvitados, int locacionId, int sectorId, int segmentoId, int jornadaId,
                                                        int proveedorId, int Anio, int Mes, string Dia, int adicionalId, int estadoId, int caracteristicaId, int itemOrganizacionId, int semestreId)
        {
            return NegocioProductos.BuscarProductosPorFiltros(unidadNegocioId, tipoCatering, tipoBarra, tipoServicio, categoriaId, cantidadInvitados, locacionId, sectorId, segmentoId, jornadaId, proveedorId, Anio, Mes, Dia, adicionalId, estadoId, caracteristicaId, itemOrganizacionId, semestreId);
        }

        public void ActualizarPrecioCostoProductos(List<Productos> ListProductos, double ValorCosto, double ValorPrecio, double PorcentajeCosto, double PorcentajePrecio, double Margen)
        {
            NegocioProductos.ActualizarPrecioCostoProductos(ListProductos, ValorCosto, ValorPrecio, PorcentajeCosto, PorcentajePrecio, Margen);
        }

        public List<Proveedores> ListarProveedores()
        {
            return NegociosProveedores.ListarProveedores();
        }

        public List<Entidades.ObtenerAdicionales> ObtenerAdicionalesPorProveedoryUnidadNegocio(int ProveedorId, int UnidadNegocioId)
        {
            return NegociosAdicionales.ObtenerAdicionalesPorProveedoryUnidadNegocio(ProveedorId, UnidadNegocioId);
        }

        public List<Cuentas> ObtenerCuentas()
        {
            return NegocioCuentas.ObtenerCuentas();
        }

        public List<Bancos> ObtenerBancos()
        {
            return NegocioBancos.ObtenerBancos();
        }

        public void GrabarPagoProveedores(PagosProveedores PagosProveedoresSeleccionado, List<ComprobantesProveedores> ListComprobantesSeleccionados, List<Cheques> ListChequesSeleccionados)
        {
            NegocioPagoProveedores.GrabarPagoProveedores(PagosProveedoresSeleccionado, ListComprobantesSeleccionados, ListChequesSeleccionados);
        }

        public List<Cheques> ObtenerCheques()
        {
            return NegociosCheques.ObtenerCheqhes();
        }

        public List<ComprobantesProveedores> BuscarComprobantesPorProveedor(int proveedorId)
        {
            return NegocioComprobanteProveedores.BuscarComprobantesPorProveedor(proveedorId);
        }

        public List<Estados> BuscarEstadosPorEntidad(string entidad)
        {
            return NegocioEstados.BuscarEstadosPorEntidad(entidad);
        }

        public List<Proveedores> ObtenerProveedoresPorProveedores(List<int?> listProveedorId)
        {
            return NegociosProveedores.ObtenerProveedoresPorProveedores(listProveedorId);
        }

        public void AcreditarCheques(List<Cheques> ListChequesSeleccionados, int empleadoId)
        {
            NegociosCheques.AcreditarCheques(ListChequesSeleccionados, empleadoId);
        }

        public List<UnidadesNegocios> ObtenerUNCotizador()
        {
            return NegociosUN.ObtenerUNCotizador();
        }

        public Empleados BuscarEmpleado(int EmpleadoId)
        {
            EmpleadosNegocios NegociosEmpleados = new EmpleadosNegocios();

            return NegociosEmpleados.BuscarEmpleado(EmpleadoId);
        }

        public List<ObjetivosEmpleados> BuscarObjetivosPorEmpleado(int EmpleadoId)
        {
            ObjetivosNegocios objetivos = new ObjetivosNegocios();

            return objetivos.BuscarObjetivosPorEmpleadoMensuales(EmpleadoId);
        }

        public Sectores BuscarSector(int sectorId)
        {
            SectoresNegocios sectores = new SectoresNegocios();

            return sectores.BuscarSector(sectorId);
        }

        public List<UnidadesNegocios_Proveedores> BuscarUnidadNegocioPorProveedor(int ProveedorId)
        {
            return NegociosUN.BuscarUnidadesNegociosPorProveedor(ProveedorId);
        }

        public List<Rubros_Proveedores> BuscarRubroPorProveedor(int ProveedorId)
        {
            return NegociosRubros.BuscarRubroPorProveedor(ProveedorId);
        }

        public List<Intermediarios> BuscarValoresIntermediariosPorLocacion(int locacionId)
        {
            IntermediariosNegocios negocio = new IntermediariosNegocios();

            return negocio.BuscarValoresIntermediariosPorLocacion(locacionId);
        }

        public void GrabarConfiguracionCateringTecnica(List<ConfiguracionCateringTecnica> list)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            negocios.ImportarConfiguracionCateringTecnica(list);
        }

        public Estados BuscarEstado(int Id)
        {
            return NegocioEstados.BuscarEstado(Id);
        }

        public void QuitarTipoCateringFamilia(TipoCateringFamilia tipoCateringFamilia)
        {
            NegocioFamilias.QuitarTipoCateringFamilia(tipoCateringFamilia);
        }

        public TipoCateringFamilia BuscarTipoCateringFamiliaPorGrupo(int grupoId, int tipoCateringId)
        {
            return NegocioFamilias.BuscarTipoCateringFamiliaPorGrupo(grupoId, tipoCateringId);
        }

        public List<CategoriasItem> ObtenerCategoriasItem()
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();


            return negocios.ObtenerCategoriasItem();
        }

        public List<CategoriasItem> ObtenerCategoriasPorGrupos(int grupoId)
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();


            return negocios.ObtenerCategoriasPorGrupos(grupoId);
        }

        public List<Items> ObtenerItemsPorCategoria(int categoriaId)
        {
            return NegocioItems.ObtenerItemsPorCategoria(categoriaId);
        }

        public List<Entidades.ObtenerAdicionales> ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(int ProveedorId, int UnidadNegocioId, int TipoCateringId)
        {
            return NegociosAdicionales.ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(ProveedorId, UnidadNegocioId, TipoCateringId);
        }

        public ConfiguracionCateringTecnica BuscarConfiguracionCateringTecnica(int segmentoId, int caracteristicaId, int momentoDiaId, int duracionId, int tipoCateringId, int tipoServicioId)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.BuscarConfiguracionCateringTecnica(segmentoId, caracteristicaId, momentoDiaId, duracionId, tipoCateringId, tipoServicioId);
        }

        public void ActivarDesactivarConfiguracion(int Id, int estado)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            negocios.ActivarDesactivarConfiguracion(Id, estado);
        }

        public List<TipoCatering> BuscarTipoCateringPorAdicional(int adicionalId)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.BuscarTipoCateringPorAdicional(adicionalId);
        }

        public List<TipoCatering> BuscarTipoCateringParaAgregarPorAdicional(int adicionalId)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            return negocios.BuscarTipoCateringParaAgregarPorAdicional(adicionalId);
        }

        public List<TipoServicios> BuscarTipoServicioPorAdicional(int adicionalId)
        {
            return NegociosTipoServicios.BuscarTipoServicioPorAdicional(adicionalId);
        }

        public List<TipoServicios> BuscarTipoServicioParaAgregarPorAdicional(int adicionalId)
        {
            return NegociosTipoServicios.BuscarTipoServicioParaAgregarPorAdicional(adicionalId);
        }

        public List<UnidadesNegocios> ObtenerUNCotizador(List<UnidadesNegocios> ListUN)
        {
            return NegociosUN.ObtenerUN(ListUN);
        }

        public Comisiones BuscarComisionPorUnidadNegocioPrecioSeleccionado(int UnidadNegocioParaAdicional, string PrecioParaAdicional)
        {
            return NegociosComisiones.BuscarComisionPorUnidadNegocioPrecioSeleccionado(UnidadNegocioParaAdicional, PrecioParaAdicional);
        }

        public Segmentos BuscarSermento(int Id)
        {
            SegmentosNegocios negocios = new SegmentosNegocios();

            return negocios.BuscarSegmentos(Id);
        }

        public void ActualizarProducto(Productos producto)
        {
            NegocioProductos.ActualizarProducto(producto);

        }

        public CategoriasItem BuscarCategoriaPadre(int id)
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();

            return negocios.BuscarCategoriaPadre(id);
        }

        public List<CategoriasItem> ObtenerCategoriasItemHijosPadres()
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();

            return negocios.ObtenerCategoriasItemHijosPadres();
        }

        public CategoriasItem BuscarCategoriasItem(int id)
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();

            return negocios.BuscarCategoriaItem(id);
        }

        public void NuevaCategoriaItem(CategoriasItem categoria)
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();


            negocios.NuevaCategoriaItem(categoria);
        }

        public void ActualizarItem(Items item)
        {
            NegocioItems.ActualizarItem(item);

        }

        public List<ProductosCatering> ObtenerProductosCatering()
        {
            ProductosCateringNegocios negocios = new ProductosCateringNegocios();


            return negocios.ObtenerProductosCatering();
        }

        public ProductosCatering BuscarProductoCatering(int id)
        {
            ProductosCateringNegocios negocios = new ProductosCateringNegocios();


            return negocios.BuscarProductoCatering(id);
        }

        public void NuevoProductoCatering(ProductosCatering pc,
                                            List<DomainAmbientHouse.Entidades.Items> ListItemsAsociados)
        {
            ProductosCateringNegocios negocios = new ProductosCateringNegocios();


            negocios.NuevosProductosCatering(pc, ListItemsAsociados);
        }

        public List<Items> BuscarItemsAsociados(int productoCateringId, string categoria, int estadoActivo)
        {
            return NegocioItems.BuscarItemsAsociados(productoCateringId, categoria, estadoActivo);
        }

        public List<Items> BuscarItemsNoAsociados(int productoCateringId, string categoria, int estadoActivo)
        {
            return NegocioItems.BuscarItemsNoAsociados(productoCateringId, categoria, estadoActivo);
        }

        public List<Tiempos> ObtenerTiempos()
        {
            TiempoNegocios negocios = new TiempoNegocios();


            return negocios.ObtenerTiempos();

        }

        public Tiempos BuscarTiempo(int id)
        {
            TiempoNegocios negocios = new TiempoNegocios();

            return negocios.BuscarTiempo(id);
        }

        public void NuevoTiempo(Tiempos tiempo)
        {
            TiempoNegocios negocios = new TiempoNegocios();

            negocios.NuevoTiempo(tiempo);
        }

        public List<TipoCateringTiempoProductoItem> ObtenerTipoCateringTiempoProductoItemDatos(int tipoCateringId)
        {
            TipoCateringTiempoProductoItemsNegocios negocio = new TipoCateringTiempoProductoItemsNegocios();

            return negocio.ObtenerTipoCateringTiempoProductoItemDatos(tipoCateringId);

        }

        public TipoCateringTiempoProductoItem BuscarTipoCateringTiempoProductoItem(long id)
        {
            TipoCateringTiempoProductoItemsNegocios negocio = new TipoCateringTiempoProductoItemsNegocios();

            return negocio.BuscarTipoCateringTiempoProductoItem(id);
        }

        public void NuevoTipoCateringTiempoProductoItem(TipoCateringTiempoProductoItem tipo)
        {
            TipoCateringTiempoProductoItemsNegocios negocio = new TipoCateringTiempoProductoItemsNegocios();

            negocio.NuevoTipoCateringTiempoProductoItem(tipo);
        }

        public List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCatering(int tipoCatering)
        {
            TipoCateringTiempoProductoItemsNegocios negocio = new TipoCateringTiempoProductoItemsNegocios();

            return negocio.BuscarConfiguracionPorTipoCatering(tipoCatering);
        }

        public void ActualizarTipoCateringTiempoProductoItem(TipoCateringTiempoProductoItem item)
        {
            TipoCateringTiempoProductoItemsNegocios negocio = new TipoCateringTiempoProductoItemsNegocios();

            negocio.ActualizarTipoCateringTiempoProductoItem(item);
        }

        public void ActualizarTipoCatering(TipoCatering item)
        {
            TipoCateringNegocios negocios = new TipoCateringNegocios();

            negocios.ActualizarTipoCatering(item);
        }

        public List<Tiempos> ObtenerTiemposPorTipoCatering(int TipoCateringId)
        {
            TiempoNegocios negocios = new TiempoNegocios();

            return negocios.ObtenerTiemposPorTipoCatering(TipoCateringId).OrderBy(o => o.Orden).ToList();
        }

        public List<ProductosCatering> ObtenerProductosPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            ProductosCateringNegocios negocios = new ProductosCateringNegocios();

            return negocios.ObtenerProductosPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        public void ActualizarAdicional(Adicionales item)
        {
            NegociosAdicionales.ActualizarAdicional(item);
        }

        public List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCateringArmadoArbol(int TipoCateringId)
        {
            TipoCateringTiempoProductoItemsNegocios negocio = new TipoCateringTiempoProductoItemsNegocios();

            return negocio.BuscarConfiguracionPorTipoCateringArmadoArbol(TipoCateringId);
        }

        public List<ProductosCatering> ObtenerProductosCateringPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            ProductosCateringNegocios negocios = new ProductosCateringNegocios();

            return negocios.ObtenerProductosPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempoProducto(int TipoCateringId, int TiempoId, int ProductoCateringId)
        {
            return NegocioItems.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, TiempoId, ProductoCateringId);
        }

        public List<CategoriasItem> ObtenerCategoriasPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();

            return negocios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempoCategorias(int TipoCateringId, int TiempoId, int CategoriaId)
        {
            return NegocioItems.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, TiempoId, CategoriaId);
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            return NegocioItems.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        public CostoLogistica BuscarCostoLogitica(int id)
        {
            return NegocioCostos.BuscarCostoLogistica(id);
        }

        public void NuevoCostoLogistica(CostoLogistica costo)
        {
            NegocioCostos.NuevoCostoLogistica(costo);
        }

        public Cheques BuscarCheque(int id)
        {
            ChequesNegocios negocios = new ChequesNegocios();

            return negocios.BuscarCheque(id);
        }

        public List<TipoBarraCategoriaItem> ObtenerTipoBarrasCategoriasItems(int tipoBarraId)
        {
            TipoBarraCategoriaItemNegocios negocios = new TipoBarraCategoriaItemNegocios();

            return negocios.ObtenerTipoBarraCategoriaItem(tipoBarraId);
        }

        public TipoBarraCategoriaItem BuscarTipoBarraCategoriaItem(long ItemId)
        {
            TipoBarraCategoriaItemNegocios negocios = new TipoBarraCategoriaItemNegocios();

            return negocios.BuscarTipoBarraCategoriaItem(ItemId);
        }

        public void ActualizarTipoBarraCategoriaItem(TipoBarraCategoriaItem item)
        {
            TipoBarraCategoriaItemNegocios negocios = new TipoBarraCategoriaItemNegocios();

            negocios.ActualizarTipoBarraCategoriaItem(item);
        }

        public void NuevoTipoBarraCategoriaItem(TipoBarraCategoriaItem tipo)
        {
            TipoBarraCategoriaItemNegocios negocios = new TipoBarraCategoriaItemNegocios();

            negocios.NuevoTipoBarraCategoriaItem(tipo);
        }

        public List<CategoriasItem> ObtenerCategoriasPorTipoBarra(int TipoBarraId)
        {
            CategoriaItemsNegocios negocios = new CategoriaItemsNegocios();

            return negocios.ObtenerCategoriasPorTipoBarra(TipoBarraId);
        }

        public List<Items> ObtenerItemsPorTipoBarraCategorias(int TipoBarraId, int CategoriaItem)
        {
            return NegocioItems.ObtenerItemsPorTipoBarraCategorias(TipoBarraId, CategoriaItem);
        }

        public List<Items> ObtenerItemsPorTipoBarra(int TipoBarraId)
        {
            return NegocioItems.ObtenerItemsPorTipoBarra(TipoBarraId);
        }

        public CostoCanon BuscarCostoCannon(int id)
        {
            return NegocioCostos.BuscarCostoCanon(id);
        }

        public void NuevoCostoCannon(CostoCanon cc)
        {
            NegocioCostos.NuevoCostoCannon(cc);
        }

        public CostoCanon BuscarCostoCannon(int segmentoId, int caracteristicaId, int tipoCateringId)
        {
            return NegocioCostos.BuscarCostoCanon(segmentoId, caracteristicaId, tipoCateringId);
        }

        public List<OrganizacionItems> ObtenerItemsOrganizacion()
        {
            OrganizacionNegocios negocios = new OrganizacionNegocios();

            return negocios.ObtenerItemsOrganizacion();

        }

        public OrganizacionItems BuscarItemsOrganizacion(int Id)
        {
            OrganizacionNegocios negocios = new OrganizacionNegocios();

            return negocios.BuscarItemsOrganizacion(Id);

        }

        public void NuevoItemOrganizacion(OrganizacionItems oi)
        {
            OrganizacionNegocios negocios = new OrganizacionNegocios();

            negocios.NuevoItemOrganizacion(oi);
        }

        public void InactivarProductos(List<Productos> list, int estadoId)
        {
            ProductosNegocios negocios = new ProductosNegocios();

            negocios.InactivarProductos(list, estadoId);
        }

        public List<Empleados> ObtenerEmpleados()
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            return negocios.ObtenerEmpleados();
        }

        public List<SectoresEmpresa> ObtenerSectoresEmpresaPorDepartamento(int departamentoId)
        {
            SectoresEmpresaNegocios negocios = new SectoresEmpresaNegocios();

            return negocios.ObtenerSectoresEmpresaPorDepartamento(departamentoId);
        }

        public List<TipoEmpleados> ObtenerTipoEmpleados()
        {
            TipoEmpleadoNegocios negocios = new TipoEmpleadoNegocios();

            return negocios.ObtenerTipoEmpleados();
        }

        public Departamentos BuscarDepartamentoPorSector(int sectorid)
        {
            DepartamentosNegocios negocios = new DepartamentosNegocios();

            return negocios.BuscarDepartamentoPorSector(sectorid);
        }

        public void GrabarEquipo(EmpleadosPresupuestosAprobados empleados)
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            negocios.GrabarEquipo(empleados);
        }

        public EmpleadosPresupuestosAprobados BuscarEquiposPorPresupuesto(int PresupuestoId)
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            return negocios.BuscarEquiposPorPresupuesto(PresupuestoId);
        }

        public List<Empleados> ObtenerEmpleadosPorTipoEmpleado(int tipoEmpleado)
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            return negocios.ObtenerEmpleadosPorTipoEmpleado(tipoEmpleado);
        }

        public void GrabarProveedoresExternos(OrganizacionPresupuestoProveedoresExternos proveedor)
        {
            NegociosProveedores.GrabarProveedoresExternos(proveedor);

        }

        public List<OrganizacionPresupuestoProveedoresExternos> ObtenerProveedoresExternosPorPresupuesto(int presupuestoId)
        {
            return NegociosProveedores.ObtenerProveedoresExternosPorPresupuesto(presupuestoId);
        }

        public OrganizacionPresupuestoProveedoresExternos BuscarOrganizacionPresupuestoProveedoresExternos(int Id)
        {
            return NegociosProveedores.BuscarOrganizacionPresupuestoProveedoresExternos(Id);
        }

        public void EliminarProveedoresExternos(OrganizacionPresupuestoProveedoresExternos proveedor)
        {
            NegociosProveedores.EliminarProveedoresExternos(proveedor);
        }

        public List<OrganizacionPresupuestoTimming> ObtenerTimmingPorPresupuesto(int PresupuestoId)
        {
            return NegociosProveedores.ObtenerTimmingPorPresupuesto(PresupuestoId);
        }

        public void GrabarTimming(OrganizacionPresupuestoTimming timming)
        {
            NegociosProveedores.GrabarTimming(timming);
        }

        public OrganizacionPresupuestoTimming BuscarOrganizacionTimming(int Id)
        {
            return NegociosProveedores.BuscarOrganizacionTimming(Id);
        }

        public void EliminarTimming(OrganizacionPresupuestoTimming timming)
        {
            NegociosProveedores.EliminarTimming(timming);
        }

        public List<OrganizacionPresupuestosArchivos> ObtenerArchivosPorPresupuesto(int PresupuestoId)
        {
            return NegociosProveedores.ObtenerArchivosPorPresupuesto(PresupuestoId);
        }

        public void GrabarArchivo(OrganizacionPresupuestosArchivos archivo)
        {
            NegociosProveedores.GrabarArchivos(archivo);
        }

        public OrganizacionPresupuestosArchivos BuscarOrganizacionArchivo(int Id)
        {
            return NegociosProveedores.BuscarOrganizacionArchivo(Id);
        }

        public void EliminarArchivo(OrganizacionPresupuestosArchivos archivo)
        {
            NegociosProveedores.EliminarArchivo(archivo);
        }

        public List<OrganizacionPresupuestosArchivos> ObtenerArchivosPorPresupuestoPorUsuario(int PresupuestoId, int EmpleadoId)
        {
            return NegociosProveedores.ObtenerArchivosPorPresupuestoPorUsuario(PresupuestoId, EmpleadoId);
        }

        public TipoMovimientos BuscarTipoMovimiento(int id)
        {
            return NegocioTipoMovimiento.BuscarTipoMovimiento(id);
        }

        public List<UnidadesNegocios> ObtenerUNReporte()
        {
            return NegociosUN.ObtenerUNReporte();
        }

        public Transferencias BuscarTransferencia(string filtro)
        {
            TransferenciasNegocios negocio = new TransferenciasNegocios();

            return negocio.BuscarTransferencia(filtro);
        }

        public Transferencias BuscarTransferenciaPorNroComprobante(string nroComprobante)
        {
            TransferenciasNegocios negocio = new TransferenciasNegocios();

            return negocio.BuscarTransferenciaPorNroComprobante(nroComprobante);
        }

        public List<Transferencias> ObtenerTransferencias()
        {
            TransferenciasNegocios negocio = new TransferenciasNegocios();

            return negocio.ObtenerTransferencias();
        }

        public List<Recibos> BuscarRecibos(RecibosSearcher searcher)
        {
            RecibosNegocios negocio = new RecibosNegocios();

            return negocio.BuscarRecibos(searcher);
        }

        public Recibos BuscarRecibo(int id)
        {
            RecibosNegocios negocio = new RecibosNegocios();

            return negocio.BuscarRecibo(id);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosTodos(DomainAmbientHouse.Entidades.TipoMovimientoSearcher searcher)
        {
            TipoMovimientosNegocios negocio = new TipoMovimientosNegocios();

            return negocio.ObtenerTipoMovimientosTodos(searcher);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosPadres()
        {
            TipoMovimientosNegocios negocio = new TipoMovimientosNegocios();

            return negocio.ObtenerTipoMovimientosPadres();
        }

        public bool GuardarTipoMovimiento(TipoMovimientos tipoMovimiento)
        {
            TipoMovimientosNegocios negocio = new TipoMovimientosNegocios();

            return negocio.GrabarTipoMovimientos(tipoMovimiento);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosParaRecibosIngresos()
        {
            TipoMovimientosNegocios negocio = new TipoMovimientosNegocios();

            return negocio.ObtenerTipoMovimientosParaRecibosIngresos();
        }

        public List<OrganizacionPresupuestoDetalle> ListarEventosFechaEnvioMailPresentacion()
        {
            OrganizacionNegocios negocio = new OrganizacionNegocios();

            return negocio.ListarEventosFechaEnvioMailPresentacion();
        }

        public List<Items> BuscarItemsporAdicional(int adicionalId)
        {
            ItemsNegocios negocio = new ItemsNegocios();

            return negocio.BuscarItemsporAdicional(adicionalId);
        }

        public void GrabarItemsAdicionales(int adicionalId, int itemsId)
        {
            AdicionalesNegocios negocio = new AdicionalesNegocios();

            negocio.GrabarItemsAdicionales(adicionalId, itemsId);
        }

        public bool ElimarItemsAdicionales(int Id, int adicionalId)
        {
            AdicionalesNegocios negocio = new AdicionalesNegocios();

            return negocio.EliminarItemsAdicionales(Id, adicionalId);
        }

        public List<INVENTARIO_Producto> ListarProductos()
        {
            INVENTARIOProductosNegocios negocio = new INVENTARIOProductosNegocios();

            return negocio.ListarProductos();


        }

        public List<INVENTARIO_Unidades> ListarUnidades()
        {
            INVENTARIOUnidadesNegocios negocio = new INVENTARIOUnidadesNegocios();

            return negocio.ListarUnidades();


        }

        public INVENTARIO_Producto BuscarINVENTARIOProducto(int Id)
        {
            INVENTARIOProductosNegocios negocio = new INVENTARIOProductosNegocios();

            return negocio.BuscarINVENTARIOProducto(Id);
        }

        public void ActualizarProductos(INVENTARIO_Producto producto)
        {
            INVENTARIOProductosNegocios negocio = new INVENTARIOProductosNegocios();

            negocio.ActualizarProductos(producto);
        }

        public CodigoPorRubro BuscarCodigoPorRubro(int rubroId)
        {
            return NegociosRubros.BuscarCodigoPorRubro(rubroId);
        }

        public List<INVENTARIO_Producto> BuscarINVENTARIOProductoPorProducto(string descripcion)
        {
            INVENTARIOProductosNegocios negocio = new INVENTARIOProductosNegocios();

            return negocio.BuscarINVENTARIOProductoPorProducto(descripcion);

        }

        public List<INVENTARIO_Producto> ListarINVENTARIOProductoPorRubro(int RubroId)
        {
            INVENTARIOProductosNegocios negocio = new INVENTARIOProductosNegocios();

            return negocio.ListarINVENTARIOProductoPorRubro(RubroId);
        }

        public INVENTARIO_Unidades BuscarINVENTARIOUnidad(int Id)
        {
            INVENTARIOUnidadesNegocios negocio = new INVENTARIOUnidadesNegocios();

            return negocio.BuscarINVENTARIOUnidades(Id);
        }

        public INVENTARIO_Producto BuscarINVENTARIOProductoPorCodigoBarra(string codigoBarra)
        {
            INVENTARIOProductosNegocios negocio = new INVENTARIOProductosNegocios();

            return negocio.BuscarINVENTARIOProductoPorCodigoBarra(codigoBarra);
        }

        public List<Entidades.ObtenerAdicionales> BuscarAdicionalesPorDescripcionProveedorSalon(string descripcion, int proveedorId, int locacionId, int unidadNegocioId)
        {
            return NegociosAdicionales.BuscarAdicionalesPorDescripcionProveedorSalon(descripcion, proveedorId, locacionId, unidadNegocioId);
        }

        public List<Categorias> ObtenerAmbientacionesPorLocacion(int locacionId)
        {
            return NegociosCategorias.ObtenerAmbientacionesPorLocacion(locacionId);
        }

        public Proveedores ObtenerProveedoresPorCuit(string cuit)
        {
            return NegociosProveedores.BuscarProveedoresPorCuit(cuit);
        }

        public List<Empresas> ObtenerEmpresas()
        {
            EmpresasNegocios negocios = new EmpresasNegocios();

            return negocios.ObtenerEmpresas();

        }

        public virtual List<Empresas> ObtenerEmpresasBlanco()
        {
            EmpresasNegocios negocios = new EmpresasNegocios();

            return negocios.ObtenerEmpresasBlanco();
        }

        public virtual List<AmbientacionCI> ObtenerAmbientacionesCI()
        {
            AmbientacionCINegocios negocios = new AmbientacionCINegocios();

            return negocios.ObtenerAmbientacionesCI();
        }

        public virtual AmbientacionCI BuscarAmbientacionCI(int Id)
        {
            AmbientacionCINegocios negocios = new AmbientacionCINegocios();

            return negocios.Buscar(Id);
        }

        public virtual CostosPaquetesCIAmbientacion BuscarCostosPaquetesCIAmbientacion(int Id)
        {
            CostosPaquetesCIAmbientacionNegocios negocios = new CostosPaquetesCIAmbientacionNegocios();

            return negocios.BuscarCostosPaquetesCIAmbientacion(Id);
        }

        public void GrabarAmbientacionCI(AmbientacionCI ambientacion)
        {
            AmbientacionCINegocios negocios = new AmbientacionCINegocios();

            negocios.Grabar(ambientacion);
        }

        public List<CostosPaquetesCIAmbientacion> ObtenerCostoPreciosAmbientacionCI()
        {
            CostosPaquetesCIAmbientacionNegocios negocios = new CostosPaquetesCIAmbientacionNegocios();

            return negocios.ObtenerCostosPaquetesCIAmbientacion();
        }

        public void GrabarCostoPreciosAmbientacionCI(CostosPaquetesCIAmbientacion costos)
        {
            CostosPaquetesCIAmbientacionNegocios negocios = new CostosPaquetesCIAmbientacionNegocios();

            negocios.Grabar(costos);
        }

        public List<Degustacion> ObtenerDegustacion()
        {
            DegustacionNegocios negocios = new DegustacionNegocios();

            return negocios.ObtenerDegustaciones();
        }

        public Degustacion BuscarDegustacion(int id)
        {
            DegustacionNegocios negocios = new DegustacionNegocios();

            return negocios.BuscarDegustacion(id);
        }

        public void Grabar(Degustacion degustacion)
        {
            DegustacionNegocios negocios = new DegustacionNegocios();

            negocios.GrabarDegustacion(degustacion);
        }

        public object BuscarDegustacionDetallePorDegustacion(int degustacion)
        {
            DegustacionDetalleNegocios negocios = new DegustacionDetalleNegocios();
            return negocios.BuscarDegustacionDetallePorDegustacion(degustacion);
        }

        public DegustacionDetalle BuscarDetalleDegustacion(int id)
        {
            DegustacionDetalleNegocios negocios = new DegustacionDetalleNegocios();

            return negocios.BuscarDegustacionDetalle(id);
        }

        public void Grabar(DegustacionDetalle detalle)
        {
            DegustacionDetalleNegocios negocios = new DegustacionDetalleNegocios();

            negocios.GrabarDegustacionDetalle(detalle);
        }

        public List<DegustacionDetalle> BuscarDegustacionDetallePorEmpleado(int degustacionId, int empleadoId)
        {
            DegustacionDetalleNegocios negocios = new DegustacionDetalleNegocios();

            return negocios.BuscarDegustacionDetallePorEmpleado(degustacionId, empleadoId);
        }

        public List<INVENTARIO_Requerimiento> ListarRequerimientos()
        {
            RequerimientosNegocios negocios = new RequerimientosNegocios();

            return negocios.ListarRequerimiento();
        }

        public List<CostosPaquetesCIAmbientacion> ListarCostosPaquetesCIAmbientacionPorProveedor(int proveedorId)
        {
            CostosPaquetesCIAmbientacionNegocios negocios = new CostosPaquetesCIAmbientacionNegocios();

            return negocios.ListarCostosPaquetesCIAmbientacionPorProveedor(proveedorId);
        }

        public List<PagosProveedores> BuscarPagoProveedoresPorComprabante(int comprobanteId)
        {
            PagoProveedoresNegocios negocios = new PagoProveedoresNegocios();

            return negocios.BuscarPagoProveedoresPorComprabante(comprobanteId);
        }

        public List<ComprobantesProveedores> BuscarComprobantesPorProveedorNroComprobante(int proveedorId, long nroComprobante)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.BuscarComprobantesPorProveedorNroComprobante(proveedorId, nroComprobante);
        }

        public List<ReporteIva_Result> BuscarIva(string fechaInicio, string fechaFin, int empresa)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.BuscarIva(fechaInicio, fechaFin, empresa);
        }

        public List<InformeResultados_Result> BuscarInformeResultados(string fechaInicio, string fechaFin)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.BuscarInformeResultados(fechaInicio, fechaFin);
        }

        public List<DetalleInformeResultados_Result> BuscarDetalleInformeResultados(string tipoMovimiento, int tipoMovimientoId, string fechaInicio, string fechaFin)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.BuscarDetalleInformeResultados(tipoMovimiento, tipoMovimientoId, fechaInicio, fechaFin);
        }

        public List<Empresas> ObtenerEmpresasBlancoProveedores()
        {
            EmpresasNegocios negocio = new EmpresasNegocios();

            return negocio.ObtenerEmpresasBlancoProveedores();
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosPorPadre(string padreId)
        {
            TipoMovimientosNegocios negocios = new TipoMovimientosNegocios();

            return negocios.ObtenerTipoMovimientosPorPadre(padreId);
        }

        public bool GrabarComprobante(ComprobantesProveedores comprobantes)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.GrabarComprobante(comprobantes);
        }

        public bool ElimarComprobanteProveedor(int ComprobanteId)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.ElimarComprobanteProveedor(ComprobanteId);
        }

        public List<Existencias> ListarExistencias(string descripcionProducto, string codigoProducto, int depositoId, int rubroId)
        {
            INVENTARIOProductosNegocios negocios = new INVENTARIOProductosNegocios();

            return negocios.ListarExistencias(descripcionProducto, codigoProducto, depositoId, rubroId);
        }

        public List<INVENTARIO_Depositos> ObtenerDepositos()
        {
            INVENTARIODepositosNegocios negocios = new INVENTARIODepositosNegocios();

            return negocios.ListarDepositos();
        }

        public Existencias BuscarExistencias(int productoId, int depositoId)
        {
            INVENTARIOProductosNegocios negocios = new INVENTARIOProductosNegocios();

            return negocios.BuscarExistencias(productoId, depositoId);
        }

        public Rubros BuscarRubroPorProducto(int productoId)
        {
            RubrosNegocios negocios = new RubrosNegocios();

            return negocios.BuscarRubroPorProducto(productoId);
        }

        public bool GuardarExistencia(Existencias existencia)
        {
            INVENTARIOProductosNegocios negocios = new INVENTARIOProductosNegocios();

            return negocios.GuardarExistencia(existencia);
        }

        public List<PagosClientes> ObtenerIndexacion(int presupuestoId, double indice, string tipoIndexacion)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();

            return negocios.ObtenerIndexacion(presupuestoId, indice, tipoIndexacion);
        }

        public List<CondicionIva> ListarCondicionIva()
        {
            CondicionIvaNegocios negocios = new CondicionIvaNegocios();

            return negocios.ListarCondicionIva();
        }

        public CondicionIva BuscarCondicionIva(int Id)
        {
            CondicionIvaNegocios negocios = new CondicionIvaNegocios();

            return negocios.BuscarCondicionIva(Id);
        }


        public List<TipoComprobantes> BuscarTipoComprobantesPorTipoProveedor(int? condicionIvaId)
        {
            TipoComprobantesNegocios negocios = new TipoComprobantesNegocios();

            return negocios.BuscarTipoComprobantesPorTipoProveedor(condicionIvaId);
        }

        public List<ProveedoresFormasdePago> BuscarFormasdePagoPorProveedor(int ProveedorId)
        {
            FormasdePagoNegocios negocios = new FormasdePagoNegocios();

            return negocios.BuscarFormasdePagoPorProveedor(ProveedorId);
        }

        public List<Transferencias> ListarTransferencias(TransferenciasSearcher searcher)
        {
            TransferenciasNegocios negocios = new TransferenciasNegocios();

            return negocios.ListarTransferencias(searcher);
        }

        public List<Cheques> ListarCheques(ChequesSearcher searcher)
        {
            ChequesNegocios negocios = new ChequesNegocios();

            return negocios.ListarCheques(searcher);
        }

        public List<PagosClientes> ObtenerIndexacion(string fechaEvento, double totalPresupuesto, double indexacion, string tipoIndexacion,
                                                        List<SimuladorIndexacion> SimuladorIndexacionSeleccionado)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();

            return negocios.ObtenerIndexacion(fechaEvento, totalPresupuesto, indexacion, tipoIndexacion, SimuladorIndexacionSeleccionado);
        }

        public Transferencias BuscarTransferencia(int id)
        {
            TransferenciasNegocios negocios = new TransferenciasNegocios();

            return negocios.BuscarTransferencia(id);
        }

        public void GrabarTransferencia(Transferencias tm)
        {
            TransferenciasNegocios negocios = new TransferenciasNegocios();

            negocios.GrabarTransferencia(tm);
        }

        public void GrabarEgresoMovimientoCaja(MovimientosCuentas movimiento)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            negocios.GrabarEgresoMovimientoCaja(movimiento);
        }

        public Cuentas BuscarCuenta(int id)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.BuscarCuenta(id);
        }

        public void GrabarCuenta(Cuentas cuenta)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            negocios.GrabarCuenta(cuenta);
        }

        public void GrabarIngresoMovimientoCaja(MovimientosCuentas movimiento)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            negocios.GrabarIngresosMovimientoCaja(movimiento);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosEgresos()
        {
            TipoMovimientosNegocios negocios = new TipoMovimientosNegocios();

            return negocios.ObtenerTipoMovimientosEgresos();
        }

        public List<NotaCreditos> ListarNotasdeCredito(int comprobanteId)
        {
            NotaCreditosNegocios negocios = new NotaCreditosNegocios();

            return negocios.ListarNotasdeCredito(comprobanteId);
        }

        public PagosClientes BuscarPagosClientes(int pagoClienteId)
        {
            PagosClienteNegocios negocio = new PagosClienteNegocios();

            return negocio.BuscarPagoCliente(pagoClienteId);
        }

        public ComprobantesProveedores_Detalles BuscarComprobanteDetalle(int detalleComprobanteId)
        {
            ComprobanteProveedoresNegocios negocio = new ComprobanteProveedoresNegocios();

            return negocio.BuscarComprobanteDetalle(detalleComprobanteId);
        }

        public bool EditarPagosClientes(PagosClientes pago)
        {
            PagosClienteNegocios negocio = new PagosClienteNegocios();

            return negocio.EditarPagosClientes(pago);
        }

        public bool EditarComprobanteDetalle(ComprobantesProveedores_Detalles comprobante)
        {
            ComprobanteProveedoresNegocios negocio = new ComprobanteProveedoresNegocios();

            return negocio.EditarComprobanteDetalle(comprobante);
        }

        public bool GrabarTransferenciaCuenta(TransferenciasCuentas movimientos)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.GrabarTransferenciaCuenta(movimientos);
        }

        public Cuentas_Log BuscarMovimiento(int id)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.BuscarMovimiento(id);
        }

        public bool GrabarMovimiento(Cuentas_Log cuentasLog)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.GrabarMovimiento(cuentasLog);
        }

        public List<CargarCostosSalones_Result> CargarPrecioCostosSalon(ParametrosCostoSalones param)
        {
            return NegociosLocaciones.CargarPrecioCostosSalon(param);
        }
        public List<CargarCostosTecnica_Result> CargarPrecioCostosTecnica(ParametrosCostoTecnica param)
        {
            return NegociosCosto.CargarPrecioCostostecnica(param);
        }

        public List<LiquidacionHorasPersonal> ObtenerLiquidaciones()
        {
            LiquidacionEmpleadosNegocios negocios = new LiquidacionEmpleadosNegocios();

            return negocios.ObtenerLiquidacionHoras();
        }

        public List<SectoresEmpresa> ObtenerSectoresEmpresa()
        {
            SectoresEmpresaNegocios negocios = new SectoresEmpresaNegocios();

            return negocios.ObtenerSectoresEmpresa();
        }

        public List<TipoEmpleados> ObtenerTipoEmpleadosPorSector(int sector)
        {
            TipoEmpleadoNegocios negocios = new TipoEmpleadoNegocios();

            return negocios.ObtenerTipoEmpleadosPorSector(sector);
        }

        public List<TipoPagoEmpleados> ObtenerTipoPagoEmpleados()
        {
            TipoPagoNegocios negocios = new TipoPagoNegocios();

            return negocios.ObtenerTipoPago();
        }

        public Cuentas_Log BuscarUltimoMovimientoCuenta(int CuentaId)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.BuscarUltimoMovimientoPorCuenta(CuentaId);
        }

        public bool EliminarCuentasLog(int id)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.EliminarCuentasLog(id);
        }

        public bool RectificarMovimiento(Cuentas_Log movimientos, int? presupuestoId, int? centroCostoId)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.RectificarMovimiento(movimientos, presupuestoId, centroCostoId);
        }

        public List<Monedas> ObtenerMonedas()
        {
            MonedasNegocios negocios = new MonedasNegocios();

            return negocios.ObtenerMonedas();
        }

        public NotaCreditos BuscarNotaCredito(int id)
        {
            NotaCreditosNegocios negocios = new NotaCreditosNegocios();

            return negocios.BuscarNotaCredito(id);
        }

        public void GrabarNotaCredito(NotaCreditos notaCredito)
        {
            NotaCreditosNegocios negocios = new NotaCreditosNegocios();

            negocios.GrabarNotaCredito(notaCredito);
        }

        public PagosProveedores BuscarPagosPorCheques(int chequeId)
        {
            PagoProveedoresNegocios negocios = new PagoProveedoresNegocios();

            return negocios.BuscarPagoProveedorPorCheque(chequeId);
        }

        public void ActualizarPagoProveedor(PagosProveedores pago)
        {
            PagoProveedoresNegocios negocios = new PagoProveedoresNegocios();

            negocios.ActualizarPagoProveedor(pago);
        }

        public List<PagosProveedores> ObtenerPagosPorComprobante(int comprobanteId)
        {
            PagoProveedoresNegocios negocios = new PagoProveedoresNegocios();

            return negocios.ObtenerPagosPorComprobante(comprobanteId);
        }

        public List<Proveedores> BuscarProveedores(ProveedoresSearcher searcher)
        {
            return NegociosProveedores.BuscarProveedores(searcher);
        }

        public List<Cuentas> ListarCuentasProEmpresas(int empresaId)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.ListarCuentasProEmpresas(empresaId);
        }

        public List<Cuentas> ListarCuentasEfectivosMasEfectivo(int empresaId)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.ListarCuentasEfectivosMasEfectivo(empresaId);
        }


        public List<NotaCreditos> ObtenerNotasCreditosPorComprobante(int comprobanteId)
        {
            NotaCreditosNegocios negocios = new NotaCreditosNegocios();

            return negocios.ObtenerNotasCreditosPorComprobante(comprobanteId);
        }

        public bool EditarMovimiento(Cuentas_Log cuentasLog)
        {
            CuentassNegocios negocios = new CuentassNegocios();

            return negocios.EditarMovimiento(cuentasLog);
        }

        public void GrabarPagoProveedores(List<OrdenPagoProveedores> ListOrdenPagoProveedoresSeleccionados)
        {
            NegocioPagoProveedores.GrabarPagoProveedores(ListOrdenPagoProveedoresSeleccionados);
        }

        public LiquidacionHorasPersonal_Detalle BuscarDetalleHoras(int Id)
        {
            LiquidacionEmpleadosDetalleNegocios negocios = new LiquidacionEmpleadosDetalleNegocios();

            return negocios.BuscarDetalleHoras(Id);
        }

        public bool GrabarLiquidacionHoras(LiquidacionHorasPersonal liquidacion)
        {
            LiquidacionEmpleadosNegocios negocios = new LiquidacionEmpleadosNegocios();

            return negocios.GrabarLiquidacionHoras(liquidacion);
        }

        public LiquidacionHorasPersonal BuscarLiquidacionHorasPersonal(int id)
        {
            LiquidacionEmpleadosNegocios negocios = new LiquidacionEmpleadosNegocios();

            return negocios.BuscarLiquidacionPersonal(id);
        }

        public bool GrabarLiquidacionHoraDetalle(LiquidacionHorasPersonal_Detalle detalle)
        {
            LiquidacionEmpleadosDetalleNegocios negocios = new LiquidacionEmpleadosDetalleNegocios();

            return negocios.GrabarLiquidacionHoraDetalle(detalle);
        }

        public List<LiquidacionHorasPersonal_Detalle> ListarLiquidacionPersonalHorasDetalle(int liquidacionId)
        {
            LiquidacionEmpleadosDetalleNegocios negocios = new LiquidacionEmpleadosDetalleNegocios();

            return negocios.ListarLiquidacionPersonalHorasDetalle(liquidacionId);
        }

        //public ValorHoras BuscarValorHoraPorSectorTipoEmpleadoTipoPago(int sectorId, int tipoEmpleadoId, int tipoPagoId)
        //{
        //    ValorHoraNegocios negocios = new ValorHoraNegocios();

        //    return negocios.BuscarValorHoraPorSectorTipoEmpleadoTipoPago(sectorId, tipoEmpleadoId, tipoPagoId);
        //}

        public bool ElimnarLiquidacionHoraDetalle(LiquidacionHorasPersonal_Detalle detalle)
        {
            LiquidacionEmpleadosDetalleNegocios negocios = new LiquidacionEmpleadosDetalleNegocios();

            return negocios.ElimnarLiquidacionHoraDetalle(detalle);
        }



        public void GuardarCheque(Cheques cheque)
        {
            ChequesNegocios negocios = new ChequesNegocios();

            negocios.GuardarCheques(cheque);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosEgresosyAjuste()
        {
            TipoMovimientosNegocios negocios = new TipoMovimientosNegocios();

            return negocios.ObtenerTipoMovimientosEgresosyAjuste();
        }

        public List<FacturasCliente> ListarFacturasClientes(FacturasClienteSearcher searcher)
        {
            FacturasClientesNegocios negocios = new FacturasClientesNegocios();

            return negocios.ListarFacturasClientes(searcher);
        }

        public void GrabarFacturasClientes(FacturasCliente factura)
        {
            FacturasClientesNegocios negocios = new FacturasClientesNegocios();

            negocios.GrabarFactura(factura);
        }

        public FacturasCliente BuscarFacturasCliente(int id)
        {
            FacturasClientesNegocios negocios = new FacturasClientesNegocios();

            return negocios.BuscarFacturasCliente(id);
        }

        public bool ExisteFacturaPorEmpresayNro(int empresaId, int nroFactura, int tipoComprobanteId)
        {
            FacturasClientesNegocios negocios = new FacturasClientesNegocios();

            return negocios.ExisteFacturaPorEmpresayNro(empresaId, nroFactura, tipoComprobanteId);
        }

        public List<FacturasCliente> BuscarFacturasClientePorNroPresupuesto(int presupuestoId)
        {
            FacturasClientesNegocios negocios = new FacturasClientesNegocios();

            return negocios.BuscarFacturasClientePorNroPresupuesto(presupuestoId);
        }



        public List<Provincias> ObtenerProvincias()
        {
            UbicacionNegocios negocios = new UbicacionNegocios();

            return negocios.ObtenerProvincias();
        }

        public List<Ciudades> BuscarCiudadesPorProvincia(int provinciaId)
        {
            UbicacionNegocios negocios = new UbicacionNegocios();

            return negocios.BuscarCiudadesPorProvincia(provinciaId);
        }

        public Ciudades BuscarCiudad(int Id)
        {
            UbicacionNegocios negocios = new UbicacionNegocios();

            return negocios.BuscarCiudad(Id);
        }

        public virtual Provincias BuscarProvinciaPorCiudad(int ciudadId)
        {
            UbicacionNegocios negocios = new UbicacionNegocios();

            return negocios.BuscarProvinciaPorCiudad(ciudadId);

        }
        public List<EventosConfirmadosProveedores> BuscarPagosProveedores()
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.BuscarPagosProveedores();
        }

        public List<BuscarItemsporTipoCatering_Result> BuscarItemsPorTipoCatering(int TipoCateringId)
        {
            ItemsNegocios negocios = new ItemsNegocios();

            return negocios.BuscarItemsPorTipoCatering(TipoCateringId);
        }
        public List<IVAVenta_Result> BuscarIvaVenta(string fechaInicio, string fechaFin, int empresa)
        {
            ComprobanteProveedoresNegocios negocios = new ComprobanteProveedoresNegocios();

            return negocios.BuscarIvaVenta(fechaInicio, fechaFin, empresa);
        }
        public List<FacturaClienteDetalle> BuscarDetalleFacturas(int facturaId)
        {
            FacturasClientesNegocios negocios = new FacturasClientesNegocios();

            return negocios.BuscarDetalleFacturas(facturaId);
        }

    }
}
