using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class UsuariosGruposNegocios
    {

        UsuariosGruposDatos Datos;

        public UsuariosGruposNegocios()
        {
            Datos = new UsuariosGruposDatos();
        }

        public virtual List<UsuariosGrupos> ObtenerGrupos()
        {

            return Datos.ObtenerGrupos();

        }


    }
}
