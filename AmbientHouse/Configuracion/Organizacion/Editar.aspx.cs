using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.Organizacion
{
    public partial class Editar : System.Web.UI.Page
    {
        private int OIId
        {
            get
            {
                return Int32.Parse(Session["OIId"].ToString());
            }
            set
            {
                Session["OIId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.OrganizacionItems OrganizacionItemSeleccionado
        {
            get
            {
                return Session["OrganizacionItemSeleccionado"] as DomainAmbientHouse.Entidades.OrganizacionItems;
            }
            set
            {
                Session["OrganizacionItemSeleccionado"] = value;
            }
        }

        AdministrativasServicios administrativa = new AdministrativasServicios();

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

                OIId = id;
            }


            if (id == 0)
                NuevaOI();
            else
                EditarOI(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarOI(int id)
        {

            DomainAmbientHouse.Entidades.OrganizacionItems oi = new DomainAmbientHouse.Entidades.OrganizacionItems();

            oi = administrativa.BuscarItemsOrganizacion(id);

            OrganizacionItemSeleccionado = oi;


            TextBoxDescripcion.Text = oi.Descripcion;

            if (oi.RequiereCantidad == "S")
                CheckBoxRequiereCantidad.Checked = true;
            else
                CheckBoxRequiereCantidad.Checked = false;

        }

        private void NuevaOI()
        {
            OrganizacionItemSeleccionado = new DomainAmbientHouse.Entidades.OrganizacionItems();
        }

        private void GrabarOI()
        {


            DomainAmbientHouse.Entidades.OrganizacionItems oi = OrganizacionItemSeleccionado;

            oi.Descripcion = TextBoxDescripcion.Text;

            if (CheckBoxRequiereCantidad.Checked)
                oi.RequiereCantidad = "S";
            else
                oi.RequiereCantidad = "N";


            administrativa.NuevoItemOrganizacion(oi);
            Response.Redirect("~/Configuracion/Organizacion/Index.aspx");
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Organizacion/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarOI();
        }
    }
}