using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Reportes
{
    public partial class ReporteMovimientosporCuentas : System.Web.UI.Page
    {

        private string TipoMovimiento
        {
            get
            {
                return Session["TipoMovimiento"].ToString();
            }
            set
            {
                Session["TipoMovimiento"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoMovimiento = DropDownListTipoGasto.SelectedValue;

                CargarListas();

                TextBoxTotalIngresos.Visible = false;
                TextBoxTotalEgresos.Visible = false;
            }
        }

        private void CargarListas()
        {
            if (TipoMovimiento == "EGRESOS")
            {
                DropDownListCuentas.DataSource = administracion.ObtenerTipoMovimientosEgresos();
                DropDownListCuentas.DataTextField = "Identificador";
                DropDownListCuentas.DataValueField = "Id";
                DropDownListCuentas.DataBind();
            }
            else
            {
                int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());
                int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
                int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
                int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
                int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());
                int cuentaImpuestosMusicales = Int32.Parse(ConfigurationManager.AppSettings["CuentaImpuestoMusicales"].ToString());
                int valletParking = Int32.Parse(ConfigurationManager.AppSettings["CuentaVallet"].ToString());
                int canon = Int32.Parse(ConfigurationManager.AppSettings["CuentaCanon"].ToString());
                int cuentaRetencionesIIBBARBA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBBARBA"].ToString());
                int cuentaGastosRepresentacion = Int32.Parse(ConfigurationManager.AppSettings["CuentaGASTOSREPRESENTACION"].ToString());
                int cuentaDiferenciaCambio = Int32.Parse(ConfigurationManager.AppSettings["CuentaDIFERENCIACAMBIO"].ToString());
                int cuentaOtrosIngresos = Int32.Parse(ConfigurationManager.AppSettings["CuentaOTROSINGRESOS"].ToString());
                int cuentaDepositoEnGarantia = Int32.Parse(ConfigurationManager.AppSettings["CuentaDEPOSITOENGARANTIA"].ToString());

                DropDownListCuentas.DataSource = administracion.ObtenerTipoMovimientos().Where(o => o.Id == cuentaClientes ||
                                                                                                        o.Id == cuentaRetencionesGanancias ||
                                                                                                        o.Id == cuentaRetencionesIVA ||
                                                                                                        o.Id == cuentaRetencionesIIBB ||
                                                                                                        o.Id == cuentaRetencionesSUSS ||
                                                                                                        o.Id == cuentaImpuestosMusicales ||
                                                                                                        o.Id == valletParking ||
                                                                                                        o.Id == canon ||
                                                                                                        o.Id == cuentaRetencionesIIBBARBA ||
                                                                                                        o.Id == cuentaGastosRepresentacion ||
                                                                                                        o.Id == cuentaDiferenciaCambio ||
                                                                                                        o.Id == cuentaOtrosIngresos ||
                                                                                                        o.Id == cuentaDepositoEnGarantia);
                DropDownListCuentas.DataTextField = "Identificador";
                DropDownListCuentas.DataValueField = "Id";
                DropDownListCuentas.DataBind();
            }
        }

        private void Buscar()
        {

            int tipoMovimientoId = 0;
            string fechaDesde = "";
            string fechaHasta = "";

            TipoMovimiento = DropDownListTipoGasto.SelectedValue;

            tipoMovimientoId = Int32.Parse(DropDownListCuentas.SelectedValue);

            if (!string.IsNullOrEmpty(TextBoxNroFechaDesde.Text))
                fechaDesde = TextBoxNroFechaDesde.Text;

            if (!string.IsNullOrEmpty(TextBoxFechaHasta.Text))
                fechaHasta = TextBoxFechaHasta.Text;

            //TextBoxMovimiento.Text = tipoMovimiento.ToUpper();
            //TextBoxFechaDesde.Text = fechaDesde;
            //TextBoxFechaHasta.Text = fechaHasta;
            //TextBoxCuenta.Text = servicios.BuscarTipoMovimiento(tipoMovimientoId).Descripcion.ToUpper();

            List<DetalleInformeResultados_Result> Listar = administracion.BuscarDetalleInformeResultados(TipoMovimiento, tipoMovimientoId, fechaDesde, fechaHasta).ToList();

            GridViewReporteIngresos.Visible = false;
            GridViewReporteEgresos.Visible = false;

            TextBoxTotalIngresos.Visible = false;
            TextBoxTotalEgresos.Visible = false;

            if (TipoMovimiento == "INGRESOS")
            {
                GridViewReporteIngresos.Visible = true;
                TextBoxTotalIngresos.Visible = true;

                GridViewReporteIngresos.DataSource = Listar.OrderBy(o => o.Fecha).ToList();
                GridViewReporteIngresos.DataBind();

                TextBoxTotalIngresos.Text = System.Math.Round((double)Listar.Sum(o => o.Importe), 2).ToString("C");
            }
            else
            {
                GridViewReporteEgresos.Visible = true;
                TextBoxTotalEgresos.Visible = true;

                GridViewReporteEgresos.DataSource = Listar.OrderBy(o => o.Fecha).ToList();
                GridViewReporteEgresos.DataBind();

                TextBoxTotalEgresos.Visible = true;
                TextBoxTotalEgresos.Text = System.Math.Round((double)Listar.Sum(o => o.Importe), 2).ToString("C");
            }

            UpdatePanelGrillaReporte.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {

            int tipoMovimientoId = 0;
            string fechaDesde = "";
            string fechaHasta = "";

            TipoMovimiento = DropDownListTipoGasto.SelectedValue;

            if (DropDownListCuentas.SelectedIndex > 0)
                tipoMovimientoId = Int32.Parse(DropDownListCuentas.SelectedValue);

            if (!string.IsNullOrEmpty(TextBoxNroFechaDesde.Text))
                fechaDesde = TextBoxNroFechaDesde.Text;

            if (!string.IsNullOrEmpty(TextBoxFechaHasta.Text))
                fechaHasta = TextBoxFechaHasta.Text;

            List<DetalleInformeResultados_Result> listado = new List<DetalleInformeResultados_Result>();

            if (TipoMovimiento == "INGRESOS")
                listado = administracion.BuscarDetalleInformeResultados(TipoMovimiento, tipoMovimientoId, fechaDesde, fechaHasta).ToList();
            else
                listado = administracion.BuscarDetalleInformeResultados(TipoMovimiento, tipoMovimientoId, fechaDesde, fechaHasta).ToList();


            GridView Listar = new GridView();

            Listar.DataSource = listado.ToList();
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

        protected void GridViewReporteEgresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteEgresos.Rows[index];

                DropDownList tipoMovimiento = row.FindControl("DropDownListTipoMovimientos") as DropDownList;

                int detalleComprobanteId = Int32.Parse(row.Cells[0].Text);

                ComprobantesProveedores_Detalles comprobante = administracion.BuscarComprobanteDetalle(detalleComprobanteId);

                comprobante.TipoMoviemientoId = Int32.Parse(tipoMovimiento.SelectedItem.Value);

                if (administracion.EditarComprobanteDetalle(comprobante))
                {
                    Buscar();
                    UpdatePanelGrillaReporte.Update();
                }

            }
        }

        protected void GridViewReporteEgresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList TipoMovimientos = (DropDownList)e.Row.FindControl("DropDownListTipoMovimientos");

                TipoMovimientos.DataSource = administracion.ObtenerTipoMovimientosEgresosyAjuste();
                TipoMovimientos.DataTextField = "Descripcion";
                TipoMovimientos.DataValueField = "Id";
                TipoMovimientos.DataBind();

                TipoMovimientos.SelectedValue = DropDownListCuentas.SelectedValue;
            }
        }

        protected void GridViewReporteIngresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteIngresos.Rows[index];

                DropDownList tipoMovimiento = row.FindControl("DropDownListTipoMovimientos") as DropDownList;

                int pagoClienteId = Int32.Parse(row.Cells[0].Text);

                PagosClientes pago = administracion.BuscarPagosClientes(pagoClienteId);

                pago.TipoMovimientoId = Int32.Parse(tipoMovimiento.SelectedItem.Value);


                if (administracion.EditarPagosClientes(pago))
                {
                    Buscar();
                    UpdatePanelGrillaReporte.Update();
                }
            }
        }

        protected void GridViewReporteIngresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int cuentaClientes = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString());
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());
            int cuentaImpuestosMusicales = Int32.Parse(ConfigurationManager.AppSettings["CuentaImpuestoMusicales"].ToString());
            int valletParking = Int32.Parse(ConfigurationManager.AppSettings["CuentaVallet"].ToString());
            int canon = Int32.Parse(ConfigurationManager.AppSettings["CuentaCanon"].ToString());
            int cuentaRetencionesIIBBARBA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBBARBA"].ToString());
            int cuentaGastosRepresentacion = Int32.Parse(ConfigurationManager.AppSettings["CuentaGASTOSREPRESENTACION"].ToString());
            int cuentaDiferenciaCambio = Int32.Parse(ConfigurationManager.AppSettings["CuentaDIFERENCIACAMBIO"].ToString());
            int cuentaAjuste = Int32.Parse(ConfigurationManager.AppSettings["CuentaAJUSTE"].ToString());


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList TipoMovimientos = (DropDownList)e.Row.FindControl("DropDownListTipoMovimientos");

                TipoMovimientos.DataSource = administracion.ObtenerTipoMovimientos().Where(o => o.Id == cuentaClientes ||
                                                                                        o.Id == cuentaRetencionesGanancias ||
                                                                                        o.Id == cuentaRetencionesIVA ||
                                                                                        o.Id == cuentaRetencionesIIBB ||
                                                                                        o.Id == cuentaRetencionesSUSS ||
                                                                                        o.Id == cuentaImpuestosMusicales ||
                                                                                        o.Id == valletParking ||
                                                                                        o.Id == canon ||
                                                                                        o.Id == cuentaRetencionesIIBBARBA ||
                                                                                        o.Id == cuentaGastosRepresentacion ||
                                                                                        o.Id == cuentaDiferenciaCambio ||
                                                                                        o.Id == cuentaAjuste);

                TipoMovimientos.DataTextField = "Descripcion";
                TipoMovimientos.DataValueField = "Id";
                TipoMovimientos.DataBind();


                TipoMovimientos.SelectedValue = DropDownListCuentas.SelectedValue;
            }
        }

        protected void DropDownListTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListTipoGasto.SelectedItem != null)
            {
                TipoMovimiento = DropDownListTipoGasto.SelectedValue.ToString();

                CargarListas();

                UpdatePanelBuscador.Update();
            }

        }
    }
}