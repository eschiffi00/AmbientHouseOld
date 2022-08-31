using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
