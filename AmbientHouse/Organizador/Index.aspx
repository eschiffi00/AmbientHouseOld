<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Organizador.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanelInicio" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup. Aprobado" SortExpression="PresupuestoId" />

                                            <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="LOCACION" HeaderText="Locacion" SortExpression="LOCACION" />
                                            <asp:BoundField DataField="SECTOR" HeaderText="Sector" SortExpression="SECTOR" />
                                            <asp:BoundField DataField="JORNADA" HeaderText="Jornada" SortExpression="JORNADA" />
                                            <asp:BoundField DataField="CantidadInicialInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInicialInvitados" />
                                            <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" SortExpression="FechaEvento" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                            <asp:TemplateField HeaderStyle-Width="500px" HeaderText="" ControlStyle-Width="300px">
                                                <ItemTemplate>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>Organizador</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListOrganizador" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Organizador&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Coordinador 1</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCoordinador" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Coordinador&gt;</asp:ListItem>
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Hora Ingreso Coordinador 1</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxHoraCoordinador1" runat="server" class="form-control" Width="50px"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraCoordinador1" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraCoordinador1" UserTimeFormat="TwentyFourHour" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Coordinador 2</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCoordinador1" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                                                    <asp:ListItem Value="null">&lt;Seleccione un Coordinador&gt;</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Hora Ingreso Coordinador 2</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxHoraCoordinador2" runat="server" class="form-control" Width="50px"></asp:TextBox>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraCoordinador2" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraCoordinador2" UserTimeFormat="TwentyFourHour" />
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                    </table>

                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderStyle-Width="500px" HeaderText="" ControlStyle-Width="300px">
                                                <ItemTemplate>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>Resp. Cocina</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespCocina" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Resp. Salon</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespSalon" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Resp. Barra</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespBarra" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Resp. Logistica</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespLogistica" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Resp. Operaciones</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespOperaciones" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Resp. Logistica Armado</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespLogisticaArmado" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Resp. Logistica Desarmado</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRespLogisticaDesarmado" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                                </ItemTemplate>
                                                <ControlStyle Width="100px" />
                                                <HeaderStyle Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonCargarSeguros" runat="server" class="btn btn-danger" Text="Contrato Proveedores" CommandName="CargarProveedoresExternos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                </ItemTemplate>
                                                <ControlStyle Width="200px" />
                                                <HeaderStyle Width="200px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>

                                                    <asp:ImageButton ID="ButtonImprirmir" runat="server" Text="Imprimir" ImageUrl="~/Content/Imagenes/imprimir.png" CommandName="Imprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

                                                    <asp:ImageButton ID="ButtonVerExperiencia" runat="server" Text="Experiencia" ImageUrl="~/Content/Imagenes/Detalle.png" CommandName="Experiencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="30px" Width="30px" />

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
