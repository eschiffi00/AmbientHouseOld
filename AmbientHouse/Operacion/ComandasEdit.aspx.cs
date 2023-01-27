using DbEntidades.Entities;
using DbEntidades.Operators;
using iTextSharp.text;
using Microsoft.SqlServer.Server;
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
                //CargaRepBebidas(seComanda);
                CargaRepBocados(seComanda);
                CargaRepIslas(seComanda);
                CargaRepCommon(seComanda.Where(x => x.Orden == 22).ToList(), repBebidas);
                CargaRepCommon(seComanda.Where(x => x.Orden == 9).ToList(), repPrincipales);
                CargaRepCommon(seComanda.Where(x => x.Orden == 17).ToList(), repBrindis);
                CargaRepCommon(seComanda.Where(x => x.Orden == 18).ToList(), repDulce);
                CargaRepCommon(seComanda.Where(x => x.Orden == 20).ToList(), repFinFiesta);
                CargaRepCommon(seComanda.Where(x => x.Orden == 21).ToList(), repPostre);

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
        protected void CargaRepBocados(List<ComandaDetalle> seComanda)
        {
            List<(string, string, string, string)> matriz = new List<(string, string, string, string)>(); 
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
                        matriz.Add((item.Clave, item.ItemId.ToString(), detalleItem.Detalle, cantidad));
                    }
                }  
            }

            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Clave = x.Item1, ItemId = x.Item2, Nombre = x.Item3, Cantidad = x.Item4 }); repBocados.DataSource = dinamicList;
            repBocados.DataBind();
        }
        protected void CargaRepIslas(List<ComandaDetalle> seComanda)
        {
            List<(string, string, string, string,string)> matriz = new List<(string, string, string, string,string)>();
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
                        matriz.Add((item.Clave, item.ItemId.ToString(), prod.Descripcion, detalleItem.Detalle, cantidad));
                    }
                }
            }
            List<DinamicData2> dinamicList = new List<DinamicData2>();
            dinamicList = matriz.ConvertAll(x => new DinamicData2 { Clave = x.Item1, ItemId = x.Item2,Titulo = x.Item3, Nombre = x.Item4, Cantidad = x.Item5 }); 
            repIslas.DataSource = dinamicList;
            repIslas.DataBind();
        }
        protected void CargaRepCommon(List<ComandaDetalle> lista,Repeater rep)
        {
            List<(string, string, string, string)> matriz = new List<(string, string, string, string)>();
            foreach (var item in lista)
            {
                int itemId = item.ItemId.Value;
                var detalleItem = ItemsOperator.GetOneByIdentity(itemId);
                var cantidad = item.Cantidad.ToString();
                matriz.Add((item.Clave, item.ItemId.ToString(), detalleItem.Detalle, cantidad));
            }
            List<DinamicData> dinamicList = new List<DinamicData>();
            dinamicList = matriz.ConvertAll(x => new DinamicData { Clave = x.Item1, ItemId = x.Item2, Nombre = x.Item3, Cantidad = x.Item4 });
            rep.DataSource = dinamicList;
            rep.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> parametros = new List<string>();
            Ratios Ratio = new Ratios();
            try
            {
                GrabaDatosComanda(sender,e);

                Response.Redirect("~/Operacion/ComandasBrowse.aspx");
            }
            catch (Exception ex)
            {
                //AlertaRoja(ex.Message);
            }
        }
        protected void GrabaDatosComanda(object sender, EventArgs e) 
        {
            var temp = Request["Id"];
            var id = 0;
            if (temp != null)
            {
                id = int.Parse(Request["Id"]);
            }
            GrabaDatosRep(id, repBebidas);
            GrabaDatosRep(id, repBocados);
            GrabaDatosRep(id, repIslas);
            GrabaDatosRep(id, repPrincipales);
            GrabaDatosRep(id, repBrindis);
            GrabaDatosRep(id, repDulce);
            GrabaDatosRep(id, repFinFiesta);
            GrabaDatosRep(id, repPostre);
       
        }
        protected void GrabaDatosRep(int id,Repeater rep)
        {
            
            try
            {
                foreach (RepeaterItem item in rep.Items)
                {
                    HiddenField hfCommon = (HiddenField)item.FindControl("hfCommon");
                    HiddenField hfCommon2 = (HiddenField)item.FindControl("hfCommon2");
                    Label lblNombre = (Label)item.FindControl("lblNombre");
                    TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");
                    string clave = hfCommon.Value;
                    string nombre = lblNombre.Text;
                    string cantidad = txtCantidad.Text;
                    string itemid = hfCommon2.Value;
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("ComandaId", id.ToString());
                    parameters.Add("Clave", clave);
                    parameters.Add("ItemId", itemid);

                    ComandaDetalle resultado = CommonOperator.GetOneByMultipleParameter<ComandaDetalle>(parameters);
                    resultado.Cantidad = int.Parse(cantidad);
                    ComandaDetalleOperator.Save(resultado);
                }
            }
            catch (Exception ex)
            {
                //AlertaRoja(ex.Message);
            }
        }
        public void repBebidas_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        public string Clave { get; set; }
        public string ItemId { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
    }
    internal class DinamicData2
    {
        public string Clave { get; set; }
        public string ItemId { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
    }
}