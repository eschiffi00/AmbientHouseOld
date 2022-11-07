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
using static System.Net.WebRequestMethods;
using NPOI.SS.Formula.Functions;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace AmbientHouse.Configuracion.AbmItems
{
    public partial class ItemsAltaMasiva2 : System.Web.UI.Page
    {
        Items seItems = new Items();
        bool rowError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubirArchivo.Width = Unit.Pixel(178);
            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            DataSet ds = UploadExcel.UploadToExcel(btnSubirArchivo);
            Session["filename"] = btnSubirArchivo.FileName;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            rowError = ValidaCampos();
        }
        protected bool ValidaCampos()
        {
            bool rowError = false;
            var insertados = 0;
            var actualizados = 0;
            var erroneos = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                TableCellCollection fila;
                fila = row.Cells;
                List<string> fields = new List<string>();
                List<string> values = new List<string>();
                fields.Add("Detalle");
                values.Add(fila[0].Text);
                if(CommonOperator.CommonValidation("Items", fields, values))
                {
                    actualizados++;
                    row.ControlStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    insertados++;
                }
                if(fila[2].Text == String.Empty)
                {
                    fila[2].Text = " ";
                }
                fields.Clear();
                values.Clear();
                fields.Add("Id");
                var arrText = fila[3].Text.Split(',');
                for(var i = 0; i < arrText.Length; i++)
                {
                    values.Add(arrText[i]);
                    if (!CommonOperator.CommonValidation("CategoriasItem", fields, values))
                    {
                        erroneos++;
                        rowError = true;
                        row.Cells[3].ControlStyle.BackColor = Color.Red;
                        row.Cells[3].ControlStyle.ForeColor = Color.White;
                    }
                }
                fields.Clear();
                values.Clear();
                fields.Add("Id");
                values.Add(fila[4].Text);
                if (!CommonOperator.CommonValidation("CentroCostos", fields, values))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[4].ControlStyle.BackColor = Color.Red;
                    row.Cells[4].ControlStyle.ForeColor = Color.White;
                }
                lblMsg.Text = "Registros a Insertar: " + insertados + "<br/>" +
                         "Registros a actualizar: " + actualizados + "<br/>" +
                          "Datos Erroneos: " + erroneos + "<br/>";
            }
            return rowError;
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!rowError)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    TableCellCollection fila;
                    fila = row.Cells;
                
                    if(row.ControlStyle.BackColor == Color.LightGreen)
                    {
                        ActualizaItem(fila);
                    }
                    else
                    {
                        InsertaItem(fila);
                    }
                

                }
                Response.Redirect("~/Configuracion/AbmItems/ItemsBrowse.aspx");
            }

        }
        private void ActualizaItem(TableCellCollection fila)
        {
            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            List<string> getFields = new List<string>();
            List<string> returns = new List<string>();
            fields.Add("Detalle");
            getFields.Add("Id");
            getFields.Add("ItemDetalleId");
            getFields.Add("NombreFantasiaId");
            values.Add(fila[0].Text);
            var itemData = CommonOperator.CommonGetString("Items", fields, getFields, values);
            seItems.Id = int.Parse(itemData[0]);
            seItems.Detalle = fila[0].Text;
            seItems.TipoItem = fila[1].Text;
            var arrText = fila[3].Text.Split(',');
            if (itemData[1] != "")
            {
                ActualizaCategorias(int.Parse(itemData[1]),arrText);
                seItems.ItemDetalleId = seItems.Id;
            }
            else
            {
                if (arrText.Count() > 0)
                {
                    seItems.ItemDetalleId = seItems.Id;
                    InsertaCategorias(seItems.Id,arrText);
                }
            }
            fields.Clear();
            getFields.Clear();
            values.Clear();
            NombreFantasia nombreFantasia = new NombreFantasia();
            nombreFantasia.Descripcion = fila[2].Text;
            seItems.NombreFantasiaId = int.Parse(itemData[2]); 
            NombreFantasiaOperator.Save(nombreFantasia);
            seItems.CuentaId = int.Parse(fila[4].Text);
            seItems.CategoriaItemId = 76;
            seItems.Costo = System.Math.Round(float.Parse(fila[5].Text), 2);
            seItems.Margen = System.Math.Round(float.Parse(fila[6].Text), 2);
            seItems.Precio = System.Math.Round(float.Parse(fila[7].Text), 2);
            seItems.DepositoId = 99;
            seItems.EstadoId = EstadosOperator.GetHablitadoID("Items");
            ItemsOperator.Save(seItems);

        }
        private void ActualizaCategorias(int ItemDetalleId, string[] categoriasArr)
        {
            
            var categoriasData = ItemDetalleOperator.GetAllByParameter("ItemId",ItemDetalleId);
            string[] arrExistentes = new string[categoriasData.Count];
            var i = 0;
            foreach(var categoria in categoriasData)
            {
                if (!categoriasArr.ToList().Contains(categoria.CategoriaId.ToString()))
                {
                    ItemDetalleOperator.Delete(categoria.Id);

                }
                else 
                {
                    arrExistentes[i] = categoria.CategoriaId.ToString();
                    i++;
                }
            }
            categoriasData = ItemDetalleOperator.GetAllByParameter("ItemId", ItemDetalleId);
            foreach (var categoria in categoriasArr)
            {
                if (!arrExistentes.Contains(categoria))
                {
                    ItemDetalle nuevaCategoria = new ItemDetalle();
                    nuevaCategoria.Id = -1;
                    nuevaCategoria.ItemId = ItemDetalleId;
                    nuevaCategoria.CategoriaId = int.Parse(categoria);
                    nuevaCategoria.EstadoId = 36;
                    ItemDetalleOperator.Save(nuevaCategoria);

                }
            }
        }
        private void InsertaCategorias(int ItemDetalleId, string[] categoriasArr)
        {
            foreach (var categoria in categoriasArr)
            {
                    ItemDetalle nuevaCategoria = new ItemDetalle();
                    nuevaCategoria.ItemId = ItemDetalleId;
                    nuevaCategoria.CategoriaId = int.Parse(categoria);
                    nuevaCategoria.EstadoId = 36;
                    ItemDetalleOperator.Save(nuevaCategoria);
            }

        }

        private void InsertaItem(TableCellCollection fila)
        {
            var newItemId = -1;
            seItems.Id = -1;
            seItems.ItemDetalleId = 99;
            seItems.Detalle = fila[0].Text;
            seItems.TipoItem = fila[1].Text;
            NombreFantasia nombreFantasia = new NombreFantasia();
            nombreFantasia.Descripcion = fila[2].Text;
            seItems.NombreFantasiaId = NombreFantasiaOperator.Save(nombreFantasia).Id;
            seItems.CategoriaItemId = 76;
            seItems.CuentaId = int.Parse(fila[4].Text);
            seItems.EstadoId = EstadosOperator.GetHablitadoID("Items");
            seItems.Costo = System.Math.Round(float.Parse(fila[5].Text), 2);
            seItems.Margen = System.Math.Round(float.Parse(fila[6].Text), 2);
            seItems.Precio = System.Math.Round(float.Parse(fila[7].Text), 2);
            seItems.DepositoId = 99;
            newItemId = ItemsOperator.Save(seItems).Id;
            seItems.ItemDetalleId = newItemId;
            seItems.Id = newItemId;
            ItemsOperator.Save(seItems);
            var arrText = fila[3].Text.Split(',');
            ItemDetalle itemDetalle = new ItemDetalle();
            foreach (var categoria in arrText)
            {
                itemDetalle.CategoriaId = int.Parse(categoria);
                ItemDetalleOperator.Save(itemDetalle);
            }
        }

    }
}