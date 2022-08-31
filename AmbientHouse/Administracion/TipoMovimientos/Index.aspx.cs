using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Administracion.TipoMovimientos
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                BuscarTipoMovimientos();
            }
        }

        private void CargarListas()
        {
            DropDownListTipoMovimientoPadre.DataSource = administracion.ObtenerTipoMovimientosPadres();
            DropDownListTipoMovimientoPadre.DataTextField = "Identificador";
            DropDownListTipoMovimientoPadre.DataValueField = "Id";
            DropDownListTipoMovimientoPadre.DataBind();
        }

        private void BuscarTipoMovimientos()
        {
            DomainAmbientHouse.Entidades.TipoMovimientoSearcher searcher = new DomainAmbientHouse.Entidades.TipoMovimientoSearcher();

            if (DropDownListTipoMovimientoPadre.SelectedItem.Value != "NULL")
                searcher.Tipo = DropDownListTipoMovimientoPadre.SelectedItem.Value;

            searcher.Codigo = TextBoxCodigoBuscador.Text;


            GridViewTipoMovimientos.DataSource = administracion.ObtenerTipoMovimientosTodos(searcher);
            GridViewTipoMovimientos.DataBind();

            UpdatePanelGrillaTipoMovimientos.Update();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/TipoMovimientos/Editar.aspx");
        }

        protected void GridViewTipoMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTipoMovimientos.PageIndex = e.NewPageIndex;
            BuscarTipoMovimientos();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarTipoMovimientos();

        }
    }
}