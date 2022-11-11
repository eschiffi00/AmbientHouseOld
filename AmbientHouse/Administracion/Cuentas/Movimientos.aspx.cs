using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Movimientos : System.Web.UI.Page
    {
        private int CuentaId
        {
            get
            {
                return Int32.Parse(Session["CuentaId"].ToString());
            }
            set
            {
                Session["CuentaId"] = value;
            }
        }

        ReporteServicios reporte = new ReporteServicios();
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CuentaId = id;
            }


        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();


        }

        private void Buscar()
        {
            MovimientosCuentasSearcher searcher = new MovimientosCuentasSearcher();

            searcher.FechaDesde = TextBoxNroFechaDesde.Text;
            searcher.FechaHasta = TextBoxFechaHasta.Text;
            searcher.CuentaId = CuentaId;

            List<MovimientosCuentas> list = reporte.ListarMovimientos(searcher);

            GridViewReporteMovimientos.DataSource = list.ToList();
            GridViewReporteMovimientos.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar(GridViewReporteMovimientos);
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

        protected void GridViewReporteMovimientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Descripcion = (TextBox)e.Row.FindControl("TextBoxDescripcion");
                Button ElimanarMovimiento = (Button)e.Row.FindControl("ButtonEliminarMovimiento");

                int id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Cuentas_Log cuentasLog = administracion.BuscarMovimiento(id);

                DomainAmbientHouse.Entidades.Cuentas_Log ultimoMovimiento = administracion.BuscarUltimoMovimientoCuenta((int)cuentasLog.CuentaId);

                ElimanarMovimiento.Visible = false;

                if (cuentasLog.Id == ultimoMovimiento.Id)
                    ElimanarMovimiento.Visible = true;


                if (cuentasLog.Descripcion != null)
                    Descripcion.Text = cuentasLog.Descripcion.ToString();
            }
        }

        protected void GridViewReporteMovimientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteMovimientos.Rows[index];

                TextBox descripcion = row.FindControl("TextBoxDescripcion") as TextBox;

                int id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Cuentas_Log cuentasLog = administracion.BuscarMovimiento(id);

                cuentasLog.Descripcion = descripcion.Text;

                administracion.EditarMovimiento(cuentasLog);

                UpdatePanelGrillaReporteMovimientos.Update();
            }
            else if (e.CommandName == "EliminarPago")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteMovimientos.Rows[index];

                int id = Int32.Parse(row.Cells[0].Text);

                administracion.EliminarCuentasLog(id);

                Buscar();

                UpdatePanelGrillaReporteMovimientos.Update();
            }

        }

    }
}