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
    public partial class ItemsEdit : System.Web.UI.Page
    {
        Items seItems = null;
        DataTable tablagrid = new DataTable();
        List<int> listaitem = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tablagrid.Columns.Add(new DataColumn("Item", typeof(string)));
                Session["tablagrid"] = tablagrid;
                Session["listaitem"] = listaitem;
                SessionClearAll();
                string s;
                object o = Page.RouteData.Values["id"];
                if (o != null) s = Page.RouteData.Values["id"].ToString();
                else s = Request.QueryString["id"];
                CargaCategorias();
                CargaCuentas();
                //CargaUnidades();
                //CargaItems();
                if (s != null && s != string.Empty)
                {
                    int uid = Convert.ToInt32(s);
                    seItems = ItemsOperator.GetOneByIdentity(uid);
                    //obtengo todas las categorias y utilizo descripcion y id
                    if (seItems.CategoriaItemId > 0)
                    {
                        MultiselectCategorias.SelectedValue = CategoriasOperator.GetOneByIdentity((int)seItems.CategoriaItemId).Id.ToString();
                    }
                    if(seItems.CuentaId > 0)
                    {
                        ddlCuenta.SelectedValue = CuentasOperator.GetOneByIdentity((int)seItems.CuentaId).Id.ToString();
                    }
                    if (seItems.DepositoId > 0)
                    {
                        //ddlUnidad.SelectedValue = INVENTARIO_UnidadesOperator.GetOneByIdentity((INVENTARIO_ProductoOperator.GetOneByIdentity((int)seItems.DepositoId).Id)).Descripcion;
                    }
                        txtDescripcion.Text = seItems.Detalle;
                    //busco el stock para el StockID
                    //INVENTARIO_Producto stockCant = new INVENTARIO_Producto();
                    //stockCant = INVENTARIO_ProductoOperator.GetOneByIdentity(seItems.DepositoId);
                    //txtCantidad.Text = stockCant.Cantidad.ToString();
                    txtMargen.Text = seItems.Margen.ToString();
                    txtCosto.Text = seItems.Costo.ToString();
                    txtPrecio.Text = seItems.Precio.ToString();
                    btnSubmit.Text = "Grabar";
                    ddlEstado.SelectedValue = EstadosOperator.GetOneByIdentity(seItems.EstadoId).Id.ToString();
                }
                else
                {
                    ddlCuenta.Items.Insert(0, new ListItem("<Selecciona Cuenta Contable>", "0"));
                    h4Titulo.InnerText = "Creación de nuevo Item";
                    seItems = new Items();
                }
                SetMaximosTextBoxes();
                SessionSaveAll();
            }
            SessionLoadAll();
        }

        public void CargaCategorias()
        {
            DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Value"), new DataColumn("Text"), new DataColumn("Categoria") });
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
        //public void CargaItems()
        //{
        //    List<ItemsCombo> ItemsList = ItemsOperator.GetAllForCombo();
        //    ddlItems.DataSource = ItemsList;
        //    ddlItems.DataTextField = "Detalle";
        //    ddlItems.DataValueField = "Id";
        //    ddlItems.DataBind();
        //}
        public void CargaCuentas()
        {
            List<Cuentas> cuentasList = CuentasOperator.GetAll();
            ddlCuenta.DataSource = cuentasList;
            ddlCuenta.DataTextField = "Nombre";
            ddlCuenta.DataValueField = "ID";
            ddlCuenta.DataBind();
        }
        //public void CargaUnidades()
        //{
        //    List<INVENTARIO_Unidades> unidadesList = INVENTARIO_UnidadesOperator.GetAll();
        //    ddlUnidad.DataSource = unidadesList;
        //    ddlUnidad.DataTextField = "Descripcion";
        //    ddlUnidad.DataValueField = "ID";
        //    ddlUnidad.DataBind();
        //}

        protected void SetMaximosTextBoxes()
        {
            txtDescripcion.MaxLength = ItemsOperator.MaxLength.Detalle;
        }

        #region Session
        protected void SessionClearAll()
        {
            Session["seItems"] = null;
        }
        protected void SessionLoadAll()
        {
            seItems = (Items)Session["seItems"];
        }
        protected void SessionSaveAll()
        {
            Session["seItems"] = seItems;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                
                seItems.ItemDetalleId = 99;
                seItems.Detalle = txtDescripcion.Text;
                seItems.CuentaId = Int32.Parse(ddlCuenta.Text);
                seItems.EstadoId = Int32.Parse(ddlEstado.Text);
                seItems.CategoriaItemId = 76;
                seItems.Costo = float.Parse(txtCosto.Text);
                seItems.Margen = float.Parse(txtMargen.Text);
                seItems.Precio = float.Parse(txtPrecio.Text);
                seItems.DepositoId = 99;
                seItems.EstadoId = EstadosOperator.GetHablitadoID();
                
                var newItemId = ItemsOperator.Save(seItems).Id;
                seItems.ItemDetalleId = newItemId;
                seItems.Id = newItemId;
                ItemsOperator.Save(seItems);

                ItemDetalle detalle = new ItemDetalle();
                foreach (ListItem item in MultiselectCategorias.Items)
                {
                    if (item.Selected)
                    {
                        detalle.ItemId = newItemId;
                        detalle.CategoriaId = item.Value;
                        ItemDetalleOperator.Save(detalle);
                    }
                }

                Response.Redirect("~/Configuracion/AmbItems/ItemsBrowse.aspx");
                //ItemsOperator.Save(seItems);
            }
            catch (Exception ex)
            {
                //AlertaRoja(ex.Message);
            }
        }
        public int ActualizaStock(INVENTARIO_Producto Item)
        {
            Item.RubroId = 1;
            Item.Codigo = "";
            Item.CodigoBarra = "";
            Item.Descripcion = "prueba";
            Item.CantidadNominal = 1.0m;
            Item.Cantidad = 0; //Decimal.Parse(txtCantidad.Text);
            Item.Costo = 1.0m;
            Item.UnidadId = 1;
            Item.UnidadPresentacionId = 1;
            Item.UnidadMedidaConversionId = 1;
            Item.TipoMovimientoId = 1;
            Item.CentroCostoId = 1;
            Item.UpdateDate = null;

            if (Item.Id > -1)
            {
                Item.UpdateDate = DateTime.Now;
            }
            else
            {
                Item.CreateDate = DateTime.Now;
            }
            Item.Delete = 1;
            Item.DeleteDate = null;
            Item = INVENTARIO_ProductoOperator.Save(Item);
            return Item.Id;
        }
        //protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    tablagrid = (DataTable)Session["tablagrid"];
        //    int id = Int32.Parse(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlItems")).Text);

        //    var idborrar = ItemDetalleOperator.GetOneRelative(id, seItems.Id);
        //    if (idborrar > 0)
        //    {
        //        ItemDetalleOperator.Delete(id);

        //    }
        //    tablagrid.Rows.RemoveAt(e.RowIndex);
        //    //foreach (DataRow fila in tablagrid.Rows)
        //    //{
        //    //    if (fila["Id"].ToString() == id.ToString())
        //    //    {
        //    //        fila.Delete();
        //    //    }
        //    //}
        //    tablagrid.AcceptChanges();
        //    GridView1.DataSource = tablagrid;
        //    GridView1.DataBind();
            
        //}
            
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DropDownList mydrop = (DropDownList)e.Row.FindControl("ddlItems");
        //        mydrop.DataSource = ItemsOperator.GetAllForCombo().OrderBy(x => x.Detalle).ToList(); ;
        //        mydrop.DataTextField = "Detalle";
        //        mydrop.DataValueField = "Id";
        //        mydrop.DataBind();
        //    }
        //}
        
    }

}