using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;

namespace AmbientHouse.Stock
{
    public partial class Ingresos : System.Web.UI.Page
    {

        AdministrativasServicios administracion = new AdministrativasServicios();

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
                ListarProductosPorRubros();
                BuscarProducto();

                SetFocus(TextBoxCodigoBarra);
            }
        }

        private void CargarListas()
        {
            DropDownListRubros.DataSource = administracion.ObtenerRubros();
            DropDownListRubros.DataTextField = "Descripcion";
            DropDownListRubros.DataValueField = "RubroId";
            DropDownListRubros.DataBind();


        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();

        }

        private void Grabar()
        {

            DomainAmbientHouse.Entidades.INVENTARIO_Producto producto = administracion.BuscarINVENTARIOProducto(INVENTARIOProductoId);

            if (DropDownListTipoIngreso.SelectedItem.Value == "ENTRADA")
            {
                producto.Cantidad = producto.Cantidad + double.Parse(TextBoxCantidadExistente.Text);
            }
            else 
            {
                producto.Cantidad = producto.Cantidad - double.Parse(TextBoxCantidadExistente.Text);
            }
         
          
            producto.EmpleadoId = EmpleadoId;

            administracion.ActualizarProductos(producto);

            TextBoxCantidadExistente.Text = "";
            TextBoxCodigoBarra.Text = "";

            SetFocus(TextBoxCodigoBarra);

            UpdatePanelIngresoEgreso.Update();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownListRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarProductosPorRubros();
            BuscarProducto();
        }

        private void ListarProductosPorRubros()
        {
            if (DropDownListRubros.SelectedItem != null)
            {
                Int32 RubroId = Int32.Parse(DropDownListRubros.SelectedItem.Value);

                List<INVENTARIO_Producto> list = administracion.ListarINVENTARIOProductoPorRubro(RubroId);

                if (list.Count > 0)
                {
                    DropDownListProductos.DataSource = list.ToList();
                    DropDownListProductos.DataTextField = "Descripcion";
                    DropDownListProductos.DataValueField = "Id";
                    DropDownListProductos.DataBind();

                }

                UpdatePanelIngresoEgreso.Update();

            }
        }

        protected void DropDownListProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            if (DropDownListRubros.SelectedItem != null)
            {
                Int32 productoId = Int32.Parse(DropDownListProductos.SelectedItem.Value);

                INVENTARIOProductoId = productoId;

                INVENTARIO_Producto producto = administracion.BuscarINVENTARIOProducto(productoId);


                TextBoxCodigo.Text = producto.Codigo;
                TextBoxUnidadPresentacion.Text = administracion.BuscarINVENTARIOUnidad(producto.UnidadPresentacionId).Descripcion;


                TextBoxExistenciaActual.Text = producto.Cantidad.ToString();

                TextBoxCantidadExistente.Text = "";
                TextBoxCodigoBarra.Text = "";

                UpdatePanelIngresoEgreso.Update();
            }
        }

        protected void TextBoxCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCodigoBarra.Text.Length > 3)
            {
                INVENTARIO_Producto producto = administracion.BuscarINVENTARIOProductoPorCodigoBarra(TextBoxCodigoBarra.Text);

                if (producto != null)
                {
                    INVENTARIOProductoId = producto.Id;
                    TextBoxCodigo.Text = producto.Codigo;
                    TextBoxUnidadPresentacion.Text = administracion.BuscarINVENTARIOUnidad(producto.UnidadPresentacionId).Descripcion;
                    TextBoxExistenciaActual.Text = producto.Cantidad.ToString();

                    DropDownListRubros.SelectedValue = producto.RubroId.ToString();

                    ListarProductosPorRubros();

                    DropDownListProductos.SelectedValue = producto.Id.ToString();

                    UpdatePanelIngresoEgreso.Update();

                    SetFocus(TextBoxCantidadExistente);
                }
                else
                { }
            }
        }
    }
}