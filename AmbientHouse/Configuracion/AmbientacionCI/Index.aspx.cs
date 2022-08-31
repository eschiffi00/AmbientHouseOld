using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Configuracion.AmbientacionCI
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Buscar();
            }

        }

        private void Buscar()
        {
            GridViewAmbientacion.DataSource = administracion.ObtenerAmbientacionesCI();
            GridViewAmbientacion.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AmbientacionCI/Editar.aspx");
        }

        protected void GridViewAmbientacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAmbientacion.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void GridViewAmbientacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewAmbientacion.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.AmbientacionCI item = administracion.BuscarAmbientacionCI(ItemId);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    administracion.GrabarAmbientacionCI(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();
            UpdatePanelGrillaAmbientacion.Update();
        }

        protected void GridViewAmbientacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");


                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.AmbientacionCI item = administracion.BuscarAmbientacionCI(ItemId);


                Estados.DataSource = administracion.BuscarEstadosPorEntidad("Categorias Corporativo Informal");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();


                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

       

    }
}