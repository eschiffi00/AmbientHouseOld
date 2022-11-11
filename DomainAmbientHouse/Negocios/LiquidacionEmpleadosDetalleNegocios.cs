using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class LiquidacionEmpleadosDetalleNegocios
    {

        private LiquidacionEmpleadosDetalleDatos Datos;

        public LiquidacionEmpleadosDetalleNegocios()
        {
            Datos = new LiquidacionEmpleadosDetalleDatos();
        }

        internal LiquidacionHorasPersonal_Detalle BuscarDetalleHoras(int Id)
        {
            return Datos.BuscarDetalleHoras(Id);
        }

        internal bool GrabarLiquidacionHoraDetalle(LiquidacionHorasPersonal_Detalle detalle)
        {
            return Datos.GrabarLiquidacionHoraDetalle(detalle);
        }

        internal List<LiquidacionHorasPersonal_Detalle> ListarLiquidacionPersonalHorasDetalle(int liquidacionId)
        {
            return Datos.ListarLiquidacionPersonalHorasDetalle(liquidacionId);
        }

        internal bool ElimnarLiquidacionHoraDetalle(LiquidacionHorasPersonal_Detalle detalle)
        {
            return Datos.ElimnarLiquidacionPersonalDetalle(detalle.Id);
        }
    }
}
