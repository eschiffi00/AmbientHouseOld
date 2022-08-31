<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Tiempos.Editar" %>
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
                        Agregar/Editar Tiempos</div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><h3>Descripcion:</h3></td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Detalle es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><h3>Orden</h3> (Indica en que orden se va a visualizar):</td>
                                <td>
                                    <asp:TextBox ID="TextBoxOrden" runat="server" class="form-control"></asp:TextBox></td>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items"  class="btn btn-info" OnClick="ButtonAceptar_Click"   />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver"  class="btn btn-óutline-primary" OnClick="ButtonVolver_Click"  />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
