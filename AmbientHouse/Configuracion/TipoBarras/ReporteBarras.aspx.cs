using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace AmbientHouse.Configuracion.TipoBarras
{
    public partial class ReporteBarras : System.Web.UI.Page
    {
        private int TipoBarraId
        {
            get
            {
                return Int32.Parse(Session["TipoBarraId"].ToString());
            }
            set
            {
                Session["TipoBarraId"] = value;
            }
        }

        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();



                List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoBarra(TipoBarraId);

                foreach (var itemCategorias in ListCategorias)
                {
                    HtmlTableRow filaCategorias = new HtmlTableRow();


                    HtmlTableCell celda1CategoriasItems = new HtmlTableCell();
                    celda1CategoriasItems.InnerText = "";

                    HtmlTableCell celda2CategoriasItems = new HtmlTableCell();
                    celda2CategoriasItems.InnerText = itemCategorias.CategoriaItemPadreDescripcion;
                    celda2CategoriasItems.Attributes.Add("style", "font-weight: bold;");

                    HtmlTableCell celda3CategoriasItems = new HtmlTableCell();
                    celda3CategoriasItems.InnerText = "";

                    HtmlTableCell celda4CategoriasItems = new HtmlTableCell();
                    celda4CategoriasItems.InnerText = "";

                    filaCategorias.Cells.Add(celda1CategoriasItems);
                    filaCategorias.Cells.Add(celda2CategoriasItems);
                    filaCategorias.Cells.Add(celda3CategoriasItems);
                    filaCategorias.Cells.Add(celda4CategoriasItems);

                    Experiencias.Rows.Add(filaCategorias);


                    List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoBarraCategorias(TipoBarraId, itemCategorias.Id);

                    foreach (var itemCatItems in ListCategoriaItems)
                    {

                        HtmlTableRow filaCategoriasItems = new HtmlTableRow();


                        HtmlTableCell celda1ItemsCategorias = new HtmlTableCell();
                        celda1ItemsCategorias.InnerText = "";

                        HtmlTableCell celda2ItemsCategorias = new HtmlTableCell();
                        celda2ItemsCategorias.InnerText = "";

                        HtmlTableCell celda3ItemsCategorias = new HtmlTableCell();
                        celda3ItemsCategorias.InnerText = itemCatItems.Detalle;

                        HtmlTableCell celda4ItemsCategorias = new HtmlTableCell();
                        celda4ItemsCategorias.InnerText = "";

                        filaCategoriasItems.Cells.Add(celda1ItemsCategorias);
                        filaCategoriasItems.Cells.Add(celda2ItemsCategorias);
                        filaCategoriasItems.Cells.Add(celda3ItemsCategorias);
                        filaCategoriasItems.Cells.Add(celda4ItemsCategorias);

                        Experiencias.Rows.Add(filaCategoriasItems);
                    }

                }

                List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoBarra(TipoBarraId);

                foreach (var itemItems in ListItems)
                {

                    HtmlTableRow filaItems = new HtmlTableRow();



                    HtmlTableCell celda1Items = new HtmlTableCell();
                    celda1Items.InnerText = "";

                    HtmlTableCell celda2Items = new HtmlTableCell();
                    celda2Items.InnerText = itemItems.Detalle;

                    HtmlTableCell celda3Items = new HtmlTableCell();
                    celda3Items.InnerText = "";


                    HtmlTableCell celda4Items = new HtmlTableCell();
                    celda4Items.InnerText = "";

                    filaItems.Cells.Add(celda1Items);
                    filaItems.Cells.Add(celda2Items);
                    filaItems.Cells.Add(celda3Items);
                    filaItems.Cells.Add(celda4Items);

                    Experiencias.Rows.Add(filaItems);

                }



            }
        }

        public void CargarDatos()
        {
            DomainAmbientHouse.Entidades.TiposBarras tb = servicios.BuscarTipoBarras(TipoBarraId);

            LabelExperiencia.Text = tb.Descripcion.ToUpper();



        }

        protected void LinkButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoBarras/Index.aspx");
        }
    }
}