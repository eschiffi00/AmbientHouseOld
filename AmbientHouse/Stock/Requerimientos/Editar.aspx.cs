using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Stock.Requerimientos
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        private int RequerimientoId
        {
            get
            {
                return Int32.Parse(Session["RequerimientoId"].ToString());
            }
            set
            {
                Session["RequerimientoId"] = value;
            }
        }

        private INVENTARIO_Requerimiento RequerimientoSeleccionado
        {
            get
            {
                return Session["RequerimientoSeleccionado"] as INVENTARIO_Requerimiento;
            }
            set
            {
                Session["RequerimientoSeleccionado"] = value;
            }
        }

        private List<INVENTARIO_Requerimiento_Detalle> ListDetalleRequerimientos
        {
            get
            {
                return Session["ListDetalleRequerimientos"] as List<INVENTARIO_Requerimiento_Detalle>;
            }
            set
            {
                Session["ListDetalleRequerimientos"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                ListDetalleRequerimientos = new List<INVENTARIO_Requerimiento_Detalle>();
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                RequerimientoId = id;
            }


            if (id == 0)
            {
                NuevoRequerimiento();
               
            }
            else
            {
                EditarRequerimiento(id);
                
            }

            SetFocus(TextBoxDescripcion);
        }

        private void EditarRequerimiento(int id)
        {
            throw new NotImplementedException();
        }

        private void NuevoRequerimiento()
        {
            RequerimientoSeleccionado = new DomainAmbientHouse.Entidades.INVENTARIO_Requerimiento();
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
           
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Requerimientos/Index.aspx");
        }

        protected void DropDownListRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarProductosPorRubros();
        }

        private void ListarProductosPorRubros()
        {
            if (DropDownListRubros.SelectedItem != null)
            {
                Int32 RubroId = Int32.Parse(DropDownListRubros.SelectedItem.Value);

                List<INVENTARIO_Producto> list = administracion.ListarINVENTARIOProductoPorRubro(RubroId);

                if (list.Count > 0)
                {
                    DropDownListProducto.DataSource = list.ToList();
                    DropDownListProducto.DataTextField = "Descripcion";
                    DropDownListProducto.DataValueField = "Id";
                    DropDownListProducto.DataBind();

                }

                UpdatePanelDetalleProductos.Update();
                 
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            INVENTARIO_Requerimiento_Detalle agregarRequerimiento = new INVENTARIO_Requerimiento_Detalle();

            agregarRequerimiento.Id = ListDetalleRequerimientos.Count() + 1;
            agregarRequerimiento.ProductoId = Int32.Parse(DropDownListProducto.SelectedItem.Value);
            agregarRequerimiento.ProductoDescripcion =DropDownListProducto.SelectedItem.Text;

           
            if (agregarRequerimiento.ProductoId > 0)
            {
                DomainAmbientHouse.Entidades.INVENTARIO_Producto producto = administracion.BuscarINVENTARIOProducto((int)agregarRequerimiento.ProductoId);
                
                agregarRequerimiento.UnidadId = producto.UnidadId;

                agregarRequerimiento.UnidadDescripcion = producto.UnidadDescripcion;

            }

            agregarRequerimiento.Cantidad = Int32.Parse(TextBoxCantidad.Text);

            ListDetalleRequerimientos.Add(agregarRequerimiento);

            GridViewRequerimientoDetalle.DataSource = ListDetalleRequerimientos.ToList();
            GridViewRequerimientoDetalle.DataBind();

            UpdatePanelDetalleProductos.Update();


        }

    }
}