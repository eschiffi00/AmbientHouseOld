using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Salones
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();
        Comun cmd = new Comun();

        private string Ruta
        {
            get
            {
                return Session["Ruta"].ToString();
            }
            set
            {
                Session["Ruta"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.CostoSalones> CostoSalonesSalida
        {
            get
            {
                return Session["CostoSalonesSalida"] as List<DomainAmbientHouse.Entidades.CostoSalones>;
            }
            set
            {
                Session["CostoSalonesSalida"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonImportar.Visible = false;
                CostoSalonesSalida = new List<CostoSalones>();

                CargarListaLocaciones();
            }
        }

        private void CargarListaLocaciones()
        {
            DropDownListLocaciones.DataSource = serviciosEventos.TraerLocaciones();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();

            cmd.CargarAnios(DropDownListAnio);
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            BuscarCostosExcel(e);
        }

        protected void ButtonImportar_Click(object sender, EventArgs e)
        {
            servicios.ImportarCostosLocaciones(CostoSalonesSalida, Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString()), Int32.Parse(DropDownListAnio.SelectedItem.Value.ToString()));
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Salones/Index.aspx");
        }

        private void BuscarCostosExcel(EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                if (this.FileUpload1.PostedFile.ContentLength > 0 && this.FileUpload1.FileName.EndsWith(".xlsx"))
                {


                    string ruta = "";

                    string CeldaInicio, CeldaFin = "";

                    CeldaFin = TextBoxFin.Text;
                    CeldaInicio = TextBoxInicio.Text;

                    List<CostoSalones> CostosSalones = new List<CostoSalones>();


                    Parametros parametro = new Parametros();


                    try
                    {
                        parametro = servicios.BuscarParametro("RutaArchivoPrecioCostoCatering");

                        ruta = parametro.Valor + FileUpload1.FileName;


                        var manipulador = new ManipuladorExcel(ruta);
                        CostosSalones = manipulador.ObtenerCostoSaloneDesdeArchivo(CeldaInicio, CeldaFin).ToList();

                        //List<CostoCatering> Salida = new List<CostoCatering>();
                        foreach (var costoSalon in CostosSalones)
                        {
                            CostoSalones cosCa = new CostoSalones();

                            cosCa.LocacionId = costoSalon.LocacionId;
                            cosCa.LocacionDescripcion = costoSalon.LocacionDescripcion;
                            cosCa.SectorId = costoSalon.SectorId;
                            cosCa.SectorDescripcion = costoSalon.SectorDescripcion;
                            cosCa.JornadaId = costoSalon.JornadaId;
                            cosCa.JornadaDescripcion = costoSalon.JornadaDescripcion;
                            cosCa.CantidadInvitados = costoSalon.CantidadInvitados;
                            cosCa.Anio = costoSalon.Anio;
                            cosCa.Mes = costoSalon.Mes;
                            cosCa.Dia = costoSalon.Dia;
                            cosCa.Precio = Math.Round(double.Parse(costoSalon.Precio.ToString()), 0);
                            cosCa.Costo = Math.Round(double.Parse(costoSalon.Costo.ToString()), 0);

                            cosCa.ValorMas5PorCiento = Math.Round(costoSalon.ValorMas5PorCiento, 0);
                            cosCa.ValorMenos5PorCiento = Math.Round(costoSalon.ValorMenos5PorCiento, 0);
                            cosCa.ValorMenos10PorCiento = Math.Round(costoSalon.ValorMenos10PorCiento, 0);

                            CostoSalonesSalida.Add(cosCa);
                        }

                        if (CostoSalonesSalida.Count > 0)
                        {
                            GridViewPrecioSalones.DataSource = CostoSalonesSalida.ToList();
                            GridViewPrecioSalones.DataBind();

                            ButtonImportar.Visible = true;
                        }
                        else
                        {
                            ButtonImportar.Visible = false;
                        }


                    }
                    catch (Exception ex)
                    {
                        string errorMsg = String.Format("{0} - {1}", ruta, e);

                        DomainAmbientHouse.Servicios.Log.save(this, ex);
                    }

                }
            }
        }
    }
}