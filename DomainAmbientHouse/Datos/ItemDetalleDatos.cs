using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class ItemDetalleDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ItemDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ItemDetalle> ObtenerItemDetalle(ItemDetalleSearcher searcher)
        {

            var query = from Id in SqlContext.ItemDetalle
                        select Id;

            //if (!string.IsNullOrEmpty(searcher.Descripcion))
            //    query = query.Where(o => o.Descripcion.Contains(searcher.Descripcion));

            return query.ToList();

        }

        public ItemDetalle BuscarItemDetalle(int id)
        {
            return SqlContext.ItemDetalle.Where(o => o.Id == id).First();
        }

        public void NuevoItemDetalle(ItemDetalle item)
        {

            if (item.Id > 0)
            {

                ItemDetalle itemEdit = SqlContext.ItemDetalle.Where(o => o.Id == item.Id).First();

                //itemEdit.Descripcion = item.Descripcion;

                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.ItemDetalle.Add(item);
                SqlContext.SaveChanges();
            }
        }


    }

    public class ItemDetalleSearcher
    {
        public string Descripcion { get; set; }

    }
}
