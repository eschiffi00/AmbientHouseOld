<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Adicionales.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Adicionales<br />
        </div>
        <div class="panel panel-primary">

            <div class="panel-body">

                <table style="width: 100%;">
                    <tr>
                        <td>Nro. Item o Descripcion:</td>
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
                        <td>Proveedores:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListProveedores" class="form-control" runat="server" AppendDataBoundItems="True" Width="100%">
                                <asp:ListItem Value="null">&lt;Seleccione un Proveedor&gt;</asp:ListItem>
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
                        <td>Salon:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListSalones" class="form-control" runat="server" AppendDataBoundItems="True" Width="100%">
                                <asp:ListItem Value="null">&lt;Seleccione un Salon&gt;</asp:ListItem>
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
                        <td>Unidad Negocio:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListUnidadNegocio" class="form-control" runat="server" AppendDataBoundItems="True" Width="100%">
                                <asp:ListItem Value="null">&lt;Seleccione Unidad Negocio&gt;</asp:ListItem>
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
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Adicionales" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                        &nbsp;|&nbsp; 
                        <asp:Button ID="ButtonExportarExcel" runat="server" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" Text="EXPORTAR A EXCEL" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaAdicionales" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewAdicionales" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewAdicionales_RowCommand" OnRowDataBound="GridViewAdicionales_RowDataBound">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Rubro" HeaderText="Unidad de Negocios" SortExpression="Rubro" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" SortExpression="Proveedor" />
                                        <asp:BoundField DataField="Locacion" HeaderText="Locacion" SortExpression="Locacion" />
                                        <asp:BoundField DataField="SoloMayoresDescripcion" HeaderText="Edades" SortExpression="SoloMayoresDescripcion" />
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
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Adicionales/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/TipoCatering/RelacionarAdicionales.aspx?Id={0}" ControlStyle-CssClass="btn btn-default" DataNavigateUrlFields="Id" Text="Agregar Experiencias">
                                            <ControlStyle CssClass="btn btn-default" />
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
