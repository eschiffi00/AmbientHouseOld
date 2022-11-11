using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class PedidoCotizacionNegocios
    {

        PedidoCotizacionDatos Datos;

        public PedidoCotizacionNegocios()
        {
            Datos = new PedidoCotizacionDatos();
        }

        //public virtual List<PedidosCotizacion> ListarPedidosCotizacionPorUsuarios(int? empleadoId, int estadoId)
        //{

        //    return Datos.ListarPedidosCotizacionPorUsuarios(empleadoId,estadoId);

        //}

        //public virtual PedidosCotizacion BuscarPedidoCotizacion(int Id)
        //{
        //    return Datos.BuscarPedidoCotizacion(Id);
        //}

        //public virtual void GrabarPedidosCotizacion(PedidosCotizacion pedidos)
        //{
        //    Datos.GrabarPedidosCotizacion(pedidos);
        //}


    }
}
