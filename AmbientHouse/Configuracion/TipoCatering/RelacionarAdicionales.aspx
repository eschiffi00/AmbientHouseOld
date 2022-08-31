<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="RelacionarAdicionales.aspx.cs" Inherits="AmbientHouse.Configuracion.TipoCatering.RelacionarAdicionales" %>

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
                        <h3>Relacionar Adicionales/Experiencias</h3>
                        <br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Adicional:</td>
                                <td class="auto-style2">
                                    <asp:Label ID="lblAdicional" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td>Familia:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListFamilias" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <asp:Button ID="ButtonAgregarFamilia" runat="server" Text="Agregar Familia" OnClick="ButtonAgregarFamilia_Click" class="btn btn-info"  />
                                    <asp:Button ID="ButtonQuitarFamilia" runat="server" Text="Quitar Familia" class="btn btn-default" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Items:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListItems" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <asp:Button ID="ButtonAgregarItem" runat="server" OnClick="ButtonAgregarItem_Click" Text="Agregar Item" class="btn btn-info" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div class="panel-heading">
                                        <h3>Experiencias</h3>
                                        <br />
                                    </div>
                                    <div class="panel-body">
                                    
                                            <asp:UpdatePanel ID="UpdatePanelArbol" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:TreeView ID="TreeViewExperiencias" runat="server">
                                                    </asp:TreeView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                      
                                    </div>
                                </td>
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

                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click"  class="btn btn-default" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
