using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAmbientHouse.Datos
{
    public class DegustacionDetalleDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public DegustacionDetalleDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        private List<DegustacionDetalle> DegustacionToModel(IQueryable<DegustacionDetalle> query)
        {
            List<DegustacionDetalle> list = new List<DegustacionDetalle>();

            foreach (var item in query)
            {

                DegustacionDetalle salida = new DegustacionDetalle();

                salida.Id = item.Id;
                salida.CantidadInvitados = item.CantidadInvitados;
                salida.CaracteristicaId = item.CaracteristicaId;
                salida.CaracteristicaDescripcion = this.SqlContext.Caracteristicas.Where(o => o.Id == item.CaracteristicaId).FirstOrDefault().Descripcion;
                salida.Comensal = item.Comensal;
                salida.Comentarios = item.Comentarios;
                salida.DegustacionId = item.DegustacionId;
                salida.EmpleadoId = item.EmpleadoId;
                salida.EmpleadoApellidoyNombre = this.SqlContext.Empleados.Where(o => o.Id == item.EmpleadoId).FirstOrDefault().ApellidoNombre;
                salida.Empresa = item.Empresa;
                salida.FechaEvento = item.FechaEvento;
                salida.LocacionId = item.LocacionId;

                salida.LocacionDescripcion = this.SqlContext.Locaciones.Where(o => o.Id == item.LocacionId).FirstOrDefault().Descripcion;
                salida.Mail = item.Mail;
                salida.NroComensal = item.NroComensal;
                salida.NroMesa = item.NroMesa;
                salida.SegmentoId = item.SegmentoId;
                salida.SegmentoDescripcion = this.SqlContext.Segmentos.Where(o => o.Id == item.SegmentoId).FirstOrDefault().Descripcion;
                salida.Telefono = item.Telefono;
                salida.TipoEventoId = item.TipoEventoId;
                if ((item.TipoEventoId > 0) && (item.TipoEventoId != null))
                {
                    salida.TipoEventoDescripcion = this.SqlContext.TipoEventos.Where(o => o.Id == item.TipoEventoId).FirstOrDefault().Descripcion;
                }
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Where(o => o.Id == item.EstadoId).FirstOrDefault().Descripcion;
                salida.EstadoEvento = item.EstadoEvento;

                list.Add(salida);

            }
            return list;
        }

        public DegustacionDetalle BuscarDegustacionDetalle(int id)
        {
            return this.SqlContext.DegustacionDetalle.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<DegustacionDetalle> BuscarDegustacionDetallePorDegustacion(int DegustacionId)
        {

            IQueryable<DegustacionDetalle> query = this.SqlContext.DegustacionDetalle.Where(o => o.DegustacionId == DegustacionId);

            return (from o in this.DegustacionToModel(query)
                    orderby o.SegmentoId
                    orderby o.EmpleadoId
                    select o).ToList<DegustacionDetalle>();
        }

        public List<DegustacionDetalle> BuscarDegustacionDetallePorEmpleado(int DegustacionId, int EmpleadoId)
        {
            var query = from d in SqlContext.DegustacionDetalle
                        where d.DegustacionId == DegustacionId && d.EmpleadoId == EmpleadoId
                        select d;

            return this.DegustacionToModel(query).ToList();
        }

        public bool GrabarDegustacionDetalle(DegustacionDetalle detalle)
        {

            try
            {
                if (detalle.Id <= 0)
                {
                    this.SqlContext.DegustacionDetalle.Add(detalle);
                    this.SqlContext.SaveChanges();
                    return true;
                }
                else
                {
                    DegustacionDetalle edit = this.SqlContext.DegustacionDetalle.Where(o => o.Id == detalle.Id).FirstOrDefault();

                    edit.CantidadInvitados = detalle.CantidadInvitados;
                    edit.CaracteristicaId = detalle.CaracteristicaId;
                    edit.Comensal = detalle.Comensal;
                    edit.NroComensal = detalle.NroComensal;
                    edit.Comentarios = detalle.Comentarios;
                    edit.DegustacionId = detalle.DegustacionId;
                    edit.EmpleadoId = detalle.EmpleadoId;
                    edit.Empresa = detalle.Empresa;
                    edit.FechaEvento = detalle.FechaEvento;
                    edit.LocacionId = detalle.LocacionId;
                    edit.Mail = detalle.Mail;
                    edit.NroComensal = detalle.NroComensal;
                    edit.NroMesa = detalle.NroMesa;
                    edit.SegmentoId = detalle.SegmentoId;
                    edit.Telefono = detalle.Telefono;
                    edit.TipoEventoId = detalle.TipoEventoId;
                    edit.EstadoId = detalle.EstadoId;
                    edit.EstadoEvento = detalle.EstadoEvento;
                    this.SqlContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class DegustacionDetalle
    {
        public string CaracteristicaDescripcion { get; set; }

        public string EmpleadoApellidoyNombre { get; set; }

        public string LocacionDescripcion { get; set; }

        public string SegmentoDescripcion { get; set; }

        public string TipoEventoDescripcion { get; set; }

        public string EstadoDescripcion { get; set; }
    }
}


