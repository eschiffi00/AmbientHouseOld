<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Seguridad.Usuarios.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Usuarios<br />
        </div>
       
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaUsuarios" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewUsuarios" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewUsuarios_RowCommand" OnRowDataBound="GridViewUsuarios_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridViewUsuarios_PageIndexChanging" PageSize="25">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Usuarios con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>
                                        <asp:BoundField DataField="EmpleadoId" HeaderText="Nro. Empleado" SortExpression="EmpleadoId" ControlStyle-Width="30%"  />
                                         <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" ControlStyle-Width="30%" />
                                       
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Estado" ControlStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="100%" />
                                            <HeaderStyle Width="20%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="100px" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                     
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
