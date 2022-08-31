using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.PlanesDePagos
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.PlanesDePago PlanesDePagoSeleccionado
        {
            get
            {
                return Session["PlanesDePagoSeleccionado"] as DomainAmbientHouse.Entidades.PlanesDePago;
            }
            set
            {
                Session["PlanesDePagoSeleccionado"] = value;
            }
        }

        private int PlanDePagoId
        {
            get
            {
                return Int32.Parse(Session["PlanDePagoId"].ToString());
            }
            set
            {
                Session["PlanDePagoId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { InicializarPagina(); }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                PlanDePagoId = id;
            }


            if (id == 0)
                NuevoPlanDePago();
            else
                EditarPlanDePago(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarPlanDePago(int id)
        {

            DomainAmbientHouse.Entidades.PlanesDePago planesDePago = new DomainAmbientHouse.Entidades.PlanesDePago();

            planesDePago = servicios.BuscarPlanDePago(id);

            PlanesDePagoSeleccionado = planesDePago;


            TextBoxDescripcion.Text = planesDePago.Descripcion;
            TextBoxIndice.Text = planesDePago.Indice.ToString();

        }

        private void NuevoPlanDePago()
        {
            PlanesDePagoSeleccionado = new DomainAmbientHouse.Entidades.PlanesDePago();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.PlanesDePago planesDePago = PlanesDePagoSeleccionado;

            planesDePago.Descripcion = TextBoxDescripcion.Text;

            double Indice = 0;

            if (TextBoxIndice.Text != "")
            { Indice = double.Parse(TextBoxIndice.Text); }
            planesDePago.Indice =  Indice;

            servicios.NuevaPlanesDePago(planesDePago);
            Response.Redirect("~/Configuracion/PlanesDePagos/Index.aspx");
        }
        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/PlanesDePagos/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }
    }
}