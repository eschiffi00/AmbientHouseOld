using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
