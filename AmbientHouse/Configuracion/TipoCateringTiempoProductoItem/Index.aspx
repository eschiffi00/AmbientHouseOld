<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.TipoCateringTiempoProductoItem.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Tipo Catering</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <div class="panel-body">

                    <table style="width: 100%;">

                        <tr>
                            <td>Experiencia:</td>
                            <td>
                                <asp:DropDownList ID="DropDownListTipoCatering" runat="server" class="form-control" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoCatering_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>


                    </table>

                </div>
                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Tipo Catering" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                        &nbsp;|&nbsp;
                        <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewTiempos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="GridViewTiempos_PageIndexChanging" PageSize="25" OnRowCommand="GridViewTiempos_RowCommand" OnRowDataBound="GridViewTiempos_RowDataBound">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                        <%--<asp:BoundField DataField="Telefono" HeaderText="Tel." SortExpression="Telefono" />--%>
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />


                                        <asp:BoundField DataField="TipoCateringDescripcion" HeaderText="Tipo Catering" SortExpression="TipoCateringDescripcion" />
                                        <asp:BoundField DataField="TiempoDescripcion" HeaderText="Tiempo" SortExpression="TiempoDescripcion" />
                                        <asp:BoundField DataField="ProductoCateringDescripcion" HeaderText="Producto" SortExpression="ProductoCateringDescripcion" />
                                        <asp:BoundField DataField="CategoriaItemDescripcion" HeaderText="Categoria Item" SortExpression="CategoriaItemDescripcion" />
                                        <asp:BoundField DataField="ItemDescripcion" HeaderText="Item" SortExpression="ItemDescripcion" />

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
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/TipoCateringTiempoProductoItem/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>
                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>

                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DropDownListTipoCatering" EventName="SelectedIndexChanged" />
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
            </table>

        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
