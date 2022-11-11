using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class NotaCreditosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public NotaCreditosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        private List<NotaCreditos> NotaCreditoToModel(IQueryable<NotaCreditos> query)
        {
            List<NotaCreditos> list = new List<NotaCreditos>();

            foreach (var item in query)
            {
                NotaCreditos salida = new NotaCreditos();

                salida.Id = item.Id;
                salida.Fecha = item.Fecha;
                salida.Importe = item.Importe;
                salida.CreateFecha = item.CreateFecha;



                list.Add(salida);
            }

            return list;
        }

        public List<NotaCreditos> ListarNotasdeCredito(int comprobanteId)
        {
            return SqlContext.NotaCreditos.Where(o => o.ComprobanteProveedorId == comprobanteId).ToList();
        }

        internal NotaCreditos BuscarNotaCredito(int id)
        {
            return SqlContext.NotaCreditos.Single(o => o.Id == id);
        }

        internal void GrabarNotaCredito(NotaCreditos notaCredito)
        {
            if (notaCredito.Id > 0)
            {
                NotaCreditos edit = SqlContext.NotaCreditos.Single(o => o.Id == notaCredito.Id);

                edit.Fecha = notaCredito.Fecha;
                edit.Importe = notaCredito.Importe;
                edit.UpdateFecha = System.DateTime.Now;

                SqlContext.SaveChanges();
            }
            else
            {
                notaCredito.CreateFecha = System.DateTime.Now;

                SqlContext.NotaCreditos.Add(notaCredito);
                SqlContext.SaveChanges();
            }
        }

        internal List<NotaCreditos> ObtenerNotasCreditosPorComprobante(int comprobanteId)
        {
            return SqlContext.NotaCreditos.Where(o => o.ComprobanteProveedorId == comprobanteId).ToList();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class NotaCreditos
    {
        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaStr
        {
            get
            {
                return String.Format(formatoFecha, Fecha);
            }
            set
            {
                Fecha = DateTime.ParseExact(FechaStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }
    }
}