using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class MovimientosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public MovimientosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual void NuevoMovimiento(Movimientos mov)
        {
            SqlContext.Movimientos.Add(mov);
            SqlContext.SaveChanges();
        }

    }
}
