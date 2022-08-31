using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace AmbientHouse.Configuracion.Items
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicio = new AdministrativasServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarItems();

                DropDownListCategorias.DataSource = servicio.ObtenerCategoriasItemHijosPadres();
                DropDownListCategorias.DataTextField = "CategoriaItemPadrePadreDescripcion";
                DropDownListCategorias.DataValueField = "Id";
                DropDownListCategorias.DataBind();
            }
        }

        private void BuscarItems()
        {
            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            GridViewItems.DataSource = servicio.BuscarItemsFiltros(TextBoxDetalleBuscador.Text, DropDownListCategorias.SelectedItem.Value, estadoActivo);
            GridViewItems.DataBind();
        }

  

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Items/Editar.aspx");
        }

        protected void GridViewItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewItems.PageIndex = e.NewPageIndex;
            BuscarItems();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Precio = (TextBox)e.Row.FindControl("TextBoxPrecio");
                TextBox Costo = (TextBox)e.Row.FindControl("TextBoxCosto");
                TextBox Descripcion = (TextBox)e.Row.FindControl("TextBoxDescripcion");
                TextBox Margen = (TextBox)e.Row.FindControl("TextBoxMargen");

                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");

                DropDownList Categorias = (DropDownList)e.Row.FindControl("DropDownListCategorias");
               

                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Items item = servicio.BuscarItems(ItemId);

            

                Precio.Text = item.Precio.ToString();
                Costo.Text = item.Costo.ToString();
                Descripcion.Text = item.Detalle.ToString();
                Margen.Text = item.Margen.ToString();

                Estados.DataSource = servicio.BuscarEstadosPorEntidad("Items");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();

                Categorias.DataSource = servicio.ObtenerCategoriasItemHijosPadres();
                Categorias.DataTextField = "CategoriaItemPadrePadreDescripcion";
                Categorias.DataValueField = "Id";
                Categorias.DataBind();


              

                Categorias.SelectedValue = item.CategoriaItemId.ToString();

                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();


            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());



            Total.DataSource = servicio.ObtenerItems(estadoActivo);
            Total.DataBind();


            Exportar(Total);
        }

        private void Exportar(GridView gridExcel)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gridExcel.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gridExcel);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=DATA.xls");
            Response.Charset = "UTF-8";
            // Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void GridViewItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewItems.Rows[index];

                TextBox precio = row.FindControl("TextBoxPrecio") as TextBox;
                TextBox costo = row.FindControl("TextBoxCosto") as TextBox;
                TextBox margen = row.FindControl("TextBoxMargen") as TextBox;
                TextBox descripcion = row.FindControl("TextBoxDescripcion") as TextBox;

                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;
                DropDownList Categoria = row.FindControl("DropDownListCategorias") as DropDownList;


                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Items item = servicio.BuscarItems(ItemId);


                double dCosto = 0;
                double dPrecio = 0;
                double dMargen = 0;



                if (cmd.IsNumeric(costo.Text))
                    dCosto = double.Parse(costo.Text);

                if (cmd.IsNumeric(precio.Text))
                    dPrecio = double.Parse(precio.Text);

                if (cmd.IsNumeric(margen.Text))
                    dMargen = double.Parse(margen.Text);

                if (item.Precio != double.Parse(precio.Text))
                {
                    item.Precio = dPrecio;
                    item.Costo = dCosto;
                    item.Margen = dPrecio / dCosto;
                }
                else
                {

                    item.Precio = dCosto * dMargen;
                    item.Costo = dCosto;
                    item.Margen = dMargen;

                }

                item.CategoriaItemId = Int32.Parse(Categoria.SelectedItem.Value);
                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);
                item.Detalle = descripcion.Text;
             

                try
                {
                    servicio.ActualizarItem(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            BuscarItems();
            UpdatePanelGrillaItems.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarItems();
        }



       

  
    }
}