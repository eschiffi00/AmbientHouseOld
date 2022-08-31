using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using System.Globalization;

namespace AmbientHouse.Administracion.NotaCreditos
{
        
    public partial class Editar : System.Web.UI.Page
    {
        private int ComprobanteId
        {
            get
            {
                return Int32.Parse(Session["ComprobanteId"].ToString());
            }
            set
            {
                Session["ComprobanteId"] = value;
            }
        }

        private int NotaCreditoId
        {
            get
            {
                return Int32.Parse(Session["NotaCreditoId"].ToString());
            }
            set
            {
                Session["NotaCreditoId"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.NotaCreditos NotaCreditosSeleccionado
        {
            get
            {
                return Session["NotaCreditosSeleccionado"] as DomainAmbientHouse.Entidades.NotaCreditos;
            }
            set
            {
                Session["NotaCreditosSeleccionado"] = value;
            }
        }

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
            }
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                NotaCreditoId = id;

            
            }

            DomainAmbientHouse.Entidades.ComprobantesProveedores comprobante = administracion.BuscarComprobantes(ComprobanteId);

            TextBoxNroComprobante.Text = comprobante.NroComprobante.ToString();

            if (id == 0)
                NuevaNotaCredito();
            else
                EditarNotaCredito(id);

            //SetFocus(TextBoxApellidoyNombre);
        }

        private void EditarNotaCredito(int id)
        {
            DomainAmbientHouse.Entidades.NotaCreditos notaCredito = new DomainAmbientHouse.Entidades.NotaCreditos();

            notaCredito = administracion.BuscarNotaCredito(id);

            NotaCreditosSeleccionado = notaCredito;

            TextBoxImporte.Text = notaCredito.Importe.ToString();
            TextBoxFecha.Text = String.Format("{0:dd/MM/yyyy}", notaCredito.Fecha); 
        

        }

        private void NuevaNotaCredito()
        {
            NotaCreditosSeleccionado = new DomainAmbientHouse.Entidades.NotaCreditos();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Valido())
                Grabar();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.NotaCreditos notaCredito = NotaCreditosSeleccionado;

            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            notaCredito.Importe = cmd.ValidarImportes(TextBoxImporte.Text);
            notaCredito.Fecha = fechaSeleccionada;
            notaCredito.ComprobanteProveedorId = ComprobanteId;

            administracion.GrabarNotaCredito(notaCredito);
            Response.Redirect("~/Administracion/NotaCreditos/Index.aspx?Id=" + ComprobanteId);
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/NotaCreditos/Index.aspx?Id=" + ComprobanteId);
        }


        public bool Valido ()
        {
            return true;
        }
    }
}