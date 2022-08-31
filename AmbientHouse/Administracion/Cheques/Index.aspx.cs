using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Web.UI.HtmlControls;

namespace AmbientHouse.Administracion.Cheques
{
    public partial class Index : System.Web.UI.Page
    {
        private List<DomainAmbientHouse.Entidades.Cheques> ListCheques
        {
            get
            {
                return Session["ListCheques"] as List<DomainAmbientHouse.Entidades.Cheques>;
            }
            set
            {
                Session["ListCheques"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Cheques> ListChequesSeleccionados
        {
            get
            {
                return Session["ListCequesSeleccionados"] as List<DomainAmbientHouse.Entidades.Cheques>;
            }
            set
            {
                Session["ListCequesSeleccionados"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

        AdministrativasServicios servicios = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListCheques = new List<DomainAmbientHouse.Entidades.Cheques>();
                ListChequesSeleccionados = new List<DomainAmbientHouse.Entidades.Cheques>();

                CargarListas();

            }

        }

        private void CargarListas()
        {
            DropDownListCuentas.DataSource = servicios.ObtenerCuentas();
            DropDownListCuentas.DataTextField = "Nombre";
            DropDownListCuentas.DataValueField = "Id";
            DropDownListCuentas.DataBind();


            DropDownListEstados.DataSource = servicios.BuscarEstadosPorEntidad("Cheques");
            DropDownListEstados.DataTextField = "Descripcion";
            DropDownListEstados.DataValueField = "Id";
            DropDownListEstados.DataBind();

        }

        private void BuscarCheques(string Saldo, string OtrosDebitos)
        {

            ChequesSearcher searcher = new ChequesSearcher();

            searcher.NroCheque = TextBoxNroCheque.Text;
            searcher.FechaEmisionDesde = TextBoxFechaEmisionDesde.Text;
            searcher.FechaEmisionHasta = TextBoxFechaEmisionHasta.Text;
            searcher.FechaVencimientoDesde = TextBoxFechaVencimientoDesde.Text;
            searcher.FechaVencimientoHasta = TextBoxFechaVencimientoHasta.Text;
            searcher.RazonSocial = TextBoxRazonSocial.Text;
            searcher.EstadoId = DropDownListEstados.SelectedItem.Value;
            

            ListCheques = servicios.ListarCheques(searcher);

            double SaldoCuenta = cmd.IsNumeric(Saldo)? cmd.ValidarImportes(Saldo):0;
            double OtrosDebitosCuenta = cmd.IsNumeric(OtrosDebitos) ? cmd.ValidarImportes(OtrosDebitos) : 0;

            SaldoCuenta = SaldoCuenta - OtrosDebitosCuenta;

            if (DropDownListCuentas.SelectedValue != "0")
            {
                ListCheques = ListCheques.Where(o => o.CuentaDescripcion.Contains(DropDownListCuentas.SelectedItem.Text)).ToList();
            }

            TextBoxImporte.Text = ListCheques.Sum(o => o.Importe).ToString("C");

            //double totalPendienteProveedores = ListCheques.Where(o => o.EstadoId == 28 && o.ProveedorId != null).Sum(o => o.Importe);

            //TextBoxImportePendienteProveedor.Text = totalPendienteProveedores.ToString("C");

            //double totalPendienteClientes = ListCheques.Where(o => o.EstadoId == 28 && o.ClienteId != null).Sum(o => o.Importe);

            //TextBoxImportePendienteClientes.Text = totalPendienteClientes.ToString("C");

            foreach (var item in ListCheques)
            {
                if (SaldoCuenta != 0)
                    SaldoCuenta = SaldoCuenta - item.Importe;
                else
                    SaldoCuenta = 0;

                item.Saldo = SaldoCuenta;
            }

            GridViewCheques.DataSource = ListCheques.OrderBy(o=> o.FechaVencimiento).ToList();
            GridViewCheques.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cheques/Editar.aspx");
        }

        protected void GridViewCheques_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCheques.PageIndex = e.NewPageIndex;

            BuscarCheques(TextBoxSaldoCuenta.Text, TextBoxOtrosConceptoADebitar.Text );
        }

        protected void ButtonAcreditados_Click(object sender, EventArgs e)
        {
            ListChequesSeleccionados.Clear();

            foreach (GridViewRow row in GridViewCheques.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxElementoSeleccionado") as CheckBox;

                if (check.Checked)
                {

                    int itemSeleccionado = Int32.Parse(row.Cells[1].Text);

                    ListChequesSeleccionados.Add(ListCheques.Where(o => o.Id == itemSeleccionado).FirstOrDefault());

                }

            }

            if (ListChequesSeleccionados.Count > 0)
            {
                servicios.AcreditarCheques(ListChequesSeleccionados, EmpleadoId);

                BuscarCheques(TextBoxSaldoCuenta.Text, TextBoxOtrosConceptoADebitar.Text);
            }


            UpdatePanelGrillaCheques.Update();
        }

        protected void GridViewCheques_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList cuenta = (DropDownList)e.Row.FindControl("DropDownListCuenta");

                CheckBox seleccionado = (CheckBox)e.Row.FindControl("CheckBoxElementoSeleccionado");


                if (double.Parse(e.Row.Cells[11].Text) < 0)
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                   
                }

                if (e.Row.Cells[9].Text == "Pagado")
                {
                    seleccionado.Visible = false;
                }

                int chequeId = Int32.Parse(e.Row.Cells[1].Text);

                PagosProveedores pago = servicios.BuscarPagosPorCheques(chequeId);

                cuenta.DataSource = servicios.ObtenerCuentas();
                cuenta.DataTextField = "Nombre";
                cuenta.DataValueField = "Id";
                cuenta.DataBind();

                if (pago != null)
                    cuenta.SelectedValue = pago.CuentaId.ToString();
                else
                    cuenta.Visible = false;
            }

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarCheques(TextBoxSaldoCuenta.Text, TextBoxOtrosConceptoADebitar.Text);
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxNroCheque.Text = "";
            TextBoxRazonSocial.Text = "";
            TextBoxFechaEmisionDesde.Text = "";
            TextBoxFechaVencimientoDesde.Text = "";
            TextBoxFechaEmisionHasta.Text = "";
            TextBoxFechaVencimientoHasta.Text = "";
            DropDownListCuentas.SelectedValue = "0";

            BuscarCheques(TextBoxSaldoCuenta.Text, TextBoxOtrosConceptoADebitar.Text);
        }

        protected void DropDownListCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCuentas.SelectedItem.Value != "0")
            {
                DomainAmbientHouse.Entidades.Cuentas_Log log = servicios.BuscarUltimoMovimientoCuenta(Int32.Parse(DropDownListCuentas.SelectedItem.Value));

                if (cmd.IsNumeric(log.SaldoActual))
                {
                    TextBoxSaldo.Text = log.SaldoActual.ToString("C");
                }

            }
        }

        protected void GridViewCheques_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCheques.Rows[index];

                DropDownList cuentas = row.FindControl("DropDownListCuenta") as DropDownList;

                int ChequeId = Int32.Parse(row.Cells[1].Text);

                DomainAmbientHouse.Entidades.PagosProveedores pago = servicios.BuscarPagosPorCheques(ChequeId);

                pago.CuentaId = Int32.Parse(cuentas.SelectedItem.Value);

                try
                {
                    servicios.ActualizarPagoProveedor(pago);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCheques.Rows[index];

                int ChequeId = Int32.Parse(row.Cells[1].Text);

                Response.Redirect("~/Administracion/Cheques/Editar.aspx?Id=" + ChequeId);
              
            }

            BuscarCheques(TextBoxSaldoCuenta.Text, TextBoxOtrosConceptoADebitar.Text);
            UpdatePanelGrillaCheques.Update();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            
            GridView Total = new GridView();

            ChequesSearcher searcher = new ChequesSearcher();

            searcher.NroCheque = TextBoxNroCheque.Text;
            searcher.FechaEmisionDesde = TextBoxFechaEmisionDesde.Text;
            searcher.FechaEmisionHasta = TextBoxFechaEmisionHasta.Text;
            searcher.FechaVencimientoDesde = TextBoxFechaVencimientoDesde.Text;
            searcher.FechaVencimientoHasta = TextBoxFechaVencimientoHasta.Text;
            searcher.RazonSocial = TextBoxRazonSocial.Text;
            searcher.EstadoId = DropDownListEstados.SelectedItem.Value;


            ListCheques = servicios.ListarCheques(searcher);

         

            Total.DataSource = ListCheques.OrderBy(o => o.FechaVencimiento).ToList();
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
    }
}