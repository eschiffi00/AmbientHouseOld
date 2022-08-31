using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;
using System.Configuration;

namespace DomainAmbientHouse.Negocios
{
    public class ProductosCateringNegocios
    {

        ProductosCateringDatos Datos;

        ItemsDatos DatosItems;

        public ProductosCateringNegocios()
        {
            Datos = new ProductosCateringDatos();
            DatosItems = new ItemsDatos();

        }

        public virtual List<ProductosCatering> ObtenerProductosCatering()
        {

            return Datos.ObtenerProductosCatering();

        }

        public void NuevosProductosCatering(ProductosCatering producto,
                                            List<DomainAmbientHouse.Entidades.Items> ListItemsAsociados)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    DatosItems.ElimnarProductoCateringItems(producto.Id);

                    Datos.NuevosProductosCatering(producto);

                    foreach (var item in ListItemsAsociados)
                    {
                        ProductosCateringItems PCI = new ProductosCateringItems();

                        PCI.ItemId = item.Id;
                        PCI.ProductoCateringId = producto.Id;
                        


                        DatosItems.GuardarProductoCateringItems(PCI);
                    }



                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }

            }


        }




        public ProductosCatering BuscarProductoCatering(int id)
        {
            return Datos.BuscarProductoCatering(id);
        }

        public List<ProductosCatering> ObtenerProductosPorTipoCateringTiempo(int TipoCateringId, int TiempoId)
        {
            return Datos.ObtenerProductosPorTipoCateringTiempo(TipoCateringId, TiempoId);
        }

        internal void NuevosProductosCatering(ProductosCatering item)
        {
            Datos.NuevosProductosCatering(item);
        }
    }
}
