using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class ItemsDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ItemsDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Items> BuscarItemsFiltros(string detalle, string categoria, int estadoId)
        {

            var query = from I in SqlContext.Items
                        where I.EstadoId == estadoId
                        select I;

            if (detalle.Length > 0)
                query = query.Where(o => o.Detalle.ToUpper().Contains(detalle.ToUpper()));

            if (categoria != "null")
            {
                int categoriaId = Int32.Parse(categoria);

                query = query.Where(o => o.CategoriaItemId == categoriaId);

            }

            return query.ToList();

        }


        public virtual List<Items> BuscarItemsFiltrosAgregadosProductos(int productoCateringId,string categoria, int estadoId)
        {

            var query = from I in SqlContext.Items
                        join PCI in SqlContext.ProductosCateringItems on I.Id equals PCI.ItemId
                        where I.EstadoId == estadoId && PCI.ProductoCateringId == productoCateringId
                        select I;

            if (categoria != "null")
            {
                int categoriaId = Int32.Parse(categoria);

                query = query.Where(o => o.CategoriaItemId == categoriaId);

            }

            return query.ToList();

        }

        public virtual List<Items> BuscarItemsFiltrosNoAgregadosProductos(int productoCateringId, string categoria, int estadoId)
        {

            var queryItemsPorProductoCatering = from I in SqlContext.Items
                                                join PCI in SqlContext.ProductosCateringItems on I.Id equals PCI.ItemId
                                                where I.EstadoId == estadoId && PCI.ProductoCateringId == productoCateringId
                                                select I;

          

            var queryItemsFull = from I in SqlContext.Items
                                where I.EstadoId == estadoId
                                select I;


            var queryFinal = queryItemsFull.Except(queryItemsPorProductoCatering);


            if (categoria != "null")
            {
                int categoriaId = Int32.Parse(categoria);

                queryFinal = queryFinal.Where(o => o.CategoriaItemId == categoriaId);

            }



            return queryFinal.ToList();

        }

        public virtual List<Items> ObtenerItems(int estadoId)
        {

            var query = from I in SqlContext.Items
                        where I.EstadoId == estadoId
                        select new 
                        { 
                            Id = I.Id,
                            Detalle = I.Detalle,
                            CategoriaItemId = I.CategoriaItemId,
                            EstadoId = I.EstadoId,
                            Costo = I.Costo,
                            Precio = I.Precio,
                            Margen = I.Margen,
                            Identificador = ""

                        };

            List<Items> Salida = new List<Items>();

            foreach (var item in query)
            {
                Items cat = new Items();

                cat.Id = item.Id;
                cat.Detalle = item.Detalle;
                cat.CategoriaItemId = item.CategoriaItemId;
                cat.EstadoId = item.EstadoId;
                cat.Costo = item.Costo;
                cat.Precio = item.Precio;
                cat.Margen = item.Margen;
                cat.Identificador = item.Id + " - " + item.Detalle;

                Salida.Add(cat);

            }
            return Salida.ToList();

        }


        public Items BuscarItems(int id)
        {
            return SqlContext.Items.Where(o => o.Id == id).First();
        }

        public void NuevoItem(Items item)
        {
            double margen;


            if (item.Id > 0)
            {

                Items itemEdit = SqlContext.Items.Where(o => o.Id == item.Id).First();

                if (item.Costo > 0)
                    margen = item.Precio / item.Costo;
                else
                    margen = 0;

                itemEdit.Detalle = item.Detalle;
                itemEdit.CategoriaItemId = item.CategoriaItemId;
                itemEdit.Costo = item.Costo;
                itemEdit.Precio = item.Precio;
                itemEdit.EstadoId = item.EstadoId;
                itemEdit.Margen = margen;


                SqlContext.SaveChanges();
            }
            else
            {

                int itemId = SqlContext.Items.Max(o => o.Id) + 1;

                if (item.Costo > 0)
                    margen = item.Precio / item.Costo;
                else
                    margen = 0;


                item.Id = itemId;
                item.Margen = margen;

                SqlContext.Items.Add(item);
                SqlContext.SaveChanges();
            }
        }

        public List<Items> ObtenerItemsPorGrupo(int grupoId)
        {
            var query = from OF in SqlContext.Familias
                        join I in SqlContext.Items on OF.CategoriaItemId equals I.Id
                        where OF.GrupoId == grupoId
                        select I;

            return query.ToList();
        }


        public List<Items> ObtenerItemsPorCategorias(int CategoriaId)
        {
            return SqlContext.Items.Where(o => o.CategoriaItemId == CategoriaId).ToList();
        }

        //public List<Items> ObtenerItemsAdicionales(int AdicionalId)
        //{
        //    var query = from I in SqlContext.Items
        //                join AI in SqlContext.AdicionalItem on I.Id equals AI.ItemId
        //                where AI.AdicionalId == AdicionalId
        //                select I;

        //    return query.ToList();
        //}

        public List<Items> ObtenerItemsPorCategoria(int categoriaId)
        {
            return SqlContext.Items.Where(o => o.CategoriaItemId == categoriaId).ToList();
        }

        public void ActualizarItem(Items item)
        {
            Items editItem = SqlContext.Items.Where(o => o.Id == item.Id).SingleOrDefault();

            editItem.Detalle = item.Detalle;
            editItem.Costo = item.Costo;
            editItem.Precio = item.Precio;
            editItem.Margen = item.Margen;
            editItem.EstadoId = item.EstadoId;

            SqlContext.SaveChanges();

        }

        public void ElimnarProductoCateringItems(int productoCateringId)
        {
            List<ProductosCateringItems> editPCI = SqlContext.ProductosCateringItems.Where(o => o.ProductoCateringId == productoCateringId).ToList();

            foreach (var item in editPCI)
            {
                SqlContext.ProductosCateringItems.Remove(item);
                SqlContext.SaveChanges();
            }
        }

        public void GuardarProductoCateringItems(ProductosCateringItems PCI)
        {
            if (PCI.Id > 0)
            {
                ProductosCateringItems editPCI = SqlContext.ProductosCateringItems.Where(o => o.Id == PCI.Id).SingleOrDefault();


                editPCI.ItemId = PCI.ItemId;
                editPCI.ProductoCateringId = PCI.ProductoCateringId;
            
            }
            else
            {
                SqlContext.ProductosCateringItems.Add(PCI);
                SqlContext.SaveChanges();
            }
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempoProducto(int TipoCateringId, int TiempoId, int ProductoCateringId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());
            int itemActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            var query = from C in SqlContext.TipoCateringTiempoProductoItem
                        join P in SqlContext.ProductosCatering on C.ProductoCateringId equals P.Id
                        join PCI in SqlContext.ProductosCateringItems on P.Id equals PCI.ProductoCateringId
                        join I in SqlContext.Items on PCI.ItemId equals I.Id
                        where C.TipoCateringId == TipoCateringId && C.TiempoId == TiempoId && C.ProductoCateringId == ProductoCateringId && C.EstadoId == activo && I.EstadoId == itemActivo
                        select I;


            return query.ToList();
                        
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempoCategorias(int TipoCateringId, int TiempoId, int CategoriaId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString());
            int itemActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            var query = from C in SqlContext.TipoCateringTiempoProductoItem
                        join Ca in SqlContext.CategoriasItem on C.CategoriaItemId equals Ca.Id
                        join I in SqlContext.Items on Ca.Id equals I.CategoriaItemId
                        where C.TipoCateringId == TipoCateringId && C.TiempoId == TiempoId && C.CategoriaItemId == CategoriaId && C.EstadoId == activo && I.EstadoId == itemActivo
                        select I;


            return query.ToList();
        }

        public List<Items> ObtenerItemsPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString()); ;
            int itemActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            var query = from C in SqlContext.TipoCateringTiempoProductoItem
                        join I in SqlContext.Items on C.ItemId equals I.Id
                        where C.TipoCateringId == TipoCateringId && C.TiempoId == TiempoId && C.EstadoId == activo && I.EstadoId == itemActivo
                        select I;


            return query.ToList();
        }

        public List<Items> ObtenerItemsPorTipoBarraCategorias(int TipoBarraId, int CategoriaItem)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoBarraCategoriaItemActivos"].ToString()); ;
            int itemActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            var query = from C in SqlContext.TipoBarraCategoriaItem
                        join Ca in SqlContext.CategoriasItem on C.CategoriaItemId equals Ca.Id
                        join I in SqlContext.Items on Ca.Id equals I.CategoriaItemId
                        where C.TipoBarraId == TipoBarraId && C.CategoriaItemId == CategoriaItem && C.EstadoId == activo && I.EstadoId == itemActivo
                        select I;


            return query.ToList();
        }

        public List<Items> ObtenerItemsPorTipoBarra(int TipoBarraId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoBarraCategoriaItemActivos"].ToString()); ;
            int itemActivo = Int32.Parse(ConfigurationManager.AppSettings["ItemActivo"].ToString());

            var query = from C in SqlContext.TipoBarraCategoriaItem
                        join I in SqlContext.Items on C.ItemId equals I.Id
                        where C.TipoBarraId == TipoBarraId && C.EstadoId == activo && I.EstadoId == itemActivo
                        select I;


            return query.ToList();
        }

        public List<Items> ListarItemsPorAdicional(int AdicionalId)
        {
            var query = from I in SqlContext.Items
                        join AI in SqlContext.AdicionalesItems on I.Id equals AI.ItemId
                        where AI.AdicionalId == AdicionalId
                        select I;


            return query.ToList();
        
        }

        public List<BuscarItemsporTipoCatering_Result> BuscarItemsPorTipoCatering(int TipoCateringId)
        {
            return SqlContext.BuscarItemsporTipoCatering(TipoCateringId).ToList();
        }
    }
}
