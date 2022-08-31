using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class UnidadesNegociosNegocios
    {

        UnidadesNegociosDatos Datos;

        public UnidadesNegociosNegocios()
        {
            Datos = new UnidadesNegociosDatos();
        }

        public virtual List<UnidadesNegocios> ObtenerUnidadesNegociosPorDepartamento()
        {

            return Datos.ObtenerUnidadesNegociosPorDepartamento();

        }

        public List<UnidadesNegocios> ObtenerUN()
        {
            return Datos.ObtenerUN();
        }

        public UnidadesNegocios BuscarUnidadesNegocios(int id)
        {
           return Datos.BuscarUnidadesNegocios( id);
        }

        public void NuevoUnidadesNegocios(UnidadesNegocios rubro)
        {
            Datos.NuevoUnidadesNegocios(rubro);
        }

        public List<UnidadesNegocios> ObtenerUnidadesNegocios()
        {
            return Datos.ObtenerUnidadesNegocios();
        }

        public List<UnidadesNegocios> ObtenerUNCotizador()
        {
            return Datos.ObtenerUNCotizador();
        }

        public List<UnidadesNegocios_Proveedores> BuscarUnidadesNegociosPorProveedor(int ProveedorId)
        {
            return Datos.BuscarUnidadesNegociosPorProveedor(ProveedorId);
        }

        public List<UnidadesNegocios> ObtenerUN(List<UnidadesNegocios> ListUN)
        {
            return Datos.ObtenerUN(ListUN);
        }

        public List<UnidadesNegocios> ObtenerUNReporte()
        {
            return Datos.ObtenerUNReporte();
        }
    }
}
