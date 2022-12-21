<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="SeguirAprobados.aspx.cs" Inherits="AmbientHouse.Administracion.PresupuestosAprobados.SeguirAprobados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 62px;
        }
    </style>
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
                                                                <asp:TextBox ID="TextBoxFechaDesdeEvento" runat="server" AutoPostBack="True" class="form-control" Width="700px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEvento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaDesdeEvento" TodaysDateFormat="" />
                                                            </th>
                                                            <td>
                                                                <asp:UpdateProgress ID="UpdateProgressGrilla" runat="server">
                                                                    <ProgressTemplate>
                                                                        <div style="text-align: center">
                                                                            <img src="../../Content/Imagenes/loading.gif" style="text-align: center" />
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
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
                                                                <table id="TableTipoCatering" style="width: 100%;" runat="server">
                                                                </table>
                                                                <table id="TableDetalle" style="width: 100%;" runat="server" border="1" class="table table-striped">
                                                                </table>

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
                                                                                <td>&nbsp;</td>
                                                                                <td>&nbsp;</td>
                                                                                <td>Ejecutivo:
                                                                            <h4>
                                                                                <asp:Label ID="LabelEjecutivo" runat="server" Font-Bold="True"></asp:Label></h4>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Hora Inicio:
                                                                                    <asp:TextBox ID="TextBoxHoraInicio" runat="server" AutoPostBack="True" class="form-control" Width="200px"></asp:TextBox>
                                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraInicio" TargetControlID="TextBoxHoraInicio" runat="server" Mask="99:99" MaskType="Time" AutoComplete="true" UserTimeFormat="TwentyFourHour" />
                                                                                    <asp:RequiredFieldValidator ID="HoraInicioRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraInicio" Display="Dynamic" ErrorMessage="Hora Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Eventos"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>&nbsp;</td>
                                                                                <td>Hora Fin:<asp:TextBox ID="TextBoxHoraFin" runat="server" AutoPostBack="True" class="form-control" Width="200px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="HoraFinRequiredFieldValidator" runat="server" ControlToValidate="TextBoxHoraFin" Display="Dynamic" ErrorMessage="Hora Inicio es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Eventos"></asp:RequiredFieldValidator>
                                                                                    <td>
                                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderHoraFin" runat="server" AutoComplete="true" Mask="99:99" MaskType="Time" TargetControlID="TextBoxHoraFin" UserTimeFormat="TwentyFourHour" />
                                                                                    </td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">&nbsp;</td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <asp:Button ID="ButtonModificarFechaEvento" runat="server" class="btn btn-success" OnClick="ButtonModificarFechaEvento_Click" Text="Modificar" />
                                                                                    <br />
                                                                                    <br />
                                                                                    <asp:Label ID="LabelMensaje" runat="server" class="form-control" Width="100%" CssClass="text-center" Text="Label" Font-Bold="True"></asp:Label>
                                                                                </td>
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

                                                                        <asp:GridView ID="GridViewVentas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewVentas_RowCommand" OnRowDataBound="GridViewVentas_RowDataBound">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#ffffcc" />
                                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                            <EmptyDataTemplate>
                                                                                ¡No hay Unidades agregadas al presupuesto!
                                                                            </EmptyDataTemplate>

                                                                            <Columns>
                                                                                <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                                                                <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />
                                                                                <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                                                <asp:BoundField DataField="PrecioSeleccionado" HeaderText="PL Seleccionado" SortExpression="PrecioSeleccionado" />
                                                                                <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                                                                                <asp:BoundField DataField="TipoLogisticaDescripcion" HeaderText="Logistica" SortExpression="TipoLogisticaDescripcion" />
                                                                                <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                                                                <asp:BoundField DataField="Logistica" HeaderText="Logistica Costo" DataFormatString="{0:C0}" SortExpression="Logistica" />
                                                                                <asp:BoundField DataField="Cannon" HeaderText="Cannon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                                                                                <asp:BoundField DataField="Comision" HeaderText="Comision" DataFormatString="{0:C0}" SortExpression="Comision" />
                                                                                <asp:BoundField DataField="NuevoValor" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="NuevoValor" />
                                                                                <asp:BoundField DataField="EstadoItem" HeaderText="Estado" SortExpression="EstadoItem" />
                                                                                <asp:BoundField DataField="FechaCreate" HeaderText="Fecha Alta" DataFormatString="{0:dd/MM/yyyy}" SortExpression="FechaCreate" />

                                                                                <%-- <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Fecha" runat="server" Text=""></asp:Label>
                                                                                        <asp:Button ID="ButtonPagado" runat="server" class="btn btn-success" Text="Cobrado" CommandName="Cobrado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>--%>

                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>

                                                                                        <asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar Item" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                    </div>

                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td>
                                                                    <h3>Total Organizador:</h3>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxTotalPorcOrganizador" runat="server" class="form-control" Font-Bold="True" ForeColor="Black" ReadOnly="True" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h3>Royalty:</h3>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxRoyalty" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100%" ForeColor="Black"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h3>Subtotal Presupuestado:</h3>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBoxSubtotalPresupuesto" runat="server" class="form-control" Font-Bold="True" ReadOnly="True" Width="100%" ForeColor="Black"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>

                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Salir" /></td>
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

    </table>

    <asp:UpdatePanel ID="UpdatePanelPagos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="panel-heading">
                <h3>Listado de Pagos Realizados</h3>
            </div>
            <asp:GridView ID="GridViewPagos" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered bs-table" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewPagos_RowCommand" Width="100%" OnRowDataBound="GridViewPagos_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#ffffcc" />
                <EmptyDataRowStyle CssClass="table table-bordered" ForeColor="Red" />
                <EmptyDataTemplate>
                    ¡No hay Pagos agregadas al presupuesto!
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                    <asp:BoundField DataField="TipoMovimientoDescripcion" HeaderText="Tipo Movimiento" SortExpression="TipoMovimientoDescripcion" />
                    <asp:BoundField DataField="FormaPagoDescripcion" HeaderText="Forma de pago" SortExpression="FormaPagoDescripcion" />

                    <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" SortExpression="FechaPago" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="ImporteNeto" HeaderText="Neto" DataFormatString="{0:C0}" SortExpression="ImporteNeto" />
                    <asp:BoundField DataField="TipoPago" HeaderText="Tipo Pago" SortExpression="TipoPago" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" />



                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Neto + Iva" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBoxImporte" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Importe" HeaderText="Neto + Iva" DataFormatString="{0:C0}" SortExpression="Importe" />--%>

                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Nro. Rec." ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBoxNroRecibo" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="EmpresaRazonSocial" HeaderText="Empresa" SortExpression="EmpresaRazonSocial" />

                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Quitar" Text="Quitar Pago" />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>

            <asp:UpdatePanel ID="UpdatePanelFacturas" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="panel-heading">
                        <h3>Listado de Facturas</h3>
                    </div>
                    <asp:GridView ID="GridViewFacturas" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="100" AllowPaging="True"  OnRowDataBound="GridViewFacturas_RowDataBound" >
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Facturas con los parametros seleccionados!  
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" HeaderStyle-Width="10px" />

<%--                            <asp:TemplateField ControlStyle-Width="250px" HeaderText="Empresa">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownListEmpresas" runat="server" CssClass="form-control"></asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="250px" />

                            </asp:TemplateField>

                            <asp:TemplateField ControlStyle-Width="200px" HeaderText="Comprobante">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownListTipoComprobantes" runat="server" CssClass="form-control"></asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="200" />
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="NroFactura" HeaderText="Nro. Factura" SortExpression="NroFactura" />
                            <asp:BoundField DataField="PresupuestoId" HeaderText="Nro. Presupuesto" />
                            <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" />
                            <asp:BoundField DataField="ClienteDescripcion" HeaderText="Razon Social" SortExpression="ClienteDescripcion" />
                            <asp:BoundField DataField="Cuit" HeaderText="Cuit" />
                            <asp:BoundField DataField="FechaStr" HeaderText="Fecha" SortExpression="FechaStr" />

                              <asp:TemplateField HeaderStyle-Width="400px" ControlStyle-Width="100%" HeaderText="Detalle Factura">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxDetalleFactura" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="400px" />
                            </asp:TemplateField>

                           <%--   <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonVer" runat="server" Text="Ver Detalle" class="btn btn-info" CommandName="VerDetalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="150px" />
                            </asp:TemplateField>--%>

                        <%--    <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                </ItemTemplate>
                                <ControlStyle Width="100%" />
                                <HeaderStyle Width="150px" />
                            </asp:TemplateField>

                          --%>

                        </Columns>

                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel-body">
                <p>
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Tipo Indexacion:</h4>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListTipoIndexacion" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="pp">Punta/Punta</asp:ListItem>
                                    <asp:ListItem Value="pc">Pago a Cuenta</asp:ListItem>
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
                            <td>
                                <h4>Total Pagado:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTotalPagado" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Indexacion:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxIndexacion" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                                <asp:Button ID="ButtonIndexacion" runat="server" class="btn btn-success" Text="Recalcular" OnClick="ButtonIndexacion_Click" />&nbsp;|&nbsp;
                                <asp:Button ID="ButtonConfirmarIndexacion" runat="server" class="btn btn-primary" Text="Confirmar" OnClick="ButtonConfirmarIndexacion_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Fecha Reserva:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxFechaReserva" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Cantidad dias Indexacion:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCantidadDiasIndexacion" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Saldo Al Dia del Evento:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSaldoAldiaDelEvento" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Saldo Al Dia de Hoy:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSaldoAlDiadeHoy" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <h4>Saldo Al Pago:</h4>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSaldoAlUltimoPago" runat="server" CssClass="form-control" ReadOnly="true" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                    </table>
                </p>
            </div>
            <div class="panel-body">
                <p>
                    <asp:Button ID="ButtonAgregarPago" runat="server" class="btn btn-info" Text="Agregar Pago" OnClick="ButtonAgregarPago_Click" />
                </p>
                <asp:Panel ID="PanelPagoClientes" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <h3>Tipo Pago</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListTipoPago" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoPago_SelectedIndexChanged">
                                    <asp:ListItem Value="null">&lt;Seleccionar&gt;</asp:ListItem>
                                    <asp:ListItem>Reserva</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Tipo Movimiento</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListTipoMovimiento" runat="server" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Empresa</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListEmpresa" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListEmpresa_SelectedIndexChanged">
                                    <asp:ListItem Value="3">&lt;Seleccionar una Empresa&gt;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Fecha Pago</h3>
                            </td>
                            <td>
                                <div style="text-align: left;">
                                    <asp:TextBox ID="TextBoxFechaPago" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                </div>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFechaPago" CultureName="en-nz" />
                                <asp:RequiredFieldValidator ID="FechaPagoRequired" runat="server" ControlToValidate="TextBoxFechaPago" Display="Dynamic" ErrorMessage="Fecha de Pago es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaPago" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaPago" TodaysDateFormat="" />
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h3>Nro Recibo</h3>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBoxNroRecibo" runat="server" class="form-control" Width="100px"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h3>Importe</h3>
                            </td>
                            <td class="auto-style1">
                                <div class="float-left">&nbsp;$&nbsp;</div>
                                <div class="float-left">
                                    <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="ImporteRequired" runat="server" ControlToValidate="TextBoxImporte" Display="Dynamic" ErrorMessage="Importe es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                            </td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <h3>Concepto</h3>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBoxConcepto" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConceptoRequired" runat="server" ControlToValidate="TextBoxConcepto" Display="Dynamic" ErrorMessage="Concepto es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <h3>Estado</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListEstadoPagos" runat="server" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Forma de Pago</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListFormadePago" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFormadePago_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Cuenta</h3>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListCuentas" runat="server" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="PanelCheques" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Cheques
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <h4>Nro. Cheque:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxNroCheque" runat="server" class="form-control" Width="150px"></asp:TextBox>

                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Fecha Emision:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaEmision" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaEmision_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEmision" TodaysDateFormat="" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Fecha Vencimiento:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaVencimiento" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaVencimiento_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimiento" TodaysDateFormat="" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <h4>Banco:</h4>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownListBancos" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Observaciones:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxObservaciones" runat="server" class="form-control" Height="150px" MaxLength="2000" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>

                                        </table>
                                </asp:Panel>
                                <asp:Panel ID="PanelTransferencia" runat="server">
                                    <div class="panel-body">
                                        <div class="panel-heading">
                                            Transferencias
                                        </div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <h4>Nro. Comprobante:</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxNroComprobanteTrans" runat="server" class="form-control" Width="150px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Fecha Comprobante</h4>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFechaComprobanteTrans" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="TextBoxFechaComprobanteTrans_CalendarExtender" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaComprobanteTrans" TodaysDateFormat="" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <h4>Cargar Comprobante de Pago Transferencia:</h4>
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="FileUploadComprobanteTransferencia" runat="server" /></td>
                                                <td>&nbsp;</td>
                                            </tr>

                                        </table>
                                    </div>
                                </asp:Panel>

                            </td>
                        </tr>
                        <tr>

                            <td colspan="2">
                                <asp:Label ID="LabelError" runat="server" Font-Bold="True" Font-Size="Medium" CssClass="text-center" ForeColor="#FF3300" Width="100%"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>

                                <asp:Button ID="ButtonGrabarPago" runat="server" class="btn btn-primary" OnClick="ButtonGrabarPago_Click" Text="Grabar" ValidationGroup="Items" />
                            </td>

                        </tr>
                    </table>

                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
