using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Configuration;


namespace AmbientHouse.Configuracion.TipoCateringTiempoProductoItem
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem TipoCateringTiempoProductoItemSeleccionado
        {
            get
            {
                return Session["TipoCateringTiempoProductoItemSeleccionado"] as DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem;
            }
            set
            {
                Session["TipoCateringTiempoProductoItemSeleccionado"] = value;
            }
        }

        private long TipoCateringTiempoProductoItemId
        {
            get
            {
                return Int32.Parse(Session["TipoCateringTiempoProductoItemId"].ToString());
            }
            set
            {
                Session["TipoCateringTiempoProductoItemId"] = value;
            }
        }


        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
                InicializarPagina();

            }
        }

        private void CargarListas()
        {
            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            DropDownListTipoCatering.DataSource = administracion.ObtenerTipoCatering();
            DropDownListTipoCatering.DataTextField = "Descripcion";
            DropDownListTipoCatering.DataValueField = "Id";
            DropDownListTipoCatering.DataBind();

            DropDownListTiempo.DataSource = administracion.ObtenerTiempos();
            DropDownListTiempo.DataTextField = "Descripcion";
            DropDownListTiempo.DataValueField = "Id";
            DropDownListTiempo.DataBind();


            DropDownListProductos.DataSource = administracion.ObtenerProductosCatering();
            DropDownListProductos.DataTextField = "Descripcion";
            DropDownListProductos.DataValueField = "Id";
            DropDownListProductos.DataBind();


            DropDownListItmes.DataSource = administracion.ObtenerItems(estadoActivo);
            DropDownListItmes.DataTextField = "Identificador";
            DropDownListItmes.DataValueField = "Id";
            DropDownListItmes.DataBind();

            DropDownListCategorias.DataSource = administracion.ObtenerCategoriasItemHijosPadres();
            DropDownListCategorias.DataTextField = "CategoriaItemPadrePadreDescripcion";
            DropDownListCategorias.DataValueField = "Id";
            DropDownListCategorias.DataBind();

        }

       

        private void InicializarPagina()
        {
            long id = 0;

            if (Request["Id"] != null)
            {
                id = Int64.Parse(Request["Id"]);

                TipoCateringTiempoProductoItemId = id;
            }


            if (id == 0)
                NuevoTipoCateringTiempoProductoItem();
            else
                EditarTipoCateringTiempoProductoItem(id);

          
        }

        private void EditarTipoCateringTiempoProductoItem(long id)
        {
            DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem item = new DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem();

            item = administracion.BuscarTipoCateringTiempoProductoItem(id);

            TipoCateringTiempoProductoItemSeleccionado = item;


            DropDownListTipoCatering.SelectedValue = item.TipoCateringId.ToString() ;
            DropDownListTiempo.SelectedValue = item.TiempoId.ToString();

            if (item.ProductoCateringId != null)
                DropDownListProductos.SelectedValue = item.ProductoCateringId.ToString();

            if (item.CategoriaItemId != null)
                DropDownListCategorias.SelectedValue = item.CategoriaItemId.ToString();


            if (item.ItemId!= null)
                DropDownListItmes.SelectedValue = item.ItemId.ToString();




        }

        private void NuevoTipoCateringTiempoProductoItem()
        {
            TipoCateringTiempoProductoItemSeleccionado = new DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem();


        }


        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {

         int activo =Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());


            DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem tipo = TipoCateringTiempoProductoItemSeleccionado;

            tipo.TipoCateringId = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value);
            tipo.TiempoId = Int32.Parse(DropDownListTiempo.SelectedItem.Value);

            if (DropDownListProductos.SelectedItem.Value != "null")
                tipo.ProductoCateringId = Int32.Parse(DropDownListProductos.SelectedItem.Value);
            else
                tipo.ProductoCateringId = null;

            if (DropDownListCategorias.SelectedItem.Value != "null")
                tipo.CategoriaItemId = Int32.Parse(DropDownListCategorias.SelectedItem.Value);
            else
                tipo.CategoriaItemId = null;
             
            if (DropDownListItmes.SelectedItem.Value != "null")
                tipo.ItemId = Int32.Parse(DropDownListItmes.SelectedItem.Value);
            else
                tipo.ItemId = null;

            tipo.EstadoId = activo;

            administracion.NuevoTipoCateringTiempoProductoItem(tipo);

            Response.Redirect("~/Configuracion/TipoCateringTiempoProductoItem/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCateringTiempoProductoItem/Index.aspx");
        }

        protected void DropDownListProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProductos.SelectedValue != "null")
            {
                DropDownListCategorias.SelectedValue = "null";
                DropDownListItmes.SelectedValue = "null";
            }

            UpdatePanelCategorias.Update();
            UpdatePanelItems.Update();
        }

        protected void DropDownListCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategorias.SelectedValue != "null")
            {
                DropDownListProductos.SelectedValue = "null";
                DropDownListItmes.SelectedValue = "null";
            }

            UpdatePanelProductos.Update();
            UpdatePanelItems.Update();
        }

        protected void DropDownListItmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListItmes.SelectedValue != "null")
            {
                DropDownListCategorias.SelectedValue = "null";
                DropDownListProductos.SelectedValue = "null";
            }

            UpdatePanelCategorias.Update();
            UpdatePanelProductos.Update();
        }
    }
}