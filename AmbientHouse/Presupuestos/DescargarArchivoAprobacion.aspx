<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="DescargarArchivoAprobacion.aspx.cs" Inherits="AmbientHouse.Presupuestos.DescargarArchivoAprobacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
          
            <td> <iframe src="ArchivoAprobacionEvento.ashx" width="0px" height="0px"></iframe>El Archivo se descargo con Exito!!!</td>
           
            
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
               
                <asp:Button ID="ButtonVolverInicio" runat="server"  class="btn btn-default" Text="Volver Inicio" OnClick="ButtonVolverInicio_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
