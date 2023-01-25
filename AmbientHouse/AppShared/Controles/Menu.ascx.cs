using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;

namespace AmbientHouse.App_Shared.Controles
{
    public partial class Menu : System.Web.UI.UserControl
    {
        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                int PerfilCoordinadorVentas = int.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
                int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
                int PerfilAdministracion = int.Parse(ConfigurationManager.AppSettings["Administracion"].ToString());
                int PerfilGerencia = int.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
                int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
                int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());
                int PerfilStock = int.Parse(ConfigurationManager.AppSettings["Stock"].ToString());
                int PerfilStockCarga = int.Parse(ConfigurationManager.AppSettings["StockCarga"].ToString());
                int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());
                int PerfilGestor = int.Parse(ConfigurationManager.AppSettings["Gestor"].ToString());

                MenuItem mnuHome = new MenuItem();

                mnuHome.Text = "Home";
                mnuHome.Value = "HOM";
                mnuHome.NavigateUrl = "~/Home/Index.aspx";

                MenuItem mnuVentas = new MenuItem();

                mnuVentas.Text = "Ventas";
                mnuVentas.Value = "VEN";
                mnuVentas.NavigateUrl = "~/Inicio/Principal.aspx";

                MenuItem mnuExperienciasVentasCatering = new MenuItem();

                mnuExperienciasVentasCatering.Text = "Experiencias de Catering";
                mnuExperienciasVentasCatering.Value = "VEN";
                mnuExperienciasVentasCatering.NavigateUrl = "~/Inicio/Experiencias/Index.aspx";

                MenuItem mnuExperienciasVentasBarras = new MenuItem();

                mnuExperienciasVentasBarras.Text = "Experiencias de Barras";
                mnuExperienciasVentasBarras.Value = "VEN";
                mnuExperienciasVentasBarras.NavigateUrl = "~/Inicio/ExperienciasBarras/Index.aspx";

                mnuVentas.ChildItems.Add(mnuExperienciasVentasCatering);
                mnuVentas.ChildItems.Add(mnuExperienciasVentasBarras);

                MenuItem mnuOrganizador = new MenuItem();

                mnuOrganizador.Text = "Organizacion";
                mnuOrganizador.Value = "ORG";
                mnuOrganizador.NavigateUrl = "~/Organizador/CalendarioOrganizador.aspx";

                MenuItem mnuOperaciones = new MenuItem();

                mnuOperaciones.Text = "Operaciones";
                mnuOperaciones.Value = "OPE";
                mnuOperaciones.NavigateUrl = "~/Operacion/CalendarioOperacion.aspx";

                MenuItem mnuComandas = new MenuItem();

                mnuComandas.Text = "Comandas";
                mnuComandas.Value = "OPE";
                mnuComandas.NavigateUrl = "~/Operacion/ComandasBrowse.aspx";

                mnuOperaciones.ChildItems.Add(mnuComandas);

                #region Administracion

                MenuItem mnuAdministracion = new MenuItem();

                mnuAdministracion.Text = "Administracion";
                mnuAdministracion.Value = "ADM";

                MenuItem mnuClientes = new MenuItem();

                mnuClientes.Text = "Clientes";
                mnuClientes.Value = "CLI";
                mnuClientes.NavigateUrl = "~/Administracion/Clientes/Index.aspx";

                MenuItem mnuCheques = new MenuItem();

                mnuCheques.Text = "Cheques";
                mnuCheques.Value = "CHE";
                mnuCheques.NavigateUrl = "~/Administracion/Cheques/Index.aspx";

                MenuItem mnuTransferencias = new MenuItem();

                mnuTransferencias.Text = "Transferencias";
                mnuTransferencias.Value = "TRA";
                mnuTransferencias.NavigateUrl = "~/Administracion/Transferencias/Index.aspx";

                MenuItem mnuAdministracionPresupuestos = new MenuItem();

                mnuAdministracionPresupuestos.Text = "Presupuestos Aprobados/Realizados";
                mnuAdministracionPresupuestos.Value = "PRA";
                mnuAdministracionPresupuestos.NavigateUrl = "~/Administracion/Default.aspx";

                MenuItem mnuPlanContable = new MenuItem();

                mnuPlanContable.Text = "Plan Contable";
                mnuPlanContable.Value = "PCT";
                mnuPlanContable.NavigateUrl = "~/Administracion/TipoMovimientos/Index.aspx";

                MenuItem mnuCajas = new MenuItem();

                mnuCajas.Text = "Cajas";
                mnuCajas.Value = "PCT";
                mnuCajas.NavigateUrl = "~/Administracion/Cuentas/Index.aspx";


                MenuItem mnuHorasPersonalEventos = new MenuItem();

                mnuHorasPersonalEventos.Text = "Sueldos Personal Eventos";
                mnuHorasPersonalEventos.Value = "PCT";
                mnuHorasPersonalEventos.NavigateUrl = "~/Administracion/LiquidacionHoras/Index.aspx";

                MenuItem mnuFacturasClientes = new MenuItem();

                mnuFacturasClientes.Text = "Facturas Clientes";
                mnuFacturasClientes.Value = "PCT";
                mnuFacturasClientes.NavigateUrl = "~/Administracion/FacturasClientes/Index.aspx";

                mnuAdministracion.ChildItems.Add(mnuClientes);
                mnuAdministracion.ChildItems.Add(mnuCheques);
                mnuAdministracion.ChildItems.Add(mnuTransferencias);
                mnuAdministracion.ChildItems.Add(mnuAdministracionPresupuestos);
                mnuAdministracion.ChildItems.Add(mnuPlanContable);
                mnuAdministracion.ChildItems.Add(mnuHorasPersonalEventos);
                mnuAdministracion.ChildItems.Add(mnuFacturasClientes);

                if (cmd.Logeado(EmpleadoId))
                {
                    mnuAdministracion.ChildItems.Add(mnuCajas);
                }

                #endregion

                #region Compras

                MenuItem mnuCompras = new MenuItem();

                mnuCompras.Text = "Compras";
                mnuCompras.Value = "COM";

                MenuItem mnuRubros = new MenuItem();

                mnuRubros.Text = "Rubros";
                mnuRubros.Value = "RUB";
                mnuRubros.NavigateUrl = "~/Configuracion/Rubros/Index.aspx";

                MenuItem mnuProveedores = new MenuItem();

                mnuProveedores.Text = "Proveedores";
                mnuProveedores.Value = "RUB";
                mnuProveedores.NavigateUrl = "~/Configuracion/Proveedores/Index.aspx";

                MenuItem mnuFacturasProveedores = new MenuItem();

                mnuFacturasProveedores.Text = "Facturas Proveedores";
                mnuFacturasProveedores.Value = "RUB";
                mnuFacturasProveedores.NavigateUrl = "~/Administracion/Comprobantes/Index.aspx";


                mnuCompras.ChildItems.Add(mnuRubros);
                mnuCompras.ChildItems.Add(mnuProveedores);
                mnuCompras.ChildItems.Add(mnuFacturasProveedores);

                #endregion

                #region Configuracion

                MenuItem mnuConfiguracion = new MenuItem();

                mnuConfiguracion.Text = "Configuracion";
                mnuConfiguracion.Value = "CON";

                MenuItem mnuUnidadesNegocios = new MenuItem();

                mnuUnidadesNegocios.Text = "Unidades de Negocios";
                mnuUnidadesNegocios.Value = "UNE";
                mnuUnidadesNegocios.NavigateUrl = "~/Configuracion/UnidadesNegocios/Index.aspx";

                mnuConfiguracion.ChildItems.Add(mnuUnidadesNegocios);

                MenuItem mnuCanon = new MenuItem();

                mnuCanon.Text = "Canon";
                mnuCanon.Value = "CNN";
                mnuCanon.NavigateUrl = "~/Costos/Canon/Index.aspx";

                mnuConfiguracion.ChildItems.Add(mnuCanon);

                MenuItem mnuConfCateringTecnicaExperiencias = new MenuItem();

                mnuConfCateringTecnicaExperiencias.Text = "Configurar Catering/Tecnica para el Cotizador";
                mnuConfCateringTecnicaExperiencias.Value = "CNN";
                mnuConfCateringTecnicaExperiencias.NavigateUrl = "~/Configuracion/ConfiguracionCateringTecnicaCotizador/Index.aspx";

                mnuConfiguracion.ChildItems.Add(mnuConfCateringTecnicaExperiencias);

                MenuItem mnuItemsVentas = new MenuItem();

                mnuItemsVentas.Text = "Productos para Presupuestar";
                mnuItemsVentas.Value = "CNN";
                mnuItemsVentas.NavigateUrl = "~/Administracion/Productos/Index.aspx";

                mnuConfiguracion.ChildItems.Add(mnuItemsVentas);

                MenuItem mnuItemDetalle = new MenuItem();

                mnuItemDetalle.Text = "Productos Finales";
                mnuItemDetalle.Value = "CPF";
                mnuItemDetalle.NavigateUrl = "~/Configuracion/ItemDetalle/Index.aspx";

                mnuConfiguracion.ChildItems.Add(mnuItemDetalle);
                #region Items
                MenuItem mnuItems = new MenuItem();

                mnuItems.Text = "Items";
                mnuItems.Value = "ITE";
                mnuItems.NavigateUrl = "~/Configuracion/AbmItems/ItemsBrowse.aspx";

                MenuItem mnuAbmItems = new MenuItem();

                mnuAbmItems.Text = "Administracion de Items";
                mnuAbmItems.Value = "ITE";
                mnuAbmItems.NavigateUrl = "~/Configuracion/AbmItems/ItemsBrowse.aspx";

                mnuItems.ChildItems.Add(mnuAbmItems);

                MenuItem mnuItemsMasiva = new MenuItem();

                mnuItemsMasiva.Text = "Alta Masiva de Items";
                mnuItemsMasiva.Value = "ITE";
                mnuItemsMasiva.NavigateUrl = "~/Configuracion/AbmItems/ItemsAltaMasiva.aspx";

                mnuItems.ChildItems.Add(mnuItemsMasiva);
                mnuConfiguracion.ChildItems.Add(mnuItems);
                MenuItem mnuRatios = new MenuItem();

                mnuRatios.Text = "Ratios";
                mnuRatios.Value = "RAT";
                mnuRatios.NavigateUrl = "~/Configuracion/Ratios/RatiosBrowse.aspx";

                MenuItem mnuAbmRatios = new MenuItem();

                mnuAbmRatios.Text = "Administracion de Ratios";
                mnuAbmRatios.Value = "RAT";
                mnuAbmRatios.NavigateUrl = "~/Configuracion/Ratios/RatiosBrowse.aspx";

                mnuRatios.ChildItems.Add(mnuAbmRatios);
                MenuItem mnuRatiosMasiva = new MenuItem();

                mnuRatiosMasiva.Text = "Alta Masiva de Ratios";
                mnuRatiosMasiva.Value = "RAT";
                mnuRatiosMasiva.NavigateUrl = "~/Configuracion/Ratios/RatiosAltaMasiva.aspx";

                mnuRatios.ChildItems.Add(mnuRatiosMasiva);
                mnuConfiguracion.ChildItems.Add(mnuRatios);

                #endregion
                #region Adicionales

                MenuItem mnuAdicionales = new MenuItem();

                mnuAdicionales.Text = "Adicionales";
                mnuAdicionales.Value = "UNE";


                MenuItem mnuTipoAdicionales = new MenuItem();

                mnuTipoAdicionales.Text = "Tipos de Adicionales";
                mnuTipoAdicionales.Value = "UNE";
                mnuTipoAdicionales.NavigateUrl = "~/Configuracion/Adicionales/Index.aspx";


                MenuItem mnuItemsAdicionales = new MenuItem();

                mnuItemsAdicionales.Text = "Configurar Items de Adicionales";
                mnuItemsAdicionales.Value = "UNE";
                mnuItemsAdicionales.NavigateUrl = "~/Configuracion/AdicionalesItems/Index.aspx";


                mnuAdicionales.ChildItems.Add(mnuTipoAdicionales);
                mnuAdicionales.ChildItems.Add(mnuItemsAdicionales);

                mnuConfiguracion.ChildItems.Add(mnuAdicionales);



                #endregion

                #region Salones

                MenuItem mnuSalones = new MenuItem();

                mnuSalones.Text = "Salones";
                mnuSalones.Value = "SAL";

                MenuItem mnuLocaciones = new MenuItem();

                mnuLocaciones.Text = "Locaciones";
                mnuLocaciones.Value = "LOC";
                mnuLocaciones.NavigateUrl = "~/Configuracion/Locaciones/Index.aspx";

                MenuItem mnuTipoLogistica = new MenuItem();

                mnuTipoLogistica.Text = "Tipo Logisticas";
                mnuTipoLogistica.Value = "LOC";
                mnuTipoLogistica.NavigateUrl = "~/Configuracion/TipoLogistica/Index.aspx";

                MenuItem mnuCostoLogistica = new MenuItem();

                mnuCostoLogistica.Text = "Costos Logisticas";
                mnuCostoLogistica.Value = "LOC";
                mnuCostoLogistica.NavigateUrl = "~/Costos/Logistica/Index.aspx";

                MenuItem mnuLocalidades = new MenuItem();

                mnuLocalidades.Text = "Regiones/Localidades";
                mnuLocalidades.Value = "LOC";
                mnuLocalidades.NavigateUrl = "~/Configuracion/Localidades/Index.aspx";

                MenuItem mnuCostosSalones = new MenuItem();

                mnuCostosSalones.Text = "Precio/Costo Salones por Rangos";
                mnuCostosSalones.Value = "LOC";
                mnuCostosSalones.NavigateUrl = "~/Administracion/Costos/Salones.aspx";

                MenuItem mnuActualizaSalones = new MenuItem();

                mnuActualizaSalones.Text = "Actualizacion de Precios";
                mnuActualizaSalones.Value = "LOC";
                mnuActualizaSalones.NavigateUrl = "~/Administracion/Productos/Salonesupd.aspx";

                mnuSalones.ChildItems.Add(mnuLocaciones);
                mnuSalones.ChildItems.Add(mnuTipoLogistica);
                mnuSalones.ChildItems.Add(mnuCostoLogistica);
                mnuSalones.ChildItems.Add(mnuLocalidades);
                mnuSalones.ChildItems.Add(mnuCostosSalones);
                mnuSalones.ChildItems.Add(mnuActualizaSalones);

                mnuConfiguracion.ChildItems.Add(mnuSalones);

                #endregion

                #region Barras

                MenuItem mnuBarras = new MenuItem();

                mnuBarras.Text = "Barras";
                mnuBarras.Value = "BAR";

                MenuItem mnuTipoBarras = new MenuItem();

                mnuTipoBarras.Text = "Tipo Barra";
                mnuTipoBarras.Value = "TBA";
                mnuTipoBarras.NavigateUrl = "~/Configuracion/TipoBarras/Index.aspx";

                MenuItem mnuCategoriasBarras = new MenuItem();

                mnuCategoriasBarras.Text = "Categorizacion de Barras";
                mnuCategoriasBarras.Value = "TBA";
                mnuCategoriasBarras.NavigateUrl = "~/Configuracion/TipoBarrasCategoriasItem/Index.aspx";


                mnuBarras.ChildItems.Add(mnuTipoBarras);
                mnuBarras.ChildItems.Add(mnuCategoriasBarras);

                mnuConfiguracion.ChildItems.Add(mnuBarras);

                #endregion

                #region Catering

                MenuItem mnuCatering = new MenuItem();

                mnuCatering.Text = "Catering";
                mnuCatering.Value = "CAT";

                MenuItem mnuTipoCatering = new MenuItem();

                mnuTipoCatering.Text = "Tipo Catering";
                mnuTipoCatering.Value = "TCA";
                mnuTipoCatering.NavigateUrl = "~/Configuracion/TipoCatering/Index.aspx";


                MenuItem mnuTiemposCatering = new MenuItem();

                mnuTiemposCatering.Text = "Tiempos de Catering (Timming)";
                mnuTiemposCatering.Value = "TCA";
                mnuTiemposCatering.NavigateUrl = "~/Configuracion/Tiempos/Index.aspx";


                MenuItem mnuExperiencias = new MenuItem();

                mnuExperiencias.Text = "Configurar Tiempos de las Experiencias";
                mnuExperiencias.Value = "TEX";
                mnuExperiencias.NavigateUrl = "~/Configuracion/TipoCateringTiempoProductoItem/Index.aspx";

                MenuItem mnuProductosCatering = new MenuItem();

                mnuProductosCatering.Text = "Agrupacion por Productos";
                mnuProductosCatering.Value = "TEX";
                mnuProductosCatering.NavigateUrl = "~/Configuracion/ProductosCatering/Index.aspx";

                MenuItem mnuCategoriasCatering = new MenuItem();

                mnuCategoriasCatering.Text = "Agrupacion por Caterogias";
                mnuCategoriasCatering.Value = "TEX";
                mnuCategoriasCatering.NavigateUrl = "~/Configuracion/CategoriaItems/Index.aspx";

                MenuItem mnuItemsCatering = new MenuItem();

                mnuItemsCatering.Text = "Items";
                mnuItemsCatering.Value = "TEX";
                mnuItemsCatering.NavigateUrl = "~/Configuracion/Items/Index.aspx";


                mnuCatering.ChildItems.Add(mnuTipoCatering);
                mnuCatering.ChildItems.Add(mnuTiemposCatering);
                mnuCatering.ChildItems.Add(mnuExperiencias);
                mnuCatering.ChildItems.Add(mnuProductosCatering);
                mnuCatering.ChildItems.Add(mnuCategoriasCatering);
                mnuCatering.ChildItems.Add(mnuItemsCatering);


                mnuConfiguracion.ChildItems.Add(mnuCatering);

                #endregion

                #region Tecnica

                MenuItem mnuTecnicas = new MenuItem();

                mnuTecnicas.Text = "Tecnica";
                mnuTecnicas.Value = "TEC";

                MenuItem mnuTipoServicios = new MenuItem();

                mnuTipoServicios.Text = "Tipo Tecnica";
                mnuTipoServicios.Value = "TTE";
                mnuTipoServicios.NavigateUrl = "~/Configuracion/TipoTecnica/Index.aspx";



                mnuTecnicas.ChildItems.Add(mnuTipoServicios);

                MenuItem mnuCostoTecnica = new MenuItem();

                mnuCostoTecnica.Text = "Precio/Costo Tecnica";
                mnuCostoTecnica.Value = "TTE";
                mnuCostoTecnica.NavigateUrl = "~/Administracion/Costos/Tecnica.aspx";

                MenuItem mnuActualizaTecnica = new MenuItem();

                mnuActualizaTecnica.Text = "Actualizacion de Precios";
                mnuActualizaTecnica.Value = "LOC";
                mnuActualizaTecnica.NavigateUrl = "~/Administracion/Productos/Tecnicaupd.aspx";



                mnuTecnicas.ChildItems.Add(mnuCostoTecnica);
                mnuTecnicas.ChildItems.Add(mnuActualizaTecnica);

                mnuConfiguracion.ChildItems.Add(mnuTecnicas);


                #endregion

                #region Ambientacion

                MenuItem mnuAmbientacion = new MenuItem();

                mnuAmbientacion.Text = "Ambientacion";
                mnuAmbientacion.Value = "AMB";

                MenuItem mnuTipoAmbientacion = new MenuItem();

                mnuTipoAmbientacion.Text = "Tipo Ambientacion";
                mnuTipoAmbientacion.Value = "TAM";
                mnuTipoAmbientacion.NavigateUrl = "~/Configuracion/Categorias/Index.aspx";

                MenuItem mnuTipoAmbientacionCI = new MenuItem();

                mnuTipoAmbientacionCI.Text = "Tipo Ambientacion Corp. Informal";
                mnuTipoAmbientacionCI.Value = "TAM";
                mnuTipoAmbientacionCI.NavigateUrl = "~/Configuracion/AmbientacionCI/Index.aspx";

                MenuItem mnuCostosAmbientacionCI = new MenuItem();

                mnuCostosAmbientacionCI.Text = "Costos/Precios Ambientacion Corp. Informal";
                mnuCostosAmbientacionCI.Value = "TAM";
                mnuCostosAmbientacionCI.NavigateUrl = "~/Costos/AmbientacionCI/Index.aspx";


                mnuAmbientacion.ChildItems.Add(mnuTipoAmbientacion);
                mnuAmbientacion.ChildItems.Add(mnuTipoAmbientacionCI);
                mnuAmbientacion.ChildItems.Add(mnuCostosAmbientacionCI);

                mnuConfiguracion.ChildItems.Add(mnuAmbientacion);

                #endregion

                #region Presupuestos

                MenuItem mnuConfiguracionPresupuestos = new MenuItem();

                mnuConfiguracionPresupuestos.Text = "Presupuestos";
                mnuConfiguracionPresupuestos.Value = "PRE";

                MenuItem mnuDuracionEvento = new MenuItem();

                mnuDuracionEvento.Text = "Duracion Eventos";
                mnuDuracionEvento.Value = "DEV";
                mnuDuracionEvento.NavigateUrl = "~/Configuracion/Duracion/Index.aspx";

                MenuItem mnuMomentoDia = new MenuItem();

                mnuMomentoDia.Text = "Momento del Dia";
                mnuMomentoDia.Value = "MDI";
                mnuMomentoDia.NavigateUrl = "~/Configuracion/MomentosDia/Index.aspx";


                mnuConfiguracionPresupuestos.ChildItems.Add(mnuDuracionEvento);
                mnuConfiguracionPresupuestos.ChildItems.Add(mnuMomentoDia);

                mnuConfiguracion.ChildItems.Add(mnuConfiguracionPresupuestos);

                #endregion

                #region Organizacion

                MenuItem mnuOrganizacion = new MenuItem();

                mnuOrganizacion.Text = "Organizacion";
                mnuOrganizacion.Value = "ORG";

                MenuItem mnuTipoOrganizacion = new MenuItem();

                mnuTipoOrganizacion.Text = "Items Organizacion";
                mnuTipoOrganizacion.Value = "TOR";
                mnuTipoOrganizacion.NavigateUrl = "~/Configuracion/Organizacion/Index.aspx";

                mnuOrganizacion.ChildItems.Add(mnuTipoOrganizacion);

                mnuConfiguracion.ChildItems.Add(mnuOrganizacion);

                #endregion



                #endregion

                MenuItem mnuRRHH = new MenuItem();

                mnuRRHH.Text = "RRHH";
                mnuRRHH.Value = "RHH";

                MenuItem mnuEmpleados = new MenuItem();

                mnuEmpleados.Text = "Empleados";
                mnuEmpleados.Value = "EMP";
                mnuEmpleados.NavigateUrl = "~/RRHH/Empleados/Index.aspx";


                MenuItem mnuUsuarios = new MenuItem();

                mnuUsuarios.Text = "Usuarios";
                mnuUsuarios.Value = "USU";
                mnuUsuarios.NavigateUrl = "~/Seguridad/Usuarios/Index.aspx";

                mnuRRHH.ChildItems.Add(mnuEmpleados);
                mnuRRHH.ChildItems.Add(mnuUsuarios);


                MenuItem mnuReportes = new MenuItem();

                mnuReportes.Text = "Reportes";
                mnuReportes.Value = "REP";
                mnuReportes.NavigateUrl = "~/Reportes/Index.aspx";

                MenuItem mnuSistemas = new MenuItem();

                mnuSistemas.Text = "Sistemas";
                mnuSistemas.Value = "SIS";

                MenuItem mnuSistemasCambioPassword = new MenuItem();

                mnuSistemasCambioPassword.Text = "Cambio Password";
                mnuSistemasCambioPassword.Value = "CPS";
                mnuSistemasCambioPassword.NavigateUrl = "~/Seguridad/CambioPassword.aspx";


                MenuItem mnuSistemasSalir = new MenuItem();

                mnuSistemasSalir.Text = "Logout";
                mnuSistemasSalir.Value = "LOG";

                mnuSistemas.ChildItems.Add(mnuSistemasCambioPassword);
                mnuSistemas.ChildItems.Add(mnuSistemasSalir);

                MenuPrincipal.Items.Add(mnuHome);


                if (PerfilId == PerfilCoordinadorVentas
                    || PerfilId == PerfilEjecutivo
                    || PerfilId == PerfilGestor)
                {
                    MenuPrincipal.Items.Add(mnuVentas);
                }
                else if (PerfilId == PerfilAdministracion)
                {
                    MenuPrincipal.Items.Add(mnuOrganizador);
                    MenuPrincipal.Items.Add(mnuOperaciones);
                    MenuPrincipal.Items.Add(mnuAdministracion);
                    MenuPrincipal.Items.Add(mnuCompras);
                }
                else if (PerfilId == PerfilGerencia)
                {
                    MenuPrincipal.Items.Add(mnuVentas);
                    MenuPrincipal.Items.Add(mnuOrganizador);
                    MenuPrincipal.Items.Add(mnuOperaciones);
                    MenuPrincipal.Items.Add(mnuAdministracion);
                    MenuPrincipal.Items.Add(mnuCompras);
                    MenuPrincipal.Items.Add(mnuConfiguracion);
                    MenuPrincipal.Items.Add(mnuRRHH);
                    MenuPrincipal.Items.Add(mnuReportes);

                }
                else if (PerfilId == PerfilOrganizador || PerfilId == PerfilCoordinadorOrganizacion)
                {
                    MenuPrincipal.Items.Add(mnuOrganizador);
                }
                else if (PerfilId == PerfilStock)
                {
                    //Response.Redirect("~/Stock/Existencias/Index.aspx");
                }
                else if (PerfilId == PerfilStockCarga)
                {
                    //Response.Redirect("~/Stock/Existencias/Index.aspx");
                }
                else if (PerfilId == PerfilOperacion)
                {
                    MenuPrincipal.Items.Add(mnuOperaciones);
                }

                MenuPrincipal.Items.Add(mnuSistemas);

            }

        }

        private void Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("~/Seguridad/Login.aspx");

        }

        protected void MenuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "LOG")
            {
                Logout();
            }
        }

    }
}