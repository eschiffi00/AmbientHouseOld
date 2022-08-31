<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AmbientHouse.Inicio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>

            <td>
                <div class="panel panel-info">
                    <div class="panel-heading">Objetivos </div>

                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <h4>
                                        <asp:Label ID="LabelEmpleado" runat="server"></asp:Label></h4>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <h3>Objetivo Mensual -  
                                                <asp:Label ID="LabelObjetivoMensual" runat="server"></asp:Label></h3>
                                </td>
                                <td>
                                    <h3>Q -  
                                                <asp:Label ID="LabelObjetivoQ" runat="server"></asp:Label></h3>
                                </td>

                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                        </table>
                    </div>
                </div>


                <div class="panel panel-primary">
                    <div class="panel-heading">Buscador (Presupuestos/Eventos) </div>

                    <div class="panel-body">

                        <table style="width: 100%;">
                            <tr>
                                <td>Apellido Cliente:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxApellidoBuscador" class="form-control" runat="server" Width="300px"></asp:TextBox></td>
                                <td>NRO. Evento:
                                    <asp:TextBox ID="TextBoxNroEventoBuscador" class="form-control" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Razon Social:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxRazonSocialBuscador" class="form-control" runat="server" Width="300px"></asp:TextBox></td>
                                <td>NRO. Presupuesto:
                                    <asp:TextBox ID="TextBoxNroPresupuestoBuscador" class="form-control" runat="server" Width="100px"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />&nbsp;|&nbsp;
                                    <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar Filtros de Busqueda" OnClick="ButtonLimpiar_Click" />

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>

                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanelBotones" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="ButtonNuevoEvento" runat="server" class="btn btn-primary" Text="Nuevo Evento" OnClick="ButtonNuevoEvento_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonEventosGuardados" runat="server" class="btn btn-default" Text="Evento Guardados" OnClick="ButtonEventosGuardados_Click" />&nbsp;|&nbsp;
                                        <asp:Button ID="ButtonEventosPendientes" runat="server" class="btn btn-warning" Text="Evento Pendientes" OnClick="ButtonEventosPendientes_Click" />&nbsp;|&nbsp;
                                        <asp:Button ID="ButtonEventoGanado" runat="server" class="btn btn-success" Text="Evento Ganado" OnClick="ButtonEventoGanado_Click" />&nbsp;|&nbsp;
                                        <asp:Button ID="ButtonVerPresupuestos" runat="server" class="btn btn-default" Text="Presupuestos Sistema Anterior" OnClick="ButtonVerPresupuestos_Click" /> &nbsp;|&nbsp;
                                        <asp:Button ID="ButtonVerCalendario" runat="server" class="btn btn-default" Text="Calendario" OnClick="ButtonVerCalendario_Click" />
                                        <asp:Button ID="ButtonEventoPerdido" runat="server" class="btn btn-danger" Text="Evento Perdido" OnClick="ButtonEventoPerdido_Click" Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonConfiguracion" runat="server" class="btn btn-default" OnClick="ButtonConfiguracion_Click" Text="Configuracion" />&nbsp;|&nbsp;
                                        <asp:Button ID="ButtonReportes" runat="server" class="btn btn-default" OnClick="ButtonReportes_Click" Text="Reportes" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonHerramientas" runat="server" class="btn btn-info" Text="Experiencias" OnClick="ButtonHerramientas_Click" />&nbsp;|&nbsp;
                                        <asp:Button ID="ButtonMisArchivos" runat="server" class="btn btn-info" Text="Mis Archivos" OnClick="ButtonMisArchivos_Click" />
                                    </td>

                                    <td>
                                        <asp:Button ID="ButtonAdministracion" runat="server" class="btn btn-info" Text="Administracion" OnClick="ButtonAdministracion_Click" />

                                        <asp:Button ID="ButtonRRHH" runat="server" class="btn btn-info" OnClick="ButtonRRHH_Click" Text="RRHH" />

                                    </td>
                                    <td>&nbsp;</td>
                                </tr>

                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel ID="UpdatePanelInicio" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="panel-heading">
                            <h3>Eventos</h3>

                            <h3>
                                <asp:Label ID="Label1" runat="server" Text="CANT. EVENTOS GUARDADOS: (@)"></asp:Label>&nbsp;|&nbsp;
                                  <asp:Label ID="Label2" runat="server" Text="CANT. EVENTOS PENDIENTES: (@)"></asp:Label>&nbsp;|&nbsp;
                                  <asp:Label ID="Label3" runat="server" Text="CANT. EVENTOS GANADOS: (@)"></asp:Label>&nbsp;|&nbsp;
                                

                            </h3>
                        </div>

                        <div class="panel-footer">

                            <asp:GridView ID="GridViewEventosGuardados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" DataKeyNames="EventoId,PresupuestoId" OnPageIndexChanging="GridViewEventosGuardados_PageIndexChanging" AllowSorting="True" OnRowDataBound="GridViewEventosGuardados_RowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="Black" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>

                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />
                                    <asp:BoundField DataField="PrecioTotalPresupuesto" HeaderText="Precio" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="CostoTotalPresupuesto" HeaderText="Costo" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="RentaTotalPresupuesto" HeaderText="Renta %" />
                                    <asp:BoundField DataField="RentaTotalNominal" HeaderText="Renta $" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="FechaCaducidad" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Caduca en" SortExpression="FechaCaducidad" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="ImageRojo" runat="server" Height="30px" ImageUrl="~/Content/Imagenes/rojo.png" Width="30px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/Nuevo.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Continuar Evento">
                                        <ControlStyle CssClass="btn btn-info" />
                                    </asp:HyperLinkField>
                                </Columns>

                            </asp:GridView>

                            <asp:GridView ID="GridViewEventosGuardadosEjecutivos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" DataKeyNames="EventoId,PresupuestoId" AllowSorting="True" OnPageIndexChanging="GridViewEventosGuardadosEjecutivos_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="Black" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>
                                    <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Seguimientos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Seguimientos" />--%>
                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />

                                    <asp:BoundField DataField="FechaCaducidad" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Caduca en" SortExpression="FechaCaducidad" />
                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/Nuevo.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Continuar Evento" />
                                </Columns>

                            </asp:GridView>

                            <asp:GridView ID="GridViewEventosPendientes" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewEventosPendientes_PageIndexChanging" OnRowDataBound="GridViewEventosPendientes_RowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#FE9A2E" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>
                                    <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Seguimientos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Seguimientos" />--%>
                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup." SortExpression="PresupuestoId" />
                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="EstadoEvento" HeaderText="Estado Evento" />
                                    <asp:BoundField DataField="EstadoPresupuesto" HeaderText="Estado Presup." />
                                    <asp:BoundField DataField="PrecioTotalPresupuesto" HeaderText="Precio" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="CostoTotalPresupuesto" HeaderText="Costo" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="RentaTotalPresupuesto" HeaderText="Renta %" />
                                    <asp:BoundField DataField="RentaTotalNominal" HeaderText="Renta $" DataFormatString="{0:C0}" />
                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/GestionPorEvento.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId" Text="Ver" />
                                </Columns>

                            </asp:GridView>

                            <asp:GridView ID="GridViewEventosPendientesEjecutivos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewEventosPendientes_PageIndexChanging" OnRowDataBound="GridViewEventosPendientesEjecutivos_RowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#FE9A2E" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>
                                    <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Seguimientos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Seguimientos" />--%>
                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="EstadoEvento" HeaderText="Estado Evento" />
                                    <asp:BoundField DataField="EstadoPresupuesto" HeaderText="Estado Presup." />

                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/GestionPorEvento.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId" Text="Ver" />
                                </Columns>

                            </asp:GridView>

                            <asp:GridView ID="GridViewEventosGanados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewEventosGanados_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>
                                    <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Seguimientos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Seguimientos" />--%>
                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" />

                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />


                                    <%--<asp:HyperLinkField DataNavigateUrlFormatString="~/Eventos/GenerarPresupuestos.aspx?ClienteId={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Generar Reserva" />--%>
                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Vender Adicionales" />

                                    <%--   <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/Nuevo.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Continuar Evento">
                                        <ControlStyle CssClass="btn btn-info" />
                                    </asp:HyperLinkField>--%>

                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Recibos/Editar.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-warning" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Imprimir Recibo" />
                                </Columns>

                            </asp:GridView>


                            <asp:GridView ID="GridViewEventosGanadosEjecutivos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewEventosGanados_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>
                                    <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Seguimientos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Seguimientos" />--%>
                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" />

                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />


                                    <%--<asp:HyperLinkField DataNavigateUrlFormatString="~/Eventos/GenerarPresupuestos.aspx?ClienteId={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Generar Reserva" />--%>
                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Vender Adicionales" />

                                    <%--    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/Nuevo.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Continuar Evento">
                                        <ControlStyle CssClass="btn btn-info" />
                                    </asp:HyperLinkField>--%>

                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/EditarPresupuestosGanados.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-warning" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Imprimir Recibo" />
                                </Columns>

                            </asp:GridView>
                            <asp:GridView ID="GridViewEventosPerdidos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewEventosPerdidos_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <HeaderStyle BackColor="#B40404" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay clientes con los parametros seleccionados!  
                                </EmptyDataTemplate>

                                <%--Paginador...--%>
                                <%--<PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="50px" CssClass="form-control"></asp:DropDownList></h3>                               
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>--%>
                                <Columns>
                                    <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Seguimientos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Seguimientos" />--%>
                                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estados" />


                                    <%--    <asp:HyperLinkField DataNavigateUrlFormatString="~/Eventos/GenerarPresupuestos.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Eventos" />
                            <asp:HyperLinkField DataNavigateUrlFormatString="~/Contactos/Index.aspx?ClienteId={0}" DataNavigateUrlFields="Id" Text="Contactos" />--%>
                                </Columns>

                            </asp:GridView>

                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ButtonBuscar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ButtonEventosGuardados" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ButtonEventosPendientes" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ButtonEventoGanado" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
