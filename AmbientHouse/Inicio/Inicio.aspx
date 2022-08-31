<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="AmbientHouse.Inicio.Inicio1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
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
                                        <asp:Button ID="ButtonAdministrarCuentas" runat="server" class="btn btn-info"  Text="Administrar Cuentas" />
                                    </td>
                                    <td>
                                        
                                        <asp:Button ID="ButtonAdministrarTipoComprobantes" runat="server" class="btn btn-info"  Text="Administrar Tipo Comprobantes" />
                                        
                                    </td>
                                    
                                    <td>
                                        
                                        <asp:Button ID="ButtonAdministrarImpuestos" runat="server" class="btn btn-info"  Text="Administrar Impuestos" />
                                        
                                    </td>
                                    
                                    <td>
                                         <asp:Button ID="ButtonClientes" runat="server" class="btn btn-info" Text="Administrar Clientes"  />
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
                                        <asp:Button ID="ButtonAdministrarComprobantes" runat="server" class="btn btn-info"  Text="Administrar Comprobantes" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarPagoAProveedores" runat="server" class="btn btn-info"  Text="Administrar Pago a Proveedores" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarProductos" runat="server" class="btn btn-info" Text="Administrar Items de Venta"  />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarLiquidacionHoras" runat="server" class="btn btn-info" Text="Administrar Liquidacion Horas" />
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
                                        <asp:Button ID="ButtonAdministrarCheques" runat="server" class="btn btn-info"  Text="Administrar Cheques" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTransferencias" runat="server" class="btn btn-info"  Text="Administrar Transferencias" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarRecibos" runat="server" class="btn btn-info"  Text="Administrar Recibos" />
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAdministrarTipoMovimientos" runat="server" class="btn btn-info"  Text="Administrar Tipos de Movimientos" />
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
                                        <asp:Button ID="ButtonCostoSalones" runat="server" class="btn btn-success"  Text="Costo Salon" />
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
                                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default"  Text="Volver al Inicio" />
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
