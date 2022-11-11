using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Proveedores
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarProveedores();
            }
        }


        private void BuscarProveedores()
        {
            ProveedoresSearcher searcher = new ProveedoresSearcher();

            searcher.RazonSocial = TextBoxRazonSocialBuscador.Text;
            searcher.Cuit = TextBoxCuitBuscador.Text;

            List<DomainAmbientHouse.Entidades.Proveedores> List = servicios.BuscarProveedores(searcher).ToList();

            GridViewProveedores.DataSource = List.ToList();
            GridViewProveedores.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Proveedores/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProveedores.PageIndex = e.NewPageIndex;
            BuscarProveedores();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedores();
        }




    }
}