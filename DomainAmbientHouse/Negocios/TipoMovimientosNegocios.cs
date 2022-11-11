using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class TipoMovimientosNegocios
    {

        TipoMovimientosDatos Datos;

        public TipoMovimientosNegocios()
        {
            Datos = new TipoMovimientosDatos();
        }

        public virtual List<TipoMovimientos> ObtenerTipoMovimientos()
        {

            return Datos.ObtenerTipoMovimientos();

        }

        public TipoMovimientos BuscarTipoMovimiento(int id)
        {
            return Datos.BuscarTipoMovimiento(id);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosTodos(DomainAmbientHouse.Entidades.TipoMovimientoSearcher searcher)
        {
            return Datos.ObtenerTipoMovimientosTodos(searcher);
        }

        public List<TipoMovimientos> ObtenerTipoMovimientosPadres()
        {
            return Datos.ObtenerTipoMovimientosPadres();
        }

        public bool GrabarTipoMovimientos(TipoMovimientos tipoMovimiento)
        {
            return Datos.GrabarTipoMovimientos(tipoMovimiento);
        }

        internal List<TipoMovimientos> ObtenerTipoMovimientosParaRecibosIngresos()
        {
            return Datos.ObtenerTipoMovimientosParaRecibosIngresos();
        }

        internal List<TipoMovimientos> ObtenerTipoMovimientosPorPadre(string padreId)
        {
            return Datos.ObtenerTipoMovimientosPorPadre(padreId);
        }

        internal List<TipoMovimientos> ObtenerTipoMovimientosEgresos()
        {
            return Datos.ObtenerTipoMovimientosEgresos();
        }

        internal List<TipoMovimientos> ObtenerTipoMovimientosEgresosyAjuste()
        {
            return Datos.ObtenerTipoMovimientosEgresosyAjuste();
        }
    }
}
