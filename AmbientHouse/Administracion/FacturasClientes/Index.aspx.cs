using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.FacturasClientes
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                Buscar();
            }
        }

        private void CargarListas()
        {
            DropDownListEmpresa.DataSource = administracion.ObtenerEmpresas();
            DropDownListEmpresa.DataTextField = "RazonSocial";
            DropDownListEmpresa.DataValueField = "Id";
            DropDownListEmpresa.DataBind();

            DropDownListEstados.DataSource = administracion.BuscarEstadosPorEntidad("FacturasCliente");
            DropDownListEstados.DataTextField = "Descripcion";
            DropDownListEstados.DataValueField = "Id";
            DropDownListEstados.DataBind();
        }

        private void Buscar()
        {
            FacturasClienteSearcher searcher = new FacturasClienteSearcher();

            searcher.EmpresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);
            searcher.NroFactura = TextBoxNroFactura.Text;
            searcher.PresupuestoId = TextBoxNroPresupuesto.Text;
            searcher.FechaDesde = TextBoxFechaDesde.Text;
            searcher.FechaHasta = TextBoxFechaHasta.Text;
            searcher.EstadoId = Int32.Parse(DropDownListEstados.SelectedItem.Value);

            searcher.Cuit = TextBoxCuit.Text;
            searcher.RazonSocial = TextBoxRazonSocial.Text;

            var list = administracion.ListarFacturasClientes(searcher);

            if (!String.IsNullOrWhiteSpace(searcher.Cuit))
            {
                list = list.Where(o => o.CUIT.Contains(searcher.Cuit)).ToList();
            }

            if (!String.IsNullOrWhiteSpace(searcher.RazonSocial))
            {
                list = list.Where(o => o.ClienteDescripcion.Contains(searcher.RazonSocial)).ToList();
            }


            GridViewFacturas.DataSource = list.ToList();
            GridViewFacturas.DataBind();

            UpdatePanelGrillaCheques.Update();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/FacturasClientes/Editar.aspx");
        }

        protected void GridViewFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewFacturas.PageIndex = e.NewPageIndex;

            Buscar();

        }

        protected void GridViewFacturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewFacturas.Rows[index];

                DropDownList estados = (DropDownList)row.FindControl("DropDownListEstados");
                DropDownList tiposComprobantes = (DropDownList)row.FindControl("DropDownListTipoComprobantes");
                DropDownList empresas = (DropDownList)row.FindControl("DropDownListEmpresas");


                int id = Int32.Parse(row.Cells[0].Text);

                FacturasCliente factura = administracion.BuscarFacturasCliente(id);

                factura.EstadoId = Int32.Parse(estados.SelectedItem.Value);
                factura.TipoComprobanteId = Int32.Parse(tiposComprobantes.SelectedItem.Value);
                factura.EmpresaId = Int32.Parse(empresas.SelectedItem.Value);


                administracion.GrabarFacturasClientes(factura);

                Buscar();


            }
            else if (e.CommandName == "Ver")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewFacturas.Rows[index];

                int id = int.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/FacturasClientes/Editar.aspx?Id=" + id);

            }

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxNroFactura.Text = "";
            TextBoxCuit.Text = "";
            TextBoxRazonSocial.Text = "";
            TextBoxNroPresupuesto.Text = "";
            TextBoxFechaDesde.Text = "";
            TextBoxFechaHasta.Text = "";
            DropDownListEmpresa.SelectedValue = "0";
            DropDownListEstados.SelectedValue = "0";
        }

        protected void GridViewFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList estados = (DropDownList)e.Row.FindControl("DropDownListEstados");
                DropDownList tiposComprobantes = (DropDownList)e.Row.FindControl("DropDownListTipoComprobantes");
                DropDownList empresas = (DropDownList)e.Row.FindControl("DropDownListEmpresas");


                estados.DataSource = administracion.BuscarEstadosPorEntidad("FacturasCliente");
                estados.DataTextField = "Descripcion";
                estados.DataValueField = "Id";
                estados.DataBind();

                tiposComprobantes.DataSource = administracion.ObtenerTipoComprobantes();
                tiposComprobantes.DataTextField = "Descripcion";
                tiposComprobantes.DataValueField = "Id";
                tiposComprobantes.DataBind();


                empresas.DataSource = administracion.ObtenerEmpresas();
                empresas.DataTextField = "RazonSocial";
                empresas.DataValueField = "Id";
                empresas.DataBind();

                int id = Int32.Parse(e.Row.Cells[0].Text);

                FacturasCliente factura = administracion.BuscarFacturasCliente(id);

                estados.SelectedValue = factura.EstadoId.ToString();

                empresas.SelectedValue = factura.EmpresaId.ToString();

                tiposComprobantes.SelectedValue = factura.TipoComprobanteId.ToString();

            }

        }
    }
}