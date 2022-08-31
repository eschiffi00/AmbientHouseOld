<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Grupos.Editar" %>

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
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Agregar/Editar Grupos<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Codigo:</td>
                                <td class="auto-style2">
                                    <asp:TextBox ID="TextBoxCodigo" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CodigoRequired" runat="server" ControlToValidate="TextBoxCodigo" Display="Dynamic" ErrorMessage="Codigo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Grupos"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Tipo:</td>
                                <td class="auto-style2">
                                    <asp:DropDownList ID="DropDownListTipo" runat="server">
                                        <asp:ListItem>Central</asp:ListItem>
                                        <asp:ListItem>Adicional</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Descripcion:</td>
                                <td class="auto-style2">
                                    <asp:TextBox ID="TextBoxDescripcion" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Grupos" OnClick="ButtonAceptar_Click" class="btn btn-info"  />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default"  />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
