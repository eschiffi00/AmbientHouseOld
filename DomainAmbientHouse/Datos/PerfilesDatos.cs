using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class PerfilesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public PerfilesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Perfiles> ObtenerPerfiles()
        {

            return SqlContext.Perfiles.ToList();

        }


        public Perfiles BuscarPerfil(int id)
        {
            return SqlContext.Perfiles.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevaPerfil(Perfiles perfiles)
        {
            if (perfiles.Id > 0)
            {

                Perfiles catEdit = SqlContext.Perfiles.Where(o => o.Id == perfiles.Id).First();

                catEdit.Descripcion = perfiles.Descripcion;



                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Perfiles.Add(perfiles);
                SqlContext.SaveChanges();
            }
        }


    }
}
