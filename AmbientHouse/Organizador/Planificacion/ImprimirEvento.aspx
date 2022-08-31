<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirEvento.aspx.cs" Inherits="AmbientHouse.Organizador.Planificacion.ImprimirEvento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evento</title>
    <link href="../../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <asp:Label ID="LabelNroPresupuesto" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="LabelNroEvento" runat="server" Text="" Visible="false"></asp:Label>

        <%
 
        
            DomainAmbientHouse.Servicios.EventosServicios eventos = new DomainAmbientHouse.Servicios.EventosServicios();
            DomainAmbientHouse.Servicios.PresupuestosServicios presupuestos = new DomainAmbientHouse.Servicios.PresupuestosServicios();
            DomainAmbientHouse.Servicios.AdministrativasServicios administrativa = new DomainAmbientHouse.Servicios.AdministrativasServicios();
            DomainAmbientHouse.Servicios.ClientesServicios clientes = new DomainAmbientHouse.Servicios.ClientesServicios();

            DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle detalleOrganizacion =
                                            new DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle();

            List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos> detalleProveedoresExternos =
                                            new List<DomainAmbientHouse.Entidades.OrganizacionPresupuestoProveedoresExternos>();

            List<DomainAmbientHouse.Entidades.PresupuestoDetalle> detallePresupuesto = new List<DomainAmbientHouse.Entidades.PresupuestoDetalle>();



            int PresupuestoId = Int32.Parse(LabelNroPresupuesto.Text.ToString());
            int EventoId = Int32.Parse(LabelNroEvento.Text.ToString());


            DomainAmbientHouse.Entidades.Eventos eventoSeleccionado = eventos.BuscarEvento(EventoId);

            DomainAmbientHouse.Entidades.ClientesBis cliente = clientes.BuscarCliente((int)eventoSeleccionado.ClienteBisId);


            DomainAmbientHouse.Entidades.OrganizacionPresupuestoDetalle detalle = eventos.BuscarOrganizacionDetallePorPresupuesto(PresupuestoId);

            string mail = "";
            string telefono = "";
            string direccion = "";
            string locacion = "";

            if (detalle != null)
            {

                mail = detalle.Mail;
                telefono = detalle.Tel;
                direccion = detalle.Direccion;
                locacion = detalle.LocacionOtra;


            }


            string ClienteNombre;
            string ClienteMail = "";
            string ClienteTelefono = "";

            if (cliente.ApellidoNombre != "")
            {
                ClienteNombre = cliente.ApellidoNombre.ToUpper();
            }
            else if (cliente.RazonSocial != "")
            {
                ClienteNombre = cliente.RazonSocial.ToUpper();
            }
            else
                ClienteNombre = "";

            if (mail == "")
                ClienteMail = cliente.MailContactoContratacion;

            if (telefono == "")
                ClienteTelefono = cliente.TelContactoContratacion;

            string ejecutivo = administrativa.BuscarEmpleado((int)eventoSeleccionado.EmpleadoId).ApellidoNombre;

            DomainAmbientHouse.Entidades.Presupuestos PresupuestoSeleccionado = eventos.BuscarPresupuesto(PresupuestoId);


            string cantidadAdultos = PresupuestoSeleccionado.CantidadInicialInvitados.ToString();

            string cantidadAdolescentes= "";
            if (PresupuestoSeleccionado.CantidadInvitadosAdolecentes != null) cantidadAdolescentes = PresupuestoSeleccionado.CantidadInvitadosAdolecentes.ToString();

            string cantidadInvitadosMenores3="";
            if (PresupuestoSeleccionado.CantidadInvitadosMenores3 != null) cantidadInvitadosMenores3 = PresupuestoSeleccionado.CantidadInvitadosMenores3.ToString();

            string cantidadInvitadosMenores3y8="";
            if (PresupuestoSeleccionado.CantidadInvitadosMenores3y8 != null) cantidadInvitadosMenores3y8 = PresupuestoSeleccionado.CantidadInvitadosMenores3y8.ToString();


            string FechaEvento = String.Format("{0:dd/MM/yyyy}", PresupuestoSeleccionado.FechaEvento);

            string DireccionLocacion = "";
            if (direccion != "")
                DireccionLocacion = direccion;
            else
                DireccionLocacion = PresupuestoSeleccionado.DireccionOtra;

            string locacionOtra = "";
            if (locacion != "")
                locacionOtra = locacion;
            else
                locacionOtra = PresupuestoSeleccionado.LocacionOtra;
                
            DomainAmbientHouse.Entidades.EmpleadosPresupuestosAprobados existeEquipo = administrativa.BuscarEquiposPorPresupuesto((int)PresupuestoId);

            int? OrganizadorId = 0;

            string organizador = "";
            
            if (existeEquipo != null)
                OrganizadorId = existeEquipo.OrganizadorId;

            if (OrganizadorId > 0)
                organizador = administrativa.BuscarEmpleado((int)OrganizadorId).ApellidoNombre;

            string Locacion = eventos.BuscarLocacion(PresupuestoSeleccionado.LocacionId).Descripcion;
            
            string TipoEvento = eventos.TraerTipoEvento().Where(o => o.Id == PresupuestoSeleccionado.TipoEventoId).Select(o => o.Descripcion).SingleOrDefault();

            string Caracteristica = eventos.TraerCaracteristicas().Where(o => o.Id == PresupuestoSeleccionado.CaracteristicaId).Select(o => o.Descripcion).SingleOrDefault();


            //TextBoxHoraInicio.Text = PresupuestoSeleccionado.HorarioEvento;
            //TextBoxHoraFin.Text = PresupuestoSeleccionado.HoraFinalizado;

            //TextBoxComentario.Text = PresupuestoSeleccionado.Comentario;

            //if (direccion != "")
            //    TextBoxDireccionLocacion.Text = direccion;
            //else
            //    TextBoxDireccionLocacion.Text = PresupuestoSeleccionado.DireccionOtra;

            //if (locacion != "")
            //    TextBoxLocacionOtra.Text = locacion;
            //else
            //    TextBoxLocacionOtra.Text = PresupuestoSeleccionado.LocacionOtra;


            detalleOrganizacion = eventos.BuscarOrganizacionDetallePorPresupuesto(PresupuestoId);

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Datos del Evento:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Nro. Presupuesto</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + PresupuestoId.ToString() + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Nro. Evento</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + EventoId.ToString() + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Fecha Evento</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + FechaEvento + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Locacion</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write( "<b>" + Locacion + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Ejecutivo</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + ejecutivo + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Organizador</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + organizador + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-12\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Motivo del festejo</label>");
            Response.Write("<div class=\"col-lg-12\">");
            Response.Write("<b>" + detalleOrganizacion.MotivoFestejo + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Hora Inicio:</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + PresupuestoSeleccionado.HorarioEvento + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Hora Fin:</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + PresupuestoSeleccionado.HoraFinalizado + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">OUT:</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + locacionOtra + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Direccion:</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + DireccionLocacion + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");



            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Datos del Cliente:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Nombre</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + ClienteNombre + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Telefono</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + ClienteTelefono + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Mail</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + ClienteMail + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Ejecutivo</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + ejecutivo + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Tipo Evento</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + TipoEvento + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Caracteristica</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + Caracteristica + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Cant. Adultos</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + cantidadAdultos + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Cant. Adolescentes</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + cantidadAdolescentes + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Cant. Menores entre 3 y 8</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + cantidadInvitadosMenores3y8 + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("<div class=\"form-group col-md-6\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\">Cant. Menores de 3</label>");
            Response.Write("<div class=\"col-lg-5\">");
            Response.Write("<b>" + cantidadInvitadosMenores3 + "</b>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            

            Response.Write("<div class=\"row\">");
            Response.Write("<div class=\"form-group col-md-12\">");
            Response.Write("<label for=\"ejemplo_email_3\" class=\"col-lg-5 control-label\" name=\"nombre\">Comentario del Presupuesto</label>");
            Response.Write("<div class=\"col-lg-12\">");
            Response.Write("<b>" + PresupuestoSeleccionado.Comentario + "</b>");
            Response.Write("<span class=\"help-block\"></span>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");

            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");




            detallePresupuesto = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 3 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Experiencias de Catering Elegida</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detallePresupuesto)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProductoDescripcion + " Cant. " + item.CantidadAdicional + " - Comentario:" + item.ComentarioProveedor + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            if (detalleOrganizacion.BocadosEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Bocados</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Bocados);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }
            if (detalleOrganizacion.IslasEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Islas</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Islas);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }
            if (detalleOrganizacion.EntradaEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Plato Entrada</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Entrada);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }
            if (detalleOrganizacion.PrincipalAdultosEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Principal Adultos</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.PrincipalAdultos);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }
            if (detalleOrganizacion.PrincipalAdolescentesEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Principal Adolescentes</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.PrincipalAdolescentes);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.PrincipalChicosEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Principal Menores</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.PrincipalChicos);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.PostreAdultosAdolescentesEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Postre para Adultos y Adolescentes:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.PostreAdultosAdolescentes);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.PostreChicosEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Postre Menores:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.PostreChicos);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.MesaDulceEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Mesa Dulce:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.MesaDulce);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.FinFiestaEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Fin de Fiesta</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.FinFiesta);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }
            if (detalleOrganizacion.TortaAlegoricaEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Torta Alegorica:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.TortaAlegorica);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }
            if (detalleOrganizacion.PlatosEspecialesEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Platos Especiales:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.PlatosEspeciales);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Platos Especiales:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.ObservacionCatering);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");



            detallePresupuesto = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 6 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Experiencias de Barras Elegida</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detallePresupuesto)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProductoDescripcion + " Cant. " + item.CantidadAdicional + " - Comentario:" + item.ComentarioProveedor + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            if (detalleOrganizacion.ServiciodeVinoChampagneEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Servicio de Vino y Champagne:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.ServiciodeVinoChampagne);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }


            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Observaciones:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.ObservacionBarras);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");


            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Particularidades/Observaciones:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");

            if (detalleOrganizacion.MesaPrincipalEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Mesa Principal:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.MesaPrincipal);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.ManteleriaEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Manteleria:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Manteleria);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.ServilletasEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Servilletas:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Servilletas);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.SillasEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Sillas:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Sillas);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.InvitadosDespues00Estado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Invitados despues de las 00Hs:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.InvitadosDespues00);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.CumpleaniosEnEventoEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Cumpleaños en el Evento:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.CumpleaniosEnEvento);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.LleganAlSalonEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Llegan al Salon:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.LleganAlSalon);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Observaciones:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.ObservacionParticulares);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            detallePresupuesto = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 2 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Experiencias de Tecnica Elegida</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detallePresupuesto)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProductoDescripcion + " Cant. " + item.CantidadAdicional + " - Comentario:" + item.ComentarioProveedor + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Observaciones</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.ObservacionTecnica);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            detallePresupuesto = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 1 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Experiencias de Ambientacion Elegida</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detallePresupuesto)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProductoDescripcion + " Cant. " + item.CantidadAdicional + " - Comentario:" + item.ComentarioProveedor + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Observaciones</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.ObservacionAmbientacion);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            detallePresupuesto = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 9 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Adicionales</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detallePresupuesto)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProductoDescripcion + " Cant. " + item.CantidadAdicional + " - Comentario:" + item.ComentarioProveedor + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Observaciones</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.ObservacionesAdicionales);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            detallePresupuesto = presupuestos.BuscarDetallePresupuesto(PresupuestoId).Where(o => o.UnidadNegocioId == 8 && (o.EstadoId == 24 || o.EstadoId == 43)).ToList();

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">OTRAS UNIDADES DE NEGOCIOS CONTRATADAS A TRAVES NUESTRO</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detallePresupuesto)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProductoDescripcion + " Cant. " + item.CantidadAdicional + " - Comentario:" + item.ComentarioProveedor + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Observaciones</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");


            detalleProveedoresExternos = administrativa.ObtenerProveedoresExternosPorPresupuesto(PresupuestoId);

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Proveedores Externos</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write("<ul class=\"list-group\">");
            foreach (var item in detalleProveedoresExternos)
            {
                Response.Write("<li class=\"list-group-item\"><h5>" + item.ProveedorExterno + " Rubro: " + item.Rubro + " Contacto: " + item.Contacto + " Correo:" + item.Correo + " Telefono:" + item.Telefono + "</h5></li>");
            }

            Response.Write("</ul>");
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");


            if (detalleOrganizacion.AcreditacionesEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Acreditaciones a Cargo de:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Acreditaciones);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.ListaInvitadosEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Lista de Invitados:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.ListaInvitados);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.ListaCocherasEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Lista de Cocheras:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.ListaCocheras);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.LayoutEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Layout:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Layout);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.AlfombraRojaEstado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Alfombra Roja:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.AlfombraRoja);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            if (detalleOrganizacion.Anexo7Estado)
            {
                Response.Write("<div class=\"card\" style=\"width: 100%;\">");
                Response.Write("<div class=\"card-header\">Anexo 7:</div>");
                Response.Write("<div class=\"card-body\">");
                Response.Write("<p class=\"card-text\">");
                Response.Write(detalleOrganizacion.Anexo7);
                Response.Write("</p>");
                Response.Write(" </div>");
                Response.Write("</div>");
            }

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Ramo:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.Ramo);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            Response.Write("<div class=\"card\" style=\"width: 100%;\">");
            Response.Write("<div class=\"card-header\">Escenario:</div>");
            Response.Write("<div class=\"card-body\">");
            Response.Write("<p class=\"card-text\">");
            Response.Write(detalleOrganizacion.Escenario);
            Response.Write("</p>");
            Response.Write(" </div>");
            Response.Write("</div>");

            
            

        %>




        <script src="../../Boostrap4/js/bootstrap.min.js"></script>
        <script src="../../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
        <script src="../../Boostrap4/js/popper.min.js"></script>
    </form>
</body>
</html>
