using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Servicios;
using DomainAmbientHouse.Entidades;
using System.Web.UI.HtmlControls;

namespace AmbientHouse.Configuracion.Adicionales
{
    public partial class Index : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();
        EventosServicios eventos = new EventosServicios();

        Comun cmd = new Comun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();

              

                BuscarAdicionales(TextBoxDescripcionBuscador.Text);
            }
        }

        private void CargarLista()
        {
            List<DomainAmbientHouse.Entidades.Proveedores> ProvUn = eventos.ObtenerProveedoresCotizador();



            DropDownListProveedores.DataSource = ProvUn.ToList();
            DropDownListProveedores.DataTextField = "RazonSocial";
            DropDownListProveedores.DataValueField = "Id";
            DropDownListProveedores.DataBind();


            DropDownListSalones.DataSource = eventos.ObtenerLocacionesParaCotizar();
            DropDownListSalones.DataTextField = "Descripcion";
            DropDownListSalones.DataValueField = "Id";
            DropDownListSalones.DataBind();

            DropDownListUnidadNegocio.DataSource = servicios.ObtenerUnidadesdeNegocios();
            DropDownListUnidadNegocio.DataTextField = "Descripcion";
            DropDownListUnidadNegocio.DataValueField = "Id";
            DropDownListUnidadNegocio.DataBind();



        }

        private void BuscarAdicionales(string descripcion)
        {

            int proveedorId = 0;
            if (DropDownListProveedores.SelectedValue != "null")
                proveedorId = Int32.Parse(DropDownListProveedores.SelectedItem.Value);

            int locacionId = 0;
            if (DropDownListSalones.SelectedValue != "null")
                locacionId = Int32.Parse(DropDownListSalones.SelectedItem.Value);

            int unidadNegocioId = 0;
            if (DropDownListUnidadNegocio.SelectedValue != "null")
                unidadNegocioId = Int32.Parse(DropDownListUnidadNegocio.SelectedItem.Value);


            List<ObtenerAdicionales> list = servicios.BuscarAdicionalesPorDescripcionProveedorSalon(descripcion,proveedorId,locacionId, unidadNegocioId);

            //if (cmd.IsNumeric(descripcion))
            //{
            //    int id = Int32.Parse(descripcion);


            //    list = list.Where(o => o.Id == id).ToList();
            //}
            //else if (!cmd.IsNumeric(descripcion))
            //{
            //    list = list.Where(o => o.Descripcion.ToLower().Contains(descripcion.ToLower())).ToList();
            //}
            //else if (proveedorId > 0)
            //{
            //    list = list.Where(o => o.Descripcion.ToLower().Contains(descripcion.ToLower()) && o.ProveedorId == proveedorId).ToList();
            //}
            //else if (locacionId > 0)
            //{
            //    list = list.Where(o => o.Descripcion.ToLower().Contains(descripcion.ToLower()) && o.LocacionId == locacionId).ToList();
            //}


            GridViewAdicionales.DataSource = list.ToList();
            GridViewAdicionales.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Adicionales/Editar.aspx");
        }

        protected void GridViewAdicionales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAdicionales.PageIndex = e.NewPageIndex;
            BuscarAdicionales(TextBoxDescripcionBuscador.Text);
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Index.aspx");
           
        }

        protected void ButtonExportarExcel_Click(object sender, EventArgs e)
        {
            GridView Total = new GridView();




            Total.DataSource = servicios.ObtenerAdicionales();
            Total.DataBind();


            Exportar(Total);
        }

        private void Exportar(GridView gridExcel)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gridExcel.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gridExcel);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=DATA.xls");
            Response.Charset = "UTF-8";
            // Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void GridViewAdicionales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewAdicionales.Rows[index];



                DropDownList Estados = row.FindControl("DropDownListEstados") as DropDownList;



                int ItemId = Int32.Parse(row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Adicionales item = servicios.BuscarAdicional(ItemId);



                item.EstadoId = Int32.Parse(Estados.SelectedItem.Value);


                try
                {
                    servicios.ActualizarAdicional(item);


                }
                catch (Exception)
                {

                    throw;
                }


            }

            BuscarAdicionales(TextBoxDescripcionBuscador.Text);
            UpdatePanelGrillaAdicionales.Update();
        }

        protected void GridViewAdicionales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList Estados = (DropDownList)e.Row.FindControl("DropDownListEstados");


                int ItemId = Int32.Parse(e.Row.Cells[0].Text);

                DomainAmbientHouse.Entidades.Adicionales item = servicios.BuscarAdicional(ItemId);


                Estados.DataSource = servicios.BuscarEstadosPorEntidad("Adicionales");
                Estados.DataTextField = "Descripcion";
                Estados.DataValueField = "Id";
                Estados.DataBind();


                Estados.SelectedValue = item.EstadoId.ToString();
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            BuscarAdicionales(TextBoxDescripcionBuscador.Text);
        }

      
 
      
    }
}