using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.ConfiguracionCateringTecnicaCotizador
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();

        private int TipoConfiguracionId
        {
            get
            {
                return Int32.Parse(Session["TipoConfiguracionId"].ToString());
            }
            set
            {
                Session["TipoConfiguracionId"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.ConfiguracionCateringTecnica> ConfiguracionCateringTecnicaSalida
        {
            get
            {
                return Session["ConfiguracionCateringTecnicaSalida"] as List<DomainAmbientHouse.Entidades.ConfiguracionCateringTecnica>;
            }
            set
            {
                Session["ConfiguracionCateringTecnicaSalida"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LabelMensaje.Visible = false;

                ConfiguracionCateringTecnicaSalida = new List<ConfiguracionCateringTecnica>();

                CargarListas();

            }

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                TipoConfiguracionId = id;
            }


            if (id == 0)
                NuevoTipoConfiguracion();
            else
                EditarTipoConfiguracion(id);


        }

        private void EditarTipoConfiguracion(int id)
        {
            throw new NotImplementedException();
        }

        private void NuevoTipoConfiguracion()
        {
            throw new NotImplementedException();
        }


        private void CargarListas()
        {
            DropDownListCaracteristicas.DataSource = eventos.TraerCaracteristicas();
            DropDownListCaracteristicas.DataTextField = "Descripcion";
            DropDownListCaracteristicas.DataValueField = "Id";
            DropDownListCaracteristicas.DataBind();


            DropDownListSegmentos.DataSource = eventos.TraerSegmentos();
            DropDownListSegmentos.DataTextField = "Descripcion";
            DropDownListSegmentos.DataValueField = "Id";
            DropDownListSegmentos.DataBind();


            DropDownListMomentosdeDia.DataSource = servicios.ObtenerMomentosDias();
            DropDownListMomentosdeDia.DataTextField = "Descripcion";
            DropDownListMomentosdeDia.DataValueField = "Id";
            DropDownListMomentosdeDia.DataBind();

            DropDownListDuracionEvento.DataSource = servicios.ObtenerDuracionEvento();
            DropDownListDuracionEvento.DataTextField = "Descripcion";
            DropDownListDuracionEvento.DataValueField = "Id";
            DropDownListDuracionEvento.DataBind();


            DropDownListTipoCatering.DataSource = eventos.TraerTipoCateringSoloActivos();
            DropDownListTipoCatering.DataTextField = "Descripcion";
            DropDownListTipoCatering.DataValueField = "Id";
            DropDownListTipoCatering.DataBind();

            DropDownListTipoServicio.DataSource = eventos.TraerTipoServicios();
            DropDownListTipoServicio.DataTextField = "Descripcion";
            DropDownListTipoServicio.DataValueField = "Id";
            DropDownListTipoServicio.DataBind();



        }



        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            LabelMensaje.Visible = false;

            int segmentoId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
            int caracteristicaId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
            int momentoDiaId = Int32.Parse(DropDownListMomentosdeDia.SelectedItem.Value.ToString());
            int duracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());
            int tipoCateringId = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value.ToString());
            int tipoServicioId = Int32.Parse(DropDownListTipoServicio.SelectedItem.Value.ToString());

            int activoConfig = Int32.Parse(ConfigurationManager.AppSettings["configuracionTecnicaCateringACTIVO"].ToString());

            DomainAmbientHouse.Entidades.ConfiguracionCateringTecnica configuracionExiste = servicios.BuscarConfiguracionCateringTecnica(segmentoId,
                                                                            caracteristicaId,
                                                                            momentoDiaId,
                                                                            duracionId,
                                                                            tipoCateringId,
                                                                            tipoServicioId);

            DomainAmbientHouse.Entidades.ConfiguracionCateringTecnica configuracionExisteLista = ConfiguracionCateringTecnicaSalida.Where(o => o.SegmentoId == segmentoId && o.CaracteristicaId == caracteristicaId &&
                                                                                                                                                o.MomentoDiaId == momentoDiaId && o.DuracionId == duracionId &&
                                                                                                                                                o.TipoServicioId == tipoServicioId && o.TipoCateringId == tipoCateringId).SingleOrDefault();

            if (configuracionExiste == null || configuracionExisteLista == null)
            {


                ConfiguracionCateringTecnica configuracion = new ConfiguracionCateringTecnica();

                configuracion.SegmentoId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value.ToString());
                configuracion.TipoServicioDescripcion = DropDownListSegmentos.SelectedItem.Text.ToString();

                configuracion.CaracteristicaId = Int32.Parse(DropDownListCaracteristicas.SelectedItem.Value.ToString());
                configuracion.CaracteristicaDescripcion = DropDownListCaracteristicas.SelectedItem.Text.ToString();


                configuracion.MomentoDiaId = Int32.Parse(DropDownListMomentosdeDia.SelectedItem.Value.ToString());
                configuracion.MomentodelDiaDescripcion = DropDownListMomentosdeDia.SelectedItem.Text.ToString();

                configuracion.DuracionId = Int32.Parse(DropDownListDuracionEvento.SelectedItem.Value.ToString());
                configuracion.DuracionDescripcion = DropDownListDuracionEvento.SelectedItem.Text.ToString();


                configuracion.TipoCateringId = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value.ToString());
                configuracion.TipoCateringDescripcion = DropDownListTipoCatering.SelectedItem.Text.ToString();

                configuracion.TipoServicioId = Int32.Parse(DropDownListTipoServicio.SelectedItem.Value.ToString());
                configuracion.TipoServicioDescripcion = DropDownListTipoServicio.SelectedItem.Text.ToString();
                configuracion.EstadoId = activoConfig;

                //if (ConfiguracionCateringTecnicaSalida.Where(o => o.Id == impuesto.Id).Count() > 0)
                //{ }
                //else
                //{
                ConfiguracionCateringTecnicaSalida.Add(configuracion);
                //}


                GridViewConfiguracion.DataSource = ConfiguracionCateringTecnicaSalida.ToList();
                GridViewConfiguracion.DataBind();


            }
            else
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = "La configuracion que esta ingresando ya existe!!!";
            }
            UpdatePanelGrillaConfiguracion.Update();

        }

        protected void ButtonQuitar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewConfiguracion.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxQuitar") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.ConfiguracionCateringTecnica config = new DomainAmbientHouse.Entidades.ConfiguracionCateringTecnica();



                    var itemRemove = ConfiguracionCateringTecnicaSalida.Where(o => o.Id == config.Id).Single();

                    ConfiguracionCateringTecnicaSalida.Remove(itemRemove);
                }

            }


            GridViewConfiguracion.DataSource = ConfiguracionCateringTecnicaSalida.ToList();
            GridViewConfiguracion.DataBind();

            UpdatePanelGrillaConfiguracion.Update();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ConfiguracionCateringTecnicaCotizador/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            servicios.GrabarConfiguracionCateringTecnica(ConfiguracionCateringTecnicaSalida.ToList());
            Response.Redirect("~/Configuracion/ConfiguracionCateringTecnicaCotizador/Index.aspx");
        }





    }
}