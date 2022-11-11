using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class ProductosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ProductosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public Productos BuscarProductosPorCodigo(string Codigo, DateTime fecha)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString()); ;

            return SqlContext.Productos.Where(o => o.Codigo.Equals(Codigo) && o.Estado == activo && (o.FechaVendimiento == null || o.FechaVendimiento == fecha)).FirstOrDefault();
        }

        public Productos BuscarProductosPorCodigo(string Codigo)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString()); ;

            return SqlContext.Productos.Where(o => o.Codigo.Equals(Codigo) && o.Estado == activo).FirstOrDefault();
        }

        public List<Productos> ObtenerProductos()
        {


            var query = from p in SqlContext.Productos
                        join Un in SqlContext.UnidadesNegocios on p.UnidadNegocioId equals Un.Id
                        select new
                        {

                            Id = p.Id,
                            Descripcion = p.Descripcion,
                            UnidadNegocioId = p.UnidadNegocioId,
                            UnidadNegocioDescripcion = Un.Descripcion,
                            Codigo = p.Codigo,
                            Costo = p.Costo,
                            Precio = p.Precio,
                            FechaVencimiento = p.FechaVendimiento,
                            Estado = p.Estado,
                            PerfilId = (p.PerfilId == null ? null : p.PerfilId)
                        };


            List<Productos> Salida = new List<Productos>();

            foreach (var item in query)
            {

                Productos cat = new Productos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.Codigo = item.Codigo;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.FechaVendimiento = item.FechaVencimiento;
                cat.Estado = item.Estado;
                cat.PerfilId = item.PerfilId;

                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        internal List<Productos> ListarProductos(SearcherProductos searcher)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["ProductoActivo"].ToString());

            int salon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            int catering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int tecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int barra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int ambientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int organizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            int adicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

            var query = from p in SqlContext.Productos
                        select p;

            if (!string.IsNullOrEmpty(searcher.ProductoId))
            {
                int productoId = int.Parse(searcher.ProductoId);
                return query.Where(x => x.Id == productoId).ToList();
            }

            if (searcher.UnidadNegocioId == tecnica)
            {
                if (searcher.Anio > 0)
                    query = query.Where(x => x.Anio == searcher.Anio && x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId);

                return query.OrderBy(o => o.LocacionId).ToList();
            }
            else if (searcher.UnidadNegocioId == salon)
            {
                if (searcher.Anio > 0)
                    query = query.Where(x => x.Anio == searcher.Anio && x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId);

                return query.OrderBy(o => o.LocacionId).ToList();

            }
            else if (searcher.UnidadNegocioId == catering)
            {
                return query.Where(x => x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId).ToList();
            }
            else if (searcher.UnidadNegocioId == barra)
            {
                return query.Where(x => x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId).ToList();
            }
            else if (searcher.UnidadNegocioId == ambientacion)
            {
                return query.Where(x => x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId).ToList();
            }
            else if (searcher.UnidadNegocioId == adicional)
            {
                return query.Where(x => x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId).ToList();
            }
            else
            {
                return query.Where(x => x.Estado == activo && x.UnidadNegocioId == searcher.UnidadNegocioId).ToList();
            }


        }

        public virtual Productos BuscarProducto(int id)
        {
            return SqlContext.Productos.Where(o => o.Id == id).FirstOrDefault();
        }

        public virtual void NuevoProducto(Productos producto)
        {
            double margen = 0;

            if (producto.Id > 0)
            {
                Productos editProducto = SqlContext.Productos.Where(o => o.Id == producto.Id).First();

                if (producto.Costo > 0)
                    margen = producto.Precio / producto.Costo;
                else
                    margen = 0;

                editProducto.Descripcion = producto.Descripcion;
                editProducto.UnidadNegocioId = producto.UnidadNegocioId;
                editProducto.Costo = producto.Costo;
                editProducto.Precio = producto.Precio;
                editProducto.Margen = margen;
                editProducto.PerfilId = producto.PerfilId;
                editProducto.Codigo = producto.Codigo;
                editProducto.Estado = producto.Estado;
                editProducto.FechaVendimiento = producto.FechaVendimiento;

                editProducto.TipoCateringId = producto.TipoCateringId;
                editProducto.TipoBarraId = producto.TipoBarraId;
                editProducto.TipoServicioId = producto.TipoServicioId;
                editProducto.SegmentoId = producto.SegmentoId;
                editProducto.SectorId = producto.SectorId;
                editProducto.ProveedorId = producto.ProveedorId;
                editProducto.JornadaId = producto.JornadaId;
                editProducto.LocacionId = producto.LocacionId;
                editProducto.CantidadInvitados = producto.CantidadInvitados;
                editProducto.CategoriaId = producto.CategoriaId;
                editProducto.OrganizacionItemId = producto.OrganizacionItemId;
                editProducto.CaracteristicaId = producto.CaracteristicaId;

                editProducto.Anio = producto.Anio;
                editProducto.Mes = producto.Mes;
                editProducto.Dia = producto.Dia;
                editProducto.Semestre = producto.Semestre;
                editProducto.Royalty = producto.Royalty;


                SqlContext.SaveChanges();


            }
            else
            {
                if (producto.Costo > 0)
                    margen = producto.Precio / producto.Costo;
                else
                    margen = 0;

                producto.Margen = margen;


                SqlContext.Productos.Add(producto);
                SqlContext.SaveChanges();
            }

        }

        public List<Productos> BuscarProductosPorFiltros(int UnidadNegocioId, int tipoCatering, int tipoBarra, int tipoServicio, int categoriaId, int cantidadInvitados, int locacionId,
                                                        int sectorId, int segmentoId, int jornadaId, int proveedorId, int Anio, int Mes, string Dia, int adicionalId, int estadoId,
                                                        int caracteristicaId, int itemOrganizacionId, int semestreId)
        {
            int estadoActivo = estadoId;

            var query = from p in SqlContext.Productos
                        join Un in SqlContext.UnidadesNegocios on p.UnidadNegocioId equals Un.Id
                        where p.Estado == estadoActivo
                        select new
                        {

                            Id = p.Id,
                            Descripcion = p.Descripcion,
                            UnidadNegocioId = p.UnidadNegocioId,
                            UnidadNegocioDescripcion = Un.Descripcion,
                            Codigo = p.Codigo,
                            Costo = p.Costo,
                            Precio = p.Precio,
                            FechaVencimiento = p.FechaVendimiento,
                            Estado = p.Estado,
                            PerfilId = (p.PerfilId == null ? null : p.PerfilId),
                            TipoCateringId = p.TipoCateringId,
                            TipoBarraId = p.TipoBarraId,
                            TipoServicioId = p.TipoServicioId,
                            CategoriaId = p.CategoriaId,
                            CantidadInvitados = p.CantidadInvitados,
                            LocacionId = p.LocacionId,
                            SectorId = p.SectorId,
                            SegmentoId = p.SegmentoId,
                            JornadaId = p.JornadaId,
                            ProveedorId = p.ProveedorId,
                            Anio = p.Anio,
                            Mes = p.Mes,
                            Dia = p.Dia,
                            AdicionalId = p.AdicionalId,
                            CaracteristicaId = p.CaracteristicaId,
                            OrganizacionItemId = p.OrganizacionItemId,
                            Margen = p.Margen,
                            SemestreId = p.Semestre,
                            Royalty = p.Royalty
                        };


            //if (!string.IsNullOrEmpty(cliente))
            //    query = query.Where(t => t.ApellidoNombre.Contains(cliente));


            if (UnidadNegocioId > 0)
                query = query.Where(t => t.UnidadNegocioId == UnidadNegocioId);

            if (tipoCatering > 0)
                query = query.Where(t => t.TipoCateringId == tipoCatering);

            if (adicionalId > 0)
                query = query.Where(t => t.AdicionalId == adicionalId);

            if (tipoBarra > 0)
                query = query.Where(t => t.TipoBarraId == tipoBarra);

            if (tipoServicio > 0)
                query = query.Where(t => t.TipoServicioId == tipoServicio);

            if (categoriaId > 0)
                query = query.Where(t => t.CategoriaId == categoriaId);

            if (cantidadInvitados > 0)
                query = query.Where(t => t.CantidadInvitados == cantidadInvitados);

            if (locacionId > 0)
                query = query.Where(t => t.LocacionId == locacionId);

            if (sectorId > 0)
                query = query.Where(t => t.SectorId == sectorId);

            if (segmentoId > 0)
                query = query.Where(t => t.SegmentoId == segmentoId);

            if (caracteristicaId > 0)
                query = query.Where(t => t.CaracteristicaId == caracteristicaId);

            if (jornadaId > 0)
                query = query.Where(t => t.JornadaId == jornadaId);

            if (proveedorId > 0)
                query = query.Where(t => t.ProveedorId == proveedorId);

            if (Anio > 0)
                query = query.Where(t => t.Anio == Anio);

            if (Mes > 0)
                query = query.Where(t => t.Mes == Mes);

            if (!string.IsNullOrEmpty(Dia))
                query = query.Where(t => t.Dia.Contains(Dia));

            if (itemOrganizacionId > 0)
                query = query.Where(t => t.OrganizacionItemId == itemOrganizacionId);

            if (semestreId > 0)
                query = query.Where(t => t.SemestreId == semestreId);

            List<Productos> Salida = new List<Productos>();

            foreach (var item in query)
            {

                Productos cat = new Productos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.Codigo = item.Codigo;
                cat.Costo = System.Math.Round(item.Costo, 3);
                cat.Precio = System.Math.Round(item.Precio, 3);
                cat.FechaVendimiento = item.FechaVencimiento;
                cat.Estado = item.Estado;
                cat.PerfilId = item.PerfilId;

                cat.TipoBarraId = item.TipoBarraId;
                cat.TipoCateringId = item.TipoCateringId;
                cat.TipoServicioId = item.TipoServicioId;
                cat.CategoriaId = item.CategoriaId;
                cat.Anio = item.Anio;
                cat.Mes = item.Mes;
                cat.Dia = item.Dia;

                cat.LocacionId = item.LocacionId;
                cat.SectorId = item.SectorId;
                cat.SegmentoId = item.SegmentoId;
                cat.CaracteristicaId = item.CaracteristicaId;
                cat.JornadaId = item.JornadaId;
                cat.CantidadInvitados = item.CantidadInvitados;
                cat.ProveedorId = item.ProveedorId;
                cat.OrganizacionItemId = item.OrganizacionItemId;
                cat.Margen = System.Math.Round(double.Parse(item.Margen.ToString()), 3);
                cat.Semestre = item.SemestreId;
                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public void ActualizarProducto(Productos producto)
        {
            Productos editProducto = SqlContext.Productos.Where(o => o.Id == producto.Id).SingleOrDefault();


            editProducto.Costo = producto.Costo;
            editProducto.Precio = producto.Precio;
            editProducto.Margen = producto.Margen;


            SqlContext.SaveChanges();
        }

        public void InactivarProductos(List<Productos> list, int estadoId)
        {


            foreach (var item in list)
            {

                Productos edit = SqlContext.Productos.Where(o => o.Id == item.Id).Single();

                edit.Estado = estadoId;

                SqlContext.SaveChanges();


            }
        }
    }

}

namespace DomainAmbientHouse.Entidades
{
    public class SearcherProductos
    {
        public string ProductoId { get; set; }
        public int UnidadNegocioId { get; set; }
        public int Anio { get; set; }
    }
}
