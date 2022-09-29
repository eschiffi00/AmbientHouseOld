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
using AmbientHouse.Herramientas.UploadExcel;

namespace WebApplication.app.ItemsNS
{
    public partial class ItemsAltaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FileUploadToServer.Width = Unit.Pixel(178);
            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            DataSet ds = UploadExcel.UploadToExcel(FileUploadToServer);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        
    }
}