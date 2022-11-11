using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class RecibosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public RecibosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public List<Recibos> ObtenerRecibos()
        {
            var query = from c in SqlContext.Recibos
                        select c;

            return RecibosToModel(query).ToList();

        }

        private List<Recibos> RecibosToModel(IQueryable<Recibos> query)
        {
            List<Recibos> list = new List<Recibos>();

            foreach (var item in query)
            {
                Recibos salida = new Recibos();

                salida.Id = item.Id;
                salida.FechaRecibo = item.FechaRecibo;
                salida.NroRecibo = item.NroRecibo;
                salida.Concepto = item.Concepto;
                salida.FormadePagoId = item.FormadePagoId;
                salida.FormadePagoDescripcion = SqlContext.FormasdePago.Where(o => o.Id == item.FormadePagoId).SingleOrDefault().Descripcion;


                list.Add(salida);
            }

            return list;
        }

        public virtual bool GrabarRecibos(Recibos recibo)
        {

            try
            {
                if (recibo.Id > 0)
                {
                    Recibos edit = SqlContext.Recibos.Where(o => o.Id == recibo.Id).FirstOrDefault();

                    edit.NroRecibo = recibo.NroRecibo;
                    edit.FechaRecibo = recibo.FechaRecibo;
                    edit.FormadePagoId = recibo.FormadePagoId;
                    edit.Concepto = recibo.Concepto;

                    edit.FechaUpdate = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    recibo.FechaCreate = System.DateTime.Now;

                    SqlContext.Recibos.Add(recibo);
                    SqlContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Recibos BuscarRecibo(int id)
        {
            return SqlContext.Recibos.Where(o => o.Id == id).SingleOrDefault();
        }

        public bool ElimnarRecibo(int id)
        {
            if (id > 0)
            {
                Recibos edit = BuscarRecibo(id);

                if (edit != null)
                {

                    edit.Delete = true;
                    edit.FechaDelete = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

        public List<Recibos> BuscarRecibos(RecibosSearcher searcher)
        {
            var query = from c in SqlContext.Recibos
                        select c;

            return RecibosToModel(query).ToList();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{

    public partial class Recibos
    {

        public string FormadePagoDescripcion { get; set; }
        public int EmpleadoId { get; set; }
        public int CuentaId { get; set; }

    }

    public partial class RecibosSearcher
    {
        public string NroRecibo { get; set; }
    }

}
