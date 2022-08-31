<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.TipoComprobantes.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
                        Agregar/Editar Tipo Comprobantes
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
                                    <h3>Descripcion:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Detalle es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
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
                                    <h3>Impuestos:</h3>
                                </td>
                                <td>

                                    <asp:DropDownList ID="DropDownListImpuestos" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">&lt;Sin Impuestos&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td><asp:Button ID="ButtonAgregar" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregar_Click" />
                                    &nbsp;|&nbsp;<asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitar_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanelGrillaImpuestos" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridViewImpuestos" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay  Impuestos con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>

                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                    <asp:TemplateField>

                                                        <ItemTemplate>

                                                            <asp:CheckBox ID="CheckBoxQuitarImpuestos" runat="server" />
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" class="btn btn-info" OnClick="ButtonAceptar_Click" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" class="btn btn-default" OnClick="ButtonVolver_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
