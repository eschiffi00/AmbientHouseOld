using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class CategoriaItemsDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public CategoriaItemsDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<CategoriasItem> ObtenerCategoriasItem()
        {

            return SqlContext.CategoriasItem.ToList();

        }

        public virtual CategoriasItem BuscarPadreCategoria(int categoriaPadreId)
        {
            return SqlContext.CategoriasItem.Where(o => o.Id == categoriaPadreId).SingleOrDefault();
        }

        public List<CategoriasItem> ObtenerCategoriasPorGrupos(int grupoId)
        {
            var query = from f in SqlContext.Familias
                        join C in SqlContext.CategoriasItem on f.CategoriaItemId equals C.Id
                        where f.GrupoId == grupoId && C.EstadoId == 1
                        select C;


            return query.ToList();


        }

        public List<CategoriasItem> ObtenerCategoriasItemHijosPadres()
        {
            var query = from C in SqlContext.CategoriasItem
                        join CP in SqlContext.CategoriasItem on C.CategoriaItemPadreId equals CP.Id into CPS
                        from CP in CPS.DefaultIfEmpty()
                        join CPP in SqlContext.CategoriasItem on CP.CategoriaItemPadreId equals CPP.Id into CPPS
                        from CPP in CPPS.DefaultIfEmpty()
                        where C.EstadoId == 1
                        select new
                        {
                            Id = C.Id,
                            Descripcion = C.Descripcion,
                            CategoriaItemPadreId = (C.CategoriaItemPadreId == null ? null : C.CategoriaItemPadreId),
                            CategoriaItemPadreDescripcion = CP.Descripcion,
                            CategoriaItemPadrePadreDescripcion = CPP.Descripcion,
                            EstadoId = C.EstadoId
                        };



            List<CategoriasItem> Salida = new List<CategoriasItem>();
            foreach (var item in query)
            {

                CategoriasItem cat = new CategoriasItem();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.CategoriaItemPadreId = item.CategoriaItemPadreId;
                cat.CategoriaItemPadreDescripcion = item.CategoriaItemPadreDescripcion + " \\ " + item.Descripcion;
                cat.EstadoId = item.EstadoId;

                if (item.CategoriaItemPadreDescripcion == null)
                {
                    cat.CategoriaItemPadrePadreDescripcion = item.Descripcion.ToUpper();
                }
                else if (item.CategoriaItemPadrePadreDescripcion == null)
                {
                    cat.CategoriaItemPadrePadreDescripcion = item.CategoriaItemPadreDescripcion + " \\ " + item.Descripcion.ToUpper(); ;
                }
                else
                    cat.CategoriaItemPadrePadreDescripcion = item.CategoriaItemPadrePadreDescripcion + " \\ " + item.CategoriaItemPadreDescripcion + " \\ " + item.Descripcion.ToUpper();


                Salida.Add(cat);
            }

            return Salida.ToList();


        }

        public CategoriasItem BuscarCategoriaItem(int id)
        {
            return SqlContext.CategoriasItem.Where(o => o.Id == id).SingleOrDefault();

        }

        public void NuevaCategoriaItem(CategoriasItem categoria)
        {
            if (categoria.Id > 0)
            {
                CategoriasItem editCategoriaItem = SqlContext.CategoriasItem.Where(o => o.Id == categoria.Id).SingleOrDefault();

                editCategoriaItem.Descripcion = categoria.Descripcion;
                editCategoriaItem.CategoriaItemPadreId = categoria.CategoriaItemPadreId;
                editCategoriaItem.EstadoId = categoria.EstadoId;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.CategoriasItem.Add(categoria);
                SqlContext.SaveChanges();
            }
        }

        public List<CategoriasItem> ObtenerCategoriasPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {

            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString()); ;

            var query = from T in SqlContext.TipoCateringTiempoProductoItem
                        join C in SqlContext.CategoriasItem on T.CategoriaItemId equals C.Id
                        join CP in SqlContext.CategoriasItem on C.CategoriaItemPadreId equals CP.Id into CPs
                        from CP in CPs.DefaultIfEmpty()
                        where T.TipoCateringId == TipoCateringId && T.TiempoId == TiempoId && T.EstadoId == activo && C.EstadoId == 1
                        select new
                        {
                            Id = C.Id,
                            Descripcion = C.Descripcion,
                            CategoriaItemPadreId = (C.CategoriaItemPadreId == null ? null : C.CategoriaItemPadreId),
                            CategoriaItemPadreDescripcion = CP.Descripcion,
                            EstadoId = C.EstadoId

                        };

            List<CategoriasItem> Salida = new List<CategoriasItem>();
            foreach (var item in query)
            {

                CategoriasItem cat = new CategoriasItem();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.CategoriaItemPadreId = item.CategoriaItemPadreId;
                cat.CategoriaItemPadreDescripcion = item.CategoriaItemPadreDescripcion + " \\ " + item.Descripcion;
                cat.EstadoId = item.EstadoId;

                if (item.CategoriaItemPadreDescripcion == null)
                {
                    cat.CategoriaItemPadreDescripcion = item.Descripcion.ToUpper();
                }


                Salida.Add(cat);
            }


            return Salida.ToList();
        }

        public List<CategoriasItem> ObtenerCategoriasPorTipoBarra(int TipoBarraId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoBarraCategoriaItemActivos"].ToString()); ;

            var query = from T in SqlContext.TipoBarraCategoriaItem
                        join C in SqlContext.CategoriasItem on T.CategoriaItemId equals C.Id
                        join CP in SqlContext.CategoriasItem on C.CategoriaItemPadreId equals CP.Id into CPs
                        from CP in CPs.DefaultIfEmpty()
                        where T.TipoBarraId == TipoBarraId && T.EstadoId == activo && C.EstadoId == 1
                        select new
                        {
                            Id = C.Id,
                            Descripcion = C.Descripcion,
                            CategoriaItemPadreId = (C.CategoriaItemPadreId == null ? null : C.CategoriaItemPadreId),
                            CategoriaItemPadreDescripcion = CP.Descripcion,
                            EstadoId = C.EstadoId

                        };

            List<CategoriasItem> Salida = new List<CategoriasItem>();
            foreach (var item in query)
            {

                CategoriasItem cat = new CategoriasItem();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.CategoriaItemPadreId = item.CategoriaItemPadreId;
                cat.CategoriaItemPadreDescripcion = item.CategoriaItemPadreDescripcion + " \\ " + item.Descripcion;
                cat.EstadoId = item.EstadoId;
                if (item.CategoriaItemPadreDescripcion == null)
                {
                    cat.CategoriaItemPadreDescripcion = item.Descripcion.ToUpper();
                }


                Salida.Add(cat);
            }


            return Salida.ToList();
        }
    }
}
