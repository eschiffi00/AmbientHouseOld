<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="VisualizaArchivo.aspx.cs" Inherits="AmbientHouse.Herramientas.Corporativos.VisualizaArchivo" %>

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
          
            <td> <iframe src="ArchivosDescargas.ashx" width="0px" height="0px"></iframe>El Archivo se descargo con Exito!!!</td>
           
            
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonVolverHerramientas" runat="server" OnClick="ButtonVolverHerramientas_Click" class="btn btn-default" Text="Volver a Herramientas" />
                <asp:Button ID="ButtonVolverInicio" runat="server" OnClick="ButtonVolverInicio_Click" class="btn btn-default" Text="Volver Inicio" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
