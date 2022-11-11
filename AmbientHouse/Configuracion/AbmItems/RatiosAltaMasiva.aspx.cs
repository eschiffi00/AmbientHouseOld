using DbEntidades.Entities;
using DbEntidades.Operators;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.AbmItems
{
    public partial class RatiosAltaMasiva : System.Web.UI.Page
    {
        Ratios seRatios = new Ratios();
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
                //valida Id del item
                fields.Add("Id");
                values.Add(fila[0].Text);
                if (!CommonOperator.CommonValidation("Items", fields, values))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[0].ControlStyle.BackColor = Color.Red;
                    row.Cells[0].ControlStyle.ForeColor = Color.White;
                }
                fields.Clear();
                values.Clear();
                //valido si es tipocatering o tipobarra y consulto que sea un id correcto
                fields.Add("Id");
                
                if (fila[1].Text.Substring(0, 3) == "TCA")
                {
                    values.Add(fila[1].Text.Substring(4));
                    if (!CommonOperator.CommonValidation("TipoCatering", fields, values))
                        {rowError = true;}
                }
                if (fila[1].Text.Substring(0, 3) == "BAR")
                {
                    values.Add(fila[1].Text.Substring(3));
                    if (!CommonOperator.CommonValidation("TiposBarras", fields, values))
                        {rowError = true;}
                }
                if (rowError)
                {
                    erroneos++;
                    row.Cells[1].ControlStyle.BackColor = Color.Red;
                    row.Cells[1].ControlStyle.ForeColor = Color.White;
                }
                fields.Clear();
                values.Clear();
                //valido categoria
                fields.Add("Id");
                values.Add(fila[2].Text);
                if (!CommonOperator.CommonValidation("CategoriasItem", fields, values))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[2].ControlStyle.BackColor = Color.Red;
                    row.Cells[2].ControlStyle.ForeColor = Color.White;
                }

                fields.Clear();
                values.Clear();
                //valido tipo de ratio
                if(fila[3].Text != "PAX" && fila[3].Text != "ITEM")
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[3].ControlStyle.BackColor = Color.Red;
                    row.Cells[3].ControlStyle.ForeColor = Color.White;
                }
                //valido centro de costos
                fields.Add("Id");
                values.Add(fila[4].Text);
                if (Regex.IsMatch(fila[4].Text, @"^[A-Z]+$"))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[4].ControlStyle.BackColor = Color.Red;
                    row.Cells[4].ControlStyle.ForeColor = Color.White;
                }
                //valido formato de datos adicionales
                if (Regex.IsMatch(fila[5].Text, @"^[A-Z]+$"))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[5].ControlStyle.BackColor = Color.Red;
                    row.Cells[5].ControlStyle.ForeColor = Color.White;
                }
                if (Regex.IsMatch(fila[6].Text, @"^[A-Z]+$"))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[6].ControlStyle.BackColor = Color.Red;
                    row.Cells[6].ControlStyle.ForeColor = Color.White;
                }
                fields.Clear();
                values.Clear();
                //valido si tiene Id de isla y si es correcto
                if(fila[7].Text != "&nbsp;")
                {

                
                    fields.Add("Id");
                    fields.Add("Titulo");
                    values.Add(fila[7].Text);
                    values.Add("Islas");
                    if (!CommonOperator.CommonValidation("ProductosCatering", fields, values))
                    {
                        erroneos++;
                        rowError = true;
                        row.Cells[7].ControlStyle.BackColor = Color.Red;
                        row.Cells[7].ControlStyle.ForeColor = Color.White;
                    }
                }
                //validaciones booleanos
                //
                if (int.Parse(fila[8].Text) > 1 || int.Parse(fila[8].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[8].ControlStyle.BackColor = Color.Red;
                    row.Cells[8].ControlStyle.ForeColor = Color.White;
                }
                if (int.Parse(fila[9].Text) > 1 || int.Parse(fila[9].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[9].ControlStyle.BackColor = Color.Red;
                    row.Cells[9].ControlStyle.ForeColor = Color.White;
                }
                if (int.Parse(fila[10].Text) > 1 || int.Parse(fila[10].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[10].ControlStyle.BackColor = Color.Red;
                    row.Cells[10].ControlStyle.ForeColor = Color.White;
                }
                if (int.Parse(fila[11].Text) > 1 || int.Parse(fila[11].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[11].ControlStyle.BackColor = Color.Red;
                    row.Cells[11].ControlStyle.ForeColor = Color.White;
                }
                if (int.Parse(fila[12].Text) > 1 || int.Parse(fila[12].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[12].ControlStyle.BackColor = Color.Red;
                    row.Cells[12].ControlStyle.ForeColor = Color.White;
                }
                fields.Clear();
                values.Clear();
                //valido si existe la cabecera del ratio
                fields.Add("ItemId");
                fields.Add("ExperienciaBarra");
                fields.Add("TipoRatio");
                fields.Add("DetalleTipo");
                for(var i =0; i < 4; i++)
                    {values.Add(fila[i].Text);}   
                if(CommonOperator.CommonValidation("Ratios",fields, values))
                {
                    actualizados++;
                    row.ControlStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    insertados++;
                }

                //VERIFICO SI ACTUALIZA O INSERTA

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

                    if (row.ControlStyle.BackColor == Color.LightGreen)
                    {
                        ActualizaItem(fila);
                    }
                    else
                    {
                        InsertaItem(fila);
                    }


                }
                Response.Redirect("~/Configuracion/AbmItems/RatiosBrowse.aspx");
            }

            
        }

        private void ActualizaItem(TableCellCollection fila)
        {
            //RECUPERO EL ID INGRESANDO CON LA CABECERA DEL RATIO
            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            List<string> getFields = new List<string>();
            fields.Add("ItemId");
            fields.Add("ExperienciaBarra");
            fields.Add("TipoRatio");
            fields.Add("DetalleTipo");
            getFields.Add("Id");
            for (var i = 0; i < 4; i++)
            { values.Add(fila[i].Text); }
            var ratioData = CommonOperator.CommonGetString("Ratios", fields, getFields, values);
            seRatios.Id = int.Parse(ratioData[0]);
            seRatios.ItemId = int.Parse(fila[0].Text);
            seRatios.ExperienciaBarra = fila[1].Text;
            seRatios.CategoriaId = int.Parse(fila[2].Text);
            seRatios.TipoRatio = fila[3].Text;
            seRatios.DetalleTipo = fila[4].Text;
            seRatios.ValorRatio = float.Parse(fila[5].Text);
            seRatios.TopeRatio = float.Parse(fila[6].Text);
            seRatios.IslaId = int.Parse(fila[7].Text);
            seRatios.Menores3 = int.Parse(fila[8].Text);
            seRatios.Menores3y8 = int.Parse(fila[9].Text);
            seRatios.Adolescentes = int.Parse(fila[10].Text);
            seRatios.AdicionalRatio = int.Parse(fila[11].Text);
            if(int.Parse(fila[12].Text) == 0)
            {
                seRatios.EstadoId = EstadosOperator.GetDeshabilitadoID("Ratios");
            }
            else
            {
                seRatios.EstadoId = EstadosOperator.GetHablitadoID("Ratios");
            }
            
            RatiosOperator.Save(seRatios);

        }

        private void InsertaItem(TableCellCollection fila)
        {
            seRatios.Id = -1;
            seRatios.ItemId = int.Parse(fila[0].Text);
            seRatios.ExperienciaBarra = fila[1].Text;
            seRatios.CategoriaId = int.Parse(fila[2].Text);
            seRatios.TipoRatio = fila[3].Text;
            seRatios.DetalleTipo = fila[4].Text;
            seRatios.ValorRatio = float.Parse(fila[5].Text);
            seRatios.TopeRatio = float.Parse(fila[6].Text);
            seRatios.IslaId = int.Parse(fila[7].Text);
            seRatios.Menores3 = int.Parse(fila[8].Text);
            seRatios.Menores3y8 = int.Parse(fila[9].Text);
            seRatios.Adolescentes = int.Parse(fila[10].Text);
            seRatios.AdicionalRatio = int.Parse(fila[11].Text);
            seRatios.EstadoId = EstadosOperator.GetHablitadoID("Ratios");
            RatiosOperator.Save(seRatios);
        }


    }
}