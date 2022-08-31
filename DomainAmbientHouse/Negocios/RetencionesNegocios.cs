using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
