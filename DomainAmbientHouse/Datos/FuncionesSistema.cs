using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class FuncionesSistemasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public FuncionesSistemasDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual void ActualizarPresupuestosVencidos()
        {

            int resultado = SqlContext.ActualizarPresupuestosVencidos();

        }
    }
}
