using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace AmbientHouse.Reportes
{
    public partial class ReporteResponsables : System.Web.UI.Page
    {
        ReporteServicios reporte = new ReporteServicios();
        AdministrativasServicios administrativa = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HabilitarCheckOrganizador();
                HabilitarCheckCoordinador1();
                HabilitarCheckCoordinador2();

                CargarListas();
            }
        }

        private void CargarListas()
        {
            int coordinador = Int32.Parse(ConfigurationManager.AppSettings["TipoEmpleadoCoordinador"].ToString());

            DropDownListCoordinador1.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(coordinador);
            DropDownListCoordinador1.DataTextField = "ApellidoNombre";
            DropDownListCoordinador1.DataValueField = "Id";
            DropDownListCoordinador1.DataBind();

            DropDownListCoordinador2.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(coordinador);
            DropDownListCoordinador2.DataTextField = "ApellidoNombre";
            DropDownListCoordinador2.DataValueField = "Id";
            DropDownListCoordinador2.DataBind();

            DropDownListOrganizador.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(coordinador);
            DropDownListOrganizador.DataTextField = "ApellidoNombre";
            DropDownListOrganizador.DataValueField = "Id";
            DropDownListOrganizador.DataBind();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();

        }

        private void Buscar()
        {
            ResponsablesSearcher searcher = new ResponsablesSearcher();

            searcher.NroPresupuesto = TextBoxNroPresupuesto.Text;
            searcher.FechaDesde = TextBoxFechaDesde.Text;
            searcher.FechaHasta = TextBoxFechaHasta.Text;

            if (!CheckBoxOrganizador.Checked)
                searcher.Organizador = DropDownListOrganizador.SelectedItem.Value;
            else
                searcher.Organizador = "SA";

            if (!CheckBoxCoordinador1.Checked)
                searcher.Coordinador1 = DropDownListCoordinador1.SelectedItem.Value;
            else
                searcher.Coordinador1 = "SA";

            if (!CheckBoxCoordinador2.Checked)
                searcher.Coordinador2 = DropDownListCoordinador2.SelectedItem.Value;
            else
                searcher.Coordinador2 = "SA";


            List<ResponsablesEventos> responsables = reporte.ListarResponsablesEventos(searcher).ToList();

            GridViewReporte.DataSource = responsables.ToList();
            GridViewReporte.DataBind();

            UpdatePanelGrillaReporte.Update();
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

        protected void CheckBoxOrganizador_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCheckOrganizador();

           
        }

        protected void CheckBoxCoordinador1_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCheckCoordinador1();
        }

        protected void CheckBoxCoordinador2_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCheckCoordinador2();
        }

        private void HabilitarCheckOrganizador()
        {
            DropDownListOrganizador.Enabled = !CheckBoxOrganizador.Checked;

            UpdatePanelBuscador.Update();
        }

        private void HabilitarCheckCoordinador1()
        {
            DropDownListCoordinador1.Enabled = !CheckBoxCoordinador1.Checked;

            UpdatePanelBuscador.Update();

        }

        private void HabilitarCheckCoordinador2()
        {
            DropDownListCoordinador2.Enabled = !CheckBoxCoordinador2.Checked;

            UpdatePanelBuscador.Update();
        }

    }
}