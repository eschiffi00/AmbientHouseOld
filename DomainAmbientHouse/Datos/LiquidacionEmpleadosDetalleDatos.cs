using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class LiquidacionEmpleadosDetalleDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public LiquidacionEmpleadosDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();

        }

        private List<LiquidacionHorasPersonal_Detalle> LiquidacionEmpleadosDetalleToModel(IQueryable<LiquidacionHorasPersonal_Detalle> query)
        {
            List<LiquidacionHorasPersonal_Detalle> list = new List<LiquidacionHorasPersonal_Detalle>();

            foreach (var item in query)
            {
                LiquidacionHorasPersonal_Detalle salida = new LiquidacionHorasPersonal_Detalle();

                salida.Id = item.Id;
                salida.EmpleadoId = item.EmpleadoId;
                salida.HoraEntrada = item.HoraEntrada;
                salida.HoraSalida = item.HoraSalida;
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Single(o => o.Id == item.EstadoId).Descripcion;
                salida.TipoPagoId = item.TipoPagoId;
                salida.TipoPagoDescripcion = SqlContext.TipoPagoEmpleados.Single(o => o.Id == item.TipoPagoId).Descripcion;
                salida.Valor = item.Valor;


                list.Add(salida);
            }

            return list;
        }

        public LiquidacionHorasPersonal_Detalle BuscarLiquidacionPersonalDetalle(int id)
        {

            var query = from t in SqlContext.LiquidacionHorasPersonal_Detalle
                        where t.Id == id
                        select t;


            return LiquidacionEmpleadosDetalleToModel(query).SingleOrDefault();

        }

        public bool ElimnarLiquidacionPersonalDetalle(int id)
        {
            if (id > 0)
            {
                LiquidacionHorasPersonal_Detalle edit = SqlContext.LiquidacionHorasPersonal_Detalle.Single(o => o.Id == id);

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

        public bool GrabarLiquidacionEmpleados_Detalle(LiquidacionHorasPersonal_Detalle detalle)
        {
            try
            {
                if (detalle.Id > 0)
                {
                    LiquidacionHorasPersonal_Detalle edit = SqlContext.LiquidacionHorasPersonal_Detalle.Single(o => o.Id == detalle.Id);

                    edit.EmpleadoId = detalle.EmpleadoId;
                    edit.HoraEntrada = detalle.HoraEntrada;
                    edit.HoraSalida = detalle.HoraSalida;
                    edit.LiquidacionPersonalHoraId = detalle.LiquidacionPersonalHoraId;
                    edit.TipoPagoId = detalle.TipoPagoId;
                    edit.Valor = detalle.Valor;
                    edit.EstadoId = detalle.EstadoId;

                    edit.FechaUpdate = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    detalle.FechaCreate = System.DateTime.Now;

                    SqlContext.LiquidacionHorasPersonal_Detalle.Add(detalle);
                    SqlContext.SaveChanges();

                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        internal LiquidacionHorasPersonal_Detalle BuscarDetalleHoras(int Id)
        {
            return SqlContext.LiquidacionHorasPersonal_Detalle.Single(o => o.Id == Id);
        }

        internal bool GrabarLiquidacionHoraDetalle(LiquidacionHorasPersonal_Detalle detalle)
        {
            try
            {


                if (detalle.Id > 0)
                {
                    LiquidacionHorasPersonal_Detalle edit = SqlContext.LiquidacionHorasPersonal_Detalle.Single(o => o.Id == detalle.Id);

                    edit.EmpleadoId = detalle.EmpleadoId;
                    edit.EstadoId = detalle.EstadoId;
                    edit.HoraEntrada = detalle.HoraEntrada;
                    edit.HoraSalida = detalle.HoraSalida;
                    edit.SectorEmpresaId = detalle.SectorEmpresaId;
                    edit.TipoEmpleadoId = detalle.TipoEmpleadoId;
                    edit.TipoPagoId = detalle.TipoPagoId;
                    edit.Valor = detalle.Valor;
                    edit.FechaUpdate = System.DateTime.Now;

                    SqlContext.SaveChanges();
                    return true;

                }
                else
                {
                    detalle.FechaCreate = System.DateTime.Now;

                    SqlContext.LiquidacionHorasPersonal_Detalle.Add(detalle);
                    SqlContext.SaveChanges();
                    return true;

                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        internal List<LiquidacionHorasPersonal_Detalle> ListarLiquidacionPersonalHorasDetalle(int liquidacionId)
        {
            return SqlContext.LiquidacionHorasPersonal_Detalle.Where(o => o.LiquidacionPersonalHoraId == liquidacionId).ToList();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{

    public partial class LiquidacionHorasPersonal_Detalle
    {
        public string EstadoDescripcion { get; set; }
        public string TipoPagoDescripcion { get; set; }
    }

}