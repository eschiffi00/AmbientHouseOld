
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class TABLARetencionesNegocios
    {

        TABLARetencionesDatos Datos;

        public TABLARetencionesNegocios()
        {
            Datos = new TABLARetencionesDatos();

        }

        public virtual List<TABLA_Retenciones> ObtenerTABLA_Retenciones()
        {
            return Datos.ObtenerTABLA_Retenciones();
        }
    }

}
