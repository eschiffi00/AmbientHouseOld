using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AmbientHouse.Administracion.TipoComprobantes
{
    public partial class Editar : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private DomainAmbientHouse.Entidades.TipoComprobantes TipoComprobantesSeleccionado
        {
            get
            {
                return Session["TipoComprobantesSeleccionado"] as DomainAmbientHouse.Entidades.TipoComprobantes;
            }
            set
            {
                Session["TipoComprobantesSeleccionado"] = value;
            }
        }

        private int TipoComprobanteId
        {
            get
            {
                return Int32.Parse(Session["TipoComprobanteId"].ToString());
            }
            set
            {
                Session["TipoComprobanteId"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Impuestos> ListImpuestos
        {
            get
            {
                return Session["ListImpuestos"] as List<DomainAmbientHouse.Entidades.Impuestos>;
            }
            set
            {
                Session["ListImpuestos"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListImpuestos = new List<DomainAmbientHouse.Entidades.Impuestos>();

                InicializarPagina();

                CargarListas();

            }
        }

        private void CargarListas()
        {
            DropDownListImpuestos.DataSource = servicios.ObtenerImpuestos();
            DropDownListImpuestos.DataTextField = "Descripcion";
            DropDownListImpuestos.DataValueField = "Id";
            DropDownListImpuestos.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);

                TipoComprobanteId = id;
            }


            if (id == 0)
                NuevoTipoComprobante();
            else
                EditarTipoComprobante(id);

            SetFocus(TextBoxDescripcion);
        }

        private void EditarTipoComprobante(int id)
        {

            DomainAmbientHouse.Entidades.TipoComprobantes tc = new DomainAmbientHouse.Entidades.TipoComprobantes();

            tc = servicios.BuscarTipoComprobante(id);

            TipoComprobantesSeleccionado = tc;


            TextBoxDescripcion.Text = tc.Descripcion;

            ListImpuestos = CargarListaImpuestos(tc.Id);

            GridViewImpuestos.DataSource = ListImpuestos.ToList();
            GridViewImpuestos.DataBind();

        }

        private List<DomainAmbientHouse.Entidades.Impuestos> CargarListaImpuestos(int tcId)
        {
            List<DomainAmbientHouse.Entidades.Impuestos> lista = servicios.ObtenerImpuestosorTipoComprobante(tcId);
            return lista;
        }

        private void NuevoTipoComprobante()
        {
            TipoComprobantesSeleccionado = new DomainAmbientHouse.Entidades.TipoComprobantes();
        }

        private void Grabar()
        {
            DomainAmbientHouse.Entidades.TipoComprobantes tc = TipoComprobantesSeleccionado;

            tc.Descripcion = TextBoxDescripcion.Text;


            //foreach (GridViewRow row in GridViewImpuestos.Rows)
            //{

            //    DomainAmbientHouse.Entidades.Impuestos impuesto = new DomainAmbientHouse.Entidades.Impuestos();

            //    impuesto.Id = Int32.Parse(row.Cells[0].Text);
            //    impuesto.Descripcion = row.Cells[1].Text;

            //    ListImpuestos.Add(impuesto);
            //}

            servicios.NuevoTipoComprobantes(tc, ListImpuestos);
            Response.Redirect("~/Administracion/TipoComprobantes/Index.aspx");
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/TipoComprobantes/Index.aspx");
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            DomainAmbientHouse.Entidades.Impuestos impuesto = new DomainAmbientHouse.Entidades.Impuestos();



            impuesto.Id = Int32.Parse(DropDownListImpuestos.SelectedItem.Value.ToString());
            impuesto.Descripcion = DropDownListImpuestos.SelectedItem.Text;

            if (ListImpuestos.Where(o => o.Id == impuesto.Id).Count() > 0)
            { }
            else
            {
                ListImpuestos.Add(impuesto);
            }

            GridViewImpuestos.DataSource = ListImpuestos.ToList();
            GridViewImpuestos.DataBind();

            UpdatePanelGrillaImpuestos.Update();
        }

        protected void ButtonQuitar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewImpuestos.Rows)
            {
                CheckBox check = row.FindControl("CheckBoxQuitarImpuestos") as CheckBox;

                if (check.Checked)
                {

                    DomainAmbientHouse.Entidades.Impuestos impuesto = new DomainAmbientHouse.Entidades.Impuestos();

                    impuesto.Id = Int32.Parse(row.Cells[0].Text);
                    impuesto.Descripcion = row.Cells[1].Text;


                    var itemRemove = ListImpuestos.Where(o => o.Id == impuesto.Id).Single();

                    ListImpuestos.Remove(itemRemove);
                }

            }


            GridViewImpuestos.DataSource = ListImpuestos.ToList();
            GridViewImpuestos.DataBind();

            UpdatePanelGrillaImpuestos.Update();


        }

    }
}