<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.TipoBarrasCategoriasItem.Editar" %>
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
                        Agregar/Editar Experiencia Tipo Barras
                    </div>
                    <div class="panel-body">
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
                                <td>Tipo Barra:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoBarra" runat="server" class="form-control" Width="100%">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                            </tr>
                          
                           
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Categorias:</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelCategorias" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListCategorias" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCategorias_SelectedIndexChanged">
                                                <asp:ListItem Value="null">&lt;Seleccione Categorias&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                         <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListItmes" EventName="SelectedIndexChanged" />
                                           
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>Items:</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelItems" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListItmes" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListItmes_SelectedIndexChanged">
                                                <asp:ListItem Value="null">&lt;Seleccione Items&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListCategorias" EventName="SelectedIndexChanged" />
                                           
                                        </Triggers>
                                    </asp:UpdatePanel>
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
