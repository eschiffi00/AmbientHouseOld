<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Proveedores.Editar" %>

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
                        Agregar/Editar Proveedores<br />
                    </div>
                    <div class="panel-body">
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Razon Social: *</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxRazonSocial" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DetalleRequired" runat="server" ControlToValidate="TextBoxRazonSocial" Display="Dynamic" ErrorMessage="Razon Social es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Nombre de Fantasia:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNombreFantasia" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>CUIT (Sin guiones): *</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCuit" runat="server" class="form-control" MaxLength="11" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CuitRequired" runat="server" ControlToValidate="TextBoxCuit" Display="Dynamic" ErrorMessage="CUIT es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Items"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LabelCuitRepetido" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>CBU:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCbu" runat="server" class="form-control" MaxLength="22" Width="300px"></asp:TextBox>
                                    <asp:Label ID="LabelCBUError" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>NRO. Cliente:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroCliente" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Telefono:</h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxTelefono" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Propio:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListPropio" runat="server" class="form-control" Width="200px">
                                        <asp:ListItem>Si</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Condicion Iva:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCondicionIva" runat="server" class="form-control" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                             <tr>
                                <td>
                                    <h3>Tipo Retencion:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListTipoRetencion" runat="server" class="form-control" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Formas de Pagos:</h3>
                                </td>
                                <td>

                                    <asp:DropDownList ID="DropDownListFormasdePago" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">&lt;Seleccione una Unidad de Negocio&gt;</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregarFormadePago" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregarFormadePago_Click" />
                                    &nbsp;|&nbsp;<asp:Button ID="ButtonQuitarFormadePago" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitarFormadePago_Click" />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanelFP" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table style="width: 100%;">


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="LabelErrores2" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                                    <td>&nbsp;</td>
                                                </tr>


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>

                                                        <asp:GridView ID="GridViewFP" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#ffffcc" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="FormadePagoId" HeaderText="Nro. Item" SortExpression="FormadePagoId" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                            </Columns>

                                                        </asp:GridView>

                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>

                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ButtonAgregarFormadePago" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ButtonQuitarFormadePago" EventName="Click" />
                                        </Triggers>

                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Unidad Negocio:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListUnidadNegocio" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">&lt;Seleccione una Unidad de Negocio&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregarUnidadesNegocios" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregarUnidadesNegocios_Click" />
                                    &nbsp;|&nbsp;<asp:Button ID="ButtonQuitarUnidadesNeocios" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitarUnidadesNeocios_Click" />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanelUN" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table style="width: 100%;">


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="LabelErrores" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                                    <td>&nbsp;</td>
                                                </tr>


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>

                                                        <asp:GridView ID="GridViewUN" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#ffffcc" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="UnidadNegocioId" HeaderText="Nro. Item" SortExpression="UnidadNegocioId" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                            </Columns>

                                                        </asp:GridView>

                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>

                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ButtonAgregarUnidadesNegocios" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ButtonQuitarUnidadesNeocios" EventName="Click" />
                                        </Triggers>

                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>Rubro:</h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListRubros" runat="server" class="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">&lt;Seleccione Un Rubro&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregarRubroProveedor" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregarRubroProveedor_Click" />
                                    &nbsp;|&nbsp;<asp:Button ID="ButtonQuitarRubroProveedor" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitarRubroProveedor_Click" />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanelRP" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table style="width: 100%;">


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="LabelErrores1" runat="server" class="form-control" Width="100%" CssClass="text-center" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label></td>
                                                    <td>&nbsp;</td>
                                                </tr>


                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>

                                                        <asp:GridView ID="GridViewRP" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#ffffcc" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBoxElementoSeleccionado" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="RubroId" HeaderText="Nro. Item" SortExpression="RubroId" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                            </Columns>

                                                        </asp:GridView>


                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ButtonQuitarRubroProveedor" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ButtonAgregarRubroProveedor" EventName="Click" />
                                        </Triggers>
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
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
