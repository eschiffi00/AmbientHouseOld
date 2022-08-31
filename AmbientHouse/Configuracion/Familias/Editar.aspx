<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Familias.Editar" %>

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
                        Agregar/Editar Familias<br />
                    </div>
                    <div class="panel-body">

                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><h3>Codigo:</h3></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListCodigo" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style2"></td>
                                </tr>
                                <tr>
                                    <td><h3>Categoria Item:</h3></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListCategorias" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><h3>Titulo:</h3></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTitulo" runat="server" Width="300px" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="TituloRequired" runat="server" ControlToValidate="TextBoxTitulo" Display="Dynamic" ErrorMessage="Titulo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Familias"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><h3>Subtitulo:</h3></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxSubtitulo" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><h3>Comentario:</h3></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxComentario" runat="server" Height="200px" TextMode="MultiLine" Width="600px" class="form-control"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><h3>Edad:</h3></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListEdad" runat="server" class="form-control">
                                            <asp:ListItem Selected="True">...</asp:ListItem>
                                            <asp:ListItem>Mayores</asp:ListItem>
                                            <asp:ListItem>Menores de 12 </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><h3>Fantasia</h3></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxFantasia" runat="server" Width="400px" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="FantasiaRequired" runat="server" ControlToValidate="TextBoxFantasia" Display="Dynamic" ErrorMessage="Fantasia es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Familias"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>&nbsp;</td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Familias" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
