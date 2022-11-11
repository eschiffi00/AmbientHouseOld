using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Logistica
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();

        private DomainAmbientHouse.Entidades.CostoLogistica CostoLogisticaSeleccionado
        {
            get
            {
                return Session["CostoLogisticaSeleccionado"] as DomainAmbientHouse.Entidades.CostoLogistica;
            }
            set
            {
                Session["CostoLogisticaSeleccionado"] = value;
            }
        }

        private int CostoLogisticaId
        {
            get
            {
                return Int32.Parse(Session["CostoLogisticaId"].ToString());
            }
            set
            {
                Session["CostoLogisticaId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarListas();
                InicializarPagina();



            }

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CostoLogisticaId = id;
            }


            if (id == 0)
                NuevoCostoLogistica();
            else
                EditarCostoLogistica(id);

            SetFocus(TextBoxPrecio);
        }

        private void EditarCostoLogistica(int id)
        {

            DomainAmbientHouse.Entidades.CostoLogistica costoLogistica = new DomainAmbientHouse.Entidades.CostoLogistica();

            costoLogistica = servicios.BuscarCostoLogitica(id);

            CostoLogisticaSeleccionado = costoLogistica;


            TextBoxPrecio.Text = costoLogistica.Valor.ToString();
            TextBoxCosto.Text = costoLogistica.Costo.ToString();


            DropDownListLocalidad.SelectedValue = costoLogistica.Localidad.ToString();
            DropDownListCantidadInvitados.SelectedValue = costoLogistica.CantidadInvitados.ToString();
            DropDownListTipoLogistica.SelectedValue = costoLogistica.ConceptoId.ToString();

            if (costoLogistica.TipoEventoId != null)
                DropDownListTipoEvento.SelectedValue = costoLogistica.TipoEventoId.ToString();


        }

        private void NuevoCostoLogistica()
        {
            CostoLogisticaSeleccionado = new DomainAmbientHouse.Entidades.CostoLogistica();
        }

        private void CargarListas()
        {
            DropDownListTipoLogistica.DataSource = servicios.ObtenerTipoLogistica();
            DropDownListTipoLogistica.DataTextField = "Concepto";
            DropDownListTipoLogistica.DataValueField = "Id";
            DropDownListTipoLogistica.DataBind();



            DropDownListLocalidad.DataSource = servicios.ObtenerLocalidades();
            DropDownListLocalidad.DataTextField = "Descripcion";
            DropDownListLocalidad.DataValueField = "Id";
            DropDownListLocalidad.DataBind();

            List<ObtenerCantidadInvitadosCatering> Cantidades = serviciosEventos.TraerCantidadPersonasCateringAdicionales();

            DropDownListCantidadInvitados.DataSource = Cantidades.ToList();
            DropDownListCantidadInvitados.DataTextField = "CantidadPersonas";
            DropDownListCantidadInvitados.DataValueField = "CantidadPersonas";
            DropDownListCantidadInvitados.DataBind();

            DropDownListTipoEvento.DataSource = serviciosEventos.TraerTipoEvento();
            DropDownListTipoEvento.DataTextField = "Descripcion";
            DropDownListTipoEvento.DataValueField = "Id";
            DropDownListTipoEvento.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Logistica/Index.aspx");
        }



        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.CostoLogistica costo = CostoLogisticaSeleccionado;

            costo.ConceptoId = Int32.Parse(DropDownListTipoLogistica.SelectedItem.Value.ToString());
            costo.Localidad = Int32.Parse(DropDownListLocalidad.SelectedItem.Value.ToString());
            costo.CantidadInvitados = Int32.Parse(DropDownListCantidadInvitados.SelectedItem.Value.ToString());

            if (costo.TipoEventoId != null)
                costo.TipoEventoId = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value.ToString());

            costo.Valor = double.Parse(TextBoxPrecio.Text);
            costo.Costo = double.Parse(TextBoxCosto.Text);

            servicios.NuevoCostoLogistica(costo);

            Response.Redirect("~/Costos/Logistica/Index.aspx");
        }

    }
}