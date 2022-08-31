using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class TipoBarraCategoriaItemDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoBarraCategoriaItemDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoBarraCategoriaItem> ObtenerTipoBarraCategoriaItem(int tipoBarraId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoBarraCategoriaItemActivos"].ToString());

            var query = from TCTPI in SqlContext.TipoBarraCategoriaItem
                        join Tc in SqlContext.TiposBarras on TCTPI.TipoBarraId equals Tc.Id
                        join I in SqlContext.Items on TCTPI.ItemId equals I.Id into Is
                        from I in Is.DefaultIfEmpty()
                        join CI in SqlContext.CategoriasItem on TCTPI.CategoriaItemId equals CI.Id into CIs
                        from CI in CIs.DefaultIfEmpty()
                        where TCTPI.TipoBarraId == tipoBarraId && TCTPI.EstadoId == activo
                        select new
                        {
                            Id = TCTPI.Id,
                            TipoBarraId = TCTPI.TipoBarraId,
                            CategoriaItemId = (TCTPI.CategoriaItemId == null ? 0 : TCTPI.CategoriaItemId),
                            ItemId = (TCTPI.ItemId == null ? 0 : TCTPI.ItemId),
                            CategoriaItemDescripcion = CI.Descripcion,
                            TipoBarraDescripcion = Tc.Descripcion,
                            ItemDescripcion = I.Detalle

                        };

            List<TipoBarraCategoriaItem> Salida = new List<TipoBarraCategoriaItem>();

            foreach (var item in query)
            {
                TipoBarraCategoriaItem cat = new TipoBarraCategoriaItem();

                cat.Id = item.Id;
                cat.TipoBarraId = item.TipoBarraId;
                cat.TipoBarraDescripcion = item.TipoBarraDescripcion;
               
                cat.ItemId = item.ItemId;
                cat.ItemDescripcion = item.ItemDescripcion;
                cat.CategoriaItemId = item.CategoriaItemId;
                cat.CategoriaItemDescripcion = item.CategoriaItemDescripcion;
              
                Salida.Add(cat);

            }

            return Salida.ToList();

        }

        public void NuevoTipoBarraCategoriaItem(TipoBarraCategoriaItem tipo)
        {
            if (tipo.Id > 0)
            {
                TipoBarraCategoriaItem edit = SqlContext.TipoBarraCategoriaItem.Where(o => o.Id == tipo.Id).SingleOrDefault();

                edit.TipoBarraId = tipo.TipoBarraId;
                
                edit.ItemId = tipo.ItemId;
                edit.CategoriaItemId = tipo.CategoriaItemId;
                edit.EstadoId = tipo.EstadoId;
                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.TipoBarraCategoriaItem.Add(tipo);
                SqlContext.SaveChanges();

            }
        }

        public TipoBarraCategoriaItem BuscarTipoBarraCategoriaItem(long id)
        {
            return SqlContext.TipoBarraCategoriaItem.Where(o => o.Id == id).SingleOrDefault();
        }

        //public virtual List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCatering(int tipoCatering)
        //{
        //    //Select Tc.Descripcion , T.Descripcion, PC.Descripcion, IP.Detalle,CI.Descripcion,IC.Detalle,I.Detalle
        //    //from  TipoCateringTiempoProductoItem C 
        //    //        inner join TipoCatering Tc on C.TipoCateringId = Tc.Id
        //    //        Inner join Tiempos T on C.TiempoId = T.Id
        //    //        Left join ProductosCatering PC on C.ProductoCateringId = PC.Id
        //    //        left join ProductosCateringItems PCI on PCI.ProductoCateringId = PC.Id
        //    //        left Join Items IP on PCI.ItemId = IP.Id
        //    //        Left Join CategoriasItem CI on C.CategoriaItemId = CI.Id
        //    //        left join Items IC on CI.Id = IC.CategoriaItemId 
        //    //        Left join Items I on C.ItemId = I.Id
        //    //Order By 1,2

        //    int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());


        //    var query = from C in SqlContext.TipoCateringTiempoProductoItem
        //                join Tc in SqlContext.TipoCatering on C.TipoCateringId equals Tc.Id
        //                join T in SqlContext.Tiempos on C.TiempoId equals T.Id
        //                join PC in SqlContext.ProductosCatering on C.ProductoCateringId equals PC.Id into PCs
        //                from PC in PCs.DefaultIfEmpty()
        //                join PCI in SqlContext.ProductosCateringItems on PC.Id equals PCI.ProductoCateringId into PCIs
        //                from PCI in PCIs.DefaultIfEmpty()
        //                join IP in SqlContext.Items on PCI.ItemId equals IP.Id into IPs
        //                from IP in IPs.DefaultIfEmpty()
        //                join CI in SqlContext.CategoriasItem on C.CategoriaItemId equals CI.Id into CIs
        //                from CI in CIs.DefaultIfEmpty()
        //                join IC in SqlContext.Items on CI.Id equals IC.CategoriaItemId into ICs
        //                from IC in ICs.DefaultIfEmpty()
        //                join I in SqlContext.Items on C.ItemId equals I.Id into Is
        //                from I in Is.DefaultIfEmpty()
        //                where C.TipoCateringId == tipoCatering && C.EstadoId == activo
        //                select new
        //                {

        //                    TipoCateringId = C.TipoCateringId,
        //                    TiempoDescripcion = T.Descripcion,
        //                    TipoCateringDescripcion = Tc.Descripcion,
        //                    ProductoCateringDescripcion = PC.Descripcion,
        //                    ProductoCateringItemId = (IP.Id == null ? 0 : IP.Id),
        //                    ProductoCateringItemDescripcion = IP.Detalle,
        //                    CategoriaItemDescripcion = CI.Descripcion,
        //                    CategoriaItemItemId = (IC.Id == null ? 0 : IC.Id),
        //                    CategoriaItemItemDescripcion = IC.Detalle,
        //                    ItemId = (I.Id == null ? 0 : I.Id),
        //                    ItemDescripcion = I.Detalle,
        //                    Orden = (T.Orden == null ? 0 : T.Orden)

        //                };


        //    List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> salida = new List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem>();

        //    foreach (var item in query)
        //    {
        //        ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem cat = new ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem();

        //        cat.TipoCateringId = item.TipoCateringId;


        //        cat.TiempoDescripcion = item.TiempoDescripcion;
        //        cat.TipoCateringDescripcion = item.TipoCateringDescripcion;

        //        cat.ProductoCateringDescripcion = item.ProductoCateringDescripcion;
        //        cat.ProductoCateringItemDescripcion = item.ProductoCateringItemDescripcion;
        //        cat.ProductoCateringItemId = item.ProductoCateringItemId;

        //        cat.CategoriaItemDescripcion = item.CategoriaItemDescripcion;
        //        cat.CategoriaItemItemDescripcion = item.CategoriaItemItemDescripcion;
        //        cat.CategoriaItemItemId = item.CategoriaItemItemId;

        //        cat.ItemDescripcion = item.ItemDescripcion;
        //        cat.ItemId = item.ItemId;

        //        cat.Orden = item.Orden;

        //        salida.Add(cat);

        //    }

        //    return salida.OrderBy(o => o.TipoCateringDescripcion).OrderBy(o => o.Orden).ToList();

        //}


        public void ActualizarTipoBarraCategoriaItem(TipoBarraCategoriaItem item)
        {
            TipoBarraCategoriaItem edit = SqlContext.TipoBarraCategoriaItem.Where(o => o.Id == item.Id).SingleOrDefault();

            edit.EstadoId = item.EstadoId;

            SqlContext.SaveChanges();
        }


        //public virtual List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> BuscarConfiguracionPorTipoCateringArmadoArbol(int tipoCatering)
        //{


        //    int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());


        //    var query = from C in SqlContext.TipoCateringTiempoProductoItem
        //                join Tc in SqlContext.TipoCatering on C.TipoCateringId equals Tc.Id
        //                join T in SqlContext.Tiempos on C.TiempoId equals T.Id
        //                join PC in SqlContext.ProductosCatering on C.ProductoCateringId equals PC.Id into PCs
        //                from PC in PCs.DefaultIfEmpty()
        //                join PCI in SqlContext.ProductosCateringItems on PC.Id equals PCI.ProductoCateringId into PCIs
        //                from PCI in PCIs.DefaultIfEmpty()
        //                join IP in SqlContext.Items on PCI.ItemId equals IP.Id into IPs
        //                from IP in IPs.DefaultIfEmpty()
        //                join CI in SqlContext.CategoriasItem on C.CategoriaItemId equals CI.Id into CIs
        //                from CI in CIs.DefaultIfEmpty()
        //                join IC in SqlContext.Items on CI.Id equals IC.CategoriaItemId into ICs
        //                from IC in ICs.DefaultIfEmpty()
        //                join I in SqlContext.Items on C.ItemId equals I.Id into Is
        //                from I in Is.DefaultIfEmpty()
        //                where C.TipoCateringId == tipoCatering && C.EstadoId == activo
        //                select new
        //                {

        //                    TipoCateringId = C.TipoCateringId,
        //                    TiempoDescripcion = T.Descripcion,
        //                    TipoCateringDescripcion = Tc.Descripcion,
        //                    ProductoCateringDescripcion = PC.Descripcion,
        //                    ProductoCateringItemId = (IP.Id == null ? 0 : IP.Id),
        //                    ProductoCateringItemDescripcion = IP.Detalle,
        //                    CategoriaItemDescripcion = CI.Descripcion,
        //                    CategoriaItemItemId = (IC.Id == null ? 0 : IC.Id),
        //                    CategoriaItemItemDescripcion = IC.Detalle,
        //                    ItemId = (I.Id == null ? 0 : I.Id),
        //                    ItemDescripcion = I.Detalle,
        //                    Orden = (T.Orden == null ? 0 : T.Orden),
        //                    TiempoId = C.TiempoId,
        //                    ProductoCateringId = (C.ProductoCateringId == null ? 0 : C.ProductoCateringId),
        //                    CategoriaItemId = (C.CategoriaItemId == null ? 0 : C.CategoriaItemId)




        //                };


        //    List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem> salida = new List<ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem>();

        //    foreach (var item in query)
        //    {
        //        ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem cat = new ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem();

        //        cat.TipoCateringId = item.TipoCateringId;


        //        cat.TiempoDescripcion = item.TiempoDescripcion;
        //        cat.TipoCateringDescripcion = item.TipoCateringDescripcion;

        //        cat.ProductoCateringDescripcion = item.ProductoCateringDescripcion;
        //        cat.ProductoCateringItemDescripcion = item.ProductoCateringItemDescripcion;
        //        cat.ProductoCateringItemId = item.ProductoCateringItemId;

        //        cat.CategoriaItemDescripcion = item.CategoriaItemDescripcion;
        //        cat.CategoriaItemItemDescripcion = item.CategoriaItemItemDescripcion;
        //        cat.CategoriaItemItemId = item.CategoriaItemItemId;

        //        cat.ItemDescripcion = item.ItemDescripcion;
        //        cat.ItemId = item.ItemId;

        //        cat.Orden = item.Orden;


        //        cat.TiempoId = item.TiempoId;
        //        cat.ProductoId = item.ProductoCateringId;
        //        cat.CategoriaItemId = item.CategoriaItemId;

        //        salida.Add(cat);

        //    }

        //    return salida.OrderBy(o => o.TipoCateringDescripcion).OrderBy(o => o.Orden).ToList();

        //}
    }
}
