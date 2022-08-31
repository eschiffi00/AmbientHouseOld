<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteMovimientosporCuentas.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteMovimientosporCuentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Detalle Movimientos por cuentas</div>
        <asp:UpdatePanel ID="UpdatePanelBuscador" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
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
                            <h3>Tipo Movimientos:</h3>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListTipoGasto" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoGasto_SelectedIndexChanged">
                                <asp:ListItem Value="INGRESOS">INGRESOS</asp:ListItem>
                                <asp:ListItem Value="EGRESOS">EGRESOS</asp:ListItem>
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
                        <td>
                            <h3>Cuenta:</h3>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCuentas" runat="server" CssClass="form-control"></asp:DropDownList></td>

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
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel-body">

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
                    <div class="panel-body">

                        <asp:GridView ID="GridViewReporteEgresos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewReporteEgresos_RowCommand" OnRowDataBound="GridViewReporteEgresos_RowDataBound">
                            <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Informacion con los parametros seleccionados!  
                            </EmptyDataTemplate>

                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" ItemStyle-Width="5%" />
                                <asp:BoundField DataField="NroRecibo" HeaderText="Nro. Comprobante" SortExpression="NroRecibo" ItemStyle-Width="5%" />
                                <asp:BoundField DataField="FechaPagoStr" HeaderText="Fecha" SortExpression="FechaPagoStr" ItemStyle-Width="10%" />
                                <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" ItemStyle-Width="20%" />
                                <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" ItemStyle-Width="10%" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Leyenda" SortExpression="Descripcion" ItemStyle-Width="20%" />

                                <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Tipo Mov." ControlStyle-Width="100%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownListTipoMovimientos" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="100%" />
                                    <HeaderStyle Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100%">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                    </ItemTemplate>
                                    <ControlStyle Width="100%" />
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </div>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 10%">&nbsp;</td>
                            <td style="width: 20%">&nbsp;</td>
                            <td style="width: 10%; text-align: right;">
                                <asp:TextBox ID="TextBoxTotalEgresos" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td style="width: 30%">&nbsp;</td>
                            <td style="width: 10%">&nbsp;</td>
                            <td style="width: 10%">&nbsp;</td>
                        </tr>

                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>


        </div>
    </div>
</asp:Content>
