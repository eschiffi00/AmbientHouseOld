﻿using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Parametros
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarParametros();

            }
        }

        private void BuscarParametros()
        {
            GridViewParametros.DataSource = servicios.ObtenerParametros();
            GridViewParametros.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Parametros/Editar.aspx");
        }

        protected void GridViewParametros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewParametros.PageIndex = e.NewPageIndex;
            BuscarParametros();
        }
    }
}