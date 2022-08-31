using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ImpuestosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ImpuestosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Impuestos> ObtenerImpuestos()
        {

            return SqlContext.Impuestos.ToList();

        }


        public Impuestos BuscarImpuestos(int id)
        {
            return SqlContext.Impuestos.Where(o => o.Id == id).First();
        }

        public void NuevoImpuestos(Impuestos item)
        {

            if (item.Id > 0)
            {

                Impuestos itemEdit = SqlContext.Impuestos.Where(o => o.Id == item.Id).First();

               
                itemEdit.Descripcion = item.Descripcion;
                itemEdit.Porcentaje = item.Porcentaje;
               
               

                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Impuestos.Add(item);
                SqlContext.SaveChanges();
            }
        }



        public List<Impuestos> ObtenerImpuestosorTipoComprobante(int tipoComprobanteId)
        {
            var query = from I in SqlContext.Impuestos
                        join tcI in SqlContext.TipoComprobante_Impuestos on I.Id equals tcI.ImpuestoId
                        where tcI.TipoComprobanteId == tipoComprobanteId
                        select I;


            return query.ToList();
        }

        public virtual List<Impuestos> BuscarImpuestosPorTipoComprobante(int tipoComprobanteId)
        {
            var query = from Tci in SqlContext.TipoComprobante_Impuestos
                        join Tc in SqlContext.TipoComprobantes on Tci.TipoComprobanteId equals Tc.Id
                        join I in SqlContext.Impuestos on Tci.ImpuestoId equals I.Id
                        where Tci.TipoComprobanteId == tipoComprobanteId
                        select I;

            return query.ToList();
        }
    }
}
