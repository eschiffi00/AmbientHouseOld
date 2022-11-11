using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Administracion.Comprobantes
{
    public partial class VerPago : System.Web.UI.Page
    {

        private int ComprobanteId
        {
            get
            {
                return Int32.Parse(Session["ComprobanteId"].ToString());
            }
            set
            {
                Session["ComprobanteId"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ComprobanteId = id;

                GridViewPagos.DataSource = administracion.ObtenerPagosPorComprobante(ComprobanteId);
                GridViewPagos.DataBind();
            }




        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
        }
    }
}