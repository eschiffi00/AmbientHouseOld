using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Configuracion.ProductosCatering
{
    public partial class Editar : System.Web.UI.Page
    {

        private DomainAmbientHouse.Entidades.ProductosCatering ProductosCateringSeleccionado
        {
            get
            {
                return Session["ProductosCateringSeleccionado"] as DomainAmbientHouse.Entidades.ProductosCatering;
            }
            set
            {
                Session["ProductosCateringSeleccionado"] = value;
            }
        }

        private int ProductoCateringId
        {
            get
            {
                return Int32.Parse(Session["ProductoCateringId"].ToString());
            }
            set
            {
                Session["ProductoCateringId"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Items> ListItemsAsociados
        {
            get
            {
                return Session["ListItemsAsociados"] as List<DomainAmbientHouse.Entidades.Items>;
            }
            set
            {
                Session["ListItemsAsociados"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Items> ListItemsNoAsociados
        {
            get
            {
                return Session["ListItemsNoAsociados"] as List<DomainAmbientHouse.Entidades.Items>;
            }
            set
            {
                Session["ListItemsNoAsociados"] = value;
            }
        }

        AdministrativasServicios administrativa = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ListItemsAsociados = new List<DomainAmbientHouse.Entidades.Items>();
                ListItemsNoAsociados = new List<DomainAmbientHouse.Entidades.Items>();
                ProductoCateringId = 0;

                CargarListas();
                InicializarPagina();


            

                Buscar();

            }
      
        }

        private void Buscar()
        {
            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            if (ProductoCateringId > 0)
            {
                ListItemsAsociados = administrativa.BuscarItemsAsociados(ProductoCateringId, "null", estadoActivo);

                GridViewItemsAsociados.DataSource = ListItemsAsociados.OrderBy(o=>o.Id).ToList();
                GridViewItemsAsociados.DataBind();
            }
            ListItemsNoAsociados = administrativa.BuscarItemsNoAsociados(ProductoCateringId, DropDownListCategorias.SelectedItem.Value, estadoActivo);

            GridViewItemsNoAsociados.DataSource = ListItemsNoAsociados.ToList();
            GridViewItemsNoAsociados.DataBind();

            UpdatePanelGrillaItems.Update();
        }

        private void CargarListas()
        {

            DropDownListCategorias.DataSource = administrativa.ObtenerCategoriasItemHijosPadres();
            DropDownListCategorias.DataTextField = "CategoriaItemPadrePadreDescripcion";
            DropDownListCategorias.DataValueField = "Id";
            DropDownListCategorias.DataBind();

 
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ProductoCateringId = id;
            }


            if (id == 0)
                NuevoProductoCategoria();
            else
                EditarProductoCategoria(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarProductoCategoria(int id)
        {

            DomainAmbientHouse.Entidades.ProductosCatering pc = new DomainAmbientHouse.Entidades.ProductosCatering();

            pc = administrativa.BuscarProductoCatering(id);

            ProductosCateringSeleccionado = pc;


            TextBoxDescripcion.Text = pc.Descripcion;

            

        }

        private void NuevoProductoCategoria()
        {
            ProductosCateringSeleccionado  = new DomainAmbientHouse.Entidades.ProductosCatering();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewItemsNoAsociados.Rows)
            {

                CheckBox check = row.FindControl("CheckBoxSeleccionar") as CheckBox;

                if (check.Checked)
                {
                    DomainAmbientHouse.Entidades.Items item = new DomainAmbientHouse.Entidades.Items();

                    int itemId = Int32.Parse(row.Cells[1].Text);


                    item = administrativa.BuscarItems(itemId);

                    ListItemsAsociados.Add(item);
                  

                }
            }

            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.ProductosCatering pc = ProductosCateringSeleccionado;

            pc.Descripcion = TextBoxDescripcion.Text;
            pc.EstadoId = 1;
          
            administrativa.NuevoProductoCatering(pc, ListItemsAsociados);

            Buscar();

            //Response.Redirect("~/Configuracion/ProductosCatering/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ProductosCatering/Index.aspx");
        }

        protected void DropDownListCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();

            UpdatePanelGrillaItems.Update();
        }

        protected void GridViewItemsAsociados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {


                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewItemsAsociados.Rows[index];

                DomainAmbientHouse.Entidades.Items item = new DomainAmbientHouse.Entidades.Items();


                item.Id = Int32.Parse(row.Cells[0].Text);



                var itemRemove = ListItemsAsociados.Where(o => o.Id == item.Id).Single();

                if (itemRemove != null)
                {
                    ListItemsAsociados.Remove(itemRemove);


                    GridViewItemsAsociados.DataSource = ListItemsAsociados.ToList();
                    GridViewItemsAsociados.DataBind();

                    UpdatePanelGrillaItems.Update();
                }
            
            }
        }
    }
}