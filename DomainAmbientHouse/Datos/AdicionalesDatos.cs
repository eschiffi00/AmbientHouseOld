using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Globalization;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class AdicionalesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public AdicionalesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ObtenerAdicionales> ObtenerAdicionales()
        {

            var query = from A in SqlContext.Adicionales
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        join E in SqlContext.Estados on A.EstadoId equals E.Id
                        join P in SqlContext.Proveedores on A.ProveedorId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        join L in SqlContext.Locaciones on A.LocacionId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where A.EstadoId != 1064
                        select new
                        {
                            Id = A.Id,
                            Descripcion = A.Descripcion,
                            Precio = A.Precio,
                            RubroId = R.Id,
                            Rubro = R.Descripcion,
                            EstadoId = E.Id,
                            EstadoDescripcion = E.Descripcion,
                            RequiereCantidad = A.RequiereCantidad,
                            ProveedorId = (P.Id == null ? 0 : P.Id),
                            Proveedor = P.RazonSocial,
                            Costo = A.Costo,
                            LocacionId = (A.LocacionId == null ? 0 : A.LocacionId),
                            Locacion = L.Descripcion,
                            SoloMayoresDescripcion = (A.SoloMayores == "N" ? "TODOS" : "SOLO ADULTOS")

                        };

            List<ObtenerAdicionales> Salida = new List<ObtenerAdicionales>();
            foreach (var item in query)
            {

                ObtenerAdicionales cat = new ObtenerAdicionales();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.Locacion = item.Locacion;
                cat.RubroId = item.RubroId;
                cat.Rubro = item.Rubro;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.Proveedor = item.Proveedor;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.RequiereCantidad = item.RequiereCantidad;
                cat.SoloMayoresDescripcion = item.SoloMayoresDescripcion;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();


        }

        public Adicionales BuscarAdicional(int id)
        {
            return SqlContext.Adicionales.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoAdicional(Adicionales adicional)
        {

            if (adicional.Id > 0)
            {

                Adicionales adiEdit = SqlContext.Adicionales.Where(o => o.Id == adicional.Id).First();

                adiEdit.RubroId = adicional.RubroId;
                adiEdit.Descripcion = adicional.Descripcion;
                adiEdit.EstadoId = adicional.EstadoId;
                adiEdit.Precio = adicional.Precio;
                adiEdit.RequiereCantidad = adicional.RequiereCantidad;
                adiEdit.RequiereCantidadRango = adicional.RequiereCantidadRango;
                adiEdit.ProveedorId = adicional.ProveedorId;
                adiEdit.LocacionId = adicional.LocacionId;
                adiEdit.SoloMayores = adicional.SoloMayores;

                SqlContext.SaveChanges();
            }
            else
            {

                int adicionalId = SqlContext.Adicionales.Max(o => o.Id) + 1;

                adicional.Id = adicionalId;

                SqlContext.Adicionales.Add(adicional);
                SqlContext.SaveChanges();
            }
        }

        public List<ObtenerAdicionales> ObtenerAdicionalesPorProveedor(int proveedorId)
        {


            var query = from A in SqlContext.Adicionales
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        join E in SqlContext.Estados on A.EstadoId equals E.Id
                        join P in SqlContext.Proveedores on A.ProveedorId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        join L in SqlContext.Locaciones on A.LocacionId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where P.Id == proveedorId
                        select new
                        {
                            Id = A.Id,
                            Descripcion = A.Descripcion,
                            Precio = A.Precio,
                            RubroId = R.Id,
                            Rubro = R.Descripcion,
                            EstadoId = E.Id,
                            EstadoDescripcion = E.Descripcion,
                            RequiereCantidad = A.RequiereCantidad,
                            ProveedorId = (P.Id == null ? 0 : P.Id),
                            Proveedor = P.RazonSocial,
                            Costo = A.Costo,
                            LocacionId = (A.LocacionId == null ? 0 : A.LocacionId),
                            Locacion = L.Descripcion

                        };

            List<ObtenerAdicionales> Salida = new List<ObtenerAdicionales>();
            foreach (var item in query)
            {

                ObtenerAdicionales cat = new ObtenerAdicionales();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.Locacion = item.Locacion;
                cat.RubroId = item.RubroId;
                cat.Rubro = item.Rubro;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.Proveedor = item.Proveedor;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.RequiereCantidad = item.RequiereCantidad;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();

        }

        public List<Adicionales> ObtenerAdicionalesPorLocaciones(int LocacionId)
        {
            return SqlContext.Adicionales.Where(o => o.LocacionId == LocacionId).ToList();
        }

        public List<ReporteAdicionales> ObtenerAdicionalesEventos(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {

            int UnidadNegocioAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

            var query = from P in SqlContext.Presupuestos
                        join pA in SqlContext.PresupuestoDetalle on P.Id equals pA.PresupuestoId into ps
                        from pAd in ps.DefaultIfEmpty()
                        join A in SqlContext.Adicionales on pAd.ServicioId equals A.Id
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        where pAd.UnidadNegocioId == UnidadNegocioAdicional
                        select new
                        {
                            NroEvento = P.EventoId,
                            NroPresupuesto = P.Id,
                            FechaEvento = P.FechaEvento,
                            Rubro = R.Descripcion,
                            AdicionalDesc = A.Descripcion,
                            AdicionalCant = pAd.CantidadAdicional,
                            AdicionalValor = pAd.PrecioItem


                        };

            List<ReporteAdicionales> Salida = new List<ReporteAdicionales>();
            foreach (var item in query)
            {

                ReporteAdicionales cat = new ReporteAdicionales();

                cat.NroEvento = item.NroEvento;
                cat.NroPresupuesto = item.NroPresupuesto;
                cat.FechaEvento = item.FechaEvento;
                cat.Rubro = item.Rubro;
                cat.AdicionalDesc = item.AdicionalDesc;
                cat.AdicionalCant = (int)item.AdicionalCant;
                cat.AdicionalValor = item.AdicionalValor;


                Salida.Add(cat);
            }

            DateTime fecDesde;
            DateTime fecHasta;

            if (fechaDesde != "")
            {
                fecDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Salida = Salida.Where(o => o.FechaEvento >= fecDesde).ToList();

            }
            if (fechaHasta != "")
            {
                fecHasta = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Salida = Salida.Where(o => o.FechaEvento <= fecHasta).ToList();
            }


            if (nroEvento > 0)
            {
                Salida = Salida.Where(o => o.NroEvento == nroEvento).ToList();
            }

            if (nroPresupuesto > 0)
            {
                Salida = Salida.Where(o => o.NroPresupuesto == nroPresupuesto).ToList();
            }


            return Salida.ToList();
        }

        public List<ObtenerAdicionales> ObtenerAdicionalesPorProveedoryUnidadNegocio(int ProveedorId, int UnidadNegocioId)
        {
            int activoAdicional = Int32.Parse(ConfigurationManager.AppSettings["EstadoAlertaActivada"].ToString());

            var query = from A in SqlContext.Adicionales
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        join E in SqlContext.Estados on A.EstadoId equals E.Id
                        join P in SqlContext.Proveedores on A.ProveedorId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        join L in SqlContext.Locaciones on A.LocacionId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where P.Id == ProveedorId && A.RubroId == UnidadNegocioId && A.EstadoId == activoAdicional
                        select new
                        {
                            Id = A.Id,
                            Descripcion = A.Descripcion,
                            Precio = A.Precio,
                            RubroId = R.Id,
                            Rubro = R.Descripcion,
                            EstadoId = E.Id,
                            EstadoDescripcion = E.Descripcion,
                            RequiereCantidad = A.RequiereCantidad,
                            ProveedorId = (P.Id == null ? 0 : P.Id),
                            Proveedor = P.RazonSocial,
                            Costo = A.Costo,
                            LocacionId = (A.LocacionId == null ? 0 : A.LocacionId),
                            Locacion = L.Descripcion

                        };

            List<ObtenerAdicionales> Salida = new List<ObtenerAdicionales>();
            foreach (var item in query)
            {

                ObtenerAdicionales cat = new ObtenerAdicionales();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.Locacion = item.Locacion;
                cat.RubroId = item.RubroId;
                cat.Rubro = item.Rubro;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.Proveedor = item.Proveedor;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.RequiereCantidad = item.RequiereCantidad;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();

        }

        public List<ObtenerAdicionales> ObtenerAdicionalesPorLocacionesUnidadNegocio(int LocacionId)
        {

            int activoAdicional = Int32.Parse(ConfigurationManager.AppSettings["EstadoAlertaActivada"].ToString());


            var query = from A in SqlContext.Adicionales
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        join E in SqlContext.Estados on A.EstadoId equals E.Id
                        join P in SqlContext.Proveedores on A.ProveedorId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        join L in SqlContext.Locaciones on A.LocacionId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where L.Id == LocacionId && A.EstadoId ==activoAdicional
                        select new
                        {
                            Id = A.Id,
                            Descripcion = A.Descripcion,
                            Precio = A.Precio,
                            RubroId = R.Id,
                            Rubro = R.Descripcion,
                            EstadoId = E.Id,
                            EstadoDescripcion = E.Descripcion,
                            RequiereCantidad = A.RequiereCantidad,
                            ProveedorId = (P.Id == null ? 0 : P.Id),
                            Proveedor = P.RazonSocial,
                            Costo = A.Costo,
                            LocacionId = (A.LocacionId == null ? 0 : A.LocacionId),
                            Locacion = L.Descripcion

                        };

            List<ObtenerAdicionales> Salida = new List<ObtenerAdicionales>();
            foreach (var item in query)
            {

                ObtenerAdicionales cat = new ObtenerAdicionales();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.Locacion = item.Locacion;
                cat.RubroId = item.RubroId;
                cat.Rubro = item.Rubro;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.Proveedor = item.Proveedor;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.RequiereCantidad = item.RequiereCantidad;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();
        }

        public List<Entidades.ObtenerAdicionales> ObtenerAdicionalesPorProveedorUnidadNegocioyTipoCatering(int ProveedorId, int UnidadNegocioId, int TipoCateringId)
        {

            int activoAdicional = Int32.Parse(ConfigurationManager.AppSettings["EstadoAlertaActivada"].ToString());


            List<int> queryAdicionalesTipoCatering = (from tc in SqlContext.TipoCateringAdicional
                                                      where tc.TipoCateringId == TipoCateringId
                                                      select tc).Select(o => o.AdicionalId).ToList();



            var query = from A in SqlContext.Adicionales
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        join E in SqlContext.Estados on A.EstadoId equals E.Id
                        join P in SqlContext.Proveedores on A.ProveedorId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        join L in SqlContext.Locaciones on A.LocacionId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        where P.Id == ProveedorId && A.RubroId == UnidadNegocioId && queryAdicionalesTipoCatering.Contains(A.Id) && A.EstadoId == activoAdicional
                        select new
                        {
                            Id = A.Id,
                            Descripcion = A.Descripcion,
                            Precio = A.Precio,
                            RubroId = R.Id,
                            Rubro = R.Descripcion,
                            EstadoId = E.Id,
                            EstadoDescripcion = E.Descripcion,
                            RequiereCantidad = A.RequiereCantidad,
                            ProveedorId = (P.Id == null ? 0 : P.Id),
                            Proveedor = P.RazonSocial,
                            Costo = A.Costo,
                            LocacionId = (A.LocacionId == null ? 0 : A.LocacionId),
                            Locacion = L.Descripcion

                        };

            List<ObtenerAdicionales> Salida = new List<ObtenerAdicionales>();
            foreach (var item in query)
            {

                ObtenerAdicionales cat = new ObtenerAdicionales();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.Locacion = item.Locacion;
                cat.RubroId = item.RubroId;
                cat.Rubro = item.Rubro;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.Proveedor = item.Proveedor;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.RequiereCantidad = item.RequiereCantidad;

                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        public void ActualizarAdicional(Adicionales item)
        {
            Adicionales adi = SqlContext.Adicionales.Where(o => o.Id == item.Id).SingleOrDefault();


            adi.EstadoId = item.EstadoId;

            SqlContext.SaveChanges();


        }

        public void NuevoAdicionalItem(int adicionalId, int itemsId)
        {
            AdicionalesItems edit = new AdicionalesItems();

            if (adicionalId > 0 && itemsId > 0)
                edit = SqlContext.AdicionalesItems.Where(o => o.AdicionalId == adicionalId && o.ItemId == itemsId).SingleOrDefault();



            if (edit !=null)
            {


                edit.AdicionalId = adicionalId;
                edit.ItemId = itemsId;

                SqlContext.SaveChanges();
            }
            else
            {
                AdicionalesItems adicionalItem = new AdicionalesItems();

                adicionalItem.AdicionalId = adicionalId;
                adicionalItem.ItemId = itemsId;

                SqlContext.AdicionalesItems.Add(adicionalItem);
                SqlContext.SaveChanges();
            }
        }

        public AdicionalesItems BuscarAdicionalItem(int adicionalItemId)
        {

            if (adicionalItemId > 0)
            {
                AdicionalesItems edit = SqlContext.AdicionalesItems.Where(o => o.Id == adicionalItemId).SingleOrDefault();

                return edit;
            }

            return new AdicionalesItems();
        }


        internal bool EliminarItemsAdicionales(int id, int adicionalId)
        {
            if (id > 0)
            {
                AdicionalesItems edit = SqlContext.AdicionalesItems.Where(o => o.ItemId == id && o.AdicionalId == adicionalId).SingleOrDefault();

                if (edit != null)
                {

                    SqlContext.AdicionalesItems.Remove(edit);
                    SqlContext.SaveChanges();
                    

                    return true;
                }
                else
                    return false;

            }
            else
                return false;


        }

        internal List<Entidades.ObtenerAdicionales> BuscarAdicionalesPorDescripcionProveedorSalon(string descripcion, int proveedorId, int locacionId, int unidadNegocioId)
        {
            var query = from A in SqlContext.Adicionales
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        join E in SqlContext.Estados on A.EstadoId equals E.Id
                        join P in SqlContext.Proveedores on A.ProveedorId equals P.Id into Ps
                        from P in Ps.DefaultIfEmpty()
                        join L in SqlContext.Locaciones on A.LocacionId equals L.Id into Ls
                        from L in Ls.DefaultIfEmpty()
                        select new
                        {
                            Id = A.Id,
                            Descripcion = A.Descripcion,
                            Precio = A.Precio,
                            RubroId = R.Id,
                            Rubro = R.Descripcion,
                            EstadoId = E.Id,
                            EstadoDescripcion = E.Descripcion,
                            RequiereCantidad = A.RequiereCantidad,
                            ProveedorId = (P.Id == null ? 0 : P.Id),
                            Proveedor = P.RazonSocial,
                            Costo = A.Costo,
                            LocacionId = (A.LocacionId == null ? 0 : A.LocacionId),
                            Locacion = L.Descripcion,
                            UnidadNegocioId= R.Id

                        };

            if (!string.IsNullOrWhiteSpace(descripcion))
                query = query.Where(o => o.Descripcion.Contains(descripcion));

            if (proveedorId > 0)
                query = query.Where(o => o.ProveedorId == proveedorId);

            if (locacionId > 0)
                query = query.Where(o => o.LocacionId == locacionId);

            if (unidadNegocioId > 0)
                query = query.Where(o => o.UnidadNegocioId == unidadNegocioId);

            List<ObtenerAdicionales> Salida = new List<ObtenerAdicionales>();
            foreach (var item in query)
            {

                ObtenerAdicionales cat = new ObtenerAdicionales();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.LocacionId = item.LocacionId;
                cat.Locacion = item.Locacion;
                cat.RubroId = item.RubroId;
                cat.Rubro = item.Rubro;
                cat.EstadoId = item.EstadoId;
                cat.EstadoDescripcion = item.EstadoDescripcion;
                cat.ProveedorId = item.ProveedorId;
                cat.Proveedor = item.Proveedor;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.RequiereCantidad = item.RequiereCantidad;

                Salida.Add(cat);
            }

            return Salida.ToList();
        }
    }
}
