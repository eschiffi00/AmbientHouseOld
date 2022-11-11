using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class RetencionesNegocios
    {

        RetencionesDatos Datos;

        public RetencionesNegocios()
        {
            Datos = new RetencionesDatos();
        }

        public virtual List<Retenciones> ListarRetenciones()
        {

            return Datos.ListarRetenciones();

        }

        public virtual List<Retenciones> BuscarRetencionesPorPagosProveedores(int id)
        {

            return Datos.BuscarRetencionesPorPagosProveedores(id);

        }

        public Retenciones BuscarRetenciones(int id)
        {
            return Datos.BuscarRetenciones(id);
        }

        public bool GrabarRetenciones(Retenciones retenciones)
        {
            return Datos.GrabarRetenciones(retenciones);
        }

        public bool EliminarRetenciones(int id)
        {
            return Datos.ElimnarRetenciones(id);
        }


    }
}
