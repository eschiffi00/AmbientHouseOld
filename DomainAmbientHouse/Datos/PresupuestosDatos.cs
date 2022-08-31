using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using System.Transactions;

namespace DomainAmbientHouse.Datos
{
    public class PresupuestosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public PresupuestosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual ObtenerDatosParaPresupuesto ObtenerPresupuestos(int EventoId)
        {

            return SqlContext.ObtenerDatosParaPresupuesto.Where(o => o.EventoId == EventoId).FirstOrDefault();

        }

        public ObtenerPresupuestoSalon ObtenerPresupuestosSalon(int presupuestoId)
        {
            return SqlContext.ObtenerPresupuestoSalon.Where(o => o.PresupuestoId == presupuestoId).FirstOrDefault();
        }

        public ObtenerPresupuestoTecnica ObtenerPresupuestosTecnica(int presupuestoId)
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

        public PresupuestoPDF ObtenerPresupuestosPorPresupuesto(int id, List<ClientesPipedrive> lisClientes)
        {

            //var query = from C in lisClientes
            var query = from E in SqlContext.Eventos
                        join P in SqlContext.Presupuestos on E.Id equals P.EventoId
                        join S in SqlContext.Segmentos on P.SegmentoId equals S.Id
                        join Ca in SqlContext.Caracteristicas on P.CaracteristicaId equals Ca.Id
                        join Se in SqlContext.Sectores on P.SectorId equals Se.Id into Ses
                        from Se in Ses.DefaultIfEmpty()
                        join T in SqlContext.TipoEventos on P.TipoEventoId equals T.Id
                        join L in SqlContext.Locaciones on P.LocacionId equals L.Id
                        join J in SqlContext.Jornadas on P.JornadaId equals J.Id
                        join Em in SqlContext.Empleados on E.EmpleadoId equals Em.Id
                        select new PresupuestoPDF
                        {
                            ClienteId = E.ClienteId,
                            ApellidoNombre = E.ApellidoNombreCliente,
                            Mail = E.Mail,
                            Celular = E.Tel,
                            SegmentoId = S.Id,
                            Segmento = S.Descripcion,
                            CaracteristicaId = Ca.Id,
                            Caracteristica = Ca.Descripcion,
                            SectorId = (Se.Id == null ? 0 : Se.Id),
                            Sector = Se.Descripcion,
                            TipoEventoId = T.Id,
                            TipoEvento = T.Descripcion,
                            LocacionId = L.Id,
                            Locacion = L.Descripcion,
                            TipoLocacion = L.TipoLocacion,
                            JornadaId = J.Id,
                            Jornada = J.Descripcion,
                            CantidadInicialInvitados = P.CantidadInicialInvitados,
                            CantidadInvitadosMenores3 = P.CantidadInvitadosMenores3,
                            CantidadInvitadosMenores3y8 = P.CantidadInvitadosMenores3y8,
                            CantidadInvitadosAdolecentes = P.CantidadInvitadosAdolecentes,
                            FechaEvento = P.FechaEvento,
                            HorarioEvento = P.HorarioEvento,
                            HorarioArmado = P.HorarioArmado,
                            HoraFinalizado = P.HoraFinalizado,
                            Comentario = E.Comentario,
                            EventoId = E.Id,
                            EmpleadoId = Em.Id,
                            Ejecutivo = Em.ApellidoNombre,
                            FechaContacto = E.Fecha,
                            PresupuestoId = P.Id,
                            RazonSocial = E.RazonSocial,
                            PrecioTotal = P.PrecioTotal,
                            PrecioPorPersona = P.PrecioPorPersona,
                            ComentarioPresupuesto = P.Comentario,
                            FechaPresupuesto = P.FechaPresupuesto,
                            LocacionOtra = P.LocacionOtra,
                            ValorOrganizador = P.ValorOrganizador,
                            ValorRoyaltyOrganizador = P.ValorRoyaltyOrganizador
                           
                        };

            return query.Where(o => o.PresupuestoId == id).FirstOrDefault();
        }

        public List<ListarAdicionalesPorPresupuesto> ObtenerAdicionales(int presupuestoId, int EstadoId)
        {

            int UNAdicionales = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

            var query = from PD in SqlContext.PresupuestoDetalle
                        join A in SqlContext.Adicionales on PD.ServicioId equals A.Id
                        join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
                        where PD.PresupuestoId == presupuestoId && PD.UnidadNegocioId == 9 && PD.EstadoId == EstadoId
                        select new
                        {
                            Descripcion = A.Descripcion,
                            Cantidad = PD.CantidadAdicional,
                            ValorAdicional = PD.ValorSeleccionado,
                            PresupuestoId = PD.PresupuestoId,
                            AdicionalId = PD.ServicioId,
                            RubroDescripcion = R.Descripcion,
                            Id = R.Id,
                            ValorIntermediario = PD.ValorIntermediario
                        };

            //var query = from PA in SqlContext.PresupuestoAdicionales
            //            join A in SqlContext.Adicionales on PA.AdicionalId equals A.Id
            //            join R in SqlContext.UnidadesNegocios on A.RubroId equals R.Id
            //            where PA.PresupuestoId == presupuestoId
            //            select new { 
            //                Descripcion = A.Descripcion,
            //                Cantidad = PA.Cantidad,
            //                ValorAdicional = PA.ValorAdicional,
            //                PresupuestoId = PA.PresupuestoId,
            //                AdicionalId = PA.AdicionalId,
            //                RubroDescripcion = R.Descripcion,
            //                Id = R.Id
            //            };

            List<ListarAdicionalesPorPresupuesto> Salida = new List<ListarAdicionalesPorPresupuesto>();
            foreach (var item in query)
            {

                ListarAdicionalesPorPresupuesto cat = new ListarAdicionalesPorPresupuesto();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
                cat.Cantidad = (int)item.Cantidad;
                cat.ValorAdicional = item.ValorAdicional;
                cat.PresupuestoId = item.PresupuestoId;
                cat.AdicionalId = (int)item.AdicionalId;
                cat.RubroDescripcion = item.RubroDescripcion;
                cat.ValorIntermediario = (item.ValorIntermediario == null ? 0 : double.Parse(item.ValorIntermediario.ToString()));

                Salida.Add(cat);
            }

            return Salida.OrderBy(o => o.RubroDescripcion).ToList();

            //return SqlContext.ListarAdicionalesPorPresupuesto.Where(o => o.PresupuestoId == presupuestoId).OrderBy(o => o.RubroDescripcion).ToList();
        }

        public Presupuestos TraerPresupuesto(int presupuestoId)
        {
            return SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).FirstOrDefault();
        }

        public Presupuestos BuscarPresupuesto(int PresupuestoId)
        {
            return SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();
        }

        public double CalcularValorTotalPresupuestoPorPresupuestoId(int PresupuestoId)
        {

            double ValorTotal = 0;

            Presupuestos presu = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();

            List<PresupuestoDetalle> query = (from L in SqlContext.PresupuestoDetalle
                                              where L.PresupuestoId == PresupuestoId
                                              select L).ToList();


            ValorTotal = query.Select(o => o.ValorSeleccionado +
                            (o.Cannon == null ? 0 : (double)o.Cannon) +
                            (o.Logistica == null ? 0 : (double)o.Logistica) +
                            (o.UsoCocina == null ? 0 : (double)o.UsoCocina) +
                            (o.ValorIntermediario == null ? 0 : (double)o.ValorIntermediario) +
                            (o.PrecioSillas == null ? 0 : (double) o.PrecioSillas) +
                            (o.PrecioMesas == null ? 0 : (double)o.PrecioMesas) +
                            (o.Incremento == null ? 0 : (double)o.Incremento) -
                            (o.Descuentos == null ? 0 : (double)o.Descuentos)).Sum();

            if (presu.ValorOrganizador != null)
            {
                ValorTotal = ValorTotal + double.Parse(presu.ValorOrganizador.ToString()) + double.Parse(presu.ValorRoyaltyOrganizador.ToString());
            }

            return System.Math.Round(ValorTotal, 2);

        }

        public double CalcularValorTotalPresupuestoAprobado(int PresupuestoId)
        {
            int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            double ValorTotal = 0;

            Presupuestos presu = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();

            List<PresupuestoDetalle> query = (from L in SqlContext.PresupuestoDetalle
                                              where L.PresupuestoId == PresupuestoId && L.EstadoId == PresupuestoDetalleAprobado
                                              select L).ToList();


            ValorTotal = query.Select(o => o.ValorSeleccionado +
                            (o.Cannon == null ? 0 : (double)o.Cannon) +
                            (o.Logistica == null ? 0 : (double)o.Logistica) +
                            (o.UsoCocina == null ? 0 : (double)o.UsoCocina) +
                            (o.ValorIntermediario == null ? 0 : (double)o.ValorIntermediario) +
                            (o.PrecioSillas == null ? 0 : (double)o.PrecioSillas) +
                            (o.PrecioMesas == null ? 0 : (double)o.PrecioMesas) +
                            (o.Incremento == null ? 0 : (double)o.Incremento) -
                            (o.Descuentos == null ? 0 : (double)o.Descuentos)).Sum();



            if (presu.ValorOrganizador != null)
            {
                ValorTotal = ValorTotal + double.Parse(presu.ValorOrganizador.ToString()) + double.Parse(presu.ValorRoyaltyOrganizador.ToString());
            }

            return System.Math.Round(ValorTotal, 2);


        }

        public double CalcularValorTotalRoyaltyAprobado(int PresupuestoId)
        {
            int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            double ValorTotal = 0;

            Presupuestos presu = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();

            List<PresupuestoDetalle> query = (from L in SqlContext.PresupuestoDetalle
                                              where L.PresupuestoId == PresupuestoId && L.EstadoId == PresupuestoDetalleAprobado
                                              select L).ToList();


            ValorTotal = query.Select(o => o.Royalty).Sum();



            if (presu.ValorOrganizador != null)
            {
                ValorTotal = ValorTotal + double.Parse(presu.ValorRoyaltyOrganizador.ToString());
            }

            return System.Math.Round(ValorTotal, 2);


        }

        internal List<Presupuestos> BuscarPresupuestoPorCliente(int clientebisId)
        {

            int eventoreservado = Int32.Parse(ConfigurationManager.AppSettings["EstadoReservado"].ToString());
            int eventocerrado = Int32.Parse(ConfigurationManager.AppSettings["EstadoCerrado"].ToString());
            int presupuestoaprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());
            int presupuestorealizado = Int32.Parse(ConfigurationManager.AppSettings["EstadoRealizado"].ToString());
           

            var query = from E in SqlContext.Eventos
                        join P in SqlContext.Presupuestos on E.Id equals P.EventoId
                        where E.ClienteBisId == clientebisId && (E.EstadoId == eventoreservado || E.EstadoId == eventocerrado)
                                                            && (P.EstadoId == presupuestoaprobado || P.EstadoId == presupuestorealizado)
                        select P;

            return query.ToList();
        }

        public double CalcularValorTotalPresupuestoPorPresupuestoIdPendiente(int PresupuestoId)
        {

            double ValorTotal = 0;
            int pendiente = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());

            Presupuestos presu = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();

            List<PresupuestoDetalle> query = (from L in SqlContext.PresupuestoDetalle
                                              where L.PresupuestoId == PresupuestoId && L.EstadoId == pendiente
                                              select L).ToList();


            ValorTotal = query.Select(o => o.ValorSeleccionado +
                            (o.Cannon == null ? 0 : (double)o.Cannon) +
                            (o.Logistica == null ? 0 : (double)o.Logistica) +
                            (o.UsoCocina == null ? 0 : (double)o.UsoCocina) +
                            (o.ValorIntermediario == null ? 0 : (double)o.ValorIntermediario) +
                            (o.Incremento == null ? 0 : (double)o.Incremento) -
                            (o.Descuentos == null ? 0 : (double)o.Descuentos)).Sum();



            //if (presu.ValorOrganizador != null)
            //{
            //    ValorTotal = ValorTotal + double.Parse(presu.ValorOrganizador.ToString());
            //}

            return System.Math.Round(ValorTotal, 2);


        }

        public double CalcularCostoTotalPresupuestoPorPresupuestoId(int PresupuestoId)
        {
            double ValorTotal = 0;

            Presupuestos presu = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoId).FirstOrDefault();

            List<PresupuestoDetalle> query = (from L in SqlContext.PresupuestoDetalle
                                              where L.PresupuestoId == PresupuestoId
                                              select L).ToList();



            ValorTotal = query.Select(o => (double)o.Costo +
                          (o.Cannon == null ? 0 : (double)o.Cannon) +
                          (o.Logistica == null ? 0 : (double)o.Logistica) +
                          (o.UsoCocina == null ? 0 : (double)o.UsoCocina) +
                          (o.ValorIntermediario == null ? 0 : (double)o.ValorIntermediario)).Sum();

            return System.Math.Round(ValorTotal, 2);
        }

        public List<ObtenerEventos> BuscarPrespuestosPorEventos(int EventoId)
        {

            EventosDatos eventos = new EventosDatos();

            List<ObtenerEventosPresupuestos> listEventos = eventos.ObtenerEventosPresupuestos(EventoId).OrderBy(o => o.PresupuestoId).Distinct().ToList();

            var query = from E in listEventos
                        //join C in lisClientes on E.ClienteId equals C.Id
                        select new ObtenerEventos
                        {
                            ApellidoNombre = E.ApellidoNombre,
                            CARACTERISTICA = E.CARACTERISTICA,
                            LOCACION = E.LOCACION,
                            SECTOR = E.SECTOR,
                            JORNADA = E.JORNADA,
                            HorarioEvento = E.HorarioEvento,
                            CantidadInicialInvitados = E.CantidadInicialInvitados,
                            FechaEvento = E.FechaEvento,
                            ClienteId = E.ClienteId,
                            Id = E.EventoId,
                            Estado = E.EstadoEvento,
                            Ejecutivo = E.Ejecutivo,
                            EventoId = E.EventoId,
                            EmpleadoId = E.EmpleadoId,
                            EstadoId = E.EstadoEventoId,
                            RazonSocial = E.RazonSocial,
                            Fecha = E.Fecha,
                            PresupuestoId = E.PresupuestoId,
                            PresupuestoEstadoId = E.PresupuestoEstadoId,
                            EstadoPresupuesto = E.EstadoPresupuesto,
                            PresupuestoIdAnterior = E.PresupuestoIdAnterior,
                            LocacionId = int.Parse(E.LocacionId.ToString()),
                            TipoEvento = E.TipoEvento

                        };


            return query.ToList();


        }

        public List<PresupuestoDetalle> ObtenerPresupuestoDetalle(int presupuestoId, int unidadNegocioId, int estadoDetalleId)
        {
            var query = from Pd in SqlContext.PresupuestoDetalle
                        where Pd.UnidadNegocioId == unidadNegocioId && Pd.PresupuestoId == presupuestoId && Pd.EstadoId == estadoDetalleId
                        select Pd;

            return query.ToList();

        }

        public void AplicarAjuste(int presupuestoDetalleId, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            PresupuestoDetalle editPresuDetalle = SqlContext.PresupuestoDetalle.Where(o => o.Id == presupuestoDetalleId).FirstOrDefault();

            switch (editPresuDetalle.UnidadNegocioId)
            {
                case 1:
                    AplicarDescuentoAmbientacion(editPresuDetalle, TotalDescuento, TotalIncremento, Comentario);
                    break;
                case 3:
                    AplicarDescuentoCatering(editPresuDetalle, TotalDescuento, TotalIncremento, Comentario);
                    break;
                case 6:
                    AplicarDescuentoBarra(editPresuDetalle, TotalDescuento, TotalIncremento, Comentario);
                    break;
                default:
                    AplicarDescuento(editPresuDetalle, TotalDescuento, TotalIncremento, Comentario);
                    break;
            }



        }

        private void AplicarDescuentoBarra(PresupuestoDetalle editPresuDetalle, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            Presupuestos presuConsultarLocacion = SqlContext.Presupuestos.Single(o => o.Id == (int)editPresuDetalle.PresupuestoId);

            Locaciones locConsultarCanon = SqlContext.Locaciones.Single(o => o.Id == presuConsultarLocacion.LocacionId);

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {


                    if (TotalDescuento > 0)
                    {
                        editPresuDetalle.Descuentos = (editPresuDetalle.Descuentos == null ? 0 : editPresuDetalle.Descuentos) + TotalDescuento;

                        CalcularNuevoCanon(editPresuDetalle, locConsultarCanon);
                    }
                    if (TotalIncremento > 0)
                    {
                        editPresuDetalle.Incremento = (editPresuDetalle.Incremento == null ? 0 : editPresuDetalle.Incremento) + TotalIncremento;

                        CalcularNuevoCanon(editPresuDetalle, locConsultarCanon);
                    }
                    editPresuDetalle.Comentario = Comentario;

                    SqlContext.SaveChanges();

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void AplicarDescuentoCatering(PresupuestoDetalle editPresuDetalle, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            Presupuestos presuConsultarLocacion = SqlContext.Presupuestos.Single(o => o.Id == (int)editPresuDetalle.PresupuestoId);

            Locaciones locConsultarCanon = SqlContext.Locaciones.Single(o => o.Id == presuConsultarLocacion.LocacionId);


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {


                    if (TotalDescuento > 0)
                    {
                        editPresuDetalle.Descuentos = (editPresuDetalle.Descuentos == null ? 0 : editPresuDetalle.Descuentos) + TotalDescuento;

                        CalcularNuevoCanon(editPresuDetalle, locConsultarCanon);
                    }
                    if (TotalIncremento > 0)
                    {
                        editPresuDetalle.Incremento = (editPresuDetalle.Incremento == null ? 0 : editPresuDetalle.Incremento) + TotalIncremento;

                        CalcularNuevoCanon(editPresuDetalle, locConsultarCanon);
                    }
                    editPresuDetalle.Comentario = Comentario;

                    SqlContext.SaveChanges();

                    scope.Complete();

                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        private void AplicarDescuentoAmbientacion(PresupuestoDetalle editPresuDetalle, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            Presupuestos presuConsultarLocacion = SqlContext.Presupuestos.Single(o => o.Id == (int)editPresuDetalle.PresupuestoId);

            Locaciones locConsultarCanon = SqlContext.Locaciones.Single(o => o.Id == presuConsultarLocacion.LocacionId);

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (TotalDescuento > 0)
                    {
                        editPresuDetalle.Descuentos = (editPresuDetalle.Descuentos == null ? 0 : editPresuDetalle.Descuentos) + TotalDescuento;

                        CalcularNuevoCanon(editPresuDetalle, locConsultarCanon);
                    }
                    if (TotalIncremento > 0)
                    {
                        editPresuDetalle.Incremento = (editPresuDetalle.Incremento == null ? 0 : editPresuDetalle.Incremento) + TotalIncremento;

                        CalcularNuevoCanon(editPresuDetalle, locConsultarCanon);

                    }
                    editPresuDetalle.Comentario = Comentario;

                    SqlContext.SaveChanges();

                    scope.Complete();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private static void CalcularNuevoCanon(PresupuestoDetalle editPresuDetalle, Locaciones locConsultarCanon)
        {
            switch (editPresuDetalle.UnidadNegocioId)
            {
                case 1:
                    if (locConsultarCanon.TipoCannonAmbientacion == "Porcentaje")
                    {
                        double totalAmbientacion = editPresuDetalle.ValorSeleccionado
                                            - (editPresuDetalle.Descuentos == null ? 0 : (double)editPresuDetalle.Descuentos)
                                            + (editPresuDetalle.Incremento == null ? 0 : (double)editPresuDetalle.Incremento);

                        editPresuDetalle.Cannon = totalAmbientacion * ((locConsultarCanon.CannonAmbientacion) / 100);

                    }
                    break;

                case 3:
                    if (locConsultarCanon.TipoCannonCatering == "Porcentaje")
                    {
                        double totalCatering = editPresuDetalle.ValorSeleccionado
                                            - (editPresuDetalle.Descuentos == null ? 0 : (double)editPresuDetalle.Descuentos)
                                            + (editPresuDetalle.Incremento == null ? 0 : (double)editPresuDetalle.Incremento);

                        editPresuDetalle.Cannon = totalCatering * ((locConsultarCanon.Cannon) / 100);

                    }
                    break;
                default:
                    if (locConsultarCanon.TipoCannonBarra == "Porcentaje")
                    {
                        double totalBarra = editPresuDetalle.ValorSeleccionado
                                            - (editPresuDetalle.Descuentos == null ? 0 : (double)editPresuDetalle.Descuentos)
                                            + (editPresuDetalle.Incremento == null ? 0 : (double)editPresuDetalle.Incremento);

                        editPresuDetalle.Cannon = totalBarra * ((locConsultarCanon.CannonBarra) / 100);

                    }
                    break;
            }
           
        }

        private void AplicarDescuento(PresupuestoDetalle editPresuDetalle, double TotalDescuento, double TotalIncremento, string Comentario)
        {
            if (TotalDescuento > 0)
                editPresuDetalle.Descuentos = (editPresuDetalle.Descuentos == null ? 0 : editPresuDetalle.Descuentos) + TotalDescuento;

            if (TotalIncremento > 0)
                editPresuDetalle.Incremento = (editPresuDetalle.Incremento == null ? 0 : editPresuDetalle.Incremento) + TotalIncremento;

            editPresuDetalle.Comentario = Comentario;

            SqlContext.SaveChanges();
        }

        public void AplicarAjuste(int presupuestoDetalleId, double TotalDescuento, double TotalIncremento, string Comentario, double TotalCosto)
        {
            PresupuestoDetalle editPresuDetalle = SqlContext.PresupuestoDetalle.Where(o => o.Id == presupuestoDetalleId).FirstOrDefault();


            //if (TotalDescuento > 0)
            //    editPresuDetalle.Descuentos = (editPresuDetalle.Descuentos == null ? 0 : editPresuDetalle.Descuentos) + TotalDescuento;

            //if (TotalIncremento > 0)
            //    editPresuDetalle.Incremento = (editPresuDetalle.Incremento == null ? 0 : editPresuDetalle.Incremento) + TotalIncremento;

            editPresuDetalle.Costo = TotalCosto;

            SqlContext.SaveChanges();
        }

        public double CalcularCantidadInvitados(double pCantidadAdultos, double pCantidadInvitadosEntre3y8, double pCantidadInvitadosMenores3, double pCantidadInvitadosAdolecentes)
        {
            ParametrosDatos datosParametros = new ParametrosDatos();

            Parametros parametroCateringEntre3y8 = datosParametros.BuscarParametros("PorcentajeCateringEntre3y8");

            double porcentajeCateringEntre3y8 = double.Parse(parametroCateringEntre3y8.Valor);

            Parametros parametroCateringMenores3 = datosParametros.BuscarParametros("PorcentajeCateringMenores3");

            double porcentajeCateringMenores3 = double.Parse(parametroCateringMenores3.Valor);

            Parametros parametroCateringAdolescentes = datosParametros.BuscarParametros("PorcentajeCateringAdolescentes");

            double porcentajeCateringAdolescentes = double.Parse(parametroCateringAdolescentes.Valor);


            double CantidadAdultos = 0;
            if (pCantidadAdultos > 0)
            {
                CantidadAdultos = pCantidadAdultos;
            }

            double CantidadInvitadosEntre3y8 = 0;
            if (pCantidadInvitadosEntre3y8 > 0)
            {
                CantidadInvitadosEntre3y8 = double.Parse((pCantidadInvitadosEntre3y8 * porcentajeCateringEntre3y8).ToString());
            }

            double CantidadInvitadosMenores3 = 0;
            if (pCantidadInvitadosMenores3 > 0)
            {
                CantidadInvitadosMenores3 = double.Parse((pCantidadInvitadosMenores3 * porcentajeCateringMenores3).ToString());
            }

            double CantidadInvitadosAdolecentes = 0;
            if (pCantidadInvitadosAdolecentes > 0)
            {
                CantidadInvitadosAdolecentes = double.Parse((pCantidadInvitadosAdolecentes * porcentajeCateringAdolescentes).ToString());
            }

            return ((CantidadAdultos + CantidadInvitadosEntre3y8 + CantidadInvitadosMenores3 + CantidadInvitadosAdolecentes));

        }

        public void AprobarPresupuesto(int presupuestoId)
        {
            int aprobado = Int32.Parse(ConfigurationManager.AppSettings["EstadoPresupuestoAprobado"].ToString());

            Presupuestos edit = SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).SingleOrDefault();

            edit.EstadoId = aprobado;
            SqlContext.SaveChanges();
        }

        public List<FechasBloqueadas> ObtenerFechasBloqueadas(DateTime fechaSeleccionada)
        {
            return SqlContext.FechasBloqueadas.Where(o => o.FechaBloqueada.Equals(fechaSeleccionada)).ToList();
        }

        public bool EliminarDetallePresupuesto(int Id)
        {
            PresupuestoDetalle detalle = SqlContext.PresupuestoDetalle.Where(o => o.Id == Id).FirstOrDefault();

            if (detalle != null)
            {

                try
                {
                    SqlContext.PresupuestoDetalle.Remove(detalle);
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
                return false;
            }
        }

        public CalculoIndexacion CalcularIndexacion(double indice, int presupuestoId)
        {

            Presupuestos presupuesto = SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).FirstOrDefault();

            double totalPresupuesto = this.CalcularValorTotalPresupuestoPorPresupuestoId(presupuestoId);
            double saldo = 0;

            List<PagosClientes> ListPagos = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                            && o.TipoPago != null
                                                                            && o.Delete == false).ToList();


            CalculoIndexacion retorno = new CalculoIndexacion();

            PagosClienteDatos totalPagadoClientesDatos = new PagosClienteDatos();

            double totalPagosPorPresupuesto = 0;// totalPagadoClientesDatos.TotalPagado(presupuestoId);

            if (ListPagos.Count() > 0)
            {

                PagosClientes buscarReserva = (from s in ListPagos where s.TipoPago.StartsWith("Reserva") select s).FirstOrDefault();

                if (buscarReserva != null)
                {

                    saldo = totalPresupuesto - (totalPagosPorPresupuesto);

                    TimeSpan ts = DateTime.Parse(presupuesto.FechaEvento.ToString()) - buscarReserva.FechaPago;
                    int diferenciaEnDias = ts.Days;

                    retorno.CantidadDias = diferenciaEnDias;
                    retorno.FechaReserva = String.Format("{0:dd/MM/yyyy}", buscarReserva.FechaPago);


                    double valornoElevado = (1 + (float)indice / 100);
                    double potencia = ((float)diferenciaEnDias / 30);
                    double elevado = Math.Pow((float)valornoElevado, (float)potencia);
                    double valotIndexado = (saldo * elevado);

                    retorno.SaldoIndexado = saldo;
                    retorno.Total = valotIndexado;
                    return retorno;

                }
                else
                {
                    retorno.CantidadDias = 0;
                    retorno.FechaReserva = "";
                    retorno.SaldoIndexado = 0;
                    retorno.Total = totalPresupuesto - (totalPagosPorPresupuesto);

                    return retorno;
                }
            }

            retorno.CantidadDias = 0;
            retorno.FechaReserva = "";
            retorno.SaldoIndexado = 0;
            retorno.Total = totalPresupuesto - (totalPagosPorPresupuesto);

            return retorno;

        }

        public CalculoIndexacion CalcularIndexacionPagoaCuenta(double indice, int presupuestoId)
        {

            int tipoMovimientoCLIENTE = Int32.Parse(ConfigurationManager.AppSettings["CuentaClientes"].ToString()); ;
            int cuentaRetencionesGanancias = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesGanancias"].ToString());
            int cuentaRetencionesIVA = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIVA"].ToString());
            int cuentaRetencionesIIBB = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesIIBB"].ToString());
            int cuentaRetencionesSUSS = Int32.Parse(ConfigurationManager.AppSettings["CuentaRetencionesSUSS"].ToString());


            string empresaOtra = "OTRO";
            string empresaMonotributo = "MONOTRIBUTO";

            Presupuestos presupuesto = SqlContext.Presupuestos.Where(o => o.Id == presupuestoId).FirstOrDefault();

            double totalPresupuesto = this.CalcularValorTotalPresupuestoPorPresupuestoId(presupuestoId);
            double saldo = 0;

            List<PagosClientes> ListPagos = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                            && o.TipoPago != null
                                                                            && o.Delete == false).ToList();



            List<PagosClientes> ListPagosRealizados = SqlContext.PagosClientes.Where(o => o.PresupuestoId == presupuestoId
                                                                            && o.Delete == false).ToList();

            CalculoIndexacion retorno = new CalculoIndexacion();

            double totalPagosPorPresupuesto = 0;

            foreach (var item in ListPagosRealizados)
            {
                if (item.TipoMovimientoId == tipoMovimientoCLIENTE
                    || item.TipoMovimientoId == cuentaRetencionesGanancias
                    || item.TipoMovimientoId == cuentaRetencionesIVA
                    || item.TipoMovimientoId == cuentaRetencionesIIBB
                    || item.TipoMovimientoId == cuentaRetencionesSUSS)
                {

                    Empresas empresa = SqlContext.Empresas.Where(o => o.Id == item.EmpresaId).SingleOrDefault();

                    //EMPRESA ES OTRO Y TIPO MOVIMIENTO ES PAGO DE CLIENTE EVENTO NO LLEVA IVA
                    if (empresa.CondicionIva == empresaOtra && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else if (empresa.CondicionIva == empresaMonotributo && item.TipoMovimientoId == tipoMovimientoCLIENTE)
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + item.Importe;
                    else
                        totalPagosPorPresupuesto = totalPagosPorPresupuesto + (item.Importe / double.Parse("1,21"));

                }
            }

            if (ListPagos.Count() > 0)
            {

                PagosClientes buscarReserva = (from s in ListPagos where s.TipoPago.StartsWith("Reserva") select s).FirstOrDefault();

                PagosClientes ultimaFecha = (from s in ListPagos select s).OrderByDescending(o => o.FechaPago).First();

                if (buscarReserva != null)
                {

                    saldo = totalPresupuesto - (totalPagosPorPresupuesto);

                    TimeSpan ts = ultimaFecha.FechaPago - buscarReserva.FechaPago;
                    int diferenciaEnDias = ts.Days;

                    retorno.CantidadDias = diferenciaEnDias;
                    retorno.FechaReserva = String.Format("{0:dd/MM/yyyy}", buscarReserva.FechaPago);

                    double valornoElevado = (1 + (float)indice / 100);
                    double potencia = ((float)diferenciaEnDias / 30);
                    double elevado = Math.Pow((float)valornoElevado, (float)potencia);
                    double valotIndexado = (saldo * elevado);

                    retorno.SaldoIndexado = saldo;
                    retorno.Total = valotIndexado;
                    return retorno;

                }
                else
                {
                    retorno.CantidadDias = 0;
                    retorno.FechaReserva = "";
                    retorno.SaldoIndexado = 0;
                    retorno.Total = totalPresupuesto - (totalPagosPorPresupuesto);

                    return retorno;
                }
            }

            retorno.CantidadDias = 0;
            retorno.FechaReserva = "";
            retorno.SaldoIndexado = 0;
            retorno.Total = totalPresupuesto - (totalPagosPorPresupuesto);

            return retorno;

        }

        public void GuardarPresupuesto(Presupuestos PresupuestoSeleccionado)
        {
            if (PresupuestoSeleccionado.Id > 0)
            {

                Presupuestos editPresu = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoSeleccionado.Id).First();

                editPresu.EventoId = PresupuestoSeleccionado.EventoId;
                editPresu.FechaEvento = PresupuestoSeleccionado.FechaEvento;
                editPresu.FechaPresupuesto = System.DateTime.Now;
                editPresu.CantidadInicialInvitados = PresupuestoSeleccionado.CantidadInicialInvitados;
                editPresu.CantidadInvitadosAdolecentes = PresupuestoSeleccionado.CantidadInvitadosAdolecentes;
                editPresu.CantidadInvitadosMenores3 = PresupuestoSeleccionado.CantidadInvitadosMenores3;
                editPresu.CantidadInvitadosMenores3y8 = PresupuestoSeleccionado.CantidadInvitadosMenores3y8;
                editPresu.TipoEventoId = PresupuestoSeleccionado.TipoEventoId;
                editPresu.LocacionId = PresupuestoSeleccionado.LocacionId;
                editPresu.CaracteristicaId = PresupuestoSeleccionado.CaracteristicaId;
                editPresu.SegmentoId = PresupuestoSeleccionado.SegmentoId;
                editPresu.SectorId = PresupuestoSeleccionado.SectorId;
                editPresu.TipoEventoOtro = PresupuestoSeleccionado.TipoEventoOtro;
                editPresu.JornadaId = PresupuestoSeleccionado.JornadaId;
                editPresu.LocacionOtra = PresupuestoSeleccionado.LocacionOtra;
                editPresu.DireccionOtra = PresupuestoSeleccionado.DireccionOtra;
                editPresu.EstadoId = PresupuestoSeleccionado.EstadoId;
                editPresu.DuracionId = PresupuestoSeleccionado.DuracionId;
                editPresu.MomentoDiaID = PresupuestoSeleccionado.MomentoDiaID;
                editPresu.ValorOrganizador = PresupuestoSeleccionado.ValorOrganizador;
                editPresu.PorcentajeOrganizador = PresupuestoSeleccionado.PorcentajeOrganizador;
                editPresu.ImporteOrganizador = PresupuestoSeleccionado.ImporteOrganizador;
                editPresu.FechaCaducidad = PresupuestoSeleccionado.FechaCaducidad;
                editPresu.HorarioEvento = PresupuestoSeleccionado.HorarioEvento;
                editPresu.HoraFinalizado = PresupuestoSeleccionado.HoraFinalizado;
                editPresu.Comentario = PresupuestoSeleccionado.Comentario;

                editPresu.CantidadAdultosFinal = PresupuestoSeleccionado.CantidadAdultosFinal;
                editPresu.CantidadAdolescentesFinal = PresupuestoSeleccionado.CantidadAdolescentesFinal;
                editPresu.CantidadMenoresEntre3y8Final = PresupuestoSeleccionado.CantidadMenoresEntre3y8Final;
                editPresu.CantidadMenores3Final = PresupuestoSeleccionado.CantidadMenores3Final;

                editPresu.ValorRoyaltyOrganizador = PresupuestoSeleccionado.ValorRoyaltyOrganizador;

                SqlContext.SaveChanges();

            }
            else
            {

                Presupuestos newPresu = new Presupuestos();

                newPresu.EventoId = PresupuestoSeleccionado.EventoId;
                newPresu.FechaEvento = PresupuestoSeleccionado.FechaEvento;
                newPresu.FechaPresupuesto = System.DateTime.Now;
                newPresu.CantidadInicialInvitados = PresupuestoSeleccionado.CantidadInicialInvitados;
                newPresu.CantidadInvitadosAdolecentes = PresupuestoSeleccionado.CantidadInvitadosAdolecentes;
                newPresu.CantidadInvitadosMenores3 = PresupuestoSeleccionado.CantidadInvitadosMenores3;
                newPresu.CantidadInvitadosMenores3y8 = PresupuestoSeleccionado.CantidadInvitadosMenores3y8;
                newPresu.TipoEventoId = PresupuestoSeleccionado.TipoEventoId;
                newPresu.LocacionId = PresupuestoSeleccionado.LocacionId;
                newPresu.CaracteristicaId = PresupuestoSeleccionado.CaracteristicaId;
                newPresu.SegmentoId = PresupuestoSeleccionado.SegmentoId;
                newPresu.SectorId = PresupuestoSeleccionado.SectorId;
                newPresu.TipoEventoOtro = PresupuestoSeleccionado.TipoEventoOtro;
                newPresu.JornadaId = PresupuestoSeleccionado.JornadaId;
                newPresu.LocacionOtra = PresupuestoSeleccionado.LocacionOtra;
                newPresu.DireccionOtra = PresupuestoSeleccionado.DireccionOtra;
                newPresu.EstadoId = PresupuestoSeleccionado.EstadoId;
                newPresu.DuracionId = PresupuestoSeleccionado.DuracionId;
                newPresu.MomentoDiaID = PresupuestoSeleccionado.MomentoDiaID;
                newPresu.ValorOrganizador = PresupuestoSeleccionado.ValorOrganizador;
                newPresu.PorcentajeOrganizador = PresupuestoSeleccionado.PorcentajeOrganizador;
                newPresu.ImporteOrganizador = PresupuestoSeleccionado.ImporteOrganizador;
                newPresu.FechaCaducidad = PresupuestoSeleccionado.FechaCaducidad;
                newPresu.HorarioEvento = PresupuestoSeleccionado.HorarioEvento;
                newPresu.HoraFinalizado = PresupuestoSeleccionado.HoraFinalizado;
                newPresu.Comentario = PresupuestoSeleccionado.Comentario;
                newPresu.ValorRoyaltyOrganizador = PresupuestoSeleccionado.ValorRoyaltyOrganizador;


                SqlContext.Presupuestos.Add(newPresu);
                SqlContext.SaveChanges();

                PresupuestoSeleccionado.Id = newPresu.Id;

            }
        }

        public void EditarPresupuesto(Presupuestos presupuesto)
        {
            if (presupuesto.Id > 0)
            {
                Presupuestos editPresu = SqlContext.Presupuestos.Where(o => o.Id == presupuesto.Id).SingleOrDefault();

                editPresu.EstadoId = presupuesto.EstadoId;

                SqlContext.SaveChanges();

            }
        }

        public bool ActualizarFechaEvento(Presupuestos PresupuestoSeleccionado)
        {
            try
            {


                if (PresupuestoSeleccionado.Id > 0)
                {
                    Presupuestos edit = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoSeleccionado.Id).SingleOrDefault();

                    edit.FechaEvento = PresupuestoSeleccionado.FechaEvento;
                    edit.HorarioEvento = PresupuestoSeleccionado.HorarioEvento;
                    edit.HoraFinalizado = PresupuestoSeleccionado.HoraFinalizado;

                    SqlContext.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public void EditarCantidadInvitados(Presupuestos PresupuestoSeleccionado)
        {
            if (PresupuestoSeleccionado.Id > 0)
            {
                Presupuestos edit = SqlContext.Presupuestos.Where(o => o.Id == PresupuestoSeleccionado.Id).SingleOrDefault();


                edit.CantidadInicialInvitados = PresupuestoSeleccionado.CantidadInicialInvitados;
                edit.CantidadInvitadosAdolecentes = PresupuestoSeleccionado.CantidadInvitadosAdolecentes;
                edit.CantidadInvitadosMenores3y8 = PresupuestoSeleccionado.CantidadInvitadosMenores3y8;
                edit.CantidadInvitadosMenores3 = PresupuestoSeleccionado.CantidadInvitadosMenores3;

                SqlContext.SaveChanges();


            }
        }

        internal bool EliminarInvitadosPendientes(int presupuestoId)
        {
            if (presupuestoId > 0)
            {
                try
                {
                    Presupuestos edit = SqlContext.Presupuestos.Single(o => o.Id == presupuestoId);

                    edit.CantidadAdultosFinal = null;
                    edit.CantidadAdolescentesFinal = null;
                    edit.CantidadMenores3Final = null;
                    edit.CantidadMenoresEntre3y8Final = null;

                    SqlContext.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }

            }
            return false;

        }
    }
}
namespace DomainAmbientHouse.Entidades
{
    public partial class CalculoIndexacion
    {
        public int CantidadDias { get; set; }

        public string FechaReserva { get; set; }

        public double SaldoIndexado { get; set; }

        public double Total { get; set; }

    }

}
