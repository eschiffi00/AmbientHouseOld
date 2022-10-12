using DbEntidades.Entities;
using DbEntidades.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
namespace WebApplication.app.ItemsNS
{
    public partial class RatiosBrowse : System.Web.UI.Page
    {
        List<RatiosListado> ratiosListado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (string.IsNullOrEmpty(Convert.ToString(Session["UsuarioId"]))) Response.Redirect("~/app/Seguridad/UsuarioLogin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                //if (!PermisoOperator.TienePermiso(Convert.ToInt32(Session["UsuarioId"]), GetType().BaseType.FullName)) throw new PermisoException();
                InicializaCategorias();
                InicializaItems();
                CargaItems();
                CargaCategorias();
                grdRatiosBind();

            }
            
        }

        public void CargaCategorias()
        {
            DataTable dt = new DataTable();
            dt = CategoriasItemOperator.GetAllWithGroups();
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["Text"].ToString();
                item.Value = row["Value"].ToString();
                item.Attributes["data-group"] = row["Categoria"].ToString();
                MultiselectCategorias.Items.Add(item);
            }
            MultiselectCategorias.DataBind();
        }
        public void CargaItems()
        {
            
            List<ItemsCombo> ItemsCombo = ItemsOperator.GetAllForCombo();
            foreach(ItemsCombo item in ItemsCombo)
            {
                ListItem MultiItem = new ListItem();
                MultiItem.Text = item.Detalle;
                MultiItem.Value = item.Id.ToString();

                MultiselectItems.Items.Add(MultiItem.ToString()) ;
            }
            MultiselectItems.DataBind();
        }
        protected void grdRatiosBind()
        {
            ratiosListado = RatiosOperator.GetAllWithDetails().ToList();
            grdRatios.DataSource = ratiosListado;
            grdRatios.DataBind();
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            RatiosListado listadoRatios = new RatiosListado();
            foreach (ListItem item in MultiselectItems.Items)
            {
                if (item.Selected)
                {
                    var ItemDet = ItemsOperator.GetOneByParameter("Detalle", item.Value);
                    List<ItemDetalle> lista = new List<ItemDetalle>();
                    if (ItemDet.ItemDetalleId != null && ItemDet.ItemDetalleId > 0)
                    {
                        lista = ItemDetalleOperator.GetAllByParameter("ItemId", ItemDet.ItemDetalleId.ToString());
                    }
                    foreach (var idCategoria in lista)
                    {

                        foreach (ListItem categoria in MultiselectCategorias.Items)
                        {

                            var descripcion = CategoriasItemOperator.GetOneByIdentity(idCategoria.CategoriaId).Descripcion;
                            if (descripcion == categoria.Text)
                            {
                                //listadoRatios.add();
                            }
                        }
                    }
                }

            }
        }

        protected void btnNuevoRatio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AdmItems/RatiosEdit.aspx");
        }
        protected void grdRatios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "ID");
            int id = Convert.ToInt32(row.Cells[colindex].Text);

            if (e.CommandName == "CommandNameDelete")
            {
                ItemsOperator.Delete(id);
                grdRatiosBind();
            }
            if (e.CommandName == "CommandNameEdit")
            {

                Response.Redirect("../../Configuracion/AdmItems/RatiosEdit.aspx?Id="+id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdRatios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void MultiselectItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicializaCategorias();
            foreach (ListItem item in MultiselectItems.Items)
            {
                if (item.Selected)
                {
                    var ItemDet = ItemsOperator.GetOneByParameter("Detalle", item.Value);
                    List<ItemDetalle> lista = new List<ItemDetalle>();
                    if (ItemDet.ItemDetalleId != null && ItemDet.ItemDetalleId > 0)
                    {
                        lista = ItemDetalleOperator.GetAllByParameter("ItemId", ItemDet.ItemDetalleId.ToString());
                    }
                    foreach (var idCategoria in lista)
                    {
                        
                        foreach(ListItem categoria in MultiselectCategorias.Items)
                        {
                        
                            var descripcion = CategoriasItemOperator.GetOneByIdentity(idCategoria.CategoriaId).Descripcion;
                            if ( descripcion == categoria.Text)
                            {
                                categoria.Selected = true;
                                categoria.Enabled  = true;
                            }
                        }
                    }
                }

            }
            foreach (ListItem Categoria in MultiselectCategorias.Items)
            {
                if (!Categoria.Selected)
                {
                    Categoria.Selected = false;
                    Categoria.Enabled = false;
                }
            }
        }
        protected void InicializaCategorias()
        {
            foreach (ListItem Categoria in MultiselectCategorias.Items)
            {
                    Categoria.Selected = false;
                    Categoria.Enabled = true;
            }
        }
        protected void InicializaItems()
        {
            foreach (ListItem Item in MultiselectItems.Items)
            {
                Item.Selected = false;
                Item.Enabled = true;
            }
        }
    }
}