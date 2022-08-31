<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Ver.aspx.cs" Inherits="AmbientHouse.Presupuestos.Ver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanelCotizador" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="PanelCotixador" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Evento</div>
                                <div class="panel-body">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td></td>
                                            <td>
                                                <h3>Nro Evento:<asp:TextBox ID="TextBoxNroEvento" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox>
                                                </h3>




                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <h3>Nro Presupuesto:<asp:TextBox ID="TextBoxNroPresupuesto" runat="server" class="form-control" ReadOnly="True" Width="100%"></asp:TextBox>
                                                </h3>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <h3>Cliente:<asp:TextBox ID="TextBoxCientesApellido" runat="server" class="form-control" Width="100%" ReadOnly="True"></asp:TextBox>
                                                </h3>




                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <h3>Invitados:</h3>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Panel ID="PanelInvitados" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <th>Cant. de Mayores:</th>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantMayores" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>


                                                            </td>
                                                            <td>Cant. de Adolescentes:</td>
                                                            <td></td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantAdolescentes" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Cant. Menores de 3 años:</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantMenores3" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>Cant. entre 3 y 8 años:</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxCantEntre3y8" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <br />
                                                <asp:Panel ID="PanelFechaEvento" runat="server" GroupingText="">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <h3>Fecha Evento:</h3>
                                                                <asp:TextBox ID="TextBoxFechaDesdeEvento" runat="server" AutoPostBack="True" class="form-control" Width="700px" ReadOnly="True"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDesdeEvento" TodaysDateFormat="" />
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;
                                                   
                                                        <asp:Panel ID="PanelTipoEventos" runat="server">
                                                            <div class="panel-heading">
                                                                <h3>Datos del Evento</h3>
                                                            </div>
                                                            <div class="panel-body">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td>Tipo de Evento:
                                                                            <h4>
                                                                                <asp:Label ID="LabelTipoEvento" runat="server" Font-Bold="True"></asp:Label></h4>

                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Momento del Dia:
                                                                            <h4>
                                                                                <asp:Label ID="LabelMomentodelDia" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Caracteristicas:
                                                                             <h4>
                                                                                 <asp:Label ID="LabelCaracteristica" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Jornada:
                                                                            <h4>
                                                                                <asp:Label ID="LabelJornada" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Segmentos:
                                                                             <h4>
                                                                                 <asp:Label ID="LabelSegmentos" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Duracion Evento:
                                                                             <h4>
                                                                                 <asp:Label ID="LabelDuraciondelEvento" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Locaciones:
                                                                               <h4>
                                                                                   <asp:Label ID="LabelLocaciones" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Sector:
                                                                            <h4>
                                                                                <asp:Label ID="LabelSector" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Hora Inicio:
                                                                            <h4>
                                                                                <asp:Label ID="LabelHoraInicio" runat="server" Font-Bold="True"></asp:Label>
                                                                            </h4>
                                                                        </td>
                                                                        <td>&nbsp;</td>
                                                                        <td>Hora Fin:
                                                                            <h4>
                                                                                <asp:Label ID="LabelHoraFin" runat="server" Font-Bold="True"></asp:Label>
                                                                            </h4>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">Comentario Evento:<asp:TextBox ID="TextBoxComentarioEvento" runat="server" class="form-control" Height="166px" MaxLength="2000" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                                                                    </tr>

                                                                </table>
                                                            </div>
                                                        </asp:Panel>
                                                            </td>

                                                        </tr>
                                                        <tr>

                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="panel-heading">
                                                                        <h3>Listado de Unidades Cotizadas</h3>
                                                                    </div>
                                                                    <div class="panel-body">

                                                                        <asp:GridView ID="GridViewVentas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#ffffcc" />
                                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                            <EmptyDataTemplate>
                                                                                ¡No hay Unidades agregadas al presupuesto!  
                                                                            </EmptyDataTemplate>

                                                                            <Columns>

                                                                                <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />

                                                                                <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                                                <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />
                                                                                <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                                                                                <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                                                                <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                                                                <asp:BoundField DataField="Logistica" HeaderText="Logistica Costo" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                                                                <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                                                                <%--<asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />--%>
                                                                                <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <asp:GridView ID="GridViewVentasConRenta" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewVentasConRenta_RowDataBound">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#ffffcc" />
                                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                            <EmptyDataTemplate>
                                                                                ¡No hay Unidades agregadas al presupuesto!  
                                                                            </EmptyDataTemplate>

                                                                            <Columns>

                                                                                <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />


                                                                                <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                                                <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />
                                                                                <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                                                                                <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                                                                <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                                                                <asp:BoundField DataField="Logistica" HeaderText="Logistica Costo" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                                                                <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                                                                <asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />
                                                                                <asp:BoundField DataField="UsoCocina" HeaderText="Uso Cocina" DataFormatString="{0:C0}" SortExpression="UsoCocina" />
                                                                                <asp:BoundField DataField="ValorIntermediario" HeaderText="Intermediario" DataFormatString="{0:C0}" SortExpression="ValorIntermediario" />
                                                                                <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />
                                                                                <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C0}" SortExpression="Costo" />
                                                                                <asp:BoundField DataField="RentaUnPorcentaje" HeaderText="Renta %" />
                                                                                <asp:BoundField DataField="RentaUnNominal" HeaderText="Renta $" DataFormatString="{0:C0}" />


                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>

                                                                </td>
                                                            </tr>

                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>Total Organizador:<asp:TextBox ID="TextBoxTotalPorcOrganizador" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100%" ForeColor="Black"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LabelRentaTotal" runat="server" Text="Renta Total:"></asp:Label><asp:TextBox ID="TextBoxTotalRenta" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>Total Presupuestado:<asp:TextBox ID="TextBoxTotalPresupuesto" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>PAX<asp:TextBox ID="TextBoxTotalPAX" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>Comentario:<asp:TextBox ID="TextBoxComentarioPresupuesto" runat="server" class="form-control" Height="166px" MaxLength="2000" TextMode="MultiLine" Width="700px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;</td>

                                                        </tr>

                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" OnClick="ButtonVolver_Click" Text="Volver" /></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </asp:Panel>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>

            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td></td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
