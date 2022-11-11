using DomainAmbientHouse.Servicios;
using System;
using System.Web.UI.WebControls;

namespace AmbientHouse.RRHH.Empleados
{
    public partial class Index : System.Web.UI.Page
    {

        EmpleadosServicios servicios = new EmpleadosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarEmpleados();

            }
        }

        private void BuscarEmpleados()
        {

            DomainAmbientHouse.Entidades.EmpleadosSearcher searcher = new DomainAmbientHouse.Entidades.EmpleadosSearcher();

            searcher.ApellidoNombre = TextBoxApellidoyNombre.Text;

            GridViewEmpleados.DataSource = servicios.ListarEmpleados(searcher);
            GridViewEmpleados.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RRHH/Empleados/Editar.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
        }

        protected void GridViewEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmpleados.PageIndex = e.NewPageIndex;
            BuscarEmpleados();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleados();
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxApellidoyNombre.Text = "";
            BuscarEmpleados();
        }
    }
}