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
    public class EventosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public EventosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<Presupuestos> BuscarEventosPorFecha(DateTime fecha, int locacionId)
        {

            return SqlContext.Presupuestos.Where(o => o.FechaEvento == fecha && o.LocacionId == locacionId).ToList();

        }

        public virtual List<ObtenerEventos> BuscarEventosPorFechaVista(DateTime fecha)
        {
            int eventosPerdidos = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());

            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());

            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            return SqlContext.ObtenerEventos.Where(o => o.FechaEvento == fecha && o.PresupuestoEstadoId == estadoPresupuestoAprobado && (o.EstadoId == estadoConfirmado || o.EstadoId == estadoReservado || o.EstadoId == estadoCerrado)).OrderBy(o => o.FechaEvento).ToList();



        }

        public List<ObtenerEventos> BuscarEventosPorFechaClienteVista(DateTime fechaEvento, string cliente, string nroPresupuesto)
        {
            var query = from c in SqlContext.ObtenerEventos
                        select c;

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(t => t.ApellidoNombre.Contains(cliente));

            if (fechaEvento.Year > 1)
            {
                query = query.Where(t => t.Fecha == fechaEvento);
            }

            //if (!string.IsNullOrEmpty(nroPresupuesto))
            //    query = query.Where(t => t..Contains(nroPresupuesto));

            return query.ToList();
        }

        public List<ObtenerEventos> BuscarEventosPorCliente(int clienteId)
        {
            return SqlContext.ObtenerEventos.Where(o => o.ClienteId == clienteId).ToList();
        }

        public List<ObtenerCantidadInvitadosCatering> TraerCantidadPersonasCatering()
        {
            return SqlContext.ObtenerCantidadInvitadosCatering.ToList();
        }

        public List<ObtenerCantidadInvitadosBarras> TraerCantidadPersonasBarras()
        {
            return SqlContext.ObtenerCantidadInvitadosBarras.ToList();
        }

        public List<ObtenerEventos> BuscarEventosPorEjecutivo(int empleadoId)
        {
            int Asignado = Int32.Parse(ConfigurationManager.AppSettings["EstadoAsignado"].ToString());


            return SqlContext.ObtenerEventos.Where(o => o.EmpleadoId == empleadoId && o.EstadoId == Asignado).OrderByDescending(o => o.FechaEvento).ToList();
        }

        #region Grabar Presupuestos


        public void GrabarPresupuesto(Presupuestos presupuesto)
        {
            SqlContext.Presupuestos.Add(presupuesto);
            SqlContext.SaveChanges();
        }

        public void EditarPresupuesto(Presupuestos presupuesto)
        {
            Presupuestos presuEdit = SqlContext.Presupuestos.Where(o => o.Id == presupuesto.Id).Single();

            presuEdit.TipoEventoOtro = presupuesto.TipoEventoOtro;
            presuEdit.TipoEventoId = presupuesto.TipoEventoId;
            presuEdit.SegmentoId = presupuesto.SegmentoId;
            presuEdit.SectorId = presupuesto.SectorId;
            presuEdit.PrecioTotal = presupuesto.PrecioTotal;
            presuEdit.PrecioPorPersona = presupuesto.PrecioPorPersona;
            presuEdit.LocacionOtra = presupuesto.LocacionOtra;
            presuEdit.LocacionId = presupuesto.LocacionId;
            presuEdit.JornadaId = presupuesto.JornadaId;
            presuEdit.HorarioEvento = presupuesto.HorarioEvento;
            presuEdit.HorarioArmado = presupuesto.HorarioArmado;
            presuEdit.HoraFinalizado = presupuesto.HoraFinalizado;
            presuEdit.FechaPresupuesto = presupuesto.FechaPresupuesto;
            presuEdit.FechaEvento = presupuesto.FechaEvento;
            presuEdit.EventoId = presupuesto.EventoId;
            presuEdit.Comentario = presupuesto.Comentario;
            presuEdit.CaracteristicaId = presupuesto.CaracteristicaId;
            presuEdit.CantidadInicialInvitados = presupuesto.CantidadInicialInvitados;
            presuEdit.CantidadInvitadosAdolecentes = presupuesto.CantidadInvitadosAdolecentes;
            presuEdit.CantidadInvitadosMenores3 = presupuesto.CantidadInvitadosMenores3;
            presuEdit.CantidadInvitadosMenores3y8 = presupuesto.CantidadInvitadosMenores3y8;
            presuEdit.EstadoId = presupuesto.EstadoId;


            SqlContext.SaveChanges();
        }

        #endregion

        public void GrabarSeguimiento(int presupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoModificado, int empleadoId)
        {

            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());
            int estadoPresupuestoRechazado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoRechazado"].ToString());

            int estadoEventoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int estadoEventoPerdido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());
            int estadoEventoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());


            Presupuestos presuEdit = SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).FirstOrDefault();

            presuEdit.EstadoId = estadoModificado;


            Eventos eventoEdit = SqlContext.Eventos.Where(o => o.Id == movimientosClientes.EventoId).FirstOrDefault();

            if (estadoModificado == estadoPresupuestoAprobado)
            {
                eventoEdit.EstadoId = estadoEventoCerrado;
                eventoEdit.EmpleadoId = empleadoId;

            }
            //else if (estadoModificado == estadoPresupuestoRechazado)
            //{
            //    eventoEdit.EstadoId = estadoEventoPerdido;
            //}
            else
            {
                eventoEdit.EstadoId = estadoEventoEnviado;
                eventoEdit.EmpleadoId = empleadoId;
            }

            SqlContext.ClientesEventosMovimientos.Add(movimientosClientes);
            SqlContext.SaveChanges();
        }

        public List<SeguimientosEventosClientesEstados> BuscarEventosPorEjecutivoSeguimiento(int empleadoId)
        {

            int Enviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            int Reservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int Confirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int Perdido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());

            return SqlContext.SeguimientosEventosClientesEstados.Where(o => o.EmpleadoId == empleadoId && (o.EstadoId == Enviado ||
                                                                                        o.EstadoId == Reservado ||
                                                                                        o.EstadoId == Confirmado ||
                                                                                        o.EstadoId == Perdido)).OrderByDescending(o => o.Fecha).OrderByDescending(o => o.EstadoId).ToList();
        }

        public int BuscarUltimoPresupuestoPorEvento(int eventoId)
        {
            var query = (from p in SqlContext.Presupuestos
                         where p.EventoId == eventoId
                         select p.Id).Max();

            return query;
        }

        public List<ObtenerEventos> BuscarEventosConfirmadosReservados()
        {

            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());

            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            return SqlContext.ObtenerEventos.Where(o => o.PresupuestoEstadoId == estadoPresupuestoAprobado && o.FechaEvento >= System.DateTime.Today && (o.EstadoId == estadoConfirmado || o.EstadoId == estadoReservado || o.EstadoId == estadoCerrado)).OrderBy(o => o.FechaEvento).ToList();
        }

        public int BuscarClientePorEvento(int EventoId)
        {
            return SqlContext.Eventos.Where(o => o.Id == EventoId).FirstOrDefault().ClienteId;
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosActivosPorEjecutivoSeguimiento(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, List<ClientesPipedrive> listClientes)
        {

            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            int estadoPresupuestoEnviadoalCliente = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());

            int estadoVencido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoVencido"].ToString());

            SeguridadDatos DatosSeguridad = new SeguridadDatos();



            if (DatosSeguridad.EsUsuarioGerencia(EmpleadoId))
            {
                var query = ObtenerEventosPresupuestosGerencia().ToList();

                var queryGerencia = from e in query
                                    where (e.PresupuestoEstadoId == estadoPresupuestoEnviadoalCliente || e.PresupuestoEstadoId == estadoVencido)
                                            && e.EstadoEventoId == estadoEnviado && e.FechaEvento >= System.DateTime.Today
                                    select e;

                queryGerencia = FiltrosQueryIncio(nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, queryGerencia);


                return queryGerencia.OrderBy(o => o.FechaEvento).Distinct().ToList();
            }
            else
            {

                var query = ObtenerEventosPresupuestos().ToList();

                var queryEjecutivo = from e in query
                                     where e.EmpleadoId == EmpleadoId
                                            && (e.PresupuestoEstadoId == estadoPresupuestoEnviadoalCliente || e.PresupuestoEstadoId == estadoVencido)
                                            && e.EstadoEventoId == estadoEnviado && e.FechaEvento >= System.DateTime.Today
                                     select e;

                queryEjecutivo = FiltrosQueryIncio(nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, queryEjecutivo);

                return queryEjecutivo.OrderBy(o => o.FechaEvento).Distinct().ToList();

            }
        }

        private static IQueryable<Entidades.ObtenerEventos> FiltrosQueryInicio(int nroEvento, int nroPresupuesto, int nroCliente, IQueryable<Entidades.ObtenerEventos> queryGerencia)
        {
            if (nroEvento > 0)
            { queryGerencia = queryGerencia.Where(o => o.EventoId == nroEvento); }

            if (nroPresupuesto > 0)
            { queryGerencia = queryGerencia.Where(o => o.PresupuestoId == nroPresupuesto); }

            if (nroCliente > 0)
            { queryGerencia = queryGerencia.Where(o => o.ClienteId == nroCliente); }
            return queryGerencia;
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosConfirmadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente,string apellidoNombre, string razonsocial, string fechaEvento)
        {

            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());

            int estadoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());



            SeguridadDatos DatosSeguridad = new SeguridadDatos();

            var query = ObtenerEventosGanados().ToList();

            var queryGerencia = from e in query
                                where e.PresupuestoEstadoId == estadoPresupuestoAprobado
                                        && (e.EstadoEventoId == estadoConfirmado || e.EstadoEventoId == estadoReservado || e.EstadoEventoId == estadoCerrado)
                                select e;

            queryGerencia = FiltrosQueryInicio(nroEvento, nroPresupuesto, nroCliente, apellidoNombre, razonsocial, fechaEvento, queryGerencia);


            return queryGerencia.OrderBy(o => o.FechaEvento).Distinct().ToList();

        }

        public List<ObtenerEventosPresupuestos> BuscarEventosRealizadosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string fechaEvento)
        {


            int estadoRealizado = Int32.Parse(ConfigurationManager.AppSettings["EstadoRealizado"].ToString());
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());


            IEnumerable<ObtenerEventosPresupuestos> query;

            query = ObtenerEventosRealizados(estadoPresupuestoAprobado, estadoRealizado).ToList();


            if (nroEvento > 0)
            { query = query.Where(o => o.EventoId == nroEvento); }


            if (nroPresupuesto > 0)
            { query = query.Where(o => o.PresupuestoId == nroPresupuesto); }

            if (!String.IsNullOrEmpty(fechaEvento))
            {
                DateTime fecha = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEvento == fecha);
            }


            return query.OrderBy(o => o.FechaEvento).Distinct().ToList();

        }

        public List<ObtenerEventosPresupuestos> BuscarEventosReservadosPorEjecutivos(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string fechaEvento)
        {

            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());


            SeguridadDatos DatosSeguridad = new SeguridadDatos();


            if (DatosSeguridad.EsUsuarioGerencia(EmpleadoId))
            {
                var query = ObtenerEventosGanados().ToList();

                var queryGerencia = from e in query
                                    where e.PresupuestoEstadoId == estadoPresupuestoAprobado
                                            && (e.EstadoEventoId == estadoConfirmado || e.EstadoEventoId == estadoReservado)
                                    select e;

                queryGerencia = FiltrosQueryInicio(nroEvento, nroPresupuesto, nroCliente,"","", fechaEvento, queryGerencia);


                return queryGerencia.OrderBy(o => o.FechaEvento).Distinct().ToList();
            }
            else
            {
                var query = ObtenerEventosGanados().ToList();

                var queryEjecutivo = from e in query
                                     where e.EmpleadoId == EmpleadoId
                                            && e.PresupuestoEstadoId == estadoPresupuestoAprobado
                                           && (e.EstadoEventoId == estadoConfirmado || e.EstadoEventoId == estadoReservado)
                                     select e;

                queryEjecutivo = FiltrosQueryInicio(nroEvento, nroPresupuesto, nroCliente,"","" ,fechaEvento, queryEjecutivo);

                return queryEjecutivo.OrderBy(o => o.FechaEvento).Distinct().ToList();

            }
        }

        private IEnumerable<Entidades.ObtenerEventosPresupuestos> FiltrosQueryInicio(int nroEvento, int nroPresupuesto, int nroCliente, 
                                                                                        string apellidoNombre, string razonsocial,
                                                                                        string fechaEvento, IEnumerable<Entidades.ObtenerEventosPresupuestos> queryGerencia)
        {
            if (nroEvento > 0)
            { queryGerencia = queryGerencia.Where(o => o.EventoId == nroEvento); }

            if (nroPresupuesto > 0)
            { queryGerencia = queryGerencia.Where(o => o.PresupuestoId == nroPresupuesto); }

            if (nroCliente > 0)
            { queryGerencia = queryGerencia.Where(o => o.ClienteId == nroCliente); }

            if (fechaEvento != "")
            {

                DateTime fecha = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                queryGerencia = queryGerencia.Where(o => o.FechaEvento == fecha);

            }

            if (apellidoNombre != "")
            { queryGerencia = queryGerencia.Where(o => o.ApellidoNombre.ToUpper().Contains(apellidoNombre.ToUpper())); }

            if (razonsocial != "")
            { queryGerencia = queryGerencia.Where(o => o.RazonSocial.ToUpper().Contains(razonsocial.ToUpper())); }


            return queryGerencia;
        }

        public List<ObtenerEventosPresupuestos> BuscarEventosGuardadosPorEjecutivoSeguimiento(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, List<ClientesPipedrive> listClientes)
        {

            int estadoAsignado = Int32.Parse(ConfigurationManager.AppSettings["EstadoAsignado"].ToString());
            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            int estadoPresupuestoGuardado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoGuardado"].ToString());


            SeguridadDatos DatosSeguridad = new SeguridadDatos();



            if (DatosSeguridad.EsUsuarioGerencia(EmpleadoId))
            {

                var query = ObtenerEventosPresupuestosGerencia().ToList();

                var queryGerencia = from e in query
                                    where (e.PresupuestoEstadoId == estadoPresupuestoGuardado || e.PresupuestoEstadoId == 0)
                                    && (e.EstadoEventoId == estadoAsignado) && e.FechaEvento >= System.DateTime.Today
                                    select e;

                queryGerencia = FiltrosQueryIncio(nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, queryGerencia);


                return queryGerencia.OrderByDescending(o => o.FechaEvento).Distinct().ToList();
            }
            else
            {

                var query = ObtenerEventosPresupuestos().ToList();

                var queryEjecutivo = from e in query
                                     where e.EmpleadoId == EmpleadoId
                                            && (e.PresupuestoEstadoId == estadoPresupuestoGuardado || e.PresupuestoEstadoId == 0)
                                           && (e.EstadoEventoId == estadoAsignado) && e.FechaEvento >= System.DateTime.Today
                                     select e;

                queryEjecutivo = FiltrosQueryIncio(nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, queryEjecutivo);

                return queryEjecutivo.OrderBy(o => o.FechaEvento).Distinct().ToList();

            }


        }

        public List<ObtenerEventosPresupuestos> BuscarEventos(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, string fechaEvento)
        {
            SeguridadDatos DatosSeguridad = new SeguridadDatos();

            IEnumerable<ObtenerEventosPresupuestos> query;

            if (DatosSeguridad.EsUsuarioGerencia(EmpleadoId))
                query = Obtener(nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, fechaEvento);
            else
                query = Obtener(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, fechaEvento);

            return query.OrderByDescending(o => o.FechaEvento).Distinct().ToList();

        }

        private static IEnumerable<Entidades.ObtenerEventosPresupuestos> FiltrosQueryIncio(int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, IEnumerable<Entidades.ObtenerEventosPresupuestos> queryGerencia)
        {
            if (nroEvento > 0)
            { queryGerencia = queryGerencia.Where(o => o.EventoId == nroEvento); }

            if (nroPresupuesto > 0)
            { queryGerencia = queryGerencia.Where(o => o.PresupuestoId == nroPresupuesto); }

            if (nroCliente > 0)
            { queryGerencia = queryGerencia.Where(o => o.ClienteId == nroCliente); }

            if (apellidoynombre.Length > 0)
            { queryGerencia = queryGerencia.Where(o => o.ApellidoNombre.ToUpper().Contains(apellidoynombre.ToUpper())); }

            if (razonsocial.Length > 0)
            { queryGerencia = queryGerencia.Where(o => o.RazonSocial.Contains(razonsocial)); }

            return queryGerencia;
        }

        private List<ObtenerEventosPresupuestos> ObtenerEventosGanados()
        {

            var query = from Ev in SqlContext.Eventos
                        join Cl in SqlContext.ClientesBis on Ev.ClienteBisId equals Cl.Id
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        select new
                        {
                            ApellidoNombre = Cl.ApellidoNombre,//Cl.ApellidoNombre,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Cl.Id,//Cl.Id,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Cl.RazonSocial,//Cl.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            Cuit = Cl.CUILCUIT,
                            Correo = Cl.MailContactoContratacion,
                            Celular = Cl.TelContactoContratacion
                        };




            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.Cuit = item.Cuit;
                cat.Correo = item.Correo;
                cat.Celular = item.Celular;

                Salida.Add(cat);
            }



            return Salida.Distinct().ToList();

        }

        private List<ObtenerEventosPresupuestos> ObtenerEventosRealizados(int estadoPresupuesto, int estadoRealizado)
        {



            var query = from Ev in SqlContext.Eventos
                        join Cl in SqlContext.ClientesBis on Ev.ClienteBisId equals Cl.Id
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        where Pre.EstadoId == estadoRealizado
                        select new
                        {
                            ApellidoNombre = Cl.ApellidoNombre,//Cl.ApellidoNombre,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Cl.Id,//Cl.Id,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = Pre.Id,
                            RazonSocial = Cl.RazonSocial,//Cl.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            Cuit = Cl.CUILCUIT,
                            Correo = Cl.MailContactoContratacion,
                            Celular = Cl.TelContactoContratacion,

                        };




            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.Cuit = item.Cuit;
                cat.Correo = item.Correo;
                cat.Celular = item.Celular;

                Salida.Add(cat);
            }



            return Salida.Distinct().ToList();

        }

        private List<ObtenerEventosPresupuestos> Obtener(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, string fechaEvento)
        {

            var query = from Ev in SqlContext.Eventos
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        where Ev.EmpleadoId == EmpleadoId //Pre.FechaEvento >= System.DateTime.Today &&
                        select new
                        {
                            ApellidoNombre = Ev.ApellidoNombreCliente,
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Ev.RazonSocial,
                            Fecha = Ev.Fecha,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0
                        };

            if (nroEvento > 0)
            { query = query.Where(o => o.EventoId == nroEvento); }

            if (nroPresupuesto > 0)
            { query = query.Where(o => o.PresupuestoId == nroPresupuesto); }

            if (nroCliente > 0)
            { query = query.Where(o => o.ClienteId == nroCliente); }

            if (apellidoynombre.Length > 0)
            { query = query.Where(o => o.ApellidoNombre.ToUpper().Contains(apellidoynombre.ToUpper())); }

            if (razonsocial.Length > 0)
            { query = query.Where(o => o.RazonSocial.Contains(razonsocial)); }

            if (fechaEvento.Length > 0)
            { query = query.Where(o => o.FechaEvento == DateTime.Parse(fechaEvento)); }


            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;

                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;

                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;
                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;
                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);
                Salida.Add(cat);
            }


            return Salida.Distinct().ToList();

        }

        private List<ObtenerEventosPresupuestos> Obtener(int nroEvento, int nroPresupuesto, int nroCliente, string apellidoynombre, string razonsocial, string fechaEvento)
        {

            var query = from Ev in SqlContext.Eventos
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        //where Pre.FechaEvento >= System.DateTime.Today
                        select new
                        {
                            ApeNom = Ev.ApellidoNombreCliente,
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocialCliente = Ev.RazonSocial,
                            Fecha = Ev.Fecha,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0
                        };

            if (nroEvento > 0)
            { query = query.Where(o => o.EventoId == nroEvento); }

            if (nroPresupuesto > 0)
            { query = query.Where(o => o.PresupuestoId == nroPresupuesto); }

            if (nroCliente > 0)
            { query = query.Where(o => o.ClienteId == nroCliente); }

            if (apellidoynombre.Length > 0)
            { query = query.Where(o => o.ApeNom.ToUpper().Contains(apellidoynombre.ToUpper())); }

            if (razonsocial.Length > 0)
            { query = query.Where(o => o.RazonSocialCliente.ToUpper().Contains(razonsocial.ToUpper())); }

            if (fechaEvento.Length > 0)
            {
                DateTime fecha = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEvento == fecha);
            }

            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApeNom;

                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;

                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;
                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;
                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocialCliente;
                cat.Fecha = item.Fecha;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);
                Salida.Add(cat);
            }

            return Salida.Distinct().ToList();

        }

        private List<ObtenerEventosPresupuestos> ObtenerEventosPresupuestosGerencia()
        {

            var query = from Ev in SqlContext.Eventos
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        select new
                        {
                            ApellidoNombre = Ev.ApellidoNombreCliente,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Ev.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0
                        };




            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);
                Salida.Add(cat);
            }



            return Salida.Distinct().ToList();

        }

        public List<ObtenerEventosPresupuestos> ObtenerEventosPresupuestos(int EventoId)
        {

            var query = from Ev in SqlContext.Eventos
                        //join Cl in ListClientes on Ev.ClienteId equals Cl.Id
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join TEv in SqlContext.TipoEventos on Pre.TipoEventoId equals TEv.Id
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        where Ev.Id == EventoId
                        select new
                        {
                            ApellidoNombre = Ev.ApellidoNombreCliente,//Cl.ApellidoNombre,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,//Cl.Id,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Ev.RazonSocial,//Cl.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0,
                            TipoEvento = TEv.Descripcion,
                            ImporteOrganizador = Pre.ImporteOrganizador,
                            PorcentajeOrganizador = Pre.PorcentajeOrganizador,
                            TotalOrganizador = Pre.ValorOrganizador

                        };



            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.TipoEvento = item.TipoEvento;

                cat.ImporteOrganizador = item.ImporteOrganizador;
                cat.PorcentajeOrganizador = item.PorcentajeOrganizador;
                cat.TotalOrganizador = item.TotalOrganizador;

                Salida.Add(cat);
            }



            return Salida.Distinct().OrderBy(o => o.PresupuestoEstadoId).ToList();

        }

        public List<ObtenerEventosPresupuestos> ObtenerEventosPresupuestosPorPresupuesto(int PresupuestoId)
        {

            var query = from Ev in SqlContext.Eventos
                        //join Cl in ListClientes on Ev.ClienteId equals Cl.Id
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join TEv in SqlContext.TipoEventos on Pre.TipoEventoId equals TEv.Id
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        where Pre.Id == PresupuestoId
                        select new
                        {
                            ApellidoNombre = Ev.ApellidoNombreCliente,//Cl.ApellidoNombre,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,//Cl.Id,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Ev.RazonSocial,//Cl.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0,
                            TipoEvento = TEv.Descripcion,
                            ImporteOrganizador = Pre.ImporteOrganizador,
                            PorcentajeOrganizador = Pre.PorcentajeOrganizador,
                            TotalOrganizador = Pre.ValorOrganizador

                        };



            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.TipoEvento = item.TipoEvento;

                cat.ImporteOrganizador = item.ImporteOrganizador;
                cat.PorcentajeOrganizador = item.PorcentajeOrganizador;
                cat.TotalOrganizador = item.TotalOrganizador;

                Salida.Add(cat);
            }



            return Salida.Distinct().OrderBy(o => o.PresupuestoEstadoId).ToList();

        }

        public List<ObtenerEventosPresupuestos> ObtenerEventosPresupuestos()
        {

            var query = from Ev in SqlContext.Eventos
                        //join Cl in ListClientes on Ev.ClienteId equals Cl.Id
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join TEv in SqlContext.TipoEventos on Pre.TipoEventoId equals TEv.Id
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        select new
                        {
                            ApellidoNombre = Ev.ApellidoNombreCliente,//Cl.ApellidoNombre,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,//Cl.Id,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Ev.RazonSocial,//Cl.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0,
                            TipoEvento = TEv.Descripcion,
                            ImporteOrganizador = Pre.ImporteOrganizador,
                            PorcentajeOrganizador = Pre.PorcentajeOrganizador,
                            TotalOrganizador = Pre.ValorOrganizador

                        };



            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.TipoEvento = item.TipoEvento;

                cat.ImporteOrganizador = item.ImporteOrganizador;
                cat.PorcentajeOrganizador = item.PorcentajeOrganizador;
                cat.TotalOrganizador = item.TotalOrganizador;

                Salida.Add(cat);
            }

            return Salida.Distinct().OrderBy(o => o.PresupuestoEstadoId).ToList();

        }

        public double CalcularRentaNominal(double precio, double costo)
        {
            if (precio > 0 && costo > 0)
            {
                double rentabilidad = precio - costo;

                return System.Math.Round(rentabilidad, 2);
            }
            else
                return 0;
        }

        public double CalcularRentabilidad(double precio, double costo)
        {
            if (precio > 0 && costo > 0)
            {
                //double rentabilidad = (((precio - costo) / precio) * 100);

                double rentabilidad = (((precio) / costo) * 100);

                return System.Math.Round(rentabilidad, 2);
            }
            else
                return 0;
        }

        public double CalcularCostoTotalPresupuesto(int presupuestoId)
        {
            if (presupuestoId > 0)
            {
                PresupuestosDatos presu = new PresupuestosDatos();

                return presu.CalcularCostoTotalPresupuestoPorPresupuestoId(presupuestoId);


            }
            else
            { return 0; }
        }

        public double CalcularPrecioTotalPresupuesto(int presupuestoId)
        {
            if (presupuestoId > 0)
            {
                PresupuestosDatos presu = new PresupuestosDatos();

                return presu.CalcularValorTotalPresupuestoPorPresupuestoId(presupuestoId);


            }
            else
            { return 0; }
        }

        public List<ObtenerEventosSeguimiento> BuscarEventosActivosPorEjecutivoProximosAVencer(int EmpleadoId)
        {

            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());

            var queryEjecutivo = from e in SqlContext.ObtenerEventosSeguimiento
                                 where e.EmpleadoId == EmpleadoId
                                     //&& e.FechaEvento <= System.DateTime.Today 
                                         && e.EstadoId == estadoEnviado
                                 select e;

            return queryEjecutivo.ToList();


        }

        public List<SeguimientosEventosClientesEstados> BuscarPrespuestosPorEvnetos(long EventoId)
        {
            return SqlContext.SeguimientosEventosClientesEstados.Where(o => o.EventoId == EventoId).ToList();
        }

        public ObtenerEventos BuscarEventoPorNroEvento(int id)
        {
            return SqlContext.ObtenerEventos.Where(o => o.EventoId == id).First();
        }

        public ObtenerEventos BuscarEventoPorNroPresupuesto(int id)
        {
            return SqlContext.ObtenerEventos.Where(o => o.PresupuestoId == id).First();
        }

        public List<ObtenerEventos> BuscarEventosActivosPorEjecutivoSeguimiento(int EmpleadoId, int nroCliente, int nroEvento, string apellidoCliente, int nroPresupuesto)
        {

            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            int estadoPresupuestoEnviadoalCliente = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());

            int estadoPresupuestoVencido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoVencido"].ToString());


            SeguridadDatos DatosSeguridad = new SeguridadDatos();

            if (DatosSeguridad.EsUsuarioGerencia(EmpleadoId))
            {
                var queryGerencia = from e in SqlContext.ObtenerEventos
                                    where e.EstadoId == estadoEnviado
                                            && (e.PresupuestoEstadoId == estadoPresupuestoEnviadoalCliente || e.PresupuestoEstadoId == estadoPresupuestoVencido)
                                    select e;

                if (nroCliente > 0)
                    queryGerencia = queryGerencia.Where(t => t.ClienteId == nroCliente);

                if (nroPresupuesto > 0)
                    queryGerencia = queryGerencia.Where(t => t.PresupuestoId == nroPresupuesto); //(SqlContext.Presupuestos.Where(o => o.Id == nroPresupuesto).FirstOrDefault().EventoId));

                if (nroEvento > 0)
                    queryGerencia = queryGerencia.Where(t => t.EventoId == nroEvento);

                if (!string.IsNullOrEmpty(apellidoCliente))
                    queryGerencia = queryGerencia.Where(t => t.ApellidoNombre.Contains(apellidoCliente));

                return queryGerencia.ToList();

            }
            else
            {
                var queryEjecutivo = from e in SqlContext.ObtenerEventos
                                     where e.EmpleadoId == EmpleadoId && e.EstadoId == estadoEnviado
                                           && (e.PresupuestoEstadoId == estadoPresupuestoEnviadoalCliente || e.PresupuestoEstadoId == estadoPresupuestoVencido)
                                     select e;
                if (nroCliente > 0)
                    queryEjecutivo = queryEjecutivo.Where(t => t.ClienteId == nroCliente);

                if (nroEvento > 0)
                    queryEjecutivo = queryEjecutivo.Where(t => t.EventoId == nroEvento);

                if (!string.IsNullOrEmpty(apellidoCliente))
                    queryEjecutivo = queryEjecutivo.Where(t => t.ApellidoNombre.Contains(apellidoCliente));

                return queryEjecutivo.ToList();

            }

        }

        public List<ObtenerEventos> ObtenerEventos(int estado)
        {
            return SqlContext.ObtenerEventos.Where(o => o.EstadoId == estado).ToList();
        }

        public List<EventosConfirmadosReservadosTODOS> EventosTodos()
        {
            return SqlContext.EventosConfirmadosReservadosTODOS.ToList();
        }

        public void GrabarSeguimiento(int PresupuestoId, ClientesEventosMovimientos movimientosClientes, int estadoModificado)
        {
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());
            int estadoPresupuestoRechazado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoRechazado"].ToString());

            int estadoEventoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int estadoEventoPerdido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());
            int estadoEventoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());


            Presupuestos presuEdit = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();

            presuEdit.EstadoId = estadoModificado;


            Eventos eventoEdit = SqlContext.Eventos.Where(o => o.Id == movimientosClientes.EventoId).FirstOrDefault();

            if (estadoModificado == estadoPresupuestoAprobado)
            {
                eventoEdit.EstadoId = estadoEventoCerrado;

            }

            else
            {
                eventoEdit.EstadoId = estadoEventoEnviado;
            }

            SqlContext.ClientesEventosMovimientos.Add(movimientosClientes);
            SqlContext.SaveChanges();
        }

        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int empleadoId)
        {
            return SqlContext.ReporteEventosPorUnidadesdeNegocios.OrderBy(o => o.NroCliente).OrderBy(o => o.NroEvento).OrderBy(o => o.NroPresupuesto).ToList();
        }

        private List<ReporteExcelDiario> ListarEventos()
        {

            var query = from e in SqlContext.Eventos
                        join p in SqlContext.Presupuestos on e.Id equals p.EventoId
                        join pd in SqlContext.PresupuestoDetalle on p.Id equals pd.Id
                        join pr in SqlContext.Productos on pd.ProductoId equals pr.Id
                        join c in SqlContext.Caracteristicas on p.CaracteristicaId equals c.Id
                        join s in SqlContext.Segmentos on p.SegmentoId equals s.Id
                        join l in SqlContext.Locaciones on p.LocacionId equals l.Id
                        join j in SqlContext.Jornadas on p.JornadaId equals j.Id
                        join se in SqlContext.Sectores on p.SectorId equals se.Id into ses
                        from se in ses.DefaultIfEmpty()
                        join ee in SqlContext.Estados on e.EstadoId equals ee.Id
                        join ep in SqlContext.Estados on p.EstadoId equals ep.Id
                        join emp in SqlContext.Empleados on e.EmpleadoId equals emp.Id
                        join tc in SqlContext.TipoCatering on pr.TipoCateringId equals tc.Id into tcs
                        from tc in tcs.DefaultIfEmpty()
                        join tb in SqlContext.TiposBarras on pr.TipoBarraId equals tb.Id into tbs
                        from tb in tbs.DefaultIfEmpty()
                        join tt in SqlContext.TipoServicios on pr.TipoServicioId equals tt.Id into tts
                        from tt in tts.DefaultIfEmpty()
                        select new
                        {
                            NroCliente = 1,
                            ApellidoNombre = "",
                            RazonSocial = "",

                            NroEvento = e.Id,
                            Caracteristica = c.Descripcion,
                            Segmento = s.Descripcion,
                            Locacion = l.Descripcion,
                            Sector = se.Descripcion,


                            Jornada = j.Descripcion,
                            HorarioEvento = p.HorarioEvento,
                            CantidadInicialInvitados = p.CantidadInicialInvitados,
                            CantidadInvitadosAdolecentes = p.CantidadInvitadosAdolecentes,
                            CantidadInvitadosMenores3y8 = p.CantidadInvitadosMenores3y8,
                            CantidadInvitadosMenores3 = p.CantidadInvitadosMenores3,

                            FechaEvento = p.FechaEvento,
                            Estado = ee.Descripcion,
                            Ejecutivo = emp.ApellidoNombre,
                            NroPresupuesto = p.Id,
                            FechaEnvioPresupuesto = p.FechaPresupuesto,
                            EstadoPresupuesto = ep.Descripcion,

                            TotalSalon = 0,
                            ValorVendidoSalon = "",
                            DescuentoSalon = 0,

                            TotalCatering = 0,
                            CostoCanonCatering = 0,
                            CostoLogisticaCatering = 0,
                            ValorVendidoCatering = "",
                            DescuentoCatering = 0,
                            TipoCatering = tc.Descripcion,

                            TotalTecnica = 0,
                            ValorVendidoTecnica = "",
                            TipoTecnica = tt.Descripcion,
                            DescuentoTecnica = 0,

                            TotalBarra = 0,
                            ValorVendidoBarra = "",
                            TipoBarra = tb.Descripcion,
                            CostoCanonBarras = 0,
                            CostoLogisticaBarra = 0,
                            DescuentoBarra = 0,

                            TotalAmbientacion = 0,
                            ValorVendidoAmbientacion = "",
                            DescuentoAmbientacion = 0,

                            TotalAdicionales = 0,
                            FechaAprobacion = DateTime.Parse(""),

                            PrecioTotal = 0,
                            PrecioPorPersona = 0
                        };

            List<ReporteExcelDiario> Salida = new List<ReporteExcelDiario>();
            foreach (var item in query)
            {

                ReporteExcelDiario cat = new ReporteExcelDiario();

                cat.NroCliente = item.NroCliente;
                cat.ApellidoNombre = item.ApellidoNombre;
                cat.RazonSocial = item.RazonSocial;

                cat.NroEvento = item.NroEvento;
                cat.Caracteristica = item.Caracteristica;
                cat.Segmento = item.Segmento;
                cat.Locacion = item.Locacion;
                cat.Sector = item.Sector;

                cat.Jornada = item.Jornada;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = Int32.Parse(item.CantidadInicialInvitados.ToString());
                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;

                cat.FechaEvento = DateTime.Parse(item.FechaEvento.ToString());
                cat.Estado = item.Estado;
                cat.Ejecutivo = item.Ejecutivo;
                cat.NroPresupuesto = item.NroPresupuesto;
                cat.FechaEnvioPresupuesto = item.FechaEnvioPresupuesto;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.TotalSalon = item.TotalSalon;
                cat.ValorVendidoSalon = item.ValorVendidoSalon;
                cat.DescuentoSalon = item.DescuentoSalon;


                cat.TotalCatering = item.TotalCatering;
                cat.CostoCanonCatering = item.CostoCanonCatering;
                cat.CostoLogisticaCatering = item.CostoLogisticaCatering;
                cat.ValorVendidoCatering = item.ValorVendidoCatering;
                cat.DescuentoCatering = item.DescuentoCatering;
                cat.TipoCatering = item.TipoCatering;

                cat.TotalTecnica = item.TotalTecnica;
                cat.ValorVendidoTecnica = item.ValorVendidoTecnica;
                cat.TipoTecnica = item.TipoTecnica;
                cat.DescuentoTecnica = item.DescuentoTecnica;

                cat.TotalBarra = item.TotalBarra;
                cat.ValorVendidoBarra = item.ValorVendidoBarra;
                cat.TipoBarra = item.TipoBarra;
                cat.CostoCanonBarras = item.CostoCanonBarras;
                cat.CostoLogisticaBarra = item.CostoLogisticaBarra;
                cat.DescuentoBarra = item.DescuentoBarra;

                cat.TotalAmbientacion = item.TotalAmbientacion;
                cat.ValorVendidoAmbientacion = item.ValorVendidoAmbientacion;
                cat.DescuentoAmbientacion = item.DescuentoAmbientacion;

                cat.TotalAdicionales = item.TotalAdicionales;
                cat.FechaAprobacion = item.FechaAprobacion;

                cat.PrecioTotal = item.PrecioTotal;
                cat.PrecioPorPersona = item.PrecioPorPersona;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public List<ReporteEventosPorUnidadesdeNegocios> ObtenerReporteEventosPorUnidadesNegocios(int nroEvento, int nroPresupuesto, string fechaDesde, string fechaHasta)
        {

            List<ReporteEventosPorUnidadesdeNegocios> Salida = (from Rg in SqlContext.ReporteEventosPorUnidadesdeNegocios select Rg).ToList();

            DateTime fecDesde;
            DateTime fecHasta;

            if (fechaDesde != "")
            {
                fecDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Salida = Salida.Where(o => o.FechaEvento >= fecDesde).ToList();

            }
            if (fechaHasta != "")
            {
                fecHasta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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

            return Salida.OrderBy(o => o.NroCliente).OrderBy(o => o.NroEvento).OrderBy(o => o.NroPresupuesto).ToList();

        }

        public List<Entidades.ObtenerEventos> BuscarEventosConfirmadosReservadosPorFechaVista(DateTime dateTime)
        {

            int estadoEventoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoEventoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoPresupuestoVencido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoVencido"].ToString());
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            return SqlContext.ObtenerEventos.Where(o => o.FechaEvento == dateTime && o.PresupuestoEstadoId == estadoPresupuestoAprobado && (o.EstadoId == estadoEventoReservado || o.EstadoId == estadoEventoConfirmado)).ToList();
        }

        public List<Entidades.ObtenerEventos> BuscarEventosConfirmadosReservadosSolamente(int nroCliente, int nroPresupuesto, int nroEvento, string apellidoCliente)
        {
            int estadoEventoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoEventoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoPresupuestoAprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            var queryGerencia = from E in SqlContext.ObtenerEventos
                                where (E.EstadoId == estadoEventoReservado
                                        || E.EstadoId == estadoEventoConfirmado)
                                       && E.PresupuestoEstadoId == estadoPresupuestoAprobado
                                       && E.FechaEvento >= System.DateTime.Today
                                select E;

            if (nroCliente > 0)
                queryGerencia = queryGerencia.Where(t => t.ClienteId == nroCliente);

            if (nroPresupuesto > 0)
                queryGerencia = queryGerencia.Where(t => t.PresupuestoId == nroPresupuesto);

            if (nroEvento > 0)
                queryGerencia = queryGerencia.Where(t => t.EventoId == nroEvento);

            if (!string.IsNullOrEmpty(apellidoCliente))
                queryGerencia = queryGerencia.Where(t => t.ApellidoNombre.Contains(apellidoCliente));

            return queryGerencia.ToList();

        }

        public List<ObtenerCantidadInvitadosCatering> TraerCantidadPersonasCateringAdicionales()
        {
            return SqlContext.ObtenerCantidadInvitadosCatering.OrderBy(o => o.CantidadPersonas).ToList();
        }

        public List<PresupuestosAVencer> BuscarPresupuestosAvencerPorEjecutivo(int EmpleadoId)
        {
            return SqlContext.PresupuestosAVencer.Where(o => o.EmpleadoId == EmpleadoId).ToList();
        }

        public List<Entidades.ObtenerEventos> BuscarEventosASeguirPorEjecutivo(int EmpleadoId)
        {
            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            int estadoPresupuestoEnviadoalCliente = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoEnviadoalCliente"].ToString());

            var queryEjecutivo = from e in SqlContext.ObtenerEventos
                                 where e.EmpleadoId == EmpleadoId
                                        && e.PresupuestoEstadoId == estadoPresupuestoEnviadoalCliente
                                        && e.EstadoId == estadoEnviado
                                 select e;

            return queryEjecutivo.ToList();
        }

        public List<Entidades.ObtenerEventos> BuscarEventosPerdidosPorEjecutivo(int EmpleadoId, int nroEvento, int nroPresupuesto, int nroCliente)
        {
            int estadoPerdido = Int32.Parse(ConfigurationManager.AppSettings["EstadoPerdido"].ToString());



            SeguridadDatos DatosSeguridad = new SeguridadDatos();


            if (DatosSeguridad.EsUsuarioGerencia(EmpleadoId))
            {
                var queryGerencia = from e in SqlContext.ObtenerEventos
                                    where (e.EstadoId == estadoPerdido)
                                    select e;

                queryGerencia = FiltrosQueryInicio(nroEvento, nroPresupuesto, nroCliente, queryGerencia);

                return queryGerencia.OrderBy(o => o.FechaEvento).Distinct().ToList();
            }
            else
            {
                var queryEjecutivo = from e in SqlContext.ObtenerEventos
                                     where e.EmpleadoId == EmpleadoId
                                     where (e.EstadoId == estadoPerdido)
                                     select e;

                queryEjecutivo = FiltrosQueryInicio(nroEvento, nroPresupuesto, nroCliente, queryEjecutivo);

                return queryEjecutivo.OrderBy(o => o.FechaEvento).Distinct().ToList();
            }
        }

        public TecnicaSalon BuscarTecnicaPorLocacion(int LocacionId, int SectorId)
        {
            return SqlContext.TecnicaSalon.Where(o => o.LocacionId == LocacionId && o.SectorId == SectorId).FirstOrDefault();
        }

        public Eventos BuscarEvento(int EventoId)
        {
            return SqlContext.Eventos.Where(o => o.Id == EventoId).FirstOrDefault();
        }

        private void GrabarSeguimientoEventos(Eventos EventoSeleccionado)
        {
            ClientesEventosMovimientos mov = new ClientesEventosMovimientos();

            mov.ClienteId = EventoSeleccionado.ClienteId;
            mov.EventoId = EventoSeleccionado.Id;
            mov.EmpleadoId = EventoSeleccionado.EmpleadoId;
            mov.FechaSeguimiento = System.DateTime.Now;
            mov.EstadoId = EventoSeleccionado.EstadoId;
            mov.Comentario = EventoSeleccionado.Comentario;

            SqlContext.ClientesEventosMovimientos.Add(mov);
        }

        public double BuscarFacturacionPorEmpleadosPorMes(int empleadoId)
        {


            return 0;
        }

        public Entidades.ObtenerEventosPresupuestos BuscarPresupuestoParaAprobar(int PresupuestoId)
        {
            return ObtenerEventosPresupuestosPorPresupuesto(PresupuestoId).SingleOrDefault();
        }

        public AmbientacionSalon BuscarAmbientacionPorLocacion(int LocacionId, int SectorId)
        {
            return SqlContext.AmbientacionSalon.Where(o => o.LocacionId == LocacionId && o.SectorId == SectorId).SingleOrDefault();
        }

        public List<ObtenerEventosPresupuestosProveedores> BuscarEventosConfirmadosProveedoresExternos(int nropresupuesto, string fechaDesde, string fechaHasta, int unidadNegocioId)
        {

            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int estadoPresupuestoAprobado =
                Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());
            int aprobadoItem = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString()); ;

            var query = from e in SqlContext.Eventos
                        join c in SqlContext.ClientesBis on e.ClienteBisId equals c.Id
                        join p in SqlContext.Presupuestos on e.Id equals p.EventoId
                        join pd in SqlContext.PresupuestoDetalle on p.Id equals pd.PresupuestoId
                        join es in SqlContext.Estados on e.EstadoId equals es.Id
                        join em in SqlContext.Empleados on e.EmpleadoId equals em.Id
                        join l in SqlContext.Locaciones on p.LocacionId equals l.Id
                        join pr in SqlContext.Productos on pd.ProductoId equals pr.Id
                        join ca in SqlContext.Caracteristicas on p.CaracteristicaId equals ca.Id
                        join tc in SqlContext.TipoCatering on pr.TipoCateringId equals tc.Id into tcs
                        from tc in tcs.DefaultIfEmpty()
                        join prc in SqlContext.Proveedores on pr.ProveedorId equals prc.Id into prcs
                        from prc in prcs.DefaultIfEmpty()
                        join tt in SqlContext.TipoServicios on pr.TipoServicioId equals tt.Id into tts
                        from tt in tts.DefaultIfEmpty()
                        join prt in SqlContext.Proveedores on pr.ProveedorId equals prt.Id into prts
                        from prt in prts.DefaultIfEmpty()
                        join tb in SqlContext.TiposBarras on pr.TipoBarraId equals tb.Id into tbs
                        from tb in tbs.DefaultIfEmpty()
                        join prb in SqlContext.Proveedores on pr.ProveedorId equals prb.Id into prbs
                        from prb in prbs.DefaultIfEmpty()
                        join ta in SqlContext.Categorias on pr.CategoriaId equals ta.Id into tas
                        from ta in tas.DefaultIfEmpty()
                        join pra in SqlContext.Proveedores on pr.ProveedorId equals pra.Id into pras
                        from pra in pras.DefaultIfEmpty()
                        join a in SqlContext.Adicionales on pr.AdicionalId equals a.Id into aas
                        from a in aas.DefaultIfEmpty()

                        where p.EstadoId == estadoPresupuestoAprobado
                              && (e.EstadoId == estadoConfirmado || e.EstadoId == estadoReservado ||
                                  e.EstadoId == estadoCerrado) && pd.EstadoId == aprobadoItem

                        select new
                        {
                            PresupuestoId = p.Id,
                            UnidadNegocioId = pd.UnidadNegocioId,
                            Ejecutivo = em.ApellidoNombre,
                            FechaEvento = p.FechaEvento,
                            FechaReserva = e.FechaSena,
                            RazonSocialCliente = (c.RazonSocial == "" ? (c.ApellidoNombre == "" ? "" : c.ApellidoNombre) : c.RazonSocial),
                            Locacion = l.Descripcion,
                            CantidadInvitados = (p.CantidadInicialInvitados == null ? 0 : p.CantidadInicialInvitados),
                            CantidadInvitadosAdolescentes = (p.CantidadInvitadosAdolecentes == null ? 0 : p.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3 = (p.CantidadInvitadosMenores3 == null ? 0 : p.CantidadInvitadosMenores3),
                            CantidadInvitadosEntre3y8 = (p.CantidadInvitadosMenores3y8 == null ? 0 : p.CantidadInvitadosMenores3y8),
                            CantidadTotal = 0,
                            TipoCatering = tc.Descripcion,
                            RazonSocialCatering = (tc.Descripcion == null ? "" : prc.RazonSocial),
                            TipoTecnica = tt.Descripcion,
                            RazonSocialTecnica = (tt.Descripcion == null ? "" : prt.RazonSocial),
                            TipoBarra = tb.Descripcion,
                            RazonSocialBarra = (tb.Descripcion == null ? "" : prb.RazonSocial),
                            TipoAmbientacion = ta.Descripcion,
                            RazonSocialAmbientacion = (ta.Descripcion == null ? "" : pra.RazonSocial),
                            Comentario = p.Comentario,
                            Adicional = a.Descripcion,
                            CantidadAdicional = pd.CantidadAdicional,
                            Caracteristica = ca.Descripcion,
                            EstadoDescripcion = es.Descripcion,
                            HorarioEvento = p.HorarioEvento,
                            HoraFinalizado = p.HoraFinalizado
                        };

            DateTime fecDesde;
            DateTime fecHasta;

            if (nropresupuesto > 0)
            { query = query.Where(o => o.PresupuestoId == nropresupuesto); }

            if (fechaDesde != "")
            {
                fecDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                query = query.Where(o => o.FechaEvento >= fecDesde);

            }
            if (fechaHasta != "")
            {
                fecHasta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                query = query.Where(o => o.FechaEvento <= fecHasta);
            }


            if (unidadNegocioId > 0)
            { query = query.Where(o => o.UnidadNegocioId == unidadNegocioId); }

            List<ObtenerEventosPresupuestosProveedores> Salida = new List<ObtenerEventosPresupuestosProveedores>();

            foreach (var item in query)
            {
                ObtenerEventosPresupuestosProveedores cat = new ObtenerEventosPresupuestosProveedores();

                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.Ejecutivo = item.Ejecutivo;
                cat.FechaEvento = item.FechaEvento;
                cat.FechaReserva = item.FechaReserva;
                cat.RazonSocialCliente = item.RazonSocialCliente;
                cat.Locacion = item.Locacion;

                cat.CantidadInvitados = (int)item.CantidadInvitados;
                cat.CantidadInvitadosAdolescentes = (int)item.CantidadInvitadosAdolescentes;
                cat.CantidadInvitadosMenores3 = (int)item.CantidadInvitadosMenores3;
                cat.CantidadInvitadosEntre3y8 = (int)item.CantidadInvitadosEntre3y8;
                cat.CantidadTotal = (cat.CantidadInvitados + cat.CantidadInvitadosAdolescentes + cat.CantidadInvitadosEntre3y8 + cat.CantidadInvitadosMenores3);

                cat.TipoCatering = item.TipoCatering;
                cat.RazonSocialCatering = item.RazonSocialCatering;
                cat.TipoTecnica = item.TipoTecnica;
                cat.RazonSocialTecnica = item.RazonSocialTecnica;
                cat.TipoBarra = item.TipoBarra;
                cat.RazonSocialBarra = item.RazonSocialBarra;
                cat.TipoAmbientacion = item.TipoAmbientacion;
                cat.RazonSocialAmbientacion = item.RazonSocialAmbientacion;

                cat.Comentario = item.Comentario;
                cat.Adicional = item.Adicional;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Caracteristica = item.Caracteristica;
                cat.EstadoDescripcion = item.EstadoDescripcion;

                cat.HorarioEvento = item.HorarioEvento;
                cat.HoraFinalizado = item.HoraFinalizado;

                Salida.Add(cat);
            }

            return Salida.Distinct().OrderBy(o => o.PresupuestoId).OrderBy(o => o.FechaEvento).ToList();
        }

        public List<ObtenerEventosPresupuestosProveedores> BuscarProveedoresEstadosEventosConfirmados(int nropresupuesto, string fechaDesde, string fechaHasta, int unidadNegocioId, string estadoProveedor, int proveedorId)
        {

            int estadoConfirmado = Int32.Parse(ConfigurationManager.AppSettings["EstadoConfirmado"].ToString());
            int estadoReservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int estadoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int estadoPresupuestoAprobado =
                Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());
            int aprobadoItem = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString()); ;

            var query = from e in SqlContext.Eventos
                        join c in SqlContext.ClientesBis on e.ClienteBisId equals c.Id
                        join p in SqlContext.Presupuestos on e.Id equals p.EventoId
                        join pd in SqlContext.PresupuestoDetalle on p.Id equals pd.PresupuestoId
                        join es in SqlContext.Estados on e.EstadoId equals es.Id
                        join em in SqlContext.Empleados on e.EmpleadoId equals em.Id
                        join l in SqlContext.Locaciones on p.LocacionId equals l.Id
                        join pr in SqlContext.Productos on pd.ProductoId equals pr.Id
                        join ca in SqlContext.Caracteristicas on p.CaracteristicaId equals ca.Id
                        join tc in SqlContext.TipoCatering on pr.TipoCateringId equals tc.Id into tcs
                        from tc in tcs.DefaultIfEmpty()
                        join prc in SqlContext.Proveedores on pr.ProveedorId equals prc.Id into prcs
                        from prc in prcs.DefaultIfEmpty()
                        join tt in SqlContext.TipoServicios on pr.TipoServicioId equals tt.Id into tts
                        from tt in tts.DefaultIfEmpty()
                        join prt in SqlContext.Proveedores on pr.ProveedorId equals prt.Id into prts
                        from prt in prts.DefaultIfEmpty()
                        join tb in SqlContext.TiposBarras on pr.TipoBarraId equals tb.Id into tbs
                        from tb in tbs.DefaultIfEmpty()
                        join prb in SqlContext.Proveedores on pr.ProveedorId equals prb.Id into prbs
                        from prb in prbs.DefaultIfEmpty()
                        join ta in SqlContext.Categorias on pr.CategoriaId equals ta.Id into tas
                        from ta in tas.DefaultIfEmpty()
                        join pra in SqlContext.Proveedores on pr.ProveedorId equals pra.Id into pras
                        from pra in pras.DefaultIfEmpty()
                        join a in SqlContext.Adicionales on pr.AdicionalId equals a.Id into aas
                        from a in aas.DefaultIfEmpty()

                        where p.EstadoId == estadoPresupuestoAprobado
                              && (e.EstadoId == estadoConfirmado || e.EstadoId == estadoReservado ||
                                  e.EstadoId == estadoCerrado) && pd.EstadoId == aprobadoItem

                        select new
                        {
                            PresupuestoId = p.Id,
                            UnidadNegocioId = pd.UnidadNegocioId,
                            UnidadNegocioDescripcion = "",
                            Ejecutivo = em.ApellidoNombre,
                            FechaEvento = p.FechaEvento,
                            FechaReserva = e.FechaSena,
                            RazonSocialCliente = (c.RazonSocial == "" ? (c.ApellidoNombre == "" ? "" : c.ApellidoNombre) : c.RazonSocial),
                            Locacion = l.Descripcion,
                            CantidadInvitados = (p.CantidadInicialInvitados == null ? 0 : p.CantidadInicialInvitados),
                            CantidadInvitadosAdolescentes = (p.CantidadInvitadosAdolecentes == null ? 0 : p.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3 = (p.CantidadInvitadosMenores3 == null ? 0 : p.CantidadInvitadosMenores3),
                            CantidadInvitadosEntre3y8 = (p.CantidadInvitadosMenores3y8 == null ? 0 : p.CantidadInvitadosMenores3y8),
                            CantidadTotal = 0,
                            TipoCatering = tc.Descripcion,
                            RazonSocialCatering = (tc.Descripcion == null ? "" : prc.RazonSocial),
                            TipoTecnica = tt.Descripcion,
                            RazonSocialTecnica = (tt.Descripcion == null ? "" : prt.RazonSocial),
                            TipoBarra = tb.Descripcion,
                            RazonSocialBarra = (tb.Descripcion == null ? "" : prb.RazonSocial),
                            TipoAmbientacion = ta.Descripcion,
                            RazonSocialAmbientacion = (ta.Descripcion == null ? "" : pra.RazonSocial),
                            Comentario = p.Comentario,
                            Adicional = a.Descripcion,
                            CantidadAdicional = pd.CantidadAdicional,
                            Caracteristica = ca.Descripcion,
                            EstadoDescripcion = es.Descripcion,
                            HorarioEvento = p.HorarioEvento,
                            HoraFinalizado = p.HoraFinalizado,
                            EstadoProveedor = pd.EstadoProveedor,
                            ComentarioProveedor = pd.ComentarioProveedor,
                            ProductoDescripcion = pr.Descripcion,
                            ProveedorId = pd.ProveedorId,
                            Costo = pd.Costo,
                            ValorSeleccionado = pd.ValorSeleccionado
                        };

            DateTime fecDesde;
            DateTime fecHasta;

            if (nropresupuesto > 0)
            { query = query.Where(o => o.PresupuestoId == nropresupuesto); }

            if (fechaDesde != "")
            {
                fecDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                query = query.Where(o => o.FechaEvento >= fecDesde);

            }
            if (fechaHasta != "")
            {
                fecHasta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                query = query.Where(o => o.FechaEvento <= fecHasta);
            }


            if (unidadNegocioId > 0)
            { query = query.Where(o => o.UnidadNegocioId == unidadNegocioId); }

            if (proveedorId > 0)
            { query = query.Where(o => o.ProveedorId == proveedorId); }

            if (estadoProveedor != "null")
            {
                if (estadoProveedor == "1")
                    query = query.Where(o => o.EstadoProveedor == true);
                else
                    query = query.Where(o => o.EstadoProveedor == null || o.EstadoProveedor == false);
            }


            List<ObtenerEventosPresupuestosProveedores> Salida = new List<ObtenerEventosPresupuestosProveedores>();

            foreach (var item in query)
            {
                ObtenerEventosPresupuestosProveedores cat = new ObtenerEventosPresupuestosProveedores();

                cat.PresupuestoId = item.PresupuestoId;
                cat.UnidadNegocioId = item.UnidadNegocioId;
                cat.UnidadNegocioDescripcion = SqlContext.UnidadesNegocios.Where(o => o.Id == item.UnidadNegocioId).FirstOrDefault().Descripcion;
                cat.Ejecutivo = item.Ejecutivo;
                cat.FechaEvento = item.FechaEvento;
                cat.FechaReserva = item.FechaReserva;
                cat.RazonSocialCliente = item.RazonSocialCliente;
                cat.Locacion = item.Locacion;

                cat.CantidadInvitados = (int)item.CantidadInvitados;
                cat.CantidadInvitadosAdolescentes = (int)item.CantidadInvitadosAdolescentes;
                cat.CantidadInvitadosMenores3 = (int)item.CantidadInvitadosMenores3;
                cat.CantidadInvitadosEntre3y8 = (int)item.CantidadInvitadosEntre3y8;
                cat.CantidadTotal = (cat.CantidadInvitados + cat.CantidadInvitadosAdolescentes + cat.CantidadInvitadosEntre3y8 + cat.CantidadInvitadosMenores3);

                cat.TipoCatering = item.TipoCatering;
                cat.RazonSocialCatering = item.RazonSocialCatering;
                cat.TipoTecnica = item.TipoTecnica;
                cat.RazonSocialTecnica = item.RazonSocialTecnica;
                cat.TipoBarra = item.TipoBarra;
                cat.RazonSocialBarra = item.RazonSocialBarra;
                cat.TipoAmbientacion = item.TipoAmbientacion;
                cat.RazonSocialAmbientacion = item.RazonSocialAmbientacion;

                cat.Comentario = item.Comentario;
                cat.Adicional = item.Adicional;
                cat.CantidadAdicional = item.CantidadAdicional;
                cat.Caracteristica = item.Caracteristica;
                cat.EstadoDescripcion = item.EstadoDescripcion;

                cat.HorarioEvento = item.HorarioEvento;
                cat.HoraFinalizado = item.HoraFinalizado;

                cat.EstadoProveedor = item.EstadoProveedor;
                cat.ComentarioProveedor = item.ComentarioProveedor;
                cat.ProductoDescripcion = item.ProductoDescripcion;
                cat.ProveedorId = item.ProveedorId;

                cat.Costo = item.Costo != null ? (double)item.Costo : 0;
                cat.Precio = item.ValorSeleccionado;

                Salida.Add(cat);
            }



            return Salida.Distinct().OrderBy(o => o.PresupuestoId).OrderBy(o => o.FechaEvento).ToList();
        }

        public OrganizacionPresupuestoDetalle BuscarOrganizacionDetalle(int id)
        {
            return SqlContext.OrganizacionPresupuestoDetalle.Where(o => o.Id == id).SingleOrDefault();

        }

        public OrganizacionPresupuestoDetalle BuscarOrganizacionDetallePorPresupuesto(int PresupuestoId)
        {
            return SqlContext.OrganizacionPresupuestoDetalle.Where(o => o.PresupuestoId == PresupuestoId).SingleOrDefault();

        }

        public void GrabarOrganizacionPresupuestoDetalle(OrganizacionPresupuestoDetalle detalle)
        {
            try
            {

                if (detalle.Id > 0)
                {
                    OrganizacionPresupuestoDetalle edit = SqlContext.OrganizacionPresupuestoDetalle.Where(o => o.Id == detalle.Id
                                                                                                && o.PresupuestoId == detalle.PresupuestoId).SingleOrDefault();

                    edit.PresupuestoId = detalle.PresupuestoId;

                    edit.MotivoFestejo = detalle.MotivoFestejo;
                    edit.Mail = detalle.Mail;
                    edit.Tel = detalle.Tel;
                    edit.Direccion = detalle.Direccion;
                    edit.LocacionOtra = detalle.LocacionOtra;

                    edit.EnvioMailPresentacion = detalle.EnvioMailPresentacion;
                    edit.FechaMailPresentacion = detalle.FechaMailPresentacion;
                    edit.RealizoReunionConCliente = detalle.RealizoReunionConCliente;

                    edit.Bocados = detalle.Bocados;
                    edit.Islas = detalle.Islas;
                    edit.Entrada = detalle.Entrada;
                    edit.PrincipalAdultos = detalle.PrincipalAdultos;
                    edit.PrincipalAdolescentes = detalle.PrincipalAdolescentes;
                    edit.PostreAdultosAdolescentes = detalle.PostreAdultosAdolescentes;
                    edit.PrincipalChicos = detalle.PrincipalChicos;
                    edit.PostreChicos = detalle.PostreChicos;
                    edit.MesaDulce = detalle.MesaDulce;
                    edit.FinFiesta = detalle.FinFiesta;

                    edit.ServiciodeVinoChampagne = detalle.ServiciodeVinoChampagne;
                    edit.ObservacionBarras = detalle.ObservacionBarras;

                    edit.MesaPrincipal = detalle.MesaPrincipal;
                    edit.Manteleria = detalle.Manteleria;
                    edit.Servilletas = detalle.Servilletas;
                    edit.Sillas = detalle.Sillas;
                    edit.InvitadosDespues00 = detalle.InvitadosDespues00;
                    edit.CumpleaniosEnEvento = detalle.CumpleaniosEnEvento;
                    edit.TortaAlegorica = detalle.TortaAlegorica;
                    edit.LleganAlSalon = detalle.LleganAlSalon;
                    edit.PlatosEspeciales = detalle.PlatosEspeciales;

                    edit.ObservacionAmbientacion = detalle.ObservacionAmbientacion;
                    edit.ObservacionCatering = detalle.ObservacionCatering;
                    edit.ObservacionesAdicionales = detalle.ObservacionesAdicionales;
                    edit.ObservacionParticulares = detalle.ObservacionParticulares;
                    edit.ObservacionTecnica = detalle.ObservacionTecnica;

                    edit.BocadosEstado = detalle.BocadosEstado;
                    edit.IslasEstado = detalle.IslasEstado;
                    edit.EntradaEstado = detalle.EntradaEstado;
                    edit.PrincipalAdultosEstado = detalle.PrincipalAdultosEstado;
                    edit.PrincipalAdolescentesEstado = detalle.PrincipalAdolescentesEstado;
                    edit.PostreAdultosAdolescentesEstado = detalle.PostreAdultosAdolescentesEstado;
                    edit.PrincipalChicosEstado = detalle.PrincipalChicosEstado;
                    edit.PostreChicosEstado = detalle.PostreChicosEstado;
                    edit.MesaDulceEstado = detalle.MesaDulceEstado;
                    edit.FinFiestaEstado = detalle.FinFiestaEstado;
                    edit.ServiciodeVinoChampagneEstado = detalle.ServiciodeVinoChampagneEstado;
                    edit.MesaPrincipalEstado = detalle.MesaPrincipalEstado;
                    edit.ManteleriaEstado = detalle.ManteleriaEstado;
                    edit.ServilletasEstado = detalle.ServilletasEstado;
                    edit.SillasEstado = detalle.SillasEstado;
                    edit.InvitadosDespues00Estado = detalle.InvitadosDespues00Estado;
                    edit.CumpleaniosEnEventoEstado = detalle.CumpleaniosEnEventoEstado;
                    edit.TortaAlegoricaEstado = detalle.TortaAlegoricaEstado;
                    edit.LleganAlSalonEstado = detalle.LleganAlSalonEstado;
                    edit.PlatosEspecialesEstado = detalle.PlatosEspecialesEstado;

                    edit.AlfombraRoja = detalle.AlfombraRoja;
                    edit.AlfombraRojaEstado = detalle.AlfombraRojaEstado;

                    edit.Acreditaciones = detalle.Acreditaciones;
                    edit.AcreditacionesEstado = detalle.AcreditacionesEstado;

                    edit.ListaInvitados = detalle.ListaInvitados;
                    edit.ListaInvitadosEstado = detalle.ListaInvitadosEstado;

                    edit.ListaCocheras = detalle.ListaCocheras;
                    edit.ListaCocherasEstado = detalle.ListaCocherasEstado;

                    edit.Ramo = detalle.Ramo;
                    edit.Escenario = detalle.Escenario;
                    edit.Layout = detalle.Layout;
                    edit.LayoutEstado = detalle.LayoutEstado;


                    edit.IngresoProveedoresLugar = detalle.IngresoProveedoresLugar;
                    edit.ContactoResponsableLugar = detalle.ContactoResponsableLugar;
                    edit.TelefonoResponsableLugar = detalle.TelefonoResponsableLugar;

                    edit.HoraArmadoLogistica = detalle.HoraArmadoLogistica;
                    edit.HoraArmadoSalon = detalle.HoraArmadoSalon;
                    edit.HoraDesarmadoSalon = detalle.HoraDesarmadoSalon;

                    edit.FechaArmadoLogistica = detalle.FechaArmadoLogistica;
                    edit.FechaArmadoSalon = detalle.FechaArmadoSalon;
                    edit.FechaDesarmadoSalon = detalle.FechaDesarmadoSalon;

                    edit.CantPersonasAfectadasArmado = detalle.CantPersonasAfectadasArmado;

                    edit.SePidioHielo = detalle.SePidioHielo;
                    edit.SePidioLogistica = detalle.SePidioLogistica;
                    edit.SePidioManteleria = detalle.SePidioManteleria;
                    edit.SePidioMoviliario = detalle.SePidioMoviliario;
                    edit.ObservacionesHielo = detalle.ObservacionesHielo;
                    edit.ObservacionesLogistica = detalle.ObservacionesLogistica;
                    edit.ObservacionesManteleria = detalle.ObservacionesManteleria;
                    edit.ObservacionesMoviliario = detalle.ObservacionesMoviliario;


                    SqlContext.SaveChanges();

                }
                else
                {
                    SqlContext.OrganizacionPresupuestoDetalle.Add(detalle);
                    SqlContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                DomainAmbientHouse.Servicios.Log.save(this, ex);
            }

        }

        public void GuardarEvento(Eventos EventoSeleccionado)
        {
            if (EventoSeleccionado.Id > 0)
            {
                Eventos editEvento = SqlContext.Eventos.Where(o => o.Id == EventoSeleccionado.Id).FirstOrDefault();

                editEvento.ClienteId = EventoSeleccionado.ClienteId;
                editEvento.EmpleadoId = EventoSeleccionado.EmpleadoId;
                editEvento.Comentario = EventoSeleccionado.Comentario;
                editEvento.EstadoId = EventoSeleccionado.EstadoId;
                editEvento.Fecha = EventoSeleccionado.Fecha;
                editEvento.Indexacion = EventoSeleccionado.Indexacion;
                editEvento.TipoIndexacion = EventoSeleccionado.TipoIndexacion;

                GrabarSeguimientoEventos(EventoSeleccionado);


                SqlContext.SaveChanges();
            }
            else
            {
                SqlContext.Eventos.Add(EventoSeleccionado);

                //DomainAmbientHouse.Servicios.Pipedrive pipe = new Servicios.Pipedrive();

                //pipe.CrearNegocio("Negocio: " + EventoSeleccionado.Id, "340000", "ARS", 2746223, EventoSeleccionado.ClienteId);

                GrabarSeguimientoEventos(EventoSeleccionado);

                SqlContext.SaveChanges();
            }

        }

        public void GrabarSenaEvento(Eventos evento)
        {
            int eventoCerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString()); ;

            if (evento.Id > 0)
            {
                Eventos editEvento = SqlContext.Eventos.Where(o => o.Id == evento.Id).FirstOrDefault();

                editEvento.MontoSena = evento.MontoSena;
                editEvento.FechaSena = evento.FechaSena;
                editEvento.ClienteBisId = evento.ClienteBisId;
                editEvento.PresupuestoAprobadoId = evento.PresupuestoAprobadoId;
                editEvento.EstadoId = eventoCerrado;

                SqlContext.SaveChanges();

                ClientesEventosMovimientos mov = new ClientesEventosMovimientos();

                mov.ClienteId = editEvento.ClienteId;
                mov.Comentario = "Seña Evento";
                mov.EmpleadoId = editEvento.EmpleadoId;
                mov.EventoId = editEvento.Id;
                mov.FechaSeguimiento = System.DateTime.Now;

                SqlContext.ClientesEventosMovimientos.Add(mov);
                SqlContext.SaveChanges();

            }
        }

        public void EditarEvento(Eventos evento)
        {
            if (evento.Id > 0)
            {
                Eventos editEvento = SqlContext.Eventos.Where(o => o.Id == evento.Id).SingleOrDefault();


                editEvento.MontoSena = evento.MontoSena;
                editEvento.FechaSena = evento.FechaSena;
                editEvento.ComprobanteAprovacion = evento.ComprobanteAprovacion;
                editEvento.ComprobanteAprovacionExtension = evento.ComprobanteAprovacionExtension;
                editEvento.NroComprobanteTransSenia = evento.NroComprobanteTransSenia;
                editEvento.FechaComprobanteTransSenia = evento.FechaComprobanteTransSenia;
                editEvento.ComprobanteTransferencia = evento.ComprobanteTransferencia;
                editEvento.ComprobanteTransferenciaExtension = evento.ComprobanteTransferenciaExtension;
                editEvento.EstadoId = evento.EstadoId;
                editEvento.ClienteBisId = evento.ClienteBisId;
                editEvento.FormadePagoId = evento.FormadePagoId;
                editEvento.Comentario = evento.Comentario;
                editEvento.ChequeSenaId = evento.ChequeSenaId;
                editEvento.Indexacion = evento.Indexacion;
                editEvento.TipoIndexacion = evento.TipoIndexacion;

                ClientesEventosMovimientos mov = new ClientesEventosMovimientos();

                mov.ClienteId = evento.ClienteId;
                mov.Comentario = evento.Comentario;
                mov.EstadoId = evento.EstadoId;
                mov.FechaSeguimiento = System.DateTime.Now;
                mov.EmpleadoId = evento.EmpleadoId;


                SqlContext.ClientesEventosMovimientos.Add(mov);

                SqlContext.SaveChanges();
            }
        }

        public void EventoPerdido(int EventoId, int estadoEventoPerdido, string comentario)
        {
            Eventos eventoEdit = SqlContext.Eventos.Where(o => o.Id == EventoId).FirstOrDefault();

            eventoEdit.EstadoId = estadoEventoPerdido;
            eventoEdit.Comentario = comentario;

            ClientesEventosMovimientos mov = new ClientesEventosMovimientos();

            mov.ClienteId = eventoEdit.ClienteId;
            mov.Comentario = comentario;
            mov.EmpleadoId = eventoEdit.EmpleadoId;
            mov.EventoId = eventoEdit.Id;
            mov.FechaSeguimiento = System.DateTime.Now;

            SqlContext.ClientesEventosMovimientos.Add(mov);

            SqlContext.SaveChanges();
        }

        public void CambioEstadoEvento(int eventoId, int estadoId)
        {
            Eventos eventoEdit = SqlContext.Eventos.Where(o => o.Id == eventoId).First();

            eventoEdit.EstadoId = estadoId;

            SqlContext.SaveChanges();

        }

        public void NuevoPresupuesto(Presupuestos presupuesto)
        {
            SqlContext.Presupuestos.Add(presupuesto);
            SqlContext.SaveChanges();
        }

        public void NuevoEvento(Eventos evento)
        {
            SqlContext.Eventos.Add(evento);
            SqlContext.SaveChanges();

            ClientesEventosMovimientos Mov = new ClientesEventosMovimientos();

            Mov.ClienteId = evento.ClienteId;
            Mov.EventoId = evento.Id;
            Mov.FechaSeguimiento = System.DateTime.Now;
            Mov.EstadoId = evento.EstadoId;

            SqlContext.ClientesEventosMovimientos.Add(Mov);

            SqlContext.SaveChanges();
        }


        //public List<ObtenerEventosPresupuestos> BuscarEventos(SearcherEventos searcher)
        //{
        //    SeguridadDatos DatosSeguridad = new SeguridadDatos();

        //    IEnumerable<ObtenerEventosPresupuestos> query;




        //    if (DatosSeguridad.EsUsuarioGerencia(Int32.Parse(searcher.EmpleadoId)))
        //        query = Obtener(nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, fechaEvento);
        //    else
        //        query = Obtener(EmpleadoId, nroEvento, nroPresupuesto, nroCliente, apellidoynombre, razonsocial, fechaEvento);

        //    return query.OrderByDescending(o => o.FechaEvento).Distinct().ToList();

        //}


        internal List<ResponsablesEventos> ListarResponsablesEventos(ResponsablesSearcher searcher)
        {
            var query = from r in SqlContext.ResponsablesEventos
                        select r;

            if (!string.IsNullOrEmpty(searcher.NroPresupuesto))
            {
                int nroPresupuesto = Int32.Parse(searcher.NroPresupuesto);
                query = query.Where(o => o.PresupuestoId == nroPresupuesto);

            }

            if (!string.IsNullOrEmpty(searcher.FechaDesde))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEvento >= fecha);
            }

            if (!string.IsNullOrEmpty(searcher.FechaHasta))
            {
                DateTime fecha = DateTime.ParseExact(searcher.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = query.Where(o => o.FechaEvento <= fecha);
            }

            if (searcher.Organizador != "null")
            {
                if (searcher.Organizador == "SA")
                {
                    query = query.Where(o => o.OrganizadorId == null);
                }
                else
                {
                    int organizador = Int32.Parse(searcher.Organizador);
                    query = query.Where(o => o.OrganizadorId == organizador);
                }
            }

            if (searcher.Coordinador1 != "null")
            {
                if (searcher.Coordinador1 == "SA")
                {
                    query = query.Where(o => o.Coordinador1Id == null);
                }
                else
                {
                    int coordinador1 = Int32.Parse(searcher.Coordinador1);
                    query = query.Where(o => o.Coordinador1Id == coordinador1);
                }
            }

            if (searcher.Coordinador2 != "null")
            {
                if (searcher.Coordinador2 == "SA")
                {
                    query = query.Where(o => o.Coordinador2Id == null);
                }
                else
                {
                    int coordinador2 = Int32.Parse(searcher.Coordinador2);
                    query = query.Where(o => o.Coordinador2Id == coordinador2);
                }
            }

            return query.OrderBy(o => o.FechaEvento).ToList();
        }


        internal List<ListadoProveedoresAsociados_Result> ListarProveedoresAsociados(SearcherReporteProveedoresAsociados searcher)
        {
            DateTime starDate = DateTime.ParseExact(searcher.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime? endDate = null;

            if (!string.IsNullOrWhiteSpace(searcher.FechaHasta))
                endDate = DateTime.ParseExact(searcher.FechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int proveedorId = searcher.ProveedorId;


            var query = from q in SqlContext.ListadoProveedoresAsociados(proveedorId, starDate, endDate)
                        select q;

            if (!string.IsNullOrWhiteSpace(searcher.PresupuestoId))
            {
                int presupuestoId = Int32.Parse(searcher.PresupuestoId);
                query = query.Where(o => o.PresupuestoId == presupuestoId);
            }

            return query.OrderBy(o => o.UnidadNegocioId).OrderBy(o => o.FechaEvento).ToList();
        }


        internal List<Entidades.ObtenerEventosPresupuestos> ListarEventosARevisar()
        {

            SeguridadDatos DatosSeguridad = new SeguridadDatos();

            var query = ObtenerEventosPresupuestosARevisar().ToList();

            var queryGerencia = from e in query
                                select e;


            return queryGerencia.OrderBy(o => o.FechaEvento).Distinct().ToList();
        }

        public List<ObtenerEventosPresupuestos> ObtenerEventosPresupuestosARevisar()
        {
            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());
            int estadoPresupuestoARevisar = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoARevisar"].ToString());

            var query = from Ev in SqlContext.Eventos
                        //join Cl in ListClientes on Ev.ClienteId equals Cl.Id
                        join Pre in SqlContext.Presupuestos on Ev.Id equals Pre.EventoId into Pres
                        from Pre in Pres.DefaultIfEmpty()
                        join Loc in SqlContext.Locaciones on Pre.LocacionId equals Loc.Id into Locs
                        from Loc in Locs.DefaultIfEmpty()
                        join TEv in SqlContext.TipoEventos on Pre.TipoEventoId equals TEv.Id
                        join Car in SqlContext.Caracteristicas on Pre.CaracteristicaId equals Car.Id into Cars
                        from Car in Cars.DefaultIfEmpty()
                        join Sec in SqlContext.Sectores on Pre.SectorId equals Sec.Id into Secs
                        from Sec in Secs.DefaultIfEmpty()
                        join Jor in SqlContext.Jornadas on Pre.JornadaId equals Jor.Id into Jors
                        from Jor in Jors.DefaultIfEmpty()
                        join Dur in SqlContext.DuracionEvento on Pre.DuracionId equals Dur.Id into Durs
                        from Dur in Durs.DefaultIfEmpty()
                        join Mom in SqlContext.MomentosDias on Pre.MomentoDiaID equals Mom.Id into Moms
                        from Mom in Moms.DefaultIfEmpty()
                        join EstEve in SqlContext.Estados on Ev.EstadoId equals EstEve.Id
                        join EstPre in SqlContext.Estados on Pre.EstadoId equals EstPre.Id into EstPres
                        from EstPre in EstPres.DefaultIfEmpty()
                        join Emp in SqlContext.Empleados on Ev.EmpleadoId equals Emp.Id
                        where Ev.EstadoId == estadoEnviado && Pre.EstadoId == estadoPresupuestoARevisar
                        select new
                        {
                            ApellidoNombre = Ev.ApellidoNombreCliente,//Cl.ApellidoNombre,
                            CARACTERISTICA = (Car.Descripcion == null ? null : Car.Descripcion),
                            LOCACION = (Loc.Descripcion == null ? null : Loc.Descripcion),
                            SECTOR = (Sec.Descripcion == null ? null : Sec.Descripcion),
                            JORNADA = (Jor.Descripcion == null ? null : Jor.Descripcion),
                            HorarioEvento = (Pre.HorarioEvento == null ? null : Pre.HorarioEvento),
                            CantidadInicialInvitados = (Pre.CantidadInicialInvitados == null ? null : Pre.CantidadInicialInvitados),
                            CantidadInvitadosAdolecentes = (Pre.CantidadInvitadosAdolecentes == null ? null : Pre.CantidadInvitadosAdolecentes),
                            CantidadInvitadosMenores3y8 = (Pre.CantidadInvitadosMenores3y8 == null ? null : Pre.CantidadInvitadosMenores3y8),
                            CantidadInvitadosMenores3 = (Pre.CantidadInvitadosMenores3 == null ? null : Pre.CantidadInvitadosMenores3),
                            FechaEvento = (Pre.FechaEvento == null ? null : Pre.FechaEvento),
                            LocacionId = (Loc.Id == null ? 0 : Loc.Id),
                            EstadoEvento = EstEve.Descripcion,
                            EstadoEventoId = EstEve.Id,
                            PresupuestoEstadoId = (EstPre.Id == null ? 0 : EstPre.Id),
                            EstadoPresupuesto = (EstPre.Descripcion == null ? null : EstPre.Descripcion),
                            Ejecutivo = Emp.ApellidoNombre,
                            EventoId = Ev.Id,
                            ClienteId = Ev.ClienteId,//Cl.Id,
                            EmpleadoId = Emp.Id,
                            PresupuestoId = (Pre.Id == null ? 0 : Pre.Id),
                            PresupuestoIdAnterior = (Pre.PresupuestoIdAnterior == null ? null : Pre.PresupuestoIdAnterior),
                            RazonSocial = Ev.RazonSocial,//Cl.RazonSocial,
                            Fecha = Ev.Fecha,
                            Duracion = Dur.Descripcion,
                            Momento = Mom.Descripcion,
                            PrecioTotalPresupuesto = 0,
                            CostoTotalPresupuesto = 0,
                            RentaTotalPresupuesto = 0,
                            FechaCaducidad = (Pre.FechaCaducidad == null ? null : Pre.FechaCaducidad),
                            RentaTotalNominal = 0,
                            TipoEvento = TEv.Descripcion,
                            ImporteOrganizador = Pre.ImporteOrganizador,
                            PorcentajeOrganizador = Pre.PorcentajeOrganizador,
                            TotalOrganizador = Pre.ValorOrganizador

                        };



            List<ObtenerEventosPresupuestos> Salida = new List<ObtenerEventosPresupuestos>();
            foreach (var item in query)
            {

                ObtenerEventosPresupuestos cat = new ObtenerEventosPresupuestos();

                cat.ApellidoNombre = item.ApellidoNombre;
                cat.CARACTERISTICA = item.CARACTERISTICA;
                cat.LocacionId = item.LocacionId;
                cat.LOCACION = item.LOCACION;
                cat.SECTOR = item.SECTOR;
                cat.JORNADA = item.JORNADA;
                cat.HorarioEvento = item.HorarioEvento;
                cat.CantidadInicialInvitados = item.CantidadInicialInvitados;

                cat.CantidadInvitadosAdolecentes = item.CantidadInvitadosAdolecentes;
                cat.CantidadInvitadosMenores3y8 = item.CantidadInvitadosMenores3y8;
                cat.CantidadInvitadosMenores3 = item.CantidadInvitadosMenores3;
                cat.FechaEvento = item.FechaEvento;
                cat.EstadoEvento = item.EstadoEvento;
                cat.EstadoEventoId = item.EstadoEventoId;
                cat.PresupuestoEstadoId = item.PresupuestoEstadoId;
                cat.EstadoPresupuesto = item.EstadoPresupuesto;

                cat.Ejecutivo = item.Ejecutivo;
                cat.EventoId = item.EventoId;
                cat.ClienteId = item.ClienteId;
                cat.EmpleadoId = item.EmpleadoId;
                cat.PresupuestoId = item.PresupuestoId;
                int presupuestoId = item.PresupuestoId;
                cat.PresupuestoIdAnterior = item.PresupuestoIdAnterior;
                cat.RazonSocial = item.RazonSocial;
                cat.Fecha = item.Fecha;
                cat.Duracion = item.Duracion;
                cat.Momento = item.Momento;

                cat.PrecioTotalPresupuesto = CalcularPrecioTotalPresupuesto(presupuestoId);
                cat.CostoTotalPresupuesto = CalcularCostoTotalPresupuesto(presupuestoId);
                cat.RentaTotalPresupuesto = CalcularRentabilidad(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.FechaCaducidad = item.FechaCaducidad;

                cat.RentaTotalNominal = CalcularRentaNominal(cat.PrecioTotalPresupuesto, cat.CostoTotalPresupuesto);

                cat.TipoEvento = item.TipoEvento;

                cat.ImporteOrganizador = item.ImporteOrganizador;
                cat.PorcentajeOrganizador = item.PorcentajeOrganizador;
                cat.TotalOrganizador = item.TotalOrganizador;

                Salida.Add(cat);
            }

            return Salida.Distinct().OrderBy(o => o.PresupuestoEstadoId).ToList();

        }
    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class Eventos
    {
        DomainAmbientHouse.Servicios.Comun cmd = new DomainAmbientHouse.Servicios.Comun();

        public string RazonSocialCliente
        {
            get
            {
                return cmd.QuitarAcentos(RazonSocial);
            }
            set
            {
                RazonSocial = cmd.QuitarAcentos(RazonSocialCliente);
            }
        }

        public string ApeNomCliente
        {
            get
            {
                return cmd.QuitarAcentos(ApellidoNombreCliente);
            }
            set
            {
                ApellidoNombreCliente = cmd.QuitarAcentos(ApeNomCliente);
            }
        }
    }

    public partial class SearcherEventos
    {
        public string EmpleadoId { get; set; }
        public string NroEvento { get; set; }
        public string NroPresupuesto { get; set; }
        public string NroCliente { get; set; }
        public string ApellidoNombre { get; set; }
        public string RazonSocial { get; set; }
        public string FechaEvento { get; set; }
    }

    public partial class SearcherReporteProveedoresAsociados
    {
        public int ProveedorId { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string PresupuestoId { get; set; }
    }

}
