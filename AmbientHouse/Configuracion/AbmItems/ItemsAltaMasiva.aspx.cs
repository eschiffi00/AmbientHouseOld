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
using AmbientHouse.Herramientas.UploadExcel;

namespace WebApplication.app.ItemsNS
{
    public partial class ItemsAltaMasiva : System.Web.UI.Page
    {
        Items seItems = new Items();
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
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var err = 0;
            foreach (GridViewRow fila in GridView1.Rows)
            {
                TableCellCollection fila2;
                fila2 = fila.Cells;
                var newItemId = -1;
                seItems.Id = -1;
                seItems.ItemDetalleId = 99;
                seItems.Detalle = fila2[0].Text;
                seItems.TipoItem = fila2[1].Text;
                NombreFantasia nombreFantasia = new NombreFantasia();
                nombreFantasia.Descripcion = fila2[2].Text;
                var arrText = fila2[3].Text.Split(',');
                foreach (var text in arrText)
                {
                    if(CategoriasItemOperator.GetOneByParameter("Descripcion", text) == null){
                        err = 1;
                    }
                }
                seItems.CategoriaItemId = 76;
                var cuentaTxt = fila2[4].Text;
                if (CuentasOperator.GetOneByParameter("Nombre", fila2[4].Text).Id > 0) {
                    seItems.CuentaId = CuentasOperator.GetOneByParameter("Nombre", fila2[4].Text).Id;
                }
                else
                {
                    err = 1;
                }
                seItems.EstadoId = EstadosOperator.GetHablitadoID();
                seItems.Costo = float.Parse(fila2[5].Text);
                seItems.Margen = float.Parse(fila2[6].Text);
                seItems.Precio = float.Parse(fila2[7].Text);
                seItems.DepositoId = 99;
                if(err == 0) {
                    if (nombreFantasia.Descripcion != null && nombreFantasia.Descripcion != "")
                    {
                        seItems.NombreFantasiaId = NombreFantasiaOperator.Save(nombreFantasia).Id;
                    }
                    else
                    {
                        seItems.NombreFantasiaId = 0;
                    }
                    newItemId = ItemsOperator.Save(seItems).Id;
                    seItems.ItemDetalleId = newItemId;
                    seItems.Id = newItemId;
                    ItemsOperator.Save(seItems);
                    ItemDetalle detalle = new ItemDetalle();
                    foreach (var text in arrText)
                    {
                        detalle.Id = -1;
                        detalle.ItemId = newItemId;
                        detalle.CategoriaId = CategoriasItemOperator.GetOneByParameter("Descripcion", text).Id;
                        ItemDetalleOperator.Save(detalle);
                    }
                }
                else { 
                    fila.ControlStyle.BackColor = Color.Red;
                    fila.ControlStyle.ForeColor = Color.White;
                }
            }
            string filename = (string)Session["filename"];
            UploadExcel.DeleteUploads(filename);
            if (err == 0)
            {
                Response.Redirect("~/Configuracion/AbmItems/ItemsAltaMasiva.aspx");
            }
        }

        


    }
}