using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ItemDetalleNegocios
    {

        ItemDetalleDatos Datos;

        public ItemDetalleNegocios()
        {
            Datos = new ItemDetalleDatos();
        }

        public virtual List<ItemDetalle> ObtenerItemDetalle(ItemDetalleSearcher searcher)
        {
            return Datos.ObtenerItemDetalle(searcher);

        }

        public ItemDetalle BuscarItemDetalle(int id)
        {
            return Datos.BuscarItemDetalle(id);
        }

        public void NuevoItems(ItemDetalle item)
        {
            Datos.NuevoItemDetalle(item);
        }


    }
}
