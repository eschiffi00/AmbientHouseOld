using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion
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

        DomainAmbientHouse.Servicios.Comun cmd = new DomainAmbientHouse.Servicios.Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                ButtonAdministrarCuentas.Visible = false;


                if (cmd.Logeado(EmpleadoId))
                {
                    ButtonAdministrarCuentas.Visible = true;
                }
            }
        }

       

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Default.aspx");
        }

        protected void ButtonAdministrarCuentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cuentas/Index.aspx");
        }

        protected void ButtonAdministrarTipoComprobantes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/TipoComprobantes/Index.aspx");
        }

        protected void ButtonAdministrarImpuestos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Impuestos/Index.aspx");
        }

        protected void ButtonAdministrarPagoAProveedores_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonAdministrarComprobantes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Comprobantes/Index.aspx");
        }

        protected void ButtonAdministrarProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Productos/Index.aspx");
        }

        protected void ButtonAdministrarCheques_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Cheques/Index.aspx");
        }

        protected void ButtonClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Clientes/Index.aspx");
        }

        protected void ButtonAdministrarTransferencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Transferencias/Index.aspx");
        }

        protected void ButtonAdministrarRecibos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Recibos/Index.aspx");
        }

        protected void ButtonAdministrarTipoMovimientos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/TipoMovimientos/Index.aspx");
        }

        protected void ButtonCostoSalones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Costos/Salones.aspx");
        }

        protected void ButtonAdministrarLiquidacionHoras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/LiquidacionHoras/Index.aspx");
        }

    }
}