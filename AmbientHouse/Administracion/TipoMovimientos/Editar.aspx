<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.TipoMovimientos.Editar" %>

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
                        Agregar/Editar Tipo Movimientos
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td><h3>Tipo Movimiento Padre:</h3></td>
                                <td> <asp:DropDownList ID="DropDownListTipoMovimientoPadre" runat="server" class="form-control" AppendDataBoundItems="True" Width="70%">
                                        <asp:ListItem Value="NULL">&lt;Sin Tipo Movimiento Padre&gt;</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                              <tr>
                                <td>
                                    <h3>Codigo:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCodigo" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CodigoRequired" runat="server" ControlToValidate="TextBoxCodigo" Display="Dynamic" ErrorMessage="Codigo es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Descripcion:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="70%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    
                                </td>
                                <td>

                                   
                                    <asp:DropDownList ID="DropDownListVisible" runat="server" class="form-control" Width="40%">
                                        <asp:ListItem Value="N">Cuenta Totalizadora SI</asp:ListItem>
                                        <asp:ListItem Value="S">Cuenta Totalizadora No</asp:ListItem>
                                    </asp:DropDownList>

                                   
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td></td>
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
