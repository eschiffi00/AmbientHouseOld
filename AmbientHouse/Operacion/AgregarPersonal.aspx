<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="AgregarPersonal.aspx.cs" Inherits="AmbientHouse.Operacion.AgregarPersonal" %>

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
                        Agregar/Editar Personal Eventos
                    </div>
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
                                    <h3>Tipo Empleado:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoEmpleado" runat="server" class="form-control" AppendDataBoundItems="True" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoEmpleado_SelectedIndexChanged">
                                        <asp:ListItem Value="0">&lt;Seleccionar Tipo Empleado&gt;</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    <h3>Empleados:</h3>
                                </td>
                                <td>

                                    <asp:DropDownList ID="DropDownListEmpleados" runat="server" class="form-control" AppendDataBoundItems="True" Width="100%">
                                        <asp:ListItem Value="0">&lt;Seleccionar Empleado&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregar" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregar_Click" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridViewEmpleadosEventos" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewEmpleadosEventos_RowCommand">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay  Impuestos con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>

                                                    <asp:BoundField DataField="EmpleadoId" HeaderText="Nro. Empleado" SortExpression="EmpleadoId" />
                                                    <asp:BoundField DataField="EmpleadoApellidoNombre" HeaderText="Empleado" SortExpression="EmpleadoApellidoNombre" />
                                                    <asp:BoundField DataField="TipoEmpleadoDescripcion" HeaderText="Tipo Empleado" SortExpression="TipoEmpleadoDescripcion" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar" CommandName="QuitarItem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>
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
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-outline-primary" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
