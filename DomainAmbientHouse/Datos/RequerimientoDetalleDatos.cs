using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class RequerimientoDetalleDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public RequerimientoDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<INVENTARIO_Requerimiento_Detalle> ListarRequerimientoDetalle()
        {

            var query = from p in SqlContext.INVENTARIO_Requerimiento_Detalle
                        where p.Delete == false
                        select p;

            return InventarioRequerimientoDetalleToModel(query).OrderBy(o => o.CreateFecha).ToList();

        }

        public virtual List<INVENTARIO_Requerimiento_Detalle> ListarRequerimientoDetalle(int requerimientoId)
        {

            var query = from p in SqlContext.INVENTARIO_Requerimiento_Detalle
                        where p.RequerimientoId == requerimientoId && p.Delete == false
                        select p;

            return InventarioRequerimientoDetalleToModel(query).OrderBy(o => o.CreateFecha).ToList();

        }

        private List<INVENTARIO_Requerimiento_Detalle> InventarioRequerimientoDetalleToModel(IQueryable<INVENTARIO_Requerimiento_Detalle> query)
        {
            List<INVENTARIO_Requerimiento_Detalle> list = new List<INVENTARIO_Requerimiento_Detalle>();

            foreach (var item in query)
            {
                INVENTARIO_Requerimiento_Detalle salida = new INVENTARIO_Requerimiento_Detalle();

                salida.Id = item.Id;
                salida.RequerimientoId = item.RequerimientoId;
                salida.UnidadId = item.UnidadId;
                salida.UnidadDescripcion = SqlContext.INVENTARIO_Unidades.Where(o => o.Id == item.UnidadId).FirstOrDefault().DescripcionCorta;
                salida.ProductoId = item.ProductoId;
                salida.ProductoDescripcion = SqlContext.INVENTARIO_Producto.Where(o => o.Id == item.ProductoId).FirstOrDefault().Descripcion;
                salida.Cantidad = item.Cantidad;
                salida.CreateFecha = item.CreateFecha;
                salida.Delete = item.Delete;
                salida.DeleteFecha = item.DeleteFecha;
                salida.UpdateFecha = item.UpdateFecha;

                list.Add(salida);
            }

            return list;
        }

        public bool GrabarRequerimientoDetalle(INVENTARIO_Requerimiento_Detalle requerimiento)
        {
            try
            {

                if (requerimiento.Id > 0)
                {
                    INVENTARIO_Requerimiento_Detalle edit = SqlContext.INVENTARIO_Requerimiento_Detalle.Where(o => o.Id == requerimiento.Id).SingleOrDefault();

                    edit.ProductoId = requerimiento.ProductoId;
                    edit.UnidadId = requerimiento.UnidadId;
                    edit.Cantidad = requerimiento.Cantidad;

                    edit.UpdateFecha = System.DateTime.Now;


                    SqlContext.SaveChanges();

                    return true;
                }
                else
                {
                    requerimiento.CreateFecha = System.DateTime.Now;

                    SqlContext.INVENTARIO_Requerimiento_Detalle.Add(requerimiento);
                    SqlContext.SaveChanges();

                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }

        public INVENTARIO_Requerimiento_Detalle BuscarRequerimientoDetalle(int id)
        {
            var query = from r in SqlContext.INVENTARIO_Requerimiento_Detalle
                        where r.Id == id
                        select r;

            return this.InventarioRequerimientoDetalleToModel(query).FirstOrDefault();

        }

        public bool ElimnarRequerimientoDetalle(int id)
        {
            if (id > 0)
            {
                INVENTARIO_Requerimiento_Detalle edit = BuscarRequerimientoDetalle(id);

                if (edit != null)
                {

                    edit.Delete = true;
                    edit.DeleteFecha = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

    }
}

namespace DomainAmbientHouse.Entidades
{

    public partial class INVENTARIO_Requerimiento_Detalle
    {
        public string ProductoDescripcion { get; set; }

        public string UnidadDescripcion { get; set; }

    }

}
