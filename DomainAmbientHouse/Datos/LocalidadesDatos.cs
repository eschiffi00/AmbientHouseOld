using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class LocalidadesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public LocalidadesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Localidades> ObtenerLocalidades()
        {

            return SqlContext.Localidades.ToList();

        }


        public Localidades BuscarLocalidades(long id)
        {
            return SqlContext.Localidades.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevaLocalidades(Localidades localidades)
        {
            if (localidades.Id > 0)
            {

                Localidades catLoc = SqlContext.Localidades.Where(o => o.Id == localidades.Id).First();

                catLoc.Descripcion = localidades.Descripcion;



                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Localidades.Add(localidades);
                SqlContext.SaveChanges();
            }
        }
    }
}
