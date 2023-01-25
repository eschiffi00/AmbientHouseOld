using DbEntidades.Entities;
using DbEntidades.Operators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AmbientHouse.Configuracion.AbmItems
{
    public partial class ComandasEdit : System.Web.UI.Page
    {
        List<ComandaDetalle> seComanda = new List<ComandaDetalle>();
        DataTable tablagrid = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["tablagrid"] = tablagrid;
                SessionClearAll();
                var id = 0;
                if (Request["Id"] != "" && Request["Id"] != null)
                {
                    id = int.Parse(Request["Id"]);
                }
                seComanda = ComandaDetalleOperator.GetAllByParameter("ComandaId", (id > 0 ? id : 0).ToString());
                seComanda.Reverse();
                CargaRepBebidas(seComanda);
                CargaRepBocados(seComanda);
                CargaRepIslas(seComanda);

                SessionSaveAll();
            }
            SessionLoadAll();
        }

        #region Session
        protected void SessionClearAll()
        {
            Session["seComanda"] = null;
        }
        protected void SessionLoadAll()
        {
            seComanda = (List<ComandaDetalle>)Session["seComanda"];
        }
        protected void SessionSaveAll()
        {
            Session["seComanda"] = seComanda;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session

        protected void CargaRepBebidas(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            //foreach (var item in seComanda)
            for (int i = seComanda.Count - 1; i >= 0; i--)
            {
                var item = seComanda[i];
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var categoriaItem = CategoriasItemOperator.GetOneByIdentity(detalleItem.CategoriaItemId);
                if(categoriaItem.CategoriaItemPadreId == 1)
                {
                    var cantidad = item.Cantidad.ToString();
                    matriz.Add((detalleItem.Detalle,cantidad));
                    seComanda.Remove(item);
                }
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repBebidas.DataSource = dinamicList;
            repBebidas.DataBind();

        }
        protected void CargaRepBocados(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            //foreach (var item in seComanda)
            for (int i = seComanda.Count - 1; i >= 0; i--)
            {
                var item = seComanda[i];
                if(item.Clave.Substring(0, 3) == "PRO")
                {
                    var proId = item.Clave.Substring(3);
                    var titulo = ProductosCateringOperator.GetOneByIdentity(int.Parse(proId)).Titulo;
                    if(titulo == "Bocados")
                    {
                        int itemId = item.ItemId.Value;
                        var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                        var cantidad = item.Cantidad.ToString();
                        matriz.Add((detalleItem.Detalle, cantidad));
                        seComanda.Remove(item);
                    }
                }  
            }

            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repBocados.DataSource = dinamicList;
            repBocados.DataBind();
        }
        protected void CargaRepIslas(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            List<string> islas = new List<string>();
            //foreach (var item in seComanda)
            for (int i = seComanda.Count - 1; i >= 0; i--)
            {
                var item = seComanda[i];
                if (item.Clave.Substring(0, 3) == "PRO")
                {
                    var proId = item.Clave.Substring(3);
                    var prod = ProductosCateringOperator.GetOneByIdentity(int.Parse(proId));
                    if (prod.Titulo == "Islas" && !islas.Contains(prod.Descripcion))
                    {
                        islas.Add(prod.Descripcion);
                        var cantidad = item.Cantidad.ToString();
                        matriz.Add((prod.Descripcion, cantidad));
                    }
                    if(prod.Titulo == "Islas")
                    {
                        seComanda.Remove(item);
                    }
                }
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repIslas.DataSource = dinamicList;
            repIslas.DataBind();
        }
        protected void CargaRepPrincipales(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            List<string> islas = new List<string>();
            foreach (var item in seComanda)
            {
                if (item.Clave.Substring(0, 3) == "PRO")
                {
                    var proId = item.Clave.Substring(3);
                    var prod = ProductosCateringOperator.GetOneByIdentity(int.Parse(proId));
                    if (prod.Titulo == "Islas" && !islas.Contains(prod.Descripcion))
                    {
                        islas.Add(prod.Descripcion);
                        var cantidad = item.Cantidad.ToString();
                        matriz.Add((prod.Descripcion, cantidad));
                    }
                    if (prod.Titulo == "Islas")
                    {
                        seComanda.Remove(item);
                    }
                }
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repIslas.DataSource = dinamicList;
            repIslas.DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var duplicado = 0;
            List<string> parametros = new List<string>();
            Ratios Ratio = new Ratios();
            try
            {
                var temp = Request["Id"];
                var id = 0;
                if (temp != null)
                {
                    id = int.Parse(Request["Id"]);
                }

                
                if (duplicado == 0)
                {
                    Response.Redirect("~/Configuracion/AbmItems/RatiosBrowse.aspx");
                }

            }
            catch (Exception ex)
            {
                //AlertaRoja(ex.Message);
            }
        }

        protected void repBebidas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repBebidas = (Repeater)sender;
                if (repBebidas.DataSource == null || repBebidas.Items.Count == 0)
                {
                    repBebidas.Visible = false;
                }
            }
        }

        //protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlDependencia.SelectedValue == "1")
        //    {
        //        txtDetalle.Enabled = false;
        //    }
        //    else
        //    {
        //        txtDetalle.Enabled = true;
        //    }
        //}
        //protected virtual void ErrorDialog()
        //{

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ratioduplicate",
        //        "ShowratiosDialog();", true);
        //}
        //protected void ArmaMensaje(List<string> datos)
        //{
        //    string mensaje =
        //                     "Item:      " + datos[0] + "<br>" +
        //                     "Experiencia: " + datos[1] + "<br>" +
        //                     "TipoRatio: " + datos[3] + "<br>" +
        //                     "Detalle  : " + datos[4];
        //    dialog.Text = mensaje;
        //}

    }

    internal class DinamicData
    {
        public string Nombre { get; set; }
        public string Cantidad { get; set; }

    }
}