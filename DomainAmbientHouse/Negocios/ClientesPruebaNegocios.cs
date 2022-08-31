using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class ClientesPruebaNegocios
    {

        ClientesPruebaDatos Datos;

        public ClientesPruebaNegocios()
        {
            Datos = new ClientesPruebaDatos();
        }

        //public virtual List<ClientesPrueba> ObtenerClientes(int usuario)
        //{

        //    return Datos.ObtenerClientes(usuario);

        //}

    }
}
