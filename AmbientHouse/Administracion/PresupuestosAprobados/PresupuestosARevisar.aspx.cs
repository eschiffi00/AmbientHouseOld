using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.PresupuestosAprobados
{
    public partial class PresupuestosARevisar : System.Web.UI.Page
    {
        private int EventoId
        {
            get
            {
                return Int32.Parse(Session["EventoId"].ToString());
            }
            set
            {
                Session["EventoId"] = value;
            }
        }

        private int EmpleadoId
        {
            get
            {
                return Int32.Parse(Session["EmpleadoId"].ToString());
            }
            set
            {
                Session["EmpleadoId"] = value;
            }
        }

        private int PerfilId
        {
            get
            {
                return Int32.Parse(Session["PerfilId"].ToString());
            }
            set
            {
                Session["PerfilId"] = value;
            }
        }

        private int PresupuestoId
        {
            get
            {
                return Int32.Parse(Session["PresupuestoId"].ToString());
            }
            set
            {
                Session["PresupuestoId"] = value;
            }
        }

        private double PorcentajeOrganizador
        {
            get
            {
                return double.Parse(Session["PorcentajeOrganizadorApro"].ToString());
            }
            set
            {
                Session["PorcentajeOrganizadorApro"] = value;
            }
        }

        private double ImporteOrganizador
        {
            get
            {
                return double.Parse(Session["ImporteOrganizadorApro"].ToString());
            }
            set
            {
                Session["ImporteOrganizadorApro"] = value;
            }
        }

        private List<PresupuestoDetalle> ListPresupuestoDetalle
        {
            get
            {
                return Session["ListPresupuestoDetalle"] as List<PresupuestoDetalle>;
            }
            set
            {
                Session["ListPresupuestoDetalle"] = value;
            }
        }

        EventosServicios eventos = new EventosServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListPresupuestoDetalle = new List<PresupuestoDetalle>();

                Inicializar();
                CargarDetalle();
            }
        }
        private void Inicializar()
        {

            int id = 0;
            EventoId = 0;
            PresupuestoId = 0;

            if (Request["EventoId"] != null)
            {
                id = Int32.Parse(Request["EventoId"]);

                EventoId = id;

                //TextBoxNroEvento.Text = EventoId.ToString().PadLeft(8, '0');
            }

            if (Request["PresupuestoId"] != null)
            {
                PresupuestoId = Int32.Parse(Request["PresupuestoId"]);
                //TextBoxNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');

                DomainAmbientHouse.Entidades.Presupuestos presupuesto = presupuestos.BuscarPresupuesto(PresupuestoId);

                if (presupuesto.ValorOrganizador != null)
                    TextBoxValorOrganizador.Text = presupuesto.ValorOrganizador.ToString();

                TextBoxComentario.Text = presupuesto.Comentario;
            }

            eventos.BuscarEventosTable(EventoId, PresupuestoId, TableTipoCatering);

            //TextBoxComentarioEvento.Text = eventos.BuscarEvento(EventoId).Comentario;

            //TextBoxComentarioPresupuesto.Text = presupuestos.BuscarPresupuesto(PresupuestoId).Comentario;

        }




        private void CargarDetalle()
        {
            ListPresupuestoDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);

            GridViewVentas.DataSource = ListPresupuestoDetalle.ToList();
            GridViewVentas.DataBind();

            TextBoxTotal.Text = System.Math.Round(cmd.CalcularTotalPresupuestoPendiente(PresupuestoId, ListPresupuestoDetalle, 0, 0), 2).ToString();



            UpdatePanelPresupuesto.Update();
        }

        protected void GridViewVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox usoCocina = (TextBox)e.Row.FindControl("TextBoxUsoCocina");
                TextBox canon = (TextBox)e.Row.FindControl("TextBoxCanon");
                TextBox logistica = (TextBox)e.Row.FindControl("TextBoxLogistica");
                TextBox fee = (TextBox)e.Row.FindControl("TextBoxFee");

                TextBox costo = (TextBox)e.Row.FindControl("TextBoxCosto");
                TextBox precio = (TextBox)e.Row.FindControl("TextBoxPrecio");


                int id = Int32.Parse(e.Row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(id);

                if (detalle.UsoCocina != null)
                    usoCocina.Text = System.Math.Round((double)detalle.UsoCocina, 2).ToString();

                if (detalle.ValorIntermediario != null)
                    fee.Text = System.Math.Round((double)detalle.ValorIntermediario, 2).ToString();

                if (detalle.Cannon != null)
                    canon.Text = System.Math.Round((double)detalle.Cannon, 2).ToString();

                if (detalle.Logistica != null)
                    logistica.Text = System.Math.Round((double)detalle.Logistica, 2).ToString();

                if (detalle.Costo != null)
                    costo.Text = System.Math.Round((double)detalle.Costo, 2).ToString();

                if (detalle.ValorSeleccionado != null)
                    precio.Text = System.Math.Round(detalle.ValorSeleccionado, 2).ToString();


            }
        }

        protected void GridViewVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                TextBox usoCocina = (TextBox)row.FindControl("TextBoxUsoCocina");
                TextBox canon = (TextBox)row.FindControl("TextBoxCanon");
                TextBox logistica = (TextBox)row.FindControl("TextBoxLogistica");
                TextBox fee = (TextBox)row.FindControl("TextBoxFee");

                TextBox costo = (TextBox)row.FindControl("TextBoxCosto");
                TextBox precio = (TextBox)row.FindControl("TextBoxPrecio");


                int id = int.Parse(row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(id);


                if (cmd.IsNumeric(usoCocina.Text))
                    detalle.UsoCocina = cmd.ValidarImportes(usoCocina.Text);

                if (cmd.IsNumeric(fee.Text))
                    detalle.ValorIntermediario = cmd.ValidarImportes(fee.Text);

                if (cmd.IsNumeric(canon.Text))
                    detalle.Cannon = cmd.ValidarImportes(canon.Text);

                if (cmd.IsNumeric(logistica.Text))
                    detalle.Logistica = cmd.ValidarImportes(logistica.Text);

                if (cmd.IsNumeric(costo.Text))
                    detalle.Costo = cmd.ValidarImportes(costo.Text);

                if (cmd.IsNumeric(precio.Text))
                    detalle.ValorSeleccionado = cmd.ValidarImportes(precio.Text);


                if (presupuestos.EditarDetallePresupuesto(detalle))
                    CargarDetalle();


            }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            int PresupuestoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());


            DomainAmbientHouse.Entidades.Presupuestos editar = eventos.BuscarPresupuesto(PresupuestoId);


            editar.EstadoId = PresupuestoEnviado;

            if (cmd.IsNumeric(TextBoxValorOrganizador.Text))
                editar.ValorOrganizador = cmd.ValidarImportes(TextBoxValorOrganizador.Text);

            editar.Comentario = TextBoxComentario.Text;

            eventos.GuardarPresupuesto(editar);

            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }
    }
}