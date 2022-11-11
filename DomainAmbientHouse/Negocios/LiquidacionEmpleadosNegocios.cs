using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class LiquidacionEmpleadosNegocios
    {
        LiquidacionEmpleadosDatos Datos;

        public LiquidacionEmpleadosNegocios()
        {
            Datos = new LiquidacionEmpleadosDatos();

        }

        public List<LiquidacionHorasPersonal> ObtenerLiquidacionHoras()
        {
            return Datos.ObtenerLiquidacionHoras();
        }

        public LiquidacionHorasPersonal BuscarLiquidacionPersonal(int id)
        {
            return Datos.BuscarLiquidacionPersonal(id);
        }

        public bool GrabarLiquidacionPersonal(LiquidacionHorasPersonal liquidacion)
        {
            return Datos.GrabarLiquidacionHorasPersonal(liquidacion);
        }

        internal bool GrabarLiquidacionHoras(LiquidacionHorasPersonal liquidacion)
        {
            return Datos.GrabarLiquidacionHorasPersonal(liquidacion);
        }
    }
}
