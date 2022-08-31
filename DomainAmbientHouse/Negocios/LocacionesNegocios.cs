using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class LocacionesNegocios
    {

        LocacionesDatos Datos;
        SectoresDatos DatosSectores;

        public LocacionesNegocios()
        {
            Datos = new LocacionesDatos();
            DatosSectores = new SectoresDatos();
        }
        public virtual List<Locaciones> ObtenerLocaciones()
        {

            return Datos.ObtenerLocaciones();

        }

        public virtual List<Locaciones> ObtenerLocaciones(int usuario)
        {

            return Datos.ObtenerLocaciones(usuario);

        }

        public virtual List<Locaciones> ObtenerLocacionesParaCotizar()
        {

            return Datos.ObtenerLocacionesParaCotizar();

        }

        public virtual List<Locaciones> ObtenerLocacionesSinPrecios()
        {
            return Datos.ObtenerLocacionesSinPrecios();
        }

        public virtual Locaciones BuscarLocaciones(int locacionId)
        {
            return Datos.BuscarLocaciones(locacionId);
        }

        public void NuevaLocacion(Locaciones Locacion, List<Sectores> ListSectores)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    Datos.NuevaLocacion(Locacion);

                    foreach (var item in ListSectores)
                    {
                        item.LocacionId = Locacion.Id;

                        DatosSectores.NuevoSectores(item);

                    }

                    scope.Complete();

                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                    throw ex;
                }
            }


        }

        public List<LocacionesValorAnio> ObtenerCostosSalonesPorAnios()
        {
            return Datos.ObtenerCostosSalonesPorAnios();
        }

        public LocacionesValorAnio BuscarLocacionesValorAnio(int id)
        {
            return Datos.BuscarLocacionesValorAnio(id);
        }

        public void NuevoLocacionesValorAnio(LocacionesValorAnio locacionesValorAnio)
        {
            Datos.NuevoLocacionesValorAnio(locacionesValorAnio);
        }

        public bool ObtenerLocacionesValorAnio(int anio, int locacionId)
        {
            return Datos.ObtenerLocacionesValorAnio(anio, locacionId);
        }

        public void GrabarTecnicaSalon(int  sectorId, List<TecnicaSalon> list)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Datos.EliminarProveedorTecnicaLocacionSector(sectorId);



                    foreach (var item in list)
                    {
                        TecnicaSalon tecSalon = new TecnicaSalon();

                        tecSalon.SectorId = item.SectorId;
                        tecSalon.LocacionId = item.LocacionId;
                        tecSalon.ProveedorId = item.ProveedorId;

                        Datos.NuevaTecnicaSalonProveedor(tecSalon);
                    }


                    scope.Complete();


                }
                catch (Exception ex)
                {
                    DomainAmbientHouse.Servicios.Log.save(this, ex);
                    throw ex;
                }
            }

     
        }

        public List<Locaciones> ObtenerLocacionesOUT()
        {
           return  Datos.ObtenerLocacionesOUT();
        }

        internal List<Locaciones> ObtenerLocacionesParaCotizarPorLocacion(int localidadId,string tieneVerde, string estacionamiento, string aireLibre)
        {
            return Datos.ObtenerLocacionesParaCotizarPorLocacion(localidadId,tieneVerde,  estacionamiento,  aireLibre);
        }

        internal List<CargarCostosSalones_Result> CargarPrecioCostosSalon(ParametrosCostoSalones param)
        {
            return Datos.CargarPrecioCostosSalon(param);
        }
    }
}
