using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;

namespace AmbientHouse.Configuracion.TipoCatering
{
    public partial class Editar : System.Web.UI.Page
    {

        private DomainAmbientHouse.Entidades.TipoCatering TipoCateringSeleccionado
        {
            get
            {
                return Session["TipoCateringSeleccionado"] as DomainAmbientHouse.Entidades.TipoCatering;
            }
            set
            {
                Session["TipoCateringSeleccionado"] = value;
            }
        }

        private AdministrativasServicios servicio = new AdministrativasServicios();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarListas();
                InicializarPagina();
            }
        }

        private void CargarListas()
        {
            DropDownListEstados.DataSource = servicio.BuscarEstadosPorEntidad("TipoCatering");
            DropDownListEstados.DataTextField = "Descripcion";
            DropDownListEstados.DataValueField = "Id";
            DropDownListEstados.DataBind();
        }

        private void InicializarPagina()
        {
            long id = 0;

            if (Request["Id"] != null)
            {
                id = Int64.Parse(Request["Id"]);
            }


            if (id == 0)
                NuevoTipoCatering();
            else
                EditarTipoCatering(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarTipoCatering(long id)
        {
            DomainAmbientHouse.Entidades.TipoCatering tipoCatering = new DomainAmbientHouse.Entidades.TipoCatering();

            tipoCatering = servicio.BuscarTipoCatering(id);

            TipoCateringSeleccionado = tipoCatering;


            TextBoxDescripcion.Text = tipoCatering.Descripcion;
            DropDownListEstados.SelectedValue = tipoCatering.EstadoId.ToString();



        }

        private void NuevoTipoCatering()
        {
            TipoCateringSeleccionado = new DomainAmbientHouse.Entidades.TipoCatering();


        }

        private void GrabarTipoCatering()
        {
            DomainAmbientHouse.Entidades.TipoCatering TipoCatering = TipoCateringSeleccionado;

            TipoCatering.Descripcion = TextBoxDescripcion.Text;



            TipoCatering.EsAdicional = "N";

            TipoCatering.RubroId = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());

            TipoCatering.EstadoId = Int32.Parse(DropDownListEstados.SelectedItem.Value);

            servicio.NuevoTipoCatering(TipoCatering);

            Response.Redirect("~/Configuracion/TipoCatering/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarTipoCatering();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCatering/Index.aspx");
        }
    }
}