using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Globalization;
using DomainAmbientHouse.Servicios;

namespace DomainAmbientHouse.Datos
{
    public class PresupuestoDetalleDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        private int _rubroSalon;
        private int _rubroCatering;
        private int _rubroTecnica;
        private int _rubroBarra;
        private int _rubroAmbientacion;
        private int _rubroOrganizacion;
        private int _rubroAdicional;

        public PresupuestoDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();

            _rubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            _rubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            _rubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            _rubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            _rubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            _rubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            _rubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());
        }

        private List<PresupuestoDetalle> PresupuestoDetalleToModel(IQueryable<PresupuestoDetalle> query)
        {
            List<PresupuestoDetalle> list = new List<PresupuestoDetalle>();

            foreach (var item in query)
            {
                PresupuestoDetalle salida = new PresupuestoDetalle();


                salida.Id = item.Id;
                salida.PresupuestoId = item.PresupuestoId;
                salida.UnidadNegocioId = item.UnidadNegocioId;
                salida.UnidadNegocioDescripcion = SqlContext.UnidadesNegocios.Where(o => o.Id == item.UnidadNegocioId).SingleOrDefault().Descripcion;
                salida.ProveedorId = item.ProveedorId;
                if (item.ProveedorId != null)
                    salida.ProveedorRazonSocial = SqlContext.Proveedores.Where(o => o.Id == item.ProveedorId).SingleOrDefault().RazonSocial;
                salida.ServicioId = item.ServicioId;
                salida.LocacionId = item.LocacionId;
                salida.ProductoId = item.ProductoId;
                salida.ProductoDescripcion = item.ProductoDescripcion;
                salida.PrecioItem = item.PrecioItem;
                salida.PrecioLista = item.PrecioLista;
                salida.PrecioMas5 = item.PrecioMas5;
                salida.PrecioMenos5 = item.PrecioMenos5;
                salida.PrecioMenos10 = item.PrecioMenos10;
                salida.CodigoItem = item.CodigoItem;
                salida.Descuentos = item.Descuentos;
                salida.Incremento = item.Incremento;
                salida.PrecioSeleccionado = item.PrecioSeleccionado;
                salida.PorcentajeComision = item.PorcentajeComision;
                salida.ValorSeleccionado = item.ValorSeleccionado;
                salida.Comision = item.Comision;
                salida.CantidadAdicional = item.CantidadAdicional;
                salida.Costo = item.Costo;
                salida.Cannon = item.Cannon;
                salida.TipoLogisticaId = item.TipoLogisticaId;
                if (item.TipoLogisticaId != null)
                    salida.TipoLogisticaDescripcion = SqlContext.TipoLogistica.Where(o => o.Id == item.TipoLogisticaId).SingleOrDefault().Concepto;
                salida.LocalidadId = item.LocalidadId;
                if (item.LocacionId != null)
                    salida.LocalidadDescripcion = SqlContext.Locaciones.Where(o => o.Id == item.LocacionId).SingleOrDefault().Descripcion;
                salida.CantInvitadosLogistica = item.CantInvitadosLogistica;
                salida.Logistica = item.Logistica;
                salida.UsoCocina = item.UsoCocina;
                salida.version = item.version;
                salida.EstadoId = item.EstadoId;
                salida.FechaAprobacion = item.FechaAprobacion;
                salida.ValorIntermediario = item.ValorIntermediario;

                salida.RentaUnNominal = CalcularRentaNominal(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                 (salida.Incremento == null ? 0 : double.Parse(salida.Incremento.ToString())),
                                  (salida.Descuentos == null ? 0 : double.Parse(salida.Descuentos.ToString())));
                salida.RentaUnPorcentaje = CalcularRentaPorcentaje(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (salida.Incremento == null ? 0 : double.Parse(salida.Incremento.ToString())),
                                     (salida.Descuentos == null ? 0 : double.Parse(salida.Descuentos.ToString())));


                salida.FechaEvento = SqlContext.Presupuestos.Where(o => o.Id == item.PresupuestoId).SingleOrDefault().FechaEvento;
                salida.Royalty = item.Royalty;


                list.Add(salida);
            }

            return list;
        }

        public void GuardarPresupuestoDetalle(PresupuestoDetalle presupuestoDetalle)
        {

            //if (presupuestoDetalle.Id > 0)
            //{
            //    PresupuestoDetalle edit = SqlContext.PresupuestoDetalle.Where(o => o.Id == presupuestoDetalle.Id).FirstOrDefault();

            //    edit.PresupuestoId = presupuestoDetalle.PresupuestoId;
            //    edit.Cannon = presupuestoDetalle.Cannon;
            //    edit.CantidadAdicional = presupuestoDetalle.CantidadAdicional;
            //    edit.CantInvitadosLogistica = presupuestoDetalle.CantInvitadosLogistica;
            //    edit.CodigoItem = presupuestoDetalle.CodigoItem;
            //    edit.ProductoId = presupuestoDetalle.ProductoId;
            //    edit.Comision = presupuestoDetalle.Comision;
            //    edit.Costo = presupuestoDetalle.Costo;
            //    edit.Descuentos = presupuestoDetalle.Descuentos;
            //    edit.Logistica = presupuestoDetalle.Logistica;
            //    edit.PorcentajeComision = presupuestoDetalle.PorcentajeComision;
            //    edit.PrecioItem = presupuestoDetalle.PrecioItem;
            //    edit.PrecioLista = presupuestoDetalle.PrecioLista;
            //    edit.PrecioMas5 = presupuestoDetalle.PrecioMas5;
            //    edit.PrecioMenos10 = presupuestoDetalle.PrecioMenos10;
            //    edit.PrecioMenos5 = presupuestoDetalle.PrecioMenos5;
            //    edit.PrecioSeleccionado = presupuestoDetalle.PrecioSeleccionado;
            //    edit.ProductoDescripcion = presupuestoDetalle.ProductoDescripcion;
            //    edit.LocacionId = presupuestoDetalle.LocacionId;
            //    edit.ProveedorId = presupuestoDetalle.ProveedorId;
            //    edit.ServicioId = presupuestoDetalle.ServicioId;
            //    edit.TipoLogisticaId = presupuestoDetalle.TipoLogisticaId;
            //    edit.UnidadNegocioId = presupuestoDetalle.UnidadNegocioId;
            //    edit.ValorSeleccionado = presupuestoDetalle.ValorSeleccionado;
            //    edit.UsoCocina = presupuestoDetalle.UsoCocina;
            //    edit.version = presupuestoDetalle.version;
            //    edit.Comentario = presupuestoDetalle.Comentario;
            //    edit.ValorIntermediario = presupuestoDetalle.ValorIntermediario;
            //    edit.EstadoId = presupuestoDetalle.EstadoId;
            //    edit.FechaUpdate = System.DateTime.Now;

            //    SqlContext.SaveChanges();

            //}
            //else
            //{

            presupuestoDetalle.FechaCreate = System.DateTime.Now;

            SqlContext.PresupuestoDetalle.Add(presupuestoDetalle);
            SqlContext.SaveChanges();

            //}

        }

        public List<PresupuestoDetalle> BuscarDetallePresupuesto(int PresupuestoId)
        {

            var query = from Pd in SqlContext.PresupuestoDetalle
                        join P in SqlContext.Productos on Pd.ProductoId equals P.Id
                        join UN in SqlContext.UnidadesNegocios on Pd.UnidadNegocioId equals UN.Id
                        join Pr in SqlContext.Proveedores on Pd.ProveedorId equals Pr.Id into Prs
                        from Pr in Prs.DefaultIfEmpty()
                        join Tl in SqlContext.TipoLogistica on Pd.TipoLogisticaId equals Tl.Id into Tls
                        from Tl in Tls.DefaultIfEmpty()
                        join L in SqlContext.Localidades on Pd.LocalidadId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        join e in SqlContext.Estados on Pd.EstadoId equals e.Id
                        where Pd.PresupuestoId == PresupuestoId
                        select new
                        {

                            Id = Pd.Id,
                            PresupuestoId = Pd.PresupuestoId,
                            UnidadNegocioId = Pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = UN.Descripcion,
                            ProveedorId = (Pd.ProveedorId == null ? null : Pd.ProveedorId),
                            ProveedorRazonSocial = Pr.RazonSocial,
                            ServicioId = (Pd.ServicioId == null ? null : Pd.ServicioId),
                            LocacionId = (Pd.LocacionId == null ? null : Pd.LocacionId),
                            ProductoId = Pd.ProductoId,
                            ProductoDescripcion = P.Descripcion,
                            PrecioItem = Pd.PrecioItem,
                            PrecioLista = Pd.PrecioLista,
                            PrecioMas5 = Pd.PrecioMas5,
                            PrecioMenos5 = Pd.PrecioMenos5,
                            PrecioMenos10 = Pd.PrecioMenos10,
                            CodigoItem = Pd.CodigoItem,
                            Descuentos = Pd.Descuentos,
                            Incremento = Pd.Incremento,
                            PrecioSeleccionado = Pd.PrecioSeleccionado,
                            PorcentajeComision = Pd.PorcentajeComision,
                            ValorSeleccionado = Pd.ValorSeleccionado,
                            Comision = Pd.Comision,
                            CantidadAdicional = Pd.CantidadAdicional,
                            Costo = Pd.Costo,
                            Cannon = Pd.Cannon,
                            ValorIntermediario = Pd.ValorIntermediario,
                            TipoLogisticaId = (Pd.TipoLogisticaId == null ? null : Pd.TipoLogisticaId),
                            TipoLogisticaDescripcion = Tl.Concepto,
                            LocalidadId = (Pd.LocalidadId == null ? null : Pd.LocalidadId),
                            LocalidadDescripcion = L.Descripcion,
                            CantInvitadosLogistica = Pd.CantInvitadosLogistica,
                            Logistica = Pd.Logistica,
                            UsoCocina = Pd.UsoCocina,
                            version = Pd.version,
                            EstadoId = Pd.EstadoId,
                            RentaUnNominal = 0,
                            RentaUnPorcentaje = 0,
                            NuevoValor = 0,
                            FechaAprobacion = Pd.FechaAprobacion,
                            EstadoItem = e.Descripcion,
                            Comentario = Pd.Comentario,
                            ComentarioProveedor = Pd.ComentarioProveedor,
                            EstadoProveedor = Pd.EstadoProveedor,
                            FechaEvento = new DateTime(),
                            AnularCanon = Pd.AnuloCanon,
                            CostoSillas = Pd.CostoSillas,
                            CostoMesas = Pd.CostoMesas,
                            PrecioSillas = Pd.PrecioSillas,
                            PrecioMesas = Pd.PrecioMesas,
                            Royalty = Pd.Royalty


                        };

            List<PresupuestoDetalle> Salida = new List<PresupuestoDetalle>();
            foreach (var item in query)
            {

                PresupuestoDetalle cat = new PresupuestoDetalle();

                cat.Id = item.Id;
                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;
                cat.ServicioId = item.ServicioId;
                cat.LocacionId = item.LocacionId;
                cat.ProductoId = item.ProductoId;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.PrecioItem = item.PrecioItem;
                cat.PrecioLista = item.PrecioLista;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.CodigoItem = item.CodigoItem;
                cat.Descuentos = item.Descuentos;
                cat.Incremento = item.Incremento;
                cat.PrecioSeleccionado = item.PrecioSeleccionado;
                cat.PorcentajeComision = item.PorcentajeComision;
                cat.ValorSeleccionado = item.ValorSeleccionado;
                cat.Comision = item.Comision;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Costo = item.Costo;
                cat.Cannon = item.Cannon;
                cat.ValorIntermediario = item.ValorIntermediario;
                cat.TipoLogisticaId = item.TipoLogisticaId;
                cat.TipoLogisticaDescripcion = item.TipoLogisticaDescripcion;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.CantInvitadosLogistica = item.CantInvitadosLogistica;
                cat.Logistica = item.Logistica;
                cat.UsoCocina = item.UsoCocina;
                cat.version = item.version;
                cat.EstadoId = item.EstadoId;


                cat.RentaUnNominal = CalcularRentaNominal(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                 (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.RentaUnPorcentaje = CalcularRentaPorcentaje(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                 (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.NuevoValor = (item.ValorSeleccionado - (item.Descuentos == null ? 0 : double.Parse(item.Descuentos.ToString())) + (item.Incremento == null ? 0 : double.Parse(item.Incremento.ToString())));

                cat.FechaAprobacion = item.FechaAprobacion;

                cat.EstadoItem = item.EstadoItem;

                cat.Comentario = item.Comentario;
                cat.ComentarioProveedor = item.ComentarioProveedor;
                cat.EstadoProveedor = item.EstadoProveedor;
                cat.FechaEvento = SqlContext.Presupuestos.Where(o => o.Id == item.PresupuestoId).FirstOrDefault().FechaEvento;

                cat.AnuloCanon = item.AnularCanon;

                cat.CostoSillas = item.CostoSillas;
                cat.CostoMesas = item.CostoMesas;
                cat.PrecioSillas = item.PrecioSillas;
                cat.PrecioMesas = item.PrecioMesas;

                cat.PorcentajeDelTotalPresupuestoPorUnidadNegocio = CalcularPorcentajeDelTotalPorUnidadNegocio(item.PresupuestoId, item.ValorSeleccionado,
                        (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                        (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));

                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            return Salida.Distinct().ToList();

        }

        internal List<PresupuestoDetalle> BuscarDetallePresupuestobis(int PresupuestoId)
        {

            var query = from Pd in SqlContext.PresupuestoDetalle
                        join P in SqlContext.Productos on Pd.ProductoId equals P.Id
                        join UN in SqlContext.UnidadesNegocios on Pd.UnidadNegocioId equals UN.Id
                        join Pr in SqlContext.Proveedores on Pd.ProveedorId equals Pr.Id into Prs
                        from Pr in Prs.DefaultIfEmpty()
                        join Tl in SqlContext.TipoLogistica on Pd.TipoLogisticaId equals Tl.Id into Tls
                        from Tl in Tls.DefaultIfEmpty()
                        join L in SqlContext.Localidades on Pd.LocalidadId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        join e in SqlContext.Estados on Pd.EstadoId equals e.Id
                        where Pd.PresupuestoId == PresupuestoId
                        select new
                        {

                            Id = Pd.Id,
                            PresupuestoId = Pd.PresupuestoId,
                            UnidadNegocioId = Pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = UN.Descripcion,
                            ProveedorId = (Pd.ProveedorId == null ? null : Pd.ProveedorId),
                            ProveedorRazonSocial = Pr.RazonSocial,
                            ServicioId = (Pd.ServicioId == null ? null : Pd.ServicioId),
                            LocacionId = (Pd.LocacionId == null ? null : Pd.LocacionId),
                            ProductoId = Pd.ProductoId,
                            ProductoDescripcion = P.Descripcion,
                            PrecioItem = Pd.PrecioItem,
                            PrecioLista = Pd.PrecioLista,
                            PrecioMas5 = Pd.PrecioMas5,
                            PrecioMenos5 = Pd.PrecioMenos5,
                            PrecioMenos10 = Pd.PrecioMenos10,
                            CodigoItem = Pd.CodigoItem,
                            Descuentos = Pd.Descuentos,
                            Incremento = Pd.Incremento,
                            PrecioSeleccionado = Pd.PrecioSeleccionado,
                            PorcentajeComision = Pd.PorcentajeComision,
                            ValorSeleccionado = Pd.ValorSeleccionado,
                            Comision = Pd.Comision,
                            CantidadAdicional = Pd.CantidadAdicional,
                            Costo = Pd.Costo,
                            Cannon = Pd.Cannon,
                            ValorIntermediario = Pd.ValorIntermediario,
                            TipoLogisticaId = (Pd.TipoLogisticaId == null ? null : Pd.TipoLogisticaId),
                            TipoLogisticaDescripcion = Tl.Concepto,
                            LocalidadId = (Pd.LocalidadId == null ? null : Pd.LocalidadId),
                            LocalidadDescripcion = L.Descripcion,
                            CantInvitadosLogistica = Pd.CantInvitadosLogistica,
                            Logistica = Pd.Logistica,
                            UsoCocina = Pd.UsoCocina,
                            version = Pd.version,
                            EstadoId = Pd.EstadoId,
                            RentaUnNominal = 0,
                            RentaUnPorcentaje = 0,
                            NuevoValor = 0,
                            FechaAprobacion = Pd.FechaAprobacion,
                            EstadoItem = e.Descripcion,
                            Comentario = Pd.Comentario,
                            ComentarioProveedor = Pd.ComentarioProveedor,
                            EstadoProveedor = Pd.EstadoProveedor,
                            FechaEvento = new DateTime(),
                            AnularCanon = Pd.AnuloCanon,
                            CostoSillas = Pd.CostoSillas,
                            CostoMesas = Pd.CostoMesas,
                            PrecioSillas = Pd.PrecioSillas,
                            PrecioMesas = Pd.PrecioMesas,
                            Royalty = Pd.Royalty


                        };

            List<PresupuestoDetalle> Salida = new List<PresupuestoDetalle>();
            foreach (var item in query)
            {

                PresupuestoDetalle cat = new PresupuestoDetalle();

                cat.Id = item.Id;
                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;
                cat.ServicioId = item.ServicioId;
                cat.LocacionId = item.LocacionId;
                cat.ProductoId = item.ProductoId;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.PrecioItem = item.PrecioItem;
                cat.PrecioLista = item.PrecioLista;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.CodigoItem = item.CodigoItem;
                cat.Descuentos = item.Descuentos;
                cat.Incremento = item.Incremento;
                cat.PrecioSeleccionado = item.PrecioSeleccionado;
                cat.PorcentajeComision = item.PorcentajeComision;
                cat.ValorSeleccionado = item.ValorSeleccionado;
                cat.Comision = item.Comision;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Costo = item.Costo;
                cat.Cannon = item.Cannon;
                cat.ValorIntermediario = item.ValorIntermediario;
                cat.TipoLogisticaId = item.TipoLogisticaId;
                cat.TipoLogisticaDescripcion = item.TipoLogisticaDescripcion;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.CantInvitadosLogistica = item.CantInvitadosLogistica;
                cat.Logistica = item.Logistica;
                cat.UsoCocina = item.UsoCocina;
                cat.version = item.version;
                cat.EstadoId = item.EstadoId;


                cat.RentaUnNominal = CalcularRentaNominal(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                 (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.RentaUnPorcentaje = CalcularRentaPorcentaje(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                 (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.NuevoValor = (item.ValorSeleccionado - (item.Descuentos == null ? 0 : double.Parse(item.Descuentos.ToString())) + (item.Incremento == null ? 0 : double.Parse(item.Incremento.ToString())));

                cat.FechaAprobacion = item.FechaAprobacion;

                cat.EstadoItem = item.EstadoItem;

                cat.Comentario = item.Comentario;
                cat.ComentarioProveedor = item.ComentarioProveedor;
                cat.EstadoProveedor = item.EstadoProveedor;
                cat.FechaEvento = SqlContext.Presupuestos.Where(o => o.Id == item.PresupuestoId).FirstOrDefault().FechaEvento;

                cat.AnuloCanon = item.AnularCanon;

                cat.CostoSillas = item.CostoSillas;
                cat.CostoMesas = item.CostoMesas;
                cat.PrecioSillas = item.PrecioSillas;
                cat.PrecioMesas = item.PrecioMesas;
                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            return Salida.Distinct().ToList();

        }
        public List<PresupuestoDetalle> RePresupuesto(int PresupuestoId)
        {

            var query = from Pd in SqlContext.PresupuestoDetalle
                        join P in SqlContext.Productos on Pd.ProductoId equals P.Id
                        join UN in SqlContext.UnidadesNegocios on Pd.UnidadNegocioId equals UN.Id
                        join Pr in SqlContext.Proveedores on Pd.ProveedorId equals Pr.Id into Prs
                        from Pr in Prs.DefaultIfEmpty()
                        join Tl in SqlContext.TipoLogistica on Pd.TipoLogisticaId equals Tl.Id into Tls
                        from Tl in Tls.DefaultIfEmpty()
                        join L in SqlContext.Localidades on Pd.LocalidadId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where Pd.PresupuestoId == PresupuestoId
                        select new
                        {

                            Id = Pd.Id,
                            PresupuestoId = Pd.PresupuestoId,
                            UnidadNegocioId = Pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = UN.Descripcion,
                            ProveedorId = (Pd.ProveedorId == null ? null : Pd.ProveedorId),
                            ProveedorRazonSocial = Pr.RazonSocial,
                            ServicioId = (Pd.ServicioId == null ? null : Pd.ServicioId),
                            LocacionId = (Pd.LocacionId == null ? null : Pd.LocacionId),
                            ProductoId = Pd.ProductoId,
                            ProductoDescripcion = P.Descripcion,
                            PrecioItem = Pd.PrecioItem,
                            PrecioLista = Pd.PrecioLista,
                            PrecioMas5 = Pd.PrecioMas5,
                            PrecioMenos5 = Pd.PrecioMenos5,
                            PrecioMenos10 = Pd.PrecioMenos10,
                            CodigoItem = Pd.CodigoItem,
                            Descuentos = Pd.Descuentos,
                            Incremento = Pd.Incremento,
                            PrecioSeleccionado = Pd.PrecioSeleccionado,
                            PorcentajeComision = Pd.PorcentajeComision,
                            ValorSeleccionado = Pd.ValorSeleccionado,
                            Comision = Pd.Comision,
                            CantidadAdicional = Pd.CantidadAdicional,
                            Costo = Pd.Costo,
                            Cannon = Pd.Cannon,
                            ValorIntermediario = Pd.ValorIntermediario,
                            TipoLogisticaId = (Pd.TipoLogisticaId == null ? null : Pd.TipoLogisticaId),
                            TipoLogisticaDescripcion = Tl.Concepto,
                            LocalidadId = (Pd.LocalidadId == null ? null : Pd.LocalidadId),
                            LocalidadDescripcion = L.Descripcion,
                            CantInvitadosLogistica = Pd.CantInvitadosLogistica,
                            Logistica = Pd.Logistica,
                            UsoCocina = Pd.UsoCocina,
                            version = Pd.version,
                            EstadoId = Pd.EstadoId,
                            Comentario = Pd.Comentario,
                            AnularCanon = Pd.AnuloCanon,
                            CostoSillas = Pd.CostoSillas,
                            CostoMesas = Pd.CostoMesas,
                            PrecioSillas = Pd.PrecioSillas,
                            PrecioMesas = Pd.PrecioMesas,
                            Royalty = Pd.Royalty

                        };

            List<PresupuestoDetalle> Salida = new List<PresupuestoDetalle>();
            foreach (var item in query)
            {

                PresupuestoDetalle cat = new PresupuestoDetalle();

                cat.Id = item.Id;
                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;
                cat.ServicioId = item.ServicioId;
                cat.LocacionId = item.LocacionId;
                cat.ProductoId = item.ProductoId;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.PrecioItem = item.PrecioItem;
                cat.PrecioLista = item.PrecioLista;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.CodigoItem = item.CodigoItem;
                cat.Descuentos = item.Descuentos;
                cat.Incremento = item.Incremento;
                cat.PrecioSeleccionado = item.PrecioSeleccionado;
                cat.PorcentajeComision = item.PorcentajeComision;
                cat.ValorSeleccionado = item.ValorSeleccionado;
                cat.Comision = item.Comision;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Costo = item.Costo;
                cat.Cannon = item.Cannon;
                cat.ValorIntermediario = item.ValorIntermediario;
                cat.TipoLogisticaId = item.TipoLogisticaId;
                cat.TipoLogisticaDescripcion = item.TipoLogisticaDescripcion;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.CantInvitadosLogistica = item.CantInvitadosLogistica;
                cat.Logistica = item.Logistica;
                cat.UsoCocina = item.UsoCocina;
                cat.version = item.version;
                cat.EstadoId = item.EstadoId;
                cat.Comentario = item.Comentario;
                cat.AnuloCanon = item.AnularCanon;

                cat.CostoSillas = item.CostoSillas;
                cat.CostoMesas = item.CostoMesas;
                cat.PrecioSillas = item.PrecioSillas;
                cat.PrecioMesas = item.PrecioMesas;
                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            return Salida.Distinct().ToList();

        }

        private double CalcularRentaPorcentaje(double costo, double precio, double comision, double incremento, double descuento)
        {
            if (precio > 0 && costo > 0)
            {
                double costoTotal = costo + comision;

                double rentabilidad = ((((precio + incremento - descuento) - costoTotal) / (precio + incremento - descuento)) * 100);

                return System.Math.Round(rentabilidad, 2);
            }
            else
                return 0;
        }

        private double CalcularRentaNominal(double costo, double precio, double comision, double incremento, double descuento)
        {
            if (precio > 0 && costo > 0)
            {
                double costoTotal = costo + comision;

                double rentabilidad = (precio + incremento - descuento) - costoTotal;

                return System.Math.Round(rentabilidad, 2);
            }
            else
                return 0;
        }



        private string CalcularPorcentajeDelTotalPorUnidadNegocio(int presupuestoId, double precio, double incremento, double descuento)
        {
            if (precio > 0)
            {

                Comun cmd = new Comun();

                double preciototalporunidadnegocio = (precio + incremento - descuento);

                List<PresupuestoDetalle> ListPresupuestoDetalle = BuscarDetallePresupuestobis(presupuestoId);

                double valortotalpresupuesto = System.Math.Round(cmd.CalcularTotalPresupuestoPendiente(presupuestoId, ListPresupuestoDetalle, 0, 0), 2);


                return System.Math.Round(((preciototalporunidadnegocio / valortotalpresupuesto) * 100), 2).ToString() + " %";

            }
            else
                return "0%";
        }

        public void EliminarPresupuestoDetalle(int presupuestoId)
        {
            List<PresupuestoDetalle> detalle = SqlContext.PresupuestoDetalle.Where(o => o.PresupuestoId == presupuestoId).ToList();

            foreach (var item in detalle)
            {

                SqlContext.PresupuestoDetalle.Remove(item);
                SqlContext.SaveChanges();

            }



        }

        public List<PresupuestoDetalle> BuscarDetallePresupuestoAprobados(int PresupuestoId)
        {
            int aprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());
            int pagado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleCobrado"].ToString());

            var query = from Pd in SqlContext.PresupuestoDetalle
                        join P in SqlContext.Productos on Pd.ProductoId equals P.Id
                        join UN in SqlContext.UnidadesNegocios on Pd.UnidadNegocioId equals UN.Id
                        join Pr in SqlContext.Proveedores on Pd.ProveedorId equals Pr.Id into Prs
                        from Pr in Prs.DefaultIfEmpty()
                        join Tl in SqlContext.TipoLogistica on Pd.TipoLogisticaId equals Tl.Id into Tls
                        from Tl in Tls.DefaultIfEmpty()
                        join L in SqlContext.Localidades on Pd.LocalidadId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where Pd.PresupuestoId == PresupuestoId && (Pd.EstadoId == aprobado || Pd.EstadoId == pagado)
                        select new
                        {

                            Id = Pd.Id,
                            PresupuestoId = Pd.PresupuestoId,
                            UnidadNegocioId = Pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = UN.Descripcion,
                            ProveedorId = (Pd.ProveedorId == null ? null : Pd.ProveedorId),
                            ProveedorRazonSocial = Pr.RazonSocial,
                            ServicioId = (Pd.ServicioId == null ? null : Pd.ServicioId),
                            LocacionId = (Pd.LocacionId == null ? null : Pd.LocacionId),
                            ProductoId = Pd.ProductoId,
                            ProductoDescripcion = P.Descripcion,
                            PrecioItem = Pd.PrecioItem,
                            PrecioLista = Pd.PrecioLista,
                            PrecioMas5 = Pd.PrecioMas5,
                            PrecioMenos5 = Pd.PrecioMenos5,
                            PrecioMenos10 = Pd.PrecioMenos10,
                            CodigoItem = Pd.CodigoItem,
                            Descuentos = Pd.Descuentos,
                            Incremento = Pd.Incremento,
                            PrecioSeleccionado = Pd.PrecioSeleccionado,
                            PorcentajeComision = Pd.PorcentajeComision,
                            ValorSeleccionado = Pd.ValorSeleccionado,
                            Comision = Pd.Comision,
                            CantidadAdicional = Pd.CantidadAdicional,
                            Costo = Pd.Costo,
                            Cannon = Pd.Cannon,
                            TipoLogisticaId = (Pd.TipoLogisticaId == null ? null : Pd.TipoLogisticaId),
                            TipoLogisticaDescripcion = Tl.Concepto,
                            LocalidadId = (Pd.LocalidadId == null ? null : Pd.LocalidadId),
                            LocalidadDescripcion = L.Descripcion,
                            CantInvitadosLogistica = Pd.CantInvitadosLogistica,
                            Logistica = Pd.Logistica,
                            UsoCocina = Pd.UsoCocina,
                            version = Pd.version,
                            EstadoId = Pd.EstadoId,
                            RentaUnNominal = 0,
                            RentaUnPorcentaje = 0,
                            FechaAprobacion = Pd.FechaAprobacion,
                            ValorIntermediario = Pd.ValorIntermediario,
                            Comentario = Pd.Comentario,
                            NuevoValor = 0,
                            FechaCreate = Pd.FechaCreate,
                            AnularCanon = Pd.AnuloCanon,
                            EstadoProveedor = Pd.EstadoProveedor,
                            ComentarioProveedor = Pd.ComentarioProveedor,
                            CostoMesas = Pd.CostoMesas,
                            CostoSillas = Pd.CostoSillas,
                            PrecioMesas = Pd.PrecioMesas,
                            PrecioSillas = Pd.PrecioSillas,
                            Royalty = Pd.Royalty
                        };

            List<PresupuestoDetalle> Salida = new List<PresupuestoDetalle>();
            foreach (var item in query)
            {

                PresupuestoDetalle cat = new PresupuestoDetalle();

                cat.Id = item.Id;
                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;
                cat.ServicioId = item.ServicioId;
                cat.LocacionId = item.LocacionId;
                cat.ProductoId = item.ProductoId;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.PrecioItem = item.PrecioItem;
                cat.PrecioLista = item.PrecioLista;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.CodigoItem = item.CodigoItem;
                cat.Descuentos = item.Descuentos;
                cat.Incremento = item.Incremento;
                cat.PrecioSeleccionado = item.PrecioSeleccionado;
                cat.PorcentajeComision = item.PorcentajeComision;
                cat.ValorSeleccionado = item.ValorSeleccionado;
                cat.Comision = item.Comision;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Costo = item.Costo;
                cat.Cannon = item.Cannon;
                cat.TipoLogisticaId = item.TipoLogisticaId;
                cat.TipoLogisticaDescripcion = item.TipoLogisticaDescripcion;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.CantInvitadosLogistica = item.CantInvitadosLogistica;
                cat.Logistica = item.Logistica;
                cat.UsoCocina = item.UsoCocina;
                cat.version = item.version;
                cat.EstadoId = item.EstadoId;
                cat.FechaAprobacion = item.FechaAprobacion;
                cat.ValorIntermediario = item.ValorIntermediario;


                cat.RentaUnNominal = CalcularRentaNominal(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                     (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.RentaUnPorcentaje = CalcularRentaPorcentaje(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                     (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));

                cat.Comentario = item.Comentario;

                cat.NuevoValor = (item.ValorSeleccionado - (item.Descuentos == null ? 0 : double.Parse(item.Descuentos.ToString())) + (item.Incremento == null ? 0 : double.Parse(item.Incremento.ToString())));

                cat.FechaCreate = item.FechaCreate;

                cat.AnuloCanon = item.AnularCanon;

                cat.EstadoProveedor = item.EstadoProveedor;
                cat.ComentarioProveedor = item.ComentarioProveedor;

                cat.CostoMesas = item.CostoMesas;
                cat.CostoSillas = item.CostoSillas;
                cat.PrecioMesas = item.PrecioMesas;
                cat.PrecioSillas = item.PrecioSillas;
                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            return Salida.Distinct().ToList();
        }

        public List<PresupuestoDetalle> BuscarDetallePresupuestoNoPagados(int PresupuestoId, string fechaEvento, string cliente)
        {
            int aprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());


            var query = from Pd in SqlContext.PresupuestoDetalle
                        join P in SqlContext.Productos on Pd.ProductoId equals P.Id
                        join Pe in SqlContext.Presupuestos on Pd.PresupuestoId equals Pe.Id
                        join E in SqlContext.Eventos on Pe.EventoId equals E.Id
                        join C in SqlContext.ClientesBis on E.ClienteBisId equals C.Id
                        join UN in SqlContext.UnidadesNegocios on Pd.UnidadNegocioId equals UN.Id
                        join Pr in SqlContext.Proveedores on Pd.ProveedorId equals Pr.Id into Prs
                        from Pr in Prs.DefaultIfEmpty()
                        join Tl in SqlContext.TipoLogistica on Pd.TipoLogisticaId equals Tl.Id into Tls
                        from Tl in Tls.DefaultIfEmpty()
                        join L in SqlContext.Localidades on Pd.LocalidadId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where Pd.EstadoId == aprobado
                        select new
                        {
                            Id = Pd.Id,
                            PresupuestoId = Pd.PresupuestoId,
                            UnidadNegocioId = Pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = UN.Descripcion,
                            ProveedorId = (Pd.ProveedorId == null ? null : Pd.ProveedorId),
                            ProveedorRazonSocial = Pr.RazonSocial,
                            ServicioId = (Pd.ServicioId == null ? null : Pd.ServicioId),
                            LocacionId = (Pd.LocacionId == null ? null : Pd.LocacionId),
                            ProductoId = Pd.ProductoId,
                            ProductoDescripcion = P.Descripcion,
                            PrecioItem = Pd.PrecioItem,
                            PrecioLista = Pd.PrecioLista,
                            PrecioMas5 = Pd.PrecioMas5,
                            PrecioMenos5 = Pd.PrecioMenos5,
                            PrecioMenos10 = Pd.PrecioMenos10,
                            CodigoItem = Pd.CodigoItem,
                            Descuentos = Pd.Descuentos,
                            Incremento = Pd.Incremento,
                            PrecioSeleccionado = Pd.PrecioSeleccionado,
                            PorcentajeComision = Pd.PorcentajeComision,
                            ValorSeleccionado = Pd.ValorSeleccionado,
                            Comision = Pd.Comision,
                            CantidadAdicional = Pd.CantidadAdicional,
                            Costo = Pd.Costo,
                            Cannon = Pd.Cannon,
                            TipoLogisticaId = (Pd.TipoLogisticaId == null ? null : Pd.TipoLogisticaId),
                            TipoLogisticaDescripcion = Tl.Concepto,
                            LocalidadId = (Pd.LocalidadId == null ? null : Pd.LocalidadId),
                            LocalidadDescripcion = L.Descripcion,
                            CantInvitadosLogistica = Pd.CantInvitadosLogistica,
                            Logistica = Pd.Logistica,
                            UsoCocina = Pd.UsoCocina,
                            version = Pd.version,
                            EstadoId = Pd.EstadoId,
                            RentaUnNominal = 0,
                            RentaUnPorcentaje = 0,
                            FechaAprobacion = Pd.FechaAprobacion,
                            ValorIntermediario = Pd.ValorIntermediario,
                            Comentario = Pd.Comentario,
                            FechaEvento = Pe.FechaEvento,
                            ClienteBisId = E.ClienteBisId,
                            ClienteNombre = (C.RazonSocial == "" ? C.ApellidoNombre : C.RazonSocial),
                            AnularCanon = Pd.AnuloCanon,
                            CostoMesas = Pd.CostoMesas,
                            CostoSillas = Pd.CostoSillas,
                            PrecioMesas = Pd.PrecioMesas,
                            PrecioSillas = Pd.PrecioSillas,
                            Royalty = Pd.Royalty

                        };


            List<PresupuestoDetalle> Salida = new List<PresupuestoDetalle>();
            foreach (var item in query)
            {

                PresupuestoDetalle cat = new PresupuestoDetalle();

                cat.Id = item.Id;
                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;
                cat.ServicioId = item.ServicioId;
                cat.LocacionId = item.LocacionId;
                cat.ProductoId = item.ProductoId;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.PrecioItem = item.PrecioItem;
                cat.PrecioLista = item.PrecioLista;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.CodigoItem = item.CodigoItem;
                cat.Descuentos = item.Descuentos;
                cat.Incremento = item.Incremento;
                cat.PrecioSeleccionado = item.PrecioSeleccionado;
                cat.PorcentajeComision = item.PorcentajeComision;
                cat.ValorSeleccionado = item.ValorSeleccionado;
                cat.Comision = item.Comision;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Costo = item.Costo;
                cat.Cannon = item.Cannon;
                cat.TipoLogisticaId = item.TipoLogisticaId;
                cat.TipoLogisticaDescripcion = item.TipoLogisticaDescripcion;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.CantInvitadosLogistica = item.CantInvitadosLogistica;
                cat.Logistica = item.Logistica;
                cat.UsoCocina = item.UsoCocina;
                cat.version = item.version;
                cat.EstadoId = item.EstadoId;
                cat.FechaAprobacion = item.FechaAprobacion;
                cat.ValorIntermediario = item.ValorIntermediario;


                cat.RentaUnNominal = CalcularRentaNominal(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                     (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.RentaUnPorcentaje = CalcularRentaPorcentaje(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                     (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));

                cat.Comentario = item.Comentario;

                cat.FechaEvento = item.FechaEvento;
                cat.ClienteBisId = item.ClienteBisId;
                cat.ClienteNombre = item.ClienteNombre;

                cat.AnuloCanon = item.AnularCanon;


                cat.CostoMesas = item.CostoMesas;
                cat.CostoSillas = item.CostoSillas;
                cat.PrecioMesas = item.PrecioMesas;
                cat.PrecioSillas = item.PrecioSillas;
                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            DateTime fecDesde;


            if (fechaEvento != "")
            {
                fecDesde = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Salida = Salida.Where(o => o.FechaEvento == fecDesde).ToList();

            }

            if (cliente != "")
            {
                Salida = Salida.Where(o => o.ClienteNombre.ToUpper().Contains(cliente.ToUpper())).ToList();
            }


            if (PresupuestoId > 0)
            {
                Salida = Salida.Where(o => o.PresupuestoId == PresupuestoId).ToList();
            }


            return Salida.Distinct().ToList();
        }

        private string ObtenerClientes(int? clienteId)
        {
            ClientesBis cliente = SqlContext.ClientesBis.Where(o => o.Id == clienteId).SingleOrDefault();

            if (cliente.ApellidoNombre != "")
            {
                return cliente.ApellidoNombre.ToUpper();
            }
            else if (cliente.RazonSocial != "")
            {
                return cliente.RazonSocial.ToUpper();
            }
            else
                return "";

        }

        public PresupuestoDetalle AddItem(PresupuestoDetalle detalle,
                                            Productos producto, int locacionId,
                                            int invitadosAdultos, int invitadosAdolescentes,
                                            int invitadosTotal, List<PresupuestoDetalle> list)
        {
            int CantidadInvitados = invitadosTotal;

            int CantidadAdultos = invitadosAdultos;
            int CantidadAdolescentes = invitadosAdolescentes;


            if (detalle.UnidadNegocioId == _rubroCatering)
            {
                detalle.UsoCocina = 0;

                AddItemCatering(detalle, CantidadInvitados, producto, locacionId);
            }
            else if (detalle.UnidadNegocioId == _rubroBarra)
            {
                detalle.UsoCocina = 0;

                AddItemBarra(detalle, CantidadAdultos, CantidadAdolescentes, CantidadInvitados, producto, locacionId, list);
            }
            else if (detalle.UnidadNegocioId == _rubroAmbientacion)
            {
                detalle.UsoCocina = 0;

                AddItemAmbientacion(detalle, CantidadAdultos, CantidadAdolescentes, CantidadInvitados, producto, locacionId);
            }

            else if (detalle.UnidadNegocioId == _rubroAdicional)
            {
                detalle.UsoCocina = 0;

                AddItemAdicional(detalle, CantidadAdultos, CantidadInvitados, producto);
            }
            else if (detalle.UnidadNegocioId == _rubroSalon)
            {
                detalle.UsoCocina = UsodeCocina(locacionId, detalle);
                RequiereMesasySillas(locacionId, CantidadInvitados, detalle);

                detalle.Costo = producto.Costo;

                detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto);
                detalle.Royalty = CalcularRoyalty(detalle.PrecioSeleccionado, producto);



                detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto);
                detalle.PrecioLista = CalcularPrecioVenta("PL", producto);
                detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto);
                detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto);
            }
            else
            {
                detalle.UsoCocina = 0;

                detalle.Costo = producto.Costo;

                detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto);

                detalle.Royalty = CalcularRoyalty(detalle.PrecioSeleccionado, producto);

                detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto);
                detalle.PrecioLista = CalcularPrecioVenta("PL", producto);
                detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto);
                detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto);

            }



            detalle.ValorSeleccionado = detalle.PrecioItem;


            //CALCULO VALOR INTERMEDIARIO SEGUN CORRESPONDA A LA LOCACION Y UNIDAD DE NEGOCIO
            detalle.ValorIntermediario = CalcularValorIntermediario(detalle.PrecioItem, detalle.UnidadNegocioId, locacionId);


            //CALCULO LA COMISION DEL ITEM SEGUN CORRESPONDA A LA UNIDAD DE NEGOCIO Y SI EL ITEM ES COMISIONABLE EN ESA LOCACION
            if (detalle.UnidadNegocioId == _rubroTecnica
                || detalle.UnidadNegocioId == _rubroAmbientacion
                || detalle.UnidadNegocioId == _rubroOrganizacion)
            {
                if (Comisiona(locacionId))
                {

                    detalle.Comision = GenerarComision(detalle.PrecioSeleccionado, detalle.PrecioItem, detalle.UnidadNegocioId, locacionId);
                    detalle.PorcentajeComision =
                        PorcentajeAdicional(detalle.PrecioSeleccionado, detalle.UnidadNegocioId, locacionId);
                }
                else
                {
                    detalle.Comision = detalle.PorcentajeComision = 0;
                }

            }
            else //SIEMPRE COMISIONA (CATERING - BARRA - ADICIONALES)
            {

                detalle.Comision = GenerarComision(detalle.PrecioSeleccionado, detalle.PrecioItem, detalle.UnidadNegocioId, locacionId);
                detalle.PorcentajeComision =
                    PorcentajeAdicional(detalle.PrecioSeleccionado, detalle.UnidadNegocioId, locacionId);
            }


            return detalle;
        }

        private void AddItemAmbientacion(PresupuestoDetalle detalle, int CantidadAdultos, int CantidadAdolescentes, int CantidadInvitados, Productos producto, int locacionId)
        {

            detalle.Costo = producto.Costo;

            detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto);
            detalle.Royalty = CalcularRoyalty(detalle.PrecioSeleccionado, producto);

            detalle.Cannon = ValorCanon(locacionId, detalle, CantidadInvitados, detalle.PrecioItem);

            detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto);
            detalle.PrecioLista = CalcularPrecioVenta("PL", producto);
            detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto);
            detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto);
        }

        private void AddItemAdicional(PresupuestoDetalle detalle, int CantidadAdultos, int CantidadInvitados, Productos producto)
        {
            AdicionalesDatos datosAdicionales = new AdicionalesDatos();

            Adicionales adi = datosAdicionales.BuscarAdicional((int)detalle.ServicioId);

            //Presupuestos presuLocacion = SqlContext.Presupuestos.Single(o => o.Id == detalle.PresupuestoId);

            Locaciones locTipoCanon = SqlContext.Locaciones.Single(o => o.Id == detalle.LocacionId);

            switch (adi.RubroId)
            {
                case 1: //ADICIONAL AMBIENTACION
                    AgregarAdicional(detalle, CantidadAdultos, CantidadInvitados, producto, adi, locTipoCanon);
                    break;

                case 3://ADICIONAL CATERING
                    AgregarAdicional(detalle, CantidadAdultos, CantidadInvitados, producto, adi, locTipoCanon);
                    break;

                case 6://ADICIONAL BARRA
                    AgregarAdicional(detalle, CantidadAdultos, CantidadInvitados, producto, adi, locTipoCanon);
                    break;
                default:
                    AgregarAdicional(detalle, CantidadAdultos, CantidadInvitados, producto, adi);
                    break;
            }




        }

        private void AgregarAdicional(PresupuestoDetalle detalle, int CantidadAdultos, int CantidadInvitados, Productos producto, Adicionales adi, Locaciones locTipoCanon)
        {

            double coeficienteRoyalty = ((double.Parse(producto.Royalty.ToString())) / 100 + 1);
            double porcentajecoeficienteRoyalty = ((double.Parse(producto.Royalty.ToString())) / 100);


            if (adi.SoloMayores == "S")
            {
                if (CantidadAdultos > 0)
                {
                    if (adi.RequiereCantidad == "S" || adi.RequiereCantidadRango == "S")
                    {
                        if (detalle.CantidadAdicional > 0)
                        {



                            detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * (int)detalle.CantidadAdicional);
                            detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * (int)detalle.CantidadAdicional);

                            detalle.Costo = (producto.Costo * detalle.CantidadAdicional);
                            detalle.CantidadAdicional = detalle.CantidadAdicional;

                            detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * (int)detalle.CantidadAdicional;
                            detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * (int)detalle.CantidadAdicional;
                            detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * (int)detalle.CantidadAdicional;
                            detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * (int)detalle.CantidadAdicional;




                        }
                        else
                        {
                            detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * 1);
                            detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * 1);

                            detalle.Costo = (producto.Costo * 1);
                            detalle.CantidadAdicional = 1;

                            detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * 1;
                            detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * 1;
                            detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * 1;
                            detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * 1;
                        }
                    }
                    else
                    {
                        detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * CantidadAdultos);
                        detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * CantidadAdultos);
                        detalle.Costo = (producto.Costo * CantidadAdultos);
                        detalle.CantidadAdicional = CantidadAdultos;

                        detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadAdultos;
                        detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadAdultos;
                        detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadAdultos;
                        detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadAdultos;
                    }

                }
            }
            else
            {
                if (adi.RequiereCantidad == "S" || adi.RequiereCantidadRango == "S")
                {
                    if (detalle.CantidadAdicional > 0)
                    {
                        detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * (int)detalle.CantidadAdicional);
                        detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * (int)detalle.CantidadAdicional);
                        detalle.Costo = (producto.Costo * detalle.CantidadAdicional);
                        detalle.CantidadAdicional = detalle.CantidadAdicional;

                        detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * (int)detalle.CantidadAdicional;
                        detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * (int)detalle.CantidadAdicional;
                        detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * (int)detalle.CantidadAdicional;
                        detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * (int)detalle.CantidadAdicional;
                    }
                    else
                    {
                        detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * 1);
                        detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * 1);
                        detalle.Costo = (producto.Costo * 1);
                        detalle.CantidadAdicional = 1;

                        detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * 1;
                        detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * 1;
                        detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * 1;
                        detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * 1;
                    }
                }

                else
                {
                    detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * CantidadInvitados);
                    detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * CantidadInvitados);
                    detalle.Costo = (producto.Costo * CantidadInvitados);
                    detalle.CantidadAdicional = CantidadInvitados;

                    detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadInvitados;
                    detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadInvitados;
                    detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadInvitados;
                    detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadInvitados;
                }
            }


            if (adi.RubroId == 1 && locTipoCanon.TipoCannonAmbientacion == "Porcentaje")
            {
                detalle.Cannon = detalle.PrecioItem * ((locTipoCanon.CannonAmbientacion) / 100);
            }
            else if (adi.RubroId == 3 && locTipoCanon.TipoCannonCatering == "Porcentaje")
            {
                detalle.Cannon = detalle.PrecioItem * ((locTipoCanon.Cannon) / 100);
            }
            else if (adi.RubroId == 6 && locTipoCanon.TipoCannonBarra == "Porcentaje")
            {
                detalle.Cannon = detalle.PrecioItem * ((locTipoCanon.CannonBarra) / 100);
            }



        }

        private void AgregarAdicional(PresupuestoDetalle detalle, int CantidadAdultos, int CantidadInvitados, Productos producto, Adicionales adi)
        {

            double coeficienteRoyalty = ((double.Parse(producto.Royalty.ToString())) / 100 + 1);
            double porcentajecoeficienteRoyalty = ((double.Parse(producto.Royalty.ToString())) / 100);


            if (adi.SoloMayores == "S")
            {
                if (CantidadAdultos > 0)
                {
                    if (adi.RequiereCantidad == "S" || adi.RequiereCantidadRango == "S")
                    {
                        if (detalle.CantidadAdicional > 0)
                        {
                            detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * (int)detalle.CantidadAdicional);
                            detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * (int)detalle.CantidadAdicional);

                            detalle.Costo = (producto.Costo * detalle.CantidadAdicional);
                            detalle.CantidadAdicional = detalle.CantidadAdicional;

                            detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * (int)detalle.CantidadAdicional;
                            detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * (int)detalle.CantidadAdicional;
                            detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * (int)detalle.CantidadAdicional;
                            detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * (int)detalle.CantidadAdicional;
                        }
                        else
                        {
                            detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * 1);
                            detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * 1);
                            detalle.Costo = (producto.Costo * 1);
                            detalle.CantidadAdicional = 1;

                            detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * 1;
                            detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * 1;
                            detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * 1;
                            detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * 1;
                        }
                    }
                    else
                    {
                        detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * CantidadAdultos);
                        detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * CantidadAdultos);

                        detalle.Costo = (producto.Costo * CantidadAdultos);
                        detalle.CantidadAdicional = CantidadAdultos;

                        detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadAdultos;
                        detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadAdultos;
                        detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadAdultos;
                        detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadAdultos;
                    }

                }
            }
            else
            {
                if (adi.RequiereCantidad == "S" || adi.RequiereCantidadRango == "S")
                {
                    if (detalle.CantidadAdicional > 0)
                    {
                        detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * (int)detalle.CantidadAdicional);
                        detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * (int)detalle.CantidadAdicional);

                        detalle.Costo = (producto.Costo * detalle.CantidadAdicional);
                        detalle.CantidadAdicional = detalle.CantidadAdicional;

                        detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * (int)detalle.CantidadAdicional;
                        detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * (int)detalle.CantidadAdicional;
                        detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * (int)detalle.CantidadAdicional;
                        detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * (int)detalle.CantidadAdicional;
                    }
                    else
                    {
                        detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * 1);
                        detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * 1);
                        detalle.Costo = (producto.Costo * 1);
                        detalle.CantidadAdicional = 1;

                        detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * 1;
                        detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * 1;
                        detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * 1;
                        detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * 1;
                    }
                }

                else
                {
                    detalle.PrecioItem = ((producto.Precio * coeficienteRoyalty) * CantidadInvitados);
                    detalle.Royalty = ((producto.Precio * porcentajecoeficienteRoyalty) * CantidadInvitados);
                    detalle.Costo = (producto.Costo * CantidadInvitados);
                    detalle.CantidadAdicional = CantidadInvitados;

                    detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadInvitados;
                    detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadInvitados;
                    detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadInvitados;
                    detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadInvitados;
                }
            }
        }

        private void AddItemBarra(PresupuestoDetalle detalle, int CantidadAdultos, int CantidadAdolescentes, int CantidadTotal, Productos producto, int locacionId, List<PresupuestoDetalle> list)
        {
            TipoBarrasDatos tipoBarraDatos = new TipoBarrasDatos();

            TiposBarras tb = tipoBarraDatos.BuscarTipoBarras((int)detalle.ServicioId);

            //if (list.Where(o => o.UnidadNegocioId == _rubroBarra && (tb.RangoEtareo == "MENORES").Count() == 0)
            //{
            //    int TotalInvitados = CantidadAdultos + CantidadAdolescentes;

            //    detalle.Costo = producto.Costo * TotalInvitados;

            //    detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto) * TotalInvitados;

            //    detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * TotalInvitados;
            //    detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * TotalInvitados;
            //    detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * TotalInvitados;
            //    detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * TotalInvitados;

            //    detalle.CantidadAdicional = TotalInvitados;
            //}
            //else
            //{

            if (tb.RangoEtareo == "ADULTOS")
            {
                detalle.Costo = producto.Costo * CantidadAdultos;

                detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto) * CantidadAdultos;
                detalle.Royalty = CalcularRoyalty(detalle.PrecioSeleccionado, producto) * CantidadAdultos;

                detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadAdultos;
                detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadAdultos;
                detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadAdultos;
                detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadAdultos;

                detalle.CantidadAdicional = CantidadAdultos;
            }
            else
            {
                detalle.Costo = producto.Costo * CantidadAdolescentes;

                detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto) * CantidadAdolescentes;
                detalle.Royalty = CalcularRoyalty(detalle.PrecioSeleccionado, producto) * CantidadAdolescentes;

                detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadAdolescentes;
                detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadAdolescentes;
                detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadAdolescentes;
                detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadAdolescentes;

                detalle.CantidadAdicional = CantidadAdolescentes;
            }
            //}

            detalle.Cannon = ValorCanon(locacionId, detalle, CantidadTotal, detalle.PrecioItem);
        }

        private void AddItemCatering(PresupuestoDetalle detalle, int CantidadInvitados, Productos producto, int locacionId)
        {
            detalle.Costo = producto.Costo * CantidadInvitados;

            detalle.PrecioItem = CalcularPrecioVenta(detalle.PrecioSeleccionado, producto) * CantidadInvitados;
            detalle.Royalty = CalcularRoyalty(detalle.PrecioSeleccionado, producto) * CantidadInvitados;

            detalle.Cannon = ValorCanon(locacionId, detalle, CantidadInvitados, detalle.PrecioItem);

            detalle.PrecioMas5 = CalcularPrecioVenta("PL + 5%", producto) * CantidadInvitados;
            detalle.PrecioLista = CalcularPrecioVenta("PL", producto) * CantidadInvitados;
            detalle.PrecioMenos5 = CalcularPrecioVenta("PL - 5%", producto) * CantidadInvitados;
            detalle.PrecioMenos10 = CalcularPrecioVenta("PL - 10%", producto) * CantidadInvitados;
        }

        public double TotalDetallePresupuesto(int presupuestoId)
        {

            return 1;
        }

        private double GenerarComision(string precio, double total, int unidadNegocioId, int locacionId)
        {

            LocacionesDatos datosLocacion = new LocacionesDatos();

            Locaciones loc = datosLocacion.BuscarLocaciones(locacionId);


            string ComisionPLMas5;
            string ComisionPL;
            string comisionPLMenos5;
            string comisionPLMenos10;

            if (unidadNegocioId == _rubroSalon)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionSalonPL+5";
                    ComisionPL = "ComisionSalonPL";
                    comisionPLMenos5 = "ComisionSalonPL-5";
                    comisionPLMenos10 = "ComisionSalonPL-10";
                }
                else
                    return 0;
            }
            else if (unidadNegocioId == _rubroCatering)
            {
                ComisionPLMas5 = "ComisionCateringPL+5";
                ComisionPL = "ComisionCateringPL";
                comisionPLMenos5 = "ComisionCateringPL-5";
                comisionPLMenos10 = "ComisionCateringPL-10";
            }
            else if (unidadNegocioId == _rubroBarra)
            {
                ComisionPLMas5 = "ComisionBarraPL+5";
                ComisionPL = "ComisionBarraPL";
                comisionPLMenos5 = "ComisionBarraPL-5";
                comisionPLMenos10 = "ComisionBarraPL-10";
            }
            else if (unidadNegocioId == _rubroTecnica)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionTecnicaPL+5";
                    ComisionPL = "ComisionTecnicaPL";
                    comisionPLMenos5 = "ComisionTecnicaPL-5";
                    comisionPLMenos10 = "ComisionTecnicaPL-10";
                }
                else
                    return 0;
            }
            else if (unidadNegocioId == _rubroOrganizacion)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionOrganizacionPL+5";
                    ComisionPL = "ComisionOrganizacionPL";
                    comisionPLMenos5 = "ComisionOrganizacionPL-5";
                    comisionPLMenos10 = "ComisionOrganizacionPL-10";
                }
                else
                    return 0;
            }
            else if (unidadNegocioId == _rubroAmbientacion)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionAmbientacionPL+5";
                    ComisionPL = "ComisionAmbientacionPL";
                    comisionPLMenos5 = "ComisionAmbientacionPL-5";
                    comisionPLMenos10 = "ComisionAmbientacionPL-10";
                }
                else
                    return 0;
            }
            else
            {
                ComisionPLMas5 = "";
                ComisionPL = "";
                comisionPLMenos5 = "";
                comisionPLMenos10 = "";
            }



            ComisionesDatos datosComisiones = new ComisionesDatos();

            List<Comisiones> comisiones = datosComisiones.ObtenerComisiones();


            if (precio == "PL + 5%")
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPLMas5)).FirstOrDefault();

                return total * (query.Porcentaje / 100);

            }
            else if (precio == "PL")
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPL)).FirstOrDefault();

                return total * (query.Porcentaje / 100);

            }
            else if (precio == "PL - 5%")
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos5)).FirstOrDefault();

                return total * (query.Porcentaje / 100);

            }
            else
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos10)).FirstOrDefault();

                return total * (query.Porcentaje / 100);

            }


        }

        private double PorcentajeAdicional(string precio, int unidadNegocioId, int locacionId)
        {
            LocacionesDatos datosLocacion = new LocacionesDatos();

            Locaciones loc = datosLocacion.BuscarLocaciones(locacionId);


            string ComisionPLMas5;
            string ComisionPL;
            string comisionPLMenos5;
            string comisionPLMenos10;

            if (unidadNegocioId == _rubroSalon)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionSalonPL+5";
                    ComisionPL = "ComisionSalonPL";
                    comisionPLMenos5 = "ComisionSalonPL-5";
                    comisionPLMenos10 = "ComisionSalonPL-10";
                }
                else
                    return 0;
            }
            else if (unidadNegocioId == _rubroCatering)
            {
                ComisionPLMas5 = "ComisionCateringPL+5";
                ComisionPL = "ComisionCateringPL";
                comisionPLMenos5 = "ComisionCateringPL-5";
                comisionPLMenos10 = "ComisionCateringPL-10";
            }
            else if (unidadNegocioId == _rubroBarra)
            {
                ComisionPLMas5 = "ComisionBarraPL+5";
                ComisionPL = "ComisionBarraPL";
                comisionPLMenos5 = "ComisionBarraPL-5";
                comisionPLMenos10 = "ComisionBarraPL-10";
            }
            else if (unidadNegocioId == _rubroTecnica)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionTecnicaPL+5";
                    ComisionPL = "ComisionTecnicaPL";
                    comisionPLMenos5 = "ComisionTecnicaPL-5";
                    comisionPLMenos10 = "ComisionTecnicaPL-10";
                }
                else
                    return 0;
            }
            else if (unidadNegocioId == _rubroAmbientacion)
            {
                if (loc.Comisiona == "S")
                {
                    ComisionPLMas5 = "ComisionAmbientacionPL+5";
                    ComisionPL = "ComisionAmbientacionPL";
                    comisionPLMenos5 = "ComisionAmbientacionPL-5";
                    comisionPLMenos10 = "ComisionAmbientacionPL-10";
                }
                else
                    return 0;
            }
            else
            {
                ComisionPLMas5 = "";
                ComisionPL = "";
                comisionPLMenos5 = "";
                comisionPLMenos10 = "";
            }


            ComisionesDatos datosComisiones = new ComisionesDatos();

            List<Comisiones> comisiones = datosComisiones.ObtenerComisiones();

            if (precio == "PL + 5")
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPLMas5)).FirstOrDefault();

                return query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));

            }
            else if (precio == "PL")
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(ComisionPL)).FirstOrDefault();

                return query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));

            }
            else if (precio == "PL - 5")
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos5)).FirstOrDefault();

                return query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));

            }
            else
            {

                var query = comisiones.Where(o => o.Descripcion.Contains(comisionPLMenos10)).FirstOrDefault();

                return query.Porcentaje + (query.PorcentajeAdicional == null ? 0 : double.Parse(query.PorcentajeAdicional.ToString()));

            }


        }

        private double CalcularValorIntermediario(double total, int unidadNegocioId, int locacionId)
        {
            IntermediariosDatos datosIntermediarios = new IntermediariosDatos();

            List<Intermediarios> ListIntermediarios = datosIntermediarios.BuscarValoresIntermediariosPorLocacion(locacionId);

            Intermediarios intermediario = ListIntermediarios.Where(o => o.UnidadNegocioId == unidadNegocioId).SingleOrDefault();

            double valorIntermediario = 0;

            if (intermediario != null)
            {
                if (intermediario.TipoComision == "Porcentaje")
                {
                    valorIntermediario = (total) * (double.Parse(intermediario.Porcentaje.ToString()) / 100);
                }
                else
                {
                    valorIntermediario = (total) + (double.Parse(intermediario.Valor.ToString()));
                }

            }

            return valorIntermediario;
        }

        private double CalcularPrecioVenta(string precio, Productos producto)
        {

            double PLMenos5 = double.Parse(ConfigurationManager.AppSettings["PLMENOS5"].ToString());

            double PLMenos10 = double.Parse(ConfigurationManager.AppSettings["PLMENOS10"].ToString());

            double coeficienteRoyalty = ((double.Parse(producto.Royalty.ToString())) / 100 + 1);

            if (precio != null)
            {
                if (precio == "PL - 10%")
                {
                    return producto.Precio * coeficienteRoyalty;
                }
                else if (precio == "PL - 5%")
                {
                    return (producto.Precio / PLMenos5) * coeficienteRoyalty;
                }
                else if (precio == "PL")
                {
                    return (producto.Precio / PLMenos10) * coeficienteRoyalty;
                }
                else if (precio == "PL + 5%")
                {
                    return ((producto.Precio / PLMenos10 / PLMenos5) * coeficienteRoyalty);
                }
            }
            return 0;

        }

        private double CalcularRoyalty(string precio, Productos producto)
        {

            double PLMenos5 = double.Parse(ConfigurationManager.AppSettings["PLMENOS5"].ToString());

            double PLMenos10 = double.Parse(ConfigurationManager.AppSettings["PLMENOS10"].ToString());

            double coeficienteRoyalty = ((double.Parse(producto.Royalty.ToString())) / 100);

            if (precio != null)
            {
                if (precio == "PL - 10%")
                {
                    return producto.Precio * coeficienteRoyalty;
                }
                else if (precio == "PL - 5%")
                {
                    return (producto.Precio / PLMenos5) * coeficienteRoyalty;
                }
                else if (precio == "PL")
                {
                    return (producto.Precio / PLMenos10) * coeficienteRoyalty;
                }
                else if (precio == "PL + 5%")
                {
                    return ((producto.Precio / PLMenos10 / PLMenos5) * coeficienteRoyalty);
                }
            }
            return 0;

        }
        private bool Comisiona(int locacionId)
        {
            LocacionesDatos locaciones = new LocacionesDatos();
            Locaciones loc = locaciones.BuscarLocaciones(locacionId);

            return (loc.Comisiona == "S");

        }

        private double? ValorCanon(int locacionId, PresupuestoDetalle detalle, int cantidadInvitados, double totalPrecio)
        {
            if (detalle.CannonCatering > 0 && detalle.UnidadNegocioId == _rubroCatering)
            {
                if (detalle.TipoCanonCatering == "Persona")
                {
                    return detalle.CannonCatering * cantidadInvitados;
                }
                else if (detalle.TipoCanonCatering == "Porcentaje")
                {
                    return (totalPrecio * (detalle.CannonCatering / 100));
                }
                else
                {
                    return detalle.CannonCatering;
                }
            }
            if (detalle.CannonBarra > 0 && detalle.UnidadNegocioId == _rubroBarra)
            {
                if (detalle.TipoCanonBarra == "Persona")
                {
                    return detalle.CannonBarra * cantidadInvitados;
                }
                else if (detalle.TipoCanonBarra == "Porcentaje")
                {
                    return (totalPrecio * (detalle.CannonBarra / 100));
                }
                else
                {
                    return detalle.CannonBarra;
                }

            }
            if (detalle.CannonAmbientacion > 0 && detalle.UnidadNegocioId == _rubroAmbientacion)
            {
                if (detalle.TipoCanonAmbientacion == "Persona")
                {
                    return detalle.CannonAmbientacion * cantidadInvitados;
                }
                else if (detalle.TipoCanonAmbientacion == "Porcentaje")
                {
                    return (totalPrecio * (detalle.CannonAmbientacion / 100));
                }
                else
                {
                    return detalle.CannonAmbientacion;
                }


            }

            int LocacionLahusen = Int32.Parse(ConfigurationManager.AppSettings["Lahusen"].ToString());
            int LocacionTerrazas = Int32.Parse(ConfigurationManager.AppSettings["TOM"].ToString());
            int ProveedorCateringAmbient = Int32.Parse(ConfigurationManager.AppSettings["ProveedorCateringAmbient"].ToString());

            LocacionesDatos locaciones = new LocacionesDatos();
            Locaciones loc = locaciones.BuscarLocaciones(locacionId);

            if ((loc.Id == LocacionLahusen || loc.Id == LocacionTerrazas) && detalle.ProveedorId == ProveedorCateringAmbient && detalle.UnidadNegocioId == _rubroCatering)
            {
                CostosDatos costo = new CostosDatos();
                CostoCanon costoCanon = costo.BuscarCostoCanon(detalle.SegmentoId,
                    detalle.CarasteristicaId,
                    Int32.Parse(detalle.ServicioId.ToString()));


                if (costoCanon != null)
                    return double.Parse(costoCanon.CanonInterno.ToString()) * cantidadInvitados;
                else
                    return 0;
            }
            else if (detalle.UnidadNegocioId == _rubroCatering)
            {
                if (loc.TipoCannonCatering == "Persona")
                    return loc.Cannon * cantidadInvitados;
                else if (loc.TipoCannonCatering == "Porcentaje")
                    return (totalPrecio * (loc.Cannon / 100));
                else
                    return (loc.Cannon);
            }

            else if (detalle.UnidadNegocioId == _rubroBarra)
            {
                if (loc.TipoCannonBarra == "Persona")
                    return loc.CannonBarra * cantidadInvitados;
                else if (loc.TipoCannonBarra == "Porcentaje")
                    return (totalPrecio * (loc.CannonBarra / 100));
                else
                    return (loc.CannonBarra);
            }

            else if (detalle.UnidadNegocioId == _rubroAmbientacion)
            {
                if (loc.TipoCannonAmbientacion == "Persona")
                    return loc.CannonAmbientacion * cantidadInvitados;
                else if (loc.TipoCannonAmbientacion == "Porcentaje")
                    return (totalPrecio * (loc.CannonAmbientacion / 100));
                else
                    return (loc.CannonAmbientacion);
            }

            return 0;

        }

        private double? UsodeCocina(int locacionId, PresupuestoDetalle detalle)
        {

            if (detalle.UsoCocina > 0)
                return detalle.UsoCocina;

            LocacionesDatos locaciones = new LocacionesDatos();
            Locaciones loc = locaciones.BuscarLocaciones(locacionId);

            return loc.UsoCocina;
        }

        private void RequiereMesasySillas(int locacionId, int cantidadPax, PresupuestoDetalle detalle)
        {
            int FORMAL = Int32.Parse(ConfigurationManager.AppSettings["Formal"].ToString()); ;

            LocacionesDatos locaciones = new LocacionesDatos();
            Locaciones loc = locaciones.BuscarLocaciones(locacionId);

            if (loc.RequiereMesasSillas && detalle.CarasteristicaId == FORMAL)
            {
                double CostoSillas = cantidadPax * (double)loc.CostoSillas;
                double CostoMesas = cantidadPax / 10 * (double)loc.CostoMesas;

                double PrecioSillas = cantidadPax * (double)loc.PrecioSillas;
                double PrecioMesas = cantidadPax / 10 * (double)loc.PrecioMesas;

                detalle.CostoSillas = CostoSillas;
                detalle.CostoMesas = CostoMesas;
                detalle.PrecioSillas = PrecioSillas;
                detalle.PrecioMesas = PrecioMesas;

            }

        }

        public void EliminarPresupuestoDetalle(List<PresupuestoDetalle> ListPresupuestoDetalleQuitados)
        {
            foreach (var item in ListPresupuestoDetalleQuitados)
            {

                var itemRemove = SqlContext.PresupuestoDetalle.Where(o => o.Id == item.Id).SingleOrDefault();

                SqlContext.PresupuestoDetalle.Remove(itemRemove);
                SqlContext.SaveChanges();

            }
        }

        public PresupuestoDetalle AprobarItemPresupuesto(int detalleId)
        {

            int aprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            if (detalleId > 0)
            {
                PresupuestoDetalle editDetalle = SqlContext.PresupuestoDetalle.Where(o => o.Id == detalleId).SingleOrDefault();

                if (editDetalle.UnidadNegocioId == 10)
                {
                    Presupuestos presu = SqlContext.Presupuestos.Where(o => o.Id == editDetalle.PresupuestoId).SingleOrDefault();

                    presu.CantidadInicialInvitados = presu.CantidadInicialInvitados + (presu.CantidadAdultosFinal != null ? presu.CantidadAdultosFinal : 0);
                    presu.CantidadInvitadosAdolecentes = (presu.CantidadInvitadosAdolecentes != null ? presu.CantidadInvitadosAdolecentes : 0) + (presu.CantidadAdolescentesFinal != null ? presu.CantidadAdolescentesFinal : 0);
                    presu.CantidadInvitadosMenores3 = (presu.CantidadInvitadosMenores3 != null ? presu.CantidadInvitadosMenores3 : 0) + (presu.CantidadMenores3Final != null ? presu.CantidadMenores3Final : 0);
                    presu.CantidadInvitadosMenores3y8 = (presu.CantidadInvitadosMenores3y8 != null ? presu.CantidadInvitadosMenores3y8 : 0) + (presu.CantidadMenoresEntre3y8Final != null ? presu.CantidadMenoresEntre3y8Final : 0);

                    presu.CantidadAdultosFinal = 0;
                    presu.CantidadAdolescentesFinal = 0;
                    presu.CantidadMenores3Final = 0;
                    presu.CantidadMenoresEntre3y8Final = 0;

                    editDetalle.EstadoId = aprobado;

                }
                else
                {
                    editDetalle.EstadoId = aprobado;
                }


                SqlContext.SaveChanges();

                return editDetalle;

            }

            return new PresupuestoDetalle();


        }

        public PresupuestoDetalle BuscarPresupuestoDetalle(int id)
        {

            var query = from Pd in SqlContext.PresupuestoDetalle
                        join P in SqlContext.Productos on Pd.ProductoId equals P.Id
                        join UN in SqlContext.UnidadesNegocios on Pd.UnidadNegocioId equals UN.Id
                        join Pr in SqlContext.Proveedores on Pd.ProveedorId equals Pr.Id into Prs
                        from Pr in Prs.DefaultIfEmpty()
                        join Tl in SqlContext.TipoLogistica on Pd.TipoLogisticaId equals Tl.Id into Tls
                        from Tl in Tls.DefaultIfEmpty()
                        join L in SqlContext.Localidades on Pd.LocalidadId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where Pd.Id == id
                        select new
                        {

                            Id = Pd.Id,
                            PresupuestoId = Pd.PresupuestoId,
                            UnidadNegocioId = Pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = UN.Descripcion,
                            ProveedorId = (Pd.ProveedorId == null ? null : Pd.ProveedorId),
                            ProveedorRazonSocial = Pr.RazonSocial,
                            ServicioId = (Pd.ServicioId == null ? null : Pd.ServicioId),
                            LocacionId = (Pd.LocacionId == null ? null : Pd.LocacionId),
                            ProductoId = Pd.ProductoId,
                            ProductoDescripcion = P.Descripcion,
                            PrecioItem = Pd.PrecioItem,
                            PrecioLista = Pd.PrecioLista,
                            PrecioMas5 = Pd.PrecioMas5,
                            PrecioMenos5 = Pd.PrecioMenos5,
                            PrecioMenos10 = Pd.PrecioMenos10,
                            CodigoItem = Pd.CodigoItem,
                            Descuentos = Pd.Descuentos,
                            Incremento = Pd.Incremento,
                            PrecioSeleccionado = Pd.PrecioSeleccionado,
                            PorcentajeComision = Pd.PorcentajeComision,
                            ValorSeleccionado = Pd.ValorSeleccionado,
                            Comision = Pd.Comision,
                            CantidadAdicional = Pd.CantidadAdicional,
                            Costo = Pd.Costo,
                            Cannon = Pd.Cannon,
                            TipoLogisticaId = (Pd.TipoLogisticaId == null ? null : Pd.TipoLogisticaId),
                            TipoLogisticaDescripcion = Tl.Concepto,
                            LocalidadId = (Pd.LocalidadId == null ? null : Pd.LocalidadId),
                            LocalidadDescripcion = L.Descripcion,
                            CantInvitadosLogistica = Pd.CantInvitadosLogistica,
                            Logistica = Pd.Logistica,
                            UsoCocina = Pd.UsoCocina,
                            version = Pd.version,
                            EstadoId = Pd.EstadoId,
                            RentaUnNominal = 0,
                            RentaUnPorcentaje = 0,
                            FechaAprobacion = Pd.FechaAprobacion,
                            ValorIntermediario = Pd.ValorIntermediario,
                            Comentario = Pd.Comentario,
                            NuevoValor = 0,
                            FechaCreate = Pd.FechaCreate,
                            AnularCanon = Pd.AnuloCanon,
                            EstadoProveedpr = Pd.EstadoProveedor,
                            ComentarioProveedor = Pd.ComentarioProveedor,
                            CostoMesas = Pd.CostoMesas,
                            CostoSillas = Pd.CostoSillas,
                            PrecioMesas = Pd.PrecioMesas,
                            PrecioSillas = Pd.PrecioSillas,
                            Royalty = Pd.Royalty

                        };

            List<PresupuestoDetalle> Salida = new List<PresupuestoDetalle>();
            foreach (var item in query)
            {

                PresupuestoDetalle cat = new PresupuestoDetalle();

                cat.Id = item.Id;
                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.ProveedorRazonSocial = item.ProveedorRazonSocial;
                cat.ServicioId = item.ServicioId;
                cat.LocacionId = item.LocacionId;
                cat.ProductoId = item.ProductoId;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.PrecioItem = item.PrecioItem;
                cat.PrecioLista = item.PrecioLista;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.CodigoItem = item.CodigoItem;
                cat.Descuentos = item.Descuentos;
                cat.Incremento = item.Incremento;
                cat.PrecioSeleccionado = item.PrecioSeleccionado;
                cat.PorcentajeComision = item.PorcentajeComision;
                cat.ValorSeleccionado = item.ValorSeleccionado;
                cat.Comision = item.Comision;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Costo = item.Costo;
                cat.Cannon = item.Cannon;
                cat.TipoLogisticaId = item.TipoLogisticaId;
                cat.TipoLogisticaDescripcion = item.TipoLogisticaDescripcion;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.CantInvitadosLogistica = item.CantInvitadosLogistica;
                cat.Logistica = item.Logistica;
                cat.UsoCocina = item.UsoCocina;
                cat.version = item.version;
                cat.EstadoId = item.EstadoId;
                cat.FechaAprobacion = item.FechaAprobacion;
                cat.ValorIntermediario = item.ValorIntermediario;


                cat.RentaUnNominal = CalcularRentaNominal(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                     (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));
                cat.RentaUnPorcentaje = CalcularRentaPorcentaje(double.Parse(item.Costo.ToString()), double.Parse(item.ValorSeleccionado.ToString()), item.Comision,
                                    (cat.Incremento == null ? 0 : double.Parse(cat.Incremento.ToString())),
                                     (cat.Descuentos == null ? 0 : double.Parse(cat.Descuentos.ToString())));

                cat.Comentario = item.Comentario;

                cat.NuevoValor = (item.ValorSeleccionado - (item.Descuentos == null ? 0 : double.Parse(item.Descuentos.ToString())) + (item.Incremento == null ? 0 : double.Parse(item.Incremento.ToString())));

                cat.FechaCreate = item.FechaCreate;

                cat.AnuloCanon = item.AnularCanon;

                cat.EstadoProveedor = item.EstadoProveedpr;
                cat.ComentarioProveedor = item.ComentarioProveedor;


                cat.CostoMesas = item.CostoMesas;
                cat.CostoSillas = item.CostoSillas;
                cat.PrecioMesas = item.PrecioMesas;
                cat.PrecioSillas = item.PrecioSillas;
                cat.Royalty = item.Royalty;

                Salida.Add(cat);
            }

            return Salida.FirstOrDefault();
        }

        internal bool ActualizarCobroItem(int Id)
        {
            int cobrado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleCobrado"].ToString()); ;

            if (Id > 0)
            {
                PresupuestoDetalle edit = SqlContext.PresupuestoDetalle.Where(o => o.Id == Id).SingleOrDefault();

                edit.EstadoId = cobrado;
                edit.FechaCobroItem = DateTime.Now;

                SqlContext.SaveChanges();

                return true;
            }

            return false;
        }

        internal void GrabarPresupuestoDetalle(PresupuestoDetalle detalle)
        {
            if (detalle.Id > 0)
            {
                PresupuestoDetalle edit = SqlContext.PresupuestoDetalle.Where(o => o.Id == detalle.Id).FirstOrDefault();

                edit.EstadoProveedor = detalle.EstadoProveedor;
                edit.ComentarioProveedor = detalle.ComentarioProveedor;
                edit.FechaUpdate = System.DateTime.Now;
                edit.Cannon = detalle.Cannon;
                edit.AnuloCanon = detalle.AnuloCanon;

                SqlContext.SaveChanges();

            }
            else
            {

            }
        }

        internal bool GrabarPresupuestoDetalleRevisado(PresupuestoDetalle detalle)
        {
            if (detalle.Id > 0)
            {

                try
                {
                    PresupuestoDetalle edit = SqlContext.PresupuestoDetalle.Where(o => o.Id == detalle.Id).FirstOrDefault();

                    edit.ValorSeleccionado = detalle.ValorSeleccionado;
                    edit.Costo = detalle.Costo;
                    edit.Cannon = detalle.Cannon;
                    edit.Logistica = detalle.Logistica;
                    edit.ValorIntermediario = detalle.ValorIntermediario;
                    edit.UsoCocina = detalle.UsoCocina;

                    edit.FechaUpdate = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
