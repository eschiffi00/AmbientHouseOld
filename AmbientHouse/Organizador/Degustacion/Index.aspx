<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Organizador.Degustacion.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
       <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Degustacion</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Degustacion" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaDegustaciones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <asp:GridView ID="GridViewDegustacion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewDegustacion_PageIndexChanging" OnRowCommand="GridViewDegustacion_RowCommand" OnRowDataBound="GridViewDegustacion_RowDataBound">

                                    <AlternatingRowStyle BackColor="#EBEBEB" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Degustacion con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro Item" SortExpression="Id" />

                                        <asp:BoundField DataField="FechaDegustacion" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaDegustacion" />

                                        <asp:BoundField DataField="HoraCorporativo" HeaderText="Hora Corp." SortExpression="HoraCorporativo" />
                                        <asp:BoundField DataField="HoraSocial" HeaderText="Hora Soc." SortExpression="HoraSocial" />
                                        <asp:BoundField DataField="LocacionDescripcion" HeaderText="Locacion" SortExpression="LocacionDescripcion" />
                                        <asp:TemplateField HeaderText="Conf. Tecnica">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButtonEstadoTecnica" runat="server" Height="30px" Width="30px" CommandName="EstadoTecnica" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Conf. Ambientacion">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButtonEstadoAmbientacion" runat="server" Height="30px" Width="30px" CommandName="EstadoAmbientacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Estado" ControlStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="DropDownListEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderStyle-Width="80px" ControlStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn btn-warning" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /></td>
                                               
                                            </ItemTemplate>
                                            <ControlStyle Width="100px" />
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>


                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Organizador/Degustacion/Editar.aspx?Id={0}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="Id" Text="Editar">
                                            <ControlStyle CssClass="btn btn-info" />
                                        </asp:HyperLinkField>

                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Organizador/DegustacionDetalle/Index.aspx?Id={0}" ControlStyle-CssClass="btn btn-danger" DataNavigateUrlFields="Id" Text="Ver Comensales">
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
