﻿using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Rubros
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }

        }

        private void CargarGrilla()
        {
            GridViewRubros.DataSource = servicios.ObtenerRubros();
            GridViewRubros.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Rubros/Editar.aspx");
        }

        protected void GridViewRubros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRubros.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }
    }
}