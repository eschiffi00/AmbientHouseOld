<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Stock.Existencias.Editar" %>

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
                        Agregar/Editar Existencias por Deposito<br />
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
                                    <h3>Deposito:</h3>
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="DropDownListDepositos" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Rubro:</h3>
                                </td>
                                <td>

                                    <asp:DropDownList ID="DropDownListRubros" runat="server" class="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropDownListRubros_SelectedIndexChanged">
                                        <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Producto:</h3>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelExistencias" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListProductos" runat="server" class="form-control" AppendDataBoundItems="true" >
                                                <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListRubros" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Cantidad:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCantidad" runat="server" class="form-control" MaxLength="200" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CantidadRequired" runat="server" ControlToValidate="TextBoxCantidad" Display="Dynamic" ErrorMessage="Cantidad es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Unidades:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListUnidades" runat="server" AppendDataBoundItems="true" class="form-control">
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
