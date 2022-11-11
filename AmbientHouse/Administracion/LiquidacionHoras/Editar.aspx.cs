using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.LiquidacionHoras
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();
        Comun cmd = new Comun();

        private List<DomainAmbientHouse.Entidades.LiquidacionHorasPersonal_Detalle> ListHorasPersonalDetalle
        {
            get
            {
                return Session["ListHorasPersonalDetalle"] as List<DomainAmbientHouse.Entidades.LiquidacionHorasPersonal_Detalle>;
            }
            set
            {
                Session["ListHorasPersonalDetalle"] = value;
            }
        }

        private DomainAmbientHouse.Entidades.LiquidacionHorasPersonal LiquidacionHorasPersonalSeleccionado
        {
            get
            {
                return Session["LiquidacionHorasPersonalSeleccionado"] as DomainAmbientHouse.Entidades.LiquidacionHorasPersonal;
            }
            set
            {
                Session["LiquidacionHorasPersonalSeleccionado"] = value;
            }
        }

        private int LiquidacionId
        {
            get
            {
                return Int32.Parse(Session["LiquidacionId"].ToString());
            }
            set
            {
                Session["LiquidacionId"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PanelAgregarEmpleados.Enabled = false;

                ListHorasPersonalDetalle = new List<LiquidacionHorasPersonal_Detalle>();

                InicializarPagina();

                CargarListas(DropDownListSectorEmpresa, DropDownListTipoPago);

                ObtenerTipoEmpleados(DropDownListSectorEmpresa, DropDownListTipoEmpleado);

                ObtenerEmpleados(DropDownListTipoEmpleado, DropDownListEmpleado);

            }

        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                LiquidacionId = id;
            }


            if (id == 0)
            { }
            else
            {
                EditarLiquidacion(id);
            }

            SetFocus(TextBoxDescripcion);
        }

        private void EditarLiquidacion(int id)
        {
            DomainAmbientHouse.Entidades.LiquidacionHorasPersonal liquidacion = new DomainAmbientHouse.Entidades.LiquidacionHorasPersonal();

            liquidacion = administracion.BuscarLiquidacionHorasPersonal(id);

            LiquidacionHorasPersonalSeleccionado = liquidacion;

            TextBoxDescripcion.Text = liquidacion.Descripcion;
            TextBoxFecha.Text = String.Format("{0:dd/MM/yyyy}", liquidacion.Fecha);
            TextBoxPresupuesto.Text = liquidacion.PresupuestoId.ToString();


            GridViewDetalle.DataSource = liquidacion.LiquidacionHorasPersonal_Detalle.ToList();
            GridViewDetalle.DataBind();

            PanelAgregarEmpleados.Enabled = true;
        }

        private int GenerarNuevaLiquidacion()
        {
            int estadoPendiente = Int32.Parse(ConfigurationManager.AppSettings["LiquidacionHorasPendiente"].ToString()); ;

            LiquidacionHorasPersonal liquidacion = new LiquidacionHorasPersonal();

            liquidacion.Fecha = DateTime.ParseExact(TextBoxFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            liquidacion.Descripcion = TextBoxDescripcion.Text;
            liquidacion.EstadoId = estadoPendiente;
            liquidacion.PresupuestoId = Int32.Parse(TextBoxPresupuesto.Text);

            administracion.GrabarLiquidacionHoras(liquidacion);

            return liquidacion.Id;

        }

        private void CargarListas(DropDownList Sectores, DropDownList TipoPago)
        {
            Sectores.DataSource = administracion.ObtenerSectoresEmpresa();
            Sectores.DataTextField = "Descripcion";
            Sectores.DataValueField = "Id";
            Sectores.DataBind();


            TipoPago.DataSource = administracion.ObtenerTipoPagoEmpleados();
            TipoPago.DataTextField = "Descripcion";
            TipoPago.DataValueField = "Id";
            TipoPago.DataBind();


        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {

            int estadoPendiente = 1;

            DomainAmbientHouse.Entidades.LiquidacionHorasPersonal_Detalle detalle = new LiquidacionHorasPersonal_Detalle();

            detalle.LiquidacionPersonalHoraId = LiquidacionId;
            detalle.EmpleadoId = Int32.Parse(DropDownListEmpleado.SelectedItem.Value);
            detalle.TipoPagoId = Int32.Parse(DropDownListTipoEmpleado.SelectedItem.Value);
            detalle.SectorEmpresaId = Int32.Parse(DropDownListSectorEmpresa.SelectedItem.Value);
            detalle.TipoEmpleadoId = Int32.Parse(DropDownListTipoEmpleado.SelectedItem.Value);
            detalle.HoraEntrada = TextBoxHoraEntrada.Text;
            detalle.HoraSalida = TextBoxHoraSalida.Text;
            detalle.EstadoId = estadoPendiente;


            //double valor = administracion.BuscarValorHoraPorSectorTipoEmpleadoTipoPago(Int32.Parse(DropDownListSectorEmpresa.SelectedItem.Value),
            //                                                                                 Int32.Parse(DropDownListTipoEmpleado.SelectedItem.Value),
            //                                                                                 Int32.Parse(DropDownListTipoEmpleado.SelectedItem.Value)).Valor;

            double valor = 1;

            float cantHoras = this.CalcularCantidadHorasTrabajadas(TextBoxHoraEntrada.Text, TextBoxHoraSalida.Text);

            detalle.Valor = valor * cantHoras;

            if (administracion.GrabarLiquidacionHoraDetalle(detalle))
            {
                ListHorasPersonalDetalle.Add(detalle);

                GridViewDetalle.DataSource = administracion.ListarLiquidacionPersonalHorasDetalle(LiquidacionId).ToList();
                GridViewDetalle.DataBind();

            }

            UpdatePanelDetalle.Update();

        }

        protected void DropDownListSectorEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerTipoEmpleados(DropDownListSectorEmpresa, DropDownListTipoEmpleado);

            ObtenerEmpleados(DropDownListTipoEmpleado, DropDownListEmpleado);

            UpdatePanelLiquidacion.Update();
        }

        private void ObtenerTipoEmpleados(DropDownList Sectores, DropDownList TipoEmpleado)
        {
            if (Sectores.SelectedItem != null)
            {
                int sector = Int32.Parse(Sectores.SelectedItem.Value);

                TipoEmpleado.DataSource = administracion.ObtenerTipoEmpleadosPorSector(sector);
                TipoEmpleado.DataTextField = "Descripcion";
                TipoEmpleado.DataValueField = "Id";
                TipoEmpleado.DataBind();

            }


        }

        protected void DropDownListTipoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerEmpleados(DropDownListTipoEmpleado, DropDownListEmpleado);
        }

        private void ObtenerEmpleados(DropDownList TipoEmpleado, DropDownList Empleados)
        {
            if (TipoEmpleado.SelectedItem != null)
            {
                int tipoEmpleado = Int32.Parse(TipoEmpleado.SelectedItem.Value);

                Empleados.DataSource = administracion.ObtenerEmpleadosPorTipoEmpleado(tipoEmpleado);
                Empleados.DataTextField = "ApellidoNombre";
                Empleados.DataValueField = "Id";
                Empleados.DataBind();
            }

            UpdatePanelLiquidacion.Update();
        }

        protected void GridViewDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList SectorEmpresa = (DropDownList)e.Row.FindControl("DropDownListSectorEmpresaGrilla");
                DropDownList TipoEmpleado = (DropDownList)e.Row.FindControl("DropDownListTipoEmpleadoGrilla");
                DropDownList TipoPago = (DropDownList)e.Row.FindControl("DropDownListTipoPagoGrilla");
                DropDownList Empleado = (DropDownList)e.Row.FindControl("DropDownListEmpleadoGrilla");
                TextBox HoraEntrada = (TextBox)e.Row.FindControl("TextBoxHoraEntradaGrilla");
                TextBox HoraSalida = (TextBox)e.Row.FindControl("TextBoxHoraSalidaGrilla");


                int Id = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.LiquidacionHorasPersonal_Detalle detalle = administracion.BuscarDetalleHoras(Id);


                CargarListas(SectorEmpresa, TipoPago);


                SectorEmpresa.SelectedValue = detalle.SectorEmpresaId.ToString();
                TipoPago.SelectedValue = detalle.TipoPagoId.ToString();

                ObtenerTipoEmpleados(SectorEmpresa, TipoEmpleado);

                TipoEmpleado.SelectedValue = detalle.TipoEmpleadoId.ToString();

                ObtenerEmpleados(TipoEmpleado, Empleado);

                Empleado.SelectedValue = detalle.EmpleadoId.ToString();

                HoraEntrada.Text = detalle.HoraEntrada;
                HoraSalida.Text = detalle.HoraSalida;

                SectorEmpresa.Enabled = false;
                TipoEmpleado.Enabled = false;


            }
        }

        protected void ButtonGenerarLiquidacion_Click(object sender, EventArgs e)
        {
            if (GenerarNuevaLiquidacion() > 0)
            {
                PanelAgregarEmpleados.Enabled = true;
            }
        }

        private float CalcularCantidadHorasTrabajadas(string horaInicio, string horaFin)
        {
            string cadenaHoraInicio;
            string cadenaMinutosInicio;

            string cadenaHoraFin;
            string cadenaMinutosFin;

            float result = 0;

            cadenaHoraInicio = horaInicio.Substring(0, 2);
            cadenaMinutosInicio = horaInicio.Substring(3, 2);

            cadenaHoraFin = horaFin.Substring(0, 2);
            cadenaMinutosFin = horaFin.Substring(3, 2);

            if (Int32.Parse(cadenaHoraInicio) == 0)
                horaInicio = "24";

            if (Int32.Parse(cadenaHoraFin) == 0)
                horaInicio = "24";

            int hHoraInicio = Int32.Parse(cadenaHoraInicio + cadenaMinutosInicio);

            int hHoraFin = Int32.Parse(cadenaHoraFin + cadenaMinutosFin);


            if (hHoraFin > hHoraInicio)
                result = ((float)hHoraFin - ((float)hHoraInicio) / 100);
            else
                result = (((2400 - (float)hHoraInicio) + (float)hHoraFin) / 100);


            //ACA TENGO QUE TOMAR LA PARTE DECIMAL Y DIVIDIRLA POR 60 Y LUEGO SUMARLA A LA PARTE ENTERA Y LUEGO RETORNAR EL VALOR DE LA FUNCION

            return result;

        }

        protected void DropDownListSectorEmpresaGrilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewDetalle.EditIndex = e.NewEditIndex;

            //int id = Convert.ToInt32(GridViewDetalle.DataKeys[e.NewEditIndex].Value);


            //DropDownList sectores = GridViewDetalle.Rows[e.NewEditIndex].FindControl("DropDownListSectorEmpresaGrilla") as DropDownList;
            //DropDownList tipoEmpleado = GridViewDetalle.Rows[e.NewEditIndex].FindControl("DropDownListTipoEmpleadoGrilla") as DropDownList;

            //if (sectores.SelectedItem != null)
            //{
            //    int sector = Int32.Parse(sectores.SelectedItem.Value);

            //    tipoEmpleado.DataSource = administracion.ObtenerTipoEmpleadosPorSector(sector);
            //    tipoEmpleado.DataTextField = "Descripcion";
            //    tipoEmpleado.DataValueField = "Id";
            //    tipoEmpleado.DataBind();
            //}
        }

        protected void GridViewDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewDetalle.Rows[index];

                DropDownList TipoPago = (DropDownList)row.FindControl("DropDownListTipoPagoGrilla");
                DropDownList Empleado = (DropDownList)row.FindControl("DropDownListEmpleadoGrilla");
                TextBox HoraEntrada = (TextBox)row.FindControl("TextBoxHoraEntradaGrilla");
                TextBox HoraSalida = (TextBox)row.FindControl("TextBoxHoraSalidaGrilla");


                int detalleId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.LiquidacionHorasPersonal_Detalle detalle = administracion.BuscarDetalleHoras(detalleId);

                detalle.TipoPagoId = Int32.Parse(TipoPago.SelectedItem.Value);
                detalle.EmpleadoId = Int32.Parse(Empleado.SelectedItem.Value);

                detalle.HoraEntrada = HoraEntrada.Text;
                detalle.HoraSalida = HoraSalida.Text;

                administracion.GrabarLiquidacionHoraDetalle(detalle);

                DomainAmbientHouse.Entidades.LiquidacionHorasPersonal liquidacion = new DomainAmbientHouse.Entidades.LiquidacionHorasPersonal();

                liquidacion = administracion.BuscarLiquidacionHorasPersonal(LiquidacionId);

                GridViewDetalle.DataSource = liquidacion.LiquidacionHorasPersonal_Detalle.ToList();
                GridViewDetalle.DataBind();


            }
            else if (e.CommandName == "Quitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewDetalle.Rows[index];

                int detalleId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.LiquidacionHorasPersonal_Detalle detalle = administracion.BuscarDetalleHoras(detalleId);

                administracion.ElimnarLiquidacionHoraDetalle(detalle);

                DomainAmbientHouse.Entidades.LiquidacionHorasPersonal liquidacion = new DomainAmbientHouse.Entidades.LiquidacionHorasPersonal();

                liquidacion = administracion.BuscarLiquidacionHorasPersonal(LiquidacionId);

                GridViewDetalle.DataSource = liquidacion.LiquidacionHorasPersonal_Detalle.ToList();
                GridViewDetalle.DataBind();

            }

            UpdatePanelDetalle.Update();

        }

    }
}