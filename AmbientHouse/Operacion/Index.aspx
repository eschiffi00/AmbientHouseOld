<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Operacion.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelInicio" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>

                    <td></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <div class="panel-footer">
                            <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewEventosGanados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewEventosGanados_RowCommand" OnRowDataBound="GridViewEventosGanados_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#04B404" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay clientes con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="EventoId" HeaderText="Nro. Evento" SortExpression="EventoId" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Presupuesto" SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />

                                            <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                            <asp:BoundField DataField="SECTOR" HeaderText="Sector" SortExpression="SECTOR" />
                                            <asp:BoundField DataField="JORNADA" HeaderText="Jornada" SortExpression="JORNADA" />
                                            <asp:BoundField DataField="CantidadInicialInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInicialInvitados" />
                                            <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" SortExpression="FechaEvento" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />

                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Organizador" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelOrganizador" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Coordinador 1" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelCoordinador1" runat="server"></asp:Label>
                                                    Hora Ingreso:<asp:Label ID="LabelHoraIngresoCoordinador1" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Coordinador 1" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelCoordinador2" runat="server"></asp:Label>
                                                     Hora Ingreso:<asp:Label ID="LabelHoraIngresoCoordinador2" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Cocina" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListCocina" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Cocina&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Salon" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListSalon" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Salon&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Barra" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListBarra" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Barra&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Logistica" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListLogistica" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Logistica&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Operaciones" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListOperaciones" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Operaciones&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Logistica Armado" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListResponsableLogisticaArmado" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Armado&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Resp. Logistica Desarmado" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListResponsableLogisticaDesarmado" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="null">&lt;Seleccione un Resp. Desarmado&gt;</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ControlStyle Width="150px" />
                                                <HeaderStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                                  
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>

                                                    <asp:ImageButton ID="ButtonVer" runat="server" Text="Ver" ImageUrl="~/Content/Imagenes/icono_ver.png" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                                                    <asp:ImageButton ID="ButtonVerExperiencia" runat="server" Text="Experiencia" ImageUrl="~/Content/Imagenes/Detalle.png" CommandName="Experiencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                                                    <%--<asp:ImageButton ID="ButtonAgregarPersonal" runat="server" Text="Personal" ImageUrl="~/Content/Imagenes/empleados.png" CommandName="Personal" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />--%>
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
                    <td>
                        <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
