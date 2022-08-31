<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Administracion.FacturasClientes.Editar" %>

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
                    <asp:UpdatePanel ID="UpdatePanelFacturas" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="panel-heading">
                                Agregar/Editar Facturas<br />
                            </div>
                            <div class="panel-body">

                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <h4>Empresa:</h4>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListEmpresas" runat="server" class="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="3">&lt;Seleccionar un Empresa&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>Cliente:</h4>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListCliente" runat="server" class="form-control" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCliente_SelectedIndexChanged">
                                                <asp:ListItem Value="null">&lt;Seleccionar un Cliente&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>Presupuestos:</h4>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListPresupuestos" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>Tipo Comprobante:</h4>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListTipoComprobante" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <h4>Nro. Factura:</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNroFactura" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNroFactura" runat="server" ControlToValidate="TextBoxNroFactura" Display="Dynamic"
                                                ErrorMessage="Nro Factura es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <h4>Fecha:</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" AutoComplete="true" MaskType="Date" TargetControlID="TextBoxFecha" CultureName="en-nz" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFecha" runat="server" ControlToValidate="TextBoxFecha" Display="Dynamic"
                                                ErrorMessage="Fecha es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>


                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:GridView ID="GridViewFacturasDetalle" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GridViewFacturasDetalle_RowDataBound" OnRowCommand="GridViewFacturasDetalle_RowCommand">
                                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Cheques con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" HeaderStyle-Width="5%">

                                                        <HeaderStyle Width="5%" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%" HeaderText="Descripcion">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TextBoxDescripcion" runat="server" CssClass="form-control" HeaderText="Descripcion"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" />
                                                        <HeaderStyle Width="55%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%" HeaderText="Importe">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TextBoxImporte" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" />
                                                        <HeaderStyle Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%" HeaderText="Grabado">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="DropDownListGrabado" runat="server" CssClass="form-control">
                                                                <asp:ListItem>SI</asp:ListItem>
                                                                <asp:ListItem>NO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" />
                                                        <HeaderStyle Width="10%" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%" HeaderText="Cantidad">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TextBoxCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" />
                                                        <HeaderStyle Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="150px" ControlStyle-Width="100%">
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonAgregar" runat="server" Text=" + " class="btn btn-success" CommandName="Agregar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            <asp:Button ID="ButtonQuitar" runat="server" Text="Quitar" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100%" />
                                                        <HeaderStyle Width="10%" />
                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>
                                            <asp:GridView ID="GridViewFacturaDetalleVer" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%">
                                                <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Cheques con los parametros seleccionados!  
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" HeaderStyle-Width="5%" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-Width="55%" />
                                                    <asp:BoundField DataField="ImporteStr" HeaderText="Importe" SortExpression="ImporteStr" HeaderStyle-Width="10%" />
                                                    <asp:BoundField DataField="GrabadoStr" HeaderText="Grabado" SortExpression="Grabado" HeaderStyle-Width="10%" />
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" HeaderStyle-Width="10%" />

                                                </Columns>

                                            </asp:GridView>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 5%">&nbsp;</td>
                                                    <td style="width: 55%"></td>
                                                    <td style="width: 10%">
                                                        <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control" Width="100%" ReadOnly="true"></asp:TextBox></td>
                                                    <td style="width: 10%">&nbsp;</td>
                                                    <td style="width: 10%">&nbsp;</td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>

                                </table>


                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" ValidationGroup="Items" OnClick="ButtonAceptar_Click" class="btn btn-info" />
                <asp:Button ID="ButtonVolver" runat="server" Text="Volver" OnClick="ButtonVolver_Click" class="btn btn-default" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
