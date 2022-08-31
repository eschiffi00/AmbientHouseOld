using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ImpuestosNegocios
    {

        ImpuestosDatos Datos;

        public ImpuestosNegocios()
        {
            Datos = new ImpuestosDatos();
        }

        public virtual List<Impuestos> ObtenerImpuestos()
        {

            return Datos.ObtenerImpuestos();

        }


        public Impuestos BuscarImpuestos(int id)
        {
            return Datos.BuscarImpuestos (id);
        }

        public void NuevoImpuestos(Impuestos item)
        {
            Datos.NuevoImpuestos(item);
        }



        public List<Impuestos> ObtenerImpuestosorTipoComprobante(int tipoComprobanteId)
        {
            return Datos.ObtenerImpuestosorTipoComprobante( tipoComprobanteId);
        }

        public virtual List<Impuestos> BuscarImpuestosPorTipoComprobante(int tipoComprobanteId)
        {
            return Datos.BuscarImpuestosPorTipoComprobante(tipoComprobanteId);
        }
    }
}
