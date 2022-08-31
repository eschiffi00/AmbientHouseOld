<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="PresupuestosARevisar.aspx.cs" Inherits="AmbientHouse.Administracion.PresupuestosAprobados.PresupuestosARevisar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <table id="TableTipoCatering" style="width: 100%;" runat="server">
    </table>
    <asp:UpdatePanel ID="UpdatePanelPresupuesto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="contenedor">

                <asp:GridView ID="GridViewVentas" runat="server"
                    CssClass="table table-bordered bs-table"
                    AutoGenerateColumns="False"
                    CellPadding="4"
                    EmptyDataText="No se Encontraron Registros"
                    ForeColor="#333333"
                    GridLines="None"
                    Width="100%" OnRowDataBound="GridViewVentas_RowDataBound" OnRowCommand="GridViewVentas_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#ffffcc" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No hay Unidades agregadas al presupuesto!  
                    </EmptyDataTemplate>

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                        <asp:BoundField DataField="ProductoId" HeaderText="Nro. Producto" SortExpression="ProductoId" />
                        <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="U. N." SortExpression="UnidadNegocioDescripcion" />
                        <asp:BoundField DataField="ProveedorRazonSocial" HeaderText="Proveedor" SortExpression="ProveedorRazonSocial" />
                        <asp:BoundField DataField="ProductoDescripcion" HeaderText="Producto" SortExpression="ProductoDescripcion" />
                         <asp:BoundField DataField="PrecioSeleccionado" HeaderText="Instancia" SortExpression="PrecioSeleccionado" />
                         <asp:BoundField DataField="PorcentajeDelTotalPresupuestoPorUnidadNegocio" HeaderText="% UN/Total" SortExpression="PorcentajeDelTotalPresupuestoPorUnidadNegocio" />
                        
                        <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                        <asp:BoundField DataField="CantidadAdicional" HeaderText="Cantidad" SortExpression="CantidadAdicional" />
                        <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                        <%-- <asp:BoundField DataField="UsoCocina" HeaderText="Logistica" DataFormatString="{0:C0}" SortExpression="UsoCocina" />
                        <asp:BoundField DataField="Logistica" HeaderText="Logistica" DataFormatString="{0:C0}" SortExpression="Logistica" />
                        <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:C0}" SortExpression="Costo" />
                       <%-- <asp:BoundField DataField="Cannon" HeaderText="Canon" DataFormatString="{0:C0}" SortExpression="Cannon" />
                        <asp:BoundField DataField="ValorSeleccionado" HeaderText="Precio" DataFormatString="{0:C0}" SortExpression="ValorSeleccionado" />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Uso de Cocina:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxUsoCocina" runat="server" CssClass="form-control" Width="150px"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>Logistica:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxLogistica" runat="server" CssClass="form-control" Width="150px"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>Canon:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCanon" runat="server" CssClass="form-control" Width="150px"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>Fee:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFee" runat="server" CssClass="form-control" Width="150px"></asp:TextBox></td>

                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Costo:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCosto" runat="server" CssClass="form-control" Width="150px"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>Precio:</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control" Width="150px"></asp:TextBox></td>

                                    </tr>

                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

            </div>
            <table style="width: 100%;">
                <tr>
                    <td>Valor Organizador:</td>
                    <td>
                        <asp:TextBox ID="TextBoxValorOrganizador" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Total Presupuesto:</td>
                    <td>
                        <asp:TextBox ID="TextBoxTotal" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td>Comentario:</td>
                    <td>
                        <asp:TextBox ID="TextBoxComentario" runat="server" CssClass="form-control"  TextMode="MultiLine" Width="997px"></asp:TextBox>
                      </td>
                </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                       <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar"  CssClass="btn btn-primary" OnClick="ButtonAceptar_Click" />&nbsp;|&nbsp;
                      <asp:Button ID="ButtonVolver" runat="server" Text="Volver" CssClass="btn btn-default" OnClick="ButtonVolver_Click" />
                    </td>
                </tr>

            </table>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
