using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Barras
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


        private List<DomainAmbientHouse.Entidades.CostoBarra> CostoBarraSalida
        {
            get
            {
                return Session["CostoBarraSalida"] as List<DomainAmbientHouse.Entidades.CostoBarra>;
            }
            set
            {
                Session["CostoBarraSalida"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonImportar.Visible = false;
                CostoBarraSalida = new List<CostoBarra>();

                CargarListaProveedores();
            }

        }

        private void CargarListaProveedores()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());

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

                    List<CostoBarra> CostosBarras = new List<CostoBarra>();


                    Parametros parametro = new Parametros();


                    try
                    {
                        parametro = servicios.BuscarParametro("RutaArchivoPrecioCostoCatering");

                        ruta = parametro.Valor + FileUpload1.FileName;


                        var manipulador = new ManipuladorExcel(ruta);
                        CostosBarras = manipulador.ObtenerCostoBarrasDesdeArchivo(CeldaInicio, CeldaFin).ToList();

                        //List<CostoCatering> Salida = new List<CostoCatering>();
                        foreach (var costoBarra in CostosBarras)
                        {
                            CostoBarra cosCa = new CostoBarra();

                            cosCa.TipoBarraId = costoBarra.TipoBarraId;
                            cosCa.Precios = Math.Round(costoBarra.Precios, 0);
                            cosCa.CantidadPersonas = costoBarra.CantidadPersonas;
                            cosCa.ValorMas5PorCiento = Math.Round(costoBarra.ValorMas5PorCiento, 0);
                            cosCa.ValorMenos5PorCiento = Math.Round(costoBarra.ValorMenos5PorCiento, 0);
                            cosCa.ValorMenos10PorCiento = Math.Round(costoBarra.ValorMenos10PorCiento, 0);
                            cosCa.TipoBarraDescripcion = costoBarra.TipoBarraDescripcion;
                            cosCa.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
                            CostoBarraSalida.Add(cosCa);
                        }

                        if (CostoBarraSalida.Count > 0)
                        {
                            GridViewCostoBarra.DataSource = CostoBarraSalida.ToList();
                            GridViewCostoBarra.DataBind();

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
            servicios.ImportarCostosBarras(CostoBarraSalida, Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString()));
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Barras/Index.aspx");
        }
    }
}