using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;

namespace AmbientHouse.Costos.Canon
{
    public partial class Editar : System.Web.UI.Page
    {

        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios serviciosEventos = new EventosServicios();

        private DomainAmbientHouse.Entidades.CostoCanon CostoCanonSeleccionado
        {
            get
            {
                return Session["CostoCanonSeleccionado"] as DomainAmbientHouse.Entidades.CostoCanon;
            }
            set
            {
                Session["CostoCanonSeleccionado"] = value;
            }
        }

        private int CostoCanonId
        {
            get
            {
                return Int32.Parse(Session["CostoCanonId"].ToString());
            }
            set
            {
                Session["CostoCanonId"] = value;
            }
        }

        private string IsEditable
        {
            get
            {
                return (Session["IsEditable"].ToString());
            }
            set
            {
                Session["IsEditable"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LabelErrores.Visible = false;

                CargarListas();
                InicializarPagina();

            }
        }

        private void CargarListas()
        {
            DropDownListCaracteristica.DataSource = serviciosEventos.TraerCaracteristicas();
            DropDownListCaracteristica.DataTextField = "Descripcion";
            DropDownListCaracteristica.DataValueField = "Id";
            DropDownListCaracteristica.DataBind();


            DropDownListSegmento.DataSource = serviciosEventos.TraerSegmentos();
            DropDownListSegmento.DataTextField = "Descripcion";
            DropDownListSegmento.DataValueField = "Id";
            DropDownListSegmento.DataBind();

            DropDownListTipoCatering.DataSource = serviciosEventos.TraerTipoCateringSoloActivos();
            DropDownListTipoCatering.DataTextField = "Descripcion";
            DropDownListTipoCatering.DataValueField = "Id";
            DropDownListTipoCatering.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                CostoCanonId = id;
            }


            if (id == 0)
            {
                NuevoCostoCannon();
                IsEditable = "N";
            }
            else
            {
                EditarCostoCannon(id);
                IsEditable = "S";
            }

            SetFocus(TextBoxCannonInterno);
        }

        private void EditarCostoCannon(int id)
        {

            DomainAmbientHouse.Entidades.CostoCanon cc = new DomainAmbientHouse.Entidades.CostoCanon();

            cc = servicios.BuscarCostoCannon(id);

            CostoCanonSeleccionado = cc;


            TextBoxCannonInterno.Text = cc.CanonInterno.ToString();
            TextBoxCannonExterno.Text = cc.CanonExterno.ToString();

            DropDownListCaracteristica.SelectedValue = cc.CaracteristicaId.ToString();
            DropDownListSegmento.SelectedValue = cc.SegmentoId.ToString();
            DropDownListTipoCatering.SelectedValue = cc.TipoCateringId.ToString();



        }

        private void NuevoCostoCannon()
        {
            CostoCanonSeleccionado = new DomainAmbientHouse.Entidades.CostoCanon();
        }

        private void GrabarCostoCannon()
        {

            if (IsEditable == "N")
            {
                CostoCanon edit = servicios.BuscarCostoCannon(Int32.Parse(DropDownListCaracteristica.SelectedItem.Value), Int32.Parse(DropDownListSegmento.SelectedItem.Value), Int32.Parse(DropDownListSegmento.SelectedItem.Value));

                if (edit == null)
                {

                    DomainAmbientHouse.Entidades.CostoCanon cc = CostoCanonSeleccionado;

                    cc.CanonExterno = double.Parse(TextBoxCannonExterno.Text);
                    cc.CanonInterno = double.Parse(TextBoxCannonInterno.Text);

                    cc.CaracteristicaId = Int32.Parse(DropDownListCaracteristica.SelectedItem.Value);
                    cc.SegmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value);
                    cc.TipoCateringId = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value);


                    servicios.NuevoCostoCannon(cc);
                    Response.Redirect("~/Costos/Canon/Index.aspx");
                }
                else
                {
                    LabelErrores.Text = "Ya Existe esa configuracion de CANNON.";
                    LabelErrores.Visible = true;
                }
            }
            else
            {
                DomainAmbientHouse.Entidades.CostoCanon cc = CostoCanonSeleccionado;

                cc.CanonExterno = double.Parse(TextBoxCannonExterno.Text);
                cc.CanonInterno = double.Parse(TextBoxCannonInterno.Text);

                cc.CaracteristicaId = Int32.Parse(DropDownListCaracteristica.SelectedItem.Value);
                cc.SegmentoId = Int32.Parse(DropDownListSegmento.SelectedItem.Value);
                cc.TipoCateringId = Int32.Parse(DropDownListTipoCatering.SelectedItem.Value);


                servicios.NuevoCostoCannon(cc);
                Response.Redirect("~/Costos/Canon/Index.aspx");
            }

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarCostoCannon();
        }



        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Canon/Index.aspx");
        }


    }
}