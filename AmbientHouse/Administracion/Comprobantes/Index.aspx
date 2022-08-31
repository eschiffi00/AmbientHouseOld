<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Comprobantes.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Comprobantes</h3>
            <br />
        </div>
        <div class="panel-body">

            <asp:Panel ID="PanelBuscarCliente" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Nro. Comprobante:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxNroComprobante" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Cuit:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCuit" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Proveedor:</h4>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListProveedores" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccionar un Proveedor&gt;</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Fecha Comprobante Desde:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxFechaComprobanteDesde" class="form-control" runat="server" Width="200px" CssClass="black"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaComprobanteDesde" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaComprobanteDesde" TodaysDateFormat="" CssClass="black" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                     <tr>
                        <td>
                            <h4>Fecha Comprobante Hasta:</h4>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxFechaComprobanteHasta" class="form-control" runat="server" Width="200px" CssClass="black"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaComprobanteHasta" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaComprobanteHasta" TodaysDateFormat="" CssClass="black" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Estado:</h4>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccionar un Estado&gt;</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>&nbsp;</td>
                    </tr>
                     <tr>
                        <td>
                            <h4>Forma de Pago:</h4>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListFormaPago" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccionar Forma de Pago&gt;</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                       <tr>
                        <td>
                            <h4>Empresa:</h4>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListEmpresa" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                <asp:ListItem Value="null">&lt;Seleccionar Empresa&gt;</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="LabelTotal" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-primary" OnClick="ButtonBuscarCliente_Click" />
                            <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar" OnClick="ButtonLimpiar_Click" />
                        </td>
                        <td class="auto-style3"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>


            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Comprobante" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonPagoProveedor" runat="server" class="btn btn-primary" Text="Pagos" OnClick="ButtonPagoProveedor_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaComprobantes" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewComprobantes" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="40" AllowPaging="True" OnPageIndexChanging="GridViewComprobantes_PageIndexChanging" OnRowDataBound="GridViewComprobantes_RowDataBound" OnRowCommand="GridViewComprobantes_RowCommand">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Comprobante con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <%--<asp:BoundField DataField="NroOrdenPago" HeaderText="Nro. Orden Pago" SortExpression="NroOrdenPago" />--%>
                                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Tipo Comprobante" ControlStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListTipoComprobantes" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="TipoComprobanteDescripcion" HeaderText="Tipo Comprobante" SortExpression="TipoComprobanteDescripcion" />--%>
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" />
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Leyenda" SortExpression="RazonSocial" />
                                         <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" />
                                        <asp:BoundField DataField="NroComprobante" HeaderText="Nro Comprobante" SortExpression="NroComprobante" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Fecha" />
                                        <asp:BoundField DataField="MontoFactura" HeaderText="Monto Factura $" DataFormatString="{0:C0}" SortExpression="MontoFactura" />
                                        <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" SortExpression="EstadoDescripcion" />
                                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Empresas" ControlStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEmpresas" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100%">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonPagoProveedores" runat="server" Text="Pagos" class="btn btn-primary" CommandName="Pagos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                <asp:Button ID="ButtonAnular" runat="server" Text="Anular" class="btn btn-danger" CommandName="Anular" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                <asp:Button ID="ButtonNotaCredito" runat="server" Text="Nota Credito" class="btn btn-default" CommandName="NotaCredito" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                <asp:Button ID="ButtonVerPago" runat="server" Text="Ver Pago" class="btn btn-info" CommandName="VerPago" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Comprobantes/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
