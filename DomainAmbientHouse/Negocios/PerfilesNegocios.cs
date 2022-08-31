using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
