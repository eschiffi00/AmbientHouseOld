using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Salones
{
    public partial class EditarValoresAnuales : System.Web.UI.Page
    {
        EventosServicios servicios = new EventosServicios();

        private DomainAmbientHouse.Entidades.LocacionesValorAnio LocacionesValorAnioSeleccionado
        {
            get
            {
                return Session["LocacionesValorAnioSeleccionado"] as DomainAmbientHouse.Entidades.LocacionesValorAnio;
            }
            set
            {
                Session["LocacionesValorAnioSeleccionado"] = value;
            }
        }

        private int ValorAnioId
        {
            get
            {
                return Int32.Parse(Session["ValorAnioId"].ToString());
            }
            set
            {
                Session["ValorAnioId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelMensaje.Visible = false;
                InicializarPagina();
                CargarListas();
            }

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ValorAnioId = id;
            }


            if (id == 0)
                NuevoLocacionesValorAnio();
            else
                EditarLocacionesValorAnio(id);

            SetFocus(DropDownListAnio);
        }

        private void EditarLocacionesValorAnio(int id)
        {

            DomainAmbientHouse.Entidades.LocacionesValorAnio locacionesValorAnio = new DomainAmbientHouse.Entidades.LocacionesValorAnio();

            locacionesValorAnio = servicios.BuscarLocacionesValorAnio(id);

            LocacionesValorAnioSeleccionado = locacionesValorAnio;


            DropDownListAnio.Text = locacionesValorAnio.Anio.ToString();
            TextBoxPrecio.Text = locacionesValorAnio.Costo.ToString();
            DropDownListLocaciones.Text = locacionesValorAnio.LocacionId.ToString();

        }

        private void NuevoLocacionesValorAnio()
        {
            LocacionesValorAnioSeleccionado = new DomainAmbientHouse.Entidades.LocacionesValorAnio();
        }

        private void CargarListas()
        {
            DropDownListLocaciones.DataSource = servicios.TraerLocaciones();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();


            int AnioActual = DateTime.Now.Year;
            int AnioRango = AnioActual + 5;

            for (int i = AnioActual; i < AnioRango; i++)
            {

                ListItem anio = new ListItem();

                anio.Text = i.ToString();
                anio.Value = i.ToString();

                DropDownListAnio.Items.Add(anio);

            }

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Salones/IndexValoresAnuales.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            LabelMensaje.Visible = false;

            int anio = Int32.Parse(DropDownListAnio.SelectedItem.Value.ToString());
            int locacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());


            DomainAmbientHouse.Entidades.LocacionesValorAnio locacionesValorAnio = LocacionesValorAnioSeleccionado;

            locacionesValorAnio.Anio = Int32.Parse(DropDownListAnio.SelectedItem.Value.ToString());
            locacionesValorAnio.Costo = double.Parse(TextBoxPrecio.Text);
            locacionesValorAnio.LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());

            if (servicios.ObtenerLocacionesValorAnio(anio, locacionId))
            {
                if (locacionesValorAnio.Id == 0)
                {
                    LabelMensaje.Visible = true;
                    LabelMensaje.Text = "El sistema ya tiene precio para dicho Salon";
                }
                else
                {

                    servicios.NuevoLocacionesValorAnio(locacionesValorAnio);

                    Response.Redirect("~/Costos/Salones/IndexValoresAnuales.aspx");
                }
            }
            else
            {

                servicios.NuevoLocacionesValorAnio(locacionesValorAnio);

                Response.Redirect("~/Costos/Salones/IndexValoresAnuales.aspx");
            }

        }
    }
}