using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DomainAmbientHouse.Servicios
{
    public class PresupuestosServicios
    {

        PresupuestosNegocios Negocios;


        public PresupuestosServicios()
        {
            Negocios = new PresupuestosNegocios();


        }

        public ObtenerDatosParaPresupuesto ObtenerPresupuestos(int eventoId)
        {

            return Negocios.ObtenerPresupuestos(eventoId);
        }

        public List<PresupuestoDetalle> ObtenerPresupuestoDetalle(int presupuestoId, int unidadNegocioId, int estadoDetalleId)
        {

            return Negocios.ObtenerPresupuestoDetalle(presupuestoId, unidadNegocioId, estadoDetalleId);

        }

        public ObtenerPresupuestoSalon ObtenerPresupuestosSalon(int presupuestoId)
        {

            return Negocios.ObtenerPresupuestosSalon(presupuestoId);
        }

        public ObtenerPresupuestoTecnica ObtenerPresupuestoTecnica(int presupuestoId)
        {

            return Negocios.ObtenerPresupuestoTecnica(presupuestoId);
        }

        public ObtenerPresupuestoCatering ObtenerPresupuestoCatering(int presupuestoId)
        {

            return Negocios.ObtenerPresupuestoCatering(presupuestoId);
        }

        public ObtenerPresupuestoBarra ObtenerPresupuestoBarra(int presupuestoId)
        {

            return Negocios.ObtenerPresupuestoBarra(presupuestoId);
        }

        public ObtenerPresupuestoAmbientacion ObtenerPresupuestoAmbientacion(int presupuestoId)
        {

            return Negocios.ObtenerPresupuestoAmbientacion(presupuestoId);
        }

        public PresupuestoPDF ObtenerPresupuestosPorPresupuesto(int id, List<ClientesPipedrive> lisClientes)
        {
            return Negocios.ObtenerPresupuestosPorPresupuesto(id, lisClientes);
        }

        public List<ListarAdicionalesPorPresupuesto> ObtenerAdicionales(int presupuestoId, int estadoId)
        {
            return Negocios.ObtenerAdicionales(presupuestoId, estadoId);
        }

        public double CalcularValorTotalPresupuestoPorPresupuestoId(int PresupuestoId)
        {

            return Negocios.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);
        }

        public List<PresupuestoDetalle> BuscarDetallePresupuesto(int PresupuestoId)
        {
            return Negocios.BuscarDetallePresupuesto(PresupuestoId);
        }

        public List<PresupuestoDetalle> BuscarDetallePresupuestoAprobados(int PresupuestoId)
        {
            return Negocios.BuscarDetallePresupuestoAprobados(PresupuestoId);
        }

        public void AplicarAjuste(int presupuestoDetalleId, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            Negocios.AplicarAjuste(presupuestoDetalleId, TotalDescuento, TotalIncremento, Comentario);
        }

        public void AplicarAjuste(int presupuestoDetalleId, double TotalDescuento, double TotalIncremento, string Comentario, double TotalCosto)
        {
            Negocios.AplicarAjuste(presupuestoDetalleId, TotalDescuento, TotalIncremento, Comentario, TotalCosto);
        }

        public PresupuestoDetalle AddItem(PresupuestoDetalle detalle, Productos producto, int locacionId, int invitadosAdultos, int invitadosAdolescentes, int invitadosTotal, List<PresupuestoDetalle> list)
        {
            PresupuestoDetalleNegocios negocio = new PresupuestoDetalleNegocios();

            return negocio.AddItem(detalle, producto, locacionId, invitadosAdultos, invitadosAdolescentes, invitadosTotal, list);
        }

        public double CalcularValorTotalPresupuestoPorPresupuestoIdPendiente(int PresupuestoId)
        {
            return Negocios.CalcularValorTotalPresupuestoPorPresupuestoIdPendiente(PresupuestoId);
        }

        public PresupuestoDetalle AprobarItemPresupuesto(int detalleId)
        {
             PresupuestoDetalleNegocios negocio = new PresupuestoDetalleNegocios();

             return negocio.AprobarItemPresupuesto(detalleId);
        }

        public void EditarCantidadInvitados(Presupuestos PresupuestoSeleccionado)
        {
            Negocios.EditarCantidadInvitados(PresupuestoSeleccionado);
        }

        public PresupuestoDetalle BuscarPresupuestoDetalle(int id)
        {
            PresupuestoDetalleNegocios negocio = new PresupuestoDetalleNegocios();

            return negocio.BuscarPresupuestoDetalle( id);
        }

        public bool ActualizarFechaEvento(Presupuestos PresupuestoSeleccionado)
        {
            return Negocios.ActualizarFechaEvento(PresupuestoSeleccionado);
        }

        public List<FechasBloqueadas> ObtenerFechasBloqueadas(DateTime fechaSeleccionada)
        {
            return Negocios.ObtenerFechasBloqueadas(fechaSeleccionada);
        }

        public bool ElimarDetallePresupuesto(int Id)
        {

            return Negocios.EliminarDetallePresupuesto(Id);
        }

        public List<PagosClientes> ObtenerPagosClientePorPresupuesto(int presupuestoId)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();


            return negocios.ObtenerPagosClientePorPresupuesto(presupuestoId);
        }

        public PagosClientes BuscarPagoCliente(int id)
        { 
              PagosClienteNegocios negocios = new PagosClienteNegocios();


              return negocios.BuscarPagoCliente(id);
        }

        public bool GrabarPagoCliente(PagosClientes pagoCliente, Cheques cheque)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();

            return negocios.GrabarPago(pagoCliente, cheque);
        }

        public bool GrabarPagoCliente(PagosClientes pagoCliente, Transferencias transferencia)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();

            return negocios.GrabarPago(pagoCliente, transferencia);
        }

        public bool GrabarPagoCliente(PagosClientes pagoCliente)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();

            return negocios.GrabarPago(pagoCliente);
        }

        public bool ElimarPagoCliente(int id)
        {
            PagosClienteNegocios negocios = new PagosClienteNegocios();

            return negocios.EliminarPago(id);
        }

        public bool ActualizarCobroItem(int Id)
        {
            PresupuestoDetalleNegocios negocios = new PresupuestoDetalleNegocios();

            return negocios.ActualizarCobroItem(Id);
        }

        public List<PresupuestoDetalle> BuscarDetallePresupuestoNoPagos(int presupuestoId,string fechaEvento, string cliente)
        {
            PresupuestoDetalleNegocios negocios = new PresupuestoDetalleNegocios();

            return negocios.BuscarDetallePresupuestoNoPagados(presupuestoId,fechaEvento,cliente);
        }

        public Presupuestos BuscarPresupuesto(int presupuestoId)
        {
            PresupuestosNegocios negocio = new PresupuestosNegocios();

            return negocio.BuscarPresupuesto(presupuestoId);
        }

        public void BuscarDetallePresupuestoTable(int PresupuestoId, HtmlTable _retorno)
        {

            Presupuestos cabecera = Negocios.BuscarPresupuesto(PresupuestoId);
            List<PresupuestoDetalle> detalle =  Negocios.BuscarDetallePresupuesto(PresupuestoId);


            ArmarCabeceraGrillaPresupuestoDetalle(_retorno);

            double _totalizadorCanon = 0;
            double _logisticaTotal = 0;

            foreach (var item in detalle)
            {

                _totalizadorCanon = _totalizadorCanon + (item.Cannon == null ? 0 : double.Parse(item.Cannon.ToString()));

                _logisticaTotal = _logisticaTotal + (item.Logistica == null ? 0 : double.Parse(item.Logistica.ToString()));


                HtmlTableRow fila = new HtmlTableRow();


                HtmlTableCell nroItem = new HtmlTableCell();
                nroItem.InnerText = item.Id.ToString();

                HtmlTableCell unidadNegocio = new HtmlTableCell();
                unidadNegocio.InnerText = item.UnidadNegocioDescripcion;

                HtmlTableCell producto = new HtmlTableCell();
                producto.InnerText = item.ProductoDescripcion;

                HtmlTableCell precioSeleccionado = new HtmlTableCell();
                precioSeleccionado.InnerText = item.PrecioSeleccionado;

                HtmlTableCell tipoLogistica = new HtmlTableCell();
                tipoLogistica.InnerText =  item.TipoLogisticaDescripcion;

                HtmlTableCell localidad = new HtmlTableCell();
                localidad.InnerText = item.LocalidadDescripcion;

                HtmlTableCell logisticaCosto = new HtmlTableCell();
                logisticaCosto.Attributes.Add("style", "text-align: right;");
                logisticaCosto.InnerText = item.Logistica == null ? "" : System.Math.Round((double)item.Logistica, 2).ToString("C");

                HtmlTableCell canon = new HtmlTableCell();
                canon.Attributes.Add("style", "text-align: right;");
                canon.InnerText = item.Cannon == null ? "" : System.Math.Round((double)item.Cannon, 2).ToString("C");

                HtmlTableCell precio = new HtmlTableCell();
                precio.Attributes.Add("style", "text-align: right;");
                precio.InnerText = item.NuevoValor == null ? "" : System.Math.Round((double)item.NuevoValor, 2).ToString("C");


                HtmlTableCell estadoItem = new HtmlTableCell();
                estadoItem.InnerText = item.EstadoItem;

                HtmlTableCell textboxComentario = new HtmlTableCell();

                TextBox Comentario = new TextBox();
                Comentario.TextMode = TextBoxMode.MultiLine;
                Comentario.ID = "TextBoxComentario" + item.Id.ToString();
              
                Comentario.CssClass = "form-control";

                textboxComentario.Controls.Add(Comentario);

                HtmlTableCell acciones = new HtmlTableCell();

                HtmlButton descuentos = new HtmlButton();
                //descuentos.ImageUrl = "~/Content/Imagenes/Ajuste.png";
                descuentos.ID = item.Id.ToString();
                descuentos.Attributes.Add("style", "width: 25px; height: 25px;");
                descuentos.Attributes.Add("OnClick", "javascript:return fnAceptar("  + item.Id + ");");
              

                ImageButton descuentos1 = new ImageButton();
                descuentos1.ImageUrl = "~/Content/Imagenes/Ajuste.png";
                descuentos1.ID = item.Id.ToString();
                descuentos1.Attributes.Add("style", "width: 25px; height: 25px;");
                
                acciones.Controls.Add(descuentos);
                acciones.Controls.Add(descuentos1);

               
                 //<asp:ImageButton ID="ImageDescuentos" runat="server" Text="Ver" ToolTip="Aplicar Ajustes (Descuentos/Incrementos) por Unidades de Negocio al Presupuesto." ImageUrl="~/Content/Imagenes/Ajuste.png"

             
                fila.Cells.Add(nroItem);
                fila.Cells.Add(unidadNegocio);
                fila.Cells.Add(producto);
                fila.Cells.Add(precioSeleccionado);
                fila.Cells.Add(tipoLogistica);
                fila.Cells.Add(localidad);
                fila.Cells.Add(logisticaCosto);
                fila.Cells.Add(canon);
                fila.Cells.Add(precio);
                fila.Cells.Add(estadoItem);
                fila.Cells.Add(textboxComentario);
                fila.Cells.Add(acciones);

                _retorno.Rows.Add(fila);
                
            }


            double Valor = this.CalcularValorTotalPresupuestoPorPresupuestoId(PresupuestoId);

            ArmarLogisticaGrillaPresupuestoDetalle(_retorno, System.Math.Round(_logisticaTotal, 2).ToString("C"));
            ArmarCanonGrillaPresupuestoDetalle (_retorno,System.Math.Round(_totalizadorCanon, 2).ToString("C"));
            //ArmarOrganizadorGrillaPresupuestoDetalle(_retorno, ,System.Math.Round(cabecera.ValorOrganizador, 2).ToString("C"));
            ArmarFooterGrillaPresupuestoDetalle(_retorno,System.Math.Round(Valor, 2).ToString("C"));


        }

        public List<Presupuestos> BuscarPresupuestoPorCliente(int clientebisId)
        {
            return Negocios.BuscarPresupuestoPorCliente(clientebisId);
        }

        private static void ArmarCabeceraGrillaPresupuestoDetalle(HtmlTable _retorno)
        {
            HtmlTableRow cabecera = new HtmlTableRow();



            HtmlTableCell _nroItem = new HtmlTableCell();
            _nroItem.InnerHtml = "<b>Nro. Item</b>";


            HtmlTableCell _unidadNegocio = new HtmlTableCell();
            _unidadNegocio.InnerHtml = "<b>U. N.</b>";

            HtmlTableCell _producto = new HtmlTableCell();
            _producto.InnerHtml = "<b>Producto</b>";

            HtmlTableCell _precioSeleccionado = new HtmlTableCell();
            _precioSeleccionado.InnerHtml = "<b>PL Seleccionado</b>"; 

            HtmlTableCell _tipoLogistica = new HtmlTableCell();
            _tipoLogistica.InnerHtml = "<b>Logistica</b>"; 

            HtmlTableCell _localidad = new HtmlTableCell();
            _localidad.InnerHtml = "<b>Localidad</b>"; 

            HtmlTableCell _logisticaCosto = new HtmlTableCell();
            _logisticaCosto.InnerHtml = "<b>Log. Costo</b>"; 

            HtmlTableCell _canon = new HtmlTableCell();
            _canon.InnerHtml = "<b>Canon</b>"; 

            HtmlTableCell _precio = new HtmlTableCell();
            _precio.InnerHtml = "<b>Precio</b>"; 

            HtmlTableCell _estadoItem = new HtmlTableCell();
            _estadoItem.InnerHtml = "<b>Estado</b>";

            HtmlTableCell _comentario = new HtmlTableCell();
            _comentario.InnerHtml = "<b>Comentario</b>";

            HtmlTableCell _acciones = new HtmlTableCell();
            _acciones.InnerHtml = "<b>Acciones</b>"; 

            cabecera.Cells.Add(_nroItem);
            cabecera.Cells.Add(_unidadNegocio);
            cabecera.Cells.Add(_producto);
            cabecera.Cells.Add(_precioSeleccionado);
            cabecera.Cells.Add(_tipoLogistica);
            cabecera.Cells.Add(_localidad);
            cabecera.Cells.Add(_logisticaCosto);
            cabecera.Cells.Add(_canon);
            cabecera.Cells.Add(_precio);
            cabecera.Cells.Add(_estadoItem);
            cabecera.Cells.Add(_comentario);
            cabecera.Cells.Add(_acciones);

            _retorno.Rows.Add(cabecera);
        }

        private static void ArmarCanonGrillaPresupuestoDetalle(HtmlTable _retorno, string canonTotal)
        {
            HtmlTableRow footer = new HtmlTableRow();
            //footer.Attributes.Add("class", "bg-success");

            HtmlTableCell _footer1 = new HtmlTableCell();
            _footer1.InnerText = "";


            HtmlTableCell _footer2 = new HtmlTableCell();
            _footer2.InnerText = "";

            HtmlTableCell _footer3 = new HtmlTableCell();
            _footer3.InnerText = "";


            HtmlTableCell _footer4 = new HtmlTableCell();
            _footer4.InnerText = "";

            HtmlTableCell _footer5 = new HtmlTableCell();
            _footer5.InnerText = "";


            HtmlTableCell _footer6 = new HtmlTableCell();
            _footer6.InnerText = "";

            HtmlTableCell _footer7 = new HtmlTableCell();
            _footer7.InnerText = "";


            HtmlTableCell _footer8 = new HtmlTableCell();
            _footer8.InnerHtml = "<b>Total Canon:</b>";

            HtmlTableCell _footer9 = new HtmlTableCell();
            _footer9.Attributes.Add("style", "text-align: right;");
            _footer9.InnerHtml = "<b>" + canonTotal + "</b>";


            HtmlTableCell _footer10 = new HtmlTableCell(); 
            _footer10.InnerText = "";

            HtmlTableCell _footer11 = new HtmlTableCell();
            _footer11.InnerText = "";


            footer.Cells.Add(_footer1);
            footer.Cells.Add(_footer2);
            footer.Cells.Add(_footer3);
            footer.Cells.Add(_footer4);
            footer.Cells.Add(_footer5);
            footer.Cells.Add(_footer6);
            footer.Cells.Add(_footer7);
            footer.Cells.Add(_footer8);
            footer.Cells.Add(_footer9);
            footer.Cells.Add(_footer10);
            footer.Cells.Add(_footer11);

            _retorno.Rows.Add(footer);
        }

      
        private static void ArmarLogisticaGrillaPresupuestoDetalle(HtmlTable _retorno, string logisticaTotal)
        {
            HtmlTableRow footer = new HtmlTableRow();
        

            HtmlTableCell _footer1 = new HtmlTableCell();
            _footer1.InnerText = "";


            HtmlTableCell _footer2 = new HtmlTableCell();
            _footer2.InnerText = "";

            HtmlTableCell _footer3 = new HtmlTableCell();
            _footer3.InnerText = "";


            HtmlTableCell _footer4 = new HtmlTableCell();
            _footer4.InnerText = "";

            HtmlTableCell _footer5 = new HtmlTableCell();
            _footer5.InnerText = "";


            HtmlTableCell _footer6 = new HtmlTableCell();
            _footer6.InnerText = "";

            HtmlTableCell _footer7 = new HtmlTableCell();
            _footer7.InnerText = "";


            HtmlTableCell _footer8 = new HtmlTableCell();
            _footer8.InnerHtml = "<b>Total Logistica:</b>";

            HtmlTableCell _footer9 = new HtmlTableCell();
            _footer9.Attributes.Add("style", "text-align: right;");
            _footer9.InnerHtml = "<b>" + logisticaTotal + " </b>";


            HtmlTableCell _footer10 = new HtmlTableCell();
            _footer10.InnerText = "";

            HtmlTableCell _footer11 = new HtmlTableCell();
            _footer11.InnerText = "";

            HtmlTableCell _footer12 = new HtmlTableCell();
            _footer12.InnerText = "";


            footer.Cells.Add(_footer1);
            footer.Cells.Add(_footer2);
            footer.Cells.Add(_footer3);
            footer.Cells.Add(_footer4);
            footer.Cells.Add(_footer5);
            footer.Cells.Add(_footer6);
            footer.Cells.Add(_footer7);
            footer.Cells.Add(_footer8);
            footer.Cells.Add(_footer9);
            footer.Cells.Add(_footer10);
            footer.Cells.Add(_footer11);
            footer.Cells.Add(_footer12);

            _retorno.Rows.Add(footer);
        }

        private static void ArmarOrganizadorGrillaPresupuestoDetalle(HtmlTable _retorno, string totalOrganizador)
        {
            HtmlTableRow footer = new HtmlTableRow();


            HtmlTableCell _footer1 = new HtmlTableCell();
            _footer1.InnerText = "";


            HtmlTableCell _footer2 = new HtmlTableCell();
            _footer2.InnerText = "";

            HtmlTableCell _footer3 = new HtmlTableCell();
            _footer3.InnerText = "";


            HtmlTableCell _footer4 = new HtmlTableCell();
            _footer4.InnerText = "";

            HtmlTableCell _footer5 = new HtmlTableCell();
            _footer5.InnerText = "";


            HtmlTableCell _footer6 = new HtmlTableCell();
            _footer6.InnerText = "";

            HtmlTableCell _footer7 = new HtmlTableCell();
            _footer7.InnerText = "";


            HtmlTableCell _footer8 = new HtmlTableCell();
            _footer8.InnerHtml = "<b>Total Organizador:</b>";

            HtmlTableCell _footer9 = new HtmlTableCell();
            _footer9.Attributes.Add("style", "text-align: right;");
            _footer9.InnerHtml = "<b>" + totalOrganizador + " </b>";


            HtmlTableCell _footer10 = new HtmlTableCell();
            _footer10.InnerText = "";


            HtmlTableCell _footer11 = new HtmlTableCell();
            _footer11.InnerText = "";

            HtmlTableCell _footer12 = new HtmlTableCell();
            _footer12.InnerText = "";


            footer.Cells.Add(_footer1);
            footer.Cells.Add(_footer2);
            footer.Cells.Add(_footer3);
            footer.Cells.Add(_footer4);
            footer.Cells.Add(_footer5);
            footer.Cells.Add(_footer6);
            footer.Cells.Add(_footer7);
            footer.Cells.Add(_footer8);
            footer.Cells.Add(_footer9);
            footer.Cells.Add(_footer10);
            footer.Cells.Add(_footer11);
            footer.Cells.Add(_footer12);

            _retorno.Rows.Add(footer);

        }

        private static void ArmarFooterGrillaPresupuestoDetalle(HtmlTable _retorno, string preciototal)
        {
            HtmlTableRow footer = new HtmlTableRow();

            footer.Attributes.Add("class", "bg-primary");

    
            HtmlTableCell _footer1 = new HtmlTableCell();
            _footer1.InnerText = "";


            HtmlTableCell _footer2 = new HtmlTableCell();
            _footer2.InnerText = "";

            HtmlTableCell _footer3 = new HtmlTableCell();
            _footer3.InnerText = "";


            HtmlTableCell _footer4 = new HtmlTableCell();
            _footer4.InnerText = "";

            HtmlTableCell _footer5 = new HtmlTableCell();
            _footer5.InnerText = "";


            HtmlTableCell _footer6 = new HtmlTableCell();
            _footer6.InnerText = "";

            HtmlTableCell _footer7 = new HtmlTableCell();
            _footer7.InnerText = "";


            HtmlTableCell _footer8 = new HtmlTableCell();
            _footer8.InnerHtml = "<b>Total Presupuesto:</b>";

            HtmlTableCell _footer9 = new HtmlTableCell();
            _footer9.Attributes.Add("style", "text-align: right;");
            _footer9.InnerHtml = "<b>" + preciototal + " </b>";


            HtmlTableCell _footer10 = new HtmlTableCell();
            _footer10.InnerText = "";

            HtmlTableCell _footer11 = new HtmlTableCell();
            _footer11.InnerText = "";

            HtmlTableCell _footer12 = new HtmlTableCell();
            _footer12.InnerText = "";


            footer.Cells.Add(_footer1);
            footer.Cells.Add(_footer2);
            footer.Cells.Add(_footer3);
            footer.Cells.Add(_footer4);
            footer.Cells.Add(_footer5);
            footer.Cells.Add(_footer6);
            footer.Cells.Add(_footer7);
            footer.Cells.Add(_footer8);
            footer.Cells.Add(_footer9);
            footer.Cells.Add(_footer10);
            footer.Cells.Add(_footer11);
            footer.Cells.Add(_footer12);

            _retorno.Rows.Add(footer);
        }

        //private HtmlTableRow AddFilaDetallePresupuesto(string descripcion1, string descripcion2, string contenido1, string contenido2)
        //{
        //    HtmlTableRow fila = new HtmlTableRow();


        //    HtmlTableCell celda10 = new HtmlTableCell();

        //    Label lbl = new Label();


        //    lbl.CssClass = "form-control";

        //    lbl.Text = descripcion1 + ": <b>" + contenido1 + "</b>";

        //    celda10.Controls.Add(lbl);

        //    HtmlTableCell celda11 = new HtmlTableCell();
        //    celda11.InnerText = "";

        //    HtmlTableCell celda12 = new HtmlTableCell();

        //    Label lbl1 = new Label();


        //    lbl1.CssClass = "form-control";

        //    lbl1.Text = descripcion2 + ": <b>" + contenido2 + "</b>";

        //    celda12.Controls.Add(lbl1);

        //    fila.Cells.Add(celda10);
        //    fila.Cells.Add(celda11);
        //    fila.Cells.Add(celda12);

        //    return fila;

        //}

        public void ActualizarDetallePresupuestos(PresupuestoDetalle detalle)
        {
            PresupuestoDetalleNegocios negocios = new  PresupuestoDetalleNegocios();

            negocios.GrabarDetallePresupuesto(detalle);
        }

        public List<PagosClientes> ObtenerPagosClientePorPresupuestoNeto(int PresupuestoId)
        {
            PagosClienteNegocios negocio = new PagosClienteNegocios();

            return negocio.ObtenerPagosClientePorPresupuestoNeto(PresupuestoId);
        }

        public CalculoIndexacion CalcularIndexacion(double indice, int presupuestoId)
        {
            return Negocios.CalcularIndexacion(indice, presupuestoId);
        }

        public CalculoIndexacion CalcularIndexacionPagoaCuenta(double indice, int presupuestoId)
        {
            return Negocios.CalcularIndexacionPagoaCuenta(indice, presupuestoId);
        }

        public double CalcularValorTotalPresupuestoAprobado(int PresupuestoId)
        {
            return Negocios.CalcularValorTotalPresupuestoAprobado(PresupuestoId);
        }

        public double CalcularValorTotalRoyaltyAprobado(int presupuestoId)
        {
            return Negocios.CalcularValorTotalRoyaltyAprobado(presupuestoId);
        }

        

        public bool EliminarInvitadosPendientes(int presupuestoId)
        {
            PresupuestosNegocios negocios = new PresupuestosNegocios();

            return negocios.EliminarInvitadosPendientes(presupuestoId);
        }

        public bool EditarDetallePresupuesto(PresupuestoDetalle detalle)
        {
            PresupuestoDetalleNegocios negocios = new PresupuestoDetalleNegocios();

            return negocios.GrabarPresupuestoDetalleRevisado(detalle);
        }
    }
}
