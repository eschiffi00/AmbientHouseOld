using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class ConceptosLogisticaDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ConceptosLogisticaDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoLogistica> ObtenerTipoLogistica()
        {

            return SqlContext.TipoLogistica.ToList();

        }


        public TipoLogistica BuscarTipoLogistica(long id)
        {
            return SqlContext.TipoLogistica.Where(o => o.Id == id).FirstOrDefault();

        }

        public void NuevoTipoLogistica(TipoLogistica tipoLogistica)
        {
            if (tipoLogistica.Id > 0)
            {

                TipoLogistica catTipoLog = SqlContext.TipoLogistica.Where(o => o.Id == tipoLogistica.Id).First();

                catTipoLog.Concepto = tipoLogistica.Concepto;



                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.TipoLogistica.Add(tipoLogistica);
                SqlContext.SaveChanges();
            }
        }
    }
}
