using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Costos.AmbientacionCI
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios administrativas = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion CostosPaquetesCIAmbientacionSeleccionado
        {
            get
            {
                return Session["CostosPaquetesCIAmbientacionSeleccionado"] as DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion;
            }
            set
            {
                Session["CostosPaquetesCIAmbientacionSeleccionado"] = value;
            }
        }

        private int CostosCIId
        {
            get
            {
                return Int32.Parse(Session["CostosCIId"].ToString());
            }
            set
            {
                Session["CostosCIId"] = value;
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

        private void CargarListas()
        {

            int activo = Int32.Parse(ConfigurationManager.AppSettings["AmbientacionCIActivo"].ToString());
            int UNAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            DropDownListPaquetes.DataSource = administrativas.ObtenerAmbientacionesCI();
            DropDownListPaquetes.DataTextField = "Descripcion";
            DropDownListPaquetes.DataValueField = "Id";
            DropDownListPaquetes.DataBind();

            DropDownListProveedores.DataSource = eventos.TraerProveedoresPorRubro(UNAmbientacion);
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CostosCIId = id;
            }


            if (id == 0)
                NuevoCosto();
            else
                EditarCostoCI(id);

            SetFocus(DropDownListPaquetes);
        }

        private void EditarCostoCI(int id)
        {
            DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion ambientacion = new DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion();

            ambientacion = administrativas.BuscarCostosPaquetesCIAmbientacion(id);

            CostosPaquetesCIAmbientacionSeleccionado = ambientacion;


            DropDownListPaquetes.SelectedValue = ambientacion.PaqueteCIID.ToString();
            DropDownListProveedores.SelectedValue = ambientacion.ProveedorId.ToString();
            DropDownListSemestre.SelectedValue = ambientacion.Semestre.ToString();
            TextBoxRangoPersonas.Text = ambientacion.CantidadPaquetes.ToString();
            TextBoxAnio.Text = ambientacion.Anio.ToString();
            TextBoxCostoFlete.Text = ambientacion.CostoFlete.ToString();
            TextBoxCosto.Text = ambientacion.Costo.ToString();
            TextBoxPrecio.Text = ambientacion.Precio.ToString();


        }

        private void NuevoCosto()
        {
            CostosPaquetesCIAmbientacionSeleccionado = new CostosPaquetesCIAmbientacion();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/AmbientacionCI/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {

            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());


            DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion ambientacion = CostosPaquetesCIAmbientacionSeleccionado;


            ambientacion.CaracteristicaId = caracteristicaId;
            ambientacion.SegmentoId = segmentoId;

            ambientacion.PaqueteCIID = Int32.Parse(DropDownListPaquetes.SelectedItem.Value);
            ambientacion.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
            ambientacion.Semestre = Int32.Parse(DropDownListSemestre.SelectedItem.Value);
            ambientacion.Anio = Int32.Parse(TextBoxAnio.Text);

            if (cmd.IsNumeric(TextBoxRangoPersonas.Text))
                ambientacion.CantidadPaquetes = Int32.Parse(TextBoxRangoPersonas.Text);

            if (cmd.IsNumeric(TextBoxCostoFlete.Text) )
                ambientacion.CostoFlete = double.Parse(TextBoxCostoFlete.Text);

            if (cmd.IsNumeric(TextBoxCosto.Text))
                ambientacion.Costo = double.Parse(TextBoxCosto.Text);

            if (cmd.IsNumeric(TextBoxPrecio.Text))
                ambientacion.Precio = double.Parse(TextBoxPrecio.Text);

            administrativas.GrabarCostoPreciosAmbientacionCI(ambientacion);


            Response.Redirect("~/Costos/AmbientacionCI/Index.aspx");
        }
    }
}