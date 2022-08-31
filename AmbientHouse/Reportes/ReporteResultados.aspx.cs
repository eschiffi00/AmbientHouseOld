using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Web.UI.HtmlControls;

namespace AmbientHouse.Reportes
{
    public partial class ReporteResultados : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxTotalIngresos.Visible = false;
                TextBoxTotalEgresos.Visible = false;
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarInformeResultados();
        }

        private void BuscarInformeResultados()
        {
            List<InformeResultados_Result> ListaInformeResultados = servicios.BuscarInformeResultados(TextBoxNroFechaDesde.Text, TextBoxFechaHasta.Text);

            List<InformeResultados_Result> ListarIngresos = ListaInformeResultados.Where(o => o.Clasificacion.Equals("INGRESOS")).ToList();

            List<InformeResultados_Result> ListarEgresos = ListaInformeResultados.Where(o => o.Clasificacion.Equals("EGRESOS")).ToList();

            GridViewReporteIngresos.DataSource = ListarIngresos;
            GridViewReporteIngresos.DataBind();


            GridViewReporteEgresos.DataSource = ListarEgresos;
            GridViewReporteEgresos.DataBind();

            double Ingresos = 0;
            double Egresos = 0;

            if (ListarIngresos.Count > 0)
            {
                TextBoxTotalIngresos.Visible = true;
                Ingresos = (double)ListarIngresos.Sum(o => o.Total);
                TextBoxTotalIngresos.Text = System.Math.Round(Ingresos, 2).ToString("C");
            }

            if (ListarEgresos.Count > 0)
            {
                TextBoxTotalEgresos.Visible = true;
                Egresos = (double)ListarEgresos.Sum(o => o.Total);
                TextBoxTotalEgresos.Text = System.Math.Round(Egresos, 2).ToString("C");
            }

            double Saldo = Ingresos - Egresos;

            TextBoxSaldo.Text = System.Math.Round(Saldo, 2).ToString("C");
            
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            List<InformeResultados_Result> ListaInformeResultados = servicios.BuscarInformeResultados(TextBoxNroFechaDesde.Text, TextBoxFechaHasta.Text);

            GridView Listar = new GridView();

            Listar.DataSource = ListaInformeResultados.ToList();
            Listar.DataBind();

            Exportar(Listar);
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

        protected void GridViewReporteIngresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetalleIngreso")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteIngresos.Rows[index];

                string tipoMovimineto = row.Cells[0].Text;
                int tipoMovimientoId = Int32.Parse(row.Cells[2].Text);
                string fechaDesde = TextBoxNroFechaDesde.Text;
                string fechaHasta = TextBoxFechaHasta.Text;

                Response.Redirect("~/Reportes/ReporteDetalle.aspx?tm=" + tipoMovimineto + "&tmId=" + tipoMovimientoId + "&fd=" + fechaDesde + "&fh=" + fechaHasta);

            }
        }

        protected void GridViewReporteEgresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetalleEgreso")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteEgresos.Rows[index];

                string tipoMovimineto = row.Cells[0].Text;
                int tipoMovimientoId = Int32.Parse(row.Cells[2].Text);
                string fechaDesde = TextBoxNroFechaDesde.Text;
                string fechaHasta = TextBoxFechaHasta.Text;

                Response.Redirect("~/Reportes/ReporteDetalle.aspx?tm=" + tipoMovimineto + "&tmId=" + tipoMovimientoId + "&fd=" + fechaDesde + "&fh=" + fechaHasta);

            }
        }
    }
}