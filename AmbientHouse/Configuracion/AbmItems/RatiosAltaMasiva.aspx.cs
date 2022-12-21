using DbEntidades.Entities;
using DbEntidades.Operators;
using NPOI.Util;
using System;
using System.Collections;
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
                //ITEM ID
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
                //EXPERIENCIA/BARRA
                //valido si es tipocatering o tipobarra y consulto que sea un id correcto
                fields.Add("Id");
                
                if (fila[1].Text.Substring(0, 4) == "TCAT")
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
                //TIPO RATIO

                if(fila[2].Text != "PAX" && fila[2].Text != "ITEM")
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[2].ControlStyle.BackColor = Color.Red;
                    row.Cells[2].ControlStyle.ForeColor = Color.White;
                }
                //BASE RATIO
                //valida si es numerico
                var numerodbl = 0.0;
                var numeroint = 0;
                if (!double.TryParse(fila[3].Text, out numerodbl))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[3].ControlStyle.BackColor = Color.Red;
                    row.Cells[3].ControlStyle.ForeColor = Color.White;
                }
                //VALOR RATIO
                //valida si es numerico
                numerodbl = 0.0;
                if (!double.TryParse(fila[4].Text, out numerodbl))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[4].ControlStyle.BackColor = Color.Red;
                    row.Cells[4].ControlStyle.ForeColor = Color.White;
                }
                //TOPE RATIO
                //valida si es numerico
                numerodbl = 0.0;
                if (!double.TryParse(fila[4].Text, out numerodbl))
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[5].ControlStyle.BackColor = Color.Red;
                    row.Cells[5].ControlStyle.ForeColor = Color.White;
                }
                fields.Clear();
                values.Clear();
                //ISLA (BOOL)
                if (int.Parse(fila[6].Text) > 1 || int.Parse(fila[6].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[6].ControlStyle.BackColor = Color.Red;
                    row.Cells[6].ControlStyle.ForeColor = Color.White;
                }
                //ADULTOS (BOOL)
                //
                if (int.Parse(fila[7].Text) > 1 || int.Parse(fila[7].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[7].ControlStyle.BackColor = Color.Red;
                    row.Cells[7].ControlStyle.ForeColor = Color.White;
                }
                //MENORES3 (BOOL)
                if (int.Parse(fila[8].Text) > 1 || int.Parse(fila[8].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[8].ControlStyle.BackColor = Color.Red;
                    row.Cells[8].ControlStyle.ForeColor = Color.White;
                }
                //MENORES3Y8 (BOOL)
                if (int.Parse(fila[9].Text) > 1 || int.Parse(fila[9].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[9].ControlStyle.BackColor = Color.Red;
                    row.Cells[9].ControlStyle.ForeColor = Color.White;
                }
                //ADOLESCENTES (BOOL)
                if (int.Parse(fila[10].Text) > 1 || int.Parse(fila[10].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[10].ControlStyle.BackColor = Color.Red;
                    row.Cells[10].ControlStyle.ForeColor = Color.White;
                }
                //FIJO RATIO (BOOL)
                if (int.Parse(fila[11].Text) > 1 || int.Parse(fila[11].Text) < 0)
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[11].ControlStyle.BackColor = Color.Red;
                    row.Cells[11].ControlStyle.ForeColor = Color.White;
                }
                //ITEM RATIO ID
                //VALIDO NUMERICO Y LUEGO VALIDO QUE EXISTA EL ITEM ID
                fields.Clear();
                values.Clear();
                numerodbl = 0.0;
                
                if (int.TryParse(fila[12].Text, out numeroint))
                {
                    if (numeroint > 0)
                    {
                        fields.Add("Id");
                        values.Add(fila[12].Text);
                        if (!CommonOperator.CommonValidation("Items", fields, values))
                        {
                            erroneos++;
                            rowError = true;
                            row.Cells[12].ControlStyle.BackColor = Color.Red;
                            row.Cells[12].ControlStyle.ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[12].ControlStyle.BackColor = Color.Red;
                    row.Cells[12].ControlStyle.ForeColor = Color.White;
                }
                //PRODUCTO RATIO ID
                //VALIDO NUMERICO Y LUEGO VALIDO QUE EXISTA EL PRODUCTO ID
                fields.Clear();
                values.Clear();
                if (int.TryParse(fila[13].Text, out numeroint))
                {
                    if (numeroint > 0)
                    {
                        fields.Add("Id");
                        values.Add(fila[13].Text);
                        if (!CommonOperator.CommonValidation("ProductosCateringItems", fields, values))
                        {
                            erroneos++;
                            rowError = true;
                            row.Cells[13].ControlStyle.BackColor = Color.Red;
                            row.Cells[13].ControlStyle.ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[13].ControlStyle.BackColor = Color.Red;
                    row.Cells[13].ControlStyle.ForeColor = Color.White;
                }
                //CATEGORIA RATIO ID
                //VALIDO NUMERICO Y LUEGO VALIDO QUE EXISTA EL CATEGORIA ID
                fields.Clear();
                values.Clear();
                if (int.TryParse(fila[14].Text, out numeroint))
                {
                    if(numeroint > 0)
                    {
                        fields.Add("Id");
                        values.Add(fila[14].Text);
                        if (!CommonOperator.CommonValidation("CategoriasItem", fields, values))
                        {
                            erroneos++;
                            rowError = true;
                            row.Cells[14].ControlStyle.BackColor = Color.Red;
                            row.Cells[14].ControlStyle.ForeColor = Color.White;
                        }
                    } 
                }
                else
                {
                    erroneos++;
                    rowError = true;
                    row.Cells[14].ControlStyle.BackColor = Color.Red;
                    row.Cells[14].ControlStyle.ForeColor = Color.White;
                }
                fields.Clear();
                values.Clear();
                //valido si existe la cabecera del ratio
                fields.Add("ItemId");
                fields.Add("ExperienciaBarra");
                fields.Add("TipoRatio");
                fields.Add("BaseRatio");
                fields.Add("TopeRatio");
                fields.Add("Isla");
                fields.Add("Adultos");
                fields.Add("Menores3");
                fields.Add("Menores3y8");
                fields.Add("Adolescentes");
                fields.Add("FijoRatio");

                for(var i =0; i < 14; i++)
                    //se filtran los campos no utilizables
                    {if(i!= 4 && i!= 12 && i != 13 && i != 14 && i<14)values.Add(fila[i].Text);}   
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
            fields.Clear();
            values.Clear();
            getFields.Clear();
            fields.Add("ItemId");
            fields.Add("ExperienciaBarra");
            fields.Add("TipoRatio");
            fields.Add("BaseRatio");
            fields.Add("TopeRatio");
            fields.Add("Isla");
            fields.Add("Adultos");
            fields.Add("Menores3");
            fields.Add("Menores3y8");
            fields.Add("Adolescentes");
            fields.Add("FijoRatio");
            getFields.Add("Id");
            for (var i = 0; i < 14; i++)
            { if (i != 4 && i != 12 && i != 13 && i != 14 && i < 14) values.Add(fila[i].Text); }
            var ratioData = CommonOperator.CommonGetString("Ratios", fields, getFields, values);
            seRatios.Id = int.Parse(ratioData[0]);
            seRatios.ItemId = int.Parse(fila[0].Text);
            seRatios.ExperienciaBarra = fila[1].Text;
            seRatios.TipoRatio = fila[2].Text;
            seRatios.BaseRatio = float.Parse(fila[3].Text);
            seRatios.ValorRatio = System.Math.Round(float.Parse(fila[4].Text), 2); 
            seRatios.TopeRatio = float.Parse(fila[5].Text);
            //seRatios.Isla = int.Parse(fila[6].Text);
            //seRatios.Adultos = int.Parse(fila[7].Text);
            //seRatios.Menores3 = int.Parse(fila[8].Text);
            //seRatios.Menores3y8 = int.Parse(fila[9].Text);
            //seRatios.Adolescentes = int.Parse(fila[10].Text);
            //seRatios.FijoRatio = int.Parse(fila[11].Text);
            seRatios.Isla = fila[6].Text == "1"? true : false;
            seRatios.Adultos = fila[7].Text == "1" ? true : false;
            seRatios.Menores3 = fila[8].Text == "1" ? true : false;
            seRatios.Menores3y8 = fila[9].Text == "1" ? true : false;
            seRatios.Adolescentes = fila[10].Text == "1" ? true : false;
            seRatios.FijoRatio = fila[11].Text == "1" ? true : false;
            seRatios.ItemRatioId = int.Parse(fila[12].Text);
            seRatios.ProductoRatioId = int.Parse(fila[13].Text);
            seRatios.CategoriaRatioId = int.Parse(fila[14].Text);
            seRatios.EstadoId = EstadosOperator.GetHablitadoID("Ratios");


            RatiosOperator.Save(seRatios);

        }

        private void InsertaItem(TableCellCollection fila)
        {
            seRatios.Id = -1;
            seRatios.ItemId = int.Parse(fila[0].Text);
            seRatios.ExperienciaBarra = fila[1].Text;
            seRatios.TipoRatio = fila[2].Text;
            seRatios.BaseRatio = float.Parse(fila[3].Text);
            seRatios.ValorRatio = float.Parse(fila[4].Text);
            seRatios.TopeRatio = float.Parse(fila[5].Text);
            seRatios.Isla = fila[6].Text == "1" ? true : false;
            seRatios.Adultos = fila[7].Text == "1" ? true : false;
            seRatios.Menores3 = fila[8].Text == "1" ? true : false;
            seRatios.Menores3y8 = fila[9].Text == "1" ? true : false;
            seRatios.Adolescentes = fila[10].Text == "1" ? true : false;
            seRatios.FijoRatio = fila[11].Text == "1" ? true : false;
            seRatios.ItemRatioId = int.Parse(fila[12].Text);
            seRatios.ProductoRatioId = int.Parse(fila[13].Text);
            seRatios.CategoriaRatioId = int.Parse(fila[14].Text);
            seRatios.EstadoId = EstadosOperator.GetHablitadoID("Ratios");
            RatiosOperator.Save(seRatios);
        }


    }
}