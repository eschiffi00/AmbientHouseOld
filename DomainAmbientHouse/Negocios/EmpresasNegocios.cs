using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class EmpresasNegocios
    {

        EmpresasDatos Datos;

        public EmpresasNegocios()
        {
            Datos = new EmpresasDatos();
        }

        public virtual List<Empresas> ObtenerEmpresas()
        {

            return Datos.ObtenerEmpresas();

        }

        public virtual List<Empresas> ObtenerEmpresasBlanco()
        {
            return Datos.ObtenerEmpresasBlanco();
        }


        internal List<Empresas> ObtenerEmpresasBlancoProveedores()
        {
            return Datos.ObtenerEmpresasBlancoProveedores();
        }
    }
}
