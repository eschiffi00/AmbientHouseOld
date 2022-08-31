using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class TransferenciasNegocios
    {

        TransferenciasDatos Datos;

        public TransferenciasNegocios()
        {
            Datos = new TransferenciasDatos();
        }



        public Transferencias BuscarTransferencia(string filtro)
        {
            return Datos.BuscarTransferencia(filtro);
        }

        internal Transferencias BuscarTransferenciaPorNroComprobante(string nroComprobante)
        {
            return Datos.BuscarTransferenciaPorNroComprobante(nroComprobante);
        }

        internal List<Transferencias> ObtenerTransferencias()
        {
            return Datos.ObtenerTransferencias();
        }

        internal List<Transferencias> ListarTransferencias(TransferenciasSearcher searcher)
        {
            return Datos.ListarTransferencias(searcher);
        }

        internal Transferencias BuscarTransferencia(int id)
        {
            return Datos.BuscarTransferencia(id);
        }

        internal void GrabarTransferencia(Transferencias tm)
        {
            Datos.GrabarTransferencias(tm);
        }
    }
}
