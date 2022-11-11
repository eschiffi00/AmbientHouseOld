using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Configuration;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Cobranzas
{
    public partial class Index : System.Web.UI.Page
    {
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void BuscarItemsNoPagos()
        {
            int presupuestoId = 0;

            if (cmd.IsNumeric(TextBoxNroPresupuestoBuscador.Text))
                presupuestoId = Int32.Parse(TextBoxNroPresupuestoBuscador.Text);

            GridViewItems.DataSource = presupuestos.BuscarDetallePresupuestoNoPagos(presupuestoId, TextBoxFechaEvento.Text, TextBoxClienteBuscador.Text);
            GridViewItems.DataBind();

            UpdatePanelGrillas.Update();

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarItemsNoPagos();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxClienteBuscador.Text = "";
            TextBoxNroPresupuestoBuscador.Text = "";
            TextBoxFechaEvento.Text = "";

        }

        protected void GridViewItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cobrado")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewItems.Rows[index];

                int Id = int.Parse(row.Cells[0].Text);

                if (presupuestos.ActualizarCobroItem(Id))
                {
                    BuscarItemsNoPagos();
                    UpdatePanelGrillas.Update();
                }

            }
        }

        protected void GridViewItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int cobrado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleCobrado"].ToString()); ;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button pagado = (Button)e.Row.FindControl("ButtonPagado");

                Label FechaPagado = (Label)e.Row.FindControl("Fecha");

                int Id = int.Parse(e.Row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(Id);


                if (detalle.EstadoId == cobrado)
                {
                    pagado.Visible = false;

                    FechaPagado.Text = String.Format("{0:dd/MM/yyyy}", detalle.FechaCobroItem);
                }

            }
        }
    }
}