using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;

namespace AmbientHouse.Organizador.Degustacion
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
            GridViewDegustacion.DataSource = administracion.ObtenerDegustacion();
            GridViewDegustacion.DataBind();

        }
        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/Degustacion/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
        }

        protected void GridViewDegustacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.GridViewDegustacion.Rows[num];
                ImageButton button2 = (ImageButton)row.FindControl("ImageButtonEstadoTecnica");
                DropDownList list = row.FindControl("DropDownListEstados") as DropDownList;
                int id = int.Parse(row.Cells[0].Text);
                DomainAmbientHouse.Entidades.Degustacion degustacion = this.administracion.BuscarDegustacion(id);
                degustacion.ConfirmoAmbientacion = ((ImageButton)row.FindControl("ImageButtonEstadoAmbientacion")).ImageUrl != "~/Content/Imagenes/noaprobado.png";
                degustacion.ConfirmoTecnica = button2.ImageUrl != "~/Content/Imagenes/noaprobado.png";
                degustacion.EstadoId = int.Parse(list.SelectedItem.Value);
                try
                {
                    this.administracion.Grabar(degustacion);
                }
                catch (Exception)
                {
                    throw;
                }
                this.Buscar();
            }
            else if (e.CommandName == "EstadoAmbientacion")
            {
                int num3 = Convert.ToInt32(e.CommandArgument);
                ImageButton button3 = (ImageButton)this.GridViewDegustacion.Rows[num3].FindControl("ImageButtonEstadoAmbientacion");
                button3.ImageUrl = (button3.ImageUrl != "~/Content/Imagenes/noaprobado.png") ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
            }
            else if (e.CommandName == "EstadoTecnica")
            {
                int num4 = Convert.ToInt32(e.CommandArgument);
                ImageButton button4 = (ImageButton)this.GridViewDegustacion.Rows[num4].FindControl("ImageButtonEstadoTecnica");
                button4.ImageUrl = (button4.ImageUrl != "~/Content/Imagenes/noaprobado.png") ? "~/Content/Imagenes/noaprobado.png" : "~/Content/Imagenes/aprobado.png";
            }
            this.UpdatePanelGrillaDegustaciones.Update();

        }

        protected void GridViewDegustacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList list = (DropDownList)e.Row.FindControl("DropDownListEstados");
                ImageButton button = (ImageButton)e.Row.FindControl("ImageButtonEstadoAmbientacion");
                ImageButton button2 = (ImageButton)e.Row.FindControl("ImageButtonEstadoTecnica");
                int id = int.Parse(e.Row.Cells[0].Text);
                DomainAmbientHouse.Entidades.Degustacion degustacion = this.administracion.BuscarDegustacion(id);
                button.ImageUrl = degustacion.ConfirmoAmbientacion ? "~/Content/Imagenes/aprobado.png" : "~/Content/Imagenes/noaprobado.png";
                button2.ImageUrl = degustacion.ConfirmoTecnica ? "~/Content/Imagenes/aprobado.png" : "~/Content/Imagenes/noaprobado.png";
                list.DataSource = this.administracion.BuscarEstadosPorEntidad("Degustacion");
                list.DataTextField = "Descripcion";
                list.DataValueField = "Id";
                list.DataBind();
                list.SelectedValue = degustacion.EstadoId.ToString();
            }

        }

        protected void GridViewDegustacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDegustacion.PageIndex = e.NewPageIndex;
            this.Buscar();

        }

       
    }
}