using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Stock.Existencias
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

        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();


        protected void Page_Load(object sender, EventArgs e)
        {
            int PerfilStock = int.Parse(ConfigurationManager.AppSettings["Stock"].ToString());
            int PerfilStockCarga = int.Parse(ConfigurationManager.AppSettings["StockCarga"].ToString());
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());

            if (!IsPostBack)
            {

                CargarListas();
                Buscar();

                if (PerfilId == PerfilStock)
                {
                    ButtonNuevo.Visible = false;
                }
                else if (PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
                {
                    ButtonNuevo.Visible = true;
                }

            }
        }

        private void CargarListas()
        {
            DropDownListRubros.DataSource = administracion.ObtenerRubros().Where(o => o.RubroId == 16 || o.RubroId == 17).ToList();
            DropDownListRubros.DataTextField = "Descripcion";
            DropDownListRubros.DataValueField = "RubroId";
            DropDownListRubros.DataBind();


            DropDownListDepositos.DataSource = administracion.ObtenerDepositos();
            DropDownListDepositos.DataTextField = "Descripcion";
            DropDownListDepositos.DataValueField = "Id";
            DropDownListDepositos.DataBind();

        }

        private void Buscar()
        {
            List<DomainAmbientHouse.Entidades.Existencias> List = administracion.ListarExistencias(TextBoxDescripcionBuscador.Text
                                                                            , TextBoxCodigoBuscador.Text
                                                                            , Int32.Parse(DropDownListDepositos.SelectedItem.Value)
                                                                            , Int32.Parse(DropDownListRubros.SelectedItem.Value));

            GridViewExistencias.DataSource = List.ToList();
            GridViewExistencias.DataBind();

            UpdatePanelGrillaProductos.Update();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Stock/Existencias/Editar.aspx");
        }

        protected void GridViewExistencias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ingreso")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewExistencias.Rows[index];

                TextBox Cantidad = (TextBox)row.FindControl("TextBoxCantidad");

                int ProductoId = Int32.Parse(row.Cells[0].Text);
                int DepositoId = Int32.Parse(row.Cells[1].Text);


                DomainAmbientHouse.Entidades.Existencias existencia = administracion.BuscarExistencias(ProductoId, DepositoId);

                if (cmd.IsNumeric(Cantidad.Text))
                    existencia.Cantidad = double.Parse(Cantidad.Text);


                try
                {
                    existencia.EmpleadoId = EmpleadoId;

                    administracion.GuardarExistencia(existencia);
                }
                catch (Exception)
                {

                    throw;
                }


            }
            else if (e.CommandName == "Egreso")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewExistencias.Rows[index];

                TextBox Cantidad = (TextBox)row.FindControl("TextBoxCantidad");

                int ProductoId = Int32.Parse(row.Cells[0].Text);
                int DepositoId = Int32.Parse(row.Cells[1].Text);


                DomainAmbientHouse.Entidades.Existencias existencia = administracion.BuscarExistencias(ProductoId, DepositoId);

                if (cmd.IsNumeric(Cantidad.Text))
                    existencia.Cantidad = double.Parse(Cantidad.Text) * -1;

                try
                {
                    existencia.EmpleadoId = EmpleadoId;

                    administracion.GuardarExistencia(existencia);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else if (e.CommandName == "Editar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewExistencias.Rows[index];

                int ProductoId = Int32.Parse(row.Cells[0].Text);
                int DepositoId = Int32.Parse(row.Cells[1].Text);

                Response.Redirect("~/Stock/Existencias/Editar.aspx?ProductoId=" + ProductoId + "&DepositoId=" + DepositoId);

            }

            Buscar();
            UpdatePanelGrillaProductos.Update();
        }

        protected void GridViewExistencias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int PerfilStockCarga = int.Parse(ConfigurationManager.AppSettings["StockCarga"].ToString());
            int PerfilCoordinador = Int32.Parse(ConfigurationManager.AppSettings["CoordinadorVentas"].ToString());
            int PerfilGerencial = Int32.Parse(ConfigurationManager.AppSettings["Gerencial"].ToString());

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button editar = (Button)e.Row.FindControl("ButtonEditar");
                Button ingreso = (Button)e.Row.FindControl("ButtonIngreso");
                Button egreso = (Button)e.Row.FindControl("ButtonEgreso");
                TextBox cantidad = (TextBox)e.Row.FindControl("TextBoxCantidad");


                int ProductoId = Int32.Parse(e.Row.Cells[0].Text);
                int DepositoId = Int32.Parse(e.Row.Cells[1].Text);

                editar.Visible = false;
                ingreso.Visible = false;
                egreso.Visible = false;
                cantidad.Visible = false;
                if (DepositoId > 0 && PerfilId == PerfilStockCarga)
                {
                    editar.Visible = true;
                    ingreso.Visible = true;
                    egreso.Visible = true;
                    cantidad.Visible = true;
                }
                else if (DepositoId > 0 && PerfilId == PerfilCoordinador || PerfilId == PerfilGerencial)
                {
                    editar.Visible = true;
                    ingreso.Visible = true;
                    egreso.Visible = true;
                    cantidad.Visible = true;
                }

                else if (DepositoId > 0 && EmpleadoId == 205 || EmpleadoId == 258 || EmpleadoId == 236)
                {
                    editar.Visible = true;
                    ingreso.Visible = true;
                    egreso.Visible = true;
                    cantidad.Visible = true;
                }
            }
        }

        protected void GridViewExistencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewExistencias.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxDescripcionBuscador.Text = "";
            TextBoxCodigoBuscador.Text = "";
            DropDownListDepositos.SelectedValue = "0";
            DropDownListRubros.SelectedValue = "0";

            Buscar();
        }

    }
}