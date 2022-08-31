<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="RelacionarTipoCatering.aspx.cs" Inherits="AmbientHouse.Configuracion.TipoCatering.RelacionarTipoCatering" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
                        <h3>Relacionar Tipo Catering/Experiencias</h3>
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
                                <td>
                                    <h3>Tipo de Catering:</h3>
                                </td>
                                <td>
                                    <h3><asp:Label ID="lblTipoCatering" runat="server"></asp:Label></h3>
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
                                <td colspan="3">
                                    <div class="panel-heading">
                                        <h3>Experiencias para Catering</h3>
                                        <br />
                                        <iframe src="ReporteExperiencias.aspx" style="width: 100%; height: 571px">

                                        </iframe>
                                    </div>
                                    <div class="panel-body">
                                        <asp:Panel ID="Panel1" runat="server" GroupingText="">
                                            <asp:UpdatePanel ID="UpdatePanelArbol" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TreeView ID="TreeViewExperiencias" runat="server">
                                                                </asp:TreeView>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
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

                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
