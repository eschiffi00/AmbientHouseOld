using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.FacturasClientes
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios administracion = new AdministrativasServicios();
        ClientesServicios clientes = new ClientesServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.FacturasCliente FacturasClienteSeleccionado
        {
            get
            {
                return Session["FacturasClienteSeleccionado"] as DomainAmbientHouse.Entidades.FacturasCliente;
            }
            set
            {
                Session["FacturasClienteSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.FacturaClienteDetalle> listFacturaDetalle
        {
            get
            {
                return Session["listFacturaDetalle"] as List<DomainAmbientHouse.Entidades.FacturaClienteDetalle>;
            }
            set
            {
                Session["listFacturaDetalle"] = value;
            }
        }

        private int FacturaId
        {
            get
            {
                return Int32.Parse(Session["FacturaId"].ToString());
            }
            set
            {
                Session["FacturaId"] = value;
            }
        }

        private double Importe
        {
            get
            {
                return double.Parse(Session["Importe"].ToString());
            }
            set
            {
                Session["Importe"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listFacturaDetalle = new List<DomainAmbientHouse.Entidades.FacturaClienteDetalle>();

                MaskedEditExtenderFecha.Mask = "99/99/9999";

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

                FacturaId = id;
            }

            GridViewFacturasDetalle.Visible = false;
            GridViewFacturaDetalleVer.Visible = false;

            if (id == 0)
            {
                FacturaClienteDetalle detalle = new FacturaClienteDetalle();

                AgregarDetalle(detalle);

                GridViewFacturasDetalle.Visible = true;
            }
            else
            {
                GridViewFacturaDetalleVer.Visible = true;

                EditarFactura(id);
            }

            SetFocus(DropDownListEmpresas);

        }

        private void EditarFactura(int id)
        {
            DomainAmbientHouse.Entidades.FacturasCliente factura = new DomainAmbientHouse.Entidades.FacturasCliente();

            factura = administracion.BuscarFacturasCliente(id);

            FacturasClienteSeleccionado = factura;


            DropDownListEmpresas.SelectedValue = factura.EmpresaId.ToString();
            DropDownListPresupuestos.SelectedValue = factura.PresupuestoId.ToString();
            DropDownListTipoComprobante.SelectedValue = factura.TipoComprobanteId.ToString();
            DropDownListCliente.SelectedValue = factura.ClienteId.ToString();
            TextBoxNroFactura.Text = factura.NroFactura.ToString();
            TextBoxImporte.Text = factura.Importe.ToString("C");
            TextBoxFecha.Text = String.Format("{0:dd/MM/yyyy}", factura.Fecha);

            DropDownListEmpresas.Enabled = false;
            DropDownListTipoComprobante.Enabled = false;
            DropDownListCliente.Enabled = false;
            DropDownListPresupuestos.Enabled = false;
            TextBoxImporte.ReadOnly = true;
            TextBoxNroFactura.ReadOnly = true;
            TextBoxFecha.ReadOnly = true;

            GridViewFacturaDetalleVer.DataSource = factura.FacturaClienteDetalle.ToList();
            GridViewFacturaDetalleVer.DataBind();



        }

        private void AgregarDetalle(FacturaClienteDetalle detalle)
        {
            double iva = double.Parse(ConfigurationManager.AppSettings["IVA21"].ToString());

            listFacturaDetalle.Add(detalle);

            GridViewFacturasDetalle.DataSource = listFacturaDetalle.ToList();
            GridViewFacturasDetalle.DataBind();

            double importe = 0;
            foreach (var item in listFacturaDetalle)
            {
                if (item.Grabado)
                    importe = importe + item.Importe * iva;
                else
                    importe = importe + item.Importe;


            }

            TextBoxImporte.Text = importe.ToString("C");

            Importe = importe;

            UpdatePanelFacturas.Update();
        }

        private void CargarListas()
        {
            ClientesSearcher searcher = new ClientesSearcher();

            DropDownListCliente.DataSource = clientes.BuscarClientesPorApellidoRazonSocial(searcher).OrderBy(o => o.Identificador).ToList();
            DropDownListCliente.DataTextField = "Identificador";
            DropDownListCliente.DataValueField = "Id";
            DropDownListCliente.DataBind();


            DropDownListEmpresas.DataSource = administracion.ObtenerEmpresas();
            DropDownListEmpresas.DataTextField = "RazonSocial";
            DropDownListEmpresas.DataValueField = "Id";
            DropDownListEmpresas.DataBind();

            DropDownListTipoComprobante.DataSource = administracion.ObtenerTipoComprobantes();
            DropDownListTipoComprobante.DataTextField = "Descripcion";
            DropDownListTipoComprobante.DataValueField = "Id";
            DropDownListTipoComprobante.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/FacturasClientes/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            int facturaPendiente = Int32.Parse(ConfigurationManager.AppSettings["FacturaPendiente"].ToString());

            FacturasCliente factura = new FacturasCliente();

            if (ValidarFactura(factura))
            {

                factura.EmpresaId = Int32.Parse(DropDownListEmpresas.SelectedItem.Value);
                factura.TipoComprobanteId = Int32.Parse(DropDownListTipoComprobante.SelectedItem.Value);
                factura.NroFactura = int.Parse(TextBoxNroFactura.Text);
                factura.Importe = cmd.ValidarImportes(Importe.ToString());
                factura.ClienteId = Int32.Parse(DropDownListCliente.SelectedItem.Value);
                factura.PresupuestoId = Int32.Parse(DropDownListPresupuestos.SelectedItem.Value);
                factura.Fecha = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                factura.EstadoId = facturaPendiente;
                factura.FacturaClienteDetalle = listFacturaDetalle.Where(s => s.Id > 0).ToList();



                administracion.GrabarFacturasClientes(factura);

                Response.Redirect("~/Administracion/FacturasClientes/Index.aspx");
            }


        }

        private bool ValidarFactura(FacturasCliente factura)
        {
            LabelErrores.Visible = false;



            if (!cmd.IsNumeric(TextBoxNroFactura.Text))
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "El nro de factura no es un valor númerico.";
                return false;
            }

            if (!cmd.IsDate(TextBoxFecha.Text))
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "El nro de factura no es un valor númerico.";
                return false;
            }


            bool existe = administracion.ExisteFacturaPorEmpresayNro(Int32.Parse(DropDownListEmpresas.SelectedValue),
                                                                        Int32.Parse(TextBoxNroFactura.Text),
                                                                        Int32.Parse(DropDownListTipoComprobante.SelectedValue));

            if (existe)
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "El nro de factura ya existe para la empresa seleccionada.";
                return false;
            }


            return true;
        }

        protected void GridViewFacturasDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button agregar = (Button)e.Row.FindControl("ButtonAgregar");
                Button quitar = (Button)e.Row.FindControl("ButtonQuitar");

                TextBox descripcion = (TextBox)e.Row.FindControl("TextBoxDescripcion");
                TextBox importe = (TextBox)e.Row.FindControl("TextBoxImporte");
                TextBox cantidad = (TextBox)e.Row.FindControl("TextBoxCantidad");

                DropDownList grabado = (DropDownList)e.Row.FindControl("DropDownListGrabado");

                int id = int.Parse(e.Row.Cells[0].Text);


                agregar.Visible = false;
                quitar.Visible = false;

                if (id == 0)
                    agregar.Visible = true;
                else
                {
                    quitar.Visible = true;

                    FacturaClienteDetalle detalle = listFacturaDetalle.Single(o => o.Id == id);

                    descripcion.Text = detalle.Descripcion;
                    importe.Text = detalle.Importe.ToString();
                    cantidad.Text = detalle.Cantidad.ToString();
                    if (detalle.Grabado)
                        grabado.SelectedValue = "SI";
                    else
                        grabado.SelectedValue = "NO";
                }
            }
        }

        protected void GridViewFacturasDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewFacturasDetalle.Rows[index];

                TextBox descripcion = (TextBox)row.FindControl("TextBoxDescripcion");
                TextBox importe = (TextBox)row.FindControl("TextBoxImporte");
                TextBox cantidad = (TextBox)row.FindControl("TextBoxCantidad");
                DropDownList grabado = (DropDownList)row.FindControl("DropDownListGrabado");

                FacturaClienteDetalle detalle = new FacturaClienteDetalle();

                detalle.Id = listFacturaDetalle.Count();
                detalle.Descripcion = descripcion.Text;
                detalle.Importe = cmd.ValidarImportes(importe.Text);
                detalle.Cantidad = cmd.ValidarImportes(cantidad.Text);
                if (grabado.SelectedItem.Value == "SI")
                    detalle.Grabado = true;
                else
                    detalle.Grabado = false;

                detalle.CreateFecha = System.DateTime.Now;

                AgregarDetalle(detalle);


            }
            else if (e.CommandName == "Quitar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewFacturasDetalle.Rows[index];

                int id = int.Parse(row.Cells[0].Text);

                FacturaClienteDetalle detalle = listFacturaDetalle.Single(o => o.Id == id);

                listFacturaDetalle.Remove(detalle);

                GridViewFacturasDetalle.DataSource = listFacturaDetalle.ToList();
                GridViewFacturasDetalle.DataBind();

                UpdatePanelFacturas.Update();

            }
        }

        protected void DropDownListCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCliente.SelectedIndex > 0)
            {

                int clientebisId = int.Parse(DropDownListCliente.SelectedValue);

                DropDownListPresupuestos.DataSource = presupuestos.BuscarPresupuestoPorCliente(clientebisId);
                DropDownListPresupuestos.DataTextField = "Id";
                DropDownListPresupuestos.DataValueField = "Id";
                DropDownListPresupuestos.DataBind();

                UpdatePanelFacturas.Update();
            }
        }
    }
}