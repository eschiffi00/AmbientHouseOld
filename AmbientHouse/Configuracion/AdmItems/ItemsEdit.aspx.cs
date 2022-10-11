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
                int id = 0;
                id = Int32.Parse(Request["Id"] != null ? Request["Id"] : "0");

                CargaCategorias();
                CargaCuentas();
                //CargaUnidades();
                //CargaItems();
                if (id != 0)
                {
                    int uid = Convert.ToInt32(s);
                    seItems = ItemsOperator.GetOneByIdentity(uid);
                    txtNombreFantasia.Text = seItems.NombreFantasiaId > 0 ? NombreFantasiaOperator.GetOneByIdentity(seItems.NombreFantasiaId).Descripcion: "";
                    switch (seItems.TipoItem)
                    {
                        case "PRO": ddlTipos.SelectedValue = "1";
                            break;
                        case "VEN": ddlTipos.SelectedValue = "2";
                            break;
                        case "OPE": ddlTipos.SelectedValue = "3";
                            break;
                    }

                    //obtengo todas las categorias y utilizo descripcion y id
                    var categorias = ItemDetalleOperator.GetAllByParameter("ItemId", id);
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
                    }else
                    {
                        MultiselectCategorias.SelectedValue = CategoriasOperator.GetOneByIdentity((int)seItems.CategoriaItemId).Id.ToString();
                    }
                    if (seItems.CuentaId > 0)
                    {
                        ddlCuenta.SelectedValue = CuentasOperator.GetOneByIdentity((int)seItems.CuentaId).Id.ToString();
                    }
                    //if (seItems.DepositoId > 0)
                    //{
                        //ddlUnidad.SelectedValue = INVENTARIO_UnidadesOperator.GetOneByIdentity((INVENTARIO_ProductoOperator.GetOneByIdentity((int)seItems.DepositoId).Id)).Descripcion;
                    //}
                    txtDescripcion.Text = seItems.Detalle;
                    //busco el stock para el StockID
                    //INVENTARIO_Producto stockCant = new INVENTARIO_Producto();
                    //stockCant = INVENTARIO_ProductoOperator.GetOneByIdentity(seItems.DepositoId);
                    //txtCantidad.Text = stockCant.Cantidad.ToString();

                    txtMargen.Text = seItems.Margen.ToString();
                    txtCosto.Text = seItems.Costo.ToString();
                    txtPrecio.Text = seItems.Precio.ToString();
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
                seItems.EstadoId = EstadosOperator.GetHablitadoID("Items");
                NombreFantasia nombreFantasia = new NombreFantasia();
                nombreFantasia.Descripcion = txtNombreFantasia.Text;
                seItems.NombreFantasiaId = NombreFantasiaOperator.Save(nombreFantasia).Id;
                switch (ddlTipos.SelectedValue)
                {
                    case "1":
                        seItems.TipoItem = "PRO";
                        break;
                    case "2":
                        seItems.TipoItem = "VEN";
                        break;
                    case "3":   
                        seItems.TipoItem = "OPE";
                        break;
                }
                var newItemId = ItemsOperator.Save(seItems).Id;
                seItems.ItemDetalleId = newItemId;
                seItems.Id = newItemId;
                ItemsOperator.Save(seItems);

                ItemDetalle detalle = new ItemDetalle();
                foreach (ListItem item in MultiselectCategorias.Items)
                {
                    if (item.Selected)
                    {
                        detalle.Id = -1;
                        detalle.ItemId = newItemId;
                        detalle.CategoriaId = Int32.Parse(item.Value);
                        ItemDetalleOperator.Save(detalle);
                    }
                }

                Response.Redirect("~/Configuracion/AdmItems/ItemsBrowse.aspx");
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
        
    }

}