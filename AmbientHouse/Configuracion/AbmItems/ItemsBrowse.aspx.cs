using DbEntidades.Entities;
using DbEntidades.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.AbmItems
{
    public partial class ItemsBrowse : System.Web.UI.Page
    {
        List<ItemsListado> itemsListado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (string.IsNullOrEmpty(Convert.ToString(Session["UsuarioId"]))) Response.Redirect("~/app/Seguridad/UsuarioLogin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                //if (!PermisoOperator.TienePermiso(Convert.ToInt32(Session["UsuarioId"]), GetType().BaseType.FullName)) throw new PermisoException();
                InicializaItems();
                InicializaCategorias();
                CargaItems();
                CargaCategorias();
                grdItemsBind();
                SessionSaveAll();
            }
            SessionLoadAll();
        }
        #region Session
        protected void SessionClearAll()
        {
            Session["itemsListado"] = null;
        }
        protected void SessionLoadAll()
        {
            itemsListado = (List<ItemsListado>)Session["itemsListado"];
        }
        protected void SessionSaveAll()
        {
            Session["itemsListado"] = itemsListado;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session
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
            foreach (ItemsCombo item in ItemsCombo)
            {
                ListItem MultiItem = new ListItem();
                MultiItem.Text = item.Detalle;
                MultiItem.Value = item.Id.ToString();

                MultiselectItems.Items.Add(MultiItem.ToString());
            }
            MultiselectItems.DataBind();
        }

        protected void grdItemsBind()
        {
            itemsListado = ItemsOperator.GetAllWithDetails().ToList();
            grdItems.DataSource = itemsListado;

            grdItems.DataBind();
            foreach (GridViewRow fila in grdItems.Rows)
            {
                TableCellCollection fila2;
                fila2 = fila.Cells;
                if (fila2[16].Text == "Inactivo")
                {
                    fila.ControlStyle.BackColor = Color.LightSalmon;
                    fila.ControlStyle.ForeColor = Color.White;
                }
            }
            //grdItems.DataBind();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevoItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AbmItems/ItemsEdit.aspx");
        }
        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "ID");
            int id = Convert.ToInt32(row.Cells[colindex].Text);

            if (e.CommandName == "CommandNameDelete")
            {
                ItemsOperator.Delete(id);
                grdItemsBind();
            }
            if (e.CommandName == "CommandNameEdit")
            {

                Response.Redirect("../../Configuracion/AbmItems/ItemsEdit.aspx?Id=" + id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            List<ItemsListado> itemsFiltrados = new List<ItemsListado>();
            if (MultiselectItems.SelectedItem != null)
            {
                foreach (ListItem item in MultiselectItems.Items)
                {
                    if (item.Selected)
                    {
                        var id = ItemsOperator.GetOneByParameter("Detalle", item.Value).Id;
                        itemsFiltrados.AddRange(itemsListado.Where(x => x.Id == id).ToList());
                    }
                }
            }
            if (MultiselectCategorias.SelectedItem != null)
            {
                foreach (ListItem categoria in MultiselectCategorias.Items)
                {
                    if (categoria.Selected)
                    {
                        
                        var idCat = CategoriasItemOperator.GetOneByParameter("Descripcion", categoria.Text).Id;
                        
                        if (itemsListado.Where(x => x.CategoriaItemId == idCat).Count() <= 0)
                        {
                            var subCategorias = CategoriasItemOperator.GetAllByParameter("CategoriaItemPadreId", idCat.ToString());
                            if (subCategorias.Count > 0)
                            {
                                foreach(var subCategoria in subCategorias)
                                {
                                    itemsFiltrados.AddRange(itemsListado.Where(x => x.CategoriaItemId == subCategoria.Id));
                                }
                            }
                        }
                        else
                        {
                            itemsFiltrados.AddRange(itemsListado.Where(x => x.CategoriaItemId == idCat));
                        }

                    }
                }
            }
            grdItems.DataSource = itemsFiltrados;
            grdItems.DataBind();
        }
        protected void InicializaItems()
        {
            foreach (ListItem Item in MultiselectItems.Items)
            {
                Item.Selected = false;
                Item.Enabled = true;
            }
        }
        protected void InicializaCategorias()
        {
            foreach (ListItem Item in MultiselectCategorias.Items)
            {
                Item.Selected = false;
                Item.Enabled = true;
            }
        }
    }
}