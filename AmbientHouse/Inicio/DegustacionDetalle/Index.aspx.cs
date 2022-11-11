using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio.DegustacionDetalle
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        private int DegustacionId
        {
            get
            {
                return Int32.Parse(Session["DegustacionId"].ToString());
            }
            set
            {
                Session["DegustacionId"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.InicializarPagina();
            }

        }

        private void InicializarPagina()
        {
            int id = 0;
            if (base.Request["Id"] != null)
            {
                id = int.Parse(base.Request["Id"]);
                this.DegustacionId = id;
            }
            this.Buscar();
        }

        private void Buscar()
        {
            this.GridViewDegustacion.DataSource = this.administracion.BuscarDegustacionDetallePorEmpleado(this.DegustacionId, this.EmpleadoId);
            this.GridViewDegustacion.DataBind();

        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Inicio/Degustacion/Index.aspx");

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Inicio/DegustacionDetalle/Editar.aspx");

        }

        protected void GridViewDegustacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDegustacion.PageIndex = e.NewPageIndex;
            this.Buscar();

        }

        protected void GridViewDegustacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.GridViewDegustacion.Rows[num];
                int id = int.Parse(row.Cells[0].Text);
                DomainAmbientHouse.Entidades.DegustacionDetalle detalle = this.administracion.BuscarDetalleDegustacion(id);
                detalle.EstadoId = int.Parse((row.FindControl("DropDownListEstados") as DropDownList).SelectedItem.Value);
                try
                {
                    this.administracion.Grabar(detalle);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            this.Buscar();
            this.UpdatePanelGrillaDegustaciones.Update();

        }

        protected void GridViewDegustacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList list = (DropDownList)e.Row.FindControl("DropDownListEstados");

                int id = Int32.Parse(e.Row.Cells[0].Text);

                list.DataSource = this.administracion.BuscarEstadosPorEntidad("DegustacionDetalle");
                list.DataTextField = "Descripcion";
                list.DataValueField = "Id";
                list.DataBind();

                list.SelectedValue = this.administracion.BuscarDetalleDegustacion(id).EstadoId.ToString();
            }

        }
    }
}