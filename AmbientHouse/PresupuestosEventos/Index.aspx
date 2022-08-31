<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.PresupuestosEventos.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>EVENTO NRO.
                <asp:Label ID="LabelNroEvento" runat="server" Text=""></asp:Label></h3>
            <br />
        </div>
        <div class="panel-body">
            <asp:GridView ID="GridViewPresupuestos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True">
                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <EmptyDataTemplate>
                    ¡No hay Costos con los parametros seleccionados!  
                </EmptyDataTemplate>

                <Columns>

                    <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                    <asp:BoundField DataField="ClienteId" HeaderText="Nro. Cliente" SortExpression="ClienteId" />
                    <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" />
                   
                  
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Panel ID="PanelDatosEvento" runat="server" GroupingText="Datos Evento">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Cliente</td>
                                      
                                         <td>Locacion</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                          <td>
                                            <asp:TextBox ID="TextBoxCliente" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxLocacion" runat="server"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Tipo Evento</td>
                                        <td>Fecha Evento</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                     <tr>
                                          <td>
                                            <asp:TextBox ID="TextBoxTipoEvento" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFechaEvento" runat="server"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                      <tr>
                                        <td>Caracteristica</td>
                                        <td>Cant. Invitados</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                     <tr>
                                          <td>
                                            <asp:TextBox ID="TextBoxCaracteristica" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCantInvitados" runat="server"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>

                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="EstadoPresupuesto" HeaderText="Estados" />

                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:ImageButton ID="ButtonImprirmir" runat="server" Text="Imprimir" ImageUrl="~/Content/Imagenes/imprimir.png" CommandName="Imprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                            <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                            <asp:ImageButton ID="ImageDescuentos" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/Ajuste.png" CommandName="Descuentos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />
                            <asp:ImageButton ID="ImageRepresupuestar" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/refresh.png" CommandName="Represupuestar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
