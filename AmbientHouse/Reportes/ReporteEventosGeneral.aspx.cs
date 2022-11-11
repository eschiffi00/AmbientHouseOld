using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Reportes
{
    public partial class ReporteEventosGeneral : System.Web.UI.Page
    {

        ReporteServicios reportes = new ReporteServicios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();

            int nroEvento = 0;
            int nroPresupuesto = 0;


            if (TextBoxNroEvento.Text != "")
            { nroEvento = int.Parse(TextBoxNroEvento.Text); }


            if (TextBoxNroPresupuesto.Text != "")
            { nroPresupuesto = int.Parse(TextBoxNroPresupuesto.Text); }


            Total.DataSource = reportes.ObtenerReporteEventosPorUnidadesNegocios(nroEvento, nroPresupuesto, TextBoxNroFechaDesde.Text, TextBoxFechaHasta.Text);
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

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarEventosGenerales();
        }

        private void BuscarEventosGenerales()
        {
            int nroEvento = 0;
            int nroPresupuesto = 0;


            if (TextBoxNroEvento.Text != "")
            { nroEvento = int.Parse(TextBoxNroEvento.Text); }


            if (TextBoxNroPresupuesto.Text != "")
            { nroPresupuesto = int.Parse(TextBoxNroPresupuesto.Text); }



            GridViewReporteEventosGenerales.DataSource = reportes.ObtenerReporteEventosPorUnidadesNegocios(nroEvento, nroPresupuesto, TextBoxNroFechaDesde.Text, TextBoxFechaHasta.Text);
            GridViewReporteEventosGenerales.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Index.aspx");
        }
    }
}