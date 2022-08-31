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
    public partial class ReporteEventosConfirmados : System.Web.UI.Page
    {
        private List<ObtenerEventos> ListPresupuestosConfirmados
        {
            get
            {
                return Session["ListPresupuestosConfirmados"] as List<ObtenerEventos>; 
            }
            set
            {
                Session["ListPresupuestosConfirmados"] = value;
            }
        }

        EventosServicios eventos = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                BuscarEventosConfirmados();

            }
        }

        private void BuscarEventosConfirmados()
        {
            ListPresupuestosConfirmados = new List<ObtenerEventos>();

            ListPresupuestosConfirmados = eventos.BuscarEventosConfirmadosReservados();


            //HtmlTable table =  GenerarTabla(ListPresupuestosConfirmados.ToList().Count(), 3);
            //Panel1.Controls.Add(table);

            GridViewEventosConfirmados.DataSource = ListPresupuestosConfirmados.ToList();
            GridViewEventosConfirmados.DataBind();
        }

        private HtmlTable GenerarTabla(int filas, int columnas)
        {
            HtmlTable tabla = new HtmlTable();

            for (int i = 1; i < filas; i++)
            {

                HtmlTableRow fila = new HtmlTableRow();

                for (int j = 1; j < columnas; j++)
                {
                    HtmlTableCell celda = new HtmlTableCell();

                    celda.InnerHtml = "<strong>ejemplo<strong>";
                }
                
            }

            return tabla;
        
        }

        protected void GridViewEventosConfirmados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEventosConfirmados.PageIndex = e.NewPageIndex;

            BuscarEventosConfirmados();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();

            Total.DataSource = eventos.BuscarEventosConfirmadosReservados();
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

    //    Private Function GenerarTabla(ByVal filas As Integer, ByVal columnas As Integer) As HtmlTable
    //    Dim t As New HtmlTable

    //    For i As Integer = 1 To filas
    //        Dim fila As New HtmlTableRow
    //        For j As Integer = 1 To columnas

    //            Dim celda As New HtmlTableCell

    //            'Insertar contenido html dentro de la celda
    //            '   <td><strong>ejemplo<strong><td>
    //            celda.InnerHtml = "<strong>ejemplo<strong>"

    //            fila.Cells.Add(celda)
    //        Next
    //        t.Rows.Add(fila)
    //    Next

    //    Return t
    //End Function
    }
}