using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.TipoCateringTiempoProductoItem
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios administracion = new AdministrativasServicios();

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

            DropDownListTipoCatering.DataSource = administracion.ObtenerTipoCatering();
            DropDownListTipoCatering.DataTextField = "Descripcion";
            DropDownListTipoCatering.DataValueField = "Id";
            DropDownListTipoCatering.DataBind();
        }

        private void Buscar()
        {
            GridViewTiempos.DataSource = administracion.ObtenerTipoCateringTiempoProductoItemDatos(Int32.Parse(DropDownListTipoCatering.SelectedItem.Value));
            GridViewTiempos.DataBind();

            UpdatePanelGrilla.Update();
        }

        protected void GridViewTiempos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTiempos.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCateringTiempoProductoItem/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();


            Total.DataSource = administracion.BuscarConfiguracionPorTipoCatering(Int32.Parse(DropDownListTipoCatering.SelectedItem.Value));
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

        protected void DropDownListTipoCatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void GridViewTiempos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");

                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem item = administracion.BuscarTipoCateringTiempoProductoItem(ItemId);

                Estados.DataSource = administracion.BuscarEstadosPorEntidad("TipoCateringTiempoProductoItem");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();

                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

        protected void GridViewTiempos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTiempos.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.TipoCateringTiempoProductoItem item = administracion.BuscarTipoCateringTiempoProductoItem(ItemId);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);



                try
                {
                    administracion.ActualizarTipoCateringTiempoProductoItem(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();

        }

    }
}