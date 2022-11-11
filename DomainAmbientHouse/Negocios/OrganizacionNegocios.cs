using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class OrganizacionNegocios
    {

        OrganizacionDatos Datos;

        public OrganizacionNegocios()
        {
            Datos = new OrganizacionDatos();
        }

        public virtual List<OrganizacionItems> ObtenerItemsOrganizacion()
        {

            return Datos.ObtenerItemsOrganizacion();

        }

        public virtual OrganizacionItems BuscarItemsOrganizacion(int Id)
        {

            return Datos.BuscarItemsOrganizacion(Id);

        }

        public virtual void NuevoItemOrganizacion(OrganizacionItems oi)
        {

            Datos.NuevoItemOrganizacion(oi);

        }


        public List<OrganizacionPresupuestoDetalle> ListarEventosFechaEnvioMailPresentacion()
        {
            return Datos.ListarEventosFechaEnvioMailPresentacion();
        }
    }
}
