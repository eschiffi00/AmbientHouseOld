using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.PedidosCotizacion
{
    public partial class Editar : System.Web.UI.Page
    {
        EventosServicios eventos = new EventosServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();

        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.PedidosCotizacion PedidosCotizacionSeleccionado
        {
            get
            {
                return Session["PedidosCotizacionSeleccionado"] as DomainAmbientHouse.Entidades.PedidosCotizacion;
            }
            set
            {
                Session["PedidosCotizacionSeleccionado"] = value;
            }
        }

        private int PedidosCotizacionId
        {
            get
            {
                return Int32.Parse(Session["PedidosCotizacionId"].ToString());
            }
            set
            {
                Session["PedidosCotizacionId"] = value;
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

        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                PanelLocacion.Visible = false;
                PanelTecnica.Visible = false;
                PanelAmbientacion.Visible = false;

                //CargarListas();

                //ObtenerLocacionesFiltradas();

                //InicializarPagina();
            }
        }

        //private void InicializarPagina()
        //{
        //    int id = 0;

        //    if (Request["Id"] != null)
        //    {
        //        id = Int32.Parse(Request["Id"]);
        //        PedidosCotizacionId =  id;
        //    }

        //    int PerfilEjecutivo = int.Parse(ConfigurationManager.AppSettings["Ejecutivo"].ToString());
        //    int PerfilAdministracion = int.Parse(ConfigurationManager.AppSettings["Administracion"].ToString());


        //    if (PerfilId == PerfilEjecutivo)
        //        PanelCostos.Visible = false;
        //    else
        //        PanelCostos.Visible = true;

        //    if (id == 0)
        //        NuevoPedidoCotizacion();
        //    else
        //        EditarPedidoCotizacion(id);


        //}

        //private void EditarPedidoCotizacion(int id)
        //{
        //    DomainAmbientHouse.Entidades.PedidosCotizacion pedido = new DomainAmbientHouse.Entidades.PedidosCotizacion();

        //    pedido = eventos.BuscarPedidoCotizacion(id);

        //    PedidosCotizacionSeleccionado = pedido;

        //    DropDownListUnidadNegocio.SelectedValue = pedido.UnidadNegocioId.ToString();

        //    if (pedido.UnidadNegocioId == 1)
        //    {
        //        PanelAmbientacion.Visible = true;

        //        DropDownListLocacionAmbientacion.SelectedValue = pedido.LocacionId.ToString();

        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocacionAmbientacion.SelectedItem.Value), DropDownListSectorAmbientacion);

        //        DropDownListSectorAmbientacion.SelectedValue = pedido.SectorId.ToString();
        //        DropDownListSegmentosAmbientacion.SelectedValue = pedido.SegmentoId.ToString();
        //        DropDownListCaracteristicasAmbientacion.SelectedValue = pedido.CaracteristicaId.ToString();

        //        this.TextBoxPaqueteAmbientacion.Text = pedido.RequerimientoAmbientacion;

        //        this.TextBoxComentario.Text = pedido.DetalleRequerimiento;

        //    }
        //    else if (pedido.UnidadNegocioId == 2)
        //    {
        //        PanelTecnica.Visible = true;

        //        DropDownListLocacionTecnica.SelectedValue = pedido.LocacionId.ToString();

        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocacionTecnica.SelectedItem.Value), DropDownListSectorTecnica);

        //        DropDownListSectorTecnica.SelectedValue = pedido.SectorId.ToString();
        //        DropDownListSegmentoTecnica.SelectedValue = pedido.SegmentoId.ToString();
        //        DropDownListTipoServicioTecnica.SelectedValue = pedido.TipoServicioId.ToString();

        //        this.TextBoxComentario.Text = pedido.DetalleRequerimiento;
        //        this.TextBoxCantidadInvitadosTecnica.Text = pedido.CantidadInvitados.ToString();


        //    }
        //    else if (pedido.UnidadNegocioId == 7)
        //    {
        //        PanelLocacion.Visible = true;

        //        DropDownListLocaciones.SelectedValue = pedido.LocacionId.ToString();

        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value), DropDownListSectores);

        //        DropDownListSectores.SelectedValue = pedido.SectorId.ToString();

        //        DropDownListJornadas.SelectedValue = pedido.JornadaId.ToString();

        //        TextBoxCantidadInvitados.Text = pedido.CantidadInvitados.ToString();

        //        TextBoxFechaDesdeEvento.Text = String.Format("{0:dd/MM/yyyy}", pedido.FechaPedida);

        //        this.TextBoxComentario.Text = pedido.DetalleRequerimiento;



        //    }

        //    this.TextBoxComentario.Text = pedido.DetalleRequerimiento;
        //}

        //private void NuevoPedidoCotizacion()
        //{
        //    PedidosCotizacionSeleccionado = new DomainAmbientHouse.Entidades.PedidosCotizacion();
        //}

        //private void CargarListas()
        //{
        //    DropDownListUnidadNegocio.DataSource = administrativas.ObtenerUnidadesdeNegocios();
        //    DropDownListUnidadNegocio.DataTextField = "Descripcion";
        //    DropDownListUnidadNegocio.DataValueField = "Id";
        //    DropDownListUnidadNegocio.DataBind();

        //    DropDownListLocalidades.DataSource = administrativas.ObtenerLocalidades();
        //    DropDownListLocalidades.DataTextField = "Descripcion";
        //    DropDownListLocalidades.DataValueField = "Id";
        //    DropDownListLocalidades.DataBind();



        //    DropDownListJornadas.DataSource = eventos.TraerJornadas();
        //    DropDownListJornadas.DataTextField = "Descripcion";
        //    DropDownListJornadas.DataValueField = "Id";
        //    DropDownListJornadas.DataBind();

        //    DropDownListLocacionTecnica.DataSource = eventos.ObtenerLocacionesParaCotizar();
        //    DropDownListLocacionTecnica.DataTextField = "Descripcion";
        //    DropDownListLocacionTecnica.DataValueField = "Id";
        //    DropDownListLocacionTecnica.DataBind();

        //    DropDownListSegmentoTecnica.DataSource = eventos.TraerSegmentos();
        //    DropDownListSegmentoTecnica.DataTextField = "Descripcion";
        //    DropDownListSegmentoTecnica.DataValueField = "Id";
        //    DropDownListSegmentoTecnica.DataBind();

        //    DropDownListLocacionAmbientacion.DataSource = eventos.ObtenerLocacionesParaCotizar();
        //    DropDownListLocacionAmbientacion.DataTextField = "Descripcion";
        //    DropDownListLocacionAmbientacion.DataValueField = "Id";
        //    DropDownListLocacionAmbientacion.DataBind();

        //    DropDownListSegmentosAmbientacion.DataSource = eventos.TraerSegmentos();
        //    DropDownListSegmentosAmbientacion.DataTextField = "Descripcion";
        //    DropDownListSegmentosAmbientacion.DataValueField = "Id";
        //    DropDownListSegmentosAmbientacion.DataBind();

        //    DropDownListCaracteristicasAmbientacion.DataSource = eventos.TraerCaracteristicas();
        //    DropDownListCaracteristicasAmbientacion.DataTextField = "Descripcion";
        //    DropDownListCaracteristicasAmbientacion.DataValueField = "Id";
        //    DropDownListCaracteristicasAmbientacion.DataBind();

        //    DropDownListTipoServicioTecnica.DataSource = eventos.TraerTipoServicios();
        //    DropDownListTipoServicioTecnica.DataTextField = "Descripcion";
        //    DropDownListTipoServicioTecnica.DataValueField = "Id";
        //    DropDownListTipoServicioTecnica.DataBind();

        //}

        //protected void ButtonAceptar_Click(object sender, EventArgs e)
        //{
        //    Grabar();
        //}

        //protected void ButtonVolver_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/PedidosCotizacion/Index.aspx");
        //}

        //private void Grabar()
        //{

        //    int EnviadoCompras = Int32.Parse(ConfigurationManager.AppSettings["PedidoCotizacionEnviadoCompras"].ToString());
        //    int Cotizado = Int32.Parse(ConfigurationManager.AppSettings["PedidoCotizacionCotizados"].ToString());

        //    DomainAmbientHouse.Entidades.PedidosCotizacion pedido = PedidosCotizacionSeleccionado;

        //    pedido.UnidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);

        //    //UNIDAD DE NEGOCIO TECNICA
        //    if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == 2)
        //    {

        //        pedido.LocacionId = Int32.Parse(DropDownListLocacionTecnica.SelectedItem.Value);

        //        pedido.SectorId = Int32.Parse(DropDownListSectorTecnica.SelectedItem.Value);

        //        pedido.FechaPedida = DateTime.Parse(TextBoxFechaEventoTecnica.Text);

        //        pedido.SegmentoId = Int32.Parse(DropDownListSegmentoTecnica.SelectedItem.Value);

        //        if (cmd.IsNumeric(TextBoxCantidadInvitados.Text))
        //            pedido.CantidadInvitados = Int32.Parse(TextBoxCantidadInvitadosTecnica.Text);

        //    }// UNIDAD DE NEGOCIO AMBIENTACION
        //    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == 1)
        //    {
        //        pedido.LocacionId = Int32.Parse(DropDownListLocacionAmbientacion.SelectedItem.Value);

        //        pedido.SectorId = Int32.Parse(DropDownListSectorAmbientacion.SelectedItem.Value);

        //        pedido.RequerimientoAmbientacion = TextBoxPaqueteAmbientacion.Text;

        //    }//UNIDAD DE NEGOCIO SALON
        //    else if (Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value) == 7)
        //    {
        //        pedido.LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value);

        //        pedido.SectorId = Int32.Parse(DropDownListSectores.SelectedItem.Value);

        //        pedido.JornadaId = Int32.Parse(DropDownListJornadas.SelectedItem.Value);

        //        pedido.FechaPedida = DateTime.Parse(TextBoxFechaDesdeEvento.Text);

        //         if (cmd.IsNumeric(TextBoxCantidadInvitados.Text))
        //            pedido.CantidadInvitados = Int32.Parse(TextBoxCantidadInvitados.Text);

        //    }



        //    pedido.DetalleRequerimiento = TextBoxComentario.Text;

        //    pedido.EstadoId = EnviadoCompras;
        //    pedido.UsuarioSolicitoId = EmpleadoId;

        //    if (cmd.IsNumeric(TextBoxCosto.Text))
        //        pedido.Costo = double.Parse(TextBoxCosto.Text);

        //    if (cmd.IsNumeric(TextBoxMargen.Text))
        //        pedido.Margen = double.Parse(TextBoxMargen.Text);




        //    eventos.GrabarPedidosCotizacion(pedido);

        //    Response.Redirect("~/PedidosCotizacion/Index.aspx");
        //}

        //protected void DropDownListUnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PanelLocacion.Visible = false;
        //    PanelTecnica.Visible = false;
        //    PanelAmbientacion.Visible = false;

        //    if (DropDownListUnidadNegocio.SelectedItem.Value == "7")
        //    {
        //        PanelLocacion.Visible = true;

        //    }
        //    else if (DropDownListUnidadNegocio.SelectedItem.Value == "2")
        //    {
        //        PanelTecnica.Visible = true;

        //        List<Proveedores> Prov = eventos.TraerProveedoresPorRubro(Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value.ToString()));

        //        DropDownListProveedores.Items.Clear();
        //        DropDownListProveedores.AppendDataBoundItems = true;
        //        DropDownListProveedores.DataSource = Prov.ToList();
        //        DropDownListProveedores.DataTextField = "RazonSocial";
        //        DropDownListProveedores.DataValueField = "Id";
        //        DropDownListProveedores.DataBind();
        //    }
        //    else if (DropDownListUnidadNegocio.SelectedItem.Value == "1")
        //    {
        //        PanelAmbientacion.Visible = true;
        //    }
        //}

        //protected void DropDownListLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (DropDownListLocaciones.SelectedItem.Value != null)
        //    {

        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value), DropDownListSectores);

        //        UpdatePanelProductos.Update();
        //    }
        //}

        //protected void DropDownListLocacionTecnica_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownListLocacionTecnica.SelectedItem.Value != null)
        //    {
        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocacionTecnica.SelectedItem.Value), DropDownListSectorTecnica);

        //        UpdatePanelProductos.Update();
        //    }
        //}

        //protected void DropDownListLocacionAmbientacion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownListLocacionAmbientacion.SelectedItem.Value != null)
        //    {

        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocacionAmbientacion.SelectedItem.Value), DropDownListSectorAmbientacion);


        //        UpdatePanelProductos.Update();
        //    }
        //}

        //private void CargarSectoresPorLocacion(int LocacionId, DropDownList sectores)
        //{
        //    if (LocacionId > 0)
        //    {
        //        sectores.DataSource = eventos.BuscarSectoresPorLocacion(LocacionId);
        //        sectores.DataTextField = "Descripcion";
        //        sectores.DataValueField = "Id";
        //        sectores.DataBind();
        //    }

        //}

        //protected void DropDownListLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownListLocalidades.SelectedItem.Value != null)
        //    {

        //        ObtenerLocacionesFiltradas();

        //    }
        //}

        //private void ObtenerLocacionesFiltradas()
        //{

        //    int localidadId = Int32.Parse(DropDownListLocalidades.SelectedItem.Value);

        //    string checkedTieneVerde = "NO";
        //    string checkedEstacionamiento = "NO";
        //    string checkedAirelibre = "NO";

        //    if (CheckBoxTieneVerde.Checked)
        //        checkedTieneVerde = "SI";

        //    if (CheckBoxEstacionamiento.Checked)
        //        checkedEstacionamiento = "SI";

        //    if (CheckBoxAireLibre.Checked)
        //        checkedAirelibre = "SI";


        //    List<Locaciones> list = eventos.ObtenerLocacionesParaCotizarPorLocacion(localidadId, checkedTieneVerde, checkedEstacionamiento, checkedAirelibre);

        //    if (list.Count > 0)
        //    {
        //        DropDownListLocaciones.DataSource = list.ToList();
        //        DropDownListLocaciones.DataTextField = "Descripcion";
        //        DropDownListLocaciones.DataValueField = "Id";
        //        DropDownListLocaciones.DataBind();

        //        CargarSectoresPorLocacion(Int32.Parse(DropDownListLocaciones.SelectedItem.Value), DropDownListSectores);

        //        DropDownListLocaciones.Visible = true;
        //        DropDownListSectores.Visible = true;

        //        LabelLocaciones.Visible = true;
        //        LabelSectores.Visible = true;

        //        LabelOtraLocacion.Visible = false;
        //        LabelOtroSector.Visible = false;

        //        TextBoxOtrasLocaciones.Visible = false;
        //        TextBoxOtroSector.Visible = false;
        //    }
        //    else
        //    {
        //        DropDownListLocaciones.Items.Clear();
        //        DropDownListSectores.Items.Clear();

        //        DropDownListLocaciones.Visible = false;
        //        DropDownListSectores.Visible = false;

        //        LabelLocaciones.Visible = false;
        //        LabelSectores.Visible = false;


        //        LabelOtraLocacion.Visible = true;
        //        LabelOtroSector.Visible = true;

        //        TextBoxOtrasLocaciones.Visible = true;
        //        TextBoxOtroSector.Visible = true;

        //    }

        //    UpdatePanelProductos.Update();
        //}

        //protected void ButtonBuscar_Click(object sender, EventArgs e)
        //{

        //    ObtenerLocacionesFiltradas();
        //}

        //protected void ButtonGenerarItem_Click(object sender, EventArgs e)
        //{
        //    int estadoActivoProducto = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());

        //    if (PedidosCotizacionSeleccionado != null)
        //    {
        //        if (PedidosCotizacionSeleccionado.UnidadNegocioId == 7)
        //        {

        //            Productos producto = new Productos();

        //            producto.Codigo = cmd.ArmarCodigoSalon(String.Format("{0:dd/MM/yyyy}", PedidosCotizacionSeleccionado.FechaPedida),
        //                                                     (int)PedidosCotizacionSeleccionado.LocacionId,
        //                                                     (int)PedidosCotizacionSeleccionado.SectorId,
        //                                                     (int)PedidosCotizacionSeleccionado.JornadaId,
        //                                                     (int)PedidosCotizacionSeleccionado.CantidadInvitados);

        //            producto.Descripcion = "";
        //            producto.LocacionId = PedidosCotizacionSeleccionado.LocacionId;
        //            producto.SectorId = PedidosCotizacionSeleccionado.SectorId;
        //            producto.JornadaId = PedidosCotizacionSeleccionado.JornadaId;
        //            producto.Anio = DateTime.Parse(PedidosCotizacionSeleccionado.FechaPedida.ToString()).Year;
        //            producto.Mes = DateTime.Parse(PedidosCotizacionSeleccionado.FechaPedida.ToString()).Month;
        //            producto.Dia = cmd.ConvertirIdioma(DateTime.Parse(PedidosCotizacionSeleccionado.FechaPedida.ToString()).DayOfWeek.ToString());
        //            producto.Costo = double.Parse(TextBoxCosto.Text);
        //            producto.Margen = double.Parse(TextBoxMargen.Text);
        //            producto.Precio = double.Parse(TextBoxCosto.Text) * double.Parse(TextBoxMargen.Text);
        //            producto.Estado = estadoActivoProducto;
        //            producto.UnidadNegocioId = PedidosCotizacionSeleccionado.UnidadNegocioId;

        //            administrativas.NuevoProducto(producto);

        //        }
        //        else if (PedidosCotizacionSeleccionado.UnidadNegocioId == 1)
        //        {
        //            Productos producto = new Productos();


        //        }
        //        else if (PedidosCotizacionSeleccionado.UnidadNegocioId == 7)
        //        {
        //            Productos producto = new Productos();

        //            producto.Codigo = cmd.ArmarCodigoTecnica(String.Format("{0:dd/MM/yyyy}", PedidosCotizacionSeleccionado.FechaPedida),
        //                                                   (int)PedidosCotizacionSeleccionado.TipoServicioId,
        //                                                   Int32.Parse(DropDownListProveedores.SelectedItem.Value),
        //                                                   (int)PedidosCotizacionSeleccionado.SegmentoId,
        //                                                   (int)PedidosCotizacionSeleccionado.SectorId);
        //        }
        //    }
        //}

    }
}