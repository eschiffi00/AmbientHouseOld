using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class OrganizacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public OrganizacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<OrganizacionItems> ObtenerItemsOrganizacion()
        {

            return SqlContext.OrganizacionItems.ToList();

        }

        public virtual OrganizacionItems BuscarItemsOrganizacion(int Id)
        {
            return SqlContext.OrganizacionItems.Where(o => o.Id == Id).SingleOrDefault();

        }

        public virtual void NuevoItemOrganizacion(OrganizacionItems oi)
        {

            if (oi.Id > 0)
            {
                OrganizacionItems edit = BuscarItemsOrganizacion(oi.Id);

                edit.Descripcion = oi.Descripcion;
                edit.RequiereCantidad = oi.RequiereCantidad;

                SqlContext.SaveChanges();
            
            }
            else
            {
                SqlContext.OrganizacionItems.Add(oi);
                SqlContext.SaveChanges();
            }
        }


        internal List<OrganizacionPresupuestoDetalle> ListarEventosFechaEnvioMailPresentacion()
        {
            if (SqlContext.EjecucionTareasProgramadas.Where(o => o.FechaEjecucion == System.DateTime.Today).Count() == 0)
            {
                return SqlContext.OrganizacionPresupuestoDetalle.Where(o => o.FechaMailPresentacion == System.DateTime.Today && o.EnvioMailPresentacion == "No").ToList();
            }
            else
                return new List<OrganizacionPresupuestoDetalle>();
           
        }
    }
}
