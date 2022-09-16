<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteCuentaCorrienteProv.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteCuentaCorrienteProv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
     <div class="panel panel-primary">

        <div class="panel panel-primary">
            <div class="panel-heading">Reporte Pagos Proveedores</div>

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
                        <h3>Cuit Proveedor:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNroCuit" runat="server" class="form-control"></asp:TextBox>
                    </td>
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
                    <td colspan="2">
                        <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="ButtonBuscar_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" /></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
            <div class="panel-body">
                <table style="width: 100%;">
               
                    <tr>


                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewReporte" OnRowDataBound="GridViewReporte_RowDataBound" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" ShowFooter="true" >
                                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Eventos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                            <asp:BoundField DataField="NroComprobante"          HeaderText="Nro. Comprobante" SortExpression="NroComprobante" />
                                            <asp:BoundField DataField="CuitProveedor"           HeaderText="Cuit Proveedor" SortExpression="CuitProveedor" />
                                            <asp:BoundField DataField="NombreProveedor"         HeaderText="Nombre Proveedor" SortExpression="NombreProveedor" />
                                            <asp:BoundField DataField="NroPresupuesto"          HeaderText="Nro. Presupuesto" SortExpression="NroPresupuesto" />
                                            <asp:BoundField DataField="FechaPresupuesto"        HeaderText="Fecha Presupuesto" DataFormatString="{0:d}" SortExpression="FechaPresupuesto" />
                                            <asp:BoundField DataField="FechaEvento"             HeaderText="Fecha Evento" DataFormatString="{0:d}" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="TipoMovimiento"          HeaderText="Tipo Movimiento" SortExpression="TipoTransaccion" />
                                            <asp:BoundField DataField="TipoTransaccion"         HeaderText="Factura/OP" SortExpression="TipoTransaccion" />
                                            <asp:BoundField DataField="FechaTransaccion"        HeaderText="Fecha Transaccion" DataFormatString="{0:d}" SortExpression="FechaTransaccion" />
                                            <asp:BoundField DataField="NroTransaccion"          HeaderText="Nro. Factura" SortExpression="NroTransaccion" />
                                            <asp:BoundField DataField="ValorNetoFactura"        HeaderText="Valor Factura" DataFormatString="{0:C0}" SortExpression="ValorNetoFactura" />
                                            <asp:BoundField DataField="ValorImpuesto"           HeaderText="Impuesto" SortExpression="ValorImpuesto" Visible="false" />
                                            <asp:BoundField DataField="ValorImpuestoInterno"    HeaderText="Impuesto Interno" SortExpression="ValorImpuestoInterno" Visible="false" />
                                            <asp:BoundField DataField="ImporteSinIVA"           HeaderText="Importe Pagado" DataFormatString="{0:C0}" SortExpression="ImporteSinIVA" />
                                            <asp:BoundField DataField="SaldoPendiente"          HeaderText="Total Pendiente" DataFormatString="{0:C0}" SortExpression="SaldoPendiente" />
                                          

                                        </Columns>

                                    </asp:GridView>
                                </ContentTemplate>

                            </asp:UpdatePanel>

                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>

    </div>
</asp:Content>
