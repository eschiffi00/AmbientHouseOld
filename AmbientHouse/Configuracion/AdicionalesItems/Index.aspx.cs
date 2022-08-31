using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.AdicionalesItems
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                BuscarItemsAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));
            }
        }

        private void CargarListas()
        {
            DropDownListAdicionales.DataSource = administracion.ObtenerAdicionales();
            DropDownListAdicionales.DataTextField = "Descripcion";
            DropDownListAdicionales.DataValueField = "Id";
            DropDownListAdicionales.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AdicionalesItems/Editar.aspx");

           
        }
         
        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
              Response.Redirect("~/Home/Index.aspx");
          
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarItemsAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));
        }

        private void BuscarItemsAdicional(int adicionalId)
        {
            GridViewItemsAdicionales.DataSource = administracion.BuscarItemsporAdicional(adicionalId);
            GridViewItemsAdicionales.DataBind();
        }

        protected void DropDownListAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarItemsAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));
        }

        protected void GridViewItemsAdicionales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewItemsAdicionales.Rows[index];

                int Id = int.Parse(row.Cells[0].Text);

                if (administracion.ElimarItemsAdicionales(Id,Int32.Parse(DropDownListAdicionales.SelectedItem.Value)));
                {
                    BuscarItemsAdicional(Int32.Parse(DropDownListAdicionales.SelectedItem.Value));

                    UpdatePanelGrillaItemsAdicionales.Update();
                }

            }
        }
    }
}