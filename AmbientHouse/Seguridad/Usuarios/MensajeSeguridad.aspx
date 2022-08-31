<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/Master/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="MensajeSeguridad.aspx.cs" Inherits="AmbientHouse.Seguridad.Usuarios.MensajeSeguridad" %>
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
            <td>  <asp:Label ID="LabelMensaje" runat="server" Font-Bold="True" ForeColor="Red" Width="100%"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonVolver" runat="server" OnClick="ButtonVolver_Click" Text="Volver" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
