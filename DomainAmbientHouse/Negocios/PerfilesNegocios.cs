using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class PerfilesNegocios
    {

        PerfilesDatos Datos;

        public PerfilesNegocios()
        {
            Datos = new PerfilesDatos();
        }

        public virtual List<Perfiles> ObtenerPerfiles()
        {

            return Datos.ObtenerPerfiles();

        }

        public Perfiles BuscarPerfil(int id)
        {
            return Datos.BuscarPerfil(id);
        }

        public void NuevaPerfil(Perfiles perfil)
        {
            Datos.NuevaPerfil(perfil);
        }


    }
}
