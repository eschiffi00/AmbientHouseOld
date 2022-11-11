using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;


namespace AmbientHouse.Costos.Ambientacion
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

        private List<DomainAmbientHouse.Entidades.CostoAmbientacion> CostoAmbientacionSalida
        {
            get
            {
                return Session["CostoAmbientacionSalida"] as List<DomainAmbientHouse.Entidades.CostoAmbientacion>;
            }
            set
            {
                Session["CostoAmbientacionSalida"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonImportar.Visible = false;
                CostoAmbientacionSalida = new List<CostoAmbientacion>();

                CargarListaProveedores();
            }
        }

        private void CargarListaProveedores()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

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

                    List<CostoAmbientacion> CostosAmbientacion = new List<CostoAmbientacion>();


                    Parametros parametro = new Parametros();


                    try
                    {
                        parametro = servicios.BuscarParametro("RutaArchivoPrecioCostoCatering");

                        ruta = parametro.Valor + FileUpload1.FileName;


                        var manipulador = new ManipuladorExcel(ruta);
                        CostosAmbientacion = manipulador.ObtenerCostoAmbientacionDesdeArchivo(CeldaInicio, CeldaFin).ToList();

                        //List<CostoCatering> Salida = new List<CostoCatering>();
                        foreach (var costosAmbientacion in CostosAmbientacion)
                        {
                            CostoAmbientacion cosCa = new CostoAmbientacion();

                            cosCa.CategoriaId = costosAmbientacion.CategoriaId;
                            cosCa.Precio = Math.Round(costosAmbientacion.Precio, 0);
                            cosCa.CantidadInvitados = costosAmbientacion.CantidadInvitados;
                            cosCa.ValorMas5PorCiento = Math.Round(costosAmbientacion.ValorMas5PorCiento, 0);
                            cosCa.ValorMenos5PorCiento = Math.Round(costosAmbientacion.ValorMenos5PorCiento, 0);
                            cosCa.ValorMenos10PorCiento = Math.Round(costosAmbientacion.ValorMenos10PorCiento, 0);
                            cosCa.CategoriaDescripcion = costosAmbientacion.CategoriaDescripcion;
                            cosCa.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
                            CostoAmbientacionSalida.Add(cosCa);
                        }

                        if (CostoAmbientacionSalida.Count > 0)
                        {
                            GridViewCostoAmbientacion.DataSource = CostoAmbientacionSalida.ToList();
                            GridViewCostoAmbientacion.DataBind();

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
            servicios.ImportarCostosAmbientacion(CostoAmbientacionSalida, Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString()));
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Ambientacion/Index.aspx");
        }
    }
}