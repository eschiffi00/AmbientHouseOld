using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Reportes
{
    public partial class ReporteGastosPorPresupuesto : System.Web.UI.Page
    {
        ReporteServicios reporte = new ReporteServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarGastos();
        }

        private void BuscarGastos()
        {
            SearcherComprobantes searcher = new SearcherComprobantes();

            searcher.PresupuestoId = TextBoxNroPresupuesto.Text;

            GridViewReporte.DataSource = reporte.ListarGastosporPresupuestos(searcher);
            GridViewReporte.DataBind();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar(GridViewReporte);
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