using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Proveedores
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.Proveedores ProveedorSeleccionado
        {
            get
            {
                return Session["ProveedorSeleccionado"] as DomainAmbientHouse.Entidades.Proveedores;
            }
            set
            {
                Session["ProveedorSeleccionado"] = value;
            }
        }

        private int ProveedorId
        {
            get
            {
                return Int32.Parse(Session["ProveedorId"].ToString());
            }
            set
            {
                Session["ProveedorId"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores> ListUnidadesNegociosProveedores
        {
            get
            {
                return Session["ListUnidadesNegociosProveedores"] as List<DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores>;
            }
            set
            {
                Session["ListUnidadesNegociosProveedores"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Rubros_Proveedores> ListRubrosProveedores
        {
            get
            {
                return Session["ListRubrosProveedores"] as List<DomainAmbientHouse.Entidades.Rubros_Proveedores>;
            }
            set
            {
                Session["ListRubrosProveedores"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.ProveedoresFormasdePago> ListProveedoresFormasdePago
        {
            get
            {
                return Session["ListProveedoresFormasdePago"] as List<DomainAmbientHouse.Entidades.ProveedoresFormasdePago>;
            }
            set
            {
                Session["ListProveedoresFormasdePago"] = value;
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListUnidadesNegociosProveedores = new List<DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores>();
                ListRubrosProveedores = new List<DomainAmbientHouse.Entidades.Rubros_Proveedores>();
                ListProveedoresFormasdePago = new List<DomainAmbientHouse.Entidades.ProveedoresFormasdePago>();

                LabelCuitRepetido.Visible = false;
                LabelCBUError.Visible = false;

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

                ProveedorId = id;
            }


            if (id == 0)
            {
                IsEdit = false;
                NuevoProveedor();
            }
            else
            {
                IsEdit = true;
                EditarProveedores(id);

            }
            SetFocus(TextBoxRazonSocial);
        }

        private void EditarProveedores(int id)
        {

            DomainAmbientHouse.Entidades.Proveedores proveedor = new DomainAmbientHouse.Entidades.Proveedores();

            proveedor = servicios.BuscarProveedor(id);

            ProveedorSeleccionado = proveedor;


            TextBoxRazonSocial.Text = proveedor.RazonSocial;
            TextBoxNombreFantasia.Text = proveedor.NombreFantasia;
            TextBoxCbu.Text = proveedor.CBU;
            TextBoxCuit.Text = proveedor.Cuit;
            TextBoxTelefono.Text = proveedor.Telefono;
            TextBoxNroCliente.Text = proveedor.NroCliente;

            if (proveedor.CondicionIvaId != null)
                DropDownListCondicionIva.SelectedValue = proveedor.CondicionIvaId.ToString();

            if (proveedor.Propio == "S")
            { DropDownListPropio.SelectedValue = "SI"; }
            else
            { DropDownListPropio.SelectedValue = "NO"; }


            ListUnidadesNegociosProveedores = servicios.BuscarUnidadNegocioPorProveedor(ProveedorId);

            if (ListUnidadesNegociosProveedores.Count() > 0)
            {


                GridViewUN.DataSource = ListUnidadesNegociosProveedores.ToList();
                GridViewUN.DataBind();
            }

            ListRubrosProveedores = servicios.BuscarRubroPorProveedor(ProveedorId);

            if (ListRubrosProveedores.Count() > 0)
            {

                GridViewRP.DataSource = ListRubrosProveedores.ToList();
                GridViewRP.DataBind();


            }

            ListProveedoresFormasdePago = servicios.BuscarFormasdePagoPorProveedor(ProveedorId);

            if (ListProveedoresFormasdePago.Count() > 0)
            {

                GridViewFP.DataSource = ListProveedoresFormasdePago.ToList();
                GridViewFP.DataBind();


            }
        }

        private void NuevoProveedor()
        {
            ProveedorSeleccionado = new DomainAmbientHouse.Entidades.Proveedores();
        }

        private void Grabar()
        {


            DomainAmbientHouse.Entidades.Proveedores proveedor = ProveedorSeleccionado;

            proveedor.RazonSocial = TextBoxRazonSocial.Text;


            proveedor.NombreFantasia = TextBoxNombreFantasia.Text;
            proveedor.CBU = TextBoxCbu.Text;
            proveedor.Cuit = TextBoxCuit.Text;
            proveedor.Telefono = TextBoxTelefono.Text;
            proveedor.NroCliente = TextBoxNroCliente.Text;
            proveedor.CondicionIvaId = Int32.Parse(DropDownListCondicionIva.SelectedItem.Value);

            if (DropDownListRubros.SelectedItem != null)
                proveedor.RubroId = Int32.Parse(DropDownListRubros.SelectedItem.Value.ToString());

            if (DropDownListUnidadNegocio.SelectedItem != null)
                proveedor.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString());

            if (DropDownListPropio.SelectedItem.Value == "SI")
            { proveedor.Propio = "S"; }
            else
            { proveedor.Propio = "N"; }


            servicios.NuevoProveedor(proveedor, ListUnidadesNegociosProveedores, ListRubrosProveedores, ListProveedoresFormasdePago);

            Response.Redirect("~/Configuracion/Proveedores/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Proveedores/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (Validar(TextBoxCuit.Text))
            {
                Grabar();
            }
        }

        private bool Validar(string cuit)
        {

            int FormaPagoTransferencias = Int32.Parse(ConfigurationManager.AppSettings["FormaPagoTransferencia"].ToString());

            DomainAmbientHouse.Entidades.Proveedores proveedorRepetido = servicios.ObtenerProveedoresPorCuit(cuit);

            LabelCuitRepetido.Visible = false;

            if (proveedorRepetido != null && IsEdit == false)
            {
                LabelCuitRepetido.Visible = true;
                LabelCuitRepetido.Text = "El cuit ya existe en el sistema como proveedor.";
                return false;
            }

            if (cuit.Length < 11)
            {
                LabelCuitRepetido.Visible = true;
                LabelCuitRepetido.Text = "El cuit no tiene el la cantidad de caracteres correctos.";
                return false;
            }

            foreach (var item in ListProveedoresFormasdePago)
            {
                if (item.FormadePagoId == FormaPagoTransferencias)
                {
                    if (TextBoxCbu.Text.Length == 0)
                    {
                        LabelCBUError.Visible = true;
                        LabelCBUError.Text = "El CBU es obligatorio ya el Proveedor acepta Transferencias.";
                        return false;
                    }

                    if (TextBoxCbu.Text.Length != 22)
                    {
                        LabelCBUError.Visible = true;
                        LabelCBUError.Text = "El CBU no tiene el largo correcto.";
                        return false;
                    }
                }
            }

            return true;
        }

        private void CargarListas()
        {
            DropDownListRubros.DataSource = servicios.ObtenerRubros();
            DropDownListRubros.DataTextField = "Descripcion";
            DropDownListRubros.DataValueField = "RubroId";
            DropDownListRubros.DataBind();


            DropDownListUnidadNegocio.DataSource = servicios.ObtenerUN();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();

            DropDownListCondicionIva.DataSource = servicios.ListarCondicionIva();
            DropDownListCondicionIva.DataTextField = "Descripcion";
            DropDownListCondicionIva.DataValueField = "Id";
            DropDownListCondicionIva.DataBind();

            DropDownListFormasdePago.DataSource = servicios.ObtenerFormasdePago();
            DropDownListFormasdePago.DataTextField = "Descripcion";
            DropDownListFormasdePago.DataValueField = "Id";
            DropDownListFormasdePago.DataBind();

            DropDownListTipoRetencion.DataSource = servicios.ObtenerTABLA_Retenciones();
            DropDownListTipoRetencion.DataTextField = "Concepto";
            DropDownListTipoRetencion.DataValueField = "Id";
            DropDownListTipoRetencion.DataBind();

        }

        protected void ButtonAgregarUnidadesNegocios_Click(object sender, EventArgs e)
        {
            int unidadNegocio = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);

            var query = from L in ListUnidadesNegociosProveedores
                        where (L.UnidadNegocioId == unidadNegocio)
                        select L;

            if (query.Count() == 0)
            {

                DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores UnProveedores = new DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores();

                UnProveedores.Descripcion = DropDownListUnidadNegocio.SelectedItem.Text;
                UnProveedores.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);

                ListUnidadesNegociosProveedores.Add(UnProveedores);


                GridViewUN.DataSource = ListUnidadesNegociosProveedores.ToList();
                GridViewUN.DataBind();


            }
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Va a ingresar la misma Unidad de Negocio al Proveedor.";

            }

        }

        protected void ButtonQuitarUnidadesNeocios_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewUN.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxElementoSeleccionado") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores UnProveedores = new DomainAmbientHouse.Entidades.UnidadesNegocios_Proveedores();


                    UnProveedores.Id = Int32.Parse(row.Cells[1].Text);

                    var itemRemove = ListUnidadesNegociosProveedores.Where(o => o.UnidadNegocioId == UnProveedores.Id).SingleOrDefault();

                    ListUnidadesNegociosProveedores.Remove(itemRemove);


                    GridViewUN.DataSource = ListUnidadesNegociosProveedores.ToList();
                    GridViewUN.DataBind();


                }

            }
        }

        protected void ButtonAgregarRubroProveedor_Click(object sender, EventArgs e)
        {
            int rubro = Int32.Parse(DropDownListRubros.SelectedItem.Value);

            var query = from L in ListRubrosProveedores
                        where (L.RubroId == rubro)
                        select L;

            if (query.Count() == 0)
            {


                DomainAmbientHouse.Entidades.Rubros_Proveedores rubroProveedores = new DomainAmbientHouse.Entidades.Rubros_Proveedores();

                rubroProveedores.Descripcion = DropDownListRubros.SelectedItem.Text;
                rubroProveedores.RubroId = Int32.Parse(DropDownListRubros.SelectedItem.Value);

                ListRubrosProveedores.Add(rubroProveedores);


                GridViewRP.DataSource = ListRubrosProveedores.ToList();
                GridViewRP.DataBind();


            }
            else
            {
                LabelErrores1.Visible = true;
                LabelErrores1.Text = "Va a ingresar el mismo Rubro al Proveedor.";

            }
        }

        protected void ButtonQuitarRubroProveedor_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewRP.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxElementoSeleccionado") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.Rubros_Proveedores rubroProveedores = new DomainAmbientHouse.Entidades.Rubros_Proveedores();


                    rubroProveedores.Id = Int32.Parse(row.Cells[1].Text);

                    var itemRemove = ListRubrosProveedores.Where(o => o.RubroId == rubroProveedores.Id).SingleOrDefault();

                    ListRubrosProveedores.Remove(itemRemove);



                    GridViewRP.DataSource = ListRubrosProveedores.ToList();
                    GridViewRP.DataBind();

                }

            }
        }

        protected void ButtonAgregarFormadePago_Click(object sender, EventArgs e)
        {
            int formadePago = Int32.Parse(DropDownListFormasdePago.SelectedItem.Value);

            var query = from L in ListProveedoresFormasdePago
                        where (L.FormadePagoId == formadePago)
                        select L;

            if (query.Count() == 0)
            {

                DomainAmbientHouse.Entidades.ProveedoresFormasdePago formaDePagoProveedores = new DomainAmbientHouse.Entidades.ProveedoresFormasdePago();

                formaDePagoProveedores.FormadePagoId = Int32.Parse(DropDownListFormasdePago.SelectedItem.Value);
                formaDePagoProveedores.Descripcion = DropDownListFormasdePago.SelectedItem.Text;

                ListProveedoresFormasdePago.Add(formaDePagoProveedores);


                GridViewFP.DataSource = ListProveedoresFormasdePago.ToList();
                GridViewFP.DataBind();


            }
            else
            {
                LabelErrores2.Visible = true;
                LabelErrores2.Text = "Va a ingresar la misma Forma de pago al Proveedor.";

            }
        }

        protected void ButtonQuitarFormadePago_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewFP.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxElementoSeleccionado") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.ProveedoresFormasdePago formadePagoProveedor = new DomainAmbientHouse.Entidades.ProveedoresFormasdePago();


                    formadePagoProveedor.Id = Int32.Parse(row.Cells[1].Text);

                    var itemRemove = ListProveedoresFormasdePago.Where(o => o.FormadePagoId == formadePagoProveedor.Id).SingleOrDefault();

                    ListProveedoresFormasdePago.Remove(itemRemove);



                    GridViewFP.DataSource = ListProveedoresFormasdePago.ToList();
                    GridViewFP.DataBind();

                }

            }
        }


    }
}