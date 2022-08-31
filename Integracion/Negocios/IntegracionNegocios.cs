using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Integracion.Entidades;
using Integracion.Datos;


namespace Integracion.Negocios
{
    public class IntegracionNegocios
    {

        IntegracionDatos Datos;

        public IntegracionNegocios()
        {
            Datos = new IntegracionDatos();
        }



        public List<ReporteAdicionales> ObtenerAdicionalesEventos(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {
            return Datos.ObtenerAdicionalesEventos(nroEvento, nroPresupuesto, fechaDesde, fechaHasta);
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservados()
        {
            return Datos.BuscarEventosConfirmadosReservados();
        }

        public void CambioEstadoEventos(int eventoId, int estadoId)
        {
            Datos.CambioEstadoEvento(eventoId, estadoId);
        }

        public ObtenerDatosParaPresupuesto ObtenerPresupuestosPorPresupuesto(int id)
        {
            return Datos.ObtenerPresupuestosPorPresupuesto(id);
        }


        public ObtenerPresupuestoSalon ObtenerPresupuestosSalon(int presupuestoId)
        {

            return Datos.ObtenerPresupuestosSalon(presupuestoId);
        }

        public ObtenerPresupuestoTecnica ObtenerPresupuestoTecnica(int presupuestoId)
        {

            return Datos.ObtenerPresupuestoTecnica(presupuestoId);
        }

        public ObtenerPresupuestoCatering ObtenerPresupuestoCatering(int presupuestoId)
        {

            return Datos.ObtenerPresupuestoCatering(presupuestoId);
        }

        public ObtenerPresupuestoBarra ObtenerPresupuestoBarra(int presupuestoId)
        {

            return Datos.ObtenerPresupuestoBarra(presupuestoId);
        }

        public ObtenerPresupuestoAmbientacion ObtenerPresupuestoAmbientacion(int presupuestoId)
        {

            return Datos.ObtenerPresupuestoAmbientacion(presupuestoId);
        }

        public ObtenerPresupuestoAudiovisual ObtenerPresupuestoAudiovisual(int presupuestoId)
        {

            return Datos.ObtenerPresupuestoAudiovisual(presupuestoId);
        }

        public ObtenerPresupuestoArtistica ObtenerPresupuestoArtistica(int presupuestoId)
        {

            return Datos.ObtenerPresupuestoArtistica(presupuestoId);
        }

        public List<ListarAdicionalesPorPresupuesto> ObtenerAdicionales(int presupuestoId)
        {
            return Datos.ObtenerAdicionales(presupuestoId);
        }

        public List<ObtenerEventos> BuscarEventosMigradosPorFechaVista(DateTime fecha)
        {
            return Datos.BuscarEventosMigradosPorFechaVista(fecha);
        }

        public List<ObtenerEventos> BuscarEventosEnviadosPorEmpleado(int EmpleadoId)
        {
            return Datos.BuscarEventosEnviadosPorEmpleado(EmpleadoId);
        }

        public List<ObtenerEventos> ObtenerEventosPorEstado(int estado)
        {
            return Datos.ObtenerEventosPorEstado(estado);
        }
    }
}
