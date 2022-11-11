using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Stock.Existencias
{
    public partial class Editar : System.Web.UI.Page
    {
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

        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Existencias ExistenciasSeleccionado
        {
            get
            {
                return Session["ExistenciasSeleccionado"] as DomainAmbientHouse.Entidades.Existencias;
            }
            set
            {
                Session["ExistenciasSeleccionado"] = value;
            }
        }

        private int ProductoId
        {
            get
            {
                return Int32.Parse(Session["ProductoId"].ToString());
            }
            set
            {
                Session["ProductoId"] = value;
            }
        }

        private int DepositoId
        {
            get
            {
                return Int32.Parse(Session["DepositoId"].ToString());
            }
            set
            {
                Session["DepositoId"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

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
            int productoId = 0;
            int depositoId = 0;

            if (Request["ProductoId"] != null)
            {
                productoId = Int32.Parse(Request["ProductoId"]);

                ProductoId = productoId;

            }

            if (Request["DepositoId"] != null)
            {
                depositoId = Int32.Parse(Request["DepositoId"]);

                DepositoId = depositoId;

            }

            if (productoId == 0 && depositoId == 0)
                NuevaExistencia();
            else
                EditarExistencia(productoId, depositoId);


            SetFocus(TextBoxCantidad);
        }

        private void EditarExistencia(int productoId, int depositoId)
        {
            DomainAmbientHouse.Entidades.Existencias existencias = new DomainAmbientHouse.Entidades.Existencias();

            existencias = administracion.BuscarExistencias(productoId, depositoId);

            ExistenciasSeleccionado = existencias;

            DomainAmbientHouse.Entidades.Rubros rubro = administracion.BuscarRubroPorProducto((int)existencias.ProductoId);

            DropDownListRubros.SelectedValue = rubro.RubroId.ToString();
            DropDownListDepositos.SelectedValue = existencias.DepositoId.ToString();

            ListarProductosPorRubros();

            DropDownListProductos.SelectedValue = existencias.ProductoId.ToString();
            DropDownListUnidades.SelectedValue = existencias.UnidadId.ToString();
            TextBoxCantidad.Text = existencias.StockDeposito.ToString();

            DropDownListRubros.Enabled = false;
            DropDownListDepositos.Enabled = false;
            DropDownListProductos.Enabled = false;

        }

        private void NuevaExistencia()
        {
            ExistenciasSeleccionado = new DomainAmbientHouse.Entidades.Existencias();
        }

        private void CargarListas()
        {
            DropDownListRubros.DataSource = administracion.ObtenerRubros().Where(o => o.RubroId == 16 || o.RubroId == 17).ToList(); ;
            DropDownListRubros.DataTextField = "Descripcion";
            DropDownListRubros.DataValueField = "RubroId";
            DropDownListRubros.DataBind();

            DropDownListDepositos.DataSource = administracion.ObtenerDepositos();
            DropDownListDepositos.DataTextField = "Descripcion";
            DropDownListDepositos.DataValueField = "Id";
            DropDownListDepositos.DataBind();

            DropDownListUnidades.DataSource = administracion.ListarUnidades();
            DropDownListUnidades.DataTextField = "Descripcion";
            DropDownListUnidades.DataValueField = "Id";
            DropDownListUnidades.DataBind();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.Existencias existencia = ExistenciasSeleccionado;

            if (cmd.IsNumeric(TextBoxCantidad.Text))
                existencia.Cantidad = double.Parse(TextBoxCantidad.Text.ToString());



            existencia.DepositoId = Int32.Parse(DropDownListDepositos.SelectedItem.Value);
            existencia.ProductoId = Int32.Parse(DropDownListProductos.SelectedItem.Value);
            existencia.EmpleadoId = EmpleadoId;
            existencia.UnidadId = Int32.Parse(DropDownListUnidades.SelectedItem.Value);

            administracion.GuardarExistencia(existencia);

            Response.Redirect("~/Stock/Existencias/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Existencias/Index.aspx");
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

                List<DomainAmbientHouse.Entidades.INVENTARIO_Producto> list = administracion.ListarINVENTARIOProductoPorRubro(RubroId);

                if (list.Count > 0)
                {
                    DropDownListProductos.DataSource = list.ToList();
                    DropDownListProductos.DataTextField = "Descripcion";
                    DropDownListProductos.DataValueField = "Id";
                    DropDownListProductos.DataBind();

                }

                UpdatePanelExistencias.Update();

            }
        }

    }
}