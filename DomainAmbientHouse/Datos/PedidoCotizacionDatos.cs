using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class PedidoCotizacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public PedidoCotizacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        //public virtual List<PedidosCotizacion> ListarPedidosCotizacionPorUsuarios(int? empleadoId, int estadoId)
        //{
        //    var query = from Tm in SqlContext.PedidosCotizacion
        //                where Tm.EstadoId == estadoId
        //                select new
        //                {
        //                    Id = Tm.Id,
        //                    NroRequerimiento = Tm.NroRequerimiento,
        //                    UnidadNegocioId = Tm.UnidadNegocioId,
        //                    UnidadNegocioDescripcion = SqlContext.UnidadesNegocios.Where(o=> o.Id == Tm.UnidadNegocioId).FirstOrDefault().Descripcion,
        //                    LocacionId = Tm.LocacionId,
        //                    LocacionDescripcion = SqlContext.Locaciones.Where(o=>o.Id == Tm.LocacionId).FirstOrDefault().Descripcion,
        //                    SectorId = Tm.SectorId,
        //                    JornadaId = Tm.JornadaId,
        //                    SegmentoId = Tm.SegmentoId,
        //                    CaracteristicaId = Tm.CaracteristicaId,
        //                    TipoServicioId = Tm.TipoServicioId,
        //                    FechaPedida = Tm.FechaPedida,
        //                    FechaCreated = Tm.FechaCreated,
        //                    UpdateFecha = Tm.UpdateFecha,
        //                    UsuarioSolicitoId = Tm.UsuarioSolicitoId,
        //                    UsuarioSolicitoNombre = SqlContext.Empleados.Where(o=> o.Id == Tm.UsuarioSolicitoId).FirstOrDefault().ApellidoNombre,
        //                    UsuarioConfirmoPedidoId = Tm.UsuarioConfirmoPedidoId,
        //                    Costo = Tm.Costo,
        //                    Margen = Tm.Margen,
        //                    RequerimientoAmbientacion = Tm.RequerimientoAmbientacion,
        //                    DetalleRequerimiento = Tm.DetalleRequerimiento,
        //                    EstadoId = Tm.EstadoId
        //                };


        //    if (empleadoId != null)
        //        query = query.Where(o => o.UsuarioSolicitoId == empleadoId);


        //    List<PedidosCotizacion> Salida = new List<PedidosCotizacion>();
        //    foreach (var item in query)
        //    {

        //        PedidosCotizacion cat = new PedidosCotizacion();

        //        cat.Id = item.Id;
        //        cat.NroRequerimiento = item.NroRequerimiento;
        //        cat.UnidadNegocioId = item.UnidadNegocioId;
        //        cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
        //        cat.LocacionId = item.LocacionId;
        //        cat.LocacionDescripcion = item.LocacionDescripcion;
        //        cat.SectorId = item.SectorId;
        //        cat.JornadaId = item.JornadaId;
        //        cat.SegmentoId = item.SegmentoId;
        //        cat.CaracteristicaId = item.CaracteristicaId;
        //        cat.TipoServicioId = item.TipoServicioId;
        //        cat.FechaPedida = item.FechaPedida;
        //        cat.FechaCreated = item.FechaCreated;
        //        cat.UpdateFecha = item.UpdateFecha;
        //        cat.UsuarioSolicitoId = item.UsuarioSolicitoId;
        //        cat.UsuarioSolicitoNombre = item.UsuarioSolicitoNombre;
        //        cat.UsuarioConfirmoPedidoId = item.UsuarioConfirmoPedidoId;
        //        cat.Costo = item.Costo;
        //        cat.Margen = item.Margen;
        //        cat.RequerimientoAmbientacion = item.RequerimientoAmbientacion;
        //        cat.DetalleRequerimiento = item.DetalleRequerimiento;
        //        cat.EstadoId = item.EstadoId;


        //        Salida.Add(cat);
        //    }

        //    return Salida.ToList();

        //}

        //public virtual PedidosCotizacion BuscarPedidoCotizacion(int id)
        //{
        //    return SqlContext.PedidosCotizacion.Where(o => o.Id == id).FirstOrDefault();
        //}

        //public void GrabarPedidosCotizacion(PedidosCotizacion pedidos)
        //{

        //    if (pedidos.Id > 0)
        //    {
        //        PedidosCotizacion edit = BuscarPedidoCotizacion(pedidos.Id);

        //        edit.CaracteristicaId = pedidos.CaracteristicaId;
        //        edit.Costo = pedidos.Costo;
        //        edit.EstadoId = pedidos.EstadoId;
        //        edit.FechaPedida = pedidos.FechaPedida;
        //        edit.JornadaId = pedidos.JornadaId;
        //        edit.LocacionId = pedidos.LocacionId;
        //        edit.SectorId = pedidos.SectorId;
        //        edit.SegmentoId = pedidos.SegmentoId;
        //        edit.TipoServicioId = pedidos.TipoServicioId;
        //        edit.UnidadNegocioId = edit.UnidadNegocioId;
        //        edit.UsuarioConfirmoPedidoId = edit.UsuarioConfirmoPedidoId;
        //        edit.UsuarioSolicitoId = edit.UsuarioSolicitoId;
        //        edit.CantidadInvitados = edit.CantidadInvitados;

        //        edit.UpdateFecha = System.DateTime.Now;

        //        SqlContext.SaveChanges();
        //    }
        //    else
        //    {
        //        pedidos.FechaCreated = System.DateTime.Now;


        //        SqlContext.PedidosCotizacion.Add(pedidos);
        //        SqlContext.SaveChanges();


        //        pedidos.NroRequerimiento = "R" + pedidos.Id.ToString().PadLeft(6, '0');

        //        SqlContext.SaveChanges();
        //    }

        //}
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class PedidosCotizacion
    {

        public string UnidadNegocioDescripcion { get; set; }

        public string LocacionDescripcion { get; set; }

        public string UsuarioSolicitoNombre { get; set; }

    }
}