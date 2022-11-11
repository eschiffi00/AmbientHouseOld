using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.ProductosCatering
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicio = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscar();

            }
        }

        private void Buscar()
        {
            GridViewProductosCatering.DataSource = servicio.ObtenerProductosCatering();
            GridViewProductosCatering.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ProductosCatering/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewProductosCatering_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProductosCatering.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();

            Total.DataSource = servicio.ObtenerProductosCatering();
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

        protected void GridViewProductosCatering_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProductosCatering.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.ProductosCatering item = servicio.BuscarProductoCatering(id);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    servicio.NuevosProductosCatering(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();
            UpdatePanelGrilla.Update();
        }

        protected void GridViewProductosCatering_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.ProductosCatering productoCategoria = servicio.BuscarProductoCatering(id);


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");

                ListItem estado1 = new ListItem();
                estado1.Text = "Activo";
                estado1.Value = "1";

                ListItem estado2 = new ListItem();
                estado2.Text = "Inactivo";
                estado2.Value = "2";

                Estados.Items.Add(estado1);
                Estados.Items.Add(estado2);

                Estados.SelectedValue = productoCategoria.EstadoId.ToString();


            }
        }
    }
}