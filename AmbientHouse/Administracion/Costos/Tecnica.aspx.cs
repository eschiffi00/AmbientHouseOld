using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Seguridad;
using static iTextSharp.text.pdf.AcroFields;
//using DbEntidades.Entities;

namespace AmbientHouse.Administracion.Costos
{
    public partial class Tecnica : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        Comun cmd = new Comun();
        int procesado = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
            }
        }

        #region Session
        protected void SessionClearAll()
        {
            Session["procesado"] = 0;
        }
        protected void SessionLoadAll()
        {
            procesado = (int)Session["procesado"];
        }
        protected void SessionSaveAll()
        {
            Session["procesado"] = procesado;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session

        private void CargarListas()
        {
            DropDownListLocacion.DataSource = administracion.ObtenerLocaciones();
            DropDownListLocacion.DataTextField = "Descripcion";
            DropDownListLocacion.DataValueField = "Id";
            DropDownListLocacion.DataBind();

            //DropDownListServicios.DataSource = eventos.tra
            //DropDownListServicios.DataTextField = "Descripcion";
            //DropDownListServicios.DataValueField = "Id";
            //DropDownListServicios.DataBind();
            MultiSelectServicios.DataSource = eventos.TraerTipoServicios();
            MultiSelectServicios.DataTextField = "Descripcion";
            MultiSelectServicios.DataValueField = "Id";
            MultiSelectServicios.DataBind();
            //ListItem itemLunes = new ListItem();
            //itemLunes.Text = "Lunes";
            //itemLunes.Value = "Lunes";

            //Dias.Items.Add(itemLunes);
            DropDownListSegmentos.DataSource = eventos.TraerSegmentos();
            DropDownListSegmentos.DataTextField = "Descripcion";
            DropDownListSegmentos.DataValueField = "Id";
            DropDownListSegmentos.DataBind();

            List<Proveedores> Prov = eventos.TraerProveedoresPorRubro(2);
            DropDownListProveedores.Items.Clear();
            DropDownListProveedores.AppendDataBoundItems = true;
            DropDownListProveedores.DataSource = Prov.ToList();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();

            cmd.CargarDiasMultiselect(MultiSelectDia);
            cmd.CargarAniosMultiselect(MultiSelectAnual);
            cmd.CargarMesesMultiselect(MultiSelectMes);

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            SessionLoadAll();
            if (procesado == 0)
            {
                GridViewProductos.DataSource = GrabarCostos().ToList();
                GridViewProductos.DataBind();
                UpdatePanelTecnica.Update();
                procesado = 1;
                SessionSaveAll();
            }
            else
            {
                Response.Redirect("~/Home/Index.aspx");
            }
                
        }

        private List<DomainAmbientHouse.Entidades.CargarCostosTecnica_Result> GrabarCostos()
        {
            DomainAmbientHouse.Entidades.ParametrosCostoTecnica param = new DomainAmbientHouse.Entidades.ParametrosCostoTecnica();
            List<DomainAmbientHouse.Entidades.CargarCostosTecnica_Result> fechas = new List<DomainAmbientHouse.Entidades.CargarCostosTecnica_Result>();

            param.LocacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value);
            param.SectorId = Int32.Parse(DropDownListSector.SelectedItem.Value);
            param.TipoServicioId = Int32.Parse(MultiSelectServicios.SelectedItem.Value);
            param.SegmentoId = Int32.Parse(DropDownListSegmentos.SelectedItem.Value);
            param.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);
            foreach (ListItem servicio in MultiSelectServicios.Items)
            {
                if (servicio.Selected)
                {
                    param.TipoServicioId = Int32.Parse(servicio.Value);
                    foreach (ListItem anio in MultiSelectAnual.Items)
                    {

                        if (anio.Selected)
                        {
                            param.Anio = Int32.Parse(anio.Value);
                            foreach (ListItem mes in MultiSelectMes.Items)
                            {

                                if (mes.Selected)
                                {
                                    param.Mes = Int32.Parse(mes.Value);
                                    foreach (ListItem dia in MultiSelectDia.Items)
                                    {

                                        if (dia.Selected)
                                        {
                                            param.Dia = dia.Value;
                                            param.Costo = double.Parse(TextBoxCosto.Text);
                                            param.Precio = double.Parse(TextBoxPrecio.Text);
                                            param.Royalty = double.Parse(TextBoxRoyalty.Text);
                                            fechas.AddRange(administracion.CargarPrecioCostosTecnica(param));
                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }

            return fechas;
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void DropDownListLocacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListLocacion.SelectedItem.Value != null)
            {
                int seleccionado = Int32.Parse(this.DropDownListLocacion.SelectedItem.Value.ToString());

                DropDownListSector.DataSource = eventos.BuscarSectoresPorLocacion(seleccionado);
                DropDownListSector.DataTextField = "Descripcion";
                DropDownListSector.DataValueField = "Id";
                DropDownListSector.DataBind();

                UpdatePanelTecnica.Update();
            }
        }

    }
}