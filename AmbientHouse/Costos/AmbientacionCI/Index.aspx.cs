using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;


namespace AmbientHouse.Costos.AmbientacionCI
{
    public partial class Index : System.Web.UI.Page
    {

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            GridViewAmbientacion.DataSource = administracion.ObtenerCostoPreciosAmbientacionCI();
            GridViewAmbientacion.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Costos/AmbientacionCI/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Index.aspx");
        }

        protected void GridViewAmbientacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAmbientacion.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void GridViewAmbientacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewAmbientacion.Rows[index];

                TextBox precio = row.FindControl("TextBoxPrecio") as TextBox;
                TextBox costo = row.FindControl("TextBoxCosto") as TextBox;
                TextBox costoFlete = (TextBox)row.FindControl("TextBoxCostoFlete");
                TextBox margen = row.FindControl("TextBoxMargen") as TextBox;
               
             



                int Id = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion costos = administracion.BuscarCostosPaquetesCIAmbientacion(Id);


                double dCosto = 0;
                double dPrecio = 0;
                double dMargen = 0;



                if (cmd.IsNumeric(costo.Text))
                    dCosto = double.Parse(costo.Text);

                if (cmd.IsNumeric(precio.Text))
                    dPrecio = double.Parse(precio.Text);

                if (cmd.IsNumeric(margen.Text))
                    dMargen = double.Parse(margen.Text);

                if ((int)costos.Precio != (int)double.Parse(precio.Text))
                {
                    costos.Precio = dPrecio;
                    costos.Costo = dCosto;
                    costos.Margen = dPrecio / dCosto;
                }
                else if ((int)costos.Costo != (int)double.Parse(costo.Text))
                {
                    costos.Costo = dCosto;
                    costos.Precio = dCosto * (double)costos.Margen;

                }
                else
                {

                    costos.Precio = dCosto * dMargen;
                    costos.Costo = dCosto;
                    costos.Margen = dMargen;

                }

                if (cmd.IsNumeric(costoFlete.Text))
                    costos.CostoFlete = Int32.Parse(costoFlete.Text);


                try
                {
                    administracion.GrabarCostoPreciosAmbientacionCI(costos);
                }
                catch (Exception)
                {

                    throw;
                }


            }

            Buscar();
            UpdatePanelGrillaAmbientacion.Update();
        }

        protected void GridViewAmbientacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox CostoFlete = (TextBox)e.Row.FindControl("TextBoxCostoFlete");
                TextBox Precio = (TextBox)e.Row.FindControl("TextBoxPrecio");
                TextBox Costo = (TextBox)e.Row.FindControl("TextBoxCosto");
                TextBox Margen = (TextBox)e.Row.FindControl("TextBoxMargen");

                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.CostosPaquetesCIAmbientacion item = administracion.BuscarCostosPaquetesCIAmbientacion(ItemId);

                CostoFlete.Text = item.CostoFlete.ToString();
                Costo.Text = item.Costo.ToString();
                Precio.Text = item.Precio.ToString();
                Margen.Text = item.Margen.ToString();


              
            }
        }
    }
}