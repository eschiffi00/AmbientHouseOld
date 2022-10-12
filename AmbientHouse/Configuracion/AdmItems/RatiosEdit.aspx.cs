using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbEntidades.Entities;
using DbEntidades.Operators;
using System.Globalization;
using System.Data;
using System.Text.RegularExpressions;

namespace WebApplication.app.ItemsNS
{
    public partial class RatiosEdit : System.Web.UI.Page
    {
        Ratios seRatios = null;
        DataTable tablagrid = new DataTable();
        List<int> listaitem = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //tablagrid.Columns.Add(new DataColumn("Item", typeof(string)));
                Session["tablagrid"] = tablagrid;
                Session["listaitem"] = listaitem;
                SessionClearAll();
                string s;
                object o = Page.RouteData.Values["id"];
                if (o != null) s = Page.RouteData.Values["id"].ToString();
                else s = Request.QueryString["id"];
                int id = 0;
                id = Int32.Parse(Request["Id"] != null ? Request["Id"] : "0");

                InicializaCategorias();
                InicializaItems();
                CargaItems();
                CargaCategorias();
                
                if (id != 0)
                {
                    int uid = Convert.ToInt32(s);
                    seRatios = RatiosOperator.GetOneByIdentity(uid);
                    
                    switch (seRatios.TipoDependencia)
                    {
                        case "PAX": ddlDependencia.SelectedValue = "1";
                            break;
                        case "ITEM":
                            ddlDependencia.SelectedValue = "2";
                            break;
                    }
                    txtDetalle.Text = seRatios.DetalleDependencia;
                    txtValor.Text = seRatios.ValorRatio.ToString();
                    txtTope.Text = seRatios.TopeRatio.ToString();
                    if (seRatios.Menores == 1)
                    {
                        chkMenores.Checked = true;
                    }
                    if (seRatios.AdicionalRatio == 1)
                    {
                        chkAdicional.Checked = true;
                    }

                    //obtengo todas las categorias y utilizo descripcion y id
                    var categorias = ItemDetalleOperator.GetAllByParameter("ItemId", id.ToString());
                    if (categorias.Count() > 0)
                    {
                        foreach (ListItem item in MultiselectCategorias.Items)
                        {
                            var categoria = categorias.Where(x => x.CategoriaId == Int32.Parse(item.Value)).ToList();
                            if (categoria.Count() > 0)
                            {
                                item.Selected = true;
                            }
                        }
                        foreach (ListItem item in MultiselectCategorias.Items)
                        {
                            if (!item.Selected)
                            {
                                item.Selected = false;
                                item.Enabled = false;
                            }
                        }
                    }
                    
                    ddlEstado.SelectedValue = EstadosOperator.GetOneByIdentity(seRatios.EstadoId).Id.ToString();
                }
                else
                {
                    h4Titulo.InnerText = "Creación de nuevo Ratio";
                    seRatios = new Ratios();
                }
                SessionSaveAll();
            }
            SessionLoadAll();
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
            foreach (ItemsCombo item in ItemsCombo)
            {
                ListItem MultiItem = new ListItem();
                MultiItem.Text = item.Detalle;
                MultiItem.Value = item.Id.ToString();

                MultiselectItems.Items.Add(MultiItem.ToString());
            }
            MultiselectItems.DataBind();
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

                        foreach (ListItem categoria in MultiselectCategorias.Items)
                        {

                            var descripcion = CategoriasItemOperator.GetOneByIdentity(idCategoria.CategoriaId).Descripcion;
                            if (descripcion == categoria.Text)
                            {
                                categoria.Selected = true;
                                categoria.Enabled = true;
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

        #region Session
        protected void SessionClearAll()
        {
            Session["seRatios"] = null;
        }
        protected void SessionLoadAll()
        {
            seRatios = (Ratios)Session["seRatios"];
        }
        protected void SessionSaveAll()
        {
            Session["seRatios"] = seRatios;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Ratios Ratio = new Ratios();
            try
            {   if(txtDetalle.Text == null || txtDetalle.Text == "") { Ratio.DetalleDependencia = " "; }
                else { Ratio.DetalleDependencia = txtDetalle.Text; }
                //seRatios.DetalleDependencia = txtDetalle.Text;
                Ratio.ValorRatio = float.Parse(txtValor.Text);
                Ratio.TopeRatio = float.Parse(txtTope.Text);
                Ratio.Menores = chkMenores.Checked ? 1 : 0;
                Ratio.AdicionalRatio = chkAdicional.Checked ? 1 : 0;
                Ratio.EstadoId = EstadosOperator.GetHablitadoID("Items");
                switch (ddlDependencia.SelectedValue)
                {
                    case "1":
                        Ratio.TipoDependencia = "PAX";
                        break;
                    case "2":
                        Ratio.TipoDependencia = "ITEM";
                        break;
                }          
                
                foreach(ListItem item in MultiselectItems.Items)
                {
                    var detItem = ItemsOperator.GetOneByParameter("Detalle", item.Text);
                    if (item.Selected)
                    {
                        foreach (ListItem categoria in MultiselectCategorias.Items)
                        {
                            var categoriasItem = ItemDetalleOperator.GetAllByParameter("ItemId", detItem.ItemDetalleId.ToString());
                            foreach(var detalle in categoriasItem)
                            {
                                if (categoria.Selected && Int32.Parse(categoria.Value) == detalle.CategoriaId)
                                {
                                    Ratio.Id = -1;
                                    Ratio.ItemId = detItem.Id;
                                    Ratio.CategoriaId = Int32.Parse(categoria.Value);
                                    RatiosOperator.Save(Ratio);
                                }
                            }
                            
                        }
                    }
                }
                Response.Redirect("~/Configuracion/AdmItems/ItemsBrowse.aspx");
            }
            catch (Exception ex)
            {
                //AlertaRoja(ex.Message);
            }
        }
        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlDependencia.SelectedValue == "1")
            {
                txtDetalle.Enabled = false;
            }
            else
            {
                txtDetalle.Enabled = true;
            }
        }

    }

}