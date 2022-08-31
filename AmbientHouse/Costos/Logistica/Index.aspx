<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Costos.Logistica.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Costos Logistica</h3>
            <br />
        </div>
        <div class="panel-body">

            <div class="panel-body">

                <table style="width: 100%;">
                    <tr>
                        <td>Tipo Logistica:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListTipoLogisticaBuscador" runat="server" class="form-control" Width="100%" AppendDataBoundItems ="true" >
                                 <asp:ListItem Value="null">&lt;Seleccione un Tipo Logistica&gt;</asp:ListItem>
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
                        <td>Localidad:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListLocalidadBuscador" runat="server" class="form-control" Width="100%" AppendDataBoundItems ="true" >
                                 <asp:ListItem Value="null">&lt;Seleccione una Localidad&gt;</asp:ListItem>
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
                        <td>Cant. Invitados:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListCantidadInvitadosBuscador" runat="server" class="form-control" Width="100%" AppendDataBoundItems ="true" >
                                <asp:ListItem Value="null">&lt;Seleccione Cant. Invitados&gt;</asp:ListItem>
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
                        <td>Tipo Evento:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListTipoEvento" runat="server" class="form-control" Width="100%" AppendDataBoundItems ="true" >
                                <asp:ListItem Value="null">&lt;Seleccione un Tipo Evento&gt;</asp:ListItem>
                            </asp:DropDownList>
                        </td>
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
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Lista de Precios Logistica" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaCostoLogistica" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewCostoLogistica" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewCostoLogistica_PageIndexChanging" OnRowCommand="GridViewCostoLogistica_RowCommand" OnRowDataBound="GridViewCostoLogistica_RowDataBound">
                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Costos con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />

                                        <asp:BoundField DataField="ConceptoDescripcion" HeaderText="Concepto" SortExpression="ConceptoDescripcion" />

                                        <asp:BoundField DataField="LocalidadDescripcion" HeaderText="Localidad" SortExpression="LocalidadDescripcion" />
                                        <asp:BoundField DataField="CantidadInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInvitados" />

                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Costo $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxCosto" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Margen %" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxMargen" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="100px" HeaderText="Precio $" ControlStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control"></asp:TextBox>
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

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Costos/Logistica/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
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
