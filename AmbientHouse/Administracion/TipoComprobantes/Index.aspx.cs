﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Administracion.TipoComprobantes
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarTipoComprobantes();
            }
        }

        private void BuscarTipoComprobantes()
        {
            GridViewTipoComprobantes.DataSource = servicios.ObtenerTipoComprobantes();
            GridViewTipoComprobantes.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/TipoComprobantes/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Index.aspx");
        }

        protected void GridViewTipoComprobantes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTipoComprobantes.PageIndex = e.NewPageIndex;
            BuscarTipoComprobantes();

        }
    }
}