<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Categorias.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 56px;
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
                                <td>
                                    <h3>Descripcion:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" MaxLength="200" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <h3>Locacion:</h3>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="DropDownListLocaciones" runat="server" class="form-control" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownListLocaciones_SelectedIndexChanged">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Sector:</h3>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelSectores" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListSectores" runat="server" class="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListLocaciones" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Segmento:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSegmentos" runat="server" class="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Caracteristica:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCaracteristicas" runat="server" class="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
