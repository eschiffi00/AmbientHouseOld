<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Items.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Items</h3>
            <br />
        </div>
          <div class="panel panel-primary">
                   

                    <div class="panel-body">

                        <table style="width: 100%;">
                            <tr>
                                <td>Detalle:</td>
                                <td>
                                    <asp:TextBox ID="TextBoxDetalleBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Categoria:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCategorias" runat="server" class="form-control" AppendDataBoundItems="true" Width="100%">
                                           <asp:ListItem Value="null">&lt;Seleccione Categoria&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                    </div>
                </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Item" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                        &nbsp;|&nbsp;
                        <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaItems" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewItems" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewItems_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridViewItems_PageIndexChanging" PageSize="25" OnRowCommand="GridViewItems_RowCommand">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Items con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />


                                        <asp:TemplateField HeaderText="Detalle" ControlStyle-Width="100%">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="300px" HeaderText="Categorias" ControlStyle-Width="300%">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="200px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Costo $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxCosto" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>

                                           <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Margen %" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxMargen" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </ItemTemplate>
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


                                        <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Items/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
