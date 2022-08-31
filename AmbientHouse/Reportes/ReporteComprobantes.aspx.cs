using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;

namespace AmbientHouse.Reportes
{
    public partial class ReporteComprobantes : System.Web.UI.Page
    {

        DomainAmbientHouse.Servicios.ReporteServicios reportes = new DomainAmbientHouse.Servicios.ReporteServicios();
        DomainAmbientHouse.Servicios.AdministrativasServicios administrativas = new DomainAmbientHouse.Servicios.AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
            }
        }

        private void CargarListas()
        {
            DropDownListTipoMovimiento.DataSource = administrativas.ObtenerTipoMovimientosEgresos();
            DropDownListTipoMovimiento.DataTextField = "Identificador";
            DropDownListTipoMovimiento.DataValueField = "Id";
            DropDownListTipoMovimiento.DataBind();
        }

        private void Buscar()
        {
            SearcherReporteComprobantes searcher = new SearcherReporteComprobantes();

            searcher.FechaDesde = TextBoxNroFechaDesde.Text;
            searcher.FechaHasta = TextBoxFechaHasta.Text;
            searcher.TipoMovimientoId = DropDownListTipoMovimiento.SelectedItem.Value;
            searcher.RazonSocial = TextBoxRazonSocial.Text;
            searcher.PresupuestoId = TextBoxPresupuesto.Text;

            List<DomainAmbientHouse.Entidades.ReporteComprobantes> list = reportes.ObtenerReporteComprobantes(searcher);

            GridViewReporteComprobantes.DataSource = list.ToList();
            GridViewReporteComprobantes.DataBind();

            TextBoxTotal.Text = (System.Math.Round(list.Select(o => o.NETO).Sum(),2)).ToString("C");

            UpdatePanelGrillaReporteComprobantes.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Index.aspx");
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();

            SearcherReporteComprobantes searcher = new SearcherReporteComprobantes();

            searcher.FechaDesde = TextBoxNroFechaDesde.Text;
            searcher.FechaHasta = TextBoxFechaHasta.Text;
            searcher.TipoMovimientoId = DropDownListTipoMovimiento.SelectedItem.Value;
            searcher.RazonSocial = TextBoxRazonSocial.Text;
            searcher.PresupuestoId = TextBoxPresupuesto.Text;

            Total.DataSource = reportes.ObtenerReporteComprobantes(searcher);
            Total.DataBind();

            Exportar(Total);
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