<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteEstadoProveedoresEventosCerrados.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteEstadoProveedoresEventosCerrados" %>

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
                            <asp:TextBox ID="TextBoxDescripcionBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h3>Fecha Desde:</h3>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxNroFechaDesde" runat="server" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaDesde" runat="server" TargetControlID="TextBoxNroFechaDesde" Format="dd/MM/yyyy" DefaultView="Days" TodaysDateFormat="" />
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
                            <h3>Unidad de Negocio:</h3>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" class="form-control" Width="100%" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccione Unidad Negocio&gt;</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                      <tr>
                        <td>
                            <h3>Proveedor:</h3>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control" Width="100%" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccione Proveedor&gt;</asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h3>Estado Proveedor:</h3>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListEstadoProveedor" runat="server" class="form-control" Width="100%" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccione Un Estado&gt;</asp:ListItem>
                                <asp:ListItem Value="1">Confirmados</asp:ListItem>
                                <asp:ListItem Value="0">Pendiente</asp:ListItem>
                            </asp:DropDownList>
                        </td>
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
                                            ¡No hay Eventos con los parametros seleccionados!  
                                        </EmptyDataTemplate>

                                        <Columns>


                                            <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />



                                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presup." SortExpression="PresupuestoId" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="Locacion" HeaderText="Locacion" SortExpression="Locacion" />
                                            <asp:BoundField DataField="CantidadTotal" HeaderText="PAX" SortExpression="CantidadTotal" />
                                            <asp:BoundField DataField="HorarioEvento" HeaderText="Hora Desde" SortExpression="HorarioEvento" />
                                            <asp:BoundField DataField="HoraFinalizado" HeaderText="Hora Hasta" SortExpression="HoraFinalizado" />
                                            <asp:BoundField DataField="RazonSocialCliente" HeaderText="Razon Social Cliente" SortExpression="RazonSocialCliente" />

                                            <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                            <asp:BoundField DataField="EstadoProveedorDescripcion" HeaderText="Estado Proveedor" SortExpression="EstadoProveedorDescripcion" />
                                            <asp:BoundField DataField="ComentarioProveedor" HeaderText="Comentario Proveedor" SortExpression="ComentarioProveedor" />

                                            <%--  <asp:BoundField DataField="Ejecutivo" HeaderText="Ejecutivo" SortExpression="Ejecutivo" />
                                            <asp:BoundField DataField="HorarioEvento" HeaderText="Hora Inicio" SortExpression="HorarioEvento" />
                                            <asp:BoundField DataField="HoraFinalizado" HeaderText="Hora Fin" SortExpression="HoraFinalizado" />
                                            <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Evento" SortExpression="FechaEvento" />
                                            <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" SortExpression="EstadoDescripcion" />
                                            <asp:BoundField DataField="FechaReserva" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Reserva" SortExpression="FechaReserva" />--%>

                                            <%--   <asp:BoundField DataField="Locacion" HeaderText="Locacion" SortExpression="Locacion" />
                                            <asp:BoundField DataField="Caracteristica" HeaderText="Caracteristica" SortExpression="Caracteristica" />
                                            <asp:BoundField DataField="CantidadTotal" HeaderText="Invitados" SortExpression="CantidadTotal" />--%>


                                            <asp:BoundField DataField="TipoCatering" HeaderText="Tipo Catering" SortExpression="TipoCatering" />
                                            <asp:BoundField DataField="RazonSocialCatering" HeaderText="RS Catering" SortExpression="RazonSocialCatering" />
                                            <asp:BoundField DataField="TipoTecnica" HeaderText="Tipo Tecnica" SortExpression="TipoTecnica" />
                                            <asp:BoundField DataField="RazonSocialTecnica" HeaderText="RS Tecnica" SortExpression="RazonSocialTecnica" />
                                            <asp:BoundField DataField="TipoBarra" HeaderText="Tipo Barra" SortExpression="TipoBarra" />
                                            <asp:BoundField DataField="RazonSocialBarra" HeaderText="RS Barra" SortExpression="RazonSocialBarra" />
                                            <asp:BoundField DataField="TipoAmbientacion" HeaderText="Tipo Ambientacion" SortExpression="TipoAmbientacion" />
                                            <asp:BoundField DataField="RazonSocialAmbientacion" HeaderText="RS Ambientacion" SortExpression="RazonSocialAmbientacion" />
                                            <asp:BoundField DataField="CantidadAdicional" HeaderText="Cant. Adicional" SortExpression="CantidadAdicional" />
                                            <asp:BoundField DataField="Adicional" HeaderText="Adicionales" SortExpression="Adicional" />
                                            <asp:BoundField DataField="Comentario" HeaderText="Comentarios" SortExpression="Comentario" />
                                             <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C0}" SortExpression="Costo" />
                                             <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="Precio" />
                                                                                                                  

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
                            <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" Text="EXPORTAR A EXCEL" OnClick="ButtonExportarExcel_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>

    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
