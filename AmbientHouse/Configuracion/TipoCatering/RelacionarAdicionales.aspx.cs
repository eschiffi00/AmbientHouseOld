using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.TipoCatering
{
    public partial class RelacionarAdicionales : System.Web.UI.Page
    {
        AdministrativasServicios servicios = new AdministrativasServicios();

        private int AdicionalId
        {
            get
            {
                return Int32.Parse(Session["AdicionalId"].ToString());
            }
            set
            {
                Session["AdicionalId"] = value;
            }
        }

        private string AdicionalDescripcion
        {
            get
            {
                return Session["AdicionalDescripcion"].ToString();
            }
            set
            {
                Session["AdicionalDescripcion"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();
                CargarListas();
                CargarTreeview();
                ButtonQuitarFamilia.Visible = false;
            }
        }

        private void CargarListas()
        {
            DropDownListFamilias.DataSource = servicios.ObtenerGruposConFamilias();
            DropDownListFamilias.DataTextField = "Codigo";
            DropDownListFamilias.DataValueField = "GrupoId";
            DropDownListFamilias.DataBind();

            int estadoActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            DropDownListItems.DataSource = servicios.ObtenerItems(estadoActivo);
            DropDownListItems.DataTextField = "Detalle";
            DropDownListItems.DataValueField = "Id";
            DropDownListItems.DataBind();
        }

        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);
                lblAdicional.Text = servicios.BuscarAdicional(id).Descripcion;

                AdicionalId = id;

                AdicionalDescripcion = lblAdicional.Text;
            }

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/Adicionales/Index.aspx");
        }

        //protected void ButtonAgregarItem_Click(object sender, EventArgs e)
        //{
        //    GrabarAdicionalesItem();
        //}

        //private void GrabarAdicionalesItem()
        //{
        //    AdicionalItem adicionalItem = new AdicionalItem();

        //    adicionalItem.AdicionalId = AdicionalId;
        //    adicionalItem.ItemId = Int32.Parse(DropDownListItems.SelectedItem.Value.ToString());

        //    servicios.NuevoAdicionalItem(adicionalItem);

        //    CargarTreeview();

        //    UpdatePanelArbol.Update();
        //}


        protected void ButtonAgregarFamilia_Click(object sender, EventArgs e)
        {
            GrabarAdicionalesFamilia();
        }

        private void GrabarAdicionalesFamilia()
        {
            DomainAmbientHouse.Entidades.TipoCateringFamilia tipCatFlia = new TipoCateringFamilia();

            tipCatFlia.AdicionalId = AdicionalId;
            tipCatFlia.GrupoId = Int32.Parse(DropDownListFamilias.SelectedItem.Value.ToString());

            servicios.NuevaTipoCateringFamilia(tipCatFlia);

            CargarTreeview();

            UpdatePanelArbol.Update();
        }


        private void CargarTreeview()
        {
            TreeViewExperiencias.Nodes.Clear();
            TreeViewExperiencias.ExpandAll();

            TreeNode nodoRaiz = new TreeNode();

            nodoRaiz.Text = AdicionalDescripcion;
            nodoRaiz.Value = "RAI";


            List<GruposItems> Grupos = servicios.ObtenerFamiliasConItemsAdicionales(AdicionalId);

            foreach (var item in Grupos)
            {
                TreeNode nodoGrupo = new TreeNode();

                nodoGrupo.Text = item.Codigo;
                nodoGrupo.Value = item.Id.ToString();

                List<DomainAmbientHouse.Entidades.Items> Items = servicios.ObtenerItemsPorGrupo(item.Id);

                foreach (var item2 in Items)
                {
                    TreeNode nodoItem = new TreeNode();

                    nodoItem.Text = item2.Detalle;
                    nodoItem.Value = item2.Id.ToString();

                    nodoGrupo.ChildNodes.Add(nodoItem);
                }

                nodoRaiz.ChildNodes.Add(nodoGrupo);
            }

            TreeNode nodoCarpetaItems = new TreeNode();

            nodoCarpetaItems.Text = "Items Adicionales";
            nodoCarpetaItems.Value = "CIT";

            //List<DomainAmbientHouse.Entidades.Items> itemsAdicionales = servicios.ObtenerItemsAdicionales(AdicionalId);

            //foreach (var item in itemsAdicionales)
            //{
            //    TreeNode nodoAdicionalItems = new TreeNode();

            //    nodoAdicionalItems.Text = item.Detalle;
            //    nodoAdicionalItems.Value = item.Id.ToString();

            //    nodoCarpetaItems.ChildNodes.Add(nodoAdicionalItems);

            //}

            nodoRaiz.ChildNodes.Add(nodoCarpetaItems);

            TreeViewExperiencias.Nodes.Add(nodoRaiz);

        }
    }
}