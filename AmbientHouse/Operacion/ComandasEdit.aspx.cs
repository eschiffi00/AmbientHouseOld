using DbEntidades.Entities;
using DbEntidades.Operators;
using iTextSharp.text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AmbientHouse.Configuracion.AbmItems
{
    public partial class ComandasEdit : System.Web.UI.Page
    {
        List<ComandaDetalle> seComanda = new List<ComandaDetalle>();
        Comandas Cabecera = new Comandas();
        DataTable tablagrid = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["tablagrid"] = tablagrid;
                SessionClearAll();
                var id = 0;
                if (Request["Id"] != "" && Request["Id"] != null)
                {
                    id = int.Parse(Request["Id"]);
                }
                seComanda = ComandaDetalleOperator.GetAllByParameter("ComandaId", (id > 0 ? id : 0).ToString());
                seComanda.Reverse();
                Cabecera = ComandasOperator.GetOneByIdentity(id);
                CargaDatosGenerales(sender,e,Cabecera);
                CargaRepBebidas(seComanda);
                CargaRepBocados(seComanda);
                CargaRepIslas(seComanda);
                CargaRepPrincipales(seComanda);
                CargaRepBrindis(seComanda);
                CargaRepDulces(seComanda);
                CargaRepFinFiesta(seComanda);
                CargaRepPostre(seComanda);

                SessionSaveAll();
            }
            SessionLoadAll();
        }

        #region Session
        protected void SessionClearAll()
        {
            Session["seComanda"] = null;
            Session["tipoIsla"] = "";
        }
        protected void SessionLoadAll()
        {
            seComanda = (List<ComandaDetalle>)Session["seComanda"];
        }
        protected void SessionSaveAll()
        {
            Session["seComanda"] = seComanda;
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            SessionSaveAll();
            base.OnPreRenderComplete(e);
        }
        #endregion Session
        protected void CargaDatosGenerales(object sender, EventArgs e,Comandas datos)
        {
            lblPresupuestoId.Text = datos.PresupuestoId != null ? datos.PresupuestoId.ToString() : string.Empty;
            lblFechaEvento.Text = datos.fechaEvento != null ? datos.fechaEvento.ToString() : "";
            lblLocacion.Text = datos.Locacion != null ? datos.Locacion.ToString() : "";
            lblHorarioLlegada.Text = datos.HorarioLlegada != null ? datos.HorarioLlegada.ToString() : "";
            lblHorarioInicio.Text = datos.HorarioInicio != null ? datos.HorarioInicio.ToString() : "";
            lblHorarioFin.Text = datos.HorarioFin != null ? datos.HorarioFin.ToString() : "";
            lblTipoEvento.Text = datos.TipoEvento != null ? datos.TipoEvento.ToString() : "" ;
            lblTipoExperiencia.Text = datos.TipoExperiencia != null ? datos.TipoExperiencia.ToString() : "";
            lblDuracion.Text = datos.Duracion != null ? datos.Duracion.ToString() : "";
            lblEmpresa.Text = datos.Empresa != null ? datos.Empresa.ToString() : "";
            lblOrganizador.Text = datos.Organizador != null ? datos.Organizador.ToString() : "";
            lblMaitre.Text = datos.Maitre != null ? datos.Maitre.ToString() : "";   
            lblCoordinador.Text = datos.Coordinador != null ? datos.Coordinador.ToString() : "";
            lblJefeProducto.Text = datos.JefeProducto != null ? datos.JefeProducto.ToString() : "";
            lblAdultos.Text = datos.Adultos != null ? datos.Adultos.ToString() : "";
            lblMenores3.Text = datos.Menores3 != null ? datos.Menores3.ToString() : "";
            lblMenores3y8.Text = datos.Menores3y8 != null ? datos.Menores3y8.ToString() : "";
            lblAdolescentes.Text = datos.Adolescentes != null ? datos.Adolescentes.ToString() : "";
            lblEstado.Text = "pendiente";
        }
        protected void CargaRepBebidas(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            //foreach (var item in seComanda)
            var listaFiltrada = seComanda.Where(x => x.Orden == 22);
            foreach(var item in listaFiltrada)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((detalleItem.Detalle,cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repBebidas.DataSource = dinamicList;
            repBebidas.DataBind();

        }
        protected void CargaRepBocados(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 7);
            foreach (var item in listaFiltrada)
            {
                if(item.Clave.Substring(0, 3) == "PRO")
                {
                    var proId = item.Clave.Substring(3);
                    var titulo = ProductosCateringOperator.GetOneByIdentity(int.Parse(proId)).Titulo;
                    if(titulo == "Bocados")
                    {
                        int itemId = item.ItemId.Value;
                        var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                        var cantidad = item.Cantidad.ToString();
                        matriz.Add((detalleItem.Detalle, cantidad));
                    }
                }  
            }

            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repBocados.DataSource = dinamicList;
            repBocados.DataBind();
        }
        protected void CargaRepIslas(List<ComandaDetalle> seComanda)
        {
            List<(string, string, string)> matriz = new List<(string, string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 7);
            foreach (var item in listaFiltrada)
            {
                if (item.Clave.Substring(0, 3) == "PRO")
                {
                    var proId = item.Clave.Substring(3);
                    var prod = ProductosCateringOperator.GetOneByIdentity(int.Parse(proId));
                    if (prod.Titulo == "Islas")
                    {
                        int itemId = item.ItemId.Value;
                        var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                        var cantidad = item.Cantidad.ToString();
                        matriz.Add((prod.Descripcion,detalleItem.Detalle, cantidad));
                    }
                }
            }
            List<DinamicData2> dinamicList = new List<DinamicData2>();
            dinamicList = matriz.ConvertAll(x => new DinamicData2 { Titulo = x.Item1, Nombre = x.Item2, Cantidad = x.Item3 });
            repIslas.DataSource = dinamicList;
            repIslas.DataBind();
        }
        protected void CargaRepPrincipales(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 9);
            foreach (var item in listaFiltrada)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((detalleItem.Detalle, cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repPrincipales.DataSource = dinamicList;
            repPrincipales.DataBind();
        }
        protected void CargaRepBrindis(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 17);
            foreach (var item in listaFiltrada)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((detalleItem.Detalle, cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repBrindis.DataSource = dinamicList;
            repBrindis.DataBind();
        }
        protected void CargaRepDulces(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 18);
            foreach (var item in listaFiltrada)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((detalleItem.Detalle, cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repDulce.DataSource = dinamicList;
            repDulce.DataBind();
        }
        protected void CargaRepFinFiesta(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 20);
            foreach (var item in listaFiltrada)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((detalleItem.Detalle, cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repFinFiesta.DataSource = dinamicList;
            repFinFiesta.DataBind();
        }
        protected void CargaRepPostre(List<ComandaDetalle> seComanda)
        {
            List<(string, string)> matriz = new List<(string, string)>();
            var listaFiltrada = seComanda.Where(x => x.Orden == 21);
            foreach (var item in listaFiltrada)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((detalleItem.Detalle, cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Nombre = x.Item1, Cantidad = x.Item2 });
            repPostre.DataSource = dinamicList;
            repPostre.DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var duplicado = 0;
            List<string> parametros = new List<string>();
            Ratios Ratio = new Ratios();
            try
            {
                var temp = Request["Id"];
                var id = 0;
                if (temp != null)
                {
                    id = int.Parse(Request["Id"]);
                }

                
                if (duplicado == 0)
                {
                    Response.Redirect("~/Configuracion/AbmItems/RatiosBrowse.aspx");
                }

            }
            catch (Exception ex)
            {
                //AlertaRoja(ex.Message);
            }
        }

        protected void repBebidas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repBebidas = (Repeater)sender;
                if (repBebidas.DataSource == null || repBebidas.Items.Count == 0)
                {
                    repBebidas.Visible = false;
                }
            }
        }

        protected void repIslas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var hfIsla = e.Item.FindControl("hfIsla") as HiddenField;
                var tipoIsla = hfIsla.Value;
                var phSubtitulo = e.Item.FindControl("phSubtitulo") as PlaceHolder;

                if (tipoIsla != (string)Session["tipoIsla"])
                {
                    phSubtitulo.Controls.Add(new LiteralControl("<h5>" + tipoIsla +"</h5>"));
                    Session["tipoIsla"] = tipoIsla;
                }
                
            }
        }

    }

    internal class DinamicData
    {
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
    }
    internal class DinamicData2
    {
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
    }
}