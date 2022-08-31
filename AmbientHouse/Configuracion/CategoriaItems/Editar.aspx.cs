using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.CategoriaItems
{
    public partial class Editar : System.Web.UI.Page
    {

        private DomainAmbientHouse.Entidades.CategoriasItem CategoriasItemSeleccionado
        {
            get
            {
                return Session["CategoriasItemSeleccionado"] as DomainAmbientHouse.Entidades.CategoriasItem;
            }
            set
            {
                Session["CategoriasItemSeleccionado"] = value;
            }
        }

        private int CategoriaItemId
        {
            get
            {
                return Int32.Parse(Session["CategoriaItemId"].ToString());
            }
            set
            {
                Session["CategoriaItemId"] = value;
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

        private void InicializarPagina()
        {
           int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CategoriaItemId = id;
            }


            if (id == 0)
                NuevoCategoria();
            else
                EditarCategoria(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarCategoria(int id)
        {

            DomainAmbientHouse.Entidades.CategoriasItem categoria = new DomainAmbientHouse.Entidades.CategoriasItem();

            categoria = administracion.BuscarCategoriasItem(id);

            CategoriasItemSeleccionado = categoria;


            TextBoxDescripcion.Text = categoria.Descripcion;

          
            DropDownListCategoriaPadre.SelectedValue = categoria.CategoriaItemPadreId.ToString();
           
          

        }

        private void NuevoCategoria()
        {
            CategoriasItemSeleccionado = new DomainAmbientHouse.Entidades.CategoriasItem();
        }

        private void CargarListas()
        {
            DropDownListCategoriaPadre.DataSource = administracion.ObtenerCategoriasItemHijosPadres();
            DropDownListCategoriaPadre.DataTextField = "CategoriaItemPadrePadreDescripcion";
            DropDownListCategoriaPadre.DataValueField = "Id";
            DropDownListCategoriaPadre.DataBind();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.CategoriasItem categoria = CategoriasItemSeleccionado;

            categoria.Descripcion = TextBoxDescripcion.Text;
            categoria.EstadoId = 1;

            if (DropDownListCategoriaPadre.SelectedItem.Value != "null")
            {
                categoria.CategoriaItemPadreId = Int32.Parse(DropDownListCategoriaPadre.SelectedItem.Value.ToString());
            }


            administracion.NuevaCategoriaItem(categoria);

            Response.Redirect("~/Configuracion/CategoriaItems/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/CategoriaItems/Index.aspx");
        }

    }
}