using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class RubrosNegocios
    {

        RubrosDatos Datos;

        public RubrosNegocios()
        {
            Datos = new RubrosDatos();
        }


        public List<Rubros> ObtenerRubros()
        {
            return Datos.ObtenerRubros();
        }

        public Rubros BuscarRubro(int id)
        {
            return Datos.BuscarRubro(id);
        }

        public void NuevoRubro(Rubros rubro)
        {
            Datos.NuevoRubro(rubro);
        }


        public List<Rubros_Proveedores> BuscarRubroPorProveedor(int ProveedorId)
        {
            return Datos.BuscarRubroPorProveedor(ProveedorId);
        }

        public CodigoPorRubro BuscarCodigoPorRubro(int rubroId)
        {
            return Datos.BuscarCodigoPorRubro(rubroId);
        }



        internal Rubros BuscarRubroPorProducto(int productoId)
        {
            return Datos.BuscarRubroPorProducto(productoId);
        }
    }
}
