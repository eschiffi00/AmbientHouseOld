using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;

namespace DomainAmbientHouse.Servicios
{
    public class ProveedoresServicios
    {

        ProveedoresNegocios Negocios;
       

        public ProveedoresServicios()
        {
            Negocios = new ProveedoresNegocios();
         
        }

     
        public List<Proveedores> ObtenerProveedores()
        {

            return Negocios.ObtenerProveedores();
        }


        //public void NuevoProveedor(Proveedores proveedor)
        //{

        //    Negocios.NuevoProveedor(proveedor);
        //}

    
        public Proveedores GetProveedor(int proveedorId)
        {
            return Negocios.GetProveedor(proveedorId);
        }


        public Proveedores BuscarProveedoresPorCuit(string nrocuit)
        {
            return Negocios.BuscarProveedoresPorCuit(nrocuit);
        }
    }
}
