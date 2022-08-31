<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Costos.Canon.Editar" %>
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
                        Actualizar Precios/Costos Experiencias de Catering<br />
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
                                    <h3>Segmento:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListSegmento" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Caracteristica:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCaracteristica" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Tipo de Catering:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoCatering" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                             <tr>
                                <td>
                                    <h3>Cannon Interno:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCannonInterno" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CannonInternoRequired" runat="server" ControlToValidate="TextBoxCannonInterno" Display="Dynamic" ErrorMessage="Cannon Interno es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                             <tr>
                                <td>
                                    <h3>Cannon Externo:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCannonExterno" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CannonExternoRequiredFied" runat="server" ControlToValidate="TextBoxCannonExterno" Display="Dynamic" ErrorMessage="Cannon Interno es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Aceptar"></asp:RequiredFieldValidator>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Aceptar" OnClick="ButtonAceptar_Click" ValidationGroup="Aceptar" />&nbsp;&nbsp;|&nbsp;
                                    <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>
                            <tr>
                                <td>&nbsp;</td>

                                <td><asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Small" ForeColor="#FF3300"></asp:Label></td>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
