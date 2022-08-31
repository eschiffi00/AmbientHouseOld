using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class INVENTARIOProductosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public INVENTARIOProductosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        private List<INVENTARIO_Producto> InventarioProductosToModel(IQueryable<INVENTARIO_Producto> query)
        {

            List<INVENTARIO_Producto> list = new List<INVENTARIO_Producto>();

            foreach (var item in query)
            {
                INVENTARIO_Producto salida = new INVENTARIO_Producto();

                salida.Id = item.Id;
                salida.Cantidad = item.Cantidad;
                salida.CantidadNominal = item.CantidadNominal;
                salida.TipoMovimientoId = item.TipoMovimientoId;
                salida.TipoMovimientoDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMovimientoId).SingleOrDefault().Descripcion;
                salida.CentroCostoId = item.CentroCostoId;
                salida.CentroCostoDescripcion = SqlContext.CentroCostos.Where(o => o.Id == item.CentroCostoId).SingleOrDefault().Descripcion;
                salida.Codigo = item.Codigo;
                salida.CodigoBarra = item.CodigoBarra;
                salida.Costo = item.Costo;
                salida.CreateDate = item.CreateDate;
                salida.Descripcion = item.Descripcion;
                salida.RubroId = item.RubroId;
                salida.RubroDescripcion = SqlContext.Rubros.Where(o => o.RubroId == item.RubroId).SingleOrDefault().Descripcion;
                salida.UnidadId = item.UnidadId;
                salida.UnidadDescripcion = SqlContext.INVENTARIO_Unidades.Where(o => o.Id == item.UnidadId).SingleOrDefault().Descripcion;
                salida.UnidadPresentacionId = item.UnidadPresentacionId;
                salida.UnidadPresentacionDescripcion = SqlContext.INVENTARIO_Unidades.Where(o => o.Id == item.UnidadId).SingleOrDefault().Descripcion;
                

                list.Add(salida);
            }

            
            return list.ToList();

        }

        public virtual List<INVENTARIO_Producto> ListarProductos()
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        select p;


            return this.InventarioProductosToModel(query).ToList();

        }

        public INVENTARIO_Producto BuscarINVENTARIOProducto(int Id)
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        where p.Id == Id
                        select p;

            return this.InventarioProductosToModel(query).FirstOrDefault();

        }

        public void ActualizarProductos(INVENTARIO_Producto producto)
        {
            if (producto.Id > 0)
            {
                INVENTARIO_Producto edit = SqlContext.INVENTARIO_Producto.Where(o=> o.Id == producto.Id).SingleOrDefault();

                edit.Descripcion = producto.Descripcion;

                if (edit.Cantidad != producto.Cantidad)
                {
                    GrabarMovimiento(producto, edit.Cantidad);
                }
               

                edit.Cantidad = producto.Cantidad;
                edit.CantidadNominal = producto.CantidadNominal;
                edit.Codigo = producto.Codigo;
                edit.Costo = producto.Costo;
                edit.RubroId = producto.RubroId;
                edit.CodigoBarra = producto.CodigoBarra;
                edit.TipoMovimientoId = producto.TipoMovimientoId;
                edit.CentroCostoId = producto.CentroCostoId;

                edit.UpdateDate = System.DateTime.Now;

                SqlContext.SaveChanges();

            }
            else
            {
                producto.CreateDate = System.DateTime.Now;

                SqlContext.INVENTARIO_Producto.Add(producto);

                CodigoPorRubro codigo = SqlContext.CodigoPorRubro.Where(o => o.RubroId == producto.RubroId).FirstOrDefault();

                if (codigo.id > 0)
                {
                    codigo.Codigo = codigo.Codigo + 1;
                }

                GrabarMovimiento(producto, 0);

                SqlContext.SaveChanges();
            }

        }

        private void GrabarMovimiento(INVENTARIO_Producto producto, double CantidadAnterior)
        {
            INVENTARIO_Movimiento_Producto movimiento = new INVENTARIO_Movimiento_Producto();

            movimiento.ProductoId = producto.Id;
            movimiento.CantidadAnterior = CantidadAnterior;
            movimiento.CantidadNueva = producto.Cantidad;
            movimiento.Fecha = System.DateTime.Now;
            movimiento.EmpleadoId = producto.EmpleadoId;

            SqlContext.INVENTARIO_Movimiento_Producto.Add(movimiento);
         
        }

        internal List<INVENTARIO_Producto> ListarINVENTARIOProductoPorRubro(int RubroId)
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        where p.RubroId == RubroId
                        select p;


            //return this.InventarioProductosToModel(query).ToList();

            return query.ToList();
        }

        internal List<INVENTARIO_Producto> BuscarINVENTARIOProductoPorProducto(string descripcion)
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        select p;

            if (!String.IsNullOrEmpty(descripcion))
                query = query.Where(o => o.Descripcion.Contains(descripcion));

            return query.ToList();

        }

        internal INVENTARIO_Producto BuscarINVENTARIOProductoPorCodigoBarra(string codigoBarra)
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        where p.CodigoBarra.Equals(codigoBarra)
                        select p;

            return this.InventarioProductosToModel(query).FirstOrDefault();
        }


        public List<Existencias> ListarExistencias(string descripcionProducto,string codigoProducto, int depositoId, int rubroId)
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        join pd in SqlContext.INVENTARIO_ProductoDeposito on p.Id equals pd.ProductoId into Ps
                        from pd in Ps.DefaultIfEmpty()
                        join d in SqlContext.INVENTARIO_Depositos on pd.DepositoId equals d.Id into Ds
                        from d in Ds.DefaultIfEmpty()
                        join u in SqlContext.INVENTARIO_Unidades on p.UnidadId equals u.Id into Us
                        from u in Us.DefaultIfEmpty()
                        join c in SqlContext.INVENTARIO_UnidadesConversion on p.UnidadMedidaConversionId equals c.Id into Cs
                        from c in Cs.DefaultIfEmpty()
                        select new
                        {
                            ProductoId = p.Id,
                            Codigo = p.Codigo,
                            Descripcion = p.Descripcion,
                            Stock = p.Cantidad,
                            StockDeposito = (pd.Cantidad == null ? 0 : pd.Cantidad),
                            DepositoId = (d.Id == null ? 0 : d.Id),
                            DepositoDescripcion = d.Descripcion,
                            RubroId = p.RubroId,
                            UnidadId = (pd.UnidadId== null ? 0 : pd.UnidadId),
                            UnidadDescripcion = u.Descripcion,
                            UnidadesConversion = c.Cantidad

                        };

            if (descripcionProducto.Length > 0)
                query = query.Where(o => o.Descripcion.ToUpper().Contains(descripcionProducto.ToUpper()));

            if (codigoProducto.Length > 0)
                query = query.Where(o => o.Codigo.ToUpper().Contains(codigoProducto.ToUpper()));

            if (depositoId > 0)
                query = query.Where(o => o.DepositoId == depositoId);

            if (rubroId > 0)
                query = query.Where(o => o.RubroId == rubroId);



             List<Existencias> Salida = new List<Existencias>();
             foreach (var item in query)
             {

                 Existencias cat = new Existencias();

                 cat.ProductoId = item.ProductoId;
                 cat.Codigo = item.Codigo;
                 cat.Descripcion = item.Descripcion;
                 cat.Stock = item.Stock;
                 cat.StockDeposito = item.StockDeposito;
                 cat.DepositoId = item.DepositoId;
                 cat.DepositoDescripcion = item.DepositoDescripcion;
                 cat.UnidadId = item.UnidadId;
                 cat.UnidadDescripcion = item.UnidadDescripcion;
                 cat.UnidadesConversion = item.UnidadesConversion;
                 
                 Salida.Add(cat);
             }

             return Salida.ToList();

        }

        internal Existencias BuscarExistencias(int productoId, int depositoId)
        {
            var query = from p in SqlContext.INVENTARIO_Producto
                        join pd in SqlContext.INVENTARIO_ProductoDeposito on p.Id equals pd.ProductoId into Ps
                        from pd in Ps.DefaultIfEmpty()
                        join d in SqlContext.INVENTARIO_Depositos on pd.DepositoId equals d.Id into Ds
                        from d in Ds.DefaultIfEmpty()
                        join u in SqlContext.INVENTARIO_Unidades on p.UnidadId equals u.Id into Us
                        from u in Us.DefaultIfEmpty()
                        join c in SqlContext.INVENTARIO_UnidadesConversion on p.UnidadMedidaConversionId equals c.Id into Cs
                        from c in Cs.DefaultIfEmpty()
                        where pd.ProductoId == productoId && pd.DepositoId == depositoId
                        select new
                        {
                            ProductoId = p.Id,
                            Codigo = p.Codigo,
                            Descripcion = p.Descripcion,
                            Stock = p.Cantidad,
                            StockDeposito = pd.Cantidad,
                            DepositoId = (d.Id == null ? 0 : d.Id),
                            DepositoDescripcion = d.Descripcion,
                            UnidadId = pd.UnidadId,
                            UnidadDescripcion = u.Descripcion,
                            UnidadesConversion = c.Cantidad
                 

                        };

            List<Existencias> Salida = new List<Existencias>();
            foreach (var item in query)
            {

                Existencias cat = new Existencias();

                cat.ProductoId = item.ProductoId;
                cat.Codigo = item.Codigo;
                cat.Descripcion = item.Descripcion;
                cat.Stock = item.Stock;
                cat.StockDeposito = item.StockDeposito;
                cat.DepositoId = item.DepositoId;
                cat.DepositoDescripcion = item.DepositoDescripcion;
                cat.UnidadId = item.UnidadId;
                cat.UnidadDescripcion = item.UnidadDescripcion;
                cat.UnidadesConversion = item.UnidadesConversion;

                Salida.Add(cat);
            }

            return Salida.SingleOrDefault();
        }

        internal void GrabarInventarioProductoDeposito(INVENTARIO_ProductoDeposito depositoProducto)
        {

            INVENTARIO_ProductoDeposito existe = SqlContext.INVENTARIO_ProductoDeposito.Where(o => o.ProductoId == depositoProducto.ProductoId &&
                                                                                                    o.DepositoId == depositoProducto.DepositoId
                                                                                                ).SingleOrDefault();

            if (existe != null)
            {
                existe.Cantidad =existe.Cantidad + depositoProducto.Cantidad;
                
                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.INVENTARIO_ProductoDeposito.Add(depositoProducto);
                SqlContext.SaveChanges();
            }



        }
    }


  
}

namespace DomainAmbientHouse.Entidades
{
    public partial class INVENTARIO_Producto
    {

        public int EmpleadoId { get; set; }

        public string TipoMovimientoDescripcion { get; set; }

        public string CentroCostoDescripcion { get; set; }

        public string RubroDescripcion { get; set; }

        public string UnidadDescripcion { get; set; }

        public string UnidadPresentacionDescripcion { get; set; }
    }

    public partial class Existencias
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public double Cantidad { get; set; }

        public double Stock { get; set; }
        public double StockDeposito { get; set; }

        public double StockPorUnidades 
        { 
            get {
                return UnidadesConversion * Stock;
            }
            set { }
        }
        public double StockDepositoPorUnidades
        {
            get
            {
                return UnidadesConversion * StockDeposito;
            }
            set { }
        }

        public int DepositoId { get; set; }
        public string DepositoDescripcion { get; set; }

        public int EmpleadoId { get; set; }

        public int UnidadId { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string UnidadDescripcion { get; set; }

        public double UnidadesConversion { get; set; }
    }

}

