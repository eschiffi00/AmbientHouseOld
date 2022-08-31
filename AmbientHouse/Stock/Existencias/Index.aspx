<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Stock.Existencias.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Stock Productos</h3>
            <br />
        </div>
        <div class="panel-body">

            <table style="width: 100%;">
                 <tr>
                    <td>Codigo:</td>
                    <td>
                        <asp:TextBox ID="TextBoxCodigoBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Descripcion:</td>
                    <td>
                        <asp:TextBox ID="TextBoxDescripcionBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Descripcion:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListDepositos" class="form-control" runat="server" AppendDataBoundItems="true" Width="100%">
                            <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                        </asp:DropDownList></td>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Rubros:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListRubros" class="form-control" runat="server" AppendDataBoundItems="true" Width="100%">
                            <asp:ListItem Value="0">&lt;Seleccionar uno&gt;</asp:ListItem>
                        </asp:DropDownList></td>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
                         &nbsp;|&nbsp;<asp:Button ID="ButtonLimpiar" runat="server" class="btn btn-secondary" Text="Limpiar filtros" OnClick="ButtonLimpiar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </div>
    <div class="panel-body">
        <asp:UpdatePanel ID="UpdatePanelGrillaProductos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%;">

                    <tr>
                        <td>&nbsp;</td>
                        <td>

                            <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Inventario" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                            <%--&nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-secondary" Text="Volver" OnClick="ButtonVolver_Click" />--%>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>

                        <td>

                            <asp:GridView ID="GridViewExistencias" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnRowCommand="GridViewExistencias_RowCommand" OnRowDataBound="GridViewExistencias_RowDataBound" OnPageIndexChanging="GridViewExistencias_PageIndexChanging">
                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Productos con los parametros seleccionados!  
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="ProductoId" HeaderText="Nro Item" SortExpression="ProductoId" />
                                    <asp:BoundField DataField="DepositoId" HeaderText="Nro Deposito" SortExpression="DepositoId" />
                                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                    <asp:BoundField DataField="DepositoDescripcion" HeaderText="Deposito" SortExpression="DepositoDescripcion" />

                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Cant. Movimiento" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UnidadDescripcion" HeaderText="Und. Almacenamiento" SortExpression="UnidadDescripcion" />
                                    <asp:BoundField DataField="UnidadesConversion" HeaderText="Unidad/Porcion" SortExpression="UnidadesConversion" />
                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>

                                            <asp:Button ID="ButtonIngreso" runat="server" Text="Ingreso" class="btn btn-success" CommandName="Ingreso" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            <asp:Button ID="ButtonEgreso" runat="server" Text="Egreso" class="btn btn-danger" CommandName="Egreso" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="StockDeposito" HeaderText="Stock Deposito" SortExpression="StockDeposito" />
                                    <asp:BoundField DataField="StockDepositoPorUnidades" HeaderText="Stock Deposito Porciones" SortExpression="StockDepositoPorUnidades" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock General" SortExpression="Stock" />
                                    <asp:BoundField DataField="StockPorUnidades" HeaderText="Stock General Porciones" SortExpression="StockPorUnidades" />
                                      

                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>

                                            <asp:Button ID="ButtonEditar" runat="server" Text="Editar" class="btn btn-info" CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />

                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
