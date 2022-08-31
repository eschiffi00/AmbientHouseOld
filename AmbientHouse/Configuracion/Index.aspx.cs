using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAdministrarLocaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }

        protected void ButtonAdministrarAdicionales_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Adicionales/Index.aspx");
        }

        protected void ButtonAdministrarTipoCatering_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCatering/Index.aspx");
        }

        protected void ButtonAdministrarFamilias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ProductosCatering/Index.aspx");
        }

        protected void ButtonAdministrarItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Items/Index.aspx");
        }

        protected void ButtonAdministrarCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Categorias/Index.aspx");
        }

        protected void ButtonAdministrarTecnica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoTecnica/Index.aspx");
        }

        protected void ButtonAdministrarTipoBarras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoBarras/Index.aspx");
        }

        protected void ButtonAdministrarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Proveedores/Index.aspx");
        }

        protected void ButtonAdministrarCostosSalones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Salones/IndexValoresAnuales.aspx");
        }

        protected void ButtonAdministrarPlanesDePago_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/PlanesDePagos/Index.aspx");
        }

        protected void ButtonAdministrarCostosCatering_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Costos/Catering/Index.aspx");
           
        }

        protected void ButtonAdministrarParametros_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Parametros/Index.aspx");
        }

        protected void ButtonAdministrarCostosBarras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Barras/Index.aspx");
        }

        protected void ButtonAdministrarCostosTecnica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Tecnica/Index.aspx");
        }

        protected void ButtonAdministrarCostosAmbientacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Ambientacion/Index.aspx");
        }

        protected void ButtonAdministrarCostosAdicionales_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Adicionales/Index.aspx");
        }

        protected void ButtonAdministrarCostosLogistica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Logistica/Index.aspx");
        }

        protected void ButtonAdministrarComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Comisiones/Index.aspx");
        }

        protected void ButtonAdministrarTipoLogistica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoLogistica/Index.aspx");
        }

        protected void ButtonAdministrarLocalidades_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Configuracion/Localidades/Index.aspx");
        }

        protected void ButtonAdministrarUnidadesNegocios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/UnidadesNegocios/Index.aspx");
        }

        protected void ButtonAdministrarRubros_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Rubros/Index.aspx");
        }

        protected void ButtonAdministrarCostosCannon_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Canon/Index.aspx");
        }

        protected void ButtonAdministrarDuraciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Duracion/Index.aspx");
        }

        protected void ButtonAdministrarMomentosDia_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/MomentosDia/Index.aspx");
        }

        protected void ButtonAdministrarConfiguracionCateringTecnica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ConfiguracionCateringTecnicaCotizador/Index.aspx");
        }

        protected void ButtonAdministrarCostosSalonesBis_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Salones/Index.aspx");
        }

        protected void ButtonAdministrarGrupos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Tiempos/Index.aspx");
        }

        protected void ButtonAdministrarCategoriaItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/CategoriaItems/Index.aspx");
        }

        protected void ButtonAdministrarExperienciasCatering_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCateringTiempoProductoItem/Index.aspx");
        }

        protected void ButtonAdministrarExperienciasBarras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoBarrasCategoriasItem/Index.aspx");
        }

        protected void ButtonAdministrarItemsOrganizacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Organizacion/Index.aspx");
        }

        protected void ButtonAdministrarItemsAdicionales_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AdicionalesItems/Index.aspx");
        }

        protected void ButtonAdministrarCategoriasCorporativoInformal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AmbientacionCI/Index.aspx");
        }

        protected void ButtonAdministrarCostosAmbientacionCI_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/AmbientacionCI/Index.aspx");
        }

    
    }
}

