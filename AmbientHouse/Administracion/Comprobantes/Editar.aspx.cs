using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AmbientHouse.Administracion.Comprobantes
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.ComprobantesProveedores ComprobantesSeleccionado
        {
            get
            {
                return Session["ComprobantesSeleccionado"] as DomainAmbientHouse.Entidades.ComprobantesProveedores;
            }
            set
            {
                Session["ComprobantesSeleccionado"] = value;
            }
        }

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

        private bool IsEdit
        {
            get
            {
                return bool.Parse(Session["IsEdit"].ToString());
            }
            set
            {
                Session["IsEdit"] = value;
            }
        }

        private List<ComprobantesProveedores_Detalles> ListComprobanteDetalle
        {
            get
            {
                return Session["ListComprobanteDetalle"] as List<ComprobantesProveedores_Detalles>;
            }
            set
            {
                Session["ListComprobanteDetalle"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Limpiar();
                //MaskedEditExtenderFecha.Mask = "99/99/9999";


                //TextBoxTotalFactura.ReadOnly = true;
                //LabelErrores.Visible = false;
                //LabelCCREquerido.Visible = false;
                //LabelErrorFechaComprobante.Visible = false;
                //LabelErrorNroComprobante.Visible = false;

                //DropDownListCuentas.Visible = false;
                //LabelCuenta.Visible = false;

                ////ComprobantesenEfectivo();

                //ListComprobanteDetalle = new List<ComprobantesProveedores_Detalles>();

                //CargarListas();

                //ActualizarImpuestos();

                //TextBoxCantidadItem.Text = "1";

                //InicializarPagina();

                //LabelVerificado.Visible = false;

            }

            LabelVerificado.Visible = false;

            CalendarExtenderFecha.EndDate = System.DateTime.Today;

        }

        private void CargarListas()
        {
            DropDownListProveedores.DataSource = servicios.ListarProveedores();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();

            ComboTipoMovimiento.DataSource = servicios.ObtenerTipoMovimientosEgresos();
            ComboTipoMovimiento.DataTextField = "Identificador";
            ComboTipoMovimiento.DataValueField = "Id";
            ComboTipoMovimiento.DataBind();

            DropDownListCentrosCosto.DataSource = servicios.ObtenerCentroCosto();
            DropDownListCentrosCosto.DataTextField = "Descripcion";
            DropDownListCentrosCosto.DataValueField = "Id";
            DropDownListCentrosCosto.DataBind();

            DropDownListCuentas.DataSource = servicios.ObtenerCuentas();
            DropDownListCuentas.DataTextField = "Nombre";
            DropDownListCuentas.DataValueField = "Id";
            DropDownListCuentas.DataBind();

            DropDownListEmpresa.DataSource = servicios.ObtenerEmpresasBlancoProveedores();
            DropDownListEmpresa.DataTextField = "RazonSocial";
            DropDownListEmpresa.DataValueField = "Id";
            DropDownListEmpresa.DataBind();

            DropDownListUnidadNegocio.DataSource = servicios.ObtenerUN();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();

            DropDownListDegustacion.DataSource = servicios.ObtenerDegustacion();
            DropDownListDegustacion.DataTextField = "Identificador";
            DropDownListDegustacion.DataValueField = "Id";
            DropDownListDegustacion.DataBind();

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ComprobanteId = id;
            }


            if (id == 0)
            {
                IsEdit = false;
                NuevoComprobante();
            }
            else
            {
                IsEdit = true;
                EditarComprobante(id);
            }
            SetFocus(TextBoxFecha);

        }

        private void NuevoComprobante()
        {
            ComprobantesSeleccionado = new DomainAmbientHouse.Entidades.ComprobantesProveedores();
        }

        private void EditarComprobante(int id)
        {

            DomainAmbientHouse.Entidades.ComprobantesProveedores comprobante = new DomainAmbientHouse.Entidades.ComprobantesProveedores();

            comprobante = servicios.BuscarComprobantes(id);

            ComprobantesSeleccionado = comprobante;

            TextBoxNroComprobante.Text = comprobante.NroComprobante.ToString();
            DropDownListProveedores.SelectedValue = comprobante.ProveedorId.ToString();

            DatosdelProveedor((int)comprobante.ProveedorId);

            DropDownListTipoComprobantes.SelectedValue = comprobante.TipoComprobanteId.ToString();
            DropDownListTipoPago.SelectedValue = comprobante.FormadePagoId.ToString();
            TextBoxFecha.Text = String.Format("{0:dd/MM/yyyy}", comprobante.Fecha);
            TextBoxTotalItem.Text = comprobante.MontoNeto.ToString();
            TextBoxIIBBARBA.Text = comprobante.IIBBARBA.ToString();
            TextBoxIIBBCABA.Text = comprobante.IIBBCABA.ToString();
            TextBoxPercepcionIva.Text = comprobante.PercepcionIVA.ToString();
            DropDownListCuentas.SelectedValue = comprobante.CuentaId.ToString();

            if (comprobante.EmpresaId != null)
                DropDownListEmpresa.SelectedValue = comprobante.EmpresaId.ToString();

            TextBoxTotalFactura.Text = comprobante.MontoFactura.ToString();

            List<ComprobantesProveedores_Detalles> detalle = servicios.BuscarDetalleComprobanteProveedorPorComprobante(id);

            if (detalle.Count > 0)
            {
                ListComprobanteDetalle = detalle.ToList();

                CalcularTotal(comprobante.IIBBARBA, comprobante.IIBBCABA, comprobante.PercepcionIVA);

                GridViewDetalle.DataSource = detalle.ToList();
                GridViewDetalle.DataBind();
            }


        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Grabar();
            }
        }

        private bool Validar()
        {

            if (!cmd.IsDate(TextBoxFecha.Text))
            {
                LabelErrorFechaComprobante.Text = "La fecha del comprobante no es una fecha valida.";
                LabelErrorFechaComprobante.Visible = true;
                return false;
            }

            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (fechaSeleccionada > System.DateTime.Today)
            {
                LabelErrorFechaComprobante.Text = "La fecha del comprobante no puede ser mayor a la fecha actual.";
                LabelErrorFechaComprobante.Visible = true;
                return false;
            }



            int proveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            long nroComprobante = Int32.Parse(TextBoxNroComprobante.Text);

            if (IsEdit == false)
            {
                List<ComprobantesProveedores> cp = servicios.BuscarComprobantesPorProveedorNroComprobante(proveedorId, nroComprobante).ToList();

                if (cp.Count() > 0)
                {
                    LabelErrorNroComprobante.Text = "El Nro Comprobante ya existe para ese proveedor.";
                    LabelErrorNroComprobante.Visible = true;
                    return false;
                }
            }

            return true;

        }

        private void Grabar()
        {
            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());
            int Pagado = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagado"].ToString());
            int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPendiente"].ToString());

            int tipoPagoEfectivo = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoEfectivo"].ToString());


            LabelErrores.Visible = false;

            DomainAmbientHouse.Entidades.ComprobantesProveedores comprobante = ComprobantesSeleccionado;

            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            comprobante.TipoComprobanteId = Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value);
            comprobante.FormadePagoId = Int32.Parse(DropDownListTipoPago.SelectedItem.Value);

            if (DropDownListProveedores.SelectedItem.Value != "null")
            {
                comprobante.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
            }

            comprobante.NroComprobante = Int32.Parse(TextBoxNroComprobante.Text);
            comprobante.PuntoVenta = Int64.Parse(TextBoxPuntoVenta.Text);
            comprobante.Fecha = fechaSeleccionada;
            comprobante.MontoNeto = double.Parse(TextBoxTotalItem.Text);
            comprobante.MontoFactura = double.Parse(TextBoxTotalFactura.Text);

            if (int.Parse(DropDownListTipoPago.SelectedItem.Value) == tipoPagoEfectivo)
            {

                comprobante.CuentaId = int.Parse(DropDownListCuentas.SelectedItem.Value);
                comprobante.EmpleadoId = 3; // Empresa OTRA
                comprobante.EstadoId = Pagado;

            }
            else
            {
                comprobante.EmpresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);
            }
            if (Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value) == ComprobanteInterno)
            {
                comprobante.CuentaId = Int32.Parse(DropDownListCuentas.SelectedItem.Value);
                comprobante.EstadoId = Pagado;
            }
            else
            {
                comprobante.EstadoId = Pendiente;
            }

            if (cmd.IsNumeric(TextBoxIIBBARBA.Text))
            {
                comprobante.IIBBARBA = cmd.ValidarImportes(TextBoxIIBBARBA.Text); // double.Parse(TextBoxIIBBARBA.Text.Replace(".", ","));
            }
            if (cmd.IsNumeric(TextBoxIIBBCABA.Text))
            {
                comprobante.IIBBCABA = cmd.ValidarImportes(TextBoxIIBBCABA.Text); // double.Parse(TextBoxIIBBCABA.Text.Replace(".", ","));
            }
            if (cmd.IsNumeric(TextBoxPercepcionIva.Text))
            {
                comprobante.PercepcionIVA = cmd.ValidarImportes(TextBoxPercepcionIva.Text);// double.Parse(TextBoxPercepcionIva.Text.Replace(".", ","));
            }

            comprobante.EmpleadoId = EmpleadoId;

            if (servicios.NuevoComprobantes(comprobante, ListComprobanteDetalle))
                Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "No se grabo el comprobante.";
            }
        }

        private void GrabarContinuar()
        {
            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());
            int Pagado = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPagado"].ToString());
            int Pendiente = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteProveedorPendiente"].ToString());

            DomainAmbientHouse.Entidades.ComprobantesProveedores comprobante = ComprobantesSeleccionado;

            DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            comprobante.TipoComprobanteId = Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value);
            comprobante.FormadePagoId = Int32.Parse(DropDownListTipoPago.SelectedItem.Value);

            if (DropDownListProveedores.SelectedItem.Value != "null")
            {
                comprobante.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
            }
            comprobante.NroComprobante = Int32.Parse(TextBoxNroComprobante.Text);
            comprobante.PuntoVenta = Int64.Parse(TextBoxPuntoVenta.Text);
            comprobante.Fecha = fechaSeleccionada;
            comprobante.MontoNeto = double.Parse(TextBoxTotalItem.Text);
            comprobante.MontoFactura = double.Parse(TextBoxTotalFactura.Text);

            comprobante.EmpresaId = Int32.Parse(DropDownListEmpresa.SelectedItem.Value);

            if (Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value) == ComprobanteInterno)
            {
                comprobante.CuentaId = Int32.Parse(DropDownListCuentas.SelectedItem.Value);
                comprobante.EstadoId = Pagado;
            }
            else
            {
                comprobante.EstadoId = Pendiente;
            }

            if (cmd.IsNumeric(TextBoxIIBBARBA.Text))
            {
                comprobante.IIBBARBA = cmd.ValidarImportes(TextBoxIIBBARBA.Text); // double.Parse(TextBoxIIBBARBA.Text.Replace(".", ","));
            }
            if (cmd.IsNumeric(TextBoxIIBBCABA.Text))
            {
                comprobante.IIBBCABA = cmd.ValidarImportes(TextBoxIIBBCABA.Text); // double.Parse(TextBoxIIBBCABA.Text.Replace(".", ","));
            }
            if (cmd.IsNumeric(TextBoxPercepcionIva.Text))
            {
                comprobante.PercepcionIVA = cmd.ValidarImportes(TextBoxPercepcionIva.Text);// double.Parse(TextBoxPercepcionIva.Text.Replace(".", ","));
            }

            comprobante.EmpleadoId = EmpleadoId;

            servicios.NuevoComprobantes(comprobante, ListComprobanteDetalle);


            TextBoxFecha.Text = "";
            TextBoxNroComprobante.Text = "";
            TextBoxTotalItem.Text = "";
            TextBoxTotalFactura.Text = "";
            TextBoxIIBBARBA.Text = "";
            TextBoxIIBBCABA.Text = "";
            TextBoxPercepcionIva.Text = "";

            DropDownListProveedores.SelectedValue = null;
            DropDownListEmpresa.SelectedValue = "3";

            ListComprobanteDetalle.Clear();
            GridViewDetalle.DataSource = ListComprobanteDetalle.ToList();
            GridViewDetalle.DataBind();

            LabelErrorNroComprobante.Visible = false;

            SetFocus(TextBoxFecha);

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
        }

        protected void ButtonAgregarItem_Click(object sender, EventArgs e)
        {
            LabelCCREquerido.Visible = false;

            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());

            var query = from L in ListComprobanteDetalle
                        where L.Descripcion.Contains(TextBoxDescripcionItem.Text) &&
                             L.Cantidad.Equals(TextBoxCantidadItem.Text)
                        select L;

            if (query != null)
            {

                ComprobantesProveedores_Detalles detalle = new ComprobantesProveedores_Detalles();


                detalle.Id = GridViewDetalle.Rows.Count + 1;
                detalle.Descripcion = TextBoxDescripcionItem.Text;
                detalle.Importe = cmd.ValidarImportes(TextBoxImporteItem.Text);// double.Parse(TextBoxImporteItem.Text.Replace(".", ","));
                detalle.Cantidad = Int32.Parse(TextBoxCantidadItem.Text);

                if (DropDownListCentrosCosto.SelectedValue != "null")
                {
                    detalle.CentroCostoId = Int32.Parse(DropDownListCentrosCosto.SelectedItem.Value);
                }
                else
                {
                    LabelCCREquerido.Visible = true;
                    return;
                }

                detalle.TipoMoviemientoId = Int32.Parse(ComboTipoMovimiento.SelectedItem.Value);
                detalle.TipoMovimientoCodigo = ComboTipoMovimiento.SelectedItem.Text;
                detalle.CentroCostoDescripcion = DropDownListCentrosCosto.SelectedItem.Text;

                if (Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value) != ComprobanteInterno)
                {
                    if (DropDownListImpuestos.SelectedItem != null)
                    {
                        detalle.TipoImpuestoId = Int32.Parse(DropDownListImpuestos.SelectedItem.Value);

                        DomainAmbientHouse.Entidades.Impuestos impuesto = servicios.BuscarImpuesto((int)detalle.TipoImpuestoId);

                        detalle.ValorImpuesto = ((impuesto.Porcentaje / 100) * detalle.Importe);
                    }

                    if (cmd.IsNumeric(TextBoxImpuestoInterno.Text))
                    {
                        detalle.ValorImpuestoInterno = cmd.ValidarImportes(TextBoxImpuestoInterno.Text);// double.Parse(TextBoxImpuestoInterno.Text.Replace(".", ","));
                    }
                }

                if (cmd.IsNumeric(TextBoxNroPresupuesto.Text))
                    detalle.PresupuestoId = Int32.Parse(TextBoxNroPresupuesto.Text);

                if (DropDownListUnidadNegocio.SelectedItem.Value != "null")
                    detalle.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);


                if (DropDownListUnidadNegocio.SelectedItem.Value != "null")
                    detalle.DegustacionId = Int32.Parse(DropDownListDegustacion.SelectedItem.Value);


                ListComprobanteDetalle.Add(detalle);

                GridViewDetalle.DataSource = ListComprobanteDetalle.ToList();

                GridViewDetalle.DataBind();

                double TotalIIBBARBA;
                double TotalIIBBCABA;
                double TotalPercepcionIva;
                TotalImpuestoCabecera(out TotalIIBBARBA, out TotalIIBBCABA, out TotalPercepcionIva);

                CalcularTotalComprobante(TotalIIBBARBA, TotalIIBBCABA, TotalPercepcionIva);
            }
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Va a ingresar el mismo Item mas de una vez en el Comprobante.";

            }


            TextBoxDescripcionItem.Text = TextBoxImporteItem.Text = "";
            TextBoxCantidadItem.Text = "1";
            TextBoxNroPresupuesto.Text = "";

            DropDownListUnidadNegocio.SelectedValue = "null";

            ComboTipoMovimiento.Focus();

            UpdatePanelComprobante.Update();
        }

        private void TotalImpuestoCabecera(out double TotalIIBBARBA, out double TotalIIBBCABA, out double TotalPercepcionIva)
        {
            TotalIIBBARBA = 0;

            if (cmd.IsNumeric(TextBoxIIBBARBA.Text))
            {
                TotalIIBBARBA = double.Parse(TextBoxIIBBARBA.Text.Replace('.', ','));
            }

            TotalIIBBCABA = 0;

            if (cmd.IsNumeric(TextBoxIIBBCABA.Text))
            {
                TotalIIBBCABA = double.Parse(TextBoxIIBBCABA.Text.Replace('.', ','));
            }

            TotalPercepcionIva = 0;

            if (cmd.IsNumeric(TextBoxPercepcionIva.Text))
            {
                TotalPercepcionIva = double.Parse(TextBoxPercepcionIva.Text.Replace('.', ','));
            }
        }

        private void CalcularTotal(double? IIBBARBA, double? IIBBCABA, double? PercepcionIVA)
        {
            var query = (from L in ListComprobanteDetalle
                         select L.Importe + (L.ValorImpuesto == null ?
                                            0 :
                                            cmd.ValidarImportes(L.ValorImpuesto.ToString())) +
                                            (L.ValorImpuestoInterno == null ?
                                            0 :
                                            cmd.ValidarImportes(L.ValorImpuestoInterno.ToString()))).Sum();

            double totalIIBB = (IIBBARBA == null ? 0 : double.Parse(IIBBARBA.ToString()))
                + (IIBBCABA == null ? 0 : double.Parse(IIBBCABA.ToString()))
                + (PercepcionIVA == null ? 0 : double.Parse(PercepcionIVA.ToString()));

            TextBoxTotalItem.Text = (System.Math.Round(double.Parse(query.ToString()) + totalIIBB, 2)).ToString();




            TextBoxTotalFactura.Text = (System.Math.Round(double.Parse(query.ToString()) + totalIIBB, 2)).ToString();
        }

        private void CalcularTotalComprobante(double totalArba, double totalCaba, double totalPercepcionIva)
        {
            var query = (from L in ListComprobanteDetalle
                         select L.Importe).Sum();


            TextBoxTotalItem.Text = (System.Math.Round(double.Parse(query.ToString()), 2)).ToString();


            var queryTotalImpuestos = (from L in ListComprobanteDetalle
                                       select L.ValorImpuesto).Sum();


            var queryTotalImpuestosInternos = (from L in ListComprobanteDetalle
                                               select L.ValorImpuestoInterno).Sum();


            //double Total = 0;
            //if (cmd.IsNumeric(TextBoxTotalFactura.Text))
            //{
            //    Total = double.Parse(TextBoxTotalFactura.Text);
            //}

            TextBoxTotalFactura.Text = (System.Math.Round(double.Parse(query.ToString()) + double.Parse(queryTotalImpuestos.ToString()) + double.Parse(queryTotalImpuestosInternos.ToString()) + totalArba + totalCaba + totalPercepcionIva, 2)).ToString();
        }

        protected void ButtonQuitar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewDetalle.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxQuitarItem") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.ComprobantesProveedores_Detalles detalle = new DomainAmbientHouse.Entidades.ComprobantesProveedores_Detalles();


                    detalle.Id = Int32.Parse(row.Cells[1].Text);

                    var itemRemove = ListComprobanteDetalle.Where(o => o.Id == detalle.Id).Single();

                    ListComprobanteDetalle.Remove(itemRemove);
                }

            }

            double TotalIIBBARBA;
            double TotalIIBBCABA;
            double TotalPercepcionIva;
            TotalImpuestoCabecera(out TotalIIBBARBA, out TotalIIBBCABA, out TotalPercepcionIva);

            CalcularTotalComprobante(TotalIIBBARBA, TotalIIBBCABA, TotalPercepcionIva);

            GridViewDetalle.DataSource = ListComprobanteDetalle.ToList();
            GridViewDetalle.DataBind();

            UpdatePanelComprobante.Update();

        }

        protected void DropDownListTipoComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarImpuestos();
        }

        private void ActualizarImpuestos()
        {
            int ComprobanteInterno = Int32.Parse(ConfigurationManager.AppSettings["ComprobanteInterno"].ToString());
            string EmpresaOtra = ConfigurationManager.AppSettings["EmpresaOtra"].ToString();

            if (DropDownListTipoComprobantes.SelectedItem != null)
            {

                if (Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value) == ComprobanteInterno)
                {
                    DropDownListImpuestos.Visible = false;
                    DropDownListCuentas.Visible = true;
                    LabelCuenta.Visible = true;

                    DropDownListEmpresa.SelectedValue = EmpresaOtra;

                    PanelImpuestos.Visible = false;
                }
                else
                {
                    PanelImpuestos.Visible = true;

                    DropDownListImpuestos.Visible = true;
                    DropDownListImpuestos.DataSource = servicios.BuscarImpuestosPorTipoComprobante(Int32.Parse(DropDownListTipoComprobantes.SelectedItem.Value));
                    DropDownListImpuestos.DataTextField = "Descripcion";
                    DropDownListImpuestos.DataValueField = "Id";
                    DropDownListImpuestos.DataBind();


                    DropDownListCuentas.Visible = false;
                    LabelCuenta.Visible = false;
                }
            }

            UpdatePanelComprobante.Update();
        }

        protected void ButtonRevisar_Click(object sender, EventArgs e)
        {
            double TotalIIBBARBA;
            double TotalIIBBCABA;
            double TotalPercepcionIva;
            TotalImpuestoCabecera(out TotalIIBBARBA, out TotalIIBBCABA, out TotalPercepcionIva);

            CalcularTotalComprobante(TotalIIBBARBA, TotalIIBBCABA, TotalPercepcionIva);




        }

        protected void ButtonVerificar_Click(object sender, EventArgs e)
        {
            if (cmd.IsNumeric(TextBoxNroPresupuesto.Text))
            {
                LabelVerificado.Visible = true;

                if (VerificarNroPresupuesto())
                    LabelVerificado.Text = "Existe";
                else
                    LabelVerificado.Text = "No Existe";

            }
        }

        private bool VerificarNroPresupuesto()
        {
            int presupuestoId = Int32.Parse(TextBoxNroPresupuesto.Text);

            PresupuestosServicios presupuestos = new PresupuestosServicios();

            return presupuestos.BuscarPresupuesto(presupuestoId) != null;
        }

        protected void DropDownListProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListProveedores.SelectedItem != null)
            {
                DatosdelProveedor(Int32.Parse(DropDownListProveedores.SelectedItem.Value));
            }


        }

        private void DatosdelProveedor(int proveedorId)
        {
            int id = proveedorId;

            Proveedores proveedor = servicios.BuscarProveedor(id);

            List<DomainAmbientHouse.Entidades.TipoComprobantes> listarComprobantes = servicios.BuscarTipoComprobantesPorTipoProveedor(proveedor.CondicionIvaId).ToList();

            DropDownListTipoComprobantes.DataSource = listarComprobantes.ToList();
            DropDownListTipoComprobantes.DataTextField = "Descripcion";
            DropDownListTipoComprobantes.DataValueField = "Id";
            DropDownListTipoComprobantes.DataBind();

            ActualizarImpuestos();

            SetFocus(TextBoxPuntoVenta);

            List<DomainAmbientHouse.Entidades.ProveedoresFormasdePago> listarFormadePago = servicios.BuscarFormasdePagoPorProveedor(proveedor.Id).ToList();

            DropDownListTipoPago.Items.Clear();

            if (listarFormadePago.Count > 0)
            {
                DropDownListTipoPago.DataSource = listarFormadePago.ToList();
                DropDownListTipoPago.DataTextField = "Descripcion";
                DropDownListTipoPago.DataValueField = "Id";
                DropDownListTipoPago.DataBind();
            }
            else
            {
                DropDownListTipoPago.DataSource = servicios.ObtenerFormasdePago();
                DropDownListTipoPago.DataTextField = "Descripcion";
                DropDownListTipoPago.DataValueField = "Id";
                DropDownListTipoPago.DataBind();

            }

            //ComprobantesenEfectivo();

            UpdatePanelComprobante.Update();
        }

        protected void DropDownListEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFocus(TextBoxIIBBCABA);
            UpdatePanelComprobante.Update();
        }

        protected void ButtonAceptaryContinuar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GrabarContinuar();
                Limpiar();
            }
        }


        internal void Limpiar()
        {
            MaskedEditExtenderFecha.Mask = "99/99/9999";


            TextBoxTotalFactura.ReadOnly = true;
            LabelErrores.Visible = false;
            LabelCCREquerido.Visible = false;
            LabelErrorFechaComprobante.Visible = false;
            LabelErrorNroComprobante.Visible = false;

            DropDownListCuentas.Visible = false;
            LabelCuenta.Visible = false;

            //ComprobantesenEfectivo();

            ListComprobanteDetalle = new List<ComprobantesProveedores_Detalles>();

            CargarListas();

            ActualizarImpuestos();

            TextBoxCantidadItem.Text = "1";

            InicializarPagina();

            LabelVerificado.Visible = false;
        }
        //protected void DropDownListTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        //{


        //    ComprobantesenEfectivo();


        //}

        //private void ComprobantesenEfectivo()
        //{
        //    int tipoPagoEfectivo = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoEfectivo"].ToString());

        //    DropDownListCuentas.Visible = false;
        //    LabelCuenta.Visible = false;


        //    if (DropDownListTipoPago.SelectedItem != null)
        //    {

        //        if (int.Parse(DropDownListTipoPago.SelectedValue) == tipoPagoEfectivo)
        //        {
        //            DropDownListCuentas.Visible = LabelCuenta.Visible = true;

        //            DropDownListCuentas.DataSource = servicios.ObtenerCuentas().Where(o => o.TipoCuenta == "EFECTIVO").ToList();
        //            DropDownListCuentas.DataTextField = "Nombre";
        //            DropDownListCuentas.DataValueField = "Id";
        //            DropDownListCuentas.DataBind();

        //            UpdatePanelComprobante.Update();
        //        }
        //    }
        //}
    }
}