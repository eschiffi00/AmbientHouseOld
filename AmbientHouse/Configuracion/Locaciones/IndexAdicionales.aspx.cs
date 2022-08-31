using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.Locaciones
{
    public partial class IndexAdicionales : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new  AdministrativasServicios();

        private int LocacionId
        {
            get
            {
                return Int32.Parse(Session["LocacionId"].ToString());
            }
            set
            {
                Session["LocacionId"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
              
            }
        }

        private void InicializarPagina()
        {
            int Id = 0;

            if (Request["Id"] != null)
            {
                Id = Int32.Parse(Request["Id"].ToString());

                LocacionId = Id;
            }

            //if (LocacionId > 0)
            //{
            //    LabelLocacion.Text = servicios.BuscarLocaciones(LocacionId).Descripcion;

            //    GridViewAdicionalesSalon.DataSource = servicios.ObtenerAdicionalesPorSalon(LocacionId);
            //    GridViewAdicionalesSalon.DataBind();
            //}
        }

        protected void ButtonAgregarLocacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/AgregarAdicionales.aspx?LocacionId&" + LocacionId);
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/Index.aspx");
        }
    }
}