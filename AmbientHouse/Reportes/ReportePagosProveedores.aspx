<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReportePagosProveedores.aspx.cs" Inherits="AmbientHouse.Reportes.ReportePagosProveedores" %>
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
                        <td>
                            <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" Text="EXPORTAR A EXCEL" OnClick="ButtonExportarExcel_Click"  />
                        
                        </td>
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
                                    <asp:GridView ID="GridViewReporte" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Eventos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="NROPRESUPUESTO" HeaderText="Nro Presup." SortExpression="NROPRESUPUESTO" />
                                            <asp:BoundField DataField="DIAEVENTO" HeaderText="Dia" SortExpression="DIAEVENTO" />
                                            <asp:BoundField DataField="MESEVENTO" HeaderText="Mes" SortExpression="MESEVENTO" />
                                            <asp:BoundField DataField="ANIOEVENTO" HeaderText="Año" SortExpression="ANIOEVENTO" />
                                            <asp:BoundField DataField="NroComprobante" HeaderText="Nro. Comp." SortExpression="NroComprobante" />
                                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                            <asp:BoundField DataField="Cuit" HeaderText="Cuit"  SortExpression="Cuit" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Detalle pago" SortExpression="Descripcion" />
                                             <asp:BoundField DataField="CUENTA" HeaderText="Cuenta" SortExpression="CUENTA" />
                                            <asp:BoundField DataField="IMPORTEPAGADO" HeaderText="Imp. Pagado" DataFormatString="{0:C0}" SortExpression="IMPORTEPAGADO" />
                                            <asp:BoundField DataField="COSTOS" HeaderText="Total Presupuesto" DataFormatString="{0:C0}" SortExpression="COSTOS" />
                                          

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
