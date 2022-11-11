using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.PedidosCotizacion
{
    public partial class Index : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BuscarPedidos();
            }
        }

        //private void BuscarPedidos()
        //{
        //    int EnviadoCompras = Int32.Parse(ConfigurationManager.AppSettings["PedidoCotizacionEnviadoCompras"].ToString());

        //    GridViewProductos.DataSource = eventos.ListarPedidosCotizacionPorUsuarios(null, EnviadoCompras);
        //    GridViewProductos.DataBind();

        //    UpdatePanelGrillaProductos.Update();
        //}

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PedidosCotizacion/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio/Principal.aspx");
        }
    }
}