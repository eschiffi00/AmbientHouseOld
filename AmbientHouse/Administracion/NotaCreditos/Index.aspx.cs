using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Administracion.NotaCreditos
{
    public partial class Index : System.Web.UI.Page
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
            }


            if (id > 0)
                ListarNotasdeCredito(id);
        }

        private void ListarNotasdeCredito(int comprobanteId)
        {
            GridViewNotaCredito.DataSource = administracion.ListarNotasdeCredito(comprobanteId);
            GridViewNotaCredito.DataBind();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/NotaCreditos/Editar.aspx");
        }
    }
}