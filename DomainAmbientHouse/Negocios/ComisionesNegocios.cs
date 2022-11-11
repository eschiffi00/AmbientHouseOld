using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class ComisionesNegocios
    {

        ComisionesDatos Datos;

        public ComisionesNegocios()
        {
            Datos = new ComisionesDatos();
        }

        public virtual List<Comisiones> ObtenerComisiones()
        {

            return Datos.ObtenerComisiones();

        }

        public Comisiones BuscarComisiones(int id)
        {
            return Datos.BuscarComisiones(id);
        }

        public void NuevaComisiones(Comisiones comisiones)
        {
            Datos.NuevaComisiones(comisiones);
        }

        public Comisiones BuscarComisiones(string descripcion)
        {
            return Datos.BuscarComisiones(descripcion);
        }

        public Comisiones BuscarComisionPorUnidadNegocioPrecioSeleccionado(int UnidadNegocioParaAdicional, string PrecioParaAdicional)
        {
            return Datos.BuscarComisionPorUnidadNegocioPrecioSeleccionado(UnidadNegocioParaAdicional, PrecioParaAdicional);
        }
    }
}
