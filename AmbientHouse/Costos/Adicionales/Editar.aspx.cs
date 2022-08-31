using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;


namespace AmbientHouse.Costos.Adicionales
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


        private List<DomainAmbientHouse.Entidades.CostoAdicionales> CostoAdicionalesSalida
        {
            get
            {
                return Session["CostoAdicionalesSalida"] as List<DomainAmbientHouse.Entidades.CostoAdicionales>;
            }
            set
            {
                Session["CostoAdicionalesSalida"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonImportar.Visible = false;
                CostoAdicionalesSalida = new List<CostoAdicionales>();

                CargarListaProveedores();
            }

        }

        private void CargarListaProveedores()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());

            DropDownListProveedores.DataSource = serviciosEventos.ObtenerProveedoresCotizador();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();


            DropDownListLocaciones.DataSource = serviciosEventos.TraerLocaciones();
            DropDownListLocaciones.DataTextField = "Descripcion";
            DropDownListLocaciones.DataValueField = "Id";
            DropDownListLocaciones.DataBind();
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

                    List<CostoAdicionales> CostoAdicionales = new List<CostoAdicionales>();


                    Parametros parametro = new Parametros();


                    try
                    {
                        parametro = servicios.BuscarParametro("RutaArchivoPrecioCostoCatering");

                        ruta = parametro.Valor + FileUpload1.FileName;


                        var manipulador = new ManipuladorExcel(ruta);
                        CostoAdicionales = manipulador.ObtenerCostoAdicionalesDesdeArchivo(CeldaInicio, CeldaFin).ToList();

                        //List<CostoCatering> Salida = new List<CostoCatering>();
                        foreach (var costoAdicional in CostoAdicionales)
                        {
                            CostoAdicionales cosCa = new CostoAdicionales();

                            cosCa.AdicionalId = costoAdicional.AdicionalId;
                            cosCa.Precio = Math.Round(costoAdicional.Precio, 0);
                            cosCa.CantidadPersonas = costoAdicional.CantidadPersonas;
                            cosCa.ValorMas5PorCiento = Math.Round(costoAdicional.ValorMas5PorCiento, 0);
                            cosCa.ValorMenos5PorCiento = Math.Round(costoAdicional.ValorMenos5PorCiento, 0);
                            cosCa.ValorMenos10PorCiento = Math.Round(costoAdicional.ValorMenos10PorCiento, 0);
                            cosCa.AdicionalDescripcion = costoAdicional.AdicionalDescripcion;

                            if (DropDownListProveedores.SelectedItem.Value != null)
                            {
                                cosCa.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());
                            }
                            else if (DropDownListLocaciones.SelectedItem.Value != null)
                            {
                                cosCa.Locacion = Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString());
                            }

                            CostoAdicionalesSalida.Add(cosCa);
                        }

                        if (CostoAdicionalesSalida.Count > 0)
                        {
                            GridViewCostoAdicionales.DataSource = CostoAdicionalesSalida.ToList();
                            GridViewCostoAdicionales.DataBind();

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
            servicios.ImportarCostosAdicionales(CostoAdicionalesSalida, Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString()), Int32.Parse(DropDownListLocaciones.SelectedItem.Value.ToString()));
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Adicionales/Index.aspx");
        }
    }
}