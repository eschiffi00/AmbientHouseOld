using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
