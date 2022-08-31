using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class CostosPaquetesCIAmbientacionNegocios
    {

        CostosPaquetesCIAmbientacionDatos Datos;

        public CostosPaquetesCIAmbientacionNegocios()
        {
            Datos = new CostosPaquetesCIAmbientacionDatos();
        }

        public virtual List<CostosPaquetesCIAmbientacion> ObtenerCostosPaquetesCIAmbientacion()
        {

            return Datos.ObtenerCostosPaquetesCIAmbientacion();

        }

        public virtual CostosPaquetesCIAmbientacion BuscarCostosPaquetesCIAmbientacion(int Id)
        {

            return Datos.BuscarCostosPaquetesCIAmbientacion(Id);

        }

        public virtual CostosPaquetesCIAmbientacion BuscarPreciosPaquetesCIAmbientacion(int paqueteId, int caracteristicaId, 
                                                                                        int segmentoId, int proveedorId,
                                                                                        int cantidadPaquetes,int semestre, int anio)
        {

            return Datos.BuscarPreciosPaquetesCIAmbientacion(paqueteId,caracteristicaId,segmentoId,proveedorId,cantidadPaquetes,semestre,anio);

        }

        public void Grabar(CostosPaquetesCIAmbientacion costos)
        {
            Datos.Grabar(costos);
        }


        internal List<CostosPaquetesCIAmbientacion> ListarCostosPaquetesCIAmbientacionPorProveedor(int proveedorId)
        {
            return Datos.ListarCostosPaquetesCIAmbientacionPorProveedor(proveedorId);
        }
    }
}
