using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Reportes
{
    public partial class ReportePagosProveedores : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
               GridViewReporte.DataSource = servicios.BuscarPagosProveedores();
                GridViewReporte.DataBind();
            }

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            List<DomainAmbientHouse.Entidades.EventosConfirmadosProveedores> list = servicios.BuscarPagosProveedores();

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