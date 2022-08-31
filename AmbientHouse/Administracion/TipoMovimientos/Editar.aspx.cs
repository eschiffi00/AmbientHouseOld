using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;

namespace AmbientHouse.Administracion.TipoMovimientos
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios administracion = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.TipoMovimientos TipoMovimientosSeleccionado
        {
            get
            {
                return Session["TipoMovimientosSeleccionado"] as DomainAmbientHouse.Entidades.TipoMovimientos;
            }
            set
            {
                Session["TipoMovimientosSeleccionado"] = value;
            }
        }

        private int TipoMovimientoId
        {
            get
            {
                return Int32.Parse(Session["TipoMovimientoId"].ToString());
            }
            set
            {
                Session["TipoMovimientoId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();

                InicializarPagina();
            }
        }

        private void CargarListas()
        {
            DropDownListTipoMovimientoPadre.DataSource = administracion.ObtenerTipoMovimientosPadres();
            DropDownListTipoMovimientoPadre.DataTextField = "Identificador";
            DropDownListTipoMovimientoPadre.DataValueField = "Id";
            DropDownListTipoMovimientoPadre.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                TipoMovimientoId = id;
            }


            if (id == 0)
                NuevoTipoMovimiento();
            else
                EditarTipoMovimiento(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarTipoMovimiento(int id)
        {
            DomainAmbientHouse.Entidades.TipoMovimientos tm = new DomainAmbientHouse.Entidades.TipoMovimientos();

            tm = administracion.BuscarTipoMovimiento(id);

            TipoMovimientosSeleccionado = tm;

            if (tm.Tipo != null)
                DropDownListTipoMovimientoPadre.SelectedValue = tm.Tipo.ToString();


            DropDownListVisible.SelectedValue = tm.Visible;

            TextBoxDescripcion.Text = tm.Descripcion;
            TextBoxCodigo.Text = tm.Codigo;
        }

        private void NuevoTipoMovimiento()
        {
            TipoMovimientosSeleccionado = new DomainAmbientHouse.Entidades.TipoMovimientos();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/TipoMovimientos/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }


        private void Grabar()
        {
            DomainAmbientHouse.Entidades.TipoMovimientos tm = TipoMovimientosSeleccionado;

            tm.Descripcion = TextBoxDescripcion.Text;
            tm.Codigo = TextBoxCodigo.Text;
            if (DropDownListTipoMovimientoPadre.SelectedItem.Value != "NULL")
                tm.Tipo = DropDownListTipoMovimientoPadre.SelectedItem.Value;

            tm.Visible = DropDownListVisible.SelectedItem.Value;


            administracion.GuardarTipoMovimiento(tm);
            Response.Redirect("~/Administracion/TipoMovimientos/Index.aspx");
        }

    }
}