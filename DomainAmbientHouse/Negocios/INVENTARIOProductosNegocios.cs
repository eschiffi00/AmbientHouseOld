using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class INVENTARIOProductosNegocios
    {

        INVENTARIOProductosDatos Datos;

        public INVENTARIOProductosNegocios()
        {
            Datos = new INVENTARIOProductosDatos();
        }

        public virtual List<INVENTARIO_Producto> ListarProductos()
        {

            return Datos.ListarProductos();

        }

        internal INVENTARIO_Producto BuscarINVENTARIOProducto(int Id)
        {
            return Datos.BuscarINVENTARIOProducto(Id);
        }

        internal void ActualizarProductos(INVENTARIO_Producto producto)
        {
            Datos.ActualizarProductos(producto);
        }

        internal List<INVENTARIO_Producto> ListarINVENTARIOProductoPorRubro(int RubroId)
        {
            return Datos.ListarINVENTARIOProductoPorRubro(RubroId);
        }
        internal List<INVENTARIO_Producto> BuscarINVENTARIOProductoPorProducto(string descripcion)
        {
            return Datos.BuscarINVENTARIOProductoPorProducto(descripcion);
        }

        internal INVENTARIO_Producto BuscarINVENTARIOProductoPorCodigoBarra(string codigoBarra)
        {
            return Datos.BuscarINVENTARIOProductoPorCodigoBarra(codigoBarra);
        }


        public List<Existencias> ListarExistencias(string descripcionProducto, string codigoProducto, int depositoId, int rubroId)
        {
            return Datos.ListarExistencias( descripcionProducto,codigoProducto,  depositoId,  rubroId);
        }



        internal Existencias BuscarExistencias(int productoId, int depositoId)
        {
            return Datos.BuscarExistencias( productoId,  depositoId);
        }

        internal bool GuardarExistencia(Existencias existencia)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    INVENTARIO_ProductoDeposito depositoProducto = new INVENTARIO_ProductoDeposito();

                    depositoProducto.DepositoId = existencia.DepositoId;
                    depositoProducto.ProductoId = existencia.ProductoId;
                    depositoProducto.Cantidad = existencia.Cantidad;
                    depositoProducto.UnidadId = existencia.UnidadId;
                    depositoProducto.FechaVencimiento = System.DateTime.Today;

                    Datos.GrabarInventarioProductoDeposito(depositoProducto);

                    INVENTARIO_Producto editProducto = Datos.BuscarINVENTARIOProducto(existencia.ProductoId);

                    editProducto.Cantidad = editProducto.Cantidad + existencia.Cantidad;
                    editProducto.EmpleadoId = existencia.EmpleadoId;

                    Datos.ActualizarProductos(editProducto);


                    scope.Complete();

                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

          
        }
    }
}
