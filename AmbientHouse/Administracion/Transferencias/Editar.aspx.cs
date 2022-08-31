using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Globalization;

namespace AmbientHouse.Administracion.Transferencias
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.Transferencias TransferenciasSeleccionado
        {
            get
            {
                return Session["TransferenciasSeleccionado"] as DomainAmbientHouse.Entidades.Transferencias;
            }
            set
            {
                Session["TransferenciasSeleccionado"] = value;
            }
        }

        private int TransferenciaId
        {
            get
            {
                return Int32.Parse(Session["TransferenciaId"].ToString());
            }
            set
            {
                Session["TransferenciaId"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

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
            DropDownListBanco.DataSource = administracion.ObtenerBancos();
            DropDownListBanco.DataTextField = "Descripcion";
            DropDownListBanco.DataValueField = "Id";
            DropDownListBanco.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                TransferenciaId = id;
            }


            if (id == 0)
                NuevaTransferencia();
            else
                EditarTransferencia(id);

            SetFocus(TextBoxNroTransferencia);
        }

        private void EditarTransferencia(int id)
        {

            TextBoxRazonSocial.ReadOnly = true;

            DomainAmbientHouse.Entidades.Transferencias tm = new DomainAmbientHouse.Entidades.Transferencias();

            tm = administracion.BuscarTransferencia(id);

            TransferenciasSeleccionado = tm;

            if (tm.ProveedorId != null)
                TextBoxRazonSocial.Text = tm.ProveedorDescripcion;
            else
                TextBoxRazonSocial.Text = tm.ClienteDescripcion;

            DropDownListBanco.SelectedValue = tm.BancoId.ToString();
            TextBoxNroTransferencia.Text = tm.NroTransferencia;
            TextBoxImporte.Text = tm.Importe.ToString();
            TextBoxFecha.Text = String.Format("{0:dd/MM/yyyy}", tm.FechaTransferencia);
        }

        private void NuevaTransferencia()
        {
            TransferenciasSeleccionado = new DomainAmbientHouse.Entidades.Transferencias();

            TextBoxRazonSocial.ReadOnly = false;
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.Transferencias tm = TransferenciasSeleccionado;

            tm.NroTransferencia = TextBoxNroTransferencia.Text;
            tm.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            tm.BancoId = Int32.Parse(DropDownListBanco.SelectedItem.Value);
            tm.FechaTransferencia = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            administracion.GrabarTransferencia(tm);
            Response.Redirect("~/Administracion/Transferencias/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Transferencias/Index.aspx");
        }
    }
}