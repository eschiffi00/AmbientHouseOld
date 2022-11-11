using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class ProcesoCierreNegocios
    {

        ProcesoCierreDatos Datos;

        public ProcesoCierreNegocios()
        {
            Datos = new ProcesoCierreDatos();
        }

        public virtual List<ProcesoCierre> ObtenerProcesoCierre()
        {

            return Datos.ObtenerProcesoCierre();

        }

    }
}
