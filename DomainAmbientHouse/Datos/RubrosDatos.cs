using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class RubrosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public RubrosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }


        public List<Rubros> ObtenerRubros()
        {
            return SqlContext.Rubros.ToList();

        }

        public Rubros BuscarRubro(int id)
        {
            return SqlContext.Rubros.Where(o => o.RubroId == id).FirstOrDefault();
        }

        public void NuevoRubro(Rubros rubro)
        {
            if (rubro.RubroId > 0)
            {

                Rubros rubroEdit = SqlContext.Rubros.Where(o => o.RubroId == rubro.RubroId).First();

                rubroEdit.Descripcion = rubro.Descripcion;
                rubroEdit.LetraCodigo = rubro.LetraCodigo;


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Rubros.Add(rubro);
                SqlContext.SaveChanges();
            }
        }



        public List<Rubros_Proveedores> BuscarRubroPorProveedor(int ProveedorId)
        {
            var query = from RUP in SqlContext.Rubros_Proveedores
                        join R in SqlContext.Rubros on RUP.RubroId equals R.RubroId
                        where RUP.ProveedorId == ProveedorId
                        select new
                        {
                            Id = RUP.Id,
                            RubroId = RUP.RubroId,
                            Descripcion = R.Descripcion

                        };


            List<Rubros_Proveedores> Salida = new List<Rubros_Proveedores>();
            foreach (var item in query)
            {
                Rubros_Proveedores ruproveedor = new Rubros_Proveedores();

                ruproveedor.Id = item.Id;
                ruproveedor.RubroId = item.RubroId;
                ruproveedor.Descripcion = item.Descripcion;


                Salida.Add(ruproveedor);
            }

            return Salida;
        }

        public CodigoPorRubro BuscarCodigoPorRubro(int rubroId)
        {
            return SqlContext.CodigoPorRubro.Where(o => o.RubroId == rubroId).FirstOrDefault();

        }

        internal Rubros BuscarRubroPorProducto(int productoId)
        {
            var query = from r in SqlContext.Rubros
                        join p in SqlContext.INVENTARIO_Producto on r.RubroId equals p.RubroId
                        where p.Id == productoId
                        select r;

            return query.SingleOrDefault();

        }
    }
}
