using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class EstadosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public EstadosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Estados> BuscarEstadosPorEntidad(string entidad)
        {

            return SqlContext.Estados.Where(o=> o.Entidad.Contains(entidad)).ToList();

        }

        public virtual List<Estados> BuscarEstadosPorEntidadParaSeguimientos(string entidad)
        {
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());
            int estadoPresupuestoRechazado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoRechazado"].ToString());
            int estadoEnviadoAlCliente = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());

            //int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            //int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            //int estadoPerdido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());

            return SqlContext.Estados.Where(o => o.Entidad.Contains(entidad) &&
                            (o.Id == estadoPresupuestoAprobado || o.Id == estadoPresupuestoRechazado || o.Id == estadoEnviadoAlCliente)).ToList();

        }


        public Estados BuscarEstado(int Id)
        {
            return SqlContext.Estados.Where(o => o.Id == Id).FirstOrDefault();
        }
    }
}
