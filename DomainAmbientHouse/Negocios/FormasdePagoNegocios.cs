using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

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
