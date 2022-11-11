using DomainAmbientHouse.Seguridad;
using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Seguridad.Usuarios
{
    public partial class Index : System.Web.UI.Page
    {
        SeguridadServicios seguridad = new SeguridadServicios();
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarUsuarios();
            }
        }

        private void BuscarUsuarios()
        {
            GridViewUsuarios.DataSource = seguridad.ObtenerUsuarios();
            GridViewUsuarios.DataBind();
        }

        protected void GridViewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewUsuarios.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Usuarios item = seguridad.BuscarUsuario(ItemId);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    seguridad.EditarUsuario(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            BuscarUsuarios();
            UpdatePanelGrillaUsuarios.Update();
        }

        protected void GridViewUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");


                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Usuarios item = seguridad.BuscarUsuario(ItemId);


                Estados.DataSource = servicios.BuscarEstadosPorEntidad("Usuarios");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();


                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

        protected void GridViewUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsuarios.PageIndex = e.NewPageIndex;
            BuscarUsuarios();
        }
    }
}