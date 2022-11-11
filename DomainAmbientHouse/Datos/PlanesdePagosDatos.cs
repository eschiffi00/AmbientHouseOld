using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class PlanesDePagosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public PlanesDePagosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<PlanesDePago> ObtenerPlanesDePagos()
        {

            return SqlContext.PlanesDePago.ToList();

        }


        public PlanesDePago BuscarPlanesDePago(int id)
        {
            return SqlContext.PlanesDePago.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevaPlanesDePago(PlanesDePago planesDePago)
        {
            if (planesDePago.Id > 0)
            {

                PlanesDePago catEdit = SqlContext.PlanesDePago.Where(o => o.Id == planesDePago.Id).First();

                catEdit.Descripcion = planesDePago.Descripcion;
                catEdit.Indice = planesDePago.Indice;


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.PlanesDePago.Add(planesDePago);
                SqlContext.SaveChanges();
            }
        }


    }
}
