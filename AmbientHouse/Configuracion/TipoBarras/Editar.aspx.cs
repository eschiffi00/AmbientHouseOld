using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Configuracion.TipoBarras
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        EventosServicios eventos = new EventosServicios();

        private DomainAmbientHouse.Entidades.TiposBarras TipoBarraSeleccionado
        {
            get
            {
                return Session["TipoBarraSeleccionado"] as DomainAmbientHouse.Entidades.TiposBarras;
            }
            set
            {
                Session["TipoBarraSeleccionado"] = value;
            }
        }

        private int TipoBarraId
        {
            get
            {
                return Int32.Parse(Session["TipoBarraId"].ToString());
            }
            set
            {
                Session["TipoBarraId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();

                CargarListas();

            }
        }

        private void CargarListas()
        {
            DropDownListSegmentos.DataSource = eventos.TraerSegmentos();
            DropDownListSegmentos.DataTextField = "Descripcion";
            DropDownListSegmentos.DataValueField = "Id";
            DropDownListSegmentos.DataBind();

            DropDownListDuracion.DataSource = servicios.ObtenerDuracionEvento();
            DropDownListDuracion.DataTextField = "Descripcion";
            DropDownListDuracion.DataValueField = "Id";
            DropDownListDuracion.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                TipoBarraId = id;
            }


            if (id == 0)
                NuevoTipoBarra();
            else
                EditarTipoBarra(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarTipoBarra(int id)
        {

            DomainAmbientHouse.Entidades.TiposBarras tipoBarra = new DomainAmbientHouse.Entidades.TiposBarras();

            tipoBarra = servicios.BuscarTipoBarras(id);

            TipoBarraSeleccionado = tipoBarra;


            TextBoxDescripcion.Text = tipoBarra.Descripcion;
            DropDownListSegmentos.SelectedValue = tipoBarra.SegmentoId.ToString();
            DropDownListDuracion.SelectedValue = tipoBarra.DuracionId.ToString();
            DropDownListTipoBarra.SelectedValue = tipoBarra.RangoEtareo;

        }

        private void NuevoTipoBarra()
        {
            TipoBarraSeleccionado = new DomainAmbientHouse.Entidades.TiposBarras();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.TiposBarras tipoBarra = TipoBarraSeleccionado;

            tipoBarra.Descripcion = TextBoxDescripcion.Text;
            tipoBarra.SegmentoId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value);
            tipoBarra.DuracionId = Int32.Parse(DropDownListDuracion.SelectedItem.Value);
            tipoBarra.RangoEtareo = DropDownListTipoBarra.SelectedItem.Value;

            servicios.NuevoTipoBarra(tipoBarra);

            Response.Redirect("~/Configuracion/TipoBarras/Index.aspx");
        }
        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoBarras/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }
    }
}