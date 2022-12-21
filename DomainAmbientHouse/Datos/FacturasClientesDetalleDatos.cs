using DomainAmbientHouse.Entidades;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class FacturasClientesDetalleDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public FacturasClientesDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();

        }

        private List<FacturaClienteDetalle> FacturaClienteDetalleToModel(IQueryable<FacturaClienteDetalle> query)
        {
            List<FacturaClienteDetalle> list = new List<FacturaClienteDetalle>();

            foreach (var item in query)
            {
                FacturaClienteDetalle salida = new FacturaClienteDetalle();

                salida.Id = item.Id;
                salida.Importe = item.Importe;
                salida.Descripcion = item.Descripcion;
                salida.Cantidad = item.Cantidad;
                salida.FacturaClienteId = item.FacturaClienteId;
                salida.Grabado = item.Grabado;

                list.Add(salida);
            }

            return list;
        }

        internal List<FacturaClienteDetalle> BuscarDetalleFacturas(int facturaId)
        {
            return SqlContext.FacturaClienteDetalle.Where(o => o.FacturaClienteId == facturaId).ToList();
        }

        public virtual FacturaClienteDetalle BuscarFacturaClienteDetalle(int id)
        {

            var query = from t in SqlContext.FacturaClienteDetalle
                        where t.Id == id
                        select t;


            return FacturaClienteDetalleToModel(query).SingleOrDefault();

        }

        public virtual bool GrabarFacturasClienteDetalle(FacturaClienteDetalle detalle)
        {

            try
            {


                if (detalle.Id > 0)
                {
                    FacturaClienteDetalle edit = SqlContext.FacturaClienteDetalle.Where(o => o.Id == detalle.Id).FirstOrDefault();

                    edit.Descripcion = detalle.Descripcion;
                    edit.Importe = detalle.Importe;
                    edit.Cantidad = detalle.Cantidad;
                    edit.Grabado = detalle.Grabado;
                    edit.UpdateFecha = System.DateTime.Now;

                    SqlContext.SaveChanges();

                    return true;

                }
                else
                {
                    detalle.CreateFecha = System.DateTime.Now;

                    SqlContext.FacturaClienteDetalle.Add(detalle);
                    SqlContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool ElimnarFacturaClienteDetalle(int id)
        {
            if (id > 0)
            {
                FacturaClienteDetalle edit = BuscarFacturaClienteDetalle(id);

                if (edit != null)
                {

                    edit.Delete = true;
                    edit.FechaDelete = System.DateTime.Now;

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
    public partial class FacturaClienteDetalle
    {
        public string ImporteStr
        {
            get
            {
                return System.Math.Round((double)Importe, 2).ToString("C");
            }

        }

        public string GrabadoStr
        {
            get
            {
                if (Grabado)
                    return "SI";
                else
                    return "NO";

            }

        }


    }
}
