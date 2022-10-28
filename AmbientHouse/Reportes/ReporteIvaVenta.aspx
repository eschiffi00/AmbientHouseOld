<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteIvaVenta.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteIvaVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Reporte Iva Ventas</div>


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
                        
                        <asp:TextBox ID="TextBoxTotalIva" runat="server" ReadOnly="true"></asp:TextBox></td>

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
                                        <asp:BoundField DataField="NroFactura" HeaderText="Nro. factura" SortExpression="NroFactura" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Empresa" SortExpression="RazonSocial" />
                                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                        <asp:BoundField DataField="CUILCUIT" HeaderText="Cuit" SortExpression="CUILCUIT" />
                                        <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                        <asp:BoundField DataField="ImporteBruto" HeaderText="Importe Bruto" DataFormatString="{0:C0}" SortExpression="ImporteBruto" />
                                        <asp:BoundField DataField="IVA21" HeaderText="IVA 21" DataFormatString="{0:C0}" SortExpression="IVA21" />
                                        <asp:BoundField DataField="ImporteTotal" HeaderText="Importe Total" DataFormatString="{0:C0}" SortExpression="ImporteTotal" />


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
</asp:Content>
