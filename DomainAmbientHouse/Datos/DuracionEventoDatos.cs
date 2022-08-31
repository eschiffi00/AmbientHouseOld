using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class DuracionEventoDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public DuracionEventoDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }
        
        public virtual List<DuracionEvento> ObtenerDuracionEvento()
        {

            return SqlContext.DuracionEvento.ToList();

        }


        public DuracionEvento BuscarDuracion(int id)
        {
            return SqlContext.DuracionEvento.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevaDuracionEvento(DuracionEvento item)
        {

            if (item.Id > 0)
            {

                DuracionEvento itemEdit = SqlContext.DuracionEvento.Where(o => o.Id == item.Id).First();


                itemEdit.Descripcion = item.Descripcion;




                SqlContext.SaveChanges();
            }
            else
            {



                SqlContext.DuracionEvento.Add(item);
                SqlContext.SaveChanges();
            }
        }

    }
}
