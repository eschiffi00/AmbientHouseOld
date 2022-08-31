using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Web.UI.HtmlControls;
using DomainAmbientHouse.Datos;

namespace AmbientHouse.Configuracion.ItemDetalle
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicio = new AdministrativasServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarItems();

            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarItems();
        }

        private void BuscarItems()
        {
            ItemDetalleSearcher searcher = new ItemDetalleSearcher();

            searcher.Descripcion = TextBoxDetalleBuscador.Text;

            GridViewItems.DataSource = servicio.ObtenerItemDetalle(searcher);
            GridViewItems.DataBind();
 
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ItemDetalle/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridViewItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                TextBox Descripcion = (TextBox)e.Row.FindControl("TextBoxDescripcion");
                
                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.ItemDetalle item = servicio.BuscarItemDetalle(ItemId);

                Descripcion.Text = item.Descripcion.ToString();
               
            }
        }
    }
}