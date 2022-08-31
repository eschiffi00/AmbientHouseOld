<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Indexacion.aspx.cs" Inherits="AmbientHouse.Reportes.Indexacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Reporte Informe de Resultados</div>
        <div class="panel-body">

            <table style="width: 100%;">
                <tr>
                    <td>
                        <h3>Fecha Evento:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaEvento" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="FechaEventoRequired" runat="server" ControlToValidate="TextBoxFechaEvento" Display="Dynamic" ErrorMessage="Fecha Reserva es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" TargetControlID="TextBoxFechaEvento" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Monto Total Presupuesto:</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxMontoTotal" runat="server" class="form-control"></asp:TextBox>

                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Tipo Indexacion:</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListTipoIndexacion" runat="server" CssClass="form-control">
                            <asp:ListItem Value="pp">Punta/Punta</asp:ListItem>
                            <asp:ListItem Value="pc">Pago a Cuenta</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><h3>Indexacion:</h3></td>
                    <td><asp:TextBox ID="TextBoxIndexacion" runat="server" class="form-control"></asp:TextBox></td>
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
                            <asp:Button ID="ButtonSimular" class="btn btn-primary" runat="server" Text="Simular" ValidationGroup="Items" OnClick="ButtonSimular_Click" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 40%;">Fecha de Pago
                </td>
                <td style="width: 40%;">Importe
                </td>
                <td style="width: 20%;"></td>
            </tr>
            <tr>
                <td style="width: 40%;">
                    <asp:TextBox ID="TextBoxFechaPago" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FechaPagoRequired" runat="server" ControlToValidate="TextBoxFechaPago" Display="Dynamic" ErrorMessage="Fecha Pago es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaPago" runat="server" TargetControlID="TextBoxFechaPago" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                </td>
                <td style="width: 40%;">
                    <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td style="width: 20%;">
                    <asp:Button ID="ButtonAgregar" class="btn btn-success" runat="server" Text="Agregar" OnClick="ButtonAgregar_Click" />
                </td>
            </tr>

        </table>
        <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:GridView ID="GridViewSimulador" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" SortExpression="FechaPago" ItemStyle-Width="50%" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" SortExpression="Importe" ItemStyle-Width="50%" />

                        </Columns>
                    </asp:GridView>
                </div>

                 <div class="panel-body">
                    <asp:GridView ID="GridViewCuotas" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" SortExpression="FechaPago" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" SortExpression="Importe" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="SaldoIndexadoAlDiaEvento" HeaderText="Saldo" SortExpression="SaldoIndexadoAlDiaEvento" ItemStyle-Width="40%" />
                            
                        </Columns>

                    </asp:GridView>



                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
