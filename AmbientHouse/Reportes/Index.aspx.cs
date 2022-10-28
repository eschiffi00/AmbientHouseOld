using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Reportes
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            }

        }

        protected void ButtonReporteAdicionales_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteAdicionales.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonReporteGeneral_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteEventosGeneral.aspx");
        }

        protected void ButtonReporteEventosConfirmados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteEventosConfirmados.aspx");
        }

        protected void ButtonReporteComprobantesProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteComprobantes.aspx");
        }

        protected void ButtonReporteProveedoresEventos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteProveedoresEventosCerrados.aspx");
        }

        protected void ButtonReporteProveedoresEstado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteEstadoProveedoresEventosCerrados.aspx");
        }

        protected void ButtonReporteIvaCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteIvaCompra.aspx");
        }

        protected void ButtonReporteInformeResultados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteResultados.aspx");
        }

        protected void ButtonReporteSimulacionIndexacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/Indexacion.aspx");
        }

        protected void ButtonReporteVentasCobranzas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteCobranzasVentas.aspx");
        }

        protected void ButtonReporteResponsables_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteResponsables.aspx");
        }

        protected void ButtonReporteGastosPorPresupuesto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteGastosPorPresupuesto.aspx");
        }

        protected void ButtonReporteProveedoresAsociados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteProveedoresAsociados.aspx");
        }

        protected void ButtonReporteProveedoresExternos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteProveedoresExternos.aspx");
        }

        protected void ButtonPagosProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReportePagosProveedores.aspx");
        }

        protected void ButtonReporteMovimientosPorCuentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteMovimientosporCuentas.aspx");
        }

        protected void ButtonReporteProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteProductos.aspx");
        }

        protected void ButtonReportePagosProveedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReportePagos.aspx");
        }

        protected void ButtonReporteIvaVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/ReporteIvaVenta.aspx");
        }
    }
}