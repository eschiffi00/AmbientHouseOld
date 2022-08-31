using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ClientesPruebaDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ClientesPruebaDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        //public virtual List<ClientesPrueba> ObtenerClientes(int usuario)
        //{
        //    return SqlContext.ClientesPrueba.Where(o=> o.propietario == usuario).ToList();
        //}

    }
}
