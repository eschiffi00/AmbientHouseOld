using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Reportes
{
    public partial class ReporteDetalle : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private int TipoMovimientoId
        {
            get
            {
                return Int32.Parse(Session["TipoMovimientoId"].ToString());
            }
            set
            {
                Session["TipoMovimientoId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            string tipoMovimiento = "";
            int tipoMovimientoId = 0;
            string fechaDesde = "";
            string fechaHasta = "";

            if (Request["tm"] != null)
                tipoMovimiento = (Request["tm"]);

            if (Request["tmId"] != null)
            {
                tipoMovimientoId = Int32.Parse(Request["tmId"]);
                TipoMovimientoId = tipoMovimientoId;
            }
            if (Request["fd"] != null)
                fechaDesde = (Request["fd"]);

            if (Request["fh"] != null)
                fechaHasta = (Request["fh"]);

            TextBoxMovimiento.Text = tipoMovimiento.ToUpper();
            TextBoxFechaDesde.Text = fechaDesde;
            TextBoxFechaHasta.Text = fechaHasta;
            TextBoxCuenta.Text = servicios.BuscarTipoMovimiento(tipoMovimientoId).Descripcion.ToUpper();

            List<DetalleInformeResultados_Result> Listar = servicios.BuscarDetalleInformeResultados(tipoMovimiento, tipoMovimientoId, fechaDesde, fechaHasta).ToList();

            GridViewReporteIngresos.Visible = false;
            GridViewReporteEgresos.Visible = false;

            TextBoxTotalIngresos.Visible = false;
            TextBoxTotalEgresos.Visible = false;

            if (tipoMovimiento == "INGRESOS")
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

                TextBoxTotalEgresos.Text = System.Math.Round((double)Listar.Sum(o => o.Importe), 2).ToString("C");
            }
        }

        protected void GridViewReporteEgresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList TipoMovimientos = (DropDownList)e.Row.FindControl("DropDownListTipoMovimientos");

                TipoMovimientos.DataSource = servicios.ObtenerTipoMovimientosEgresosyAjuste();
                TipoMovimientos.DataTextField = "Descripcion";
                TipoMovimientos.DataValueField = "Id";
                TipoMovimientos.DataBind();

                TipoMovimientos.SelectedValue = TipoMovimientoId.ToString();
            }
        }

        protected void GridViewReporteEgresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewReporteEgresos.Rows[index];

                DropDownList tipoMovimiento = row.FindControl("DropDownListTipoMovimientos") as DropDownList;

                int detalleComprobanteId = Int32.Parse(row.Cells[0].Text);

                ComprobantesProveedores_Detalles comprobante = servicios.BuscarComprobanteDetalle(detalleComprobanteId);

                comprobante.TipoMoviemientoId = Int32.Parse(tipoMovimiento.SelectedItem.Value);

                if (servicios.EditarComprobanteDetalle(comprobante))
                {
                    InicializarPagina();
                    UpdatePanelGrillaReporte.Update();
                }

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

                PagosClientes pago = servicios.BuscarPagosClientes(pagoClienteId);

                pago.TipoMovimientoId = Int32.Parse(tipoMovimiento.SelectedItem.Value);


                if (servicios.EditarPagosClientes(pago))
                {
                    InicializarPagina();
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

                TipoMovimientos.DataSource = servicios.ObtenerTipoMovimientos().Where(o => o.Id == cuentaClientes ||
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


                TipoMovimientos.SelectedValue = TipoMovimientoId.ToString();
            }
        }

    }
}