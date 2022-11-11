using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
