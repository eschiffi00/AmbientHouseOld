using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Stock.Productos
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.INVENTARIO_Producto INVENTARIOProductoSeleccionado
        {
            get
            {
                return Session["INVENTARIOProductoSeleccionado"] as DomainAmbientHouse.Entidades.INVENTARIO_Producto;
            }
            set
            {
                Session["INVENTARIOProductoSeleccionado"] = value;
            }
        }

        private int INVENTARIOProductoId
        {
            get
            {
                return Int32.Parse(Session["INVENTARIOProductoId"].ToString());
            }
            set
            {
                Session["INVENTARIOProductoId"] = value;
            }
        }

        private string Operacion
        {
            get
            {
                return Session["Operacion"].ToString();
            }
            set
            {
                Session["Operacion"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                InicializarPagina();

            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                INVENTARIOProductoId = id;
            }


            if (id == 0)
            {
                NuevoINVENTARIOProducto();
                Operacion = "A";
            }
            else
            {
                EditarINVENTARIOProducto(id);
                Operacion = "M";
            }

            SetFocus(TextBoxDescripcion);
        }

        private void EditarINVENTARIOProducto(int id)
        {


            DomainAmbientHouse.Entidades.INVENTARIO_Producto producto = new DomainAmbientHouse.Entidades.INVENTARIO_Producto();

            producto = administracion.BuscarINVENTARIOProducto(id);

            INVENTARIOProductoSeleccionado = producto;

            DropDownListRubros.SelectedValue = producto.RubroId.ToString();

            TextBoxDescripcion.Text = producto.Descripcion;
            TextBoxCosto.Text = producto.Costo.ToString();
            TextBoxCodigo.Text = producto.Codigo;
            TextBoxCodigoBarra.Text = producto.CodigoBarra;


            if (cmd.IsNumeric(producto.CantidadNominal))
                TextBoxCantidadNominal.Text = producto.CantidadNominal.ToString();

            if (cmd.IsNumeric(producto.Cantidad))
                TextBoxCantidadExistente.Text = producto.Cantidad.ToString();


            DropDownListRubros.SelectedValue = producto.RubroId.ToString();
            DropDownListUnidad.SelectedValue = producto.UnidadId.ToString();
            DropDownListPresentacion.SelectedValue = producto.UnidadPresentacionId.ToString();



        }

        private void NuevoINVENTARIOProducto()
        {
            INVENTARIOProductoSeleccionado = new DomainAmbientHouse.Entidades.INVENTARIO_Producto();
        }

        private void CargarListas()
        {
            DropDownListRubros.DataSource = administracion.ObtenerRubros();
            DropDownListRubros.DataTextField = "Descripcion";
            DropDownListRubros.DataValueField = "RubroId";
            DropDownListRubros.DataBind();


            DropDownListUnidad.DataSource = administracion.ListarUnidades();
            DropDownListUnidad.DataTextField = "Descripcion";
            DropDownListUnidad.DataValueField = "Id";
            DropDownListUnidad.DataBind();

            DropDownListPresentacion.DataSource = administracion.ListarUnidades();
            DropDownListPresentacion.DataTextField = "Descripcion";
            DropDownListPresentacion.DataValueField = "Id";
            DropDownListPresentacion.DataBind();


        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {

            Grabar();
        }

        private void Grabar()
        {

            DomainAmbientHouse.Entidades.INVENTARIO_Producto producto = INVENTARIOProductoSeleccionado;

            if (cmd.IsNumeric(TextBoxCantidadExistente.Text))
                producto.Cantidad = double.Parse(TextBoxCantidadExistente.Text.ToString());

            if (cmd.IsNumeric(TextBoxCantidadNominal.Text))
                producto.CantidadNominal = double.Parse(TextBoxCantidadNominal.Text.ToString());

            producto.Codigo = TextBoxCodigo.Text;

            if (cmd.IsNumeric(TextBoxCosto.Text))
                producto.Costo = double.Parse(TextBoxCosto.Text.ToString().Replace('.', ','));

            producto.Descripcion = TextBoxDescripcion.Text;

            producto.RubroId = Int32.Parse(DropDownListRubros.SelectedItem.Value);
            producto.UnidadId = Int32.Parse(DropDownListUnidad.SelectedItem.Value);
            producto.UnidadPresentacionId = Int32.Parse(DropDownListPresentacion.SelectedItem.Value);

            producto.CodigoBarra = TextBoxCodigoBarra.Text;
            producto.EmpleadoId = EmpleadoId;

            administracion.ActualizarProductos(producto);

            Response.Redirect("~/Stock/Productos/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Productos/Index.aspx");
        }

        protected void DropDownListRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Operacion == "A")
            {
                if (DropDownListRubros.SelectedItem != null)
                {
                    int rubroId = Int32.Parse(DropDownListRubros.SelectedItem.Value);

                    Rubros rubro = administracion.BuscarRubro(rubroId);

                    CodigoPorRubro codigo = administracion.BuscarCodigoPorRubro(rubroId);

                    TextBoxCodigo.Text = rubro.LetraCodigo + (codigo.Codigo + 1).ToString().PadLeft(3, '0');

                }
            }
        }
    }
}