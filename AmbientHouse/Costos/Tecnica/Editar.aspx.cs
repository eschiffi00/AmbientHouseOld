using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Tecnica
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


        private List<DomainAmbientHouse.Entidades.CostoTecnica> CostoTecnicaSalida
        {
            get
            {
                return Session["CostoTecnicaSalida"] as List<DomainAmbientHouse.Entidades.CostoTecnica>;
            }
            set
            {
                Session["CostoTecnicaSalida"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ButtonImportar.Visible = false;
                CostoTecnicaSalida = new List<CostoTecnica>();
                CargarListas();

            }
        }

        private void CargarListas()
        {
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());

            DropDownListProveedores.DataSource = serviciosEventos.TraerProveedoresPorRubro(RubroTecnica);
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();


            int AnioActual = DateTime.Now.Year;
            int AnioRango = AnioActual + 5;


            cmd.CargarAnios(DropDownListAnio);

            //for (int i = AnioActual; i < AnioRango; i++)
            //{

            //    ListItem anio = new ListItem();

            //    anio.Text = i.ToString();
            //    anio.Value = i.ToString();

            //    DropDownListAnio.Items.Add(anio);

            //}

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

                    List<CostoTecnica> CostosTecnica = new List<CostoTecnica>();


                    Parametros parametro = new Parametros();


                    try
                    {
                        parametro = servicios.BuscarParametro("RutaArchivoPrecioCostoCatering");

                        ruta = parametro.Valor + FileUpload1.FileName;


                        var manipulador = new ManipuladorExcel(ruta);
                        CostosTecnica = manipulador.ObtenerCostoTecnicaDesdeArchivo(CeldaInicio, CeldaFin).ToList();

                        //List<CostoCatering> Salida = new List<CostoCatering>();
                        foreach (var costoTecnica in CostosTecnica)
                        {
                            CostoTecnica cosCa = new CostoTecnica();

                            cosCa.TipoServicioId = costoTecnica.TipoServicioId;
                            cosCa.Precio = Math.Round(costoTecnica.Precio, 0);
                            cosCa.SegmentoId = costoTecnica.SegmentoId;
                            cosCa.ValorMas5PorCiento = Math.Round(costoTecnica.ValorMas5PorCiento, 0);
                            cosCa.ValorMenos5PorCiento = Math.Round(costoTecnica.ValorMenos5PorCiento, 0);
                            cosCa.ValorMenos10PorCiento = Math.Round(costoTecnica.ValorMenos10PorCiento, 0);
                            cosCa.TipoServicioDescripcion = costoTecnica.TipoServicioDescripcion;
                            cosCa.SegmentoDescripcion = costoTecnica.SegmentoDescripcion;
                            cosCa.Dia = costoTecnica.Dia;
                            cosCa.Mes = costoTecnica.Mes;
                            cosCa.Anio = Int32.Parse(DropDownListAnio.SelectedItem.Value.ToString());
                            cosCa.ProveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString());

                            CostoTecnicaSalida.Add(cosCa);
                        }

                        if (CostoTecnicaSalida.Count > 0)
                        {
                            GridViewCostoTecnica.DataSource = CostoTecnicaSalida.ToList();
                            GridViewCostoTecnica.DataBind();

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
            servicios.ImportarCostosTecnica(CostoTecnicaSalida, Int32.Parse(DropDownListProveedores.SelectedItem.Value.ToString()), Int32.Parse(DropDownListAnio.SelectedItem.Value.ToString()));
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Tecnica/Index.aspx");
        }

    }
}