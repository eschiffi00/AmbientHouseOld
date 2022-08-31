<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="AmbientHouse.Inicio.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">


    <div class="panel panel-primary">
        <div class="panel-heading">Buscador (Presupuestos/Eventos) </div>

        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>Apellido Cliente:</td>
                    <td>
                        <asp:TextBox ID="TextBoxApellidoBuscador" class="form-control" runat="server" Width="300px" AutoPostBack="True" OnTextChanged="TextBoxApellidoBuscador_TextChanged"></asp:TextBox>
                    </td>
                    <td>NRO. Evento:
                        <asp:TextBox ID="TextBoxNroEventoBuscador" class="form-control" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Razon Social:</td>
                    <td>
                        <asp:TextBox ID="TextBoxRazonSocialBuscador" class="form-control" runat="server" Width="300px" AutoPostBack="True" OnTextChanged="TextBoxRazonSocialBuscador_TextChanged"></asp:TextBox></td>
                    <td>NRO. Presupuesto:
                    <asp:TextBox ID="TextBoxNroPresupuestoBuscador" class="form-control" runat="server" Width="100px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Fecha Evento:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFecha" class="form-control" runat="server" Width="200px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>

        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelBotones" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="ButtonNuevoEvento" runat="server" class="btn btn-primary" Text="Nuevo Evento" OnClick="ButtonNuevoEvento_Click" />&nbsp;|&nbsp;
                                <asp:Button ID="ButtonBuscarEventos" runat="server" class="btn btn-info" Text="Buscar" OnClick="ButtonBuscarEventos_Click" />&nbsp;|&nbsp;
                                <asp:Button ID="ButtonDegustacion" runat="server" class="btn btn-warning" Text="Degustacion" OnClick="ButtonDegustacion_Click" />
                            </td>
                            <td>&nbsp;<asp:Button ID="ButtonVerCalendario" runat="server" class="btn btn-default" Text="Calendario" OnClick="ButtonVerCalendario_Click" />
                            </td>
                            <td>&nbsp;<asp:Button ID="ButtonStock" runat="server" class="btn btn-danger" Text="Stock" OnClick="ButtonStock_Click" />
                            </td>
                            <td>&nbsp;</td>

                        </tr>

                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="panel-body">
            <asp:UpdateProgress ID="UpdateProgressGrilla" runat="server">
                <ProgressTemplate>
                    <div style="text-align: center">
                        <img src="../Content/Imagenes/loading.gif" style="text-align: center" />
                    </div>
                </ProgressTemplate>

            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="PanelCarga" runat="server">

                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <%--<iframe src="http://docs.google.com/viewer?url=http%3A%2F%2Fmeridadesign.com%2Fdemos%2Fquotes.ppsx&embedded=true" width="600" height="300" style="border: none;"></iframe>--%>
                    <asp:Panel ID="PanelGrillas" runat="server">

                        <asp:GridView ID="GridViewEventosGerencial" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" DataKeyNames="EventoId,PresupuestoId" AllowSorting="True" OnRowDataBound="GridViewEventosGerencial_RowDataBound" OnRowCommand="GridViewEventosGerencial_RowCommand" OnPageIndexChanging="GridViewEventosGerencial_PageIndexChanging">
                            <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                            <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="Black" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Eventos con los parametros seleccionados!  
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
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
                                <asp:BoundField DataField="FechaCaducidad" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Caduca en" SortExpression="FechaCaducidad" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="ImageRojo" runat="server" Height="30px" ImageUrl="~/Content/Imagenes/rojo.png" Width="30px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonContinuarEvento" runat="server" class="btn btn-default" Text="Continuar Evento" CommandName="Continuar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Button ID="ButtonVer" runat="server" class="btn btn-warning" Text="Ver" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Button ID="ButtonVenderAdicionales" runat="server" class="btn btn-success" Text="Vender Adicionales" CommandName="VenderAdicionales" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:ImageButton ID="ImageButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="VerLupa" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                        <br />
                                        <asp:Button ID="ButtonEstablecerInvitados" runat="server" class="btn btn-primary" Text="Establecer Invitados" CommandName="Invitados" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                    </ItemTemplate>
                                </asp:TemplateField>



                            </Columns>

                        </asp:GridView>

                        <asp:GridView ID="GridViewEventosEjecutivos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" DataKeyNames="EventoId,PresupuestoId" AllowSorting="True" OnRowCommand="GridViewEventosEjecutivos_RowCommand" OnRowDataBound="GridViewEventosEjecutivos_RowDataBound" OnPageIndexChanging="GridViewEventosEjecutivos_PageIndexChanging">
                            <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                            <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="Black" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Eventos con los parametros seleccionados!  
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                                <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                <asp:BoundField DataField="EstadoEvento" HeaderText="Estado Evento" />
                                <asp:BoundField DataField="EstadoPresupuesto" HeaderText="Estado Presup." />
                                <asp:BoundField DataField="FechaCaducidad" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Caduca en" SortExpression="FechaCaducidad" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonContinuarEvento" runat="server" class="btn btn-default" Text="Continuar Evento" CommandName="Continuar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Button ID="ButtonVer" runat="server" class="btn btn-warning" Text="Ver" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Button ID="ButtonVenderAdicionales" runat="server" class="btn btn-success" Text="Vender Adicionales" CommandName="VenderAdicionales" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:ImageButton ID="ImageButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="VerLupa" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                        <br />
                                        <asp:Button ID="ButtonEstablecerInvitados" runat="server" class="btn btn-primary" Text="Establecer Invitados" CommandName="Invitados" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </asp:Panel>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ButtonBuscarEventos" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </div>


</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
