using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio.Experiencias
{
    public partial class Index : System.Web.UI.Page
    {
        private AdministrativasServicios servicios = new AdministrativasServicios();

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

        private int TipoCatering
        {
            get
            {
                return Int32.Parse(Session["TipoCateringId"].ToString());
            }
            set
            {
                Session["TipoCateringId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BuscarTipoCatering();
            }
        }

        private void BuscarTipoCatering()
        {
            GridViewTpoCatering.DataSource = servicios.ObtenerTipoCatering();
            GridViewTpoCatering.DataBind();
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            int PerfilOrganizador = int.Parse(ConfigurationManager.AppSettings["Organizador"].ToString());
            int PerfilOperacion = int.Parse(ConfigurationManager.AppSettings["Operacion"].ToString());

            if (PerfilId == PerfilOrganizador)
            {
                Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
            }
            else if (PerfilId == PerfilOperacion)
            {
                Response.Redirect("~/Operacion/CalendarioOperacion.aspx");
            }
            else
                Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewTpoCatering_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Experiencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTpoCatering.Rows[index];


                TipoCatering = int.Parse(row.Cells[0].Text);


                Response.Redirect("~/Inicio/Experiencias/Reporte.aspx");
            }
        }
    }
}