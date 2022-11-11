using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Domain.Datos
{
    public class PresupuestosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public PresupuestosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public Presupuestos Get(int Id)
        {
            return SqlContext.Presupuestos.Where(o => o.Id == Id).Single();
        }

        public List<Presupuestos> List(PresupuestosSearcher searcher)
        {
            var query = from p in SqlContext.Presupuestos
                        select p;


            if (searcher.NroEvento > 0)
                query = query.Where(o => o.EventoId == searcher.NroEvento);

            if (searcher.NroPresupuesto > 0)
                query = query.Where(o => o.Id == searcher.NroPresupuesto);

            if (searcher.EstadoId > 0)
                query = query.Where(o => o.EstadoId == searcher.EstadoId);



            return query.ToList();
        }
    }
}

namespace Domain.Entidades
{
    public partial class PresupuestosSearcher
    {
        public int NroPresupuesto { get; set; }
        public DateTime FechaEvento { get; set; }
        public int NroEvento { get; set; }
        public int EstadoId { get; set; }

    }

    public partial class Presupuestos
    {
        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaEventoStr
        {
            get
            {
                return String.Format(formatoFecha, FechaEvento);
            }
            set
            {
                FechaEvento = DateTime.ParseExact(FechaEventoStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string FechaPresupuestoStr
        {
            get
            {
                return String.Format(formatoFecha, FechaPresupuesto);
            }
            set
            {
                FechaPresupuesto = DateTime.ParseExact(FechaPresupuestoStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

    }
}
