<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Reportes.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 33%;
        }

        .auto-style2 {
            width: 33%;
        }

        .auto-style3 {
            width: 33%;
        }

        .auto-style4 {
            width: 33%;
        }

        .auto-style5 {
            width: 33%;
        }

        .auto-style6 {
            width: 33%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Reportes</h3>
            <br />
        </div>
        <div class="panel-body">
            <asp:Panel ID="PanelConfiguracion" runat="server">


                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Panel ID="PanelGeneral" GroupingText="General" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:Button ID="ButtonReporteGeneral" runat="server" Width="100%" class="btn btn-info btn-lg btn-block" OnClick="ButtonReporteGeneral_Click" Text="Reporte General de Eventos" /></td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteEventosConfirmados" runat="server" Width="100%" class="btn btn-info btn-lg btn-block" OnClick="ButtonReporteEventosConfirmados_Click" Text="Reporte Eventos Confirmados" /></td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:Button ID="ButtonReporteVentasCobranzas" runat="server" Width="100%" class="btn btn-info btn-lg btn-block" Text="Reporte Ventas Cobranzas" OnClick="ButtonReporteVentasCobranzas_Click" /></td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteProductos" runat="server" class="btn btn-info btn-lg btn-block" Text="Reporte Productos" Width="100%" OnClick="ButtonReporteProductos_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:Button ID="ButtonReportePagosProveedores" runat="server" Width="100%" class="btn btn-info btn-lg btn-block" Text="Reporte Pagos" OnClick="ButtonReportePagosProveedores_Click" /></td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Panel ID="PanelOrganizacion" GroupingText="Compras/Organizacion" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="auto-style4">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <asp:Button ID="ButtonReporteProveedoresEstado" Width="100%" runat="server" class="btn btn-primary btn-lg btn-block" OnClick="ButtonReporteProveedoresEstado_Click" Text="Reporte Proveedores Eventos Estados" />

                                        </td>
                                        <td class="auto-style4">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteProveedoresEventos" Width="100%" runat="server" class="btn btn-primary btn-lg btn-block" OnClick="ButtonReporteProveedoresEventos_Click" Text="Reporte Proveedores Eventos" /></td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="auto-style4">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">
                                            <asp:Button ID="ButtonReporteResponsables" Width="100%" runat="server" class="btn btn-primary btn-lg btn-block" Text="Reporte Responsables Eventos" OnClick="ButtonReporteResponsables_Click" />

                                        </td>

                                        <td class="auto-style4">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteProveedoresExternos" runat="server" class="btn btn-primary btn-lg btn-block" OnClick="ButtonReporteProveedoresExternos_Click" Text="Reporte Proveedores Externos" Width="100%" />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="auto-style4">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>

                            </asp:Panel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Panel ID="PanelAdministracion" GroupingText="Administracion" runat="server">

                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>

                                        <td class="auto-style5">
                                            <asp:Button ID="ButtonReporteInformeResultados" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" Text="Reporte Informe de Resultados" OnClick="ButtonReporteInformeResultados_Click" /></td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteIvaCompra" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" OnClick="ButtonReporteIvaCompra_Click" Text="Reporte IVA Compra" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>

                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteIvaVenta" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" Text="Reporte IVA Venta" OnClick="ButtonReporteIvaVenta_Click" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>

                                        <td class="auto-style5">
                                            <asp:Button ID="ButtonReporteComprobantesProveedores" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" OnClick="ButtonReporteComprobantesProveedores_Click" Text="Reporte Comprobantes Proveedores" /></td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>
                                            <asp:Button ID="ButtonReporteSimulacionIndexacion" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" OnClick="ButtonReporteSimulacionIndexacion_Click" Text="Simulador Indexacion" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>

                                        <td class="auto-style5">
                                            <asp:Button ID="ButtonReporteGastosPorPresupuesto" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" Text="Reporte Gastos por Presupuesto" OnClick="ButtonReporteGastosPorPresupuesto_Click" /></td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>

                                            <asp:Button ID="ButtonReporteProveedoresAsociados" runat="server" class="btn btn-warning btn-lg btn-block" Text="Reporte Proveedores Asociados" Width="100%" OnClick="ButtonReporteProveedoresAsociados_Click" />

                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>

                                        <td class="auto-style5">
                                            <asp:Button ID="ButtonPagosProveedores" runat="server" Width="100%" class="btn btn-warning btn-lg btn-block" Text="Reporte Pagos Proveedores" OnClick="ButtonPagosProveedores_Click" /></td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>


                                            <asp:Button ID="ButtonReporteMovimientosPorCuentas" runat="server" class="btn btn-warning btn-lg btn-block" Text="Reporte Movimientos por Cuentas" Width="100%" OnClick="ButtonReporteMovimientosPorCuentas_Click" />


                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver al Inicio" OnClick="ButtonVolver_Click" />
            </asp:Panel>
        </div>
    </div>

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
