﻿using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Stock.Requerimientos
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            GridViewRequerimientos.DataSource = administracion.ListarRequerimientos();
            GridViewRequerimientos.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Requerimientos/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Default.aspx");
        }

        protected void GridViewRequerimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRequerimientos.PageIndex = e.NewPageIndex;
            Buscar();
        }
    }
}