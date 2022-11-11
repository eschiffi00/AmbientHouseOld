using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;

namespace AmbientHouse.Configuracion.AdicionalesItems
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();
            }

        }

        private void CargarLista()
        {

            DropDownListAdicionales.DataSource = administracion.ObtenerAdicionales();
            DropDownListAdicionales.DataTextField = "Descripcion";
            DropDownListAdicionales.DataValueField = "Id";
            DropDownListAdicionales.DataBind();


            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            DropDownListItems.DataSource = administracion.ObtenerItems(estadoActivo);
            DropDownListItems.DataTextField = "Detalle";
            DropDownListItems.DataValueField = "Id";
            DropDownListItems.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AdicionalesItems/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            administracion.GrabarItemsAdicionales(Int32.Parse(DropDownListAdicionales.SelectedItem.Value), Int32.Parse(DropDownListItems.SelectedItem.Value));
            Response.Redirect("~/Configuracion/AdicionalesItems/Index.aspx");
        }

        protected void ButtonAceptaryContinuar_Click(object sender, EventArgs e)
        {
            administracion.GrabarItemsAdicionales(Int32.Parse(DropDownListAdicionales.SelectedItem.Value), Int32.Parse(DropDownListItems.SelectedItem.Value));

            DropDownListItems.SelectedValue = "0";
        }
    }
}