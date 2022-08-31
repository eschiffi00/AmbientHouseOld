using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using static iTextSharp.text.pdf.AcroFields;

namespace AmbientHouse.Administracion.Costos
{
    public partial class Salones : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
            }
        }

        private void CargarListas()
        {
            DropDownListLocacion.DataSource = administracion.ObtenerLocaciones();
            DropDownListLocacion.DataTextField = "Descripcion";
            DropDownListLocacion.DataValueField = "Id";
            DropDownListLocacion.DataBind();

            DropDownListJornada.DataSource = eventos.TraerJornadas();
            DropDownListJornada.DataTextField = "Descripcion";
            DropDownListJornada.DataValueField = "Id";
            DropDownListJornada.DataBind();

            cmd.CargarDiasMultiselect(MultiSelectDia);
            cmd.CargarAniosMultiselect(MultiSelectAnual);
            cmd.CargarMesesMultiselect(MultiSelectMes);

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (GrabarCostos().Count() > 0)
            {
                GridViewProductos.DataSource = GrabarCostos().ToList();
                GridViewProductos.DataBind();
                UpdatePanelSalones.Update();
            }
                
        }

        private List<DomainAmbientHouse.Entidades.CargarCostosSalones_Result> GrabarCostos()
        {
            DomainAmbientHouse.Entidades.ParametrosCostoSalones param = new DomainAmbientHouse.Entidades.ParametrosCostoSalones();
            List<DomainAmbientHouse.Entidades.CargarCostosSalones_Result> fechas = new List<DomainAmbientHouse.Entidades.CargarCostosSalones_Result>();

            param.LocacionId = Int32.Parse(DropDownListLocacion.SelectedItem.Value);
            param.SectorId = Int32.Parse(DropDownListSector.SelectedItem.Value);
            param.JornadaId = Int32.Parse(DropDownListJornada.SelectedItem.Value);
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
                                    fechas.AddRange(administracion.CargarPrecioCostosSalon(param));
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

                UpdatePanelSalones.Update();
            }
        }

    }
}