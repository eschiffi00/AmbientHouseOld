using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Reportes
{
    public partial class ReporteProveedoresAsociados : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarLista();

            }

        }

        private void CargarLista()
        {
            DropDownListProveedores.DataSource = eventos.ObtenerProveedoresCotizador();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Index.aspx");
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SearcherReporteProveedoresAsociados searcher = new SearcherReporteProveedoresAsociados();

            searcher.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
            searcher.FechaDesde = TextBoxFechaDesde.Text;
            searcher.FechaHasta = TextBoxFechaHasta.Text;
            searcher.PresupuestoId = TextBoxPresupuesto.Text;

            GridViewReporteComprobantes.DataSource = eventos.ListadoProveedoresAsociados(searcher);
            GridViewReporteComprobantes.DataBind();

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar(GridViewReporteComprobantes);
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
    }
}