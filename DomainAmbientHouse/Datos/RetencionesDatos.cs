using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class RetencionesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public RetencionesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Retenciones> ListarRetenciones()
        {

            var query = from p in SqlContext.Retenciones
                        where p.Delete == false
                        select p;

            return RetencionesToModel(query).OrderBy(o => o.CreateFecha).ToList();

        }

        public virtual List<Retenciones> BuscarRetencionesPorPagosProveedores(int pagoProveedorId)
        {

            var query = from p in SqlContext.Retenciones
                        where p.PagoProveedorId == pagoProveedorId && p.Delete == false
                        select p;

            return RetencionesToModel(query).OrderBy(o => o.CreateFecha).ToList();

        }

        private List<Retenciones> RetencionesToModel(IQueryable<Retenciones> query)
        {

            List<Retenciones> list = new List<Retenciones>();

            foreach (var item in query)
            {
                Retenciones salida = new Retenciones();

                salida.Id = item.Id;
                salida.Fecha = item.Fecha;
                salida.Importe = item.Importe;
                salida.NroCertificado = item.NroCertificado;
                salida.TipoMovimimientoId = item.TipoMovimimientoId;
                salida.TipoMovimientoDescripcion = SqlContext.TipoMovimientos.Where(o => o.Id == item.TipoMovimimientoId).SingleOrDefault().Descripcion;
                salida.PagoClienteId = item.PagoClienteId;
                salida.PagoProveedorId = item.PagoProveedorId;


                list.Add(salida);
            }

            return list;
        }

        public bool GrabarRetenciones(Retenciones retenciones)
        {
            try
            {

                if (retenciones.Id > 0)
                {
                    Retenciones edit = SqlContext.Retenciones.Where(o => o.Id == retenciones.Id).SingleOrDefault();

                    edit.Importe = retenciones.Importe;
                    edit.Fecha = retenciones.Fecha;
                    edit.NroCertificado = retenciones.NroCertificado;

                    edit.UpdateFecha = System.DateTime.Now;


                    SqlContext.SaveChanges();

                    return true;
                }
                else
                {
                    retenciones.CreateFecha = System.DateTime.Now;

                    SqlContext.Retenciones.Add(retenciones);
                    SqlContext.SaveChanges();

                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }

        public Retenciones BuscarRetenciones(int id)
        {
            return SqlContext.Retenciones.Where(o => o.Id == id).SingleOrDefault();

        }

        public bool ElimnarRetenciones(int id)
        {
            if (id > 0)
            {
                Retenciones edit = BuscarRetenciones(id);

                if (edit != null)
                {

                    edit.Delete = true;
                    edit.DeleteFecha = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

    }

}

namespace DomainAmbientHouse.Entidades
{
    public partial class Retenciones
    {

        public string TipoMovimientoDescripcion { get; set; }

    }

}

