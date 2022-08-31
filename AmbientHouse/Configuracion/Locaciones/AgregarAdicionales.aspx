<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="AgregarAdicionales.aspx.cs" Inherits="AmbientHouse.Configuracion.Locaciones.AgregarAdicionales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 936px;
        }
        .auto-style3 {
            width: 367px;
        }
    </style>
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
                        Adicionales Locaciones<br />
                    </div>
                    <div class="panel-body">


                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    &nbsp;</td>
                                <td>
                                    <h3><asp:Label ID="LabelLocacion" runat="server"></asp:Label></h3>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <h3><asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label></h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Adicionales"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3"><h3><asp:Label ID="Label1" runat="server" Text="Precio:"></asp:Label></h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style2">
                                    &nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxActivo" runat="server" class="form-control" Checked="True" Text="Visible en el Cotizador?" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxCantidad" runat="server" class="form-control" Text="Requiere Cantidad?" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>
                <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Aceptar" ValidationGroup="Adicionales" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
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
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
