<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Stock.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Boostrap4/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="row">

            <div class="col-sm">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Stock Productos</h3>
                        <br />
                    </div>
                    <div class="panel-body">

                        <table style="width: 100%;">
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
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />

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

                                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Producto" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-secondary" Text="Volver" OnClick="ButtonVolver_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>

                                    <td>

                                        <asp:GridView ID="GridViewProductos" runat="server" CssClass="table table-bordered table-condensed" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewProductos_PageIndexChanging" OnRowCommand="GridViewProductos_RowCommand" OnRowDataBound="GridViewProductos_RowDataBound">
                                            <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#ffffcc" />
                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                            <EmptyDataTemplate>
                                                ¡No hay Productos con los parametros seleccionados!  
                                            </EmptyDataTemplate>
                                            <Columns>


                                                <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Cantidad Exist." ControlStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBoxCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <HeaderStyle Width="100px" />
                                                </asp:TemplateField>

                                                <asp:HyperLinkField DataNavigateUrlFormatString="~/Stock/Productos/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-dark" DataNavigateUrlFields="Id" Text="Editar">
                                                    <ControlStyle CssClass="btn btn-info" />
                                                </asp:HyperLinkField>

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
        </div>

    </div>
    <script src="../../Boostrap4/js/jquery-3.3.1.slim.min.js"></script>
    <script src="../../Boostrap4/js/popper.min.js"></script>
    <script src="../../Boostrap4/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
