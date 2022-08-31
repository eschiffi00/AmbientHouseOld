using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class INVENTARIODepositosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public INVENTARIODepositosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        private List<INVENTARIO_Depositos> InventarioDepositosToModel(IQueryable<INVENTARIO_Depositos> query)
        {

            List<INVENTARIO_Depositos> list = new List<INVENTARIO_Depositos>();

            foreach (var item in query)
            {
                INVENTARIO_Depositos salida = new INVENTARIO_Depositos();

                salida.Id = item.Id;
                salida.Descripcion = item.Descripcion;
             

                list.Add(salida);
            }


            return list.ToList();

        }

        public virtual List<INVENTARIO_Depositos> ListarDepositos()
        {
            var query = from d in SqlContext.INVENTARIO_Depositos
                        where d.Delete == false
                        select d;

            return this.InventarioDepositosToModel(query).ToList();
            

        }




        internal INVENTARIO_Unidades BuscarINVENTARIOUnidades(int Id)
        {
            return SqlContext.INVENTARIO_Unidades.Where(o => o.Id == Id).FirstOrDefault();
        }
    }
}
