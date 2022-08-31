<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteGastosPorPresupuesto.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteGastosPorPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">

        <div class="panel panel-primary">
            <div class="panel-heading">Reporte Responsables Eventos</div>

            <div class="panel-body">

                <table style="width: 100%;">
                    <tr>
                        <td>
                            <h3>Nro. Presupuesto:</h3>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxNroPresupuesto" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>



                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
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
                                    <asp:GridView ID="GridViewReporte" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Gastos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>
                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup." SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comp." SortExpression="NroComprobante" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" />
                                            <asp:BoundField DataField="Leyenda" HeaderText="Descripcion" SortExpression="Leyenda" />
                                            <asp:BoundField DataField="TIPOMOVIMIENTO" HeaderText="Tipo Mov." SortExpression="TIPOMOVIMIENTO" />
                                            <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:C0}" SortExpression="Importe" />
                                            <asp:BoundField DataField="IMPUESTO" HeaderText="Tipo Impuesto" SortExpression="IMPUESTO" />
                                            <asp:BoundField DataField="ValorImpuesto" HeaderText="Imp. Impuesto" DataFormatString="{0:C0}" SortExpression="ValorImpuesto" />
                                            <asp:BoundField DataField="ValorImpuestoInterno" HeaderText="Imp. Impuesto Int." DataFormatString="{0:C0}" SortExpression="ValorImpuestoInterno" />
                                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                            <asp:BoundField DataField="ESTADO" HeaderText="Estado" SortExpression="ESTADO" />
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
