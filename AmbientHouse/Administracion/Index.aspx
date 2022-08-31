<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading"><h3>Administracion</h3>
                    </div>
                    <div class="panel-body">

                        <asp:Panel ID="PanelConfiguracion" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    
                                    <td>   
                                        <asp:Button ID="ButtonAdministrarCuentas" runat="server" class="btn btn-info" OnClick="ButtonAdministrarCuentas_Click" Text="Administrar Cuentas" />
                                    </td>
                                    <td>
                                        
                                        <asp:Button ID="ButtonAdministrarTipoComprobantes" runat="server" class="btn btn-info" OnClick="ButtonAdministrarTipoComprobantes_Click" Text="Administrar Tipo Comprobantes" />
                                        
                                    </td>
                                    
                                    <td>
                                        
                                        <asp:Button ID="ButtonAdministrarImpuestos" runat="server" class="btn btn-info" OnClick="ButtonAdministrarImpuestos_Click" Text="Administrar Impuestos" />
                                        
                                    </td>
                                    
                                    <td>
                                         <asp:Button ID="ButtonClientes" runat="server" class="btn btn-info" Text="Administrar Clientes" OnClick="ButtonClientes_Click" />
                                    </td>

                                     <td>
                                      
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                   
                                </tr>
                             
                               
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarComprobantes" runat="server" class="btn btn-info" OnClick="ButtonAdministrarComprobantes_Click" Text="Administrar Comprobantes" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarPagoAProveedores" runat="server" class="btn btn-info" OnClick="ButtonAdministrarPagoAProveedores_Click" Text="Administrar Pago a Proveedores" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarProductos" runat="server" class="btn btn-info" Text="Administrar Items de Venta" OnClick="ButtonAdministrarProductos_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarLiquidacionHoras" runat="server" class="btn btn-info" Text="Administrar Liquidacion Horas" OnClick="ButtonAdministrarLiquidacionHoras_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarCheques" runat="server" class="btn btn-info" OnClick="ButtonAdministrarCheques_Click" Text="Administrar Cheques" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTransferencias" runat="server" class="btn btn-info" OnClick="ButtonAdministrarTransferencias_Click" Text="Administrar Transferencias" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarRecibos" runat="server" class="btn btn-info" OnClick="ButtonAdministrarRecibos_Click" Text="Administrar Recibos" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTipoMovimientos" runat="server" class="btn btn-info" OnClick="ButtonAdministrarTipoMovimientos_Click" Text="Administrar Tipos de Movimientos" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonCostoSalones" runat="server" class="btn btn-success"  Text="Costo Salon" OnClick="ButtonCostoSalones_Click" />
                                    </td>
                                   <td>&nbsp;</td>
                                   <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Volver al Inicio" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>

                            </table>
                        </asp:Panel>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
