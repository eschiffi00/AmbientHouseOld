using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Stock
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }

        protected void ButtonAdministrarProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Productos/Index.aspx");
        }

        protected void ButtonAdministrarRequerimientos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Requerimientos/Index.aspx");
        }
    }
}