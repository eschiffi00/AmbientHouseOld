using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class TiempoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TiempoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }
        
        public virtual List<Tiempos> ObtenerTiempos()
        {

            return SqlContext.Tiempos.OrderBy(o=>o.Orden).ToList();

        }


        public Tiempos BuscarTiempo(int id)
        {
            return SqlContext.Tiempos.Where(o=> o.Id == id).SingleOrDefault();
        }

        public void NuevoTiempo(Tiempos tiempo)
        {
            if (tiempo.Id > 0)
            {
                Tiempos editTiempo = SqlContext.Tiempos.Where(o => o.Id == tiempo.Id).SingleOrDefault();

                editTiempo.Descripcion = tiempo.Descripcion;
                editTiempo.Orden = tiempo.Orden;

                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.Tiempos.Add(tiempo);
                    SqlContext.SaveChanges();

            }

        }

        public List<Tiempos> ObtenerTiemposPorTipoCatering(int TipoCateringId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString()); ;

            var query = from T in SqlContext.Tiempos
                        join C in SqlContext.TipoCateringTiempoProductoItem on T.Id equals C.TiempoId
                        where C.TipoCateringId == TipoCateringId && C.EstadoId == activo
                        select T;

            return query.OrderBy(o=> o.Orden).Distinct().ToList();
        }
    }
}
