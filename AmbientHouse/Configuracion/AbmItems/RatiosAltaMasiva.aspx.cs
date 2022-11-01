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
    public partial class RatiosAltaMasiva : System.Web.UI.Page
    {
        Ratios seRatios = new Ratios();
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
            
            var insertados = 0;
            var actualizados = 0;
            var erroneos = 0;
            var flagActualiza = false;
            //recorro el grid generado por el excel
            foreach (GridViewRow fila in GridView1.Rows)
            {
                var err = false;
                flagActualiza = false;
                TableCellCollection fila2;
                fila2 = fila.Cells;
                List<string> parametros = new List<string>();
                //valido que el nombre del item y la categoria sean correctos
                var itemid =  ItemsOperator.GetOneByParameter("Detalle", Server.HtmlDecode(fila2[0].Text)).Id;
                if (itemid < 0) 
                {
                    err = true;
                }
                else
                {
                    seRatios.ItemId = itemid;
                    parametros.Add(itemid.ToString());
                }
                seRatios.ExperienciaBarra = fila2[1].Text;
                parametros.Add(fila2[1].Text);
                var categoriaid = CategoriasItemOperator.GetOneByParameter("Descripcion",fila2[2].Text).Id;
                if(categoriaid < 0)
                {
                    err = true;
                }
                else
                {
                    seRatios.CategoriaId = categoriaid;
                    parametros.Add(categoriaid.ToString());
                }
                seRatios.TipoRatio = fila2[3].Text;
                parametros.Add(fila2[3].Text);
                seRatios.DetalleTipo = fila2[4].Text;
                parametros.Add(fila2[4].Text);
                //obtengo el id del ratio utilizando itemid,categoriaid,tiporatio,detalletipo
                //para verificar si es una actualizacion o alta
                if (!err) seRatios.Id = RatiosOperator.GetRatioId(parametros);

                if (seRatios.Id > 0)
                {
                    flagActualiza = true;
                }
                else
                {
                    seRatios.Id = -1;
                }
                seRatios.ValorRatio = System.Math.Round(float.Parse(fila2[5].Text),2);
                seRatios.TopeRatio = System.Math.Round(float.Parse(fila2[6].Text),2);
                seRatios.Menores3 = int.Parse(fila2[7].Text);
                seRatios.Menores3y8 = int.Parse(fila2[8].Text);
                seRatios.Adolescentes = int.Parse(fila2[9].Text);
                seRatios.AdicionalRatio = int.Parse(fila2[10].Text);
                seRatios.EstadoId = EstadosOperator.GetHablitadoID("Ratios");
                if (!err)
                {
                    RatiosOperator.Save(seRatios);
                    if (flagActualiza)
                    {
                        actualizados++;
                    }
                    else
                    {
                        insertados++;
                    }
                }else 
                {
                    erroneos++;
                    fila.ControlStyle.BackColor = Color.Red;
                    fila.ControlStyle.ForeColor = Color.White;
                }
            }
            string filename = (string)Session["filename"];
            UploadExcel.DeleteUploads(filename);
            lblMsg.Text = "Insertados: " + insertados + "<br/>" +
                          "Actualizados: " + actualizados + "<br/>" +
                           "Erroneos: " + erroneos + "<br/>";
            if (erroneos == 0)
            {

                Response.Redirect("~/Configuracion/AbmItems/RatiosBrowse.aspx");
            }
        }

        


    }
}