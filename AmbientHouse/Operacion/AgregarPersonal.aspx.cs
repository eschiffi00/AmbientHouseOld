using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace AmbientHouse.Operacion
{
    public partial class AgregarPersonal : System.Web.UI.Page
    {
        private string Fecha
        {
            get
            {
                return Session["Fecha"].ToString();
            }
            set
            {
                Session["Fecha"] = value;
            }
        }

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

        private int ClienteId
        {
            get
            {
                return Int32.Parse(Session["ClienteId"].ToString());
            }
            set
            {
                Session["ClienteId"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.PersonalEventos> Personal
        {
            get
            {
                return Session["ListPersonal"] as List<DomainAmbientHouse.Entidades.PersonalEventos>;
            }
            set
            {
                Session["ListPersonal"] = value;
            }
        }

        AdministrativasServicios administrativa = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Personal = new List<DomainAmbientHouse.Entidades.PersonalEventos>();

                CargarListas();

                InicializarPagina();
            }
        }

        private void InicializarPagina()
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

            //CargarEvento();

            //CargarPresupuesto();

            //List<DomainAmbientHouse.Entidades.PersonalEventos> Personal = administrativa.BuscarPersonalEvento(EventoId);

            //GridViewEmpleadosEventos.DataSource = Personal.ToList();
            //GridViewEmpleadosEventos.DataBind();

        }

        private void CargarListas()
        {

            DropDownListTipoEmpleado.DataSource = administrativa.ObtenerTipoEmpleados();
            DropDownListTipoEmpleado.DataTextField = "Descripcion";
            DropDownListTipoEmpleado.DataValueField = "Id";
            DropDownListTipoEmpleado.DataBind();

        }

        protected void DropDownListTipoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListTipoEmpleado.SelectedItem != null)
            {
                int tipoEmpleadoId = Int32.Parse(DropDownListTipoEmpleado.SelectedItem.Value);

                DropDownListEmpleados.Items.Clear();
                DropDownListEmpleados.DataSource = administrativa.ObtenerEmpleadosPorTipoEmpleado(tipoEmpleadoId);
                DropDownListEmpleados.DataTextField = "ApellidoNombre";
                DropDownListEmpleados.DataValueField = "Id";
                DropDownListEmpleados.DataBind();

            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            //DomainAmbientHouse.Entidades.PersonalEventos personal = new DomainAmbientHouse.Entidades.PersonalEventos();

            //personal.EmpleadoId = Int32.Parse(DropDownListEmpleados.SelectedItem.Value);
            //personal.EmpleadoApellidoNombre = DropDownListEmpleados.SelectedItem.Text;
            //personal.TipoEmpleadoDescripcion = DropDownListTipoEmpleado.SelectedItem.Text;


            //Personal.Add(personal);

            //GridViewEmpleadosEventos.DataSource = Personal.ToList();
            //GridViewEmpleadosEventos.DataBind();

            //UpdatePanelGrilla.Update();
        }

        protected void GridViewEmpleadosEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "QuitarItem")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = GridViewEmpleadosEventos.Rows[index];

            //    DomainAmbientHouse.Entidades.PersonalEventos personal = new DomainAmbientHouse.Entidades.PersonalEventos();

            //    personal.EmpleadoId = Int32.Parse(row.Cells[0].Text);

            //    var itemRemove = Personal.Where(o => o.EmpleadoId == personal.EmpleadoId).Single();

            //    if (itemRemove  != null)
            //    {
            //        Personal.Remove(itemRemove);
            //    }

            //    GridViewEmpleadosEventos.DataSource = Personal.ToList();
            //    GridViewEmpleadosEventos.DataBind();

            //    UpdatePanelGrilla.Update();

            //}
        }

    }
}