using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Configuration;
using System.Globalization;

namespace AmbientHouse.Organizador.Degustacion
{
    public partial class Editar : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administracion = new AdministrativasServicios();

      
        private int DegustacionId
        {
            get
            {
                return Int32.Parse(Session["DegustacionId"].ToString());
            }
            set
            {
                Session["DegustacionId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.Degustacion DegustacionSeleccionado
        {
            get
            {
                return Session["DegustacionSeleccionado"] as DomainAmbientHouse.Entidades.Degustacion;
            }
            set
            {
                Session["DegustacionSeleccionado"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.CargarListas();
                this.InicializarPagina();
            }

        }

        private void CargarListas()
        {
            this.DropDownListLocaciones.DataSource = this.eventos.ObtenerLocacionesParaCotizar();
            this.DropDownListLocaciones.DataTextField = "Descripcion";
            this.DropDownListLocaciones.DataValueField = "Id";
            this.DropDownListLocaciones.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;
            if (base.Request["Id"] != null)
            {
                id = int.Parse(base.Request["Id"]);
            }
            if (id == 0)
            {
                this.NuevaDegustacion();
            }
            else
            {
                this.EditarDegustacion(id);
            }
            base.SetFocus(this.TextBoxFechaDegustacion);
        }

        private void EditarDegustacion(int id)
        {
            DomainAmbientHouse.Entidades.Degustacion degustacion = new DomainAmbientHouse.Entidades.Degustacion();

            degustacion = this.administracion.BuscarDegustacion(id);
            this.DegustacionSeleccionado = degustacion;
            this.TextBoxFechaDegustacion.Text = String.Format("{0:dd/MM/yyyy}", degustacion.FechaDegustacion);
            this.TextBoxHoraCorporativo.Text = degustacion.HoraCorporativo;
            this.TextBoxHoraSocial.Text = degustacion.HoraSocial;
            this.DropDownListLocaciones.SelectedValue = degustacion.Locacion.ToString();

        }

        private void NuevaDegustacion()
        {
            this.DegustacionSeleccionado = new DomainAmbientHouse.Entidades.Degustacion();

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Organizador/Degustacion/Index.aspx");
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.Degustacion degustacionSeleccionado = this.DegustacionSeleccionado;
            degustacionSeleccionado.FechaDegustacion = DateTime.ParseExact(this.TextBoxFechaDegustacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            degustacionSeleccionado.HoraCorporativo = this.TextBoxHoraCorporativo.Text;
            degustacionSeleccionado.HoraSocial = this.TextBoxHoraSocial.Text;
            degustacionSeleccionado.Locacion = int.Parse(this.DropDownListLocaciones.SelectedItem.Value);
            degustacionSeleccionado.ConfirmoAmbientacion = false;
            degustacionSeleccionado.ConfirmoTecnica = false;
            degustacionSeleccionado.EstadoId = int.Parse(ConfigurationManager.AppSettings["DegustacionAbierta"].ToString());
            this.administracion.Grabar(degustacionSeleccionado);
            base.Response.Redirect("~/Organizador/Degustacion/Index.aspx");
        }


    }
}