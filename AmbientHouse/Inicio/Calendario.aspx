<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="AmbientHouse.Inicio.Calendario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">
        function showmodalpopup1() {
            $("#popupdiv").dialog({

                width: 400,
                height: 150,
                autoOpen: true,
                draggable: false,
                resizable: false,
                hide: "slide",
                modal: true,


            });
        };

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <table style="width: 100%;">
      
        <tr>
           <%-- <td>&nbsp;</td>--%>
            <td>
                <asp:Calendar ID="CalendarEventos" runat="server" OnDayRender="CalendarEventos_DayRender" CssClass="form-control"></asp:Calendar>
            </td>
           <%-- <td>&nbsp;</td>--%>
        </tr>
       
    </table>
     <asp:Button ID="ButtonSalir" runat="server" class="btn btn-primary" OnClick="ButtonSalir_Click" Text="Salir" />

 <%--   <div id="popupdiv">

        Hola!!!!
    </div>--%>
   
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
