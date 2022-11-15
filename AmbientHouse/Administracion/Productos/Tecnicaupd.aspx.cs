using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Productos
{
    public partial class Tecnicaupd : System.Web.UI.Page
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

            DropDownListLocacion.DataSource = servicioEventos.TraerLocaciones();
            DropDownListLocacion.DataTextField = "Descripcion";
            DropDownListLocacion.DataValueField = "Id";
            DropDownListLocacion.DataBind();

            DropDownListTipoServicio.DataSource = servicioEventos.TraerTipoServicios();
            DropDownListTipoServicio.DataTextField = "Descripcion";
            DropDownListTipoServicio.DataValueField = "Id";
            DropDownListTipoServicio.DataBind();

            DropDownListSegmento.DataSource = servicioEventos.TraerSegmentos();
            DropDownListSegmento.DataTextField = "Descripcion";
            DropDownListSegmento.DataValueField = "Id";
            DropDownListSegmento.DataBind();


            List<ObtenerCantidadInvitadosCatering> Cantidades = servicioEventos.TraerCantidadPersonasCatering();

            cmd.CargarAniosMultiselect(DropDownListAnio);
            cmd.CargarMesesMultiselect(DropDownListMes);
            cmd.CargarDiasMultiselect(DropDownListDia);


            DropDownListEstados.DataSource = servicios.BuscarEstadosPorEntidad("Productos");
            DropDownListEstados.DataTextField = "Descripcion";
            DropDownListEstados.DataValueField = "Id";
            DropDownListEstados.DataBind();

            List<DomainAmbientHouse.Entidades.Proveedores> ProvUn = servicioEventos.TraerProveedoresPorRubro(2);

            DropDownListProveedores.Items.Clear();
            DropDownListProveedores.AppendDataBoundItems = true;
            DropDownListProveedores.DataSource = ProvUn.ToList();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();
        }

        protected void DropDownListUnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListasParaCodigo();
        }

        private void CargarListasParaCodigo()
        {

            LetraCodigo = "L";
            DropDownListSector.Visible = true;
            DropDownListLocacion.Visible = true;
            DropDownListTipoServicio.Visible = true;
            DropDownListSegmento.Visible = true;
            DropDownListProveedores.Visible = true;
            DropDownListAnio.Visible = true;
            DropDownListMes.Visible = true;
            DropDownListDia.Visible = true;

            LabelSector.Visible = true;
            LabelLocacion.Visible = true;
            LabelSegmento.Visible = true;
            LabelTipoServicio.Visible = true;
            LabelProveedores.Visible = true;
            LabelAnio.Visible = true;
            LabelMes.Visible = true;
            LabelDia.Visible = true;

            UpdatePanelFiltros.Update();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "multiselectformat",
            //    "multiselectformat();", true);
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
            List<int> tipoServicio = new List<int>();
            int categoriaId = 0;
            List<int> servicioId = new List<int>();
            int cantidadInvitados = 0;
            int locacionId = 0;
            List<int> sectorId = new List<int>();
            int jornadaId = 0;
            int segmentoId = 0;
            int caracteristicaId = 0;
            int proveedorId = 0;
            List<int> Anio = new List<int>();
            List<int> Mes = new List<int>();
            List<string> Dia = new List<string>();
            int adicionalId = 0;
            int estadoId = Int32.Parse(DropDownListEstados.SelectedItem.Value);
            int itemOrganizacionId = 0;
            int semestreId = 0;
            ListProductos.Clear();


            Filtros(out unidadNegocioId, out tipoCatering, out tipoBarra, out tipoServicio, out categoriaId, out cantidadInvitados, out locacionId, out sectorId, out jornadaId, out segmentoId, out proveedorId, out Anio, out Mes, out Dia, out adicionalId, out caracteristicaId, out itemOrganizacionId, out semestreId);

            if (unidadNegocioId == 2)
            {
                foreach (var servicio in tipoServicio)
                {
                    foreach (var sector in sectorId)
                    {
                        foreach (var anio in Anio)
                        {
                            foreach (var mes in Mes)
                            {
                                foreach (var dia in Dia)
                                {
                                    ListProductos.AddRange(servicios.BuscarProductosPorFiltros(unidadNegocioId, tipoCatering, tipoBarra, servicio, categoriaId, cantidadInvitados,
                                                                                                            locacionId, sector, segmentoId, jornadaId, proveedorId,
                                                                                                            anio, mes, dia, adicionalId, estadoId, caracteristicaId, itemOrganizacionId, semestreId));
                                }
                            }
                        }
                    }
                }
                
            }



            GridViewProductos.DataSource = ListProductos.ToList();
            GridViewProductos.DataBind();


            UpdatePanelGrillaProductos.Update();
        }

        private void Filtros(out int unidadNegocioId, out int tipoCatering, out int tipoBarra, out List<int> tipoServicio, out int categoriaId, out int cantidadInvitados,
                            out int locacionId, out List<int> sectorId, out int jornadaId, out int segmentoId, out int proveedorId, out List<int> Anio,
                            out List<int> Mes, out List<string> Dia, out int adicionalId, out int caracteristicaId, out int organizacionItemId, out int semestreId)
        {

            unidadNegocioId = 2;
            tipoCatering = 0;
            tipoBarra = 0;
            categoriaId = 0;
            segmentoId = 0;
            proveedorId = 0;
            cantidadInvitados = 0;
            jornadaId = 0;

            locacionId = 0;
            if (DropDownListLocacion.SelectedItem.Value != "null")
            { locacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value); }

            sectorId = new List<int>();
            foreach (ListItem sector in DropDownListSector.Items)
            {
                if (sector.Selected)
                { sectorId.Add(Int32.Parse(sector.Value)); }
            }

            tipoServicio = new List<int>();
            foreach (ListItem servicio in DropDownListTipoServicio.Items)
            {
                if (servicio.Selected)
                { tipoServicio.Add(Int32.Parse(servicio.Value)); }
            }

            Anio = new List<int>();
            foreach (ListItem anio in DropDownListAnio.Items)
            {
                if (anio.Selected)
                { Anio.Add(Int32.Parse(anio.Value)); }
            }

            Mes = new List<int>();
            foreach (ListItem mes in DropDownListMes.Items)
            {
                if (mes.Selected)
                { Mes.Add(Int32.Parse(mes.Value)); }
            }

            Dia = new List<string>();
            foreach (ListItem dia in DropDownListDia.Items)
            {
                if (dia.Selected)
                { Dia.Add(dia.Text); }
            }

            adicionalId = 0;
            caracteristicaId = 0;
            organizacionItemId = 0;
            semestreId = 0;

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

                //ListItem oitem = new ListItem();

                //oitem.Text = "Seleccione un Sector";
                //oitem.Value = "null";

                //DropDownListSector.Items.Add(oitem);
            }
            else
            {
                DropDownListSector.Items.Clear();
                DropDownListSector.SelectedValue = "null";
            }

            UpdatePanelFiltros.Update();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "multiselectformat",
                "multiselectformat();", true);
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
            List<int> tipoServicio;
            int categoriaId;
            int cantidadInvitados = 0;
            int locacionId = 0;
            List<int> sectorId = new List<int>();
            int jornadaId = 0;
            int segmentoId = 0;
            int caracteristicaId = 0;
            int proveedorId = 0;
            List<int> Anio = new List<int>();
            List<int> Mes = new List<int>();
            List<string> Dia = new List<string>();
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



    }
}