﻿using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Comisiones
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarComisiones();

            }
        }

        private void BuscarComisiones()
        {
            GridViewComisiones.DataSource = servicios.ObtenerComisiones();
            GridViewComisiones.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Comisiones/Editar.aspx");
        }

        protected void GridViewComisiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewComisiones.PageIndex = e.NewPageIndex;
            BuscarComisiones();

        }
    }
}