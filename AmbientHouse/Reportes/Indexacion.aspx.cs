using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Reportes
{
    public partial class Indexacion : System.Web.UI.Page
    {
        private List<DomainAmbientHouse.Entidades.SimuladorIndexacion> SimuladorIndexacionSeleccionado
        {
            get
            {
                return Session["SimuladorIndexacionSeleccionado"] as List<DomainAmbientHouse.Entidades.SimuladorIndexacion>;
            }
            set
            {
                Session["SimuladorIndexacionSeleccionado"] = value;
            }
        }

        AdministrativasServicios administrativas = new AdministrativasServicios();
        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SimuladorIndexacionSeleccionado = new List<DomainAmbientHouse.Entidades.SimuladorIndexacion>();
        }



        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            SimuladorIndexacion simular = new SimuladorIndexacion();

            simular.FechaPago = TextBoxFechaPago.Text;
            simular.Importe = TextBoxImporte.Text;

            SimuladorIndexacionSeleccionado.Add(simular);

            GridViewSimulador.DataSource = SimuladorIndexacionSeleccionado.ToList();
            GridViewSimulador.DataBind();

        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSimular_Click(object sender, EventArgs e)
        {


            List<PagosClientes> list = administrativas.ObtenerIndexacion(TextBoxFechaEvento.Text,
                                                                            cmd.ValidarImportes(TextBoxMontoTotal.Text),
                                                                            cmd.ValidarImportes(TextBoxIndexacion.Text),
                                                                            DropDownListTipoIndexacion.SelectedValue,
                                                                            SimuladorIndexacionSeleccionado);

            GridViewCuotas.DataSource = list.ToList();
            GridViewCuotas.DataBind();

        }

    }
}