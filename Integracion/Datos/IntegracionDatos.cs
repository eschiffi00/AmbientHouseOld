using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integracion.Entidades;
using System.Globalization;
using System.Configuration;

namespace Integracion.Datos
{
    public class IntegracionDatos
    {
        public AHEntities SqlContext { get; set; }


        public IntegracionDatos()
        {
            SqlContext = new AHEntities();
        }


        public List<ReporteAdicionales> ObtenerAdicionalesEventos(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {

           

            var query = from P in SqlContext.Presupuestos
                        join pA in SqlContext.PresupuestoAdicionales on P.Id equals pA.PresupuestoId 
                        join A in SqlContext.Adicionales on pA.AdicionalId equals A.Id
                        join R in SqlContext.Rubros on A.RubroId equals R.Id
                        select new
                        {
                            NroEvento = P.EventoId,
                            NroPresupuesto = P.Id,
                            FechaEvento = P.FechaEvento,
                            Rubro = R.Descripcion,
                            AdicionalDesc = A.Descripcion,
                            AdicionalCant = pA.Cantidad,
                            AdicionalValor = pA.ValorAdicional


                        };

            List<ReporteAdicionales> Salida = new List<ReporteAdicionales>();
            foreach (var item in query)
            {

                ReporteAdicionales cat = new ReporteAdicionales();

                cat.NroEvento = item.NroEvento;
                cat.NroPresupuesto = item.NroPresupuesto;
                cat.FechaEvento = item.FechaEvento;
                cat.Rubro = item.Rubro;
                cat.AdicionalDesc = item.AdicionalDesc;
                cat.AdicionalCant =  (int)item.AdicionalCant;
                cat.AdicionalValor = item.AdicionalValor;


                Salida.Add(cat);
            }

            DateTime fecDesde;
            DateTime fecHasta;

            if (fechaDesde != "")
            {
                fecDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Salida = Salida.Where(o => o.FechaEvento >= fecDesde).ToList();

            }
            if (fechaHasta != "")
            {
                fecHasta = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Salida = Salida.Where(o => o.FechaEvento <= fecHasta).ToList();
            }


            if (nroEvento > 0)
            {
                Salida = Salida.Where(o => o.NroEvento == nroEvento).ToList();
            }

            if (nroPresupuesto > 0)
            {
                Salida = Salida.Where(o => o.NroPresupuesto == nroPresupuesto).ToList();
            }


            return Salida.ToList();
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservados()
        {
 
            int estadoConfirmado = 2;
            int estadoReservado = 4;
            int estadoCerrado = 14;

            int estadoPresupuestoAprobado = 11;

            return SqlContext.ObtenerEventos.Where(o => o.PresupuestoEstadoId == estadoPresupuestoAprobado && o.FechaEvento >= System.DateTime.Today && (o.EstadoId == estadoConfirmado || o.EstadoId == estadoReservado || o.EstadoId == estadoCerrado)).OrderBy(o => o.FechaEvento).ToList();
        }

        public void CambioEstadoEvento(int eventoId, int estadoId)
        {
            Eventos eventoEdit = SqlContext.Eventos.Where(o => o.Id == eventoId).First();

            eventoEdit.EstadoId = estadoId;

            SqlContext.SaveChanges();

        }

        public ObtenerDatosParaPresupuesto ObtenerPresupuestosPorPresupuesto(int id)
        {
            return SqlContext.ObtenerDatosParaPresupuesto.Where(o => o.PresupuestoId == id).FirstOrDefault();
        }


        public ObtenerPresupuestoSalon ObtenerPresupuestosSalon(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoSalon.Where( o=> o.PresupuestoId== presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoTecnica ObtenerPresupuestoTecnica(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoTecnica.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoCatering ObtenerPresupuestoCatering(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoCatering.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoBarra ObtenerPresupuestoBarra(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoBarra.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoAmbientacion ObtenerPresupuestoAmbientacion(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoAmbientacion.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoAudiovisual ObtenerPresupuestoAudiovisual(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoAudiovisual.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoArtistica ObtenerPresupuestoArtistica(int presupuestoId)
        {

            return SqlContext.ObtenerPresupuestoArtistica.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public List<ListarAdicionalesPorPresupuesto> ObtenerAdicionales(int presupuestoId)
        {
            return SqlContext.ListarAdicionalesPorPresupuesto.Where(o => o.PresupuestoId == presupuestoId).OrderBy(o => o.RubroDescripcion).ToList();
        }



        public List<ObtenerEventos> BuscarEventosMigradosPorFechaVista(DateTime fecha)
        {

            int estadoConfirmado = 2;
            int estadoReservado = 4;
            int estadoCerrado = 14;

            int estadoPresupuestoAprobado = 11;

            return SqlContext.ObtenerEventos.Where(o => o.FechaEvento == fecha && o.PresupuestoEstadoId == estadoPresupuestoAprobado && (o.EstadoId == estadoConfirmado || o.EstadoId == estadoReservado || o.EstadoId == estadoCerrado)).OrderBy(o => o.FechaEvento).ToList();

        }

        public List<ObtenerEventos> BuscarEventosEnviadosPorEmpleado(int EmpleadoId)
        {

            int estadoEnviado = 8;

            int estadoPresupuestoEnviado = 13;


            return SqlContext.ObtenerEventos.Where(o => o.PresupuestoEstadoId == estadoPresupuestoEnviado && o.EmpleadoId == EmpleadoId && o.FechaEvento >= System.DateTime.Today && (o.EstadoId == estadoEnviado)).OrderBy(o => o.FechaEvento).ToList();

        }

        public List<ObtenerEventos> ObtenerEventosPorEstado(int estado)
        {
            return SqlContext.ObtenerEventos.Where(o => o.EstadoId == estado).ToList();
        }
    }
}
