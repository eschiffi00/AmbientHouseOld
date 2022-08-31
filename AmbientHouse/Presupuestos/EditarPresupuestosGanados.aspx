<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="EditarPresupuestosGanados.aspx.cs" Inherits="AmbientHouse.Presupuestos.EditarPresupuestosGanados" %>

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
                                            <td>&nbsp;</td>
                                            <td>
                                                <br />
                                                <asp:Panel ID="PanelFechaEvento" runat="server" GroupingText="">
                                                    <table style="width: 100%;">

                                                        <tr>
                                                            <td>NRO. EVENTO:</td>
                                                            <td>
                                                                <h4>
                                                                    <asp:Label ID="LabelNroEvent" runat="server" Font-Bold="True" Width="400px"></asp:Label></h4>
                                                            </td>

                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>


                                                            <td>NRO. PRESUPUESTO:</td>

                                                            <td>
                                                                <h4>
                                                                    <asp:Label ID="LabelNroPresup" runat="server" Font-Bold="True" Width="400px"></asp:Label></h4>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>

                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="panel-footer">
                                                                        <h3>Cliente</h3>
                                                                        <asp:Label ID="LabelCLiente" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                                        <h3>Cantidad Invitados Inicial</h3>
                                                                        <asp:Panel ID="PanelInvitados" runat="server">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <th>Cant. de Mayores:</th>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantMayores" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>Cant. de Adolescentes:</td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantAdolescentes" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Cant. Menores de 3 años:</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantMenores3" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>Cant. entre 3 y 8 años:</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantEntre3y8" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <h3>Cantidad Invitados Final</h3>
                                                                        <asp:Panel ID="PanelInvitadosFinal" runat="server">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <th>Cant. de Mayores:</th>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantMayoresFinal" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>Cant. de Adolescentes:</td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantAdolescentesFinal" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Cant. Menores de 3 años:</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantMenores3Final" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>Cant. entre 3 y 8 años:</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantEntre3y8Final" runat="server" class="form-control" ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <h3>Cantidad Invitados Adicionales</h3>
                                                                        <asp:Panel ID="PanelInvitadosAdicionales" runat="server">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <th>Cant. de Mayores:</th>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantMayoresAdicionales" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>Cant. de Adolescentes:</td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantAdolescentesAdicionales" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Cant. Menores de 3 años:</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantMenores3Adicionales" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>Cant. entre 3 y 8 años:</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxCantEntre3y8Adicionales" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>Total por Invitados Extra:</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBoxTotalInvitadosAgregados" runat="server" class="form-control" Width="100px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:Button ID="ButtonAgregarInvitados" runat="server" class="btn btn-success" Text="Agregar Invitados" OnClick="ButtonAgregarInvitados_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <h3>Datos Evento</h3>
                                                                        <asp:Panel ID="PanelTipoEventos" runat="server">
                                                                            <div class="panel-body">
                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>Fecha Evento
                                                                                            <asp:TextBox ID="TextBoxFechaDesdeEvento" runat="server" AutoPostBack="True" class="form-control" ReadOnly="True" Width="700px"></asp:TextBox>
                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDesdeEvento" TodaysDateFormat="" />
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Tipo de Evento:
                                                                                            <h4>
                                                                                                <asp:Label ID="LabelTipoEvento" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Momento del Dia:
                                                                                            <h4>
                                                                                                <asp:Label ID="LabelMomentodelDia" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
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
                                                                                                <asp:Label ID="LabelCaracteristica" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Jornada:
                                                                                            <h4>
                                                                                                <asp:Label ID="LabelJornada" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
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
                                                                                                <asp:Label ID="LabelSegmentos" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Duracion Evento:
                                                                                            <h4>
                                                                                                <asp:Label ID="LabelDuraciondelEvento" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
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
                                                                                                <asp:Label ID="LabelLocaciones" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Sector:
                                                                                            <h4>
                                                                                                <asp:Label ID="LabelSector" runat="server" Font-Bold="True"></asp:Label>
                                                                                            </h4>
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

                                                                        <h3>Armar Cotizacion</h3>
                                                                        <asp:Panel ID="PanelArmarCotizacion" runat="server">

                                                                            <div class="panel-body">
                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Unidad de Negocio:<asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListUnidadNegocio_SelectedIndexChanged" Width="100%">
                                                                                            <asp:ListItem Value="0">&lt;Seleccionar Unidad de Negocio&gt;</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Proveedor<asp:DropDownList ID="DropDownListProveedor" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListProveedor_SelectedIndexChanged" Width="100%">
                                                                                            <asp:ListItem Value="null">&lt;Seleccionar un Proveedor&gt;</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Servicio<asp:DropDownList ID="DropDownListServicio" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListServicio_SelectedIndexChanged" Width="100%">
                                                                                            <asp:ListItem Value="0">&lt;Seleccionar un Producto&gt;</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>Precio Venta<asp:DropDownList ID="DropDownListPrecios" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" Width="100%">
                                                                                            <asp:ListItem Value="0">&lt;Seleccionar un Precio&gt;</asp:ListItem>
                                                                                            <asp:ListItem Value="1.05">PL + 5%</asp:ListItem>
                                                                                            <asp:ListItem Value="1">PL</asp:ListItem>
                                                                                            <asp:ListItem Value="0.95">PL - 5%</asp:ListItem>
                                                                                            <asp:ListItem Value="0.90">PL - 10%</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="LabelTipoLogistica" runat="server" Text="Tipo Logistica:"></asp:Label>
                                                                                            <asp:DropDownList ID="DropDownListConceptoLogistica" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListConceptoLogistica_SelectedIndexChanged" Width="100%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>
                                                                                            <asp:Label ID="LabelLocalidadLogistica" runat="server" Text="Localidad:"></asp:Label>
                                                                                            <asp:DropDownList ID="DropDownListLocalidadesLogisitca" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListLocalidadesLogisitca_SelectedIndexChanged" Width="100%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>
                                                                                            <asp:Label ID="LabelLogistica" runat="server" Text="Logistica:"></asp:Label>
                                                                                            <asp:TextBox ID="TextBoxCostoLogistica" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>
                                                                                            <asp:Label ID="LabelCantidadItemsOrganizacion" runat="server" Text="Cantidad:"></asp:Label>
                                                                                            <asp:TextBox ID="TextBoxCantidadItemsOrganizacion" runat="server" class="form-control"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>


                                                                                    <tr>
                                                                                        <td class="auto-style2"></td>
                                                                                        <td class="auto-style2"></td>
                                                                                        <td class="auto-style2"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="auto-style2">&nbsp;</td>
                                                                                        <td class="auto-style2">&nbsp;</td>
                                                                                        <td class="auto-style2">&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>

                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </asp:Panel>
                                                                        <div>
                                                                            <asp:Panel ID="PanelAmbientacionCorporativoInformal" runat="server">
                                                                                <div class="panel-heading">
                                                                                    <h3>Ambientacion Corporativa Informal</h3>
                                                                                </div>
                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>Items de Ambientacion</td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DropDownListCIItemsAmbientacion" runat="server" CssClass="form-control"></asp:DropDownList>
                                                                                        </td>

                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>

                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>Cantidad de Paquetes</td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DropDownListCICantidadPaquetesAmbientacion" runat="server" CssClass="form-control">
                                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                                <asp:ListItem>15</asp:ListItem>
                                                                                                <asp:ListItem>20</asp:ListItem>
                                                                                                <asp:ListItem>25</asp:ListItem>
                                                                                              
                                                                                            </asp:DropDownList>
                                                                                        </td>

                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>

                                                                                    </tr>


                                                                                    <div>
                                                                                    </div>
                                                                            </asp:Panel>

                                                                        </div>

                                                                        <div>
                                                                            <asp:Button ID="ButtonAgregarItem" runat="server" class="btn btn-success" OnClick="ButtonAgregarItem_Click" Text="Agregar al Presupuesto" />


                                                                        </div>
                                                                        <h3>Listado de Unidades Cotizadas</h3>
                                                                        <asp:GridView ID="GridViewVentas" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewVentas_RowCommand" OnRowDataBound="GridViewVentas_RowDataBound" Width="100%">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#ffffcc" />
                                                                            <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                                                                            <EmptyDataTemplate>
                                                                                ¡No hay Unidades agregadas al presupuesto!&nbsp;&nbsp;
                                                                            </EmptyDataTemplate>
                                                                            <Columns>
                                                                                <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />
                                                                                <asp:BoundField DataField="ProductoId" HeaderText="Nro Item" SortExpression="ProductoId" />
                                                                                <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                                                <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />
                                                                                <%--<asp:BoundField DataField="Comision" DataFormatString="{0:C0}" HeaderText="Comision" SortExpression="Comision" />--%>
                                                                                <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                                                                <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                                                                <asp:BoundField DataField="Logistica" DataFormatString="{0:C0}" HeaderText="Logistica Costo" SortExpression="Logistica" />
                                                                                <asp:BoundField DataField="Cannon" DataFormatString="{0:C0}" HeaderText="Cannon" SortExpression="Cannon" />
                                                                                <asp:BoundField DataField="UsoCocina" DataFormatString="{0:C0}" HeaderText="Uso Cocina" SortExpression="UsoCocina" />
                                                                                <asp:BoundField DataField="ValorIntermediario" DataFormatString="{0:C0}" HeaderText="Fee" SortExpression="ValorIntermediario" />
                                                                                <asp:BoundField DataField="PrecioItem" DataFormatString="{0:C0}" HeaderText="Precio" SortExpression="PrecioItem" />
                                                                                <asp:BoundField DataField="NuevoValor" DataFormatString="{0:C0}" HeaderText="Precio Ajustado" SortExpression="NuevoValor" />
                                                                                <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                                                                                <asp:BoundField DataField="ProveedorId" HeaderStyle-Width="0px" HeaderText="" ItemStyle-Width="0px" SortExpression="ProveedorId">
                                                                                    <HeaderStyle Width="0px" />
                                                                                    <ItemStyle Width="0px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="UnidadNegocioId" HeaderStyle-Width="0px" HeaderText="" ItemStyle-Width="0px" SortExpression="UnidadNegocioId">
                                                                                    <HeaderStyle Width="0px" />
                                                                                    <ItemStyle Width="0px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Id" HeaderStyle-Width="0px" HeaderText="" ItemStyle-Width="0px" SortExpression="Id">
                                                                                    <HeaderStyle Width="0px" />
                                                                                    <ItemStyle Width="0px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="EstadoItem" HeaderText="Estado" SortExpression="EstadoItem" />
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="ButtonPresupuestarAdicionales" runat="server" class="btn btn-info" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="CargarAdicionales" Text="Cargar Adicionales" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="ButtonQuitarItem" runat="server" class="btn btn-danger" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="QuitarItem" Text="Quitar" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="ButtonAprobarItem" runat="server" class="btn btn-primary" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="AprobarItem" Text="Aprobar Item" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:Panel ID="PanelAdicionales" runat="server">
                                                                            <div class="panel-heading">
                                                                                <h3>Adicionales</h3>
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DropDownListAdicionales" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DropDownListAdicionales_SelectedIndexChanged" Width="100%">
                                                                                                <asp:ListItem Value="0">&lt;Seleccionar un Producto&gt;</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>&nbsp;&nbsp;<asp:Button ID="ButtonAgregarAdicional" runat="server" class="btn btn-success" OnClick="ButtonAgregarAdicional_Click" Text="Agregar Adicional" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="LabelCantidadAdicional" runat="server" Text="Cantidad:"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBoxCantidadAdicional" runat="server" class="form-control"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </asp:Panel>
                                                                        <asp:Label ID="LabelMensajeAdicionales" runat="server" class="form-control" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300" Width="100%"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>Total Organizador:<asp:TextBox ID="TextBoxTotalPorcOrganizador" runat="server" class="form-control" Font-Bold="True" ForeColor="Black" ReadOnly="True" Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
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
                                                                    <td>Comentario:<asp:TextBox ID="TextBoxComentarioPresupuesto" runat="server" class="form-control" Height="166px" MaxLength="2000" ReadOnly="True" TextMode="MultiLine" Width="700px"></asp:TextBox>
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
                                                                    <td>
                                                                        <asp:Button ID="ButtonVerCambios" runat="server" class="btn btn-info" Text="Ver Presupuesto Pendiente" OnClick="ButtonVerCambios_Click" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="ButtonGuardarCambios" runat="server" class="btn btn-primary" OnClick="ButtonGuardarCambios_Click" Text="Ver Presupuesto Aprobado" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Salir" />
                                                                    </td>
                                                                </tr>
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

                        <asp:Panel ID="PanelVisorPDF" runat="server">

                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <iframe height="780px" src="Presupuesto.ashx" width="100%"></iframe>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <div class="panel-footer">
                                            &nbsp;
                                    <asp:Button ID="ButtonSalir" runat="server" class="btn btn-primary" OnClick="ButtonSalir_Click" Text="Salir" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                        <asp:Panel ID="PanelPendientePDF" runat="server">

                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <iframe height="780px" src="PresupuestoClienteCambios.ashx" width="100%"></iframe>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <div class="panel-footer">
                                            &nbsp;
                                    <asp:Button ID="ButtonSalirPendiente" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonSalirPendiente_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
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

















<%--  <asp:Panel ID="PanelInvitados" runat="server">
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
                                                </asp:Panel>--%>


<%--     <asp:Panel ID="PanelTipoEventos" runat="server">
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

                                                                </table>
                                                            </div>
                                                        </asp:Panel>--%>