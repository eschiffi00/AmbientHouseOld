using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class TipoComprobantesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoComprobantesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoComprobantes> ObtenerTipoComprobantes()
        {

            return SqlContext.TipoComprobantes.ToList();

        }


        public TipoComprobantes BuscarTipoComprobantes(int id)
        {
            return SqlContext.TipoComprobantes.Where(o => o.Id == id).First();
        }

        public void NuevoTipoComprobantes(TipoComprobantes item)
        {

            if (item.Id > 0)
            {

                TipoComprobantes itemEdit = SqlContext.TipoComprobantes.Where(o => o.Id == item.Id).First();

                itemEdit.Descripcion = item.Descripcion;

                SqlContext.SaveChanges();
            }
            else
            {


                SqlContext.TipoComprobantes.Add(item);
                SqlContext.SaveChanges();


            }
        }



        public void NuevoTipoComprobanteImpuesto(Impuestos item, int tipoComprobanteId)
        {
            TipoComprobante_Impuestos tcI = new TipoComprobante_Impuestos();

            tcI.ImpuestoId = item.Id;
            tcI.TipoComprobanteId = tipoComprobanteId;

            SqlContext.TipoComprobante_Impuestos.Add(tcI);
            SqlContext.SaveChanges();
        }

        public void EliminarImpuestoTipoComprobante(int tipoComprobanteId)
        {
            List<TipoComprobante_Impuestos> tipoComprobanteImpuestos = SqlContext.TipoComprobante_Impuestos.Where(o => o.TipoComprobanteId == tipoComprobanteId).ToList();

            foreach (var item in tipoComprobanteImpuestos)
            {
                SqlContext.TipoComprobante_Impuestos.Remove(item);
            }
            SqlContext.SaveChanges();

        }

        internal List<TipoComprobantes> BuscarTipoComprobantesPorTipoProveedor(int? condicionIvaId)
        {
            if (condicionIvaId != null)
            {
                List<TipoComprobantes> listar = SqlContext.TipoComprobantes.Where(o => o.CondicionIvaId == condicionIvaId).ToList();

                if (listar.Count > 0)
                {
                    return listar.ToList();
                }
            }
            return SqlContext.TipoComprobantes.ToList();

        }
    }
}
