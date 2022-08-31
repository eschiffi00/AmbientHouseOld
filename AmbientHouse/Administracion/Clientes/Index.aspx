<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Administracion.Clientes.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Clientes</h3>
            <br />
        </div>
        <div class="panel panel-primary">

            <div class="panel-body">

                <table style="width: 100%;">
                    <tr>
                        <td>Nombre o Razon Social:</td>
                        <td>
                            <asp:TextBox ID="TextBoxDescripcionBuscador" class="form-control" runat="server" Width="100%"></asp:TextBox></td>
                        <td>&nbsp;</td>
                    </tr>
                     <tr>
                        <td>CUIT/DNI:</td>
                        <td>
                            <asp:TextBox ID="TextBoxCUITDNIBuscador" class="form-control" runat="server" Width="200px" MaxLength="11"></asp:TextBox></td>
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
            <asp:UpdatePanel ID="UpdatePanelGrillaClientes" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%;">

                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Cliente" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                                &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>

                            <td>

                                <asp:GridView ID="GridViewClientes" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewClientes_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Clientes con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                        <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre" SortExpression="ApellidoNombre" />
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" />
                                        <asp:BoundField DataField="CondicionIva" HeaderText="IVA" SortExpression="CondicionIva" />
                                        <asp:BoundField DataField="CUILCUIT" HeaderText="CUIT" SortExpression="CUILCUIT" />
                                         <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Administracion/Clientes/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
