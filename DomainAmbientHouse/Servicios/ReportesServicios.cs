using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System.Collections.Generic;

namespace DomainAmbientHouse.Servicios
{
    public class ReporteServicios
    {

        AdicionalesNegocios NegocioAdicionales;
        EventosNegocios NegocioEventos;
        ComprobanteProveedoresNegocios NegocioComprobantes;
        PagosClienteNegocios NegocioPagosClientes;
        CuentassNegocios NegocioCuenta;
        ProductosNegocios NegocioProducto;

        public ReporteServicios()
        {
            NegocioAdicionales = new AdicionalesNegocios();
            NegocioEventos = new EventosNegocios();
            NegocioComprobantes = new ComprobanteProveedoresNegocios();
            NegocioPagosClientes = new PagosClienteNegocios();
            NegocioCuenta = new CuentassNegocios();
            NegocioProducto = new ProductosNegocios();


        }

        public List<Productos> ListarProductos(SearcherProductos searcher)
        {
            return NegocioProducto.ListarProductos(searcher);
        }

        public List<ReporteAdicionales> ObtenerAdicionalesEventos(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {
            return NegocioAdicionales.ObtenerAdicionalesEventos(nroEvento, nroPresupuesto, fechaDesde, fechaHasta);
        }
        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {
            return NegocioEventos.ObtenerReporteEventosPorUnidadesNegocios(nroEvento, nroPresupuesto, fechaDesde, fechaHasta);
        }

        public List<ReporteComprobantes> ObtenerReporteComprobantes(SearcherReporteComprobantes searcher)
        {
            return NegocioComprobantes.ObtenerReporteComprobantes(searcher);

        }

        public List<CobranzasVentas> ListarCobranzasVentas()
        {
            return NegocioPagosClientes.ListarCobranzasVentas();
        }

        public List<MovimientosCuentas> ListarMovimientos(MovimientosCuentasSearcher searcher)
        {
            return NegocioCuenta.ListarMovimientos(searcher);
        }

        public List<ResponsablesEventos> ListarResponsablesEventos(ResponsablesSearcher searcher)
        {
            return NegocioEventos.ListarResponsablesEventos(searcher);
        }

        public List<GastosporPresupuestos> ListarGastosporPresupuestos(SearcherComprobantes searcher)
        {
            return NegocioComprobantes.ListarGastosporPresupuestos(searcher);
        }

        public List<ProveedoresExternos> ListarProveedoresExternos(ProveedoresExternosSearcher searcher)
        {
            ProveedoresNegocios negocio = new ProveedoresNegocios();

            return negocio.ListarProveedoresExternos(searcher);
        }
    }
}
