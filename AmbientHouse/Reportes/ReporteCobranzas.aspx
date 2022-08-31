<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteCobranzas.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteCobranzas" %>
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
                    <td><h3>Nro. Evento:</h3></td>
                    <td> <asp:TextBox ID="TextBoxNroEvento" runat="server" class="form-control"></asp:TextBox></td>
                    <td> &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><h3>Nro. Presupuesto:</h3></td>
                    <td><asp:TextBox ID="TextBoxNroPresupuesto" runat="server" class="form-control"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><h3>Fecha Desde:</h3></td>
                    <td><asp:TextBox ID="TextBoxNroFechaDesde" runat="server" class="form-control"></asp:TextBox>
                          <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxNroFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><h3>Fecha Hasta:</h3></td>
                    <td><asp:TextBox ID="TextBoxFechaHasta" runat="server" class="form-control"></asp:TextBox>
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
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" /></td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">Reporte General de Eventos</div>
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
                                    <asp:GridView ID="GridViewReporteCobranzas" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True"  >
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Cobranzas con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                           
                                           <asp:BoundField DataField="NroEvento" HeaderText="Nro. Evento" SortExpression="NroEvento" />
                                            <asp:BoundField DataField="NroPresupuesto" HeaderText="Nro. Presupuesto" SortExpression="NroPresupuesto" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="Rubro" HeaderText="Rubro" SortExpression="Rubro" />
                                            <asp:BoundField DataField="AdicionalDesc" HeaderText="Adicional" SortExpression="AdicionalDesc" />
                                            <asp:BoundField DataField="AdicionalCant" HeaderText="Cant." SortExpression="AdicionalCant" />
                                            <asp:BoundField DataField="AdicionalValor" HeaderText="Precio" SortExpression="AdicionalValor" />
                                          
                                           

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
