using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DbEntidades.Operators;
using DbEntidades.Entities;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using NPOI.SS.Formula.Functions;

using System.Text.RegularExpressions;

namespace AmbientHouse.Reportes
{
    public partial class ReporteCuentaCorrienteProv : System.Web.UI.Page
    {
        DomainAmbientHouse.Servicios.AdministrativasServicios administrativas = new DomainAmbientHouse.Servicios.AdministrativasServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarListas();
                
            }

        }
        private void CargarListas()
        {
            DropDownListTipoMovimiento.DataSource = administrativas.ObtenerTipoMovimientosEgresos().OrderBy(x => x.Descripcion);
            DropDownListTipoMovimiento.DataTextField = "Identificador";
            DropDownListTipoMovimiento.DataValueField = "Id";
            DropDownListTipoMovimiento.DataBind();
        }
        private void Buscar()
        {
            parametros2 Cuenta = new parametros2();
            Cuenta.FechaDesde = TextBoxNroFechaDesde.Text;
            Cuenta.FechaHasta = TextBoxFechaHasta.Text;
            //Cuenta.TipoMovimientoId = DropDownListTipoMovimiento.SelectedItem.Value;
            Cuenta.NroPresupuesto = Int32.Parse(TextBoxPresupuesto.Text !="" ? TextBoxPresupuesto.Text: "0");
            Cuenta.CuitProveedor = TextBoxNroCuit.Text;
            Cuenta.TipoMovimiento = DropDownListTipoMovimiento.SelectedItem.Text;
            if(Cuenta.TipoMovimiento == "<Todas>") 
            { Cuenta.TipoMovimiento = string.Empty; }
            else
            {
                Cuenta.TipoMovimiento = Cuenta.TipoMovimiento.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            List<CuentaCorrienteProveedores> list = CuentaCorrienteProveedoresOperator.FiltrarCuentaCorriente(Cuenta);
     
            GridViewReporte.DataSource = list;
            GridViewReporte.DataBind();

            UpdatePanelGrillaReporte.Update();
        }
        double subtotal = 0.0;
        double facturaTotal = 0.0;
        double ImporteTotal = 0.0;

        protected void GridViewReporte_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                var cadena = "";
                cadena = e.Row.Cells[10].Text;
                cadena = cadena.Replace("$ ", String.Empty);
                cadena = cadena.Replace(".", String.Empty);
                if (int.TryParse(cadena, out _)) 
                { 
                    subtotal += float.Parse(cadena);
                    facturaTotal += float.Parse(cadena);
                }
                cadena = e.Row.Cells[13].Text;
                cadena = cadena.Replace("$ ", String.Empty);
                cadena = cadena.Replace(".", String.Empty);
                if (int.TryParse(cadena, out _))
                {
                    ImporteTotal += float.Parse(cadena);
                    subtotal -= float.Parse(cadena);
                }
                for(var cell = 0; cell < e.Row.Cells.Count;cell ++)
                {
                    if(e.Row.Cells[cell].Text.Replace("$ ", String.Empty) == "0")
                    {
                        e.Row.Cells[cell].Text = string.Empty;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[10].Width = 200;
                e.Row.Cells[10].Text = "$ " + Convert.ToString(facturaTotal);
                e.Row.Cells[13].Text = "$ " + Convert.ToString(ImporteTotal);
                e.Row.Cells[14].Text = "$ " + Convert.ToString(subtotal);
            }
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
            List<CuentaCorrienteProveedores> list = CuentaCorrienteProveedoresOperator.GetAll();

            GridView excel = new GridView();

            excel.DataSource = list.ToList();
            excel.DataBind();

            Exportar(excel);
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