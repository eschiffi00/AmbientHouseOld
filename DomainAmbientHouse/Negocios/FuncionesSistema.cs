using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class FuncionesSistemaNegocios
    {

        FuncionesSistemasDatos Datos;

        public FuncionesSistemaNegocios()
        {
            Datos = new FuncionesSistemasDatos();
        }

        public virtual void ActualizarPresupuestosVencidos()
        {

            Datos.ActualizarPresupuestosVencidos();

        }

    }
}
