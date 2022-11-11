using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class LocalidadesNegocios
    {

        LocalidadesDatos Datos;

        public LocalidadesNegocios()
        {
            Datos = new LocalidadesDatos();
        }

        public virtual List<Localidades> ObtenerLocalidades()
        {

            return Datos.ObtenerLocalidades();

        }


        public Localidades BuscarLocalidades(long id)
        {
            return Datos.BuscarLocalidades(id);
        }

        public void NuevaLocalidades(Localidades localidades)
        {
            Datos.NuevaLocalidades(localidades);
        }
    }
}
