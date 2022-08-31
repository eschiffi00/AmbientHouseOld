using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class CondicionIvaNegocios
    {

        CondicionIvaDatos Datos;

        public CondicionIvaNegocios()
        {
            Datos = new CondicionIvaDatos();
        }

        public virtual List<CondicionIva> ListarCondicionIva()
        {
            return Datos.ListarCondicionIva();
        }

        public virtual CondicionIva BuscarCondicionIva(int Id)
        {
            return Datos.BuscarCondicionIva(Id);
        }

    }
}
