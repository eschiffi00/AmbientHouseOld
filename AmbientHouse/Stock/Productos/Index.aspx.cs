using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Stock
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();


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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarProductos();

            }
        }

        private void BuscarProductos()
        {
            GridViewProductos.DataSource = administracion.BuscarINVENTARIOProductoPorProducto(TextBoxDescripcionBuscador.Text);
            GridViewProductos.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Productos/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Default.aspx");
        }

        protected void GridViewProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProductos.PageIndex = e.NewPageIndex;
            BuscarProductos();
        }

        protected void GridViewProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Cantidad = (TextBox)e.Row.FindControl("TextBoxCantidad");


                int ProductoId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.INVENTARIO_Producto producto = administracion.BuscarINVENTARIOProducto(ProductoId);

                Cantidad.Text = producto.Cantidad.ToString();

            }
        }

        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProductos.Rows[index];

                TextBox Cantidad = (TextBox)row.FindControl("TextBoxCantidad");

                int ProductoId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.INVENTARIO_Producto producto = administracion.BuscarINVENTARIOProducto(ProductoId);

                if (cmd.IsNumeric(Cantidad.Text))
                    producto.Cantidad = double.Parse(Cantidad.Text);


                try
                {
                    producto.EmpleadoId = EmpleadoId;

                    administracion.ActualizarProductos(producto);
                }
                catch (Exception)
                {

                    throw;
                }


            }

            BuscarProductos();
            UpdatePanelGrillaProductos.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarProductos();
        }


    }
}