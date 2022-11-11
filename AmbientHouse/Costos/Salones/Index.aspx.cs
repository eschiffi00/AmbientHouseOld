using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Salones
{
    public partial class Index : System.Web.UI.Page
    {

        EventosServicios servicios = new EventosServicios();
        Comun cmd = new Comun();

        private List<CostoSalones> ListCostoSalones
        {
            get
            {
                return Session["ListCostoSalones"] as List<CostoSalones>;
            }
            set
            {
                Session["ListCostoSalones"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarCostoSalones();

                ListCostoSalones = new List<CostoSalones>();


            }
        }

        private void BuscarCostoSalones()
        {
            GridViewPrecioSalones.DataSource = servicios.ObtenerCostoSalones();
            GridViewPrecioSalones.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Salones/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void GridViewPrecioSalones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPrecioSalones.PageIndex = e.NewPageIndex;
            BuscarCostoSalones();
        }

        //private void CargarListaLocaciones()
        //{
        //    DropDownListLocaciones.DataSource = servicios.TraerLocaciones();
        //    DropDownListLocaciones.DataTextField = "Descripcion";
        //    DropDownListLocaciones.DataValueField = "Id";
        //    DropDownListLocaciones.DataBind();

        //    DropDownListJornada.DataSource = servicios.TraerJornadas();
        //    DropDownListJornada.DataTextField = "Descripcion";
        //    DropDownListJornada.DataValueField = "Id";
        //    DropDownListJornada.DataBind();

        //    cmd.CargarAnios(DropDownListAnio);

        //    cmd.CargarMeses(DropDownListMes);

        //    cmd.CargarDias(DropDownListDia);

        //    List<ObtenerCantidadPersonasAdicionalesCatering> Cantidades = servicios.TraerCantidadPersonasCateringAdicionales();

        //    DropDownListCantidadInvitados.DataSource = Cantidades.ToList();
        //    DropDownListCantidadInvitados.DataTextField = "CantidadPersonas";
        //    DropDownListCantidadInvitados.DataValueField = "CantidadPersonas";
        //    DropDownListCantidadInvitados.DataBind();




        //}

        //protected void DropDownListLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownListLocaciones.SelectedItem.Value != null)
        //    {



        //        int seleccionado = Int32.Parse(this.DropDownListLocaciones.SelectedItem.Value.ToString());


        //        DropDownListSector.DataSource = servicios.BuscarSectoresPorLocacion(seleccionado);
        //        DropDownListSector.DataTextField = "Descripcion";
        //        DropDownListSector.DataValueField = "Id";
        //        DropDownListSector.DataBind();
        //    }

        //    UpdatePanelFiltros.Update();
        //}


    }
}