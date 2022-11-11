using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Domain.Datos
{
    public class EventosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public EventosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public Eventos Get(int Id)
        {
            return SqlContext.Eventos.Where(o => o.Id == Id).Single();
        }

        public List<Eventos> List(EventosSearcher eventoSearcher)
        {
            var query = from e in SqlContext.Eventos
                        select e;


            if (eventoSearcher.ClienteId > 0)
                query = query.Where(o => o.ClienteId == eventoSearcher.ClienteId);

            return query.ToList();

        }


    }
}

namespace Domain.Entidades
{
    public partial class EventosSearcher
    {
        public int ClienteId { get; set; }
    }

    public partial class Eventos
    {

        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaSenaStr
        {
            get
            {
                return String.Format(formatoFecha, FechaSena);
            }
            set
            {
                FechaSena = DateTime.ParseExact(FechaSenaStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }


    }
}
