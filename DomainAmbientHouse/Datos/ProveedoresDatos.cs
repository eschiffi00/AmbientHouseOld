using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Globalization;

namespace DomainAmbientHouse.Datos
{
    public class ProveedoresDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ProveedoresDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Proveedores> ObtenerProveedores()
        {

            var query = from u in SqlContext.Proveedores
                        //join UnP in SqlContext.UnidadesNegocios_Proveedores on u.Id equals UnP.UnidadNegocioId into UnPs
                        //from UnP in UnPs.DefaultIfEmpty()
                        //join p in SqlContext.UnidadesNegocios on UnP.UnidadNegocioId equals p.Id into Ps
                        //from p in Ps.DefaultIfEmpty()
                        //join RP in SqlContext.Rubros_Proveedores on u.Id equals RP.ProveedorId into RPs
                        //from RP in RPs.DefaultIfEmpty()
                        //join r in SqlContext.Rubros on RP.RubroId equals r.RubroId into Rs
                        //from r in Rs.DefaultIfEmpty()
                        select new
                        {
                            Id = u.Id,
                            RazonSocial = u.RazonSocial,
                            NombreFantasia = u.NombreFantasia,
                            Cuit = u.Cuit,
                            CBU = u.CBU,
                            NroCliente = u.NroCliente,
                            Propio = u.Propio,
                            //RubroId = (r.RubroId == null ? 0 : r.RubroId),
                            //RubroDescripcion = r.Descripcion,
                            //UnidadNegocioId = (p.Id == null ? 0 : p.Id),
                            //UnidadNegocioDescripcion = p.Descripcion,
                            Telefono = u.Telefono,
                            CondicionIvaId = u.CondicionIvaId

                        };

            List<Proveedores> Salida = new List<Proveedores>();
            foreach (var item in query)
            {

                Proveedores cat = new Proveedores();

                cat.Id = item.Id;
                cat.RazonSocial = item.RazonSocial;
                cat.NombreFantasia = item.NombreFantasia;
                cat.Cuit = item.Cuit;
                cat.CBU = item.CBU;
                cat.NroCliente = item.NroCliente;
                cat.Propio = item.Propio;
                //cat.RubroId = item.RubroId;
                //cat.RubroDescripcion = item.RubroDescripcion;
                //cat.UnidadNegocioId = item.UnidadNegocioId;
                //cat.UnidadNegocioDescripcion = item.UnidadNegocioDescripcion;
                cat.Telefono = item.Telefono;
                cat.CondicionIvaId = item.CondicionIvaId;

                Salida.Add(cat);
            }

            return Salida.Distinct().OrderBy(o => o.RazonSocial).ToList();

        }

        public virtual List<Proveedores> ListarProveedores()
        {

            return SqlContext.Proveedores.Distinct().OrderBy(o => o.RazonSocial).ToList();
        }

        public virtual List<Proveedores> BuscarProveedoresporUnidadesNegocios(int UnidadNegociosId)
        {
            var query = from P in SqlContext.Proveedores
                        join UnP in SqlContext.UnidadesNegocios_Proveedores on P.Id equals UnP.ProveedorId
                        where UnP.UnidadNegocioId == UnidadNegociosId
                        select P;

            return query.OrderBy(o => o.RazonSocial).ToList();

        }

        public virtual Proveedores GetProveedor(int proveedorId)
        {
            return SqlContext.Proveedores.Where(o => o.Id == proveedorId).FirstOrDefault();

        }

        public Proveedores BuscarProveedor(int id)
        {
            return SqlContext.Proveedores.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Proveedores> BuscarProveedorLista(int id)
        {
            return SqlContext.Proveedores.Where(o => o.Id == id).ToList();
        }

        public void NuevoProveedor(Proveedores proveedor)
        {
            if (proveedor.Id > 0)
            {

                Proveedores proveedorEdit = SqlContext.Proveedores.Where(o => o.Id == proveedor.Id).First();

                proveedorEdit.NroCliente = proveedor.NroCliente;
                proveedorEdit.RazonSocial = proveedor.RazonSocial;
                proveedorEdit.Telefono = proveedor.Telefono;
                proveedorEdit.CBU = proveedor.CBU;
                proveedorEdit.Cuit = proveedor.Cuit;
                proveedorEdit.CondicionIvaId = proveedor.CondicionIvaId;
                //proveedorEdit.RubroId = proveedor.RubroId;
                //proveedorEdit.UnidadNegociosId = proveedor.UnidadNegociosId;
                proveedorEdit.Propio = proveedor.Propio;

                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Proveedores.Add(proveedor);
                SqlContext.SaveChanges();
            }
        }

        public List<Proveedores> ObtenerProveedoresCotizador()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());


            List<int> lista = new List<int>() { RubroCatering, RubroTecnica, RubroAmbientacion, RubroBarra, RubroSalon };

            var query = from p in SqlContext.Proveedores
                        join UnP in SqlContext.UnidadesNegocios_Proveedores on p.Id equals UnP.ProveedorId
                        join un in SqlContext.UnidadesNegocios on UnP.UnidadNegocioId equals un.Id
                        where lista.Contains(un.Id)
                        select p;

            return query.OrderBy(o => o.RazonSocial).ToList();

        }

        public List<Proveedores> TraerProveedores(List<int> list)
        {



            var query = from p in SqlContext.Proveedores
                        join PUn in SqlContext.UnidadesNegocios_Proveedores on p.Id equals PUn.ProveedorId
                        where list.Contains(PUn.UnidadNegocioId)
                        select p;

            return query.OrderBy(o => o.RazonSocial).ToList();


        }

        public List<Proveedores> ObtenerProveedoresPorProveedores(List<int?> listProveedorId)
        {
            var query = from p in SqlContext.Proveedores
                        where listProveedorId.Contains(p.Id)
                        select p;

            return query.OrderBy(o => o.RazonSocial).ToList();
        }

        public void NuevaUnidadNegocioProveedor(UnidadesNegocios_Proveedores UNProveedores)
        {
            SqlContext.UnidadesNegocios_Proveedores.Add(UNProveedores);
            SqlContext.SaveChanges();
        }

        public void NuevoRubroProveedor(Rubros_Proveedores RubroProveedores)
        {
            SqlContext.Rubros_Proveedores.Add(RubroProveedores);
            SqlContext.SaveChanges();
        }

        public void EliminarUnidadNegocioProveedor(int proveedorId)
        {
            List<UnidadesNegocios_Proveedores> detalle = SqlContext.UnidadesNegocios_Proveedores.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in detalle)
            {
                SqlContext.UnidadesNegocios_Proveedores.Remove(item);
                SqlContext.SaveChanges();
            }

        }

        public void EliminarRubroProveedor(int proveedorId)
        {
            List<Rubros_Proveedores> detalle = SqlContext.Rubros_Proveedores.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in detalle)
            {
                SqlContext.Rubros_Proveedores.Remove(item);
                SqlContext.SaveChanges();
            }

        }

        public List<AmbientacionSalon> ObtenerProveedorAmbientacionPorLocacionSector(int LocacionId, int sectorId)
        {
            var query = from ts in SqlContext.AmbientacionSalon
                        join p in SqlContext.Proveedores on ts.ProveedorId equals p.Id
                        join lo in SqlContext.Locaciones on ts.LocacionId equals lo.Id
                        join s in SqlContext.Sectores on ts.SectorId equals s.Id
                        where ts.LocacionId == LocacionId && ts.SectorId == sectorId
                        select new
                        {
                            Id = ts.Id,
                            ProveedorId = ts.ProveedorId,
                            RazonSocial = p.RazonSocial,
                            LocacionId = ts.LocacionId,
                            LocacionDescripcion = lo.Descripcion,
                            SectorId = ts.SectorId,
                            SectorDescripcion = s.Descripcion


                        };

            List<AmbientacionSalon> Salida = new List<AmbientacionSalon>();
            foreach (var item in query)
            {

                AmbientacionSalon cat = new AmbientacionSalon();

                cat.Id = item.Id;
                cat.ProveedorId = item.ProveedorId;
                cat.RazonSocial = item.RazonSocial;
                cat.LocacionId = item.LocacionId;
                cat.LocacionDescripcion = item.LocacionDescripcion;
                cat.SectorId = item.SectorId;
                cat.SectorDescripcion = item.SectorDescripcion;


                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.RazonSocial).Distinct().ToList();
        }

        internal void EliminarProveedorAmbientacionLocacionSector(int sectorId)
        {
            List<AmbientacionSalon> detalle = SqlContext.AmbientacionSalon.Where(o => o.SectorId == sectorId).ToList();

            foreach (var item in detalle)
            {
                SqlContext.AmbientacionSalon.Remove(item);
                SqlContext.SaveChanges();
            }

        }

        public void NuevaAmbientacionSalonProveedor(AmbientacionSalon ambSalon)
        {
            SqlContext.AmbientacionSalon.Add(ambSalon);
            SqlContext.SaveChanges();
        }

        internal List<TecnicaSalon> ObtenerProveedorTecnicaPorLocacionSector(int LocacionId, int sectorId)
        {
            var query = from ts in SqlContext.TecnicaSalon
                        join p in SqlContext.Proveedores on ts.ProveedorId equals p.Id
                        join lo in SqlContext.Locaciones on ts.LocacionId equals lo.Id
                        join s in SqlContext.Sectores on ts.SectorId equals s.Id
                        where ts.LocacionId == LocacionId && ts.SectorId == sectorId
                        select new
                        {
                            Id = ts.Id,
                            ProveedorId = ts.ProveedorId,
                            RazonSocial = p.RazonSocial,
                            LocacionId = ts.LocacionId,
                            LocacionDescripcion = lo.Descripcion,
                            SectorId = ts.SectorId,
                            SectorDescripcion = s.Descripcion


                        };

            List<TecnicaSalon> Salida = new List<TecnicaSalon>();
            foreach (var item in query)
            {

                TecnicaSalon cat = new TecnicaSalon();

                cat.Id = item.Id;
                cat.ProveedorId = item.ProveedorId;
                cat.RazonSocial = item.RazonSocial;
                cat.LocacionId = item.LocacionId;
                cat.LocacionDescripcion = item.LocacionDescripcion;
                cat.SectorId = item.SectorId;
                cat.SectorDescripcion = item.SectorDescripcion;


                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.RazonSocial).Distinct().ToList();

        }


        #region Organizacion Proveedores Externos

        internal void GrabarProveedoresExternos(OrganizacionPresupuestoProveedoresExternos proveedor)
        {
            if (proveedor.Id > 0)
            {
                OrganizacionPresupuestoProveedoresExternos edit = SqlContext.OrganizacionPresupuestoProveedoresExternos.Where(o => o.Id == proveedor.Id).SingleOrDefault();

                edit.ProveedorExterno = proveedor.ProveedorExterno;
                edit.Contacto = proveedor.Contacto;
                edit.Correo = proveedor.Correo;
                edit.Observaciones = proveedor.Observaciones;
                edit.PresupuestoId = proveedor.PresupuestoId;
                edit.Rubro = proveedor.Rubro;
                edit.Telefono = proveedor.Telefono;
                edit.SegurosOk = proveedor.SegurosOk;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.OrganizacionPresupuestoProveedoresExternos.Add(proveedor);
                SqlContext.SaveChanges();
            }
        }

        public List<OrganizacionPresupuestoProveedoresExternos> ObtenerProveedoresExternosPorPresupuesto(int presupuestoId)
        {
            return SqlContext.OrganizacionPresupuestoProveedoresExternos.Where(o => o.PresupuestoId == presupuestoId).ToList();
        }

        internal OrganizacionPresupuestoProveedoresExternos BuscarOrganizacionPresupuestoProveedoresExternos(int Id)
        {
            return SqlContext.OrganizacionPresupuestoProveedoresExternos.Where(o => o.Id == Id).SingleOrDefault();
        }

        internal void EliminarProveedoresExternos(OrganizacionPresupuestoProveedoresExternos proveedor)
        {
            OrganizacionPresupuestoProveedoresExternos detalle = SqlContext.OrganizacionPresupuestoProveedoresExternos.Where(o => o.Id == proveedor.Id).SingleOrDefault();

            if (detalle != null)
            {
                SqlContext.OrganizacionPresupuestoProveedoresExternos.Remove(detalle);
                SqlContext.SaveChanges();

            }
        }

        #endregion

        #region Organizacion Timming

        internal List<OrganizacionPresupuestoTimming> ObtenerTimmingPorPresupuesto(int PresupuestoId)
        {
            return SqlContext.OrganizacionPresupuestoTimming.Where(o => o.PresupuestoId == PresupuestoId).ToList();
        }

        internal OrganizacionPresupuestoTimming BuscarOrganizacionTimming(int Id)
        {
            return SqlContext.OrganizacionPresupuestoTimming.Where(o => o.Id == Id).SingleOrDefault();
        }

        internal void GrabarTimming(OrganizacionPresupuestoTimming timming)
        {
            if (timming.Id > 0)
            {
                OrganizacionPresupuestoTimming edit = SqlContext.OrganizacionPresupuestoTimming.Where(o => o.Id == timming.Id).SingleOrDefault();

                edit.Descripcion = timming.Descripcion;
                edit.Duracion = timming.Duracion;
                edit.HoraInicio = timming.HoraInicio;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.OrganizacionPresupuestoTimming.Add(timming);
                SqlContext.SaveChanges();
            }
        }

        internal void EliminarTimming(OrganizacionPresupuestoTimming timming)
        {
            OrganizacionPresupuestoTimming detalle = SqlContext.OrganizacionPresupuestoTimming.Where(o => o.Id == timming.Id).SingleOrDefault();

            if (detalle != null)
            {
                SqlContext.OrganizacionPresupuestoTimming.Remove(detalle);
                SqlContext.SaveChanges();

            }
        }

        #endregion

        #region Organizacion Archivos

        internal List<OrganizacionPresupuestosArchivos> ObtenerArchivosPorPresupuesto(int PresupuestoId)
        {
            return SqlContext.OrganizacionPresupuestosArchivos.Where(o => o.PresupuestoId == PresupuestoId).ToList();
        }

        internal OrganizacionPresupuestosArchivos BuscarOrganizacionArchivo(int Id)
        {
            return SqlContext.OrganizacionPresupuestosArchivos.Where(o => o.Id == Id).SingleOrDefault();
        }

        internal void GrabarArchivo(OrganizacionPresupuestosArchivos archivo)
        {
            if (archivo.Id > 0)
            {
                OrganizacionPresupuestosArchivos edit = SqlContext.OrganizacionPresupuestosArchivos.Where(o => o.Id == archivo.Id).SingleOrDefault();

                if (archivo.Extension != "")
                {
                    edit.Desripcion = archivo.Desripcion;
                    edit.Extension = archivo.Extension;
                    edit.NombreArchivo = archivo.NombreArchivo;
                    edit.Archivo = archivo.Archivo;
                    edit.EmpleadoId = archivo.EmpleadoId;
                    edit.CreateFecha = System.DateTime.Now;

                    SqlContext.SaveChanges();
                }
            }
            else
            {
                SqlContext.OrganizacionPresupuestosArchivos.Add(archivo);
                SqlContext.SaveChanges();
            }
        }

        internal void EliminarArchivo(OrganizacionPresupuestosArchivos archivo)
        {
            OrganizacionPresupuestosArchivos detalle = SqlContext.OrganizacionPresupuestosArchivos.Where(o => o.Id == archivo.Id).SingleOrDefault();

            if (detalle != null)
            {
                SqlContext.OrganizacionPresupuestosArchivos.Remove(detalle);
                SqlContext.SaveChanges();

            }
        }

        internal List<OrganizacionPresupuestosArchivos> ObtenerArchivosPorPresupuestoPorUsuario(int PresupuestoId, int EmpleadoId)
        {
            return SqlContext.OrganizacionPresupuestosArchivos.Where(o => o.PresupuestoId == PresupuestoId && o.EmpleadoId == EmpleadoId).ToList();
        }

        #endregion

        public Proveedores BuscarProveedoresPorCuit(string cuit)
        {
            return SqlContext.Proveedores.Where(o => o.Cuit.Equals(cuit)).SingleOrDefault();
        }

        internal void NuevaFormadePagoProveedores(ProveedoresFormasdePago proveedoresFormasdePago)
        {
            SqlContext.ProveedoresFormasdePago.Add(proveedoresFormasdePago);
            SqlContext.SaveChanges();
        }

        internal void EliminarFormasdePagoProveedor(int proveedorId)
        {
            List<ProveedoresFormasdePago> detalle = SqlContext.ProveedoresFormasdePago.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in detalle)
            {
                SqlContext.ProveedoresFormasdePago.Remove(item);
                SqlContext.SaveChanges();

            }
        }

        public string ValidarProveedores(int? proveedorId)
        {

            if (proveedorId != null)
            {
                Proveedores proveedor = SqlContext.Proveedores.Where(o => o.Id == proveedorId).SingleOrDefault();

                if (proveedor.RazonSocial != "")
                {
                    return proveedor.RazonSocial.ToUpper();
                }
                else
                    return "";
            }

            return "";

        }

        internal List<Proveedores> BuscarProveedores(ProveedoresSearcher searcher) 

        {
            var query = from P in SqlContext.Proveedores
                        select P;


            if (!string.IsNullOrEmpty(searcher.RazonSocial))
            {
                query = query.Where(o => o.RazonSocial.Contains(searcher.RazonSocial));
            }

            if (!string.IsNullOrEmpty(searcher.Cuit))
            {
                query = query.Where(o => o.Cuit.Contains(searcher.Cuit));
            }

            return query.ToList();


        }

        public List<ProveedoresExternos> BuscarProveedoresExternos(ProveedoresExternosSearcher searcher)
        {
            var query = from p in SqlContext.ProveedoresExternos
                        select p;

            if (!string.IsNullOrWhiteSpace(searcher.NroPresupuesto))
            {
                int presupuestoId = Int32.Parse(searcher.NroPresupuesto);
                query = query.Where(o => o.Id == presupuestoId);

            }

            if (!string.IsNullOrWhiteSpace(searcher.FechaEventoDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaEventoDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEvento >= fecha);

            }

            if (!string.IsNullOrWhiteSpace(searcher.FechaEventoHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaEventoHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEvento <= fecha);

            }

            if (!string.IsNullOrWhiteSpace(searcher.RazonSocial))
            {
                query = query.Where(o => o.Proveedor.Contains(searcher.RazonSocial));

            }



            return query.OrderBy(o => o.FechaEvento).ToList();
        }

    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class ProveedoresSearcher
    {

        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
    }


     public partial class ProveedoresExternosSearcher
    {

        public string RazonSocial { get; set; }
        public string FechaEventoDesde { get; set; }
        public string FechaEventoHasta { get; set; }
         public string NroPresupuesto { get; set; }
    }
}