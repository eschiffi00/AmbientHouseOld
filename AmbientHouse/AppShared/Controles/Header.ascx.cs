using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.App_Shared.Controles
{
    public partial class Header : System.Web.UI.UserControl
    {
        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonLogo_Click(object sender, ImageClickEventArgs e)
        {
            int PerfilCoordinadorVentas = int.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilAdministracion = int.Parse(ConfigurationManager.AppSettings["Administracion"].ToString());
            int PerfilGerencia = int.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());
            int PerfilStock = int.Parse(ConfigurationManager.AppSettings["Stock"].ToString());
            int PerfilStockCarga = int.Parse(ConfigurationManager.AppSettings["StockCarga"].ToString());
            int PerfilCoordinadorOrganizacion = int.Parse(ConfigurationManager.AppSettings["CoordinadorOrganizacion"].ToString());


            if (PerfilId == PerfilCoordinadorVentas || PerfilId == PerfilEjecutivo)
            {
                Response.Redirect("~/Inicio/Principal.aspx");
            }
            else if (PerfilId == PerfilAdministracion)
            {
                Response.Redirect("~/Home/Index.aspx");
            }
            else if (PerfilId == PerfilGerencia)
            {
                Response.Redirect("~/Home/Index.aspx");

            }
            else if (PerfilId == PerfilOrganizador || PerfilId == PerfilCoordinadorOrganizacion)
            {
                Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
            }
            else if (PerfilId == PerfilStock)
            {
                Response.Redirect("~/Stock/Existencias/Index.aspx");
            }
            else if (PerfilId == PerfilStockCarga)
            {
                Response.Redirect("~/Stock/Existencias/Index.aspx");
            }
            else if (PerfilId == PerfilOperacion)
            {
                Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
            }

        }

   


    }
}