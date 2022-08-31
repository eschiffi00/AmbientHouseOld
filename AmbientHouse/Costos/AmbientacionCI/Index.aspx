<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Costos.AmbientacionCI.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Costos Ambientacion Corporativo Informal</h3>
            <br />
        </div>

    </div>
    <div class="panel-body">
        <table style="width: 100%;">

            <tr>
                <td>&nbsp;</td>
                <td>

                    <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Costo Experiencia Ambientacion" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                    &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>

                <td>
                    <asp:UpdatePanel ID="UpdatePanelGrillaAmbientacion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewAmbientacion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewAmbientacion_PageIndexChanging" OnRowCommand="GridViewAmbientacion_RowCommand" OnRowDataBound="GridViewAmbientacion_RowDataBound">
                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Locaciones con los parametros seleccionados!  
                                </EmptyDataTemplate>
                                <Columns>

                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                    <asp:BoundField DataField="PaqueteCIDescripcion" HeaderText="Paquete" SortExpression="PaqueteCIDescripcion" />
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Proveedor" SortExpression="RazonSocial" />
                                    <asp:BoundField DataField="CantidadPaquetes" HeaderText="Rango Paquete" SortExpression="CantidadPaquetes" />
                                    <asp:BoundField DataField="Semestre" HeaderText="Semestre" SortExpression="Semestre" />
                                    <asp:BoundField DataField="Anio" HeaderText="Anio" SortExpression="Anio" />

                                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Costo Flete $" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxCostoFlete" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
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




                                    <%-- <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />--%>

                                    <%--  <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Estado" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>--%>


                                    <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                        </ItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFormatString="~/Costos/AmbientacionCI/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
