<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteResponsables.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteResponsables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">

        <div class="panel panel-primary">
            <div class="panel-heading">Reporte Responsables Eventos</div>

            <div class="panel-body">

                <asp:UpdatePanel ID="UpdatePanelBuscador" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <h3>Nro. Presupuesto:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroPresupuesto" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Fecha Desde:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFechaDesde" runat="server" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Fecha Hasta:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFechaHasta" runat="server" class="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaHasta" runat="server" TargetControlID="TextBoxFechaHasta" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Organizador:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListOrganizador" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="null">&lt;Seleccione un Organizador&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxOrganizador" runat="server" OnCheckedChanged="CheckBoxOrganizador_CheckedChanged" Text="Sin Asignar" AutoPostBack="True" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Coordinador 1:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCoordinador1" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="null">&lt;Seleccione un Coordinador&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td> <asp:CheckBox ID="CheckBoxCoordinador1" runat="server"  Text="Sin Asignar" AutoPostBack="True" OnCheckedChanged="CheckBoxCoordinador1_CheckedChanged" /></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Coordinador 2:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCoordinador2" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="null">&lt;Seleccione un Coordinador&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td><asp:CheckBox ID="CheckBoxCoordinador2" runat="server"  Text="Sin Asignar" AutoPostBack="True" OnCheckedChanged="CheckBoxCoordinador2_CheckedChanged" /></td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <table style="width: 100%;">

                    <tr>
                        <td>&nbsp;</td>
                        <td></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>

                        <td>
                            <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewReporte" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Responsables con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup." SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="HorarioEvento" HeaderText="Hora Inicio" SortExpression="HorarioEvento" />
                                            <asp:BoundField DataField="HoraFinalizado" HeaderText="Hora Fin" SortExpression="HoraFinalizado" />
                                            <asp:BoundField DataField="Caracteristica" HeaderText="Caracteristica" SortExpression="Caracteristica" />
                                            <asp:BoundField DataField="Segmento" HeaderText="Segmento" SortExpression="Segmento" />
                                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                            <asp:BoundField DataField="Locacion" HeaderText="Locacion" SortExpression="Locacion" />
                                            <asp:BoundField DataField="Total_Invitados" HeaderText="Total Invitados" SortExpression="Total_Invitados" />
                                            <asp:BoundField DataField="Resp__Cocina" HeaderText="Resp. Cocina" SortExpression="Resp__Cocina" />
                                            <asp:BoundField DataField="Resp__Barra" HeaderText="Resp. Barra" SortExpression="Resp__Barra" />
                                            <asp:BoundField DataField="Resp__Logistica" HeaderText="Resp. Logistica" SortExpression="Resp__Logistica" />
                                            <asp:BoundField DataField="Resp__Operaciones" HeaderText="Resp. Operaciones" SortExpression="Resp__Operaciones" />
                                            <asp:BoundField DataField="Resp__Salon" HeaderText="Resp. Salon" SortExpression="Resp__Salon" />
                                            <asp:BoundField DataField="Coordinador_1" HeaderText="Coordinador 1" SortExpression="Coordinador_1" />
                                            <asp:BoundField DataField="HoraIngresoCoordinador1" HeaderText="Hora Ingreso Coord 1" SortExpression="HoraIngresoCoordinador1" />
                                            <asp:BoundField DataField="Coordinador_2" HeaderText="Coordinador 2" SortExpression="Coordinador_2" />
                                            <asp:BoundField DataField="HoraIngresoCoordinador2" HeaderText="Hora Ingreso Coord 2" SortExpression="HoraIngresoCoordinador2" />
                                            <asp:BoundField DataField="Organizador" HeaderText="Organizador" SortExpression="Organizador" />
                                            <asp:BoundField DataField="Resp__Logistica_Armado" HeaderText="Resp. Log. Armado" SortExpression="Resp__Logistica_Armado" />
                                            <asp:BoundField DataField="Resp__Logistica_Desarmado" HeaderText="Resp. Log. Desarmado" SortExpression="Resp__Logistica_Desarmado" />

                                        </Columns>

                                    </asp:GridView>
                                </ContentTemplate>

                            </asp:UpdatePanel>

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>

    </div>
</asp:Content>
