﻿using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.TipoTecnica
{
    public partial class Index : System.Web.UI.Page
    {


        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarTipoServicios();

            }
        }

        private void BuscarTipoServicios()
        {
            GridViewTipoTecnicas.DataSource = servicios.ObtenerTipoTecnica();
            GridViewTipoTecnicas.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoTecnica/Editar.aspx");
        }

        protected void GridViewTipoTecnicas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTipoTecnicas.PageIndex = e.NewPageIndex;
            BuscarTipoServicios();
        }
    }
}