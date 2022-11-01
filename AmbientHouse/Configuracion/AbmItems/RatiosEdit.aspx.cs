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


namespace AmbientHouse.Configuracion.AbmItems
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
                Session["tablagrid"] = tablagrid;
                Session["listaitem"] = listaitem;
                SessionClearAll();
                //string s;
                //object o = Page.RouteData.Values["id"];
                //if (o != null) s = Page.RouteData.Values["id"].ToString();
                //else s = Request.QueryString["id"];
                var temp = Request["Id"];
                var id = 0;
                var categoria = "";
                if (temp != null)
                {
                    var list = temp.Split('-');
                    id = Int32.Parse(list[0]);
                    categoria = list[1];
                }


                InicializaCategorias();
                InicializaItems();
                InicializaExpBarras();
                CargaExperienciasBarras();
                CargaItems();
                CargaCategorias();
                
                if (id != 0)
                {
                    seRatios = RatiosOperator.GetOneByIdentity(id);
                    var Item = MultiselectItems.Items.FindByText(ItemsOperator.GetOneByParameter("Id",seRatios.ItemId.ToString()).Detalle);
                    Item.Selected = true;
                    MultiselectItems.Enabled = false;
                    ListItem experienciabarra = new ListItem();
                    if (seRatios.ExperienciaBarra.Substring(0, 3) == "BAR")
                    {
                        experienciabarra = MultiselectExperiencias.Items.FindByText(TiposBarrasOperator.GetOneByParameter("Id", seRatios.ExperienciaBarra.Substring(3)).Descripcion);
                    }
                    else
                    {
                        experienciabarra = MultiselectExperiencias.Items.FindByText(TipoCateringOperator.GetOneByParameter("Id", seRatios.ExperienciaBarra.Substring(4)).Descripcion);
                    }
                    experienciabarra.Selected = true;
                    switch (seRatios.TipoRatio)
                    {
                        case "PAX": ddlDependencia.SelectedValue = "1";
                            break;
                        case "ITEM":
                            ddlDependencia.SelectedValue = "2";
                            break;
                    }
                    txtDetalle.Text = seRatios.DetalleTipo;
                    txtValor.Text = seRatios.ValorRatio.ToString();
                    txtTope.Text = seRatios.TopeRatio.ToString();
                    if (seRatios.Menores3 == 1)
                    {
                        chkMenores3.Checked = true;
                    }
                    if (seRatios.Menores3y8 == 1)
                    {
                        chkMenores3y8.Checked = true;
                    }
                    if (seRatios.Adolescentes == 1)
                    {
                        chkAdolescentes.Checked = true;
                    }
                    if (seRatios.AdicionalRatio == 1)
                    {
                        chkAdicional.Checked = true;
                    }
                    var cat = MultiselectCategorias.Items.FindByText(categoria);
                    cat.Selected = true;
                    MultiselectCategorias.Enabled = false;
                    //obtengo todas las categorias y utilizo descripcion y id
                    //var categorias = ItemDetalleOperator.GetAllByParameter("ItemId", id);
                    //if (categorias.Count() > 0)
                    //{
                    //    foreach (ListItem item in MultiselectCategorias.Items)
                    //    {
                    //        var categoria = categorias.Where(x => x.CategoriaId == Int32.Parse(item.Value)).ToList();
                    //        if (categoria.Count() > 0)
                    //        {
                    //            item.Selected = true;
                    //        }
                    //    }
                    //    foreach (ListItem item in MultiselectCategorias.Items)
                    //    {
                    //        if (!item.Selected)
                    //        {
                    //            item.Selected = false;
                    //            item.Enabled = false;
                    //        }
                    //    }
                    //}else
                    //{
                    //    var cat = MultiselectCategorias.Items.FindByText(CategoriasItemOperator.GetOneByParameter("Id",seRatios.CategoriaId.ToString()).Descripcion);
                    //    cat.Selected = true;
                    //}

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
                        lista = ItemDetalleOperator.GetAllByParameter("ItemId", ItemDet.ItemDetalleId.Value);
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
                    }
                    else
                    {
                        foreach (ListItem categoria in MultiselectCategorias.Items)
                        {

                            var descripcion = CategoriasItemOperator.GetOneByIdentity(ItemDet.CategoriaItemId).Descripcion;
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
        protected void InicializaExpBarras()
        {
            foreach (ListItem Item in MultiselectExperiencias.Items)
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
            var duplicado = 0;
            List<string> parametros = new List<string>();
            Ratios Ratio = new Ratios();
            try
            {
                var temp = Request["Id"];
                var id = 0;
                var categoria = "";
                if (temp != null)
                {
                    var list = temp.Split('-');
                    id = Int32.Parse(list[0]);
                    categoria = list[1];
                }

                if (txtDetalle.Text == null || txtDetalle.Text == "") { Ratio.DetalleTipo = " "; }
                else { Ratio.DetalleTipo = txtDetalle.Text; }
                Ratio.ValorRatio = System.Math.Round(float.Parse(txtValor.Text),2);
                Ratio.TopeRatio = System.Math.Round(float.Parse(txtTope.Text),2);
                Ratio.Menores3 = chkMenores3.Checked ? 1 : 0;
                Ratio.Menores3y8 = chkMenores3y8.Checked ? 1 : 0;
                Ratio.Adolescentes = chkAdolescentes.Checked ? 1 : 0;
                Ratio.AdicionalRatio = chkAdicional.Checked ? 1 : 0;  
                Ratio.EstadoId = EstadosOperator.GetHablitadoID("Items");
                switch (ddlDependencia.SelectedValue)
                {
                    case "1":
                        Ratio.TipoRatio = "PAX";
                        break;
                    case "2":
                        Ratio.TipoRatio = "ITEM";
                        break;
                }          
                if(id > 0)
                {
                    Ratio.Id = id;
                    Ratio.ItemId = RatiosOperator.GetOneByIdentity(id).ItemId;
                    Ratio.ExperienciaBarra = RatiosOperator.GetOneByIdentity(id).ExperienciaBarra;
                    Ratio.CategoriaId = CategoriasItemOperator.GetOneByParameter("Descripcion",categoria).Id;
                    RatiosOperator.Save(Ratio);

                }
                else
                {
                    //recorro multiselect items
                    foreach(ListItem item in MultiselectItems.Items)
                    {
                        
                        if (item.Selected)
                        {            
                            var detItem = ItemsOperator.GetOneByParameter("Detalle", item.Text);
                            //recorro multiselect experiencias por cada item seleccionado
                            foreach (ListItem MulExpBar in MultiselectExperiencias.Items)
                            {
                                if (MulExpBar.Selected)
                                {
                                    //recorro multiselect categorias por cada experiencia seleccionado
                                    foreach (ListItem MulCat in MultiselectCategorias.Items)
                                    {
                                        List<ItemDetalle> categoriasItem;
                                        if (MulCat.Selected)
                                        {
                                            //si tengo itemdetalleid significa que tengo una categoria asociada al item o varias
                                            //obtengo las categorias y luego las recorro
                                            if (detItem.ItemDetalleId != null)
                                            {
                                                categoriasItem = ItemDetalleOperator.GetAllByParameter("ItemId", detItem.ItemDetalleId.Value);
                                                foreach (var detalle in categoriasItem)
                                                {
                                                    if (MulCat.Selected && Int32.Parse(MulCat.Value) == detalle.CategoriaId)
                                                    {
                                                        Ratio.Id = -1;
                                                        Ratio.ItemId = detItem.Id;
                                                        Ratio.CategoriaId = Int32.Parse(MulCat.Value);
                                                        //verifico si se selecciono un tipo de experiencia o barra y armo el codigo
                                                        if (TipoCateringOperator.TipoCateringValidation("Descripcion", MulExpBar.Text))
                                                        {
                                                            Ratio.ExperienciaBarra = "TCAT" + MulExpBar.Value;
                                                        }
                                                        else
                                                        {
                                                            Ratio.ExperienciaBarra = "BAR" + MulExpBar.Value;
                                                        }
                                                        parametros.Add(Ratio.ItemId.ToString());
                                                        parametros.Add(Ratio.ExperienciaBarra);
                                                        parametros.Add(Ratio.CategoriaId.ToString());
                                                        parametros.Add(Ratio.TipoRatio);
                                                        parametros.Add(Ratio.DetalleTipo);
                                                        if (!RatiosOperator.RatioValidation(parametros) && duplicado == 0)
                                                        {
                                                            RatiosOperator.Save(Ratio);
                                                        }
                                                        else
                                                        {
                                                            parametros[0] = item.Text;
                                                            parametros[1] = MulCat.Text;
                                                            ArmaMensaje(parametros);
                                                            ErrorDialog();
                                                            duplicado = 1;
                                                        }

                                                    }
                                                }
                                            }
                                            //CODIGO TEMPORAL PARA LOS ITEMS QUE YA TIENEN UN ITEMCATEGORIAID
                                            //BORRAR LUEGO DE QUE TODOS TENGAN ITEMDETALLEID
                                            else
                                            {
                                                Ratio.Id = -1;
                                                Ratio.ItemId = detItem.Id;
                                                Ratio.CategoriaId = detItem.CategoriaItemId;
                                                parametros.Add(Ratio.ItemId.ToString());
                                                parametros.Add(Ratio.ExperienciaBarra);
                                                parametros.Add(Ratio.CategoriaId.ToString());
                                                parametros.Add(Ratio.TipoRatio);
                                                parametros.Add(Ratio.DetalleTipo);
                                                if (RatiosOperator.RatioValidation(parametros) && duplicado == 0)
                                                {
                                                    RatiosOperator.Save(Ratio);
                                                }
                                                else
                                                {
                                                    parametros[0] = item.Text;
                                                    parametros[1] = MulCat.Text;
                                                    ArmaMensaje(parametros);
                                                    ErrorDialog();
                                                    duplicado = 1;
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if(duplicado == 0)
                {
                    Response.Redirect("~/Configuracion/AbmItems/RatiosBrowse.aspx");
                }
               
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
        protected virtual void ErrorDialog()
        {
            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ratioduplicate",
                "ShowratiosDialog();", true);
        }
        protected void ArmaMensaje(List<string> datos)
        {
            string mensaje = 
                             "Item:      " + datos[0] + "<br>" +
                             "Categoria: " + datos[1] + "<br>" +
                             "TipoRatio: " + datos[2] + "<br>" +
                             "Detalle  : " + datos[3];
            dialog.Text = mensaje;
        }

    }

}