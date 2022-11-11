using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class ComisionesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ComisionesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Comisiones> ObtenerComisiones()
        {

            return SqlContext.Comisiones.ToList();

        }


        public Comisiones BuscarComisiones(int id)
        {
            return SqlContext.Comisiones.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevaComisiones(Comisiones comisiones)
        {
            if (comisiones.Id > 0)
            {

                Comisiones catEdit = SqlContext.Comisiones.Where(o => o.Id == comisiones.Id).First();

                catEdit.Descripcion = comisiones.Descripcion;
                catEdit.Porcentaje = comisiones.Porcentaje;
                catEdit.PorcentajeAdicional = comisiones.PorcentajeAdicional;


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Comisiones.Add(comisiones);
                SqlContext.SaveChanges();
            }
        }

        public Comisiones BuscarComisiones(string descripcion)
        {
            return SqlContext.Comisiones.Where(o => o.Descripcion.Contains(descripcion)).FirstOrDefault();
        }

        public Comisiones BuscarComisionPorUnidadNegocioPrecioSeleccionado(int UnidadNegocioParaAdicional, string PrecioParaAdicional)
        {
            return SqlContext.Comisiones.Where(o => o.UnidadNegocioId == UnidadNegocioParaAdicional
                                                && o.Precio.Contains(PrecioParaAdicional)).FirstOrDefault();
        }
    }
}
