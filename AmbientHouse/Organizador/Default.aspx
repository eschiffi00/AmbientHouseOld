<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AmbientHouse.Organizador.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <asp:UpdatePanel ID="UpdatePanelInicio" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>

                    <td>

                        <div class="panel panel-primary">
                            <div class="panel-heading">Buscador (Presupuestos/Eventos) </div>

                            <div class="panel-body">

                                <table style="width: 100%;">
                                    <tr>
                                        <td>NRO. Evento:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroEventoBuscador" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>NRO. Presupuesto:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroPresupuestoBuscador" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
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
                                            <td>&nbsp;</td>
                                            <td>&nbsp;
                                                <asp:Button ID="ButtonEventoCerrados" runat="server" class="btn btn-primary" Text="Eventos Cerrados"  />&nbsp;|&nbsp;
                                                <asp:Button ID="ButtonEventoTransferido" runat="server" class="btn btn-success" Text="Evento Transferido"  />&nbsp;|&nbsp;
                                                <asp:Button ID="ButtonEventosReunionCliente" runat="server" class="btn btn-default" Text="Evento Reunion Cliente"  />&nbsp;|&nbsp;
                                                <asp:Button ID="ButtonEventoDegustacion" runat="server" class="btn btn-danger" Text="Evento Degustacion"  />&nbsp;|&nbsp;

                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                &nbsp;</td>

                                            <td>
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>

                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="panel-footer">
                            <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewEventosGanados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnRowDataBound="GridViewEventosGanados_RowDataBound" OnPageIndexChanging="GridViewEventosGanados_PageIndexChanging" OnRowCommand="GridViewEventosGanados_RowCommand">

                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Evenntos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                            <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuit" HeaderText="CUIT/CUIL" SortExpression="Cuit" />
                                            <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                            <asp:BoundField DataField="Celular" HeaderText="Tel" SortExpression="Celular" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="EstadoEvento" HeaderText="Estados" />

                                            <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/ReservarPresupuesto.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Reservar Presupuesto" />
                                            <asp:HyperLinkField DataNavigateUrlFormatString="~/Presupuestos/ReservarPresupuesto.aspx?EventoId={0}&PresupuestoId={1}" ControlStyle-CssClass="btn btn-primary" DataNavigateUrlFields="EventoId, PresupuestoId" Text="Confirmar Presupuesto" />

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ButtonImprirmir" runat="server" Text="Imprimir" ImageUrl="~/Content/Imagenes/imprimir.png" CommandName="Imprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                    <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>


                               
                                </ContentTemplate>
                               
                            </asp:UpdatePanel>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
