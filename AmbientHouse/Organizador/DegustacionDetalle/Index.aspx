<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Organizador.DegustacionDetalle.Index" %>

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
                        <asp:Button ID="ButtonExportarExcel" runat="server" Text="Exportar Excel" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" />
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
                                        <asp:BoundField DataField="SegmentoDescripcion" HeaderText="Seg" SortExpression="SegmentoDescripcion" />

                                        <asp:BoundField DataField="Empresa" HeaderText="Empresa" SortExpression="Empresa" />
                                        <asp:BoundField DataField="Comensal" HeaderText="Comensal" SortExpression="Comensal" />

                                        <asp:BoundField DataField="NroMesa" HeaderText="# Mesa" SortExpression="NroMesa" />


                                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="# Comensal" ControlStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxComensal" runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="150px" />
                                            <HeaderStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                        <asp:BoundField DataField="EstadoEvento" HeaderText="Cerrado/Por Cerrar" SortExpression="EstadoEvento" />
                                        <asp:BoundField DataField="CantidadInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInvitados" />
                                        <asp:BoundField DataField="CaracteristicaDescripcion" HeaderText="Caracteristicas" SortExpression="CaracteristicaDescripcion" />
                                        <asp:BoundField DataField="LocacionDescripcion" HeaderText="Locacion" SortExpression="LocacionDescripcion" />
                                        <asp:BoundField DataField="TipoEventoDescripcion" HeaderText="Tipo" SortExpression="TipoEventoDescripcion" />

                                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Comentario" ControlStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ControlStyle Width="300px" />
                                            <HeaderStyle Width="300px" />
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="Mail" HeaderText="Correo" SortExpression="Mail" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                                        <asp:BoundField DataField="EmpleadoApellidoyNombre" HeaderText="Ejecutivo" SortExpression="EmpleadoApellidoyNombre" />


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
