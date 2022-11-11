using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class FormasdePagoNegocios
    {

        FormasdePagoDatos Datos;

        public FormasdePagoNegocios()
        {
            Datos = new FormasdePagoDatos();
        }

        public virtual List<FormasdePago> ObtenerFormasdePago()
        {
            return Datos.ObtenerFormasdePago();
        }


        internal List<ProveedoresFormasdePago> BuscarFormasdePagoPorProveedor(int ProveedorId)
        {
            return Datos.BuscarFormasdePagoPorProveedor(ProveedorId);
        }
    }
}
