using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Productos
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios servicioEventos = new EventosServicios();

        Comun cmd = new Comun();

        private List<DomainAmbientHouse.Entidades.Productos> ListProductos
        {
            get
            {
                return Session["ListProductos"] as List<DomainAmbientHouse.Entidades.Productos>;
            }
            set
            {
                Session["ListProductos"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListProductos = new List<DomainAmbientHouse.Entidades.Productos>();

                CargarListas();

                CargarListasParaCodigo();


                //int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());

                //if (Int32.Parse(DropDownListEstados.SelectedItem.Value) == activo)
                //    ButtonInactivar.Visible = true;
                //else
                //    ButtonActivar.Visible = true;

                //UpdatePanelFiltros.Update();
            }

        }

        //private void CargarGrilla()
        //{
        //    GridViewProductos.DataSource = servicios.ObtenerProductos();
        //    GridViewProductos.DataBind();
        //}

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Administracion/Productos/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProductos.PageIndex = e.NewPageIndex;
            Buscar();
        }

        private void CargarListas()
        {
            DropDownListUnidadNegocio.DataSource = servicios.ObtenerUN();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();


            DropDownListLocacion.DataSource = servicioEventos.TraerLocaciones();
            DropDownListLocacion.DataTextField = "Descripcion";
            DropDownListLocacion.DataValueField = "Id";
            DropDownListLocacion.DataBind();

            DropDownListOrganizacion.DataSource = servicios.ObtenerItemsOrganizacion();
            DropDownListOrganizacion.DataTextField = "Descripcion";
            DropDownListOrganizacion.DataValueField = "Id";
            DropDownListOrganizacion.DataBind();

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

            List<ObtenerCantidadInvitadosCatering> Cantidades = servicioEventos.TraerCantidadPersonasCatering();

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

            cmd.CargarAnios(DropDownListAnio);
            cmd.CargarMeses(DropDownListMes);
            cmd.CargarDias(DropDownListDia);


            DropDownListEstados.DataSource = servicios.BuscarEstadosPorEntidad("Productos");
            DropDownListEstados.DataTextField = "Descripcion";
            DropDownListEstados.DataValueField = "Id";
            DropDownListEstados.DataBind();

        }

        protected void DropDownListUnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListasParaCodigo();
        }

        private void CargarListasParaCodigo()
        {


            int RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            int RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            int RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

            DropDownListSector.Visible = false;
            DropDownListLocacion.Visible = false;
            DropDownListJornada.Visible = false;
            DropDownListAnio.Visible = false;
            DropDownListMes.Visible = false;
            DropDownListDia.Visible = false;
            DropDownListTipoCatering.Visible = false;
            DropDownListCantidadPersonas.Visible = false;
            DropDownListTipoServicio.Visible = false;
            DropDownListTipoBarra.Visible = false;
            DropDownListCategorias.Visible = false;
            DropDownListSegmento.Visible = false;
            DropDownListProveedores.Visible = false;
            DropDownListAdicional.Visible = false;
            DropDownListCaracteristica.Visible = false;
            DropDownListOrganizacion.Visible = false;
            DropDownListSemestre.Visible = false;

            LabelAdicional.Visible = false;
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
            LabelCaracteristica.Visible = false;
            LabelOrganizacion.Visible = false;
            LabelSemestre.Visible = false;

            DropDownListSector.SelectedItem.Value = "null";
            DropDownListLocacion.SelectedItem.Value = "null";
            DropDownListJornada.SelectedItem.Value = "null";
            DropDownListAnio.SelectedItem.Value = "null";
            DropDownListMes.SelectedItem.Value = "null";
            DropDownListDia.SelectedItem.Value = "null";
            DropDownListCantidadPersonas.SelectedItem.Value = "null";
            DropDownListTipoServicio.SelectedItem.Value = "null";
            DropDownListTipoBarra.SelectedItem.Value = "null";
            DropDownListCategorias.SelectedItem.Value = "null";
            DropDownListSegmento.SelectedItem.Value = "null";
            DropDownListProveedores.SelectedItem.Value = "null";
            DropDownListTipoCatering.SelectedItem.Value = "null";
            DropDownListCaracteristica.SelectedItem.Value = "null";
            DropDownListOrganizacion.SelectedItem.Value = "null";
            DropDownListAdicional.SelectedItem.Value = "null";
            DropDownListSemestre.SelectedItem.Value = "null";

            if (DropDownListUnidadNegocio.SelectedItem.Value != null)
            {


                List<DomainAmbientHouse.Entidades.Proveedores> ProvUn = servicioEventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

                DropDownListProveedores.Items.Clear();
                DropDownListProveedores.AppendDataBoundItems = true;

                ListItem nulo = new ListItem();

                nulo.Text = "Seleccione un Proveedor";
                nulo.Value = "null";

                DropDownListProveedores.Items.Add(nulo);
                DropDownListProveedores.DataSource = ProvUn.ToList();
                DropDownListProveedores.DataTextField = "RazonSocial";
                DropDownListProveedores.DataValueField = "Id";
                DropDownListProveedores.DataBind();


                if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroSalon)
                {
                    LetraCodigo = "L";
                    DropDownListSector.Visible = true;
                    DropDownListLocacion.Visible = true;
                    DropDownListJornada.Visible = true;
                    DropDownListAnio.Visible = true;
                    DropDownListMes.Visible = true;
                    DropDownListDia.Visible = true;
                    DropDownListCantidadPersonas.Visible = true;

                    LabelSector.Visible = true;
                    LabelLocacion.Visible = true;
                    LabelJornada.Visible = true;
                    LabelAnio.Visible = true;
                    LabelMes.Visible = true;
                    LabelDia.Visible = true;
                    LabelCantidadPersonas.Visible = true;

                    ListItem oitem = new ListItem();

                    oitem.Text = "Seleccione un Proveedor";
                    oitem.Value = "null";

                    DropDownListProveedores.Items.Add(oitem);

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

                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroTecnica)
                {
                    LetraCodigo = "T";
                    DropDownListTipoServicio.Visible = true;
                    DropDownListSegmento.Visible = true;
                    DropDownListProveedores.Visible = true;
                    DropDownListAnio.Visible = true;
                    DropDownListMes.Visible = true;
                    DropDownListDia.Visible = true;
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


                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroAdicional)
                {
                    LetraCodigo = "AD";

                    DropDownListProveedores.Visible = true;
                    LabelProveedores.Visible = true;

                    DropDownListAdicional.Visible = true;
                    LabelAdicional.Visible = true;


                    List<int> Un = new List<int>() { RubroCatering, RubroBarra, RubroTecnica, RubroAmbientacion };

                    List<DomainAmbientHouse.Entidades.Proveedores> Prov = servicioEventos.TraerProveedores(Un);

                    DropDownListProveedores.Items.Clear();
                    DropDownListProveedores.AppendDataBoundItems = true;
                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();

                    ListItem oitem = new ListItem();

                    oitem.Text = "Seleccione un Proveedor";
                    oitem.Value = "null";

                    DropDownListProveedores.Items.Add(oitem);

                    DropDownListProveedores.SelectedValue = "null";


                }
                else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()) == RubroOrganizacion)
                {
                    LetraCodigo = "O";

                    DropDownListOrganizacion.Visible = true;
                    DropDownListProveedores.Visible = true;

                    LabelOrganizacion.Visible = true;
                    LabelProveedores.Visible = true;

                    ListItem oitem = new ListItem();

                    oitem.Text = "Seleccione un Proveedor";
                    oitem.Value = "null";

                    DropDownListProveedores.Items.Add(oitem);
                }
            }


            UpdatePanelFiltros.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {

            Buscar();

        }

        private void Buscar()
        {
            int unidadNegocioId = 0;
            int tipoCatering = 0;
            int tipoBarra = 0;
            int tipoServicio = 0;
            int categoriaId = 0;
            int cantidadInvitados = 0;
            int locacionId = 0;
            int sectorId = 0;
            int jornadaId = 0;
            int segmentoId = 0;
            int caracteristicaId = 0;
            int proveedorId = 0;
            int Anio = 0;
            int Mes = 0;
            string Dia;
            int adicionalId = 0;
            int estadoId = Int32.Parse(DropDownListEstados.SelectedItem.Value);
            int itemOrganizacionId = 0;
            int semestreId = 0;



            Filtros(out unidadNegocioId, out tipoCatering, out tipoBarra, out tipoServicio, out categoriaId, out cantidadInvitados, out locacionId, out sectorId, out jornadaId, out segmentoId, out proveedorId, out Anio, out Mes, out Dia, out adicionalId, out caracteristicaId, out itemOrganizacionId, out semestreId);


            ListProductos = servicios.BuscarProductosPorFiltros(unidadNegocioId, tipoCatering, tipoBarra, tipoServicio, categoriaId, cantidadInvitados,
                                                                                                            locacionId, sectorId, segmentoId, jornadaId, proveedorId,
                                                                                                            Anio, Mes, Dia, adicionalId, estadoId, caracteristicaId, itemOrganizacionId, semestreId);


            GridViewProductos.DataSource = ListProductos.ToList();
            GridViewProductos.DataBind();


            UpdatePanelGrillaProductos.Update();
        }

        private void Filtros(out int unidadNegocioId, out int tipoCatering, out int tipoBarra, out int tipoServicio, out int categoriaId, out int cantidadInvitados,
                            out int locacionId, out int sectorId, out int jornadaId, out int segmentoId, out int proveedorId, out int Anio,
                            out int Mes, out string Dia, out int adicionalId, out int caracteristicaId, out int organizacionItemId, out int semestreId)
        {

            unidadNegocioId = 0;
            if (DropDownListUnidadNegocio.SelectedItem.Value != "null")
            { unidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value); }

            tipoCatering = 0;
            if (DropDownListTipoCatering.SelectedItem.Value != "null")
            { tipoCatering = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value); }

            tipoBarra = 0;
            if (DropDownListTipoBarra.SelectedItem.Value != "null")
            { tipoBarra = Int32.Parse(DropDownListTipoBarra.SelectedItem.Value); }


            tipoServicio = 0;
            if (DropDownListTipoServicio.SelectedItem.Value != "null")
            { tipoServicio = Int32.Parse(DropDownListTipoServicio.SelectedItem.Value); }

            categoriaId = 0;
            if (DropDownListCategorias.SelectedItem.Value != "null")
            { categoriaId = Int32.Parse(DropDownListCategorias.SelectedItem.Value); }

            cantidadInvitados = 0;
            if (DropDownListCantidadPersonas.SelectedItem.Value != "null")
            { cantidadInvitados = Int32.Parse(DropDownListCantidadPersonas.SelectedItem.Value); }

            locacionId = 0;
            if (DropDownListLocacion.SelectedItem.Value != "null")
            { locacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value); }


            sectorId = 0;
            if (DropDownListSector.SelectedItem.Value != "null")
            { sectorId = Int32.Parse(DropDownListSector.SelectedItem.Value); }

            jornadaId = 0;
            if (DropDownListJornada.SelectedItem.Value != "null")
            { jornadaId = Int32.Parse(DropDownListJornada.SelectedItem.Value); }

            segmentoId = 0;
            if (DropDownListSegmento.SelectedItem.Value != "null")
            { segmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value); }

            proveedorId = 0;
            if (DropDownListProveedores.SelectedItem.Value != "null")
            { proveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value); }


            Anio = 0;
            if (DropDownListAnio.SelectedItem.Value != "null")
            { Anio = Int32.Parse(DropDownListAnio.SelectedItem.Value); }

            Mes = 0;
            if (DropDownListMes.SelectedItem.Value != "null")
            { Mes = Int32.Parse(DropDownListMes.SelectedItem.Value); }

            Dia = null;
            if (DropDownListDia.SelectedItem.Value != "null")
            { Dia = DropDownListDia.SelectedItem.Value; }

            adicionalId = 0;
            if (DropDownListAdicional.SelectedItem.Value != "null")
            { adicionalId = Int32.Parse(DropDownListAdicional.SelectedItem.Value); }

            caracteristicaId = 0;
            if (DropDownListCaracteristica.SelectedItem.Value != "null")
            { caracteristicaId = Int32.Parse(DropDownListCaracteristica.SelectedItem.Value); }

            organizacionItemId = 0;
            if (DropDownListOrganizacion.SelectedItem.Value != "null")
            { organizacionItemId = Int32.Parse(DropDownListOrganizacion.SelectedItem.Value); }

            semestreId = 0;
            if (DropDownListSemestre.SelectedItem.Value != "null")
            { semestreId = Int32.Parse(DropDownListSemestre.SelectedItem.Value); }

        }

        protected void DropDownListLocacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListLocacion.SelectedItem.Value != "null")
            {
                int seleccionado = Int32.Parse(this.DropDownListLocacion.SelectedItem.Value.ToString());

                DropDownListSector.Items.Clear();
                DropDownListSector.DataSource = servicioEventos.BuscarSectoresPorLocacion(seleccionado);
                DropDownListSector.DataTextField = "Descripcion";
                DropDownListSector.DataValueField = "Id";
                DropDownListSector.DataBind();

                ListItem oitem = new ListItem();

                oitem.Text = "Seleccione un Sector";
                oitem.Value = "null";

                DropDownListSector.Items.Add(oitem);
            }
            else
            {
                DropDownListSector.Items.Clear();
                DropDownListSector.SelectedValue = "null";
            }

            UpdatePanelFiltros.Update();
        }

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
            double ValorPrecio = 0;
            double ValorCosto = 0;
            double PorcentajePrecio = 0;
            double PorcentajeCosto = 0;

            double Margen = 0;

            int unidadNegocioId;
            int tipoCatering;
            int tipoBarra;
            int tipoServicio;
            int categoriaId;
            int cantidadInvitados;
            int locacionId;
            int sectorId;
            int jornadaId;
            int segmentoId;
            int caracteristicaId;
            int proveedorId;
            int Anio;
            int Mes;
            string Dia;
            int adicionalId;
            int itemOrganizacionId;
            int semestreId;

            Filtros(out unidadNegocioId, out tipoCatering, out tipoBarra, out tipoServicio, out categoriaId, out cantidadInvitados, out locacionId, out sectorId, out jornadaId, out segmentoId, out proveedorId, out Anio, out Mes, out Dia, out adicionalId, out caracteristicaId, out itemOrganizacionId, out semestreId);


            if (RadioButtonValor.Checked)
            {
                if (cmd.IsNumeric(TextBoxPrecio.Text))
                {
                    ValorPrecio = cmd.ValidarImportes(TextBoxPrecio.Text);
                }

                if (cmd.IsNumeric(TextBoxCosto.Text))
                {
                    ValorCosto = cmd.ValidarImportes(TextBoxCosto.Text);
                }
            }
            else
            {
                if (cmd.IsNumeric(TextBoxPrecio.Text))
                {
                    PorcentajePrecio = (cmd.ValidarImportes(TextBoxPrecio.Text) / 100) + 1;
                }

                if (cmd.IsNumeric(TextBoxCosto.Text))
                {
                    PorcentajeCosto = (cmd.ValidarImportes(TextBoxCosto.Text) / 100 + 1);
                }
            }

            if (cmd.IsNumeric(TextBoxMargen.Text))
            {

                Margen = double.Parse(TextBoxMargen.Text);

            }

            servicios.ActualizarPrecioCostoProductos(ListProductos, ValorCosto, ValorPrecio, PorcentajeCosto, PorcentajePrecio, Margen);

            Buscar();

            TextBoxCosto.Text = "";
            TextBoxPrecio.Text = "";
            TextBoxMargen.Text = "";

            UpdatePanelGrillaProductos.Update();
        }

        protected void GridViewProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Precio = (TextBox)e.Row.FindControl("TextBoxPrecio");
                TextBox Costo = (TextBox)e.Row.FindControl("TextBoxCosto");
                TextBox Margen = (TextBox)e.Row.FindControl("TextBoxMargen");
                TextBox Fecha = (TextBox)e.Row.FindControl("TextBoxFecha");


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");

                int ProductoId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Productos producto = servicios.BuscarProducto(ProductoId);

                Precio.Text = producto.Precio.ToString();
                Costo.Text = producto.Costo.ToString();
                Margen.Text = producto.Margen.ToString();
                if (producto.FechaVendimiento != null)
                    Fecha.Text = String.Format("{0:dd/MM/yyyy}", producto.FechaVendimiento);



                Estados.DataSource = servicios.BuscarEstadosPorEntidad("Productos");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();


                Estados.SelectedValue = producto.Estado.ToString();
            }
        }

        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewProductos.Rows[index];

                TextBox precio = row.FindControl("TextBoxPrecio") as TextBox;
                TextBox costo = row.FindControl("TextBoxCosto") as TextBox;
                TextBox margen = row.FindControl("TextBoxMargen") as TextBox;
                TextBox fecha = row.FindControl("TextBoxFecha") as TextBox;

                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;

                int ProductoId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Productos producto = servicios.BuscarProducto(ProductoId);

                double dCosto = 0;
                double dPrecio = 0;
                double dMargen = 0;

                if (cmd.IsNumeric(costo.Text))
                    dCosto = cmd.ValidarImportes(costo.Text);

                if (cmd.IsNumeric(precio.Text))
                    dPrecio = cmd.ValidarImportes(precio.Text);

                if (cmd.IsNumeric(margen.Text))
                    dMargen = double.Parse(margen.Text);

                if ((int)producto.Precio != (int)double.Parse(precio.Text))
                {
                    producto.Precio = dPrecio;
                    producto.Costo = dCosto;
                    producto.Margen = dPrecio / dCosto;
                }
                else if ((int)producto.Costo != (int)double.Parse(costo.Text))
                {
                    producto.Costo = dCosto;
                    producto.Precio = dCosto * (double)producto.Margen;

                }
                else
                {
                    producto.Precio = dCosto * dMargen;
                    producto.Costo = dCosto;
                    producto.Margen = dMargen;
                }

                producto.Estado = Int32.Parse(Estados.SelectedItem.Value);

                if (fecha.Text == "")
                    producto.FechaVendimiento = null;
                else
                {
                    DateTime fechaSeleccionadaVencimiento = DateTime.ParseExact(fecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    producto.FechaVendimiento = fechaSeleccionadaVencimiento;

                }

                try
                {
                    servicios.ActualizarProducto(producto);
                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();
            UpdatePanelGrillaProductos.Update();
        }

        protected void GridViewProductos_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridViewProductos.DataSource = ListProductos.OrderBy(o => o.Id);
            GridViewProductos.DataBind();
        }

        protected void ButtonInactivar_Click(object sender, EventArgs e)
        {
            int inactivo = Int32.Parse(ConfigurationManager.AppSettings["ProductoInactivo"].ToString());

            if (ListProductos.Count > 0)
                servicios.InactivarProductos(ListProductos, inactivo);

            UpdatePanelGrillaProductos.Update();
        }

        protected void ButtonActivar_Click(object sender, EventArgs e)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());

            if (ListProductos.Count > 0)
                servicios.InactivarProductos(ListProductos, activo);

            UpdatePanelGrillaProductos.Update();
        }

        protected void DropDownListAdicional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListAdicional.SelectedItem != null)
            {

                DomainAmbientHouse.Entidades.Adicionales adicional = servicioEventos.BuscarAdicional(Int32.Parse(DropDownListAdicional.SelectedItem.Value));

                if (adicional.RequiereCantidad == "S")
                {
                    LabelCantidadPersonas.Visible = false;
                    DropDownListCantidadPersonas.Visible = false;
                }

                //if (adicional.RubroId == RubroSalon)
                //{
                //    DropDownListLocacion.Visible = true;
                //    DropDownListProveedores.Visible = false;

                //}
                //else
                //{
                //    DropDownListProveedores.Visible = true;
                //    DropDownListLocacion.Visible = false;
                //}


            }
        }

    }
}