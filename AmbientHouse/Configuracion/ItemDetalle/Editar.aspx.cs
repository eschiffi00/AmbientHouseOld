using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace AmbientHouse.Configuracion.ItemDetalle
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        Comun cmd = new Comun();

        private DomainAmbientHouse.Entidades.ItemDetalle ItemDetalleSeleccionado
        {
            get
            {
                return Session["ItemDetalleSeleccionado"] as DomainAmbientHouse.Entidades.ItemDetalle;
            }
            set
            {
                Session["ItemDetalleSeleccionado"] = value;
            }
        }

        private int ItemDetalleId
        {
            get
            {
                return Int32.Parse(Session["ItemDetalleId"].ToString());
            }
            set
            {
                Session["ItemDetalleId"] = value;
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
            ddlTipoCateringbind();
            ddlItemsbind(Int32.Parse(ddlTipoCatering.SelectedValue));
        }

        private void ddlTipoCateringbind()
        {
            ddlTipoCatering.DataSource = servicios.ObtenerTipoCatering();
            ddlTipoCatering.DataTextField = "Descripcion";
            ddlTipoCatering.DataValueField = "Id";
            ddlTipoCatering.DataBind();

        }

        private void ddlItemsbind(int tipoCateringId)
        {
            ddlItems.Items.Clear();
            ddlItems.DataSource = servicios.BuscarItemsPorTipoCatering(tipoCateringId);
            ddlItems.DataTextField = "Detalle";
            ddlItems.DataValueField = "ItemId";
            ddlItems.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                ItemDetalleId = id;
            }


            if (id == 0)
                NuevoItem();
            else
                EditarItem(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarItem(int id)
        {

            DomainAmbientHouse.Entidades.ItemDetalle item = new DomainAmbientHouse.Entidades.ItemDetalle();

            item = servicios.BuscarItemDetalle(id);

            ItemDetalleSeleccionado = item;


            //TextBoxDescripcion.Text = item.Descripcion;
           
        }

        private void NuevoItem()
        {
            ItemDetalleSeleccionado = new DomainAmbientHouse.Entidades.ItemDetalle();
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            GrabarItem();
        }


        private void GrabarItem()
        {
            
            DomainAmbientHouse.Entidades.ItemDetalle item = ItemDetalleSeleccionado;

            //item.Descripcion = TextBoxDescripcion.Text;
           
            servicios.NuevoItemDetalle(item);
            Response.Redirect("~/Configuracion/ItemDetalle/Index.aspx");
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/ItemDetalle/Index.aspx");
        }

        protected void ddlTipoCatering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCatering.SelectedItem.Value != null)
            {
                int tipocateringId = Int32.Parse(ddlTipoCatering.SelectedValue);
                ddlItemsbind(tipocateringId);

            }

            UpdatePanelEditar.Update();
        }
    }
}