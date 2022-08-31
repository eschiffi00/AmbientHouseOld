using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using System.IO;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Costos.Catering
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();
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


        private List<DomainAmbientHouse.Entidades.CostoCatering> CostoCateringSalida
        {
            get
            {
                return Session["CostoCateringSalida"] as List<DomainAmbientHouse.Entidades.CostoCatering>;
            }
            set
            {
                Session["CostoCateringSalida"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonImportar.Visible = false;
                CostoCateringSalida = new List<CostoCatering>();

                CargarListaProveedores();
            }

        }

        private void CargarListaProveedores()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());

            DropDownListProveedores.DataSource = serviciosEventos.TraerProveedoresPorRubro(RubroCatering);
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {

            BuscarCostosExcel(e);
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

                    List<CostoCatering> CostosCatering = new List<CostoCatering>();


                    Parametros parametro = new Parametros();


                    try
                    {
                        parametro = servicios.BuscarParametro("RutaArchivoPrecioCostoCatering");

                        ruta = parametro.Valor + FileUpload1.FileName;


                        var manipulador = new ManipuladorExcel(ruta);
                        CostosCatering = manipulador.ObtenerCostoCateringDesdeArchivo(CeldaInicio, CeldaFin).ToList();

                        //List<CostoCatering> Salida = new List<CostoCatering>();
                        foreach (var costoCatering in CostosCatering)
                        {
                            CostoCatering cosCa = new CostoCatering();

                            cosCa.TipoCateringId = costoCatering.TipoCateringId;
                            cosCa.Precio = Math.Round(costoCatering.Precio,0);
                            cosCa.CantidadPersonas = costoCatering.CantidadPersonas;
                            cosCa.ValorMas5PorCiento = Math.Round(costoCatering.ValorMas5PorCiento,0);
                            cosCa.ValorMenos5PorCiento = Math.Round(costoCatering.ValorMenos5PorCiento,0);
                            cosCa.ValorMenos10PorCiento = Math.Round(costoCatering.ValorMenos10PorCiento, 0);
                            cosCa.TipoCateringDescripcion = costoCatering.TipoCateringDescripcion;
                            cosCa.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
                            CostoCateringSalida.Add(cosCa);
                        }

                        if (CostoCateringSalida.Count > 0)
                        {
                            GridViewCostoCatering.DataSource = CostoCateringSalida.ToList();
                            GridViewCostoCatering.DataBind();

                            ButtonImportar.Visible = true;
                        }
                        else
                        {
                            ButtonImportar.Visible = false;
                        }


                    }
                    catch (Exception)
                    {
                        string errorMsg = String.Format("{0} - {1}", ruta, e);

                    }

                }
            }
        }

        protected void ButtonImportar_Click(object sender, EventArgs e)
        {
            servicios.ImportarCostosCatering(CostoCateringSalida, Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString()));
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Catering/Index.aspx");
        }

     
    }
}