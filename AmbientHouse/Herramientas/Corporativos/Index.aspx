<%@ Page Title="" Language="C#" MasterPageFile="~/AppShared/MasterPage/AmbientHouse.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AmbientHouse.Herramientas.Corporativos.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">
            Herramientas<br />
        </div>
        <div class="panel-body">
         
            <asp:Button ID="ButtonNuevo" runat="server" class="btn btn-info" Text="+ Agregar Archivos" OnClick="ButtonNuevo_Click" />
            &nbsp;|&nbsp;<asp:Button ID="ButtonNuevaCategoria" runat="server" Text="Nueva Carpeta" class="btn btn-info" OnClick="ButtonNuevaCategoria_Click" />
            &nbsp;|&nbsp;<asp:Button ID="ButtonVolver" runat="server" class="btn btn-default" OnClick="ButtonVolver_Click" Text="Volver" />
            <br />
            <table style="width: 100%;">

                <tr>
                    <td>

                       
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>

                    <td>
                        <asp:UpdatePanel ID="UpdatePanelGrillaHerramientas" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>


                                  <asp:GridView ID="GridViewHerramientas"  runat="server" CssClass="table table-bordered bs-table" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No se Encontraron Registros" ForeColor="#333333" GridLines="None" Width="100%" PageSize="25" AllowPaging="True" OnPageIndexChanging="GridViewHerramientas_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#2E64FE" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <EmptyDataTemplate>
                                        ¡No hay Locaciones con los parametros seleccionados!  
                                    </EmptyDataTemplate>

                                    <Columns>

                                        <asp:BoundField DataField="Id" HeaderText="Nro. Item" SortExpression="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="Carpeta" HeaderText="Categoria" SortExpression="Carpeta" />
                                        <asp:HyperLinkField DataNavigateUrlFormatString="~/Herramientas/Corporativos/VisualizaArchivo.aspx?Id={0}" DataNavigateUrlFields="Id" Text="Descargar" />


                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="ButtonEliminarArchivo" runat="server" class="btn btn-danger" OnClick="ButtonEliminarArchivo_Click" Text="Eliminar" />
                                            </ItemTemplate>
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
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinksContainer" runat="server">
</asp:Content>
