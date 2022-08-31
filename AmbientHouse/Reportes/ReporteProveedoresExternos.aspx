<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteProveedoresExternos.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteProveedoresExternos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
       <div class="panel panel-primary">
    
        <div class="panel panel-primary">
            <div class="panel-heading">Reporte Proveedores Eventos Cerrados</div>

              <div class="panel-body">

                 <table style="width: 100%;">
                    <tr>
                        <td>Nro. Presupuesto:</td>
                        <td>
                            <asp:TextBox ID="TextBoxNroPresupuesto" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>Fecha Desde:</td>
                    <td><asp:TextBox ID="TextBoxFechaDesde" runat="server" class="form-control"></asp:TextBox>
                          <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                        </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Hasta:</td>
                    <td><asp:TextBox ID="TextBoxFechaHasta" runat="server" class="form-control"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaHasta" runat="server" TargetControlID="TextBoxFechaHasta" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                      <tr>
                    <td>Razon Social:</td>
                    <td>
                         <asp:TextBox ID="TextBoxRazonSocial" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                    <td>&nbsp;</td>
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
                                            ¡No hay Proveedores con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:BoundField DataField="Id" HeaderText="Nro. Presup." SortExpression="Id" />
                                            <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                            <asp:BoundField DataField="HorarioEvento" HeaderText="Hora Inicio" SortExpression="HorarioEvento" />
                                            <asp:BoundField DataField="HoraFinalizado" HeaderText="Hora Fin" SortExpression="HoraFinalizado" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="Locacion" HeaderText="Locacion" SortExpression="Locacion" />
                                            <asp:BoundField DataField="Total_Invitados" HeaderText="Locacion" SortExpression="Total_Invitados" />

                                            <asp:BoundField DataField="Proveedor" HeaderText="Razon Social" SortExpression="Proveedor" />
                                            <asp:BoundField DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" />
                                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
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
