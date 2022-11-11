using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class TipoCateringTiempoProductoItemDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoCateringTiempoProductoItemDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoCateringTiempoProductoItem> ObtenerTipoCateringTiempoProductoItemDatos(int tipoCateringId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());

            var query = from TCTPI in SqlContext.TipoCateringTiempoProductoItem
                        join Tc in SqlContext.TipoCatering on TCTPI.TipoCateringId equals Tc.Id
                        join T in SqlContext.Tiempos on TCTPI.TiempoId equals T.Id
                        join PC in SqlContext.ProductosCatering on TCTPI.ProductoCateringId equals PC.Id into PCIs
                        from PCI in PCIs.DefaultIfEmpty()
                        join I in SqlContext.Items on TCTPI.ItemId equals I.Id into Is
                        from I in Is.DefaultIfEmpty()
                        join CI in SqlContext.CategoriasItem on TCTPI.CategoriaItemId equals CI.Id into CIs
                        from CI in CIs.DefaultIfEmpty()
                        where TCTPI.TipoCateringId == tipoCateringId && TCTPI.EstadoId == activo
                        select new
                        {
                            Id = TCTPI.Id,
                            TipoCateringId = TCTPI.TipoCateringId,
                            TiempoId = TCTPI.TiempoId,
                            CategoriaItemId = (TCTPI.CategoriaItemId == null ? 0 : TCTPI.CategoriaItemId),
                            ProductoCateringId = (TCTPI.ProductoCateringId == null ? 0 : TCTPI.ProductoCateringId),
                            ItemId = (TCTPI.ItemId == null ? 0 : TCTPI.ItemId),
                            CategoriaItemDescripcion = CI.Descripcion,
                            TiempoDescripcion = T.Descripcion,
                            TipoCateringDescripcion = Tc.Descripcion,
                            ProductoCateringDescripcion = PCI.Descripcion,
                            ItemDescripcion = I.Detalle,
                            Orden = (T.Orden == null ? 0 : T.Orden)

                        };

            List<TipoCateringTiempoProductoItem> Salida = new List<TipoCateringTiempoProductoItem>();

            foreach (var item in query)
            {
                TipoCateringTiempoProductoItem cat = new TipoCateringTiempoProductoItem();

                cat.Id = item.Id;
                cat.TipoCateringId = item.TipoCateringId;
                cat.TipoCateringDescripcion = item.TipoCateringDescripcion;
                cat.TiempoId = item.TiempoId;
                cat.TiempoDescripcion = item.TiempoDescripcion;
                cat.ProductoCateringId = item.ProductoCateringId;
                cat.ProductoCateringDescripcion = item.ProductoCateringDescripcion;
                cat.ItemId = item.ItemId;
                cat.ItemDescripcion = item.ItemDescripcion;
                cat.CategoriaItemId = item.CategoriaItemId;
                cat.CategoriaItemDescripcion = item.CategoriaItemDescripcion;
                cat.Orden = item.Orden;
                Salida.Add(cat);

            }

            return Salida.ToList();

        }

        public void NuevoTipoCateringTiempoProductoItem(TipoCateringTiempoProductoItem tipo)
        {
            if (tipo.Id > 0)
            {
                TipoCateringTiempoProductoItem edit = SqlContext.TipoCateringTiempoProductoItem.Where(o => o.Id == tipo.Id).SingleOrDefault();

                edit.TipoCateringId = tipo.TipoCateringId;
                edit.TiempoId = tipo.TiempoId;
                edit.ProductoCateringId = tipo.ProductoCateringId;
                edit.ItemId = tipo.ItemId;
                edit.CategoriaItemId = tipo.CategoriaItemId;
                edit.EstadoId = tipo.EstadoId;
                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.TipoCateringTiempoProductoItem.Add(tipo);
                SqlContext.SaveChanges();

            }
        }

        public TipoCateringTiempoProductoItem BuscarTipoCateringTiempoProductoItem(long id)
        {
            return SqlContext.TipoCateringTiempoProductoItem.Where(o => o.Id == id).SingleOrDefault();
        }

        public virtual List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCatering(int tipoCatering)
        {
            //Select Tc.Descripcion , T.Descripcion, PC.Descripcion, IP.Detalle,CI.Descripcion,IC.Detalle,I.Detalle
            //from  TipoCateringTiempoProductoItem C 
            //        inner join TipoCatering Tc on C.TipoCateringId = Tc.Id
            //        Inner join Tiempos T on C.TiempoId = T.Id
            //        Left join ProductosCatering PC on C.ProductoCateringId = PC.Id
            //        left join ProductosCateringItems PCI on PCI.ProductoCateringId = PC.Id
            //        left Join Items IP on PCI.ItemId = IP.Id
            //        Left Join CategoriasItem CI on C.CategoriaItemId = CI.Id
            //        left join Items IC on CI.Id = IC.CategoriaItemId 
            //        Left join Items I on C.ItemId = I.Id
            //Order By 1,2

            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());


            var query = from C in SqlContext.TipoCateringTiempoProductoItem
                        join Tc in SqlContext.TipoCatering on C.TipoCateringId equals Tc.Id
                        join T in SqlContext.Tiempos on C.TiempoId equals T.Id
                        join PC in SqlContext.ProductosCatering on C.ProductoCateringId equals PC.Id into PCs
                        from PC in PCs.DefaultIfEmpty()
                        join PCI in SqlContext.ProductosCateringItems on PC.Id equals PCI.ProductoCateringId into PCIs
                        from PCI in PCIs.DefaultIfEmpty()
                        join IP in SqlContext.Items on PCI.ItemId equals IP.Id into IPs
                        from IP in IPs.DefaultIfEmpty()
                        join CI in SqlContext.CategoriasItem on C.CategoriaItemId equals CI.Id into CIs
                        from CI in CIs.DefaultIfEmpty()
                        join IC in SqlContext.Items on CI.Id equals IC.CategoriaItemId into ICs
                        from IC in ICs.DefaultIfEmpty()
                        join I in SqlContext.Items on C.ItemId equals I.Id into Is
                        from I in Is.DefaultIfEmpty()
                        where C.TipoCateringId == tipoCatering && C.EstadoId == activo
                        select new
                        {

                            TipoCateringId = C.TipoCateringId,
                            TiempoDescripcion = T.Descripcion,
                            TipoCateringDescripcion = Tc.Descripcion,
                            ProductoCateringDescripcion = PC.Descripcion,
                            ProductoCateringItemId = (IP.Id == null ? 0 : IP.Id),
                            ProductoCateringItemDescripcion = IP.Detalle,
                            CategoriaItemDescripcion = CI.Descripcion,
                            CategoriaItemItemId = (IC.Id == null ? 0 : IC.Id),
                            CategoriaItemItemDescripcion = IC.Detalle,
                            ItemId = (I.Id == null ? 0 : I.Id),
                            ItemDescripcion = I.Detalle,
                            Orden = (T.Orden == null ? 0 : T.Orden)

                        };


            List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> salida = new List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem>();

            foreach (var item in query)
            {
                ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem cat = new ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem();

                cat.TipoCateringId = item.TipoCateringId;


                cat.TiempoDescripcion = item.TiempoDescripcion;
                cat.TipoCateringDescripcion = item.TipoCateringDescripcion;

                cat.ProductoCateringDescripcion = item.ProductoCateringDescripcion;
                cat.ProductoCateringItemDescripcion = item.ProductoCateringItemDescripcion;
                cat.ProductoCateringItemId = item.ProductoCateringItemId;

                cat.CategoriaItemDescripcion = item.CategoriaItemDescripcion;
                cat.CategoriaItemItemDescripcion = item.CategoriaItemItemDescripcion;
                cat.CategoriaItemItemId = item.CategoriaItemItemId;

                cat.ItemDescripcion = item.ItemDescripcion;
                cat.ItemId = item.ItemId;

                cat.Orden = item.Orden;

                salida.Add(cat);

            }

            return salida.OrderBy(o => o.TipoCateringDescripcion).OrderBy(o => o.Orden).ToList();

        }


        public void ActualizarTipoCateringTiempoProductoItem(TipoCateringTiempoProductoItem item)
        {
            TipoCateringTiempoProductoItem edit = SqlContext.TipoCateringTiempoProductoItem.Where(o => o.Id == item.Id).SingleOrDefault();

            edit.EstadoId = item.EstadoId;

            SqlContext.SaveChanges();
        }


        public virtual List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCateringArmadoArbol(int tipoCatering)
        {


            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());


            var query = from C in SqlContext.TipoCateringTiempoProductoItem
                        join Tc in SqlContext.TipoCatering on C.TipoCateringId equals Tc.Id
                        join T in SqlContext.Tiempos on C.TiempoId equals T.Id
                        join PC in SqlContext.ProductosCatering on C.ProductoCateringId equals PC.Id into PCs
                        from PC in PCs.DefaultIfEmpty()
                        join PCI in SqlContext.ProductosCateringItems on PC.Id equals PCI.ProductoCateringId into PCIs
                        from PCI in PCIs.DefaultIfEmpty()
                        join IP in SqlContext.Items on PCI.ItemId equals IP.Id into IPs
                        from IP in IPs.DefaultIfEmpty()
                        join CI in SqlContext.CategoriasItem on C.CategoriaItemId equals CI.Id into CIs
                        from CI in CIs.DefaultIfEmpty()
                        join IC in SqlContext.Items on CI.Id equals IC.CategoriaItemId into ICs
                        from IC in ICs.DefaultIfEmpty()
                        join I in SqlContext.Items on C.ItemId equals I.Id into Is
                        from I in Is.DefaultIfEmpty()
                        where C.TipoCateringId == tipoCatering && C.EstadoId == activo
                        select new
                        {

                            TipoCateringId = C.TipoCateringId,
                            TiempoDescripcion = T.Descripcion,
                            TipoCateringDescripcion = Tc.Descripcion,
                            ProductoCateringDescripcion = PC.Descripcion,
                            ProductoCateringItemId = (IP.Id == null ? 0 : IP.Id),
                            ProductoCateringItemDescripcion = IP.Detalle,
                            CategoriaItemDescripcion = CI.Descripcion,
                            CategoriaItemItemId = (IC.Id == null ? 0 : IC.Id),
                            CategoriaItemItemDescripcion = IC.Detalle,
                            ItemId = (I.Id == null ? 0 : I.Id),
                            ItemDescripcion = I.Detalle,
                            Orden = (T.Orden == null ? 0 : T.Orden),
                            TiempoId = C.TiempoId,
                            ProductoCateringId = (C.ProductoCateringId == null ? 0 : C.ProductoCateringId),
                            CategoriaItemId = (C.CategoriaItemId == null ? 0 : C.CategoriaItemId)




                        };


            List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> salida = new List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem>();

            foreach (var item in query)
            {
                ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem cat = new ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem();

                cat.TipoCateringId = item.TipoCateringId;


                cat.TiempoDescripcion = item.TiempoDescripcion;
                cat.TipoCateringDescripcion = item.TipoCateringDescripcion;

                cat.ProductoCateringDescripcion = item.ProductoCateringDescripcion;
                cat.ProductoCateringItemDescripcion = item.ProductoCateringItemDescripcion;
                cat.ProductoCateringItemId = item.ProductoCateringItemId;

                cat.CategoriaItemDescripcion = item.CategoriaItemDescripcion;
                cat.CategoriaItemItemDescripcion = item.CategoriaItemItemDescripcion;
                cat.CategoriaItemItemId = item.CategoriaItemItemId;

                cat.ItemDescripcion = item.ItemDescripcion;
                cat.ItemId = item.ItemId;

                cat.Orden = item.Orden;


                cat.TiempoId = item.TiempoId;
                cat.ProductoId = item.ProductoCateringId;
                cat.CategoriaItemId = item.CategoriaItemId;

                salida.Add(cat);

            }

            return salida.OrderBy(o => o.TipoCateringDescripcion).OrderBy(o => o.Orden).ToList();

        }
    }
}
