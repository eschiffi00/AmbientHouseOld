using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Domain.Datos
{
    public class PresupuestosDetalleDatos
    {

        public AmbientHouseEntities SqlContext { get; set; }

        public PresupuestosDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public PresupuestoDetalle Get(int Id)
        {
            return SqlContext.PresupuestoDetalle.Where(o => o.Id == Id).Single();
        }

        public List<PresupuestoDetalle> List(PresupuestoDetalleSearcher searcher)
        {
            var query = from p in SqlContext.PresupuestoDetalle
                        select p;


            if (searcher.NroPresupuesto > 0)
                query = query.Where(o => o.PresupuestoId == searcher.NroPresupuesto);




            return query.ToList();
        }

        public bool Save(PresupuestoDetalle detalle)
        {

            if (detalle.Id > 0)
            {
                PresupuestoDetalle edit = SqlContext.PresupuestoDetalle.Where(o => o.Id == detalle.Id).First();

                ToEntity(detalle, edit);

                try
                {
                    SqlContext.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                detalle.FechaCreate = System.DateTime.Now;

                try
                {
                    SqlContext.PresupuestoDetalle.Add(detalle);
                    SqlContext.SaveChanges();

                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }


        }

        private static void ToEntity(PresupuestoDetalle detalle, PresupuestoDetalle edit)
        {
            edit.AnuloCanon = detalle.AnuloCanon;
            edit.Cannon = detalle.Cannon;
            edit.CantidadAdicional = detalle.CantidadAdicional;
            edit.CantInvitadosLogistica = detalle.CantInvitadosLogistica;
            edit.CodigoItem = detalle.CodigoItem;
            edit.Comentario = detalle.Comentario;
            edit.ComentarioProveedor = detalle.ComentarioProveedor;
            edit.Comision = detalle.Comision;
            edit.Costo = detalle.Costo;
            edit.Descuentos = detalle.Descuentos;
            edit.EstadoId = detalle.EstadoId;
            edit.EstadoProveedor = detalle.EstadoProveedor;
            edit.FechaAprobacion = detalle.FechaAprobacion;
            edit.FechaUpdate = System.DateTime.Now;
            edit.Incremento = detalle.Incremento;
            edit.LocacionId = detalle.LocacionId;
            edit.LocalidadId = detalle.LocalidadId;
            edit.Logistica = detalle.Logistica;
            edit.PorcentajeComision = detalle.PorcentajeComision;
            edit.PrecioItem = detalle.PrecioItem;
            edit.PrecioLista = detalle.PrecioLista;
            edit.PrecioMas5 = detalle.PrecioMas5;
            edit.PrecioMenos10 = detalle.PrecioMenos10;
            edit.PrecioMenos5 = detalle.PrecioMenos5;
            edit.PrecioSeleccionado = detalle.PrecioSeleccionado;
            edit.PresupuestoId = detalle.PresupuestoId;
            edit.ProductoId = detalle.ProductoId;
            edit.ProveedorId = detalle.ProveedorId;
            edit.ServicioId = detalle.ServicioId;
            edit.TipoLogisticaId = detalle.TipoLogisticaId;
            edit.UnidadNegocioId = detalle.UnidadNegocioId;
            edit.UsoCocina = detalle.UsoCocina;
            edit.ValorIntermediario = detalle.ValorIntermediario;
            edit.ValorSeleccionado = detalle.ValorSeleccionado;
            edit.version = detalle.version;
        }

    }
}

namespace Domain.Entidades
{
    public partial class PresupuestoDetalleSearcher
    {
        public int NroPresupuesto { get; set; }
    }

    public partial class PresupuestoDetalle
    {
        private string formatoFecha = ConfigurationManager.AppSettings["FormatoddMMyyyy"].ToString();

        public string FechaCreateStr
        {
            get
            {
                return String.Format(formatoFecha, FechaCreate);
            }
            set
            {
                FechaCreate = DateTime.ParseExact(FechaCreateStr, formatoFecha, CultureInfo.InvariantCulture);
            }
        }

        //public readonly string ValorSeleccionadoStr
        //{
        //    get
        //    {
        //        return System.Math.Round(ValorSeleccionado, 2).ToString("C"); 
        //    }

        //}

        //public readonly string UsoCocinaStr
        //{
        //    get
        //    {
        //        if (UsoCocina != null)
        //            return System.Math.Round((double)UsoCocina, 2).ToString("C");
        //        else
        //            return "";
        //    }

        //}

        //public readonly string CanonStr
        //{
        //    get
        //    {
        //        if (UsoCocina != null)
        //            return System.Math.Round((double)Cannon, 2).ToString("C");
        //        else
        //            return "";
        //    }

        //}


    }
}