using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;
using System.Configuration;

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
