<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/Ambient.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Operacion.DesgustacionDetalle.Index" %>
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
                        <asp:Button ID="ButtonExportarExcel" runat="server" Text="Exportar Excel" class="btn btn-warning" OnClick="ButtonExportarExcel_Click" />&nbsp;|&nbsp;
                       <asp:Button ID="ButtonVolver" runat="server" class="btn btn-outline-primary" Text="Volver" OnClick="ButtonVolver_Click" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaDegustaciones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewDegustacion" runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewDegustacion_PageIndexChanging">
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
                                        <asp:BoundField DataField="NroComensal" HeaderText="# Comensal" SortExpression="NroComensal" />
                                        <asp:BoundField DataField="FechaEvento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Evento" SortExpression="FechaEvento" />
                                        <asp:BoundField DataField="EstadoEvento" HeaderText="Cerrado/Por Cerrar" SortExpression="EstadoEvento" />
                                        <asp:BoundField DataField="CantidadInvitados" HeaderText="Cant. Invitados" SortExpression="CantidadInvitados" />
                                        <asp:BoundField DataField="CaracteristicaDescripcion" HeaderText="Caracteristicas" SortExpression="CaracteristicaDescripcion" />
                                        <asp:BoundField DataField="LocacionDescripcion" HeaderText="Locacion" SortExpression="LocacionDescripcion" />
                                        <asp:BoundField DataField="TipoEventoDescripcion" HeaderText="Tipo" SortExpression="TipoEventoDescripcion" />
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentario" SortExpression="Comentarios" />

                                        <asp:BoundField DataField="Mail" HeaderText="Correo" SortExpression="Mail" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                                        <asp:BoundField DataField="EmpleadoApellidoyNombre" HeaderText="Ejecutivo" SortExpression="EmpleadoApellidoyNombre" />
                                        <asp:BoundField DataField="EstadoDescripcion" HeaderText="Estado" SortExpression="EstadoDescripcion" />
                                         


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
