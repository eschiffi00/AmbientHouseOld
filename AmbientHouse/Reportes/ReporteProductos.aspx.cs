using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;

namespace AmbientHouse.Reportes
{
    public partial class ReporteProductos : System.Web.UI.Page
    {
        AdministrativasServicios administrativas = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarListas();
            }
        }

        private void CargarListas()
        {
            AdministrativasServicios servicios = new AdministrativasServicios();
            Comun cmd = new Comun();

            DropDownListUnidadNegocio.DataSource = servicios.ObtenerUN();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();


            cmd.CargarAnios(DropDownListAnio);
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {

            GridViewReporteProductos.DataSource = BuscarProductos().ToList();
            GridViewReporteProductos.DataBind();

        }

        private List<Productos> BuscarProductos()
        {
            ReporteServicios reporte = new ReporteServicios();

            SearcherProductos searcher = new SearcherProductos();

            searcher.UnidadNegocioId = int.Parse(DropDownListUnidadNegocio.SelectedValue);
            searcher.Anio = int.Parse(DropDownListAnio.SelectedValue);
            searcher.ProductoId = TextBoxNroItem.Text;


            return reporte.ListarProductos(searcher);
          
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView grillaExcel = new GridView();

            grillaExcel.DataSource= BuscarProductos().ToList();
            grillaExcel.DataBind();

            Exportar(grillaExcel);
        }

        private void Exportar(GridView gridExcel)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gridExcel.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gridExcel);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=DATA.xls");
            Response.Charset = "UTF-8";
            // Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        public string GetLocacion(Object id)
        {

            if (id != null)
            {
                int key = (int)id;

                var locacion = administrativas.BuscarLocaciones(key);

                return locacion.Descripcion;

            }
            else
                return "No Aplica";

        }

        public string GetTecnica(Object id)
        {

            if (id != null)
            {
                int key = (int)id;

                var tecnica = administrativas.BuscarTipoServicios(key);

                return tecnica.Descripcion;

            }
            else
                return "No Aplica";

        }

        protected void GridViewReporteProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewReporteProductos.PageIndex = e.NewPageIndex;

            BuscarProductos();
        }
    }
}