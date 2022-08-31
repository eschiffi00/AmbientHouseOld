using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections.Generic;
using DomainAmbientHouse.Entidades;
using System.Configuration;
using DomainAmbientHouse.Negocios;

namespace DomainAmbientHouse.Servicios
{
    public class Mail
    {
        EventosServicios servicios = new EventosServicios();
        AdministrativasServicios administrativas = new AdministrativasServicios();
        Comun cmd = new Comun();

        public void envioMailAprobadoComercial(int PresupuestoId, int EventoId)
        {
            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();


            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);
            ListadoMailsComerciales(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);

            //string[] mails = ConfigurationManager.AppSettings["emailAprobacion"].Split(';');

            string Mensaje = GenerarMensajeCerrado(PresupuestoId, EventoId);

            foreach (var item in mails)
            {

                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(item.ToString()));
                email.From = new MailAddress(mailfrom);
                email.Subject = "EVENTO CERRADO";
                email.Body = Mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = puerto;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailfrom, password);
                string output = null;

                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

            }

        }

        public void envioMailAprobadoAdministracion(int PresupuestoId, int EventoId)
        {

            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();


            List<string> mails = new List<string>();

            ListadoMailsSistemas(mails);
            ListadoMailsAdministracion(mails);
            ListadoMailsComerciales(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);

            //string[] mails = ConfigurationManager.AppSettings["emailCerrado"].Split(';');

            string Mensaje = GenerarMensajeReservado(PresupuestoId, EventoId);

            foreach (var item in mails)
            {

                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(item.ToString()));
                email.From = new MailAddress(mailfrom);
                email.Subject = "EVENTO RESERVADO";
                email.Body = Mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = puerto;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailfrom, password);
                string output = null;

                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

            }



        }

        public void envioMailCambiosEventoGanado(int PresupuestoId, int EventoId, string Producto)
        {

            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();

            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);



            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');

            string Mensaje = GenerarMensajeCambiosEvento(PresupuestoId, EventoId, Producto);

            foreach (var item in mails)
            {

                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(item.ToString()));
                email.From = new MailAddress(mailfrom);
                email.Subject = "CAMBIOS EVENTO GANADO";
                email.Body = Mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = puerto;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailfrom, password);
                string output = null;

                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

            }



        }

        public void envioMailCambioInvitados(int PresupuestoId, int EventoId)
        {

            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();

            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);

            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');

            string Mensaje = GenerarMensajeCambioInvitados(PresupuestoId, EventoId);

            foreach (var item in mails)
            {

                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(item.ToString()));
                email.From = new MailAddress(mailfrom);
                email.Subject = "ACTUALIZACION INVITADOS EVENTO GANADO";
                email.Body = Mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = puerto;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailfrom, password);
                string output = null;

                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

            }

        }

        public void CambioFecha(int PresupuestoId, int EventoId, DateTime fechaAnterior, string horaInicioAnterior, string horaFinAnterior)
        {

            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();

            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);
            ListadoMailsComerciales(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);


            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');
            string Asunto = "";
            string Mensaje = GenerarMensajeCambioFechaHorarios(PresupuestoId, EventoId, fechaAnterior, ref Asunto, horaInicioAnterior, horaFinAnterior);

            if (Mensaje != "")
            {
                foreach (var item in mails)
                {

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(item.ToString()));
                    email.From = new MailAddress(mailfrom);
                    email.Subject = Asunto;
                    email.Body = Mensaje;
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.Port = puerto;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailfrom, password);
                    string output = null;

                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }

                }
            }
        }

        public void CambioHora(int PresupuestoId, int EventoId, string HoraInicioAnterior, string HoraFinAnterior)
        {
            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();

            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);
            ListadoMailsComerciales(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);
            ListadoMailsSistemas(mails);

            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');
            string Asunto = "";
            string Mensaje = GenerarMensajeHorariosOrganizacion(PresupuestoId, EventoId, ref Asunto, HoraInicioAnterior, HoraFinAnterior);

            if (Mensaje != "")
            {
                foreach (var item in mails)
                {

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(item.ToString()));
                    email.From = new MailAddress(mailfrom);
                    email.Subject = Asunto;
                    email.Body = Mensaje;
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.Port = puerto;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailfrom, password);
                    string output = null;

                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }

                }
            }

            //SmtpClient smtpClient = new SmtpClient();
            //NetworkCredential basicCredential = new NetworkCredential(username, password);
            //MailMessage message = new MailMessage();
            //MailAddress fromAddress = new MailAddress(from);

            //smtpClient.Host = host;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = basicCredential;

            //message.From = fromAddress;
            //message.Subject = subject;
            //message.IsBodyHtml = true;
            //message.Body = body;
            //message.To.Add(tto);

            //try
            //{
            //    smtpClient.Send(message);
            //}
            //catch (Exception ex)
            //{
            //    //Si hay error lo muestra
            //    Response.Write(ex.Message);
            //}
        }

        public void envioMailCambioInvitadosOrganizacion(int PresupuestoId, int EventoId)
        {
            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();


            List<string> mails = new List<string>();

            ListadoMailsComerciales(mails);

            ListadoMailsAdministracion(mails);

            ListadoMailsOperaciones(mails);

            ListadoMailsOrganizacion(mails);


            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');
            string Asunto = "";
            string Mensaje = GenerarMensajeCambioInvitadosOrganizacion(PresupuestoId, EventoId, ref Asunto);

            if (Mensaje != "")
            {
                foreach (var item in mails)
                {

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(item.ToString()));
                    email.From = new MailAddress(mailfrom);
                    email.Subject = Asunto;
                    email.Body = Mensaje;
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.Port = puerto;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailfrom, password);
                    string output = null;

                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }

                }
            }
        }

        public void envioMailAlertaMailPresentacion(int EventoId, int PresupuestoId)
        {
            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();


            List<string> mails = new List<string>();


            ListadoMailsOrganizacion(mails);

            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');
            string Asunto = "";
            string Mensaje = GenerarMailAlertaOrganizacionPresentacion(EventoId, PresupuestoId);

            if (Mensaje != "")
            {
                foreach (var item in mails)
                {

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(item.ToString()));
                    email.From = new MailAddress(mailfrom);
                    email.Subject = Asunto;
                    email.Body = Mensaje;
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.Port = puerto;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailfrom, password);
                    string output = null;

                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }

                }
            }
        }

        public void EnvioMailAjustes(int PresupuestoId, int EventoId)
        {
            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();

            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);

            string Asunto = "Ajuste Presupuesto";
            string Mensaje = GenerarMensajeMailAjustes(PresupuestoId, EventoId);

            if (Mensaje != "")
            {
                foreach (var item in mails)
                {

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(item.ToString()));
                    email.From = new MailAddress(mailfrom);
                    email.Subject = Asunto;
                    email.Body = Mensaje;
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.Port = puerto;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailfrom, password);
                    string output = null;

                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }

                }
            }
        }

        private string GenerarMensajeMailAjustes(int PresupuestoId, int EventoId)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);


            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
               "</b> fue Modificado por Administracion. </br> El mismo debera ser controlado en la opcion de Precios y Costos. Ya que sufrio modificaciones en dichos Items.</br>" +
              " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
              " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
              " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
              " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
              " Sector: <b>" + ValidarSector(Presu) + "</b></br>" +
              " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>";


            return Mensaje;
        }

        private string GenerarMailAlertaOrganizacionPresentacion(int EventoId, int PresupuestoId)
        {
            return "Alerta";

            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);

            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                "</b> fue Cerrado por el ejecutivo. </br> El mismo debera ser controlado y reservado por Administracion para poder ser visualizado en el Calendario de Eventos. </br>" +
               " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
               " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
               " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
               " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
               " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
               " Sector: <b>" + ValidarSector(Presu) + "</b></br>" +
               " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
               " Cantidad Invitados: <b>" + CalcularCantidadInvitados(Presu.CantidadInicialInvitados.ToString(), Presu.CantidadInvitadosMenores3y8.ToString(), Presu.CantidadInvitadosMenores3.ToString(), Presu.CantidadInvitadosAdolecentes.ToString()).ToString() + "</b></br>";


            return Mensaje;

        }

        public void envioMailModificacionArchivos(OrganizacionPresupuestosArchivos archivos)
        {
            string host = ConfigurationManager.AppSettings["Host"].ToString();
            int puerto = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            string mailfrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
            string password = ConfigurationManager.AppSettings["PWD"].ToString();

            List<string> mails = new List<string>();

            ListadoMailsAdministracion(mails);
            ListadoMailsComerciales(mails);
            ListadoMailsOperaciones(mails);
            ListadoMailsOrganizacion(mails);


            //string[] mails = ConfigurationManager.AppSettings["emailCambios"].Split(';');
            string Asunto = "";
            string Mensaje = GenerarMensajeCambioArchivodOrganizacion(archivos, ref Asunto);

            if (Mensaje != "")
            {
                foreach (var item in mails)
                {

                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(item.ToString()));
                    email.From = new MailAddress(mailfrom);
                    email.Subject = Asunto;
                    email.Body = Mensaje;
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.Port = puerto;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(mailfrom, password);
                    string output = null;

                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }

                }
            }
        }

        private string GenerarMensajeCambioArchivodOrganizacion(OrganizacionPresupuestosArchivos archivos, ref string Asunto)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(archivos.PresupuestoId);

            Eventos Evento = negociosEventos.BuscarEvento(Presu.EventoId);

            string Mensaje = "El Presupuesto: <b>" + archivos.PresupuestoId.ToString() +
                    " Nro. Evento: <b>" + Evento.Id.ToString() + "</b></br>" +
                    " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                    " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                    " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
                    " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                    " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                    " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                    " Cantidad Adolescentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                    " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                    " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                    " <p style='color:red;'> EL ARCHIVO: " + archivos.NombreArchivo + " FUE MODIFICADO POR: " + ValidarEmpleado(archivos.EmpleadoId) + ". </p>" +
                    " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

            Asunto = "ARCHIVO MODIFICADO ORGANIZACION";

            return Mensaje;


        }

        private string GenerarMensajeCerrado(int PresupuestoId, int EventoId)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);

            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                "</b> fue Cerrado por el ejecutivo. </br> El mismo debera ser controlado y reservado por Administracion para poder ser visualizado en el Calendario de Eventos. </br>" +
               " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
               " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
               " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
               " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
               " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
               " Sector: <b>" + ValidarSector(Presu) + "</b></br>" +
               " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
               " Cantidad Invitados: <b>" + CalcularCantidadInvitados(Presu.CantidadInicialInvitados.ToString(), Presu.CantidadInvitadosMenores3y8.ToString(), Presu.CantidadInvitadosMenores3.ToString(), Presu.CantidadInvitadosAdolecentes.ToString()).ToString() + "</b></br>";


            return Mensaje;

        }

        private string GenerarMensajeReservado(int PresupuestoId, int EventoId)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);

            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
               "</b> fue Reservado en Calendario por Administracion. </br> La fecha fue bloqueada en el calendario para comenzar la organizacion, operacion y produccion de dicho evento.</br>" +
               " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
               " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
               " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
               " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
               " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
               " Sector: <b>" + ValidarSector(Presu) + "</b></br>" +
               " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
               " Cantidad Invitados: <b>" + CalcularCantidadInvitados(Presu.CantidadInicialInvitados.ToString(), Presu.CantidadInvitadosMenores3y8.ToString(), Presu.CantidadInvitadosMenores3.ToString(), Presu.CantidadInvitadosAdolecentes.ToString()).ToString() + "</b></br>" +
               " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

            return Mensaje;

        }

        private string GenerarMensajeCambiosEvento(int PresupuestoId, int EventoId, string producto)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);


            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                           "</b> sufrio modificaciones." +
                           " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                           " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                           " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                           " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
                           " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                           " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                           " Cantidad Invitados: <b>" + CalcularCantidadInvitados(Presu.CantidadInicialInvitados.ToString(), Presu.CantidadInvitadosMenores3y8.ToString(), Presu.CantidadInvitadosMenores3.ToString(), Presu.CantidadInvitadosAdolecentes.ToString()).ToString() + "</b></br>" +
                           " Cambio: <b>" + (producto != null ? producto.ToUpper() : "Ver Presupuesto") + "</b></br>" +
                           " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";


            return Mensaje;

        }

        private string GenerarMensajeCambioInvitados(int PresupuestoId, int EventoId)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);


            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                    "</b> fue Reservado en Calendario por Administracion. </br> La fecha fue bloqueada en el calendario para comenzar la organizacion, operacion y produccion de dicho evento.</br>" +
                    " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                    " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                    " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                    " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
                    " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                    " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                    " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                    " Cantidad Adolescentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                    " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                    " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                    " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";



            return Mensaje;

        }

        private string GenerarMensajeCambioFechaHorarios(int PresupuestoId, int EventoId, DateTime fechaAnterior, ref string Asunto, string horaInicioAnterior, string horaFinAnterior)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);

            string Mensaje = "";

            if (Presu.FechaEvento != fechaAnterior && (Presu.HorarioEvento != horaInicioAnterior || Presu.HoraFinalizado != horaFinAnterior))
            {
                Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                        "</b> , ha cambiado de fecha. </br>" +
                        " La fecha era: <b>" + String.Format("{0:dd/MM/yyyy}", fechaAnterior) + "<?b>. </br> La fecha nueva es: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b> fue bloqueada en el calendario.</br>" +
                        " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                        " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                        " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                        " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                        " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                        " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                        " Cantidad Adolecentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                        " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                        " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                        " Hora de Inicio Anterior: <b>" + horaInicioAnterior.ToString() + "</b></br>" +
                        " Hora Fin Anterior: <b>" + horaFinAnterior.ToString() + "</b></br>" +
                        " Hora de Inicio Nueva: <b>" + Presu.HorarioEvento.ToString() + "</b></br>" +
                        " Hora Fin Nueva: <b>" + Presu.HoraFinalizado.ToString() + "</b></br>" +
                        " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

                Asunto = "CAMBIO FECHA Y HORA";
            }
            else if (Presu.FechaEvento != fechaAnterior)
            {
                Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                        "</b> , ha cambiado de fecha. </br>" +
                        " La fecha era: <b>" + String.Format("{0:dd/MM/yyyy}", fechaAnterior) + "<?b>. </br> La fecha nueva es: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b> fue bloqueada en el calendario.</br>" +
                        " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                        " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                        " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                        " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                        " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                        " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                        " Cantidad Adolecentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                        " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                        " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                        " Hora de Inicio: <b>" + Presu.HorarioEvento.ToString() + "</b></br>" +
                        " Hora Fin: <b>" + Presu.HoraFinalizado.ToString() + "</b></br>" +
                        " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

                Asunto = "CAMBIO FECHA";
            }
            else if (Presu.HorarioEvento != horaInicioAnterior || Presu.HoraFinalizado != horaFinAnterior)
            {
                Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                            "</b> , ha cambiado el Horario. </br>" +
                            " La fecha es: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b> ,fue bloqueada en el calendario.</br>" +
                            " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                            " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                            " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                            " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                            " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                            " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                            " Cantidad Adolecentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                            " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                            " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                            " Hora de Inicio Anterior: <b>" + horaInicioAnterior.ToString() + "</b></br>" +
                            " Hora Fin Anterior: <b>" + horaFinAnterior.ToString() + "</b></br>" +
                            " Hora de Inicio Nueva: <b>" + Presu.HorarioEvento.ToString() + "</b></br>" +
                            " Hora Fin Nueva: <b>" + Presu.HoraFinalizado.ToString() + "</b></br>" +
                            " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

                Asunto = "CAMBIO HORARIO";
            }


            return Mensaje;

        }

        private string GenerarMensajeHorariosOrganizacion(int PresupuestoId, int EventoId, ref string Asunto, string horaInicioAnterior, string horaFinAnterior)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);

            string Mensaje = "";


            if (Presu.HorarioEvento != horaInicioAnterior || Presu.HoraFinalizado != horaFinAnterior)
            {
                Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                            "</b> , ha cambiado el Horario. </br>" +
                            " La fecha es: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b> ,fue bloqueada en el calendario.</br>" +
                            " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                            " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                            " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                            " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                            " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                            " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                            " Cantidad Adolecentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                            " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                            " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                            " Hora de Inicio Anterior: <b>" + horaInicioAnterior.ToString() + "</b></br>" +
                            " Hora Fin Anterior: <b>" + horaFinAnterior.ToString() + "</b></br>" +
                            " Hora de Inicio Nueva: <b>" + Presu.HorarioEvento.ToString() + "</b></br>" +
                            " Hora Fin Nueva: <b>" + Presu.HoraFinalizado.ToString() + "</b></br>" +
                            " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

                Asunto = "CAMBIO HORARIO POR ORGANIZACION";
            }


            return Mensaje;

        }

        private string GenerarMensajeCambioInvitadosOrganizacion(int PresupuestoId, int EventoId, ref string Asunto)
        {
            PresupuestosNegocios negociosPresupuesto = new PresupuestosNegocios();

            EventosNegocios negociosEventos = new EventosNegocios();

            Eventos Evento = negociosEventos.BuscarEvento(EventoId);

            Presupuestos Presu = negociosPresupuesto.BuscarPresupuesto(PresupuestoId);


            string Mensaje = "El Presupuesto: <b>" + PresupuestoId.ToString() +
                    "</b> fue Reservado en Calendario por Administracion. </br> La fecha fue bloqueada en el calendario para comenzar la organizacion, operacion y produccion de dicho evento.</br>" +
                    " Nro. Evento: <b>" + EventoId.ToString() + "</b></br>" +
                    " Cliente: <b>" + ValidarCliente(Evento) + "</b></br>" +
                    " Ejecutivo: <b>" + ValidarEjecutivo(Evento) + "</b></br>" +
                    " Fecha Evento: <b>" + String.Format("{0:dd/MM/yyyy}", Presu.FechaEvento) + "</b></br>" +
                    " Locacion: <b>" + ValidarLocacion(Presu) + "</b></br>" +
                    " Tipo Evento: <b>" + ValidarTipoCatering(Presu) + "</b></br>" +
                    " Cantidad Adultos: <b>" + Presu.CantidadInicialInvitados.ToString() + "</b></br>" +
                    " Cantidad Adolescentes: <b>" + Presu.CantidadInvitadosAdolecentes.ToString() + "</b></br>" +
                    " Cantidad Entre 3 y 8: <b>" + Presu.CantidadInvitadosMenores3y8.ToString() + "</b></br>" +
                    " Cantidad Menores de 3: <b>" + Presu.CantidadInvitadosMenores3.ToString() + "</b></br>" +
                    " <b> Este es sólo un aviso, para buscar la última información actualizada sobre este evento diríjase al sistema. </b>";

            Asunto = "CAMBIO INVITADOS ORGANIZACION";

            return Mensaje;

        }

        private int CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {
            return Int32.Parse(cmd.CalcularCantidadInvitados(pCantidadAdultos, pCantidadInvitadosEntre3y8, pCantidadInvitadosMenores3, pCantidadInvitadosAdolecentes).ToString());

        }

        private string ValidarTipoCatering(Presupuestos presupuesto)
        {

            TipoEventosNegocios negocios = new TipoEventosNegocios();

            TipoEventos te = negocios.BuscarTipoEvento(presupuesto.TipoEventoId);

            if (te != null)
            {
                return te.Descripcion.ToUpper();
            }
            else
                return "";
        }

        private string ValidarSector(Presupuestos presupuesto)
        {


            if (presupuesto.SectorId != null)
            {

                int sector = (int)presupuesto.SectorId;

                Sectores sec = servicios.BuscarSector(sector);
                if (sec != null)
                {
                    return sec.Descripcion.ToUpper();
                }
                else
                    return "";


            }
            return "";
        }

        private string ValidarLocacion(Presupuestos presupuesto)
        {

            LocacionesNegocios negocios = new LocacionesNegocios();

            Locaciones locacion = negocios.BuscarLocaciones(presupuesto.LocacionId);

            if (locacion != null)
            {
                return locacion.Descripcion.ToUpper();
            }
            else
                return "";
        }

        private object ValidarEmpleado(int empleadoId)
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            Empleados empleado = negocios.BuscarEmpleado(empleadoId);

            if (empleado != null)
            {
                return empleado.ApellidoNombre.ToUpper();
            }
            else
                return "";
        }

        private string ValidarEjecutivo(Eventos evento)
        {
            EmpleadosNegocios negocios = new EmpleadosNegocios();

            Empleados empleado = negocios.BuscarEmpleado(evento.EmpleadoId);

            if (empleado != null)
            {
                return empleado.ApellidoNombre.ToUpper();
            }
            else
                return "";
        }

        private string ValidarCliente(Eventos evento)
        {

            ClientesNegocios negociosClientes = new ClientesNegocios();


            ClientesBis cliente = negociosClientes.BuscarCliente((int)evento.ClienteBisId);

            if (cliente.ApellidoNombre != "")
            {
                return cliente.ApellidoNombre.ToUpper();
            }
            else if (cliente.RazonSocial != "")
            {
                return cliente.RazonSocial.ToUpper();
            }
            else
                return "";


        }

        private static void ListadoMailsOrganizacion(List<string> mails)
        {
            //Organizadoras
            mails.Add("georginap@edificiolahusen.com.ar");
            mails.Add("roxana@edificiolahusen.com.ar");

        }

        private static void ListadoMailsOperaciones(List<string> mails)
        {
            //Operaciones

            mails.Add("cynthia@grupolahusen.com.ar");
            mails.Add("angel@grupoambient.com.ar");
            mails.Add("carina@ambienthouse.com.ar");
            mails.Add("leonel@edificiolahusen.com.ar");
            mails.Add("soledad@edificiolahusen.com.ar");
        }

        private static void ListadoMailsAdministracion(List<string> mails)
        {
            //Administracion
            mails.Add("administracion@edificiolahusen.com.ar");
            mails.Add("nahuel@grupolahusen.com.ar");
            mails.Add("alejandro@edificiolahusen.com.ar");
        }

        private static void ListadoMailsComerciales(List<string> mails)
        {
            //Comerciales
            mails.Add("lucas@ambienthouse.com.ar");
            mails.Add("martin.aliandri@ambienthouse.com.ar");
            mails.Add("florencia@edificiolahusen.com.ar");
            mails.Add("hernanrimoli@ambienthouse.com.ar");
            mails.Add("damiancolombi@ambienthouse.com.ar");
            mails.Add("angeles@grupolahusen.com.ar");

        }

        private static void ListadoMailsCall(List<string> mails)
        {
            //CAll
            mails.Add("daiana@edificiolahusen.com.ar");
            mails.Add("ignacio@edificiolahusen.com.ar");
        }

        private static void ListadoMailsSistemas(List<string> mails)
        {
            //Sistemas
            mails.Add("diegostrevezza@hotmail.com");

        }
    }
}