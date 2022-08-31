using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Globalization;

namespace AmbientHouse.Organizador
{
    public partial class ReporteEventos : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();
        Comun cmd = new Comun();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Searcher();

                CargarLista();

            }

        }

        private void CargarLista()
        {
            DropDownListUnidadNegocio.DataSource = administrativas.ObtenerUNReporte();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();
        }

        private void Searcher()
        {
            int nroPresupuesto = 0;
            if (cmd.IsNumeric(TextBoxDescripcionBuscador.Text))
                nroPresupuesto = Int32.Parse(TextBoxDescripcionBuscador.Text);


            int unidadNegocioId = 0;
            if (DropDownListUnidadNegocio.SelectedItem.Value != "null")
                unidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);

            Buscar(nroPresupuesto, TextBoxNroFechaDesde.Text, TextBoxFechaHasta.Text, unidadNegocioId);
        }

        private void Buscar(int nropresupuesto, string fechaeventodesde, string fechaeventohasta, int unidadnegocioId)
        {

            List<ObtenerEventosPresupuestosProveedores> list = eventos.BuscarEventosConfirmadosProveedoresExternos(nropresupuesto, fechaeventodesde, fechaeventohasta, unidadnegocioId);

            GridViewReporte.DataSource = list.ToList();
            GridViewReporte.DataBind();
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Organizador/CalendarioOrganizador.aspx");
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Searcher();
        }

    }
}