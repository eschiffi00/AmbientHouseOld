using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Costos.Logistica
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();
        EventosServicios servicios = new EventosServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
                BuscarCostoLogostica();
            }

        }

        private void BuscarCostoLogostica()
        {
            int tipoLogistica = 0;
            if ((DropDownListTipoLogisticaBuscador.SelectedItem.Value != "null"))
                tipoLogistica = Int32.Parse(DropDownListTipoLogisticaBuscador.SelectedItem.Value);


            int localidad = 0;
            if ((DropDownListLocalidadBuscador.SelectedItem.Value != "null"))
                localidad = Int32.Parse(DropDownListLocalidadBuscador.SelectedItem.Value);


            int tipoEvento = 0;
            if ((DropDownListTipoEvento.SelectedItem.Value != "null"))
                tipoEvento = Int32.Parse(DropDownListTipoEvento.SelectedItem.Value);

            GridViewCostoLogistica.DataSource = servicios.ObtenerCostosLogisticas(tipoLogistica,
                localidad,
                DropDownListCantidadInvitadosBuscador.SelectedItem.Value,
                tipoEvento);

            GridViewCostoLogistica.DataBind();

            UpdatePanelGrillaCostoLogistica.Update();
        }

        private void CargarListas()
        {
            DropDownListTipoLogisticaBuscador.DataSource = administracion.ObtenerTipoLogistica();
            DropDownListTipoLogisticaBuscador.DataTextField = "Concepto";
            DropDownListTipoLogisticaBuscador.DataValueField = "Id";
            DropDownListTipoLogisticaBuscador.DataBind();



            DropDownListLocalidadBuscador.DataSource = administracion.ObtenerLocalidades();
            DropDownListLocalidadBuscador.DataTextField = "Descripcion";
            DropDownListLocalidadBuscador.DataValueField = "Id";
            DropDownListLocalidadBuscador.DataBind();

            List<ObtenerCantidadInvitadosCatering> Cantidades = servicios.TraerCantidadPersonasCateringAdicionales();

            DropDownListCantidadInvitadosBuscador.DataSource = Cantidades.ToList();
            DropDownListCantidadInvitadosBuscador.DataTextField = "CantidadPersonas";
            DropDownListCantidadInvitadosBuscador.DataValueField = "CantidadPersonas";
            DropDownListCantidadInvitadosBuscador.DataBind();


            DropDownListTipoEvento.DataSource = servicios.TraerTipoEvento();
            DropDownListTipoEvento.DataTextField = "Descripcion";
            DropDownListTipoEvento.DataValueField = "Id";
            DropDownListTipoEvento.DataBind();

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/Logistica/Editar.aspx");
        }

        protected void GridViewCostoLogistica_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCostoLogistica.PageIndex = e.NewPageIndex;
            BuscarCostoLogostica();
        }

        protected void GridViewCostoLogistica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCostoLogistica.Rows[index];

                TextBox precio = row.FindControl("TextBoxPrecio") as TextBox;
                TextBox costo = row.FindControl("TextBoxCosto") as TextBox;
                TextBox margen = row.FindControl("TextBoxMargen") as TextBox;



                int id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.CostoLogistica costos = servicios.BuscarCostoLogistica(id);


                double dCosto = 0;
                double dPrecio = 0;
                double dMargen = 0;



                if (cmd.IsNumeric(costo.Text))
                    dCosto = double.Parse(costo.Text);

                if (cmd.IsNumeric(precio.Text))
                    dPrecio = double.Parse(precio.Text);

                if (cmd.IsNumeric(margen.Text))
                    dMargen = double.Parse(margen.Text);

                if (costos.Valor != double.Parse(precio.Text))
                {
                    costos.Valor = dPrecio;
                    costos.Costo = dCosto;
                    costos.Margen = dPrecio / dCosto;
                }
                else
                {

                    costos.Valor = dCosto * dMargen;
                    costos.Costo = dCosto;
                    costos.Margen = dMargen;

                }



                try
                {
                    servicios.ActualizarCostoLogistica(costos);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            BuscarCostoLogostica();

        }

        protected void GridViewCostoLogistica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox Precio = (TextBox)e.Row.FindControl("TextBoxPrecio");
                TextBox Costo = (TextBox)e.Row.FindControl("TextBoxCosto");
                TextBox Margen = (TextBox)e.Row.FindControl("TextBoxMargen");



                int id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.CostoLogistica costo = servicios.BuscarCostoLogistica(id);

                Precio.Text = costo.Valor.ToString();
                Costo.Text = costo.Costo.ToString();
                Margen.Text = costo.Margen.ToString();

            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarCostoLogostica();
        }
    }
}