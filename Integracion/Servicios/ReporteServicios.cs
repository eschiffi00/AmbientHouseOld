using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integracion.Negocios;
using Integracion.Entidades;


namespace Integracion.Servicios
{
    public class ReporteServicios
    {
        public ReporteServicios()
        {
        }


        public List<ReporteAdicionales> ObtenerAdicionalesEventos(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerAdicionalesEventos(nroEvento, nroPresupuesto, fechaDesde, fechaHasta);
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservados()
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.BuscarEventosConfirmadosReservados();
        }

        public void CambioEstadoEvento(int eventoId, int estadoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            negocios.CambioEstadoEventos(eventoId, estadoId);
        }

        public ObtenerDatosParaPresupuesto ObtenerPresupuestosPorPresupuesto(int id)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestosPorPresupuesto(id);
        }

        public ObtenerPresupuestoSalon ObtenerPresupuestosSalon(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestosSalon(presupuestoId);
        }

        public ObtenerPresupuestoTecnica ObtenerPresupuestoTecnica(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestoTecnica(presupuestoId);
        }

        public ObtenerPresupuestoCatering ObtenerPresupuestoCatering(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestoCatering(presupuestoId);
        }

        public ObtenerPresupuestoBarra ObtenerPresupuestoBarra(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestoBarra(presupuestoId);
        }

        public ObtenerPresupuestoAmbientacion ObtenerPresupuestoAmbientacion(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestoAmbientacion(presupuestoId);
        }

        public ObtenerPresupuestoAudiovisual ObtenerPresupuestoAudiovisual(int presupuestoId)

        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestoAudiovisual(presupuestoId);
        }

        public ObtenerPresupuestoArtistica ObtenerPresupuestoArtistica(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerPresupuestoArtistica(presupuestoId);
        }

        public List<ListarAdicionalesPorPresupuesto> ObtenerAdicionales(int presupuestoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerAdicionales(presupuestoId);
        }


        public ObtenerEventos BuscarEventoPorNroEvento(int EventoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.BuscarEventosConfirmadosReservados().Where(o=> o.EventoId == EventoId).FirstOrDefault();
        }

        public List<ObtenerEventos> BuscarEventosMigradosPorFechaVista(DateTime fecha)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.BuscarEventosMigradosPorFechaVista (fecha);
        }

      

        public List<ObtenerEventos> BuscarEventosEnviadosPorEmpleado(int EmpleadoId)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.BuscarEventosEnviadosPorEmpleado(EmpleadoId);

        }

        public List<ObtenerEventos> ObtenerEventosPorEstado(int estado)
        {
            IntegracionNegocios negocios = new IntegracionNegocios();

            return negocios.ObtenerEventosPorEstado(estado);
        }
    }
}
