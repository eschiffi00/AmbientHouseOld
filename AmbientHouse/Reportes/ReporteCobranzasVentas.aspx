<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteCobranzasVentas.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteCobranzasVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">Reporte Informe de Resultados</div>
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
                        <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" Text="EXPORTAR A EXCEL" OnClick="ButtonExportarExcel_Click" />
                        &nbsp;|&nbsp;
                            <asp:Button ID="ButtonVolver" class="btn btn-outline-primary" runat="server" Text="Volver" OnClick="ButtonVolver_Click"  />

                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
       
        <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
               

                 <div class="panel-body">
                    <asp:GridView ID="GridViewVentasCobranzas" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>
                            <asp:BoundField DataField="PresupuestoId" HeaderText="Presupuesto" SortExpression="PresupuestoId" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="NroRecibo" HeaderText="Nro. Rec." SortExpression="NroRecibo" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="FechaPagoStr" HeaderText="Fec. Pago" SortExpression="FechaPagoStr" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="FechaEventoStr" HeaderText="Fec. Evento" SortExpression="FechaEventoStr" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="TotalStr" HeaderText="Total Evento" SortExpression="TotalStr" ItemStyle-Width="20%" />
                        </Columns>

                    </asp:GridView>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
