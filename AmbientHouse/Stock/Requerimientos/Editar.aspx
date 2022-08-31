<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Stock.Requerimientos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-sm">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    Agregar/Editar Requerimientos<br />
                                </div>
                                <div class="panel-body">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Detalle:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control" MaxLength="200" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Detalle es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h3>Fecha:</h3>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxFecha" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="FechaRequired" runat="server" ControlToValidate="TextBoxFecha" Display="Dynamic" ErrorMessage="Fecha es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFecha" runat="server" DefaultView="Years" Format="dd/MM/yyyy" TargetControlID="TextBoxFecha" TodaysDateFormat="" CssClass="black" />
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
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                            <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-secondary" OnClick="ButtonVolver_Click" />
                        </td>
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
                            <asp:UpdatePanel ID="UpdatePanelDetalleProductos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="PanelDetalle" runat="server">
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                Detalle Requerimientos<br />
                                            </div>
                                            <div class="panel-body">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <h3>Rubro</h3>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListRubros" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownListRubros_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>

                                                        <td>
                                                            <h3>Producto</h3>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListProducto" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                                        <td>
                                                            <h3>Cantidad</h3>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxCantidad" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td>
                                                            &nbsp;&nbsp;<asp:Button ID="ButtonAgregar" runat="server" Text="+" class="btn btn-success" OnClick="ButtonAgregar_Click" />
                                                        </td>
                                                    </tr>

                                                </table>

                                            </div>
                                            <div class="panel-body">
                                                <asp:GridView ID="GridViewRequerimientoDetalle" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True">
                                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#ffffcc" />
                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                    <EmptyDataTemplate>
                                                        ¡No hay Productos para el requerimiento!  
                                                    </EmptyDataTemplate>
                                                    <Columns>

                                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                        <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                        <asp:BoundField DataField="UnidadDescripcion" HeaderText="Unidad" SortExpression="UnidadDescripcion" />


                                                        <asp:TemplateField HeaderStyle-Width="20%" ControlStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="ButtonQuitar"  runat="server" Text="X" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="Quitar Producto" />
                                               
                                                            </ItemTemplate>
                                                            <ControlStyle Width="20%" />
                                                            <HeaderStyle Width="20%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>

                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>


                </table>
            </div>

        </div>
    </div>

    <script src="../../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../Boostrap4/js/popper.min.js"></script>
    <script src="../../Boostrap4/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>





