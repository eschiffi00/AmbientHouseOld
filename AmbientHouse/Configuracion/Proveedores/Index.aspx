<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Proveedores.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Proveedores</h3>
            <br />
        </div>
        <div class="panel panel-primary">


            <div class="panel-body">

                <table style="width: 100%;">
                    <tr>
                        <td>Razon Social:</td>
                        <td>
                            <asp:TextBox ID="TextBoxRazonSocialBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                     <tr>
                        <td>CUIT:</td>
                        <td>
                            <asp:TextBox ID="TextBoxCuitBuscador" class="form-control" runat="server" Width="100%" MaxLength="11"></asp:TextBox></td>
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

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Proveedores" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver"  OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaProveedores" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewProveedores" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewProveedores_PageIndexChanging">
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

                                        <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                        <asp:BoundField DataField="CUIT" HeaderText="CUIT" SortExpression="CUIT" />
                                       <%-- <asp:BoundField DataField="RubroDescripcion" HeaderText="Rubro" SortExpression="RubroDescripcion" />
                                        <asp:BoundField DataField="UnidadNegocioDescripcion" HeaderText="Un. Negocio" SortExpression="UnidadNegocioDescripcion" />--%>
                                        <asp:BoundField DataField="NombreFantasia" HeaderText="Nombre Fantasia" SortExpression="NombreFantasia" />
                                        <asp:BoundField DataField="CBU" HeaderText="CBU" SortExpression="CBU" />
                                        <asp:BoundField DataField="NroCliente" HeaderText="Nro. Cliente" SortExpression="NroCliente" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Nro. Tel." SortExpression="Telefono" />

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Proveedores/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
