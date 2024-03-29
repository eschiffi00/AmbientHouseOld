﻿using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Administracion.Recibos
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BuscarRecibos();


            }
        }

        private void BuscarRecibos()
        {
            RecibosSearcher searcher = new RecibosSearcher();

            GridViewRecibos.DataSource = administracion.BuscarRecibos(searcher);
            GridViewRecibos.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Recibos/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Index.aspx");
        }
    }
}