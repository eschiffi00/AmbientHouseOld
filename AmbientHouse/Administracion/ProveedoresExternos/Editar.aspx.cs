using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.ProveedoresExternos
{
    public partial class Editar : System.Web.UI.Page
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

        EventosServicios eventos = new EventosServicios();
        PresupuestosServicios presupuestos = new PresupuestosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            }

            eventos.BuscarEventosTable(EventoId, PresupuestoId, TableTipoCatering);

            TextBoxComentarioEvento.Text = eventos.BuscarEvento(EventoId).Comentario;

            TextBoxComentarioPresupuesto.Text = presupuestos.BuscarPresupuesto(PresupuestoId).Comentario;

        }

        private void CargarDetalle()
        {
            List<PresupuestoDetalle> ListPresuDetalle = presupuestos.BuscarDetallePresupuesto(PresupuestoId);

            GridViewVentas.DataSource = ListPresuDetalle.ToList();
            GridViewVentas.DataBind();
        }


        [System.Web.Services.WebMethod]
        public static string HelloWorld()
        {
            return "Hola";
        }

        private static HtmlTable TblEventos;

        [System.Web.Services.WebMethod]
        public static void GetDatos()
        {
            EventosServicios eventos = new EventosServicios();

            TblEventos = new HtmlTable();

            eventos.BuscarEventosTable(9057, 14660, TblEventos);



        }

        protected void GridViewVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtComentarioProveedor = (TextBox)e.Row.FindControl("TextBoxComentarioProoveedor");
                ImageButton imgButton = (ImageButton)e.Row.FindControl("ImageButtonEstado");


                int Id = int.Parse(e.Row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(Id);

                txtComentarioProveedor.Text = detalle.ComentarioProveedor;

                if (detalle.EstadoProveedor == false || detalle.EstadoProveedor == null)
                    imgButton.ImageUrl = "~/Content/Imagenes/noaprobado.png";
                else
                    imgButton.ImageUrl = "~/Content/Imagenes/aprobado.png";

            }

        }

        protected void GridViewVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];

                TextBox txtComentarioProveedor = (TextBox)row.FindControl("TextBoxComentarioProoveedor");
                ImageButton imgButton = (ImageButton)row.FindControl("ImageButtonEstado");

                int Id = int.Parse(row.Cells[0].Text);

                PresupuestoDetalle detalle = presupuestos.BuscarPresupuestoDetalle(Id);

                if (imgButton.ImageUrl == "~/Content/Imagenes/noaprobado.png")
                    detalle.EstadoProveedor = false;
                else
                    detalle.EstadoProveedor = true;

                detalle.ComentarioProveedor = txtComentarioProveedor.Text;

                presupuestos.ActualizarDetallePresupuestos(detalle);

                CargarDetalle();

                UpdatePanelProveedores.Update();
            }
            else if (e.CommandName == "Estado")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewVentas.Rows[index];


                ImageButton imgButton = (ImageButton)row.FindControl("ImageButtonEstado");


                if (imgButton.ImageUrl == "~/Content/Imagenes/noaprobado.png")
                    imgButton.ImageUrl = "~/Content/Imagenes/aprobado.png";
                else
                    imgButton.ImageUrl = "~/Content/Imagenes/noaprobado.png";

                UpdatePanelProveedores.Update();

            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }

    }
}