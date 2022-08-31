<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteResultados.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteResultados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">Reporte Informe de Resultados</div>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Saldo:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSaldo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                         </td>
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
                    <td>
                        <h3>Agrupar Por:</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListTipoGasto" runat="server" CssClass="form-control">
                            <asp:ListItem Value="T">Todas</asp:ListItem>
                            <asp:ListItem Value="F">Gastos Fijos</asp:ListItem>
                            <asp:ListItem Value="V">Gastos Variables</asp:ListItem>
                        </asp:DropDownList>
                    </td>
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
        <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel-body">

                    <asp:GridView ID="GridViewReporteIngresos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewReporteIngresos_RowCommand">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="Clasificacion" HeaderText="Movimiento" SortExpression="Clasificacion" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" ItemStyle-Width="10%" />
                             <asp:BoundField DataField="Id" HeaderText="" SortExpression="Id" ItemStyle-Width="0%" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Cuenta" SortExpression="Descripcion" ItemStyle-Width="50%" />
                            <asp:BoundField DataField="TotalStr" HeaderText="Total" SortExpression="TotalStr" ItemStyle-Width="20%" />
                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%">
                                <ItemTemplate >
                                    <asp:Button ID="ButtonVerDetalleIngresos" runat="server" 
                                        Text="Ver" class="btn btn-primary" CommandName="DetalleIngreso" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="10%" />
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 10%">&nbsp;</td>
                        <td style="width: 10%">&nbsp;</td>
                        <td style="width: 50%">&nbsp;</td>
                        <td style="width: 20%">
                            <asp:TextBox ID="TextBoxTotalIngresos" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>
                         <td style="width: 10%">&nbsp;</td>
                    </tr>

                </table>
                <div class="panel-body">

                    <asp:GridView ID="GridViewReporteEgresos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewReporteEgresos_RowCommand">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="Clasificacion" HeaderText="Movimiento" SortExpression="Clasificacion" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Id" HeaderText="" SortExpression="Id" ItemStyle-Width="0%" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Cuenta" SortExpression="Descripcion" ItemStyle-Width="50%" />
                            <asp:BoundField DataField="TotalStr" HeaderText="Total" SortExpression="TotalStr" ItemStyle-Width="20%" />
                            <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonVerDetalleEgresos" runat="server" 
                                        Text="Ver" class="btn btn-primary" CommandName="DetalleEgreso" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                </ItemTemplate>
                                 <ControlStyle Width="100%" />
                                <HeaderStyle Width="10%" />
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                </div>
                <table style="width: 100%;">
                    <tr>
                       <td style="width: 10%">&nbsp;</td>
                        <td style="width: 10%">&nbsp;</td>
                        <td style="width: 50%">&nbsp;</td>
                        <td style="width: 20%">
                            <asp:TextBox ID="TextBoxTotalEgresos" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>
                         <td style="width: 10%">&nbsp;</td>
                    </tr>

                </table>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
