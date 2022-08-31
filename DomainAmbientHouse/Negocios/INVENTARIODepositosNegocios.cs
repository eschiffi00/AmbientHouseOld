using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class INVENTARIODepositosNegocios
    {

        INVENTARIODepositosDatos Datos;

        public INVENTARIODepositosNegocios()
        {
            Datos = new INVENTARIODepositosDatos();
        }

        public virtual List<INVENTARIO_Depositos> ListarDepositos()
        {
            return Datos.ListarDepositos();
        }

    }
}
