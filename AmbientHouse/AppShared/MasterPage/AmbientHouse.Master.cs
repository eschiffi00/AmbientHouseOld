using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse
{
    public partial class AmbientHouse : System.Web.UI.MasterPage
    {
        DomainAmbientHouse.Servicios.Comun cmd = new DomainAmbientHouse.Servicios.Comun();

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
            if (!this.IsPostBack)
            {

                int areaVentas = int.Parse(ConfigurationManager.AppSettings["DeptoVentas"].ToString());
                int areaGerencia = int.Parse(ConfigurationManager.AppSettings["DeptoGerencia"].ToString());
                int areaAdministracion = int.Parse(ConfigurationManager.AppSettings["DeptoAdministracion"].ToString());



            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            int PerfilCoordinadorVentas = int.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
            int PerfilAdministracion = int.Parse(ConfigurationManager.AppSettings["Administracion"].ToString());
            int PerfilGerencia = int.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());
            int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());
            int PerfilStock = int.Parse(ConfigurationManager.AppSettings["Stock"].ToString());
            int PerfilStockCarga = int.Parse(ConfigurationManager.AppSettings["StockCarga"].ToString());
            int PerfilGestor = int.Parse(ConfigurationManager.AppSettings["Gestor"].ToString());


            if (PerfilId == PerfilCoordinadorVentas 
                || PerfilId == PerfilEjecutivo
                || PerfilId == PerfilGestor)
            {
                Response.Redirect("~/Inicio/Principal.aspx");
            }
            else if (PerfilId == PerfilAdministracion)
            {
                Response.Redirect("~/Administracion/Default.aspx");
            }
            else if (PerfilId == PerfilGerencia)
            {
                Response.Redirect("~/Inicio/Principal.aspx");
            }
            else if (PerfilId == PerfilOrganizador)
            {
                Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
            }
            else if (PerfilId == PerfilStock)
            {
                Response.Redirect("~/Stock/Default.aspx");
            }
            else if (PerfilId == PerfilStockCarga)
            {
                Response.Redirect("~/Stock/Ingresos.aspx");
            }
            else if (PerfilId == PerfilOperacion)
            {
                Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
            }

        }
    }
}