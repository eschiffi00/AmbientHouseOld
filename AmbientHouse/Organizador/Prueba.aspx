<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="AmbientHouse.Organizador.Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
      <table style="width: 100%;">
      
          <tr>
           <%-- <td>&nbsp;</td>--%>
            <td>
                 <asp:Button ID="ButtonHerramientas" runat="server" class="btn btn-info" Text="Experiencias"  />&nbsp;|&nbsp;
                <asp:Button ID="ButtonVerListadoEventos" runat="server" class="btn btn-primary" Text="Listado Eventos"  />&nbsp;|&nbsp;
                <asp:Button ID="ButtonDegustacion" runat="server" class="btn btn-danger" Text="Degustacion"  />
            </td>
           <%-- <td>&nbsp;</td>--%>
        </tr>

          <tr>
            <td>
                 &nbsp;</td>
        </tr>

          <tr>
            <td>
                &nbsp;&nbsp;
                 <asp:Label ID="LabelVisto" runat="server" Text="Label"></asp:Label>
                &nbsp;|&nbsp;
                <asp:Label ID="LabelNoVisto" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

        <tr>
           <%-- <td>&nbsp;</td>--%>
            <td>
                <asp:Calendar ID="CalendarEventos" runat="server"  CssClass="form-control" ></asp:Calendar>
            </td>
           <%-- <td>&nbsp;</td>--%>
        </tr>
       
    </table>
</asp:Content>
