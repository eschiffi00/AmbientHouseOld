using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class INVENTARIOUnidadesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public INVENTARIOUnidadesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<INVENTARIO_Unidades> ListarUnidades()
        {


            var query = from Tm in SqlContext.INVENTARIO_Unidades
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                          
                        };



            List<INVENTARIO_Unidades> Salida = new List<INVENTARIO_Unidades>();
            foreach (var item in query)
            {

                INVENTARIO_Unidades cat = new INVENTARIO_Unidades();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
              
                Salida.Add(cat);
            }

            return Salida.ToList();


        }




        internal INVENTARIO_Unidades BuscarINVENTARIOUnidades(int Id)
        {
            return SqlContext.INVENTARIO_Unidades.Where(o => o.Id == Id).FirstOrDefault();
        }
    }
}
