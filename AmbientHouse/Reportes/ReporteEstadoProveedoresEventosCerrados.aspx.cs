﻿using System;
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
    public partial class ReporteEstadoProveedoresEventosCerrados : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Searcher();

                CargarLista();

            }

        }

        private void CargarLista()
        {
            DropDownListUnidadNegocio.DataSource = administrativas.ObtenerUNReporte();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();


            DropDownListProveedores.DataSource = eventos.ObtenerProveedoresCotizador();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();
        }

        private void Searcher()
        {
            int nroPresupuesto = 0;
            if (cmd.IsNumeric(TextBoxDescripcionBuscador.Text))
                nroPresupuesto = Int32.Parse(TextBoxDescripcionBuscador.Text);


            int unidadNegocioId = 0;
            if (DropDownListUnidadNegocio.SelectedItem.Value != "null")
                unidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);

            int proveedorId = 0;
            if (DropDownListProveedores.SelectedItem.Value != "null")
                proveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);




            Buscar(nroPresupuesto, TextBoxNroFechaDesde.Text, TextBoxFechaHasta.Text, unidadNegocioId, DropDownListEstadoProveedor.SelectedItem.Value, proveedorId);
        }

        private void Buscar(int nropresupuesto, string fechaeventodesde, string fechaeventohasta, int unidadnegocioId,string estadoProveedor, int proveedorId)
        {


            List<ObtenerEventosPresupuestosProveedores> list = eventos.BuscarProveedoresEstadosEventosConfirmados(nropresupuesto, fechaeventodesde, fechaeventohasta, unidadnegocioId, estadoProveedor, proveedorId);

            GridViewReporte.DataSource = list.ToList();
            GridViewReporte.DataBind();
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
            Searcher();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar(GridViewReporte);
        }
    }
}