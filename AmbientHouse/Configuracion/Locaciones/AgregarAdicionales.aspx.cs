using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;


namespace AmbientHouse.Configuracion.Locaciones
{
    public partial class AgregarAdicionales : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Adicionales AdicionalSeleccionado
        {
            get
            {
                return Session["AdicionalSeleccionado"] as DomainAmbientHouse.Entidades.Adicionales;
            }
            set
            {
                Session["AdicionalSeleccionado"] = value;
            }
        }

        private int LocacionId
        {
            get
            {
                return Int32.Parse(Session["LocacionId"].ToString());
            }
            set
            {
                Session["LocacionId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { InicializarPagina(); }
        }

        private void InicializarPagina()
        {
            int Id = 0;

            if (Request["LocacionId"] != null)
            {
                Id = Int32.Parse(Request["LocacionId"].ToString());

                LocacionId = Id;

                LabelLocacion.Text = servicios.BuscarLocaciones(LocacionId).Descripcion.ToUpper();
            }


            if (Id == 0)
                NuevoAdicional();
            else
                EditarAdicional(Id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarAdicional(int id)
        {

            int adicionalActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalActivo"].ToString());
            int adicionalNoActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalNoActivo"].ToString());


            DomainAmbientHouse.Entidades.Adicionales adicional = new DomainAmbientHouse.Entidades.Adicionales();

            adicional = servicios.BuscarAdicional(id);

            AdicionalSeleccionado = adicional;


            TextBoxDescripcion.Text = adicional.Descripcion;
            TextBoxPrecio.Text = adicional.Precio.ToString();

            if (adicional.EstadoId == adicionalActivo)
            { CheckBoxActivo.Checked = true; }
            else
            { CheckBoxActivo.Checked = false; }

            if (adicional.RequiereCantidad != null)
            { CheckBoxCantidad.Checked = true; }
            else
            { CheckBoxCantidad.Checked = false; }
        }

        private void NuevoAdicional()
        {
            AdicionalSeleccionado = new DomainAmbientHouse.Entidades.Adicionales();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarAdicional();
        }

        private void GrabarAdicional()
        {
            int adicionalActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalActivo"].ToString());
            int adicionalNoActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalNoActivo"].ToString());

            int rubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());

            DomainAmbientHouse.Entidades.Adicionales adicional = AdicionalSeleccionado;

            adicional.Descripcion = TextBoxDescripcion.Text;

            if (TextBoxPrecio.Text != "")
            {
                adicional.Precio = double.Parse(TextBoxPrecio.Text);
            }
            else
            {
                adicional.Precio = null;
            }
            adicional.RubroId = rubroSalon;

            if (CheckBoxActivo.Checked)
            { adicional.EstadoId = adicionalActivo; }
            else
            { adicional.EstadoId = adicionalNoActivo; }

            if (CheckBoxCantidad.Checked)
            { adicional.RequiereCantidad = "S"; }


            //servicios.NuevoAdicionalSalon(adicional,LocacionId);
            Response.Redirect("~/Configuracion/Locaciones/IndexAdicionales.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Locaciones/IndexAdicionales.aspx");
        }
    }
}