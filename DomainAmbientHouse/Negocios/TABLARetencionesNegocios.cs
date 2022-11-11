using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
