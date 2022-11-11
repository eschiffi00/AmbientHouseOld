using DomainAmbientHouse.Servicios;
using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Operacion.DesgustacionDetalle
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
            base.Response.Redirect("~/Operacion/Degustacion/Index.aspx");
        }

        protected void GridViewDegustacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewDegustacion.PageIndex = e.NewPageIndex;
            this.Buscar();
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

    }
}