using DbEntidades.Entities;
using DbEntidades.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace AmbientHouse.Configuracion.AbmItems
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
                //InicializaCategorias();
                InicializaItems();
                InicializaExpBarras();
                CargaExperienciasBarras();
                CargaItems();
                //CargaCategorias();
                grdRatiosBind();
                SessionSaveAll();
            }
            SessionLoadAll();
        }

        //public void CargaCategorias()
        //{
        //    DataTable dt = new DataTable();
        //    dt = CategoriasItemOperator.GetAllWithGroups();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        ListItem item = new ListItem();
        //        item.Text = row["Text"].ToString();
        //        item.Value = row["Value"].ToString();
        //        item.Attributes["data-group"] = row["Categoria"].ToString();
        //        MultiselectCategorias.Items.Add(item);
        //    }
        //    MultiselectCategorias.DataBind();
        //}

        #region Session
        protected void SessionClearAll()
        {
            Session["ratiosListado"] = null;
        }
        protected void SessionLoadAll()
        {
            ratiosListado = (List<RatiosListado>)Session["ratiosListado"];
        }
        protected void SessionSaveAll()
        {
            Session["ratiosListado"] = ratiosListado;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session
        public void CargaExperienciasBarras()
        {
            List<TipoCateringComun> tipocatering = TipoCateringOperator.GetAllForCombo();
            foreach (var item in tipocatering)
            {
                ListItem experiencia = new ListItem();
                experiencia.Text = item.Descripcion;
                experiencia.Value = item.Id.ToString();
                MultiselectExperiencias.Items.Add(experiencia);
            }
            List<TiposBarrasComun> tipobarras = TiposBarrasOperator.GetAllForCombo();
            foreach (var item in tipobarras)
            {
                ListItem barra = new ListItem();
                barra.Text = item.Descripcion;
                barra.Value = item.Id.ToString();
                MultiselectExperiencias.Items.Add(barra);
            }
            MultiselectExperiencias.DataBind();
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
        protected void grdRatiosBind()
        {

            ratiosListado = RatiosOperator.GetAllWithDetails().ToList();
            grdRatios.DataSource = ratiosListado;
            grdRatios.DataBind();
            foreach (GridViewRow fila in grdRatios.Rows)
            {
                TableCellCollection fila2;
                fila2 = fila.Cells;
                if (fila2[18].Text == "Inactivo")
                {
                    fila.ControlStyle.BackColor = Color.LightSalmon;
                    fila.ControlStyle.ForeColor = Color.White;
                }
            }
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            List<RatiosListado> ratiosfiltrados = new List<RatiosListado>();
            if (MultiselectItems.SelectedItem != null)
            {
                foreach (ListItem item in MultiselectItems.Items)
                {
                    if (item.Selected)
                    {
                        var id = ItemsOperator.GetOneByParameter("Detalle", item.Value).Id;
                        ratiosfiltrados.AddRange(ratiosListado.Where(x => x.ItemId == id).ToList());
                    }
                }
            }
            if(MultiselectExperiencias.SelectedItem != null)
            {
                foreach (ListItem experiencia in MultiselectExperiencias.Items)
                {
                    var valor = experiencia.Value;
                    var codigoExperiencia = "";
                    if (experiencia.Selected)
                    {
                        var tipocatering = TipoCateringOperator.GetOneByIdentity(int.Parse(valor));

                        if (tipocatering != null)
                        {
                            codigoExperiencia = "TCAT" + tipocatering.Id;
                        }
                        else
                        {
                            var tipobarra = TiposBarrasOperator.GetOneByIdentity(int.Parse(valor));
                            if (tipobarra != null)
                            {
                                codigoExperiencia = "BAR" + tipobarra.Id;
                            }
                        }
                        
                        ratiosfiltrados = ratiosfiltrados.Where(x => x.ExperienciaBarraCodigo == codigoExperiencia).ToList();
                    }
                }
            }
            //if (MultiselectCategorias.SelectedItem != null)
            //{
            //    foreach (ListItem categoria in MultiselectCategorias.Items)
            //    {
            //        if (categoria.Selected)
            //        {
            //            ratiosfiltrados.AddRange(ratiosfiltrados.Where(x => x.CategoriaId == Int32.Parse(categoria.Value)).ToList());
            //        }
            //    }
            //}
            grdRatios.DataSource = ratiosfiltrados;
            grdRatios.DataBind();


            //RatiosListado listadoRatios = new RatiosListado();
            //List<Ratios> listaRatios = new List<Ratios>();
            //if(MultiselectItems.SelectedItem != null)
            //{
            //    foreach (ListItem item in MultiselectItems.Items)
            //    {
            //        if (item.Selected)
            //        {
            //            listaRatios.AddRange(RatiosOperator.GetAllByParameter("ItemId", item.Value.ToString()));
            //        }
            //    }
            //}
            //else
            //{
            //    var ItemDet = ItemsOperator.GetOneByParameter("Detalle", item.Value);
            //    List<ItemDetalle> lista = new List<ItemDetalle>();
            //    if (ItemDet.ItemDetalleId != null && ItemDet.ItemDetalleId > 0)
            //    {
            //        lista = ItemDetalleOperator.GetAllByParameter("ItemId", ItemDet.ItemDetalleId.Value);
            //        foreach (var idCategoria in lista)
            //        {

            //            foreach (ListItem categoria in MultiselectCategorias.Items)
            //            {

            //                var descripcion = CategoriasItemOperator.GetOneByIdentity(idCategoria.CategoriaId).Descripcion;
            //                if (descripcion == categoria.Text)
            //                {

            //                    //listadoRatios.add();
            //                }
            //            }
            //        }
            //    }
            //}
        }

        protected void btnNuevoRatio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AbmItems/RatiosEdit.aspx");
        }
        protected void grdRatios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "ID");
            int id = Convert.ToInt32(row.Cells[colindex].Text);
            //colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "Categoria Detalle");
            //string categoria = row.Cells[colindex].Text;

            if (e.CommandName == "CommandNameDelete")
            {
                RatiosOperator.Delete(id);
                grdRatiosBind();
            }
            if (e.CommandName == "CommandNameEdit")
            {

                Response.Redirect("../../Configuracion/AbmItems/RatiosEdit.aspx?Id=" + id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdRatios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void MultiselectItems_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    InicializaCategorias();
        //    foreach (ListItem item in MultiselectItems.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            var ItemDet = ItemsOperator.GetOneByParameter("Detalle", item.Value);
        //            List<ItemDetalle> lista = new List<ItemDetalle>();
        //            if (ItemDet.ItemDetalleId != null && ItemDet.ItemDetalleId > 0)
        //            {
        //                lista = ItemDetalleOperator.GetAllByParameter("ItemId", ItemDet.ItemDetalleId.Value);
        //                foreach (var idCategoria in lista)
        //                {
        //                    foreach (ListItem categoria in MultiselectCategorias.Items)
        //                    {
        //                        var descripcion = CategoriasItemOperator.GetOneByIdentity(idCategoria.CategoriaId).Descripcion;
        //                        if (descripcion == categoria.Text)
        //                        {
        //                            categoria.Selected = true;
        //                            categoria.Enabled = true;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                foreach (ListItem categoria in MultiselectCategorias.Items)
        //                {

        //                    var descripcion = CategoriasItemOperator.GetOneByIdentity(ItemDet.CategoriaItemId).Descripcion;
        //                    if (descripcion == categoria.Text)
        //                    {
        //                        categoria.Selected = true;
        //                        categoria.Enabled = true;
        //                    }
        //                }
        //            }

        //            foreach (ListItem Categoria in MultiselectCategorias.Items)
        //            {
        //                if (!Categoria.Selected)
        //                {
        //                    Categoria.Selected = false;
        //                    Categoria.Enabled = false;
        //                }
        //            }
        //        }
        //    }
        //}
        //protected void InicializaCategorias()
        //{
        //    foreach (ListItem Categoria in MultiselectCategorias.Items)
        //    {
        //        Categoria.Selected = false;
        //        Categoria.Enabled = true;
        //    }
        //}
        protected void InicializaItems()
        {
            foreach (ListItem Item in MultiselectItems.Items)
            {
                Item.Selected = false;
                Item.Enabled = true;
            }
        }
        protected void InicializaExpBarras()
        {
            foreach (ListItem Item in MultiselectExperiencias.Items)
            {
                Item.Selected = false;
                Item.Enabled = true;
            }
        }
    }
}