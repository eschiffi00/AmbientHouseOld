<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteBarras.aspx.cs" Inherits="AmbientHouse.Configuracion.TipoBarras.ReporteBarras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function imprSelec(muestra) {
             var ficha = document.getElementById(muestra);
             var ventimp = window.open(' ', 'popimpr');
             ventimp.document.write(ficha.innerHTML);
             ventimp.document.close();
             ventimp.print();
             ventimp.close();
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
     <div id="muestra">

        <div >
            <asp:Label ID="LabelExperiencia" runat="server" class="form-control" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
        </div>
        <table id="TableTipoCatering" style="width: 100%;" runat="server">
        </table>
        <table id="Experiencias" style="width: 100%;" runat="server" class="form-control">
        </table>
    </div>
    <a href="javascript:imprSelec('muestra')">Imprimir</a>
    <asp:LinkButton ID="LinkButtonVolver" runat="server" OnClick="LinkButtonVolver_Click">Volver</asp:LinkButton>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
