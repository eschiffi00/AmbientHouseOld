using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.TipoBarrasCategoriasItem
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.TipoBarraCategoriaItem TipoBarraCategoriaItemSeleccionado
        {
            get
            {
                return Session["TipoBarraCategoriaItemSeleccionado"] as DomainAmbientHouse.Entidades.TipoBarraCategoriaItem;
            }
            set
            {
                Session["TipoBarraCategoriaItemSeleccionado"] = value;
            }
        }

        private long TipoBarraCategoriaItemId
        {
            get
            {
                return Int32.Parse(Session["TipoBarraCategoriaItemId"].ToString());
            }
            set
            {
                Session["TipoBarraCategoriaItemId"] = value;
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

            DropDownListTipoBarra.DataSource = administracion.ObtenerTipoBarras();
            DropDownListTipoBarra.DataTextField = "Descripcion";
            DropDownListTipoBarra.DataValueField = "Id";
            DropDownListTipoBarra.DataBind();

        


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

                TipoBarraCategoriaItemId = id;
            }


            if (id == 0)
                NuevoTipoBarraCategoriaItem();
            else
                EditarTipoBarraCategoriaItem(id);


        }

        private void EditarTipoBarraCategoriaItem(long id)
        {
            DomainAmbientHouse.Entidades.TipoBarraCategoriaItem item = new DomainAmbientHouse.Entidades.TipoBarraCategoriaItem();

            item = administracion.BuscarTipoBarraCategoriaItem(id);

            TipoBarraCategoriaItemSeleccionado = item;


            DropDownListTipoBarra.SelectedValue = item.TipoBarraId.ToString();
          

            if (item.CategoriaItemId != null)
                DropDownListCategorias.SelectedValue = item.CategoriaItemId.ToString();


            if (item.ItemId != null)
                DropDownListItmes.SelectedValue = item.ItemId.ToString();




        }

        private void NuevoTipoBarraCategoriaItem()
        {
            TipoBarraCategoriaItemSeleccionado = new DomainAmbientHouse.Entidades.TipoBarraCategoriaItem();


        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoBarraCategoriaItemActivos"].ToString());


            DomainAmbientHouse.Entidades.TipoBarraCategoriaItem tipo = TipoBarraCategoriaItemSeleccionado;

            tipo.TipoBarraId = Int32.Parse(DropDownListTipoBarra.SelectedItem.Value);
          
            if (DropDownListCategorias.SelectedItem.Value != "null")
                tipo.CategoriaItemId = Int32.Parse(DropDownListCategorias.SelectedItem.Value);
            else
                tipo.CategoriaItemId = null;

            if (DropDownListItmes.SelectedItem.Value != "null")
                tipo.ItemId = Int32.Parse(DropDownListItmes.SelectedItem.Value);
            else
                tipo.ItemId = null;

            tipo.EstadoId = activo;

            administracion.NuevoTipoBarraCategoriaItem(tipo);

            Response.Redirect("~/Configuracion/TipoBarrasCategoriasItem/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoBarrasCategoriasItem/Index.aspx");
        }

        protected void DropDownListCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategorias.SelectedValue != "null")
            {
                
                DropDownListItmes.SelectedValue = "null";
            }

           
            UpdatePanelItems.Update();
        }

        protected void DropDownListItmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListItmes.SelectedValue != "null")
            {
                DropDownListCategorias.SelectedValue = "null";
              
            }

            UpdatePanelCategorias.Update();
           
        }
    }
}