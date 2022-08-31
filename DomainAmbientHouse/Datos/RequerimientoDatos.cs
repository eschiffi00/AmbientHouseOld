using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class RequerimientoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public RequerimientoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<INVENTARIO_Requerimiento> ListarRequerimiento()
        {

            var query = from p in SqlContext.INVENTARIO_Requerimiento
                        where p.Delete == false
                        select p;

            return InventarioRequerimientoToModel(query).OrderBy(o => o.CreateFecha).ToList();

        }

        private List<INVENTARIO_Requerimiento> InventarioRequerimientoToModel(IQueryable<INVENTARIO_Requerimiento> query)
        {


            List<INVENTARIO_Requerimiento> list = new List<INVENTARIO_Requerimiento>();

            foreach (var item in query)
            {
                INVENTARIO_Requerimiento salida = new INVENTARIO_Requerimiento();

                salida.Id = item.Id;
                salida.Detalle = item.Detalle;
                salida.Fecha = item.Fecha;
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Where(o => o.Id == item.EstadoId).FirstOrDefault().Descripcion;
                salida.CreateFecha = item.CreateFecha;
                salida.Delete = item.Delete;
                salida.DeleteFecha = item.DeleteFecha;
                salida.UpdateFecha = item.UpdateFecha;

                salida.INVENTARIO_Requerimiento_Detalle = SqlContext.INVENTARIO_Requerimiento_Detalle.Where(o => o.RequerimientoId == item.Id).ToList();
              
                list.Add(salida);
            }

            return list;
        }

        public bool GrabarRequerimiento(INVENTARIO_Requerimiento requerimiento)
        {
            try
            {

                if (requerimiento.Id > 0)
                {
                    INVENTARIO_Requerimiento edit = SqlContext.INVENTARIO_Requerimiento.Where(o => o.Id == requerimiento.Id).SingleOrDefault();

                    edit.Detalle = requerimiento.Detalle;
                    edit.EstadoId = requerimiento.EstadoId;
                    edit.Fecha = requerimiento.Fecha;
                    edit.UpdateFecha = System.DateTime.Now;


                    SqlContext.SaveChanges();

                    return true;
                }
                else
                {
                    requerimiento.CreateFecha = System.DateTime.Now;

                    SqlContext.INVENTARIO_Requerimiento.Add(requerimiento);
                    SqlContext.SaveChanges();

                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }

        public INVENTARIO_Requerimiento BuscarRequerimiento(int id)
        {
            var query = from r in SqlContext.INVENTARIO_Requerimiento
                        where r.Id == id
                        select r;

            return this.InventarioRequerimientoToModel(query).FirstOrDefault();

        }

        public bool ElimnarRequerimiento(int id)
        {
            if (id > 0)
            {
                INVENTARIO_Requerimiento edit = BuscarRequerimiento(id);

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

    public partial class INVENTARIO_Requerimiento
    {
        public string EstadoDescripcion { get; set; }
    }

}




