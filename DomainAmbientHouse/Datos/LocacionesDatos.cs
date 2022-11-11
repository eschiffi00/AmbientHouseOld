using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class LocacionesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public LocacionesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Locaciones> ObtenerLocacionesParaCotizar()
        {
            int UnidadNegocio = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());

            List<int?> locaciones = (from Pro in SqlContext.Productos
                                     where Pro.UnidadNegocioId == UnidadNegocio
                                     select Pro).Select(o => o.LocacionId).Distinct().ToList();



            var query = from L in SqlContext.Locaciones
                            //join Se in SqlContext.Sectores on L.Id equals Se.LocacionId
                            //join p in SqlContext.TecnicaSalon on Se.Id equals p.SectorId into ps
                            //from p in ps.DefaultIfEmpty()
                            //join Pt in SqlContext.Proveedores on p.ProveedorId equals Pt.Id into pl
                            //from Pt in pl.DefaultIfEmpty()
                        where locaciones.Contains(L.Id)
                        select new
                        {
                            Id = L.Id,
                            Descripcion = L.Descripcion,
                            TipoLocacion = L.TipoLocacion,
                            //TecnicaDescripcion = (Pt.RazonSocial == null ? String.Empty : Pt.RazonSocial),
                            TieneLogistica = L.TieneLogistica,
                            Comisiona = L.Comisiona,
                            UsoCocina = L.UsoCocina,
                            CapacidadInformal = L.CapacidadInformal,
                            CapacidadFormal = L.CapacidadFormal,
                            CapacidadAuditorio = L.CapacidadAuditorio,
                            TipoCannonCatering = L.TipoCannonCatering,
                            TipoCannonBarra = L.TipoCannonBarra,
                            TipoCannonAmbientacion = L.TipoCannonAmbientacion,
                            ValorCannon = L.Cannon,
                            ValorCannonBarra = L.CannonBarra,
                            ValorCannonAmbientacion = L.CannonAmbientacion,
                            Verde = L.Verde,
                            Estacionamiento = L.Estacionamiento,
                            Airelibre = L.AireLibre,
                            LocalidadId = L.LocalidadId,
                            Direccion = L.Direccion,
                            Telefono = L.Telefono,
                            web = L.web,
                            Comentario = L.Comentarios,
                            Mail = L.Mail
                        };

            List<Locaciones> Salida = new List<Locaciones>();
            foreach (var item in query)
            {

                Locaciones cat = new Locaciones();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.TipoLocacion = item.TipoLocacion;
                //cat.TecnicaDescripcion = item.TecnicaDescripcion;
                cat.TieneLogistica = item.TieneLogistica;
                cat.Comisiona = item.Comisiona;
                cat.UsoCocina = item.UsoCocina;
                cat.CapacidadInformal = item.CapacidadInformal;
                cat.CapacidadFormal = item.CapacidadFormal;
                cat.CapacidadAuditorio = item.CapacidadAuditorio;
                cat.TipoCannonCatering = item.TipoCannonCatering;
                cat.TipoCannonBarra = item.TipoCannonBarra;
                cat.TipoCannonAmbientacion = item.TipoCannonAmbientacion;
                cat.Cannon = item.ValorCannon;
                cat.CannonBarra = item.ValorCannonBarra;
                cat.CannonAmbientacion = item.ValorCannonAmbientacion;
                cat.Verde = item.Verde;
                cat.Estacionamiento = item.Estacionamiento;
                cat.AireLibre = item.Airelibre;
                cat.LocalidadId = item.LocalidadId;
                cat.Direccion = item.Direccion;
                cat.Telefono = item.Telefono;
                cat.web = item.web;
                cat.Comentarios = item.Comentario;
                cat.Mail = item.Mail;


                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();

        }

        public virtual List<Locaciones> ObtenerLocaciones(int usuario)
        {

            var query = from L in SqlContext.Locaciones
                        join p in SqlContext.UsuariosLocaciones on L.Id equals p.LocacionId into ps
                        from p in ps.DefaultIfEmpty()
                        where p.EmpleadoId == usuario
                        select new
                        {
                            Id = L.Id,
                            Descripcion = L.Descripcion,
                            TipoLocacion = L.TipoLocacion,
                            //TecnicaDescripcion = (Pt.RazonSocial == null ? String.Empty : Pt.RazonSocial),
                            TieneLogistica = L.TieneLogistica,
                            Comisiona = L.Comisiona,
                            UsoCocina = L.UsoCocina,
                            CapacidadInformal = L.CapacidadInformal,
                            CapacidadFormal = L.CapacidadFormal,
                            CapacidadAuditorio = L.CapacidadAuditorio,
                            TipoCannonCatering = L.TipoCannonCatering,
                            TipoCannonBarra = L.TipoCannonBarra,
                            TipoCannonAmbientacion = L.TipoCannonAmbientacion,
                            ValorCannon = L.Cannon,
                            ValorCannonBarra = L.CannonBarra,
                            ValorCannonAmbientacion = L.CannonAmbientacion,
                            Verde = L.Verde,
                            Estacionamiento = L.Estacionamiento,
                            Airelibre = L.AireLibre,
                            LocalidadId = L.LocalidadId,
                            Direccion = L.Direccion,
                            Telefono = L.Telefono,
                            web = L.web,
                            Comentario = L.Comentarios,
                            Mail = L.Mail

                        };

            List<Locaciones> Salida = new List<Locaciones>();
            foreach (var item in query)
            {

                Locaciones cat = new Locaciones();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.TipoLocacion = item.TipoLocacion;
                //cat.TecnicaDescripcion = item.TecnicaDescripcion;
                cat.TieneLogistica = item.TieneLogistica;
                cat.Comisiona = item.Comisiona;
                cat.UsoCocina = item.UsoCocina;
                cat.CapacidadInformal = item.CapacidadInformal;
                cat.CapacidadFormal = item.CapacidadFormal;
                cat.CapacidadAuditorio = item.CapacidadAuditorio;
                cat.TipoCannonCatering = item.TipoCannonCatering;
                cat.TipoCannonBarra = item.TipoCannonBarra;
                cat.TipoCannonAmbientacion = item.TipoCannonAmbientacion;
                cat.Cannon = item.ValorCannon;
                cat.CannonBarra = item.ValorCannonBarra;
                cat.CannonAmbientacion = item.ValorCannonAmbientacion;
                cat.Verde = item.Verde;
                cat.Estacionamiento = item.Estacionamiento;
                cat.AireLibre = item.Airelibre;
                cat.LocalidadId = item.LocalidadId;
                cat.Direccion = item.Direccion;
                cat.Telefono = item.Telefono;
                cat.web = item.web;
                cat.Comentarios = item.Comentario;
                cat.Mail = item.Mail;
                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();

        }

        public virtual List<Locaciones> ObtenerLocaciones()
        {

            var query = from L in SqlContext.Locaciones
                        join p in SqlContext.Localidades on L.LocalidadId equals p.Id
                        //from p in ps.DefaultIfEmpty()
                        //join Pt in SqlContext.Proveedores on p.ProveedorId equals Pt.Id into pl
                        //from Pt in pl.DefaultIfEmpty()
                        select new
                        {
                            Id = L.Id,
                            Descripcion = L.Descripcion,
                            TipoLocacion = L.TipoLocacion,
                            //TecnicaDescripcion = (Pt.RazonSocial == null ? String.Empty : Pt.RazonSocial),
                            TieneLogistica = L.TieneLogistica,
                            Comisiona = L.Comisiona,
                            UsoCocina = L.UsoCocina,
                            CapacidadInformal = L.CapacidadInformal,
                            CapacidadFormal = L.CapacidadFormal,
                            CapacidadAuditorio = L.CapacidadAuditorio,
                            TipoCannonCatering = L.TipoCannonCatering,
                            TipoCannonBarra = L.TipoCannonBarra,
                            TipoCannonAmbientacion = L.TipoCannonAmbientacion,
                            ValorCannon = L.Cannon,
                            ValorCannonBarra = L.CannonBarra,
                            ValorCannonAmbientacion = L.CannonAmbientacion,
                            Verde = L.Verde,
                            Estacionamiento = L.Estacionamiento,
                            Airelibre = L.AireLibre,
                            LocalidadId = L.LocalidadId,
                            LocalidadDescripcion = p.Descripcion,
                            Direccion = L.Direccion,
                            Telefono = L.Telefono,
                            web = L.web,
                            Comentario = L.Comentarios,
                            Mail = L.Mail
                        };

            List<Locaciones> Salida = new List<Locaciones>();
            foreach (var item in query)
            {

                Locaciones cat = new Locaciones();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.TipoLocacion = item.TipoLocacion;
                //cat.TecnicaDescripcion = item.TecnicaDescripcion;
                cat.TieneLogistica = item.TieneLogistica;
                cat.Comisiona = item.Comisiona;
                cat.UsoCocina = item.UsoCocina;
                cat.CapacidadInformal = item.CapacidadInformal;
                cat.CapacidadFormal = item.CapacidadFormal;
                cat.CapacidadAuditorio = item.CapacidadAuditorio;
                cat.TipoCannonCatering = item.TipoCannonCatering;
                cat.TipoCannonBarra = item.TipoCannonBarra;
                cat.TipoCannonAmbientacion = item.TipoCannonAmbientacion;
                cat.Cannon = item.ValorCannon;
                cat.CannonBarra = item.ValorCannonBarra;
                cat.CannonAmbientacion = item.ValorCannonAmbientacion;
                cat.Verde = item.Verde;
                cat.Estacionamiento = item.Estacionamiento;
                cat.AireLibre = item.Airelibre;
                cat.LocalidadId = item.LocalidadId;
                cat.LocalidadDescripcion = item.LocalidadDescripcion;
                cat.Direccion = item.Direccion;
                cat.Telefono = item.Telefono;
                cat.web = item.web;
                cat.Comentarios = item.Comentario;
                cat.Mail = item.Mail;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();

        }

        public virtual List<Locaciones> ObtenerLocacionesSinPrecios()
        {
            return SqlContext.Locaciones.OrderBy(o => o.Descripcion).ToList();
        }

        public virtual Locaciones BuscarLocaciones(int locacionId)
        {

            return SqlContext.Locaciones.Where(o => o.Id == locacionId).FirstOrDefault();

        }

        public void NuevaLocacion(Locaciones Locacion)
        {
            if (Locacion.Id > 0)
            {
                Locaciones locacionEdit = SqlContext.Locaciones.Where(o => o.Id == Locacion.Id).First();


                locacionEdit.TipoLocacion = Locacion.TipoLocacion;
                locacionEdit.Descripcion = Locacion.Descripcion;
                locacionEdit.UsoCocina = Locacion.UsoCocina;
                locacionEdit.Cannon = Locacion.Cannon;
                locacionEdit.CapacidadInformal = Locacion.CapacidadInformal;
                locacionEdit.CapacidadFormal = Locacion.CapacidadFormal;
                locacionEdit.CapacidadAuditorio = Locacion.CapacidadAuditorio;
                locacionEdit.TieneLogistica = Locacion.TieneLogistica;
                locacionEdit.Comisiona = Locacion.Comisiona;
                locacionEdit.TipoCannonCatering = Locacion.TipoCannonCatering;
                locacionEdit.Cannon = Locacion.Cannon;
                locacionEdit.TipoCannonBarra = Locacion.TipoCannonBarra;
                locacionEdit.CannonBarra = Locacion.CannonBarra;
                locacionEdit.TipoCannonAmbientacion = Locacion.TipoCannonAmbientacion;
                locacionEdit.CannonAmbientacion = Locacion.CannonAmbientacion;
                locacionEdit.LocalidadId = Locacion.LocalidadId;
                locacionEdit.Verde = Locacion.Verde;
                locacionEdit.Estacionamiento = Locacion.Estacionamiento;
                locacionEdit.AireLibre = Locacion.AireLibre;
                locacionEdit.Comentarios = Locacion.Comentarios;
                locacionEdit.Direccion = Locacion.Direccion;
                locacionEdit.Mail = Locacion.Mail;
                locacionEdit.Telefono = Locacion.Telefono;
                locacionEdit.web = Locacion.web;
                locacionEdit.RequiereMesasSillas = Locacion.RequiereMesasSillas;
                locacionEdit.CostoMesas = Locacion.CostoMesas;
                locacionEdit.CostoSillas = Locacion.CostoSillas;
                locacionEdit.PrecioMesas = Locacion.PrecioMesas;
                locacionEdit.PrecioSillas = Locacion.PrecioSillas;


                SqlContext.SaveChanges();
            }
            else
            {

                Locacion.Id = SqlContext.Locaciones.Max(o => o.Id + 1);
                SqlContext.Locaciones.Add(Locacion);
                SqlContext.SaveChanges();
            }
        }

        public List<LocacionesValorAnio> ObtenerCostosSalonesPorAnios()
        {
            var query = from L in SqlContext.Locaciones
                        join Vl in SqlContext.LocacionesValorAnio on L.Id equals Vl.LocacionId
                        select new
                        {
                            Anio = Vl.Anio,
                            Precio = Vl.Costo,
                            LocacionId = L.Id,
                            LocacionDescripcion = L.Descripcion,
                            Id = Vl.Id

                        };

            List<LocacionesValorAnio> salida = new List<LocacionesValorAnio>();
            foreach (var item in query)
            {

                LocacionesValorAnio locacion = new LocacionesValorAnio();

                locacion.Id = item.Id;
                locacion.LocacionId = item.LocacionId;
                locacion.LocacionDescripcion = item.LocacionDescripcion;
                locacion.Costo = item.Precio;
                locacion.Anio = item.Anio;

                salida.Add(locacion);


            }

            return salida.OrderBy(o => o.Anio).ToList();
        }

        public LocacionesValorAnio BuscarLocacionesValorAnio(int id)
        {
            return SqlContext.LocacionesValorAnio.Where(o => o.Id == id).FirstOrDefault();
        }

        public bool ObtenerLocacionesValorAnio(int anio, int locacionId)
        {
            return SqlContext.LocacionesValorAnio.Where(o => o.LocacionId == locacionId && o.Anio == anio).Count() > 0;
        }

        public void NuevoLocacionesValorAnio(LocacionesValorAnio locacionesValorAnio)
        {
            if (locacionesValorAnio.Id > 0)
            {

                LocacionesValorAnio catEdit = SqlContext.LocacionesValorAnio.Where(o => o.Id == locacionesValorAnio.Id).First();

                catEdit.Anio = locacionesValorAnio.Anio;
                catEdit.Costo = locacionesValorAnio.Costo;
                catEdit.LocacionId = locacionesValorAnio.LocacionId;


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.LocacionesValorAnio.Add(locacionesValorAnio);
                SqlContext.SaveChanges();
            }
        }

        public void GrabarTecnicaSalon(TecnicaSalon tecnicaSalon)
        {
            if (tecnicaSalon.Id > 0)
            {
                TecnicaSalon editTecSalon = SqlContext.TecnicaSalon.Where(o => o.Id == tecnicaSalon.Id).FirstOrDefault();

                editTecSalon.LocacionId = tecnicaSalon.LocacionId;
                editTecSalon.ProveedorId = tecnicaSalon.ProveedorId;
                editTecSalon.SectorId = tecnicaSalon.SectorId;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.TecnicaSalon.Add(tecnicaSalon);
                SqlContext.SaveChanges();

            }
        }

        public void GrabarAmbientacionSalon(AmbientacionSalon ambientacionSalon)
        {
            if (ambientacionSalon.Id > 0)
            {
                AmbientacionSalon editAmbSalon = SqlContext.AmbientacionSalon.Where(o => o.Id == ambientacionSalon.Id).FirstOrDefault();

                editAmbSalon.LocacionId = ambientacionSalon.LocacionId;
                editAmbSalon.ProveedorId = ambientacionSalon.ProveedorId;
                editAmbSalon.SectorId = ambientacionSalon.SectorId;

                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.AmbientacionSalon.Add(ambientacionSalon);
                SqlContext.SaveChanges();
            }
        }

        public List<Locaciones> ObtenerLocacionesOUT()
        {
            var query = from L in SqlContext.Locaciones
                        select new
                        {
                            Id = L.Id,
                            Descripcion = L.Descripcion,
                            TipoLocacion = L.TipoLocacion,
                            TieneLogistica = L.TieneLogistica,
                            Comisiona = L.Comisiona,
                            UsoCocina = L.UsoCocina,
                            CapacidadInformal = L.CapacidadInformal,
                            CapacidadFormal = L.CapacidadFormal,
                            CapacidadAuditorio = L.CapacidadAuditorio,
                            TipoCannonCatering = L.TipoCannonCatering,
                            TipoCannonBarra = L.TipoCannonBarra,
                            TipoCannonAmbientacion = L.TipoCannonAmbientacion,
                            ValorCannon = L.Cannon,
                            ValorCannonBarra = L.CannonBarra,
                            ValorCannonAmbientacion = L.CannonAmbientacion,
                            Verde = L.Verde,
                            Estacionamiento = L.Estacionamiento,
                            Airelibre = L.AireLibre,
                            LocalidadId = L.LocalidadId,
                            Direccion = L.Direccion,
                            Telefono = L.Telefono,
                            web = L.web,
                            Comentario = L.Comentarios,
                            Mail = L.Mail,
                            RequiereMesasSillas = L.RequiereMesasSillas,
                            CostoSillas = L.CostoSillas,
                            CostoMesas = L.CostoMesas,
                            PrecioMesas = L.PrecioMesas,
                            PrecioSillas = L.PrecioSillas
                        };

            List<Locaciones> Salida = new List<Locaciones>();
            foreach (var item in query)
            {

                Locaciones cat = new Locaciones();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.TipoLocacion = item.TipoLocacion;
                cat.TieneLogistica = item.TieneLogistica;
                cat.Comisiona = item.Comisiona;
                cat.UsoCocina = item.UsoCocina;
                cat.CapacidadInformal = item.CapacidadInformal;
                cat.CapacidadFormal = item.CapacidadFormal;
                cat.CapacidadAuditorio = item.CapacidadAuditorio;
                cat.TipoCannonCatering = item.TipoCannonCatering;
                cat.TipoCannonBarra = item.TipoCannonBarra;
                cat.TipoCannonAmbientacion = item.TipoCannonAmbientacion;
                cat.Cannon = item.ValorCannon;
                cat.CannonBarra = item.ValorCannonBarra;
                cat.CannonAmbientacion = item.ValorCannonAmbientacion;
                cat.Verde = item.Verde;
                cat.Estacionamiento = item.Estacionamiento;
                cat.AireLibre = item.Airelibre;
                cat.LocalidadId = item.LocalidadId;
                cat.Direccion = item.Direccion;
                cat.Telefono = item.Telefono;
                cat.web = item.web;
                cat.Comentarios = item.Comentario;
                cat.Mail = item.Mail;
                cat.RequiereMesasSillas = item.RequiereMesasSillas;
                cat.CostoSillas = item.CostoSillas;
                cat.CostoMesas = item.CostoMesas;
                cat.PrecioMesas = item.PrecioMesas;
                cat.PrecioSillas = item.PrecioSillas;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Descripcion).ToList();

        }

        internal void EliminarProveedorTecnicaLocacionSector(int sectorId)
        {
            List<TecnicaSalon> detalle = SqlContext.TecnicaSalon.Where(o => o.SectorId == sectorId).ToList();

            foreach (var item in detalle)
            {

                SqlContext.TecnicaSalon.Remove(item);
                SqlContext.SaveChanges();

            }
        }

        internal void NuevaTecnicaSalonProveedor(TecnicaSalon tecSalon)
        {
            if (tecSalon.Id > 0)
            {
                TecnicaSalon editTecSalon = SqlContext.TecnicaSalon.Where(o => o.Id == tecSalon.Id).FirstOrDefault();

                editTecSalon.LocacionId = tecSalon.LocacionId;
                editTecSalon.ProveedorId = tecSalon.ProveedorId;
                editTecSalon.SectorId = tecSalon.SectorId;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.TecnicaSalon.Add(tecSalon);
                SqlContext.SaveChanges();

            }
        }

        internal List<Locaciones> ObtenerLocacionesParaCotizarPorLocacion(int localidadId, string tieneVerde, string estacionamiento, string aireLibre)
        {
            return SqlContext.Locaciones.Where(o => o.LocalidadId == localidadId &&
                                                    o.Verde.Equals(tieneVerde) &&
                                                    o.Estacionamiento.Equals(estacionamiento) &&
                                                    o.AireLibre.Equals(aireLibre)).ToList();
        }


        internal List<CargarCostosSalones_Result> CargarPrecioCostosSalon(ParametrosCostoSalones param)
        {
            List<CargarCostosSalones_Result> query = new List<CargarCostosSalones_Result>();
            try
            {
                query = (from c in SqlContext.CargarCostosSalones(param.LocacionId, param.SectorId,
                                                                    param.Anio, param.Mes,
                                                                    param.JornadaId, param.Dia,
                                                                    param.Costo, param.Precio, param.Royalty)
                         select c).ToList();
                //select new ResultParametrosCostosSalones
                //{
                //   Id = c.Id,
                //   Codigo = c.Codigo,
                //   UN = c.Column1,
                //   Descripcion = c.Descripcion,
                //   Costo = c.Costo,
                //   Margen = c.Margen,
                //   Precio =c.Precio
                //}).ToList();


                return query;
            }
            catch (Exception)
            {
                return query;
            }


        }
    }
}


namespace DomainAmbientHouse.Entidades
{
    public partial class ParametrosCostoSalones
    {
        public int LocacionId { get; set; }
        public int SectorId { get; set; }
        public int JornadaId { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string Dia { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public double Royalty { get; set; }

    }

    public partial class ResultParametrosCostosSalones
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string UN { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double? Margen { get; set; }
        public double Precio { get; set; }

    }
}


