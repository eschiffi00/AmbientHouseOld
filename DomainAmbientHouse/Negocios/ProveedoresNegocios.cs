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
    public class ProveedoresNegocios
    {

        ProveedoresDatos Datos;

        public ProveedoresNegocios()
        {
            Datos = new ProveedoresDatos();
        }

        public virtual List<Proveedores> BuscarProveedoresporUnidadesNegocios(int unidadNegocioId)
        {

            return Datos.BuscarProveedoresporUnidadesNegocios(unidadNegocioId);

        }

        public virtual List<Proveedores> ListarProveedores()
        {

            return Datos.ListarProveedores();
        }

        public Proveedores GetProveedor(int proveedorId)
        {
            return Datos.GetProveedor(proveedorId);
        }

        public void NuevoProveedor(Proveedores proveedor, 
                                    List<UnidadesNegocios_Proveedores> ListUnidadesNegociosProveedores, 
                                    List<Rubros_Proveedores> ListRubrosProveedores,
                                    List<ProveedoresFormasdePago> ListProveedoresFormasdePago)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Datos.EliminarUnidadNegocioProveedor(proveedor.Id);

                    Datos.EliminarRubroProveedor(proveedor.Id);

                    Datos.EliminarFormasdePagoProveedor(proveedor.Id);

                    Datos.NuevoProveedor(proveedor);

                    foreach (var item in ListUnidadesNegociosProveedores)
                    {
                        UnidadesNegocios_Proveedores UNProveedores = new UnidadesNegocios_Proveedores();

                        UNProveedores.ProveedorId = proveedor.Id;
                        UNProveedores.UnidadNegocioId = item.UnidadNegocioId;

                        Datos.NuevaUnidadNegocioProveedor(UNProveedores);
                    }

                    foreach (var item in ListRubrosProveedores)
                    {
                        Rubros_Proveedores RubroProveedores = new Rubros_Proveedores();

                        RubroProveedores.ProveedorId = proveedor.Id;
                        RubroProveedores.RubroId = item.RubroId;

                        Datos.NuevoRubroProveedor(RubroProveedores);

                    }

                    foreach (var item in ListProveedoresFormasdePago)
                    {
                        ProveedoresFormasdePago proveedoresFormasdePago = new ProveedoresFormasdePago();

                        proveedoresFormasdePago.ProveedorId = proveedor.Id;
                        proveedoresFormasdePago.FormadePagoId = item.FormadePagoId;

                        Datos.NuevaFormadePagoProveedores(proveedoresFormasdePago);

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

        public virtual List<Proveedores> ObtenerProveedores()
        {
            return Datos.ObtenerProveedores();
        }

        public Proveedores BuscarProveedor(int id)
        {
            return Datos.BuscarProveedor(id);
        }

        public List<Proveedores> BuscarProveedorLista(int id)
        {
            return Datos.BuscarProveedorLista(id);
        }

        public List<Proveedores> ObtenerProveedoresCotizador()
        {
            return Datos.ObtenerProveedoresCotizador();
        }

        internal List<Proveedores> TraerProveedores(List<int> list)
        {
            return Datos.TraerProveedores(list);
        }

        public List<Proveedores> ObtenerProveedoresPorProveedores(List<int?> listProveedorId)
        {
            return Datos.ObtenerProveedoresPorProveedores(listProveedorId);
        }

        public List<AmbientacionSalon> ObtenerProveedorAmbientacionPorLocacionSector(int LocacionId, int sectorId)
        {
            return Datos.ObtenerProveedorAmbientacionPorLocacionSector(LocacionId, sectorId);
        }

        public void GrabarProveedoresAmbientacion(int sectorId, List<AmbientacionSalon> ListAmbientacionSalon)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    Datos.EliminarProveedorAmbientacionLocacionSector(sectorId);



                    foreach (var item in ListAmbientacionSalon)
                    {
                        AmbientacionSalon ambSalon = new AmbientacionSalon();

                        ambSalon.SectorId = item.SectorId;
                        ambSalon.LocacionId = item.LocacionId;
                        ambSalon.ProveedorId = item.ProveedorId;

                        Datos.NuevaAmbientacionSalonProveedor(ambSalon);
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

        internal List<TecnicaSalon> ObtenerProveedorTecnicaPorLocacionSector(int LocacionId, int sectorId)
        {
            return Datos.ObtenerProveedorTecnicaPorLocacionSector(LocacionId, sectorId);
        }

        internal void GrabarProveedoresExternos(OrganizacionPresupuestoProveedoresExternos proveedor)
        {
            Datos.GrabarProveedoresExternos(proveedor);
        }

        public List<OrganizacionPresupuestoProveedoresExternos> ObtenerProveedoresExternosPorPresupuesto(int presupuestoId)
        {
            return Datos.ObtenerProveedoresExternosPorPresupuesto(presupuestoId);
        }

        internal OrganizacionPresupuestoProveedoresExternos BuscarOrganizacionPresupuestoProveedoresExternos(int Id)
        {
            return Datos.BuscarOrganizacionPresupuestoProveedoresExternos(Id);
        }

        internal void EliminarProveedoresExternos(OrganizacionPresupuestoProveedoresExternos proveedor)
        {
            Datos.EliminarProveedoresExternos( proveedor);
        }

        internal List<OrganizacionPresupuestoTimming> ObtenerTimmingPorPresupuesto(int PresupuestoId)
        {
            return Datos.ObtenerTimmingPorPresupuesto(PresupuestoId);
        }

        internal void GrabarTimming(OrganizacionPresupuestoTimming timming)
        {
            Datos.GrabarTimming(timming);
        }

        internal OrganizacionPresupuestoTimming BuscarOrganizacionTimming(int Id)
        {
            return Datos.BuscarOrganizacionTimming(Id);
        }

        internal void EliminarTimming(OrganizacionPresupuestoTimming timming)
        {
            Datos.EliminarTimming(timming);
        }

        internal List<OrganizacionPresupuestosArchivos> ObtenerArchivosPorPresupuesto(int PresupuestoId)
        {
            return Datos.ObtenerArchivosPorPresupuesto(PresupuestoId);
        }

        internal void GrabarArchivos(OrganizacionPresupuestosArchivos archivo)
        {
            Datos.GrabarArchivo(archivo);
        }

        internal OrganizacionPresupuestosArchivos BuscarOrganizacionArchivo(int Id)
        {
            return Datos.BuscarOrganizacionArchivo(Id);
        }

        internal void EliminarArchivo(OrganizacionPresupuestosArchivos archivo)
        {
            Datos.EliminarArchivo(archivo);
        }

        internal List<OrganizacionPresupuestosArchivos> ObtenerArchivosPorPresupuestoPorUsuario(int PresupuestoId, int EmpleadoId)
        {
            return Datos.ObtenerArchivosPorPresupuestoPorUsuario(PresupuestoId, EmpleadoId);
        }

        internal Proveedores BuscarProveedoresPorCuit(string cuit)
        {
            return Datos.BuscarProveedoresPorCuit( cuit);
        }



        internal List<Proveedores> BuscarProveedores(ProveedoresSearcher searcher)
        {
           return Datos.BuscarProveedores( searcher);
        }

        internal List<ProveedoresExternos> ListarProveedoresExternos(ProveedoresExternosSearcher searcher)
        {
            return Datos.BuscarProveedoresExternos(searcher);
        }
    }
}
