using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class TipoMovimientosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public TipoMovimientosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<TipoMovimientos> ObtenerTipoMovimientos()
        {

            var query = from Tm in SqlContext.TipoMovimientos
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            Tipo = Tm.Tipo,
                            Visible = Tm.Visible
                        };



            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Tipo = item.Tipo;
                //if (item.Tipo != null)
                //    cat.TipoMovimientoPadreDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMoviemientoPadreId).SingleOrDefault().Descripcion;
                //else
                //    cat.TipoMovimientoPadreDescripcion = "";
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            return Salida.Where(o => o.Visible == "S").OrderBy(o => o.Codigo).ToList();

        }

        public virtual List<TipoMovimientos> ObtenerTipoMovimientosTodos(DomainAmbientHouse.Entidades.TipoMovimientoSearcher searcher)
        {

            var query = from Tm in SqlContext.TipoMovimientos
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            TipoMoviemientoPadreId = Tm.Tipo,
                            Visible = Tm.Visible
                        };



            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Tipo = item.TipoMoviemientoPadreId;
                //if (item.TipoMoviemientoPadreId != null)
                //    cat.TipoMovimientoPadreDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMoviemientoPadreId).SingleOrDefault().Descripcion;
                //else
                //    cat.TipoMovimientoPadreDescripcion = "";
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            if (searcher.Codigo.Length > 1)
                Salida = Salida.Where(o => o.Codigo.Contains(searcher.Codigo)).ToList();

            if (searcher.Tipo != null)
            {
                if (searcher.Tipo.Length > 0)
                    Salida = Salida.Where(o => o.Tipo == searcher.Tipo).ToList();
            }
            return Salida.OrderBy(o => o.Codigo).ToList();

        }

        public TipoMovimientos BuscarTipoMovimiento(int id)
        {
            return SqlContext.TipoMovimientos.Where(o => o.Id == id).SingleOrDefault();

        }

        public virtual List<TipoMovimientos> ObtenerTipoMovimientosParaRecibosIngresos()
        {
            int ventaArtistica = Int32.Parse(ConfigurationManager.AppSettings["cuentaArtistica"].ToString());
            int ventaValetParking = Int32.Parse(ConfigurationManager.AppSettings["cuentaValetParking"].ToString());
            int ventaUsoCocina = Int32.Parse(ConfigurationManager.AppSettings["cuentaUsoCocina"].ToString());
            int ventaCannon = Int32.Parse(ConfigurationManager.AppSettings["cuentaCannon"].ToString());
            int ventaComisiones = Int32.Parse(ConfigurationManager.AppSettings["cuentaComisiones"].ToString());
            int ventaImpuestosMusicales = Int32.Parse(ConfigurationManager.AppSettings["cuentaImpuestosMusicales"].ToString());
            int ventaOtros = Int32.Parse(ConfigurationManager.AppSettings["cuentaOtros"].ToString());



            List<int> lista = new List<int>() { ventaArtistica, ventaValetParking, ventaUsoCocina, ventaCannon, ventaComisiones, ventaImpuestosMusicales, ventaOtros };

            var query = from Tm in SqlContext.TipoMovimientos
                        where lista.Contains(Tm.Id)
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            Visible = Tm.Visible
                        };



            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            return Salida.Where(o => o.Visible == "S").OrderBy(o => o.Codigo).ToList();

        }

        public List<TipoMovimientos> ObtenerTipoMovimientosPadres()
        {
            var query = from Tm in SqlContext.TipoMovimientos
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            Tipo = Tm.Tipo,
                            Visible = Tm.Visible
                        };



            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Tipo = item.Tipo;
                //if (item.TipoMoviemientoPadreId != null)
                //    cat.TipoMovimientoPadreDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMoviemientoPadreId).SingleOrDefault().Descripcion;
                //else
                //    cat.TipoMovimientoPadreDescripcion = "";
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            return Salida.Where(o => o.Visible == "N").OrderBy(o => o.Codigo).ToList();
        }

        public bool GrabarTipoMovimientos(TipoMovimientos tipoMovimiento)
        {
            try
            {


                if (tipoMovimiento.Id > 0)
                {
                    TipoMovimientos edit = SqlContext.TipoMovimientos.Where(o => o.Id == tipoMovimiento.Id).SingleOrDefault();


                    edit.Tipo = tipoMovimiento.Tipo;
                    edit.Codigo = tipoMovimiento.Codigo;
                    edit.Descripcion = tipoMovimiento.Descripcion;
                    edit.Visible = tipoMovimiento.Visible;

                    SqlContext.SaveChanges();

                }
                else
                {
                    SqlContext.TipoMovimientos.Add(tipoMovimiento);
                    SqlContext.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        internal List<TipoMovimientos> ObtenerTipoMovimientosPorPadre(string padreId)
        {
            var query = from Tm in SqlContext.TipoMovimientos
                        where Tm.Tipo.Equals(padreId)
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            Tipo = Tm.Tipo,
                            Visible = Tm.Visible
                        };



            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Tipo = item.Tipo;
                //if (item.TipoMoviemientoPadreId != null)
                //    cat.TipoMovimientoPadreDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMoviemientoPadreId).SingleOrDefault().Descripcion;
                //else
                //    cat.TipoMovimientoPadreDescripcion = "";
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.Codigo).ToList();
        }

        internal List<TipoMovimientos> ObtenerTipoMovimientosEgresos()
        {

            var query = from Tm in SqlContext.TipoMovimientos
                        where Tm.IsEgreso == true
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            Tipo = Tm.Tipo,
                            Visible = Tm.Visible
                        };



            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Tipo = item.Tipo;
                //if (item.Tipo != null)
                //    cat.TipoMovimientoPadreDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMoviemientoPadreId).SingleOrDefault().Descripcion;
                //else
                //    cat.TipoMovimientoPadreDescripcion = "";
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            return Salida.Where(o => o.Visible == "S").OrderBy(o => o.Codigo).ToList();

        }


        internal List<TipoMovimientos> ObtenerTipoMovimientosEgresosyAjuste()
        {
            int cuentaAjuste = Int32.Parse(ConfigurationManager.AppSettings["CuentaAJUSTE"].ToString());


            var query = from Tm in SqlContext.TipoMovimientos
                        where Tm.IsEgreso == true
                        select new
                        {
                            Id = Tm.Id,
                            Descripcion = Tm.Descripcion,
                            Codigo = Tm.Codigo,
                            Identificador = Tm.Descripcion + " - " + Tm.Codigo,
                            Tipo = Tm.Tipo,
                            Visible = Tm.Visible
                        };


            TipoMovimientos ajuste = SqlContext.TipoMovimientos.Single(o => o.Id == cuentaAjuste);

            List<TipoMovimientos> Salida = new List<TipoMovimientos>();
            foreach (var item in query)
            {

                TipoMovimientos cat = new TipoMovimientos();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Codigo = item.Codigo;
                cat.Identificador = item.Identificador;
                cat.Tipo = item.Tipo;
                //if (item.Tipo != null)
                //    cat.TipoMovimientoPadreDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMoviemientoPadreId).SingleOrDefault().Descripcion;
                //else
                //    cat.TipoMovimientoPadreDescripcion = "";
                cat.Visible = item.Visible;

                Salida.Add(cat);
            }

            Salida.Add(ajuste);

            return Salida.Where(o => o.Visible == "S").OrderBy(o => o.Codigo).ToList();
        }
    }
}
