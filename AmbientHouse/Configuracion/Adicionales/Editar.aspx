<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="AmbientHouse.Configuracion.Adicionales.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
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
                        <h3>Adicionales</h3>
                        <br />
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
                                    <h3>
                                        <asp:Label ID="Label3" runat="server" Text="Unidad de Negocios:"></asp:Label></h3>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListUnidadNegocios" runat="server" class="form-control" OnSelectedIndexChanged="DropDownListUnidadNegocios_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" Width="100%">
                                        <asp:ListItem Value="0">&lt;Seleccionar Unidad de Negocio&gt;</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelLocaciones" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListLocaciones" runat="server" class="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="0">&lt;Todos&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="UpdatePanelProveedores" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListProveedores" runat="server" class="form-control" AppendDataBoundItems="true">
                                                <asp:ListItem Value="0">&lt;Todos&gt;</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>
                                        <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label></h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescripcion" class="form-control" runat="server" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="TextBoxDescripcion" Display="Dynamic" ErrorMessage="Descripcion es requerido." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Adicionales"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>
                                        <asp:Label ID="Label1" runat="server" Text="Precio:"></asp:Label></h3>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-control"></asp:TextBox>
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
                                    
                                    <asp:CheckBox ID="CheckBoxActivo" runat="server" class="form-check" Checked="True" Text="Visible en el Cotizador?" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxSoloAdultos" runat="server" class="form-check" Checked="True" Text="Solo Adultos" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxCantidades" runat="server" AutoPostBack="True" Text="Requiere Definir Cantidades Diferenciales" OnCheckedChanged="CheckBoxCantidades_CheckedChanged" />
                                    <asp:UpdatePanel ID="UpdatePanelCantidades" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <asp:Panel ID="PanelRequierenCantidad" runat="server">

                                                <asp:RadioButton ID="RadioButtonRequiereCantidad" runat="server" AutoPostBack="True" Checked="True" GroupName="Cantidad" Text="Requiere Cantidad" />
                                                <br />
                                                <asp:RadioButton ID="RadioButtonRequieraCantidadRango" runat="server" AutoPostBack="True" GroupName="Cantidad" Text="Requiere Cantidad Rango" />

                                            </asp:Panel>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="CheckBoxCantidades" EventName="CheckedChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td></td>
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
                                    <asp:UpdatePanel ID="UpdatePanelTipoCateringParaAgregar" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListTipoCateringAgregar" runat="server" class="form-control" Width="300px">
                                            </asp:DropDownList>
                                        </ContentTemplate>

                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ButtonAgregar" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ButtonQuitar" EventName="Click" />
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
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAgregar" runat="server" class="btn btn-success" Text="Agregar" OnClick="ButtonAgregar_Click" />
                                    &nbsp; &nbsp;<asp:Button ID="ButtonQuitar" runat="server" class="btn btn-danger" Text="Quitar" OnClick="ButtonQuitar_Click" />
                                    &nbsp; &nbsp;<asp:Label ID="LabelMensaje" runat="server" Text="" ForeColor="#ff3300" Font-Bold="true"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelGrillaTipoCatering" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridViewTipoCatering" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#ffffcc" />
                                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                <EmptyDataTemplate>
                                                    ¡No hay Experiencias para el Adicional Seleccionado!  
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                                                    <asp:TemplateField>

                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBoxQuitar" runat="server" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>

                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ButtonAgregar" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="ButtonQuitar" EventName="Click" />
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
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-info" Text="Aceptar" ValidationGroup="Adicionales" OnClick="ButtonAceptar_Click" />
                                    <asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>--%>
