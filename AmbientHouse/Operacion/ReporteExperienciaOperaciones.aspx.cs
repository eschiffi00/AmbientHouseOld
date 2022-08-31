using DomainAmbientHouse.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmbientHouse.Operacion
{
    public partial class ReporteExperienciaOperaciones : System.Web.UI.Page
    {
        private int TipoCateringId
        {
            get
            {
                return Int32.Parse(Session["TipoCateringId"].ToString());
            }
            set
            {
                Session["TipoCateringId"] = value;
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

        AdministrativasServicios servicios = new AdministrativasServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fecha = Request["FechaEvento"].ToString();

                if (TipoCateringId > 0)
                {
                    CargarDatos();

                    List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);



                    foreach (var item in ListTiempos)
                    {
                        HtmlTableRow filaTiempo = new HtmlTableRow();


                        HtmlTableCell celda1Tiempo = new HtmlTableCell();
                        celda1Tiempo.InnerText = item.Descripcion.ToUpper();

                        celda1Tiempo.Attributes.Add("style", "font-weight: bold; width: 15%;");

                        HtmlTableCell celda2Tiempo = new HtmlTableCell();
                        celda2Tiempo.InnerText = "";

                        HtmlTableCell celda3Tiempo = new HtmlTableCell();
                        celda3Tiempo.InnerText = "";

                        HtmlTableCell celda4Tiempo = new HtmlTableCell();
                        celda4Tiempo.InnerText = "";

                        filaTiempo.Cells.Add(celda1Tiempo);
                        filaTiempo.Cells.Add(celda2Tiempo);
                        filaTiempo.Cells.Add(celda3Tiempo);
                        filaTiempo.Cells.Add(celda4Tiempo);
                        // Añadimos las celdas a la tabla
                        Experiencias.Rows.Add(filaTiempo);



                        List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                        //HtmlTableRow filaProductoTitulo = new HtmlTableRow();

                        //HtmlTableCell clProductosIDTitulo = new HtmlTableCell();
                        //clProductosIDTitulo.InnerText = ListProductos.FirstOrDefault().Titulo;

                        //HtmlTableCell clProductosItemsTitulo = new HtmlTableCell();
                        //clProductosItemsTitulo.InnerText = "";

                        //filaProductoTitulo.Cells.Add(clProductosIDTitulo);
                        //filaProductoTitulo.Cells.Add(clProductosItemsTitulo);

                        //Experiencias.Rows.Add(filaProductoTitulo);

                        string Titulo = "";

                        foreach (var itemProducto in ListProductos)
                        {

                            HtmlTableRow filaProducto = new HtmlTableRow();

                            HtmlTableCell celda1ProductosCatering = new HtmlTableCell();
                            celda1ProductosCatering.InnerText = "";

                            HtmlTableCell celda2ProductosCatering = new HtmlTableCell();



                            if (Titulo != itemProducto.Titulo)
                            {
                                celda2ProductosCatering.InnerText = itemProducto.Titulo;
                                celda2ProductosCatering.Attributes.Add("style", "font-weight: bold;");
                                Titulo = itemProducto.Titulo;
                            }
                            else
                                celda2ProductosCatering.InnerText = "";

                            HtmlTableCell celda3ProductosCatering = new HtmlTableCell();
                            celda3ProductosCatering.InnerText = itemProducto.Descripcion;
                            celda3ProductosCatering.Attributes.Add("style", "font-weight: bold;");

                            HtmlTableCell celda4ProductosCatering = new HtmlTableCell();
                            celda4ProductosCatering.InnerText = "";

                            filaProducto.Cells.Add(celda1ProductosCatering);
                            filaProducto.Cells.Add(celda2ProductosCatering);
                            filaProducto.Cells.Add(celda3ProductosCatering);
                            filaProducto.Cells.Add(celda4ProductosCatering);


                            Experiencias.Rows.Add(filaProducto);

                            List<DomainAmbientHouse.Entidades.Items> ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);


                            int itemPro = 0;

                            itemPro = itemPro + 1;





                            foreach (var itemProductosItems in ListProductoItems)
                            {

                                HtmlTableRow filaProductoItems = new HtmlTableRow();

                                HtmlTableCell celda1ProductosCateringItems = new HtmlTableCell();
                                celda1ProductosCateringItems.InnerText = "";

                                HtmlTableCell celda2ProductosCateringItems = new HtmlTableCell();
                                celda2ProductosCateringItems.InnerText = "";

                                HtmlTableCell celda3ProductosCateringItems = new HtmlTableCell();
                                celda3ProductosCateringItems.InnerText = "";

                                HtmlTableCell celda4ProductosCateringItems = new HtmlTableCell();
                                celda4ProductosCateringItems.InnerText = itemProductosItems.Detalle;

                                filaProductoItems.Cells.Add(celda1ProductosCateringItems);
                                filaProductoItems.Cells.Add(celda2ProductosCateringItems);
                                filaProductoItems.Cells.Add(celda3ProductosCateringItems);
                                filaProductoItems.Cells.Add(celda4ProductosCateringItems);

                                Experiencias.Rows.Add(filaProductoItems);


                            }
                        }


                        List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

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


                            List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

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
                        List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                        foreach (var itemItems in ListItems)
                        {

                            HtmlTableRow filaItems = new HtmlTableRow();



                            HtmlTableCell celda1Items = new HtmlTableCell();
                            celda1Items.InnerText = "";

                            HtmlTableCell celda2Items = new HtmlTableCell();
                            celda2Items.InnerText = "";

                            HtmlTableCell celda3Items = new HtmlTableCell();
                            celda3Items.InnerText = "";


                            HtmlTableCell celda4Items = new HtmlTableCell();
                            celda4Items.InnerText = itemItems.Detalle;

                            filaItems.Cells.Add(celda1Items);
                            filaItems.Cells.Add(celda2Items);
                            filaItems.Cells.Add(celda3Items);
                            filaItems.Cells.Add(celda4Items);

                            Experiencias.Rows.Add(filaItems);

                        }





                    }
                }
            }
        }

        public void CargarDatos()
        {
            DomainAmbientHouse.Entidades.TipoCatering tc = servicios.BuscarTipoCatering(TipoCateringId);

            LabelExperiencia.Text = tc.Descripcion.ToUpper();

            LabelNroEvento.Text = EventoId.ToString().PadLeft(8, '0');

            LabelNroPresupuesto.Text = PresupuestoId.ToString().PadLeft(8, '0');


        }

        protected void LinkButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operacion/Index.aspx?FechaEvento=" + Fecha);
        }
    }
}