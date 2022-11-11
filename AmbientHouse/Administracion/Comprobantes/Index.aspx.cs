using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Comprobantes
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private List<DomainAmbientHouse.Entidades.ComprobantesProveedores> ListComprobantes
        {
            get
            {
                return Session["ListComprobantes"] as List<DomainAmbientHouse.Entidades.ComprobantesProveedores>;
            }
            set
            {
                Session["ListComprobantes"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.ComprobantesProveedores> ListComprobantesSeleccionados
        {
            get
            {
                return Session["ListComprobantesSeleccionados"] as List<DomainAmbientHouse.Entidades.ComprobantesProveedores>;
            }
            set
            {
                Session["ListComprobantesSeleccionados"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListComprobantes = new List<DomainAmbientHouse.Entidades.ComprobantesProveedores>();
                ListComprobantesSeleccionados = new List<DomainAmbientHouse.Entidades.ComprobantesProveedores>();

                CargarListas();
            }
        }

        private void CargarListas()
        {
            DropDownListProveedores.DataSource = servicios.ListarProveedores();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();

            DropDownListEstados.DataSource = servicios.BuscarEstadosPorEntidad("ComprobanteProveedor");
            DropDownListEstados.DataTextField = "Descripcion";
            DropDownListEstados.DataValueField = "Id";
            DropDownListEstados.DataBind();

            DropDownListFormaPago.DataSource = servicios.ObtenerFormasdePago();
            DropDownListFormaPago.DataTextField = "Descripcion";
            DropDownListFormaPago.DataValueField = "Id";
            DropDownListFormaPago.DataBind();

            DropDownListEmpresa.DataSource = servicios.ObtenerEmpresas();
            DropDownListEmpresa.DataTextField = "RazonSocial";
            DropDownListEmpresa.DataValueField = "Id";
            DropDownListEmpresa.DataBind();

        }

        private void BuscarComprobantes()
        {

            DomainAmbientHouse.Entidades.SearcherComprobantes searcher = new DomainAmbientHouse.Entidades.SearcherComprobantes();

            searcher.NroComprobante = TextBoxNroComprobante.Text;
            searcher.ProveedorId = DropDownListProveedores.SelectedItem.Value;
            searcher.NroCuit = TextBoxCuit.Text;
            searcher.Estado = DropDownListEstados.SelectedItem.Value;
            searcher.FormadePago = DropDownListFormaPago.SelectedItem.Value;
            searcher.Empresa = DropDownListEmpresa.SelectedItem.Value;
            searcher.FechaComprobanteDesde = TextBoxFechaComprobanteDesde.Text;
            searcher.FechaComprobanteHasta = TextBoxFechaComprobanteHasta.Text;

            ListComprobantes = servicios.ObtenerComprobantes(searcher);


            LabelTotal.Text = ListComprobantes.Sum(o => o.MontoFactura).Value.ToString("C");

            GridViewComprobantes.DataSource = ListComprobantes.ToList();
            GridViewComprobantes.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewComprobantes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewComprobantes.PageIndex = e.NewPageIndex;

            BuscarComprobantes();
        }

        protected void ButtonPagoProveedor_Click(object sender, EventArgs e)
        {

            int proveedorId = 0;

            ListComprobantesSeleccionados.Clear();

            foreach (GridViewRow row in GridViewComprobantes.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxElementoSeleccionado") as CheckBox;

                if (check.Checked)
                {

                    int itemSeleccionado = Int32.Parse(row.Cells[1].Text);

                    ListComprobantesSeleccionados.Add(ListComprobantes.Where(o => o.Id == itemSeleccionado).FirstOrDefault());

                }

            }

            if (ListComprobantesSeleccionados.Count > 0)
            {
                proveedorId = Int32.Parse(ListComprobantesSeleccionados.FirstOrDefault().ProveedorId.ToString());
                Response.Redirect("~/Administracion/PagoProveedores/Editar.aspx?ProveedorId=" + proveedorId);
            }
        }

        protected void GridViewComprobantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox seleccionado = (CheckBox)e.Row.FindControl("CheckBoxElementoSeleccionado");
                DropDownList empresas = (DropDownList)e.Row.FindControl("DropDownListEmpresas");
                DropDownList tipoComprobante = (DropDownList)e.Row.FindControl("DropDownListTipoComprobantes");

                Button buttonPago = (Button)e.Row.FindControl("ButtonPagoProveedores");

                Button buttonVerPago = (Button)e.Row.FindControl("ButtonVerPago");

                int ComprobanteId = Int32.Parse(e.Row.Cells[1].Text);

                DomainAmbientHouse.Entidades.ComprobantesProveedores comprobantes = servicios.BuscarComprobantes(ComprobanteId);

                empresas.DataSource = servicios.ObtenerEmpresasBlancoProveedores();
                empresas.DataTextField = "RazonSocial";
                empresas.DataValueField = "Id";
                empresas.DataBind();

                tipoComprobante.DataSource = servicios.ObtenerTipoComprobantes();
                tipoComprobante.DataTextField = "Descripcion";
                tipoComprobante.DataValueField = "Id";
                tipoComprobante.DataBind();


                if (comprobantes.EmpresaId != null)
                    empresas.SelectedValue = comprobantes.EmpresaId.ToString();

                tipoComprobante.SelectedValue = comprobantes.TipoComprobanteId.ToString();

                buttonVerPago.Visible = false;

                if (comprobantes.EstadoDescripcion == "Pagada")
                {
                    buttonPago.Visible = false;
                    seleccionado.Visible = false;
                    buttonVerPago.Visible = true;
                }

            }

        }

        protected void ButtonBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarComprobantes();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxCuit.Text = "";
        }

        protected void GridViewComprobantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Pagos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComprobantes.Rows[index];

                ListComprobantesSeleccionados.Clear();

                int Id = Int32.Parse(row.Cells[1].Text);

                ComprobantesProveedores comp = servicios.BuscarComprobantes(Id);

                if (comp != null)
                    ListComprobantesSeleccionados.Add(comp);

                if (ListComprobantesSeleccionados.Count > 0)
                {
                    Response.Redirect("~/Administracion/PagoProveedores/Editar.aspx?ProveedorId=" + comp.ProveedorId);
                }
            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComprobantes.Rows[index];

                DropDownList empresas = (DropDownList)row.FindControl("DropDownListEmpresas");
                DropDownList tipoComprobante = (DropDownList)row.FindControl("DropDownListTipoComprobantes");


                int ComprobanteId = Int32.Parse(row.Cells[1].Text);

                DomainAmbientHouse.Entidades.ComprobantesProveedores comprobantes = servicios.BuscarComprobantes(ComprobanteId);

                comprobantes.TipoComprobanteId = Int32.Parse(tipoComprobante.SelectedItem.Value);
                comprobantes.EmpresaId = Int32.Parse(empresas.SelectedItem.Value);

                servicios.GrabarComprobante(comprobantes);

            }
            else if (e.CommandName == "Anular")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComprobantes.Rows[index];

                int ComprobanteId = Int32.Parse(row.Cells[1].Text);

                servicios.ElimarComprobanteProveedor(ComprobanteId);

            }
            else if (e.CommandName == "NotaCredito")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComprobantes.Rows[index];

                int ComprobanteId = Int32.Parse(row.Cells[1].Text);

                Response.Redirect("~/Administracion/NotaCreditos/Index.aspx?id=" + ComprobanteId);

            }
            else if (e.CommandName == "VerPago")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewComprobantes.Rows[index];

                int ComprobanteId = Int32.Parse(row.Cells[1].Text);

                Response.Redirect("~/Administracion/Comprobantes/VerPago.aspx?id=" + ComprobanteId);

            }
            UpdatePanelGrillaComprobantes.Update();

        }

    }
}