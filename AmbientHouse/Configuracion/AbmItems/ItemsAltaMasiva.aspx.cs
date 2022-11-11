using DbEntidades.Entities;
using DbEntidades.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.AbmItems
{
    public partial class ItemsAltaMasiva : System.Web.UI.Page
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
                if (fila[0].Text != "&nbsp;")
                {
                    fields.Add("Detalle");
                    values.Add(fila[0].Text);
                    if (CommonOperator.CommonValidation("Items", fields, values))
                    {
                        actualizados++;
                        row.ControlStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        insertados++;
                    }
                    if (fila[2].Text == String.Empty)
                    {
                        fila[2].Text = " ";
                    }
                    fields.Clear();
                    values.Clear();
                    fields.Add("Id");
                    values.Add(fila[3].Text);
                    if (!CommonOperator.CommonValidation("CategoriasItem", fields, values))
                    {
                        erroneos++;
                        rowError = true;
                        row.Cells[3].ControlStyle.BackColor = Color.Red;
                        row.Cells[3].ControlStyle.ForeColor = Color.White;
                    }
                    var list = fila[4].Text.Split(',').ToList();
                    foreach(var value in list)
                    {
                        fields.Clear();
                        values.Clear();
                        fields.Add("Id");
                        values.Add(value);
                        if (!CommonOperator.CommonValidation("Items", fields, values))
                        {
                            erroneos++;
                            rowError = true;
                            row.Cells[4].ControlStyle.BackColor = Color.Red;
                            row.Cells[4].ControlStyle.ForeColor = Color.White;
                        }
                    }
                    fields.Clear();
                    values.Clear();
                    fields.Add("Id");
                    values.Add(fila[5].Text);
                    if (!CommonOperator.CommonValidation("CentroCostos", fields, values))
                    {
                        erroneos++;
                        rowError = true;
                        row.Cells[5].ControlStyle.BackColor = Color.Red;
                        row.Cells[5].ControlStyle.ForeColor = Color.White;
                    }
                    lblMsg.Text = "Registros a Insertar: " + insertados + "<br/>" +
                             "Registros a actualizar: " + actualizados + "<br/>" +
                              "Datos Erroneos: " + erroneos + "<br/>";
                }
                
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
                    
                    if (row.ControlStyle.BackColor == Color.LightGreen)
                    {
                        ActualizaItem(fila);
                    }
                    else
                    {
                        if (fila[0].Text != "&nbsp;")
                        {
                            InsertaItem(fila);
                        }
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
            fields.Add("Detalle");
            values.Add(fila[2].Text);
            if (CommonOperator.CommonValidation("Items", fields, values))
            {
                fields.Clear();
                getFields.Clear();
                values.Clear();
                fields.Add("Detalle");
                getFields.Add("Id");
                getFields.Add("ItemDetalleId");
                getFields.Add("NombreFantasiaId");
                values.Add(fila[2].Text);
            }
            else 
            {
                fields.Clear();
                getFields.Clear();
                values.Clear();
                fields.Add("Detalle");
                getFields.Add("Id");
                getFields.Add("NombreFantasiaId");
                values.Add(fila[0].Text);
            }
            
            var itemData = CommonOperator.CommonGetString("Items", fields, getFields, values);
            seItems.Id = int.Parse(itemData[0]);
            seItems.Detalle = fila[0].Text;
            seItems.TipoItem = fila[1].Text;
            
            
            fields.Clear();
            getFields.Clear();
            values.Clear();
            NombreFantasia nombreFantasia = new NombreFantasia();
            nombreFantasia.Descripcion = fila[2].Text;
            if (itemData[1] != "" && int.Parse(itemData[1]) != -1)
            {
                seItems.NombreFantasiaId = int.Parse(itemData[1]);
            }
            else
            {
                seItems.NombreFantasiaId = -1;
            }
            NombreFantasiaOperator.Save(nombreFantasia);
            if(fila[4].Text != "0")
            {
                var list = fila[4].Text.Split(',').ToList();
                var DetalleItems = ItemDetalleOperator.GetAllByParameter("ItemId", seItems.Id);
                foreach (var item in DetalleItems)
                {
                    ItemDetalleOperator.Delete(item.Id);
                }
                foreach (var item in list)
                {
                    ItemDetalle itemDetalle = new ItemDetalle();
                    itemDetalle.ItemId = seItems.Id;
                    itemDetalle.DetalleItemId = int.Parse(item);
                    itemDetalle.EstadoId = 1;
                    ItemDetalleOperator.Save(itemDetalle);
                }
                seItems.ItemDetalleId = seItems.Id;
            }
            else { seItems.ItemDetalleId = 0; }
            
            
            seItems.CategoriaItemId = int.Parse(fila[3].Text);
            seItems.CuentaId = int.Parse(fila[5].Text);
            seItems.Costo = System.Math.Round(float.Parse(fila[6].Text), 2);
            seItems.Margen = System.Math.Round(float.Parse(fila[7].Text), 2);
            seItems.Precio = System.Math.Round(float.Parse(fila[8].Text), 2);
            seItems.DepositoId = 99;
            seItems.EstadoId = EstadosOperator.GetHablitadoID("Items");
            ItemsOperator.Save(seItems);

        }


        private void InsertaItem(TableCellCollection fila)
        {
            seItems.Id = -1;
            seItems.ItemDetalleId = 99;
            seItems.Detalle = fila[0].Text;
            seItems.TipoItem = fila[1].Text;
            NombreFantasia nombreFantasia = new NombreFantasia();
            nombreFantasia.Descripcion = fila[2].Text;
            seItems.NombreFantasiaId = NombreFantasiaOperator.Save(nombreFantasia).Id;
            seItems.CategoriaItemId = int.Parse(fila[3].Text);
            seItems.ItemDetalleId = 0;

            seItems.CuentaId = int.Parse(fila[5].Text);
            seItems.EstadoId = EstadosOperator.GetHablitadoID("Items");
            seItems.Costo = System.Math.Round(float.Parse(fila[6].Text), 2);
            seItems.Margen = System.Math.Round(float.Parse(fila[7].Text), 2);
            seItems.Precio = System.Math.Round(float.Parse(fila[8].Text), 2);
            seItems.DepositoId = 99;
            seItems.Id = ItemsOperator.Save(seItems).Id;
            if (fila[4].Text != "0")
            {
                var list = fila[4].Text.Split(',').ToList();
                var DetalleItems = ItemDetalleOperator.GetAllByParameter("ItemId", seItems.Id);
                foreach (var item in DetalleItems)
                {
                    ItemDetalleOperator.Delete(item.Id);
                }
                foreach (var item in list)
                {
                    ItemDetalle itemDetalle = new ItemDetalle();
                    itemDetalle.ItemId = seItems.Id;
                    itemDetalle.DetalleItemId = int.Parse(item);
                    itemDetalle.EstadoId = 1;
                    ItemDetalleOperator.Save(itemDetalle);
                }
            }
        }

    }
}