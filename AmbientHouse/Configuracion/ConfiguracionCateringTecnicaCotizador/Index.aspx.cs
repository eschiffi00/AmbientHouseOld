using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.ConfiguracionCateringTecnicaCotizador
{
    public partial class Index : System.Web.UI.Page
    {
        private List<ConfiguracionCateringTecnica> ListConfiguraciones
        {
            get
            {
                return Session["ListConfiguraciones"] as List<ConfiguracionCateringTecnica>;
            }
            set
            {
                Session["ListConfiguraciones"] = value;
            }
        }

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListConfiguraciones = new List<ConfiguracionCateringTecnica>();

                CargarListas();
                BuscarConfiguracionCateringTecnica();
            }

        }

        private void CargarListas()
        {
            DropDownListMomentoDelDia.DataSource = servicios.ObtenerMomentosDias();
            DropDownListMomentoDelDia.DataTextField = "Descripcion";
            DropDownListMomentoDelDia.DataValueField = "Id";
            DropDownListMomentoDelDia.DataBind();

            DropDownListCaracteristica.DataSource = eventos.TraerCaracteristicas();
            DropDownListCaracteristica.DataTextField = "Descripcion";
            DropDownListCaracteristica.DataValueField = "Id";
            DropDownListCaracteristica.DataBind();


            DropDownListSegmento.DataSource = eventos.TraerSegmentos();
            DropDownListSegmento.DataTextField = "Descripcion";
            DropDownListSegmento.DataValueField = "Id";
            DropDownListSegmento.DataBind();

            DropDownListDuracion.DataSource = servicios.ObtenerDuracionEvento();
            DropDownListDuracion.DataTextField = "Descripcion";
            DropDownListDuracion.DataValueField = "Id";
            DropDownListDuracion.DataBind();



        }

        private void BuscarConfiguracionCateringTecnica()
        {

            int segmentoId = 0;
            if (DropDownListSegmento.SelectedItem.Value != "null")
            { segmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value); }

            int caracteristicaId = 0;
            if (DropDownListCaracteristica.SelectedItem.Value != "null")
            { caracteristicaId = Int32.Parse(DropDownListCaracteristica.SelectedItem.Value); }

            int momentodiaId = 0;
            if (DropDownListMomentoDelDia.SelectedItem.Value != "null")
            { momentodiaId = Int32.Parse(DropDownListMomentoDelDia.SelectedItem.Value); }

            int duracionId = 0;
            if (DropDownListDuracion.SelectedItem.Value != "null")
            { duracionId = Int32.Parse(DropDownListDuracion.SelectedItem.Value); }



            ListConfiguraciones = servicios.ObtenerConfiguracionCateringTecnica(segmentoId, caracteristicaId, momentodiaId, duracionId);

            GridViewConfigCateringTecnica.DataSource = ListConfiguraciones.ToList();

            GridViewConfigCateringTecnica.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ConfiguracionCateringTecnicaCotizador/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        //protected void GridViewConfigCateringTecnica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridViewConfigCateringTecnica.PageIndex = e.NewPageIndex;
        //    BuscarConfiguracionCateringTecnica();
        //}

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarConfiguracionCateringTecnica();

            UpdatePanelGrillaConfigCateringTecnica.Update();
        }

        protected void ButtonActivarSeleccionados_Click(object sender, EventArgs e)
        {
            int activoConfig = Int32.Parse(ConfigurationManager.AppSettings["configuracionTecnicaCateringACTIVO"].ToString());

            foreach (GridViewRow row in GridViewConfigCateringTecnica.Rows)
            {

                CheckBox check = row.FindControl("CheckBoxSeleccionar") as CheckBox;

                if (check.Checked)
                {
                    int item = Int32.Parse(row.Cells[0].Text);

                    servicios.ActivarDesactivarConfiguracion(item, activoConfig);

                }
            }

            BuscarConfiguracionCateringTecnica();

            UpdatePanelGrillaConfigCateringTecnica.Update();

        }

        protected void ButtonDesactivarSeleccionados_Click(object sender, EventArgs e)
        {
            int desactivoConfig = Int32.Parse(ConfigurationManager.AppSettings["configuracionTecnicaCateringINACTIVO"].ToString());

            foreach (GridViewRow row in GridViewConfigCateringTecnica.Rows)
            {

                CheckBox check = row.FindControl("CheckBoxSeleccionar") as CheckBox;

                if (check.Checked)
                {
                    int item = Int32.Parse(row.Cells[0].Text);

                    servicios.ActivarDesactivarConfiguracion(item, desactivoConfig);

                }
            }

            BuscarConfiguracionCateringTecnica();

            UpdatePanelGrillaConfigCateringTecnica.Update();

        }

        protected void ButtonSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewConfigCateringTecnica.Rows)
            {

                CheckBox check = row.FindControl("CheckBoxSeleccionar") as CheckBox;

                if (check.Checked)
                    check.Checked = false;
                else
                    check.Checked = true;
            }
        }

        public string EvaluarEstado(Object id)
        {

            int key = (int)id;

            var estados = servicios.BuscarEstado(key);


            return estados.Descripcion;

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();

            int segmentoId = 0;
            if (DropDownListSegmento.SelectedItem.Value != "null")
            { segmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value); }

            int caracteristicaId = 0;
            if (DropDownListCaracteristica.SelectedItem.Value != "null")
            { caracteristicaId = Int32.Parse(DropDownListCaracteristica.SelectedItem.Value); }

            int momentodiaId = 0;
            if (DropDownListMomentoDelDia.SelectedItem.Value != "null")
            { momentodiaId = Int32.Parse(DropDownListMomentoDelDia.SelectedItem.Value); }

            int duracionId = 0;
            if (DropDownListDuracion.SelectedItem.Value != "null")
            { duracionId = Int32.Parse(DropDownListDuracion.SelectedItem.Value); }

            Total.DataSource = servicios.ObtenerConfiguracionCateringTecnica(segmentoId, caracteristicaId, momentodiaId, duracionId);
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

    }
}