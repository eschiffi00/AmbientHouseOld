using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Configuracion.Items
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.Items ItemSeleccionado
        {
            get
            {
                return Session["ItemSeleccionado"] as DomainAmbientHouse.Entidades.Items;
            }
            set
            {
                Session["ItemSeleccionado"] = value;
            }
        }

        private int ItemId
        {
            get
            {
                return Int32.Parse(Session["ItemId"].ToString());
            }
            set
            {
                Session["ItemId"] = value;
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

        private void CargarListas()
        {
            DropDownListCategoriasItems.DataSource = servicios.ObtenerCategoriasItem();
            DropDownListCategoriasItems.DataTextField = "Descripcion";
            DropDownListCategoriasItems.DataValueField = "Id";
            DropDownListCategoriasItems.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ItemId = id;
            }


            if (id == 0)
                NuevoItem();
            else
                EditarItem(id);

            SetFocus(TextBoxDetalle);
        }

        private void EditarItem(int id)
        {

           DomainAmbientHouse.Entidades.Items item = new DomainAmbientHouse.Entidades.Items();

           item = servicios.BuscarItems(id);

            ItemSeleccionado = item;


            TextBoxDetalle.Text = item.Detalle;
            DropDownListCategoriasItems.SelectedValue = item.CategoriaItemId.ToString();

            if (cmd.IsNumeric(item.Costo))
                TextBoxCosto.Text = item.Costo.ToString();

              if (cmd.IsNumeric(item.Precio))
                TextBoxPrecio.Text = item.Precio.ToString();
         
        }

        private void NuevoItem()
        {
            ItemSeleccionado = new DomainAmbientHouse.Entidades.Items();
        }

        private void GrabarItem()
        {
            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());


            DomainAmbientHouse.Entidades.Items item = ItemSeleccionado;

            item.Detalle = TextBoxDetalle.Text;
            item.CategoriaItemId = Int32.Parse(DropDownListCategoriasItems.SelectedItem.Value);

            if (cmd.IsNumeric(TextBoxPrecio.Text) )
                item.Precio = double.Parse(TextBoxPrecio.Text.ToString());

            if (cmd.IsNumeric(TextBoxCosto.Text))
                item.Costo =  double.Parse(TextBoxCosto.Text.ToString());

            item.EstadoId = estadoActivo;

            servicios.NuevoItem(item);
            Response.Redirect("~/Configuracion/Items/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Items/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarItem();
        }
       
      
    }
}