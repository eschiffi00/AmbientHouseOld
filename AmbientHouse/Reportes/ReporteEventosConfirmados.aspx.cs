using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Web.UI.HtmlControls;
using DbEntidades.Entities;
using DbEntidades.Operators;
using DBEntidades.Entities;

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
            List<NewEventosConfirmados> eventosNew = new List<NewEventosConfirmados>();
            eventosNew = CargarNuevoReporte(ListPresupuestosConfirmados.ToList());
            GridViewEventosConfirmados.DataSource = eventosNew;
            GridViewEventosConfirmados.DataBind();
        }
        public List<NewEventosConfirmados> CargarNuevoReporte(List<ObtenerEventos> lista)
        {
            List<NewEventosConfirmados> EventosConfirmadosNew = new List<NewEventosConfirmados>();
            NewEventosConfirmados e = new NewEventosConfirmados();
            foreach(var evento in lista) { 
                e.ApellidoNombre = evento.ApellidoNombre;
                e.CARACTERISTICA = evento.CARACTERISTICA;
                e.LOCACION = evento.LOCACION;
                e.SECTOR = evento.SECTOR;
                e.JORNADA = evento.JORNADA;
                e.HorarioEvento = evento.HorarioEvento;
                e.CantidadInicialInvitados = evento.CantidadInicialInvitados;
                e.FechaEvento = evento.FechaEvento;
                e.Id = evento.Id;
                e.Estado = evento.Estado;
                e.Ejecutivo = evento.Ejecutivo;
                e.EventoId = evento.EventoId;
                e.ClienteId = evento.ClienteId;
                e.EmpleadoId = evento.EmpleadoId;
                e.EstadoId = evento.EstadoId;
                e.RazonSocial = evento.RazonSocial;
                e.Fecha = evento.Fecha;
                e.PresupuestoId = evento.PresupuestoId;
                e.PresupuestoEstadoId = evento.PresupuestoEstadoId;
                e.EstadoPresupuesto = evento.EstadoPresupuesto;
                e.PresupuestoIdAnterior = evento.PresupuestoIdAnterior;
                e.LocacionId = evento.LocacionId;
                e.EmpleadoCliente = evento.EmpleadoCliente;
                e.TipoEvento = evento.TipoEvento;
                e.ClienteBisId = evento.ClienteBisId;
                e.Cliente = evento.Cliente;
                e.FechaSena = evento.FechaSena;
                e.TipoEventoId = evento.TipoEventoId;
                var producto = ProductosOperator.GetOneByIdentity(PresupuestoDetalleOperator.GetOneByIdentity(e.PresupuestoId).ProductoId);
                e.TipoExperiencia = TipoCateringOperator.GetOneByIdentity(producto.TipoCateringId.Value).Descripcion == null ? " " : TipoCateringOperator.GetOneByIdentity(producto.TipoCateringId.Value).Descripcion;
                e.TipoBarra = TiposBarrasOperator.GetOneByIdentity(producto.TipoBarraId.Value).Descripcion == null ? " " : TiposBarrasOperator.GetOneByIdentity(producto.TipoBarraId.Value).Descripcion;
                EventosConfirmadosNew.Add(e);
            }
            return EventosConfirmadosNew.ToList();
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