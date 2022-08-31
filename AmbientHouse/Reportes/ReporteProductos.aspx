<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="ReporteProductos.aspx.cs" Inherits="AmbientHouse.Reportes.ReporteProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Reporte Informe de Resultados</div>
        <div class="panel-body">

            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <h3>Nro Item:</h3>
                        </td>
                    <td>
                        <asp:TextBox ID="TextBoxNroItem" runat="server" CssClass="form-control"></asp:TextBox></td>

                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Unidad de Negocio:</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" CssClass="form-control"></asp:DropDownList></td>

                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>Año:</h3>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListAnio" runat="server" CssClass="form-control"></asp:DropDownList></td>

                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" Text="EXPORTAR A EXCEL" OnClick="ButtonExportarExcel_Click" />
                        &nbsp;|&nbsp;
                            <asp:Button ID="ButtonBuscar" class="btn btn-primary" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" ValidationGroup="Items" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <asp:UpdatePanel ID="UpdatePanelGrillaReporte" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="panel-body">

                    <asp:GridView ID="GridViewReporteProductos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridViewReporteProductos_PageIndexChanging" PageSize="50">
                        <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                        <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay Informacion con los parametros seleccionados!  
                        </EmptyDataTemplate>

                        <Columns>

                            <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="20%" />
                            <asp:TemplateField HeaderText="Locacion" ItemStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocacion" runat="server" Text='<%# GetLocacion(Eval("LocacionId")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Tecnica" ItemStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:Label ID="lblTecnica" runat="server" Text='<%# GetTecnica(Eval("TipoServicioId")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Costo" HeaderText="Costo" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Margen" HeaderText="Margen" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" ItemStyle-Width="10%" />

                        </Columns>

                    </asp:GridView>

                </div>
                <%--  --%>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</asp:Content>
