using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Transferencias
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios administrativa = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BuscarTransferencias();
            }
        }

        private void BuscarTransferencias()
        {
            TransferenciasSearcher searcher = new TransferenciasSearcher();

            searcher.Cuit = TextBoxNroCuit.Text;
            searcher.NroTransferencia = TextBoxNroTransferencia.Text;
            searcher.RazonSocial = TextBoxRazonSocial.Text;
            searcher.FechaTransferencia = TextBoxFecha.Text;

            GridViewTransferencias.DataSource = administrativa.ListarTransferencias(searcher);
            GridViewTransferencias.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewTransferencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTransferencias.PageIndex = e.NewPageIndex;
            BuscarTransferencias();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarTransferencias();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxFecha.Text = "";
            TextBoxNroTransferencia.Text = "";
            TextBoxRazonSocial.Text = "";
            TextBoxNroCuit.Text = "";

            //this.Controls.OfType<TextBox>().ToList().ForEach(o => o.Text = "");

            BuscarTransferencias();
        }
    }
}