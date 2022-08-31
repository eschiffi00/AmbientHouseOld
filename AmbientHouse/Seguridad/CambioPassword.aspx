<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="AmbientHouse.Seguridad.CambioPassword" %>

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
                        Cambio Password
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="LabelError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Password:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxLoginAnterior" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="TextBoxLoginAnterior" Display="Dynamic" ErrorMessage="Password es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Password Nuevo:</td>
                                <td class="auto-style2">
                                    <asp:TextBox ID="TextBoxLoginNuevo" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequiredPassNuevo" runat="server" ControlToValidate="TextBoxLoginNuevo" Display="Dynamic" ErrorMessage="Nuevo Password es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td>Confirmar Password:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxConfirmacion" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequiredConfirmar" runat="server" ControlToValidate="TextBoxConfirmacion" Display="Dynamic" ErrorMessage="Confirmar Password es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click" Text="Aceptar" ValidationGroup="Usuario" class="btn btn-primary"/>
                                    &nbsp;|&nbsp;
                                    <asp:Button ID="ButtonCancelar" runat="server" OnClick="ButtonCancelar_Click" Text="Cancelar" class="btn btn-default" />
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
