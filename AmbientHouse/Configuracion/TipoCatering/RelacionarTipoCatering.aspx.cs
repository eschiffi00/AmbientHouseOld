using DomainAmbientHouse.Servicios;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace AmbientHouse.Configuracion.TipoCatering
{
    public partial class RelacionarTipoCatering : System.Web.UI.Page
    {
        private List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos
        {
            get
            {
                return Session["ListTiempos"] as List<DomainAmbientHouse.Entidades.Tiempos>;
            }
            set
            {
                Session["ListTiempos"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos
        {
            get
            {
                return Session["ListProductos"] as List<DomainAmbientHouse.Entidades.ProductosCatering>;
            }
            set
            {
                Session["ListProductos"] = value;
            }
        }

        private List<DomainAmbientHouse.Entidades.Items> ListProductoItems
        {
            get
            {
                return Session["ListProductoItems"] as List<DomainAmbientHouse.Entidades.Items>;
            }
            set
            {
                Session["ListProductoItems"] = value;
            }
        }


        AdministrativasServicios servicios = new AdministrativasServicios();

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

        private string TipoCateringDescripcion
        {
            get
            {
                return Session["TipoCateringDescripcion"].ToString();
            }
            set
            {
                Session["TipoCateringDescripcion"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarPagina();

                CargarTreeview();



                //ListTiempos = new List<DomainAmbientHouse.Entidades.Tiempos>();

                //ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);




                //var datasource = new ReportDataSource("DataSet1", ListTiempos.ToList());

                ////if (!Page.IsPostBack)
                ////{
                //    ReportViewer1.Visible = true;
                //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //    ReportViewer1.LocalReport.ReportPath = @"Configuracion\Prueba.rdlc";
                ////}

                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(datasource);
                //ReportViewer1.LocalReport.Refresh();

            }
        }



        private void InicializarPagina()
        {
            int id = 0;

            if (Request["Id"] != null)
            {
                id = Int32.Parse(Request["Id"]);
                lblTipoCatering.Text = servicios.BuscarTipoCatering(id).Descripcion;

                TipoCateringId = id;

                TipoCateringDescripcion = lblTipoCatering.Text;
            }

        }




        //private void GrabarTipoCateringFamilia()
        //{
        //    DomainAmbientHouse.Entidades.TipoCateringFamilia tipCatFlia = new TipoCateringFamilia();

        //    tipCatFlia.TipoCateringId = TipoCateringId;
        //    tipCatFlia.GrupoId = Int32.Parse(DropDownListFamilias.SelectedItem.Value.ToString());

        //    servicios.NuevaTipoCateringFamilia(tipCatFlia);

        //    CargarTreeview();

        //    UpdatePanelArbol.Update();
        //}

        private void CargarTreeview()
        {
            TreeViewExperiencias.Nodes.Clear();


            TreeNode nodoRaiz = new TreeNode();

            nodoRaiz.Text = TipoCateringDescripcion;
            nodoRaiz.Value = "RAI";


            //List<DomainAmbientHouse.Entidades.Tiempos>


            ListTiempos = new List<DomainAmbientHouse.Entidades.Tiempos>();

            ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);

            foreach (var item in ListTiempos)
            {
                TreeNode nodoTiempo = new TreeNode();

                nodoTiempo.Text = item.Descripcion;
                nodoTiempo.Value = item.Id.ToString();


                ListProductos = new List<DomainAmbientHouse.Entidades.ProductosCatering>();

                ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);


                string titulo = "";

                foreach (var itemProducto in ListProductos)
                {
                    TreeNode nodoProducto = new TreeNode();

                    TreeNode nodoCategoriaProducto = new TreeNode();
                    if (titulo != itemProducto.Titulo)
                    {


                        nodoCategoriaProducto.Text = itemProducto.Titulo;
                        nodoCategoriaProducto.Value = "";

                    }

                    titulo = itemProducto.Titulo;

                    nodoProducto.Text = itemProducto.Descripcion;
                    nodoProducto.Value = itemProducto.Id.ToString();

                    ListProductoItems = new List<DomainAmbientHouse.Entidades.Items>();

                    ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);

                    foreach (var itemProductosItems in ListProductoItems)
                    {
                        TreeNode nodoItems = new TreeNode();

                        nodoItems.Text = itemProductosItems.Detalle;
                        nodoItems.Value = itemProductosItems.Id.ToString();

                        nodoProducto.ChildNodes.Add(nodoItems);

                    }
                    nodoProducto.ChildNodes.Add(nodoCategoriaProducto);

                    nodoTiempo.ChildNodes.Add(nodoProducto);
                }




                List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                foreach (var itemCategorias in ListCategorias)
                {
                    TreeNode nodoCategorias = new TreeNode();

                    nodoCategorias.Text = itemCategorias.Descripcion;
                    nodoCategorias.Value = itemCategorias.Id.ToString();


                    List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                    foreach (var itemCatItems in ListCategoriaItems)
                    {
                        TreeNode nodoItems = new TreeNode();

                        nodoItems.Text = itemCatItems.Detalle;
                        nodoItems.Value = itemCatItems.Id.ToString();

                        nodoCategorias.ChildNodes.Add(nodoItems);

                    }


                    nodoTiempo.ChildNodes.Add(nodoCategorias);

                }




                List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                foreach (var itemItems in ListItems)
                {
                    TreeNode nodoItemsItems = new TreeNode();

                    nodoItemsItems.Text = itemItems.Detalle;
                    nodoItemsItems.Value = itemItems.Id.ToString();




                    nodoTiempo.ChildNodes.Add(nodoItemsItems);

                }



                nodoRaiz.ChildNodes.Add(nodoTiempo);

            }

            TreeViewExperiencias.Nodes.Add(nodoRaiz);
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Configuracion/TipoCatering/Index.aspx");
        }

        //protected void TreeViewExperiencias_SelectedNodeChanged(object sender, EventArgs e)
        //{
        //    if (TreeViewExperiencias.SelectedNode.Value != "RAI")
        //    {
        //        if (TreeViewExperiencias.SelectedNode.Value != "")
        //        {

        //            int valor = Int32.Parse(TreeViewExperiencias.SelectedNode.Value.ToString());


        //            TipoCateringFamilia tcf = servicios.BuscarTipoCateringFamiliaPorGrupo(valor, TipoCateringId);

        //            if (tcf != null)
        //            {

        //                //ButtonQuitarFamilia.Visible = true;

        //                //ButtonQuitarFamilia.Text = "Quitar - " + TreeViewExperiencias.SelectedNode.Text;

        //                UpdatePanelArbol.Update();
        //            }

        //        }

        //    }


        //}

        //protected void ButtonQuitarFamilia_Click(object sender, EventArgs e)
        //{


        //    if (TreeViewExperiencias.SelectedNode != null)
        //    {
        //        int valor = Int32.Parse(TreeViewExperiencias.SelectedNode.Value.ToString());

        //        TipoCateringFamilia tcf = new TipoCateringFamilia();

        //        tcf.GrupoId = valor;
        //        tcf.TipoCateringId = TipoCateringId;

        //        servicios.QuitarTipoCateringFamilia(tcf);

        //    }

        //    //ButtonQuitarFamilia.Visible = false;

        //    CargarTreeview();

        //    UpdatePanelArbol.Update();
        //}



        private void GenerarPDF()
        {







            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\diego\Desktop\prueba.pdf", FileMode.Create));



            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();


            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Mi primer documento PDF"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.


            PdfPTable tblPrueba = new PdfPTable(2);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;



            List<DomainAmbientHouse.Entidades.Tiempos> ListTiempos = servicios.ObtenerTiemposPorTipoCatering(TipoCateringId);

            foreach (var item in ListTiempos)
            {

                PdfPCell clTiempo = new PdfPCell(new Phrase(item.Descripcion, _standardFont));
                clTiempo.BorderWidth = 0;
                clTiempo.BorderWidthBottom = 0.75f;

                PdfPCell clTiempo1 = new PdfPCell(new Phrase("", _standardFont));
                clTiempo1.BorderWidth = 0;
                clTiempo1.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clTiempo);
                tblPrueba.AddCell(clTiempo1);




                List<DomainAmbientHouse.Entidades.ProductosCatering> ListProductos = servicios.ObtenerProductosCateringPorTipoCateringTiempo(TipoCateringId, item.Id);

                foreach (var itemProducto in ListProductos)
                {
                    PdfPCell clProductos = new PdfPCell(new Phrase(itemProducto.Descripcion, _standardFont));
                    clProductos.BorderWidth = 0;

                    PdfPCell cl1 = new PdfPCell(new Phrase("", _standardFont));
                    clProductos.BorderWidth = 0;

                    tblPrueba.AddCell(clProductos);
                    tblPrueba.AddCell(cl1);


                    ListProductoItems = servicios.ObtenerItemsPorTipoCateringTiempoProducto(TipoCateringId, item.Id, itemProducto.Id);

                    foreach (var itemProductosItems in ListProductoItems)
                    {
                        PdfPCell clProductosID = new PdfPCell(new Phrase("", _standardFont));
                        clProductosID.BorderWidth = 0;

                        PdfPCell clProductosItems = new PdfPCell(new Phrase(itemProductosItems.Detalle, _standardFont));
                        clProductosItems.BorderWidth = 0;

                        tblPrueba.AddCell(clProductosID);
                        tblPrueba.AddCell(clProductosItems);

                    }
                }


                List<DomainAmbientHouse.Entidades.CategoriasItem> ListCategorias = servicios.ObtenerCategoriasPorTipoCateringTiempo(TipoCateringId, item.Id);

                foreach (var itemCategorias in ListCategorias)
                {
                    PdfPCell clCategorias = new PdfPCell(new Phrase(itemCategorias.Descripcion, _standardFont));
                    clCategorias.BorderWidth = 0;

                    PdfPCell cl2 = new PdfPCell(new Phrase("", _standardFont));
                    cl2.BorderWidth = 0;

                    tblPrueba.AddCell(clCategorias);
                    tblPrueba.AddCell(cl2);


                    List<DomainAmbientHouse.Entidades.Items> ListCategoriaItems = servicios.ObtenerItemsPorTipoCateringTiempoCategorias(TipoCateringId, item.Id, itemCategorias.Id);

                    foreach (var itemCatItems in ListCategoriaItems)
                    {
                        PdfPCell clCategoriasID = new PdfPCell(new Phrase("", _standardFont));
                        clCategoriasID.BorderWidth = 0;

                        PdfPCell clCategoriasItems = new PdfPCell(new Phrase(itemCatItems.Detalle, _standardFont));
                        clCategoriasItems.BorderWidth = 0;

                        tblPrueba.AddCell(clCategoriasID);
                        tblPrueba.AddCell(clCategoriasItems);


                    }

                }
                List<DomainAmbientHouse.Entidades.Items> ListItems = servicios.ObtenerItemsPorTipoCateringTiempo(TipoCateringId, item.Id);

                foreach (var itemItems in ListItems)
                {
                    PdfPCell clItemsID = new PdfPCell(new Phrase("", _standardFont));
                    clItemsID.BorderWidth = 0;

                    PdfPCell clItems = new PdfPCell(new Phrase(itemItems.Detalle, _standardFont));
                    clItems.BorderWidth = 0;

                    tblPrueba.AddCell(clItemsID);
                    tblPrueba.AddCell(clItems);

                }


            }




            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();






        }
    }
}