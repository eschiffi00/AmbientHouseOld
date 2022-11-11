using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.Adicionales
{
    public partial class Editar : System.Web.UI.Page
    {
        private DomainAmbientHouse.Entidades.Adicionales AdicionalSeleccionado
        {
            get
            {
                return Session["AdicionalSeleccionado"] as DomainAmbientHouse.Entidades.Adicionales;
            }
            set
            {
                Session["AdicionalSeleccionado"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.TipoCatering> ListTipoCatering
        {
            get
            {
                return Session["ListTipoCatering"] as List<DomainAmbientHouse.Entidades.TipoCatering>;
            }
            set
            {
                Session["ListTipoCatering"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.TipoCatering> ListTipoCateringParaAgregar
        {
            get
            {
                return Session["ListTipoCateringParaAgregar"] as List<DomainAmbientHouse.Entidades.TipoCatering>;
            }
            set
            {
                Session["ListTipoCateringParaAgregar"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.TipoServicios> ListTipoServicios
        {
            get
            {
                return Session["ListTipoServicios"] as List<DomainAmbientHouse.Entidades.TipoServicios>;
            }
            set
            {
                Session["ListTipoServicios"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.TipoServicios> ListTipoServiciosParaAgregar
        {
            get
            {
                return Session["ListTipoServiciosParaAgregar"] as List<DomainAmbientHouse.Entidades.TipoServicios>;
            }
            set
            {
                Session["ListTipoServiciosParaAgregar"] = value;
            }
        }

        private List<TipoCateringAdicional> ListTipoCateringAdicional
        {
            get
            {
                return Session["ListTipoCateringAdicional"] as List<DomainAmbientHouse.Entidades.TipoCateringAdicional>;
            }
            set
            {
                Session["ListTipoCateringAdicional"] = value;
            }
        }

        private int AdicionalId
        {
            get
            {
                return Int32.Parse(Session["AdicionalId"].ToString());
            }
            set
            {
                Session["AdicionalId"] = value;
            }
        }

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();
        ProveedoresServicios serviciosProveedor = new ProveedoresServicios();

        private int unSalon
        {
            get
            {
                return Int32.Parse(Session["unSalon"].ToString());
            }
            set
            {
                Session["unSalon"] = value;
            }
        }

        private int unAmbientacion
        {
            get
            {
                return Int32.Parse(Session["unAmbientacion"].ToString());
            }
            set
            {
                Session["unAmbientacion"] = value;
            }
        }

        private int unBarras
        {
            get
            {
                return Int32.Parse(Session["unBarras"].ToString());
            }
            set
            {
                Session["unBarras"] = value;
            }
        }

        private int unCatering
        {
            get
            {
                return Int32.Parse(Session["unCatering"].ToString());
            }
            set
            {
                Session["unCatering"] = value;
            }
        }

        private int unTecnica
        {
            get
            {
                return Int32.Parse(Session["unTecnica"].ToString());
            }
            set
            {
                Session["unTecnica"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListTipoCatering = new List<DomainAmbientHouse.Entidades.TipoCatering>();
                ListTipoCateringParaAgregar = new List<DomainAmbientHouse.Entidades.TipoCatering>();

                ListTipoServicios = new List<DomainAmbientHouse.Entidades.TipoServicios>();
                ListTipoServiciosParaAgregar = new List<DomainAmbientHouse.Entidades.TipoServicios>();

                ListTipoCateringAdicional = new List<TipoCateringAdicional>();


                UpdatePanelLocaciones.Visible = false;
                UpdatePanelProveedores.Visible = false;

                DropDownListTipoCateringAgregar.Visible = false;
                GridViewTipoCatering.Visible = false;
                ButtonAgregar.Visible = false;
                ButtonQuitar.Visible = false;
                LabelMensaje.Visible = false;

                unSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
                unAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
                unBarras = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
                unCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
                unTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());

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

                AdicionalId = id;
            }


            if (id == 0)
                NuevoAdicional();
            else
                EditarAdicional(id);

            SetFocus(TextBoxDescripcion);
        }

        private void CargarListas()
        {


            DropDownListUnidadNegocios.DataSource = servicios.ObtenerUnidadesdeNegocios();
            DropDownListUnidadNegocios.DataTextField = "Descripcion";
            DropDownListUnidadNegocios.DataValueField = "Id";
            DropDownListUnidadNegocios.DataBind();


            DropDownListLocaciones.DataSource = serviciosEventos.TraerLocaciones();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();

        }

        private void EditarAdicional(int id)
        {

            int adicionalActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalActivo"].ToString());
            int adicionalNoActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalNoActivo"].ToString());


            DomainAmbientHouse.Entidades.Adicionales adicional = new DomainAmbientHouse.Entidades.Adicionales();

            adicional = servicios.BuscarAdicional(id);

            AdicionalSeleccionado = adicional;

            DropDownListUnidadNegocios.SelectedValue = adicional.RubroId.ToString();

            if (adicional.LocacionId != null)
            {
                DropDownListLocaciones.Visible = true;
                DropDownListProveedores.Visible = false;

                DropDownListLocaciones.SelectedValue = adicional.LocacionId.ToString();
            }
            else
            {
                DropDownListLocaciones.Visible = false;
                DropDownListProveedores.Visible = true;

                DropDownListProveedores.SelectedValue = adicional.ProveedorId.ToString();
            }

            TextBoxDescripcion.Text = adicional.Descripcion;
            TextBoxPrecio.Text = adicional.Precio.ToString();

            if (adicional.EstadoId == adicionalActivo)
            { CheckBoxActivo.Checked = true; }
            else
            { CheckBoxActivo.Checked = false; }


            if (adicional.SoloMayores == "S")
            { CheckBoxSoloAdultos.Checked = true; }
            else
            { CheckBoxSoloAdultos.Checked = false; }


            if (adicional.RequiereCantidad == "N" && adicional.RequiereCantidadRango == "N")
            {
                CheckBoxCantidades.Checked = false;
                RadioButtonRequiereCantidad.Checked = false;
                RadioButtonRequieraCantidadRango.Checked = false;
                PanelRequierenCantidad.Enabled = false;
            }
            else
            {

                CheckBoxCantidades.Checked = true;
                PanelRequierenCantidad.Enabled = true;

                if (adicional.RequiereCantidad == "S")
                { RadioButtonRequiereCantidad.Checked = true; }
                else
                { RadioButtonRequiereCantidad.Checked = false; }

                if (adicional.RequiereCantidadRango == "S")
                { RadioButtonRequieraCantidadRango.Checked = true; }
                else
                { RadioButtonRequieraCantidadRango.Checked = false; }

            }

            CargarListasLocacionesProveedores();

            CargarExperienciasPorAdicional(adicional);

        }

        private void CargarExperienciasPorAdicional(DomainAmbientHouse.Entidades.Adicionales adicional)
        {

            DropDownListTipoCateringAgregar.Visible = false;
            GridViewTipoCatering.Visible = false;
            ButtonAgregar.Visible = false;
            ButtonQuitar.Visible = false;

            if (DropDownListUnidadNegocios.SelectedItem.Value != null)
            {
                int UN = Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value.ToString());


                if (UN == unSalon)
                {


                }

                if (UN == unCatering)
                {

                    DropDownListTipoCateringAgregar.Visible = true;
                    GridViewTipoCatering.Visible = true;
                    ButtonAgregar.Visible = true;
                    ButtonQuitar.Visible = true;


                    ListTipoCateringParaAgregar = servicios.BuscarTipoCateringParaAgregarPorAdicional((int)adicional.Id);

                    DropDownListTipoCateringAgregar.DataSource = ListTipoCateringParaAgregar.ToList();
                    DropDownListTipoCateringAgregar.DataTextField = "Descripcion";
                    DropDownListTipoCateringAgregar.DataValueField = "Id";
                    DropDownListTipoCateringAgregar.DataBind();


                    ListTipoCatering = servicios.BuscarTipoCateringPorAdicional((int)adicional.Id);


                    foreach (var item in ListTipoCatering)
                    {
                        TipoCateringAdicional tcA = new TipoCateringAdicional();

                        tcA.AdicionalId = adicional.Id;
                        tcA.TipoCateringId = item.Id;

                        ListTipoCateringAdicional.Add(tcA);

                    }

                    GridViewTipoCatering.DataSource = ListTipoCatering.ToList();
                    GridViewTipoCatering.DataBind();
                }

                if (UN == unTecnica)
                {

                    DropDownListTipoCateringAgregar.Visible = true;
                    GridViewTipoCatering.Visible = true;
                    ButtonAgregar.Visible = true;
                    ButtonQuitar.Visible = true;

                    ListTipoServiciosParaAgregar = servicios.BuscarTipoServicioParaAgregarPorAdicional((int)adicional.Id);

                    DropDownListTipoCateringAgregar.DataSource = ListTipoServiciosParaAgregar.ToList();
                    DropDownListTipoCateringAgregar.DataTextField = "Descripcion";
                    DropDownListTipoCateringAgregar.DataValueField = "Id";
                    DropDownListTipoCateringAgregar.DataBind();


                    ListTipoServicios = servicios.BuscarTipoServicioPorAdicional((int)adicional.Id);

                    GridViewTipoCatering.DataSource = ListTipoServicios.ToList();
                    GridViewTipoCatering.DataBind();
                }

            }



        }

        private void NuevoAdicional()
        {
            AdicionalSeleccionado = new DomainAmbientHouse.Entidades.Adicionales();

            PanelRequierenCantidad.Enabled = CheckBoxCantidades.Checked;

            UpdatePanelCantidades.Update();

        }

        private void GrabarAdicional()
        {
            int adicionalActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalActivo"].ToString());
            int adicionalNoActivo = Int32.Parse(ConfigurationManager.AppSettings["AdicionalNoActivo"].ToString());


            int UN = Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value.ToString());

            DomainAmbientHouse.Entidades.Adicionales adicional = AdicionalSeleccionado;

            adicional.Descripcion = TextBoxDescripcion.Text;

            if (TextBoxPrecio.Text != "")
            {
                adicional.Precio = double.Parse(TextBoxPrecio.Text);
            }
            else
            {
                adicional.Precio = null;
            }
            adicional.RubroId = UN;

            if (CheckBoxActivo.Checked)
            { adicional.EstadoId = adicionalActivo; }
            else
            { adicional.EstadoId = adicionalNoActivo; }

            if (CheckBoxSoloAdultos.Checked)
            { adicional.SoloMayores = "S"; }
            else
            { adicional.SoloMayores = "N"; }

            if (CheckBoxCantidades.Checked)
            {
                if (RadioButtonRequiereCantidad.Checked)
                { adicional.RequiereCantidad = "S"; }
                else
                    adicional.RequiereCantidad = "N";

                if (RadioButtonRequieraCantidadRango.Checked)
                { adicional.RequiereCantidadRango = "S"; }
                else
                    adicional.RequiereCantidadRango = "N";
            }
            else
            {
                adicional.RequiereCantidad = "N";
                adicional.RequiereCantidadRango = "N";

            }


            if (UN == unSalon)
            {
                adicional.LocacionId = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
            }

            if (DropDownListProveedores.SelectedItem != null)
            {
                adicional.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
            }

            servicios.NuevoAdicional(adicional, ListTipoCatering, ListTipoServicios);
            Response.Redirect("~/Configuracion/Adicionales/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Adicionales/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarAdicional();
        }

        protected void DropDownListUnidadNegocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListasLocacionesProveedores();

            if (Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value) == unCatering)
            {
                DropDownListTipoCateringAgregar.Visible = true;
                GridViewTipoCatering.Visible = true;
                ButtonAgregar.Visible = true;
                ButtonQuitar.Visible = true;


                ListTipoCateringParaAgregar = serviciosEventos.TraerTipoCatering();

                DropDownListTipoCateringAgregar.DataSource = ListTipoCateringParaAgregar.ToList();
                DropDownListTipoCateringAgregar.DataTextField = "Descripcion";
                DropDownListTipoCateringAgregar.DataValueField = "Id";
                DropDownListTipoCateringAgregar.DataBind();

            }
            else if (Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value) == unTecnica)
            {
                DropDownListTipoCateringAgregar.Visible = true;
                GridViewTipoCatering.Visible = true;
                ButtonAgregar.Visible = true;
                ButtonQuitar.Visible = true;

                ListTipoServiciosParaAgregar = serviciosEventos.TraerTipoServicios();

                DropDownListTipoCateringAgregar.DataSource = ListTipoServiciosParaAgregar.ToList();
                DropDownListTipoCateringAgregar.DataTextField = "Descripcion";
                DropDownListTipoCateringAgregar.DataValueField = "Id";
                DropDownListTipoCateringAgregar.DataBind();

            }
            else
            {
                DropDownListTipoCateringAgregar.Visible = false;
                GridViewTipoCatering.Visible = false;
                ButtonAgregar.Visible = false;
                ButtonQuitar.Visible = false;
            }

        }

        private void CargarListasLocacionesProveedores()
        {
            UpdatePanelLocaciones.Visible = false;
            UpdatePanelProveedores.Visible = false;


            if (DropDownListUnidadNegocios.SelectedItem.Value != null)
            {
                int UN = Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value.ToString());

                if (UN == unSalon)
                {
                    UpdatePanelLocaciones.Visible = true;
                    UpdatePanelLocaciones.Update();

                }

                DropDownListProveedores.Items.Clear();

                if (UN == unCatering)
                {


                    List<DomainAmbientHouse.Entidades.Proveedores> Prov = serviciosEventos.TraerProveedoresPorRubro(unCatering);

                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();


                    UpdatePanelProveedores.Visible = true;
                    UpdatePanelProveedores.Update();
                }

                if (UN == unTecnica)
                {
                    List<DomainAmbientHouse.Entidades.Proveedores> Prov = serviciosEventos.TraerProveedoresPorRubro(unTecnica);

                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();


                    UpdatePanelProveedores.Visible = true;
                    UpdatePanelProveedores.Update();
                }

                if (UN == unAmbientacion)
                {
                    List<DomainAmbientHouse.Entidades.Proveedores> Prov = serviciosEventos.TraerProveedoresPorRubro(unAmbientacion);

                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();


                    UpdatePanelProveedores.Visible = true;
                    UpdatePanelProveedores.Update();
                }

                if (UN == unBarras)
                {
                    List<DomainAmbientHouse.Entidades.Proveedores> Prov = serviciosEventos.TraerProveedoresPorRubro(unBarras);

                    DropDownListProveedores.DataSource = Prov.ToList();
                    DropDownListProveedores.DataTextField = "RazonSocial";
                    DropDownListProveedores.DataValueField = "Id";
                    DropDownListProveedores.DataBind();


                    UpdatePanelProveedores.Visible = true;
                    UpdatePanelProveedores.Update();
                }
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {


            LabelMensaje.Visible = false;

            if (DropDownListUnidadNegocios.SelectedItem.Value != null)
            {


                int UN = Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value.ToString());


                if (UN == unCatering)
                {

                    int Seleccionado = Int32.Parse(DropDownListTipoCateringAgregar.SelectedItem.Value.ToString());


                    var itemRepetido = ListTipoCatering.Where(o => o.Id == Seleccionado).SingleOrDefault();

                    if (itemRepetido == null)
                    {
                        DomainAmbientHouse.Entidades.TipoCatering tc = servicios.BuscarTipoCatering(Seleccionado);

                        ListTipoCatering.Add(tc);

                        GridViewTipoCatering.DataSource = ListTipoCatering.ToList();
                        GridViewTipoCatering.DataBind();


                        DropDownListTipoCateringAgregar.Items.Clear();
                        DropDownListTipoCateringAgregar.DataSource = ListTipoCateringParaAgregar.ToList();
                        DropDownListTipoCateringAgregar.DataTextField = "Descripcion";
                        DropDownListTipoCateringAgregar.DataValueField = "Id";
                        DropDownListTipoCateringAgregar.DataBind();
                    }
                    else
                    {
                        LabelMensaje.Visible = true;
                        LabelMensaje.Text = "Ya existe la experiencia para el Adicional!!!";

                    }

                }
                else if (UN == unTecnica)
                {
                    int Seleccionado = Int32.Parse(DropDownListTipoCateringAgregar.SelectedItem.Value.ToString());


                    var itemRepetido = ListTipoServicios.Where(o => o.Id == Seleccionado).SingleOrDefault();

                    if (itemRepetido == null)
                    {
                        DomainAmbientHouse.Entidades.TipoServicios ts = servicios.BuscarTipoServicios(Seleccionado);

                        ListTipoServicios.Add(ts);

                        GridViewTipoCatering.DataSource = ListTipoServicios.ToList();
                        GridViewTipoCatering.DataBind();


                        DropDownListTipoCateringAgregar.Items.Clear();
                        DropDownListTipoCateringAgregar.DataSource = ListTipoServiciosParaAgregar.ToList();
                        DropDownListTipoCateringAgregar.DataTextField = "Descripcion";
                        DropDownListTipoCateringAgregar.DataValueField = "Id";
                        DropDownListTipoCateringAgregar.DataBind();
                    }
                    else
                    {
                        LabelMensaje.Visible = true;
                        LabelMensaje.Text = "Ya existe la experiencia para el Adicional!!!";

                    }
                }

            }
            UpdatePanelGrillaTipoCatering.Update();
            UpdatePanelTipoCateringParaAgregar.Update();

        }

        protected void ButtonQuitar_Click(object sender, EventArgs e)
        {

            if (DropDownListUnidadNegocios.SelectedItem.Value != null)
            {


                int UN = Int32.Parse(DropDownListUnidadNegocios.SelectedItem.Value.ToString());
                foreach (GridViewRow row in GridViewTipoCatering.Rows)
                {
                    CheckBox check = row.FindControl("CheckBoxQuitar") as CheckBox;

                    if (check.Checked)
                    {


                        if (UN == unCatering)
                        {

                            DomainAmbientHouse.Entidades.TipoCatering tc = new DomainAmbientHouse.Entidades.TipoCatering();

                            tc.Id = Int32.Parse(row.Cells[0].Text);
                            tc.Descripcion = row.Cells[1].Text;


                            var itemRemove = ListTipoCatering.Where(o => o.Id == tc.Id).Single();

                            ListTipoCatering.Remove(itemRemove);

                        }
                        else if (UN == unTecnica)
                        {

                            DomainAmbientHouse.Entidades.TipoServicios tc = new DomainAmbientHouse.Entidades.TipoServicios();

                            tc.Id = Int32.Parse(row.Cells[0].Text);
                            tc.Descripcion = row.Cells[1].Text;


                            var itemRemove = ListTipoServicios.Where(o => o.Id == tc.Id).Single();

                            ListTipoServicios.Remove(itemRemove);
                        }

                    }
                }

                if (UN == unCatering)
                {

                    GridViewTipoCatering.DataSource = ListTipoCatering.ToList();
                    GridViewTipoCatering.DataBind();

                }
                else if (UN == unTecnica)
                {
                    GridViewTipoCatering.DataSource = ListTipoServicios.ToList();
                    GridViewTipoCatering.DataBind();
                }

            }




            UpdatePanelGrillaTipoCatering.Update();
            UpdatePanelTipoCateringParaAgregar.Update();
        }

        protected void CheckBoxCantidades_CheckedChanged(object sender, EventArgs e)
        {
            PanelRequierenCantidad.Enabled = CheckBoxCantidades.Checked;

            UpdatePanelCantidades.Update();

        }

    }
}