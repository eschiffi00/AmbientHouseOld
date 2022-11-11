using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class ProductosCateringDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ProductosCateringDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ProductosCatering> ObtenerProductosCatering()
        {


            return SqlContext.ProductosCatering.ToList();



        }

        public virtual void NuevosProductosCatering(ProductosCatering producto)
        {
            if (producto.Id > 0)
            {
                ProductosCatering editPC = SqlContext.ProductosCatering.Where(o => o.Id == producto.Id).FirstOrDefault();

                editPC.Descripcion = producto.Descripcion;
                editPC.EstadoId = producto.EstadoId;

                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.ProductosCatering.Add(producto);
                SqlContext.SaveChanges();
            }

        }



        public ProductosCatering BuscarProductoCatering(int id)
        {
            return SqlContext.ProductosCatering.Where(o => o.Id == id).SingleOrDefault();
        }

        public List<ProductosCatering> ObtenerProductosPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            int activo = Int32.Parse(ConfigurationManager.AppSettings["TipoCateringTiempoProductoItemctivo"].ToString()); ;

            var query = from P in SqlContext.ProductosCatering
                        join C in SqlContext.TipoCateringTiempoProductoItem on P.Id equals C.ProductoCateringId
                        where C.TipoCateringId == TipoCateringId && C.TiempoId == TiempoId && C.EstadoId == activo && P.EstadoId == 1
                        select P;

            return query.ToList();
        }


    }
}
