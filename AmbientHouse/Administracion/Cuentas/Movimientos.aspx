<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Movimientos.aspx.cs" Inherits="AmbientHouse.Administracion.Cuentas.Movimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Buscador</div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <h3>Fecha Desde:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNroFechaDesde" runat="server" class="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxNroFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <h3>Fecha Hasta:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaHasta" runat="server" class="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaHasta" runat="server" TargetControlID="TextBoxFechaHasta" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="ButtonBuscar_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" /></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">Movimientos</div>
            <div class="panel-body">
                <table style="width: 100%;">

                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>

                        <td>
                            <asp:UpdatePanel ID="UpdatePanelGrillaReporteMovimientos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewReporteMovimientos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewReporteMovimientos_RowCommand" OnRowDataBound="GridViewReporteMovimientos_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Movimientos con los parametros seleccionados!  
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="NroMovimiento" HeaderText="Nro. Mov." SortExpression="NroMovimiento" ItemStyle-Width="5%" />
                                            <asp:BoundField DataField="FechaMovimiento" HeaderText="Fecha Movimiento" SortExpression="FechaMovimiento" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="TipoMovimientoCuenta" HeaderText="Tipo Movimiento" SortExpression="TipoMovimientoCuenta" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="SaldoAnteriorStr" HeaderText="Saldo Anterior" SortExpression="SaldoAnteriorStr" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="SaldoActualStr" HeaderText="Saldo Actual" SortExpression="SaldoActualStr" ItemStyle-Width="15%" />
                                            <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" ItemStyle-Width="10%" />
                                            <asp:TemplateField HeaderStyle-Width="25%" HeaderText="Descripcion" ControlStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                                                </ItemTemplate>
                                                <ControlStyle Width="100%" />
                                                <HeaderStyle Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="5%" ControlStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                                </ItemTemplate>
                                                <ControlStyle Width="100%" />
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="5%" ControlStyle-Width="5%">
                                                <ItemTemplate>

                                                    <asp:Button ID="ButtonEliminarMovimiento" runat="server" Text="Quitar" class="btn btn-danger" CommandName="EliminarPago" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                                </ItemTemplate>
                                                <ControlStyle Width="100%" />
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
