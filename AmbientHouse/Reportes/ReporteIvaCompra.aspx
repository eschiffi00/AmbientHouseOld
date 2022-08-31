<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteIvaCompra.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteIvaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">

        <div class="panel panel-primary">
            <div class="panel-heading">Reporte Proveedores Eventos Cerrados</div>

            <div class="panel-body">

                <table style="width: 100%;">

                    <tr>
                        <td>
                            <h3>Fecha Desde:</h3>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxNroFechaDesde" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="FechaDesdeRequired" runat="server" ControlToValidate="TextBoxNroFechaDesde" Display="Dynamic" ErrorMessage="Fecha Desde es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxNroFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h3>Fecha Hasta:</h3>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxFechaHasta" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="FechaHastaRequired" runat="server" ControlToValidate="TextBoxFechaHasta" Display="Dynamic" ErrorMessage="Fecha Hasta es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaHasta" runat="server" TargetControlID="TextBoxFechaHasta" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>


                    <tr>
                        <td>
                            <h3>Empresa:</h3>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListEmpresa" runat="server" class="form-control" Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" Text="EXPORTAR A EXCEL" OnClick="ButtonExportarExcel_Click" />
                            &nbsp;|&nbsp;
                            <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" ValidationGroup="Items" />

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
            <div class="panel-body">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">Total Iva
                         <asp:TextBox ID="TextBoxTotalIva" runat="server" ReadOnly ="true"></asp:TextBox></td>
                       
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Total Iva 27%
                         <asp:TextBox ID="TextBoxIva27" runat="server" ReadOnly ="true"></asp:TextBox></td>
                        <td>Total Iva 21%
                         <asp:TextBox ID="TextBoxIva21" runat="server" ReadOnly ="true"></asp:TextBox></td>
                        <td>Total Iva 10.5%
                         <asp:TextBox ID="TextBoxIva105" runat="server" ReadOnly ="true"></asp:TextBox></td>
                        <td>Total Percepcion Iva
                         <asp:TextBox ID="TextBoxPercepcion" runat="server" ReadOnly ="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>


                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewReporte" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Eventos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" />
                                            <asp:BoundField DataField="TipoComprobante" HeaderText="Comprobante" SortExpression="TipoComprobante" />
                                            <asp:BoundField DataField="PuntoVenta" HeaderText="Pto. Venta" SortExpression="PuntoVenta" />
                                            <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comprobante" SortExpression="NroComprobante" />
                                            <asp:BoundField DataField="ImporteNeto" HeaderText="Neto" DataFormatString="{0:C0}" SortExpression="ImporteNeto" />
                                            <asp:BoundField DataField="IVA27" HeaderText="IVA 27%" DataFormatString="{0:C0}" SortExpression="IVA27" />
                                            <asp:BoundField DataField="IVA21" HeaderText="IVA 21%" DataFormatString="{0:C0}" SortExpression="IVA21" />
                                            <asp:BoundField DataField="IVA105" HeaderText="IVA 10.5%" DataFormatString="{0:C0}" SortExpression="IVA105" />
                                            <asp:BoundField DataField="PercepcionIVA" HeaderText="Percepcion IVA" DataFormatString="{0:C0}" SortExpression="PercepcionIVA" />
                                            <asp:BoundField DataField="PercepcionIIBBARBA" HeaderText="Percepcion IIBB ARBA" DataFormatString="{0:C0}" SortExpression="PercepcionIIBBARBA" />
                                            <asp:BoundField DataField="PercepcionIIBBCABA" HeaderText="Percepcion IIBB CABA" DataFormatString="{0:C0}" SortExpression="PercepcionIIBBCABA" />
                                            <asp:BoundField DataField="Exento" HeaderText="Exento" DataFormatString="{0:C0}" SortExpression="Exento" />
                                            <asp:BoundField DataField="MontoFactura" HeaderText="MontoFactura" DataFormatString="{0:C0}" SortExpression="MontoFactura" />

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
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
