using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.Cuentas
{
    public partial class Index : System.Web.UI.Page
    {

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

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (cmd.Logeado(EmpleadoId))
                    BuscarCuentas();
                else
                    Response.Redirect("~/Error/NoTienePermisos.aspx");

            }

        }

        private void BuscarCuentas()
        {

            GridViewCuentas.DataSource = administracion.ObtenerCuentas();
            GridViewCuentas.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewCuentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCuentas.PageIndex = e.NewPageIndex;

            BuscarCuentas();
        }

        protected void GridViewCuentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button Ingresos = (Button)e.Row.FindControl("ButtonIngreso");
                Button Egresos = (Button)e.Row.FindControl("ButtonEgreso");
                Button Movimientos = (Button)e.Row.FindControl("ButtonVerMovimientos");
                Button Transferir = (Button)e.Row.FindControl("ButtonTransferir");
                Button Conciliar = (Button)e.Row.FindControl("ButtonConciliar");

                Ingresos.Visible = false;
                Egresos.Visible = false;
                Movimientos.Visible = false;
                Transferir.Visible = false;
                Conciliar.Visible = false;

                int cuentaId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Cuentas cuenta = administracion.BuscarCuenta(cuentaId);


                switch (cuenta.TipoCuenta)
                {
                    case "EFECTIVO":
                        Ingresos.Visible = true;
                        Egresos.Visible = true;
                        Movimientos.Visible = true;
                        Transferir.Visible = true;
                        Conciliar.Visible = true;
                        break;
                    case "BANCARIA":
                        Ingresos.Visible = true;
                        Egresos.Visible = true;
                        Movimientos.Visible = true;
                        Transferir.Visible = true;
                        Conciliar.Visible = true;
                        break;
                    default:
                        break;
                }

            }
        }

        protected void GridViewCuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ingreso")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCuentas.Rows[index];

                int cuentaId = Int32.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/Cuentas/Ingreso.aspx?Id=" + cuentaId);


            }
            else if (e.CommandName == "Egreso")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCuentas.Rows[index];

                int cuentaId = Int32.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/Cuentas/Egreso.aspx?Id=" + cuentaId);
            }
            else if (e.CommandName == "Movimientos")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCuentas.Rows[index];

                int cuentaId = Int32.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/Cuentas/Movimientos.aspx?Id=" + cuentaId);
            }
            else if (e.CommandName == "Transferir")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCuentas.Rows[index];

                int cuentaId = Int32.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/Cuentas/Transferencias.aspx?Id=" + cuentaId);
            }
            else if (e.CommandName == "Conciliar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCuentas.Rows[index];

                int cuentaId = Int32.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/Cuentas/Conciliar.aspx?Id=" + cuentaId);
            }
            else if (e.CommandName == "Rectificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCuentas.Rows[index];

                int cuentaId = Int32.Parse(row.Cells[0].Text);

                Response.Redirect("~/Administracion/Cuentas/Rectificatoria.aspx?Id=" + cuentaId);
            }


            BuscarCuentas();
            UpdatePanelGrillaCuentas.Update();
        }
    }
}