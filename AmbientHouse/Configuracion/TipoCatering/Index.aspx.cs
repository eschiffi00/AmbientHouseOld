using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.TipoCatering
{
    public partial class Index : System.Web.UI.Page
    {
        private AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BuscarTipoCatering();
            }
        }

        private void BuscarTipoCatering()
        {
            GridViewTpoCatering.DataSource = servicios.ObtenerTipoCatering();
            GridViewTpoCatering.DataBind();
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCatering/Editar.aspx");
        }

        public string EvaluarEstado(Object id)
        {

            int key = (int)id;

            var estados = servicios.BuscarEstado(key);


            return estados.Descripcion;

        }

        protected void GridViewTpoCatering_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTpoCatering.PageIndex = e.NewPageIndex;
            BuscarTipoCatering();
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();




            Total.DataSource = servicios.ObtenerTipoCatering();
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

        protected void GridViewTpoCatering_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");


                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.TipoCatering item = servicios.BuscarTipoCatering(ItemId);


                Estados.DataSource = servicios.BuscarEstadosPorEntidad("TipoCatering");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();


                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

        protected void GridViewTpoCatering_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTpoCatering.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.TipoCatering item = servicios.BuscarTipoCatering(ItemId);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    servicios.ActualizarTipoCatering(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            BuscarTipoCatering();
            UpdatePanelGrillaClientes.Update();
        }
    }
}