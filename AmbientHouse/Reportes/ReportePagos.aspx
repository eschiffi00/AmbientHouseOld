<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReportePagos.aspx.cs" Inherits="AmbientHouse.Reportes.ReportePagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Detalle Informe de Resultados</div>
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 15%">Movimiento</td>
                <td style="width: 35%">
                    <asp:TextBox ID="TextBoxMovimiento" ReadOnly="true" CssClass="form-control" runat="server" Width="100%"></asp:TextBox></td>

                <td style="width: 15%">Cuenta</td>
                <td style="width: 35%">
                    <asp:TextBox ID="TextBoxCuenta" ReadOnly="true" CssClass="form-control" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">Fecha Desde</td>
                <td style="width: 35%">
                    <asp:TextBox ID="TextBoxFechaDesde" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox></td>

                <td style="width: 15%">Fecha Hasta</td>
                <td style="width: 35%">
                    <asp:TextBox ID="TextBoxFechaHasta" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>

        </table>
        <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="panel-body">

                    <asp:GridView ID="GridViewReporteIngresos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewReporteIngresos_RowCommand" OnRowDataBound="GridViewReporteIngresos_RowDataBound">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" SortExpression="PresupuestoId" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="NroRecibo" HeaderText="Nro. Recibo" SortExpression="NroRecibo" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="FechaPagoStr" HeaderText="Fecha" SortExpression="FechaPagoStr" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="ImporteStr" HeaderText="Total" SortExpression="ImporteStr" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="ApellidoNombre" HeaderText="Ejecutivo" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" />

                            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Tipo Mov." ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownListTipoMovimientos" runat="server" CssClass="form-control"></asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                </ItemTemplate>
                                <ControlStyle Width="100px" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                </div>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 5%">&nbsp;</td>
                        <td style="width: 5%">&nbsp;</td>
                        <td style="width: 10%">&nbsp;</td>
                        <td style="width: 30%">&nbsp;</td>
                        <td style="width: 30%; text-align: right;">>
                            <asp:TextBox ID="TextBoxTotalIngresos" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td style="width: 10%">&nbsp;</td>
                        <td style="width: 10%">&nbsp;</td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
