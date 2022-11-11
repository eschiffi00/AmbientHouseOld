using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.CategoriaItems
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscar();

            }
        }

        private void Buscar()
        {
            GridViewCategoriaItems.DataSource = servicios.ObtenerCategoriasItem();
            GridViewCategoriaItems.DataBind();
        }


        protected void GridViewCategoriaItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCategoriaItems.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/CategoriaItems/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        public string BuscarCategoriaPadre(Object id)
        {

            if (id != null)
            {
                int key = (int)id;

                var categoria = servicios.BuscarCategoriaPadre(key);



                return categoria.Descripcion;

            }
            else
                return "";

        }

        protected void GridViewCategoriaItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.CategoriasItem categoriaItems = servicios.BuscarCategoriasItem(id);


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");

                ListItem estado1 = new ListItem();
                estado1.Text = "Activo";
                estado1.Value = "1";

                ListItem estado2 = new ListItem();
                estado2.Text = "Inactivo";
                estado2.Value = "2";

                Estados.Items.Add(estado1);
                Estados.Items.Add(estado2);

                Estados.SelectedValue = categoriaItems.EstadoId.ToString();


            }
        }

        protected void GridViewCategoriaItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCategoriaItems.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.CategoriasItem item = servicios.BuscarCategoriasItem(id);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    servicios.NuevaCategoriaItem(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();
            UpdatePanelGrilla.Update();
        }
    }
}