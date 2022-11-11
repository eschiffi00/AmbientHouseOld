using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class BancosNegocios
    {

        BancosDatos Datos;

        public BancosNegocios()
        {
            Datos = new BancosDatos();
        }

        public virtual List<Bancos> ObtenerBancos()
        {

            return Datos.ObtenerBancos();

        }

    }
}
