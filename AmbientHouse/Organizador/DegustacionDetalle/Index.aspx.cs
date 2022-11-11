using DomainAmbientHouse.Servicios;
using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace AmbientHouse.Organizador.DegustacionDetalle
{
    public partial class Index : System.Web.UI.Page
    {
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

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

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
            this.GridViewDegustacion.DataSource = this.administracion.BuscarDegustacionDetallePorDegustacion(this.DegustacionId);
            this.GridViewDegustacion.DataBind();

        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Organizador/Degustacion/Index.aspx");

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            this.GridViewDegustacion.DataSource = this.administracion.BuscarDegustacionDetallePorDegustacion(this.DegustacionId);
            this.GridViewDegustacion.DataBind();
            this.Exportar(GridViewDegustacion);

        }

        private void Exportar(GridView gridExcel)
        {
            StringBuilder sb = new StringBuilder();
            Page page = new Page();
            HtmlForm child = new HtmlForm();
            gridExcel.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(child);
            child.Controls.Add(gridExcel);
            page.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
            base.Response.Clear();
            base.Response.Buffer = true;
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.AddHeader("Content-Disposition", "attachment;filename=DATA.xls");
            base.Response.Charset = "UTF-8";
            base.Response.Write(sb.ToString());
            base.Response.End();
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


                TextBox comentario = (TextBox)row.FindControl("TextBoxComentario");
                TextBox comensal = (TextBox)row.FindControl("TextBoxComensal");


                int id = int.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.DegustacionDetalle detalle = this.administracion.BuscarDetalleDegustacion(id);

                detalle.EstadoId = int.Parse((row.FindControl("DropDownListEstados") as DropDownList).SelectedItem.Value);

                detalle.Comentarios = comentario.Text;

                if (cmd.IsNumeric(comensal.Text))
                    detalle.NroComensal = Int32.Parse(comensal.Text.ToString());

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

                TextBox comentario = (TextBox)e.Row.FindControl("TextBoxComentario");
                TextBox comensal = (TextBox)e.Row.FindControl("TextBoxComensal");

                int id = int.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.DegustacionDetalle detalle = this.administracion.BuscarDetalleDegustacion(id);

                list.DataSource = this.administracion.BuscarEstadosPorEntidad("DegustacionDetalle");
                list.DataTextField = "Descripcion";


                list.DataValueField = "Id";
                list.DataBind();

                list.SelectedValue = detalle.EstadoId.ToString();

                comentario.Text = detalle.Comentarios;

                if (cmd.IsNumeric(detalle.NroComensal))
                    comensal.Text = detalle.NroComensal.ToString();



            }

        }
    }
}