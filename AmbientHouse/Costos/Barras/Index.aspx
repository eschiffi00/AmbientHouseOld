<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Costos.Barras.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Costos Barras</h3><br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Lista de Precios Barras" OnClick="ButtonNuevo_Click"  />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default"  Text="Volver" OnClick="ButtonVolver_Click"    />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaCostoBarra" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewCostoBarra" runat="server"  CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewCostoBarra_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                       
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="TipoBarraDescripcion" HeaderText="Tipo Barra" SortExpression="TipoBarraDescripcion" />
                                        <asp:BoundField DataField="ProveedorDescripcion" HeaderText="Proveedor" SortExpression="ProveedorDescripcion" />
                                        <asp:BoundField DataField="CantidadPersonas" HeaderText="Cant. Personas" SortExpression="CantidadPersonas" />
                                        <asp:BoundField DataField="Costo" HeaderText="Costo $" SortExpression="Costo" />
                                        <asp:BoundField DataField="Precios" HeaderText="Precio $" SortExpression="Precios" />
                                        <asp:BoundField DataField="PrecioMas5" HeaderText="Pl + 5 $" SortExpression="PrecioMas5" />
                                        <asp:BoundField DataField="PrecioMenos5" HeaderText="Pl - 5 $" SortExpression="PrecioMenos5" />
                                        <asp:BoundField DataField="PrecioMenos10" HeaderText="Pl - 10 $" SortExpression="PrecioMenos10" />

                                  <%--       <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Rubros/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                       --%>

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
