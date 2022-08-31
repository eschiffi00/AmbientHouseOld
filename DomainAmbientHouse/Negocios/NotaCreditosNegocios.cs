using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class NotaCreditosNegocios
    {

        NotaCreditosDatos Datos;

        public NotaCreditosNegocios()
        {
            Datos = new NotaCreditosDatos();
        }

        public virtual List<NotaCreditos> ListarNotasdeCredito(int comprobanteId)
        {
            return Datos.ListarNotasdeCredito(comprobanteId);
        }


        internal NotaCreditos BuscarNotaCredito(int id)
        {
            return Datos.BuscarNotaCredito(id);
        }

        internal void GrabarNotaCredito(NotaCreditos notaCredito)
        {
            Datos.GrabarNotaCredito(notaCredito);
        }

        internal List<NotaCreditos> ObtenerNotasCreditosPorComprobante(int comprobanteId)
        {
           return Datos.ObtenerNotasCreditosPorComprobante( comprobanteId);
        }
    }
}
