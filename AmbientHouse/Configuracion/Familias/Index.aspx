<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Configuracion.Familias.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3>Familias</h3>
            <br />
        </div>
        <div class="panel-body">
            <table style="width: 100%;">

                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="ButtonNuevo" runat="server" Text="+Agregar Familia" class="btn btn-info" OnClick="ButtonNuevo_Click" />
                        &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" Text="Volver" OnClick="ButtonVolver_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaFamilias" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridViewFamilias" runat="server"  CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>
                                    <Columns>

                                        <asp:BoundField DataField="CategoriaItemId" HeaderText="Categoria" SortExpression="CategoriaItemId" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                                        <asp:BoundField DataField="Subtitulo" HeaderText="Subtitulo" SortExpression="Subtitulo" />
                                        <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario" />
                                        <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
                                        <asp:BoundField DataField="Fantasia" HeaderText="Fantasia" SortExpression="Fantasia" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />

                          
                                           <asp:HyperLinkField DataNavigateUrlFormatString="~/Configuracion/Familias/Editar.aspx?GrupoId={0}&CategoriaItemId={1}" ControlStyle-CssClass="btn btn-info" DataNavigateUrlFields="GrupoId,CategoriaItemId" Text="Editar" >
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
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
