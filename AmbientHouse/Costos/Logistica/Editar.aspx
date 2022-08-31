<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Costos.Logistica.Editar" %>
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
                        Actualizar Precios/Costos Logistica<br />
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
                                    <h3>Tipo Logistica:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoLogistica" CssClass="form-control" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Localidad:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListLocalidad" CssClass="form-control" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Cantidad de Invitados:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCantidadInvitados" CssClass="form-control" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><h3>Tipo Evento:</h3></td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoEvento" CssClass="form-control" runat="server" Width="100%" AppendDataBoundItems ="true" >
                                         <asp:ListItem Value="null">&lt;Seleccione un Tipo de Evento&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td><h3>Precio:</h3></td>
                                <td>
                                    
                                    <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control" Width="200"></asp:TextBox>
                                    
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td><h3>Costo:</h3></td>

                                <td>
                                    <asp:TextBox ID="TextBoxCosto" runat="server" class="form-control" Width="200"></asp:TextBox>
                                    </td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                        </table>
                        <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Aceptar" OnClick="ButtonAceptar_Click" ValidationGroup="Aceptar" />&nbsp;|&nbsp;
                                    <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                    </div>

                   
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
