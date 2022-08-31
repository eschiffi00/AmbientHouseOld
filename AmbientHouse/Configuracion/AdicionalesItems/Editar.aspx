<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.AdicionalesItems.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Agregar/Editar Experiencias de Ambientacion<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <h3>Adicional:</h3>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="DropDownListAdicionales" runat="server" class="form-control" AppendDataBoundItems="True" AutoPostBack="True" Width="100%">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Item:</h3>
                                </td>
                                <td>

                                    <asp:DropDownList ID="DropDownListItems" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar y Salir" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                 <asp:Button ID="ButtonAceptaryContinuar" runat="server" Text="Aceptar y Continuar" ValidationGroup="Items" class="btn btn-warning" OnClick="ButtonAceptaryContinuar_Click"  />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
