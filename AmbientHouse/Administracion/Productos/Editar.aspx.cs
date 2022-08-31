using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using System.Configuration;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Seguridad;
using System.Globalization;

namespace AmbientHouse.Administracion.Productos
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios servicioEventos = new EventosServicios();
        SeguridadServicios seguridad = new SeguridadServicios();

        Comun cmd = new Comun();

        #region Variables de Session

        private DomainAmbientHouse.Entidades.Productos ProductosSeleccionado
        {
            get
            {
                return Session["ProductosSeleccionado"] as DomainAmbientHouse.Entidades.Productos;
            }
            set
            {
                Session["ProductosSeleccionado"] = value;
            }
        }

        private int ProductoId
        {
            get
            {
                return Int32.Parse(Session["ProductoId"].ToString());
            }
            set
            {
                Session["ProductoId"] = value;
            }
        }

        private string LetraCodigo
        {
            get
            {
                return Session["LetraCodigo"].ToString();
            }
            set
            {
                Session["LetraCodigo"] = value;
            }
        }

        private int RubroSalon
        {
            get
            {
                return Int32.Parse(Session["RubroSalon"].ToString());
            }
            set
            {
                Session["RubroSalon"] = value;
            }
        }

        private int RubroCatering
        {
            get
            {
                return Int32.Parse(Session["RubroCatering"].ToString());
            }
            set
            {
                Session["RubroCatering"] = value;
            }
        }

        private int RubroBarra
        {
            get
            {
                return Int32.Parse(Session["RubroBarra"].ToString());
            }
            set
            {
                Session["RubroBarra"] = value;
            }
        }

        private int RubroTecnica
        {
            get
            {
                return Int32.Parse(Session["RubroTecnica"].ToString());
            }
            set
            {
                Session["RubroTecnica"] = value;
            }
        }

        private int RubroAmbientacion
        {
            get
            {
                return Int32.Parse(Session["RubroAmbientacion"].ToString());
            }
            set
            {
                Session["RubroAmbientacion"] = value;
            }
        }

        private int RubroOrganizacion
        {
            get
            {
                return Int32.Parse(Session["RubroOrganizacion"].ToString());
            }
            set
            {
                Session["RubroOrganizacion"] = value;
            }
        }

        private int RubroAdicional
        {
            get
            {
                return Int32.Parse(Session["RubroAdicional"].ToString());
            }
            set
            {
                Session["RubroAdicional"] = value;
            }
        }

        private string IsEditable
        {
            get
            {
                return Session["IsEditable"].ToString();
            }
            set
            {
                Session["IsEditable"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LabelErrores.Visible = false;

                CargarListas();

                CargarVariablesSession();



                InicializarPagina();

                CargarListasParaCodigo();
            }
        }

        private void CargarVariablesSession()
        {
            RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());
        }

        private void CargarListas()
        {
            DropDownListUnidadNegocio.DataSource = servicios.ObtenerUN();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();


            DropDownListItemsOrganizacion.DataSource = servicios.ObtenerItemsOrganizacion();
            DropDownListItemsOrganizacion.DataTextField = "Descripcion";
            DropDownListItemsOrganizacion.DataValueField = "Id";
            DropDownListItemsOrganizacion.DataBind();

            DropDownListLocacion.DataSource = servicioEventos.TraerLocacionesSinPrecios();
            DropDownListLocacion.DataTextField = "Descripcion";
            DropDownListLocacion.DataValueField = "Id";
            DropDownListLocacion.DataBind();

            DropDownListCategorias.DataSource = servicioEventos.TraerCategorias();
            DropDownListCategorias.DataTextField = "Descripcion";
            DropDownListCategorias.DataValueField = "Id";
            DropDownListCategorias.DataBind();

            DropDownListTipoCatering.DataSource = servicioEventos.TraerTipoCatering();
            DropDownListTipoCatering.DataTextField = "Descripcion";
            DropDownListTipoCatering.DataValueField = "Id";
            DropDownListTipoCatering.DataBind();

            DropDownListTipoBarra.DataSource = servicioEventos.TraerTipoBarras();
            DropDownListTipoBarra.DataTextField = "Descripcion";
            DropDownListTipoBarra.DataValueField = "Id";
            DropDownListTipoBarra.DataBind();

            DropDownListTipoServicio.DataSource = servicioEventos.TraerTipoServicios();
            DropDownListTipoServicio.DataTextField = "Descripcion";
            DropDownListTipoServicio.DataValueField = "Id";
            DropDownListTipoServicio.DataBind();

            DropDownListJornada.DataSource = servicioEventos.TraerJornadas();
            DropDownListJornada.DataTextField = "Descripcion";
            DropDownListJornada.DataValueField = "Id";
            DropDownListJornada.DataBind();


            DropDownListAdicional.DataSource = servicios.ObtenerAdicionales();
            DropDownListAdicional.DataTextField = "Descripcion";
            DropDownListAdicional.DataValueField = "Id";
            DropDownListAdicional.DataBind();

            List<ObtenerCantidadInvitadosCatering> Cantidades = servicioEventos.TraerCantidadPersonasCateringAdicionales();

            DropDownListCantidadPersonas.DataSource = Cantidades.ToList();
            DropDownListCantidadPersonas.DataTextField = "CantidadPersonas";
            DropDownListCantidadPersonas.DataValueField = "CantidadPersonas";
            DropDownListCantidadPersonas.DataBind();

            DropDownListSegmento.DataSource = servicioEventos.TraerSegmentos();
            DropDownListSegmento.DataTextField = "Descripcion";
            DropDownListSegmento.DataValueField = "Id";
            DropDownListSegmento.DataBind();

            DropDownListCaracteristica.DataSource = servicioEventos.TraerCaracteristicas();
            DropDownListCaracteristica.DataTextField = "Descripcion";
            DropDownListCaracteristica.DataValueField = "Id";
            DropDownListCaracteristica.DataBind();

            DropDownListPerfil.DataSource = seguridad.ObtenerPerfiles();
            DropDownListPerfil.DataTextField = "Descripcion";
            DropDownListPerfil.DataValueField = "Id";
            DropDownListPerfil.DataBind();

            cmd.CargarAnios(DropDownListAnio);
            cmd.CargarMeses(DropDownListMes);
            cmd.CargarDias(DropDownListDias);

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ProductoId = id;
            }


            if (id == 0)
            {
                IsEditable = "N";
                NuevoProducto();
            }
            else
            {
                IsEditable = "S";
                EditarProducto(id);
            }

            SetFocus(TextBoxDescripcion);
        }

        private void EditarProducto(int id)
        {

            DomainAmbientHouse.Entidades.Productos producto = new DomainAmbientHouse.Entidades.Productos();

            producto = servicios.BuscarProducto(id);

            ProductosSeleccionado = producto;

            DropDownListUnidadNegocio.SelectedValue = producto.UnidadNegocioId.ToString();

            if (producto.TipoCateringId != null)
            {
                DropDownListTipoCatering.SelectedValue = producto.TipoCateringId.ToString();
            }

            if (producto.TipoBarraId != null)
            {
                DropDownListTipoBarra.SelectedValue = producto.TipoBarraId.ToString();
            }

            if (producto.TipoServicioId != null)
            {
                DropDownListTipoServicio.SelectedValue = producto.TipoServicioId.ToString();
            }

            if (producto.CategoriaId != null)
            {
                DropDownListCategorias.SelectedValue = producto.CategoriaId.ToString();
            }

            if (producto.LocacionId != null)
            {
                DropDownListLocacion.SelectedValue = producto.LocacionId.ToString();

                int seleccionado = Int32.Parse(this.DropDownListLocacion.SelectedItem.Value.ToString());


                DropDownListSector.DataSource = servicioEventos.BuscarSectoresPorLocacion(seleccionado);
                DropDownListSector.DataTextField = "Descripcion";
                DropDownListSector.DataValueField = "Id";
                DropDownListSector.DataBind();
            }

            if (producto.SectorId != null)
            {
                DropDownListSector.SelectedValue = producto.SectorId.ToString();
            }

            if (producto.SegmentoId != null)
            {
                DropDownListSegmento.SelectedValue = producto.SegmentoId.ToString();
            }

            if (producto.CaracteristicaId != null)
            {
                DropDownListCaracteristica.SelectedValue = producto.CaracteristicaId.ToString();
            }

            if (producto.JornadaId != null)
            {
                DropDownListJornada.SelectedValue = producto.JornadaId.ToString();
            }

            if (producto.CantidadInvitados != null)
            {
                DropDownListCantidadPersonas.SelectedValue = producto.CantidadInvitados.ToString();
            }

            if (producto.ProveedorId != null)
            {
                DropDownListProveedores.SelectedValue = producto.ProveedorId.ToString();
            }

            if (producto.AdicionalId != null)
            {
                DropDownListAdicional.SelectedValue = producto.AdicionalId.ToString();

            }

            if (producto.OrganizacionItemId != null)
            {
                DropDownListItemsOrganizacion.SelectedValue = producto.OrganizacionItemId.ToString();

            }

            if (producto.UnidadNegocioId == RubroSalon || producto.UnidadNegocioId == RubroTecnica)
            {

                string anio;
                string mes;
                string dia;

                anio = producto.Anio.ToString().PadLeft(2, '0');

                DropDownListAnio.SelectedValue = producto.Anio.ToString();

                mes = producto.Mes.ToString().PadLeft(2, '0');

                DropDownListMes.SelectedValue = producto.Mes.ToString().PadLeft(2, '0');

                DropDownListDias.SelectedValue = producto.Dia.ToString();

            }

            TextBoxDescripcion.Text = producto.Descripcion;
            TextBoxCosto.Text = producto.Costo.ToString();
            TextBoxPrecio.Text = producto.Precio.ToString();
            TextBoxCodigo.Text = producto.Codigo.ToString();
            TextBoxRoyalty.Text = producto.Royalty.ToString();

            if (producto.FechaVendimiento != null)
            {
                TextBoxFechaVencimiento.Text = String.Format("{0:dd/MM/yyyy}", producto.FechaVendimiento);
            }

        }

        private void NuevoProducto()
        {
            ProductosSeleccionado = new DomainAmbientHouse.Entidades.Productos();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            double coeficienteRoyalty = double.Parse(ConfigurationManager.AppSettings["coeficienteRoyalty"].ToString());

            DomainAmbientHouse.Entidades.Productos productoConsultado = servicios.BuscarProductosPorCodigo(TextBoxCodigo.Text);


            if (productoConsultado == null && IsEditable == "N")
            {
                DateTime fechaSeleccionadaVencimiento;

                int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());

                DomainAmbientHouse.Entidades.Productos producto = ProductosSeleccionado;

                producto.Descripcion = TextBoxDescripcion.Text;
                producto.Costo = double.Parse(TextBoxCosto.Text);
                producto.Precio = double.Parse(TextBoxPrecio.Text);

                if (cmd.IsNumeric(TextBoxRoyalty.Text))
                    producto.Royalty = double.Parse(TextBoxRoyalty.Text);
                else
                    producto.Royalty = coeficienteRoyalty;

                producto.Codigo = TextBoxCodigo.Text;
                producto.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);
                producto.Estado = activo;

                if (TextBoxFechaVencimiento.Text != "")
                {
                    fechaSeleccionadaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    producto.FechaVendimiento = fechaSeleccionadaVencimiento;
                }

                if (DropDownListPerfil.SelectedItem.Value != "null")
                {
                    producto.PerfilId = Int32.Parse(DropDownListPerfil.SelectedItem.Value);

                }

                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroCatering)
                {
                    GraboCatering(producto);


                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroBarra)
                {
                    GraboBarra(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
                {
                    GraboTecnica(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
                {
                    GraboAmbientacion(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
                {
                    GraboSalon(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAdicional)
                {
                    GraboAdicional(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroOrganizacion)
                {
                    GraboOrganizacion(producto);
                }



                servicios.NuevoProducto(producto);
                Response.Redirect("~/Administracion/Productos/Index.aspx");
            }
            else if (IsEditable == "S")
            {
                DateTime fechaSeleccionadaVencimiento;

                int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());
               

                DomainAmbientHouse.Entidades.Productos producto = ProductosSeleccionado;

                producto.Descripcion = TextBoxDescripcion.Text;
                producto.Costo = cmd.ValidarImportes(TextBoxCosto.Text);
                producto.Precio = cmd.ValidarImportes(TextBoxPrecio.Text);
                if (cmd.IsNumeric(TextBoxRoyalty.Text))
                    producto.Royalty = double.Parse(TextBoxRoyalty.Text);
                else
                    producto.Royalty = coeficienteRoyalty;

                producto.Codigo = TextBoxCodigo.Text;
                producto.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);
                producto.Estado = activo;

                if (TextBoxFechaVencimiento.Text != "")
                {
                    fechaSeleccionadaVencimiento = DateTime.ParseExact(TextBoxFechaVencimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    producto.FechaVendimiento = fechaSeleccionadaVencimiento;
                }

                if (DropDownListPerfil.SelectedItem.Value != "null")
                {
                    producto.PerfilId = Int32.Parse(DropDownListPerfil.SelectedItem.Value);

                }

                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroCatering)
                {
                    GraboCatering(producto);


                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroBarra)
                {
                    GraboBarra(producto);


                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
                {
                    GraboTecnica(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
                {
                    GraboAmbientacion(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
                {
                    GraboSalon(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAdicional)
                {
                    GraboAdicional(producto);
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroOrganizacion)
                {
                    GraboOrganizacion(producto);
                }


                servicios.NuevoProducto(producto);
                Response.Redirect("~/Administracion/Productos/Index.aspx");

            }
            else
            {
                LabelErrores.Visible = true;
                LabelErrores.Text = "Ya existe un Item con ese Codigo!!!";
            }


        }

        private void GraboAdicional(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListAdicional.SelectedItem != null)
            {
                producto.AdicionalId = Int32.Parse(DropDownListAdicional.SelectedItem.Value);

            }

            Adicionales adicional = servicioEventos.BuscarAdicional(Int32.Parse(DropDownListAdicional.SelectedItem.Value));

            if (adicional.RequiereCantidad == "N")
            {
                if (DropDownListCantidadPersonas.SelectedItem != null)
                {
                    producto.CantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value);

                }
            }
           

            if (DropDownListProveedores.SelectedItem != null)
            {
                producto.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            }


        }

        private void GraboSalon(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListLocacion.SelectedItem != null)
            {
                producto.LocacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value);

            }


            if (DropDownListCantidadPersonas.SelectedItem != null)
            {
                producto.CantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value);

            }



            if (DropDownListSector.SelectedItem != null)
            {
                producto.SectorId = Int32.Parse(DropDownListSector.SelectedItem.Value);

            }


            if (DropDownListJornada.SelectedItem != null)
            {
                producto.JornadaId = Int32.Parse(DropDownListJornada.SelectedItem.Value);

            }


            if (DropDownListAnio.SelectedItem != null)
            {
                producto.Anio = Int32.Parse(DropDownListAnio.SelectedItem.Value);
            }

            if (DropDownListMes.SelectedItem != null)
            {
                producto.Mes = Int32.Parse(DropDownListMes.SelectedItem.Value);
            }

            if (DropDownListDias.SelectedItem != null)
            {
                producto.Dia = DropDownListDias.SelectedItem.Value;
            }


        }

        private void GraboAmbientacion(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListCategorias.SelectedItem != null)
            {
                producto.CategoriaId = Int32.Parse(DropDownListCategorias.SelectedItem.Value);

            }

            if (DropDownListProveedores.SelectedItem != null)
            {
                producto.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            }

            if (DropDownListCantidadPersonas.SelectedItem != null)
            {
                producto.CantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value);

            }

            if (DropDownListLocacion.SelectedItem != null)
            {
                producto.LocacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value);

            }

            if (DropDownListSector.SelectedItem != null)
            {
                producto.SectorId = Int32.Parse(DropDownListSector.SelectedItem.Value);

            }

            if (DropDownListCategorias.SelectedItem != null)
            {
                producto.CategoriaId = Int32.Parse(DropDownListCategorias.SelectedItem.Value);

            }

            if (DropDownListCaracteristica.SelectedItem != null)
            {
                producto.CaracteristicaId = Int32.Parse(DropDownListCaracteristica.SelectedItem.Value);

            }

            if (DropDownListSegmento.SelectedItem != null)
            {
                producto.SegmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value);

            }

            if (DropDownListSemestre.SelectedItem != null)
            {
                producto.Semestre = Int32.Parse(DropDownListSemestre.SelectedItem.Value);
            }

        }

        private void GraboTecnica(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListTipoServicio.SelectedItem != null)
            {
                producto.TipoServicioId = Int32.Parse(DropDownListTipoServicio.SelectedItem.Value);

            }

            if (DropDownListProveedores.SelectedItem != null)
            {
                producto.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            }

            if (DropDownListSegmento.SelectedItem != null)
            {
                producto.SegmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value);

            }

            if (DropDownListAnio.SelectedItem != null)
            {
                producto.Anio = Int32.Parse(DropDownListAnio.SelectedItem.Value);
            }

            if (DropDownListMes.SelectedItem != null)
            {
                producto.Mes = Int32.Parse(DropDownListMes.SelectedItem.Value);
            }

            if (DropDownListDias.SelectedItem != null)
            {
                producto.Dia = DropDownListDias.SelectedItem.Value;
            }

            if (DropDownListLocacion.SelectedItem != null)
            {
                producto.LocacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value);

            }

            if (DropDownListSector.SelectedItem != null)
            {
                producto.SectorId = Int32.Parse(DropDownListSector.SelectedItem.Value);

            }

        }

        private void GraboBarra(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListTipoBarra.SelectedItem != null)
            {
                producto.TipoBarraId = Int32.Parse(DropDownListTipoBarra.SelectedItem.Value);

            }

            if (DropDownListProveedores.SelectedItem != null)
            {
                producto.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            }

            if (DropDownListCantidadPersonas.SelectedItem != null)
            {
                producto.CantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value);

            }
        }

        private void GraboCatering(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListTipoCatering.SelectedItem != null)
            {
                producto.TipoCateringId = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value);

            }

            if (DropDownListProveedores.SelectedItem != null)
            {
                producto.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            }

            if (DropDownListCantidadPersonas.SelectedItem != null)
            {
                producto.CantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value);

            }
        }

        private void GraboOrganizacion(DomainAmbientHouse.Entidades.Productos producto)
        {
            if (DropDownListItemsOrganizacion.SelectedItem != null)
            {
                producto.OrganizacionItemId = Int32.Parse(DropDownListItemsOrganizacion.SelectedItem.Value);

            }

            OrganizacionItems OI = servicios.BuscarItemsOrganizacion(Int32.Parse(DropDownListItemsOrganizacion.SelectedItem.Value));

            if (OI.RequiereCantidad == "N")
            {
                if (DropDownListCantidadPersonas.SelectedItem != null)
                {
                    producto.CantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value);

                }
            }

            if (DropDownListProveedores.SelectedItem != null)
            {
                producto.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Productos/Index.aspx");
        }

        protected void DropDownListUnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListUnidadNegocio.SelectedItem.Value != null)
            {

                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroSalon)
                {
                    DropDownListProveedores.Visible = false;
                }
                else
                {
                    DropDownListProveedores.Visible = true;


                    //List<Proveedores> Prov = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    //DropDownListProveedores.Items.Clear();
                    //DropDownListProveedores.AppendDataBoundItems = true;
                    //DropDownListProveedores.DataSource = Prov.ToList();
                    //DropDownListProveedores.DataTextField = "RazonSocial";
                    //DropDownListProveedores.DataValueField = "Id";
                    //DropDownListProveedores.DataBind();
                }

                CargarListasParaCodigo();
            }


            UpdatePanelProductos.Update();
        }

        private void CargarListasParaCodigo()
        {

            ControlesSegunUN(RubroSalon, RubroCatering, RubroTecnica, RubroBarra, RubroAmbientacion, RubroOrganizacion, RubroAdicional);


            UpdatePanelProductos.Update();
        }

        private void ControlesSegunUN(int RubroSalon, int RubroCatering, int RubroTecnica, int RubroBarra, int RubroAmbientacion, int RubroOrganizacion, int RubroAdicional)
        {

            DropDownListSector.Visible = false;
            DropDownListLocacion.Visible = false;
            DropDownListJornada.Visible = false;
            DropDownListAnio.Visible = false;
            DropDownListMes.Visible = false;
            DropDownListDias.Visible = false;
            DropDownListTipoCatering.Visible = false;
            DropDownListCantidadPersonas.Visible = false;
            DropDownListTipoServicio.Visible = false;
            DropDownListTipoBarra.Visible = false;
            DropDownListCategorias.Visible = false;
            DropDownListSegmento.Visible = false;
            DropDownListProveedores.Visible = false;
            DropDownListAdicional.Visible = false;
            DropDownListCaracteristica.Visible = false;
            DropDownListItemsOrganizacion.Visible = false;
            DropDownListSemestre.Visible = false;

            LabelSector.Visible = false;
            LabelTipoCatering.Visible = false;
            LabelLocacion.Visible = false;
            LabelJornada.Visible = false;
            LabelAnio.Visible = false;
            LabelMes.Visible = false;
            LabelDia.Visible = false;
            LabelCantidadPersonas.Visible = false;
            LabelTipoServicio.Visible = false;
            LabelBarra.Visible = false;
            LabelCategorias.Visible = false;
            LabelSegmento.Visible = false;
            LabelProveedores.Visible = false;
            LabelAdicionales.Visible = false;
            LabelCaracteristica.Visible = false;
            LabelOrganizacion.Visible = false;
            LabelSemestre.Visible = false;

            if (DropDownListUnidadNegocio.SelectedItem.Value != "null")
            {

                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroSalon)
                {
                    LetraCodigo = "L";
                    DropDownListSector.Visible = true;
                    DropDownListLocacion.Visible = true;
                    DropDownListJornada.Visible = true;
                    DropDownListAnio.Visible = true;
                    DropDownListMes.Visible = true;
                    DropDownListDias.Visible = true;
                    DropDownListCantidadPersonas.Visible = true;

                    LabelSector.Visible = true;
                    LabelLocacion.Visible = true;
                    LabelJornada.Visible = true;
                    LabelAnio.Visible = true;
                    LabelMes.Visible = true;
                    LabelDia.Visible = true;
                    LabelCantidadPersonas.Visible = true;



                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroCatering)
                {
                    LetraCodigo = "C";
                    DropDownListTipoCatering.Visible = true;
                    DropDownListCantidadPersonas.Visible = true;
                    DropDownListProveedores.Visible = true;

                    LabelTipoCatering.Visible = true;
                    LabelCantidadPersonas.Visible = true;
                    LabelProveedores.Visible = true;

                    List<Proveedores> Prov = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroBarra)
                {
                    LetraCodigo = "B";
                    DropDownListTipoBarra.Visible = true;
                    DropDownListCantidadPersonas.Visible = true;
                    DropDownListProveedores.Visible = true;

                    LabelCantidadPersonas.Visible = true;
                    LabelBarra.Visible = true;
                    LabelProveedores.Visible = true;

                    List<Proveedores> Prov = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroTecnica)
                {
                    LetraCodigo = "T";
                    DropDownListTipoServicio.Visible = true;
                    DropDownListSegmento.Visible = true;
                    DropDownListProveedores.Visible = true;
                    DropDownListAnio.Visible = true;
                    DropDownListMes.Visible = true;
                    DropDownListDias.Visible = true;
                    DropDownListSector.Visible = true;
                    DropDownListLocacion.Visible = true;

                    LabelTipoServicio.Visible = true;
                    LabelSegmento.Visible = true;
                    LabelProveedores.Visible = true;
                    LabelAnio.Visible = true;
                    LabelMes.Visible = true;
                    LabelDia.Visible = true;
                    LabelSector.Visible = true;
                    LabelLocacion.Visible = true;

                    List<Proveedores> Prov = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroAmbientacion)
                {
                    LetraCodigo = "A";
                    DropDownListCategorias.Visible = true;
                    DropDownListCantidadPersonas.Visible = true;
                    DropDownListProveedores.Visible = true;
                    DropDownListSector.Visible = true;
                    DropDownListLocacion.Visible = true;
                    DropDownListCaracteristica.Visible = true;
                    DropDownListSegmento.Visible = true;
                    DropDownListSemestre.Visible = true;
                    DropDownListAnio.Visible = true;

                    LabelCantidadPersonas.Visible = true;
                    LabelCategorias.Visible = true;
                    LabelProveedores.Visible = true;
                    LabelSector.Visible = true;
                    LabelLocacion.Visible = true;
                    LabelSegmento.Visible = true;
                    LabelCaracteristica.Visible = true;
                    LabelSemestre.Visible = true;
                    LabelAnio.Visible = true;

                    List<Proveedores> Prov = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroAdicional)
                {
                    LetraCodigo = "AD";

                    DropDownListProveedores.Visible = true;
                    DropDownListAdicional.Visible = true;
                    DropDownListCantidadPersonas.Visible = true;


                    LabelCantidadPersonas.Visible = true;
                    LabelAdicionales.Visible = true;
                    LabelProveedores.Visible = true;

                    Adicionales adicional = servicioEventos.BuscarAdicional(Int32.Parse(DropDownListAdicional.SelectedItem.Value));



                    if (adicional.RequiereCantidad == "S")
                    {
                        DropDownListCantidadPersonas.Visible = false;
                        LabelCantidadPersonas.Visible = false;
                    }
                    else
                    {
                        DropDownListCantidadPersonas.Visible = true;
                        LabelCantidadPersonas.Visible = true;
                    }

                    List<int> Un = new List<int>() { RubroCatering, RubroBarra, RubroTecnica, RubroAmbientacion };

                    List<Proveedores> Prov = servicioEventos.TraerProveedores(Un);

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroOrganizacion)
                {
                    LetraCodigo = "O";

                    DropDownListItemsOrganizacion.Visible = true;
                    DropDownListProveedores.Visible = true;

                    LabelOrganizacion.Visible = true;
                    LabelProveedores.Visible = true;


                    OrganizacionItems OI = servicios.BuscarItemsOrganizacion(Int32.Parse(DropDownListItemsOrganizacion.SelectedItem.Value));


                    if (OI.RequiereCantidad == "S")
                    {
                        DropDownListCantidadPersonas.Visible = false;
                        LabelCantidadPersonas.Visible = false;
                    }
                    else
                    {
                        DropDownListCantidadPersonas.Visible = true;
                        LabelCantidadPersonas.Visible = true;
                    }

                    List<Proveedores> Prov = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                    FormarCodigoOrganizacion();
                }
            }
        }

        protected void DropDownListLocacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListLocacion.SelectedItem.Value != null)
            {

                int seleccionado = Int32.Parse(this.DropDownListLocacion.SelectedItem.Value.ToString());


                DropDownListSector.DataSource = servicioEventos.BuscarSectoresPorLocacion(seleccionado);
                DropDownListSector.DataTextField = "Descripcion";
                DropDownListSector.DataValueField = "Id";
                DropDownListSector.DataBind();

                UpdatePanelProductos.Update();

                //DateTime fechaSeleccionada = DateTime.ParseExact(TextBoxFechaCodigo.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
                {
                    FormarCodigoSalon();
                    FormarDescripcionSalon();
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
                {
                    FormarCodigoTecnica();
                    FormarDescripcionTecnica();
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
                {
                    FormarCodigoAmbientacion();
                    FormarDescripcionAmbientacion();
                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAdicional)
                {
                    FormarCodigoAdicional();
                }


            }
        }

        protected void DropDownListTipoCatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoCatering();

            FormarDescripcionCatering();
        }

        protected void DropDownListCantidadPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroCatering)
            {
                FormarCodigoCatering();

                FormarDescripcionCatering();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroBarra)
            {

                FormarCodigoBarra();
                FormarDescripcionBarra();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
            {
                FormarCodigoSalon();
                FormarDescripcionSalon();

            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
            {
                FormarCodigoAmbientacion();
                FormarDescripcionAmbientacion();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAdicional)
            {
                FormarCodigoAdicional();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroOrganizacion)
            {
                FormarCodigoOrganizacion();
            }
        }

        protected void DropDownListProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroCatering)
            {
                FormarCodigoCatering();

                FormarDescripcionCatering();

            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
            {
                FormarCodigoTecnica();

                FormarDescripcionTecnica();

            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
            {
                FormarCodigoAmbientacion();

                FormarDescripcionAmbientacion();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroBarra)
            {
                FormarCodigoBarra();

                FormarDescripcionBarra();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAdicional)
            {

                FormarCodigoAdicional();

            }

        }

        protected void DropDownListSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
            {
                FormarCodigoSalon();
                FormarDescripcionSalon();

            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
            {
                FormarCodigoTecnica();
                FormarDescripcionTecnica();

            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
            {
                FormarCodigoAmbientacion();
                FormarDescripcionAmbientacion();

            }
        }

        protected void DropDownListJornada_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoSalon();
            FormarDescripcionSalon();

        }

        protected void DropDownListTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoTecnica();
            FormarDescripcionTecnica();


        }

        protected void DropDownListSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoTecnica();
            FormarDescripcionTecnica();

         

        }

  

        protected void TextBoxFechaCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListTipoBarra_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoBarra();
            FormarDescripcionBarra();
        }

        protected void DropDownListCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoAmbientacion();

            FormarDescripcionAmbientacion();

        }

        protected void DropDownListAdicional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListAdicional.SelectedItem != null)
            {

                FormarCodigoAdicional();

            }

        }

        protected void DropDownListAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
            {
                FormarCodigoSalon();
                FormarDescripcionSalon();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
            {
                FormarCodigoTecnica();
                FormarDescripcionTecnica();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroAmbientacion)
            {
                FormarCodigoAmbientacion();
                FormarDescripcionAmbientacion();
            }

        }

        protected void DropDownListMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
            {
                FormarCodigoSalon();

                FormarDescripcionSalon();

            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
            {
                FormarCodigoTecnica();
                FormarDescripcionTecnica();

            }
        }

        protected void DropDownListDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroSalon)
            {
                FormarCodigoSalon();

                FormarDescripcionSalon();
            }
            else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == RubroTecnica)
            {
                FormarCodigoTecnica();

                FormarDescripcionTecnica();
            }
        }

        private void FormarCodigoSalon()
        {
            TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListLocacion.SelectedItem.Value.ToString() + "S" + DropDownListSector.SelectedItem.Value.ToString() + "J" + DropDownListJornada.SelectedItem.Value.ToString() + DropDownListAnio.SelectedItem.Value.ToString() + Int32.Parse(DropDownListMes.SelectedItem.Value).ToString() + DropDownListDias.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
        }

        private void FormarDescripcionSalon()
        {
            TextBoxDescripcion.Text = DropDownListLocacion.SelectedItem.Text.ToString() + " " + DropDownListDias.SelectedItem.Text.ToString() + " " + DropDownListMes.SelectedItem.Text.ToString() + " " + DropDownListAnio.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString();
        }

        private void FormarCodigoTecnica()
        {
            TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListTipoServicio.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "S" + DropDownListSegmento.SelectedItem.Value.ToString()
               + DropDownListAnio.SelectedItem.Value.ToString() + Int32.Parse(DropDownListMes.SelectedItem.Value).ToString() + DropDownListDias.SelectedItem.Value.ToString() + "S" + DropDownListSector.SelectedItem.Value.ToString();
        }

        private void FormarDescripcionTecnica()
        {
            //(ts.Descripcion + ' ' + Cast(Dia as Varchar) + ' ' + Cast(Mes as Varchar) + ' ' + Cast(c.Anio as Varchar) + P.RazonSocial)
            TextBoxDescripcion.Text = DropDownListTipoServicio.SelectedItem.Text.ToString() + " " + DropDownListDias.SelectedItem.Text.ToString()
                + " " + DropDownListMes.SelectedItem.Text.ToString() + " " + DropDownListAnio.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString() + " " + DropDownListSector.SelectedItem.Text.ToString();

        }

        private void FormarCodigoAmbientacion()
        {
            TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListCategorias.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString() + "S" + DropDownListSector.SelectedItem.Value.ToString() + "SE" + DropDownListSemestre.SelectedItem.Value.ToString() + DropDownListAnio.SelectedItem.Value.ToString(); 
        }

        private void FormarDescripcionAmbientacion()
        {
            TextBoxDescripcion.Text = DropDownListCategorias.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString() + " " + DropDownListSector.SelectedItem.Text.ToString();
        }

        private void FormarCodigoCatering()
        {
            TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListTipoCatering.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
        }

        private void FormarDescripcionCatering()
        {
            //(t.Descripcion + ' ' + CAST(CantidadPersonas as Varchar) + ' ' + P.RazonSocial)

            TextBoxDescripcion.Text = DropDownListTipoCatering.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString();

        }

        private void FormarCodigoBarra()
        {
            TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListTipoBarra.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
        }

        private void FormarDescripcionBarra()
        {
            //(t.Descripcion + ' ' + CAST(CantidadPersonas as Varchar) + ' ' + P.RazonSocial)

            TextBoxDescripcion.Text = DropDownListTipoBarra.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString();

        }

        private void FormarCodigoAdicional()
        {
            DropDownListLocacion.Visible = false;
            LabelLocacion.Visible = false;

            DropDownListCantidadPersonas.Visible = false;
            LabelCantidadPersonas.Visible = false;

            DropDownListProveedores.Visible = false;
            LabelProveedores.Visible = false;

            Adicionales adicional = servicioEventos.BuscarAdicional(Int32.Parse(DropDownListAdicional.SelectedItem.Value));

            if (adicional.RubroId == RubroSalon)
            {

                DropDownListLocacion.Visible = true;
                LabelLocacion.Visible = true;

                if (adicional.RequiereCantidad == "S")
                {

                    TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListAdicional.SelectedItem.Value.ToString() + "P0" + "L" + DropDownListLocacion.SelectedItem.Value.ToString() + "I1";
                    FormarDescripcionAdicionalSalonRequiereCantidad();

                }
                else if (adicional.RequiereCantidadRango == "S")
                {
                    DropDownListCantidadPersonas.Visible = true;
                    LabelCantidadPersonas.Visible = true;

                    TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListAdicional.SelectedItem.Value.ToString() + "P0" + "L" + DropDownListLocacion.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
                    FormarDescripcionAdicionalSalon();
                }
                else
                {
                    DropDownListCantidadPersonas.Visible = true;
                    LabelCantidadPersonas.Visible = true;

                    TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListAdicional.SelectedItem.Value.ToString() + "P0" + "L" + DropDownListLocacion.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
                    FormarDescripcionAdicionalSalon();

                }
            }
            else
            {
                DropDownListProveedores.Visible = true;
                LabelProveedores.Visible = true;

                if (adicional.RequiereCantidad == "S")
                {
                    TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListAdicional.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "L0" + "I1";
                    FormarDescripcionAdicionalRequiereCantidad();
                }

                else if (adicional.RequiereCantidadRango == "S")
                {
                    DropDownListCantidadPersonas.Visible = true;
                    LabelCantidadPersonas.Visible = true;

                    TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListAdicional.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "L0" + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
                    FormarDescripcionAdicional();

                }

                else
                {
                    DropDownListCantidadPersonas.Visible = true;
                    LabelCantidadPersonas.Visible = true;

                    TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListAdicional.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "L0" + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
                    FormarDescripcionAdicional();

                }
            }
        }

        private void FormarDescripcionAdicionalSalonRequiereCantidad()
        {
            TextBoxDescripcion.Text = DropDownListAdicional.SelectedItem.Text.ToString() + " 1 " + DropDownListLocacion.SelectedItem.Text.ToString();
        }

        private void FormarDescripcionAdicionalSalon()
        {
            TextBoxDescripcion.Text = DropDownListAdicional.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString() + " " + DropDownListLocacion.SelectedItem.Text.ToString();
        }

        private void FormarDescripcionAdicionalRequiereCantidad()
        {
            TextBoxDescripcion.Text = DropDownListAdicional.SelectedItem.Text.ToString() + " 1 " + DropDownListProveedores.SelectedItem.Text.ToString();
        }

        private void FormarCodigoOrganizacion()
        {
            OrganizacionItems OI = servicios.BuscarItemsOrganizacion(Int32.Parse(DropDownListItemsOrganizacion.SelectedItem.Value));

            if (OI.RequiereCantidad == "S")
            {
                TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListItemsOrganizacion.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "I1";
                TextBoxDescripcion.Text = DropDownListItemsOrganizacion.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString();

                DropDownListCantidadPersonas.Visible = false;
                LabelCantidadPersonas.Visible = false;
            }
            else
            {
                DropDownListCantidadPersonas.Visible = true;
                LabelCantidadPersonas.Visible = true;

                TextBoxCodigo.Text = LetraCodigo.ToString() + DropDownListItemsOrganizacion.SelectedItem.Value.ToString() + "P" + DropDownListProveedores.SelectedItem.Value.ToString() + "I" + DropDownListCantidadPersonas.SelectedItem.Value.ToString();
                FormarDescripcionOrganizacion();
            }

        }

        private void FormarDescripcionAdicional()
        {
            TextBoxDescripcion.Text = DropDownListAdicional.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString();
        }

        private void FormarDescripcionOrganizacion()
        {
            TextBoxDescripcion.Text = DropDownListItemsOrganizacion.SelectedItem.Text.ToString() + " " + DropDownListProveedores.SelectedItem.Text.ToString() + " " + DropDownListCantidadPersonas.SelectedItem.Text.ToString();
        }

        protected void DropDownListCaracteristica_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoAmbientacion();
            FormarDescripcionAmbientacion();
        }

        protected void DropDownListItemsOrganizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoOrganizacion();
        }

        protected void DropDownListSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormarCodigoAmbientacion();
            FormarDescripcionAmbientacion();
        }

    }
}
