using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AmbientHouse.Administracion.Clientes
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        ClientesServicios clientes = new ClientesServicios();

        Comun cmd = new Comun();
          
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarClientes();
            }
        }

        private void BuscarClientes()
        {

            ClientesSearcher searcher = new ClientesSearcher();

            searcher.RazonSocial = TextBoxDescripcionBuscador.Text;
            searcher.CUIT = TextBoxCUITDNIBuscador.Text;

            List<DomainAmbientHouse.Entidades.ClientesBis> list = clientes.BuscarClientesPorApellidoRazonSocial(searcher);

            GridViewClientes.DataSource = list.ToList();
            GridViewClientes.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Clientes/Editar.aspx");
        }

        protected void GridViewClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewClientes.PageIndex = e.NewPageIndex;
            BuscarClientes();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }
    }
}