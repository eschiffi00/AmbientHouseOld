using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class MomentosDiaDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public MomentosDiaDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<MomentosDias> ObtenerMomentosDia()
        {

            return SqlContext.MomentosDias.ToList();

        }


        public MomentosDias BuscarMomentosDias(int id)
        {
            return SqlContext.MomentosDias.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoMomentoDia(MomentosDias item)
        {

            if (item.Id > 0)
            {

                MomentosDias itemEdit = SqlContext.MomentosDias.Where(o => o.Id == item.Id).First();


                itemEdit.Descripcion = item.Descripcion;




                SqlContext.SaveChanges();
            }
            else
            {



                SqlContext.MomentosDias.Add(item);
                SqlContext.SaveChanges();
            }
        }

    }
}
