<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Localidades.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
      <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Localidades</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3><asp:Label ID="LabelDescipcion" runat="server" Text="Descripcion"></asp:Label></h3>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxDescripcion" runat="server" Width="300px"  class="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>

                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                       
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click"  class="btn btn-info" Text="Aceptar" ValidationGroup="Cliente" />
                        &nbsp;
                &nbsp;<asp:Button ID="ButtonVolver" runat="server"  class="btn btn-default" OnClick="ButtonVolver_Click" Text="Volver" />
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                </table>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
