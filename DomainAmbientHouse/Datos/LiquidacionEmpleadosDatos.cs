using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using System.Configuration;
using System.Globalization;

namespace DomainAmbientHouse.Datos
{
    public class LiquidacionEmpleadosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public LiquidacionEmpleadosDatos()
        {
            SqlContext = new AmbientHouseEntities();

        }

        public virtual List<LiquidacionHorasPersonal> ObtenerLiquidacionHoras()
        {

            var query = from c in SqlContext.LiquidacionHorasPersonal
                        select c;



            return LiquidacionEmpleadosToModel(query).ToList();

        }

        private List<LiquidacionHorasPersonal> LiquidacionEmpleadosToModel(IQueryable<LiquidacionHorasPersonal> query)
        {
            List<LiquidacionHorasPersonal> list = new List<LiquidacionHorasPersonal>();

            foreach (var item in query)
            {
                LiquidacionHorasPersonal salida = new LiquidacionHorasPersonal();

                salida.Id = item.Id;
                salida.Descripcion = item.Descripcion;
                salida.PresupuestoId = item.PresupuestoId;
                salida.Fecha = item.Fecha;
                salida.LiquidacionHorasPersonal_Detalle = SqlContext
                                                            .LiquidacionHorasPersonal_Detalle
                                                            .Where(o => o.LiquidacionPersonalHoraId == item.Id && o.Delete != true).ToList();
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Single(o => o.Id == item.EstadoId).Descripcion;
                ;


                list.Add(salida);
            }

            return list;
        }

        public virtual bool GrabarLiquidacionHorasPersonal(LiquidacionHorasPersonal liquidacion)
        {
            try
            {


                if (liquidacion.Id > 0)
                {
                    LiquidacionHorasPersonal edit = SqlContext.LiquidacionHorasPersonal.Where(o => o.Id == liquidacion.Id).FirstOrDefault();

                    edit.Descripcion = liquidacion.Descripcion;
                    edit.Fecha = liquidacion.Fecha;
                    edit.EstadoId = liquidacion.EstadoId;
                    edit.PresupuestoId = liquidacion.PresupuestoId;

                    edit.FechaUpdate = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    liquidacion.FechaCreate = System.DateTime.Now;

                    SqlContext.LiquidacionHorasPersonal.Add(liquidacion);
                    SqlContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public LiquidacionHorasPersonal BuscarLiquidacionPersonal(int id)
        {

            var query = from t in SqlContext.LiquidacionHorasPersonal
                        where t.Id == id
                        select t;


            return LiquidacionEmpleadosToModel(query).SingleOrDefault();

        }

        public bool ElimnarLiquidacionPersonal(int id)
        {
            if (id > 0)
            {
                LiquidacionHorasPersonal edit = BuscarLiquidacionPersonal(id);

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

    

        //public List<Transferencias> ListarTransferencias(TransferenciasSearcher searcher)
        //{
        //    var query = from t in SqlContext.Transferencias
        //                select t;


        //    if (!string.IsNullOrEmpty(searcher.NroTransferencia))
        //        query = query.Where(o => o.NroTransferencia.Contains(searcher.NroTransferencia));

        //    if (!string.IsNullOrEmpty(searcher.FechaTransferencia))
        //    {
        //        DateTime fecha = DateTime.ParseExact(searcher.FechaTransferencia, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        query = query.Where(o => o.FechaTransferencia == fecha);
        //    }

        //    if (!string.IsNullOrEmpty(searcher.Importe))
        //        query = query.Where(o => o.Importe == double.Parse(searcher.Importe));

        //    if (!string.IsNullOrEmpty(searcher.RazonSocial))
        //    {

        //        query = from q in query
        //                join c in SqlContext.ClientesBis on q.ClienteId equals c.Id into CS
        //                from c in CS.DefaultIfEmpty()
        //                join p in SqlContext.Proveedores on q.ProveedorId equals p.Id into PS
        //                from p in PS.DefaultIfEmpty()
        //                where (c.RazonSocial.Contains(searcher.RazonSocial) 
        //                        || c.ApellidoNombre.Contains(searcher.RazonSocial)) 
        //                        || p.RazonSocial.Contains(searcher.RazonSocial)
        //                select q;


        //    }
        //    if (!string.IsNullOrEmpty(searcher.Cuit))
        //    {

        //        query = from q in query
        //                join c in SqlContext.ClientesBis on q.ClienteId equals c.Id into CS
        //                from c in CS.DefaultIfEmpty()
        //                join p in SqlContext.Proveedores on q.ProveedorId equals p.Id into PS
        //                from p in PS.DefaultIfEmpty()
        //                where (c.CUILCUIT.Contains(searcher.Cuit)
        //                        || p.Cuit.Contains(searcher.Cuit))
        //                select q;


        //    }

        //    return TransferenciaToModel(query).ToList();
        //}

    }
}

namespace DomainAmbientHouse.Entidades
{

    public partial class LiquidacionHorasPersonal
    {
        public string EstadoDescripcion { get; set; }
    }

}