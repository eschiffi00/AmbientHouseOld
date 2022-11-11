using DomainAmbientHouse.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class CostosPaquetesCIAmbientacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public CostosPaquetesCIAmbientacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        private List<CostosPaquetesCIAmbientacion> CostosPaquetesCIAmbientacionToModel(IQueryable<CostosPaquetesCIAmbientacion> query)
        {



            List<CostosPaquetesCIAmbientacion> list = new List<CostosPaquetesCIAmbientacion>();

            foreach (var item in query)
            {
                CostosPaquetesCIAmbientacion salida = new CostosPaquetesCIAmbientacion();

                salida.Id = item.Id;
                salida.CaracteristicaId = item.CaracteristicaId;
                salida.CaracteristicaDescripcion = SqlContext.Caracteristicas.Where(o => o.Id == item.CaracteristicaId).FirstOrDefault().Descripcion;
                salida.SegmentoId = item.SegmentoId;
                salida.SegmentosDescripcion = SqlContext.Segmentos.Where(o => o.Id == item.SegmentoId).FirstOrDefault().Descripcion;
                salida.ProveedorId = item.ProveedorId;
                salida.RazonSocial = SqlContext.Proveedores.Where(o => o.Id == item.ProveedorId).FirstOrDefault().RazonSocial;
                salida.Semestre = item.Semestre;
                salida.Anio = item.Anio;
                salida.PaqueteCIID = item.PaqueteCIID;
                salida.PaqueteCIDescripcion = SqlContext.AmbientacionCI.Where(o => o.Id == item.PaqueteCIID).FirstOrDefault().Descripcion;
                salida.CantidadPaquetes = item.CantidadPaquetes;
                salida.Precio = item.Precio;
                salida.Costo = item.Costo;
                salida.CostoFlete = item.CostoFlete;
                salida.Margen = item.Margen;





                list.Add(salida);
            }

            return list;
        }

        public virtual List<CostosPaquetesCIAmbientacion> ObtenerCostosPaquetesCIAmbientacion()
        {


            var query = from p in SqlContext.CostosPaquetesCIAmbientacion
                        select p;

            return CostosPaquetesCIAmbientacionToModel(query).ToList();


        }

        public virtual CostosPaquetesCIAmbientacion BuscarCostosPaquetesCIAmbientacion(int Id)
        {
            var query = from p in SqlContext.CostosPaquetesCIAmbientacion
                        where p.Id == Id
                        select p;


            return CostosPaquetesCIAmbientacionToModel(query).FirstOrDefault();

        }

        public virtual CostosPaquetesCIAmbientacion BuscarPreciosPaquetesCIAmbientacion(int paqueteId, int caracteristicaId,
                                                                                        int segmentoId, int proveedorId,
                                                                                        int cantidadPaquetes, int semestre, int anio)
        {

            return SqlContext.CostosPaquetesCIAmbientacion.Where(o => o.PaqueteCIID == paqueteId && o.CaracteristicaId == caracteristicaId
                                                                    && o.SegmentoId == segmentoId && o.ProveedorId == proveedorId
                                                                    && o.CantidadPaquetes >= cantidadPaquetes && o.Semestre == semestre
                                                                    && o.Anio == anio).FirstOrDefault();
        }

        public void Grabar(CostosPaquetesCIAmbientacion costos)
        {
            double margen = 0;

            if (costos.Id > 0)
            {
                CostosPaquetesCIAmbientacion edit = SqlContext.CostosPaquetesCIAmbientacion.Where(o => o.Id == costos.Id).FirstOrDefault();

                if (costos.Costo > 0)
                    margen = costos.Precio / costos.Costo;
                else
                    margen = 0;

                edit.CaracteristicaId = costos.CaracteristicaId;
                edit.SegmentoId = costos.SegmentoId;
                edit.ProveedorId = costos.ProveedorId;
                edit.Anio = costos.Anio;
                edit.CantidadPaquetes = costos.CantidadPaquetes;
                edit.Costo = costos.Costo;
                edit.CostoFlete = costos.CostoFlete;
                edit.Margen = margen;
                edit.Precio = costos.Precio;
                edit.Semestre = costos.Semestre;

                SqlContext.SaveChanges();

            }
            else
            {
                if (costos.Costo > 0)
                    margen = costos.Precio / costos.Costo;
                else
                    margen = 0;

                costos.Margen = margen;

                SqlContext.CostosPaquetesCIAmbientacion.Add(costos);
                SqlContext.SaveChanges();

            }
        }

        internal List<CostosPaquetesCIAmbientacion> ListarCostosPaquetesCIAmbientacionPorProveedor(int proveedorId)
        {
            return SqlContext.CostosPaquetesCIAmbientacion.Where(o => o.ProveedorId == proveedorId).ToList();
        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class CostosPaquetesCIAmbientacion
    {

        public string CaracteristicaDescripcion { get; set; }

        public string SegmentosDescripcion { get; set; }

        public string PaqueteCIDescripcion { get; set; }

        public string RazonSocial { get; set; }
    }

}

