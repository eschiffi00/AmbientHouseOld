<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Cheques.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Cheques</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">
                <tr>
                    <td>Nro. Cheque</td>
                    <td>
                        <asp:TextBox ID="TextBoxNroCheque" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Razon Social:</td>
                    <td>
                        <asp:TextBox ID="TextBoxRazonSocial" class="form-control" runat="server" Width="300px" AutoPostBack="True"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Vencimiento Desde:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaVencimientoDesde" class="form-control" runat="server" Width="200px" CssClass="black"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimientoDesde" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimientoDesde" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Vencimiento Hasta:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaVencimientoHasta" class="form-control" runat="server" Width="200px" CssClass="black"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimientoHasta" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaVencimientoHasta" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Emision Desde:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaEmisionDesde" class="form-control" runat="server" Width="200px" CssClass="black"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEmisionDesde" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEmisionDesde" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Emision Hasta:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFechaEmisionHasta" class="form-control" runat="server" Width="200px" CssClass="black"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaEmisionHasta" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFechaEmisionHasta" TodaysDateFormat="" CssClass="black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Cuentas:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListCuentas" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCuentas_SelectedIndexChanged">
                            <asp:ListItem Value="0">&lt;Seleccione una Cuenta&gt;</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Estados:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListEstados" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">&lt;Seleccione un Estado&gt;</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Saldo Cuenta Seleccionada:</td>
                    <td>
                        <asp:TextBox ID="TextBoxSaldo" class="form-control" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Total Importe:</td>
                    <td>
                        <asp:TextBox ID="TextBoxImporte" class="form-control" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td>Ingrese el Saldo de la Cuenta:</td>
                    <td>
                        <asp:TextBox ID="TextBoxSaldoCuenta" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td>Otros Conceptos a Debitar:</td>
                    <td>
                        <asp:TextBox ID="TextBoxOtrosConceptoADebitar" class="form-control" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <%-- <tr>
                    <td>Total Importe Pendiente Proveedores:</td>
                    <td>
                        <asp:TextBox ID="TextBoxImportePendienteProveedor" class="form-control" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>Total Importe Pendiente Clientes:</td>
                    <td>
                        <asp:TextBox ID="TextBoxImportePendienteClientes" class="form-control" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />&nbsp;|&nbsp;
                        <asp:Button ID="ButtonLimpiar" class="btn btn-default" runat="server" Text="Limpiar Filtros" OnClick="ButtonLimpiar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelGrillaCheques" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Cheques" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                                &nbsp;|&nbsp;<asp:Button ID="ButtonAcreditados" runat="server" class="btn btn-primary" Text="Acreditados" OnClick="ButtonAcreditados_Click" />
                                &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                                &nbsp;|&nbsp;<asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>

                            <td>

                                <asp:GridView ID="GridViewCheques" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="100" AllowPaging="True" OnPageIndexChanging="GridViewCheques_PageIndexChanging" OnRowDataBound="GridViewCheques_RowDataBound" OnRowCommand="GridViewCheques_RowCommand">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Cheques con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                        <asp:BoundField DataField="NroCheque" HeaderText="Nro. Cheque" SortExpression="NroCheque" />
                                        <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" />
                                        <asp:TemplateField HeaderStyle-Width="300px" HeaderText="Cuenta" ControlStyle-Width="100%">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListCuenta" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                                      <asp:ListItem Value="null">&lt;Sin Asignar Cuenta&gt;</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="300px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProveedorDescripcion" HeaderText="Proveedor" SortExpression="ProveedorDescripcion" />
                                        <asp:BoundField DataField="ClienteDescripcion" HeaderText="Cliente" SortExpression="ClienteDescripcion" />
                                        <asp:BoundField DataField="FechaEmisionStr" HeaderText="Fec. Emision" SortExpression="FechaEmisionStr" />
                                        <asp:BoundField DataField="FechaVencimientoStr" HeaderText="Fec. Vencimiento" SortExpression="FechaVencimientoStr" />
                                        <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" SortExpression="EstadoDescripcion" />
                                         <asp:BoundField DataField="Observaciones" HeaderText="Observacion" SortExpression="Observaciones" />
                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo" SortExpression="Saldo" />
                                        <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                 <asp:Button ID="ButtonEditar" runat="server" Text="Editar" class="btn btn-info" CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>


                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
