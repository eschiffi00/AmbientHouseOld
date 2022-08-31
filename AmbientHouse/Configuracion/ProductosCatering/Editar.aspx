<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.ProductosCatering.Editar" %>

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
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Productos Catering</h3>
                        <br />
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
                                    <h3>Descripcion:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Adicionales"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCategorias" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCategorias_SelectedIndexChanged" Width="100%" AppendDataBoundItems="true">
                                    <asp:ListItem Value="null">&lt;Todas&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>

                                    <asp:UpdatePanel ID="UpdatePanelGrillaItems" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridViewItemsAsociados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" Caption="Items Asociados" OnRowCommand="GridViewItemsAsociados_RowCommand">
                                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Items con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>


                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonQuitarItem" runat="server" Text="Quitar" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>


                                            <asp:GridView ID="GridViewItemsNoAsociados" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" Caption="Items No Asociados">
                                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Items con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>

                                                    <asp:TemplateField>

                                                        <ItemTemplate>

                                                            <asp:CheckBox ID="CheckBoxSeleccionar" runat="server" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle" />

                                                </Columns>

                                            </asp:GridView>
                                        </ContentTemplate>

                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DropDownListCategorias" EventName="SelectedIndexChanged" />
                                        </Triggers>

                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <%-- <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelGrillaItemsNoAsociados" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                        </ContentTemplate>

                                     
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>--%>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Aceptar" ValidationGroup="Adicionales" OnClick="ButtonAceptar_Click" />
                                    <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                                </td>
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
