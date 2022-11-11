using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Categorias
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarListas();

                Buscar();

            }
        }

        private void CargarListas()
        {

            DropDownListLocaciones.DataSource = eventos.ObtenerLocacionesParaCotizar();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();
        }

        private void Buscar()
        {
            if (DropDownListLocaciones.SelectedItem.Value != "null")
                GridViewAmbientacion.DataSource = servicios.ObtenerAmbientacionesPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value));
            else
                GridViewAmbientacion.DataSource = servicios.ObtenerAmbientaciones();


            GridViewAmbientacion.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Categorias/Editar.aspx");
        }

        protected void GridViewAmbientacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAmbientacion.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void GridViewAmbientacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");


                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Categorias item = servicios.BuscarCategorias(ItemId);


                Estados.DataSource = servicios.BuscarEstadosPorEntidad("Categorias");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();


                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

        protected void GridViewAmbientacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewAmbientacion.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Categorias item = servicios.BuscarCategorias(ItemId);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    servicios.NuevaCategoria(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();
            UpdatePanelGrillaAmbientacion.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void DropDownListLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}