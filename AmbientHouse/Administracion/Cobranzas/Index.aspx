<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Cobranzas.Index" %>

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
                                        <td>&nbsp;</td>
                                        <td>Cliente:<asp:TextBox ID="TextBoxClienteBuscador" runat="server" class="form-control" Width="500px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>NRO. Presupuesto:<asp:TextBox ID="TextBoxNroPresupuestoBuscador" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>FECHA EVENTO:</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFechaEvento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" CssClass="black" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEvento" TodaysDateFormat="" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />&nbsp;|&nbsp;
                                            <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar Filtros de Busqueda" OnClick="ButtonLimpiar_Click" /></td>
                                        <td>&nbsp;</td>
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

                        <div class="panel-footer">
                            <asp:UpdatePanel ID="UpdatePanelGrillas" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>


                                    <asp:GridView ID="GridViewItems" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewItems_RowCommand" OnRowDataBound="GridViewItems_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Unidades agregadas al presupuesto!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presu." SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="ClienteNombre" HeaderText="Cliente" SortExpression="ClienteNombre" />
                                            <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />
                                            <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                            <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />
                                            <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                            <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                            <asp:BoundField DataField="Logistica" HeaderText="Logistica Costo" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                            <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                            <asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />
                                            <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Fecha" runat="server" Text=""></asp:Label>
                                                    <asp:Button ID="ButtonPagado" runat="server" class="btn btn-success" Text="Cobrado" CommandName="Cobrado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>

                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ButtonBuscar" EventName="Click" />
                                </Triggers>

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
