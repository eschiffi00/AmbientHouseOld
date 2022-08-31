<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="CalendarioOrganizador.aspx.cs" Inherits="AmbientHouse.Organizador.CalendarioOrganizador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="width: 100%;">

        <tr>
            <%-- <td>&nbsp;</td>--%>
            <td>
                <asp:Button ID="ButtonHerramientas" runat="server" class="btn btn-info" Text="Experiencias" OnClick="ButtonHerramientas_Click" />&nbsp;|&nbsp;
                <asp:Button ID="ButtonVerListadoEventos" runat="server" class="btn btn-primary" Text="Listado Eventos" OnClick="ButtonVerListadoEventos_Click" />&nbsp;|&nbsp;
                <asp:Button ID="ButtonDegustacion" runat="server" class="btn btn-danger" Text="Degustacion" OnClick="ButtonDegustacion_Click" />&nbsp;|&nbsp;
                <asp:Button ID="ButtonEventosRealizados" runat="server" class="btn btn-success" Text="Eventos Realizados" OnClick="ButtonEventosRealizados_Click" />
            </td>
            <%-- <td>&nbsp;</td>--%>
        </tr>

        <tr>
            <td>


                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Filtrar por Box o Resto de Eventos:<asp:DropDownList ID="DropDownListTipoEvento" runat="server" CssClass ="form-control" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoEvento_SelectedIndexChanged">
                            <asp:ListItem>Eventos</asp:ListItem>
                            <asp:ListItem>Boxs</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td>&nbsp;&nbsp;
                 <asp:Label ID="LabelVisto" runat="server" Text="Label"></asp:Label>
                &nbsp;|&nbsp;
                <asp:Label ID="LabelNoVisto" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

        <tr>
            <%-- <td>&nbsp;</td>--%>
            <td>
                <asp:Calendar ID="CalendarEventos" runat="server" OnDayRender="CalendarEventos_DayRender" CssClass="form-control" OnSelectionChanged="CalendarEventos_SelectionChanged"></asp:Calendar>
            </td>
            <%-- <td>&nbsp;</td>--%>
        </tr>

    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
