using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class FormasdePagoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public FormasdePagoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<FormasdePago> ObtenerFormasdePago()
        {

            return SqlContext.FormasdePago.ToList();

        }

        public List<ProveedoresFormasdePago> BuscarFormasdePagoPorProveedor(int ProveedorId)
        {
            var query = from RUP in SqlContext.ProveedoresFormasdePago
                        join R in SqlContext.FormasdePago on RUP.FormadePagoId equals R.Id
                        where RUP.ProveedorId == ProveedorId
                        select new
                        {
                            Id = RUP.Id,
                            FormaPagoId = RUP.FormadePagoId,
                            Descripcion = R.Descripcion

                        };

            List<ProveedoresFormasdePago> Salida = new List<ProveedoresFormasdePago>();

            foreach (var item in query)
            {
                ProveedoresFormasdePago ruproveedor = new ProveedoresFormasdePago();

                ruproveedor.Id = item.Id;
                ruproveedor.FormadePagoId = item.FormaPagoId;
                ruproveedor.Descripcion = item.Descripcion;


                Salida.Add(ruproveedor);
            }


            return Salida;
        }

    }
}
