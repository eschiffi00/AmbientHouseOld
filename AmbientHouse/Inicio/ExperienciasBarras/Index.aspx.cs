using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Inicio.ExperienciasBarras
{
    public partial class Index : System.Web.UI.Page
    {
        private int TipoBarraId
        {
            get
            {
                return Int32.Parse(Session["TipoBarraId"].ToString());
            }
            set
            {
                Session["TipoBarraId"] = value;
            }
        }

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

        private AdministrativasServicios servicios = new AdministrativasServicios();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { BuscarTipoBarras(); }
        }

        private void BuscarTipoBarras()
        {
            GridViewTiposBarras.DataSource = servicios.ObtenerTipoBarras();
            GridViewTiposBarras.DataBind();
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
                Response.Redirect("~/Inicio/Index.aspx");
        }
         
        public string EvaluarSegmento(Object id)
        {

            int key = (int)id;

            var segmentos = servicios.BuscarSermento(key);


            return segmentos.Descripcion;

        }

        public string EvaluarDuracion(Object id)
        {

            int key = (int)id;

            var duracion = servicios.BuscarDuracion(key);


            return duracion.Descripcion;

        }

        protected void GridViewTiposBarras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Experiencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTiposBarras.Rows[index];


                TipoBarraId = int.Parse(row.Cells[0].Text);


                Response.Redirect("~/Inicio/ExperienciasBarras/Reporte.aspx");
            }
        }

        protected void GridViewTiposBarras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTiposBarras.PageIndex = e.NewPageIndex;
            BuscarTipoBarras();
        }

    }
}