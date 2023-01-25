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
    public partial class ComandasBrowse : System.Web.UI.Page
    {
        List<Comandas> comandaListado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //InicializaExpBarras();
                //CargaExperienciasBarras();
                grdComandasBind();
                SessionSaveAll();
            }
            SessionLoadAll();
        }

        #region Session
        protected void SessionClearAll()
        {
            Session["comandaListado"] = null;
        }
        protected void SessionLoadAll()
        {
            comandaListado = (List<Comandas>)Session["comandaListado"];
        }
        protected void SessionSaveAll()
        {
            Session["comandaListado"] = comandaListado;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session
        //public void CargaExperienciasBarras()
        //{
        //    List<TipoCateringComun> tipocatering = TipoCateringOperator.GetAllForCombo();
        //    foreach (var item in tipocatering)
        //    {
        //        ListItem experiencia = new ListItem();
        //        experiencia.Text = item.Descripcion;
        //        experiencia.Value = item.Id.ToString();
        //        MultiselectExperiencias.Items.Add(experiencia);
        //    }
        //    List<TiposBarrasComun> tipobarras = TiposBarrasOperator.GetAllForCombo();
        //    foreach (var item in tipobarras)
        //    {
        //        ListItem barra = new ListItem();
        //        barra.Text = item.Descripcion;
        //        barra.Value = item.Id.ToString();
        //        MultiselectExperiencias.Items.Add(barra);
        //    }
        //    MultiselectExperiencias.DataBind();
        //}
        
        protected void grdComandasBind()
        {

            comandaListado = ComandasOperator.GetAll().ToList();
            grdComandas.DataSource = comandaListado;
            grdComandas.DataBind();
            foreach (GridViewRow fila in grdComandas.Rows)
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
        //protected void btnFiltrar_Click(object sender, EventArgs e)
        //{
        //    List<string> fields = new List<string>();
        //    List<string> values = new List<string>();
        //    List<Comandas> ratiosfiltrados = new List<Comandas>();
        //    if(MultiselectExperiencias.SelectedItem != null)
        //    {
        //        foreach (ListItem experiencia in MultiselectExperiencias.Items)
        //        {
        //            var valor = experiencia.Value;
        //            var codigoExperiencia = "";
        //            if (experiencia.Selected)
        //            {
        //                var tipocatering = TipoCateringOperator.GetOneByIdentity(int.Parse(valor));

        //                if (tipocatering != null && tipocatering.Descripcion == experiencia.Text)
        //                {
        //                    codigoExperiencia = "TCAT" + tipocatering.Id;
        //                }
        //                else
        //                {
        //                    var tipobarra = TiposBarrasOperator.GetOneByIdentity(int.Parse(valor));
        //                    if (tipobarra != null && tipobarra.Descripcion == experiencia.Text)
        //                    {
        //                        codigoExperiencia = "BAR" + tipobarra.Id;
        //                    }
        //                }
        //                ratiosfiltrados.AddRange(comandaListado.Where(x => x.TipoExperiencia == codigoExperiencia).ToList());
        //            }
        //        }
        //    }
        //    grdComandas.DataSource = ratiosfiltrados;
        //    grdComandas.DataBind();
        //}

        protected void btnNuevoRatio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/AbmItems/RatiosEdit.aspx");
        }
        protected void grdComandas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "ID");
            int id = Convert.ToInt32(row.Cells[colindex].Text);
            //colindex = CCLib.GetColumnIndexByHeaderText((GridView)sender, "Categoria Detalle");
            //string categoria = row.Cells[colindex].Text;

            if (e.CommandName == "CommandNameDelete")
            {
                RatiosOperator.Delete(id);
                grdComandasBind();
            }
            if (e.CommandName == "CommandNameEdit")
            {

                Response.Redirect("~/Operacion/ComandasEdit.aspx?Id=" + id);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grdComandas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //protected void InicializaExpBarras()
        //{
        //    foreach (ListItem Item in MultiselectExperiencias.Items)
        //    {
        //        Item.Selected = false;
        //        Item.Enabled = true;
        //    }
        //}
    }
}