<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteProveedoresAsociados.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteProveedoresAsociados" %>

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
                        <asp:TextBox ID="TextBoxFechaDesde" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="FechaDesdeRequired" runat="server" ControlToValidate="TextBoxFechaDesde" Display="Dynamic" ErrorMessage="Fecha Desde es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
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
                        <asp:DropDownList ID="DropDownListProveedores" runat="server" CssClass="form-control"></asp:DropDownList>
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
                    <td colspan="2">
                        <asp:Button ID="ButtonBuscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="ButtonBuscar_Click" ValidationGroup="Items" />
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
                            <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewReporteComprobantes" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Datos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presu." SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="UN" HeaderText="U. Negocio" SortExpression="UN" />
                                            <asp:BoundField DataField="PAX" HeaderText="PAX" SortExpression="PAX" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="HorarioEvento" HeaderText="Hora Inicio" SortExpression="HorarioEvento" />
                                            <asp:BoundField DataField="HoraFinalizado" HeaderText="Hora Fin" SortExpression="HoraFinalizado" />
                                            <asp:BoundField DataField="Locacion" HeaderText="Locacion" SortExpression="Locacion" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto Descripcion" SortExpression="ProductoDescripcion" />
                                            <asp:BoundField DataField="ServicioDescripcion" HeaderText="Servicio Descripcion" SortExpression="ServicioDescripcion" />
                                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                            <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                                            <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" DataFormatString="{0:C0}" />
                                            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" DataFormatString="{0:C0}" />
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
