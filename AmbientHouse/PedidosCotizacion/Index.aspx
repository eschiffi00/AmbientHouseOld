<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.PedidosCotizacion.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Pedido de Cotizaciones</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Pedido" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdateProgress ID="UpdateProgressGrilla" runat="server">
                            <ProgressTemplate>
                                <div style="text-align: center">
                                    &nbsp;
                                </div>
                            </ProgressTemplate>

                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="UpdatePanelGrillaProductos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewProductos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" PageSize="200">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Productos con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="NroRequerimiento" HeaderText="Nro. Requerimiento" SortExpression="NroRequerimiento" />
                                        <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U.N." SortExpression="UnidadNegocioDescripcion" />
                                        <asp:BoundField DataField="LocacionDescripcion" HeaderText="Locacion" SortExpression="LocacionDescripcion" />
                                        <asp:BoundField DataField="UsuarioSolicitoNombre" HeaderText="Quien Solicito" SortExpression="UsuarioSolicitoNombre" />

                                      <%--  <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Costo $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxCosto" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Margen %" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxMargen" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Precio $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Estado" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Fecha Item" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxFecha" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFechaVencimiento" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" />

                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>--%>
                                        <asp:BoundField DataField="FechaPedida" HeaderText="Fecha del Pedido" DataFormatString="{0:dd/MM/yyyy}"  SortExpression="FechaPedida" />
                                      <%--  <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>--%>
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/PedidosCotizacion/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
