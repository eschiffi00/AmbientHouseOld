using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Configuration;

namespace AmbientHouse.Inicio.DegustacionDetalle
{
    public partial class Editar : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

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

        private int DegustacionDetalleId
        {
            get
            {
                return Int32.Parse(Session["DegustacionDetalleId"].ToString());
            }
            set
            {
                Session["DegustacionDetalleId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.DegustacionDetalle DegustacionDetalleSeleccionado
        {
            get
            {
                return Session["DegustacionDetalleSeleccionado"] as DomainAmbientHouse.Entidades.DegustacionDetalle;
            }
            set
            {
                Session["DegustacionDetalleSeleccionado"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.PanelSocial.Visible = false;
                this.PanelCorporativo.Visible = false;
                this.CargarListas();
                this.CargarFormulario();
                this.InicializarPagina();
            }

        }

        private void CargarListas()
        {
            this.DropDownListSegmentos.DataSource = this.eventos.TraerSegmentos();
            this.DropDownListSegmentos.DataTextField = "Descripcion";
            this.DropDownListSegmentos.DataValueField = "Id";
            this.DropDownListSegmentos.DataBind();
            this.DropDownListCaracteristicasCorp.DataSource = this.eventos.TraerCaracteristicas();
            this.DropDownListCaracteristicasCorp.DataTextField = "Descripcion";
            this.DropDownListCaracteristicasCorp.DataValueField = "Id";
            this.DropDownListCaracteristicasCorp.DataBind();
            this.DropDownListCaracteristicasSoc.DataSource = this.eventos.TraerCaracteristicas();
            this.DropDownListCaracteristicasSoc.DataTextField = "Descripcion";
            this.DropDownListCaracteristicasSoc.DataValueField = "Id";
            this.DropDownListCaracteristicasSoc.DataBind();
            this.DropDownListLocacionesCorp.DataSource = this.eventos.ObtenerLocacionesParaCotizar();
            this.DropDownListLocacionesCorp.DataTextField = "Descripcion";
            this.DropDownListLocacionesCorp.DataValueField = "Id";
            this.DropDownListLocacionesCorp.DataBind();
            this.DropDownListLocacionesSoc.DataSource = this.eventos.ObtenerLocacionesParaCotizar();
            this.DropDownListLocacionesSoc.DataTextField = "Descripcion";
            this.DropDownListLocacionesSoc.DataValueField = "Id";
            this.DropDownListLocacionesSoc.DataBind();
            this.DropDownListTipoEvento.DataSource = this.eventos.TraerTipoEvento();
            this.DropDownListTipoEvento.DataTextField = "Descripcion";
            this.DropDownListTipoEvento.DataValueField = "Id";
            this.DropDownListTipoEvento.DataBind();
        }

        private void CargarFormulario()
        {
            int num = int.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());
            this.PanelSocial.Visible = false;
            this.PanelCorporativo.Visible = false;
            if (this.DropDownListSegmentos.SelectedItem != null)
            {
                if (int.Parse(this.DropDownListSegmentos.SelectedItem.Value) == num)
                {
                    this.PanelCorporativo.Visible = true;
                }
                else
                {
                    this.PanelSocial.Visible = true;
                }
            }
            this.UpdatePanelComensales.Update();
        }

        private void InicializarPagina()
        {
            int id = 0;
            if (base.Request["Id"] != null)
            {
                id = int.Parse(base.Request["Id"]);
                this.DegustacionDetalleId = id;
            }
            if (id == 0)
            {
                this.NuevoDetalle();
            }
            else
            {
                this.EditarDetalle(id);
            }
        }

        private void EditarDetalle(int id)
        {
                int num = int.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());
                DomainAmbientHouse.Entidades.DegustacionDetalle detalle = new DomainAmbientHouse.Entidades.DegustacionDetalle();
                detalle = this.administracion.BuscarDetalleDegustacion(id);
                this.DegustacionDetalleSeleccionado = detalle;
                if (detalle.SegmentoId != num)
                {
                    this.DropDownListSegmentos.SelectedValue = detalle.SegmentoId.ToString();
                    this.PanelSocial.Visible = true;
                    this.PanelCorporativo.Visible = false;
                    this.TextBoxNombreyApellidoSoc.Text = detalle.Comensal;
                    this.TextBoxNroComensalSoc.Text = detalle.NroComensal.ToString();
                    this.TextBoxNroMesaSoc.Text = detalle.NroMesa.ToString();
                    this.TextBoxFechaEventoSoc.Text =String.Format("{0:dd/MM/yyyy}",detalle.FechaEvento);
                    this.TextBoxCantInvitadosSoc.Text = detalle.CantidadInvitados.ToString();
                    this.DropDownListCaracteristicasSoc.SelectedValue = detalle.CaracteristicaId.ToString();
                    this.DropDownListLocacionesSoc.SelectedValue = detalle.LocacionId.ToString();
                    this.TextBoxComentarioSoc.Text = detalle.Comentarios;
                    this.TextBoxTelefonoSoc.Text = detalle.Telefono;
                    this.TextBoxCorreoSoc.Text = detalle.Mail;
                    this.DropDownListTipoEvento.SelectedValue = detalle.TipoEventoId.ToString();
                }
                else
                {
                    this.DropDownListSegmentos.SelectedValue = detalle.SegmentoId.ToString();
                    this.PanelCorporativo.Visible = true;
                    this.PanelSocial.Visible = false;
                    this.TextBoxEmpresa.Text = detalle.Empresa;
                    this.TextBoxNombreyApellidoCorp.Text = detalle.Comensal;
                    this.TextBoxNroComensalCorp.Text = detalle.NroComensal.ToString();
                    this.TextBoxNroMesaCorp.Text = detalle.NroMesa.ToString();
                    this.TextBoxFechaEventoCorp.Text = String.Format("{0:dd/MM/yyyy}", detalle.FechaEvento);
                    this.TextBoxCantInvitadosCorp.Text = detalle.CantidadInvitados.ToString();
                    this.DropDownListCaracteristicasCorp.SelectedValue = detalle.CaracteristicaId.ToString();
                    this.DropDownListLocacionesCorp.SelectedValue = detalle.LocacionId.ToString();
                    this.TextBoxComentarioCorp.Text = detalle.Comentarios;
                    this.TextBoxTelefonoCorp.Text = detalle.Telefono;
                    this.TextBoxCorreoCorp.Text = detalle.Mail;
                    this.DropDownListEstado.SelectedValue = detalle.EstadoEvento;
                }

        }

        private void NuevoDetalle()
        {
            this.DegustacionDetalleSeleccionado = new DomainAmbientHouse.Entidades.DegustacionDetalle();

        }

        protected void DropDownListSegmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarFormulario();

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            string str;
            if (this.Validar(out str))
            {
                this.Grabar();
            }
            else
            {
                this.LabelMensaje.Text = str.ToUpper();
            }
            this.LabelMensaje.Visible = true;
        }


        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Inicio/DegustacionDetalle/Index.aspx?Id=" + this.DegustacionId);

        }

        private void Grabar()
        {
            int num = int.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());
            int num2 = int.Parse(ConfigurationManager.AppSettings["DegustacionDetallePendiente"].ToString());
            DomainAmbientHouse.Entidades.DegustacionDetalle degustacionDetalleSeleccionado = this.DegustacionDetalleSeleccionado;
            if (int.Parse(this.DropDownListSegmentos.SelectedItem.Value) != num)
            {
                degustacionDetalleSeleccionado.Comensal = this.TextBoxNombreyApellidoSoc.Text;
                degustacionDetalleSeleccionado.NroComensal = new int?(int.Parse(this.TextBoxNroComensalSoc.Text));
                degustacionDetalleSeleccionado.NroMesa = new int?(int.Parse(this.TextBoxNroMesaSoc.Text));
                degustacionDetalleSeleccionado.FechaEvento = DateTime.Parse(this.TextBoxFechaEventoSoc.Text);
                degustacionDetalleSeleccionado.CantidadInvitados = int.Parse(this.TextBoxCantInvitadosSoc.Text);
                degustacionDetalleSeleccionado.CaracteristicaId = int.Parse(this.DropDownListCaracteristicasSoc.SelectedItem.Value);
                degustacionDetalleSeleccionado.LocacionId = new int?(int.Parse(this.DropDownListLocacionesSoc.SelectedItem.Value));
                degustacionDetalleSeleccionado.Comentarios = this.TextBoxComentarioSoc.Text;
                degustacionDetalleSeleccionado.Telefono = this.TextBoxTelefonoSoc.Text;
                degustacionDetalleSeleccionado.Mail = this.TextBoxCorreoSoc.Text;
                degustacionDetalleSeleccionado.TipoEventoId = new int?(int.Parse(this.DropDownListTipoEvento.SelectedItem.Value));
            }
            else
            {
                degustacionDetalleSeleccionado.Empresa = this.TextBoxEmpresa.Text;
                degustacionDetalleSeleccionado.Comensal = this.TextBoxNombreyApellidoCorp.Text;
                if (this.cmd.IsNumeric(this.TextBoxNroComensalCorp.Text))
                {
                    degustacionDetalleSeleccionado.NroComensal = new int?(int.Parse(this.TextBoxNroComensalCorp.Text));
                }
                if (this.cmd.IsNumeric(this.TextBoxNroMesaCorp.Text))
                {
                    degustacionDetalleSeleccionado.NroMesa = new int?(int.Parse(this.TextBoxNroMesaCorp.Text));
                }
                degustacionDetalleSeleccionado.FechaEvento = DateTime.Parse(this.TextBoxFechaEventoCorp.Text);
                degustacionDetalleSeleccionado.CantidadInvitados = int.Parse(this.TextBoxCantInvitadosCorp.Text);
                degustacionDetalleSeleccionado.CaracteristicaId = int.Parse(this.DropDownListCaracteristicasCorp.SelectedItem.Value);
                degustacionDetalleSeleccionado.LocacionId = new int?(int.Parse(this.DropDownListLocacionesCorp.SelectedItem.Value));
                degustacionDetalleSeleccionado.Comentarios = this.TextBoxComentarioCorp.Text;
                degustacionDetalleSeleccionado.Telefono = this.TextBoxTelefonoCorp.Text;
                degustacionDetalleSeleccionado.Mail = this.TextBoxCorreoCorp.Text;
                degustacionDetalleSeleccionado.EstadoEvento = this.DropDownListEstado.SelectedItem.Value;
            }
            degustacionDetalleSeleccionado.EmpleadoId = this.EmpleadoId;
            degustacionDetalleSeleccionado.DegustacionId = this.DegustacionId;
            degustacionDetalleSeleccionado.SegmentoId = int.Parse(this.DropDownListSegmentos.SelectedItem.Value);
            degustacionDetalleSeleccionado.EstadoId = num2;
            this.administracion.Grabar(degustacionDetalleSeleccionado);
            base.Response.Redirect("~/Inicio/DegustacionDetalle/Index.aspx?Id=" + this.DegustacionId);
        }

        private bool Validar(out string mensaje)
        {
            int num = int.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());
            if (int.Parse(this.DropDownListSegmentos.SelectedItem.Value) == num)
            {
                if (this.TextBoxEmpresa.Text.Length == 0)
                {
                    mensaje = "Empresa es obligatorio";
                    return false;
                }
                if (this.TextBoxFechaEventoCorp.Text.Length == 0)
                {
                    mensaje = "Fecha de Evento es obligatorio";
                    return false;
                }
                if (this.TextBoxCantInvitadosCorp.Text.Length == 0)
                {
                    mensaje = "Cant. de Invitados es obligatorio";
                    return false;
                }
            }
            else
            {
                if (this.TextBoxFechaEventoSoc.Text.Length == 0)
                {
                    mensaje = "Fecha de Evento es obligatorio";
                    return false;
                }
                if (this.TextBoxCantInvitadosSoc.Text.Length == 0)
                {
                    mensaje = "Cantidad de Invitados es obligatorio";
                    return false;
                }
                if (this.TextBoxNroMesaSoc.Text.Length == 0)
                {
                    mensaje = "Nro. de Mesa es obligatorio";
                    return false;
                }
                if (this.TextBoxNroComensalSoc.Text.Length == 0)
                {
                    mensaje = "Nro. de Comensal es obligatorio";
                    return false;
                }
                if (this.TextBoxNombreyApellidoSoc.Text.Length == 0)
                {
                    mensaje = "Nombre y Apellido es obligatorio";
                    return false;
                }
                if (this.TextBoxCantInvitadosSoc.Text.Length == 0)
                {
                    mensaje = "Cant. de Invitados es obligatorio";
                    return false;
                }
            }
            mensaje = "";
            return true;
        }



    }
}