using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class AmbientacionCIDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public AmbientacionCIDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<AmbientacionCI> ObtenerAmbientacionesCI()
        {

            return SqlContext.AmbientacionCI.ToList();


        }

        public virtual void Grabar(AmbientacionCI ambientacion)
        {
            if (ambientacion.Id > 0)
            {
                AmbientacionCI edit = Buscar(ambientacion.Id);


                edit.Descripcion = ambientacion.Descripcion;
                edit.Flete = ambientacion.Flete;
                edit.EstadoId = ambientacion.EstadoId;

                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.AmbientacionCI.Add(ambientacion);
                SqlContext.SaveChanges();
            }
        }

        public virtual AmbientacionCI Buscar(int Id)
        {
            return SqlContext.AmbientacionCI.Where(o => o.Id == Id).FirstOrDefault();
        }

    }
}
