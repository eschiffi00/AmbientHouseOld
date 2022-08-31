<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.Cuentas.Editar" %>
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
                        Agregar/Editar Cajas<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><h3>Nombre:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxNombre" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxNombre" Display="Dynamic" ErrorMessage="Nombre es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                             <tr>
                                <td><h3>Descripcion:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control"></asp:TextBox>
                                    
                                </td>
                                <td></td>
                            </tr>
                             <tr>
                                <td><h3>Tipo de Cuenta:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoCuenta" CssClass="form-control" runat="server">
                                        <asp:ListItem>BANCARIA</asp:ListItem>
                                        <asp:ListItem>EFECTIVO</asp:ListItem>
                                        <asp:ListItem>CHEQUE</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </td>
                                <td></td>
                            </tr>
                              <tr>
                                <td><h3>Moneda:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListMonedas" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    
                                </td>
                                <td></td>
                            </tr>
                              <tr>
                                <td><h3>Empresa:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListEmpresa" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    
                                </td>
                                <td></td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info"  />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
