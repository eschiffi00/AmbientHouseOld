using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class PedidoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public PedidoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<INVENTARIO_Pedido> ListarPedidos(int estado)
        {

            var query = from p in SqlContext.INVENTARIO_Pedido
                        where p.Delete == false && p.EstadoId == estado
                        select p;

            return InventarioPedidoToModel(query).OrderBy(o => o.CreateFecha).ToList();

        }

        private List<INVENTARIO_Pedido> InventarioPedidoToModel(IQueryable<INVENTARIO_Pedido> query)
        {


            List<INVENTARIO_Pedido> list = new List<INVENTARIO_Pedido>();

            foreach (var item in query)
            {
                INVENTARIO_Pedido salida = new INVENTARIO_Pedido();

                salida.Id = item.Id;
                salida.ProveedorId = item.ProveedorId;
                salida.RazonSocialProveedor = SqlContext.Proveedores.Where(o => o.Id == item.ProveedorId).FirstOrDefault().RazonSocial;
                salida.Fecha = item.Fecha;
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Where(o => o.Id == item.EstadoId).FirstOrDefault().Descripcion;
                salida.CreateFecha = item.CreateFecha;
                salida.Delete = item.Delete;
                salida.DeleteFecha = item.DeleteFecha;
                salida.UpdateFecha = item.UpdateFecha;

                salida.INVENTARIO_Requerimiento_Detalle = SqlContext.INVENTARIO_Requerimiento_Detalle.Where(o => o.PedidoId == item.Id).ToList();
              
                list.Add(salida);
            }

            return list;
        }

        public bool GrabarPedido(INVENTARIO_Pedido pedido)
        {
            try
            {

                if (pedido.Id > 0)
                {
                    INVENTARIO_Pedido edit = SqlContext.INVENTARIO_Pedido.Where(o => o.Id == pedido.Id).SingleOrDefault();

                    edit.ProveedorId = pedido.ProveedorId;
                    edit.EstadoId = pedido.EstadoId;
                    edit.Fecha = pedido.Fecha;
                    edit.UpdateFecha = System.DateTime.Now;


                    SqlContext.SaveChanges();

                    return true;
                }
                else
                {
                    pedido.CreateFecha = System.DateTime.Now;

                    SqlContext.INVENTARIO_Pedido.Add(pedido);
                    SqlContext.SaveChanges();

                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }

        public INVENTARIO_Pedido BuscarPedido(int id)
        {
            var query = from r in SqlContext.INVENTARIO_Pedido
                        where r.Id == id
                        select r;

            return this.InventarioPedidoToModel(query).FirstOrDefault();

        }

        public bool ElimnarPedido(int id)
        {
            if (id > 0)
            {
                INVENTARIO_Pedido edit = BuscarPedido(id);

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

    public partial class INVENTARIO_Pedido
    {
        public string EstadoDescripcion { get; set; }

        public string RazonSocialProveedor { get; set; }
    }

}




