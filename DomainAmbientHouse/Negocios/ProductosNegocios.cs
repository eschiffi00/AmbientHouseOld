using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class ProductosNegocios
    {

        ProductosDatos Datos;

        public ProductosNegocios()
        {
            Datos = new ProductosDatos();
        }

        public virtual Productos BuscarProductosPorCodigo(string codigo, DateTime fecha)
        {

            return Datos.BuscarProductosPorCodigo(codigo, fecha);

        }

        public virtual Productos BuscarProductosPorCodigo(string codigo)
        {

            return Datos.BuscarProductosPorCodigo(codigo);

        }


        public virtual List<Productos> ObtenerProductos()
        {
            return Datos.ObtenerProductos();
        }

        public virtual Productos BuscarProducto(int id)
        {
            return Datos.BuscarProducto(id);
        }

        public virtual void NuevoProducto(Productos producto)
        {
            try
            {
                Datos.NuevoProducto(producto);
            }
            catch (Exception ex)
            {

                DomainAmbientHouse.Servicios.Log.save(this, ex);
            }

        }

        internal List<Productos> ListarProductos(SearcherProductos searcher)
        {
            return Datos.ListarProductos(searcher);
        }

        public List<Productos> BuscarProductosPorFiltros(int unidadNegocioId, int tipoCatering, int tipoBarra, int tipoServicio, int categoriaId,
                                                    int cantidadInvitados, int locacionId, int sectorId, int segmentoId, int jornadaId,
                                                    int proveedorId, int Anio, int Mes, string Dia, int adicionalId, int estadoId, int caracteristicaId, int itemOrganizacionId, int semestreId)
        {
            return Datos.BuscarProductosPorFiltros(unidadNegocioId, tipoCatering, tipoBarra, tipoServicio, categoriaId, cantidadInvitados, locacionId, sectorId, segmentoId, jornadaId, proveedorId, Anio, Mes, Dia, adicionalId, estadoId, caracteristicaId, itemOrganizacionId, semestreId);

        }

        public void ActualizarPrecioCostoProductos(List<Productos> ListProductos, double ValorCosto, double ValorPrecio, double PorcentajeCosto, double PorcentajePrecio, double Margen)
        {



            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (var item in ListProductos)
                    {

                        double costo = 0;
                        double precio = 0;
                        double margen = 0;

                        Productos cat = new Productos();

                        cat.Id = item.Id;
                        cat.Descripcion = item.Descripcion;
                        cat.UnidadNegocioId = item.UnidadNegocioId;
                        cat.Codigo = item.Codigo;
                        //cat.Margen = Margen;

                        if (ValorCosto > 0)
                        {

                            costo = item.Costo + ValorCosto;
                            precio = costo * double.Parse(item.Margen.ToString());
                            margen = double.Parse(item.Margen.ToString());


                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;

                        }
                        else if (ValorCosto < 0)
                        {

                            costo = item.Costo + ValorCosto;
                            precio = costo * double.Parse(item.Margen.ToString());
                            margen = double.Parse(item.Margen.ToString());


                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;

                        }
                        else if (PorcentajeCosto > 0)
                        {

                            costo = item.Costo * PorcentajeCosto;
                            precio = costo * double.Parse(item.Margen.ToString());
                            margen = double.Parse(item.Margen.ToString());

                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;

                        }
                        else if (ValorPrecio > 0)
                        {

                            precio = item.Precio + ValorPrecio;

                            costo = item.Costo;

                            margen = precio / costo;

                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;


                        }
                        else if (ValorPrecio < 0)
                        {
                            precio = item.Precio + ValorPrecio;

                            costo = item.Costo;

                            margen = precio / costo;

                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;
                        }
                        else if (PorcentajePrecio > 0)
                        {


                            precio = item.Precio * PorcentajePrecio;

                            costo = item.Costo;

                            margen = precio / costo;

                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;
                        }

                        else if (Margen > 0)
                        {

                            precio = item.Costo * Margen;

                            costo = item.Costo;

                            margen = Margen;

                            cat.Costo = costo;

                            cat.Precio = precio;

                            cat.Margen = margen;
                        }


                        cat.FechaVendimiento = item.FechaVendimiento;
                        cat.Estado = item.Estado;
                        cat.PerfilId = item.PerfilId;

                        cat.TipoCateringId = item.TipoCateringId;
                        cat.TipoBarraId = item.TipoBarraId;
                        cat.TipoServicioId = item.TipoServicioId;
                        cat.SegmentoId = item.SegmentoId;
                        cat.CaracteristicaId = item.CaracteristicaId;
                        cat.SectorId = item.SectorId;
                        cat.ProveedorId = item.ProveedorId;
                        cat.JornadaId = item.JornadaId;
                        cat.LocacionId = item.LocacionId;
                        cat.CantidadInvitados = item.CantidadInvitados;
                        cat.CategoriaId = item.CategoriaId;

                        cat.Anio = item.Anio;
                        cat.Mes = item.Mes;
                        cat.Dia = item.Dia;

                        Datos.NuevoProducto(cat);
                    }

                    scope.Complete();

                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                    throw;
                }
            }
        }

        public void ActualizarProducto(Productos producto)
        {
            Datos.ActualizarProducto(producto);
        }

        public void InactivarProductos(List<Productos> list, int estadoId)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Datos.InactivarProductos(list, estadoId);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                    throw;
                }



            }
        }
    }
}
