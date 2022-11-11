using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

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
