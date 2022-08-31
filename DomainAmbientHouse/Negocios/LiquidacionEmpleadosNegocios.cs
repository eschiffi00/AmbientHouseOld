using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
