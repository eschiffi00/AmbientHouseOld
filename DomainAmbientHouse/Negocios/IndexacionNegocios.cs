using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Negocios
{
    public class IndexacionNegocios
    {

        IndexacionDatos Datos;

        public IndexacionNegocios()
        {
            Datos = new IndexacionDatos();
        }

        public virtual Indexacion BuscarIndexacionVigente()
        {

            return Datos.BuscarIndexacionVigente();

        }

    }
}
