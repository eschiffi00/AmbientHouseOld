<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="EditarOLD.aspx.cs" Inherits="AmbientHouse.Administracion.Recibos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Panel ID="PanelCliente" runat="server">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Agregar/Editar Recibos
                                           
                        </div>
                        <div class="panel-body">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelRazonSocial" runat="server" Text="Razon Social"></asp:Label>
                                            <asp:Label ID="LabelApellidoyNombre" runat="server" Text="Apellido y Nombre"></asp:Label></h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelApellidoyNombreText" runat="server" Text="Label" Font-Bold="True"></asp:Label>

                                            <asp:Label ID="LabelRazonSocialText" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>

                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>Domicilio:</h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelDomicilio" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>Condicion IVA:</h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelCondicionIva" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>Cuit/Cuit:</h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelCuit" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>
                                    </td>

                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>


                                <tr>
                                    <td>
                                        <h4>Monto Senia:</h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelMontoSenia" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>Fecha Senia:</h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelFechaSenia" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h4>Forma de Pago:</h4>
                                    </td>
                                    <td>
                                        <h4>
                                            <asp:Label ID="LabelFormadePago" runat="server" Text="Label" Font-Bold="True"></asp:Label></h4>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>

                            </table>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelReciboPDF" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <iframe height="780px" src="/Presupuestos/RecibosEventos.ashx" width="100%"></iframe>
                            </td>
                        </tr>

                       
                    </table>

                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
