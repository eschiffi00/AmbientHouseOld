<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteExperiencias.aspx.cs" Inherits="AmbientHouse.Configuracion.TipoCatering.ReporteExperiencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td> <iframe height="780px" src="CateringExperiencias.ashx" width="100%"></iframe></td>
            <td>&nbsp;</td>
        </tr>
       
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
