<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteComprobantes.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteComprobantes" %>

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
                    <td>
                        <h3>Razon Social:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td>&nbsp;</td>
                    <td>
                        <h3>Nro. Presupuesto:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPresupuesto" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <h3>Tipo Movimiento:</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListTipoMovimiento" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                            <asp:ListItem Value="Todas">&lt;Todas&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Total Neto:</td>
                    <td>
                        <asp:TextBox ID="TextBoxTotal" runat="server" class="form-control"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="ButtonBuscar_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" /></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">Reporte Comprobantes</div>
            <div class="panel-body">
                <table style="width: 100%;">

                    <tr>
                        <td>&nbsp;</td>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>

                        <td>
                            <asp:UpdatePanel ID="UpdatePanelGrillaReporteComprobantes" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewReporteComprobantes" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Locaciones con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                            <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comprobante" SortExpression="NroComprobante" />
                                            <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="Fecha" />

                                            <asp:BoundField DataField="MontoFactura" HeaderText="Monto Factura" SortExpression="MontoFactura" />

                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo Comprobante" SortExpression="Descripcion" />

                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuenta" HeaderText="Cuenta" SortExpression="Cuenta" />
                                            <asp:BoundField DataField="NETO" HeaderText="Neto" SortExpression="NETO" />
                                            <asp:BoundField DataField="Leyenda" HeaderText="Leyenda" SortExpression="Leyenda" />
                                            <asp:BoundField DataField="TipoImpuesto" HeaderText="Tipo Impuesto" SortExpression="TipoImpuesto" />
                                            <asp:BoundField DataField="IMPUESTO" HeaderText="Impuesto" SortExpression="IMPUESTO" />
                                            <asp:BoundField DataField="IMPUESTOINTERNO" HeaderText="Impuesto Int." SortExpression="IMPUESTOINTERNO" />
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup." SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="FormadePago" HeaderText="Forma de Pago" SortExpression="FormadePago" />
                                            <asp:BoundField DataField="CC" HeaderText="CC" SortExpression="CC" />
                                            <asp:BoundField DataField="Leyenda" HeaderText="Leyenda" SortExpression="Leyenda" />
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
